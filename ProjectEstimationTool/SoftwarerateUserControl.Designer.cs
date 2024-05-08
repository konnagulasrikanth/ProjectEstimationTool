namespace ProjectEstimationTool
{
    partial class SoftwarerateUserControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            SoftwareIds = new DataGridViewTextBoxColumn();
            projectIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            SoftwareName = new DataGridViewTextBoxColumn();
            MonthlyRate = new DataGridViewTextBoxColumn();
            projectDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            softwareBindingSource1 = new BindingSource(components);
            SoftwareId = new DataGridViewTextBoxColumn();
            ProjectId = new DataGridViewTextBoxColumn();
            label7 = new Label();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)softwareBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.RosyBrown;
            dataGridViewCellStyle1.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { SoftwareIds, projectIdDataGridViewTextBoxColumn, SoftwareName, MonthlyRate, projectDataGridViewTextBoxColumn });
            dataGridView1.DataSource = softwareBindingSource1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(324, 49);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(777, 204);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            dataGridView1.CellParsing += dataGridView1_CellParsing;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            // 
            // SoftwareIds
            // 
            SoftwareIds.DataPropertyName = "SoftwareId";
            SoftwareIds.HeaderText = "SoftwareId";
            SoftwareIds.Name = "SoftwareIds";
            SoftwareIds.Visible = false;
            // 
            // projectIdDataGridViewTextBoxColumn
            // 
            projectIdDataGridViewTextBoxColumn.DataPropertyName = "ProjectId";
            projectIdDataGridViewTextBoxColumn.HeaderText = "ProjectId";
            projectIdDataGridViewTextBoxColumn.Name = "projectIdDataGridViewTextBoxColumn";
            projectIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // SoftwareName
            // 
            SoftwareName.DataPropertyName = "SoftwareName";
            SoftwareName.HeaderText = "SoftwareName";
            SoftwareName.Name = "SoftwareName";
            // 
            // MonthlyRate
            // 
            MonthlyRate.DataPropertyName = "MonthlyRate";
            MonthlyRate.HeaderText = "MonthlyRate";
            MonthlyRate.Name = "MonthlyRate";
            // 
            // projectDataGridViewTextBoxColumn
            // 
            projectDataGridViewTextBoxColumn.DataPropertyName = "Project";
            projectDataGridViewTextBoxColumn.HeaderText = "Project";
            projectDataGridViewTextBoxColumn.Name = "projectDataGridViewTextBoxColumn";
            projectDataGridViewTextBoxColumn.Visible = false;
            // 
            // softwareBindingSource1
            // 
            softwareBindingSource1.DataSource = typeof(Models.Software);
            // 
            // SoftwareId
            // 
            SoftwareId.DataPropertyName = "SoftwareId";
            SoftwareId.HeaderText = "SoftwareId";
            SoftwareId.Name = "SoftwareId";
            // 
            // ProjectId
            // 
            ProjectId.DataPropertyName = "ProjectId";
            ProjectId.HeaderText = "ProjectId";
            ProjectId.Name = "ProjectId";
            ProjectId.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.LightBlue;
            label7.Font = new Font("Palatino Linotype", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(507, 9);
            label7.Name = "label7";
            label7.Size = new Size(448, 37);
            label7.TabIndex = 7;
            label7.Text = "Configure Software, Monthly Rate";
            // 
            // button6
            // 
            button6.BackColor = Color.RosyBrown;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button6.Location = new Point(1211, 3);
            button6.Name = "button6";
            button6.Size = new Size(71, 23);
            button6.TabIndex = 8;
            button6.Text = "Previous";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // SoftwarerateUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button6);
            Controls.Add(label7);
            Controls.Add(dataGridView1);
            Name = "SoftwarerateUserControl";
            Size = new Size(1366, 708);
            Load += SoftwarerateUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)softwareBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn SoftwareId;
        private DataGridViewTextBoxColumn ProjectId;
        private Label label7;
        private Button button6;
        private DataGridViewTextBoxColumn SoftwareIds;
        private DataGridViewTextBoxColumn projectIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn SoftwareName;
        private DataGridViewTextBoxColumn MonthlyRate;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn softwareCostingDataGridViewTextBoxColumn;
        private BindingSource softwareBindingSource1;
    }
}
