using Org.BouncyCastle.Crypto.Tls;
using ProjectEstimationTool.Models;
using ProjectEstimationTool.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectEstimationTool
{
    public partial class ResourceAllocationUserControl : UserControl
    {
        ProjectEstimationToolMasterContext db = new ProjectEstimationToolMasterContext();
        //private int ProjectId;
        private int TimelineId;
        private int resallocated;
        //private ResourceAllocation Res { get; set; }


        public ResourceAllocationUserControl()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void RefreshData()
        {
            var res = from t in db.ResourceAllocation
                      where t.ProjectId == Form1.projectid
                      select t;
            dataGridView1.DataSource = res.ToList();
        }
        private void ResourceAllocationUserControl_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;




            LoadAllocationData();
            //updateRes();
            //delresUpdate();
            RefreshData();
        }
        public void LoadAllocationData()
        {
            try
            {
                var distinctPhases = db.Timeline .Where(p => p.ProjectId == Form1.projectid).Select(p => p.Phase).Distinct().ToList();

                foreach (var phase in distinctPhases)
                {
                    // Check if records already exist for the current phase in ImplementingResourceCosting
                    if (!db.ResourceAllocation.Any(e => e.ProjectId == Form1.projectid && e.Phase == phase))
                    {
                        // Records don't exist for the current phase, proceed to load data
                        var phasesForCurrentPhase = db.Timeline .Where(p => p.ProjectId == Form1.projectid && p.Phase == phase).ToList();
                        foreach (var phasename in phasesForCurrentPhase)
                        {
                            // Create a new instance of ImplementingResourceCosting
                            var Res = new ResourceAllocation
                            {
                                ProjectId = Form1.projectid,
                                TimelineId = phasename.TimelineId,
                                Functionality = phasename.Functionality,
                                Phase = phasename.Phase,
                                ResReq = phasename.ResReq,
                                EffHrs = phasename.EffHrs,
                                Mm = phasename.Mm,
                                ResourceAllocated = 0,
                                ResourcePending = phasename.ResReq
                            };
                            // Add the new record to the ImplementingResourceCosting table
                            db.ResourceAllocation.Add(Res);
                        }
                        // Save changes to the database for the current phase
                        db.SaveChanges();
                        RefreshData();
                    }
                    else
                    {
                        RefreshData();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error loading allocation data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
       
        public void updateRes() //when the data is updated in timeline it reflects in the resource allocation data
        {
            //try
            //{
            //    // Fetch the TimelineId based on the projectid
            //    var timelineId = db.Timeline
            //        .Where(t => t.ProjectId == Form1.projectid)
            //        .Select(t => t.TimelineId)
            //        .ToList();

            //    bool resdataupdate = db.ResourceAllocation.Any(t => t.ProjectId == Form1.projectid) ;

            //    if (resdataupdate)
            //    {
            //        var resourcesupdated = db.ResourceAllocation.Where(t => t.ProjectId == Form1.projectid).ToList();

            //        foreach (var resource in resourcesupdated)
            //        {
            //            // Fetch the ResourceCount from ResourceCosting for the specific TimelineId
            //            foreach (var item in timelineId)
            //            {
            //                int resallocated = db.ResourceCosting
            //                    .Where(t => t.ProjectId == Form1.projectid && t.TimelineId == item)
            //                    .Select(t => t.ResCount)
            //                    .Sum();

            //                // Create a new ResourceAllocation object for each timelineId


            //                // Assuming that the latest timelinedata corresponds to the last item in timelineId
            //                var timelinedata = db.Timeline.FirstOrDefault(t => t.TimelineId == item && t.ProjectId == Form1.projectid);

            //                if (timelinedata != null)
            //                {
            //                    var updatedResource = new ResourceAllocation
            //                    {
            //                        ProjectId = resource.ProjectId,
            //                        TimelineId = resource.TimelineId,
            //                        Functionality = resource.Functionality,
            //                        Phase = resource.Phase,
            //                        ResReq = resource.ResReq,
            //                        EffHrs = resource.EffHrs,
            //                        Mm = resource.Mm,
            //                        ResourceAllocated = resallocated,
            //                        ResourcePending = resource.ResourcePending
            //                    };

            //                    // Update or add the new ResourceAllocation object to the database
            //                    db.ResourceAllocation.Update(updatedResource);
            //                }
            //            }
            //        }

            //        db.SaveChanges();
            //        RefreshData();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error updating resource allocation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
        public void delresUpdate() //when the data is deleted in timeline it automatically updates in the resourceallocation
        {
            try
            {
                bool resdel = db.ResourceAllocation.Any(t => t.ProjectId == Form1.projectid);
                if (resdel)
                {
                    var resTodlete = db.ResourceAllocation.Where(t => t.ProjectId == Form1.projectid && t.TimelineId == TimelineId).ToList();
                    foreach (var resource in resTodlete) 
                    {
                        db.ResourceAllocation.Remove(resource);

                    }
                    db.SaveChanges();
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting resource allocation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Timeline tm = new Timeline();
            this.Hide();
            this.Parent.Controls.Add(tm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           ResourceCostingUserControl rc = new ResourceCostingUserControl();
            this.Hide();
            this.Parent.Controls.Add(rc);
        }
       
    }
}
