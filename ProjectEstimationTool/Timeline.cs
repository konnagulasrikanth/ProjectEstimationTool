using Microsoft.EntityFrameworkCore;
using ProjectEstimationTool.Models;
using System.Data;

namespace ProjectEstimationTool
{
    public partial class Timeline : UserControl
    {
        ProjectEstimationToolMasterContext db;
        public int TimelineID { get; set; }


        private Timeline td;

        public ProjectEstimationTool.Models.Timeline tm;
        private bool defaultsAdded = false; // Add this field to keep track of whether defaults have been added

        public Timeline()
        {
            InitializeComponent();
            db = new ProjectEstimationToolMasterContext();
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            loadTimelineData();

        }

        private void Timeline_Load(object sender, EventArgs e)
        {
            panel8.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            UpdateTimelines();



            var maxMmForProject = db.Timeline.Where(p => p.ProjectId == Form1.projectid).Select(p => p.Mm + p.Lag).DefaultIfEmpty().Max();
            AddColumnsPermanently(maxMmForProject);
            if (!defaultsAdded)
            {
                bool defaultEntriesExist = db.Timeline.Where(tl => tl.ProjectId == Form1.projectid).Any(tl => tl.Phase.Contains("KickOFF/Demo/Setup") || tl.Phase.Contains("Requirements") || tl.Phase.Contains("Build&Design") || tl.Phase.Contains("QA"));

                if (!defaultEntriesExist)
                {
                    var sumOfBafinalHrs = db.ScopeAndEffort.Where(t => t.ProjectId == Form1.projectid).Sum(t => t.BafinalHrs);
                    var sumOfDevfinalHrs = db.ScopeAndEffort.Where(t => t.ProjectId == Form1.projectid).Sum(t => t.DevFinalHrs);
                    var sumOfQafinalHrs = db.ScopeAndEffort.Where(t => t.ProjectId == Form1.projectid).Sum(t => t.QafinalHrs);

                    if (sumOfBafinalHrs > 0 && sumOfDevfinalHrs > 0 && sumOfQafinalHrs > 0)
                    {
                        var k = new ProjectEstimationTool.Models.Timeline[]
                        {
                    new ProjectEstimationTool.Models.Timeline
                    {
                        ProjectId = Form1.projectid,
                        Functionality = "KickOff",
                        Phase = "KickOFF/Demo/Setup",
                        EffHrs = 0,
                        ResReq = 0,
                        Mm = 1,
                        Lag = 1
                    },
                    new ProjectEstimationTool.Models.Timeline
                    {
                        ProjectId = Form1.projectid,
                        Functionality = "",
                        Phase = "Requirement",
                        EffHrs = (int)sumOfBafinalHrs,
                        ResReq = 0,
                        Mm = 0,
                        Lag = 0
                    },
                    new ProjectEstimationTool.Models.Timeline
                    {
                        ProjectId = Form1.projectid,
                        Functionality = "",
                        Phase = "Build&Design",
                        EffHrs = (int)sumOfDevfinalHrs,
                        ResReq = 0,
                        Mm = 0,
                        Lag = 0
                    },
                    new ProjectEstimationTool.Models.Timeline
                    {
                        ProjectId = Form1.projectid,
                        Functionality = "",
                        Phase = "QA",
                        EffHrs = (int)sumOfQafinalHrs,
                        ResReq = 0,
                        Mm = 0,
                        Lag = 0
                    }
                        };

                        db.Timeline.AddRange(k.ToList());
                        db.SaveChanges();
                        defaultsAdded = true; // Set the flag to true after adding defaults
                    }
                }
            }

            loadTimelineData();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        public void AddColumnsPermanently(int MMvalue)
        {

            var maxMmForProject = db.Timeline.Where(p => p.ProjectId == Form1.projectid).Select(p => p.Mm + p.Lag).DefaultIfEmpty().Max();
            if (maxMmForProject <= MMvalue)
            {
                for (int i = 0; i <= MMvalue; i++)
                {
                    string columnName = "MM" + i;
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = columnName,
                        HeaderText = columnName
                    });
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string functionality = textBox1.Text;
            var existingItems = comboBox1.Items.Cast<string>().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new object[] { "Requirement", "Build&Design", "QA", "PM", "Architect-Lead", "Infra", "Mgmt." });

            string resReqText = textBox3.Text;
            if (!int.TryParse(resReqText, out int resReq))
            {
                MessageBox.Show("Please enter ResReq.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text) || comboBox1.SelectedIndex == 0 || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Please enter values for all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string mmText = textBox4.Text;
            if (!int.TryParse(mmText, out int mm))
            {
                MessageBox.Show("Please enter a valid integer for Mm.");
                return;
            }

            string lagText = textBox5.Text;
            if (!int.TryParse(lagText, out int lag))
            {
                MessageBox.Show("Please enter a valid integer for Lag.");
                return;
            }

            string phase = textBox1.Text + "-" + comboBox1.Text;

            bool isDuplicate = db.Timeline.Any(t =>
                t.ProjectId == Form1.projectid &&
                t.Functionality == functionality &&
                t.Phase == phase);

            var monthlyhrs = (from t in db.Productivity
                              where t.ProductivityName == "Month" && t.ProjectId == Form1.projectid
                              select t.Hours).FirstOrDefault();

            if (isDuplicate)
            {
                MessageBox.Show("Combination of functionality and phase already exists. Please choose a different combination.");
                return; // Exit the method to prevent further execution
            }

            var res = new ProjectEstimationTool.Models.Timeline
            {
                ProjectId = Form1.projectid,
                Functionality = textBox1.Text,
                Phase = phase,
                ResReq = resReq,
                Mm = mm,
                Lag = lag,
                EffHrs = mm * resReq * monthlyhrs,
            };

            db.Timeline.Add(res);
            db.SaveChanges();
            loadTimelineData();
            panel6.Visible = false;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue;
            panel8.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;

            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.AddRange(new object[] { "PM", "Architect-Lead", "Infra", "Mgmt." });
            }
        }
        public void loadTimelineData()
        {
            var res = from t in db.Timeline
                      where t.ProjectId == Form1.projectid
                      select t;
            dataGridView1.DataSource = res.ToList();
            var hrs = (from t in db.Timeline
                       where t.ProjectId == Form1.projectid
                       select t.EffHrs).Sum();

            var maxMmForProject = db.Timeline.Where(p => p.ProjectId == Form1.projectid).Select(p => p.Mm + p.Lag).DefaultIfEmpty().Max();
            label5.Text = hrs.ToString();
            label6.Text = maxMmForProject.ToString();
            SetRowColorBasedOnPhase();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.RosyBrown;
            panel6.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            panel7.Visible = false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Index > 3)
            {


                if (dataGridView1.SelectedCells.Count > 0)

                {

                    DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];

                        if (selectedRow.DataBoundItem is ProjectEstimationTool.Models.Timeline tm)
                        {
                            int seid = tm.TimelineId;
                            var delete = db.Timeline.FirstOrDefault(t => t.TimelineId == seid);
                            if (delete != null)
                            {

                                var relallocations = db.ResourceAllocation.Where(t => t.TimelineId == TimelineID);
                                db.ResourceAllocation.RemoveRange(relallocations);
                                var rescosting = db.ResourceCosting.Where(t => t.ProjectId == Form1.projectid);
                                db.ResourceCosting.RemoveRange(rescosting);
                                db.Timeline.Remove(delete);
                                db.SaveChanges();
                                loadTimelineData();

                            }




                        }

                    }

                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
            panel7.Visible = true;
            panel6.Visible = false;
            if (comboBox2.Items.Count == 0)
            {
                comboBox2.Items.Clear();
                comboBox2.Items.AddRange(new object[] { "Requirement", "Build&Design", "QA", "PM", "Architect-Lead", "Infra", "Mgmt." });
            }
            if (dataGridView1.SelectedRows[0].Index < 1)
            {
                comboBox2.Visible = false;
                label16.Visible = false;
            }
            else
            {
                comboBox2.Visible = true;
                label16.Visible = true;
            }
            if (dataGridView1.SelectedRows[0].Index == 0)
            {
                panel7.Visible = false;
                MessageBox.Show("Editing KickOFF/Demo/Setup is not allowed.");
            }

            if (dataGridView1.SelectedRows.Count > 0)

            {

                tm = dataGridView1.SelectedRows[0].DataBoundItem as ProjectEstimationTool.Models.Timeline;

                if (tm != null)

                {

                    textBox2.Text = tm.Functionality;

                    string[] phaseParts = tm.Phase.Split('-');
                    if (phaseParts.Length == 2)
                    {
                        textBox1.Text = phaseParts[0];
                        comboBox2.Text = phaseParts[1];
                    }
                    textBox7.Text = tm.ResReq.ToString();

                    textBox8.Text = tm.Mm.ToString();

                    textBox9.Text = tm.Lag.ToString();

                }

            }

        }

        public void SetRowColorBasedOnPhase()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                object FunctionalityCellvalue = row.Cells["Functionality"].Value;
                object phasesCellValue = row.Cells["Phasename"].Value;
                object mmCellValue = row.Cells["Mmname"].Value;
                object lagCellValue = row.Cells["Lagname"].Value;
                var minMmForProject = db.Timeline.Where(p => p.ProjectId == Form1.projectid && p.Phase != "KickOFF/Demo/Setup").Select(p => p.Lag).DefaultIfEmpty().Min();
                int m = minMmForProject;
                if (phasesCellValue != null && mmCellValue != null && lagCellValue != null)
                {
                    string phase = phasesCellValue.ToString();
                    int lagForRow = Convert.ToInt32(lagCellValue);
                    int mmForRow = Convert.ToInt32(mmCellValue) + 8 + lagForRow;
                    string functionalitys = FunctionalityCellvalue.ToString();
                    for (int i = lagForRow + 9; i <= mmForRow; i++)
                    {
                        if (i < dataGridView1.Columns.Count)
                        {
                            string kickoffFunctionality = "KickOFF/Demo/Setup";
                            if (phase.Equals(kickoffFunctionality))
                            {
                                row.Cells[minMmForProject + 9].Style.BackColor = Color.Transparent;
                                row.Cells[minMmForProject + 9].Value = "K";
                            }
                            int demodate1 = db.Demodates.Where(p => p.ProjectId == Form1.projectid).Select(d => d.Demodate1).FirstOrDefault();
                            int demodate2 = db.Demodates.Where(p => p.ProjectId == Form1.projectid).Select(d => d.Demodate2).FirstOrDefault();
                            if (demodate1 > 0 && phase.Equals(kickoffFunctionality))
                            {
                                int demodate1Index = 9 + demodate1 - 1;
                                if (demodate1Index < dataGridView1.Columns.Count)
                                {
                                    row.Cells[demodate1Index].Style.BackColor = Color.Transparent;
                                    row.Cells[demodate1Index].Value = "D1";
                                }
                            }

                            if (demodate2 > 0 && phase.Equals(kickoffFunctionality))
                            {
                                int demodate2Index = 9 + demodate2 - 1;
                                if (demodate2Index < dataGridView1.Columns.Count)
                                {
                                    row.Cells[demodate2Index].Style.BackColor = Color.Transparent;
                                    row.Cells[demodate2Index].Value = "D2";
                                }
                            }
                            Color color = GetColorForPhaseAndMM(phase, functionalitys);
                            row.Cells[i].Style.BackColor = color;
                        }
                    }
                }
            }
        }

        private Color GetColorForPhaseAndMM(string phase, string Functionality)
        {

            string PMFunctionality = Functionality + "-PM"; // Add space after functionality for "PM" case
            string ArchFunctionality = Functionality + "-Architect-Lead";
            string InfraFunctionality = Functionality + "-Infra";
            string MgmtFunctionality = Functionality + "-Mgmt.";
            string RequirementsFunctionality = Functionality + "-Requirement";
            string BuildDesignFunctionality = Functionality + "-Build&Design";
            string QAFunctionality = Functionality + "-QA";

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
                    return Color.Orange;
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
                var maxMmForProject = db.Timeline.Where(t=>t.ProjectId == Form1.projectid).Select(p => p.Mm + p.Lag).Max();
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
                }
                // Update the demo dates if required
                UpdateDemoDatesIfRequired(maxMmForProject);
                db.SaveChanges();
           
                // Reload timeline data
                loadTimelineData();
            }
        }
   




        private void button3_Click(object sender, EventArgs e) //edit code button 
        {

            try
            {


                string functionality = textBox2.Text;
                string phase = comboBox2.Text;

                int resReq = int.Parse(textBox7.Text);
                int mm = int.Parse(textBox8.Text);
                int lag = int.Parse(textBox9.Text);
                int monthlyhrs = (from t in db.Productivity
                                  where t.ProductivityName == "Month" && t.ProjectId == Form1.projectid
                                  select t.Hours).FirstOrDefault();

                int effhours = resReq * mm * monthlyhrs;
                //   effhours = int.Parse(textBox4.Text) * int.Parse(textBox3.Text) * monthlyhrs;

                bool isDuplicate = db.Timeline.Any(t =>
            t.ProjectId == Form1.projectid &&
            t.Functionality == functionality &&
            t.ResReq == resReq &&
            t.Mm == mm &&
            t.Lag == lag &&
            t.Phase == functionality + "-" + phase);

                if (isDuplicate)
                {
                    MessageBox.Show("Combination of Functionality and Phase already exists. Please choose a different combination.");
                    return; // Exit the method to prevent further execution
                }

                // Validation: Check if any of the required fields are empty
                if (string.IsNullOrWhiteSpace(textBox2.Text) || comboBox2.SelectedIndex == -1 || string.IsNullOrWhiteSpace(textBox7.Text) || string.IsNullOrWhiteSpace(textBox8.Text) || string.IsNullOrWhiteSpace(textBox9.Text))
                {
                    MessageBox.Show("Please enter values for all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // Update the selected timeline entry
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    ProjectEstimationTool.Models.Timeline selectedTimeline = dataGridView1.SelectedRows[0].DataBoundItem as ProjectEstimationTool.Models.Timeline;

                    if (selectedTimeline != null)
                    {
                        selectedTimeline.Functionality = functionality;
                        selectedTimeline.Phase = functionality + "-" + phase;
                        selectedTimeline.ResReq = resReq;
                        selectedTimeline.Mm = mm;
                        selectedTimeline.Lag = lag;

                        selectedTimeline.EffHrs = effhours;

                        var resupdate = db.ResourceAllocation.Where(t => t.TimelineId == selectedTimeline.TimelineId).ToList();
                        foreach (var item in resupdate)
                        {
                            item.Functionality = functionality;
                            item.Phase = functionality + "-" + phase;
                            item.ResReq = resReq;
                            item.Mm = mm;
                            item.EffHrs = effhours;
                            // Update ResourceAllocated and ResourcePending
                            item.ResourceAllocated = CalculateResourceAllocated(item.TimelineId);
                            item.ResourcePending = item.ResReq - item.ResourceAllocated;


                            db.ResourceAllocation.UpdateRange(item);

                        }
                        db.SaveChanges();
                        MessageBox.Show("Timeline Updated Successfully!");
                        loadTimelineData();
                        UpdateTimelines();
                        panel7.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private int CalculateResourceAllocated(int timelineId)
        {
            // Calculate and return the total resource allocated for the given timelineId
            return db.ResourceAllocation
                .Where(ra => ra.TimelineId == timelineId)
                .Sum(ra => ra.ResourceAllocated);
        }
        private void timelineBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.BackColor = Color.LightBlue;
            panel8.Visible = true;
            // Retrieve demo dates from the database
            var demoDates = db.Demodates.FirstOrDefault(d => d.ProjectId == Form1.projectid);

            if (demoDates != null)
            {
                // Populate the textboxes with demo dates
                textBox6.Text = demoDates.Demodate1.ToString();
                textBox10.Text = demoDates.Demodate2.ToString();
            }
            else
            {
                // If no demo dates are found in the database, set default values
                textBox6.Text = "0";
                textBox10.Text = "0";
            }
        }
        private void UpdateDemoDatesIfRequired(int newMaxMonth)
        {
            var demoDates = db.Demodates.FirstOrDefault(d => d.ProjectId == Form1.projectid);

            if (demoDates != null && demoDates.Demodate1 + demoDates.Demodate2 != newMaxMonth)
            {
                demoDates.Demodate2 = newMaxMonth ;

                // Save changes to the database
                db.Demodates.Update(demoDates);
                db.SaveChanges();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            var maxmm = db.Timeline.Where(p => p.ProjectId == Form1.projectid).Select(p => p.Mm + p.Lag).Max();

            if (!int.TryParse(textBox6.Text, out int demodate1) || !int.TryParse(textBox10.Text, out int demodate2))
            {
                MessageBox.Show("Please enter valid demo dates in MM format.");
                return;
            }

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
            else if (AddOrUpdateDemodates.Demodate1 > maxmm || AddOrUpdateDemodates.Demodate2 > maxmm)
            {
                MessageBox.Show("You cannot enter demo dates beyond the required months for this phase.");
            }
            else if (AddOrUpdateDemodates.Demodate1 >= AddOrUpdateDemodates.Demodate2)
            {
                MessageBox.Show("Demodate1 must be less than Demodate2.");
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
                loadTimelineData();
                panel8.Visible = false;
            }



        }


        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.RebeccaPurple;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = DefaultBackColor;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button6.BackColor = Color.RosyBrown;
            panel8.Visible = false;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {


            Scope sc = new Scope();
            this.Hide();
            this.Parent.Controls.Add(sc);
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

