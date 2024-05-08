namespace ProjectEstimationTool
{
    partial class ResourceRateUserControl
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
            dataGridView1 = new DataGridView();
            resourceBindingSource = new BindingSource(components);
            label9 = new Label();
            button6 = new Button();
            button7 = new Button();
            ResourceId = new DataGridViewTextBoxColumn();
            projectIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            countryIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            CountryNames = new DataGridViewComboBoxColumn();
            TypeNames = new DataGridViewComboBoxColumn();
            LevelNames = new DataGridViewComboBoxColumn();
            HourlyRate = new DataGridViewTextBoxColumn();
            resourceTypeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            levelIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            countryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            levelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            projectDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            resourceCostingDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            resourceTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resourceBindingSource).BeginInit();
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
            dataGridViewCellStyle1.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ResourceId, projectIdDataGridViewTextBoxColumn, countryIdDataGridViewTextBoxColumn, CountryNames, TypeNames, LevelNames, HourlyRate, resourceTypeIdDataGridViewTextBoxColumn, levelIdDataGridViewTextBoxColumn, countryDataGridViewTextBoxColumn, levelDataGridViewTextBoxColumn, projectDataGridViewTextBoxColumn, resourceCostingDataGridViewTextBoxColumn, resourceTypeDataGridViewTextBoxColumn });
            dataGridView1.DataSource = resourceBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(125, 47);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1141, 569);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            // 
            // resourceBindingSource
            // 
            resourceBindingSource.DataSource = typeof(Models.Resource);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.LightBlue;
            label9.Font = new Font("Palatino Linotype", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(524, 7);
            label9.Name = "label9";
            label9.Size = new Size(328, 37);
            label9.TabIndex = 3;
            label9.Text = "Configure Resource Rate";
            // 
            // button6
            // 
            button6.BackColor = Color.RosyBrown;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button6.Location = new Point(1213, 4);
            button6.Name = "button6";
            button6.Size = new Size(77, 32);
            button6.TabIndex = 4;
            button6.Text = "Previous";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.RosyBrown;
            button7.FlatStyle = FlatStyle.Popup;
            button7.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button7.Location = new Point(1293, 4);
            button7.Name = "button7";
            button7.Size = new Size(68, 32);
            button7.TabIndex = 5;
            button7.Text = "Next";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // ResourceId
            // 
            ResourceId.DataPropertyName = "ResourceId";
            ResourceId.HeaderText = "ResourceId";
            ResourceId.Name = "ResourceId";
            ResourceId.Visible = false;
            // 
            // projectIdDataGridViewTextBoxColumn
            // 
            projectIdDataGridViewTextBoxColumn.DataPropertyName = "ProjectId";
            projectIdDataGridViewTextBoxColumn.HeaderText = "ProjectId";
            projectIdDataGridViewTextBoxColumn.Name = "projectIdDataGridViewTextBoxColumn";
            projectIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // countryIdDataGridViewTextBoxColumn
            // 
            countryIdDataGridViewTextBoxColumn.DataPropertyName = "CountryId";
            countryIdDataGridViewTextBoxColumn.HeaderText = "CountryId";
            countryIdDataGridViewTextBoxColumn.Name = "countryIdDataGridViewTextBoxColumn";
            countryIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // CountryNames
            // 
            CountryNames.DataPropertyName = "CountryName";
            CountryNames.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            CountryNames.FlatStyle = FlatStyle.Popup;
            CountryNames.HeaderText = "Country";
            CountryNames.Name = "CountryNames";
            CountryNames.Resizable = DataGridViewTriState.True;
            CountryNames.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // TypeNames
            // 
            TypeNames.DataPropertyName = "TypeName";
            TypeNames.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            TypeNames.FlatStyle = FlatStyle.Popup;
            TypeNames.HeaderText = "Resource Type";
            TypeNames.Name = "TypeNames";
            TypeNames.Resizable = DataGridViewTriState.True;
            TypeNames.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // LevelNames
            // 
            LevelNames.DataPropertyName = "LevelName";
            LevelNames.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            LevelNames.FlatStyle = FlatStyle.Popup;
            LevelNames.HeaderText = "Resource Level";
            LevelNames.Name = "LevelNames";
            LevelNames.Resizable = DataGridViewTriState.True;
            LevelNames.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // HourlyRate
            // 
            HourlyRate.DataPropertyName = "HourlyRate";
            HourlyRate.HeaderText = "Hourly Rate ($)";
            HourlyRate.Name = "HourlyRate";
            // 
            // resourceTypeIdDataGridViewTextBoxColumn
            // 
            resourceTypeIdDataGridViewTextBoxColumn.DataPropertyName = "ResourceTypeId";
            resourceTypeIdDataGridViewTextBoxColumn.HeaderText = "ResourceTypeId";
            resourceTypeIdDataGridViewTextBoxColumn.Name = "resourceTypeIdDataGridViewTextBoxColumn";
            resourceTypeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // levelIdDataGridViewTextBoxColumn
            // 
            levelIdDataGridViewTextBoxColumn.DataPropertyName = "LevelId";
            levelIdDataGridViewTextBoxColumn.HeaderText = "LevelId";
            levelIdDataGridViewTextBoxColumn.Name = "levelIdDataGridViewTextBoxColumn";
            levelIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            countryDataGridViewTextBoxColumn.HeaderText = "Country";
            countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            countryDataGridViewTextBoxColumn.Visible = false;
            // 
            // levelDataGridViewTextBoxColumn
            // 
            levelDataGridViewTextBoxColumn.DataPropertyName = "Level";
            levelDataGridViewTextBoxColumn.HeaderText = "Level";
            levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
            levelDataGridViewTextBoxColumn.Visible = false;
            // 
            // projectDataGridViewTextBoxColumn
            // 
            projectDataGridViewTextBoxColumn.DataPropertyName = "Project";
            projectDataGridViewTextBoxColumn.HeaderText = "Project";
            projectDataGridViewTextBoxColumn.Name = "projectDataGridViewTextBoxColumn";
            projectDataGridViewTextBoxColumn.Visible = false;
            // 
            // resourceCostingDataGridViewTextBoxColumn
            // 
            resourceCostingDataGridViewTextBoxColumn.DataPropertyName = "ResourceCosting";
            resourceCostingDataGridViewTextBoxColumn.HeaderText = "ResourceCosting";
            resourceCostingDataGridViewTextBoxColumn.Name = "resourceCostingDataGridViewTextBoxColumn";
            resourceCostingDataGridViewTextBoxColumn.Visible = false;
            // 
            // resourceTypeDataGridViewTextBoxColumn
            // 
            resourceTypeDataGridViewTextBoxColumn.DataPropertyName = "ResourceType";
            resourceTypeDataGridViewTextBoxColumn.HeaderText = "ResourceType";
            resourceTypeDataGridViewTextBoxColumn.Name = "resourceTypeDataGridViewTextBoxColumn";
            resourceTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // ResourceRateUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label9);
            Controls.Add(dataGridView1);
            Name = "ResourceRateUserControl";
            Size = new Size(1363, 708);
            Load += ResourceRateUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)resourceBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label9;
        private Button button6;
        private Button button7;
        private BindingSource resourceBindingSource;
        private DataGridViewTextBoxColumn ResourceId;
        private DataGridViewTextBoxColumn projectIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn countryIdDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn CountryNames;
        private DataGridViewComboBoxColumn TypeNames;
        private DataGridViewComboBoxColumn LevelNames;
        private DataGridViewTextBoxColumn HourlyRate;
        private DataGridViewTextBoxColumn resourceTypeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn levelIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn resourceCostingDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn resourceTypeDataGridViewTextBoxColumn;
    }
}
