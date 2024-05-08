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
    public partial class MasterUserControl : UserControl
    {
        public ToolStripMenuItem GetSummaryToolStripMenuItem()
        {
            return summaryToolStripMenuItem;
        }
        private int Projectid;
        private string Projectname;
        public MasterUserControl()
        {
            InitializeComponent();
        }
        public void UpdateProjectLabel(string projectname, int projectid)
        {
            Projectid = projectid;
            Projectname = projectname;
        }



        private void MasterUserControl_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.projectname;
        }

        private void productivityToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void softwareRateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resourceTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void functionalAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void functionalSubAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resourceLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resourceRateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void configurationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void configurationsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }







        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void configurationsToolStripMenuItem_Click_2(object sender, EventArgs e)
        {

        }

        private void scopeEffortToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ScopeTestUserControl sc = new ScopeTestUserControl();
            panel4.Controls.Clear();
            panel4.Controls.Add(sc);
            colorbutton(scopeEffortToolStripMenuItem);
            //sc.LoadComboBoxData();
            //sc.LoadScopeData();


        }
        public void LoadScopeSection()
        {
            //panel4.Controls.Clear();
            //panel4.Controls.Add(new Scope());
            //colorbutton(scopeEffortToolStripMenuItem);
        }
        public void LoadhomeSection()
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new HomeUserControl());
            colorbutton(homeToolStripMenuItem);
        }
        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            panel4.Controls.Clear();
            panel4.Controls.Add(new HomeUserControl());
            colorbutton(homeToolStripMenuItem);

        }


        private void timelineToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Timeline tm = new Timeline();
            panel4.Controls.Clear();
            panel4.Controls.Add(tm);
            tm.LoadData();
            colorbutton(timelineToolStripMenuItem);

        }

        private void effortToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new EffortTypeUserControl());
            colorbutton(configurationsToolStripMenuItem);
        }
        public void loadconfigdata()
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new EffortTypeUserControl());
        }



        private void productivityToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new ProductivityUserControl());
            colorbutton(configurationsToolStripMenuItem);

        }

        private void functionalAreaToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new FunctionalUserControl());
            colorbutton(configurationsToolStripMenuItem);

        }



        private void countryToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new CountryUserControl());
            colorbutton(configurationsToolStripMenuItem);

        }

        private void resourceTypeToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new ResourceTypeUserControl());
            colorbutton(configurationsToolStripMenuItem);

        }

        private void resourceLevelToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new ResourceLevelUserControl());
            colorbutton(configurationsToolStripMenuItem);

        }

        private void resourceRateToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new ResourceRateUserControl());
            colorbutton(configurationsToolStripMenuItem);

        }

        private void softwareRateToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new SoftwarerateUserControl());
            colorbutton(configurationsToolStripMenuItem);

        }

        private void resourceCostingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            ResourceCostingTest rm = new ResourceCostingTest();
            rm.LoadComboBoxData();
            panel4.Controls.Add(rm);







            colorbutton(resourceCostingToolStripMenuItem);

        }


        private void resourceCostingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new ResourceCostingUserControl());
            colorbutton(resourceCostingToolStripMenuItem);

        }

        private void resourceAllocationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new SummaryUserControl());
            colorbutton(summaryToolStripMenuItem);
        }
        public void colorbutton(ToolStripMenuItem stripMenuItem)
        {
            homeToolStripMenuItem.BackColor = Color.RosyBrown;
            configurationsToolStripMenuItem.BackColor = Color.RosyBrown;
            scopeEffortToolStripMenuItem.BackColor = Color.RosyBrown;
            timelineToolStripMenuItem.BackColor = Color.RosyBrown;
            resourceCostingToolStripMenuItem.BackColor = Color.RosyBrown;
            summaryToolStripMenuItem.BackColor = Color.RosyBrown;
            stripMenuItem.BackColor = Color.LightBlue;

        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1.projectid = 0;
            Form1 fc = new Form1();
            if (fc == null)
            {
                fc = new Form1();
            }
            this.FindForm()?.Hide();
            fc.Show();
            colorbutton(toolStripMenuItem1);
        }



        private void softwareCostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            SoftwareListControl rm = new SoftwareListControl();
            panel4.Controls.Add(rm);
            rm.load();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            SoftwareListControl rm = new SoftwareListControl();
            panel4.Controls.Add(rm);
        }

        private void testToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            panel4.Controls.Clear();
            SoftwareCostingTest rm = new SoftwareCostingTest();
            panel4.Controls.Add(rm);
        }

        private void resourceCostingTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
          ResourceCostingTest rm = new ResourceCostingTest();
            panel4.Controls.Add(rm);
        }
    }
}
