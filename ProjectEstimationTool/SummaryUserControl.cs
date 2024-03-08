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

            textBox1.Text = "5";
            textBox2.Text = "20";
            label22.Visible = false;

        }

        private void SummaryUserControl_Load(object sender, EventArgs e)
        {
            label25.Visible = false;
            label26.Visible = false;
            label1.Text = Form1.projectname;
            //for total efforts
            var EffortHours = db.Timeline.Where(s => s.ProjectId == Form1.projectid).Sum(s => s.EffHrs);
            TotalEfforHours = EffortHours;
            label6.Text = $"{EffortHours.ToString()} Hours";
           
            //resource cost
            var Resourcecost = db.ResourceCosting.Where(r => r.ProjectId == Form1.projectid).Sum(s => s.Cost);
            label10.Text = Resourcecost.ToString();
            label10.Text = $"$ {Resourcecost}";

            //softwarecost
            var softwarecost = db.Software.Where(s => s.ProjectId == Form1.projectid).Sum(s => s.MonthlyRate);
            var numofres = db.ResourceCosting.Where(n => n.ProjectId == Form1.projectid).Sum(n => n.ResCount);
            var duartioninmonths = db.Timeline.Where(n => n.ProjectId == Form1.projectid).Max(n => n.Mm);

            TotalsoftwareCost = (softwarecost * duartioninmonths * numofres);
            label12.Text = Convert.ToString(TotalsoftwareCost);
            label12.Text = $"$ {TotalsoftwareCost}";
            //totalcost
            TotalCost = TotalsoftwareCost+ Resourcecost;
            label14.Text = Convert.ToString(TotalCost);
            label14.Text = $"$ {TotalCost}";

            //travelbudget percentage
            int TravelBudgetPer = Convert.ToInt32(textBox1.Text);

            int ContigencyPer = Convert.ToInt32(textBox2.Text);
            double TravelBudget = TotalCost * TravelBudgetPer / 100.0;
            double Contigency = TotalCost * ContigencyPer/ 100.0;
            label17.Text = Convert.ToString(TravelBudget);
            label17.Text = $"$ {TravelBudget}";
            label18.Text = Convert.ToString(Contigency);
            label18.Text = $"$ {Contigency}";
            Grandtotal = TotalCost + Contigency + TravelBudget;
            label20.Text = Convert.ToString(Grandtotal);
            label20.Text = $"$ {Grandtotal}";
            label21.Text = NumberToWordsConverter.ConvertToWords(Grandtotal);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label25.Visible = true;
            if (!string.IsNullOrEmpty(textBox1.Text) && int.TryParse(textBox1.Text, out int travelbudgetper))
            {
                if (travelbudgetper >= 0 && travelbudgetper <= 200)
                {
                    double travelbudget = TotalCost * travelbudgetper / 100.0;
                    Grandtotal = TotalCost + travelbudget + contigency;

                    label17.Text = Convert.ToString(travelbudget);
                    label17.Text = $"$ {travelbudget}";
                    label20.Text = Convert.ToString(Grandtotal);
                    label20.Text = $"$ {Grandtotal}";
                    label21.Text = NumberToWordsConverter.ConvertToWords(Grandtotal);
                    label25.Text = "";
                }
                else
                {
                    label25.Text= "Travel Budget should be between 0 and 200.";
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
                    double contigency = TotalCost * contigencyper / 100.0;

                    label18.Text = Convert.ToString(contigency);
                    label18.Text = $"$ {contigency}";
                    Grandtotal = TotalCost + travelbudget + contigency;

                    label20.Text = Convert.ToString(Grandtotal);
                    label20.Text = $"$ {Grandtotal}";

                    label21.Text = NumberToWordsConverter.ConvertToWords(Grandtotal);
                    label26.Text = "";
                }
                else
                {
                    label26.Text = "Contigency should be between 0 and 200.";
                    textBox2.Text = ""; // Reset the textbox
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






        private void button1_Click(object sender, EventArgs e)
        {
            GeneratePdf();
            label22.Visible = true;
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
    }
}
