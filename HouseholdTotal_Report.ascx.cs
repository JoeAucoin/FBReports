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
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Common.Lists;

namespace GIBS.Modules.FBReports
{
    public partial class HouseholdTotal_Report : PortalModuleBase, IActionable
    {

        private GridViewHelper helper;
        // To show custom operations...
        private List<int> mQuantities = new List<int>();
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEndDate.Text = DateTime.Now.ToShortDateString();
                txtStartDate.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
                FillLocationsDropdown();

                CountSummary();
                Fill_ClientsDetails();
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



                CountSummary();
 
                Fill_ClientsDetails();

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

                items = controller.FBReports_HouseholdTotal_Report(_startDate, _endDate, Int32.Parse(ddlTHH.SelectedValue.ToString()), this.PortalId);

                gv_ClientDetails.DataSource = items;
                gv_ClientDetails.DataBind();





            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        public void CountSummary()
        {

            try
            {

                helper = new GridViewHelper(this.gv_ClientDetails);
           //     helper.RegisterGroup("ClientCity", true, true);


                //helper.RegisterSummary("HouseholdTotal", SummaryOperation.Sum, "ClientCity");

                //helper.RegisterSummary("AFM_Adults", SummaryOperation.Sum, "ClientCity");
                //helper.RegisterSummary("AFM_65Plus", SummaryOperation.Sum, "ClientCity");
                //helper.RegisterSummary("AFM_Children", SummaryOperation.Sum, "ClientCity");
                //helper.RegisterSummary("AFM_NoDOB", SummaryOperation.Sum, "ClientCity");
                //helper.RegisterSummary("ClientID", SummaryOperation.Count, "ClientCity");


                helper.RegisterSummary("HouseholdTotal", SummaryOperation.Sum);

                helper.RegisterSummary("AFM_Adults", SummaryOperation.Sum);
                helper.RegisterSummary("AFM_65Plus", SummaryOperation.Sum);
                helper.RegisterSummary("AFM_Children", SummaryOperation.Sum);
                helper.RegisterSummary("AFM_NoDOB", SummaryOperation.Sum);
                helper.RegisterSummary("ClientID", SummaryOperation.Count);


                // helper.RegisterGroup("ClientZipCode", true, true);
          //      helper.GroupHeader += new GroupEvent(helper_GroupHeader);
                helper.GroupSummary += new GroupEvent(helper_Bug);

            //    helper.ApplyGroupSort();


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