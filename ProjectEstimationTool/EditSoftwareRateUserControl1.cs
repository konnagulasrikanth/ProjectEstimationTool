using ProjectEstimationTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectEstimationTool
{
    public partial class EditSoftwareRateUserControl1 : UserControl
    {
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        private int softwareId;
        private string softwareName;
        private int monthlyRate;
        private SoftwarerateUserControl sf;
        public EditSoftwareRateUserControl1()
        {
            InitializeComponent();
            sf = new SoftwarerateUserControl();
        }
        public void UpdateSoftware(int id, string name, int rate)
        {
            softwareId = id;
            softwareName = name;
            monthlyRate = rate;
            UpdateTextBoxes();
        }
        private void UpdateTextBoxes()
        {
            textBox1.Text = softwareName;
            textBox2.Text = monthlyRate.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve the existing Software from the database
            Software existingSoftware = db.Software.Find(softwareId);

            if (existingSoftware != null)
            {
                // Update the properties with the values from the textboxes
                existingSoftware.SoftwareName = textBox1.Text;
                existingSoftware.MonthlyRate = int.Parse(textBox2.Text);

                // Save changes back to the database
                db.SaveChanges();
            

                MessageBox.Show("Software updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Software not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    
    }

