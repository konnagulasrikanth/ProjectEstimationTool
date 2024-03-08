using Microsoft.Data.SqlClient;
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
    public partial class SoftwarerateUserControl : UserControl
    {
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        private Software s;
        static DataTable dt = new DataTable();

        public DataGridView MyDataGridView
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
        }
        static string ConnectionString = @"Data Source=ICS-LT-64146D3\SQLEXPRESS;Initial Catalog=ProjectEstimationToolMaster;Integrated Security=True;TrustServerCertificate=True";



        public SoftwarerateUserControl()
        {
            InitializeComponent();
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }



        private void SoftwarerateUserControl_Load(object sender, EventArgs e)
        {
            LoadSoftwareData();
     

            panel1.Visible = false;
            panel2.Visible = false;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadSoftwareData()
        {
            var res = from t in db.Software
                      where t.ProjectId == Form1.projectid
                      select t;
            dataGridView1.DataSource = res.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue;
            panel1.Visible = true;
            panel2.Visible = false;


        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                s = dataGridView1.SelectedRows[0].DataBoundItem as Software;
                if (s != null)
                {
                    textBox4.Text = s.SoftwareName;
                    textBox3.Text = s.MonthlyRate.ToString();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    if (selectedRow.DataBoundItem is Software selectedResource)
                    {
                        int resourceId = selectedResource.SoftwareId;

                        var resourceToDelete = db.Software.FirstOrDefault(r => r.SoftwareId == resourceId);

                        if (resourceToDelete != null)
                        {
                            db.Software.Remove(resourceToDelete);
                            db.SaveChanges();
                            LoadSoftwareData();
                        }
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSoftwareInput())
                {
                    var newSoftware = new Software
                    {
                        ProjectId = Form1.projectid,
                        SoftwareName = textBox1.Text,
                        MonthlyRate = int.Parse(textBox2.Text),
                    };

                    db.Software.Add(newSoftware);
                    db.SaveChanges();
                    LoadSoftwareData();
                    button1.BackColor = Color.RosyBrown;

                    panel1.Visible = false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid numeric value for Monthly Rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate that MonthlyRate is not null or empty
                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Please enter a valid Monthly Rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!textBox4.Text.All(char.IsLetter))
                {
                    MessageBox.Show("Error: Software Name should only contain alphabets.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return ;
                }

                // Validate that MonthlyRate is a valid numeric value
                if (!int.TryParse(textBox3.Text, out int monthlyRate))
                {
                    MessageBox.Show("Please enter a valid numeric value for Monthly Rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate that SoftwareName is not null or empty
                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    MessageBox.Show("Please enter a valid Software Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate that SoftwareName is not duplicated
                if (db.Software.Any(s => s.SoftwareName == textBox4.Text && s.ProjectId == Form1.projectid && s.SoftwareId != s.SoftwareId))
                {
                    MessageBox.Show("Software with the same name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Your existing code to update the software details
                s.SoftwareName = textBox4.Text;
                s.MonthlyRate = monthlyRate;
                db.SaveChanges();
                LoadSoftwareData();
                panel2.Visible = false;
                panel1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.RosyBrown;

            panel1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ResourceRateUserControl rc = new ResourceRateUserControl();
            this.Hide();
            this.Parent.Controls.Add(rc);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Scope sc = new Scope();
            this.Hide();
            this.Parent.Controls.Add(sc);
        }
        private bool ValidateSoftwareInput()
        {
            // Validate that all the required fields are filled
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!textBox1.Text.All(char.IsLetter))
            {
                MessageBox.Show("Error: Software Name should only contain alphabets.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(textBox2.Text, out _))
            {
                MessageBox.Show("Please enter a valid numeric value for Monthly Rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate that the software name is not duplicated
            if (db.Software.Any(s => s.SoftwareName == textBox1.Text && s.ProjectId == Form1.projectid))
            {
                MessageBox.Show("Software with the same name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}

