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
    public partial class CountryUserControl : UserControl
    {

        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        private int cid;
        private string countryname;
        private string Projectname;
        private string projectid;
        private Country countrydata;
        static DataTable dt = new DataTable();

        public CountryUserControl()
        {
            InitializeComponent();

            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            LoadCountryData();
        }

        private void LoadCountryData()
        {
            var res = (from t in db.Country
                      where t.ProjectId == Form1.projectid
                      select t);
            dataGridView1.DataSource = res.ToList();
        }



        private void CountryUserControl_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            LoadCountryData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cid != 0)
            {
                Country functionalAreaToDelete = db.Country.FirstOrDefault(fs => fs.CountryId == cid);

                if (functionalAreaToDelete != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        db.Country.Remove(functionalAreaToDelete);
                        db.SaveChanges();
                        // Assuming RefreshData() performs the necessary actions to refresh the UI or data grid
                        LoadCountryData();
                    }
                    // No need for an else block if you don't have specific actions for DialogResult.No
                }
            }
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
                countrydata = dataGridView1.SelectedRows[0].DataBoundItem as Country;
                if (countrydata != null)
                {
                    textBox2.Text = countrydata.CountryName;
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
                cid = Convert.ToInt32(clickedRow.Cells["CountryID"].Value);
                countryname = Convert.ToString(clickedRow.Cells["CountryNames"].Value);

            }
        }
        private bool IsValidString(string input)
        {
            // Check if the input is not empty and contains only letters or whitespace
            return !string.IsNullOrWhiteSpace(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private bool CountryNameExists(string name)
        {
            // Check if the country name already exists in the database
            return db.Country.Any(c => c.ProjectId == Form1.projectid && c.CountryName == name);
        }

        private void button2_Click(object sender, EventArgs e)  //addcountry button
        {
            button1.BackColor = Color.RosyBrown;
            try
            {
                // Validate that CountryName is not empty and contains only letters or whitespace
                if (!IsValidString(textBox1.Text))
                {
                    MessageBox.Show("Please enter a valid country name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the country name already exists
                if (CountryNameExists(textBox1.Text))
                {
                    MessageBox.Show("Country name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var res = new Country
                {
                    ProjectId = Form1.projectid,
                    CountryName = textBox1.Text
                };
                db.Country.Add(res);
                db.SaveChanges();
                LoadCountryData();
                panel1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.RosyBrown;
            panel1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)   //edit button of countryname
        {
            try
            {
                // Validate that CountryName is not empty and contains only letters or whitespace
                if (!IsValidString(textBox2.Text))
                {
                    MessageBox.Show("Please enter a valid country name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the country name already exists
                if (CountryNameExists(textBox2.Text))
                {
                    MessageBox.Show("Country name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var d = from t in db.Country
                        where t.ProjectId == Form1.projectid
                        select t;
                if (d.Any())
                {
                    countrydata.CountryName = textBox2.Text;
                    db.SaveChanges();
                    MessageBox.Show("Country updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCountryData();
                    UpdateResource(Form1.projectid,countryname);

                    panel2.Visible = false;
                }
                else
                {
                    MessageBox.Show("Country not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void UpdateResource(int projectID, string newCountryName)
        {
            var resources = db.Resource.Where(r => r.ProjectId == projectID).ToList();

            if (resources != null)
            {
                foreach (var resource in resources)
                {
                    resource.CountryName = newCountryName;
                    db.SaveChanges();
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FunctioanSubAreaUserControl fc = new FunctioanSubAreaUserControl();
            this.Hide();
            this.Parent.Controls.Add(fc);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ResourceTypeUserControl rc = new ResourceTypeUserControl(); 
            this.Hide();
            this.Parent.Controls.Add(rc);
        }
    }
}
