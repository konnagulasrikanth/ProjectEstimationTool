using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Tls;
using Org.BouncyCastle.Ocsp;
using ProjectEstimationTool.Models;
using ProjectEstimationTool.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectEstimationTool
{
    public partial class ResourceRateUserControl : UserControl
    {
        private Resource selecteddata;
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        BindingList<Resource> resources;

        public ResourceRateUserControl()
        {
            InitializeComponent();
            resources = new BindingList<Resource>();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.DataError += dataGridView1_DataError;




        }

        private void LoadComboBoxData()
        {

            var countryNames = db.Country
                    .Where(c => c.ProjectId == Form1.projectid)
                    .Select(t => t.CountryName)
                    .Distinct().ToList();
            DataGridViewComboBoxColumn countryColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["CountryNames"];
            countryColumn.DataSource = countryNames;

            // Populate the resource type combo box with data
            var resourceTypes = db.ResourceTypes
                .Where(rt => rt.ProjectId == Form1.projectid)
                .Select(t => t.TypeName)
                .Distinct().ToList();
            DataGridViewComboBoxColumn typeColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["TypeNames"];
            typeColumn.DataSource = resourceTypes;

            // Populate the resource level combo box with data
            var resourceLevels = db.ResourceLevel
                .Where(rl => rl.ProjectId == Form1.projectid)
                .Select(t => t.LevelName)
                .Distinct().ToList();
            DataGridViewComboBoxColumn levelColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["LevelNames"];
            levelColumn.DataSource = resourceLevels;
            LoadDefaultResourceData();



        }
        private void ResourceRateUserControl_Load(object sender, EventArgs e)
        {

            UpdateResource();
            LoadComboBoxData();
            int hourlyRateColumnIndex = dataGridView1.Columns["HourlyRate"].Index;

            // Hook into the CellFormatting event to format the HourlyRate column
            dataGridView1.CellFormatting += (s, ev) =>
            {
                // Check if the current cell is in the HourlyRate column
                if (ev.ColumnIndex == hourlyRateColumnIndex && ev.RowIndex >= 0)
                {
                    // Get the value from the cell
                    if (decimal.TryParse(ev.Value?.ToString(), out decimal hourlyRate))
                    {
                        // Format the value with the dollar symbol
                        ev.Value = string.Format("${0:N2}", hourlyRate);
                        ev.FormattingApplied = true; // Set this to true to indicate the value has been formatted
                    }
                }
            };

        }










        private void LoadDefaultResourceData()
        {
            // Clear the resources list
            resources.Clear();

            // Fetch resources from the database
            var res = db.Resource.Where(t => t.ProjectId == Form1.projectid).ToList();

            // Add the fetched resources to the resources list
            foreach (Resource resource in res)
            {
                resources.Add(resource);
            }

            // Set the DataGridView data source
            dataGridView1.DataSource = resources;
        }




        private bool IsDuplicateResource(string country, string resourceType, string resourceLevel)
        {
            //int currentResourceId = db.Resource.Where(c=>c.CountryName==country&&c.TypeName ==resourceType && c.LevelName==resourceLevel).Select(p=>p.ResourceId).FirstOrDefault();
            return db.Resource.Any(r =>
                r.ProjectId == Form1.projectid &&
                r.CountryName == country &&
                r.TypeName == resourceType &&
                r.LevelName == resourceLevel);
        }
        private bool IsDuplicateResourceEdit(string country, string resourceType, string resourceLevel, int currentResourceId)
        {
            // Check if the resource entry already exists in the database (case-insensitive)
            var existingResource = db.Resource
                .FirstOrDefault(r =>
                    r.ProjectId == Form1.projectid &&
                    r.CountryName.ToLower() == country.ToLower() &&
                    r.TypeName.ToLower() == resourceType.ToLower() &&
                    r.LevelName.ToLower() == resourceLevel.ToLower() &&
                    r.ResourceId != currentResourceId);

            return existingResource != null;
        }



        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private void UpdateResource()
        {
            try
            {
                var ResourceRecords = db.Resource
                    .Where(se => se.ProjectId == Form1.projectid)
                    .ToList();
                dataGridView1.DataSource = ResourceRecords;
                // Fetch updated FunctionalArea records from the database
                foreach (var ResourceRecord in ResourceRecords)
                {
                    var countrydata = db.Country
                 .Where(t => t.CountryId == ResourceRecord.CountryId && t.ProjectId == Form1.projectid)
                 .FirstOrDefault();
                    var reslevel = db.ResourceLevel
                   .Where(t => t.LevelId == ResourceRecord.LevelId && t.ProjectId == Form1.projectid)
                     .FirstOrDefault();
                    var restype = db.ResourceTypes
                   .Where(t => t.ResourceTypeId == ResourceRecord.ResourceTypeId && t.ProjectId == Form1.projectid)
                       .FirstOrDefault();

                    if (ResourceRecord != null)
                    {
                        ResourceRecord.TypeName = restype.TypeName;
                        ResourceRecord.LevelName = reslevel.LevelName;
                        ResourceRecord.CountryName = countrydata.CountryName;

                        db.SaveChanges();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void button6_Click(object sender, EventArgs e)
        {
            ResourceLevelUserControl rl = new ResourceLevelUserControl();
            this.Hide();
            this.Parent.Controls.Add(rl);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SoftwarerateUserControl sr = new SoftwarerateUserControl();
            this.Hide();
            this.Parent.Controls.Add(sr);
        }


        //private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        int rowIndex = e.RowIndex;
        //        int columnIndex = e.ColumnIndex;

        //        // Check if the edited cell is within the data grid view bounds
        //        if (rowIndex >= 0 && columnIndex >= 0)
        //        {
        //            DataGridViewRow editedRow = dataGridView1.Rows[rowIndex];

        //            // Check if the edited cell is in the HourlyRate column
        //            if (dataGridView1.Columns[columnIndex].Name == "HourlyRate")
        //            {
        //                // Get values from the edited row
        //                string resourceType = editedRow.Cells["TypeNames"].Value?.ToString();
        //                string resourceLevel = editedRow.Cells["LevelNames"].Value?.ToString();
        //                string country = editedRow.Cells["CountryNames"].Value?.ToString();

        //                // Validate that the hourly rate is a valid integer
        //                if (!int.TryParse(editedRow.Cells["HourlyRate"].Value?.ToString(), out int hourlyRate))
        //                {
        //                    MessageBox.Show("Please enter a valid hourly rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return;
        //                }

        //                // Assuming you have an entity class named Resource
        //                var resource = db.Resource.FirstOrDefault(p =>
        //                    p.TypeName == resourceType &&
        //                    p.LevelName == resourceLevel &&
        //                    p.CountryName == country);

        //                if (resource != null)
        //                {
        //                    // Update resource properties based on the edited cell
        //                    switch (dataGridView1.Columns[columnIndex].Name)
        //                    {
        //                        case "TypeNames":
        //                            resource.TypeName = editedRow.Cells[columnIndex].Value?.ToString();
        //                            break;
        //                        case "LevelNames":
        //                            resource.LevelName = editedRow.Cells[columnIndex].Value?.ToString();
        //                            break;
        //                        case "CountryNames":
        //                            resource.CountryName = editedRow.Cells[columnIndex].Value?.ToString();
        //                            break;
        //                        case "HourlyRate":
        //                            resource.HourlyRate = Convert.ToInt32(editedRow.Cells[columnIndex].Value);
        //                            break;
        //                        default:
        //                            break;
        //                    }

        //                    // Save changes within a try-catch block
        //                    try
        //                    {
        //                        db.SaveChanges();
        //                        MessageBox.Show("Updated successfully");
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        // Display the specific error message from the inner exception
        //                        string errorMessage = ex.InnerException?.Message ?? ex.Message;
        //                        MessageBox.Show($"Error saving to the database: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    }
        //                }
        //                else
        //                {
        //                    //var resourceid = db.Resource.Where(r => r.ProjectId == Form1.projectid && r.TypeName == selectedResourceType).Select(r => r.ResourceId).FirstOrDefault();
        //                    var counid = db.Country.Where(t => t.ProjectId == Form1.projectid && t.CountryName == country).Select(t => t.CountryId).FirstOrDefault();
        //                    var typid = db.ResourceTypes.Where(t => t.ProjectId == Form1.projectid && t.TypeName == resourceType).Select(t => t.ResourceTypeId).FirstOrDefault();
        //                    var levid = db.ResourceLevel.Where(l => l.ProjectId == Form1.projectid && l.LevelName == resourceLevel).Select(l => l.LevelId).FirstOrDefault();
        //                    // Resource not found, add a new combination
        //                    var newResource = new Resource
        //                    {
        //                        ProjectId = Form1.projectid,
        //                        CountryId = counid,
        //                        ResourceTypeId = typid,
        //                        LevelId = levid,
        //                        TypeName = resourceType,
        //                        LevelName = resourceLevel,
        //                        CountryName = country,
        //                        HourlyRate = Convert.ToInt32(editedRow.Cells["HourlyRate"].Value)
        //                    };

        //                    // Save new resource within a try-catch block
        //                    try
        //                    {
        //                        db.Resource.Add(newResource);
        //                        db.SaveChanges();
        //                        MessageBox.Show("New resource added successfully");
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        // Display the specific error message from the inner exception
        //                        string errorMessage = ex.InnerException?.Message ?? ex.Message;
        //                        MessageBox.Show($"Error saving to the database: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

        //private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        int rowIndex = e.RowIndex;
        //        int columnIndex = e.ColumnIndex;

        //        // Check if the edited cell is within the data grid view bounds
        //        if (rowIndex >= 0 && columnIndex >= 0)
        //        {
        //            DataGridViewRow editedRow = dataGridView1.Rows[rowIndex];

        //            // Check if the edited cell is in the HourlyRate column
        //            if (dataGridView1.Columns[columnIndex].Name == "HourlyRate")
        //            {
        //                // Get values from the edited row
        //                string resourceType = editedRow.Cells["TypeNames"].Value?.ToString();
        //                string resourceLevel = editedRow.Cells["LevelNames"].Value?.ToString();
        //                string country = editedRow.Cells["CountryNames"].Value?.ToString();

        //                // Validate that the hourly rate is a valid integer
        //                string hourlyRateText = editedRow.Cells["HourlyRate"].Value?.ToString();
        //                if (!string.IsNullOrWhiteSpace(hourlyRateText) && int.TryParse(hourlyRateText, out int hourlyRate))
        //                {
        //                    // Assuming you have an entity class named Resource
        //                    var resource = db.Resource.FirstOrDefault(p =>
        //                        p.TypeName == resourceType &&
        //                        p.LevelName == resourceLevel &&
        //                        p.CountryName == country);

        //                    if (resource != null)
        //                    {
        //                        // Update resource properties based on the edited cell
        //                        switch (dataGridView1.Columns[columnIndex].Name)
        //                        {
        //                            case "TypeNames":
        //                                resource.TypeName = editedRow.Cells[columnIndex].Value?.ToString();
        //                                break;
        //                            case "LevelNames":
        //                                resource.LevelName = editedRow.Cells[columnIndex].Value?.ToString();
        //                                break;
        //                            case "CountryNames":
        //                                resource.CountryName = editedRow.Cells[columnIndex].Value?.ToString();
        //                                break;
        //                            case "HourlyRate":
        //                                resource.HourlyRate = hourlyRate;
        //                                break;
        //                            default:
        //                                break;
        //                        }

        //                        // Save changes within a try-catch block
        //                        try
        //                        {
        //                            db.SaveChanges();
        //                            MessageBox.Show("Updated successfully");
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            // Display the specific error message from the inner exception
        //                            string errorMessage = ex.InnerException?.Message ?? ex.Message;
        //                            MessageBox.Show($"Error saving to the database: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        //var resourceid = db.Resource.Where(r => r.ProjectId == Form1.projectid && r.TypeName == selectedResourceType).Select(r => r.ResourceId).FirstOrDefault();
        //                        var counid = db.Country.Where(t => t.ProjectId == Form1.projectid && t.CountryName == country).Select(t => t.CountryId).FirstOrDefault();
        //                        var typid = db.ResourceTypes.Where(t => t.ProjectId == Form1.projectid && t.TypeName == resourceType).Select(t => t.ResourceTypeId).FirstOrDefault();
        //                        var levid = db.ResourceLevel.Where(l => l.ProjectId == Form1.projectid && l.LevelName == resourceLevel).Select(l => l.LevelId).FirstOrDefault();
        //                        // Resource not found, add a new combination
        //                        var newResource = new Resource
        //                        {
        //                            ProjectId = Form1.projectid,
        //                            CountryId = counid,
        //                            ResourceTypeId = typid,
        //                            LevelId = levid,
        //                            TypeName = resourceType,
        //                            LevelName = resourceLevel,
        //                            CountryName = country,
        //                            HourlyRate = hourlyRate
        //                        };

        //                        // Save new resource within a try-catch block
        //                        try
        //                        {
        //                            db.Resource.Add(newResource);
        //                            db.SaveChanges();
        //                            MessageBox.Show("New resource added successfully");
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            // Display the specific error message from the inner exception
        //                            string errorMessage = ex.InnerException?.Message ?? ex.Message;
        //                            MessageBox.Show($"Error saving to the database: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Please enter a valid hourly rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        
        {
            try
            {
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;

                // Check if the edited cell is within the data grid view bounds
                if (rowIndex >= 0 && columnIndex >= 0)
                {
                    DataGridViewRow editedRow = dataGridView1.Rows[rowIndex];

                    // Check if the edited cell is in the HourlyRate column
                    if (dataGridView1.Columns[columnIndex].Name == "HourlyRate")
                    {
                        // Get values from the edited row
                        string resourceType = editedRow.Cells["TypeNames"].Value?.ToString();
                        string resourceLevel = editedRow.Cells["LevelNames"].Value?.ToString();
                        string country = editedRow.Cells["CountryNames"].Value?.ToString();

                        // Validate that the hourly rate is a valid integer
                        string hourlyRateText = editedRow.Cells["HourlyRate"].Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(hourlyRateText) && IsInteger(hourlyRateText))
                        {
                            int hourlyRate = int.Parse(hourlyRateText);
                            // Assuming you have an entity class named Resource
                            var resource = db.Resource.FirstOrDefault(p =>
                                p.TypeName == resourceType &&
                                p.LevelName == resourceLevel &&
                                p.CountryName == country);

                            if (resource != null)
                            {
                                // Update resource properties based on the edited cell
                                switch (dataGridView1.Columns[columnIndex].Name)
                                {
                                    case "TypeNames":
                                        resource.TypeName = editedRow.Cells[columnIndex].Value?.ToString();
                                        break;
                                    case "LevelNames":
                                        resource.LevelName = editedRow.Cells[columnIndex].Value?.ToString();
                                        break;
                                    case "CountryNames":
                                        resource.CountryName = editedRow.Cells[columnIndex].Value?.ToString();
                                        break;
                                    case "HourlyRate":
                                        resource.HourlyRate = hourlyRate;
                                        break;
                                    default:
                                        break;
                                }

                                // Save changes within a try-catch block
                                try
                                {
                                    db.SaveChanges();
                                    MessageBox.Show("Updated successfully");
                                }
                                catch (Exception ex)
                                {
                                    // Display the specific error message from the inner exception
                                    string errorMessage = ex.InnerException?.Message ?? ex.Message;
                                    MessageBox.Show($"Error saving to the database: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                //var resourceid = db.Resource.Where(r => r.ProjectId == Form1.projectid && r.TypeName == selectedResourceType).Select(r => r.ResourceId).FirstOrDefault();
                                var counid = db.Country.Where(t => t.ProjectId == Form1.projectid && t.CountryName == country).Select(t => t.CountryId).FirstOrDefault();
                                var typid = db.ResourceTypes.Where(t => t.ProjectId == Form1.projectid && t.TypeName == resourceType).Select(t => t.ResourceTypeId).FirstOrDefault();
                                var levid = db.ResourceLevel.Where(l => l.ProjectId == Form1.projectid && l.LevelName == resourceLevel).Select(l => l.LevelId).FirstOrDefault();
                                // Resource not found, add a new combination
                                var newResource = new Resource
                                {
                                    ProjectId = Form1.projectid,
                                    CountryId = counid,
                                    ResourceTypeId = typid,
                                    LevelId = levid,
                                    TypeName = resourceType,
                                    LevelName = resourceLevel,
                                    CountryName = country,
                                    HourlyRate = hourlyRate
                                };

                                // Save new resource within a try-catch block
                                try
                                {
                                    db.Resource.Add(newResource);
                                    db.SaveChanges();
                                    MessageBox.Show("New resource added successfully");
                                }
                                catch (Exception ex)
                                {
                                    // Display the specific error message from the inner exception
                                    string errorMessage = ex.InnerException?.Message ?? ex.Message;
                                    MessageBox.Show($"Error saving to the database: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid integer for hourly rate without spaces or special characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function to check if a string represents a valid integer
        private bool IsInteger(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Delete key is pressed
            if (e.KeyCode == Keys.Delete)
            {
                // Ensure that at least one row is selected
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Get the selected resource
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                        if (selectedRow.DataBoundItem is Resource selectedResource)
                        {
                            int resourceId = selectedResource.ResourceId;

                            // Find the resource in the database
                            var resourceToDelete = db.Resource.FirstOrDefault(r => r.ResourceId == resourceId);

                            // If the resource is found, delete it
                            if (resourceToDelete != null)
                            {
                                db.Resource.Remove(resourceToDelete);
                                db.SaveChanges();
                                LoadDefaultResourceData();
                            }
                        }
                    }
                }
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
    }
}
            
