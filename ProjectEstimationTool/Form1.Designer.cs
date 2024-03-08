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
            button1.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(67, 291);
            button1.Name = "button1";
            button1.Size = new Size(162, 35);
            button1.TabIndex = 0;
            button1.Text = "Create New Project";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(37, 444);
            button2.Name = "button2";
            button2.Size = new Size(219, 39);
            button2.TabIndex = 1;
            button2.Text = "Continue With Existing Project";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightBlue;
            label1.Font = new Font("Palatino Linotype", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(364, 21);
            label1.Name = "label1";
            label1.Size = new Size(450, 55);
            label1.TabIndex = 2;
            label1.Text = "Project Estimation Tool";
            label1.Click += label1_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 45);
            label3.Name = "label3";
            label3.Size = new Size(152, 18);
            label3.TabIndex = 4;
            label3.Text = "Enter Project Name :";
            label3.Click += label3_Click_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(179, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(156, 23);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button3
            // 
            button3.Font = new Font("Palatino Linotype", 9.75F);
            button3.Location = new Point(137, 77);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 7;
            button3.Text = "Create";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(133, 20);
            label5.Name = "label5";
            label5.Size = new Size(146, 26);
            label5.TabIndex = 8;
            label5.Text = "Existing Project ";
            label5.Click += label5_Click;
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(237, 70);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
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
            label6.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 70);
            label6.Name = "label6";
            label6.Size = new Size(210, 22);
            label6.TabIndex = 10;
            label6.Text = "Select Existing Project :";
            label6.Click += label6_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(115, 104);
            button4.Name = "button4";
            button4.Size = new Size(75, 31);
            button4.TabIndex = 11;
            button4.Text = "Open";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Red;
            label9.Location = new Point(175, 146);
            label9.Name = "label9";
            label9.Size = new Size(41, 16);
            label9.TabIndex = 17;
            label9.Text = "label9";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1338, 706);
            panel1.TabIndex = 18;
            panel1.Paint += panel1_Paint_3;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label13);
            panel3.Location = new Point(86, 190);
            panel3.Name = "panel3";
            panel3.Size = new Size(551, 219);
            panel3.TabIndex = 20;
            panel3.Paint += panel3_Paint;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.DarkCyan;
            label12.Location = new Point(2, 72);
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
            label13.Location = new Point(3, 11);
            label13.Name = "label13";
            label13.Size = new Size(448, 32);
            label13.TabIndex = 5;
            label13.Text = "Welcome to our Project Estimation Tool!";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(label5);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(comboBox1);
            panel5.Controls.Add(button4);
            panel5.Controls.Add(label9);
            panel5.Location = new Point(708, 339);
            panel5.Name = "panel5";
            panel5.Size = new Size(366, 176);
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
            panel6.Location = new Point(144, 220);
            panel6.Name = "panel6";
            panel6.Size = new Size(537, 197);
            panel6.TabIndex = 23;
            panel6.Paint += panel6_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(198, 16);
            label4.Name = "label4";
            label4.Size = new Size(143, 28);
            label4.TabIndex = 16;
            label4.Text = "Project Name";
            // 
            // button5
            // 
            button5.Font = new Font("Palatino Linotype", 9.75F);
            button5.Location = new Point(290, 54);
            button5.Name = "button5";
            button5.Size = new Size(233, 42);
            button5.TabIndex = 19;
            button5.Text = "Get Started";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // button6
            // 
            button6.Font = new Font("Palatino Linotype", 9.75F);
            button6.Location = new Point(258, 129);
            button6.Name = "button6";
            button6.Size = new Size(267, 38);
            button6.TabIndex = 20;
            button6.Text = "Go to configurations";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(12, 63);
            label7.Name = "label7";
            label7.Size = new Size(271, 18);
            label7.TabIndex = 17;
            label7.Text = "Continue With Default Configurations :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(28, 149);
            label8.Name = "label8";
            label8.Size = new Size(109, 18);
            label8.TabIndex = 18;
            label8.Text = "Configurations";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(label11);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(button3);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(708, 167);
            panel4.Name = "panel4";
            panel4.Size = new Size(347, 134);
            panel4.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Red;
            label11.Location = new Point(44, 109);
            label11.Name = "label11";
            label11.Size = new Size(47, 16);
            label11.TabIndex = 9;
            label11.Text = "label11";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(65, 7);
            label2.Name = "label2";
            label2.Size = new Size(171, 26);
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
            panel2.Name = "panel2";
            panel2.Size = new Size(312, 751);
            panel2.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(41, 149);
            label10.Name = "label10";
            label10.Size = new Size(213, 21);
            label10.TabIndex = 2;
            label10.Text = "Start Estimating Your Project";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1338, 706);
            Controls.Add(panel6);
            Controls.Add(panel3);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Project Estimation Tool";
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
