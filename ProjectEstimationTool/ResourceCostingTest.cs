using Microsoft.Extensions.Logging.Abstractions;
using Org.BouncyCastle.Crypto.Tls;
using ProjectEstimationTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;




namespace ProjectEstimationTool
{

    public partial class ResourceCostingTest : UserControl
    {

        private int ProjectID;
        private string ProjectName;
        private int rescostingid;
        private string phase;
        private int rescount;
        private string restype;
        private string country;
        private string rolelevel;
        private int hourlyrate;
        private float monthlyrate;
        private float durationinmonths;
        private int cost;
        private int Hourlyrate;
        private int Monthlyhours;
        private int Monthlyrate;
        private int Cost;
        private int Months;
        private int? rescurrentallocated;
        private int resourcereq;

        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        private BindingList<ProjectEstimationTool.Models.ResourceCosting> resourceCostingList;
        private Dictionary<string, int> defaultResourceCounts = new Dictionary<string, int>();
        public ResourceCostingTest()
        {
            InitializeComponent();
            resourceCostingList = new BindingList<ProjectEstimationTool.Models.ResourceCosting>();
            dataGridView1.DataSource = resourceCostingList;
          
            

        }

        //take support of ur teammate she can help u

        public void LoadComboBoxData()
        {

            // Ensure that the DataGridView allows user additions
            dataGridView1.AllowUserToAddRows = true;
            // Populate the Phase combo box with data
            var phases = db.Timeline
                .Where(t => t.ProjectId == Form1.projectid)
                .Select(t => t.Phase)
                .Distinct()
                .ToList();

            // Set the data source for the Phase column
            DataGridViewComboBoxColumn phaseColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["dataGridViewTextBoxColumn3"];
            phaseColumn.DataSource = phases;

            // Populate the Country combo box with data
            var countries = db.Country
                    .Where(c => c.ProjectId == Form1.projectid)
                    .Select(c => c.CountryName)
                    .Distinct().ToList();
            DataGridViewComboBoxColumn countryColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["dataGridViewTextBoxColumn6"];
            countryColumn.DataSource = countries;

            // Populate the ResType combo box with data
            var resourceTypes = db.ResourceTypes
                .Where(rt => rt.ProjectId == Form1.projectid)
                .Select(rt => rt.TypeName)
                .Distinct().ToList();
            DataGridViewComboBoxColumn resTypeColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["dataGridViewTextBoxColumn5"];
            resTypeColumn.DataSource = resourceTypes;

            // Populate the RoleLevel combo box with data
            var roleLevels = db.ResourceLevel
                .Where(rl => rl.ProjectId == Form1.projectid)
                .Select(rl => rl.LevelName)
                .Distinct().ToList();
            DataGridViewComboBoxColumn roleLevelColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["dataGridViewTextBoxColumn7"];
            roleLevelColumn.DataSource = roleLevels;
            // Fetch ResourceCosting data from the database
            LoadDefaultRows1();

            var resourceCostingData = db.ResourceCosting.Where(rc => rc.ProjectId == Form1.projectid).ToList();
            // Add the fetched data to the resourceCostings list
            foreach (var resourceCosting in resourceCostingData)
            {
                resourceCostingList.Add(resourceCosting);
            }




        }




        public void Rateformula(string country, string resourcetype, string rolelevel, string phase, int rescount)
        {
            Hourlyrate = (from rate in db.Resource
                          where rate.CountryName.Contains(country) && rate.TypeName.Contains(resourcetype) && rate.LevelName.Contains(rolelevel) && rate.ProjectId == Form1.projectid
                          select rate.HourlyRate).FirstOrDefault();
            Monthlyhours = (from hours in db.Productivity
                            where hours.ProductivityName == "Week" && hours.ProjectId == Form1.projectid
                            select hours.Hours).FirstOrDefault();
            Months = (from mm in db.Timeline
                      where mm.Phase == phase && mm.ProjectId == Form1.projectid
                      select mm.Mm).FirstOrDefault();
            Monthlyrate = Hourlyrate * Monthlyhours * rescount;
            Cost = Monthlyrate * Months;

        }

        private void ResourceCostingTest_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;

                // Check if the edited cell is within the data grid view bounds
                if (dataGridView1 != null && e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Retrieve the edited row
                    DataGridViewRow editedRow = dataGridView1.Rows[rowIndex];

                    // Get values from the edited row
                    string selectedPhase = editedRow.Cells["dataGridViewTextBoxColumn3"].Value?.ToString();
                    string selectedCountry = editedRow.Cells["dataGridViewTextBoxColumn6"].Value?.ToString();
                    string selectedResourceType = editedRow.Cells["dataGridViewTextBoxColumn5"].Value?.ToString();
                    string selectedRoleLevel = editedRow.Cells["dataGridViewTextBoxColumn7"].Value?.ToString();

                    // Retrieve the ResourceCosting object for the edited row
                    var editedResourceCosting = dataGridView1.Rows[rowIndex].DataBoundItem as ResourceCosting;

                    if (editedResourceCosting != null)
                    {
                        // Update ResourceCosting properties based on the edited cell
                        switch (dataGridView1.Columns[columnIndex].Name)
                        {
                            case "dataGridViewTextBoxColumn3":
                                editedResourceCosting.Phase = selectedPhase;
                                break;
                            case "dataGridViewTextBoxColumn6":
                                editedResourceCosting.Country = selectedCountry;
                                break;
                            case "dataGridViewTextBoxColumn5":
                                editedResourceCosting.ResType = selectedResourceType;
                                break;
                            case "dataGridViewTextBoxColumn7":
                                editedResourceCosting.RoleLevel = selectedRoleLevel;
                                break;
                            case "dataGridViewTextBoxColumn4":
                                if (int.TryParse(editedRow.Cells["dataGridViewTextBoxColumn4"].Value?.ToString(), out int resCount))
                                {
                                    editedResourceCosting.ResCount = resCount;
                                    Rateformula(selectedCountry, selectedResourceType, selectedRoleLevel, selectedPhase, resCount);
                                    editedResourceCosting.HourlyRate = Hourlyrate;
                                    editedResourceCosting.MonthlyRate = Monthlyrate;
                                    editedResourceCosting.Cost = Cost;
                                    editedResourceCosting.DurationMm = Months;
                                    db.SaveChanges();
                                    dataGridView1.Refresh();

                                }
                                break;
                            default:
                                break;
                        }

                        // Save changes within a try-catch block

                    }
                    try
                    {
                        int resourceCostingId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
                        if (resourceCostingId == 0)
                        {
                            // Check if any required property is null before saving
                            if (string.IsNullOrEmpty(selectedPhase) ||
                                string.IsNullOrEmpty(selectedCountry) ||
                                string.IsNullOrEmpty(selectedResourceType) ||
                                string.IsNullOrEmpty(selectedRoleLevel))
                            {
                                //MessageBox.Show("Please select values for Phase, Country, Resource Type, and Role Level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            int ResCount = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["dataGridViewTextBoxColumn4"].Value);
                            // Apply rate formula for newly added records
                            Rateformula(selectedCountry, selectedResourceType, selectedRoleLevel, selectedPhase, ResCount);


                            // Retrieve timelineId and resourceid from the database
                            var timelineId = db.Timeline
                                .Where(t => t.ProjectId == Form1.projectid && t.Phase == selectedPhase)
                                .Select(t => t.TimelineId)
                                .FirstOrDefault();

                            var resourceid = db.Resource
                                .Where(r => r.ProjectId == Form1.projectid && r.TypeName == selectedResourceType)
                                .Select(r => r.ResourceId)
                                .FirstOrDefault();

                            // Create a new ResourceCosting object for adding
                            var adddata = new ResourceCosting
                            {
                                ProjectId = Form1.projectid,
                                TimelineId = timelineId,
                                ResourceId = resourceid,
                                Phase = selectedPhase,
                                ResType = selectedResourceType,
                                Country = selectedCountry,
                                RoleLevel = selectedRoleLevel,
                                ResCount = ResCount,
                                HourlyRate = Hourlyrate,
                                DurationMm = Months,
                                MonthlyRate = Monthlyrate,
                                Cost = Cost
                            };

                            // Add the new record to the database and save changes
                            db.ResourceCosting.Add(adddata);
                            db.SaveChanges();
                            // Refresh DataGridView binding after updating
                            // Update DataGridView cells with calculated values
                            dataGridView1.Rows[rowIndex].Cells["dataGridViewTextBoxColumn8"].Value = Hourlyrate;
                            dataGridView1.Rows[rowIndex].Cells["dataGridViewTextBoxColumn9"].Value = Monthlyrate;
                            dataGridView1.Rows[rowIndex].Cells["dataGridViewTextBoxColumn11"].Value = Cost;
                            dataGridView1.Refresh();

                            MessageBox.Show("New resource costing added successfully");

                        }
                        else
                        {
                            // Update existing ResourceCosting record in the database
                            var resourceCostingId1 = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
                            int ResCount = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["dataGridViewTextBoxColumn4"].Value);

                            // Fetch the existing ResourceCosting record from the database
                            var existingResourceCosting = db.ResourceCosting.FirstOrDefault(rc => rc.ResourceCostingId == resourceCostingId);

                            if (existingResourceCosting != null)
                            {
                                // Update the existing record with the new values
                                existingResourceCosting.Phase = selectedPhase;
                                existingResourceCosting.ResType = selectedResourceType;
                                existingResourceCosting.Country = selectedCountry;
                                existingResourceCosting.RoleLevel = selectedRoleLevel;
                                existingResourceCosting.ResCount = ResCount;

                                // Apply rate formula for updated records
                                Rateformula(selectedCountry, selectedResourceType, selectedRoleLevel, selectedPhase, ResCount);

                                // Update ResourceCosting properties with formula-calculated values
                                existingResourceCosting.HourlyRate = Hourlyrate;
                                existingResourceCosting.MonthlyRate = Monthlyrate;
                                existingResourceCosting.Cost = Cost;
                                existingResourceCosting.DurationMm = Months;

                                // Save changes to the database
                                try
                                {
                                    db.SaveChanges();
                                    // Refresh DataGridView binding after updating
                                    dataGridView1.Refresh();
                        

                                    MessageBox.Show("Resource costing updated successfully");
                                }
                                catch (Exception ex)
                                {
                                    string errorMessage = ex.InnerException?.Message ?? ex.Message;
                                    MessageBox.Show($"Error updating resource costing: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Resource costing not found in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        // Display the specific error message from the inner exception
                        string errorMessage = ex.InnerException?.Message ?? ex.Message;
                        MessageBox.Show($"Error saving to the database: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }


        private void LoadDefaultRows1()
        {
            try
            {
                dataGridView1.AllowUserToAddRows = false;
                //dataGridView1.Columns["Column1"].Visible = false;
                //dataGridView1.Columns["DurationMm"].DefaultCellStyle.BackColor = Color.Gray;




                // Fetch distinct phases from the database
                var defaultPhases = (from phase in db.Timeline
                                     where phase.ProjectId == Form1.projectid
                                     select phase.Phase).Distinct().ToList();

                // Populate ResourceCosting2List and deduct allocated counts from default values
                foreach (var phase in defaultPhases)
                {
                    // Fetch default resource count for the phase
                    int defaultCount = (from item in db.Timeline
                                        where item.Phase == phase && item.ProjectId == Form1.projectid
                                        select item.ResReq).FirstOrDefault();

                    // Fetch allocated count for the phase
                    int allocatedCount = (from item in db.ResourceCosting
                                          where item.Phase == phase && item.ProjectId == Form1.projectid
                                          select item.ResCount).Sum();

                    // Calculate remaining count by deducting allocated count from default count
                    int remainingCount = defaultCount - allocatedCount;

                    // Add to ResourceCosting2List only if remainingCount is greater than 0
                    if (remainingCount > 0 && phase != "Kickoff/Demo/Setup")
                    {

                        resourceCostingList.Add(new ResourceCosting
                        {
                            Phase = phase,
                            ResCount = remainingCount,
                            DurationMm = (from item in db.Timeline
                                          where item.Phase == phase && item.ProjectId == Form1.projectid
                                          select item.Mm).FirstOrDefault()

                        });

                    }




                }

                // Set the default phases as the DataSource for the phase column in the DataGridView
                DataGridViewComboBoxColumn phaseColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["dataGridViewTextBoxColumn3"];
                phaseColumn.DataSource = defaultPhases;
                // Lock the allocation columns
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                   dataGridView1.Rows[i].Cells["DurationMm"].ReadOnly = true;
                    dataGridView1.Rows[i].Cells["DurationMm"].Style.BackColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (e.Exception is FormatException)
                {
                    e.Cancel = true;
                }

            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during error handling
                Console.WriteLine($"Error handling DataGridView data error: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the delete key is pressed
            if (e.KeyCode == Keys.Delete)
            {
                // Check if any rows are selected
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Prompt the user to confirm deletion
                    DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // If the user confirms deletion
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Get the index of the selected row
                            int rowIndex = dataGridView1.SelectedRows[0].Index;

                            // Get the ResourceCostingId of the selected row
                            int resourceCostingId = (int)dataGridView1.Rows[rowIndex].Cells["Column1"].Value;

                            // Remove the row from the DataGridView
                            dataGridView1.Rows.RemoveAt(rowIndex);

                            // Delete the corresponding record from the database using resourceCostingId
                            var recordToDelete = db.ResourceCosting.FirstOrDefault(rc => rc.ResourceCostingId == resourceCostingId);
                            if (recordToDelete != null)
                            {
                                db.ResourceCosting.Remove(recordToDelete);
                                // Remove associated SoftwareCostingTest records
                                db.SoftwareCostingTest.RemoveRange(recordToDelete.SoftwareCostingTest);
                                db.SaveChanges();
                                dataGridView1.Refresh();

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
