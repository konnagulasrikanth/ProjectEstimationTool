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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            projectIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            FunctionalAreaNames = new DataGridViewTextBoxColumn();
            projectDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            FunctionalAreaIds = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            functionalAreaBindingSource = new BindingSource(components);
            panel1 = new Panel();
            button5 = new Button();
            label4 = new Label();
            button2 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            panel2 = new Panel();
            button4 = new Button();
            label5 = new Label();
            button3 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)functionalAreaBindingSource).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.RosyBrown;
            dataGridViewCellStyle1.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { projectIdDataGridViewTextBoxColumn, FunctionalAreaNames, projectDataGridViewTextBoxColumn, FunctionalAreaIds });
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridView1.DataSource = functionalAreaBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(406, 79);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.RosyBrown;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(312, 174);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            // 
            // projectIdDataGridViewTextBoxColumn
            // 
            projectIdDataGridViewTextBoxColumn.DataPropertyName = "ProjectId";
            projectIdDataGridViewTextBoxColumn.HeaderText = "ProjectId";
            projectIdDataGridViewTextBoxColumn.Name = "projectIdDataGridViewTextBoxColumn";
            projectIdDataGridViewTextBoxColumn.ReadOnly = true;
            projectIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // FunctionalAreaNames
            // 
            FunctionalAreaNames.DataPropertyName = "FunctionalAreaName";
            FunctionalAreaNames.HeaderText = "Functional Area";
            FunctionalAreaNames.Name = "FunctionalAreaNames";
            FunctionalAreaNames.ReadOnly = true;
            // 
            // projectDataGridViewTextBoxColumn
            // 
            projectDataGridViewTextBoxColumn.DataPropertyName = "Project";
            projectDataGridViewTextBoxColumn.HeaderText = "Project";
            projectDataGridViewTextBoxColumn.Name = "projectDataGridViewTextBoxColumn";
            projectDataGridViewTextBoxColumn.ReadOnly = true;
            projectDataGridViewTextBoxColumn.Visible = false;
            // 
            // FunctionalAreaIds
            // 
            FunctionalAreaIds.DataPropertyName = "FunctionalAreaId";
            FunctionalAreaIds.HeaderText = "FunctionalAreaId";
            FunctionalAreaIds.Name = "FunctionalAreaIds";
            FunctionalAreaIds.ReadOnly = true;
            FunctionalAreaIds.Visible = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 70);
            contextMenuStrip1.MouseDown += contextMenuStrip1_MouseDown;
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
            // functionalAreaBindingSource
            // 
            functionalAreaBindingSource.DataSource = typeof(Models.FunctionalArea);
            // 
            // panel1
            // 
            panel1.Controls.Add(button5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(447, 309);
            panel1.Name = "panel1";
            panel1.Size = new Size(328, 150);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint_1;
            // 
            // button5
            // 
            button5.BackColor = Color.Red;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(293, 8);
            button5.Name = "button5";
            button5.Size = new Size(32, 23);
            button5.TabIndex = 5;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(32, 8);
            label4.Name = "label4";
            label4.Size = new Size(246, 28);
            label4.TabIndex = 3;
            label4.Text = "Update Functional Area";
            // 
            // button2
            // 
            button2.BackColor = Color.RosyBrown;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(141, 110);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 11.25F);
            label1.Location = new Point(32, 68);
            label1.Name = "label1";
            label1.Size = new Size(157, 20);
            label1.TabIndex = 1;
            label1.Text = "Functional Area Name";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Palatino Linotype", 11.25F);
            textBox1.Location = new Point(199, 65);
            textBox1.MaxLength = 50;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(116, 28);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.RosyBrown;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button1.Location = new Point(406, 274);
            button1.Name = "button1";
            button1.Size = new Size(54, 29);
            button1.TabIndex = 2;
            button1.Text = "New";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(button4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBox2);
            panel2.Location = new Point(430, 330);
            panel2.Name = "panel2";
            panel2.Size = new Size(345, 158);
            panel2.TabIndex = 3;
            // 
            // button4
            // 
            button4.BackColor = Color.Red;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(301, 11);
            button4.Name = "button4";
            button4.Size = new Size(32, 23);
            button4.TabIndex = 4;
            button4.Text = "X";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(60, 11);
            label5.Name = "label5";
            label5.Size = new Size(217, 28);
            label5.TabIndex = 3;
            label5.Text = "Add Functional Area";
            label5.Click += label5_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.RosyBrown;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(122, 107);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "Save";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 11.25F);
            label2.Location = new Point(19, 65);
            label2.Name = "label2";
            label2.Size = new Size(157, 20);
            label2.TabIndex = 1;
            label2.Text = "Functional Area Name";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Palatino Linotype", 11.25F);
            textBox2.Location = new Point(182, 62);
            textBox2.MaxLength = 50;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(132, 28);
            textBox2.TabIndex = 0;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightBlue;
            label3.Font = new Font("Palatino Linotype", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(412, 22);
            label3.Name = "label3";
            label3.Size = new Size(302, 32);
            label3.TabIndex = 4;
            label3.Text = "Configure Functional Area";
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
            // FunctionalUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label3);
            Controls.Add(panel2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "FunctionalUserControl";
            Size = new Size(1363, 687);
            Load += FunctionalUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)functionalAreaBindingSource).EndInit();
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
        private BindingSource functionalAreaBindingSource;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Button button2;
        private Label label1;
        private TextBox textBox1;
        private Panel panel2;
        private Button button3;
        private Label label2;
        private TextBox textBox2;
        private Label label4;
        private Label label5;
        private Label label3;
        private Button button5;
        private Button button4;
        private Button button6;
        private Button button7;
        private DataGridViewTextBoxColumn projectIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn FunctionalAreaNames;
        private DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn FunctionalAreaIds;
    }
}
