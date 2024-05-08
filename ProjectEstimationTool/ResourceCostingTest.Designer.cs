namespace ProjectEstimationTool
{
    partial class ResourceCostingTest
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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewComboBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewComboBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewComboBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewComboBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            DurationMm = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn18 = new DataGridViewTextBoxColumn();
            resourceCostingBindingSource = new BindingSource(components);
            ResourceCostingId = new DataGridViewTextBoxColumn();
            Phases = new DataGridViewComboBoxColumn();
            label21 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resourceCostingBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.RosyBrown;
            dataGridViewCellStyle6.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, DurationMm, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn14, dataGridViewTextBoxColumn15, dataGridViewTextBoxColumn16, dataGridViewTextBoxColumn17, dataGridViewTextBoxColumn18 });
            dataGridView1.DataSource = resourceCostingBindingSource;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle10.SelectionForeColor = Color.Black;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle10;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(96, 122);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1206, 219);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "ResourceCostingId";
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            Column1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "Phase";
            dataGridViewTextBoxColumn3.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dataGridViewTextBoxColumn3.FlatStyle = FlatStyle.Popup;
            dataGridViewTextBoxColumn3.HeaderText = "Phase";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Resizable = DataGridViewTriState.True;
            dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "ResCount";
            dataGridViewTextBoxColumn4.HeaderText = "ResCount";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "ResType";
            dataGridViewTextBoxColumn5.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dataGridViewTextBoxColumn5.FlatStyle = FlatStyle.Popup;
            dataGridViewTextBoxColumn5.HeaderText = "ResType";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Resizable = DataGridViewTriState.True;
            dataGridViewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "Country";
            dataGridViewTextBoxColumn6.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dataGridViewTextBoxColumn6.FlatStyle = FlatStyle.Popup;
            dataGridViewTextBoxColumn6.HeaderText = "Country";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Resizable = DataGridViewTriState.True;
            dataGridViewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "RoleLevel";
            dataGridViewTextBoxColumn7.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dataGridViewTextBoxColumn7.FlatStyle = FlatStyle.Popup;
            dataGridViewTextBoxColumn7.HeaderText = "RoleLevel";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.Resizable = DataGridViewTriState.True;
            dataGridViewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.DataPropertyName = "HourlyRate";
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewTextBoxColumn8.HeaderText = "HourlyRate";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.DataPropertyName = "MonthlyRate";
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewTextBoxColumn9.HeaderText = "WeeklyRate";
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // DurationMm
            // 
            DurationMm.DataPropertyName = "DurationMm";
            DurationMm.HeaderText = "DurationWK";
            DurationMm.Name = "DurationMm";
            DurationMm.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.DataPropertyName = "Cost";
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewTextBoxColumn11.HeaderText = "Cost";
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.DataPropertyName = "TimelineId";
            dataGridViewTextBoxColumn12.HeaderText = "TimelineId";
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.DataPropertyName = "ResourceId";
            dataGridViewTextBoxColumn13.HeaderText = "ResourceId";
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "ProjectId";
            dataGridViewTextBoxColumn2.HeaderText = "ProjectId";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.DataPropertyName = "Project";
            dataGridViewTextBoxColumn14.HeaderText = "Project";
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewTextBoxColumn15.DataPropertyName = "Resource";
            dataGridViewTextBoxColumn15.HeaderText = "Resource";
            dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            dataGridViewTextBoxColumn16.DataPropertyName = "SoftwareCosting";
            dataGridViewTextBoxColumn16.HeaderText = "SoftwareCosting";
            dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn17
            // 
            dataGridViewTextBoxColumn17.DataPropertyName = "SoftwareCostingTest";
            dataGridViewTextBoxColumn17.HeaderText = "SoftwareCostingTest";
            dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            dataGridViewTextBoxColumn17.Visible = false;
            // 
            // dataGridViewTextBoxColumn18
            // 
            dataGridViewTextBoxColumn18.DataPropertyName = "Timeline";
            dataGridViewTextBoxColumn18.HeaderText = "Timeline";
            dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            dataGridViewTextBoxColumn18.Visible = false;
            // 
            // resourceCostingBindingSource
            // 
            resourceCostingBindingSource.DataSource = typeof(Models.ResourceCosting);
            // 
            // ResourceCostingId
            // 
            ResourceCostingId.DataPropertyName = "ResourceCostingId";
            ResourceCostingId.HeaderText = "ResourceCostingId";
            ResourceCostingId.Name = "ResourceCostingId";
            ResourceCostingId.Visible = false;
            // 
            // Phases
            // 
            Phases.DataPropertyName = "Phase";
            Phases.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            Phases.FlatStyle = FlatStyle.Popup;
            Phases.HeaderText = "Phase";
            Phases.Name = "Phases";
            Phases.Resizable = DataGridViewTriState.True;
            Phases.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.LightBlue;
            label21.Font = new Font("Palatino Linotype", 20F, FontStyle.Bold);
            label21.Location = new Point(573, 56);
            label21.Name = "label21";
            label21.Size = new Size(229, 37);
            label21.TabIndex = 24;
            label21.Text = "ResourceCosting";
            // 
            // ResourceCostingTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label21);
            Controls.Add(dataGridView1);
            Name = "ResourceCostingTest";
            Size = new Size(1363, 704);
            Load += ResourceCostingTest_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)resourceCostingBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn HourlyRates;
        private DataGridViewTextBoxColumn ResourceCostingId;
        private DataGridViewComboBoxColumn Phases;
        private DataGridViewTextBoxColumn resourceCostingIdDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn phaseDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn resCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn resTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roleLevelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn hourlyRateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn monthlyRateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn durationMmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn timelineIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn resourceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn softwareCostingDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn softwareCostingTestDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn timelineDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn projectIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ResourceCostingIds;
        private DataGridViewComboBoxColumn Phasess;
        private DataGridViewTextBoxColumn ResCountss;
        private DataGridViewComboBoxColumn ResTypes;
        private DataGridViewComboBoxColumn Countrys;
        private DataGridViewComboBoxColumn RoleLevels;
        private DataGridViewTextBoxColumn HourlyRatess;
        private BindingSource resourceCostingBindingSource;
        private DataGridViewTextBoxColumn ResourceCostingIdss;
        private Label label21;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewComboBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewComboBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewComboBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn DurationMm;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
    }
}
