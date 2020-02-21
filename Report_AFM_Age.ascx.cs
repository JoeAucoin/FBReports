using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

using GIBS.FBReports.Components;
using DotNetNuke.Common;
using DotNetNuke.Web.UI.WebControls;
//using Telerik.Web.UI;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Common.Lists;






namespace GIBS.Modules.FBReports
{
    public partial class Report_AFM_Age : PortalModuleBase, IActionable
    {
     
        

        static int myModID = 0;
        static int myTabID = 0;
     //   bool isPdfExport = false;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            try
            {
               
             //   this.Controls.Add(new Telerik.Web.UI.RadStyleSheetManager());


                if (!IsPostBack)
                {

                    txtEndDate.Text = DateTime.Now.ToShortDateString();
                    txtStartDate.Text = DateTime.Now.AddMonths(-1).ToShortDateString();

                    GetSettings();
                    FillLocationsDropdown();

                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
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

        public void GetSettings()
        {

            try
            {

                //FBReportsSettings settingsData = new FBReportsSettings(this.TabModuleId);

                //         if (settingsData.FoodBankClientModuleID != null)
                //         {

                //             string MyReturnURL = settingsData.FoodBankClientModuleID;
                //             // 65-496
                //             string s = MyReturnURL;
                //             string[] parts = s.Split('-');
                //             string i1 = parts[0];
                //             string i2 = parts[1];

                //             myModID = Convert.ToInt32(i2);
                //             myTabID = Convert.ToInt32(i1);

                //         }

                if (Settings.Contains("FoodBankClientModuleID"))
                {
                    string MyReturnURL = Settings["FoodBankClientModuleID"].ToString();
                    string s = MyReturnURL;
                    string[] parts = s.Split('-');
                    string i1 = parts[0];
                    string i2 = parts[1];

                    myModID = Convert.ToInt32(i2);
                    myTabID = Convert.ToInt32(i1);
                }

                //Populate the ddlMinAge DropDownList
                for (int i = 1; i <= 21; i++)
                {
                    String age = (i).ToString();
                    ListItem li = new ListItem(age, age);
                    ddlMinAge.Items.Add(li);
                } 

                //Populate the ddlMaxAge DropDownList
                for (int i = 14; i <= 65; i++)
                {
                    String age = (i).ToString();
                    ListItem li = new ListItem(age, age);
                    ddlMaxAge.Items.Add(li);
                } 

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }	


        protected void Page_Init(object sender, EventArgs e)
        {
            ModuleConfiguration.ModuleTitle = Localization.GetString("ControlTitle", this.LocalResourceFile);
            JavaScript.RequestRegistration(CommonJs.jQuery);
            JavaScript.RequestRegistration(CommonJs.jQueryUI);
        }


        protected void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
               
         //       GroupIt();
                Fill_Report();
                
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }



        public void Fill_Report()
        {

            try
            {
                DateTime _startDate = DateTime.Parse(txtStartDate.Text.ToString());
                DateTime _endDate = DateTime.Parse(txtEndDate.Text.ToString());
                
                List<FBReportsInfo> items;
                FBReportsController controller = new FBReportsController();

                items = controller.FBReports_AFM_Age(_startDate, _endDate, Int32.Parse(ddlMinAge.SelectedValue.ToString()), Int32.Parse(ddlMaxAge.SelectedValue.ToString()), this.PortalId, ddlLocations.SelectedValue.ToString());
                
             //   DnnGrid1.MasterTableView.Caption = Localization.GetString("dnnGrid_ReportLabel", this.LocalResourceFile) + " - Last Visit between " + _startDate.ToShortDateString() + "  and " + _endDate.ToShortDateString();
                lblMessage.Text = Localization.GetString("dnnGrid_ReportLabel", this.LocalResourceFile) + "<br />Last Visit between " + _startDate.ToShortDateString() + "  and " + _endDate.ToShortDateString() + "<br />" + items.Count.ToString() + " Records";
                GridView1.DataSource = items;
                GridView1.DataBind();
                





            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }



        //protected void RadGrid1_GridExporting(object source, GridExportingArgs e)
        //{
        //    switch (e.ExportType)
        //    {
        //        case ExportType.Excel:
        //            do something with the e.ExportOutput value      
        //            break;
        //        case ExportType.ExcelML:
        //            do something with the e.ExportOutput value     
        //            break;
        //        case ExportType.Word:
        //            do something with the e.ExportOutput value       
        //            break;
        //        case ExportType.Csv:
        //            do something with the e.ExportOutput value    
        //            break;
        //        case ExportType.Pdf:
        //            you can't change the output here - use the PdfExporting event instead   
        //            break;
        //    }
        //}

        //open_in_new_tab(url)

        //protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        //{

        //    if (e.CommandName == RadGrid.ExportToPdfCommandName)

        //        isPdfExport = true;

        //}

        //protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        //{

        //    if (isPdfExport)

        //        FormatGridItem(e.Item);

        //}

        //protected void FormatGridItem(GridItem item)
        //{

        //    item.Style["color"] = "#eeeeee";



        //    if (item is GridDataItem)
        //    {

        //        item.Style["vertical-align"] = "middle";

        //        item.Style["text-align"] = "center";

        //    }



        //    switch (item.ItemType) //Mimic RadGrid appearance for the exported PDF file
        //    {

        //        case GridItemType.Item: item.Style["background-color"] = "#4F4F4F"; break;

        //        case GridItemType.AlternatingItem: item.Style["background-color"] = "#494949"; break;

        //        case GridItemType.Header: item.Style["background-color"] = "#2B2B2B"; break;

        //        case GridItemType.CommandItem: item.Style["background-color"] = "#000000"; break;

        //    }



        //    if (item is GridCommandItem)
        //    {

        //        item.PrepareItemStyle();  //needed to span the image over the CommandItem cells

        //    }

        //}

        protected void gv_ClientDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.LinkButton lbNewWindow = new System.Web.UI.WebControls.LinkButton();
                lbNewWindow = (System.Web.UI.WebControls.LinkButton)e.Row.FindControl("LinkButtonEdit");
                if (lbNewWindow != null)
                {
                    string clientID = DataBinder.Eval(e.Row.DataItem, "ClientID").ToString();

                    string newURL = Globals.NavigateURL(myTabID, "EditClient", "mid=" + myModID.ToString() + "&cid=" + clientID);

                    lbNewWindow.Attributes.Add("OnClick", "open_in_new_tab('" + newURL.ToString() + "')");

                }
            }
        }


        protected void gv_ClientDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Edit")
                {
                    int clientID = Convert.ToInt32(e.CommandArgument);

                    if (Settings.Contains("FoodBankClientModuleID"))
                    {
                        string MyReturnURL = Settings["FoodBankClientModuleID"].ToString();
                        // 65-496
                        string s = MyReturnURL;
                        string[] parts = s.Split('-');
                        string i1 = parts[0];
                        string i2 = parts[1];

                        int myModID = Convert.ToInt32(i2);
                        int myTabID = Convert.ToInt32(i1);

                        string newURL = Globals.NavigateURL(myTabID, "EditClient", "mid=" + myModID.ToString() + "&cid=" + clientID);

                    }


                }




            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void gv_ClientDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // No requirement to implement code here
        }

        protected void gv_ClientDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // No requirement to implement code here
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






        protected void Button1_Click(object sender, EventArgs e)
        {

      //      DnnGrid1.MasterTableView.GetColumn("ClientCity").Visible = false;
            

            //DnnGrid1.ExportSettings.Pdf.PageHeight = Unit.Parse("11in");
            //DnnGrid1.ExportSettings.Pdf.PageWidth = Unit.Parse("8.5in");
            //DnnGrid1.ExportSettings.Pdf.PageLeftMargin = Unit.Parse(".25in");
            //DnnGrid1.ExportSettings.Pdf.PageRightMargin = Unit.Parse(".25in");
            //DnnGrid1.ExportSettings.Pdf.PageTopMargin = Unit.Parse(".25in");
            //DnnGrid1.ExportSettings.Pdf.PageBottomMargin = Unit.Parse(".25in");

            //foreach (GridDataItem item in DnnGrid1.Items)
            //    item.Style["font-size"] = "8px";


            ////Localization.GetString("dnnGrid_ReportLabel", this.LocalResourceFile) + " - Start Date: " + radStartDate.SelectedDate.Value.ToShortDateString() + "  |  End Date: " + radEndDate.SelectedDate.Value.ToShortDateString();

            //DnnGrid1.ExportSettings.Pdf.Author = "Global Internet Business Solutions";
            //DnnGrid1.ExportSettings.Pdf.Subject = "A www.DnnFoodBank.com Module";

            //DnnGrid1.ExportSettings.Pdf.PageTitle = DnnGrid1.MasterTableView.Caption.ToString();
            //DnnGrid1.ExportSettings.Pdf.Title = DnnGrid1.MasterTableView.Caption.ToString();

            //DnnGrid1.ExportSettings.FileName = "rptHouseholdMembersByAge-" + string.Format("{0:yyyy-MM-dd_hh-mm}", DateTime.Now);

            //DnnGrid1.MasterTableView.ExportToPdf();
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {


            //DnnGrid1.ExportSettings.FileName = "rptHouseholdMembersByAge-" + string.Format("{0:yyyy-MM-dd_hh-mm}", DateTime.Now);

            ////   DnnGrid1.MasterTableView.ExportToCSV();
            //// DnnGrid1.MasterTableView.ExportToWord();

            //DnnGrid1.MasterTableView.ExportToExcel();


        }





    }
}