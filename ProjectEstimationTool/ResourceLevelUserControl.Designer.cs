namespace ProjectEstimationTool
{
    partial class ResourceLevelUserControl
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
            dataGridView1 = new DataGridView();
            levelIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            projectIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            levelNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            projectDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            resourceLevelBindingSource = new BindingSource(components);
            panel1 = new Panel();
            button3 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            label1 = new Label();
            panel2 = new Panel();
            button4 = new Button();
            button5 = new Button();
            textBox2 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)resourceLevelBindingSource).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.RosyBrown;
            dataGridViewCellStyle1.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { levelIdDataGridViewTextBoxColumn, projectIdDataGridViewTextBoxColumn, levelNameDataGridViewTextBoxColumn, projectDataGridViewTextBoxColumn });
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridView1.DataSource = resourceLevelBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(512, 70);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(185, 133);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // levelIdDataGridViewTextBoxColumn
            // 
            levelIdDataGridViewTextBoxColumn.DataPropertyName = "LevelId";
            levelIdDataGridViewTextBoxColumn.HeaderText = "LevelId";
            levelIdDataGridViewTextBoxColumn.Name = "levelIdDataGridViewTextBoxColumn";
            levelIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // projectIdDataGridViewTextBoxColumn
            // 
            projectIdDataGridViewTextBoxColumn.DataPropertyName = "ProjectId";
            projectIdDataGridViewTextBoxColumn.HeaderText = "ProjectId";
            projectIdDataGridViewTextBoxColumn.Name = "projectIdDataGridViewTextBoxColumn";
            projectIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // levelNameDataGridViewTextBoxColumn
            // 
            levelNameDataGridViewTextBoxColumn.DataPropertyName = "LevelName";
            levelNameDataGridViewTextBoxColumn.HeaderText = "Resource Level";
            levelNameDataGridViewTextBoxColumn.Name = "levelNameDataGridViewTextBoxColumn";
            // 
            // projectDataGridViewTextBoxColumn
            // 
            projectDataGridViewTextBoxColumn.DataPropertyName = "Project";
            projectDataGridViewTextBoxColumn.HeaderText = "Project";
            projectDataGridViewTextBoxColumn.Name = "projectDataGridViewTextBoxColumn";
            projectDataGridViewTextBoxColumn.Visible = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 70);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(180, 22);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(180, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // resourceLevelBindingSource
            // 
            resourceLevelBindingSource.DataSource = typeof(Models.ResourceLevel);
            // 
            // panel1
            // 
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(575, 222);
            panel1.Name = "panel1";
            panel1.Size = new Size(307, 159);
            panel1.TabIndex = 1;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(192, 0, 0);
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(273, 3);
            button3.Name = "button3";
            button3.Size = new Size(30, 23);
            button3.TabIndex = 4;
            button3.Text = "X";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.RosyBrown;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(105, 117);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(123, 66);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(158, 23);
            textBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(2, 69);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 1;
            label3.Text = "Resource Level";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(41, 21);
            label2.Name = "label2";
            label2.Size = new Size(208, 28);
            label2.TabIndex = 0;
            label2.Text = "Add Resource Level";
            label2.Click += label2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.RosyBrown;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button1.Location = new Point(512, 215);
            button1.Name = "button1";
            button1.Size = new Size(57, 23);
            button1.TabIndex = 2;
            button1.Text = "New";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightBlue;
            label1.Font = new Font("Palatino Linotype", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(512, 22);
            label1.Name = "label1";
            label1.Size = new Size(294, 32);
            label1.TabIndex = 3;
            label1.Text = "Configure Resource Level";
            // 
            // panel2
            // 
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(512, 267);
            panel2.Name = "panel2";
            panel2.Size = new Size(350, 170);
            panel2.TabIndex = 5;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(192, 0, 0);
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(313, 3);
            button4.Name = "button4";
            button4.Size = new Size(30, 23);
            button4.TabIndex = 4;
            button4.Text = "X";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.RosyBrown;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(105, 120);
            button5.Name = "button5";
            button5.Size = new Size(75, 31);
            button5.TabIndex = 3;
            button5.Text = "Update";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(142, 77);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(156, 23);
            textBox2.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(28, 80);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 1;
            label4.Text = "Resource Level";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(28, 14);
            label5.Name = "label5";
            label5.Size = new Size(237, 28);
            label5.TabIndex = 0;
            label5.Text = "Update Resource Level";
            // 
            // button6
            // 
            button6.BackColor = Color.RosyBrown;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button6.Location = new Point(1206, 3);
            button6.Name = "button6";
            button6.Size = new Size(69, 23);
            button6.TabIndex = 6;
            button6.Text = "Previous";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            button6.MouseEnter += button6_MouseEnter;
            // 
            // button7
            // 
            button7.BackColor = Color.RosyBrown;
            button7.FlatStyle = FlatStyle.Popup;
            button7.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button7.Location = new Point(1281, 3);
            button7.Name = "button7";
            button7.Size = new Size(69, 23);
            button7.TabIndex = 7;
            button7.Text = "Next";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // ResourceLevelUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button7);
            Controls.Add(panel2);
            Controls.Add(button6);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Name = "ResourceLevelUserControl";
            Size = new Size(1363, 708);
            Load += ResourceLevelUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)resourceLevelBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private Button button1;
        private DataGridViewTextBoxColumn levelIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn projectIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn levelNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private BindingSource resourceLevelBindingSource;
        private Button button3;
        private Button button2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Button button4;
        private Button button5;
        private TextBox textBox2;
        private Label label4;
        private Label label5;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Button button6;
        private Button button7;
    }
}
