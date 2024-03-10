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
        public FunctionalUserControl()
        {
            InitializeComponent();
        }

        private void FunctionalUserControl_Load(object sender, EventArgs e)
        {
    
            LoadFunctionalAreaData();
            panel1.Visible = false;
            panel2.Visible = false;

        }
        private void LoadFunctionalAreaData()
        {
            var res = from t in db.FunctionalArea
                      where t.ProjectId == Form1.projectid
                      select t;
            dataGridView1.DataSource = res.ToList();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue;
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            if (dataGridView1.SelectedRows.Count > 0)
            {

                selecteddata = dataGridView1.SelectedRows[0].DataBoundItem as FunctionalArea;
                if (selecteddata != null)
                {
                    textBox1.Text = selecteddata.FunctionalAreaName;

                }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
            functionalAreaId = Convert.ToInt32(clickedRow.Cells["FunctionalAreaIds"].Value);
            functionalAreaName = Convert.ToString(clickedRow.Cells["FunctionalAreaNames"].Value);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (functionalAreaId != 0)
            {
                FunctionalArea functionalAreaToDelete = db.FunctionalArea.FirstOrDefault(fs => fs.FunctionalAreaId == functionalAreaId);

                if (functionalAreaToDelete != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        db.FunctionalArea.Remove(functionalAreaToDelete);
                        db.SaveChanges();
                        LoadFunctionalAreaData();

                    }

                }
            }

        }

        private void contextMenuStrip1_MouseDown(object sender, MouseEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if the functional area name already exists
            if (FunctionalAreaNameExists(textBox1.Text,functionalAreaId))
            {
                MessageBox.Show("Functional area name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           

            // Validate that FunctionalAreaName is not empty and contains only letters or whitespace
            if (!IsValidString(textBox1.Text))
            {
                MessageBox.Show("Please enter a valid functional area name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var rest = from t in db.FunctionalArea
                       where t.ProjectId == Form1.projectid
                       select t;

            if (rest.Any())
            {
                selecteddata.FunctionalAreaName = textBox1.Text.Trim();
                db.SaveChanges();
                MessageBox.Show("Functional Area updated successfully.");
                LoadFunctionalAreaData();
                panel1.Visible = false;
            }
            else
            {
                MessageBox.Show("Functional Area not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue;
            // Validate that FunctionalAreaName is not empty and contains only letters or whitespace
            if (!IsValidString(textBox2.Text))
            {
                MessageBox.Show("Please enter a valid functional area name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Check if the functional area name already exists
            if (FunctionalAreaNameExists(textBox2.Text,functionalAreaId))
            {
                MessageBox.Show("Functional area name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var resss = new FunctionalArea
            {
                ProjectId = Form1.projectid,
                FunctionalAreaName = textBox2.Text.Trim(),

            };
            db.FunctionalArea.Add(resss);
            db.SaveChanges();
            MessageBox.Show("Functional Area added successfully.");
            button1.BackColor = Color.RosyBrown;
            LoadFunctionalAreaData();
            panel2.Visible = false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            button1.BackColor = Color.RosyBrown;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProductivityUserControl prod = new ProductivityUserControl();
            this.Hide();
            this.Parent.Controls.Add(prod);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FunctioanSubAreaUserControl fc = new FunctioanSubAreaUserControl();
            this.Hide();
            this.Parent.Controls.Add(fc); 
        }
    }
}
