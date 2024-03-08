using Microsoft.Data.SqlClient;
using ProjectEstimationTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectEstimationTool
{
    public partial class ResourceTypeUserControl : UserControl
    {
      
        private ResourceTypes selecteddata;
   

        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        static string ConnectionString = @"Data Source=ICS-LT-64146D3\SQLEXPRESS;Initial Catalog=ProjectEstimationToolMaster;Integrated Security=True;TrustServerCertificate=True";
        public ResourceTypeUserControl()
        {
            InitializeComponent();


        }
        public void RefreshData()
        {



        }
        public void LoadResourceTypes()
        {

            var res = from t in db.ResourceTypes
                      where t.ProjectId == Form1.projectid
                      select t;
            dataGridView1.DataSource = res.ToList();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ResourceTypeUserControl_Load(object sender, EventArgs e)
        {
            LoadResourceTypes();
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue;

            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            if (dataGridView1.SelectedRows.Count > 0)
            {

                selecteddata = dataGridView1.SelectedRows[0].DataBoundItem as ResourceTypes;
                if (selecteddata != null)
                {
                    textBox1.Text = selecteddata.TypeName;

                }
            }

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private bool ResourceTypeExists(string name)
        {
            // Check if the resource type name already exists in the database
            return db.ResourceTypes.Any(r => r.ProjectId == Form1.projectid && r.TypeName == name);
        }

        private void button3_Click(object sender, EventArgs e) //edit button of resource types
        {

            // Validate that TypeName is not null or empty
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a valid resource type name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsValidResourceTypeName(textBox1.Text))
            {
                MessageBox.Show("Resource type name should only contain letters and spaces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate that TypeName is not duplicated
            if (ResourceTypeExists(textBox1.Text))
            {
                MessageBox.Show("Resource type name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            var rest = from t in db.ResourceTypes
                       where t.ProjectId == Form1.projectid
                       select t;

            if (rest.Any())
            {
                string newTypeName = textBox1.Text;

                // Update the ResourceTypes table
                selecteddata.TypeName = newTypeName;
                db.SaveChanges();

               

                LoadResourceTypes();
                panel1.Visible = false;



                MessageBox.Show("ResourceType updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ResourceType not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidResourceTypeName(string typeName)
        {
            // Check if the input contains only letters and spaces
            return !string.IsNullOrWhiteSpace(typeName) && typeName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.RosyBrown;

            // Validate that TypeName is not null or empty
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter a valid resource type name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate that TypeName is not duplicated
            if (ResourceTypeExists(textBox2.Text))
            {
                MessageBox.Show("Resource type name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsValidResourceTypeName(textBox2.Text))
            {
                MessageBox.Show("Resource type name should only contain letters and spaces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var a = new ResourceTypes
            {
                ProjectId = Form1.projectid,
                TypeName = textBox2.Text,
            };
            db.ResourceTypes.Add(a);
            db.SaveChanges();
            LoadResourceTypes();
            panel2.Visible = false;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.RosyBrown;

            panel2.Visible = false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    if (selectedRow.DataBoundItem is ResourceTypes selectedResource)
                    {
                        int resourceId = selectedResource.ResourceTypeId;

                        var resourceToDelete = db.ResourceTypes.FirstOrDefault(r => r.ResourceTypeId == resourceId);

                        if (resourceToDelete != null)
                        {
                            db.ResourceTypes.Remove(resourceToDelete);
                            db.SaveChanges();
                            LoadResourceTypes();
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CountryUserControl cr = new CountryUserControl();
            this.Hide();
            this.Parent.Controls.Add(cr);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ResourceLevelUserControl rl = new ResourceLevelUserControl();   
            this.Hide();
            this.Parent.Controls.Add(rl);
        }
    }
}
