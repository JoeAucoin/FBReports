using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

using GIBS.FBReports.Components;
using DotNetNuke.Common;
using System.Drawing;
using DotNetNuke.Common.Lists;
using DotNetNuke.Framework.JavaScriptLibraries;

namespace GIBS.Modules.FBReports
{
    public partial class NewClientsReport : PortalModuleBase, IActionable
    {
     
        private GridViewHelper helper;
        // To show custom operations...
        private List<int> mQuantities = new List<int>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillLocationsDropdown();

                txtEndDate.Text = DateTime.Now.ToShortDateString();
                txtStartDate.Text = DateTime.Now.AddMonths(-1).ToShortDateString();

                // RUN REPORT
                GetTotalInHouseholdServed();
                Fill_Age_Groups_AFM();
                Fill_Age_Groups_Clients();
                GroupIt();
                Fill_ClientsDetails();
                //  txtEndDate.Text = 
            }
        }


        protected void Page_Init(object sender, EventArgs e)
        {
            ModuleConfiguration.ModuleTitle = Localization.GetString("ControlTitle", this.LocalResourceFile);
            JavaScript.RequestRegistration(CommonJs.jQuery);
            JavaScript.RequestRegistration(CommonJs.jQueryUI);
        }


        public void FillLocationsDropdown()
        {

            try
            {
                var MobileLocations = new ListController().GetListEntryInfoItems("ClientServiceLocation", "", this.PortalId);

                ddlLocations.DataTextField = "Text";
                ddlLocations.DataValueField = "Text";
                ddlLocations.DataSource = MobileLocations;
                ddlLocations.DataBind();
                ddlLocations.Items.Insert(0, new ListItem("All Locations", "0"));
                ddlLocations.Items.Insert(1, new ListItem("This Location", "Pantry"));

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }		

        protected void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                GetTotalInHouseholdServed();
                Fill_Age_Groups_AFM();
                Fill_Age_Groups_Clients();

                GroupIt();
                Fill_ClientsDetails();
                
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void GetTotalInHouseholdServed()
        {

            try
            {
                DateTime _startDate = DateTime.Parse(txtStartDate.Text.ToString());
                DateTime _endDate = DateTime.Parse(txtEndDate.Text.ToString());
                
                FBReportsController controller = new FBReportsController();
                FBReportsInfo item = controller.FBReports_New_Clients_Report_THH(_startDate, _endDate, this.PortalId, ddlLocations.SelectedValue.ToString());


                //lblTHHServed
                if (item != null && item.THH_Served > 0)
                {
                    lblTHHServed.Text = "<b>Total New Clients & Family Served: " + item.THH_Served.ToString() + "</b>";
                }
                else
                {
                    lblTHHServed.Text = "<b>No Results</b>";
                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void Fill_Age_Groups_AFM()
        {

            try
            {
                DateTime _startDate = DateTime.Parse(txtStartDate.Text.ToString());
                DateTime _endDate = DateTime.Parse(txtEndDate.Text.ToString());
                
                List<FBReportsInfo> items;
                FBReportsController controller = new FBReportsController();

                items = controller.FBReports_New_Clients_Age_Groups_AFM(_startDate, _endDate, this.PortalId, ddlLocations.SelectedValue.ToString());

                gv_Age_Groups_AFM.DataSource = items;
                gv_Age_Groups_AFM.DataBind();


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void Fill_Age_Groups_Clients()
        {

            try
            {
                DateTime _startDate = DateTime.Parse(txtStartDate.Text.ToString());
                DateTime _endDate = DateTime.Parse(txtEndDate.Text.ToString());
                
                List<FBReportsInfo> items;
                FBReportsController controller = new FBReportsController();

                items = controller.FBReports_New_Clients_Age_Groups_Clients(_startDate, _endDate, this.PortalId, ddlLocations.SelectedValue.ToString());

                gv_Age_Groups_Clients.DataSource = items;
                gv_Age_Groups_Clients.DataBind();

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }



        public void Fill_ClientsDetails()
        {

            try
            {
                DateTime _startDate = DateTime.Parse(txtStartDate.Text.ToString());
                DateTime _endDate = DateTime.Parse(txtEndDate.Text.ToString());
                
                List<FBReportsInfo> items;
                FBReportsController controller = new FBReportsController();

                items = controller.FBReports_New_Clients_Report(_startDate, _endDate, this.PortalId, ddlLocations.SelectedValue.ToString());

                gv_ClientDetails.DataSource = items;
                gv_ClientDetails.DataBind();





            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        public void GroupIt()
        {

            try
            {

                this.gv_ClientDetails.Columns[0].Visible = true;
                this.gv_ClientDetails.Columns[1].Visible = true;
                this.gv_ClientDetails.Columns[2].Visible = true;
                this.gv_ClientDetails.Columns[3].Visible = true;

                helper = new GridViewHelper(this.gv_ClientDetails);
                if (rblReportType.SelectedValue.ToString() == "Detail")
                {
                    helper.RegisterGroup("ClientCity", true, true);
                }
                else
                {
                    helper.SetSuppressGroup("ClientCity");
                }

                
                helper.RegisterSummary("HouseholdTotal", SummaryOperation.Sum, "ClientCity");

                helper.RegisterSummary("ClientAdult", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("Client65Plus", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("ClientChild", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("ClientNoDOB", SummaryOperation.Sum, "ClientCity");

                helper.RegisterSummary("AFM_Adults", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("AFM_65Plus", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("AFM_Children", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("AFM_NoDOB", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("ClientID", SummaryOperation.Count, "ClientCity");

                
                helper.RegisterSummary("HouseholdTotal", SummaryOperation.Sum);

                helper.RegisterSummary("ClientAdult", SummaryOperation.Sum);
                helper.RegisterSummary("Client65Plus", SummaryOperation.Sum);
                helper.RegisterSummary("ClientChild", SummaryOperation.Sum);
                helper.RegisterSummary("ClientNoDOB", SummaryOperation.Sum);

                helper.RegisterSummary("AFM_Adults", SummaryOperation.Sum);
                helper.RegisterSummary("AFM_65Plus", SummaryOperation.Sum);
                helper.RegisterSummary("AFM_Children", SummaryOperation.Sum);
                helper.RegisterSummary("AFM_NoDOB", SummaryOperation.Sum);
                helper.RegisterSummary("ClientID", SummaryOperation.Count);


                // helper.RegisterGroup("ClientZipCode", true, true);
                helper.GroupHeader += new GroupEvent(helper_GroupHeader);
                helper.GroupSummary += new GroupEvent(helper_Bug);

                if (rblReportType.SelectedValue.ToString() == "Summary")
                {
                    helper.SetInvisibleColumnsWithoutGroupSummary();
                }
                else
                {
                    // DO NOTHING
                }

                helper.ApplyGroupSort();


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void gv_ClientDetails_Sorting(object sender, GridViewSortEventArgs e)
        {
            //gv_ClientDetails.DataSource = // Call to your data-binding routine
            //gv_ClientDetails.DataBind();
        }

        private void helper_ManualSummary(GridViewRow row)
        {
            GridViewRow newRow = helper.InsertGridRow(row);
            newRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            newRow.Cells[0].Text = String.Format("Total: {0} items, ", helper.GeneralSummaries["ClientCity"].Value, helper.GeneralSummaries["HouseholdTotal"].Value);
        }

        private void helper_GroupSummary(string groupName, object[] values, GridViewRow row)
        {
            row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            row.Cells[0].Text = "Média";
        }

        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == "ClientCity")
            {
                row.BackColor = Color.LightGray;
                row.Cells[0].Text = "&nbsp;&nbsp;<b>" + row.Cells[0].Text + "</b>";
                
            }
        }

        private void SaveQuantity(string column, string group, object value)
        {
            mQuantities.Add(Convert.ToInt32(value));
        }

        private object GetMinQuantity(string column, string group)
        {
            int[] qArray = new int[mQuantities.Count];
            mQuantities.CopyTo(qArray);
            Array.Sort(qArray);
            return qArray[0];
        }

        private void helper_Bug(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == null) return;

            row.BackColor = Color.LightCyan;
            row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            row.Cells[0].Text = values[0] + " TOTALS&nbsp;";
        }

        #region IActionable Members 

        public DotNetNuke.Entities.Modules.Actions.ModuleActionCollection ModuleActions
        {
            get
            {
                //create a new action to add an item, this will be added to the controls
                //dropdown menu
                ModuleActionCollection actions = new ModuleActionCollection();
                actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, this.LocalResourceFile),
                    ModuleActionType.AddContent, "", "", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit,
                     true, false);

                return actions;
            }
        }

        #endregion


    }
}