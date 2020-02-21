using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke;
using GIBS.FBReports.Components;
using DotNetNuke.Common;

namespace GIBS.Modules.FBReports
{
    public partial class ViewFBReports : PortalModuleBase
        //, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HyperLink1.NavigateUrl = Globals.NavigateURL(this.TabId, "DailyReport", "mid=" + ModuleId.ToString());
            HyperLink1.Text = "Client Visit Report";
            HyperLink2.NavigateUrl = Globals.NavigateURL(this.TabId, "NewClientsReport", "mid=" + ModuleId.ToString());
            HyperLink2.Text = "New Clients Report";
            HyperLink3.NavigateUrl = Globals.NavigateURL(this.TabId, "DistinctClientsReport", "mid=" + ModuleId.ToString());
            HyperLink3.Text = "Distinct Clients Report";
            HyperLink4.NavigateUrl = Globals.NavigateURL(this.TabId, "HouseholdTotal_Report", "mid=" + ModuleId.ToString());
            HyperLink4.Text = "Household Total Report";
            HyperLink5.NavigateUrl = Globals.NavigateURL(this.TabId, "AFMAgeReport", "mid=" + ModuleId.ToString());
            HyperLink5.Text = "Household Members by Age Report";
            HyperLink6.NavigateUrl = Globals.NavigateURL(this.TabId, "FoodReport", "mid=" + ModuleId.ToString());
            HyperLink6.Text = "Food Inventory Report";

            HyperLink7.NavigateUrl = Globals.NavigateURL(this.TabId, "MapReport", "mid=" + ModuleId.ToString());
            //    AFMAgeReport

            //try
            //{
            //     //   LoadSettings();
                 


            //    if (!IsPostBack)
            //    {

            //     //   LoadSettings();
                 
            //        HyperLink1.NavigateUrl = Globals.NavigateURL(this.TabId, "DailyReport", "mid=" + ModuleId.ToString());
            //        HyperLink1.Text = "Client Visit Report";
            //        HyperLink2.NavigateUrl = Globals.NavigateURL(this.TabId, "NewClientsReport", "mid=" + ModuleId.ToString());
            //        HyperLink2.Text = "New Clients Report";
            //        HyperLink3.NavigateUrl = Globals.NavigateURL(this.TabId, "DistinctClientsReport", "mid=" + ModuleId.ToString());
            //        HyperLink3.Text = "Distinct Clients Report";
            //        HyperLink4.NavigateUrl = Globals.NavigateURL(this.TabId, "HouseholdTotal_Report", "mid=" + ModuleId.ToString());
            //        HyperLink4.Text = "Household Total Report";
            //        HyperLink5.NavigateUrl = Globals.NavigateURL(this.TabId, "AFMAgeReport", "mid=" + ModuleId.ToString());
            //        HyperLink5.Text = "Household Members by Age Report";
            //        HyperLink6.NavigateUrl = Globals.NavigateURL(this.TabId, "FoodReport", "mid=" + ModuleId.ToString());
            //        HyperLink6.Text = "Food Inventory Report";

            //        HyperLink7.NavigateUrl = Globals.NavigateURL(this.TabId, "MapReport", "mid=" + ModuleId.ToString());
            //        //    AFMAgeReport
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Exceptions.ProcessModuleLoadException(this, ex);
            //}
        }


      //  public void LoadSettings()
        //{
        //    try
        //    {
        //        if (!IsPostBack)
        //        {

        //            //FBReportsSettings settingsData = new FBReportsSettings(this.TabModuleId);

        //            //if (settingsData.FormToLoad != null)
        //            //{
        //            //    // Response.Redirect(Globals.NavigateURL(PortalSettings.ActiveTab.TabID, settingsData.FormToLoad.ToString(), "mid=" + ModuleId.ToString()));



        //            //    //ChangeRequestForm changeRequestForm = (ChangeRequestForm)Page.LoadControl(ControlPath.ToString() + "ChangeRequestForm.ascx");

        //            //    ////add the control to the place holder!
        //            //    //PlaceHolder1.Controls.Add(changeRequestForm);

        //            //}
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Exceptions.ProcessModuleLoadException(this, ex);
        //    }
        //}


        //#region IActionable Members

        //public DotNetNuke.Entities.Modules.Actions.ModuleActionCollection ModuleActions
        //{
        //    get
        //    {
        //        //create a new action to add an item, this will be added to the controls
        //        //dropdown menu
        //        ModuleActionCollection actions = new ModuleActionCollection();
        //        actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, this.LocalResourceFile),
        //            ModuleActionType.AddContent, "", "", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit,
        //             true, false);

        //        return actions;
        //    }
        //}

        //#endregion


        /// <summary>
        /// Handles the items being bound to the datalist control. In this method we merge the data with the
        /// template defined for this control to produce the result to display to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


    }
}