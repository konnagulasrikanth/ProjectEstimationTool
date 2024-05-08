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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectEstimationTool
{
    public partial class ProductivityUserControl : UserControl
    {
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        private Productivity p;
        private string workinghours;
        BindingList<Productivity> product;
        public ProductivityUserControl()
        {
            InitializeComponent();
            product = new BindingList<Productivity>();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            LoadProductivityData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadProductivityData()
        {

            try
            {
                var prod = db.Productivity.Where(t => t.ProjectId == Form1.projectid).ToList();
                product.Clear();
                foreach (var type in prod)
                {
                    product.Add(type);
                }
                dataGridView1.DataSource = product;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured to load the data");
            }



        }

        private void ProductivityUserControl_Load(object sender, EventArgs e)
        {

        }

        private bool IsValidHours(string input)
        {
            // Check if the input is a valid integer
            return int.TryParse(input, out _);
        }

        private void productivityrelation(string type, int duration)
        {
            try
            {
                var weekhours = db.Productivity.Where(p => p.ProjectId == Form1.projectid).ToList();

                foreach (var item in weekhours)
                {
                    switch (type)
                    {
                        case "Day":
                            if (item.ProductivityName == "Month")
                            {
                                item.Hours = duration * 20;
                            }
                            else if (item.ProductivityName == "Week")
                            {
                                item.Hours = duration * 5;
                            }
                            break;

                        case "Week":
                            if (item.ProductivityName == "Day")
                            {
                                item.Hours = duration / 5;
                            }
                            else if (item.ProductivityName == "Month")
                            {
                                item.Hours = duration * 4;
                            }
                            break;

                        default: // Assuming the default case is "Month"
                            if (item.ProductivityName == "Day")
                            {
                                item.Hours = duration / 20;
                            }
                            else if (item.ProductivityName == "Week")
                            {
                                item.Hours = duration / 4;
                            }
                            break;
                    }
                }

                db.SaveChanges();
                LoadProductivityData();
                UpdateTimeline(Form1.projectid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateTimeline(int projectID) //this function updates the monthly changed hours to timeline
        {
            var uptime = db.Timeline.Where(t => t.ProjectId == projectID).ToList();
            if (uptime != null)
            {
                foreach (var u in uptime)
                {
                    int monthlyHours = db.Productivity
                        .Where(p => p.ProductivityName == "Week" && p.ProjectId == projectID)
                        .Select(p => p.Hours)
                        .FirstOrDefault();

                    bool defaultvalues = u.Phase.Contains("Kickoff/Demo") || u.Phase.Contains("Requirements") || u.Phase.Contains("Build&Design") || u.Phase.Contains("QA");

                    if (!defaultvalues && monthlyHours != null)
                    {
                        u.EffHrs = u.ResReq * u.Mm * monthlyHours;
                        db.SaveChanges();
                    }
                }
            }
        }







        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EffortTypeUserControl effor = new EffortTypeUserControl();
            this.Hide();
            this.Parent.Controls.Add(effor);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FunctionalUserControl fc = new FunctionalUserControl();
            this.Hide();
            this.Parent.Controls.Add(fc);
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow editedRow = dataGridView1.Rows[e.RowIndex];

                // Ensure the edited row is not a new row
                if (!editedRow.IsNewRow)
                {
                    // Get the edited Productivity object
                    Productivity editedProductivity = editedRow.DataBoundItem as Productivity;

                    if (editedProductivity != null)
                    {
                        // Validate the edited value
                        if (!IsValidHours(editedRow.Cells["Hours"].Value.ToString()))
                        {
                            MessageBox.Show("Please enter a valid value for hours.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LoadProductivityData();
                            return;
                        }

                        // Validate that the entered hours are not negative
                        int enteredHours = int.Parse(editedRow.Cells["Hours"].Value.ToString());
                        if (enteredHours < 0)
                        {
                            MessageBox.Show("Please enter a non-negative value for hours.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LoadProductivityData();
                            return;
                        }

                        // Update the corresponding Productivity record
                        editedProductivity.Hours = enteredHours;
                        productivityrelation(editedProductivity.ProductivityName, enteredHours);
                        db.SaveChanges();

                        // Update Timeline based on Productivity
                        UpdateTimeline(Form1.projectid);

                        LoadProductivityData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadProductivityData();
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (e.RowIndex > 0 && (e.ColumnIndex == 3))
                {
                    string inputValue = e.FormattedValue.ToString();

                    if (string.IsNullOrWhiteSpace(inputValue))
                    {
                        // Handle empty cell
                        dataGridView1.Rows[e.RowIndex].ErrorText = "Cell value cannot be empty.";
                        e.Cancel = true;
                        return;
                    }

                    if (!int.TryParse(inputValue, out int value) || value < 0)
                    {
                        MessageBox.Show("Please enter a non-negative integer value.");
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ""; // Clear the cell value
                        return;
                    }
                }
                dataGridView1.Rows[e.RowIndex].ErrorText = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
