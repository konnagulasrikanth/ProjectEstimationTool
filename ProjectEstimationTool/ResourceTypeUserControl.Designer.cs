namespace ProjectEstimationTool
{
    partial class ResourceTypeUserControl
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
            resourceTypeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            typeNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            resourceTypesBindingSource = new BindingSource(components);
            button1 = new Button();
            label1 = new Label();
            panel1 = new Panel();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            button5 = new Button();
            button4 = new Button();
            textBox2 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)resourceTypesBindingSource).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { resourceTypeIdDataGridViewTextBoxColumn, typeNameDataGridViewTextBoxColumn });
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridView1.DataSource = resourceTypesBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(474, 73);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.RosyBrown;
            dataGridViewCellStyle3.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(257, 79);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            // 
            // resourceTypeIdDataGridViewTextBoxColumn
            // 
            resourceTypeIdDataGridViewTextBoxColumn.DataPropertyName = "ResourceTypeId";
            resourceTypeIdDataGridViewTextBoxColumn.HeaderText = "ResourceTypeId";
            resourceTypeIdDataGridViewTextBoxColumn.Name = "resourceTypeIdDataGridViewTextBoxColumn";
            resourceTypeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // typeNameDataGridViewTextBoxColumn
            // 
            typeNameDataGridViewTextBoxColumn.DataPropertyName = "TypeName";
            typeNameDataGridViewTextBoxColumn.HeaderText = "Resource Type";
            typeNameDataGridViewTextBoxColumn.Name = "typeNameDataGridViewTextBoxColumn";
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
            // resourceTypesBindingSource
            // 
            resourceTypesBindingSource.DataSource = typeof(Models.ResourceTypes);
            // 
            // button1
            // 
            button1.BackColor = Color.RosyBrown;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button1.Location = new Point(474, 188);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(72, 31);
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
            label1.Location = new Point(462, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(290, 32);
            label1.TabIndex = 1;
            label1.Text = "Configure Resource Type";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(487, 227);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 186);
            panel1.TabIndex = 4;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(192, 0, 0);
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button2.Location = new Point(346, 20);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(35, 31);
            button2.TabIndex = 9;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.RosyBrown;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button3.Location = new Point(131, 149);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(96, 31);
            button3.TabIndex = 8;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(204, 85);
            textBox1.Margin = new Padding(4);
            textBox1.MaxLength = 20;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(127, 28);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 11.25F);
            label2.Location = new Point(62, 93);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 6;
            label2.Text = "Resource Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold);
            label3.Location = new Point(83, 25);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(215, 26);
            label3.TabIndex = 5;
            label3.Text = "Update Resource Type";
            // 
            // panel2
            // 
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(554, 200);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(362, 195);
            panel2.TabIndex = 10;
            // 
            // button5
            // 
            button5.BackColor = Color.RosyBrown;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button5.Location = new Point(110, 141);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(96, 31);
            button5.TabIndex = 8;
            button5.Text = "Save";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(192, 0, 0);
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button4.Location = new Point(315, 23);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(35, 31);
            button4.TabIndex = 9;
            button4.Text = "X";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(165, 83);
            textBox2.Margin = new Padding(4);
            textBox2.MaxLength = 20;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(127, 28);
            textBox2.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Palatino Linotype", 11.25F);
            label4.Location = new Point(20, 86);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(106, 20);
            label4.TabIndex = 6;
            label4.Text = "Resource Type";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold);
            label5.Location = new Point(79, 23);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(188, 26);
            label5.TabIndex = 5;
            label5.Text = "Add Resource Type";
            // 
            // button6
            // 
            button6.BackColor = Color.RosyBrown;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button6.Location = new Point(1146, 4);
            button6.Margin = new Padding(4);
            button6.Name = "button6";
            button6.Size = new Size(85, 31);
            button6.TabIndex = 11;
            button6.Text = "Previous";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.RosyBrown;
            button7.FlatStyle = FlatStyle.Popup;
            button7.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold);
            button7.Location = new Point(1248, 4);
            button7.Margin = new Padding(4);
            button7.Name = "button7";
            button7.Size = new Size(85, 31);
            button7.TabIndex = 12;
            button7.Text = "Next";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // ResourceTypeUserControl
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(label1);
            Font = new Font("Palatino Linotype", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "ResourceTypeUserControl";
            Size = new Size(1363, 687);
            Load += ResourceTypeUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)resourceTypesBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button button1;
        private Label label1;
        private BindingSource resourceTypesBindingSource;
        private Panel panel1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private DataGridViewTextBoxColumn resourceTypeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeNameDataGridViewTextBoxColumn;
        private Panel panel2;
        private Button button4;
        private Button button5;
        private TextBox textBox2;
        private Label label4;
        private Label label5;
        private Button button6;
        private Button button7;
    }
}
