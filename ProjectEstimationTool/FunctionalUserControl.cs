using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectEstimationTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectEstimationTool
{
    public partial class FunctionalUserControl : UserControl
    {
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        private int functionalAreaId;
        private string functionalAreaName;
        private FunctionalArea selecteddata;
        BindingList<FunctionalArea> functionalAreas;
        public FunctionalUserControl()
        {
            InitializeComponent();
            functionalAreas = new BindingList<FunctionalArea>();
            ////dataGridView2.DataSource = functionalAreas;
            //var res = from t in db.FunctionalArea
            //          where t.ProjectId == Form1.projectid
            //          select t;
            //List<ProjectEstimationTool.Models.FunctionalArea> funclist = res.ToList();
            //BindingList<ProjectEstimationTool.Models.FunctionalArea> funcdata = new BindingList<ProjectEstimationTool.Models.FunctionalArea>(funclist);
            //dataGridView2.DataSource = funcdata;
            LoadData();
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
         //  dataGridView2.CellValidated += dataGridView2_CellValidated;
        }
        private void LoadData()
        {
            try
            {
                var res = db.FunctionalArea.Where(t => t.ProjectId == Form1.projectid).ToList();
                functionalAreas.Clear();
                foreach (var item in res)
                {
                    functionalAreas.Add(item);

                }
                dataGridView2.DataSource = functionalAreas;
            }
            catch
            {
                MessageBox.Show("Error Loading while loading the data");
            }
        }

        private void FunctionalUserControl_Load(object sender, EventArgs e)
        {

        }
        private void LoadFunctionalAreaData()
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }









        private bool IsValidString(string input)
        {
            // Check if the input is not empty and contains only letters, hyphens, or whitespace
            return !string.IsNullOrWhiteSpace(input) && input.All(c => char.IsLetter(c) || c == '-' || char.IsWhiteSpace(c));
        }

        private bool FunctionalAreaNameExists(string name, int currentFunctionalAreaId)
        {
            // Check if the functional area name already exists in the database (case-insensitive)
            var existingFunctionalArea = db.FunctionalArea
                .FirstOrDefault(fa =>
                    fa.ProjectId == Form1.projectid &&
                    fa.FunctionalAreaName.ToLower() == name.ToLower() &&
                    fa.FunctionalAreaId != currentFunctionalAreaId);

            return existingFunctionalArea != null;
        }













        private void button6_Click(object sender, EventArgs e)
        {
            ProductivityUserControl prod = new ProductivityUserControl();
            this.Hide();
            this.Parent.Controls.Add(prod);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            {
                CountryUserControl country = new CountryUserControl();
                this.Hide();
                this.Parent.Controls.Add(country);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                // Check if a row is selected
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    // Get the index of the selected row
                    int rowIndex = dataGridView2.SelectedRows[0].Index;

                    // Ensure the selected row index is within a valid range
                    if (rowIndex >= 0 && rowIndex < dataGridView2.Rows.Count)
                    {
                        int functionalAreaId = Convert.ToInt32(dataGridView2.Rows[rowIndex].Cells["FunctionalAreaIdss"].Value);

                        if (functionalAreaId != 0)
                        {
                            FunctionalArea functionalAreaToDelete = db.FunctionalArea.FirstOrDefault(fs => fs.FunctionalAreaId == functionalAreaId);

                            // Confirm deletion with a dialog box
                            DialogResult result = MessageBox.Show("Deleting this item will also delete associated data. Are you sure you want to proceed?", "Delete Row", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                // Remove the entity from the database context and save changes
                                if (functionalAreaToDelete != null)
                                {
                                    db.FunctionalArea.Remove(functionalAreaToDelete);
                                    db.SaveChanges();
                                    MessageBox.Show("Deleted successfully");

                                    // Remove the row from the DataGridView
                                    dataGridView2.Rows.RemoveAt(rowIndex);
                                }
                            }
                        }
                    }

                    e.Handled = true;
                }
            }





        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private FunctionalArea GetItemToUpdate(int rowIndex, int itemId)
        {
            // Retrieve the FunctionalArea object from the database based on the provided itemId
            // You'll need to adjust this according to your database context and entity classes
            var itemToUpdate = db.FunctionalArea.FirstOrDefault(fa => fa.FunctionalAreaId == itemId);

            return itemToUpdate;
        }

        private bool ColumnNameExists(string name, string columnName, int itemId)
        {
            if (columnName == "FunctionalAreaNames")
            {
                // Allow duplicate names for FunctionalAreaNames
                return false;
            }
            else if (columnName == "FunctionalSubAreaName")
            {
                // Check if the name already exists for FunctionalSubAreaName
                return db.FunctionalArea.Any(fa => fa.FunctionalSubAreaName == name && fa.FunctionalAreaId != itemId);
            }
            else
            {
                return false;
            }
        }

        private FunctionalArea GetItemToUpdate(int itemId)
        {
            return db.FunctionalArea.FirstOrDefault(fa => fa.FunctionalAreaId == itemId);
        }
        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the editing happened in FunctionalAreaName or FunctionalSubAreaName column
            if (e.ColumnIndex != 2 && e.ColumnIndex != 3)
                return;

            // Get the entered values
            string functionalAreaName = dataGridView2.Rows[e.RowIndex].Cells[2].Value?.ToString()?.Trim();
            string functionalSubAreaName = dataGridView2.Rows[e.RowIndex].Cells[3].Value?.ToString()?.Trim();

            // Check if FunctionalAreaName is null
            if (string.IsNullOrEmpty(functionalAreaName))
            {
                // Wait for FunctionalAreaName to be entered
                return;
            }

            // Check if both names are entered
            if (!string.IsNullOrEmpty(functionalAreaName) && !string.IsNullOrEmpty(functionalSubAreaName))
            {
                // Save the new entry to the database
                try
                {
                    int functionalAreaId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["FunctionalAreaIdss"].Value);

                    // Check if an existing entry with the same FunctionalAreaId exists
                    FunctionalArea existingEntry = GetItemToUpdate(functionalAreaId);
                    if(existingEntry!=null){
                        existingEntry.FunctionalAreaName = functionalAreaName;
                        existingEntry.FunctionalSubAreaName = functionalSubAreaName;

                        db.SaveChanges(); // Save changes to the database

                        MessageBox.Show("Item updated successfully.");
                    }
                    else
                    {
                        // Create a new FunctionalArea entry with both names
                        var newFunctionalArea = new FunctionalArea
                        {
                            ProjectId = Form1.projectid,
                            FunctionalAreaName = functionalAreaName,
                            FunctionalSubAreaName = functionalSubAreaName
                        };

                        db.FunctionalArea.Add(newFunctionalArea);
                        db.SaveChanges();

                        MessageBox.Show("Item added successfully.");
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Set a flag indicating that the event has been processed
            dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = "Processed";
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string? value1 = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString()?.Trim();
                dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value1;
                dataGridView2.CellValidating -= dataGridView2_CellValidating;

                 string? value = e.FormattedValue?.ToString()?.Trim();
                if (e.ColumnIndex == 2 || e.ColumnIndex == 3) // Check if editing happened in FunctionalAreaName or FunctionalSubAreaName column
                {

                    if (string.IsNullOrEmpty(value))
                    {
                        MessageBox.Show("Value cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        e.Cancel = true; // Cancel the event to prevent the cell from losing focus
                    }
                    else if (!IsValidString1(value))
                    {
                        MessageBox.Show("Value contains invalid characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        e.Cancel = true; // Cancel the event to prevent the cell from losing focus
                    }
                    else if (e.ColumnIndex == 3) // Only perform this check for FunctionalSubAreaName column
                    {
                        // Get the value of FunctionalAreaName from the same row
                        string functionalAreaName = dataGridView2.Rows[e.RowIndex].Cells[2].Value?.ToString()?.Trim();

                        // Check if the combination of FunctionalAreaName and FunctionalSubAreaName already exists
                        if (FunctionalAreaSubAreaCombinationExists(functionalAreaName, value))
                        {
                            MessageBox.Show("The combination of functional area and sub-area already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                            e.Cancel = true; // Cancel the event to prevent the cell from losing focus

                        }
                    }
                }
                dataGridView2.CellValidating += dataGridView2_CellValidating;


            }
        }
        private void dataGridView2_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the validated cell is in FunctionalAreaName or FunctionalSubAreaName column
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                // Get the value of the validated cell
                string value = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString()?.Trim();

                // Set the trimmed value back to the cell
                dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value;
            }
        }


        private bool FunctionalAreaSubAreaCombinationExists(string functionalAreaName, string functionalSubAreaName)
        {
            // Check if the combination of functional area and sub-area already exists
            return db.FunctionalArea.Any(fa =>
                fa.ProjectId == Form1.projectid &&
                fa.FunctionalAreaName.ToLower() == functionalAreaName.ToLower() &&
                fa.FunctionalSubAreaName.ToLower() == functionalSubAreaName.ToLower());
        }

        private bool IsValidString1(string input)
        {
            // Check if the input is not empty
            if (string.IsNullOrWhiteSpace(input))
                return false;

            // Check if the input contains only alphanumeric characters and hyphens
            if (!input.All(c => char.IsLetterOrDigit(c) || c == '-'))
                return false;

            // Check if the input contains at least one letter
            if (!input.Any(char.IsLetter))
                return false;

            // Check if the input contains only letters and digits
            if (!input.All(char.IsLetterOrDigit))
                return false;

            return true;
        }
    }
}

 