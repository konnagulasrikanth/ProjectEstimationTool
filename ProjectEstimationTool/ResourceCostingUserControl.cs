using Microsoft.Identity.Client;
using ProjectEstimationTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Tls;
using Microsoft.Data.SqlClient;
using ProjectEstimationTool.Properties;
using iTextSharp.text;
using System.Diagnostics;


namespace ProjectEstimationTool
{
    public partial class ResourceCostingUserControl : UserControl
    {
        // private ResourceCosting Res { get; set; }
        private int timelineid;
        private int Hourlyrate;
        private int Monthlyhours;
        private int Months;
        private int Monthlyrate;
        private int Cost;
        private string phase;

        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        private BindingList<ProjectEstimationTool.Models.ResourceCosting> resourceCostings;

        public ResourceCostingUserControl()
        {
            InitializeComponent();
            resourceCostings = new BindingList<ProjectEstimationTool.Models.ResourceCosting>();
            dataGridView1 = new DataGridView(); // This line is not needed because dataGridView1 is already defined in the designer

            // Set properties and event handlers for dataGridView1
            dataGridView1.DataSource = resourceCostings;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = true;

            // Load combo box data and default rows
            LoadComboBoxData(); // This method should populate the combo boxes
            LoadDefaultRows();



        }
        public void LoadComboBoxData()
        {
            try
            {
                // Ensure that the DataGridView allows user additions
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.DataSource = null; // Unbind the DataGridView (if needed)

                // Populate the Phase combo box with data
                var phases = db.Timeline
                    .Where(t => t.ProjectId == Form1.projectid)
                    .Select(t => t.Phase)
                    .ToList();
                if (dataGridView1 != null)
                {
                    // Check if the "Phase" column exists
                    if (dataGridView1.Columns.Contains("ph"))
                    {
                        // The "Phase" column exists, proceed with setting its DataSource
                        DataGridViewComboBoxColumn phaseColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["Phase"];
                        phaseColumn.DataSource = phases;
                    }
                    else
                    {
                        // The "Phase" column does not exist
                        MessageBox.Show("The 'Phase' column is not found in dataGridView1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // dataGridView1 is null, handle the situation accordingly
                    MessageBox.Show("dataGridView1 is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // DataGridViewComboBoxColumn phaseColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["Phase"];
                // phaseColumn.DataSource = phases;

                // Populate the Country combo box with data
                var countries = db.Country
                    .Where(c => c.ProjectId == Form1.projectid)
                    .Select(c => c.CountryName)
                    .Distinct()
                    .ToList();

                DataGridViewComboBoxColumn countryColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["Country"];
                countryColumn.DataSource = countries;

                // Populate the ResType combo box with data
                var resourceTypes = db.ResourceTypes
                    .Where(rt => rt.ProjectId == Form1.projectid)
                    .Select(rt => rt.TypeName)
                    .Distinct()
                    .ToList();
                DataGridViewComboBoxColumn resTypeColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["ResType"];
                resTypeColumn.DataSource = resourceTypes;

                // Populate the RoleLevel combo box with data
                var roleLevels = db.ResourceLevel
                    .Where(rl => rl.ProjectId == Form1.projectid)
                    .Select(rl => rl.LevelName)
                    .Distinct()
                    .ToList();
                DataGridViewComboBoxColumn roleLevelColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["RoleLevel"];
                roleLevelColumn.DataSource = roleLevels;
            }
            catch (Exception ex)
            {
                // Log the exception
                Debug.WriteLine("Error in LoadComboBoxData: " + ex.Message);
                // Optionally rethrow the exception if needed
                throw;
            }
        }




        private void LoadDefaultRows()
        {
            try
            {

                // Fetch distinct phases from the database
                var defaultPhases = db.Timeline
                                    .Where(phase => phase.ProjectId == Form1.projectid)
                                    .Select(phase => phase.Phase)
                                    .Distinct()
                                    .ToList();

                // Populate ResourceCosting2List and deduct allocated counts from default values
                foreach (var phase in defaultPhases)
                {
                    // Fetch default resource count for the phase
                    int defaultCount = db.Timeline
                                        .Where(item => item.Phase == phase && item.ProjectId == Form1.projectid)
                                        .Select(item => item.ResReq)
                                        .FirstOrDefault();

                    // Fetch allocated count for the phase
                    int allocatedCount = db.ResourceCosting
                                            .Where(item => item.Phase == phase && item.ProjectId == Form1.projectid)
                                            .Select(item => item.ResCount)
                                            .Sum();

                    // Calculate remaining count by deducting allocated count from default count
                    int remainingCount = defaultCount - allocatedCount;

                    // Add to ResourceCosting2List only if remainingCount is greater than 0
                    if (remainingCount >= 0)
                    {
                        resourceCostings.Add(new ResourceCosting
                        {
                            Phase = phase,
                            ResCount = remainingCount,
                            DurationMm = db.Timeline
                                                .Where(item => item.Phase == phase && item.ProjectId == Form1.projectid)
                                                .Select(item => item.Mm)
                                                .FirstOrDefault()
                        });
                    }
                }

                // Set the DataGridView data source
                dataGridView1.DataSource = resourceCostings;

                // Set the default phases as the DataSource for the phase column in the DataGridView
                DataGridViewComboBoxColumn phaseColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["Phase"];
                phaseColumn.DataSource = defaultPhases;

                // Lock the allocation columns
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["ResCount"].ReadOnly = true;
                    dataGridView1.Rows[i].Cells["DurationMm"].ReadOnly = true;
                    dataGridView1.Rows[i].Cells["ResCount"].Style.BackColor = Color.Gray;
                    dataGridView1.Rows[i].Cells["DurationMm"].Style.BackColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //private void LoadDefaultRows()
        //{
        //    try
        //    {
        //        // Fetch default phases from the database
        //        var defaultPhases = (from phase in db.Timeline
        //                             where phase.ProjectId == Form1.projectid
        //                             select phase.Phase).ToList();

        //        // Clear existing rows
        //        dataGridView1.Rows.Clear();
        //        dataGridView1.AutoGenerateColumns = false;


        //        // Add default rows to the DataGridView
        //        foreach (var phase in defaultPhases)
        //        {
        //            // Fetch default resource count and duration for the phase
        //            var defaultData = db.Timeline
        //                                .FirstOrDefault(item => item.Phase == phase && item.ProjectId == Form1.projectid);

        //            if (defaultData != null)
        //            {
        //                int defaultCount = defaultData.ResReq;
        //                int defaultDuration = defaultData.Mm;

        //                // Calculate remaining resources required for the default phase
        //                int resPending = CalculateRemainingResources(phase, defaultCount);

        //                // Add default row to the DataGridView
        //                DataGridViewRow defaultRow = new DataGridViewRow();
        //                defaultRow.CreateCells(dataGridView1);
        //                defaultRow.Cells[1].Value = phase; // Assuming the first column is for Phase
        //                defaultRow.Cells[2].Value = resPending; // Assuming the second column is for ResCount
        //                defaultRow.Cells[8].Value = defaultDuration; // Assuming the third column is for DurationMm
        //                defaultRow.DefaultCellStyle.BackColor = Color.LightGray; // Color for default rows
        //                dataGridView1.Rows.Add(defaultRow);
        //            }
        //        }

        //        // Add allocated rows to the DataGridView
        //        foreach (var phase in defaultPhases)
        //        {
        //            // Fetch allocated resources for the phase
        //            var allocatedResources = db.ResourceCosting
        //                                        .Where(item => item.Phase == phase && item.ProjectId == Form1.projectid)
        //                                        .ToList();

        //            // Add allocated ResourceCosting entries to the DataGridView
        //            foreach (var allocatedResource in allocatedResources)
        //            {
        //                DataGridViewRow allocatedRow = new DataGridViewRow();
        //                allocatedRow.CreateCells(dataGridView1);
        //                allocatedRow.Cells[1].Value = allocatedResource.Phase; // Assuming the first column is for Phase
        //                allocatedRow.Cells[4].Value = allocatedResource.Country;
        //                allocatedRow.Cells[3].Value = allocatedResource.ResType;
        //                allocatedRow.Cells[5].Value = allocatedResource.RoleLevel;
        //                allocatedRow.Cells[2].Value = allocatedResource.ResCount; // Assuming the second column is for ResCount
        //                allocatedRow.Cells[7].Value = allocatedResource.MonthlyRate;
        //                allocatedRow.Cells[6].Value = allocatedResource.HourlyRate;
        //                allocatedRow.Cells[8].Value = allocatedResource.DurationMm; // Assuming the third column is for DurationMm
        //                allocatedRow.Cells[9].Value = allocatedResource.Cost;
        //                dataGridView1.Rows.Add(allocatedRow);
        //            }
        //        }

        //        // Set the default phases as the DataSource for the phase column in the DataGridView
        //        DataGridViewComboBoxColumn phaseColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["Phases"];
        //        phaseColumn.DataSource = defaultPhases;

        //        // Lock certain columns and style default rows
        //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //        {
        //            // Check if the row is a default row (colored)
        //            if (dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.LightGray)
        //            {
        //                dataGridView1.Rows[i].Cells["ResCount"].ReadOnly = false;
        //                dataGridView1.Rows[i].Cells["ResCount"].Style.BackColor = Color.Gray;
        //                dataGridView1.Rows[i].Cells["DurationMm"].ReadOnly = true;
        //                dataGridView1.Rows[i].Cells["DurationMm"].Style.BackColor = Color.Gray;
        //            }
        //            else
        //            {
        //                // Allocated rows remain normal (not colored or locked)
        //                dataGridView1.Rows[i].Cells["ResCount"].ReadOnly = false;
        //                dataGridView1.Rows[i].Cells["DurationMm"].ReadOnly = true;
        //            }
        //        }

        //        // Hide the ResourceCostingId column
        //        //dataGridView1.Columns["ResourceCostingIdss"].Visible = false;
        //        dataGridView1.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        // Helper method to calculate remaining resources for a default phase
        private int CalculateRemainingResources(string phase, int defaultCount)
        {
            // Fetch allocated resources count for the phase
            var allocatedResources = db.ResourceCosting
                                        .Where(item => item.Phase == phase && item.ProjectId == Form1.projectid)
                                        .ToList();

            // Calculate total allocated resources (sum of ResCount)
            int totalAllocated = allocatedResources.Sum(item => item.ResCount);

            // Calculate remaining resources required
            int resPending = defaultCount - totalAllocated;
            return resPending;
        }


        public void RefreshData()
        {
            var res = from t in db.ResourceCosting
                      where t.ProjectId == Form1.projectid
                      select t;
            dataGridView1.DataSource = res.ToList();



        }
        public void UpdateResourceCosting()
        {

            // fetch resourcecosting data from the database
            var resourcecostingdata = db.ResourceCosting.Where(rc => rc.ProjectId == Form1.projectid).ToList();

            // add the fetched data to the resourcecostings list
            foreach (var resourcecosting in resourcecostingdata)
            {
                resourceCostings.Add(resourcecosting);
            }
            dataGridView1.DataSource = resourceCostings;

            // Set the DataGridView data source
        }

        private void ResourceCostingUserControl_Load(object sender, EventArgs e)
        {



        }
        public void Rateformula(string country, string resourcetype, string rolelevel, string phase, int rescount)
        {
            Hourlyrate = (from rate in db.Resource
                          where rate.CountryName.Contains(country) && rate.TypeName.Contains(resourcetype) && rate.LevelName.Contains(rolelevel) && rate.ProjectId == Form1.projectid
                          select rate.HourlyRate).FirstOrDefault();
            Monthlyhours = (from hours in db.Productivity
                            where hours.ProductivityName == "Month" && hours.ProjectId == Form1.projectid
                            select hours.Hours).FirstOrDefault();
            Months = (from mm in db.Timeline
                      where mm.Phase == phase && mm.ProjectId == Form1.projectid
                      select mm.Mm).FirstOrDefault();
            Monthlyrate = Hourlyrate * Monthlyhours * rescount;
            Cost = Monthlyrate * Months;

        }





        private void button6_Click(object sender, EventArgs e)
        {
            Timeline tm = new Timeline();
            this.Hide();
            this.Parent.Controls.Add(tm);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            SummaryUserControl ra = new SummaryUserControl();
            this.Hide();
            this.Parent.Controls.Add(ra);

            MasterUserControl m = new MasterUserControl();


        }








        private void CalculateAndSaveResourceCosting(ResourceCosting resourceCosting)
        {
            // Calculate and update the ResourceCosting properties
            Rateformula(resourceCosting.Country, resourceCosting.ResType, resourceCosting.RoleLevel, resourceCosting.Phase, resourceCosting.ResCount);

            resourceCosting.HourlyRate = Hourlyrate;
            resourceCosting.MonthlyRate = Monthlyrate;
            resourceCosting.Cost = Cost;
            resourceCosting.DurationMm = Months;
            // Save changes to the database
            db.SaveChanges();
        }





        // Set the data source for the Phase column



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
        public void UpdateResourceCostTimeline()
        {
            try
            {
                var ResourceCosts = db.ResourceCosting
           .Where(se => se.ProjectId == Form1.projectid)
           .ToList();
                dataGridView1.DataSource = ResourceCosts;

                foreach (var resource in ResourceCosts)
                {
                    var timelinedata = db.Timeline
                .Where(t => t.TimelineId == resource.TimelineId && t.ProjectId == Form1.projectid)
                .FirstOrDefault();
                    var resrate = db.Resource
                   .Where(t => t.ResourceId == resource.ResourceId && t.ProjectId == Form1.projectid)
                     .FirstOrDefault();
                    if (timelinedata != null && resrate != null)
                    {
                        resource.DurationMm = timelinedata.Mm;
                        resource.Phase = timelinedata.Phase;
                        resource.RoleLevel = resrate.LevelName;
                        resource.ResType = resrate.TypeName;
                        resource.Country = resrate.CountryName;


                        Rateformula(resrate.CountryName, resrate.TypeName, resrate.LevelName, timelinedata.Phase, resource.ResCount);

                        resource.HourlyRate = resrate.HourlyRate;
                        resource.MonthlyRate = resource.HourlyRate * Monthlyhours * resource.ResCount;
                        resource.Cost = resource.DurationMm * resource.MonthlyRate;
                        // Updated code to ensure the correct update
                        resource.Country = resrate.CountryName;
                        resource.ResType = resrate.TypeName;
                        db.SaveChanges();

                    }
                }

            }
            catch
            {
            }
        }


        private void resourceCostingBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
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
                    string selectedPhase = editedRow.Cells["Phase"].Value?.ToString();
                    string selectedCountry = editedRow.Cells["Country"].Value?.ToString();
                    string selectedResourceType = editedRow.Cells["ResType"].Value?.ToString();
                    string selectedRoleLevel = editedRow.Cells["RoleLevel"].Value?.ToString();

                    // Retrieve the ResourceCosting object for the edited row
                    var editedResourceCosting = dataGridView1.Rows[rowIndex].DataBoundItem as ResourceCosting;

                    if (editedResourceCosting != null)
                    {
                        // Update ResourceCosting properties based on the edited cell
                        switch (dataGridView1.Columns[columnIndex].Name)
                        {
                            case "Phase":
                                editedResourceCosting.Phase = selectedPhase;
                                break;
                            case "Country":
                                editedResourceCosting.Country = selectedCountry;
                                break;
                            case "ResType":
                                editedResourceCosting.ResType = selectedResourceType;
                                break;
                            case "RoleLevel":
                                editedResourceCosting.RoleLevel = selectedRoleLevel;
                                break;
                            case "ResCount":
                                if (int.TryParse(editedRow.Cells["ResCount"].Value?.ToString(), out int resCount))
                                {
                                    editedResourceCosting.ResCount = resCount;
                                    Rateformula(selectedCountry, selectedResourceType, selectedRoleLevel, selectedPhase, resCount);
                                    editedResourceCosting.HourlyRate = Hourlyrate;
                                    editedResourceCosting.MonthlyRate = Monthlyrate;
                                    editedResourceCosting.Cost = Cost;
                                    editedResourceCosting.DurationMm = Months;
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
                            int ResCount = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ResCount"].Value);
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
                                MonthlyRate = Monthlyrate,// Include MonthlyRate
                                Cost = Cost
                            };

                            // Add the new record to the database and save changes
                            db.ResourceCosting.Add(adddata);
                            db.SaveChanges();
                            MessageBox.Show("New resource costing added successfully");
                        }
                        else
                        {
                            // Update existing ResourceCosting record in the database
                            db.SaveChanges(); // Save changes after updating
                            MessageBox.Show("Resource costing updated successfully");
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

        private void dataGridView1_KeyDown_1(object sender, KeyEventArgs e)
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
                        int rowIndex = -1; // Declare rowIndex outside of the try block

                        try
                        {
                            // Get the index of the selected row
                            rowIndex = dataGridView1.SelectedRows[0].Index;

                            // Get the ResourceCostingId of the selected row
                            int resourceCostingId = (int)dataGridView1.Rows[rowIndex].Cells["ResourceCostingIdss"].Value;

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
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is SqlException sqlEx && sqlEx.Number == 547) // Check if it's a foreign key constraint violation
                            {
                                if (rowIndex != -1)
                                {
                                    // Remove the row from the DataGridView even if the deletion from the database failed
                                    dataGridView1.Rows.RemoveAt(rowIndex);
                                }
                                MessageBox.Show("The selected record cannot be deleted because it is referenced by other records.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show($"Error deleting row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


