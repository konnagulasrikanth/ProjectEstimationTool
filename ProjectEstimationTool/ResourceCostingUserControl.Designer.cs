namespace ProjectEstimationTool
{
    partial class ResourceCostingUserControl
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
            label1 = new Label();
            button6 = new Button();
            button7 = new Button();
            ResourceCostingId = new DataGridViewTextBoxColumn();
            resourceCostingBindingSource1 = new BindingSource(components);
            ResourceCostingIdss = new DataGridViewTextBoxColumn();
            projectIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Phases = new DataGridViewComboBoxColumn();
            ResCount = new DataGridViewTextBoxColumn();
            ResType = new DataGridViewComboBoxColumn();
            Country = new DataGridViewComboBoxColumn();
            RoleLevel = new DataGridViewComboBoxColumn();
            resourceCostingIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridView1 = new DataGridView();
            resourceCostingIdDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            ph = new DataGridViewComboBoxColumn();
            resCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            resTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            countryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            roleLevelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            hourlyRateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            monthlyRateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            durationMmDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            costDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            projectIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            timelineIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            resourceIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            projectDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            resourceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            softwareCostingDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            softwareCostingTestDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            timelineDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            resourceCostingBindingSource = new BindingSource(components);
            resourceCostingIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)resourceCostingBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resourceCostingBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightBlue;
            label1.Font = new Font("Palatino Linotype", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 15);
            label1.Name = "label1";
            label1.Size = new Size(204, 32);
            label1.TabIndex = 0;
            label1.Text = "Resource Costing";
            // 
            // button6
            // 
            button6.BackColor = Color.RosyBrown;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            button6.Location = new Point(1203, 4);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 5;
            button6.Text = "Previous";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.RosyBrown;
            button7.FlatStyle = FlatStyle.Popup;
            button7.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            button7.Location = new Point(1284, 4);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 6;
            button7.Text = "Next";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // ResourceCostingId
            // 
            ResourceCostingId.DataPropertyName = "ResourceCostingId";
            ResourceCostingId.HeaderText = "ResourceCostingId";
            ResourceCostingId.Name = "ResourceCostingId";
            ResourceCostingId.Visible = false;
            // 
            // resourceCostingBindingSource1
            // 
            resourceCostingBindingSource1.DataSource = typeof(Models.ResourceCosting);
            // 
            // ResourceCostingIdss
            // 
            ResourceCostingIdss.DataPropertyName = "ResourceCostingId";
            ResourceCostingIdss.HeaderText = "ResourceCostingId";
            ResourceCostingIdss.Name = "ResourceCostingIdss";
            // 
            // projectIdDataGridViewTextBoxColumn
            // 
            projectIdDataGridViewTextBoxColumn.DataPropertyName = "ProjectId";
            projectIdDataGridViewTextBoxColumn.HeaderText = "ProjectId";
            projectIdDataGridViewTextBoxColumn.Name = "projectIdDataGridViewTextBoxColumn";
            // 
            // Phases
            // 
            Phases.DataPropertyName = "Phase";
            Phases.HeaderText = "Phase";
            Phases.Name = "Phases";
            Phases.Resizable = DataGridViewTriState.True;
            Phases.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // ResCount
            // 
            ResCount.DataPropertyName = "ResCount";
            ResCount.HeaderText = "ResCount";
            ResCount.Name = "ResCount";
            // 
            // ResType
            // 
            ResType.DataPropertyName = "ResType";
            ResType.HeaderText = "ResType";
            ResType.Name = "ResType";
            ResType.Resizable = DataGridViewTriState.True;
            ResType.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Country
            // 
            Country.DataPropertyName = "Country";
            Country.HeaderText = "Country";
            Country.Name = "Country";
            Country.Resizable = DataGridViewTriState.True;
            Country.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // RoleLevel
            // 
            RoleLevel.DataPropertyName = "RoleLevel";
            RoleLevel.HeaderText = "RoleLevel";
            RoleLevel.Name = "RoleLevel";
            RoleLevel.Resizable = DataGridViewTriState.True;
            RoleLevel.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // resourceCostingIdDataGridViewTextBoxColumn
            // 
            resourceCostingIdDataGridViewTextBoxColumn.DataPropertyName = "ResourceCostingId";
            resourceCostingIdDataGridViewTextBoxColumn.HeaderText = "ResourceCostingId";
            resourceCostingIdDataGridViewTextBoxColumn.Name = "resourceCostingIdDataGridViewTextBoxColumn";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { resourceCostingIdDataGridViewTextBoxColumn2, ph, resCountDataGridViewTextBoxColumn, resTypeDataGridViewTextBoxColumn, countryDataGridViewTextBoxColumn, roleLevelDataGridViewTextBoxColumn, hourlyRateDataGridViewTextBoxColumn, monthlyRateDataGridViewTextBoxColumn, durationMmDataGridViewTextBoxColumn, costDataGridViewTextBoxColumn, projectIdDataGridViewTextBoxColumn1, timelineIdDataGridViewTextBoxColumn, resourceIdDataGridViewTextBoxColumn, projectDataGridViewTextBoxColumn, resourceDataGridViewTextBoxColumn, softwareCostingDataGridViewTextBoxColumn, softwareCostingTestDataGridViewTextBoxColumn, timelineDataGridViewTextBoxColumn });
            dataGridView1.DataSource = resourceCostingBindingSource;
            dataGridView1.Location = new Point(72, 101);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1114, 148);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // resourceCostingIdDataGridViewTextBoxColumn2
            // 
            resourceCostingIdDataGridViewTextBoxColumn2.DataPropertyName = "ResourceCostingId";
            resourceCostingIdDataGridViewTextBoxColumn2.HeaderText = "ResourceCostingId";
            resourceCostingIdDataGridViewTextBoxColumn2.Name = "resourceCostingIdDataGridViewTextBoxColumn2";
            // 
            // ph
            // 
            ph.DataPropertyName = "Phase";
            ph.HeaderText = "Phase";
            ph.Name = "ph";
            ph.Resizable = DataGridViewTriState.True;
            ph.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // resCountDataGridViewTextBoxColumn
            // 
            resCountDataGridViewTextBoxColumn.DataPropertyName = "ResCount";
            resCountDataGridViewTextBoxColumn.HeaderText = "ResCount";
            resCountDataGridViewTextBoxColumn.Name = "resCountDataGridViewTextBoxColumn";
            // 
            // resTypeDataGridViewTextBoxColumn
            // 
            resTypeDataGridViewTextBoxColumn.DataPropertyName = "ResType";
            resTypeDataGridViewTextBoxColumn.HeaderText = "ResType";
            resTypeDataGridViewTextBoxColumn.Name = "resTypeDataGridViewTextBoxColumn";
            // 
            // countryDataGridViewTextBoxColumn
            // 
            countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            countryDataGridViewTextBoxColumn.HeaderText = "Country";
            countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            // 
            // roleLevelDataGridViewTextBoxColumn
            // 
            roleLevelDataGridViewTextBoxColumn.DataPropertyName = "RoleLevel";
            roleLevelDataGridViewTextBoxColumn.HeaderText = "RoleLevel";
            roleLevelDataGridViewTextBoxColumn.Name = "roleLevelDataGridViewTextBoxColumn";
            // 
            // hourlyRateDataGridViewTextBoxColumn
            // 
            hourlyRateDataGridViewTextBoxColumn.DataPropertyName = "HourlyRate";
            hourlyRateDataGridViewTextBoxColumn.HeaderText = "HourlyRate";
            hourlyRateDataGridViewTextBoxColumn.Name = "hourlyRateDataGridViewTextBoxColumn";
            // 
            // monthlyRateDataGridViewTextBoxColumn
            // 
            monthlyRateDataGridViewTextBoxColumn.DataPropertyName = "MonthlyRate";
            monthlyRateDataGridViewTextBoxColumn.HeaderText = "MonthlyRate";
            monthlyRateDataGridViewTextBoxColumn.Name = "monthlyRateDataGridViewTextBoxColumn";
            // 
            // durationMmDataGridViewTextBoxColumn
            // 
            durationMmDataGridViewTextBoxColumn.DataPropertyName = "DurationMm";
            durationMmDataGridViewTextBoxColumn.HeaderText = "DurationMm";
            durationMmDataGridViewTextBoxColumn.Name = "durationMmDataGridViewTextBoxColumn";
            // 
            // costDataGridViewTextBoxColumn
            // 
            costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            costDataGridViewTextBoxColumn.HeaderText = "Cost";
            costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            // 
            // projectIdDataGridViewTextBoxColumn1
            // 
            projectIdDataGridViewTextBoxColumn1.DataPropertyName = "ProjectId";
            projectIdDataGridViewTextBoxColumn1.HeaderText = "ProjectId";
            projectIdDataGridViewTextBoxColumn1.Name = "projectIdDataGridViewTextBoxColumn1";
            projectIdDataGridViewTextBoxColumn1.Visible = false;
            // 
            // timelineIdDataGridViewTextBoxColumn
            // 
            timelineIdDataGridViewTextBoxColumn.DataPropertyName = "TimelineId";
            timelineIdDataGridViewTextBoxColumn.HeaderText = "TimelineId";
            timelineIdDataGridViewTextBoxColumn.Name = "timelineIdDataGridViewTextBoxColumn";
            timelineIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // resourceIdDataGridViewTextBoxColumn
            // 
            resourceIdDataGridViewTextBoxColumn.DataPropertyName = "ResourceId";
            resourceIdDataGridViewTextBoxColumn.HeaderText = "ResourceId";
            resourceIdDataGridViewTextBoxColumn.Name = "resourceIdDataGridViewTextBoxColumn";
            resourceIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // projectDataGridViewTextBoxColumn
            // 
            projectDataGridViewTextBoxColumn.DataPropertyName = "Project";
            projectDataGridViewTextBoxColumn.HeaderText = "Project";
            projectDataGridViewTextBoxColumn.Name = "projectDataGridViewTextBoxColumn";
            projectDataGridViewTextBoxColumn.Visible = false;
            // 
            // resourceDataGridViewTextBoxColumn
            // 
            resourceDataGridViewTextBoxColumn.DataPropertyName = "Resource";
            resourceDataGridViewTextBoxColumn.HeaderText = "Resource";
            resourceDataGridViewTextBoxColumn.Name = "resourceDataGridViewTextBoxColumn";
            resourceDataGridViewTextBoxColumn.Visible = false;
            // 
            // softwareCostingDataGridViewTextBoxColumn
            // 
            softwareCostingDataGridViewTextBoxColumn.DataPropertyName = "SoftwareCosting";
            softwareCostingDataGridViewTextBoxColumn.HeaderText = "SoftwareCosting";
            softwareCostingDataGridViewTextBoxColumn.Name = "softwareCostingDataGridViewTextBoxColumn";
            softwareCostingDataGridViewTextBoxColumn.Visible = false;
            // 
            // softwareCostingTestDataGridViewTextBoxColumn
            // 
            softwareCostingTestDataGridViewTextBoxColumn.DataPropertyName = "SoftwareCostingTest";
            softwareCostingTestDataGridViewTextBoxColumn.HeaderText = "SoftwareCostingTest";
            softwareCostingTestDataGridViewTextBoxColumn.Name = "softwareCostingTestDataGridViewTextBoxColumn";
            softwareCostingTestDataGridViewTextBoxColumn.Visible = false;
            // 
            // timelineDataGridViewTextBoxColumn
            // 
            timelineDataGridViewTextBoxColumn.DataPropertyName = "Timeline";
            timelineDataGridViewTextBoxColumn.HeaderText = "Timeline";
            timelineDataGridViewTextBoxColumn.Name = "timelineDataGridViewTextBoxColumn";
            timelineDataGridViewTextBoxColumn.Visible = false;
            // 
            // resourceCostingBindingSource
            // 
            resourceCostingBindingSource.DataSource = typeof(Models.ResourceCosting);
            // 
            // resourceCostingIdDataGridViewTextBoxColumn1
            // 
            resourceCostingIdDataGridViewTextBoxColumn1.DataPropertyName = "ResourceCostingId";
            resourceCostingIdDataGridViewTextBoxColumn1.HeaderText = "ResourceCostingId";
            resourceCostingIdDataGridViewTextBoxColumn1.Name = "resourceCostingIdDataGridViewTextBoxColumn1";
            // 
            // ResourceCostingUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dataGridView1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label1);
            Name = "ResourceCostingUserControl";
            Size = new Size(1363, 708);
            Load += ResourceCostingUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)resourceCostingBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)resourceCostingBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button6;
        private Button button7;
        private DataGridViewTextBoxColumn ResourceCostingId;
        private DataGridViewTextBoxColumn ResourceCostingIds;
        private DataGridViewTextBoxColumn HourlyRates;
        private BindingSource resourceCostingBindingSource1;
        private DataGridViewTextBoxColumn ResourceCostingIdss;
        private DataGridViewTextBoxColumn projectIdDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn Phases;
        private DataGridViewTextBoxColumn ResCount;
        private DataGridViewComboBoxColumn ResType;
        private DataGridViewComboBoxColumn Country;
        private DataGridViewComboBoxColumn RoleLevel;
        private DataGridViewTextBoxColumn resourceCostingIdDataGridViewTextBoxColumn;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn phaseDataGridViewTextBoxColumn;
        private BindingSource resourceCostingBindingSource;
        private DataGridViewTextBoxColumn resourceCostingIdDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn resourceCostingIdDataGridViewTextBoxColumn2;
        private DataGridViewComboBoxColumn ph;
        private DataGridViewTextBoxColumn resCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn resTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roleLevelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn hourlyRateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn monthlyRateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn durationMmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn projectIdDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn timelineIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn resourceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn softwareCostingDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn softwareCostingTestDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn timelineDataGridViewTextBoxColumn;
    }
}
