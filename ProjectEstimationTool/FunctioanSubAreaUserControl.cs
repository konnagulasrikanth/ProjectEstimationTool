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

namespace ProjectEstimationTool
{
    public partial class FunctioanSubAreaUserControl : UserControl
    {

        static DataTable dt = new DataTable();
        private string fsa;
        private int fsaid;
        private string functionalSubAreaName;
        private FunctionalSubArea selecteddata;
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        static string ConnectionString = @"Data Source=ICS-LT-64146D3\SQLEXPRESS;Initial Catalog=ProjectEstimationToolMaster;Integrated Security=True;TrustServerCertificate=True";
        public void RefreshData()
        {
            var res = from t in db.FunctionalSubArea
                      where t.ProjectId == Form1.projectid
                      select t;
            dataGridView1.DataSource = res.ToList();


        }
        public FunctioanSubAreaUserControl()
        {
            InitializeComponent();
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }

        private void FunctioanSubAreaUserControl_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            RefreshData();
            //dataGridView1.EnableHeadersVisualStyles = false;
            //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }
        private void dgv1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {


        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {


            panel1.Visible = true;
            panel2.Visible = false;
            if (dataGridView1.SelectedRows.Count > 0)
            {

                selecteddata = dataGridView1.SelectedRows[0].DataBoundItem as FunctionalSubArea;
                if (selecteddata != null)
                {
                    textBox1.Text = selecteddata.FunctionalSubAreaName;

                }
            }
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fsaid != 0)
            {
                FunctionalSubArea functionalSubAreaToDelete = db.FunctionalSubArea.FirstOrDefault(fs => fs.FunctionalSubAreaId == fsaid);

                if (functionalSubAreaToDelete != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        db.FunctionalSubArea.Remove(functionalSubAreaToDelete);
                        db.SaveChanges();
                        RefreshData();

                    }
                }
            }

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
            fsaid = Convert.ToInt32(clickedRow.Cells["FunctionalSubAreaId"].Value);
            fsa = Convert.ToString(clickedRow.Cells["functionalsubareanames"].Value);
        }
        private bool FunctionalSubAreaNameExists(string name)
        {
            // Check if the functional sub-area name already exists in the database
            return db.FunctionalSubArea.Any(fsa => fsa.ProjectId == Form1.projectid && fsa.FunctionalSubAreaName == name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if the functional sub-area name already exists
            if (FunctionalSubAreaNameExists(textBox1.Text))
            {
                MessageBox.Show("Functional sub-area name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validate that FunctionalSubAreaName is not empty and contains only letters or whitespace
            if (!IsValidString(textBox1.Text))
            {
                MessageBox.Show("Please enter a valid functional sub-area name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var rest = from t in db.FunctionalSubArea
                       where t.ProjectId == Form1.projectid
                       select t;
            if (rest.Any())
            {
                selecteddata.FunctionalSubAreaName = textBox1.Text;
                db.SaveChanges();
                RefreshData();
                panel1.Visible = false;


                MessageBox.Show("Functional Sub-Area updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Functional Sub-Area not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Visible = false;
        }
        private bool IsValidString(string input)
        {
            // Check if the input is not empty and contains only letters or whitespace
            return !string.IsNullOrWhiteSpace(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));

        }
        private void button5_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue; 
            // Check if the functional sub-area name already exists
            if (FunctionalSubAreaNameExists(textBox2.Text))
            {
                MessageBox.Show("Functional sub-area name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validate that FunctionalSubAreaName is not empty and contains only letters or whitespace
            if (!IsValidString(textBox2.Text))
            {
                MessageBox.Show("Please enter a valid functional sub-area name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var res = new FunctionalSubArea
            {
                ProjectId = Form1.projectid,
                FunctionalSubAreaName = textBox2.Text,
            };
            db.FunctionalSubArea.Add(res);
            db.SaveChanges();
            RefreshData();
            panel2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FunctionalUserControl fc = new FunctionalUserControl();
            this.Hide();
            this.Parent.Controls.Add(fc);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CountryUserControl country = new CountryUserControl();
            this.Hide();
            this.Parent.Controls.Add((country));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}