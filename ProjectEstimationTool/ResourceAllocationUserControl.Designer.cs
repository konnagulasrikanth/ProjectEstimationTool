namespace ProjectEstimationTool
{
    partial class ResourceAllocationUserControl
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
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            resourceAllocationBindingSource = new BindingSource(components);
            button1 = new Button();
            button2 = new Button();
            resourceAllocationIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            projectIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            timelineIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            functionalityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Phase = new DataGridViewTextBoxColumn();
            EffHrs = new DataGridViewTextBoxColumn();
            ResReq = new DataGridViewTextBoxColumn();
            Mm = new DataGridViewTextBoxColumn();
            ResourceAllocated = new DataGridViewTextBoxColumn();
            ResourcePending = new DataGridViewTextBoxColumn();
            projectDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Timeline = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resourceAllocationBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(479, 35);
            label1.Name = "label1";
            label1.Size = new Size(293, 34);
            label1.TabIndex = 0;
            label1.Text = "Resource Allocation";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { resourceAllocationIdDataGridViewTextBoxColumn, projectIdDataGridViewTextBoxColumn, timelineIdDataGridViewTextBoxColumn, functionalityDataGridViewTextBoxColumn, Phase, EffHrs, ResReq, Mm, ResourceAllocated, ResourcePending, projectDataGridViewTextBoxColumn, Timeline });
            dataGridView1.DataSource = resourceAllocationBindingSource;
            dataGridView1.Location = new Point(55, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dataGridView1.Size = new Size(1270, 150);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // resourceAllocationBindingSource
            // 
            resourceAllocationBindingSource.DataSource = typeof(Models.ResourceAllocation);
            // 
            // button1
            // 
            button1.Location = new Point(55, 397);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Previous";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1250, 397);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Next";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // resourceAllocationIdDataGridViewTextBoxColumn
            // 
            resourceAllocationIdDataGridViewTextBoxColumn.DataPropertyName = "ResourceAllocationId";
            resourceAllocationIdDataGridViewTextBoxColumn.HeaderText = "ResourceAllocationId";
            resourceAllocationIdDataGridViewTextBoxColumn.Name = "resourceAllocationIdDataGridViewTextBoxColumn";
            resourceAllocationIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // projectIdDataGridViewTextBoxColumn
            // 
            projectIdDataGridViewTextBoxColumn.DataPropertyName = "ProjectId";
            projectIdDataGridViewTextBoxColumn.HeaderText = "ProjectId";
            projectIdDataGridViewTextBoxColumn.Name = "projectIdDataGridViewTextBoxColumn";
            projectIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // timelineIdDataGridViewTextBoxColumn
            // 
            timelineIdDataGridViewTextBoxColumn.DataPropertyName = "TimelineId";
            timelineIdDataGridViewTextBoxColumn.HeaderText = "TimelineId";
            timelineIdDataGridViewTextBoxColumn.Name = "timelineIdDataGridViewTextBoxColumn";
            timelineIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // functionalityDataGridViewTextBoxColumn
            // 
            functionalityDataGridViewTextBoxColumn.DataPropertyName = "Functionality";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            functionalityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            functionalityDataGridViewTextBoxColumn.HeaderText = "Functionality";
            functionalityDataGridViewTextBoxColumn.Name = "functionalityDataGridViewTextBoxColumn";
            functionalityDataGridViewTextBoxColumn.Visible = false;
            // 
            // Phase
            // 
            Phase.DataPropertyName = "Phase";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Phase.DefaultCellStyle = dataGridViewCellStyle3;
            Phase.HeaderText = "Phase";
            Phase.Name = "Phase";
            // 
            // EffHrs
            // 
            EffHrs.DataPropertyName = "EffHrs";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EffHrs.DefaultCellStyle = dataGridViewCellStyle4;
            EffHrs.HeaderText = "Effort Hours";
            EffHrs.Name = "EffHrs";
            // 
            // ResReq
            // 
            ResReq.DataPropertyName = "ResReq";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(192, 255, 255);
            ResReq.DefaultCellStyle = dataGridViewCellStyle5;
            ResReq.HeaderText = "Res. Required";
            ResReq.Name = "ResReq";
            // 
            // Mm
            // 
            Mm.DataPropertyName = "Mm";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Mm.DefaultCellStyle = dataGridViewCellStyle6;
            Mm.HeaderText = "Mm";
            Mm.Name = "Mm";
            // 
            // ResourceAllocated
            // 
            ResourceAllocated.DataPropertyName = "ResourceAllocated";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.PaleGreen;
            ResourceAllocated.DefaultCellStyle = dataGridViewCellStyle7;
            ResourceAllocated.HeaderText = "Resource Currently Allocated";
            ResourceAllocated.Name = "ResourceAllocated";
            // 
            // ResourcePending
            // 
            ResourcePending.DataPropertyName = "ResourcePending";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(255, 128, 128);
            ResourcePending.DefaultCellStyle = dataGridViewCellStyle8;
            ResourcePending.HeaderText = "Resource Allocation Pending";
            ResourcePending.Name = "ResourcePending";
            // 
            // projectDataGridViewTextBoxColumn
            // 
            projectDataGridViewTextBoxColumn.DataPropertyName = "Project";
            projectDataGridViewTextBoxColumn.HeaderText = "Project";
            projectDataGridViewTextBoxColumn.Name = "projectDataGridViewTextBoxColumn";
            projectDataGridViewTextBoxColumn.Visible = false;
            // 
            // Timeline
            // 
            Timeline.DataPropertyName = "Timeline";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Timeline.DefaultCellStyle = dataGridViewCellStyle9;
            Timeline.HeaderText = "Timeline";
            Timeline.Name = "Timeline";
            Timeline.Visible = false;
            // 
            // ResourceAllocationUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "ResourceAllocationUserControl";
            Size = new Size(1363, 708);
            Load += ResourceAllocationUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)resourceAllocationBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private BindingSource resourceAllocationBindingSource;
        private Button button1;
        private Button button2;
        private DataGridViewTextBoxColumn resourceAllocationIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn projectIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn timelineIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn functionalityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Phase;
        private DataGridViewTextBoxColumn EffHrs;
        private DataGridViewTextBoxColumn ResReq;
        private DataGridViewTextBoxColumn Mm;
        private DataGridViewTextBoxColumn ResourceAllocated;
        private DataGridViewTextBoxColumn ResourcePending;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Timeline;
    }
}
