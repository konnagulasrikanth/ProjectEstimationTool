﻿using Org.BouncyCastle.Crypto.Tls;
using ProjectEstimationTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectEstimationTool
{
    public partial class Scope : UserControl
    {
        private ScopeAndEffort s = new ScopeAndEffort();
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        BindingList<ScopeAndEffort> ScopeEffortList;

        public Scope()
        {
            InitializeComponent();
            ScopeEffortList = new BindingList<ScopeAndEffort>();


            dataGridView1.DataSource = ScopeEffortList;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }

        private void Scope_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RosyBrown;
            dataGridView1.Columns[0].HeaderCell.Style.BackColor = Color.Magenta;
            dataGridView1.Columns[1].HeaderCell.Style.BackColor = Color.Yellow;
            loadScopeData();


            UpdateData();
            SetTotals();





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        public void loadScopeData()
        {
            var res = from t in db.ScopeAndEffort
                      where t.ProjectId == Form1.projectid
                      select t;
            dataGridView1.DataSource = res.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue;
            // Clear the TextBoxes for the next entry
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            richTextBox1.Clear();
            panel2.Visible = false;

            panel2.Visible = true;
            panel3.Visible = false;
            textBox1.Visible = true;
            textBox1.Text = "";
            label5.Visible = true;
            label25.Visible = true;



            var ef = db.FunctionalArea.Where(t => t.ProjectId == Form1.projectid).Select(t => t.FunctionalAreaName).Distinct();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(ef.ToArray());

            var fa = db.EffortType.Where(t => t.ProjectId == Form1.projectid).Select(t => t.EffortName).Distinct();
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(fa.ToArray());


            var fsa = db.FunctionalSubArea.Where(t => t.ProjectId == Form1.projectid).Select(t => t.FunctionalSubAreaName).Distinct();
            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(fsa.ToArray());


        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.RosyBrown;
            try
            {
                if (string.IsNullOrEmpty(comboBox1.SelectedItem?.ToString()) ||
                    string.IsNullOrEmpty(comboBox2.SelectedItem?.ToString()) ||
                    string.IsNullOrEmpty(comboBox3.SelectedItem?.ToString()) ||
                    string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please select the mandatory fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if textBox1 contains only numeric values
                if (!int.TryParse(textBox1.Text, out _))
                {
                    MessageBox.Show("Number of Operations must be a numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(textBox1.Text, out int numberOfOperations) || numberOfOperations <= 0)
                {
                    MessageBox.Show("Number of Operations is a mandatory field and must be greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var FunctAreaid = db.FunctionalArea
                    .Where(p => p.ProjectId == Form1.projectid && p.FunctionalAreaName == comboBox1.SelectedItem.ToString())
                    .Select(p => p.FunctionalAreaId)
                    .FirstOrDefault();

                var FunclSubAreaid = db.FunctionalSubArea
                    .Where(p => p.ProjectId == Form1.projectid && p.FunctionalSubAreaName == comboBox3.SelectedItem.ToString())
                    .Select(p => p.FunctionalSubAreaId)
                    .FirstOrDefault();

                var Effortid = db.EffortType
                    .Where(p => p.ProjectId == Form1.projectid && p.EffortName == comboBox2.SelectedItem.ToString())
                    .Select(p => p.EffortId)
                    .FirstOrDefault();
                var selectedEffort = db.EffortType
                        .Where(t => t.EffortId == Effortid && t.ProjectId == Form1.projectid)
                        .FirstOrDefault();
                int BarefactorPercentage = int.TryParse(textBox2.Text, out int basRefactor) ? basRefactor : 0;
                int DevRefactorPercentage = int.TryParse(textBox3.Text, out int devsRefactor) ? devsRefactor : 0;
                int QarefactorPercentage = int.TryParse(textBox4.Text, out int qasRefactor) ? qasRefactor : 0;

                decimal Bahrs = Convert.ToDecimal(selectedEffort.ActualEffort * (selectedEffort.Ba / 100.0)) * int.Parse(textBox1.Text);
                decimal Devhrs = Convert.ToDecimal(selectedEffort.ActualEffort * (selectedEffort.Dev / 100.0)) * int.Parse(textBox1.Text);
                decimal Qahrs = Convert.ToDecimal(selectedEffort.ActualEffort * (selectedEffort.Qa / 100.0)) * int.Parse(textBox1.Text);
                decimal BafinalHrs = (Bahrs - (decimal)(BarefactorPercentage / 100.0) * Bahrs);
                decimal DevFinalHrs = (Devhrs - (decimal)(DevRefactorPercentage / 100.0) * Devhrs);
                decimal QafinalHrs = (Qahrs - (decimal)(QarefactorPercentage / 100.0) * Qahrs);
                int Effort = (int)((Bahrs - (decimal)(BarefactorPercentage / 100.0) * Bahrs) +
                    (Devhrs - (decimal)(DevRefactorPercentage / 100.0) * Devhrs) +
                    (Qahrs - (decimal)(QarefactorPercentage / 100.0) * Qahrs));



                s = new ScopeAndEffort
                {
                    ProjectId = Form1.projectid,
                    FunctionalAreaName = comboBox1.SelectedItem?.ToString(),
                    EffortName = comboBox2.SelectedItem?.ToString(),
                    FunctionalSubAreaName = comboBox3.SelectedItem?.ToString(),
                    FunctionalAreaId = FunctAreaid,
                    FunctionalSubAreaId = FunclSubAreaid,
                    EffortId = Effortid,
                    BaHrs = Bahrs,
                    BafinalHrs = BafinalHrs,
                    DevHrs = Devhrs,
                    DevFinalHrs = DevFinalHrs,
                    QaHrs = Qahrs,
                    QafinalHrs = QafinalHrs,
                    Effort = Effort,
                    NumberOfOperations = int.TryParse(textBox1.Text, out int operations) ? operations : 0,
                    BarefactorPercentage = int.TryParse(textBox2.Text, out int baRefactor) ? baRefactor : 0,
                    DevRefactorPercentage = int.TryParse(textBox3.Text, out int devRefactor) ? devRefactor : 0,
                    QarefactorPercentage = int.TryParse(textBox4.Text, out int qaRefactor) ? qaRefactor : 0,
                    Description = richTextBox1.Text
                };

                // Validate refactor percentages individually (0 to 100) and collectively (not exceeding 300)

                if (s.BarefactorPercentage < 0) s.BarefactorPercentage = 0;
                if (s.DevRefactorPercentage < 0) s.DevRefactorPercentage = 0;
                if (s.QarefactorPercentage < 0) s.QarefactorPercentage = 0;

                if (s.BarefactorPercentage > 100) s.BarefactorPercentage = 100;
                if (s.DevRefactorPercentage > 100) s.DevRefactorPercentage = 100;
                if (s.QarefactorPercentage > 100) s.QarefactorPercentage = 100;

                if ((s.BarefactorPercentage > 100 || s.DevRefactorPercentage > 100 || s.QarefactorPercentage > 100))
                {
                    s.BarefactorPercentage = 100;
                    s.DevRefactorPercentage = 100;
                    s.QarefactorPercentage = 100;
                }

                db.ScopeAndEffort.Add(s);

                db.SaveChanges();
                SetTotals();

                loadScopeData();
                // Clear the TextBoxes for the next entry
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                richTextBox1.Clear();
                panel2.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panel3.Visible = true;
            panel2.Visible = false;
            var ef = db.FunctionalArea.Where(t => t.ProjectId == Form1.projectid).Select(t => t.FunctionalAreaName).Distinct();
            comboBox6.Items.Clear();
            comboBox6.Items.AddRange(ef.ToArray());

            var fa = db.EffortType.Where(t => t.ProjectId == Form1.projectid).Select(t => t.EffortName).Distinct();
            comboBox5.Items.Clear();
            comboBox5.Items.AddRange(fa.ToArray());


            var fsa = db.FunctionalSubArea.Where(t => t.ProjectId == Form1.projectid).Select(t => t.FunctionalSubAreaName).Distinct();
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(fsa.ToArray());

            if (dataGridView1.SelectedRows.Count > 0)
            {
                s = dataGridView1.SelectedRows[0].DataBoundItem as ScopeAndEffort;
                if (s != null)
                {

                    if (comboBox6.Items.Contains(s.FunctionalAreaName))
                        comboBox6.Text = s.FunctionalAreaName;

                    if (comboBox4.Items.Contains(s.FunctionalSubAreaName))
                        comboBox4.Text = s.FunctionalSubAreaName;

                    if (comboBox5.Items.Contains(s.EffortName))
                        comboBox5.Text = s.EffortName;

                    textBox10.Text = s.NumberOfOperations.ToString();
                    textBox9.Text = s.BarefactorPercentage.ToString();
                    textBox8.Text = s.DevRefactorPercentage.ToString();
                    textBox7.Text = s.QarefactorPercentage.ToString();
                    richTextBox2.Text = s.Description.ToString();
                    // Check if Functional Sub-Area is "Rules"
                    if (s.FunctionalSubAreaName == "Rules")
                    {
                        // Use rules from the EffortType table
                        int numberOfOperations = GetRulesFromEffortType(s.EffortName);

                        // Set the value in textBox10
                        textBox10.Text = numberOfOperations.ToString();

                        // Hide textBox10
                        textBox10.Visible = false;
                        label14.Visible = false;
                        label22.Visible = false;
                    }
                    else
                    {
                        // Allow the user to enter values for other Functional Sub-Areas
                        textBox10.Visible = true;
                        label14.Visible = true;
                        label22.Visible = true;
                    }


                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string effort = comboBox5.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(effort) ||
                string.IsNullOrEmpty(comboBox6.SelectedItem?.ToString()) ||
                string.IsNullOrEmpty(comboBox4.SelectedItem?.ToString()) ||
                string.IsNullOrEmpty(textBox9.Text) ||
                string.IsNullOrEmpty(textBox8.Text) ||
                string.IsNullOrEmpty(textBox7.Text) ||
                string.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("Please fill in all the mandatory fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate if numeric and greater than 0
            if (!int.TryParse(textBox10.Text, out int numberOfOperations) || numberOfOperations <= 0)
            {
                MessageBox.Show("Number of Operations must be a numeric value greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
  

            // Validate refactor percentages as numeric values (default to 0 if null or not numeric)
            int.TryParse(textBox9.Text, out int baRefactor);
            int.TryParse(textBox8.Text, out int devRefactor);
            int.TryParse(textBox7.Text, out int qaRefactor);

            // Ensure refactor percentages are within the valid range (0 to 100)
            baRefactor = Math.Max(0, Math.Min(100, baRefactor));
            devRefactor = Math.Max(0, Math.Min(100, devRefactor));
            qaRefactor = Math.Max(0, Math.Min(100, qaRefactor));
            var Effortid = db.EffortType.Where(p => p.ProjectId == Form1.projectid && p.EffortName == comboBox5.SelectedItem.ToString()).Select(p => p.EffortId).FirstOrDefault();


            var existingRecord = db.EffortType
                .FirstOrDefault(et => et.EffortName == comboBox5.SelectedItem.ToString() && et.ProjectId == Form1.projectid && et.EffortId != Effortid);

            if (existingRecord != null)
            {
                MessageBox.Show("This combination already exists in the EffortType table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method to prevent adding the duplicate record
            }
            var selectedEffort = from t in db.EffortType
                                 where t.EffortName == effort && t.ProjectId == Form1.projectid
                                 select t;
            var FunctAreaid = db.FunctionalArea.Where(p => p.ProjectId == Form1.projectid && p.FunctionalAreaName == comboBox6.SelectedItem.ToString()).Select(p => p.FunctionalAreaId).FirstOrDefault();
            var FunclSubAreaid = db.FunctionalSubArea.Where(p => p.ProjectId == Form1.projectid && p.FunctionalSubAreaName == comboBox4.SelectedItem.ToString()).Select(p => p.FunctionalSubAreaId).FirstOrDefault();
            try
            {

                s.FunctionalAreaName = comboBox6.SelectedItem.ToString();
                s.FunctionalSubAreaName = comboBox4.SelectedItem.ToString();
                s.EffortName = comboBox5.SelectedItem.ToString();
                s.Description = richTextBox2.Text;
                s.EffortId = Effortid;
                s.FunctionalAreaId = FunctAreaid;
                s.FunctionalSubAreaId = FunclSubAreaid;
                s.BarefactorPercentage = int.Parse(textBox9.Text);
                s.DevRefactorPercentage = int.Parse(textBox8.Text);
                s.QarefactorPercentage = int.Parse(textBox7.Text);
                s.NumberOfOperations = int.Parse(textBox10.Text);


                if (s.ScopeAndEffortId == 0) // Check if it's a new record (ID is 0)
                {
                    // Check if the same combination already exists
                    var existingRecords = db.ScopeAndEffort
                        .Where(se => se.ProjectId == s.ProjectId &&
                                     se.FunctionalAreaName == s.FunctionalAreaName &&
                                     se.EffortName == s.EffortName &&
                                     se.FunctionalSubAreaName == s.FunctionalSubAreaName)
                        .FirstOrDefault();

                    if (existingRecord != null)
                    {
                        MessageBox.Show("This combination already exists in the ScopeAndEffort table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Exit the method to prevent adding the duplicate record
                    }
                }

                if (selectedEffort.Any())
                {
                    // Update the existing record or add a new one
                    // Update the existing record
                    Decimal Bahrs = Convert.ToDecimal(selectedEffort.First().ActualEffort * s.NumberOfOperations);
                    Decimal Devhrs = Convert.ToDecimal(selectedEffort.First().ActualEffort * s.NumberOfOperations);
                    Decimal Qahrs = Convert.ToDecimal(selectedEffort.First().ActualEffort * s.NumberOfOperations);


                    s.BaHrs = Bahrs;
                    s.DevHrs = Devhrs;
                    s.QaHrs = Qahrs;
                    s.BafinalHrs = (Bahrs - (decimal)(s.BarefactorPercentage / 100.0) * Bahrs);
                    s.DevFinalHrs = (Devhrs - (decimal)(s.DevRefactorPercentage / 100.0) * Devhrs);
                    s.QafinalHrs = (Qahrs - (decimal)(s.QarefactorPercentage / 100.0) * Qahrs);
                    s.Effort = Convert.ToInt32(Bahrs - ((decimal)(s.BarefactorPercentage / 100.0) * Bahrs) +
                                 (Devhrs - (decimal)(s.DevRefactorPercentage / 100.0) * Devhrs) +
                                 (Qahrs - (decimal)(s.QarefactorPercentage / 100.0) * Qahrs));
                    if (s.ScopeAndEffortId == 0) // Check if it's a new record (ID is 0)
                    {
                        db.ScopeAndEffort.Add(s);
                    }

                    db.SaveChanges();
                    SetTotals();

                    loadScopeData();
                    panel3.Visible = false;
                }
                else
                {
                    MessageBox.Show("Effort not found in the EffortType table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];
                    if (selectedRow.DataBoundItem is ScopeAndEffort selectedScopeEffort)
                    {
                        int seid = selectedScopeEffort.ScopeAndEffortId;
                        var delete = db.ScopeAndEffort.FirstOrDefault(t => t.ScopeAndEffortId == seid);

                        if (delete != null)
                        {
                            db.ScopeAndEffort.Remove(delete);
                            db.SaveChanges();
                            loadScopeData();
                        }
                    }
                }
            }
        }
        private void SetTotals()
        {
            var scopeAndEffortQuery = db.ScopeAndEffort.Where(se => se.ProjectId == Form1.projectid);

            var BAFinalTotal = scopeAndEffortQuery.Sum(se => se.BafinalHrs);
            var DevFinalTotal = scopeAndEffortQuery.Sum(se => se.DevFinalHrs);
            var QAFinalTotal = scopeAndEffortQuery.Sum(se => se.QafinalHrs);
            var TotalEffort = scopeAndEffortQuery.Sum(se => se.Effort);
            var TotalOperations = scopeAndEffortQuery.Sum(se => se.NumberOfOperations);
            var BATotal = scopeAndEffortQuery.Sum(se => se.BaHrs);
            var DevTotal = scopeAndEffortQuery.Sum(se => se.DevHrs);
            var QATotal = scopeAndEffortQuery.Sum(se => se.QaHrs);
            label28.Text = BAFinalTotal.ToString();
            label30.Text = TotalOperations.ToString();
            label31.Text = TotalEffort.ToString();
            label32.Text = BATotal.ToString();
            label33.Text = DevTotal.ToString();
            label34.Text = DevFinalTotal.ToString();
            label35.Text = QATotal.ToString();
            label36.Text = QAFinalTotal.ToString();
        }




        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.RosyBrown;
            panel3.Visible = false;

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.RosyBrown;
            panel2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.BackColor = Color.LightBlue;
            SoftwarerateUserControl sc = new SoftwarerateUserControl();
            this.Hide();
            this.Parent.Controls.Add(sc);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Timeline tc = new Timeline();
            this.Hide();
            this.Parent.Controls.Add(tc);
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.Red;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = DefaultBackColor;
        }
        public void UpdateData()
        {
            try
            {
                var scopeAndEffortRecords = db.ScopeAndEffort
                    .Where(se => se.ProjectId == Form1.projectid)
                    .ToList();
                dataGridView1.DataSource = scopeAndEffortRecords;
                // Fetch updated FunctionalArea records from the database




                foreach (var scopeAndEffortRecord in scopeAndEffortRecords)
                {
                    var selectedEffort = db.EffortType
                        .Where(t => t.EffortId == scopeAndEffortRecord.EffortId && t.ProjectId == Form1.projectid)
                        .FirstOrDefault();
                    var functionalAreaRecords = db.FunctionalArea
                   .Where(fa => fa.FunctionalAreaId == scopeAndEffortRecord.FunctionalAreaId && fa.ProjectId == Form1.projectid)
                   .FirstOrDefault();

                    // Fetch updated FunctionalSubArea records from the database
                    var functionalSubAreaRecords = db.FunctionalSubArea
                        .Where(fsa => fsa.FunctionalSubAreaId == scopeAndEffortRecord.FunctionalSubAreaId && fsa.ProjectId == Form1.projectid)
                        .FirstOrDefault();
                    if (selectedEffort != null)
                    {
                        // Update the existing record
                        decimal Bahrs = Convert.ToDecimal(selectedEffort.ActualEffort * (selectedEffort.Ba / 100.0)) * scopeAndEffortRecord.NumberOfOperations;
                        decimal Devhrs = Convert.ToDecimal(selectedEffort.ActualEffort * (selectedEffort.Dev / 100.0)) * scopeAndEffortRecord.NumberOfOperations;
                        decimal Qahrs = Convert.ToDecimal(selectedEffort.ActualEffort * (selectedEffort.Qa / 100.0)) * scopeAndEffortRecord.NumberOfOperations;
                        scopeAndEffortRecord.EffortName = selectedEffort.EffortName;
                        scopeAndEffortRecord.FunctionalAreaName = functionalAreaRecords.FunctionalAreaName;
                        scopeAndEffortRecord.FunctionalSubAreaName = functionalSubAreaRecords.FunctionalSubAreaName;
                        scopeAndEffortRecord.BaHrs = Bahrs;
                        scopeAndEffortRecord.DevHrs = Devhrs;
                        scopeAndEffortRecord.QaHrs = Qahrs;
                        scopeAndEffortRecord.BafinalHrs = (Bahrs - (decimal)(scopeAndEffortRecord.BarefactorPercentage / 100.0) * Bahrs);
                        scopeAndEffortRecord.DevFinalHrs = (Devhrs - (decimal)(scopeAndEffortRecord.DevRefactorPercentage / 100.0) * Devhrs);
                        scopeAndEffortRecord.QafinalHrs = (Qahrs - (decimal)(scopeAndEffortRecord.QarefactorPercentage / 100.0) * Qahrs);
                        scopeAndEffortRecord.Effort = (int)((Bahrs - (decimal)(scopeAndEffortRecord.BarefactorPercentage / 100.0) * Bahrs) +
                            (Devhrs - (decimal)(scopeAndEffortRecord.DevRefactorPercentage / 100.0) * Devhrs) +
                            (Qahrs - (decimal)(scopeAndEffortRecord.QarefactorPercentage / 100.0) * Qahrs));


                        db.SaveChanges();



                    }
                    else
                    {
                        MessageBox.Show("Effort not found in the EffortType table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private int GetRulesFromEffortType(string effortType)
        {
            // Fetch rules from the EffortType table based on the selected effort type
            var rules = db.EffortType
                .Where(t => t.EffortName == effortType && t.ProjectId == Form1.projectid)
                .Select(t => t.Rules)
                .FirstOrDefault();
            string rulesAsString = rules.ToString();


            // If rules are found, parse and return the value
            if (int.TryParse(rulesAsString, out int numberOfOperations))
            {
                return numberOfOperations;
            }

            // Return 0 if parsing fails or no rules are found
            return 0;
        }

        private void UpdateRulesAdd()
        {
            // Get selected values from combo boxes
            string functionalArea = comboBox1.SelectedItem?.ToString();
            string functionalSubArea = comboBox3.SelectedItem?.ToString();
            string effortType = comboBox2.SelectedItem?.ToString();

            // Check if all necessary selections are made
            if (string.IsNullOrEmpty(functionalArea) || string.IsNullOrEmpty(effortType))
                return;

            // Check if Functional Sub-Area is "Rules"
            if (functionalSubArea == "Rules")
            {
                // Use rules from the EffortType table
                int numberOfOperations = GetRulesFromEffortType(effortType);

                // Set the value in textBox1
                textBox1.Text = numberOfOperations.ToString();

                // Hide textBox1
                textBox1.Visible = false;
                label5.Visible = false;
                label25.Visible = false;
            }
            else
            {
                // Allow the user to enter values for other Functional Sub-Areas
                // You may want to add validation for user input here
                textBox1.Visible = true;
                textBox1.Text = "";
                label5.Visible = true;
                label25.Visible = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            UpdateRulesAdd();



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRulesAdd();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRulesEdit();

        }
        private void UpdateRulesEdit()
        {
            // Get selected values from combo boxes
            string functionalArea = comboBox6.SelectedItem?.ToString();
            string functionalSubArea = comboBox4.SelectedItem?.ToString();
            string effortType = comboBox5.SelectedItem?.ToString();

            // Check if all necessary selections are made
            if (string.IsNullOrEmpty(functionalArea) || string.IsNullOrEmpty(effortType))
                return;

            // Check if Functional Sub-Area is "Rules"
            if (functionalSubArea == "Rules")
            {
                // Use rules from the EffortType table
                int numberOfOperations = GetRulesFromEffortType(effortType);

                // Set the value in textBox10
                textBox10.Text = numberOfOperations.ToString();

                // Hide textBox10
                textBox10.Visible = false;
                label14.Visible = false;
                label22.Visible = false;
            }
            else
            {
                // Allow the user to enter values for other Functional Sub-Areas
                textBox10.Visible = true;
                textBox10.Text = "";
                label14.Visible = true;
                label22.Visible = true;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRulesEdit();


        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            int i = richTextBox2.Text.Length;

            if (i >= 0)
            {
                label38.Text = i.ToString();
            }

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int i = richTextBox1.Text.Length;

            if (i >= 0)
            {
                label40.Text = i.ToString();
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
