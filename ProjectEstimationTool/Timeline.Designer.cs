namespace ProjectEstimationTool
{
    partial class Timeline
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
            dataGridView1 = new DataGridView();
            timelineIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            projectIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Functionality = new DataGridViewTextBoxColumn();
            Phasename = new DataGridViewTextBoxColumn();
            EffHrs = new DataGridViewTextBoxColumn();
            ResReq = new DataGridViewTextBoxColumn();
            Mmname = new DataGridViewTextBoxColumn();
            Lagname = new DataGridViewTextBoxColumn();
            timelineBindingSource = new BindingSource(components);
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            button1 = new Button();
            panel6 = new Panel();
            label20 = new Label();
            button5 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            panel7 = new Panel();
            button4 = new Button();
            button3 = new Button();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            comboBox2 = new ComboBox();
            textBox9 = new TextBox();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            textBox2 = new TextBox();
            label14 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            button6 = new Button();
            panel8 = new Panel();
            button8 = new Button();
            label22 = new Label();
            label21 = new Label();
            button7 = new Button();
            textBox10 = new TextBox();
            textBox6 = new TextBox();
            button9 = new Button();
            button10 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timelineBindingSource).BeginInit();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            panel8.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightBlue;
            label1.Font = new Font("Palatino Linotype", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(489, 8);
            label1.Name = "label1";
            label1.Size = new Size(131, 37);
            label1.TabIndex = 0;
            label1.Text = "Timeline";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { timelineIdDataGridViewTextBoxColumn, projectIdDataGridViewTextBoxColumn, Functionality, Phasename, EffHrs, ResReq, Mmname, Lagname });
            dataGridView1.DataSource = timelineBindingSource;
            dataGridView1.Location = new Point(56, 146);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1220, 183);
            dataGridView1.TabIndex = 1;
            // 
            // timelineIdDataGridViewTextBoxColumn
            // 
            timelineIdDataGridViewTextBoxColumn.DataPropertyName = "TimelineId";
            timelineIdDataGridViewTextBoxColumn.HeaderText = "TimelineId";
            timelineIdDataGridViewTextBoxColumn.Name = "timelineIdDataGridViewTextBoxColumn";
            timelineIdDataGridViewTextBoxColumn.ReadOnly = true;
            timelineIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // projectIdDataGridViewTextBoxColumn
            // 
            projectIdDataGridViewTextBoxColumn.DataPropertyName = "ProjectId";
            projectIdDataGridViewTextBoxColumn.HeaderText = "ProjectId";
            projectIdDataGridViewTextBoxColumn.Name = "projectIdDataGridViewTextBoxColumn";
            projectIdDataGridViewTextBoxColumn.ReadOnly = true;
            projectIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // Functionality
            // 
            Functionality.DataPropertyName = "Functionality";
            Functionality.HeaderText = "Functionality";
            Functionality.Name = "Functionality";
            Functionality.ReadOnly = true;
            Functionality.Width = 205;
            // 
            // Phasename
            // 
            Phasename.DataPropertyName = "Phase";
            Phasename.HeaderText = "Phase";
            Phasename.Name = "Phasename";
            Phasename.ReadOnly = true;
            Phasename.Width = 204;
            // 
            // EffHrs
            // 
            EffHrs.DataPropertyName = "EffHrs";
            EffHrs.HeaderText = "Eff Hrs";
            EffHrs.Name = "EffHrs";
            EffHrs.ReadOnly = true;
            EffHrs.Width = 205;
            // 
            // ResReq
            // 
            ResReq.DataPropertyName = "ResReq";
            ResReq.HeaderText = "Res.Req";
            ResReq.Name = "ResReq";
            ResReq.ReadOnly = true;
            ResReq.Width = 205;
            // 
            // Mmname
            // 
            Mmname.DataPropertyName = "Mm";
            Mmname.HeaderText = "MM";
            Mmname.Name = "Mmname";
            Mmname.ReadOnly = true;
            Mmname.Width = 205;
            // 
            // Lagname
            // 
            Lagname.DataPropertyName = "Lag";
            Lagname.HeaderText = "Lag";
            Lagname.Name = "Lagname";
            Lagname.ReadOnly = true;
            Lagname.Width = 206;
            // 
            // timelineBindingSource
            // 
            timelineBindingSource.DataSource = typeof(Models.Timeline);
            timelineBindingSource.CurrentChanged += timelineBindingSource_CurrentChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.LightBlue;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(168, 32);
            label6.Name = "label6";
            label6.Size = new Size(158, 31);
            label6.TabIndex = 1;
            label6.Text = "label6";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.LightBlue;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(168, 1);
            label5.Name = "label5";
            label5.Size = new Size(158, 30);
            label5.TabIndex = 0;
            label5.Text = "label5";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LightBlue;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(4, 32);
            label4.Name = "label4";
            label4.Size = new Size(157, 31);
            label4.TabIndex = 1;
            label4.Text = "Duration in Months";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightBlue;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(4, 1);
            label3.Name = "label3";
            label3.Size = new Size(157, 30);
            label3.TabIndex = 0;
            label3.Text = "Total Hours";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.RosyBrown;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(54, 335);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "New";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.MouseEnter += button1_MouseEnter;
            button1.MouseLeave += button1_MouseLeave;
            // 
            // panel6
            // 
            panel6.Controls.Add(label20);
            panel6.Controls.Add(button5);
            panel6.Controls.Add(button2);
            panel6.Controls.Add(comboBox1);
            panel6.Controls.Add(label13);
            panel6.Controls.Add(label12);
            panel6.Controls.Add(label11);
            panel6.Controls.Add(label10);
            panel6.Controls.Add(label9);
            panel6.Controls.Add(textBox5);
            panel6.Controls.Add(textBox4);
            panel6.Controls.Add(textBox3);
            panel6.Controls.Add(textBox1);
            panel6.Location = new Point(181, 372);
            panel6.Name = "panel6";
            panel6.Size = new Size(249, 278);
            panel6.TabIndex = 4;
            panel6.Paint += panel6_Paint;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.Location = new Point(69, 10);
            label20.Name = "label20";
            label20.Size = new Size(92, 16);
            label20.TabIndex = 13;
            label20.Text = "Add Timeline";
            // 
            // button5
            // 
            button5.BackColor = Color.Red;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(212, 6);
            button5.Name = "button5";
            button5.Size = new Size(30, 23);
            button5.TabIndex = 12;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.RosyBrown;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(127, 245);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 11;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(113, 78);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(103, 23);
            comboBox1.TabIndex = 10;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Palatino Linotype", 9.75F);
            label13.Location = new Point(17, 198);
            label13.Name = "label13";
            label13.Size = new Size(30, 18);
            label13.TabIndex = 9;
            label13.Text = "Lag";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Palatino Linotype", 9.75F);
            label12.Location = new Point(17, 160);
            label12.Name = "label12";
            label12.Size = new Size(32, 18);
            label12.TabIndex = 8;
            label12.Text = "MM";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Palatino Linotype", 9.75F);
            label11.Location = new Point(17, 114);
            label11.Name = "label11";
            label11.Size = new Size(29, 18);
            label11.TabIndex = 7;
            label11.Text = "Res";
            label11.Click += label11_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Palatino Linotype", 9.75F);
            label10.Location = new Point(17, 74);
            label10.Name = "label10";
            label10.Size = new Size(43, 18);
            label10.TabIndex = 6;
            label10.Text = "Phase";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Palatino Linotype", 9.75F);
            label9.Location = new Point(17, 38);
            label9.Name = "label9";
            label9.Size = new Size(89, 18);
            label9.TabIndex = 5;
            label9.Text = "Functionality";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(116, 193);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(114, 155);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(114, 117);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(114, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(button4);
            panel7.Controls.Add(button3);
            panel7.Controls.Add(label19);
            panel7.Controls.Add(label18);
            panel7.Controls.Add(label17);
            panel7.Controls.Add(label16);
            panel7.Controls.Add(label15);
            panel7.Controls.Add(comboBox2);
            panel7.Controls.Add(textBox9);
            panel7.Controls.Add(textBox8);
            panel7.Controls.Add(textBox7);
            panel7.Controls.Add(textBox2);
            panel7.Controls.Add(label14);
            panel7.Location = new Point(445, 363);
            panel7.Name = "panel7";
            panel7.Size = new Size(269, 315);
            panel7.TabIndex = 5;
            panel7.Paint += panel7_Paint;
            // 
            // button4
            // 
            button4.BackColor = Color.Red;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(232, 6);
            button4.Name = "button4";
            button4.Size = new Size(31, 23);
            button4.TabIndex = 13;
            button4.Text = "X";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.RosyBrown;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button3.Location = new Point(110, 262);
            button3.Name = "button3";
            button3.Size = new Size(75, 27);
            button3.TabIndex = 12;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(35, 236);
            label19.Name = "label19";
            label19.Size = new Size(26, 15);
            label19.TabIndex = 11;
            label19.Text = "Lag";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(32, 195);
            label18.Name = "label18";
            label18.Size = new Size(29, 15);
            label18.TabIndex = 10;
            label18.Text = "MM";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(23, 141);
            label17.Name = "label17";
            label17.Size = new Size(25, 15);
            label17.TabIndex = 9;
            label17.Text = "Res";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(19, 95);
            label16.Name = "label16";
            label16.Size = new Size(38, 15);
            label16.TabIndex = 8;
            label16.Text = "Phase";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(7, 52);
            label15.Name = "label15";
            label15.Size = new Size(76, 15);
            label15.TabIndex = 7;
            label15.Text = "Functionality";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(128, 95);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(100, 23);
            comboBox2.TabIndex = 6;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(128, 228);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(100, 23);
            textBox9.TabIndex = 5;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(128, 187);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(100, 23);
            textBox8.TabIndex = 4;
            textBox8.TextChanged += textBox8_TextChanged;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(128, 141);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(100, 23);
            textBox7.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(128, 49);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(62, 13);
            label14.Name = "label14";
            label14.Size = new Size(112, 16);
            label14.TabIndex = 0;
            label14.Text = "Update Timeline";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(107, 22);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.RosyBrown;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(135, 335);
            button6.Name = "button6";
            button6.Size = new Size(104, 23);
            button6.TabIndex = 6;
            button6.Text = "Demo Month";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // panel8
            // 
            panel8.Controls.Add(button8);
            panel8.Controls.Add(label22);
            panel8.Controls.Add(label21);
            panel8.Controls.Add(button7);
            panel8.Controls.Add(textBox10);
            panel8.Controls.Add(textBox6);
            panel8.Location = new Point(731, 363);
            panel8.Name = "panel8";
            panel8.Size = new Size(255, 177);
            panel8.TabIndex = 7;
            panel8.Paint += panel8_Paint;
            // 
            // button8
            // 
            button8.BackColor = Color.Red;
            button8.FlatStyle = FlatStyle.Popup;
            button8.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.Location = new Point(211, 6);
            button8.Name = "button8";
            button8.Size = new Size(31, 23);
            button8.TabIndex = 5;
            button8.Text = "X";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(13, 91);
            label22.Name = "label22";
            label22.Size = new Size(81, 15);
            label22.TabIndex = 4;
            label22.Text = "DemoMonth2";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(10, 41);
            label21.Name = "label21";
            label21.Size = new Size(81, 15);
            label21.TabIndex = 3;
            label21.Text = "DemoMonth1";
            // 
            // button7
            // 
            button7.BackColor = Color.RosyBrown;
            button7.FlatStyle = FlatStyle.Popup;
            button7.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.Location = new Point(102, 121);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 2;
            button7.Text = "Save";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(102, 87);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(100, 23);
            textBox10.TabIndex = 1;
            textBox10.TextChanged += textBox10_TextChanged;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(102, 35);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 0;
            // 
            // button9
            // 
            button9.BackColor = Color.RosyBrown;
            button9.FlatStyle = FlatStyle.Popup;
            button9.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button9.Location = new Point(1201, 112);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 8;
            button9.Text = "Next";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.RosyBrown;
            button10.FlatStyle = FlatStyle.Popup;
            button10.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button10.Location = new Point(1111, 112);
            button10.Name = "button10";
            button10.Size = new Size(75, 23);
            button10.TabIndex = 9;
            button10.Text = "Previous";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.LightBlue;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(label6, 1, 1);
            tableLayoutPanel1.Controls.Add(label5, 1, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 1);
            tableLayoutPanel1.Location = new Point(56, 76);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(330, 64);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightBlue;
            label2.Font = new Font("Arial", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(56, 51);
            label2.Name = "label2";
            label2.Size = new Size(330, 24);
            label2.TabIndex = 0;
            label2.Text = "Implementation Timeline && Efforts";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // Timeline
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(panel8);
            Controls.Add(button6);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "Timeline";
            Size = new Size(1363, 708);
            Load += Timeline_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)timelineBindingSource).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private BindingSource timelineBindingSource;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button button1;
        private Panel panel6;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox1;
        private Button button2;
        private ComboBox comboBox1;
        private Panel panel7;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private ComboBox comboBox2;
        private TextBox textBox9;
        private TextBox textBox8;
        private TextBox textBox7;
        private TextBox textBox2;
        private Label label14;
        private Button button4;
        private Button button3;
        private Button button5;
        private Label label20;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private DataGridViewTextBoxColumn demoDateDataGridViewTextBoxColumn;
        private Button button6;
        private Panel panel8;
        private Button button7;
        private TextBox textBox10;
        private TextBox textBox6;
        private Label label22;
        private Label label21;
        private Button button8;
        private Button button9;
        private Button button10;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private DataGridViewTextBoxColumn timelineIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn projectIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Functionality;
        private DataGridViewTextBoxColumn Phasename;
        private DataGridViewTextBoxColumn EffHrs;
        private DataGridViewTextBoxColumn ResReq;
        private DataGridViewTextBoxColumn Mmname;
        private DataGridViewTextBoxColumn Lagname;
    }
}
