namespace ProjectEstimationTool
{
    partial class EffortTypeUserControl
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgv1 = new DataGridView();
            EffortIds = new DataGridViewTextBoxColumn();
            projectIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            EffortName = new DataGridViewTextBoxColumn();
            ActualEffort = new DataGridViewTextBoxColumn();
            Ba = new DataGridViewTextBoxColumn();
            Dev = new DataGridViewTextBoxColumn();
            Qa = new DataGridViewTextBoxColumn();
            projectDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            effortTypeBindingSource = new BindingSource(components);
            label1 = new Label();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)effortTypeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgv1
            // 
            dgv1.AutoGenerateColumns = false;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv1.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.RosyBrown;
            dataGridViewCellStyle1.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv1.Columns.AddRange(new DataGridViewColumn[] { EffortIds, projectIdDataGridViewTextBoxColumn, EffortName, ActualEffort, Ba, Dev, Qa, projectDataGridViewTextBoxColumn, dataGridViewTextBoxColumn1 });
            dgv1.DataSource = effortTypeBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv1.DefaultCellStyle = dataGridViewCellStyle2;
            dgv1.EnableHeadersVisualStyles = false;
            dgv1.Location = new Point(118, 61);
            dgv1.Margin = new Padding(3, 4, 3, 4);
            dgv1.Name = "dgv1";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.RosyBrown;
            dataGridViewCellStyle3.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgv1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv1.RowHeadersVisible = false;
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.Size = new Size(1154, 265);
            dgv1.TabIndex = 0;
            dgv1.CellClick += dgv1_CellClick;
            dgv1.CellContentClick += dataGridView1_CellContentClick;
            dgv1.CellEndEdit += dgv1_CellEndEdit;
            dgv1.CellValidating += dgv1_CellValidating;
            dgv1.DataError += dgv1_DataError;
            dgv1.KeyDown += dgv1_KeyDown;
            // 
            // EffortIds
            // 
            EffortIds.DataPropertyName = "EffortId";
            EffortIds.HeaderText = "EffortId";
            EffortIds.Name = "EffortIds";
            EffortIds.Visible = false;
            // 
            // projectIdDataGridViewTextBoxColumn
            // 
            projectIdDataGridViewTextBoxColumn.DataPropertyName = "ProjectId";
            projectIdDataGridViewTextBoxColumn.HeaderText = "ProjectId";
            projectIdDataGridViewTextBoxColumn.Name = "projectIdDataGridViewTextBoxColumn";
            projectIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // EffortName
            // 
            EffortName.DataPropertyName = "EffortName";
            EffortName.HeaderText = "Effort Type";
            EffortName.Name = "EffortName";
            // 
            // ActualEffort
            // 
            ActualEffort.DataPropertyName = "ActualEffort";
            ActualEffort.HeaderText = "Actual Effort";
            ActualEffort.Name = "ActualEffort";
            // 
            // Ba
            // 
            Ba.DataPropertyName = "Ba";
            Ba.HeaderText = "Ba";
            Ba.Name = "Ba";
            // 
            // Dev
            // 
            Dev.DataPropertyName = "Dev";
            Dev.HeaderText = "Dev";
            Dev.Name = "Dev";
            // 
            // Qa
            // 
            Qa.DataPropertyName = "Qa";
            Qa.HeaderText = "Qa";
            Qa.Name = "Qa";
            // 
            // projectDataGridViewTextBoxColumn
            // 
            projectDataGridViewTextBoxColumn.DataPropertyName = "Project";
            projectDataGridViewTextBoxColumn.HeaderText = "Project";
            projectDataGridViewTextBoxColumn.Name = "projectDataGridViewTextBoxColumn";
            projectDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "ScopeAndEffort";
            dataGridViewTextBoxColumn1.HeaderText = "ScopeAndEffort";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Visible = false;
            // 
            // effortTypeBindingSource
            // 
            effortTypeBindingSource.DataSource = typeof(Models.EffortType);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightBlue;
            label1.Font = new Font("Palatino Linotype", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(328, 14);
            label1.Name = "label1";
            label1.Size = new Size(709, 37);
            label1.TabIndex = 4;
            label1.Text = "Configure Effort Type, Actual Effort, BA%, Dev%, QA%";
            // 
            // button6
            // 
            button6.BackColor = Color.RosyBrown;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(1284, 2);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(77, 28);
            button6.TabIndex = 31;
            button6.Text = "Next";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // EffortTypeUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button6);
            Controls.Add(label1);
            Controls.Add(dgv1);
            Font = new Font("Palatino Linotype", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EffortTypeUserControl";
            Size = new Size(1363, 687);
            Load += EffortTypeUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
            ((System.ComponentModel.ISupportInitialize)effortTypeBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv1;
        private DataGridViewTextBoxColumn scopeAndEffortDataGridViewTextBoxColumn;
        private Label label1;
        private Button button6;
        private DataGridViewTextBoxColumn EffortIds;
        private DataGridViewTextBoxColumn projectIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn EffortName;
        private DataGridViewTextBoxColumn ActualEffort;
        private DataGridViewTextBoxColumn Ba;
        private DataGridViewTextBoxColumn Dev;
        private DataGridViewTextBoxColumn Qa;
        private DataGridViewTextBoxColumn Rules;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private BindingSource effortTypeBindingSource;
    }
}
