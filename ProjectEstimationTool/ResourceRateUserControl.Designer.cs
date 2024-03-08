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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            resourceIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            projectIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            countryNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            typeNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            levelNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            hourlyRateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            resourceBindingSource = new BindingSource(components);
            panel1 = new Panel();
            button4 = new Button();
            label11 = new Label();
            button2 = new Button();
            textBox1 = new TextBox();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            button5 = new Button();
            label10 = new Label();
            button3 = new Button();
            textBox2 = new TextBox();
            comboBox4 = new ComboBox();
            comboBox5 = new ComboBox();
            comboBox6 = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            button1 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            label9 = new Label();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resourceBindingSource).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.RosyBrown;
            dataGridViewCellStyle3.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { resourceIdDataGridViewTextBoxColumn, projectIdDataGridViewTextBoxColumn, countryNameDataGridViewTextBoxColumn, typeNameDataGridViewTextBoxColumn, levelNameDataGridViewTextBoxColumn, hourlyRateDataGridViewTextBoxColumn });
            dataGridView1.DataSource = resourceBindingSource;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(234, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(897, 160);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            // 
            // resourceIdDataGridViewTextBoxColumn
            // 
            resourceIdDataGridViewTextBoxColumn.DataPropertyName = "ResourceId";
            resourceIdDataGridViewTextBoxColumn.HeaderText = "ResourceId";
            resourceIdDataGridViewTextBoxColumn.Name = "resourceIdDataGridViewTextBoxColumn";
            resourceIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // projectIdDataGridViewTextBoxColumn
            // 
            projectIdDataGridViewTextBoxColumn.DataPropertyName = "ProjectId";
            projectIdDataGridViewTextBoxColumn.HeaderText = "ProjectId";
            projectIdDataGridViewTextBoxColumn.Name = "projectIdDataGridViewTextBoxColumn";
            projectIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // countryNameDataGridViewTextBoxColumn
            // 
            countryNameDataGridViewTextBoxColumn.DataPropertyName = "CountryName";
            countryNameDataGridViewTextBoxColumn.HeaderText = "Country";
            countryNameDataGridViewTextBoxColumn.Name = "countryNameDataGridViewTextBoxColumn";
            // 
            // typeNameDataGridViewTextBoxColumn
            // 
            typeNameDataGridViewTextBoxColumn.DataPropertyName = "TypeName";
            typeNameDataGridViewTextBoxColumn.HeaderText = "Resource Type";
            typeNameDataGridViewTextBoxColumn.Name = "typeNameDataGridViewTextBoxColumn";
            // 
            // levelNameDataGridViewTextBoxColumn
            // 
            levelNameDataGridViewTextBoxColumn.DataPropertyName = "LevelName";
            levelNameDataGridViewTextBoxColumn.HeaderText = "Resource Level";
            levelNameDataGridViewTextBoxColumn.Name = "levelNameDataGridViewTextBoxColumn";
            // 
            // hourlyRateDataGridViewTextBoxColumn
            // 
            hourlyRateDataGridViewTextBoxColumn.DataPropertyName = "HourlyRate";
            hourlyRateDataGridViewTextBoxColumn.HeaderText = "HourlyRate($)";
            hourlyRateDataGridViewTextBoxColumn.Name = "hourlyRateDataGridViewTextBoxColumn";
            // 
            // resourceBindingSource
            // 
            resourceBindingSource.DataSource = typeof(Models.Resource);
            // 
            // panel1
            // 
            panel1.Controls.Add(button4);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(282, 271);
            panel1.Name = "panel1";
            panel1.Size = new Size(389, 199);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(192, 0, 0);
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(328, 3);
            button4.Name = "button4";
            button4.Size = new Size(32, 23);
            button4.TabIndex = 10;
            button4.Text = "X";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(108, 8);
            label11.Name = "label11";
            label11.Size = new Size(198, 28);
            label11.TabIndex = 9;
            label11.Text = "Add Resource Rate";
            // 
            // button2
            // 
            button2.BackColor = Color.RosyBrown;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(285, 166);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 8;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(152, 161);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 7;
            // 
            // comboBox3
            // 
            comboBox3.Font = new Font("Palatino Linotype", 9.75F);
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(152, 121);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 26);
            comboBox3.TabIndex = 6;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(152, 84);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 26);
            comboBox2.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(152, 53);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 26);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Palatino Linotype", 11.25F);
            label4.Location = new Point(24, 169);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 3;
            label4.Text = "Hourly Rate";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 11.25F);
            label3.Location = new Point(24, 124);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 2;
            label3.Text = "Resource Level";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 11.25F);
            label2.Location = new Point(24, 84);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 1;
            label2.Text = "Resource Type";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 11.25F);
            label1.Location = new Point(33, 56);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 0;
            label1.Text = "Country";
            // 
            // panel2
            // 
            panel2.Controls.Add(button5);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(comboBox4);
            panel2.Controls.Add(comboBox5);
            panel2.Controls.Add(comboBox6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(319, 225);
            panel2.Name = "panel2";
            panel2.Size = new Size(402, 211);
            panel2.TabIndex = 3;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(192, 0, 0);
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(359, 3);
            button5.Name = "button5";
            button5.Size = new Size(36, 23);
            button5.TabIndex = 10;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(113, 11);
            label10.Name = "label10";
            label10.Size = new Size(227, 28);
            label10.TabIndex = 9;
            label10.Text = "Update Resource Rate";
            // 
            // button3
            // 
            button3.BackColor = Color.RosyBrown;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(277, 175);
            button3.Name = "button3";
            button3.Size = new Size(75, 29);
            button3.TabIndex = 8;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(152, 172);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 7;
            // 
            // comboBox4
            // 
            comboBox4.Font = new Font("Palatino Linotype", 9.75F);
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(152, 127);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(121, 26);
            comboBox4.TabIndex = 6;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // comboBox5
            // 
            comboBox5.Font = new Font("Palatino Linotype", 9.75F);
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(152, 90);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(121, 26);
            comboBox5.TabIndex = 5;
            // 
            // comboBox6
            // 
            comboBox6.Font = new Font("Palatino Linotype", 9.75F);
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(152, 59);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(121, 26);
            comboBox6.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Palatino Linotype", 11.25F);
            label5.Location = new Point(24, 175);
            label5.Name = "label5";
            label5.Size = new Size(89, 20);
            label5.TabIndex = 3;
            label5.Text = "Hourly Rate";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Palatino Linotype", 11.25F);
            label6.Location = new Point(24, 130);
            label6.Name = "label6";
            label6.Size = new Size(108, 20);
            label6.TabIndex = 2;
            label6.Text = "Resource Level";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Palatino Linotype", 11.25F);
            label7.Location = new Point(24, 90);
            label7.Name = "label7";
            label7.Size = new Size(106, 20);
            label7.TabIndex = 1;
            label7.Text = "Resource Type";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Palatino Linotype", 11.25F);
            label8.Location = new Point(24, 52);
            label8.Name = "label8";
            label8.Size = new Size(65, 20);
            label8.TabIndex = 0;
            label8.Text = "Country";
            // 
            // button1
            // 
            button1.BackColor = Color.RosyBrown;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button1.Location = new Point(234, 235);
            button1.Name = "button1";
            button1.Size = new Size(63, 30);
            button1.TabIndex = 2;
            button1.Text = "New";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(117, 48);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(116, 22);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(116, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.LightBlue;
            label9.Font = new Font("Palatino Linotype", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(524, 7);
            label9.Name = "label9";
            label9.Size = new Size(284, 32);
            label9.TabIndex = 3;
            label9.Text = "Configure Resource Rate";
            // 
            // button6
            // 
            button6.BackColor = Color.RosyBrown;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button6.Location = new Point(1208, 7);
            button6.Name = "button6";
            button6.Size = new Size(77, 23);
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
            button7.Location = new Point(1292, 7);
            button7.Name = "button7";
            button7.Size = new Size(68, 23);
            button7.TabIndex = 5;
            button7.Text = "Next";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // ResourceRateUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label9);
            Controls.Add(panel2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Name = "ResourceRateUserControl";
            Size = new Size(1363, 708);
            Load += ResourceRateUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)resourceBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private Button button1;
        private TextBox textBox1;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button2;
        private Panel panel2;
        private Button button3;
        private TextBox textBox2;
        private ComboBox comboBox4;
        private ComboBox comboBox5;
        private ComboBox comboBox6;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn projectIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn countryNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn levelNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn hourlyRateDataGridViewTextBoxColumn;
        private BindingSource resourceBindingSource;
        private Label label9;
        private Label label11;
        private Label label10;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}
