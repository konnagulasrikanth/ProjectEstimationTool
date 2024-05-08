using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Tls;
using ProjectEstimationTool.Models;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectEstimationTool
{
    public partial class Timeline : UserControl
    {
        ProjectEstimationToolMasterContext db;
        public int TimelineID { get; set; }
        BindingList<ProjectEstimationTool.Models.Timeline> timelines;

        private bool defaultTimelineAdded = false;
        private Timeline td;
        private int MaxMonth;
        public ProjectEstimationTool.Models.Timeline tm;
        private bool defaultsAdded = false; // Add this field to keep track of whether defaults have been added



        public Timeline()
        {
            InitializeComponent();
            db = new ProjectEstimationToolMasterContext();
            timelines = new BindingList<ProjectEstimationTool.Models.Timeline>();
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }

        public void LoadData()
        {
            try
            {
                // Fetch timeline data from the database
                var timel = db.Timeline.Where(t => t.ProjectId == Form1.projectid).ToList();

                // Clear the existing data in the timelines list
                timelines.Clear();

                // Add each timeline retrieved from the database to the timelines list
                foreach (var t in timel)
                {
                    timelines.Add(t);
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = timelines;
                // Calculate the total EffHrs
                var hrs = (from t in db.Timeline
                           where t.ProjectId == Form1.projectid
                           select t.EffHrs).Sum();
                label5.Text = hrs.ToString();

                // Calculate the maximum MM for the project
                var maxMmForProject = timel.Select(t => t.Mm + t.Lag).DefaultIfEmpty().Max();
                label6.Text = maxMmForProject.ToString();

                // Apply row color based on the phase
                SetRowColorBasedOnPhase();
                // Make the first four rows of the "Phasename" column non-editable
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index < 4)
                    {
                        // Make the cell non-editable
                        row.Cells["Phasename"].ReadOnly = true;
                    }
                }

                // Enable adding new rows
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading data is not happening. Please check!");
            }
        }

        private void Timeline_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            //UpdateTimelines();
            var maxMmForProject = db.Timeline
            .Where(p => p.ProjectId == Form1.projectid)
            .Select(p => p.Mm + p.Lag)
            .DefaultIfEmpty()
            .Max();
            AddColumnsPermanently(maxMmForProject);
            var TimeLines = db.Timeline.ToList().Where(p => p.ProjectId == Form1.projectid);
            foreach (var TimeLine in TimeLines)                                                   //Adding the data if existed when the screen is opened
            {
                timelines.Add(TimeLine);
            }
            updateTimeline();
            UpdateDemoDatesIfRequired(maxMmForProject);
            AddDefaultTimelineEntries();
            GetMonthlyHours();
            SetRowColorBasedOnPhase();
        }
        public void AddTimeLine(string Phase, int Effhours, int Resreq, int MM, int Lags, bool isDefault = false)
        {
            try
            {
                ProjectEstimationTool.Models.Timeline Adddata = new ProjectEstimationTool.Models.Timeline
                {
                    //Functionality = Functionalityname,
                    ProjectId = Form1.projectid,
                    Phase = Phase,
                    EffHrs = Effhours,
                    ResReq = Resreq,
                    Mm = MM,
                    Lag = Lags,
                };
                timelines.Add(Adddata);
                if (isDefault)
                {
                    db.Timeline.Add(Adddata);
                    db.SaveChanges();
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddDefaultTimelineEntries()
        {
            try
            {
                var scopeEfforts = db.ScopeAndEffort.Where(se => se.ProjectId == Form1.projectid).GroupBy(se => se.ProjectId)
                         .Select(g => new
                         {
                             Bahrs = g.Sum(se => se.BafinalHrs),                                                                         //To calculate the total Ba hours,Dev hours, Qa hours from the scope and effort table 
                             Devhrs = g.Sum(se => se.DevFinalHrs),                                                                       // for that proejct id
                             Qahrs = g.Sum(se => se.QafinalHrs),
                             operations = g.Sum(se => se.NumberOfOperations)

                         }).FirstOrDefault();
                if (!defaultTimelineAdded)
                {
                    bool defaultEntriesExist = db.Timeline.Where(tl => tl.ProjectId == Form1.projectid).Any(tl => tl.Phase.Contains("Kickoff/Demo") || tl.Phase.Contains("Requirements") || tl.Phase.Contains("Build&Design") || tl.Phase.Contains("QA"));

                    if (!defaultEntriesExist)                                                                                              //Checking the first four values exist or not if not then Add the rows and viceversa
                    {

                        if (scopeEfforts != null)
                        {
                            int monthlyHours = GetMonthlyHours(); // Get weekly hours from database 
                            double mmRequirements = (double)scopeEfforts.Bahrs / monthlyHours;
                            double mmBuildDesign = (double)scopeEfforts.Devhrs / monthlyHours;
                            double mmQA = (double)scopeEfforts.Qahrs / monthlyHours;

                            AddTimeLine("Kickoff/Demo/Setup", 0, 0, 1, 0, true);
                            AddTimeLine("Requirement", (int)scopeEfforts.Bahrs, 1, Convert.ToInt32(mmRequirements), 0, true);
                            AddTimeLine("Build&Design", (int)scopeEfforts.Devhrs, 1, Convert.ToInt32(mmBuildDesign), Convert.ToInt32(mmRequirements), true);
                            AddTimeLine("QA", (int)scopeEfforts.Qahrs, 1, Convert.ToInt32(mmQA), Convert.ToInt32(mmBuildDesign) + Convert.ToInt32(mmRequirements), true);
                            AddTimeLine("PM", 0, 0, 0, 0, true);
                            AddTimeLine("Architect-Lead", 0, 0, 0, 0, true);
                            AddTimeLine("Infra", 0, 0, 0, 0, true);
                            AddTimeLine("Mgmt.", 0, 0, 0, 0, true);
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        if (scopeEfforts != null)                                                                                           // It will uodate Ba hours ,QA Hours,Dev hours each time screen is loaded for first hours need to be constant
                        {
                            var existingTimelineEntries = db.Timeline
                                .Where(tl => tl.ProjectId == Form1.projectid &&
                                             (tl.Phase.EndsWith("Kickoff/Demo/Setup") ||
                                              tl.Phase.EndsWith("Requirement") ||
                                              tl.Phase.EndsWith("Build&Design") ||
                                              tl.Phase.EndsWith("QA")))
                                .ToList();

                            foreach (var entry in existingTimelineEntries)
                            {

                                switch (entry.Phase)
                                {
                                    case string phaseCase when phaseCase.EndsWith("Kickoff/Demo/Setup"):
                                        break;
                                    case string phaseCase when phaseCase.EndsWith("Requirement"):
                                        entry.EffHrs = ((int)scopeEfforts.Bahrs);
                                        entry.Mm = Convert.ToInt32(CalculateMM(entry.ResReq, "Requirement", entry.EffHrs));
                                        //entry.Lag = 0;
                                        break;
                                    case string phaseCase when phaseCase.EndsWith("Build&Design"):
                                        entry.EffHrs = ((int)scopeEfforts.Devhrs);
                                        entry.Mm = Convert.ToInt32(CalculateMM(entry.ResReq, "Requirement", entry.EffHrs));
                                        //entry.Lag= Convert.ToInt32(CalculateMM(entry.ResReq, "Requirements", entry.Effhrs));
                                        break;
                                    case string phaseCase when phaseCase.EndsWith("QA"):
                                        entry.EffHrs = ((int)scopeEfforts.Qahrs);
                                        entry.Mm = Convert.ToInt32(CalculateMM(entry.ResReq, "Requirement", entry.EffHrs));
                                        //entry.Lag= Convert.ToInt32(CalculateMM(entry.ResReq, "Requirements", entry.Effhrs))+ Convert.ToInt32(CalculateMM(entry.ResReq, "Requirements", entry.Effhrs));
                                        break;
                                }
                            }
                        }
                        else
                        {
                            var existingTimelineEntries = db.Timeline
                               .Where(tl => tl.ProjectId == Form1.projectid &&
                                            (tl.Phase.EndsWith("Kickoff/Demo/Setup") ||
                                             tl.Phase.EndsWith("Requirement") ||
                                             tl.Phase.EndsWith("Build&Design") ||
                                             tl.Phase.EndsWith("QA")))
                               .ToList();

                            foreach (var entry in existingTimelineEntries)
                            {

                                switch (entry.Phase)
                                {
                                    case string phaseCase when phaseCase.EndsWith("Kickoff/Demo/Setup"):
                                        break;
                                    case string phaseCase when phaseCase.EndsWith("Requirement"):
                                        entry.EffHrs = 0;
                                        break;
                                    case string phaseCase when phaseCase.EndsWith("Build&Design"):
                                        entry.EffHrs = 0;
                                        break;
                                    case string phaseCase when phaseCase.EndsWith("QA"):
                                        entry.EffHrs = 0;
                                        break;
                                }
                            }
                            MessageBox.Show("Please enter Scope And Effort field values in Scope And Effort Screen");

                        }

                    }
                }
                defaultTimelineAdded = true;

                db.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void updateTimeline()
        {
            try
            {
                var editdata = timelines.Where(et => et.ProjectId == Form1.projectid).ToList();  //checking Timeline is existing or not
                if (editdata != null)
                {
                    foreach (var updatedata in editdata)
                    {
                        int monthlyHours = db.Productivity.Where(p => p.ProductivityName == "Month" & p.ProjectId == Form1.projectid).Select(p => p.Hours).FirstOrDefault();
                        bool defaultvalues = updatedata.Phase == ("Kickoff/Demo/Setup") || updatedata.Phase == ("Requirement") || updatedata.Phase == ("Build&Design") || updatedata.Phase == ("QA");
                        if (!defaultvalues)
                        {
                            if (monthlyHours != 0)
                            {
                                updatedata.EffHrs = updatedata.ResReq * updatedata.Mm / 4 * monthlyHours;

                                db.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch { }
        }

        public void AddColumnsPermanently(int MMvalue)
        {
            var maxMmPlusLag = db.Timeline
                    .Where(t => t.ProjectId == Form1.projectid)
                    .Select(t => t.Mm + t.Lag)
                    .DefaultIfEmpty()
                    .Max();

            if (maxMmPlusLag > 0)
            {
                int newMaxMmPlusLag = maxMmPlusLag;

                // Removing columns
                for (int i = dataGridView1.Columns.Count - 1; i > 0; i--)
                {
                    if (dataGridView1.Columns[i].Name.StartsWith("WK"))
                    {
                        int columnNumber = int.Parse(dataGridView1.Columns[i].Name.Substring(2));
                        if (columnNumber > newMaxMmPlusLag)
                        {
                            dataGridView1.Columns.RemoveAt(i);
                        }
                    }
                }

                // Adding columns
                for (int i = 1; i <= newMaxMmPlusLag; i++)
                {
                    string columnName = "WK" + i;
                    if (!dataGridView1.Columns.Contains(columnName))
                    {
                        var newColumn = new DataGridViewTextBoxColumn()
                        {
                            Name = columnName,
                            HeaderText = columnName
                        };
                        dataGridView1.Columns.Add(newColumn);
                        newColumn.ReadOnly = true;
                    }
                }
            }

            SetRowColorBasedOnPhase();

        }


        private double CalculateMM(double resource, string phase, double effhrs)
        {
            if (resource <= 0)
            {
                MessageBox.Show("Resource value must be greater than zero. Please enter a valid resource value.");
                return 1; // Default value, you can change this as needed
            }

            double roundedResource = Math.Max(resource, 1); // Ensure resource is at least 1
            int monthlyHours = GetMonthlyHours(); // Get monthly hours from database or other source

            // Ensure monthlyHours is not zero to prevent division by zero
            if (monthlyHours == 0)
                monthlyHours = 1;

            double effHours = effhrs; // Get Effhours from the second column
            double mm;

            // Check if the phase is Build & Design, QA, or Requirements
            if (phase == "Build&Design" || phase == "QA" || phase == "Requirement")
            {
                mm = effHours / (roundedResource * monthlyHours);
            }
            else
            {
                mm = (effHours / (roundedResource * monthlyHours)) + 1;
            }

            return Math.Max(mm, 1); // Ensure mm is at least 1
        }

        private double CalculateResource(double mm, string phase, double effhrs)
        {
            if (mm <= 0)
            {
                MessageBox.Show("MM value must be greater than zero. Please enter a valid MM value.");
                return 1; // Default value, you can change this as needed
            }

            double roundedMM = Math.Max(mm, 1); // Ensure MM is at least 1
            int monthlyHours = GetMonthlyHours(); // Get monthly hours from database or other source

            // Ensure monthlyHours is not zero to prevent division by zero
            if (monthlyHours == 0)
                monthlyHours = 1;

            double effHours = effhrs; // Get Effhours from the second column
            double resource;

            // Check if the phase is Build & Design, QA, or Requirements
            if (phase == "Build&Design" || phase == "QA" || phase == "Requirement")
            {
                resource = effHours / (roundedMM * monthlyHours);
            }
            else
            {
                resource = (effHours / (roundedMM * monthlyHours)) + 1;
            }

            return Math.Max(resource, 1); // Ensure resource is at least 1
        }

        private double CalculateEffHours(double mm, double resource, string phase, double effhrs)
        {
            if (mm <= 0 || resource <= 0)
            {
                MessageBox.Show("MM and Resource values must be greater than zero. Please enter valid values.");
                return 1; // Default value, you can change this as needed
            }

            int monthlyHours = GetMonthlyHours(); // Get monthly hours from database or other source

            // Ensure monthlyHours is not zero to prevent division by zero
            if (monthlyHours == 0)
                monthlyHours = 1;

            double effHours = effhrs; // Get Effhours from the second column

            // Check if the phase is Build & Design, QA, or Requirements
            if (phase == "Build&Design" || phase == "QA" || phase == "Requirement")
            {
                return effHours;
            }
            else
            {
                double calculatedEffHours = ((mm * resource * monthlyHours)) + 1;
                return Math.Max(calculatedEffHours, 1); // Ensure calculatedEffHours is at least 1
            }
        }
        private int GetMonthlyHours()
        {
            // Implement logic to retrieve monthly hours from the database
            // Placeholder value, replace it with actual logic

            int monthlyHours = db.Productivity
                                            .Where(p => p.ProductivityName == "Month" && p.ProjectId == Form1.projectid)
                                            .Select(p => p.Hours)
                                            .FirstOrDefault();
            return Math.Max(monthlyHours / 4, 1); // Ensure monthlyHours is at least 1
        }

        public void SetRowColorBasedOnPhase()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                object phasesCellValue = row.Cells["Phasename"].Value;
                object mmCellValue = row.Cells["Mmname"].Value;
                object lagCellValue = row.Cells["Lagname"].Value;
                var minMmForProject = db.Timeline.Where(p => p.ProjectId == Form1.projectid && p.Phase != "Kickoff/Demo/Setup").Select(p => p.Lag).DefaultIfEmpty().Min();
                int m = minMmForProject;
                if (phasesCellValue != null && mmCellValue != null && lagCellValue != null)
                {
                    string phase = phasesCellValue.ToString();
                    int lagForRow = Convert.ToInt32(lagCellValue);
                    int mmForRow = Convert.ToInt32(mmCellValue) + 8 + lagForRow;
                    for (int i = lagForRow + 9; i <= mmForRow; i++)
                    {
                        if (i < dataGridView1.Columns.Count)
                        {
                            string kickoffFunctionality = "Kickoff/Demo/Setup";
                            if (phase.Equals(kickoffFunctionality))
                            {

                                row.Cells[minMmForProject + 9].Value = "K";
                                row.Cells[minMmForProject + 9].Style.BackColor = Color.Black;

                            }
                            int demodate1 = db.Demodates.Where(p => p.ProjectId == Form1.projectid).Select(d => d.Demodate1).FirstOrDefault();
                            int demodate2 = db.Demodates.Where(p => p.ProjectId == Form1.projectid).Select(d => d.Demodate2).FirstOrDefault();
                            if (demodate1 > 0 && phase.Equals(kickoffFunctionality))
                            {
                                int demodate1Index = 9 + demodate1 - 1;
                                if (demodate1Index < dataGridView1.Columns.Count)
                                {
                                    row.Cells[demodate1Index].Style.BackColor = Color.Black;
                                    row.Cells[demodate1Index].Style.ForeColor = Color.White;

                                    row.Cells[demodate1Index].Value = "D1";
                                }
                            }

                            if (demodate2 > 0 && phase.Equals(kickoffFunctionality))
                            {
                                int demodate2Index = 9 + demodate2 - 1;
                                if (demodate2Index < dataGridView1.Columns.Count)
                                {
                                    row.Cells[demodate2Index].Style.BackColor = Color.Black;
                                    row.Cells[demodate2Index].Style.ForeColor = Color.White;

                                    row.Cells[demodate2Index].Value = "D2";
                                }
                            }
                            Color color = GetColorForPhase(phase);
                            row.Cells[i].Style.BackColor = color;
                        }
                    }
                }
            }
        
        }


        private Color GetColorForPhase(string phase)
        {
            string PMFunctionality = "PM";
            string ArchFunctionality = "Architect-Lead";
            string InfraFunctionality = "Infra";
            string MgmtFunctionality = "Mgmt.";
            string RequirementsFunctionality = "Requirement";
            string BuildDesignFunctionality = "Build&Design";
            string QAFunctionality = "QA";

            switch (phase)
            {
                case string pmCase when pmCase == PMFunctionality:
                    return Color.Purple;
                case string archCase when archCase == ArchFunctionality:
                    return Color.Indigo;
                case string infraCase when infraCase == InfraFunctionality:
                    return Color.Cyan;
                case string mgmtCase when mgmtCase == MgmtFunctionality:
                    return Color.Brown;
                case string reqCase when reqCase == RequirementsFunctionality:
                    return Color.BurlyWood;
                case string buildCase when buildCase == BuildDesignFunctionality:
                    return Color.DarkOrange;
                case string qaCase when qaCase == QAFunctionality:
                    return Color.DeepPink;
                default:
                    return Color.White; // Default color
            }
            
        }

        private void UpdateTimelines() //this method updates when the scope and effort changes, then in the load of timeline it automatically updated
        {
            var sumOfBafinalHrs = db.ScopeAndEffort.Where(t => t.ProjectId == Form1.projectid).Sum(t => t.BafinalHrs);
            var sumOfDevfinalHrs = db.ScopeAndEffort.Where(t => t.ProjectId == Form1.projectid).Sum(t => t.DevFinalHrs);
            var sumOfQafinalHrs = db.ScopeAndEffort.Where(t => t.ProjectId == Form1.projectid).Sum(t => t.QafinalHrs);

            bool timelineDataExists = db.Timeline.Any(t => t.ProjectId == Form1.projectid);

            if (timelineDataExists)
            {
                var timelinesToUpdate = db.Timeline.Where(t => t.ProjectId == Form1.projectid).ToList();
                var maxMmForProject = db.Timeline.Where(t => t.ProjectId == Form1.projectid).Select(p => p.Mm + p.Lag).Max();
                foreach (var timeline in timelinesToUpdate)
                {
                    if (timeline.Phase.Contains("Requirement"))
                    {
                        timeline.EffHrs = (int)sumOfBafinalHrs;
                    }
                    else if (timeline.Phase.Contains("Build&Design"))
                    {
                        timeline.EffHrs = (int)sumOfDevfinalHrs;
                    }
                    else if (timeline.Phase.Contains("QA"))
                    {
                        timeline.EffHrs = (int)sumOfQafinalHrs;
                    }

                
                    //// calculate new mm based on updated effhrs and existing resreq
                    int weeklyhours = db.Productivity
                        .Where(p => p.ProductivityName == "Week" && p.ProjectId == Form1.projectid)
                        .Select(p => p.Hours)
                        .FirstOrDefault();

                    if (timeline.ResReq != 0 && weeklyhours != 0)
                    {
                        timeline.Mm = (int)Math.Ceiling((double)timeline.EffHrs / (weeklyhours * timeline.ResReq));
                    }
                }

                SetRowColorBasedOnPhase();
                
                // Update the demo dates if required
                db.SaveChanges();
                LoadData();

            }
        }



        private void button10_Click(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ResourceCostingUserControl rc = new ResourceCostingUserControl();
            this.Hide();
            this.Parent.Controls.Add(rc);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void AddNewRowToDatabase(DataGridViewRow newRow)
        {
            try
            {
                // Check if all cell values in the row are not null
                for (int i = 0; i < 5; i++)
                {
                    DataGridViewCell cell = newRow.Cells[i];
                    if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        // If any cell value is null or empty, exit the method
                        return;
                    }
                }
                if (newRow != null)
                {
                    // Create a new EffortType object with values from the new row
                    ProjectEstimationTool.Models.Timeline timeline = new ProjectEstimationTool.Models.Timeline
                    {
                        ProjectId = Form1.projectid,
                        Phase = newRow.Cells["Phasename"].Value.ToString(),
                        EffHrs = Convert.ToInt32(newRow.Cells["EffHrs"].Value),
                        ResReq = Convert.ToInt32(newRow.Cells["ResReq"].Value),
                        Mm = Convert.ToInt32(newRow.Cells["Mmname"].Value),
                        Lag = Convert.ToInt32(newRow.Cells["Lagname"].Value),

                    };

                    // Add the new EffortType object to the database context
                    db.Add(timeline);
                    db.SaveChanges();
                    LoadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;

                // Check if the row index is within the bounds of existing rows
                if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count - 1)
                {
                    // Check if the edited cell is in the Phase column and if the row index is within the first four rows
                    if (columnIndex == dataGridView1.Columns["Phasename"].Index && rowIndex < 4)
                    {
                        MessageBox.Show("Editing phase for the first four rows is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string selectedPhase = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                    // Check if the selected phase is "Requirements" for the first four rows
                    if (selectedPhase == "Requirement")
                    {
                        MessageBox.Show(" phase 'Requirements' is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Check if the selected phase is "Build&Design" for the first four rows
                    if (selectedPhase == "Build&Design")
                    {
                        MessageBox.Show(" phase 'Build&Design' is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Check if the selected phase is "QA" for the first four rows
                    if (selectedPhase == "QA")
                    {
                        MessageBox.Show(" phase 'QA'  is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];

                    // Check if all cell values in the row are not null
                    for (int i = 0; i < 5; i++)
                    {
                        DataGridViewCell cell = row.Cells[i];
                        if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            // If any cell value is null or empty, exit the method
                            return;
                        }
                    }
                    int Timelineid = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
                    var timeline = db.Timeline.FirstOrDefault(p => p.TimelineId == Timelineid);
                    ProjectEstimationTool.Models.Timeline timeline1 = dataGridView1.Rows[rowIndex].DataBoundItem as ProjectEstimationTool.Models.Timeline;

                    if (timeline != null)
                    {
                        DataGridViewCell editedCell = row.Cells[columnIndex];
                        if (editedCell.Value != null && !string.IsNullOrWhiteSpace(editedCell.Value.ToString()))
                        {
                            // Recalculate other values based on the user-entered value
                            switch (columnIndex)
                            {
                                case 2: // Effhr column
                                    RecalculateResReqMm(rowIndex, "EffHrs");
                                    RecalculateEffhrsResReqMm(rowIndex, "EffHrs");
                                    break;
                                case 3: // ResReqs column
                                    RecalculateEffhrsResReqMm(rowIndex, "ResReq");
                                    RecalculateEffhrsMm(rowIndex, "ResReq");
                                    break;
                                case 4: // Mms column
                                    RecalculateResReqMm(rowIndex, "Mmname");
                                    RecalculateResReqEffhrs(rowIndex, "Mmname");
                                    break;
                                default:
                                    break;
                            }
                            UpdateTimelineObject(rowIndex);


                        }
                    }
                    else if (Timelineid == 0)
                    {
                        AddNewRowToDatabase(row);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void UpdateTimelineObject(int rowIndex)
        {
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            var timeline = row.DataBoundItem as ProjectEstimationTool.Models.Timeline;
            ProjectEstimationTool.Models.Timeline Timeline1 = dataGridView1.Rows[rowIndex].DataBoundItem as ProjectEstimationTool.Models.Timeline;
            string affectedPhase;
            if (!TimelineConditions(Timeline1, out affectedPhase))
            {
                // Conditions not met, ask the user to update the affected phase
                var result = MessageBox.Show($"The end week of {affectedPhase} may be affected. Do you want to update it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Update the affected phase
                    UpdateAffectedPhase(affectedPhase, Timeline1);
                }
                else
                {
                    // Inform the user and return
                    MessageBox.Show("Timeline conditions are not met. Please review the timeline before updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (timeline != null)
            {
                timeline.Phase = Timeline1.Phase;
                timeline.EffHrs = Timeline1.EffHrs;
                timeline.ResReq = Timeline1.ResReq;
                timeline.Mm = Timeline1.Mm;
                timeline.Lag = Timeline1.Lag;

                db.SaveChanges();
                SetRowColorBasedOnPhase();
                LoadData();

            }
        }
        private void RecalculateEffhrsResReqMm(int rowIndex, string columnName)
        {
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            double mm = Convert.ToDouble(row.Cells["Mmname"].Value);
            double resReq = Convert.ToDouble(row.Cells["ResReq"].Value);
            double Efforthour = Convert.ToDouble(row.Cells["EffHrs"].Value);
            string phase = row.Cells["Phasename"].Value.ToString(); // Assuming phase information is stored in a cell named "Phase"
            if (columnName == "Mmname")
            {
                double recalculatedEffhrs = CalculateEffHours(mm, resReq, phase, Efforthour);
                row.Cells["EffHrs"].Value = recalculatedEffhrs;
            }
            else if (columnName == "ResReq")
            {
                double recalculatedMm = CalculateMM(resReq, phase, Efforthour);
                row.Cells["Mmname"].Value = recalculatedMm;
            }
        }

        private void RecalculateResReqEffhrs(int rowIndex, string columnName)
        {
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            double mm = Convert.ToDouble(row.Cells["Mmname"].Value);
            double resReq = Convert.ToDouble(row.Cells["ResReq"].Value);
            double Efforthour = Convert.ToDouble(row.Cells["EffHrs"].Value);
            string phase = row.Cells["Phasename"].Value.ToString(); // Assuming phase information is stored in a cell named "Phase"
            if (columnName == "Mmname")
            {
                double recalculatedResReq = CalculateResource(mm, phase, Efforthour);
                row.Cells["ResReq"].Value = recalculatedResReq;
            }
        }

        private void RecalculateResReqMm(int rowIndex, string columnName)
        {
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            double mm = Convert.ToDouble(row.Cells["Mmname"].Value);
            double resReq = Convert.ToDouble(row.Cells["ResReq"].Value);
            double Efforthour = Convert.ToDouble(row.Cells["EffHrs"].Value);
            string phase = row.Cells["Phasename"].Value.ToString(); // Assuming phase information is stored in a cell named "Phase"
            if (columnName == "EffHrs")
            {
                double recalculatedResReq = CalculateResource(mm, phase, Efforthour);
                row.Cells["ResReq"].Value = recalculatedResReq;
            }
        }

        private void RecalculateEffhrsMm(int rowIndex, string columnName)
        {
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            double mm = Convert.ToDouble(row.Cells["Mmname"].Value);
            double resReq = Convert.ToDouble(row.Cells["ResReq"].Value);
            double Efforthour = Convert.ToDouble(row.Cells["EffHrs"].Value);
            string phase = row.Cells["Phasename"].Value.ToString(); // Assuming phase information is stored in a cell named "Phase"
            if (columnName == "ResReq")
            {
                double recalculatedEffhrs = CalculateEffHours(mm, resReq, phase, Efforthour);
                row.Cells["EffHrs"].Value = recalculatedEffhrs;
            }
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            // Check if the current cell belongs to the EffHrs column and is in one of the default phases
            if (dataGridView.CurrentCell.ColumnIndex == dataGridView.Columns["EffHrs"].Index &&
                (dataGridView.CurrentRow.Cells["Phasename"].Value.ToString() == "Requirement" ||
                 dataGridView.CurrentRow.Cells["Phasename"].Value.ToString() == "Build&Design" ||
                 dataGridView.CurrentRow.Cells["Phasename"].Value.ToString() == "QA"))
            {
                //// Disable editing for the EffHrs cell
                //TextBox textBox = e.Control as TextBox;
                //if (textBox != null)
                //{
                //    textBox.ReadOnly = true;
                //    textBox.BackColor = Color.LightGray; // Change the background color to indicate it's not editable
                //}
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
                e.Cancel = true;
            }
            else
            {
                Console.WriteLine($"Error occurred in DataGridView: {e.Exception.Message}");
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Delete key was pressed
            if (e.KeyCode == Keys.Delete)
            {
                // Iterate through all selected rows
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    // Check if the row index is greater than or equal to 4
                    if (row.Index >= 4)
                    {
                        // Display a confirmation message box before deleting
                        DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Check if the cell in the "TimelineId" column is not null
                            if (row.Cells["TimelineId"].Value != null)
                            {
                                // Retrieve the TimelineId from the cell
                                int timelineId = Convert.ToInt32(row.Cells["TimelineId"].Value);

                                // Retrieve the timeline entity from the database based on the TimelineId
                                var timeline = db.Timeline.FirstOrDefault(t => t.TimelineId == timelineId);

                                // If timeline entity exists, remove it from the database and save changes
                                if (timeline != null)
                                {
                                    db.Timeline.Remove(timeline);
                                    db.SaveChanges();
                                }
                            }

                            // Remove the row from the DataGridView
                            dataGridView1.Rows.Remove(row);
                        }
                    }
                    else
                    {
                        // Display a message box indicating that deletion of default values is not allowed
                        MessageBox.Show("Deletion of default values is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                LoadData();

            }
        }

        private bool TimelineConditions(ProjectEstimationTool.Models.Timeline timeline, out string affectedPhase)
        {
            affectedPhase = null;

            switch (timeline.Phase)
            {
                case "Requirement":
                    if (!HandleRequirementsPhase(timeline))
                    {
                        affectedPhase = "Build & Design";
                        return false;
                    }
                    break;
                case "Build&Design":
                    if (!HandleBuildDesignPhase(timeline))
                    {
                        affectedPhase = "QA";
                        return false;
                    }
                    break;
                case "QA":
                    if (!HandleQAPhase(timeline))
                    {
                        affectedPhase = "Requirements or Build & Design";
                        return false;
                    }
                    break;
                default:
                    // Other phases, if any, can be handled here
                    return true; // Default to true if no specific condition applies
            }

            return true;
        }

        private bool HandleRequirementsPhase(ProjectEstimationTool.Models.Timeline timelineEntry)
        {
            // Calculate end week of Requirements
            var requirementsEndWeek = timelineEntry.Mm + timelineEntry.Lag;
            var requirementsStartWeek = timelineEntry.Lag;

            // Check if end week of Requirements exceeds end week of Build & Design
            var buildDesignEndWeek = db.Timeline
                .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "Build&Design")
                .Select(tl => tl.Mm + tl.Lag)
                .FirstOrDefault();
            var QAEndWeek = db.Timeline
                .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "QA")
                .Select(tl => tl.Mm + tl.Lag)
                .FirstOrDefault();
            var BuildDesignStartWeek = db.Timeline.Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "Build&Design")
                .Select(tl => tl.Lag)
                .FirstOrDefault();
            var QAStartWeek = db.Timeline
               .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "QA")
               .Select(tl => tl.Lag)
               .FirstOrDefault();
            if (requirementsStartWeek > BuildDesignStartWeek || requirementsStartWeek > QAStartWeek)
            {
                var result = MessageBox.Show("End week of Requirements exceeds start week of Build & Design or QA. Do you want to adjust the timeline?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    LoadData();
                    return false;
                }
                // Calculate lag
                int lag = Math.Max(requirementsStartWeek - BuildDesignStartWeek, requirementsStartWeek - QAStartWeek);

                // Adjust end week of Build & Design
                var buildDesignEntry = db.Timeline
                    .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "Build&Design")
                    .FirstOrDefault();
                var QADesignEntry = db.Timeline
                    .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "QA")
                    .FirstOrDefault();
                if (requirementsStartWeek > BuildDesignStartWeek)
                {
                    buildDesignEntry.Lag += lag;
                }
                if (requirementsStartWeek > QAStartWeek)
                {
                    QADesignEntry.Lag += lag;
                }
            }

            if (requirementsEndWeek > buildDesignEndWeek || requirementsEndWeek > QAEndWeek)
            {
                // Prompt user for confirmation
                var result = MessageBox.Show("End week of Requirements exceeds end week of Build & Design or QA. Do you want to adjust the timeline?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    LoadData();
                    return false;
                }
                // Calculate lag
                int lag = Math.Max(requirementsEndWeek - buildDesignEndWeek, requirementsEndWeek - QAEndWeek);

                // Adjust end week of Build & Design
                var buildDesignEntry = db.Timeline
                    .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "Build&Design")
                    .FirstOrDefault();
                var QADesignEntry = db.Timeline
                    .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "QA")
                    .FirstOrDefault();
                if (requirementsEndWeek > buildDesignEndWeek)
                {
                    buildDesignEntry.Lag += lag;
                }
                if (requirementsEndWeek > QAEndWeek)
                {
                    QADesignEntry.Lag += lag;
                }
            }
            return true;
        }

        private bool HandleBuildDesignPhase(ProjectEstimationTool.Models.Timeline timelineEntry)
        {
            // Calculate end week of Build & Design
            var buildDesignEndWeek = timelineEntry.Mm + timelineEntry.Lag;
            var BuildDesignStartWeek = timelineEntry.Lag;
            // Get the end week of Requirements
            var requirementsEndWeek = db.Timeline
                .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "Requirement")
                .Select(tl => tl.Mm + tl.Lag)
                .FirstOrDefault();

            // Get the end week of QA
            var qaEndWeek = db.Timeline
                .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "QA")
                .Select(tl => tl.Mm + tl.Lag)
                .FirstOrDefault();
            var requirementsStartWeek = db.Timeline.Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "Requirement")
              .Select(tl => tl.Lag)
              .FirstOrDefault();
            var QAStartWeek = db.Timeline.Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "QA")
               .Select(tl => tl.Lag)
               .FirstOrDefault();
            if (BuildDesignStartWeek < requirementsStartWeek)
            {
                // Prompt user for confirmation
                var result = MessageBox.Show("start week of Build & Design is before start week of Requirements. Do you want to adjust the timeline?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return false;

                // Calculate lag to adjust
                int lagAdjustment = requirementsStartWeek - BuildDesignStartWeek;

                // Adjust lag
                timelineEntry.Lag += lagAdjustment; // Increase lag of Build & Design
            }
            else if (BuildDesignStartWeek > QAStartWeek)
            {
                // Prompt user for confirmation
                var result = MessageBox.Show("start week of Build & Design is after start week of QA. Do you want to adjust the timeline?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return false;

                // Calculate lag to adjust
                int lagAdjustment = BuildDesignStartWeek - QAStartWeek;

                // Adjust lag of both QA and Build & Design
                var qaEntry = db.Timeline
                    .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "QA")
                    .FirstOrDefault();
                var buildDesignEntry = db.Timeline
                    .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "Build&Design")
                    .FirstOrDefault();

                qaEntry.Lag += lagAdjustment;
                buildDesignEntry.Lag += lagAdjustment;
            }
            if (buildDesignEndWeek < requirementsEndWeek)
            {
                // Prompt user for confirmation
                var result = MessageBox.Show("End week of Build & Design is before end week of Requirements. Do you want to adjust the timeline?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    LoadData();
                    return false;
                }
                // Calculate lag to adjust
                int lagAdjustment = requirementsEndWeek - buildDesignEndWeek;

                // Adjust lag
                timelineEntry.Lag += lagAdjustment; // Increase lag of Build & Design
            }
            else if (buildDesignEndWeek > qaEndWeek)
            {
                // Prompt user for confirmation
                var result = MessageBox.Show("End week of Build & Design is after end week of QA. Do you want to adjust the timeline?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    LoadData();
                    return false;
                }

                // Calculate lag to adjust
                int lagAdjustment = buildDesignEndWeek - qaEndWeek;

                // Adjust lag of both QA and Build & Design
                var qaEntry = db.Timeline
                    .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "QA")
                    .FirstOrDefault();
                var buildDesignEntry = db.Timeline
                    .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "Build&Design")
                    .FirstOrDefault();

                qaEntry.Lag += lagAdjustment;
                buildDesignEntry.Lag += lagAdjustment;
            }

            return true;
        }


        private bool HandleQAPhase(ProjectEstimationTool.Models.Timeline timelineEntry)
        {
            // Calculate end week of QA
            var qaEndWeek = timelineEntry.Mm + timelineEntry.Lag;
            var QAStartWeek = timelineEntry.Lag;
            // Get the end week of Requirements
            var requirementsEndWeek = db.Timeline
                .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "Requirement")
                .Select(tl => tl.Mm + tl.Lag)
                .FirstOrDefault();

            // Get the end week of Build & Design
            var buildDesignEndWeek = db.Timeline
                .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "Build&Design")
                .Select(tl => tl.Mm + tl.Lag)
                .FirstOrDefault();
            var requirementsStartWeek = db.Timeline.Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "Requirement")
            .Select(tl => tl.Lag)
            .FirstOrDefault();
            var BuildDesignStartWeek = db.Timeline.Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "Build&Design")
               .Select(tl => tl.Lag)
               .FirstOrDefault();

            if (QAStartWeek < requirementsStartWeek || QAStartWeek < BuildDesignStartWeek)
            {
                // Prompt user for confirmation
                var result = MessageBox.Show("start week of QA finishes before start week of Requirements or Build & Design. Do you want to adjust the timeline?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    LoadData();
                    return false;
                }
                // Calculate lag
                int newLag = Math.Max(requirementsStartWeek - QAStartWeek, BuildDesignStartWeek - QAStartWeek);

                // Adjust lag
                timelineEntry.Lag += newLag;
            }
            if (qaEndWeek < requirementsEndWeek || qaEndWeek < buildDesignEndWeek)
            {
                // Prompt user for confirmation
                var result = MessageBox.Show("End week of QA finishes before end week of Requirements or Build & Design. Do you want to adjust the timeline?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    LoadData();
                    return false;
                }
                // Calculate lag
                int newLag = Math.Max(requirementsEndWeek - qaEndWeek, buildDesignEndWeek - qaEndWeek);

                // Adjust lag
                timelineEntry.Lag += newLag;
            }

            return true;
        }

        private void UpdateAffectedPhase(string affectedPhase, ProjectEstimationTool.Models.Timeline timeline)
        {
            // Update the affected phase based on the specific logic
            switch (affectedPhase)
            {
                case "Build&Design":
                    // Update Build & Design phase
                    HandleBuildDesignPhase(timeline);
                    break;
                case "QA":
                    // Update QA phase
                    HandleQAPhase(timeline);
                    break;
                case "Requirement or Build&Design":
                    // Update either Requirements or Build & Design phase based on specific logic
                    HandleRequirementsOrBuildDesignPhase(timeline);
                    break;
                default:
                    // Handle other affected phases, if any
                    break;
            }
        }
        private bool HandleRequirementsOrBuildDesignPhase(ProjectEstimationTool.Models.Timeline timeline)
        {
            // Calculate end week of the phase
            var endWeek = timeline.Mm + timeline.Lag;

            // Check if the end week exceeds the end week of the next phase (QA)
            var nextPhaseEndWeek = db.Timeline
                .Where(tl => tl.ProjectId == Form1.projectid && tl.Phase == "QA")
                .Select(tl => tl.Mm + tl.Lag)
                .FirstOrDefault();

            if (endWeek > nextPhaseEndWeek)
            {
                // Prompt user for confirmation
                var result = MessageBox.Show($"End week of {timeline.Phase} exceeds end week of QA. Do you want to adjust the timeline?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return false;

                // Calculate new lag
                int newLag = endWeek - nextPhaseEndWeek;
                if (newLag < 1)
                {
                    MessageBox.Show("It's not possible to set lag below 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Adjust lag of the current phase
                timeline.Lag -= newLag;

                // Inform the user about the phase that has been affected
                MessageBox.Show($"The lag of {timeline.Phase} phase has been adjusted to maintain the timeline.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void UpdateDemoDatesIfRequired(int newMaxMonth)
        {
            var demoDates = db.Demodates.FirstOrDefault(d => d.ProjectId == Form1.projectid);

            if (demoDates != null && demoDates.Demodate1 + demoDates.Demodate2 != newMaxMonth)
            {
                demoDates.Demodate2 = newMaxMonth;

                // Save changes to the database
                db.Demodates.Update(demoDates);
                db.SaveChanges();
                LoadData();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue;
            panel1.Visible = true;
            // Retrieve demo dates from the database
            var demoDates = db.Demodates.FirstOrDefault(d => d.ProjectId == Form1.projectid);

            if (demoDates != null)
            {
                // Populate the textboxes with demo dates
                textBox1.Text = demoDates.Demodate1.ToString();
                textBox2.Text = demoDates.Demodate2.ToString();
            }
            else
            {
                // If no demo dates are found in the database, set default values
                textBox1.Text = "0";
                textBox2.Text = "0";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var maxmm = db.Timeline.Where(p => p.ProjectId == Form1.projectid).Select(p => p.Mm + p.Lag).Max();

            if (!int.TryParse(textBox1.Text, out int demodate1) || !int.TryParse(textBox2.Text, out int demodate2))
            {
                MessageBox.Show("Please enter valid demo dates in MM format.");
                return;
            }
            var originalMaxMm = maxmm;
            maxmm /= 2;

            Demodates AddOrUpdateDemodates = new Demodates
            {
                Demodate1 = demodate1 >= 2 ? demodate1 : 0,
                Demodate2 = demodate2 >= 2 ? demodate2 : 0,
                ProjectId = Form1.projectid,
            };

            if (AddOrUpdateDemodates.Demodate1 == 0 || AddOrUpdateDemodates.Demodate2 == 0)
            {
                MessageBox.Show("Please enter valid demo dates in MM format.");
            }
            else if (AddOrUpdateDemodates.Demodate1 > maxmm && AddOrUpdateDemodates.Demodate2 > originalMaxMm)
            {
                MessageBox.Show("You cannot enter demo dates beyond the required months for this phase.");
            }
            else if (AddOrUpdateDemodates.Demodate1 >= AddOrUpdateDemodates.Demodate2)
            {
                MessageBox.Show("Demodate1 must be less than Demodate2.");
            }
            else if(AddOrUpdateDemodates.Demodate1 > maxmm || AddOrUpdateDemodates.Demodate2 > originalMaxMm)
            {
                MessageBox.Show("You cannot enter demo dates beyond the required months for this phase.");
                return;
            }
            else
            {
                var existingDemodates = db.Demodates.FirstOrDefault(p => p.ProjectId == Form1.projectid);

                if (existingDemodates != null)
                {
                    existingDemodates.Demodate1 = AddOrUpdateDemodates.Demodate1;
                    existingDemodates.Demodate2 = AddOrUpdateDemodates.Demodate2;
                    db.Demodates.Update(existingDemodates);
                    MessageBox.Show("Demo dates updated successfully!");
                }
                    else
                {
                    db.Demodates.Add(AddOrUpdateDemodates);
                    MessageBox.Show("Demo dates added successfully!");
                }

                db.SaveChanges();
              //LoadData();
                panel1.Visible = false;
               
            }


        }
    }


}

