namespace ProjectEstimationTool
{
    partial class SoftwareCostingTest
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
            label21 = new Label();
            SuspendLayout();
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.LightBlue;
            label21.Font = new Font("Palatino Linotype", 20F, FontStyle.Bold);
            label21.Location = new Point(538, 176);
            label21.Name = "label21";
            label21.Size = new Size(226, 37);
            label21.TabIndex = 24;
            label21.Text = "SoftwareCosting";
            // 
            // SoftwareCostingTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label21);
            Name = "SoftwareCostingTest";
            Size = new Size(1306, 704);
            Load += SoftwareCostingTest_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label21;
    }
}
