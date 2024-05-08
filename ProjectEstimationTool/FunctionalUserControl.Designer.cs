namespace ProjectEstimationTool
{
    partial class FunctionalUserControl
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
            label3 = new Label();
            button6 = new Button();
            button7 = new Button();
            dataGridView2 = new DataGridView();
            FunctionalAreaIdss = new DataGridViewTextBoxColumn();
            projectIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            functionalAreaNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            FunctionalSubAreaName = new DataGridViewTextBoxColumn();
            projectDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            scopeAndEffortDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            functionalAreaBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)functionalAreaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightBlue;
            label3.Font = new Font("Palatino Linotype", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(306, 37);
            label3.Name = "label3";
            label3.Size = new Size(649, 37);
            label3.TabIndex = 4;
            label3.Text = "Configure Functional Area && Functional Sub-Area";
            label3.Click += label3_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.RosyBrown;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button6.Location = new Point(1210, 5);
            button6.Name = "button6";
            button6.Size = new Size(75, 34);
            button6.TabIndex = 5;
            button6.Text = "Previous";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.RosyBrown;
            button7.FlatStyle = FlatStyle.Popup;
            button7.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button7.Location = new Point(1287, 5);
            button7.Name = "button7";
            button7.Size = new Size(75, 34);
            button7.TabIndex = 6;
            button7.Text = "Next";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.RosyBrown;
            dataGridViewCellStyle1.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle1.SelectionForeColor = Color.RosyBrown;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { FunctionalAreaIdss, projectIdDataGridViewTextBoxColumn, functionalAreaNameDataGridViewTextBoxColumn, FunctionalSubAreaName, projectDataGridViewTextBoxColumn, scopeAndEffortDataGridViewTextBoxColumn });
            dataGridView2.DataSource = functionalAreaBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.Location = new Point(342, 101);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.Size = new Size(559, 205);
            dataGridView2.TabIndex = 7;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            dataGridView2.CellEndEdit += dataGridView2_CellEndEdit;
            dataGridView2.CellValidating += dataGridView2_CellValidating;
            dataGridView2.KeyDown += dataGridView2_KeyDown;
            // 
            // FunctionalAreaIdss
            // 
            FunctionalAreaIdss.DataPropertyName = "FunctionalAreaId";
            FunctionalAreaIdss.HeaderText = "FunctionalAreaId";
            FunctionalAreaIdss.Name = "FunctionalAreaIdss";
            FunctionalAreaIdss.Visible = false;
            // 
            // projectIdDataGridViewTextBoxColumn
            // 
            projectIdDataGridViewTextBoxColumn.DataPropertyName = "ProjectId";
            projectIdDataGridViewTextBoxColumn.HeaderText = "ProjectId";
            projectIdDataGridViewTextBoxColumn.Name = "projectIdDataGridViewTextBoxColumn";
            projectIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // functionalAreaNameDataGridViewTextBoxColumn
            // 
            functionalAreaNameDataGridViewTextBoxColumn.DataPropertyName = "FunctionalAreaName";
            functionalAreaNameDataGridViewTextBoxColumn.HeaderText = "Functional Area";
            functionalAreaNameDataGridViewTextBoxColumn.Name = "functionalAreaNameDataGridViewTextBoxColumn";
            // 
            // FunctionalSubAreaName
            // 
            FunctionalSubAreaName.DataPropertyName = "FunctionalSubAreaName";
            FunctionalSubAreaName.HeaderText = "Functional Sub-Area";
            FunctionalSubAreaName.Name = "FunctionalSubAreaName";
            // 
            // projectDataGridViewTextBoxColumn
            // 
            projectDataGridViewTextBoxColumn.DataPropertyName = "Project";
            projectDataGridViewTextBoxColumn.HeaderText = "Project";
            projectDataGridViewTextBoxColumn.Name = "projectDataGridViewTextBoxColumn";
            projectDataGridViewTextBoxColumn.Visible = false;
            // 
            // scopeAndEffortDataGridViewTextBoxColumn
            // 
            scopeAndEffortDataGridViewTextBoxColumn.DataPropertyName = "ScopeAndEffort";
            scopeAndEffortDataGridViewTextBoxColumn.HeaderText = "ScopeAndEffort";
            scopeAndEffortDataGridViewTextBoxColumn.Name = "scopeAndEffortDataGridViewTextBoxColumn";
            scopeAndEffortDataGridViewTextBoxColumn.Visible = false;
            // 
            // functionalAreaBindingSource
            // 
            functionalAreaBindingSource.DataSource = typeof(Models.FunctionalArea);
            // 
            // FunctionalUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dataGridView2);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label3);
            Name = "FunctionalUserControl";
            Size = new Size(1363, 687);
            Load += FunctionalUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)functionalAreaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Button button6;
        private Button button7;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn FunctionalAreaIdss;
        private DataGridViewTextBoxColumn projectIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn functionalAreaNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn FunctionalSubAreaName;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn scopeAndEffortDataGridViewTextBoxColumn;
        private BindingSource functionalAreaBindingSource;
    }
}
