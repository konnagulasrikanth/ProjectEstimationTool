namespace ProjectEstimationTool
{
    partial class Timeline
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            button9 = new Button();
            button10 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            TimelineId = new DataGridViewTextBoxColumn();
            Phasename = new DataGridViewTextBoxColumn();
            EffHrs = new DataGridViewTextBoxColumn();
            ResReq = new DataGridViewTextBoxColumn();
            Mmname = new DataGridViewTextBoxColumn();
            Lagname = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            resourceCostingDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            projectIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            timelineBindingSource = new BindingSource(components);
            button1 = new Button();
            panel1 = new Panel();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button2 = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timelineBindingSource).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightBlue;
            label1.Font = new Font("Palatino Linotype", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(597, 13);
            label1.Name = "label1";
            label1.Size = new Size(131, 37);
            label1.TabIndex = 0;
            label1.Text = "Timeline";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.LightBlue;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(169, 32);
            label6.Name = "label6";
            label6.Size = new Size(159, 31);
            label6.TabIndex = 1;
            label6.Text = "label6";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.LightBlue;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(169, 1);
            label5.Name = "label5";
            label5.Size = new Size(159, 30);
            label5.TabIndex = 0;
            label5.Text = "label5";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LightBlue;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(4, 32);
            label4.Name = "label4";
            label4.Size = new Size(158, 31);
            label4.TabIndex = 1;
            label4.Text = "Duration in Weeks";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(4, 1);
            label3.Name = "label3";
            label3.Size = new Size(158, 30);
            label3.TabIndex = 0;
            label3.Text = "Total Hours";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.RosyBrown;
            button9.FlatStyle = FlatStyle.Popup;
            button9.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button9.Location = new Point(1285, 3);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 8;
            button9.Text = "Next";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.RosyBrown;
            button10.FlatStyle = FlatStyle.Popup;
            button10.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button10.Location = new Point(1195, 3);
            button10.Name = "button10";
            button10.Size = new Size(75, 23);
            button10.TabIndex = 9;
            button10.Text = "Previous";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.LightBlue;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(label6, 1, 1);
            tableLayoutPanel1.Controls.Add(label5, 1, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 1);
            tableLayoutPanel1.Location = new Point(18, 80);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(332, 64);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightBlue;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Arial", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 55);
            label2.Name = "label2";
            label2.Size = new Size(332, 26);
            label2.TabIndex = 0;
            label2.Text = "Implementation Timeline && Efforts";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.RosyBrown;
            dataGridViewCellStyle3.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { TimelineId, Phasename, EffHrs, ResReq, Mmname, Lagname, dataGridViewTextBoxColumn1, resourceCostingDataGridViewTextBoxColumn, projectIdDataGridViewTextBoxColumn });
            dataGridView1.DataSource = timelineBindingSource;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(17, 161);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1343, 289);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            // 
            // TimelineId
            // 
            TimelineId.DataPropertyName = "TimelineId";
            TimelineId.HeaderText = "TimelineId";
            TimelineId.Name = "TimelineId";
            TimelineId.Visible = false;
            // 
            // Phasename
            // 
            Phasename.DataPropertyName = "Phase";
            Phasename.HeaderText = "Phase";
            Phasename.Name = "Phasename";
            Phasename.Resizable = DataGridViewTriState.True;
            Phasename.Width = 160;
            // 
            // EffHrs
            // 
            EffHrs.DataPropertyName = "EffHrs";
            EffHrs.HeaderText = "EffHrs";
            EffHrs.Name = "EffHrs";
            EffHrs.Width = 60;
            // 
            // ResReq
            // 
            ResReq.DataPropertyName = "ResReq";
            ResReq.HeaderText = "ResReq";
            ResReq.Name = "ResReq";
            ResReq.Width = 60;
            // 
            // Mmname
            // 
            Mmname.DataPropertyName = "Mm";
            Mmname.HeaderText = "WK";
            Mmname.Name = "Mmname";
            Mmname.Width = 60;
            // 
            // Lagname
            // 
            Lagname.DataPropertyName = "Lag";
            Lagname.HeaderText = "Lag";
            Lagname.Name = "Lagname";
            Lagname.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Project";
            dataGridViewTextBoxColumn1.HeaderText = "Project";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Visible = false;
            // 
            // resourceCostingDataGridViewTextBoxColumn
            // 
            resourceCostingDataGridViewTextBoxColumn.DataPropertyName = "ResourceCosting";
            resourceCostingDataGridViewTextBoxColumn.HeaderText = "ResourceCosting";
            resourceCostingDataGridViewTextBoxColumn.Name = "resourceCostingDataGridViewTextBoxColumn";
            resourceCostingDataGridViewTextBoxColumn.Visible = false;
            // 
            // projectIdDataGridViewTextBoxColumn
            // 
            projectIdDataGridViewTextBoxColumn.DataPropertyName = "ProjectId";
            projectIdDataGridViewTextBoxColumn.HeaderText = "ProjectId";
            projectIdDataGridViewTextBoxColumn.Name = "projectIdDataGridViewTextBoxColumn";
            projectIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // timelineBindingSource
            // 
            timelineBindingSource.DataSource = typeof(Models.Timeline);
            // 
            // button1
            // 
            button1.Location = new Point(22, 478);
            button1.Name = "button1";
            button1.Size = new Size(90, 23);
            button1.TabIndex = 12;
            button1.Text = "Demo Dates";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(168, 478);
            panel1.Name = "panel1";
            panel1.Size = new Size(299, 159);
            panel1.TabIndex = 13;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(107, 29);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(107, 74);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(118, 112);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Submit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Timeline
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(label1);
            Name = "Timeline";
            Size = new Size(1363, 708);
            Load += Timeline_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)timelineBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private DataGridViewTextBoxColumn demoDateDataGridViewTextBoxColumn;
        private Button button9;
        private Button button10;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private DataGridViewTextBoxColumn Functionality;
        private DataGridViewTextBoxColumn WK;
        private DataGridView dataGridView1;
        private BindingSource timelineBindingSource;
        private DataGridViewTextBoxColumn TimelineId;
        private DataGridViewTextBoxColumn Phasename;
        private DataGridViewTextBoxColumn EffHrs;
        private DataGridViewTextBoxColumn ResReq;
        private DataGridViewTextBoxColumn Mmname;
        private DataGridViewTextBoxColumn Lagname;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn resourceCostingDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn projectIdDataGridViewTextBoxColumn;
        private Button button1;
        private Panel panel1;
        private Button button2;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}
