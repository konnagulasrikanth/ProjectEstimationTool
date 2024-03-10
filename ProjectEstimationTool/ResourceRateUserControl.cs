using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using ProjectEstimationTool.Models;
using ProjectEstimationTool.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectEstimationTool
{
    public partial class ResourceRateUserControl : UserControl
    {
        private Resource selecteddata;
        private int CountryName;
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        public ResourceRateUserControl()
        {
            InitializeComponent();
            LoadDefaultResourceData();
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }

        private void ResourceRateUserControl_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            UpdateResource();
            //UpdateResourceDataOnChanges();


            LoadDefaultResourceData();
        }
        private void LoadDefaultResourceData()
        {
            var res = from t in db.Resource
                      where t.ProjectId == Form1.projectid
                      select t;
            dataGridView1.DataSource = res.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue;
            panel1.Visible = true;
            panel2.Visible = false;
            comboBox1.Refresh();
            // Distinct values for Country
            var ef = db.Country
                .Where(c => c.ProjectId == Form1.projectid) // Filter by ProjectId
                .Select(t => t.CountryName)
                .Distinct();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(ef.ToArray());

            // Distinct values for ResourceTypes
            comboBox2.Refresh();
            var fa = db.ResourceTypes
                .Where(rt => rt.ProjectId == Form1.projectid) // Filter by ProjectId
                .Select(t => t.TypeName)
                .Distinct();
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(fa.ToArray());

            // Distinct values for ResourceLevel
            comboBox3.Refresh();
            var fsa = db.ResourceLevel
                .Where(rl => rl.ProjectId == Form1.projectid) // Filter by ProjectId
                .Select(t => t.LevelName)
                .Distinct();
            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(fsa.ToArray());
            LoadDefaultResourceData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private bool IsDuplicateResource(string country, string resourceType, string resourceLevel)
        {
            //int currentResourceId = db.Resource.Where(c=>c.CountryName==country&&c.TypeName ==resourceType && c.LevelName==resourceLevel).Select(p=>p.ResourceId).FirstOrDefault();
            return db.Resource.Any(r =>
                r.ProjectId == Form1.projectid &&
                r.CountryName == country &&
                r.TypeName == resourceType &&
                r.LevelName == resourceLevel);
        }
        private bool IsDuplicateResourceEdit(string country, string resourceType, string resourceLevel, int currentResourceId)
        {
            // Check if the resource entry already exists in the database (case-insensitive)
            var existingResource = db.Resource
                .FirstOrDefault(r =>
                    r.ProjectId == Form1.projectid &&
                    r.CountryName.ToLower() == country.ToLower() &&
                    r.TypeName.ToLower() == resourceType.ToLower() &&
                    r.LevelName.ToLower() == resourceLevel.ToLower() &&
                    r.ResourceId != currentResourceId);

            return existingResource != null;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
          
            try
            {
                // Validate that a country is selected
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a country.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate that a resource type is selected
                if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a resource type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate that a resource level is selected
                if (comboBox3.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a resource level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Check for duplicate entry
                if (IsDuplicateResource(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString()))
                {
                    MessageBox.Show("Duplicate resource entry found. Please choose different values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Please enter an hourly rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate that the hourly rate is a valid integer
                if (!int.TryParse(textBox1.Text, out int hourlyRate))
                {
                    MessageBox.Show("Please enter a valid hourly rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var countryid = db.Country.Where(p => p.ProjectId == Form1.projectid && p.CountryName == comboBox1.SelectedItem.ToString()).Select(p => p.CountryId).FirstOrDefault();
                var reslevelid = db.ResourceLevel.Where(p => p.ProjectId == Form1.projectid && p.LevelName == comboBox3.SelectedItem.ToString()).Select(p => p.LevelId).FirstOrDefault();
                var restypeid = db.ResourceTypes.Where(p => p.ProjectId == Form1.projectid && p.TypeName == comboBox2.SelectedItem.ToString()).Select(p => p.ResourceTypeId).FirstOrDefault();

                var res = new Resource
                {
                    ProjectId = Form1.projectid,
                    CountryId = countryid,
                    ResourceTypeId = restypeid,
                    LevelId = reslevelid,
                    CountryName = comboBox1.SelectedItem.ToString(),
                    TypeName = comboBox2.SelectedItem.ToString(),
                    LevelName = comboBox3.SelectedItem.ToString(),
                    HourlyRate = int.Parse(textBox1.Text.Trim()),
                };
                db.Resource.Add(res);
                db.SaveChanges();
                LoadDefaultResourceData();
                button1.BackColor = Color.RosyBrown;

                panel1.Visible = false;
            }
            catch
            (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;

            var ef = db.Country
                     .Where(c => c.ProjectId == Form1.projectid) // Filter by ProjectId
                     .Select(t => t.CountryName)
                     .Distinct();
            comboBox6.Items.Clear();
            comboBox6.Items.AddRange(ef.ToArray());

            var fa = db.ResourceTypes
                         .Where(rt => rt.ProjectId == Form1.projectid) // Filter by ProjectId
                         .Select(t => t.TypeName)
                         .Distinct();
            comboBox5.Items.Clear();
            comboBox5.Items.AddRange(fa.ToArray());
            var fsa = db.ResourceLevel
                           .Where(rl => rl.ProjectId == Form1.projectid) // Filter by ProjectId
                           .Select(t => t.LevelName)
                           .Distinct();
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(fsa.ToArray());

            if (dataGridView1.SelectedRows.Count > 0)
            {

                selecteddata = dataGridView1.SelectedRows[0].DataBoundItem as Resource;
                if (selecteddata != null)
                {
                    comboBox6.Text = selecteddata.CountryName;
                    comboBox5.Text = selecteddata.TypeName;
                    comboBox4.Text = selecteddata.LevelName;
                    textBox2.Text = selecteddata.HourlyRate.ToString();
                }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private void UpdateResource()
        {
            try
            {
                var ResourceRecords = db.Resource
                    .Where(se => se.ProjectId == Form1.projectid)
                    .ToList();
                dataGridView1.DataSource = ResourceRecords;
                // Fetch updated FunctionalArea records from the database
                foreach (var ResourceRecord in ResourceRecords)
                {
                    var countrydata = db.Country
                 .Where(t => t.CountryId == ResourceRecord.CountryId && t.ProjectId == Form1.projectid)
                 .FirstOrDefault();
                    var reslevel = db.ResourceLevel
                   .Where(t => t.LevelId == ResourceRecord.LevelId && t.ProjectId == Form1.projectid)
                     .FirstOrDefault();
                    var restype = db.ResourceTypes
                   .Where(t => t.ResourceTypeId == ResourceRecord.ResourceTypeId && t.ProjectId == Form1.projectid)
                       .FirstOrDefault();
                    if (ResourceRecord != null)
                    {
                        ResourceRecord.TypeName = restype.TypeName;
                        ResourceRecord.LevelName = reslevel.LevelName;
                        ResourceRecord.CountryName = countrydata.CountryName;
                        db.SaveChanges();

                    }

                }
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
                // Validate that a country is selected
                if (comboBox6.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a country.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate that a resource type is selected
                if (comboBox5.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a resource type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate that a resource level is selected
                if (comboBox4.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a resource level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check for duplicate entry
                if (IsDuplicateResourceEdit(comboBox6.SelectedItem.ToString(), comboBox5.SelectedItem.ToString(), comboBox4.SelectedItem.ToString(),selecteddata.ResourceId))
                {
                    MessageBox.Show("Duplicate resource entry found. Please choose different values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Please enter an hourly rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // Validate that the hourly rate is a valid integer
                if (!int.TryParse(textBox2.Text, out int hourlyRate))
                {
                    MessageBox.Show("Please enter a valid hourly rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var countryid = db.Country.Where(p => p.ProjectId == Form1.projectid && p.CountryName == comboBox6.SelectedItem.ToString()).Select(p => p.CountryId).FirstOrDefault();
                var reslevelid = db.ResourceLevel.Where(p => p.ProjectId == Form1.projectid && p.LevelName == comboBox4.SelectedItem.ToString()).Select(p => p.LevelId).FirstOrDefault();
                var restypeid = db.ResourceTypes.Where(p => p.ProjectId == Form1.projectid && p.TypeName == comboBox5.SelectedItem.ToString()).Select(p => p.ResourceTypeId).FirstOrDefault();
                selecteddata.CountryName = comboBox6.SelectedItem.ToString();
                selecteddata.ResourceTypeId = restypeid;
                selecteddata.LevelId = reslevelid;
                selecteddata.CountryId = countryid;
                selecteddata.TypeName = comboBox5.SelectedItem.ToString();
                selecteddata.LevelName = comboBox4.SelectedItem.ToString();
                selecteddata.HourlyRate = int.Parse(textBox2.Text.Trim());
                db.SaveChanges();
                panel2.Visible = false;
                LoadDefaultResourceData();
            }
            catch
            (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    if (selectedRow.DataBoundItem is Resource selectedResource)
                    {
                        int resourceId = selectedResource.ResourceId;

                        var resourceToDelete = db.Resource.FirstOrDefault(r => r.ResourceId == resourceId);

                        if (resourceToDelete != null)
                        {
                            db.Resource.Remove(resourceToDelete);
                            db.SaveChanges();
                            LoadDefaultResourceData();
                        }
                    }
                }
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            button1.BackColor = Color.RosyBrown;

            panel1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ResourceLevelUserControl rl = new ResourceLevelUserControl();
            this.Hide();
            this.Parent.Controls.Add(rl);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SoftwarerateUserControl sr = new SoftwarerateUserControl();
            this.Hide();
            this.Parent.Controls.Add(sr);
        }
  
      

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
