using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

namespace ProjectEstimationTool
{
    public partial class ResourceLevelUserControl : UserControl
    {
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        private ResourceLevel leveldata;
        BindingList<ResourceLevel> resleveldata;
        int levelid;
        public ResourceLevelUserControl()
        {
            InitializeComponent();
            resleveldata = new BindingList<ResourceLevel>();
            LoadResourceLevelData();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = true;
         //   dataGridView1.RowsAdded += DataGridView1_RowsAdded;


        }
        private void LoadResourceLevelData()
        {
            try
            {
                if (Form1.projectid == null)
                {
                    MessageBox.Show("Project ID is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var res = db.ResourceLevel.Where(t => t.ProjectId == Form1.projectid).ToList();
                resleveldata.Clear();
                foreach (var item in res)
                {
                    resleveldata.Add(item);
                }
                dataGridView1.DataSource = resleveldata;

            }
            catch (Exception ex)
            {

            }


        }


        private void ResourceLevelUserControl_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private bool ResourceLevelExists(string name, int currentResourceLevelId)
        {
            // Check if the resource level name already exists in the database (case-insensitive)
            var existingResourceLevel = db.ResourceLevel
                .FirstOrDefault(rl =>
                    rl.ProjectId == Form1.projectid &&
                    rl.LevelName.ToLower() == name.ToLower() &&
                    rl.LevelId != currentResourceLevelId);

            return existingResourceLevel != null;
        }
        private bool ResourceLevelExists1(string name)
        {
            // Check if the resource level name already exists in the database (case-insensitive)
            var existingResourceLevel = db.ResourceLevel
                .FirstOrDefault(rl =>
                    rl.ProjectId == Form1.projectid &&
                    rl.LevelName.ToLower() == name.ToLower() 
                  );

            return existingResourceLevel != null;
        }


        private bool IsValidResourceLevelName(string levelName)
        {
            // Check if the input contains only letters
            return !string.IsNullOrWhiteSpace(levelName) && levelName.Any(c => char.IsLetter(c)) && levelName.Any(c => char.IsDigit(c));

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ResourceTypeUserControl rc = new ResourceTypeUserControl();
            this.Hide();
            this.Parent.Controls.Add(rc);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ResourceRateUserControl rt = new ResourceRateUserControl();
            this.Hide();
            this.Parent.Controls.Add(rt);
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == dataGridView1.Columns["LevelName"].Index)
            //    {
            //        int newRowIdx = dataGridView1.Rows.Count - 1;
            //        string enteredValue = dataGridView1.Rows[e.RowIndex].Cells["LevelName"].Value?.ToString()?.Trim();

            //        if (string.IsNullOrEmpty(enteredValue))
            //        {
            //            MessageBox.Show("Please enter a resource level name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        if (!IsValidResourceLevelName(enteredValue))
            //        {
            //            MessageBox.Show("Please enter a valid resource level name (letters, hyphens, or whitespace).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        // Verify LevelId column index (adjust if needed)
            //        int levelIdColumnIndex = dataGridView1.Columns["LevelIds"].Index;

            //        // Check if it's a new row or an existing row being edited
            //        bool isNewRow = e.RowIndex == newRowIdx;

            //        // Ensure that Form1.projectid is not null
            //        if (Form1.projectid == null)
            //        {
            //            MessageBox.Show("Project ID is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        if (isNewRow)
            //        {
            //            // Handle adding a new row
            //            if (ResourceLevelExists(enteredValue, 0))
            //            {
            //                MessageBox.Show("This name already exists. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return;
            //            }

            //            // Save changes to the database within a try-catch block
            //            try
            //            {

            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show($"Error saving resource level: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //        else
            //        {
            //            // Handle editing an existing row
            //            int levelId;
            //            try
            //            {
            //                levelId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[levelIdColumnIndex].Value);
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show($"Error retrieving LevelId: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return;
            //            }

            //            if (ResourceLevelExists(enteredValue, levelId))
            //            {
            //                MessageBox.Show("This name already exists for another resource level. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return;
            //            }

            //            var resourceLevelToUpdate = db.ResourceLevel.FirstOrDefault(rl => rl.LevelId == levelId);
            //            if (resourceLevelToUpdate != null)
            //            {
            //                resourceLevelToUpdate.LevelName = enteredValue;

            //                // Save changes within a try-catch block
            //                try
            //                {
            //                    db.SaveChanges();
            //                    MessageBox.Show("Resource level updated successfully.");
            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show($"Error saving to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //            }
            //            else
            //            {
            //                var newResourceLevel = new ResourceLevel
            //                {
            //                    ProjectId = Form1.projectid,
            //                    LevelName = enteredValue
            //                };
            //                db.ResourceLevel.Add(newResourceLevel);
            //                db.SaveChanges();
            //                MessageBox.Show("Resource level added successfully.");
            //                LoadResourceLevelData();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
            //======================================================
            //    try
            //    {
            //        if (e.ColumnIndex == dataGridView1.Columns["LevelName"].Index)
            //        {
            //            int newRowIdx = dataGridView1.Rows.Count - 1;
            //            string enteredValue = dataGridView1.Rows[e.RowIndex].Cells["LevelName"].Value?.ToString()?.Trim();
            //            string originalValue = enteredValue; // Store the original value

            //            if (string.IsNullOrEmpty(enteredValue))
            //            {
            //                MessageBox.Show("Please enter a resource level name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return;
            //            }

            //            // Validate the entered value
            //            if (!IsValidResourceLevelName(enteredValue))
            //            {
            //                MessageBox.Show("Please enter a valid resource level name (only numeric characters without spaces or special characters).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                // Restore the original value if validation fails
            //                dataGridView1.Rows[e.RowIndex].Cells["LevelName"].Value = originalValue;
            //                return;
            //            }

            //            // Verify LevelId column index (adjust if needed)
            //            int levelIdColumnIndex = dataGridView1.Columns["LevelIds"].Index;

            //            // Check if it's a new row or an existing row being edited
            //            bool isNewRow = e.RowIndex == newRowIdx;

            //            // Ensure that Form1.projectid is not null
            //            if (Form1.projectid == null)
            //            {
            //                MessageBox.Show("Project ID is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return;
            //            }

            //            if (isNewRow)
            //            {
            //                // Handle adding a new row
            //                if (ResourceLevelExists(enteredValue, 0))
            //                {
            //                    MessageBox.Show("This name already exists. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    // dataGridView1.Rows[dataGridView1.NewRowIndex].Cells["LevelName"].Value = "";
            //                    dataGridView1.Rows[e.RowIndex].Cells["LevelName"].Value = "";
            //                    return;
            //                }

            //                // Save changes to the database within a try-catch block
            //                try
            //                {
            //                    var newResourceLevel = new ResourceLevel
            //                    {
            //                        ProjectId = Form1.projectid,
            //                        LevelName = enteredValue
            //                    };
            //                    db.ResourceLevel.Add(newResourceLevel);
            //                    db.SaveChanges();
            //                    MessageBox.Show("Resource level added successfully.");
            //                    LoadResourceLevelData(); // Reload resource level data after adding
            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show($"Error saving resource level: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //            }
            //            else
            //            {
            //                // Handle editing an existing row
            //                int levelName;
            //                try
            //                {
            //                    levelName = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[levelIdColumnIndex].Value);
            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show($"Error retrieving LevelId: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }

            //                if (ResourceLevelExists(enteredValue, levelName))
            //                {
            //                    MessageBox.Show("This name already exists for another resource level. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    // Restore the original value if validation fails
            //                    dataGridView1.Rows[e.RowIndex].Cells["LevelName"].Value = originalValue;
            //                    return;
            //                }
            //                if(ResourceLevelExists1(enteredValue))
            //                {
            //                    MessageBox.Show("This name already exists for another resource level. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    //dataGridView1.Rows[e.RowIndex].Cells["LevelName"].Value = originalValue;
            //                    db.SaveChanges();
            //                    return;
            //                }
            //                var resourceLevelToUpdate = db.ResourceLevel.FirstOrDefault(rl => rl.LevelId == levelid);
            //                if (resourceLevelToUpdate != null)
            //                {
            //                    resourceLevelToUpdate.LevelName = enteredValue;

            //                    // Save changes within a try-catch block
            //                    try
            //                    {
            //                        db.SaveChanges();
            //                        MessageBox.Show("Resource level updated successfully.");
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        MessageBox.Show($"Error saving to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    }
            //                }
            //                else
            //                {
            //                    //MessageBox.Show("Resource level not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    var newResourceLevel = new ResourceLevel
            //                    {
            //                        ProjectId = Form1.projectid,
            //                        LevelName = enteredValue
            //                    };
            //                    db.ResourceLevel.Add(newResourceLevel);
            //                    db.SaveChanges();
            //                    MessageBox.Show("Resource level added successfully.");
            //                    LoadResourceLevelData();
            //                }
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}


            try
{
                if (e.ColumnIndex == dataGridView1.Columns["LevelName"].Index)
                {
                    int newRowIdx = dataGridView1.Rows.Count - 1;
                    string enteredValue = dataGridView1.Rows[e.RowIndex].Cells["LevelName"].Value?.ToString()?.Trim();
                    string originalValue = enteredValue; // Store the original value

                    if (string.IsNullOrEmpty(enteredValue))
                    {
                        MessageBox.Show("Please enter a resource level name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Validate the entered value
                    if (!IsValidResourceLevelName(enteredValue))
                    {
                        MessageBox.Show("Please enter a valid resource level name (only alphanumeric characters without spaces or special characters).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Clear the cell and restore the original value if validation fails
                        dataGridView1.Rows[e.RowIndex].Cells["LevelName"].Value = "";
                        return;
                    }

                    // Verify LevelId column index (adjust if needed)
                    int levelIdColumnIndex = dataGridView1.Columns["LevelIds"].Index;

                    // Check if it's a new row or an existing row being edited
                    bool isNewRow = e.RowIndex == newRowIdx;

                    // Ensure that Form1.projectid is not null
                    if (Form1.projectid == null)
                    {
                        MessageBox.Show("Project ID is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (isNewRow)
                    {
                        // Handle adding a new row
                        if (ResourceLevelExists(enteredValue, 0))
                        {
                            MessageBox.Show("This name already exists. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // Clear the cell if duplicate data is entered
                            dataGridView1.Rows[e.RowIndex].Cells["LevelName"].Value = "";
                            return;
                        }

                        // Save changes to the database within a try-catch block
                        try
                        {
                            var newResourceLevel = new ResourceLevel
                            {
                                ProjectId = Form1.projectid,
                                LevelName = enteredValue
                            };
                            db.ResourceLevel.Add(newResourceLevel);
                            db.SaveChanges();
                            MessageBox.Show("Resource level added successfully.");
                            LoadResourceLevelData(); // Reload resource level data after adding
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error saving resource level: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Handle editing an existing row
                        int levelId;
                        try
                        {
                            levelId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[levelIdColumnIndex].Value);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error retrieving LevelId: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (ResourceLevelExists(enteredValue, levelId))
                        {
                            MessageBox.Show("This name already exists for another resource level. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // Clear the cell if duplicate data is entered
                            dataGridView1.Rows[e.RowIndex].Cells["LevelName"].Value = "";
                            return;
                        }

                        var resourceLevelToUpdate = db.ResourceLevel.FirstOrDefault(rl => rl.LevelId == levelId);
                        if (resourceLevelToUpdate != null)
                        {
                            resourceLevelToUpdate.LevelName = enteredValue;

                            // Save changes within a try-catch block
                            try
                            {
                                db.SaveChanges();
                                MessageBox.Show("Resource level updated successfully.");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error saving to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            // If resource level not found, treat it as a new addition
                            var newResourceLevel = new ResourceLevel
                            {
                                ProjectId = Form1.projectid,
                                LevelName = enteredValue
                            };
                            db.ResourceLevel.Add(newResourceLevel);
                            try
                            {
                                db.SaveChanges();
                                MessageBox.Show("Resource level added successfully.");
                                LoadResourceLevelData();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error saving resource level: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
catch (Exception ex)
{
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
            //private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
            //{
            //    // Check if the new row is being added
            //    if (e.RowIndex == dataGridView1.NewRowIndex)
            //    {
            //        // Handle adding a new row
            //        if (ResourceLevelExists(enteredValue, 0))
            //        {
            //            MessageBox.Show("This name already exists. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //            // Clear the value in the "LevelName" column of the new row
            //            dataGridView1.Rows[e.RowIndex].Cells["LevelName"].Value = "";

            //            // Optionally, you can also set focus to this cell
            //            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells["LevelName"];

            //            return;
            //        }
            //    }
            //}
            private void ReloadPreviousData(int rowIndex, string originalValue)
        {
            // Reload the previous data into the cell
            dataGridView1.Rows[rowIndex].Cells["LevelName"].Value = originalValue;
        }




        private void DeleteDependentResourceRecords(int levelId)
        {
            // Example: Querying and deleting dependent records
            var dependentRecords = db.Resource.Where(r => r.LevelId == levelId).ToList();
            // Delete dependent records
            db.Resource.RemoveRange(dependentRecords);
            // Save changes after removing the dependent records
            db.SaveChanges();
            // Retry deleting the record in the 'ResourceLevels' table
            LoadResourceLevelData();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                        if (selectedRow.DataBoundItem is ResourceLevel selectedResourceLevel)
                        {
                            int levelId = selectedResourceLevel.LevelId;

                            try
                            {
                                // Attempt to delete the record in the 'ResourceLevels' table
                                var resourceLevelToDelete = db.ResourceLevel.FirstOrDefault(rl => rl.LevelId == levelId);

                                if (resourceLevelToDelete != null)
                                {
                                    db.ResourceLevel.Remove(resourceLevelToDelete);
                                    db.SaveChanges();
                                   // LoadResourceLevelData();
                                }
                            }
                            catch (DbUpdateException ex)
                            {
                                // Check if the exception is due to a foreign key constraint violation
                                if (ex.InnerException is SqlException sqlException && sqlException.Number == 547)
                                {
                                    // Handle foreign key constraint violation by deleting dependent records in the 'Resource' table
                                    DeleteDependentResourceRecords(levelId);
                                }
                                else
                                {
                                    // Handle other types of exceptions or log the error
                                    MessageBox.Show("An error occurred while deleting the record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}