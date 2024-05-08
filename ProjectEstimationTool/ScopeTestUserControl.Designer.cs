namespace ProjectEstimationTool
{
    partial class ScopeTestUserControl
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            ScopeAndEffortId = new DataGridViewTextBoxColumn();
            projectIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            FunctionalAreaName = new DataGridViewComboBoxColumn();
            FunctionalSubAreaName = new DataGridViewComboBoxColumn();
            EffortName = new DataGridViewComboBoxColumn();
            NumberOfOperations = new DataGridViewTextBoxColumn();
            Effort = new DataGridViewTextBoxColumn();
            BaHrs = new DataGridViewTextBoxColumn();
            BarefactorPercentage = new DataGridViewTextBoxColumn();
            BafinalHrs = new DataGridViewTextBoxColumn();
            DevHrs = new DataGridViewTextBoxColumn();
            DevRefactorPercentage = new DataGridViewTextBoxColumn();
            DevFinalHrs = new DataGridViewTextBoxColumn();
            QaHrs = new DataGridViewTextBoxColumn();
            QarefactorPercentage = new DataGridViewTextBoxColumn();
            QafinalHrs = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            effortIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            functionalAreaIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            effortNavigationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            functionalAreaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            projectDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            scopeAndEffortBindingSource = new BindingSource(components);
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scopeAndEffortBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.RosyBrown;
            dataGridViewCellStyle1.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ScopeAndEffortId, projectIdDataGridViewTextBoxColumn, FunctionalAreaName, FunctionalSubAreaName, EffortName, NumberOfOperations, Effort, BaHrs, BarefactorPercentage, BafinalHrs, DevHrs, DevRefactorPercentage, DevFinalHrs, QaHrs, QarefactorPercentage, QafinalHrs, Description, effortIdDataGridViewTextBoxColumn, functionalAreaIdDataGridViewTextBoxColumn, effortNavigationDataGridViewTextBoxColumn, functionalAreaDataGridViewTextBoxColumn, projectDataGridViewTextBoxColumn });
            dataGridView1.DataSource = scopeAndEffortBindingSource;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(6, 60);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1357, 369);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            // 
            // ScopeAndEffortId
            // 
            ScopeAndEffortId.DataPropertyName = "ScopeAndEffortId";
            ScopeAndEffortId.HeaderText = "ScopeAndEffortId";
            ScopeAndEffortId.Name = "ScopeAndEffortId";
            ScopeAndEffortId.Visible = false;
            // 
            // projectIdDataGridViewTextBoxColumn
            // 
            projectIdDataGridViewTextBoxColumn.DataPropertyName = "ProjectId";
            projectIdDataGridViewTextBoxColumn.HeaderText = "ProjectId";
            projectIdDataGridViewTextBoxColumn.Name = "projectIdDataGridViewTextBoxColumn";
            projectIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // FunctionalAreaName
            // 
            FunctionalAreaName.DataPropertyName = "FunctionalAreaName";
            FunctionalAreaName.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            FunctionalAreaName.FlatStyle = FlatStyle.Popup;
            FunctionalAreaName.HeaderText = "Functional Area";
            FunctionalAreaName.Name = "FunctionalAreaName";
            FunctionalAreaName.Resizable = DataGridViewTriState.True;
            FunctionalAreaName.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // FunctionalSubAreaName
            // 
            FunctionalSubAreaName.DataPropertyName = "FunctionalSubAreaName";
            FunctionalSubAreaName.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            FunctionalSubAreaName.FlatStyle = FlatStyle.Popup;
            FunctionalSubAreaName.HeaderText = "Functional Sub-Area";
            FunctionalSubAreaName.Name = "FunctionalSubAreaName";
            FunctionalSubAreaName.Resizable = DataGridViewTriState.True;
            FunctionalSubAreaName.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // EffortName
            // 
            EffortName.DataPropertyName = "EffortName";
            EffortName.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            EffortName.FlatStyle = FlatStyle.Popup;
            EffortName.HeaderText = "Complexity";
            EffortName.Name = "EffortName";
            EffortName.Resizable = DataGridViewTriState.True;
            EffortName.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // NumberOfOperations
            // 
            NumberOfOperations.DataPropertyName = "NumberOfOperations";
            NumberOfOperations.HeaderText = "# Of Operations";
            NumberOfOperations.Name = "NumberOfOperations";
            // 
            // Effort
            // 
            Effort.DataPropertyName = "Effort";
            Effort.HeaderText = "Effort";
            Effort.Name = "Effort";
            // 
            // BaHrs
            // 
            BaHrs.DataPropertyName = "BaHrs";
            BaHrs.HeaderText = "BA Hrs.";
            BaHrs.Name = "BaHrs";
            // 
            // BarefactorPercentage
            // 
            BarefactorPercentage.DataPropertyName = "BarefactorPercentage";
            BarefactorPercentage.HeaderText = "BA Refactor %";
            BarefactorPercentage.Name = "BarefactorPercentage";
            // 
            // BafinalHrs
            // 
            BafinalHrs.DataPropertyName = "BafinalHrs";
            BafinalHrs.HeaderText = "BA Final Hrs.";
            BafinalHrs.Name = "BafinalHrs";
            // 
            // DevHrs
            // 
            DevHrs.DataPropertyName = "DevHrs";
            DevHrs.HeaderText = "DEV Hrs.";
            DevHrs.Name = "DevHrs";
            // 
            // DevRefactorPercentage
            // 
            DevRefactorPercentage.DataPropertyName = "DevRefactorPercentage";
            DevRefactorPercentage.HeaderText = "DEV Refactor %";
            DevRefactorPercentage.Name = "DevRefactorPercentage";
            // 
            // DevFinalHrs
            // 
            DevFinalHrs.DataPropertyName = "DevFinalHrs";
            DevFinalHrs.HeaderText = "DEV Final Hrs.";
            DevFinalHrs.Name = "DevFinalHrs";
            // 
            // QaHrs
            // 
            QaHrs.DataPropertyName = "QaHrs";
            QaHrs.HeaderText = "QA Hrs.";
            QaHrs.Name = "QaHrs";
            // 
            // QarefactorPercentage
            // 
            QarefactorPercentage.DataPropertyName = "QarefactorPercentage";
            QarefactorPercentage.HeaderText = "QA Refactor %";
            QarefactorPercentage.Name = "QarefactorPercentage";
            // 
            // QafinalHrs
            // 
            QafinalHrs.DataPropertyName = "QafinalHrs";
            QafinalHrs.HeaderText = "QA Final Hrs.";
            QafinalHrs.Name = "QafinalHrs";
            // 
            // Description
            // 
            Description.DataPropertyName = "Description";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            Description.DefaultCellStyle = dataGridViewCellStyle2;
            Description.HeaderText = "Description";
            Description.MaxInputLength = 500;
            Description.Name = "Description";
            // 
            // effortIdDataGridViewTextBoxColumn
            // 
            effortIdDataGridViewTextBoxColumn.DataPropertyName = "EffortId";
            effortIdDataGridViewTextBoxColumn.HeaderText = "EffortId";
            effortIdDataGridViewTextBoxColumn.Name = "effortIdDataGridViewTextBoxColumn";
            effortIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // functionalAreaIdDataGridViewTextBoxColumn
            // 
            functionalAreaIdDataGridViewTextBoxColumn.DataPropertyName = "FunctionalAreaId";
            functionalAreaIdDataGridViewTextBoxColumn.HeaderText = "FunctionalAreaId";
            functionalAreaIdDataGridViewTextBoxColumn.Name = "functionalAreaIdDataGridViewTextBoxColumn";
            functionalAreaIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // effortNavigationDataGridViewTextBoxColumn
            // 
            effortNavigationDataGridViewTextBoxColumn.DataPropertyName = "EffortNavigation";
            effortNavigationDataGridViewTextBoxColumn.HeaderText = "EffortNavigation";
            effortNavigationDataGridViewTextBoxColumn.Name = "effortNavigationDataGridViewTextBoxColumn";
            effortNavigationDataGridViewTextBoxColumn.Visible = false;
            // 
            // functionalAreaDataGridViewTextBoxColumn
            // 
            functionalAreaDataGridViewTextBoxColumn.DataPropertyName = "FunctionalArea";
            functionalAreaDataGridViewTextBoxColumn.HeaderText = "FunctionalArea";
            functionalAreaDataGridViewTextBoxColumn.Name = "functionalAreaDataGridViewTextBoxColumn";
            functionalAreaDataGridViewTextBoxColumn.Visible = false;
            // 
            // projectDataGridViewTextBoxColumn
            // 
            projectDataGridViewTextBoxColumn.DataPropertyName = "Project";
            projectDataGridViewTextBoxColumn.HeaderText = "Project";
            projectDataGridViewTextBoxColumn.Name = "projectDataGridViewTextBoxColumn";
            projectDataGridViewTextBoxColumn.Visible = false;
            // 
            // scopeAndEffortBindingSource
            // 
            scopeAndEffortBindingSource.DataSource = typeof(Models.ScopeAndEffort);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightBlue;
            label1.Font = new Font("Palatino Linotype", 20.25F, FontStyle.Bold);
            label1.Location = new Point(529, 20);
            label1.Name = "label1";
            label1.Size = new Size(224, 37);
            label1.TabIndex = 2;
            label1.Text = "Scope and Effort";
            // 
            // ScopeTestUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "ScopeTestUserControl";
            Size = new Size(1363, 704);
            Load += ScopeTestUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)scopeAndEffortBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource scopeAndEffortBindingSource;
        private Label label1;
        private DataGridViewTextBoxColumn ScopeAndEffortId;
        private DataGridViewTextBoxColumn projectIdDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn FunctionalAreaName;
        private DataGridViewComboBoxColumn FunctionalSubAreaName;
        private DataGridViewComboBoxColumn EffortName;
        private DataGridViewTextBoxColumn NumberOfOperations;
        private DataGridViewTextBoxColumn Effort;
        private DataGridViewTextBoxColumn BaHrs;
        private DataGridViewTextBoxColumn BarefactorPercentage;
        private DataGridViewTextBoxColumn BafinalHrs;
        private DataGridViewTextBoxColumn DevHrs;
        private DataGridViewTextBoxColumn DevRefactorPercentage;
        private DataGridViewTextBoxColumn DevFinalHrs;
        private DataGridViewTextBoxColumn QaHrs;
        private DataGridViewTextBoxColumn QarefactorPercentage;
        private DataGridViewTextBoxColumn QafinalHrs;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn effortIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn functionalAreaIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn effortNavigationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn functionalAreaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
    }
}
