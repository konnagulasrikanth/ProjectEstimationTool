using iTextSharp.text.pdf;
using iTextSharp.text;
using ProjectEstimationTool.Models;
using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Document = iTextSharp.text.Document;
using Image = iTextSharp.text.Image;
using System.Text.RegularExpressions;
using LiveCharts;
using LiveCharts.Wpf;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts.Wpf.Charts.Base;
using Chart = System.Windows.Forms.DataVisualization.Charting.Chart;
using System.Reflection.Metadata;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
using System.Xml.Linq;
using iTextSharp.text.pdf.interfaces;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms.Design;
using System.Security.Policy;



namespace ProjectEstimationTool
{
    public partial class SummaryUserControl : UserControl
    {
        public class ChartGenerator
        {
            private readonly ProjectEstimationToolMasterContext db; // Your database context

            public ChartGenerator(ProjectEstimationToolMasterContext db1)
            {
                db = db1;
            }
        }


        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        private int TotalEfforHours;
        private int TotalsoftwareCost;
        private double TotalCost;
        private double Grandtotal;
        private double contigency;
        private double travelbudget;
        private int Hourlyrate;
        private int Monthlyhours;
        private int Months;
        private int Monthlyrate;
        private double Resourcecost;
        private double Cost;
        // Declare chart1
        private Chart chart1;

        public SummaryUserControl()
        {
            InitializeComponent();
            chart1 = new Chart();
            //textBox1.Text = "5";
            //textBox2.Text = "20";
            //label22.Visible = false;

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


        public double Rateformula(string country, string resourcetype, string rolelevel, string phase, int rescount)
        {
            Hourlyrate = (from rate in db.Resource
                          where rate.CountryName.Contains(country) && rate.TypeName.Contains(resourcetype) && rate.LevelName.Contains(rolelevel) && rate.ProjectId == Form1.projectid
                          select rate.HourlyRate).FirstOrDefault();
            Monthlyhours = (from hours in db.Productivity
                            where hours.ProductivityName == "Week" && hours.ProjectId == Form1.projectid
                            select hours.Hours).FirstOrDefault();
            Months = (from mm in db.Timeline
                      where mm.Phase == phase && mm.ProjectId == Form1.projectid
                      select mm.Mm).FirstOrDefault();
            Monthlyrate = Hourlyrate * Monthlyhours * rescount;
            Cost = Monthlyrate * Months;
            return Cost;

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
            var reslist = db.ResourceCosting.Where(r => r.ProjectId == Form1.projectid).ToList();

            foreach (var item in reslist)
            {
                Resourcecost += Rateformula(item.Country, item.ResType, item.RoleLevel, item.Phase, item.ResCount);
            }
            //resource cost
            label10.Text = Resourcecost.ToString();
            label10.Text = $"$ {Resourcecost:#,##0.00}";

            ////softwarecost
            //var softwarecost = db.Software.Where(s => s.ProjectId == Form1.projectid).Sum(s => s.MonthlyRate);
            //var softwaredata = db.ResourceCosting.Where(p=>p.ProjectId==Form1.projectid).ToList();
            //var numofres = db.ResourceCosting.Where(n => n.ProjectId == Form1.projectid).Sum(n => n.ResCount);
            ////var duartioninmonths = db.Timeline.Where(n => n.ProjectId == Form1.projectid).Max(n => n.Mm);
            //int softcost = 0;
            //foreach (var phase in softwaredata)
            //{
            //    var durationinmonths = phase.DurationMm;
            //    softcost += durationinmonths * softwarecost * phase.ResCount;
            //}

            var softcost = db.SoftwareCostingTest.Where(t => t.ProjectId == Form1.projectid).Sum(t => t.SoftwareCost);

            TotalsoftwareCost = Convert.ToInt32(softcost);
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

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    label25.Visible = true;

        //    if (!string.IsNullOrEmpty(textBox1.Text) && int.TryParse(textBox1.Text, out int travelbudgetper))
        //    {
        //        if (travelbudgetper >= 0 && travelbudgetper < 100)
        //        {
        //            try
        //            {
        //                // Calculate travel budget and update labels
        //                double travelbudget = TotalCost * travelbudgetper / 100.0;
        //                Grandtotal = TotalCost + travelbudget + contigency;

        //                label17.Text = $"$ {travelbudget:#,##0.00}";
        //                label20.Text = $"$ {Grandtotal:#,##0.00}";
        //                label21.Text = NumberToWordsConverter.ConvertToWords(Grandtotal);

        //                label25.Text = ""; // Clear error message

        //                // Update the Summary table with the new travel budget
        //                var sum = db.Summary.FirstOrDefault(s => s.ProjectId == Form1.projectid);

        //                if (sum != null)
        //                {
        //                    sum.TravelBudget = travelbudgetper;
        //                    db.SaveChanges();
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            label25.Text = "Travel Budget should be between 0 and 100.";
        //            textBox1.Text = "";
        //        }
        //    }

        //}

        //private void textBox2_TextChanged(object sender, EventArgs e)
        //{
        //    label26.Visible = true;

        //    if (!string.IsNullOrEmpty(textBox2.Text) && int.TryParse(textBox2.Text, out int contigencyper))
        //    {
        //        if (contigencyper >= 0 && contigencyper < 100)
        //        {
        //            try
        //            {
        //                // Calculate contingency and update labels
        //                double contigency = TotalCost * contigencyper / 100.0;
        //                Grandtotal = TotalCost + travelbudget + contigency;

        //                label18.Text = $"$ {contigency:#,##0.00}";
        //                label20.Text = $"$ {Grandtotal:#,##0.00}";
        //                label21.Text = NumberToWordsConverter.ConvertToWords(Grandtotal);

        //                label26.Text = ""; // Clear error message

        //                // Update the Summary table with the new contingency value
        //                var sum = db.Summary.FirstOrDefault(s => s.ProjectId == Form1.projectid);

        //                if (sum != null)
        //                {
        //                    sum.Contingency = contigencyper;
        //                    db.SaveChanges();
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            label26.Text = "Contingency should be between 0 and 100.";
        //            textBox2.Text = "";
        //        }
        //    }
        //}


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label25.Visible = true;
            string input = textBox1.Text.Trim();

            // Check if the input is empty or contains only digits
            if (!string.IsNullOrEmpty(input) && input.All(char.IsDigit))
            {
                // Convert the input to integer
                int travelbudgetper = int.Parse(input);

                if (travelbudgetper >= 0 && travelbudgetper < 100)
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
                    label25.Text = "Travel Budget should be between 0 and 100.";
                }
            }
            else if (!string.IsNullOrEmpty(input))
            {
                label25.Text = "Please enter a valid integer.";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label26.Visible = true;
            string input = textBox2.Text.Trim();

            // Check if the input is empty or contains only digits
            if (!string.IsNullOrEmpty(input) && input.All(char.IsDigit))
            {
                // Convert the input to integer
                int contigencyper = int.Parse(input);

                if (contigencyper >= 0 && contigencyper < 100)
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
                    label26.Text = "Contingency should be between 0 and 100.";
                }
            }
            else if (!string.IsNullOrEmpty(input))
            {
                label26.Text = "Please enter a valid integer.";
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

        //string directoryPath = "C:\\Users\\srikanthko\\Documents\\ProjectEsimationTool"; 
        // Specify your directory path here

        /* public void GeneratePdf(String templatePath)
         {
          if(String.IsNullOrEmpty(templatePath) || !File.Exists(templatePath))
             {
                 MessageBox.Show("Invalid template PDF path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }
             string baseFileName = Form1.projectname;
             string directoryPath = "C:\\Users\\srikanthko\\Documents\\ProjectEsimationTool"; // Specify your directory path here
             try
             {
                 // Check if the directory exists
                 if (!Directory.Exists(directoryPath))
                 {
                     MessageBox.Show("Directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }

                 try
                 {
                     // Check if a record for the project ID already exists in the PDFVersions table
                     var pdfvc = db.Pdfversions.FirstOrDefault(t => t.ProjectId == Form1.projectid);

                     if (pdfvc != null)
                     {
                         // If a record exists, increment the version by 0.1 and round to 2 decimal places
                         pdfvc.Version = Math.Round((pdfvc.Version ?? 0.0m) + 0.1m, 2);
                     }
                     else
                     {
                         // If no record exists, create a new record with initial version 1.0
                         pdfvc = new Pdfversions { ProjectId = Form1.projectid, Version = 1.0m };
                         db.Pdfversions.Add(pdfvc);
                     }

                     // Save changes to the database
                     db.SaveChanges();
                 }
                 catch (Exception ex)
                 {
                     // Handle any exceptions that occur during the update process
                     MessageBox.Show("Error updating PDF version count: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }

                 // Retrieve the PDF version count from the database
                 decimal versionCount = db.Pdfversions
                     .Where(t => t.ProjectId == Form1.projectid)
                     .Select(t => t.Version ?? 0.0m)
                     .FirstOrDefault();
                 // Format the PDF version count to display up to two decimal places
                 string versionCountFormatted = versionCount.ToString("0.0");

                 // Construct the filename with the version count appended
                 string fileName = $"{baseFileName} {versionCountFormatted}.pdf";

                 // Check if the file with the initial name exists
                 while (File.Exists(Path.Combine(directoryPath, fileName)))
                 {
                     // Extract the version number from the file name
                     Match match = Regex.Match(fileName, @"(\d+\.\d+)");
                     if (match.Success)
                     {
                         // Increment the version number
                         string[] parts = match.Value.Split('.');
                         int majorVersion = int.Parse(parts[0]);
                         int minorVersion = int.Parse(parts[1]);
                         minorVersion++;

                         // Construct the new file name with the incremented version
                         fileName = $"{baseFileName} {majorVersion}.{minorVersion}.pdf";
                     }
                     else
                     {
                         // If the file name does not follow the expected pattern, break the loop
                         break;
                     }
                 }

                 // Open a SaveFileDialog to select the destination for the PDF file
                 SaveFileDialog saveFileDialog = new SaveFileDialog();
                 saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
                 saveFileDialog.FilterIndex = 1;
                 saveFileDialog.RestoreDirectory = true;
                 saveFileDialog.FileName = fileName; // Set the initial file name in the dialog

                 if (saveFileDialog.ShowDialog() == DialogResult.OK)
                 {
                     fileName = saveFileDialog.FileName;

                     FileStream fs = null;
                     Document document = null;

                     try
                     {
                         using (FileStream templateFileStream = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
                         {
                             fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
                             {
                                 PdfReader reader = new PdfReader(templateFileStream);
                                 PdfStamper stamper = new PdfStamper(reader, fs);

                                 document = new Document(PageSize.A4, 50, 50, 25, 25);

                                 // Define the watermark
                                 string watermarkText = Form1.projectname;
                                 string companyText = "Infinite Computer Solutions (India) Ltd.";
                                 Image companyIcon = Image.GetInstance("C:\\Users\\srikanthko\\source\\repos\\ProjectEstimationTool\\ProjectEstimationTool\\Image\\icon.png");
                                 BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);

                                 PdfWriter writer = PdfWriter.GetInstance(document, fs);
                                 writer.PageEvent = new Watermark(watermarkText, companyText, companyIcon, bf);

                                 document.Open();



                                 // Create a table with 2 columns
                                 PdfPTable table = new PdfPTable(2);
                                 table.WidthPercentage = 100; // Set the table width to 100% of the page width

                                 // Add table cells with your data

                                 table.AddCell(new PdfPCell(new Phrase("Implementaion Estimation of Summary : ")));
                                 table.AddCell(new PdfPCell(new Phrase(Form1.projectname)));
                                 table.AddCell(new PdfPCell(new Phrase("Total hours")));
                                 table.AddCell(new PdfPCell(new Phrase(label6.Text)));

                                 table.AddCell(new PdfPCell(new Phrase("Resource Cost")));
                                 table.AddCell(new PdfPCell(new Phrase(label10.Text)));

                                 table.AddCell(new PdfPCell(new Phrase("Total Software Cost")));
                                 table.AddCell(new PdfPCell(new Phrase(label12.Text)));

                                 table.AddCell(new PdfPCell(new Phrase("Total Cost")));
                                 table.AddCell(new PdfPCell(new Phrase(label14.Text)));

                                 table.AddCell(new PdfPCell(new Phrase("Travel Budget")));
                                 table.AddCell(new PdfPCell(new Phrase(label17.Text)));

                                 table.AddCell(new PdfPCell(new Phrase("Contingency Budget")));
                                 table.AddCell(new PdfPCell(new Phrase(label18.Text)));

                                 table.AddCell(new PdfPCell(new Phrase("Grand Total")));
                                 table.AddCell(new PdfPCell(new Phrase(label20.Text)));

                                 table.AddCell(new PdfPCell(new Phrase("Grand Total In Words")));
                                 table.AddCell(new PdfPCell(new Phrase(label21.Text)));

                                 // Add borders to all cells
                                 foreach (PdfPCell cell in table.Rows.SelectMany(row => row.GetCells()))
                                 {
                                     cell.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                                 }

                                 // Add the table to the document
                                 document.Add(table);
                                 // Generate the pie chart and add to PDF
                                 GeneratePieChartAndAddToPdf(document);
                                 GenerateDonutChartAndAddToPdf(document);

                             }

                         }
                     }
                     finally
                     {
                         // Close the document and file stream
                         if (document != null)
                         {
                             document.Close();
                         }
                         if (fs != null)
                         {
                             fs.Close();

                         }
                     }

                     MessageBox.Show("PDF file generated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
             }
             catch (Exception ex)
             {
                 // Handle any exceptions
                 MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }
 */

        public void GeneratePdf(string templatePath)
        {
            if (string.IsNullOrEmpty(templatePath) || !File.Exists(templatePath))
            {
                MessageBox.Show("Invalid template PDF path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string baseFileName = Form1.projectname;
            string directoryPath = "C:\\Users\\srikanthko\\Documents\\ProjectEsimationTool";

            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    MessageBox.Show("Directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Increment version number in database
                UpdatePdfVersion();

                decimal versionCount = GetPdfVersion();

                string versionCountFormatted = versionCount.ToString("0.0");
                string fileName = $"{baseFileName} {versionCountFormatted}.pdf";

                while (File.Exists(Path.Combine(directoryPath, fileName)))
                {
                    Match match = Regex.Match(fileName, @"(\d+\.\d+)");
                    if (match.Success)
                    {
                        string[] parts = match.Value.Split('.');
                        int majorVersion = int.Parse(parts[0]);
                        int minorVersion = int.Parse(parts[1]);
                        minorVersion++;

                        fileName = $"{baseFileName} {majorVersion}.{minorVersion}.pdf";
                    }
                    else
                    {
                        break;
                    }
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = fileName;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;

                    using (FileStream templateFileStream = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
                    using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {

                        //  PdfStamper stamper = new PdfStamper(reader, fs);
                        Document document = new Document(PageSize.A4, 50, 50, 250, 25);
                        PdfWriter writer = PdfWriter.GetInstance(document, fs);
                        writer.PageEvent = new CustomPageEvent();
                        writer.PageEvent = new Watermark(Form1.projectname, "Infinite Computer Solutions (India) Ltd.", Image.GetInstance("C:\\Users\\srikanthko\\source\\repos\\ProjectEstimationTool\\ProjectEstimationTool\\Image\\icon.png"), BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED));
                        document.Open();

                        PdfReader reader = new PdfReader(templateFileStream);
                        PdfImportedPage importedPage = writer.GetImportedPage(reader, 1);
                        PdfContentByte content = writer.DirectContent;
                        content.AddTemplate(importedPage, 0, 0); // Adding at position (0,0)
                        PdfPTable table = new PdfPTable(2);
                        table.WidthPercentage = 100;

                        table.AddCell(new PdfPCell(new Phrase("Implementaion Estimation of Summary : ")));
                        table.AddCell(new PdfPCell(new Phrase(Form1.projectname)));
                        table.AddCell(new PdfPCell(new Phrase("Total hours")));
                        table.AddCell(new PdfPCell(new Phrase(label6.Text)));
                        table.AddCell(new PdfPCell(new Phrase("Resource Cost")));
                        table.AddCell(new PdfPCell(new Phrase(label10.Text)));
                        table.AddCell(new PdfPCell(new Phrase("Total Software Cost")));
                        table.AddCell(new PdfPCell(new Phrase(label12.Text)));
                        table.AddCell(new PdfPCell(new Phrase("Total Cost")));
                        table.AddCell(new PdfPCell(new Phrase(label14.Text)));
                        table.AddCell(new PdfPCell(new Phrase("Travel Budget")));
                        table.AddCell(new PdfPCell(new Phrase(label17.Text)));
                        table.AddCell(new PdfPCell(new Phrase("Contingency Budget")));
                        table.AddCell(new PdfPCell(new Phrase(label18.Text)));
                        table.AddCell(new PdfPCell(new Phrase("Grand Total")));
                        table.AddCell(new PdfPCell(new Phrase(label20.Text)));
                        table.AddCell(new PdfPCell(new Phrase("Grand Total In Words")));
                        table.AddCell(new PdfPCell(new Phrase(label21.Text)));

                        foreach (PdfPCell cell in table.Rows.SelectMany(row => row.GetCells()))
                        {
                            cell.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                        }

                        document.Add(table);
                        GeneratePieChartAndAddToPdf(document, Form1.projectid);
                        GenerateDonutChartAndAddToPdf(document);
                        document.Close();
                        fs.Close();
                    }

                    MessageBox.Show("PDF file generated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePdfVersion()
        {
            try
            {
                var pdfvc = db.Pdfversions.FirstOrDefault(t => t.ProjectId == Form1.projectid);

                if (pdfvc != null)
                {
                    pdfvc.Version = Math.Round((pdfvc.Version ?? 0.0m) + 0.1m, 2);
                }
                else
                {
                    pdfvc = new Pdfversions { ProjectId = Form1.projectid, Version = 1.0m };
                    db.Pdfversions.Add(pdfvc);
                }

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating PDF version count: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetPdfVersion()
        {
            decimal versionCount = db.Pdfversions
                .Where(t => t.ProjectId == Form1.projectid)
                .Select(t => t.Version ?? 0.0m)
                .FirstOrDefault();
            return versionCount;
        }


        public class Watermark : PdfPageEventHelper
        {
            string watermarkText;
            string companyText;
            Image companyIcon;
            BaseFont bf;

            public Watermark(string watermarkText, string companyText, Image companyIcon, BaseFont bf)
            {
                this.watermarkText = watermarkText;
                this.companyText = companyText;
                this.companyIcon = companyIcon;
                this.bf = bf;
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                // Add watermark
                PdfContentByte content = writer.DirectContentUnder;
                content.BeginText();
                content.SetFontAndSize(bf, 36);
                content.SetColorFill(BaseColor.LIGHT_GRAY);
                content.SetTextMatrix(30, 30); // Position of the watermark
                content.ShowTextAligned(Element.ALIGN_CENTER, watermarkText, PageSize.A4.Width / 2, PageSize.A4.Height / 2, 45);
                content.EndText();

                // Add date and time
                PdfContentByte canvas = writer.DirectContent;
                ColumnText.ShowTextAligned(canvas, Element.ALIGN_RIGHT,
                new Phrase(DateTime.Now.ToString()), document.PageSize.Width - 30, 30, 0);

                // Add company icon
                float iconWidth = 30f; // Adjust as needed
                float iconHeight = 25f; // Adjust as needed
                float iconX = 30; // X-coordinate of the icon
                float iconY = 20; // Y-coordinate of the icon
                companyIcon.SetAbsolutePosition(iconX, iconY);
                companyIcon.ScaleAbsolute(iconWidth, iconHeight);
                document.Add(companyIcon);

                // Add company text
                ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT,
                    new Phrase(companyText), iconX + iconWidth + 5, iconY + iconHeight / 2, 0);
            }
        }

        //private void GeneratePieChartAndAddToPdf(Document document)
        //{
        //    try
        //    {
        //        // Fetch the statistical data from the database
        //        var resourceCostSum = db.ResourceCosting.Where(t => t.ProjectId == Form1.projectid).Sum(t => t.Cost);
        //        var softwareCost = db.SoftwareCosting.Where(t => t.ProjectId == Form1.projectid).Sum(t => t.SoftwareCost);

        //        // Prepare data for chart
        //        string[] x = { "Resource Cost", "Software Cost" , "Travel Budget", "Contingency Budget" };
        //        double[] y = { Convert.ToDouble(resourceCostSum), Convert.ToDouble(softwareCost) };

        //        // Create a new chart
        //        Chart chart = new Chart();

        //        // Clear existing series from the chart
        //        chart.Series.Clear();

        //        // Add new series to the chart
        //        Series series = new Series("Cost");

        //        // Add data points to the series
        //        for (int i = 0; i < Math.Min(x.Length, y.Length); i++)
        //        {
        //            series.Points.AddY(y[i]);
        //            series.Points[i].AxisLabel = x[i];
        //        }

        //        // Set chart type
        //        series.ChartType = SeriesChartType.Pie;

        //        // Add series to the chart
        //        chart.Series.Add(series);

        //        // Enable 3D style
        //        chart.ChartAreas.Add(new ChartArea());
        //        chart.ChartAreas[0].Area3DStyle.Enable3D = true;

        //        // Create a memory stream to store the chart image
        //        MemoryStream chartStream = new MemoryStream();

        //        // Save the chart as an image to the memory stream
        //        chart.SaveImage(chartStream, ChartImageFormat.Png);

        //        // Reset the position of the memory stream to the beginning
        //        chartStream.Position = 0;

        //        // Add a new page for the pie chart
        //        document.NewPage();

        //        // Add the chart image to the PDF document
        //        Image chartImage = Image.GetInstance(chartStream);
        //        document.Add(chartImage);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error generating pie chart and adding to PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private void GenerateDonutChartAndAddToPdf(Document document)
        //{
        //    try
        //    {
        //        // Fetch the statistical data from the database
        //        var resourceCostSum = db.ResourceCosting.Where(t => t.ProjectId == Form1.projectid).Sum(t => t.Cost);
        //        var softwareCost = db.SoftwareCosting.Where(t => t.ProjectId == Form1.projectid).Sum(t => t.SoftwareCost);

        //        // Prepare data for chart
        //        string[] x = { "Resource Cost", "Software Cost" , "Travel Budget", "Contingency Budget" };
        //        double[] y = { Convert.ToDouble(resourceCostSum), Convert.ToDouble(softwareCost) };

        //        // Create a new chart
        //        Chart chart = new Chart();

        //        // Clear existing series from the chart
        //        chart.Series.Clear();

        //        // Add new series to the chart
        //        Series series = new Series("Cost");

        //        // Add data points to the series
        //        for (int i = 0; i < Math.Min(x.Length, y.Length); i++)
        //        {
        //            series.Points.AddY(y[i]);
        //            series.Points[i].AxisLabel = x[i];
        //        }

        //        // Set chart type to Pie
        //        series.ChartType = SeriesChartType.Doughnut;

        //        // Set the width of the donut hole (50% means no hole)
        //        series["DoughnutRadius"] = "50";

        //        // Add series to the chart
        //        chart.Series.Add(series);

        //        // Enable 3D style
        //        chart.ChartAreas.Add(new ChartArea());
        //        chart.ChartAreas[0].Area3DStyle.Enable3D = true;

        //        // Create a memory stream to store the chart image
        //        MemoryStream chartStream = new MemoryStream();

        //        // Save the chart as an image to the memory stream
        //        chart.SaveImage(chartStream, ChartImageFormat.Png);

        //        // Reset the position of the memory stream to the beginning
        //        chartStream.Position = 0;

        //        // Add a new page for the donut chart
        //        document.NewPage();

        //        // Add the chart image to the PDF document
        //        Image chartImage = Image.GetInstance(chartStream);
        //        document.Add(chartImage);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error generating donut chart and adding to PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void GeneratePieChartAndAddToPdf(Document document, int projectId)
        {
            try
            {
                // Fetch the statistical data from the database
                var resourceCostSum = db.ResourceCosting.Where(t => t.ProjectId == projectId).Sum(t => t.Cost);
                var softwareCost = db.SoftwareCosting.Where(t => t.ProjectId == projectId).Sum(t => t.SoftwareCost);
                var travelBudget = db.Summary.Where(t => t.ProjectId == projectId).Sum(t => t.TravelBudget);
                var contingencyBudget = db.Summary.Where(t => t.ProjectId == projectId).Sum(t => t.Contingency);

                // Prepare data for chart
                string[] x = { "Resource Cost", "Software Cost", "Travel Budget", "Contingency Budget" };
                double[] y = { Convert.ToDouble(resourceCostSum), Convert.ToDouble(softwareCost), Convert.ToDouble(travelBudget), Convert.ToDouble(contingencyBudget) };

                // Define colors for each category
                Color[] colors = { Color.Blue, Color.Green, Color.Red, Color.Yellow };

                // Create a new chart
                Chart chart = new Chart();

                // Clear existing series from the chart
                chart.Series.Clear();

                // Add new series to the chart
                Series series = new Series("Cost");

                // Add data points to the series
                for (int i = 0; i < Math.Min(x.Length, y.Length); i++)
                {
                    series.Points.AddY(y[i]);
                    series.Points[i].Color = colors[i]; // Set color for each category
                    series.Points[i].LegendText = x[i]; // Set legend text for each data point
                }

                // Set chart type
                series.ChartType = SeriesChartType.Pie;

                // Add series to the chart
                chart.Series.Add(series);

                // Enable 3D style
                chart.ChartAreas.Add(new ChartArea());
                chart.ChartAreas[0].Area3DStyle.Enable3D = true;

                // Create a memory stream to store the chart image
                MemoryStream chartStream = new MemoryStream();

                // Save the chart as an image to the memory stream
                chart.SaveImage(chartStream, ChartImageFormat.Png);

                // Reset the position of the memory stream to the beginning
                chartStream.Position = 0;

                // Add a new page for the pie chart
                document.NewPage();

                // Add the chart image to the PDF document
                Image chartImage = Image.GetInstance(chartStream);
                document.Add(chartImage);

                // Add legend manually to the PDF document
                PdfPTable legendTable = new PdfPTable(2); // Assuming 2 columns for color and category name
                legendTable.WidthPercentage = 30; // Adjust the width of the legend table as needed

                for (int i = 0; i < Math.Min(x.Length, colors.Length); i++)
                {
                    PdfPCell colorCell = new PdfPCell();
                    colorCell.BackgroundColor = new BaseColor(colors[i]);
                    legendTable.AddCell(colorCell);

                    PdfPCell categoryCell = new PdfPCell(new Phrase(x[i]));
                    legendTable.AddCell(categoryCell);
                }

                document.Add(legendTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating pie chart and adding to PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateDonutChartAndAddToPdf(Document document)
        {
            try
            {
                // Fetch the statistical data from the database
                var resourceCostSum = db.ResourceCosting.Where(t => t.ProjectId == Form1.projectid).Sum(t => t.Cost);
                var softwareCost = db.SoftwareCosting.Where(t => t.ProjectId == Form1.projectid).Sum(t => t.SoftwareCost);

                // Prepare data for chart
                string[] x = { "Resource Cost", "Software Cost", "Travel Budget", "Contingency Budget" };
                double[] y = { Convert.ToDouble(resourceCostSum), Convert.ToDouble(softwareCost) };

                // Create a new chart
                Chart chart = new Chart();

                // Clear existing series from the chart
                chart.Series.Clear();

                // Add new series to the chart
                Series series = new Series("Cost");

                // Add data points to the series
                for (int i = 0; i < Math.Min(x.Length, y.Length); i++)
                {
                    series.Points.AddY(y[i]);
                    series.Points[i].AxisLabel = x[i];
                }

                // Set chart type to Pie
                series.ChartType = SeriesChartType.Doughnut;

                // Set the width of the donut hole (50% means no hole)
                series["DoughnutRadius"] = "50";

                // Add series to the chart
                chart.Series.Add(series);

                // Enable 3D style
                chart.ChartAreas.Add(new ChartArea());
                chart.ChartAreas[0].Area3DStyle.Enable3D = true;

                // Create a memory stream to store the chart image
                MemoryStream chartStream = new MemoryStream();

                // Save the chart as an image to the memory stream
                chart.SaveImage(chartStream, ChartImageFormat.Png);

                // Reset the position of the memory stream to the beginning
                chartStream.Position = 0;

                // Add a new page for the donut chart
                document.NewPage();

                // Add the chart image to the PDF document
                Image chartImage = Image.GetInstance(chartStream);
                document.Add(chartImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating donut chart and adding to PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            // GeneratePdf("C:\\Users\\srikanthko\\Downloads\\Invoice-Template.pdf");


            //------------------------------------
            UpdatePdfVersion();


            // Prompt user to select template PDF file
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
            //openFileDialog.FilterIndex = 1;
            //openFileDialog.RestoreDirectory = true;
            //openFileDialog.FileName = fileName;


            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string templatePath = openFileDialog.FileName;
            //    GeneratePdf("C:\\Users\\srikanthko\\Downloads\\Invoice-Template.pdf");
            //}
            string templatePath = @"C:/Users/srikanthko/Documents/ProjectEsimationTool/Template.pdf"; // Specify the template path here or use an OpenFileDialog if needed
            GeneratePdf(templatePath);
        }
        public class CustomPageEvent : PdfPageEventHelper
        {
            public override void OnStartPage(PdfWriter writer, Document document)
            {
                if (document.PageNumber > 1) // Add borders to pages except for the first page
                {
                    PdfContentByte canvas = writer.DirectContent;
                    iTextSharp.text.Rectangle rect = document.PageSize;
                    float borderWidth = 16f; // Adjust the border width as needed
                    float shiftUp = 55f;

                    float partWidth = rect.Width / 3f; // Divide the page width into three equal parts

                    // Loop through each part and draw borders with alternating colors
                    for (int i = 0; i < 3; i++)
                    {
                        BaseColor color;
                        if (i % 2 == 0)
                            color = new BaseColor(30, 139, 205); // Light blue color
                        else
                            color = new BaseColor(0, 32, 96); // Dark blue color

                        canvas.SetColorStroke(color);
                        canvas.SetColorFill(color);
                        canvas.Rectangle(rect.Left + i * partWidth, rect.Bottom + shiftUp, partWidth, borderWidth);
                        canvas.FillStroke();
                    }
                }
            }
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



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }

}


