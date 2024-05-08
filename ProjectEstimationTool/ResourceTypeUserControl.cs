using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities.Collections;
using ProjectEstimationTool.Models;
using ProjectEstimationTool.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectEstimationTool
{
    public partial class ResourceTypeUserControl : UserControl
    {

        private ResourceTypes selecteddata;
        private int rid;
        BindingList<ResourceTypes> typedata;


        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        public ResourceTypeUserControl()
        {
            InitializeComponent();
            typedata = new BindingList<ResourceTypes>();
            LoadResourceTypes();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = true;

        }
        public void LoadResourceTypes()
        {
            try
            {
                var types = db.ResourceTypes.Where(t => t.ProjectId == Form1.projectid).ToList();
                typedata.Clear();
                foreach (var type in types)
                {
                    typedata.Add(type);
                }
                dataGridView1.DataSource = typedata;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading data is not happening please check!");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ResourceTypeUserControl_Load(object sender, EventArgs e)
        {

        }



        private bool ResourceTypeExists(string name, int currentResourceTypeId)
        {
            // Check if the resource type name already exists in the database (case-insensitive)
            var existingResourceType = db.ResourceTypes
                .FirstOrDefault(rt =>
                    rt.ProjectId == Form1.projectid &&
                    rt.TypeName.ToLower() == name.ToLower() &&
                    rt.ResourceTypeId != currentResourceTypeId);

            return existingResourceType != null;
        }



        private bool IsValidResourceTypeName(string typeName)
        {
            // Check if the input contains only letters and spaces
            return !string.IsNullOrWhiteSpace(typeName) && typeName.All(c => char.IsLetter(c) || c == '-' || char.IsWhiteSpace(c));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CountryUserControl cr = new CountryUserControl();
            this.Hide();
            this.Parent.Controls.Add(cr);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ResourceLevelUserControl rl = new ResourceLevelUserControl();
            this.Hide();
            this.Parent.Controls.Add(rl);
        }
        private void DeleteDependentRecords(int resourceTypeId)
        {
            // Example: Querying and deleting dependent records
            var dependentRecords = db.Resource.Where(r => r.ResourceTypeId == resourceTypeId).ToList();
            // Delete dependent records
            db.Resource.RemoveRange(dependentRecords);
            // Save changes after removing the dependent records
            db.SaveChanges();
            // Retry deleting the record in the 'ResourceTypes' table
            LoadResourceTypes();
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

                        if (selectedRow.DataBoundItem is ResourceTypes selectedResource)
                        {
                            int resourceTypeId = selectedResource.ResourceTypeId;

                            try
                            {
                                // Attempt to delete the record in the 'ResourceTypes' table
                                var resourceToDelete = db.ResourceTypes.FirstOrDefault(rt => rt.ResourceTypeId == resourceTypeId);

                                if (resourceToDelete != null)
                                {
                                    db.ResourceTypes.Remove(resourceToDelete);
                                    db.SaveChanges();
                                    LoadResourceTypes();
                                }
                            }
                            catch (DbUpdateException ex)
                            {
                                // Check if the exception is due to a foreign key constraint violation
                                if (ex.InnerException is SqlException sqlException && sqlException.Number == 547)
                                {
                                    // Handle foreign key constraint violation by deleting dependent records in the 'Resource' table
                                    DeleteDependentRecords(resourceTypeId);
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == dataGridView1.Columns["TypeName"].Index)
            //{
            //    int newRowIdx = dataGridView1.Rows.Count - 1;
            //    string enteredValue = dataGridView1.Rows[e.RowIndex].Cells["TypeName"].Value?.ToString().Trim();

            //    // Common validation (applicable to both add and edit scenarios)
            //    if (string.IsNullOrEmpty(enteredValue))
            //    {
            //        MessageBox.Show("Please enter a resource type name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    if (!IsValidResourceTypeName(enteredValue)) // Replace with your more comprehensive validation logic
            //    {
            //        MessageBox.Show("Please enter a valid resource type name (letters, hyphens, or whitespace).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    // **Verify ResourceTypeId column index** (adjust if needed)
            //    int resourceTypeIdColumnIndex = dataGridView1.Columns["ResourceTypeId"].Index; // Assuming ResourceTypeId is in the "ResourceTypeId" column

            //    // Determine if it's a new row or an existing row being edited
            //    bool isNewRow = e.RowIndex == newRowIdx;

            //    if (isNewRow)
            //    {
            //        // Handle adding a new row
            //        if (ResourceTypeExists(enteredValue, 0)) // Check for duplicate name (0 for new entry)
            //        {
            //            MessageBox.Show("This name already exists. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        // Save changes to the database within a try-catch block
            //        try
            //        {

            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show($"Error saving resource type: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    else
            //    {
            //        // Handle editing an existing row
            //        int resourceTypeId;
            //        try
            //        {
            //            resourceTypeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[resourceTypeIdColumnIndex].Value); // Retrieve the ID from the correct column
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show($"Error retrieving ResourceTypeId: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        if (ResourceTypeExists(enteredValue, resourceTypeId)) // Check for duplicate (excluding the current resource type)
            //        {
            //            MessageBox.Show("This name already exists for another resource type. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        // Update the existing resource type object
            //        var resourceTypeToUpdate = db.ResourceTypes.FirstOrDefault(rt => rt.ResourceTypeId == resourceTypeId);
            //        if (resourceTypeToUpdate != null)
            //        {
            //            resourceTypeToUpdate.TypeName = enteredValue;

            //            // Save changes within a try-catch block
            //            try
            //            {
            //                db.SaveChanges();
            //                MessageBox.Show("Resource type updated successfully.");
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show($"Error saving to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //        else
            //        {
            //            // Add the new resource type to the data source
            //            var newResourceType = new ResourceTypes
            //            {
            //                ProjectId = Form1.projectid, // Assuming project ID is readily available
            //                TypeName = enteredValue
            //            };
            //            db.ResourceTypes.Add(newResourceType);
            //            db.SaveChanges();
            //            LoadResourceTypes(); // Refresh the data after adding a new resource type
            //            MessageBox.Show("Resource type added successfully.");
            //        }
            //    }
            //}
            //if (e.ColumnIndex == dataGridView1.Columns["TypeName"].Index) // Verify TypeName column
            //{
            //    string enteredValue = dataGridView1.Rows[e.RowIndex].Cells["TypeName"].Value?.ToString().Trim(); // Trim whitespaces

            //    // Validate the resource type name
            //    if (!ValidateResourceTypeName(enteredValue, out string errorMessage))
            //    {
            //        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ""; // Clear the cell value
            //        return;
            //    }

            //    // **Verify ResourceTypeId column index** (adjust if needed)
            //    int resourceTypeIdColumnIndex = dataGridView1.Columns["ResourceTypeId"].Index; // Assuming ResourceTypeId is in the "ResourceTypeId" column

            //    // Determine if it's a new row or an existing row being edited
            //    bool isNewRow = e.RowIndex == dataGridView1.Rows.Count - 1;

            //    if (isNewRow)
            //    {
            //        // Handle adding a new row
            //        if (ResourceTypeNameExists(enteredValue, 0)) // Check for duplicate name (0 for new entry)
            //        {
            //            MessageBox.Show("This name already exists. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ""; // Clear the cell value
            //            return;
            //        }
            //        if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Check if the row and column indices are valid
            //        {
            //            DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //            if (cell != null && cell.Value != null)
            //            {
            //                string resourceTypeName = cell.Value.ToString();
            //                if (!ValidateResourceTypeName1(resourceTypeName))
            //                {
            //                    cell = null; // Clear the cell value if it's not valid
            //                }
            //            }
            //        }
            //        // Save changes to the database within a try-catch block
            //        try
            //        {
            //            // Create a new ResourceType object and add it to the database
            //            var newResourceType = new ResourceTypes
            //            {
            //                ProjectId = Form1.projectid, // Assuming project ID is readily available
            //                TypeName = enteredValue
            //            };
            //            db.ResourceTypes.Add(newResourceType);
            //            db.SaveChanges(); // Save the changes to the database
            //            MessageBox.Show("Resource type added successfully.");
            //            LoadResourceTypes(); // Refresh the data after adding a new resource type
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show($"Error saving resource type: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    else
            //    {
            //        // Handle editing an existing row
            //        int resourceTypeId;
            //        try
            //        {
            //            resourceTypeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[resourceTypeIdColumnIndex].Value); // Retrieve the ID from the correct column
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show($"Error retrieving ResourceTypeId: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        if (ResourceTypeNameExists(enteredValue, resourceTypeId)) // Check for duplicate (excluding the current resource type)
            //        {
            //            MessageBox.Show("This name already exists for another resource type. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ""; // Clear the cell value
            //            return;
            //        }



            //        // Update the existing resource type object
            //        var resourceTypeToUpdate = db.ResourceTypes.FirstOrDefault(rt => rt.ResourceTypeId == resourceTypeId);
            //        if (resourceTypeToUpdate != null)
            //        {
            //            resourceTypeToUpdate.TypeName = enteredValue;

            //            // Save changes within a try-catch block
            //            try
            //            {
            //                db.SaveChanges();
            //                UpdateResourceTypes(Form1.projectid, enteredValue);
            //                MessageBox.Show("Resource type updated successfully.");
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show($"Error saving to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //        else
            //        {
            //            // This case should not occur, as we're editing an existing row
            //            // MessageBox.Show("Resource type not found for editing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            if (e.ColumnIndex == dataGridView1.Columns["TypeName"].Index) // Verify TypeName column
            {
                string enteredValue = (dataGridView1.Rows[e.RowIndex].Cells["TypeName"].Value ?? "").ToString().Trim(); // Trim whitespaces

                // Validate the resource type name
                if (!ValidateResourceTypeName(enteredValue, out string errorMessage))
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ""; // Clear the cell value
                    return;
                }

                int resourceTypeIdColumnIndex = dataGridView1.Columns["ResourceTypeId"].Index;

                // Parse the ResourceTypeId
                if (!int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[resourceTypeIdColumnIndex].Value?.ToString(), out int resourceTypeId))
                {
                    MessageBox.Show("Invalid Resource Type ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool isNewRow =e.RowIndex== dataGridView1.Rows.Count - 2;

                if (isNewRow)
                {
                    if (ResourceTypeNameExists(enteredValue, 0)) // Check for duplicate name (0 for new entry)
                    {
                        MessageBox.Show("This name already exists. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ""; // Clear the cell value
                        return;
                    }

                    // Save new resource type to the database
                    try
                    {
                        var newResourceType = new ResourceTypes
                        {
                            ProjectId = Form1.projectid, // Assuming project ID is readily available
                            TypeName = enteredValue
                        };

                        db.ResourceTypes.Add(newResourceType);
                        db.SaveChanges(); // Save changes to the database

                        MessageBox.Show("Resource type added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadResourceTypes(); // Refresh the data after adding a new resource type
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving resource type: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Editing an existing row
                    try
                    {
                        resourceTypeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[resourceTypeIdColumnIndex].Value); // Retrieve the ID from the correct column
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error retrieving ResourceTypeId: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (ResourceTypeNameExists(enteredValue, resourceTypeId)) // Check for duplicate (excluding the current resource type)
                    {
                        MessageBox.Show("This name already exists for another resource type. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ""; // Clear the cell value
                        return;
                    }

                    // Update the existing resource type
                    var resourceTypeToUpdate = db.ResourceTypes.FirstOrDefault(rt => rt.ResourceTypeId == resourceTypeId);
                    if (resourceTypeToUpdate != null)
                    {
                        resourceTypeToUpdate.TypeName = enteredValue;

                        // Save changes to the database
                        try
                        {
                            db.SaveChanges();
                            UpdateResourceTypes(Form1.projectid, enteredValue);
                            MessageBox.Show("Resource type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error saving to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                      //  MessageBox.Show("Resource type not found for editing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void UpdateResourceTypes(int projectId, string typeName)
        {
            // Assuming you have access to the database context or data source
            try
            {
                // Find the existing resource type based on project ID and type name
                var existingResourceType = db.ResourceTypes.FirstOrDefault(rt => rt.ProjectId == projectId && rt.TypeName == typeName);
                if (existingResourceType != null)
                {
                    // Update the type name
                    existingResourceType.TypeName = typeName;
                    // Save changes to the database
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating resource types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ResourceTypeNameExists(string typeName, int excludingResourceTypeId)
        {
            // Assuming you have access to the database context or data source
            try
            {
                // Check if any resource type with the given name exists, excluding the specified resource type ID
                return db.ResourceTypes.Any(rt => rt.ResourceTypeId != excludingResourceTypeId && rt.TypeName == typeName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking resource type existence: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Return false in case of an error
            }
        }


        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["CountryNames"].Index)
            {
                // Check if the control is a System.Windows.Forms.TextBox
                if (e.Control is System.Windows.Forms.TextBox textBox)
                {
                    // Unregister the previous event handler to prevent duplicate registrations
                    textBox.KeyPress -= TextBox_KeyPress;
                    // Register the event handler for the KeyPress event
                    textBox.KeyPress += TextBox_KeyPress;
                }
                //else
                //{
                //    // Handle the case where the control is not a TextBox
                //    // You may choose to display an error message or handle it differently
                //    MessageBox.Show("Editing control is not a TextBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a white space
            if (e.KeyChar == ' ')
            {
                // Consume the event, preventing the white space from being entered
                e.Handled = true;
            }
        }



        private bool ValidateResourceTypeName1(string resourceTypeName)
        {
            // Validate that ResourceTypeName is not empty, does not contain numeric characters,
            // and does not contain special characters
            if (string.IsNullOrWhiteSpace(resourceTypeName) || resourceTypeName.Any(char.IsDigit) || !Regex.IsMatch(resourceTypeName, @"^[a-zA-Z\s-]+$"))
            {



                MessageBox.Show("Please enter a valid resource type name without numeric or special characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                // dataGridView1.Rows[e.RowIndex].Cells[e.columnIndex].Value = String.Empty;

                return false;
            }
            return true;
        }
        private bool ValidateResourceTypeName(string resourceTypeName, out string errorMessage)
        {
            // Validate that ResourceTypeName is not empty, does not contain numeric characters,
            // and does not contain special characters
            if (string.IsNullOrWhiteSpace(resourceTypeName) || resourceTypeName.Any(char.IsDigit) || !Regex.IsMatch(resourceTypeName, @"^[a-zA-Z\s-]+$"))
            {
                errorMessage = "Please enter a valid resource type name without numeric or special characters.";
                return false;
            }

            errorMessage = ""; // No error
            return true;
        }


    }
}
    

