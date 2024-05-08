namespace ProjectEstimationTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            button3 = new Button();
            label5 = new Label();
            comboBox1 = new ComboBox();
            projectBindingSource = new BindingSource(components);
            label6 = new Label();
            button4 = new Button();
            label9 = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            label12 = new Label();
            label13 = new Label();
            panel5 = new Panel();
            panel6 = new Panel();
            label4 = new Label();
            button5 = new Button();
            button6 = new Button();
            label7 = new Label();
            label8 = new Label();
            panel4 = new Panel();
            label11 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)projectBindingSource).BeginInit();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.LightBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(36, 237);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(219, 40);
            button1.TabIndex = 0;
            button1.Text = "Create New Project";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.LightBlue;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(36, 413);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(219, 44);
            button2.TabIndex = 1;
            button2.Text = "Continue With Existing Project";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Palatino Linotype", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(364, 24);
            label1.Name = "label1";
            label1.Size = new Size(450, 55);
            label1.TabIndex = 2;
            label1.Text = "Project Estimation Tool";
            label1.Click += label1_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 51);
            label3.Name = "label3";
            label3.Size = new Size(163, 22);
            label3.TabIndex = 4;
            label3.Text = "Enter Project Name :";
            label3.Click += label3_Click_1;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(179, 47);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(156, 25);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button3
            // 
            button3.BackColor = Color.RosyBrown;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(137, 87);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(75, 26);
            button3.TabIndex = 7;
            button3.Text = "Create";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(133, 23);
            label5.Name = "label5";
            label5.Size = new Size(156, 26);
            label5.TabIndex = 8;
            label5.Text = "Existing Project ";
            label5.Click += label5_Click;
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(200, 79);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(158, 26);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // projectBindingSource
            // 
            projectBindingSource.DataSource = typeof(Models.Project);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 79);
            label6.Name = "label6";
            label6.Size = new Size(182, 22);
            label6.TabIndex = 10;
            label6.Text = "Select Existing Project :";
            label6.Click += label6_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.RosyBrown;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(115, 118);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(75, 32);
            button4.TabIndex = 11;
            button4.Text = "Open";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Red;
            label9.Location = new Point(29, 161);
            label9.Name = "label9";
            label9.Size = new Size(44, 18);
            label9.TabIndex = 17;
            label9.Text = "label9";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightCyan;
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1355, 707);
            panel1.TabIndex = 18;
            panel1.Paint += panel1_Paint_3;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label13);
            panel3.Location = new Point(146, 197);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(551, 266);
            panel3.TabIndex = 20;
            panel3.Paint += panel3_Paint;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.DarkCyan;
            label12.Location = new Point(6, 79);
            label12.Name = "label12";
            label12.Size = new Size(549, 130);
            label12.TabIndex = 24;
            label12.Text = resources.GetString("label12.Text");
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Palatino Linotype", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.IndianRed;
            label13.Location = new Point(3, 43);
            label13.Name = "label13";
            label13.Size = new Size(448, 32);
            label13.TabIndex = 5;
            label13.Text = "Welcome to our Project Estimation Tool!\r\n";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(label5);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(comboBox1);
            panel5.Controls.Add(button4);
            panel5.Controls.Add(label9);
            panel5.Location = new Point(710, 344);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(366, 186);
            panel5.TabIndex = 22;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(label4);
            panel6.Controls.Add(button5);
            panel6.Controls.Add(button6);
            panel6.Controls.Add(label7);
            panel6.Controls.Add(label8);
            panel6.Font = new Font("Segoe Script", 15.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            panel6.Location = new Point(168, 249);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(537, 223);
            panel6.TabIndex = 23;
            panel6.Paint += panel6_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LightBlue;
            label4.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(198, 18);
            label4.Name = "label4";
            label4.Size = new Size(143, 28);
            label4.TabIndex = 16;
            label4.Text = "Project Name";
            // 
            // button5
            // 
            button5.BackColor = Color.RosyBrown;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(290, 61);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(233, 47);
            button5.TabIndex = 19;
            button5.Text = "Get Started";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click_1;
            // 
            // button6
            // 
            button6.BackColor = Color.RosyBrown;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(258, 146);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(267, 43);
            button6.TabIndex = 20;
            button6.Text = "Go to configurations";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(12, 72);
            label7.Name = "label7";
            label7.Size = new Size(277, 22);
            label7.TabIndex = 17;
            label7.Text = "Continue With Default Configurations :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(40, 155);
            label8.Name = "label8";
            label8.Size = new Size(119, 22);
            label8.TabIndex = 18;
            label8.Text = "Configurations :";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(label11);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(button3);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(708, 189);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(347, 152);
            panel4.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Red;
            label11.Location = new Point(44, 124);
            label11.Name = "label11";
            label11.Size = new Size(51, 18);
            label11.TabIndex = 9;
            label11.Text = "label11";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(65, 8);
            label2.Name = "label2";
            label2.Size = new Size(185, 26);
            label2.TabIndex = 8;
            label2.Text = "Create New Project";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label10);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(1082, -2);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(312, 851);
            panel2.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(33, 152);
            label10.Name = "label10";
            label10.Size = new Size(221, 21);
            label10.TabIndex = 2;
            label10.Text = "Start Estimating Your Project !";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1355, 707);
            Controls.Add(panel6);
            Controls.Add(panel3);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Font = new Font("Palatino Linotype", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            RightToLeft = RightToLeft.No;
            Text = "Project Estimation Tool";
            TransparencyKey = Color.FromArgb(0, 192, 0);
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)projectBindingSource).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label3;
        private TextBox textBox1;
        private Button button3;
        private Label label5;
        private ComboBox comboBox1;
        private Label label6;
        private Button button4;
        private Label label9;
        private BindingSource projectBindingSource;
        private Panel panel1;
        private Panel panel2;
        private Label label10;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label label13;
        private Label label4;
        private Button button5;
        private Button button6;
        private Label label7;
        private Label label8;
        private Label label12;
        private Label label2;
        private Label label11;
    }
}
