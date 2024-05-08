using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectEstimationTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectEstimationTool
{
    public partial class CountryUserControl : UserControl
    {

        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();

        // Load countries from the database
        private BindingList<Country> countrybind;

        private int cid;
        public CountryUserControl()
        {
            InitializeComponent();

            countrybind = new BindingList<Country>();
            LoadCountryData();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;

        }

        private void LoadCountryData()
        {
            try
            {
                var countries = db.Country.Where(t => t.ProjectId == Form1.projectid).ToList(); // Filter by project ID
                countrybind.Clear();
                // dataGridView1.DataSource = null;

                foreach (var country in countries)
                {
                    countrybind.Add(country);
                }
                // Set the BindingSource data source
                dataGridView1.DataSource = countrybind;
                //  dataGridView1.DataSource = countries;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }



        private void CountryUserControl_Load(object sender, EventArgs e)
        {
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private bool IsValidString(string input)
        {
            // Check if the input is not empty and contains only letters, hyphens, or spaces
            return !string.IsNullOrWhiteSpace(input) && input.All(c => char.IsLetter(c) || c == '-' || char.IsWhiteSpace(c));
        }

        private bool CountryNameExists(string name, int currentCountryId)
        {
            // Check if the country name already exists in the database (case-insensitive)
            var existingCountry = db.Country
                .FirstOrDefault(c =>
                    c.ProjectId == Form1.projectid &&
                    c.CountryName.ToLower() == name.ToLower() &&
                    c.CountryId != currentCountryId);

            return existingCountry != null;
        }
        private void UpdateResource(int projectID, string newCountryName)
        {
            var resources = db.Resource.Where(r => r.ProjectId == projectID).ToList();

            if (resources != null)
            {
                foreach (var resource in resources)
                {
                    resource.CountryName = newCountryName;
                    db.SaveChanges();
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            {
                FunctionalUserControl functionalUserControl = new FunctionalUserControl();
                this.Hide();
                this.Parent.Controls.Add(functionalUserControl);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ResourceTypeUserControl rc = new ResourceTypeUserControl();
            this.Hide();
            this.Parent.Controls.Add(rc);
        }

        //private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == dataGridView1.Columns["CountryNames"].Index) // Verify CountryNames column
        //    {
        //        int newRowIdx = dataGridView1.Rows.Count - 1;

        //        string enteredValue = dataGridView1.Rows[e.RowIndex].Cells["CountryNames"].Value?.ToString().Trim(); // Trim whitespaces


        //        // Common validation (applicable to both add and edit scenarios)
        //        if (string.IsNullOrEmpty(enteredValue))
        //        {
        //            MessageBox.Show("Please enter a country name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        // Capitalize the first letter of the entered country name if it's not null and not empty
        //        if (!string.IsNullOrEmpty(enteredValue))
        //        {
        //            enteredValue = char.ToUpper(enteredValue[0]) + enteredValue.Substring(1);
        //        }

        //        if (!IsValidString(enteredValue)) // Replace with your more comprehensive validation logic
        //        {
        //            MessageBox.Show("Please enter a valid country name (letters, hyphens, or whitespace).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //          //  dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
        //            return;
        //        }

        //        // **Verify CountryId column index** (adjust if needed)
        //        int countryIdColumnIndex = dataGridView1.Columns["CountryId"].Index; // Assuming CountryId is in the "CountryId" column

        //        // Determine if it's a new row or an existing row being edited
        //        bool isNewRow = e.RowIndex == newRowIdx;

        //        if (isNewRow)
        //        {
        //            // Handle adding a new row
        //            if (CountryNameExists(enteredValue, 0)) // Check for duplicate name (0 for new entry)
        //            {
        //                MessageBox.Show("This name already exists. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //            // Save changes to the database within a try-catch block
        //            try
        //            {
        //                // Your code to save the new country...
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"Error saving country: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }


        //        else
        //        {
        //            // Handle editing an existing row
        //            int countryId;
        //            try
        //            {
        //                countryId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[countryIdColumnIndex].Value); // Retrieve the ID from the correct column
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"Error retrieving CountryId: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }

        //            if (CountryNameExists(enteredValue, countryId)) // Check for duplicate (excluding the current country)
        //            {
        //                MessageBox.Show("This name already exists for another country. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
        //                return;
        //            }

        //            // Update the existing country object
        //            var countryToUpdate = db.Country.FirstOrDefault(c => c.CountryId == countryId);
        //            if (countryToUpdate != null)
        //            {
        //                countryToUpdate.CountryName = enteredValue;

        //                // Save changes within a try-catch block
        //                try
        //                {
        //                    db.SaveChanges();
        //                    UpdateResource(Form1.projectid, enteredValue);
        //                    MessageBox.Show("Country updated successfully.");
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show($"Error saving to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //            else
        //            {
        //                // Create a new Country object and add it to the data source
        //                var newCountry = new Country
        //                {
        //                    ProjectId = Form1.projectid, // Assuming project ID is readily available
        //                    CountryName = enteredValue
        //                };
        //                db.Country.Add(newCountry);
        //                db.SaveChanges();
        //                MessageBox.Show("Country added successfully.");
        //                LoadCountryData(); // Refresh the data after adding a new country
        //            }
        //        }
        //    }

        //}


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["CountryNames"].Index) // Verify CountryNames column
            {
                int newRowIdx = dataGridView1.Rows.Count - 1;

                string enteredValue = dataGridView1.Rows[e.RowIndex].Cells["CountryNames"].Value?.ToString().Trim(); // Trim whitespaces

                // Common validation (applicable to both add and edit scenarios)
                if (string.IsNullOrEmpty(enteredValue))
                {
                    MessageBox.Show("Please enter a country name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Capitalize the first letter of the entered country name if it's not null and not empty
                if (!string.IsNullOrEmpty(enteredValue))
                {
                    enteredValue = char.ToUpper(enteredValue[0]) + enteredValue.Substring(1);
                }

                if (!IsValidString(enteredValue) || ContainsSpecialCharacters(enteredValue)) // Modified validation condition
                {
                    MessageBox.Show("Please enter a valid country name (letters, hyphens, or whitespace) without special characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ""; // Clear the cell
                    return;
                }

                // **Verify CountryId column index** (adjust if needed)
                int countryIdColumnIndex = dataGridView1.Columns["CountryId"].Index; // Assuming CountryId is in the "CountryId" column

                // Determine if it's a new row or an existing row being edited
                bool isNewRow = e.RowIndex == newRowIdx;

                if (isNewRow)
                {
                    // Handle adding a new row
                    if (CountryNameExists(enteredValue, 0)) // Check for duplicate name (0 for new entry)
                    {
                        MessageBox.Show("This name already exists. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Save changes to the database within a try-catch block
                    try
                    {
                        // Your code to save the new country...
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving country: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Handle editing an existing row
                    int countryId;
                    try
                    {
                        countryId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[countryIdColumnIndex].Value); // Retrieve the ID from the correct column
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error retrieving CountryId: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (CountryNameExists(enteredValue, countryId)) // Check for duplicate (excluding the current country)
                    {
                        MessageBox.Show("This name already exists for another country. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        return;
                    }

                    // Update the existing country object
                    var countryToUpdate = db.Country.FirstOrDefault(c => c.CountryId == countryId);
                    if (countryToUpdate != null)
                    {
                        // Convert the first letter to uppercase
                        enteredValue = char.ToUpper(enteredValue[0]) + enteredValue.Substring(1);

                        countryToUpdate.CountryName = enteredValue;

                        // Save changes within a try-catch block
                        try
                        {
                            db.SaveChanges();
                            UpdateResource(Form1.projectid, enteredValue);
                            MessageBox.Show("Country updated successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error saving to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Create a new Country object and add it to the data source
                        var newCountry = new Country
                        {
                            ProjectId = Form1.projectid, // Assuming project ID is readily available
                            CountryName = enteredValue
                        };
                        db.Country.Add(newCountry);
                        db.SaveChanges();
                        MessageBox.Show("Country added successfully.");
                        LoadCountryData(); // Refresh the data after adding a new country
                    }
                }
            }
        }

        // Helper method to check if the string contains special characters
        private bool ContainsSpecialCharacters(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetter(c) && c != '-' && !char.IsWhiteSpace(c))
                {
                    return true;
                }
            }
            return false;
        }



        //    if (e.ColumnIndex == dataGridView1.Columns["CountryNames"].Index) // Verify CountryNames column
        //    {
        //        string enteredValue = dataGridView1.Rows[e.RowIndex].Cells["CountryNames"].Value?.ToString().Trim(); // Trim whitespaces

        //        // Validate the country name
        //        if (!ValidateCountryName(enteredValue))
        //            return;

        //        // **Verify CountryId column index** (adjust if needed)
        //        int countryIdColumnIndex = dataGridView1.Columns["CountryId"].Index; // Assuming CountryId is in the "CountryId" column

        //        // Determine if it's a new row or an existing row being edited
        //        bool isNewRow = e.RowIndex == dataGridView1.Rows.Count && dataGridView1.Rows[e.RowIndex].IsNewRow;

        //        if (isNewRow && (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6))
        //        {
        //            // Handle adding a new row
        //            if (CountryNameExists(enteredValue, 0)) // Check for duplicate name (0 for new entry)
        //            {
        //                MessageBox.Show("This name already exists. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ""; // Clear the cell value
        //                return;
        //            }
        //            // Save changes to the database within a try-catch block
        //            try
        //            {
        //                // Create a new Country object and add it to the database
        //                var newCountry = new Country
        //                {
        //                    ProjectId = Form1.projectid, // Assuming project ID is readily available
        //                    CountryName = enteredValue
        //                };
        //                db.Country.Add(newCountry);
        //                db.SaveChanges(); // Save the changes to the database
        //                MessageBox.Show("Country added successfully.");
        //                LoadCountryData(); // Refresh the data after adding a new country
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"Error saving country: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            // Handle editing an existing row
        //            int countryId;
        //            try
        //            {
        //                countryId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[countryIdColumnIndex].Value); // Retrieve the ID from the correct column
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"Error retrieving CountryId: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }

        //            if (CountryNameExists(enteredValue, countryId)) // Check for duplicate (excluding the current country)
        //            {
        //                MessageBox.Show("This name already exists for another country. Please choose a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ""; // Clear the cell value
        //                return;
        //            }

        //            // Update the existing country object
        //            var countryToUpdate = db.Country.FirstOrDefault(c => c.CountryId == countryId);
        //            if (countryToUpdate != null)
        //            {
        //                countryToUpdate.CountryName = enteredValue;

        //                // Save changes within a try-catch block
        //                try
        //                {
        //                    db.SaveChanges();
        //                    UpdateResource(Form1.projectid, enteredValue);
        //                    MessageBox.Show("Country updated successfully.");
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show($"Error saving to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //            else
        //            {
        //                // This case should not occur, as we're editing an existing row
        //                MessageBox.Show("Country not found for editing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //}





        private bool ValidateCountryName(string countryName)
        {
            // Capitalize the first letter of the country name
            countryName = char.ToUpper(countryName[0]) + countryName.Substring(1);

            // Validate that CountryName is not empty and contains only letters, whitespace, and no numeric or special characters
            if (string.IsNullOrWhiteSpace(countryName) ||
                countryName.Any(c => char.IsDigit(c) || !char.IsLetterOrDigit(c))) // Check if contains numeric or special characters
            {
                MessageBox.Show("Please enter a valid country name without numeric or special characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }




        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["CountryNames"].Index)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress -= TextBox_KeyPress;
                    textBox.KeyPress += TextBox_KeyPress;
                }
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



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }


        private void DeleteDependentCountryRecords(int dependentId)
        {
            // Example: Querying and deleting dependent records
            var dependentRecords = db.Resource.Where(r => r.CountryId == dependentId).ToList();
            // Delete dependent records
            db.Resource.RemoveRange(dependentRecords);
            // Save changes after removing the dependent records
            db.SaveChanges();
            // Retry deleting the record in the 'Countries' table
            LoadCountryData();
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

                        if (selectedRow.DataBoundItem is Country selectedCountry)
                        {
                            int countryId = selectedCountry.CountryId;

                            try
                            {
                                // Attempt to delete the record in the 'Countries' table
                                var countryToDelete = db.Country.FirstOrDefault(c => c.CountryId == countryId);

                                if (countryToDelete != null)
                                {
                                    db.Country.Remove(countryToDelete);
                                    db.SaveChanges();
                                   // LoadCountryData();
                                }
                               
                            }
                            catch (DbUpdateException ex)
                            {
                                // Check if the exception is due to a foreign key constraint violation
                                if (ex.InnerException is SqlException sqlException && sqlException.Number == 547)
                                {
                                    // Handle foreign key constraint violation by deleting dependent records in the 'Resource' table
                                    DeleteDependentCountryRecords(countryId);
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
    

                            private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
          


        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }
    }
}
