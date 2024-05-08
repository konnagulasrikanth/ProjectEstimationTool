using Guna.UI2.AnimatorNS;
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
    public partial class SoftwareCostingTest : UserControl
    {
        private bool comboBoxDropDownHandlerAttached = false;

        ProjectEstimationToolMasterContext p;
        private DataGridView dataGridView1;
        private ComboBox comboBox;
        private CheckedListBox checkedListBox;
        private List<object> selectedItemsList;
        private bool isDropDownVisible;
        public SoftwareCostingTest()
        {
            InitializeComponent();
            p = new ProjectEstimationToolMasterContext();
            dataGridView1 = new DataGridView();
            comboBox = new ComboBox();
            checkedListBox = new CheckedListBox();
            selectedItemsList = new List<object>();
            isDropDownVisible = false;
            InitializeDataGridView();
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            checkedListBox.LostFocus += CheckedListBox_LostFocus;
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
        }

        private void SoftwareCostingTest_Load(object sender, EventArgs e)
        {
            try
            {
                Loaddata();
                UpdateSoftwareCostingData();
                PopulateSoftwareListColumn();

            }
            catch (Exception ex)
            {
                MessageBox.Show("357");
            }
        }
        private void InitializeDataGridView()
        {
            try
            {

                dataGridView1 = new DataGridView();
                dataGridView1.Size = new Size(1100, 200);
                dataGridView1.Dock = DockStyle.None;
                dataGridView1.Location = new Point((this.Width - dataGridView1.Width) / 2, (this.Height - dataGridView1.Height) / 2); // Centering the DataGridView
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // Set the default column header cell style alignment to left
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dataGridView1.BackgroundColor = Color.White;
                DataGridViewComboBoxColumn softwareListColumn = new DataGridViewComboBoxColumn();
                softwareListColumn.Name = "SoftwareList";
                softwareListColumn.HeaderText = "Software List";
                softwareListColumn.DataPropertyName = "SoftwareName";
                softwareListColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                softwareListColumn.FlatStyle = FlatStyle.Popup;
                DataGridViewTextBoxColumn softidColumn = new DataGridViewTextBoxColumn();
                softidColumn.Name = "softidColumn";
                softidColumn.DataPropertyName = "softid";
                softidColumn.HeaderText = "Soft ID";
                softidColumn.Visible = false;
                DataGridViewTextBoxColumn projectIdColumn = new DataGridViewTextBoxColumn();
                projectIdColumn.Name = "projectidColumn";
                projectIdColumn.DataPropertyName = "Projectid";
                projectIdColumn.HeaderText = "Project ID";
                projectIdColumn.Visible = false;
                DataGridViewTextBoxColumn resCostIDColumn = new DataGridViewTextBoxColumn();
                resCostIDColumn.Name = "ResCostIDColumn";
                resCostIDColumn.DataPropertyName = "ResCostID";
                resCostIDColumn.HeaderText = "Resource Cost ID";
                resCostIDColumn.Visible = false;
                DataGridViewTextBoxColumn phaseColumn = new DataGridViewTextBoxColumn();
                phaseColumn.Name = "PhaseColumn";
                phaseColumn.DataPropertyName = "Phase";
                phaseColumn.HeaderText = "Phase";
                phaseColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DataGridViewTextBoxColumn resCountColumn = new DataGridViewTextBoxColumn();
                resCountColumn.Name = "RescountColumn";
                resCountColumn.DataPropertyName = "Rescount";
                resCountColumn.HeaderText = "Res.Count";
                resCountColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DataGridViewTextBoxColumn countrycolumn = new DataGridViewTextBoxColumn();
                countrycolumn.Name = "Country";
                countrycolumn.DataPropertyName = "Country";
                countrycolumn.HeaderText = "Country";
                DataGridViewTextBoxColumn restypecolumn = new DataGridViewTextBoxColumn();
                restypecolumn.Name = "restype";
                restypecolumn.DataPropertyName = "restype";
                restypecolumn.HeaderText = "Res.Type";
                DataGridViewTextBoxColumn rolcolumn = new DataGridViewTextBoxColumn();
                rolcolumn.Name = "RoleLevel"; // Ensure that the Name matches the DataPropertyName
                rolcolumn.DataPropertyName = "RoleLevel"; // Ensure that the DataPropertyName matches the property name in your data source
                rolcolumn.HeaderText = "Rol.Level";
                rolcolumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DataGridViewTextBoxColumn weeksColumn = new DataGridViewTextBoxColumn();
                weeksColumn.Name = "weeksColumn";
                weeksColumn.DataPropertyName = "DurationMM";
                weeksColumn.HeaderText = "Weeks";
                weeksColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DataGridViewTextBoxColumn softwareCostColumn = new DataGridViewTextBoxColumn();
                softwareCostColumn.Name = "SoftwareCostColumn";
                softwareCostColumn.DataPropertyName = "SoftwareCost";
                softwareCostColumn.HeaderText = "Total Cost";
                softwareCostColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // Adjust column widths and alignment
                resCountColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                resCountColumn.Width = 95; // Set your desired width here
                countrycolumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                countrycolumn.Width = 80; // Set your desired width here
                restypecolumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                restypecolumn.Width = 90; // Set your desired width here
                rolcolumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                rolcolumn.Width = 80; // Set your desired width here
                weeksColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                weeksColumn.Width = 60;
                softwareCostColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                softwareCostColumn.Width = 110;


                dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                          softidColumn,
                          projectIdColumn,
                          resCostIDColumn,
                          phaseColumn,
                          resCountColumn,
                          countrycolumn,
                          restypecolumn,
                          rolcolumn,
                          weeksColumn,
                          softwareListColumn,
                           softwareCostColumn
                              });
                // Set column header style
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Palatino Linotype", 12, FontStyle.Bold);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RosyBrown;
                dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
                dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.RosyBrown;


                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
                dataGridView1.DefaultCellStyle.BackColor = Color.White;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dataGridView1.DefaultCellStyle.Font = new Font("Palatino Linotype", 10, FontStyle.Bold);

                Controls.Add(dataGridView1);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.AllowUserToAddRows = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("116");
            }

        }
    
        public void Loaddata()
        {
            try
            {
                // Fetch distinct phases from resource costing
                var distinctPhases = p.ResourceCosting
                    .Where(rc => rc.ProjectId == Form1.projectid)
                    .Select(rc => rc.Phase)
                    .Distinct()
                    .ToList();

                foreach (var phase in distinctPhases)
                {
                    // Get all resource costing records for the current phase
                    var resourceCostsForPhase = p.ResourceCosting
                        .Where(rc => rc.ProjectId == Form1.projectid && rc.Phase == phase)
                        .ToList();

                    // Update software costing data for each resource costing record
                    foreach (var resourceCost in resourceCostsForPhase)
                    {
                        // Check if there's any corresponding software costing data
                        var existingSoftwareCosts = p.SoftwareCostingTest
                            .Where(sc => sc.ProjectId == Form1.projectid && sc.Phase == phase && sc.ResourceCostingId == resourceCost.ResourceCostingId)
                            .ToList();

                        if (existingSoftwareCosts.Count == 0)
                        {
                            // Create new software costing record
                            var softwareCost = new ProjectEstimationTool.Models.SoftwareCostingTest
                            {
                                ProjectId = Form1.projectid,
                                ResourceCostingId = resourceCost.ResourceCostingId,
                                Phase = resourceCost.Phase,
                                ResCount = resourceCost.ResCount,
                                Country = resourceCost.Country,
                                ResType = resourceCost.ResType,
                                RoleLevel = resourceCost.RoleLevel,
                                SoftwareName = string.Empty,
                                SoftwareCost = 0,
                                DurationMm = resourceCost.DurationMm,
                            };
                            p.SoftwareCostingTest.Add(softwareCost);
                        }
                        else
                        {
                            // Update existing software costing records
                            foreach (var existingSoftwareCost in existingSoftwareCosts)
                            {
                                existingSoftwareCost.ResCount = resourceCost.ResCount;
                                existingSoftwareCost.DurationMm = resourceCost.DurationMm;
                                existingSoftwareCost.Country = resourceCost.Country;
                                existingSoftwareCost.ResType = resourceCost.ResType;
                                existingSoftwareCost.RoleLevel = resourceCost.RoleLevel;
                                existingSoftwareCost.SoftwareCost = CalculateTotalCost(existingSoftwareCost);
                            }
                        }
                    }
                }

                // Save changes to the database
                p.SaveChanges();

                // Bind the software costing data to the DataGridView
                dataGridView1.DataSource = p.SoftwareCostingTest.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading allocation data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int CalculateTotalCost(ProjectEstimationTool.Models.SoftwareCostingTest softwareCost)
        {
            // Implement your logic to calculate total cost here
            var software = p.Software.FirstOrDefault(s => s.SoftwareName == softwareCost.SoftwareName);
            var resourceCost = p.ResourceCosting.FirstOrDefault(rc => rc.ResourceCostingId == softwareCost.ResourceCostingId);
            var productivity = p.Productivity.FirstOrDefault(p => p.ProjectId == Form1.projectid && p.ProductivityName == "Week");

            if (software != null && resourceCost != null && productivity != null)
            {
                // Calculate total cost
                int totalCost = (int)(resourceCost.ResCount * resourceCost.DurationMm * software.MonthlyRate * productivity.Hours);
                return totalCost;
            }
            else
            {
                // Handle the case where one of the required entities is not found
                // For simplicity, returning 0 as total cost
                return 0;
            }
        }


        // Method to update software costing data when changes are made in resource costing
        private void UpdateSoftwareCostingData()
        {
            try
            {
                // Get distinct phases from resource costing
                var distinctPhases = p.ResourceCosting
                    .Where(rc => rc.ProjectId == Form1.projectid)
                    .Select(rc => rc.Phase)
                    .Distinct()
                    .ToList();

                foreach (var phase in distinctPhases)
                {
                    // Check if there's any corresponding software costing data
                    var softwareCosts = p.SoftwareCostingTest
                        .Where(sc => sc.ProjectId == Form1.projectid && sc.Phase == phase)
                        .ToList();

                    // If there's no software costing data for the phase, create it
                    if (softwareCosts.Count == 0)
                    {
                        var phasesForCurrentPhase = p.ResourceCosting
                            .Where(rc => rc.ProjectId == Form1.projectid && rc.Phase == phase)
                            .ToList();
                        foreach (var rc in phasesForCurrentPhase)
                        {
                            var softwareCost = new ProjectEstimationTool.Models.SoftwareCostingTest
                            {
                                ProjectId = Form1.projectid,
                                ResourceCostingId = rc.ResourceCostingId,
                                Phase = rc.Phase,
                                ResCount = rc.ResCount,
                                Country = rc.Country,
                                ResType = rc.ResType,
                                RoleLevel = rc.RoleLevel,
                                SoftwareName = string.Empty,
                                SoftwareCost = 0,
                                DurationMm = rc.DurationMm,
                            };
                            p.SoftwareCostingTest.Add(softwareCost);
                        }
                    }
                }
                // Save changes outside the loop to avoid saving for each record
                p.SaveChanges();
                dataGridView1.DataSource = p.SoftwareCostingTest.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating software costing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Update DataGridView with selected software name and calculate software cost
                if (e.ColumnIndex == dataGridView1.Columns["SoftwareList"].Index && e.RowIndex >= 0)
                {
                    var selectedSoftware = dataGridView1.Rows[e.RowIndex].Cells["SoftwareList"].Value?.ToString();
                    if (!string.IsNullOrEmpty(selectedSoftware))
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error handling cell value change: " + ex.Message);
            }
        }



        private void ShowDropDownCheckList()
        {
            try
            {
                DataGridViewColumn currentColumn = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex];
                if (currentColumn.Name == "SoftwareList")
                {
                    checkedListBox.Items.Clear();

                    // Populate the checklist box with all available options
                    var distinctSoftwareList = GetDistinctSoftwareList();
                    foreach (var item in distinctSoftwareList)
                    {
                        checkedListBox.Items.Add(item);
                    }

                    checkedListBox.ItemCheck += (sender, e) =>
                    {
                        object selectedItem = checkedListBox.Items[e.Index];
                        if (e.NewValue == CheckState.Checked)
                        {
                            if (!selectedItemsList.Contains(selectedItem))
                            {
                                selectedItemsList.Add(selectedItem);
                            }
                        }
                        else
                        {
                            selectedItemsList.Remove(selectedItem);
                        }
                    };

                    checkedListBox.LostFocus += (sender, e) =>
                    {
                        if (isDropDownVisible)
                        {
                            dataGridView1.EndEdit();
                            checkedListBox.Visible = false;
                            isDropDownVisible = false;
                            UpdateDatabaseWithSelectedItems();
                        }
                    };

                    checkedListBox.Height = 100;

                    // Get the bounds of the cell to position the checkedListBox below the comboBox
                    Rectangle cellBounds = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, false);
                    checkedListBox.Left = cellBounds.Left;
                    checkedListBox.Top = cellBounds.Bottom;
                    checkedListBox.Width = cellBounds.Width;

                    dataGridView1.Controls.Add(checkedListBox);
                    checkedListBox.BringToFront();
                    checkedListBox.Focus();

                    checkedListBox.Visible = true;

                    // Update the checkedListBox based on the current cell value
                    string phase = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["PhaseColumn"].Value?.ToString();
                    if (phase != null)
                    {
                        var resourceCostingData = p.SoftwareCostingTest
                            .Where(rc => rc.ProjectId == Form1.projectid && rc.Phase == phase)
                            .Select(rc => rc.SoftwareName).FirstOrDefault(); // Assuming only one value is retrieved

                        if (resourceCostingData != null)
                        {
                            // Split the string to get individual software names
                            var selectedItems = resourceCostingData.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var selectedItem in selectedItems)
                            {
                                int index = checkedListBox.Items.IndexOf(selectedItem.Trim());
                                if (index >= 0)
                                {
                                    checkedListBox.SetItemChecked(index, true);
                                }
                            }
                        }
                        PopulateSoftwareListColumn();

                    }

                    isDropDownVisible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing dropdown checklist: " + ex.Message);
            }
        }

        private void PopulateSoftwareListColumn()
        {
            try
            {
                // Clear existing items in the combobox column
                DataGridViewComboBoxColumn softwareListColumn = dataGridView1.Columns["SoftwareList"] as DataGridViewComboBoxColumn;
                if (softwareListColumn != null)
                {
                    softwareListColumn.Items.Clear();

                    // Fetch distinct software names from the SoftwareCosting table
                    var distinctSoftwareList = p.SoftwareCostingTest
                        .Where(sc => sc.ProjectId == Form1.projectid)
                        .Select(sc => sc.SoftwareName)
                        .Distinct()
                        .ToList();

                    // Add distinct software names to the combobox column
                    foreach (var softwareName in distinctSoftwareList)
                    {
                        softwareListColumn.Items.Add(softwareName);
                    }

                    // Iterate through DataGridView rows and check the appropriate items
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        var softwareName = row.Cells["SoftwareList"].Value?.ToString();
                        if (!string.IsNullOrEmpty(softwareName))
                        {
                            // Check the item if it exists in the SoftwareCosting table
                            if (distinctSoftwareList.Contains(softwareName))
                            {
                                row.Cells["SoftwareList"].Value = softwareName;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("SoftwareList column not found.");
                }
                // Format the SoftwareCost column to display values in dollars
                dataGridView1.Columns["SoftwareCostColumn"].DefaultCellStyle.Format = "C";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error populating SoftwareList column: " + ex.Message);
            }
        }

        private List<object> GetDistinctSoftwareList()
        {

            var list = (from t in p.Software
                        where t.ProjectId == Form1.projectid
                        select t.SoftwareName).Distinct().ToList();

            return list.Cast<object>().ToList();

        }


        private int CalculateSoftwareCost(ProjectEstimationTool.Models.SoftwareCostingTest softwareCost)
        {
            try
            {
                string[] selectedSoftware = softwareCost.SoftwareName.Split(',');
                int totalCost = 0;
                foreach (string softwareItem in selectedSoftware)
                {
                    string trimmedSoftwareItem = softwareItem.Trim();
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                    ProjectEstimationTool.Models.SoftwareCostingTest selectedSoftwareCost = selectedRow.DataBoundItem as ProjectEstimationTool.Models.SoftwareCostingTest;
                    var software = p.Software.FirstOrDefault(s => s.SoftwareName == trimmedSoftwareItem);
                    var s = (from t in p.ResourceCosting
                             where t.ProjectId == Form1.projectid && t.Phase == selectedSoftwareCost.Phase
                             select t).FirstOrDefault();
                    var hours = (from t in p.Productivity
                                 where t.ProjectId == Form1.projectid && t.ProductivityName == "Week"
                                 select t.Hours).FirstOrDefault();
                    if (software != null && s != null)
                    {
                        totalCost += (int)(s.ResCount * s.DurationMm * software.MonthlyRate);
                    }
                    else
                    {
                    }
                }
                return totalCost;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating software cost: " + ex.Message);
                return 0;
            }
        }


        private void UpdateDatabaseWithSelectedItems()
        {
            try
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                ProjectEstimationTool.Models.SoftwareCostingTest selectedSoftwareCost = selectedRow.DataBoundItem as ProjectEstimationTool.Models.SoftwareCostingTest;
                if (selectedRow != null)
                {
                    if (selectedSoftwareCost != null)
                    {
                        // Get the selected item from the checklist box
                        var selectedItem = checkedListBox.SelectedItem;
                        if (selectedItem != null)
                        {
                            selectedSoftwareCost.SoftwareName = string.Join(", ", selectedItemsList);
                            selectedSoftwareCost.SoftwareCost = CalculateSoftwareCost(selectedSoftwareCost);

                            if (selectedSoftwareCost.Phase != null)
                            {

                                p.SaveChanges(); // Save changes to the database
                                PopulateSoftwareListColumn();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating database: " + ex.Message);
            }
        }



        private void CheckedListBox_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (isDropDownVisible)
                {
                    dataGridView1.EndEdit();
                    checkedListBox.Visible = false;
                    isDropDownVisible = false;
                    UpdateDatabaseWithSelectedItems();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("283");
            }
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["SoftwareList"].Index && e.Control is ComboBox)
                {

                    comboBox = e.Control as ComboBox;
                    comboBox.DropDown += ComboBox_DropDown;
                    comboBox.DropDownHeight = 1;
                }
                ShowDropDownCheckList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("300");
            }

        }
        private int flag = 0; // Initialize flag as a class-level variable

        private void ComboBox_Click(object sender, EventArgs e)
        {
            try
            {
                flag++; // Increment flag on each click

                if (flag % 2 == 1)
                {
                    // Odd flag value: Show the checkedListBox
                    checkedListBox.Visible = true;
                }
                else
                {
                    // Even flag value: Hide the checkedListBox and perform load operation
                    checkedListBox.Visible = false;
                    Loaddata(); // Assuming load() is a method to perform necessary operations
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here (e.g., display a message box or log the error)
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {

                if (comboBox != null)
                {
                    //ShowDropDownCheckList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("313");
            }
        }




        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                        ProjectEstimationTool.Models.SoftwareCostingTest selectedSoftwareCost = selectedRow.DataBoundItem as ProjectEstimationTool.Models.SoftwareCostingTest;
                        DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Set the SoftwareList column value to null for the selected row
                            selectedRow.Cells["SoftwareList"].Value = null;
                            // Optionally, you can set other column values here if needed
                            p.Remove(selectedSoftwareCost);
                            // Save changes to the database
                            p.SaveChanges();
                        }
                        else
                        {
                            dataGridView1.AllowUserToDeleteRows = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("451");
            }
        }



        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow modifiedRow = dataGridView1.Rows[e.RowIndex];
                if (modifiedRow != null)
                {
                    var softwareCost = (ProjectEstimationTool.Models.SoftwareCostingTest)modifiedRow.DataBoundItem;
                    if (softwareCost != null)
                    {

                        if (softwareCost.SoftwareCostId == 0)
                        {
                            softwareCost.ProjectId = Form1.projectid;
                            var resid = (from t in p.ResourceCosting
                                         where t.ProjectId == Form1.projectid && t.Phase == softwareCost.Phase
                                         select t.ResourceCostingId).FirstOrDefault();
                            softwareCost.ResourceCostingId = resid;
                            var s = (from t in p.ResourceCosting
                                     where t.ProjectId == Form1.projectid && t.Phase == softwareCost.Phase
                                     select t).FirstOrDefault();
                            var sumres = (from t in p.ResourceCosting
                                          where t.ProjectId == Form1.projectid && t.Phase == softwareCost.Phase
                                          select t.ResCount).Sum();
                            var country = (from t in p.ResourceCosting
                                           where t.ProjectId == Form1.projectid && t.Phase == softwareCost.Phase
                                           select t.Country).FirstOrDefault();
                            var restype = (from t in p.ResourceCosting
                                           where t.ProjectId == Form1.projectid && t.Phase == softwareCost.Phase
                                           select t.ResType).FirstOrDefault();
                            var rollevel = (from t in p.ResourceCosting
                                            where t.ProjectId == Form1.projectid && t.Phase == softwareCost.Phase
                                            select t.RoleLevel).FirstOrDefault();

                            if (s != null)
                            {
                                softwareCost.DurationMm = (int)s.DurationMm;
                                softwareCost.ResCount = sumres;
                                softwareCost.Country = s.Country;
                                softwareCost.ResType = s.ResType;
                                softwareCost.RoleLevel = s.RoleLevel;
                            }
                            var softwareid = (from t in p.Software
                                              where t.ProjectId == Form1.projectid && t.SoftwareName == softwareCost.SoftwareName
                                              select t.SoftwareId).FirstOrDefault();

                        }
                        else
                        {

                            var resid = (from t in p.ResourceCosting
                                         where t.ProjectId == Form1.projectid && t.Phase == softwareCost.Phase
                                         select t.ResourceCostingId).FirstOrDefault();
                            softwareCost.ResourceCostingId = resid;
                            var s = (from t in p.ResourceCosting
                                     where t.ProjectId == Form1.projectid && t.Phase == softwareCost.Phase
                                     select t).FirstOrDefault();
                            if (s != null)
                            {
                                softwareCost.DurationMm = (int)s.DurationMm;
                                softwareCost.ResCount = (int)s.ResCount;
                                softwareCost.Country = s.Country;
                                softwareCost.ResType = s.ResType;
                                softwareCost.RoleLevel = s.RoleLevel;
                            }
                            var softwareid = (from t in p.Software
                                              where t.ProjectId == Form1.projectid && t.SoftwareName == softwareCost.SoftwareName
                                              select t).FirstOrDefault();
                            if (softwareid != null)
                            {

                                var hours = (from t in p.Productivity
                                             where t.ProjectId == Form1.projectid && t.ProductivityName == "Week"
                                             select t.Hours).FirstOrDefault();
                                softwareCost.SoftwareCost = (int)(s.ResCount * s.DurationMm * softwareid.MonthlyRate);
                            }
                        }
                        if (softwareCost.ResCount == 0)
                        {
                            MessageBox.Show("Resource Count should not be zero");
                            modifiedRow.Cells[e.ColumnIndex].Value = DBNull.Value;
                            return;
                        }
                        if (softwareCost.SoftwareCostId == 0)
                        {
                            p.SoftwareCostingTest.Add(softwareCost);

                        }
                        if (softwareCost.SoftwareCostId > 0 && softwareCost.Phase != null /*&& softwareCost.SoftwareName != null*/ /*&& softwareCost.SoftwareCost > 0*/)
                        {

                            p.SaveChanges();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("562");
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


    }
}

