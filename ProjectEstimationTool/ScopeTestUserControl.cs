using Org.BouncyCastle.Crypto.Tls;
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
    public partial class ScopeTestUserControl : UserControl
    {
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        BindingList<ScopeAndEffort> ScopeEffortList;
        private bool isUpdatingTotal = false;
        public ScopeTestUserControl()
        {
            InitializeComponent();
            ScopeEffortList = new BindingList<ScopeAndEffort>();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;

            //dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            // Make the first row readonly



        }
        private void ScopeTestUserControl_Load(object sender, EventArgs e)
        {
            LoadScopeData();
            LoadComboBoxData();
            GenerateTotalsRow();
           
        }
        public void LoadScopeData()
        {
            try
            {
                // Clear the resources list
                /*   var res = db.ScopeAndEffort.Where(t => t.ProjectId == Form1.projectid).ToList();

                   ScopeEffortList.Clear();

                   // Fetch resources from the database

                   // Add the fetched resources to the resources list
                   foreach (ScopeAndEffort item in res)
                   {
                       ScopeEffortList.Add(item);
                   }

                   // Set the DataGridView data source
                   dataGridView1.DataSource = ScopeEffortList;*/
                var res = from t in db.ScopeAndEffort
                          where t.ProjectId == Form1.projectid
                          select t;

                List<ProjectEstimationTool.Models.ScopeAndEffort> softwareCosts = res.ToList();
                softwareCosts.Insert(0, new ProjectEstimationTool.Models.ScopeAndEffort());
                BindingList<ProjectEstimationTool.Models.ScopeAndEffort> softwareCostList = new BindingList<ProjectEstimationTool.Models.ScopeAndEffort>(softwareCosts);

                dataGridView1.DataSource = softwareCostList;
            }
            catch (Exception ex)
            {
                // Handle exception
                MessageBox.Show($"Error loading scope data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadComboBoxData()
        {
            try
            {
                var scopedata = db.ScopeAndEffort.Where(t => t.ProjectId == Form1.projectid).ToList();
                ScopeEffortList.Clear();

                // Populate FunctionalAreaName combobox
                var functionalAreas = db.FunctionalArea
                    .Where(t => t.ProjectId == Form1.projectid)
                    .Select(t => t.FunctionalAreaName)
                    .Distinct()
                    .ToList();
                var comboColumnFA = dataGridView1.Columns["FunctionalAreaName"] as DataGridViewComboBoxColumn;
                comboColumnFA.DataSource = functionalAreas;

                // Populate EffortName combobox
                var effortTypes = db.EffortType
                    .Where(t => t.ProjectId == Form1.projectid)
                    .Select(t => t.EffortName)
                    .Distinct()
                    .ToList();
                var comboColumnET = dataGridView1.Columns["EffortName"] as DataGridViewComboBoxColumn;
                comboColumnET.DataSource = effortTypes;

            }
            catch (Exception ex)
            {
                // Error handling
                MessageBox.Show($"Error populating comboboxes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error populating comboboxes: {ex.Message}");
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
            }
            else
            {
                Console.WriteLine($"Error occurred in DataGridView: {e.Exception.Message}");
            }
        }
        //private void HoursFormula(DataGridViewRow newRow)
        //{
        //    try
        //    {
        //        // Check if the DataGridView contains the "Effort" column
        //        if (!newRow.DataGridView.Columns.Contains("Effort"))
        //        {
        //            MessageBox.Show("Column named Effort cannot be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        // Check if the cell containing EffortName exists in the row
        //        if (newRow.Cells["FunctionalAreaName"].Value != null &&
        //            newRow.Cells["FunctionalSubAreaName"].Value != null &&
        //            newRow.Cells["EffortName"].Value != null)
        //        {
        //            string functionalArea = newRow.Cells["FunctionalAreaName"].Value.ToString();
        //            string functionalSubarea = newRow.Cells["FunctionalSubAreaName"].Value.ToString();
        //            string complexitySelected = newRow.Cells["EffortName"].Value.ToString();

        //            // Check if the combination already exists
        //            var existingRow = newRow.DataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(row =>
        //                row.Cells["FunctionalAreaName"] != null &&
        //                row.Cells["FunctionalAreaName"].Value != null &&
        //                row.Cells["FunctionalAreaName"].Value.ToString() == functionalArea &&
        //                row.Cells["FunctionalSubAreaName"] != null &&
        //                row.Cells["FunctionalSubAreaName"].Value != null &&
        //                row.Cells["FunctionalSubAreaName"].Value.ToString() == functionalSubarea &&
        //                row.Cells["EffortName"] != null &&
        //                row.Cells["EffortName"].Value != null &&
        //                row.Cells["EffortName"].Value.ToString() == complexitySelected &&
        //                row.Index != newRow.Index); // Exclude the current row

        //            if (existingRow != null)
        //            {
        //                MessageBox.Show("This combination already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                ClearRowValues(newRow);
        //                return;
        //            }
        //            var selectedEffortType = db.EffortType.FirstOrDefault(e => e.EffortName == complexitySelected);
        //            if (selectedEffortType != null)
        //            {
        //                int EffortId = selectedEffortType.EffortId;
        //                decimal BApercentage = selectedEffortType.Ba;
        //                decimal Devpercentage = selectedEffortType.Dev;
        //                decimal QApercentage = selectedEffortType.Qa;
        //                int actualeffort = selectedEffortType.ActualEffort;
        //                decimal BARefactor = Convert.ToDecimal(newRow.Cells["BarefactorPercentage"].Value);
        //                decimal DevRefactor = Convert.ToDecimal(newRow.Cells["DevRefactorPercentage"].Value);
        //                decimal QARefactor = Convert.ToDecimal(newRow.Cells["QarefactorPercentage"].Value);
        //                int OfOperations = Convert.ToInt32(newRow.Cells["NumberOfOperations"].Value);
        //                decimal BAhours = Convert.ToDecimal(actualeffort * (BApercentage / 100.0m)) * OfOperations;
        //                decimal Devhours = Convert.ToDecimal(actualeffort * (Devpercentage / 100.0m)) * OfOperations;
        //                decimal QAhours = Convert.ToDecimal(actualeffort * (QApercentage / 100.0m)) * OfOperations;
        //                decimal BAFinalhours = BAhours * (1 - (BARefactor / 100.0m));
        //                decimal DevFinalhours = Devhours * (1 - (DevRefactor / 100.0m));
        //                decimal QAFinalhours = QAhours * (1 - (QARefactor / 100.0m));
        //                int Effort = (int)(BAFinalhours + DevFinalhours + QAFinalhours);

        //                newRow.Cells["Effort"].Value = Effort;
        //                newRow.Cells["BaHrs"].Value = BAhours;
        //                newRow.Cells["BafinalHrs"].Value = Math.Round(BAFinalhours, 2);
        //                newRow.Cells["DevHrs"].Value = Devhours;
        //                newRow.Cells["DevFinalHrs"].Value = Math.Round(DevFinalhours, 2);
        //                newRow.Cells["QaHrs"].Value = QAhours;
        //                newRow.Cells["QafinalHrs"].Value = Math.Round(QAFinalhours, 2);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Effort type not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                ClearRowValues(newRow);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("EffortName parameter not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error in HoursFormula: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }


        //}

        private void HoursFormula(DataGridViewRow newRow)
        {
            try
            {
                // Check if the DataGridView contains the "Effort" column
                if (!newRow.DataGridView.Columns.Contains("Effort"))
                {
                    MessageBox.Show("Column named Effort cannot be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the cell containing EffortName exists in the row
                if (newRow.Cells["FunctionalAreaName"].Value != null &&
                    newRow.Cells["FunctionalSubAreaName"].Value != null &&
                    newRow.Cells["EffortName"].Value != null)
                {
                    string functionalArea = newRow.Cells["FunctionalAreaName"].Value.ToString();
                    string functionalSubarea = newRow.Cells["FunctionalSubAreaName"].Value.ToString();
                    string complexitySelected = newRow.Cells["EffortName"].Value.ToString();

                    // Check if the combination already exists
                    var existingRow = newRow.DataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(row =>
                        row.Cells["FunctionalAreaName"] != null &&
                        row.Cells["FunctionalAreaName"].Value != null &&
                        row.Cells["FunctionalAreaName"].Value.ToString() == functionalArea &&
                        row.Cells["FunctionalSubAreaName"] != null &&
                        row.Cells["FunctionalSubAreaName"].Value != null &&
                        row.Cells["FunctionalSubAreaName"].Value.ToString() == functionalSubarea &&
                        row.Cells["EffortName"] != null &&
                        row.Cells["EffortName"].Value != null &&
                        row.Cells["EffortName"].Value.ToString() == complexitySelected &&
                        row.Index != newRow.Index); // Exclude the current row

                    if (existingRow != null)
                    {
                        MessageBox.Show("This combination already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearRowValues(newRow);
                        return;
                    }

                    var selectedEffortType = db.EffortType.FirstOrDefault(e => e.EffortName == complexitySelected);
                    if (selectedEffortType != null)
                    {
                        int actualeffort = selectedEffortType.ActualEffort;
                        decimal BApercentage = selectedEffortType.Ba;
                        decimal Devpercentage = selectedEffortType.Dev;
                        decimal QApercentage = selectedEffortType.Qa;

                        // Validate NumberOfOperations
                        if (newRow.Cells["NumberOfOperations"].Value != null && newRow.Cells["NumberOfOperations"].Value is int)
                        {
                            int OfOperations = Convert.ToInt32(newRow.Cells["NumberOfOperations"].Value);

                            if (OfOperations < 0)
                            {
                                MessageBox.Show("Number of operations cannot be negative.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                newRow.Cells["NumberOfOperations"].Value = null;
                                return;
                            }

                            decimal BARefactor = Convert.ToDecimal(newRow.Cells["BarefactorPercentage"].Value);
                            decimal DevRefactor = Convert.ToDecimal(newRow.Cells["DevRefactorPercentage"].Value);
                            decimal QARefactor = Convert.ToDecimal(newRow.Cells["QarefactorPercentage"].Value);

                            decimal BAhours = Convert.ToDecimal(actualeffort * (BApercentage / 100.0m)) * OfOperations;
                            decimal Devhours = Convert.ToDecimal(actualeffort * (Devpercentage / 100.0m)) * OfOperations;
                            decimal QAhours = Convert.ToDecimal(actualeffort * (QApercentage / 100.0m)) * OfOperations;

                            decimal BAFinalhours = BAhours * (1 - (BARefactor / 100.0m));
                            decimal DevFinalhours = Devhours * (1 - (DevRefactor / 100.0m));
                            decimal QAFinalhours = QAhours * (1 - (QARefactor / 100.0m));

                            int Effort = (int)(BAFinalhours + DevFinalhours + QAFinalhours);

                            newRow.Cells["Effort"].Value = Effort;
                            newRow.Cells["BaHrs"].Value = BAhours;
                            newRow.Cells["BafinalHrs"].Value = Math.Round(BAFinalhours, 2);
                            newRow.Cells["DevHrs"].Value = Devhours;
                            newRow.Cells["DevFinalHrs"].Value = Math.Round(DevFinalhours, 2);
                            newRow.Cells["QaHrs"].Value = QAhours;
                            newRow.Cells["QafinalHrs"].Value = Math.Round(QAFinalhours, 2);
                        }
                        else
                        {
                            MessageBox.Show("Invalid value for Number of Operations.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ClearRowValues(newRow);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Effort type not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearRowValues(newRow);
                    }
                }
                else
                {
                    MessageBox.Show("EffortName parameter not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in HoursFormula: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ClearRowValues(DataGridViewRow row)
        {
            // Clear the values in the specified row
            row.Cells["FunctionalAreaName"].Value = null;
            row.Cells["FunctionalSubAreaName"].Value = null;
            row.Cells["EffortName"].Value = null;
            row.Cells["Effort"].Value = null;
            row.Cells["BaHrs"].Value = null;
            row.Cells["BafinalHrs"].Value = null;
            row.Cells["DevHrs"].Value = null;
            row.Cells["DevFinalHrs"].Value = null;
            row.Cells["QaHrs"].Value = null;
            row.Cells["QafinalHrs"].Value = null;
        }





        private void AddNewScopeAndEffort(DataGridViewRow newRow)
        {
            try
            {
                // Check if the row is null
                if (newRow == null)
                {
                    MessageBox.Show("The row is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if all required fields are filled
                string selectedFunctionalArea = newRow.Cells["FunctionalAreaName"]?.Value?.ToString();
                string selectedComplexity = newRow.Cells["EffortName"]?.Value?.ToString();
                string numberOfOperationsStr = newRow.Cells["NumberOfOperations"]?.Value?.ToString();
                string barefactorPercentageStr = newRow.Cells["BarefactorPercentage"]?.Value?.ToString();
                string devRefactorPercentageStr = newRow.Cells["DevRefactorPercentage"]?.Value?.ToString();
                string qaRefactorPercentageStr = newRow.Cells["QarefactorPercentage"]?.Value?.ToString();

                if (string.IsNullOrWhiteSpace(selectedFunctionalArea) ||
                    string.IsNullOrWhiteSpace(selectedComplexity) ||
                    string.IsNullOrWhiteSpace(numberOfOperationsStr) ||
                    string.IsNullOrWhiteSpace(barefactorPercentageStr) ||
                    string.IsNullOrWhiteSpace(devRefactorPercentageStr) ||
                    string.IsNullOrWhiteSpace(qaRefactorPercentageStr))
                {
                    return;
                }

                // Convert string values to appropriate types
                if (!int.TryParse(numberOfOperationsStr, out int numberOfOperations) ||
                    !int.TryParse(barefactorPercentageStr, out int barefactorPercentage) ||
                    !int.TryParse(devRefactorPercentageStr, out int devRefactorPercentage) ||
                    !int.TryParse(qaRefactorPercentageStr, out int qaRefactorPercentage))
                {
                    MessageBox.Show("One or more fields contain invalid values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calculate the other fields using the formula
                //  HoursFormula(newRow);

                // Fetch IDs from the database
                int functionalAreaID = db.FunctionalArea.FirstOrDefault(f => f.FunctionalAreaName == selectedFunctionalArea)?.FunctionalAreaId ?? 0;
                int effortId = db.EffortType.FirstOrDefault(f => f.EffortName == selectedComplexity)?.EffortId ?? 0;

                // Validate IDs
                if (functionalAreaID == 0 || effortId == 0)
                {
                    MessageBox.Show("Functional area ID or Effort ID not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a new ScopeAndEffort object
                ScopeAndEffort newScopeAndEffort = new ScopeAndEffort
                {
                    ProjectId = Form1.projectid,
                    FunctionalAreaId = functionalAreaID,
                    EffortId = effortId,
                    EffortName = selectedComplexity,
                    FunctionalAreaName = selectedFunctionalArea,
                    FunctionalSubAreaName = newRow.Cells["FunctionalSubAreaName"]?.Value?.ToString() ?? "",
                    NumberOfOperations = numberOfOperations,
                    BarefactorPercentage = barefactorPercentage,
                    DevRefactorPercentage = devRefactorPercentage,
                    QarefactorPercentage = qaRefactorPercentage,
                    Description = newRow.Cells["Description"]?.Value?.ToString() ?? "",
                    BaHrs = Convert.ToDecimal(newRow.Cells["BaHrs"]?.Value),
                    BafinalHrs = Convert.ToDecimal(newRow.Cells["BafinalHrs"]?.Value),
                    DevHrs = Convert.ToDecimal(newRow.Cells["DevHrs"]?.Value),
                    DevFinalHrs = Convert.ToDecimal(newRow.Cells["DevFinalHrs"]?.Value),
                    QaHrs = Convert.ToDecimal(newRow.Cells["QaHrs"]?.Value),
                    QafinalHrs = Convert.ToDecimal(newRow.Cells["QafinalHrs"]?.Value),
                    Effort = Convert.ToInt32(newRow.Cells["Effort"]?.Value)
                };

                // Add the new ScopeAndEffort object to the database
                db.ScopeAndEffort.Add(newScopeAndEffort);
                db.SaveChanges(); // Save changes to the database
                GenerateTotalsRow();


                // Refresh DataGridView
                LoadScopeData();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding new scope and effort: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateScopeAndEffort(DataGridViewRow editedRow)
        {
            try
            {
                // Get the ScopeAndEffortId of the edited row
                int scopeAndEffortId = Convert.ToInt32(editedRow.Cells["ScopeAndEffortId"].Value);
                Console.WriteLine(scopeAndEffortId.ToString());
                // Retrieve the existing ScopeAndEffort object from the database
                var existingScopeAndEffort = db.ScopeAndEffort.FirstOrDefault(s => s.ScopeAndEffortId == scopeAndEffortId);

                if (existingScopeAndEffort != null)
                {
                    // Update the existing ScopeAndEffort object with the edited values
                    existingScopeAndEffort.FunctionalAreaName = editedRow.Cells["FunctionalAreaName"]?.Value?.ToString();
                    existingScopeAndEffort.EffortName = editedRow.Cells["EffortName"]?.Value?.ToString();
                    existingScopeAndEffort.FunctionalSubAreaName = editedRow.Cells["FunctionalSubAreaName"]?.Value?.ToString() ?? "";
                    existingScopeAndEffort.NumberOfOperations = Convert.ToInt32(editedRow.Cells["NumberOfOperations"]?.Value);
                    existingScopeAndEffort.BarefactorPercentage = Convert.ToInt32(editedRow.Cells["BarefactorPercentage"]?.Value);
                    existingScopeAndEffort.DevRefactorPercentage = Convert.ToInt32(editedRow.Cells["DevRefactorPercentage"]?.Value);
                    existingScopeAndEffort.QarefactorPercentage = Convert.ToInt32(editedRow.Cells["QarefactorPercentage"]?.Value);
                    existingScopeAndEffort.Description = editedRow.Cells["Description"]?.Value?.ToString() ?? "";
                    existingScopeAndEffort.BaHrs = Convert.ToDecimal(editedRow.Cells["BaHrs"]?.Value);
                    existingScopeAndEffort.BafinalHrs = Convert.ToDecimal(editedRow.Cells["BafinalHrs"]?.Value);
                    existingScopeAndEffort.DevHrs = Convert.ToDecimal(editedRow.Cells["DevHrs"]?.Value);
                    existingScopeAndEffort.DevFinalHrs = Convert.ToDecimal(editedRow.Cells["DevFinalHrs"]?.Value);
                    existingScopeAndEffort.QaHrs = Convert.ToDecimal(editedRow.Cells["QaHrs"]?.Value);
                    existingScopeAndEffort.QafinalHrs = Convert.ToDecimal(editedRow.Cells["QafinalHrs"]?.Value);
                    existingScopeAndEffort.Effort = Convert.ToInt32(editedRow.Cells["Effort"]?.Value);

                    // Save changes to the database
                    db.SaveChanges();
                    GenerateTotalsRow();

                    // Refresh DataGridView
                    // LoadScopeData();

                }
                else
                {
                    MessageBox.Show("Scope and Effort record not found for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Error updating scope and effort: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



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

                    // Update the database with the edited row's data
                    //    UpdateDatabase(rowIndex, columnIndex);

                    // If any of the relevant columns are edited, recalculate the hours formula for the edited row
                    if (dataGridView1.Columns[columnIndex].Name == "EffortName" ||
                        dataGridView1.Columns[columnIndex].Name == "BarefactorPercentage" ||
                        dataGridView1.Columns[columnIndex].Name == "DevRefactorPercentage" ||
                        dataGridView1.Columns[columnIndex].Name == "QarefactorPercentage" ||
                        dataGridView1.Columns[columnIndex].Name == "NumberOfOperations")
                    {
                        HoursFormula(editedRow);
                    }

                    // Call the method to add new scope and effort if ScopeAndEffortId is 0 (indicating a new entry)
                    if (dataGridView1.Rows[rowIndex].Cells["ScopeAndEffortId"].Value.ToString() == "0")
                    {
                        AddNewScopeAndEffort(editedRow);
                    }
                    else
                    {
                        // Call the method to update existing scope and effort if ScopeAndEffortId is not 0
                        UpdateScopeAndEffort(editedRow);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error handling cell edit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }




        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                // Check if any row is selected
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Display a confirmation message box
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // If the user confirms deletion
                    if (result == DialogResult.Yes)
                    {
                        // Retrieve the selected row
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                        // Retrieve the ScopeAndEffort object from the selected row
                        ScopeAndEffort selectedScopeAndEffort = selectedRow.DataBoundItem as ScopeAndEffort;

                        // Remove the row from the BindingList and from the DataGridView
                        ScopeEffortList.Remove(selectedScopeAndEffort);

                        // Save changes to the database
                        db.ScopeAndEffort.Remove(selectedScopeAndEffort);
                        db.SaveChanges();
                    }
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the cell is in one of the percentage columns
            if (dataGridView1.Columns[e.ColumnIndex].Name == "BarefactorPercentage" ||
                dataGridView1.Columns[e.ColumnIndex].Name == "DevRefactorPercentage" ||
                dataGridView1.Columns[e.ColumnIndex].Name == "QarefactorPercentage")
            {
                // Check if the cell value is not null and can be converted to decimal
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    // Format the value to display with % symbol
                    e.Value = value.ToString("N2") + "%";
                    e.FormattingApplied = true; // Specify that the formatting has been applied
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv != null && dgv.CurrentCell != null && dgv.CurrentCell.RowIndex == 0)
            {
                // Disable editing for the first row
                e.Control.Enabled = false;

                // Set the foreground color to black
                e.Control.ForeColor = Color.Black;
                e.Control.BackColor = Color.Black;
            }
        }


        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["FunctionalAreaName"]?.Index && e.RowIndex >= 0)
            {
                var selectedFunctionalArea = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (selectedFunctionalArea != null)
                {
                    dataGridView1.Rows[e.RowIndex].Cells["FunctionalSubAreaName"].Value = "";
                    var subAreas = (from t in db.FunctionalArea
                                    where t.ProjectId == Form1.projectid && t.FunctionalAreaName == selectedFunctionalArea
                                    select t.FunctionalSubAreaName).ToList();
                    DataGridViewComboBoxCell subAreaCell = dataGridView1.Rows[e.RowIndex].Cells["FunctionalSubAreaName"] as DataGridViewComboBoxCell;
                    if (subAreaCell != null)
                    {
                        subAreaCell.DataSource = subAreas;
                    }
                    else
                    {
                        MessageBox.Show("DataGridViewComboBoxCell named 'functionalSubAreaNameDataGridViewTextBoxColumn' not found.");
                    }
                }
            }

        }



        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }
        private void GenerateTotalsRow()
        {
            if (!isUpdatingTotal)
            {
                isUpdatingTotal = true;
                try
                {
                    decimal totalOperations = 0;
                    decimal totalEffort = 0;
                    decimal totalQA = 0;
                    decimal totalBA = 0;
                    decimal totalDev = 0;
                    decimal totalQAFinalHrs = 0;
                    decimal totalDevFinalHrs = 0;
                    decimal totalBAFinalHrs = 0;
                    decimal totalbarefaper = 0;
                    decimal totaldevrefacper = 0;
                    decimal totalqarefacper = 0;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            totalOperations += Convert.ToDecimal(row.Cells["NumberOfOperations"].Value);
                            totalEffort += Convert.ToDecimal(row.Cells["Effort"].Value);
                            totalQA += Convert.ToDecimal(row.Cells["QaHrs"].Value);
                            totalBA += Convert.ToDecimal(row.Cells["BaHrs"].Value);
                            totalDev += Convert.ToDecimal(row.Cells["DevHrs"].Value);
                            totalQAFinalHrs += Convert.ToDecimal(row.Cells["QafinalHrs"].Value);
                            totalDevFinalHrs += Convert.ToDecimal(row.Cells["DevFinalHrs"].Value);
                            totalBAFinalHrs += Convert.ToDecimal(row.Cells["BafinalHrs"].Value);
                            totalbarefaper += Convert.ToDecimal(row.Cells["BarefactorPercentage"].Value);
                            totaldevrefacper += Convert.ToDecimal(row.Cells["DevRefactorPercentage"].Value);
                            totalqarefacper += Convert.ToDecimal(row.Cells["QarefactorPercentage"].Value);

                        }
                    }
                    var totalRow = dataGridView1.Rows[0].DataBoundItem as ProjectEstimationTool.Models.ScopeAndEffort;
                    if (totalRow != null)
                    {
                        totalRow.NumberOfOperations = (int)totalOperations;
                        totalRow.Effort = (int)Math.Round(totalEffort, 2);
                        totalRow.QaHrs = (int)Math.Round(totalQA, 2);
                        totalRow.BaHrs = (int)Math.Round(totalBA, 2);
                        totalRow.DevHrs = (int)Math.Round(totalDev, 2);
                        totalRow.QafinalHrs = (int)Math.Round(totalQAFinalHrs, 2);
                        totalRow.DevFinalHrs = (int)Math.Round(totalDevFinalHrs, 2);
                        totalRow.BafinalHrs = (int)Math.Round(totalBAFinalHrs, 2);
                        totalRow.BarefactorPercentage = (int)Math.Round(totalbarefaper, 2);
                        totalRow.QarefactorPercentage = (int)Math.Round(totalqarefacper, 2);
                        totalRow.DevRefactorPercentage = (int)Math.Round(totaldevrefacper, 2);
                    }
                }
                finally
                {
                    isUpdatingTotal = false;
                }
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    var functionalArea = row.Cells["FunctionalAreaName"].Value?.ToString();
                    if (!string.IsNullOrEmpty(functionalArea))
                    {
                        var subAreas = (from t in db.FunctionalArea
                                        where t.ProjectId == Form1.projectid && t.FunctionalAreaName == functionalArea
                                        select t.FunctionalSubAreaName).Distinct().ToList();

                        DataGridViewComboBoxCell subAreaCell = row.Cells["FunctionalSubAreaName"] as DataGridViewComboBoxCell;

                        if (subAreaCell != null)
                        {
                            subAreaCell.DataSource = subAreas;
                        }
                        else
                        {
                            MessageBox.Show($"DataGridViewComboBoxCell for functional area '{functionalArea}' not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error populating sub areas: " + ex.Message);
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Check if it's the first row
            if (e.RowIndex == 0)
            {
                // Set the background color of the first row to black
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Black;
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;


                // Make the first row readonly
                foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                {
                    cell.ReadOnly = true;
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

