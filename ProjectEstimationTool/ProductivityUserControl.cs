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
        public ProductivityUserControl()
        {
            InitializeComponent();
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadProductivityData()
        {
       
            label4.Visible = false; 
            

            var res = from t in db.Productivity
                      where t.ProjectId == Form1.projectid
                      select t;
            dataGridView1.DataSource = res.ToList();

        }

        private void ProductivityUserControl_Load(object sender, EventArgs e)
        {
            LoadProductivityData();
            panel1.Visible = false;

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
          
            if (dataGridView1.SelectedRows.Count > 0)
            {

                p = dataGridView1.SelectedRows[0].DataBoundItem as Productivity;
                if (p != null)
                {
                    textBox1.Text = p.Hours.ToString();
                    workinghours = p.ProductivityName;
                }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private bool IsValidHours(string input)
        {
            // Check if the input is a valid integer
            return int.TryParse(input, out _);
        }
        private void button1_Click(object sender, EventArgs e)
        {
           

            try
            {
                // Validate that Hours is a valid integer
                if (!IsValidHours(textBox1.Text))
                {
                    label4.ForeColor = Color.Red;
                    label4.Text = "Error: Please enter a valid value for hours.";
                    return;
                }

                // Validate that the entered hours are not negative
                int enteredHours = int.Parse(textBox1.Text);
                if (enteredHours < 0)
                {
                    label4.ForeColor = Color.Red;

                    label4.Text = "Please enter a non-negative value for hours.";
                    return;
                }

                switch (workinghours)
                {
                    case "Day":
                        if (enteredHours < 1 || enteredHours > 24)
                        {
                            label4.ForeColor = Color.Red;
                            label4.Text = "Hours for a day should be between 1 to 24.";
                            return;
                        }
                        break;
                    case "Week":
                        if (enteredHours < 1 || enteredHours > 140)
                        {
                            label4.ForeColor = Color.Red;
                            label4.Text = "Hours for a week should be between 1 to 140.";
                            return;
                        }
                        break;
                    case "Month":
                        if (enteredHours < 1 || enteredHours > 480)
                        {
                            label4.ForeColor = Color.Red;
                            label4.Text = "Hours for a month should be between 1 to 480.";
                            return;
                        }
                        break;
                    default:
                        break;
                }


                label4.ForeColor = Color.Black; 

                label4.Text = ""; 
                panel1.Visible = false;

                p.Hours = enteredHours;
                db.SaveChanges();
                // Update Timeline based on Productivity
                UpdateTimeline(Form1.projectid);

                LoadProductivityData();
            
            }

            catch (Exception ex)
            {
                label4.ForeColor = Color.Red;
                label4.Text = $"Error: {ex.Message}";
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
                        .Where(p => p.ProductivityName == "Month" && p.ProjectId == projectID)
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

      

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            label4.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = true;
            // Validate that the entered text is a valid integer
            if (!IsValidHours(textBox1.Text))
            {
                label4.ForeColor = Color.Red;

                label4.Text = "Please enter a valid value for hours.";
            }
            else
            {
                label4.ForeColor = Color.Black; // Reset text color to default

                label4.Text = ""; // Clear the error message
            }
        }
    }
}
