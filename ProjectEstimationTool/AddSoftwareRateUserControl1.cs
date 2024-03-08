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

namespace ProjectEstimationTool
{
    public partial class AddSoftwareRateUserControl1 : UserControl
    {
        public AddSoftwareRateUserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Capture the values entered by the user in the textboxes
            int projectId = Form1.projectid; // Assuming Form1.projectid is available
            int countryname = Convert.ToInt32(textBox1.Text); // Assuming you have a TextBox named textBoxCountryId
            int resourceTypeId = Convert.ToInt32(textBox2.Text); // Assuming you have a TextBox named textBoxResourceTypeId
            int levelId = Convert.ToInt32(textBox3.Text); // Assuming you have a TextBox named textBoxLevelId
            int hourlyRate = Convert.ToInt32(textBox4.Text); // Assuming you have a TextBox named textBoxHourlyRate

            // Establish a connection to the SQL Server database using Entity Framework
            using (ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext())
            {
                try
                {
                    // Create a new Resource object with the entered values
                    Resource newResource = new Resource
                    {
                        ProjectId = projectId,
                        /*  CountryId = countryId,
                          ResourceTypeId = resourceTypeId,
                          LevelId = levelId,*/
                      //  CountryName = countryname,

                        HourlyRate = hourlyRate
                    };

                    // Add the new Resource object to the Resource DbSet
                    db.Resource.Add(newResource);

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
