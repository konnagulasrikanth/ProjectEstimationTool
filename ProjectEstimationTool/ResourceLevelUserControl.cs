using ProjectEstimationTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectEstimationTool
{
    public partial class ResourceLevelUserControl : UserControl
    {
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        private ResourceLevel leveldata;
         int levelid;
        public ResourceLevelUserControl()
        {
            InitializeComponent();
            LoadResourceLevelData();
        }
        private void LoadResourceLevelData()
        {

            var res = from t in db.ResourceLevel
                      where t.ProjectId == Form1.projectid
                      select t;
            dataGridView1.DataSource = res.ToList();
        }


        private void ResourceLevelUserControl_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue;
            panel1.Visible = true;
            panel2.Visible = false;

        }
        private bool ResourceLevelExists(string name, int currentResourceLevelId)
        {
            // Check if the resource level name already exists in the database (case-insensitive)
            var existingResourceLevel = db.ResourceLevel
                .FirstOrDefault(rl =>
                    rl.ProjectId == Form1.projectid &&
                    rl.LevelName.ToLower() == name.ToLower() &&
                    rl.LevelId != currentResourceLevelId);

            return existingResourceLevel != null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate that LevelName is not null or empty
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Please enter a valid resource level name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate that LevelName does not contain spaces
                if (textBox1.Text.Contains(" "))
                {
                    MessageBox.Show("Resource level name cannot contain spaces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate that LevelName does not contain numbers or special characters
                if (!IsValidResourceLevelName(textBox1.Text))
                {
                    MessageBox.Show("Resource level name should only contain letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate that LevelName is not duplicated
                if (ResourceLevelExists(textBox1.Text,leveldata.LevelId))
                {
                    MessageBox.Show("Resource level name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var res = new ResourceLevel
                {
                    ProjectId = Form1.projectid,
                    LevelName = textBox1.Text.Trim(),
                };
                db.ResourceLevel.Add(res);
                db.SaveChanges();
                button1.BackColor = Color.RosyBrown;
                LoadResourceLevelData();
                panel1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidResourceLevelName(string levelName)
        {
            // Check if the input contains only letters
            return !string.IsNullOrWhiteSpace(levelName) && levelName.Any(c => char.IsLetter(c)) && levelName.Any(c => char.IsDigit(c));
        
         }

        private void button5_Click(object sender, EventArgs e) //edit button of resource level
        {
            try
            {
                // Validate that LevelName is not null or empty
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Please enter a valid resource level name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate that LevelName does not contain spaces
                if (textBox2.Text.Contains(" "))
                {
                    MessageBox.Show("Resource level name cannot contain spaces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate that LevelName does not contain numbers or special characters
                if (!IsValidResourceLevelName(textBox2.Text))
                {
                    MessageBox.Show("Resource level name should only contain letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate that LevelName is not duplicated
                if (ResourceLevelExists(textBox2.Text,leveldata.LevelId))
                {
                    MessageBox.Show("Resource level name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var d = from t in db.ResourceLevel
                        where t.ProjectId == Form1.projectid
                        select t;
                if (d.Any())
                {
                    leveldata.LevelName = textBox2.Text.Trim();
                    db.SaveChanges();
                    MessageBox.Show("Resource Level updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadResourceLevelData();
                    panel2.Visible = false;
                }
                else
                {
                    MessageBox.Show("Resource Level not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panel2.Visible = true;
            panel1.Visible = false;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                leveldata = dataGridView1.SelectedRows[0].DataBoundItem as ResourceLevel;
                if (leveldata != null)
                {
                    textBox2.Text = leveldata.LevelName;
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

                    if (selectedRow.DataBoundItem is ResourceLevel selectedResource)
                    {
                        int resourceId = selectedResource.LevelId;

                        var resourceToDelete = db.ResourceLevel.FirstOrDefault(r => r.LevelId == resourceId);

                        if (resourceToDelete != null)
                        {
                            db.ResourceLevel.Remove(resourceToDelete);
                            db.SaveChanges();
                            LoadResourceLevelData();
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.RosyBrown;
            panel1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ResourceTypeUserControl rc = new ResourceTypeUserControl();
            this.Hide();
            this.Parent.Controls.Add(rc);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ResourceRateUserControl rt = new ResourceRateUserControl();
            this.Hide();
            this.Parent.Controls.Add(rt);
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
