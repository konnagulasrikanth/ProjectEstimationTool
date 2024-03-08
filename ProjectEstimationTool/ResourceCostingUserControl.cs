using Microsoft.Identity.Client;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectEstimationTool
{
    public partial class ResourceCostingUserControl : UserControl
    {
        private ResourceCosting Res { get; set; }
        private int timelineid;

        private int Hourlyrate;
        private int Monthlyhours;
        private int Months;
        private int Monthlyrate;
        private int Cost;
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        public ResourceCostingUserControl()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void RefreshData()
        {
            var res = from t in db.ResourceCosting
                      where t.ProjectId == Form1.projectid
                      select t;
            dataGridView1.DataSource = res.ToList();

        }
        public void RefreshAllocation()
        {
            var res1 = from t in db.ResourceAllocation
                      where t.ProjectId == Form1.projectid
                      select t;
            dataGridView2.DataSource = res1.ToList();

        }

        private void ResourceCostingUserControl_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;

            UpdateResourceCostTimeline();

            var phase = (from phasename in db.Timeline
                         where phasename.ProjectId == Form1.projectid
                         select phasename.Phase).Distinct();
            var country = (from countryname in db.Country
                           where countryname.ProjectId == Form1.projectid
                           select countryname.CountryName).Distinct();
            var reslevel = (from reslevelname in db.ResourceLevel
                            where reslevelname.ProjectId == Form1.projectid
                            select reslevelname.LevelName).Distinct();
            var restype = (from restypename in db.ResourceTypes
                           where restypename.ProjectId == Form1.projectid
                           select restypename.TypeName).Distinct();
            textBox1.Text = "0";
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox1.Items.AddRange(phase.ToArray());
            comboBox2.Items.AddRange(restype.ToArray());
            comboBox3.Items.AddRange(country.ToArray());
            comboBox4.Items.AddRange(reslevel.ToArray());

            RefreshData();
            RefreshAllocation();
        }
        public void Rateformula(string country, string resourcetype, string rolelevel, string phase, int rescount)
        {
            Hourlyrate = (from rate in db.Resource
                          where rate.CountryName.Contains(country) && rate.TypeName.Contains(resourcetype) && rate.LevelName.Contains(rolelevel) && rate.ProjectId == Form1.projectid
                          select rate.HourlyRate).FirstOrDefault();
            Monthlyhours = (from hours in db.Productivity
                            where hours.ProductivityName == "Month" && hours.ProjectId == Form1.projectid
                            select hours.Hours).FirstOrDefault();
            Months = (from mm in db.Timeline
                      where mm.Phase == phase && mm.ProjectId == Form1.projectid
                      select mm.Mm).FirstOrDefault();
            Monthlyrate = Hourlyrate * Monthlyhours *rescount;
            Cost = Monthlyrate * Months;

        }
        private void UpdateButtonEnabledState() //validation for the adding the resouce count
        {
            // Check if all fields are selected/entered
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null ||
                comboBox3.SelectedItem == null || comboBox4.SelectedItem == null ||
                string.IsNullOrEmpty(textBox1.Text))
            {
                button2.Enabled = false;
                return;
            }

            // Fetch the TimelineId based on the selected phase
            var selectedPhase = comboBox1.SelectedItem.ToString();
            var selectedCountry = comboBox3.SelectedItem.ToString();
            var selectedResourceType = comboBox2.SelectedItem.ToString();
            var selectedRoleLevel = comboBox4.SelectedItem.ToString();
            var enteredResourceCount = int.Parse(textBox1.Text);

            // Check if the combination already exists
            var existingResourceCosting = db.ResourceCosting
                .FirstOrDefault(rc =>
                    rc.ProjectId == Form1.projectid &&
                    rc.Phase == selectedPhase &&
                    rc.Country == selectedCountry &&
                    rc.ResType == selectedResourceType &&
                    rc.RoleLevel == selectedRoleLevel);

            if (existingResourceCosting != null)
            {
                // Combination already exists, display an error message and disable the button
                button2.Enabled = false;
            }
            else
            {
                // Combination doesn't exist, enable the button
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null ||
                    comboBox3.SelectedItem == null || comboBox4.SelectedItem == null ||
                    string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please enter values for all fields.", "Alert!");
                    return;
                }

                if (!int.TryParse(textBox1.Text, out int resourceCount) || resourceCount <= 0)
                {
                    MessageBox.Show("Please enter a valid positive integer for Resource Count.", "Alert!");
                    return;
                }

                var selectedPhase = comboBox1.SelectedItem.ToString();
                var selectedCountry = comboBox3.SelectedItem.ToString();
                var selectedResourceType = comboBox2.SelectedItem.ToString();
                var selectedRoleLevel = comboBox4.SelectedItem.ToString();

                var existingRecord = db.ResourceCosting
                    .FirstOrDefault(rc =>
                   
                        rc.ProjectId == Form1.projectid &&
                        rc.Phase == selectedPhase &&
                        rc.Country == selectedCountry &&
                        rc.ResType == selectedResourceType &&
                        rc.RoleLevel == selectedRoleLevel);


                if (existingRecord != null)
                {
                    MessageBox.Show("The same combination already exists please choose another combination.", "Alert!");
                    return;
                }

                var resRequired = db.Timeline
                    .Where(t => t.ProjectId == Form1.projectid && t.Phase == selectedPhase)
                    .Select(t => t.ResReq)
                    .FirstOrDefault();

                var resAllocated = db.ResourceCosting
                    .Where(rc => rc.ProjectId == Form1.projectid && rc.Phase == selectedPhase)
                    .Select(rc => rc.ResCount)
                    .Sum();

                var availableResources = resRequired - resAllocated;

                if (resourceCount <= 0)
                {
                    MessageBox.Show("Please enter a number greater than 0 for Resource Count.", "Alert!");
                    return;
                }
                else if (resourceCount > availableResources)
                {
                    MessageBox.Show($"Number of resources cannot be greater than available resources ({availableResources}).", "Alert!");
                    return;
                }
                else if (resourceCount > resRequired)
                {
                    MessageBox.Show($"Number of resources cannot be greater than ResRequired ({resRequired}).", "Alert!");
                    return;
                }
                var resourceid = db.Resource.Where(r => r.ProjectId == Form1.projectid && r.TypeName == selectedResourceType).Select(r=>r.ResourceId).FirstOrDefault();
                var timelineId = db.Timeline
                    .Where(t => t.ProjectId == Form1.projectid && t.Phase == selectedPhase)
                    .Select(t => t.TimelineId)
                    .FirstOrDefault();

                Rateformula(selectedCountry, selectedResourceType, selectedRoleLevel, selectedPhase, resourceCount);

                var adddata = new ResourceCosting
                {
                    
                    ProjectId = Form1.projectid,
                    TimelineId = timelineId,
                    ResourceId = resourceid,
                    Phase = selectedPhase,
                    ResCount = resourceCount,
                    ResType = selectedResourceType,
                    Country = selectedCountry,
                    RoleLevel = selectedRoleLevel,
                    HourlyRate = Hourlyrate,
                    MonthlyRate = Monthlyrate,
                    Cost = Cost,
                    DurationMm = Months
                };

                db.ResourceCosting.Add(adddata);
                db.SaveChanges();

                var resallocation = db.ResourceCosting
                    .Where(p => p.ProjectId == Form1.projectid && p.TimelineId == timelineId)
                    .Select(p => p.ResCount)
                    .Sum();

                var updateAllocation = db.ResourceAllocation
                    .Where(p => p.ProjectId == Form1.projectid && p.TimelineId == timelineId)
                    .ToList();

                int respending = resRequired - resallocation;

                if (updateAllocation != null && updateAllocation.Count > 0)
                {
                    try
                    {
                        foreach (var allocation in updateAllocation)
                        {
                            allocation.ResourcePending = respending;
                            allocation.ResourceAllocated = resallocation;
                            db.ResourceAllocation.Update(allocation);
                            int i = db.SaveChanges();
                            MessageBox.Show($"Updated ResourcePending: {allocation.ResourcePending}, Updated ResourceAllocated: {allocation.ResourceAllocated}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating ResourceAllocation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                RefreshData();
                RefreshAllocation();
                button1.BackColor = Color.RosyBrown;
                panel1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.BackColor= Color.RosyBrown;
            panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue;
            panel1.Visible = true;
            panel2.Visible = false;
            // Clear entered values
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            textBox1.Text = "";
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            var phase = (from phasename in db.Timeline
                         where phasename.ProjectId == Form1.projectid
                         select phasename.Phase).Distinct();
            var country = (from countryname in db.Country
                           where countryname.ProjectId == Form1.projectid
                           select countryname.CountryName).Distinct();
            var reslevel = (from reslevelname in db.ResourceLevel
                            where reslevelname.ProjectId == Form1.projectid
                            select reslevelname.LevelName).Distinct();
            var restype = (from restypename in db.ResourceTypes
                           where restypename.ProjectId == Form1.projectid
                           select restypename.TypeName).Distinct();
            comboBox8.Items.Clear();
            comboBox8.Items.AddRange(phase.ToArray());
            comboBox6.Items.Clear();
            comboBox6.Items.AddRange(country.ToArray());
            comboBox5.Items.Clear();
            comboBox5.Items.AddRange(reslevel.ToArray());
            comboBox7.Items.Clear();
            comboBox7.Items.AddRange(restype.ToArray());
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Res = dataGridView1.SelectedRows[0].DataBoundItem as ResourceCosting;

                if (Res != null)
                {
                    comboBox8.Text = Res.Phase;
                    comboBox6.Text = Res.Country;
                    comboBox5.Text = Res.RoleLevel;
                    comboBox7.Text = Res.ResType;
                    textBox2.Text = Res.ResCount.ToString();
                }


            }
        }

        private void button5_Click(object sender, EventArgs e) //edit button code
        {

            try
            {
                if (comboBox8.SelectedItem == null || comboBox6.SelectedItem == null ||
                    comboBox5.SelectedItem == null || comboBox7.SelectedItem == null ||
                    string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Please enter values for all fields.", "Alert!");
                    return;
                }

                if (!int.TryParse(textBox2.Text, out int resCount) || resCount <= 0)
                {
                    MessageBox.Show("Please enter a valid positive integer for Resource Count.", "Alert!");
                    return;
                }

                var selectedPhase = comboBox8.SelectedItem.ToString();
                var selectedCountry = comboBox6.SelectedItem.ToString();
                var selectedResourceType = comboBox7.SelectedItem.ToString();
                var selectedRoleLevel = comboBox5.SelectedItem.ToString();

                var resRequired = db.Timeline
                    .Where(t => t.ProjectId == Form1.projectid && t.Phase == selectedPhase)
                    .Select(t => t.ResReq)
                    .FirstOrDefault();

                var resAllocated = db.ResourceCosting
                    .Where(rc => rc.ProjectId == Form1.projectid && rc.Phase == selectedPhase && rc.ResourceCostingId != Res.ResourceCostingId)
                    .Select(rc => rc.ResCount)
                    .Sum();

                var availableResources = resRequired - resAllocated;

                if (resCount <= 0)
                {
                    MessageBox.Show("Please enter a number greater than 0 for Resource Count.", "Alert!");
                    return;
                }
                else if (resCount > availableResources)
                {
                    MessageBox.Show($"Number of resources cannot be greater than available resources ({availableResources}).", "Alert!");
                    return;
                }
                else if (resCount > resRequired)
                {
                    MessageBox.Show($"Number of resources cannot be greater than ResRequired ({resRequired}).", "Alert!");
                    return;
                }

                // Fetch the existing ResourceCosting record
                var existingResourceCosting = db.ResourceCosting
                    .FirstOrDefault(rc =>
                        rc.ProjectId == Form1.projectid &&
                        rc.Phase == Res.Phase && // Check with the original values
                        rc.Country == Res.Country &&
                        rc.ResType == Res.ResType &&
                        rc.RoleLevel == Res.RoleLevel);
                var resourceid = db.Resource.Where(r => r.ProjectId == Form1.projectid && r.TypeName == selectedResourceType).Select(r => r.ResourceId).FirstOrDefault();

                // Update the ResourceCosting record
                Res.ProjectId = Form1.projectid;
                Res.ResourceId = resourceid;
                Res.Phase = selectedPhase;
                Res.Country = selectedCountry;
                Res.RoleLevel = selectedRoleLevel;
                Res.ResType = selectedResourceType;
                Res.ResCount = resCount; // Using the parsed value
                Rateformula(selectedCountry, selectedResourceType, selectedRoleLevel, selectedPhase, resCount);
                Res.HourlyRate = Hourlyrate;
                Res.MonthlyRate = Monthlyrate;
                Res.Cost = Cost;
                Res.DurationMm = Months;

                db.SaveChanges();

                var uresreq = db.Timeline
                    .Where(p => p.ProjectId == Form1.projectid && p.Phase == selectedPhase)
                    .Select(p => p.ResReq)
                    .FirstOrDefault();

                var uresallocation = db.ResourceCosting
                    .Where(p => p.ProjectId == Form1.projectid && p.Phase == selectedPhase)
                    .Select(p => p.ResCount)
                    .Sum();

                var uupdateAllocation = db.ResourceAllocation
                    .Where(p => p.ProjectId == Form1.projectid && p.Phase == selectedPhase)
                    .ToList();

                int urespending = uresreq - uresallocation;

                if (uupdateAllocation != null && uupdateAllocation.Count > 0)
                {
                    foreach (var allocation in uupdateAllocation)
                    {
                        allocation.ResourcePending = urespending;
                        allocation.ResourceAllocated = uresallocation;
                        db.ResourceAllocation.Update(allocation);
                        db.SaveChanges();
                    }
                }

                RefreshData();
                RefreshAllocation();
                panel2.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating resource costing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];
                    if (selectedRow.DataBoundItem is ResourceCosting RESCOST)
                    {
                        int seid = RESCOST.ResourceCostingId;

                        var delete = db.ResourceCosting.FirstOrDefault(t => t.ResourceCostingId == seid);

                        if (delete != null)
                        {
                            db.ResourceCosting.Remove(delete);
                            db.SaveChanges();
                            var uresreq = db.Timeline.Where(p => p.ProjectId == Form1.projectid && p.Phase == delete.Phase).Select(p => p.ResReq).FirstOrDefault();
                            var uresallocation = db.ResourceCosting.Where(p => p.ProjectId == Form1.projectid && p.Phase == delete.Phase).Select(p => p.ResCount).Sum();
                            var uupdateAllocation = db.ResourceAllocation.Where(p => p.ProjectId == Form1.projectid && p.Phase == delete.Phase).ToList();
                            int urespending = uresreq - uresallocation;

                            if (uupdateAllocation != null && uupdateAllocation.Count > 0)
                            {
                                foreach (var allocation in uupdateAllocation)
                                {
                                    allocation.ResourcePending = urespending;
                                    allocation.ResourceAllocated = uresallocation;
                                    db.ResourceAllocation.Update(allocation);
                                    db.SaveChanges();
                                }
                            }
                            RefreshData();
                            RefreshAllocation();
                            // Clear entered values
                            comboBox1.SelectedIndex = -1;
                            comboBox2.SelectedIndex = -1;
                            comboBox3.SelectedIndex = -1;
                            comboBox4.SelectedIndex = -1;
                            textBox1.Text = "";
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Timeline tm = new Timeline();
            this.Hide();
            this.Parent.Controls.Add(tm);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            SummaryUserControl ra = new SummaryUserControl();
            this.Hide();
            this.Parent.Controls.Add(ra);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public void UpdateResourceCostTimeline()
        {
            try
            {
                var ResourceCosts = db.ResourceCosting
           .Where(se => se.ProjectId == Form1.projectid)
           .ToList();
                dataGridView1.DataSource = ResourceCosts;

                foreach (var resource in ResourceCosts)
                {
                    var timelinedata = db.Timeline
                .Where(t => t.TimelineId == resource.TimelineId && t.ProjectId == Form1.projectid)
                .FirstOrDefault();
                    var resrate = db.Resource
                   .Where(t => t.ResourceId == resource.ResourceId && t.ProjectId == Form1.projectid)
                     .FirstOrDefault();
                    if (resource != null)
                    {
                        resource.DurationMm = timelinedata.Mm;
                        resource.Phase = timelinedata.Phase;
                        resource.RoleLevel = resrate.LevelName;
                        resource.ResType = resrate.TypeName;
                        resource.Country=resrate.CountryName;
                        

                        Rateformula(resrate.TypeName, resrate.TypeName, resrate.LevelName, timelinedata.Phase,resource.ResCount);

                        resource.HourlyRate = resrate.HourlyRate;
                        resource.MonthlyRate = resource.HourlyRate * Monthlyhours*resource.ResCount;
                        resource.Cost = resource.DurationMm * resource.MonthlyRate;
                        db.SaveChanges();

                    }
                }

            }
            catch
            {
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}