using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectEstimationTool.Models;
using ProjectEstimationTool.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectEstimationTool
{
    public partial class SoftwarerateUserControl : UserControl
    {
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        private Software s;


        BindingList<Software> softdata;




        public SoftwarerateUserControl()
        {
            InitializeComponent();
            softdata = new BindingList<Software>();

           // dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
           // dataGridView1.CellParsing += dataGridView1_CellParsing;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = true;
            LoadSoftwareData();

        }



        private void SoftwarerateUserControl_Load(object sender, EventArgs e)
        {




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadSoftwareData()
        {
            softdata.Clear();

            // Fetch resources from the database
            var res = db.Software.Where(t => t.ProjectId == Form1.projectid).ToList();

            // Add the fetched resources to the resources list
            foreach (Software resource in res)
            {
                softdata.Add(resource);
            }

            // Set the DataGridView data source
            dataGridView1.DataSource = softdata;
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
        }
        private bool SoftwareNameExists(string softwareName, int currentSoftwareId)
        {
            var existingSoftware = db.Software
                .FirstOrDefault(s =>
                    s.SoftwareName.ToLower() == softwareName.ToLower() &&
                    s.ProjectId == Form1.projectid &&
                    s.SoftwareId != currentSoftwareId);

            return existingSoftware != null;
        }



        private void button6_Click(object sender, EventArgs e)
        {
            ResourceRateUserControl rc = new ResourceRateUserControl();
            this.Hide();
            this.Parent.Controls.Add(rc);
        }





        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == dataGridView1.Columns["MonthlyRate"].Index)
            //{
            //    int newRowIdx = dataGridView1.Rows.Count - 1;
            //    string softwareName = dataGridView1.Rows[e.RowIndex].Cells["SoftwareName"].Value?.ToString().Trim();
            //    string monthlyRateStr = dataGridView1.Rows[e.RowIndex].Cells["MonthlyRate"].Value?.ToString().Trim();

            //    // **Verify SoftwareId column index** (adjust if needed)
            //    int softwareIdColumnIndex = dataGridView1.Columns["SoftwareIds"].Index; // Assuming SoftwareId is in the "SoftwareId" column



            //    // Determine if it's a new row or an existing row being edited
            //    bool isNewRow = e.RowIndex == newRowIdx;

            //    if (!isNewRow)
            //    {
            //        int softwareId = 0;
            //        try
            //        {
            //            softwareId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[softwareIdColumnIndex].Value); // Retrieve the ID from the correct column
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show($"Error retrieving SoftwareId: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        // If softwareId is 0, then it's not a valid row to edit
            //        if (softwareId == 0)
            //        {
            //            if (!string.IsNullOrEmpty(monthlyRateStr))
            //            {
            //                // Handle adding a new row
            //                // Create a new Software object and add it to the database
            //                var newSoftware = new Software
            //                {
            //                    ProjectId = Form1.projectid, // Assuming project ID is readily available
            //                    SoftwareName = softwareName,
            //                    MonthlyRate = Convert.ToInt32(monthlyRateStr)
            //                };

            //                // Save changes to the database within a try-catch block
            //                try
            //                {
            //                    db.Software.Add(newSoftware);
            //                    db.SaveChanges();
            //                    LoadSoftwareData();
            //                    MessageBox.Show("Software added successfully.");
            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show($"Error adding software: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Please enter the monthly rate.");
            //            }
            //        }

            //        // Handle editing an existing row
            //        // If softwareId is 0, then it's not a valid row to edit
            //        if (softwareId != 0)
            //        {
            //            // Handle editing an existing row
            //            // Update the existing Software object
            //            var softwareToUpdate = db.Software.FirstOrDefault(s => s.SoftwareId == softwareId);
            //            if (softwareToUpdate != null)
            //            {
            //                softwareToUpdate.SoftwareName = softwareName;
            //                softwareToUpdate.MonthlyRate = Convert.ToInt32(monthlyRateStr);
            //                db.SaveChanges();
            //                LoadSoftwareData();
            //                MessageBox.Show("Software updated successfully.");
            //            }
            //        }
            //    }
            //}
            if (e.ColumnIndex == dataGridView1.Columns["MonthlyRate"].Index)
            {
                // Validation for MonthlyRate column
                string monthlyRateStr1 = dataGridView1.Rows[e.RowIndex].Cells["MonthlyRate"].Value?.ToString().Trim();
                if (!IsValidNumber(monthlyRateStr1))
                {
                    MessageBox.Show("Please enter a valid monthly rate (numeric characters only).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells["MonthlyRate"].Value = ""; // Clear the cell value
                    return;
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["SoftwareName"].Index)
            {
                // Validation for SoftwareName column
                string SoftwareName = dataGridView1.Rows[e.RowIndex].Cells["SoftwareName"].Value?.ToString().Trim();
                if (!IsValidSoftwareName(SoftwareName))
                {
                    MessageBox.Show("Please enter a valid software name (alphabetic characters only).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells["SoftwareName"].Value = ""; // Clear the cell value
                    return;
                }
                // Check for duplicate names
                int softwareId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["SoftwareIds"].Value);
                if (SoftwareNameExists1(SoftwareName, softwareId))
                {
                    MessageBox.Show("This software name already exists. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells["SoftwareName"].Value = ""; // Clear the cell value
                    return;
                }
            }

            // Existing code below this point (no changes)

            int newRowIdx = dataGridView1.Rows.Count - 1;
            string softwareName = dataGridView1.Rows[e.RowIndex].Cells["SoftwareName"].Value?.ToString().Trim();
            string monthlyRateStr = dataGridView1.Rows[e.RowIndex].Cells["MonthlyRate"].Value?.ToString().Trim();

            // **Verify SoftwareId column index** (adjust if needed)
            int softwareIdColumnIndex = dataGridView1.Columns["SoftwareIds"].Index; // Assuming SoftwareId is in the "SoftwareId" column

            // Determine if it's a new row or an existing row being edited
            bool isNewRow = e.RowIndex == newRowIdx;

            if (!isNewRow)
            {
                int softwareId = 0;
                try
                {
                    softwareId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[softwareIdColumnIndex].Value); // Retrieve the ID from the correct column
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving SoftwareId: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If softwareId is 0, then it's not a valid row to edit
                if (softwareId == 0)
                {
                    if (!string.IsNullOrEmpty(monthlyRateStr))
                    {
                        // Handle adding a new row
                        // Create a new Software object and add it to the database
                        var newSoftware = new Software
                        {
                            ProjectId = Form1.projectid, // Assuming project ID is readily available
                            SoftwareName = softwareName,
                            MonthlyRate = Convert.ToInt32(monthlyRateStr)
                        };

                        // Save changes to the database within a try-catch block
                        try
                        {
                            db.Software.Add(newSoftware);
                            db.SaveChanges();
                            LoadSoftwareData();
                            MessageBox.Show("Software added successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error adding software: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter the monthly rate.");
                    }
                }

                // Handle editing an existing row
                // If softwareId is 0, then it's not a valid row to edit
                if (softwareId != 0)
                {
                    // Handle editing an existing row
                    // Update the existing Software object
                    var softwareToUpdate = db.Software.FirstOrDefault(s => s.SoftwareId == softwareId);
                    if (softwareToUpdate != null)
                    {
                        softwareToUpdate.SoftwareName = softwareName;
                        // Try-catch block for updating monthly rate
                        try
                        {
                            softwareToUpdate.MonthlyRate = Convert.ToInt32(monthlyRateStr);
                            db.SaveChanges();
                            LoadSoftwareData();
                            MessageBox.Show("Software updated successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error updating monthly rate: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }


        }

        // Method to validate if a string consists of numeric characters only
        private bool IsValidNumber(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.All(char.IsDigit);
        }

        // Method to validate if a string consists of alphabetic characters only
        private bool IsValidSoftwareName(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter);
        }

        // Method to check if the software name already exists
        private bool SoftwareNameExists1(string softwareName, int currentSoftwareId)
        {
            var existingSoftware = db.Software
                .FirstOrDefault(s =>
                    s.SoftwareName.ToLower() == softwareName.ToLower() &&
                    s.SoftwareId != currentSoftwareId);

            return existingSoftware != null;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                // Check if any row is selected
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Get the SoftwareId from the selected row
                    int softwareId = Convert.ToInt32(selectedRow.Cells["SoftwareIds"].Value);

                    // Ask for confirmation before deleting
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Find the Software object in the database
                            var softwareToDelete = db.Software.FirstOrDefault(s => s.SoftwareId == softwareId);
                            if (softwareToDelete != null)
                            {
                                // Remove the Software object from the database
                                db.Software.Remove(softwareToDelete);
                                db.SaveChanges();
                               // LoadSoftwareData();
                                // Remove the row from the DataGridView
                                dataGridView1.Rows.Remove(selectedRow);

                                MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Selected record not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

      

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["MonthlyRate"].Index)
            {
                // Check if the entered value can be parsed as an integer
                if (!int.TryParse(e.Value.ToString(), out int parsedValue))
                {
                    // If parsing fails, set ParsingApplied to true to indicate that the event handler has handled the parsing
                    e.ParsingApplied = true;

                    // Show error message to the user
                    MessageBox.Show("Please enter a valid integer value for the monthly rate.", "Error", MessageBoxButtons.OK);

                    // Clear the cell value
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
                else
                {
                    // If parsing succeeds, set the parsed value to the Value property of the event args
                    // e.Value = parsedValue;

                    // Clear any previous error text for the cell
                    //  dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
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




