using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Client;
using ProjectEstimationTool.Models;
namespace ProjectEstimationTool
{
    public partial class Form1 : Form
    {
        public static int projectid { get; set; }
        public static string projectname { get; set; }
        private bool isButton1Clicked = false;
        private bool isButton2Clicked = false;
        private bool isButton3Clicked = false;
        private bool isButton4Clicked = false;
        private ProjectEstimationToolMasterContext projectContext = new ProjectEstimationToolMasterContext();
        public Form1()
        {
            InitializeComponent();
            comboBox1.MaxDropDownItems = 5;
            comboBox1.IntegralHeight = false;
        }


        private void LoadProjects()
        {

            try
            {
                // Load project names into the combo box
                var projectNames = projectContext.Project
                    .Select(project => project.ProjectName)
                    .ToList();

                comboBox1.Items.Clear(); // Clear existing items before adding new ones
                comboBox1.Items.AddRange(projectNames.ToArray());
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, e.g., log it or show an error message.
                Console.WriteLine($"An error occurred while loading projects: {ex.Message}");
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            panel1.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            label11.Visible = false;
            //this.FormBorderStyle = FormBorderStyle.Sizable;


            try
            {
                // Load project names into the combo box
                var projectNames = projectContext.Project
                    .Select(project => project.ProjectName)
                    .ToList();

                comboBox1.Items.Clear(); // Clear existing items before adding new ones
                comboBox1.Items.AddRange(projectNames.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading projects: {ex.Message}");
            }
            UpdateVisibility();
            ResetButtonStates();

            label9.Text = "";

        }
        private void ResetButtonStates()
        {
            isButton1Clicked = false;
            isButton2Clicked = false;
            isButton3Clicked = false;
            isButton4Clicked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //textboxchange when creating the new project it validates automatically
        {

            if (isButton1Clicked)
            {
                // Check if the project name already exists
                string projectName = textBox1.Text.Trim();

                bool projectExists = projectContext.Project.Any(p => p.ProjectName == projectName);

                if (projectExists)
                {
                    label11.Visible = true;    
                    label11.Text = "Project name already exists.Please choose another name";
                    button3.Enabled = false; // Disable the button if the project name exists
                }
                else
                {
                    label11.Visible = false;
                    label11.Text = "";
                    button3.Enabled = true; // Enable the button if the project name is unique
                }
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)  //create new project button
        {
            panel3.Visible = true;
            panel4.Visible = true;


            isButton1Clicked = true;
            isButton2Clicked = false;
            isButton3Clicked = false;
            isButton4Clicked = false;
            if (isButton1Clicked)
            {
                label3.Visible = true;
                textBox1.Visible = true;
                button3.Visible = true;
                UpdateVisibility();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)  //continue with existing project
        {

            panel5.Visible = true;
            panel3.Visible = true;
            panel4.Visible = false;
            panel6.Visible = false;

            isButton2Clicked = true;
            isButton3Clicked = false;
            isButton4Clicked = false;
            if (isButton2Clicked)
            {


                label5.Visible = true;
                label6.Visible = true;
                label9.Visible = true;
                comboBox1.Visible = true;
                button4.Visible = true;
                UpdateVisibility();

            }
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)  //create project (create) button
        {
            panel6.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Visible = false;
            panel2.Visible = false;



            //    panel3.Visible = true;
            //    panel2.Visible = false;
            isButton1Clicked = false;
            isButton2Clicked = false;
            isButton3Clicked = true;
            isButton4Clicked = false;
            if (isButton3Clicked)
            {
                label7.Visible = true;
                label8.Visible = true;
                label4.Visible = true;
                label1.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                UpdateVisibility();
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                label11.Text = "Please enter a project name before proceeding.";
                return; 
            }

            projectname = textBox1.Text.Trim();

            // Check if the project name already exists
            bool projectExists = projectContext.Project.Any(p => p.ProjectName == projectname);

            if (projectExists)
            {
                label11.Text = "Project Name already exists. Choose another name";
            }
            else
            {
                Project newProject = new Project { ProjectName = projectname };
                projectContext.Project.Add(newProject);
                projectContext.SaveChanges();
                projectid = newProject.ProjectId;

                // label4.Text = projectname;
                label4.Text = newProject.ProjectName;
                projectname = newProject.ProjectName;
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            LoadData();

        }
        private void LoadData()
        {
            bool projectExists = projectContext.Project.Any(p => p.ProjectName == projectname);

            if (projectExists)
            {

                MasterUserControl homeControl = new MasterUserControl();
                homeControl.Dock = DockStyle.Fill;
                homeControl.UpdateProjectLabel(projectname, projectid);
                panel1.Visible = true;
                panel1.Controls.Clear();
                panel1.Controls.Add(homeControl);
                label9.Text = "";

                //1) effort type 

                var dataToInsert = projectContext.DefaultEffortType.ToList(); // Fetch all records    

                // Insert data into DestinationTable with manually specified ProjectId             
                var destinationTableRecords = dataToInsert.Select(item =>
                {
                    // Create a new instance of DestinationTable entity                    
                    var destinationItem = new EffortType
                    {
                        // Set properties from the source table item                        
                        // Assuming the properties are the same in both tables          
                        EffortName = item.EffortName,
                        ActualEffort = item.ActualEffort,
                        Ba = item.Ba,
                        Dev = item.Dev,
                        Qa = item.Qa,
                        Rules = item.Rules,
                        // Set the ProjectId manually
                        ProjectId = projectid // <-- This value needs to be a valid ProjectId
                    };
                    return destinationItem;
                });

                // Add the new records to the destination table                
                projectContext.EffortType.AddRange(destinationTableRecords);


                //3 functional default to functionalarea



                // Fetch all records from DefaultFunctionalArea
                var funcdata = projectContext.DefaultFunctionalArea.ToList();

                // Insert data into FunctionalArea with manually specified ProjectId             
                var desrec = funcdata.Select(item =>
                {
                    // Create a new instance of FunctionalArea entity                    
                    var destinationItem = new FunctionalArea
                    {
                        // Set properties from the source table item                        
                        // Assuming the properties are the same in both tables          
                        FunctionalAreaName = item.FunctionalAreaName,
                        // Set the ProjectId manually
                        ProjectId = projectid // <-- This value needs to be a valid ProjectId
                    };
                    return destinationItem;
                });

                // Add the new records to the destination table                
                projectContext.FunctionalArea.AddRange(desrec);


                //productivity 

                // Fetch all records from DefaultProductivity
                var prod = projectContext.DefaultProductivity.ToList();

                // Insert data into Productivity with manually specified ProjectId             
                var dest = prod.Select(item =>
                {
                    // Create a new instance of Productivity entity                    
                    var destinationItem = new Productivity
                    {
                        // Set properties from the source table item                        
                        // Assuming the properties are the same in both tables          
                        ProductivityName = item.ProductivityName,
                        Hours = item.Hours,
                        // Set the ProjectId manually
                        ProjectId = projectid // <-- This value needs to be a valid ProjectId
                    };
                    return destinationItem;
                });


                // Add the new records to the destination table                
                projectContext.Productivity.AddRange(dest);

                //Functional SubArea
                var FuncSub = projectContext.DefaultFunctionalSubArea.ToList();

                // Insert data into FunctionalSubArea with manually specified ProjectId             
                var destina = FuncSub.Select(item =>
                {
                    var destinationItem = new FunctionalSubArea
                    {
                        FunctionalSubAreaName = item.FunctionalSubAreaName,
                        ProjectId = projectid
                    };
                    return destinationItem;
                });

                // Add the new records to the destination table                
                projectContext.FunctionalSubArea.AddRange(destina);

           

            

             


  
                var soft = projectContext.DefaultSoftware.ToList();

                // Insert data into Software with manually specified ProjectId             
                var de = soft.Select(item =>
                {
                    // Create a new instance of Software entity                    
                    var destinationItem = new Software
                    {
                        // Set properties from the source table item                        
                        // Assuming the properties are the same in both tables          
                        SoftwareName = item.SoftwareName,
                        MonthlyRate = item.MonthlyRate,
                        // Set the ProjectId manually
                        ProjectId = projectid // <-- This value needs to be a valid ProjectId
                    };
                    return destinationItem;
                });

                // Add the new records to the destination table                
                projectContext.Software.AddRange(de);

             //defualt resource to country , resourcetype,resourcelevel , and ResourceRate
                var defaultResources = projectContext.DefaultResource.ToList();

                // HashSet to store distinct values
                var uniqueCountries = new HashSet<string>();
                var uniqueResourceTypes = new HashSet<string>();
                var uniqueResourceLevels = new HashSet<string>();

                foreach (var item in defaultResources)
                {
                    if (uniqueCountries.Add(item.CountryName))
                    {
                        var destinationCountry = new Country
                        {

                            CountryName = item.CountryName,
                            ProjectId = projectid
                        };
                        projectContext.Country.Add(destinationCountry);
                        projectContext.SaveChanges();
                    }

                    if (uniqueResourceTypes.Add(item.TypeName))
                    {
                        var destinationResourceType = new ResourceTypes
                        {
                            TypeName = item.TypeName,
                            ProjectId = projectid
                        };
                        projectContext.ResourceTypes.Add(destinationResourceType);
                        projectContext.SaveChanges();
                    }

                    if (uniqueResourceLevels.Add(item.LevelName))
                    {
                        var destinationResourceLevel = new ResourceLevel
                        {
                            LevelName = item.LevelName,
                            ProjectId = projectid
                        };
                        projectContext.ResourceLevel.Add(destinationResourceLevel);
                        projectContext.SaveChanges();
                    }
                    var res = (from t in projectContext.Country
                               where t.ProjectId == projectid && t.CountryName=="India"
                               select t.CountryId).FirstOrDefault();
                    var res1 = (from t in projectContext.Country
                                where t.ProjectId == projectid && t.CountryName == "USA"
                                select t.CountryId).FirstOrDefault();
                    var typ = (from t in projectContext.ResourceTypes
                               where t.ProjectId == projectid && t.TypeName == "FTE"
                               select t.ResourceTypeId).FirstOrDefault();
                    var typ1 = (from t in projectContext.ResourceTypes
                                where t.ProjectId == projectid && t.TypeName == "Contractor"
                                select t.ResourceTypeId).FirstOrDefault();
                    var c1 = (from t in projectContext.ResourceLevel
                              where t.ProjectId == projectid && t.LevelName == "C01"
                              select t.LevelId).FirstOrDefault();
                    var c2 = (from t in projectContext.ResourceLevel
                              where t.ProjectId == projectid && t.LevelName == "C02"
                              select t.LevelId).FirstOrDefault();
                    var c3 = (from t in projectContext.ResourceLevel
                              where t.ProjectId == projectid && t.LevelName == "C03"
                              select t.LevelId).FirstOrDefault();
                    var c4 = (from t in projectContext.ResourceLevel
                              where t.ProjectId == projectid && t.LevelName == "C04"
                              select t.LevelId).FirstOrDefault();
                    var c5 = (from t in projectContext.ResourceLevel
                              where t.ProjectId == projectid && t.LevelName == "C05"
                              select t.LevelId).FirstOrDefault();
                    var c6 = (from t in projectContext.ResourceLevel
                              where t.ProjectId == projectid && t.LevelName == "C06"
                              select t.LevelId).FirstOrDefault();
                    var c7 = (from t in projectContext.ResourceLevel
                              where t.ProjectId == projectid && t.LevelName == "C07"
                              select t.LevelId).FirstOrDefault();
                    var c8 = (from t in projectContext.ResourceLevel
                              where t.ProjectId == projectid && t.LevelName == "C08"
                              select t.LevelId).FirstOrDefault();
                    var c9 = (from t in projectContext.ResourceLevel
                              where t.ProjectId == projectid && t.LevelName == "C09"
                              select t.LevelId).FirstOrDefault();
                    var levelMappings = new Dictionary<string, int>
                    {
                        { "C01", c1 },
                        { "C02", c2 },
                        { "C03", c3 },
                        { "C04", c4 },
                        { "C05", c5 },
                        { "C06", c6 },
                        { "C07", c7 },
                        { "C08", c8 },
                        { "C09", c9 }
                    };

                    if (uniqueCountries.Contains(item.CountryName) && uniqueResourceTypes.Contains(item.TypeName) && uniqueResourceLevels.Contains(item.LevelName))
                    {

                        var destinationResource = new Resource
                        {
                            LevelId = levelMappings.ContainsKey(item.LevelName) ? levelMappings[item.LevelName] : 0,
                            ResourceTypeId = (item.TypeName == "FTE") ? typ : typ1,
                            CountryId = (item.CountryName == "India") ? res : res1,
                            CountryName = item.CountryName,
                            TypeName = item.TypeName,
                            LevelName = item.LevelName,
                            HourlyRate = item.HourlyRate,
                            ProjectId = projectid,
                        };
                        projectContext.Resource.Add(destinationResource);
                    }



                    // Save changes to the database
                    projectContext.SaveChanges();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //panel3.Visible = false;
            //panel2.Visible = false;
            //panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(new MasterUserControl());
            label1.Visible = false;
            LoadData();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                projectname = comboBox1.SelectedItem.ToString();
                Project selectedProject = projectContext.Project.FirstOrDefault(p => p.ProjectName == projectname);
                    button4.Enabled = true;     
            }
            else
            {
                // Disable the button and update visibility
                button4.Enabled = false;
                UpdateVisibility();

                label9.Text = "Please select the project from the list.";
                panel6.Visible = true;
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = false;
                label1.Visible = true;
                label2.Visible = false;
            }
        }

            private void button4_Click(object sender, EventArgs e)  //existing project (open) button
        {
            panel6.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            label1.Visible = false;
            
            
            if (comboBox1.SelectedIndex != -1)
            {
                button4.Enabled = true;

                panel6.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                label1.Visible = false;
                projectname = comboBox1.SelectedItem.ToString();
                Project selectedProject = projectContext.Project.FirstOrDefault(p => p.ProjectName == projectname);

                if (selectedProject != null)
                {
                    projectid = selectedProject.ProjectId;
                    MasterUserControl homeControl = new MasterUserControl();
                    homeControl.Dock = DockStyle.Fill;
                    homeControl.UpdateProjectLabel(projectname, projectid);
                    panel1.Visible = true;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(homeControl);
                    label9.Text = "";
                }
            }
            else
            {
                label9.Text = "Please select the project from the list.";
                button4.Enabled = false;
                panel6.Visible = true;
                panel1.Visible= false;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = false;
                label1 .Visible = true;
                label2.Visible = false;
            }
  
        }
        
        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void UpdateVisibility()
        {




            // Case 1
            label3.Visible = isButton1Clicked;
            textBox1.Visible = isButton1Clicked;
            button3.Visible = isButton1Clicked;

            // Case 2
            label5.Visible = isButton2Clicked;
            label6.Visible = isButton2Clicked;
            comboBox1.Visible = isButton2Clicked;
            button4.Visible = isButton2Clicked;

            // Case 3 and Case 4
            //label1.Visible = isButton3Clicked || isButton4Clicked;
            label4.Visible = isButton3Clicked || isButton4Clicked;
            label7.Visible = isButton3Clicked || isButton4Clicked;
            label8.Visible = isButton3Clicked || isButton4Clicked;
            button5.Visible = isButton3Clicked || isButton4Clicked;
            button6.Visible = isButton3Clicked || isButton4Clicked;
        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_3(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e) //  get started with default configurations
        {
            LoadData();
            panel6.Visible = false;
            label1.Visible = false;
            MasterUserControl masterControl = new MasterUserControl();
            masterControl.Dock = DockStyle.Fill;
            masterControl.UpdateProjectLabel(projectname, projectid);
            masterControl.LoadScopeSection(); // Call the method to load the "Scope and Effort" section
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(masterControl);
            label9.Text = "";



        }

        private void button6_Click_1(object sender, EventArgs e)  // go to configuration for customization
        {
            LoadData();
            panel6.Visible = false;
            label1.Visible = false;
            MasterUserControl masterControl = new MasterUserControl();
            masterControl.Dock = DockStyle.Fill;
            masterControl.UpdateProjectLabel(projectname, projectid);
            masterControl.loadconfigdata(); //call the method to configurations
            panel1.Visible = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(masterControl);
            label9.Text = "";



        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }
    }
}


