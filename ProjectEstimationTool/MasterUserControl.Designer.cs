namespace ProjectEstimationTool
{
    partial class MasterUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            panel4 = new Panel();
            panel3 = new Panel();
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            configurationsToolStripMenuItem = new ToolStripMenuItem();
            effortToolStripMenuItem = new ToolStripMenuItem();
            productivityToolStripMenuItem = new ToolStripMenuItem();
            functionalAreaToolStripMenuItem = new ToolStripMenuItem();
            functionalSubAreaToolStripMenuItem = new ToolStripMenuItem();
            countryToolStripMenuItem = new ToolStripMenuItem();
            resourceTypeToolStripMenuItem = new ToolStripMenuItem();
            resourceLevelToolStripMenuItem = new ToolStripMenuItem();
            resourceRateToolStripMenuItem = new ToolStripMenuItem();
            softwareRateToolStripMenuItem = new ToolStripMenuItem();
            scopeEffortToolStripMenuItem = new ToolStripMenuItem();
            timelineToolStripMenuItem = new ToolStripMenuItem();
            resourceCostingToolStripMenuItem = new ToolStripMenuItem();
            summaryToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1366, 741);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = Color.RosyBrown;
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1366, 741);
            panel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.LightBlue;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Location = new Point(1087, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(279, 48);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightBlue;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(4, 1);
            label1.Name = "label1";
            label1.Size = new Size(271, 46);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Location = new Point(-1, 47);
            panel4.Name = "panel4";
            panel4.Size = new Size(1367, 694);
            panel4.TabIndex = 3;
            panel4.Paint += panel4_Paint_1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.RosyBrown;
            panel3.Controls.Add(menuStrip1);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1084, 45);
            panel3.TabIndex = 3;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.RosyBrown;
            menuStrip1.Dock = DockStyle.Fill;
            menuStrip1.Font = new Font("Palatino Linotype", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, configurationsToolStripMenuItem, scopeEffortToolStripMenuItem, timelineToolStripMenuItem, resourceCostingToolStripMenuItem, summaryToolStripMenuItem, toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5 });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1084, 45);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(92, 41);
            homeToolStripMenuItem.Text = "Home";
            homeToolStripMenuItem.Click += homeToolStripMenuItem_Click_1;
            // 
            // configurationsToolStripMenuItem
            // 
            configurationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { effortToolStripMenuItem, productivityToolStripMenuItem, functionalAreaToolStripMenuItem, functionalSubAreaToolStripMenuItem, countryToolStripMenuItem, resourceTypeToolStripMenuItem, resourceLevelToolStripMenuItem, resourceRateToolStripMenuItem, softwareRateToolStripMenuItem });
            configurationsToolStripMenuItem.Font = new Font("Palatino Linotype", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            configurationsToolStripMenuItem.Name = "configurationsToolStripMenuItem";
            configurationsToolStripMenuItem.Size = new Size(189, 41);
            configurationsToolStripMenuItem.Text = "Configurations";
            configurationsToolStripMenuItem.Click += configurationsToolStripMenuItem_Click_2;
            // 
            // effortToolStripMenuItem
            // 
            effortToolStripMenuItem.Name = "effortToolStripMenuItem";
            effortToolStripMenuItem.Size = new Size(314, 36);
            effortToolStripMenuItem.Text = "Effort Type";
            effortToolStripMenuItem.Click += effortToolStripMenuItem_Click_2;
            // 
            // productivityToolStripMenuItem
            // 
            productivityToolStripMenuItem.Name = "productivityToolStripMenuItem";
            productivityToolStripMenuItem.Size = new Size(314, 36);
            productivityToolStripMenuItem.Text = "Productivity";
            productivityToolStripMenuItem.Click += productivityToolStripMenuItem_Click_2;
            // 
            // functionalAreaToolStripMenuItem
            // 
            functionalAreaToolStripMenuItem.Name = "functionalAreaToolStripMenuItem";
            functionalAreaToolStripMenuItem.Size = new Size(314, 36);
            functionalAreaToolStripMenuItem.Text = "Functional Area";
            functionalAreaToolStripMenuItem.Click += functionalAreaToolStripMenuItem_Click_2;
            // 
            // functionalSubAreaToolStripMenuItem
            // 
            functionalSubAreaToolStripMenuItem.Name = "functionalSubAreaToolStripMenuItem";
            functionalSubAreaToolStripMenuItem.Size = new Size(314, 36);
            functionalSubAreaToolStripMenuItem.Text = "Functional Sub-Area";
            functionalSubAreaToolStripMenuItem.Click += functionalSubAreaToolStripMenuItem_Click_2;
            // 
            // countryToolStripMenuItem
            // 
            countryToolStripMenuItem.Name = "countryToolStripMenuItem";
            countryToolStripMenuItem.Size = new Size(314, 36);
            countryToolStripMenuItem.Text = "Country";
            countryToolStripMenuItem.Click += countryToolStripMenuItem_Click_2;
            // 
            // resourceTypeToolStripMenuItem
            // 
            resourceTypeToolStripMenuItem.Name = "resourceTypeToolStripMenuItem";
            resourceTypeToolStripMenuItem.Size = new Size(314, 36);
            resourceTypeToolStripMenuItem.Text = "Resource Type";
            resourceTypeToolStripMenuItem.Click += resourceTypeToolStripMenuItem_Click_2;
            // 
            // resourceLevelToolStripMenuItem
            // 
            resourceLevelToolStripMenuItem.Name = "resourceLevelToolStripMenuItem";
            resourceLevelToolStripMenuItem.Size = new Size(314, 36);
            resourceLevelToolStripMenuItem.Text = "Resource Level";
            resourceLevelToolStripMenuItem.Click += resourceLevelToolStripMenuItem_Click_2;
            // 
            // resourceRateToolStripMenuItem
            // 
            resourceRateToolStripMenuItem.Name = "resourceRateToolStripMenuItem";
            resourceRateToolStripMenuItem.Size = new Size(314, 36);
            resourceRateToolStripMenuItem.Text = "Resource Rate";
            resourceRateToolStripMenuItem.Click += resourceRateToolStripMenuItem_Click_2;
            // 
            // softwareRateToolStripMenuItem
            // 
            softwareRateToolStripMenuItem.Name = "softwareRateToolStripMenuItem";
            softwareRateToolStripMenuItem.Size = new Size(314, 36);
            softwareRateToolStripMenuItem.Text = "Software Rate";
            softwareRateToolStripMenuItem.Click += softwareRateToolStripMenuItem_Click_2;
            // 
            // scopeEffortToolStripMenuItem
            // 
            scopeEffortToolStripMenuItem.Name = "scopeEffortToolStripMenuItem";
            scopeEffortToolStripMenuItem.Size = new Size(184, 41);
            scopeEffortToolStripMenuItem.Text = "Scope && Effort";
            scopeEffortToolStripMenuItem.Click += scopeEffortToolStripMenuItem_Click_1;
            // 
            // timelineToolStripMenuItem
            // 
            timelineToolStripMenuItem.Name = "timelineToolStripMenuItem";
            timelineToolStripMenuItem.Size = new Size(123, 41);
            timelineToolStripMenuItem.Text = "Timeline";
            timelineToolStripMenuItem.Click += timelineToolStripMenuItem_Click_1;
            // 
            // resourceCostingToolStripMenuItem
            // 
            resourceCostingToolStripMenuItem.Font = new Font("Palatino Linotype", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            resourceCostingToolStripMenuItem.Name = "resourceCostingToolStripMenuItem";
            resourceCostingToolStripMenuItem.RightToLeft = RightToLeft.No;
            resourceCostingToolStripMenuItem.Size = new Size(216, 41);
            resourceCostingToolStripMenuItem.Text = "Resource Costing";
            resourceCostingToolStripMenuItem.Click += resourceCostingToolStripMenuItem_Click_1;
            // 
            // summaryToolStripMenuItem
            // 
            summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            summaryToolStripMenuItem.Size = new Size(132, 41);
            summaryToolStripMenuItem.Text = "Summary";
            summaryToolStripMenuItem.Click += summaryToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(12, 41);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(12, 41);
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Checked = true;
            toolStripMenuItem3.CheckState = CheckState.Indeterminate;
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(12, 41);
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(12, 41);
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(12, 41);
            // 
            // MasterUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "MasterUserControl";
            Size = new Size(1366, 741);
            Load += MasterUserControl_Load;
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem configurationsToolStripMenuItem;
        private ToolStripMenuItem effortToolStripMenuItem;
        private ToolStripMenuItem productivityToolStripMenuItem;
        private ToolStripMenuItem functionalAreaToolStripMenuItem;
        private ToolStripMenuItem functionalSubAreaToolStripMenuItem;
        private ToolStripMenuItem countryToolStripMenuItem;
        private ToolStripMenuItem resourceTypeToolStripMenuItem;
        private ToolStripMenuItem resourceLevelToolStripMenuItem;
        private ToolStripMenuItem resourceRateToolStripMenuItem;
        private ToolStripMenuItem softwareRateToolStripMenuItem;
        private ToolStripMenuItem scopeEffortToolStripMenuItem;
        private ToolStripMenuItem timelineToolStripMenuItem;
        private ToolStripMenuItem resourceCostingToolStripMenuItem;
        private ToolStripMenuItem summaryToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
    }
}
