using Microsoft.Data.SqlClient;
using ProjectEstimationTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectEstimationTool
{
    public partial class EffortTypeUserControl : UserControl
    {
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        private int Projectid;
        private EffortType effortdata;
        //private EffortType ActualEffort;
        //private EffortType Ba;
        //private EffortType Dev;
        //private EffortType Qa;
        private string Projectname;
        private int effortId;
        BindingList<EffortType> effortlist;

        static DataTable dt = new DataTable();

        public EffortTypeUserControl()
        {


            InitializeComponent();
            effortlist = new BindingList<EffortType>();
            RefreshData();
            dgv1.AutoGenerateColumns = true;
            dgv1.AllowUserToAddRows = true;
           // dgv1.CellEndEdit += dgv1_CellEndEdit;
          //  dgv1.CellValidating += dgv1_CellValidating;



        }

        public void RefreshData()
        {
            try
            {
                var res = db.EffortType.Where(t => t.ProjectId == Form1.projectid).ToList();
                effortlist.Clear();
                foreach (var item in res)
                {
                    effortlist.Add(item);
                }
                dgv1.DataSource = effortlist;
            }
            catch
            {
                MessageBox.Show("Error Loading while loading the data");
            }
        }
        private void UpdateEffortListFromGrid()
        {
            effortlist.Clear();
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                if (!row.IsNewRow)
                {
                    var effort = (EffortType)row.DataBoundItem;
                    effortlist.Add(effort);
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void EffortTypeUserControl_Load(object sender, EventArgs e)
        {


        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {



        }






        private bool EffortNameExists(string effortName, int currentEffortId)
        {
            var existingEffort = db.EffortType
         .FirstOrDefault(t =>
             t.EffortName.ToLower() == effortName.ToLower() &&
             t.ProjectId == Form1.projectid &&
             t.EffortId != currentEffortId);

            return existingEffort != null;
        }





        private void button6_Click(object sender, EventArgs e)
        {
            ProductivityUserControl prod = new ProductivityUserControl();
            this.Hide();
            this.Parent.Controls.Add(prod);
        }



        //private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.RowIndex >= 0)
        //        {
        //            DataGridViewRow modifiedRow = dgv1.Rows[e.RowIndex];
        //            var effortdata = (ProjectEstimationTool.Models.EffortType)modifiedRow.DataBoundItem;


        //            effortdata.EffortName = effortdata.EffortName.Trim();



        //            if (effortdata.EffortName.Contains("  ") || effortdata.EffortName.Contains("--") || effortdata.EffortName.Contains("- -"))
        //            {
        //                MessageBox.Show("Continuous spaces or hyphens are not allowed in the effort name.");
        //                modifiedRow.Cells[e.ColumnIndex].Value = DBNull.Value;
        //                return;
        //            }
        //            if (char.IsDigit(effortdata.EffortName.FirstOrDefault()))
        //            {
        //                MessageBox.Show("Effort name should not start with a number.");
        //                modifiedRow.Cells[e.ColumnIndex].Value = DBNull.Value;
        //                return;
        //            }
        //            if (effortdata.EffortName.Any(c => !char.IsLetterOrDigit(c) && c != '-' && c != ' '))
        //            {
        //                MessageBox.Show("Effort name should not contain special characters other than hyphen and space.");
        //                modifiedRow.Cells[e.ColumnIndex].Value = DBNull.Value;
        //                return;
        //            }

        //            effortdata.ProjectId = Form1.projectid;

        //            if (effortdata.EffortId == 0)
        //            {

        //                db.EffortType.Add(effortdata);

        //            }

        //            if ((effortdata.EffortId != 0 && effortdata.EffortName != null && effortdata.ActualEffort > 0) && (effortdata.Ba > 0 || effortdata.Dev > 0 || effortdata.Qa > 0))
        //            {
        //                if (effortdata.Ba + effortdata.Dev + effortdata.Qa != 100)
        //                {
        //                    MessageBox.Show("Sum of BA, Dev, QA values should not be equal to 100.");
        //                    effortdata.Qa = 0;
        //                    dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
        //                    return;
        //                }
        //            }


        //            if (effortdata.EffortName != null && effortdata.Ba + effortdata.Dev + effortdata.Qa == 100)
        //            {
        //                db.SaveChanges();
        //                MessageBox.Show("Data saved successfully.");
        //            }
        //            else if (effortdata.EffortName == null)
        //            {
        //                MessageBox.Show("Please enter effort name.");
        //                return;
        //            }

        //            else if (effortdata.EffortName != null && effortdata.ActualEffort > 0 && effortdata.Ba > 0 && effortdata.Dev > 0 && effortdata.Qa > 0)
        //            {
        //                MessageBox.Show("Sum of BA, Dev, QA values should not be equal to 100.");
        //                dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
        //                return;
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //=================================




        //private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.RowIndex >= 0)
        //        {
        //            DataGridViewRow modifiedRow = dgv1.Rows[e.RowIndex];
        //            var effortdata = (ProjectEstimationTool.Models.EffortType)modifiedRow.DataBoundItem;
        //            if (effortdata == null)
        //            {
        //              //  MessageBox.Show("Effort data is null.");
        //                return;
        //            }

        //            effortdata.EffortName = effortdata.EffortName.Trim();

        //            // Validate Effort Name
        //            if (string.IsNullOrWhiteSpace(effortdata.EffortName))
        //            {
        //                MessageBox.Show("Effort name cannot be empty.");
        //                return;
        //            }

        //            // Validate Effort Name Format
        //            if (effortdata.EffortName.Contains("  ") || effortdata.EffortName.Contains("--") || effortdata.EffortName.Contains("- -"))
        //            {
        //                MessageBox.Show("Continuous spaces or hyphens are not allowed in the effort name.");
        //                return;
        //            }

        //            // Validate Effort Name Start
        //            if (char.IsDigit(effortdata.EffortName.FirstOrDefault()))
        //            {
        //                MessageBox.Show("Effort name should not start with a number.");
        //                return;
        //            }

        //            // Validate Effort Name Special Characters
        //            if (effortdata.EffortName.Any(c => !char.IsLetterOrDigit(c) && c != '-' && c != ' '))
        //            {
        //                MessageBox.Show("Effort name should not contain special characters other than hyphen and space.");
        //                return;
        //            }

        //            // Other validations...

        //            if (effortdata.EffortId == 0)
        //            {
        //                db.EffortType.Add(effortdata);
        //            }

        //            if (dgv1.Columns[e.ColumnIndex].Name == "Qa") // Check if QA column is being edited
        //            {
        //                // Check if all BA, Dev, and QA values are entered before sum validation
        //                bool allValuesEntered = dgv1.Rows[e.RowIndex].Cells.Cast<DataGridViewCell>()
        //                                        .Any(cell => cell.OwningColumn.Name == "Ba" || cell.OwningColumn.Name == "Dev" || cell.OwningColumn.Name == "Qa")
        //                                        && dgv1.Rows[e.RowIndex].Cells["Ba"].Value != null
        //                                        && dgv1.Rows[e.RowIndex].Cells["Dev"].Value != null
        //                                        && dgv1.Rows[e.RowIndex].Cells["Qa"].Value != null;

        //                if (allValuesEntered && (effortdata.EffortName != null && effortdata.ActualEffort > 0))
        //                {
        //                    int ba = Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells["Ba"].Value);
        //                    int dev = Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells["Dev"].Value);
        //                    int qa = Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells["Qa"].Value);

        //                    if (ba + dev + qa != 100)
        //                    {
        //                        MessageBox.Show("Sum of BA, Dev, QA values should be equal to 100.");
        //                        // Clear the last entered value
        //                        // modifiedRow.Cells[e.ColumnIndex].Value = null;
        //                        //   dgv1.Rows[e.RowIndex].Cells["Qa"].Value = DBNull.Value;
        //                        // int qaColumnIndex = dgv1.Columns["Qa"].Index;
        //                        dgv1.Rows[e.RowIndex].Cells["Ba"].Value = null;
        //                        dgv1.Rows[e.RowIndex].Cells["Dev"].Value = null;
        //                        dgv1.Rows[e.RowIndex].Cells["Qa"].Value = null;
        //                        // Clear the last entered value in the "Qa" column
        //                        //  dgv1.Rows[e.RowIndex].Cells[qaColumnIndex].Value = null;

        //                        return;
        //                    }
        //                }
        //            }
        //            effortdata.ProjectId = Form1.projectid;

        //            if (effortdata.EffortId == 0)
        //            {

        //                db.EffortType.Add(effortdata);

        //            }


        //            // If the sum is correct or other conditions are met, save the data
        //            if (effortdata.EffortId==0 && effortdata.EffortName != null && effortdata.Ba + effortdata.Dev + effortdata.Qa == 100)
        //            {
        //                db.SaveChanges();
        //                MessageBox.Show("Data saved successfully.");
        //                dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
        //            }
        //            else if (effortdata.EffortName == null)
        //            {
        //                MessageBox.Show("Please enter effort name.");
        //                return;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception
        //        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {

                    DataGridViewRow modifiedRow = dgv1.Rows[e.RowIndex];
                    var effortdata = (ProjectEstimationTool.Models.EffortType)modifiedRow.DataBoundItem;
                    if (effortdata == null)
                    {
                        //  MessageBox.Show("Effort data is null.");
                        return;
                    }

                    effortdata.EffortName = effortdata.EffortName.Trim();

                    // Validate Effort Name
                    if (string.IsNullOrWhiteSpace(effortdata.EffortName))
                    {
                        MessageBox.Show("Effort name cannot be empty.");
                        
                        return;
                     
                    }

                    // Validate Effort Name Format
                    if (effortdata.EffortName.Contains("  ") || effortdata.EffortName.Contains("--") || effortdata.EffortName.Contains("- -"))
                    {
                        MessageBox.Show("Continuous spaces or hyphens are not allowed in the effort name.");
                        return;
                    }

                    // Validate Effort Name Start
                    if (char.IsDigit(effortdata.EffortName.FirstOrDefault()))
                    {
                        MessageBox.Show("Effort name should not start with a number.");
                        return;
                    }

                    // Validate Effort Name Special Characters
                    if (effortdata.EffortName.Any(c => !char.IsLetterOrDigit(c) && c != '-' && c != ' '))
                    {
                        MessageBox.Show("Effort name should not contain special characters other than hyphen and space.");
                        return;
                    }

                    // Other validations...

                    if (effortdata.EffortId == 0)
                    {
                        db.EffortType.Add(effortdata);
                    }

                    if (dgv1.Columns[e.ColumnIndex].Name == "Qa") // Check if QA column is being edited
                    {
                        // Check if all BA, Dev, and QA values are entered before sum validation
                        bool allValuesEntered = dgv1.Rows[e.RowIndex].Cells.Cast<DataGridViewCell>()
                                                .Any(cell => cell.OwningColumn.Name == "Ba" || cell.OwningColumn.Name == "Dev" || cell.OwningColumn.Name == "Qa")
                                                && dgv1.Rows[e.RowIndex].Cells["Ba"].Value != null
                                                && dgv1.Rows[e.RowIndex].Cells["Dev"].Value != null
                                                && dgv1.Rows[e.RowIndex].Cells["Qa"].Value != null;

                        if (allValuesEntered && (effortdata.EffortName != null && effortdata.ActualEffort > 0))
                        {
                            int ba = Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells["Ba"].Value);
                            int dev = Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells["Dev"].Value);
                            int qa = Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells["Qa"].Value);

                            if (ba + dev + qa != 100)
                            {
                                MessageBox.Show("Sum of BA, Dev, QA values should be equal to 100.");
                                // Clear the last entered value
                                dgv1.Rows[e.RowIndex].Cells["Ba"].Value = null;
                                dgv1.Rows[e.RowIndex].Cells["Dev"].Value = null;
                                dgv1.Rows[e.RowIndex].Cells["Qa"].Value = null;
                                // Disable the next cell for editing
                                // Disable editing for the next row
                                for (int i = 0; i < dgv1.Rows.Count; i++)
                                {
                                    if (i < e.RowIndex)
                                    {
                                        dgv1.Rows[i].ReadOnly = false;
                                    }
                                    else if(i == e.RowIndex)
                                    {
                                        dgv1.Rows[i].ReadOnly=false;
                                    }
                                    else
                                    {
                                        dgv1.Rows[i].ReadOnly = true;
                                    }
                                }
                              

                            }
                        }
                    }
                    effortdata.ProjectId = Form1.projectid;

                    if (effortdata.EffortId == 0)
                    {
                        db.EffortType.Add(effortdata);
                    }

                    // If the sum is correct or other conditions are met, save the data
                    if (effortdata.EffortId == 0 && effortdata.EffortName != null && effortdata.Ba + effortdata.Dev + effortdata.Qa == 100)
                    {
                        db.SaveChanges();
                        MessageBox.Show("Data saved successfully.");
                        dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
                    }
                    else if (effortdata.EffortName == null)
                    {
                        MessageBox.Show("Please enter effort name.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //private void dgv1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    try
        //    {
        //        if (e.RowIndex > 0 && e.ColumnIndex == 2) // Check only for the Effort Type column
        //        {
        //            string inputValue = e.FormattedValue.ToString().Trim();

        //            if (string.IsNullOrWhiteSpace(inputValue))
        //            {
        //                // Handle empty cell
        //                dgv1.Rows[e.RowIndex].ErrorText = "Cell value cannot be empty.";
        //                e.Cancel = true;
        //                return;
        //            }

        //            // Check for duplicate data only in the Effort Type column
        //            for (int i = 0; i < dgv1.Rows.Count - 1; i++)
        //            {
        //                if (i != e.RowIndex) // Exclude the current row
        //                {
        //                    if (dgv1.Rows[i].Cells[2].Value != null &&
        //                        dgv1.Rows[i].Cells[2].Value.ToString() == inputValue)
        //                    {
        //                        MessageBox.Show("Duplicate data is not allowed in the Effort Type column.");
        //                        dgv1.Rows[e.RowIndex].Cells[2].Value = ""; // Clear the cell value
        //                        e.Cancel = true;
        //                        return;
        //                    }
        //                }
        //            }
        //        }
        //        dgv1.Rows[e.RowIndex].ErrorText = "";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //}



        private void dgv1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (dgv1.SelectedRows.Count > 0)
                    {
                        var selectedRow = dgv1.SelectedRows[0];
                        var effortdata = (ProjectEstimationTool.Models.EffortType)selectedRow.DataBoundItem;
                        var effortId = effortdata.EffortId;

                        DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            var effortToDelete = db.EffortType.FirstOrDefault(e => e.EffortId == effortId);

                            if (effortToDelete != null)
                            {
                                db.EffortType.Remove(effortToDelete);
                                db.SaveChanges();
                                RefreshData();
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

     private void dgv1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
{
    try
    {
        if (e.RowIndex >= 0)
        {
            if (e.ColumnIndex == 2) // Check for the Effort Type column
            {
                string inputValue = e.FormattedValue.ToString().Trim();

                if (string.IsNullOrWhiteSpace(inputValue))
                {
                    // Handle empty cell
                    dgv1.Rows[e.RowIndex].ErrorText = "Cell value cannot be empty.";
                    e.Cancel = true;
                    return;
                }

                // Check for duplicate data only in the Effort Type column
                foreach (DataGridViewRow row in dgv1.Rows)
                {
                    if (row.Index != e.RowIndex && row.Cells[2].Value != null &&
                        row.Cells[2].Value.ToString().Equals(inputValue, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Duplicate data is not allowed in the Effort Type column.");
                        e.Cancel = true;
                        return;
                    }
                }
            }
            // Rest of your validation logic...
        }
        dgv1.Rows[e.RowIndex].ErrorText = ""; // Clear error text
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}





        private void dgv1_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

