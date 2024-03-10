using Microsoft.Data.SqlClient;
using ProjectEstimationTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectEstimationTool
{
    public partial class SoftwarerateUserControl : UserControl
    {
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        private Software s;
        static DataTable dt = new DataTable();

        public DataGridView MyDataGridView
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
        }



        public SoftwarerateUserControl()
        {
            InitializeComponent();
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }



        private void SoftwarerateUserControl_Load(object sender, EventArgs e)
        {
            LoadSoftwareData();
     

            panel1.Visible = false;
            panel2.Visible = false;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadSoftwareData()
        {
            var res = from t in db.Software
                      where t.ProjectId == Form1.projectid
                      select t;
            dataGridView1.DataSource = res.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue;
            textBox1.Text = "";
            textBox2.Text = "";
            panel1.Visible = true;
            panel2.Visible = false;


        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                s = dataGridView1.SelectedRows[0].DataBoundItem as Software;
                if (s != null)
                {
                    textBox4.Text = s.SoftwareName;
                    textBox3.Text = s.MonthlyRate.ToString();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    if (selectedRow.DataBoundItem is Software selectedResource)
                    {
                        int resourceId = selectedResource.SoftwareId;

                        var resourceToDelete = db.Software.FirstOrDefault(r => r.SoftwareId == resourceId);

                        if (resourceToDelete != null)
                        {
                            db.Software.Remove(resourceToDelete);
                            db.SaveChanges();
                            LoadSoftwareData();
                        }
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
        }
        private bool SoftwareNameExists(string softwareName, int currentSoftwareId)
        {
            var existingSoftware = db.Software
                .FirstOrDefault(s =>
                    s.SoftwareName.ToLower() == softwareName.ToLower() &&
                    s.ProjectId == Form1.projectid &&
                    s.SoftwareId != currentSoftwareId);

            return existingSoftware != null;
        }

        private void ShowValidationMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool IsValidSoftwareName(string softwareName)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(softwareName, "^[a-zA-Z\\s\\-]+$");
        }

        private bool IsValidNumericValue(string value, out int result)
        {
            return int.TryParse(value, out result);
        }

        private bool IsDuplicateSoftwareName(string softwareName, int? excludeSoftwareId = null)
        {
            string lowerSoftwareName = softwareName.ToLower();
            return db.Software.Any(s => s.SoftwareName.ToLower() == lowerSoftwareName && s.ProjectId == Form1.projectid && (excludeSoftwareId == null || s.SoftwareId != excludeSoftwareId));
        }
        public bool SetToolTip(System.Windows.Forms.TextBox textBox, string message)
        {
            try
            {
                string trimmedText = textBox.Text.Trim(); // Remove leading and trailing white spaces

                if (string.IsNullOrWhiteSpace(trimmedText))
                {
                    MessageBox.Show("TextBox cannot be empty");
                    return true;
                }
                else if (!ContainsAlphabet(trimmedText))
                {
                    MessageBox.Show("TextBox should contain atleast one Alphabet");                   
                    return true;
                }
                else if (ContainsMultipleWhiteSpaces(trimmedText))
                {
                    MessageBox.Show("Text BOx should only contain one space in between words");
                    return true;
                }
                else if (ContainsMultipleSpecialCharacters(trimmedText))
                {
                    MessageBox.Show("Text B0x should only contain one Special caharacters in between words");
                    return true;
                }
                else
                {
                    
                    return false;
                }
            }
            catch { return false; }
        }
        public bool ContainsAlphabet(string value)
        {
            try
            {
                // Define a regular expression pattern to match alphabetic characters
                string pattern = @"[a-zA-Z]";
                // Matches a string that contains at least one alphabet character

                // Check if the string contains at least one alphabet character according to the pattern
                return Regex.IsMatch(value, pattern);
            }
            catch { return false; }
        }
        public bool ContainsMultipleWhiteSpaces(string value)
        {
            try
            {
                // Define a regular expression pattern to match multiple white spaces between words
                string pattern = @"\s{2,}";
                // Matches a string that contains multiple white spaces between words

                // Check if the string contains multiple white spaces between words according to the pattern
                return Regex.IsMatch(value, pattern);
            }
            catch { return false; }
        }

        public bool ContainsMultipleSpecialCharacters(string value)
        {
            try
            {
                // Define a regular expression pattern to match multiple special characters between words
                string pattern = @"[^A-Za-z0-9\s]{2,}";
                // Matches a string that contains multiple special characters between words

                // Check if the string contains multiple special characters between words according to the pattern
                return Regex.IsMatch(value, pattern);
            }
            catch { return false; }
        }
        public bool TextValidation(System.Windows.Forms.TextBox textBox, string message)
        {
            try
            {
                if (!int.TryParse(message, out int value))
                {
                    MessageBox.Show("Please enter a valid integer value");
                    return true; // Validation failed
                }
                else if (value < 0)
                {
                    MessageBox.Show("Please enter positive values");
                    return true; // Validation failed
                }
                else if (value > Int32.MaxValue)
                {
                    MessageBox.Show("Please enter shorter value");
                    return true; // Validation failed
                }
                else
                {
                    return false; // Validation success
                }
            }
            catch { return false; }

        }
        private bool ValidateSoftwareForAdd()
        {
            // Validate that all the required fields are filled
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                ShowValidationMessage("Please fill in all the required fields.");
                return false;
            }

            // Validate that Software Name contains only alphabets, hyphens, spaces
            if (!IsValidSoftwareName(textBox1.Text))
            {
                ShowValidationMessage("Error: Software Name should only contain alphabets, hyphens, and spaces.");
                return false;
            }

            // Validate that Monthly Rate is a valid numeric value
            if (!IsValidNumericValue(textBox2.Text, out _))
            {
                ShowValidationMessage("Please enter a valid numeric value for Monthly Rate.");
                return false;
            }

            // Validate that the software name is not duplicated (case-insensitive)
            // Validate that the software name is not duplicated (case-insensitive)
            if (SoftwareNameExists(textBox1.Text, 0))
            {
                MessageBox.Show("Software with the same name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidateSoftwareForEdit()
        {
            // Validate that all the required fields are filled
            if (string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                ShowValidationMessage("Please fill in all the required fields.");
                return false;
            }

            // Validate that Software Name contains only alphabets, hyphens, spaces
            if (!IsValidSoftwareName(textBox4.Text))
            {
                ShowValidationMessage("Error: Software Name should only contain alphabets, hyphens, and spaces.");
                return false;
            }

            // Validate that Monthly Rate is a valid numeric value
            if (!IsValidNumericValue(textBox3.Text, out _))
            {
                ShowValidationMessage("Please enter a valid numeric value for Monthly Rate.");
                return false;
            }

            // Validate that the software name is not duplicated (case-insensitive) excluding the current edited item
            if (SoftwareNameExists(textBox4.Text, s.SoftwareId))
            {
                MessageBox.Show("Software with the same name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextValidation(textBox2, textBox2.Text))
                {
                    // Validation failed
                    return;
                }
                if (SetToolTip(textBox1,textBox1.Text))
                {
                    return;
                }
                // Check if the software name already exists
                if (SoftwareNameExists(textBox1.Text, 0))
                {
                    MessageBox.Show("Software with the same name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var newSoftware = new Software
                    {
                        ProjectId = Form1.projectid,
                        SoftwareName = textBox1.Text.Trim(),
                        MonthlyRate = int.Parse(textBox2.Text),
                    };

                    db.Software.Add(newSoftware);
                    db.SaveChanges();
                    LoadSoftwareData();
                    button1.BackColor = Color.RosyBrown;

                    panel1.Visible = false;
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid numeric value for Monthly Rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextValidation(textBox3, textBox3.Text))
                {
                    // Validation failed
                    return;
                }
                if (SetToolTip(textBox4, textBox4.Text))
                {
                    return;
                }
                // Validate that the software name is not duplicated (case-insensitive) excluding the current edited item
                if (SoftwareNameExists(textBox4.Text, s.SoftwareId))
                {
                    MessageBox.Show("Software with the same name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate that MonthlyRate is a valid numeric value
                if (!int.TryParse(textBox3.Text, out int monthlyRate))
                    {
                        MessageBox.Show("Please enter a valid numeric value for Monthly Rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Your existing code to update the software details
                    s.SoftwareName = textBox4.Text.Trim();
                    s.MonthlyRate = monthlyRate;
                    db.SaveChanges();
                    LoadSoftwareData();
                
                panel2.Visible = false;
                panel1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.RosyBrown;
            textBox1.Text = "";
            textBox2.Text = "";

            panel1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ResourceRateUserControl rc = new ResourceRateUserControl();
            this.Hide();
            this.Parent.Controls.Add(rc);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Scope sc = new Scope();
            this.Hide();
            this.Parent.Controls.Add(sc);
        }
       


    }
}

