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

        private void effortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EffortTypeUserControl UpdateControl = new EffortTypeUserControl();
            panel1.Controls.Clear();
            panel1.Controls.Add(UpdateControl);
            UpdateControl.Dock = DockStyle.Fill;
            UpdateControl.UpdateProjectLabel(Projectname, Projectid);
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
















        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void scopeEffortToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }



        private void resourceCostingToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }


        private void resourceCostingToolStripMenuItem_Click(object sender, EventArgs e)
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
            panel4.Controls.Clear();
            panel4.Controls.Add(new Scope());
            colorbutton(scopeEffortToolStripMenuItem);

        }
        public void LoadScopeSection()
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new Scope());
            colorbutton(scopeEffortToolStripMenuItem);
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
            panel4.Controls.Clear();
            panel4.Controls.Add(new Timeline());
            colorbutton(timelineToolStripMenuItem);

        }

        private void effortToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new EffortTypeUserControl());
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
        }

        private void functionalAreaToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new FunctionalUserControl());
        }

        private void functionalSubAreaToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new FunctioanSubAreaUserControl());
        }

        private void countryToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new CountryUserControl());
        }

        private void resourceTypeToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new ResourceTypeUserControl());
        }

        private void resourceLevelToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new ResourceLevelUserControl());
        }

        private void resourceRateToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new ResourceRateUserControl());
        }

        private void softwareRateToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new SoftwarerateUserControl());
        }

        private void resourceCostingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            panel4.Controls.Clear();

            // Load ResourceCostingUserControl and add it to panel4
            ResourceCostingUserControl resourceCostingUserControl = new ResourceCostingUserControl();
            panel4.Controls.Add(resourceCostingUserControl);

            // Load ResourceAllocationUserControl in the background (hidden)
            ResourceAllocationUserControl resourceAllocationUserControl = new ResourceAllocationUserControl();
            resourceAllocationUserControl.RefreshData(); // Refresh data if needed

            // Add ResourceAllocationUserControl to panel4 (not setting Visible to true)
            panel4.Controls.Add(resourceAllocationUserControl);

            // Enable buttons in parent control (if applicable)
            ResourceAllocationUserControl parentControl = FindParent<ResourceAllocationUserControl>(this);
            if (parentControl != null)
            {
                parentControl.RefreshData();
            }

            colorbutton(resourceCostingToolStripMenuItem);

        }
        private T FindParent<T>(Control control) where T : Control
        { //for accessing the parent control
            Control parent = control.Parent;
            while (parent != null)
            {
                if (parent is T typedParent)
                {
                    return typedParent;
                }
                parent = parent.Parent;
            }
            return null;
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

        private void resourceAllocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Controls.Add(new ResourceAllocationUserControl());
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
    }
}
