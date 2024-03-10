using iTextSharp.text.pdf;
using iTextSharp.text;
using ProjectEstimationTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rectangle = System.Drawing.Rectangle;
using System.Drawing.Printing;
using Org.BouncyCastle.Crypto.Tls;

namespace ProjectEstimationTool
{
    public partial class SummaryUserControl : UserControl
    {
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        private int TotalEfforHours;
        private int TotalsoftwareCost;
        private double TotalCost;
        private double Grandtotal;
        private double contigency;
        private double travelbudget;

        public SummaryUserControl()
        {
            InitializeComponent();

            //textBox1.Text = "5";
            //textBox2.Text = "20";
            label22.Visible = false;

        }
        private void LoadSummaryData()
        {
            try
            {
                var summary = db.Summary.FirstOrDefault(p => p.ProjectId == Form1.projectid);

                if (summary != null)
                {
                    // If a summary record exists, load the data from the database
                    textBox1.Text = summary.TravelBudget.ToString();
                    textBox2.Text = summary.Contingency.ToString();
                }
                else
                {
                    // If no summary record exists, use default values and create a new record
                    travelbudget = 5;
                    contigency = 20;
                    textBox1.Text = travelbudget.ToString();
                    textBox2.Text = contigency.ToString();

                    var sum = new Summary
                    {
                        ProjectId = Form1.projectid,
                        TravelBudget = travelbudget,
                        Contingency = contigency
                    };

                    db.Summary.Add(sum);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SummaryUserControl_Load(object sender, EventArgs e)
        {
            label25.Visible = false;
            label26.Visible = false;
            LoadSummaryData();

            label1.Text = Form1.projectname;
            //for total efforts
            var EffortHours = db.Timeline.Where(s => s.ProjectId == Form1.projectid).Sum(s => s.EffHrs);
            TotalEfforHours = EffortHours;
            label6.Text = $"{EffortHours.ToString()} Hours";

            //resource cost
            var Resourcecost = db.ResourceCosting.Where(r => r.ProjectId == Form1.projectid).Sum(s => s.Cost);
            label10.Text = Resourcecost.ToString();
            label10.Text = $"$ {Resourcecost:#,##0.00}";

            //softwarecost
            var softwarecost = db.Software.Where(s => s.ProjectId == Form1.projectid).Sum(s => s.MonthlyRate);
            var softwaredata = db.ResourceCosting.Where(p=>p.ProjectId==Form1.projectid).ToList();
            var numofres = db.ResourceCosting.Where(n => n.ProjectId == Form1.projectid).Sum(n => n.ResCount);
            //var duartioninmonths = db.Timeline.Where(n => n.ProjectId == Form1.projectid).Max(n => n.Mm);
            int softcost = 0;
            foreach (var phase in softwaredata)
            {
                var durationinmonths = phase.DurationMm;
                softcost += durationinmonths * softwarecost * phase.ResCount;
            }

            TotalsoftwareCost = softcost;
            label12.Text = Convert.ToString(TotalsoftwareCost);
            label12.Text = $"$ {TotalsoftwareCost:#,##0.00}";
            //totalcost
            TotalCost = TotalsoftwareCost + Resourcecost;
            label14.Text = Convert.ToString(TotalCost);
            label14.Text = $"$ {TotalCost:#,##0.00}";

            //travelbudget percentage
            int TravelBudgetPer = Convert.ToInt32(textBox1.Text);

            int ContigencyPer = Convert.ToInt32(textBox2.Text);
            double TravelBudget = TotalCost * TravelBudgetPer / 100.0;
            double Contigency = TotalCost * ContigencyPer / 100.0;
            label17.Text = Convert.ToString(TravelBudget);
            label17.Text = $"$ {TravelBudget:#,##0.00}";
            label18.Text = Convert.ToString(Contigency);
            label18.Text = $"$ {Contigency:#,##0.00}";
            Grandtotal = TotalCost + Contigency + TravelBudget;
            label20.Text = Convert.ToString(Grandtotal);
            label20.Text = $"$ {Grandtotal:#,##0.00}";
            label21.Text = NumberToWordsConverter.ConvertToWords(Grandtotal);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label25.Visible = true;

            if (!string.IsNullOrEmpty(textBox1.Text) && int.TryParse(textBox1.Text, out int travelbudgetper))
            {
                if (travelbudgetper >= 0 && travelbudgetper <= 200)
                {
                    try
                    {
                        // Calculate travel budget and update labels
                        double travelbudget = TotalCost * travelbudgetper / 100.0;
                        Grandtotal = TotalCost + travelbudget + contigency;

                        label17.Text = $"$ {travelbudget:#,##0.00}";
                        label20.Text = $"$ {Grandtotal:#,##0.00}";
                        label21.Text = NumberToWordsConverter.ConvertToWords(Grandtotal);

                        label25.Text = ""; // Clear error message

                        // Update the Summary table with the new travel budget
                        var sum = db.Summary.FirstOrDefault(s => s.ProjectId == Form1.projectid);

                        if (sum != null)
                        {
                            sum.TravelBudget = travelbudgetper;
                           db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    label25.Text = "Travel Budget should be between 0 and 200.";
                    textBox1.Text = "";
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label26.Visible = true;

            if (!string.IsNullOrEmpty(textBox2.Text) && int.TryParse(textBox2.Text, out int contigencyper))
            {
                if (contigencyper >= 0 && contigencyper <= 200)
                {
                    try
                    {
                        // Calculate contingency and update labels
                        double contigency = TotalCost * contigencyper / 100.0;
                        Grandtotal = TotalCost + travelbudget + contigency;

                        label18.Text = $"$ {contigency:#,##0.00}";
                        label20.Text = $"$ {Grandtotal:#,##0.00}";
                        label21.Text = NumberToWordsConverter.ConvertToWords(Grandtotal);

                        label26.Text = ""; // Clear error message

                        // Update the Summary table with the new contingency value
                        var sum = db.Summary.FirstOrDefault(s => s.ProjectId == Form1.projectid);

                        if (sum != null)
                        {
                            sum.Contingency = contigencyper;
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    label26.Text = "Contingency should be between 0 and 200.";
                    textBox2.Text = "";
                }
            }
        }
        public static class NumberToWordsConverter
        {
            private static readonly string[] Ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            private static readonly string[] Tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            private static readonly string[] Thousands = { "", "Thousand", "Million", "Billion", "Trillion" };

            public static string ConvertToWords(double number)
            {
                if (number == 0)
                    return "Zero";

                long intPart = (long)number;
                int decimalPart = (int)Math.Round((number - intPart) * 100);

                string intPartWords = ConvertToWords(intPart);
                string decimalPartWords = decimalPart > 0 ? $"and {ConvertToWords(decimalPart)} Cents" : "";

                return $"{intPartWords} Dollars {decimalPartWords}".Trim();
            }
            private static string ConvertToWords(long number)
            {
                if (number < 20)
                    return Ones[number];

                string result = "";
                int i = 0;

                while (number > 0)
                {
                    if (number % 1000 != 0)
                    {
                        result = $"{ConvertToWordsUnderThousand((int)(number % 1000))} {Thousands[i]} {result}";
                    }

                    number /= 1000;
                    i++;
                }
                return result.Trim();
            }

            private static string ConvertToWordsUnderThousand(int number)
            {
                if (number == 0)
                    return "";

                string words = "";

                if (number >= 100)
                {
                    words += $"{Ones[number / 100]} Hundred ";
                    number %= 100;
                }

                if (number >= 20)
                {
                    words += $"{Tens[number / 10]} ";
                    number %= 10;
                }

                if (number > 0)
                {
                    words += $"{Ones[number]} ";
                }
                return words.Trim();
            }
        }

        public void GeneratePdf()

        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;

                try

                {

                    FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);

                    iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 50, 50, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(document, fs);

                    document.Open();

                    // Add content to the PDF document

                    document.Add(new Paragraph("Implementation Estimation Summary"));

                    document.Add(new Paragraph($"Total hours: {label6.Text:C}"));

                    document.Add(new Paragraph($"Resource Cost: {label10.Text}"));

                    document.Add(new Paragraph($"Total Software Cost: {label12.Text:C}"));

                    document.Add(new Paragraph($"Total Cost: {TotalCost:C}"));

                    document.Add(new Paragraph($"Travel Budget: {label17.Text}"));

                    document.Add(new Paragraph($"Contingency Budget: {label18.Text}"));

                    document.Add(new Paragraph($"Grand Total: {label20.Text:C}"));

                    document.Add(new Paragraph($"Grand Total in Words: {label21.Text}"));

                    document.Close();

                    fs.Close();

                }

                catch (Exception ex)

                {

                    // Handle any exceptions

                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }

                label22.Text = "PDF generated successfully.";

            }

        }




        Bitmap bmp;

        private void button1_Click(object sender, EventArgs e)
        {


            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A4", 1363, 704);

            // Set the margins to zero
            printDocument1.DefaultPageSettings.Margins = new Margins(0, 800, 0, 0);

            // Create a bitmap of the entire form
            bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));

            // Show print preview dialog
            printPreviewDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResourceCostingUserControl rc = new ResourceCostingUserControl();
            this.Hide();
            this.Parent.Controls.Add(rc);
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawImage(bmp, e.MarginBounds.Left, e.MarginBounds.Top, bmp.Width, bmp.Height);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}

