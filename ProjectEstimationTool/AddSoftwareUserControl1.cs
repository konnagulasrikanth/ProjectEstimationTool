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
    public partial class AddSoftwareUserControl1 : UserControl
    {
        public AddSoftwareUserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Capture the values entered by the user in the textboxes
            string softwareName = textBox1.Text;
            int monthlyRate = Convert.ToInt32(textBox2.Text);

            // Establish a connection to the SQL Server database using Entity Framework
            using (ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext())
            {
                try
                {
                    // Create a new Software object with the entered values
                    Software newSoftware = new Software
                    {
                        SoftwareName = softwareName,
                        ProjectId = Form1.projectid, // Assuming Form1.projectid is available
                        MonthlyRate = monthlyRate
                    };

                    // Add the new Software object to the Software DbSet
                    db.Software.Add(newSoftware);

                    // Save changes to the database
                    int rowsAffected = db.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        // Data inserted successfully
                        MessageBox.Show("Data inserted successfully.");
                        // Assuming effortTypeUserControl.RefreshData() performs the necessary actions to refresh the UI or data grid
                        // effortTypeUserControl.RefreshData();
                    }
                    else
                    {
                        // No rows affected, something went wrong
                        MessageBox.Show("Failed to insert data.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


    }
}

