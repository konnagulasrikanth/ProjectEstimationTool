using Microsoft.Data.SqlClient;
using ProjectEstimationTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
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
        private string Projectname;
        private int effortId;
 
        static DataTable dt = new DataTable();
        public DataGridView MyDataGridView
        {
            get { return dgv1; }
            set { dgv1 = value; }
        }



        static string ConnectionString = @"Data Source=ICS-LT-64146D3\SQLEXPRESS;Initial Catalog=ProjectEstimationToolMaster;Integrated Security=True;TrustServerCertificate=True";
        public void UpdateProjectLabel(string projectname, int projectid)
        {
            Projectid = projectid;
            Projectname = projectname;
            RefreshData();
        }
        public void RefreshData()
        {
            var res = from t in db.EffortType
                      where t.ProjectId == Form1.projectid
                      select t;
            dgv1.DataSource = res.ToList();
        }
        public EffortTypeUserControl()
        {


            InitializeComponent();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue;
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            if (dgv1.SelectedRows.Count > 0)
            {
                effortdata = dgv1.SelectedRows[0].DataBoundItem as EffortType;

                if (effortdata != null)
                {
                    textBox12.Text = effortdata.EffortName;

                    textBox11.Text = effortdata.ActualEffort.ToString();
                    textBox10.Text = effortdata.Ba.ToString();
                    textBox9.Text = effortdata.Qa.ToString();
                    textBox8.Text = effortdata.Dev.ToString();
                    textBox7.Text = effortdata.Rules.ToString();

                }
            }

        }

        private void EffortTypeUserControl_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            RefreshData();

        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {



        }
        private void dgv1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (effortId != 0)
            {
                EffortType EffortTypeToDelete = db.EffortType.FirstOrDefault(fs => fs.EffortId == effortId);

                if (EffortTypeToDelete != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        db.EffortType.Remove(EffortTypeToDelete);
                        db.SaveChanges();
                        RefreshData();
                    }
                    // No need for an else block if you don't have specific actions for DialogResult.No
                }
            }
        }

        private void editToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {

        }
        // Helper method to check if the effort name already exists
        private bool EffortNameExists(string effortName)
        {
            var existingEffort = db.EffortType.FirstOrDefault(t => t.EffortName == effortName && t.ProjectId == Form1.projectid);
            return existingEffort != null;
        }

        private void button3_Click(object sender, EventArgs e)  //add effort type code
        {
            try
            {
                // Trim leading and trailing whitespaces from the input
                string effortName = textBox1.Text.Trim();
                string actualEffortStr = textBox2.Text.Trim();
                string baPercentageStr = textBox3.Text.Trim();
                string qaPercentageStr = textBox4.Text.Trim();
                string devPercentageStr = textBox5.Text.Trim();
                string rulesStr = textBox6.Text.Trim();

                // Check if any of the fields are empty
                if (string.IsNullOrWhiteSpace(effortName) ||
                    string.IsNullOrWhiteSpace(actualEffortStr) ||
                    string.IsNullOrWhiteSpace(baPercentageStr) ||
                    string.IsNullOrWhiteSpace(qaPercentageStr) ||
                    string.IsNullOrWhiteSpace(devPercentageStr) ||
                    string.IsNullOrWhiteSpace(rulesStr))
                {
                    MessageBox.Show("Error: All fields must be entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the input contains only numeric characters for numeric fields
                if (!int.TryParse(actualEffortStr, out int actualEffort) ||
                    !int.TryParse(baPercentageStr, out int baPercentage) ||
                    !int.TryParse(qaPercentageStr, out int qaPercentage) ||
                    !int.TryParse(devPercentageStr, out int devPercentage) ||
                    !int.TryParse(rulesStr, out int rules))
                {
                    MessageBox.Show("Error: Numeric fields must contain valid numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the effort name contains only alphabets
                if (!effortName.All(char.IsLetter))
                {
                    MessageBox.Show("Error: Effort Name should only contain alphabets.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the individual percentages for BA, QA, and Dev exceed 100%
                if (baPercentage + qaPercentage + devPercentage > 100)
                {
                    MessageBox.Show("Error: The sum of BA, QA, and Dev percentages should not exceed 100%.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the effort name already exists (case-insensitive)
                if (EffortNameExists(effortName))
                {
                    MessageBox.Show("Error: Effort Type with the same name already exists. Choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // Create a new EffortType instance
                EffortType newEffortType = new EffortType
                {
                    EffortName = effortName,
                    ActualEffort = actualEffort,
                    Ba = baPercentage,
                    Qa = qaPercentage,
                    Dev = devPercentage,
                    Rules = rules,
                    ProjectId = Form1.projectid
                };

                db.EffortType.Add(newEffortType);
                db.SaveChanges();
                RefreshData();
                // Clear the data in textboxes
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                panel1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e) //edit button for updation
        {
            try
            {
                string effortName = textBox12.Text.Trim();
                string actualEffortStr = textBox11.Text.Trim();
                string baPercentageStr = textBox10.Text.Trim();
                string qaPercentageStr = textBox9.Text.Trim();
                string devPercentageStr = textBox8.Text.Trim();
                string rulesStr = textBox7.Text.Trim();

                // Check if any of the fields are empty
                if (string.IsNullOrWhiteSpace(effortName) ||
                    string.IsNullOrWhiteSpace(actualEffortStr) ||
                    string.IsNullOrWhiteSpace(baPercentageStr) ||
                    string.IsNullOrWhiteSpace(qaPercentageStr) ||
                    string.IsNullOrWhiteSpace(devPercentageStr) ||
                    string.IsNullOrWhiteSpace(rulesStr))
                {
                    MessageBox.Show("Error: All fields must be entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the input contains only numeric characters for numeric fields
                if (!int.TryParse(actualEffortStr, out int actualEffort) ||
                    !int.TryParse(baPercentageStr, out int baPercentage) ||
                    !int.TryParse(qaPercentageStr, out int qaPercentage) ||
                    !int.TryParse(devPercentageStr, out int devPercentage) ||
                    !int.TryParse(rulesStr, out int rules))
                {
                    MessageBox.Show("Error: Numeric fields must contain valid numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the individual percentages for BA, QA, and Dev exceed 100%
                if (baPercentage + qaPercentage + devPercentage > 100)
                {
                    MessageBox.Show("Error: The sum of BA, QA, and Dev percentages should equal 100%.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the existing EffortType with the new values
                effortdata.EffortName = effortName;
                effortdata.ActualEffort = actualEffort;
                effortdata.Ba = baPercentage;
                effortdata.Qa = qaPercentage;
                effortdata.Dev = devPercentage;
                effortdata.Rules = rules;

                db.SaveChanges();
                RefreshData();
                panel2.Visible = false;
                MessageBox.Show("Effort Type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProductivityUserControl prod = new ProductivityUserControl();
            this.Hide();
            this.Parent.Controls.Add(prod);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}

