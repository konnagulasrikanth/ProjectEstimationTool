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
    public partial class SoftwareListControl : UserControl
    {
        private bool comboBoxDropDownHandlerAttached = false;

        ProjectEstimationToolMasterContext p;
        private DataGridView dataGridView1;
        private ComboBox comboBox;
        private CheckedListBox checkedListBox;
        private List<object> selectedItemsList;
        private bool isDropDownVisible;
        public SoftwareListControl()
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

            //UpdateSoftwareListColumnHeaderText();

        }

        private void SoftwareListControl_Load(object sender, EventArgs e)
        {
            try
            {
                load();
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
                dataGridView1.BackgroundColor= Color.White;
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
                DataGridViewComboBoxColumn phaseColumn = new DataGridViewComboBoxColumn();
                phaseColumn.Name = "PhaseColumn";
                phaseColumn.DataPropertyName = "Phase";
                phaseColumn.HeaderText = "Phase";
                phaseColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                phaseColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                phaseColumn.FlatStyle = FlatStyle.Popup;
                DataGridViewTextBoxColumn resCountColumn = new DataGridViewTextBoxColumn();
                resCountColumn.Name = "RescountColumn";
                resCountColumn.DataPropertyName = "Rescount";
                resCountColumn.HeaderText = "Resource Count";
                resCountColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DataGridViewTextBoxColumn weeksColumn = new DataGridViewTextBoxColumn();
                weeksColumn.Name = "weeksColumn";
                weeksColumn.DataPropertyName = "DurationMM";
                weeksColumn.HeaderText = "Weeks";
                weeksColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DataGridViewTextBoxColumn softwareCostColumn = new DataGridViewTextBoxColumn();
                softwareCostColumn.Name = "SoftwareCostColumn";
                softwareCostColumn.DataPropertyName = "SoftwareCost";
                softwareCostColumn.HeaderText = "Software Cost";
                softwareCostColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                
             
                dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                  softidColumn,
                  projectIdColumn,
                  resCostIDColumn,
                  phaseColumn,
                  resCountColumn,
                   softwareListColumn,
                   weeksColumn,
                   softwareCostColumn
                      });
                // Set column header style
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Palatino Linotype", 11, FontStyle.Bold);
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
                        var resourceCostingData = p.SoftwareCosting
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
      
        private List<object> GetDistinctSoftwareList()
        {

            var list = (from t in p.Software
                        where t.ProjectId == Form1.projectid
                        select t.SoftwareName).Distinct().ToList();

            return list.Cast<object>().ToList();

        }
    

        private int CalculateSoftwareCost(SoftwareCosting softwareCost)
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
                    ProjectEstimationTool.Models.SoftwareCosting selectedSoftwareCost = selectedRow.DataBoundItem as ProjectEstimationTool.Models.SoftwareCosting;
                    var software = p.Software.FirstOrDefault(s => s.SoftwareName == trimmedSoftwareItem);
                    var s = (from t in p.Timeline
                             where t.ProjectId == Form1.projectid && t.Phase == selectedSoftwareCost.Phase
                             select t).FirstOrDefault();
                    var hours = (from t in p.Productivity
                                 where t.ProjectId == Form1.projectid && t.ProductivityName == "Week"
                                 select t.Hours).FirstOrDefault();
                    if (software != null && s != null)
                    {
                        totalCost += (int)(s.ResReq * s.Mm * software.MonthlyRate);
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
                ProjectEstimationTool.Models.SoftwareCosting selectedSoftwareCost = selectedRow.DataBoundItem as ProjectEstimationTool.Models.SoftwareCosting;
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




        public void load()
        {
            try
            {
                if (p != null)
                {
                    var res = from t in p.SoftwareCosting
                              where t.ProjectId == Form1.projectid
                              select t;
                    List<ProjectEstimationTool.Models.SoftwareCosting> softwareCosts = res.ToList();
                    BindingList<ProjectEstimationTool.Models.SoftwareCosting> softwareCostList = new BindingList<ProjectEstimationTool.Models.SoftwareCosting>(softwareCosts);
                    dataGridView1.DataSource = softwareCostList;
                    populatecomboboxes();
                    PopulateSoftwareListColumn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("377");
            }

        }


        public void populatecomboboxes()
        {
            try
            {
                if (p != null && p.Timeline != null)
                {
                    var phase = (from t in p.Timeline
                                 where t.ProjectId == Form1.projectid && !t.Phase.Contains("Kick")
                                 select t.Phase).Distinct();
                    DataGridViewComboBoxColumn comboColumn = dataGridView1.Columns["PhaseColumn"] as DataGridViewComboBoxColumn;

                    
                    if (comboColumn != null)
                    {
                        comboColumn.DataSource = phase.ToList();
                    }
                    else
                    {
                        MessageBox.Show("DataGridViewComboBoxColumn named 'PhaseColumn' not found.");
                    }
                }
                else
                {
                    MessageBox.Show("ProjectEstimationToolDBContext or Timeline data is null.");
                }
         
            }
            catch (Exception ex)
            {
                MessageBox.Show("417");
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
                    var distinctSoftwareList = p.SoftwareCosting
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
                        ProjectEstimationTool.Models.SoftwareCosting selectedSoftwareCost = selectedRow.DataBoundItem as ProjectEstimationTool.Models.SoftwareCosting;
                        DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            var softwareCostToDelete = p.SoftwareCosting.FirstOrDefault(t => t.SoftwareCostId == selectedSoftwareCost.SoftwareCostId);
                            if (softwareCostToDelete != null)
                            {
                                p.SoftwareCosting.Remove(softwareCostToDelete);
                                p.SaveChanges();
                            }
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
        private bool IsCombinationExists(ProjectEstimationTool.Models.SoftwareCosting softwareCost)
        {

            var existingCombination = p.SoftwareCosting
                .FirstOrDefault(t => t.ProjectId == softwareCost.ProjectId &&
                                     t.Phase == softwareCost.Phase &&
                                       t.SoftwareName == softwareCost.SoftwareName);

            return existingCombination != null;

        }
        private bool editcombination(ProjectEstimationTool.Models.SoftwareCosting softwareCost)
        {
            var existingCombination = p.SoftwareCosting
                    .FirstOrDefault(t => t.ProjectId == softwareCost.ProjectId &&
                                          t.SoftwareCostId != softwareCost.SoftwareCostId &&
                                          t.Phase == softwareCost.Phase &&
                                           t.SoftwareName == softwareCost.SoftwareName);
            return existingCombination != null;

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow modifiedRow = dataGridView1.Rows[e.RowIndex];
                if (modifiedRow != null)
                {
                    var softwareCost = (ProjectEstimationTool.Models.SoftwareCosting)modifiedRow.DataBoundItem;
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
                            var sumres= (from t in p.ResourceCosting
                                         where t.ProjectId == Form1.projectid && t.Phase == softwareCost.Phase
                                         select t.ResCount).Sum();
                            if (s != null)
                            {
                                softwareCost.DurationMm = (int)s.DurationMm;
                                softwareCost.ResCount = sumres;
                            }
                            var softwareid = (from t in p.Software
                                              where t.ProjectId == Form1.projectid && t.SoftwareName == softwareCost.SoftwareName
                                              select t.SoftwareId).FirstOrDefault();
                            if (IsCombinationExists(softwareCost))
                            {
                                MessageBox.Show("This combination already exists. Please enter a unique combination.");
                                modifiedRow.Cells[e.ColumnIndex].Value = DBNull.Value;
                                return;
                            }
                        }
                        else
                        {
                            //UpdateDatabaseWithSelectedItems();
                            if (editcombination(softwareCost))
                            {
                                MessageBox.Show("This combination already exists. Please enter a unique combination.");
                                modifiedRow.Cells[e.ColumnIndex].Value = DBNull.Value;
                                return;
                            }
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
                            p.SoftwareCosting.Add(softwareCost);

                        }
                        if (softwareCost.SoftwareCostId > 0 && softwareCost.Phase != null && softwareCost.SoftwareName != null && softwareCost.SoftwareCost > 0)
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

        private T FindParent<T>(Control control) where T : Control
        {
            Control parent = control.Parent;
            while (parent != null)
            {
                if (parent is T typedParent)
                {
                    return typedParent;
                }
                parent = parent.Parent;
            }
            return null;
        }
    }
}
