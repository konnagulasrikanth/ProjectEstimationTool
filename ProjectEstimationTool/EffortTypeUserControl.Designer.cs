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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgv1 = new DataGridView();
            EffortIds = new DataGridViewTextBoxColumn();
            EffortNames = new DataGridViewTextBoxColumn();
            ActualEfforts = new DataGridViewTextBoxColumn();
            Bas = new DataGridViewTextBoxColumn();
            Devs = new DataGridViewTextBoxColumn();
            Qas = new DataGridViewTextBoxColumn();
            Rule = new DataGridViewTextBoxColumn();
            projectDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            effortTypeBindingSource = new BindingSource(components);
            button1 = new Button();
            panel1 = new Panel();
            button2 = new Button();
            label7 = new Label();
            button3 = new Button();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label8 = new Label();
            textBox1 = new TextBox();
            panel2 = new Panel();
            button4 = new Button();
            label9 = new Label();
            button5 = new Button();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            textBox11 = new TextBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            textBox12 = new TextBox();
            label1 = new Label();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)effortTypeBindingSource).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgv1
            // 
            dgv1.AllowUserToAddRows = false;
            dgv1.AllowUserToDeleteRows = false;
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
            dgv1.Columns.AddRange(new DataGridViewColumn[] { EffortIds, EffortNames, ActualEfforts, Bas, Devs, Qas, Rule, projectDataGridViewTextBoxColumn });
            dgv1.ContextMenuStrip = contextMenuStrip1;
            dgv1.DataSource = effortTypeBindingSource;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgv1.DefaultCellStyle = dataGridViewCellStyle4;
            dgv1.EnableHeadersVisualStyles = false;
            dgv1.Location = new Point(118, 61);
            dgv1.Margin = new Padding(3, 4, 3, 4);
            dgv1.Name = "dgv1";
            dgv1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.RosyBrown;
            dataGridViewCellStyle5.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgv1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgv1.RowHeadersVisible = false;
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.Size = new Size(1154, 114);
            dgv1.TabIndex = 0;
            dgv1.CellClick += dgv1_CellClick;
            dgv1.CellContentClick += dataGridView1_CellContentClick;
            dgv1.CellMouseDown += dgv1_CellMouseDown;
            // 
            // EffortIds
            // 
            EffortIds.DataPropertyName = "EffortId";
            EffortIds.HeaderText = "EffortId";
            EffortIds.Name = "EffortIds";
            EffortIds.ReadOnly = true;
            EffortIds.Visible = false;
            // 
            // EffortNames
            // 
            EffortNames.DataPropertyName = "EffortName";
            EffortNames.HeaderText = "Effort Type";
            EffortNames.Name = "EffortNames";
            EffortNames.ReadOnly = true;
            // 
            // ActualEfforts
            // 
            ActualEfforts.DataPropertyName = "ActualEffort";
            ActualEfforts.HeaderText = "Actual Effort";
            ActualEfforts.Name = "ActualEfforts";
            ActualEfforts.ReadOnly = true;
            // 
            // Bas
            // 
            Bas.DataPropertyName = "Ba";
            dataGridViewCellStyle2.NullValue = null;
            Bas.DefaultCellStyle = dataGridViewCellStyle2;
            Bas.HeaderText = "BA%";
            Bas.Name = "Bas";
            Bas.ReadOnly = true;
            // 
            // Devs
            // 
            Devs.DataPropertyName = "Dev";
            Devs.HeaderText = "Dev%";
            Devs.Name = "Devs";
            Devs.ReadOnly = true;
            // 
            // Qas
            // 
            Qas.DataPropertyName = "Qa";
            Qas.HeaderText = "QA%";
            Qas.Name = "Qas";
            Qas.ReadOnly = true;
            // 
            // Rule
            // 
            Rule.DataPropertyName = "Rules";
            dataGridViewCellStyle3.BackColor = Color.White;
            Rule.DefaultCellStyle = dataGridViewCellStyle3;
            Rule.HeaderText = "Rules";
            Rule.Name = "Rule";
            Rule.ReadOnly = true;
            // 
            // projectDataGridViewTextBoxColumn
            // 
            projectDataGridViewTextBoxColumn.DataPropertyName = "Project";
            projectDataGridViewTextBoxColumn.HeaderText = "Project";
            projectDataGridViewTextBoxColumn.Name = "projectDataGridViewTextBoxColumn";
            projectDataGridViewTextBoxColumn.ReadOnly = true;
            projectDataGridViewTextBoxColumn.Visible = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(116, 48);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(115, 22);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            editToolStripMenuItem.MouseDown += editToolStripMenuItem_MouseDown;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(115, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // effortTypeBindingSource
            // 
            effortTypeBindingSource.DataSource = typeof(Models.EffortType);
            // 
            // button1
            // 
            button1.BackColor = Color.RosyBrown;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(120, 182);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 28);
            button1.TabIndex = 2;
            button1.Text = "New";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(textBox6);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(178, 246);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(678, 367);
            panel1.TabIndex = 3;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(632, 10);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(37, 28);
            button2.TabIndex = 29;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(32, 10);
            label7.Name = "label7";
            label7.Size = new Size(558, 28);
            label7.TabIndex = 28;
            label7.Text = "Add Effort Type, Actual Effort, Rules, BA%, Dev%, QA%";
            // 
            // button3
            // 
            button3.BackColor = Color.RosyBrown;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(320, 324);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(86, 28);
            button3.TabIndex = 27;
            button3.Text = "Save";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(320, 268);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(114, 25);
            textBox6.TabIndex = 26;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(320, 210);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(114, 25);
            textBox5.TabIndex = 25;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(320, 167);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(114, 25);
            textBox4.TabIndex = 24;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(320, 130);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(114, 25);
            textBox3.TabIndex = 23;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(320, 94);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(114, 25);
            textBox2.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Palatino Linotype", 11.25F);
            label6.Location = new Point(258, 268);
            label6.Name = "label6";
            label6.Size = new Size(45, 20);
            label6.TabIndex = 21;
            label6.Text = "Rules";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Palatino Linotype", 11.25F);
            label5.Location = new Point(258, 167);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 20;
            label5.Text = "QA %";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Palatino Linotype", 11.25F);
            label4.Location = new Point(257, 219);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 19;
            label4.Text = "Dev %";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 11.25F);
            label3.Location = new Point(259, 130);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 18;
            label3.Text = "BA %";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 11.25F);
            label2.Location = new Point(200, 96);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 17;
            label2.Text = "Actual Effort";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Palatino Linotype", 11.25F);
            label8.Location = new Point(211, 53);
            label8.Name = "label8";
            label8.Size = new Size(84, 20);
            label8.TabIndex = 16;
            label8.Text = "Effort Type";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(320, 51);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(114, 25);
            textBox1.TabIndex = 15;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(button4);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(textBox7);
            panel2.Controls.Add(textBox8);
            panel2.Controls.Add(textBox9);
            panel2.Controls.Add(textBox10);
            panel2.Controls.Add(textBox11);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(textBox12);
            panel2.Location = new Point(131, 288);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(696, 374);
            panel2.TabIndex = 30;
            // 
            // button4
            // 
            button4.BackColor = Color.Red;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(653, 4);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(37, 28);
            button4.TabIndex = 29;
            button4.Text = "X";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(30, 4);
            label9.Name = "label9";
            label9.Size = new Size(587, 28);
            label9.TabIndex = 28;
            label9.Text = "Update Effort Type, Actual Effort, Rules, BA%, Dev%, QA%";
            // 
            // button5
            // 
            button5.BackColor = Color.RosyBrown;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(322, 330);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(86, 28);
            button5.TabIndex = 27;
            button5.Text = "Update";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(322, 268);
            textBox7.Margin = new Padding(3, 4, 3, 4);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(114, 25);
            textBox7.TabIndex = 26;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(322, 210);
            textBox8.Margin = new Padding(3, 4, 3, 4);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(114, 25);
            textBox8.TabIndex = 25;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(322, 167);
            textBox9.Margin = new Padding(3, 4, 3, 4);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(114, 25);
            textBox9.TabIndex = 24;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(322, 130);
            textBox10.Margin = new Padding(3, 4, 3, 4);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(114, 25);
            textBox10.TabIndex = 23;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(322, 94);
            textBox11.Margin = new Padding(3, 4, 3, 4);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(114, 25);
            textBox11.TabIndex = 22;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Palatino Linotype", 11.25F);
            label10.Location = new Point(260, 268);
            label10.Name = "label10";
            label10.Size = new Size(45, 20);
            label10.TabIndex = 21;
            label10.Text = "Rules";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Palatino Linotype", 11.25F);
            label11.Location = new Point(260, 167);
            label11.Name = "label11";
            label11.Size = new Size(49, 20);
            label11.TabIndex = 20;
            label11.Text = "QA %";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Palatino Linotype", 11.25F);
            label12.Location = new Point(259, 219);
            label12.Name = "label12";
            label12.Size = new Size(53, 20);
            label12.TabIndex = 19;
            label12.Text = "Dev %";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Palatino Linotype", 11.25F);
            label13.Location = new Point(261, 130);
            label13.Name = "label13";
            label13.Size = new Size(46, 20);
            label13.TabIndex = 18;
            label13.Text = "BA %";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(211, 96);
            label14.Name = "label14";
            label14.Size = new Size(94, 20);
            label14.TabIndex = 17;
            label14.Text = "Actual Effort";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Palatino Linotype", 11.25F);
            label15.Location = new Point(221, 51);
            label15.Name = "label15";
            label15.Size = new Size(84, 20);
            label15.TabIndex = 16;
            label15.Text = "Effort Type";
            // 
            // textBox12
            // 
            textBox12.Location = new Point(322, 51);
            textBox12.Margin = new Padding(3, 4, 3, 4);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(114, 25);
            textBox12.TabIndex = 15;
            textBox12.TextChanged += textBox12_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightBlue;
            label1.Font = new Font("Palatino Linotype", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(328, 14);
            label1.Name = "label1";
            label1.Size = new Size(693, 32);
            label1.TabIndex = 4;
            label1.Text = "Configure Effort Type, Actual Effort, BA%, Dev%, QA%, Rules";
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
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(dgv1);
            Font = new Font("Palatino Linotype", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EffortTypeUserControl";
            Size = new Size(1363, 687);
            Load += EffortTypeUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)effortTypeBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv1;
        private Button button1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private BindingSource effortTypeBindingSource;
        private DataGridViewTextBoxColumn scopeAndEffortDataGridViewTextBoxColumn;
        private Panel panel1;
        private Label label1;
        private Button button2;
        private Label label7;
        private Button button3;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label8;
        private TextBox textBox1;
        private Panel panel2;
        private Button button4;
        private Label label9;
        private Button button5;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox textBox12;
        private Button button6;
        private DataGridViewTextBoxColumn EffortIds;
        private DataGridViewTextBoxColumn EffortNames;
        private DataGridViewTextBoxColumn ActualEfforts;
        private DataGridViewTextBoxColumn Bas;
        private DataGridViewTextBoxColumn Devs;
        private DataGridViewTextBoxColumn Qas;
        private DataGridViewTextBoxColumn Rule;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
    }
}
