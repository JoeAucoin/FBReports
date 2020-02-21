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
    public partial class MapReport : PortalModuleBase
    {

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            JavaScript.RequestRegistration(CommonJs.jQuery);
            JavaScript.RequestRegistration(CommonJs.jQueryUI);
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEndDate.Text = DateTime.Now.ToShortDateString();
                txtStartDate.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
                FillLocationsDropdown();
               

                Fill_Report();
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

        protected void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {


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
                string s = "";
                DateTime _startDate = DateTime.Parse(txtStartDate.Text.ToString());
                DateTime _endDate = DateTime.Parse(txtEndDate.Text.ToString());

                List<FBReportsInfo> items;
                FBReportsController controller = new FBReportsController();

                items = controller.FBReports_MapClients(_startDate, _endDate);

                rptMarkers.DataSource = items;
                rptMarkers.DataBind();

                //for (int i = 0; i < items.Count; i++)
                //{
                // //   lblDebug.Text += items[i].Latitude + Environment.NewLine;
                //    s += "{ lat: " + items[i].Latitude + ", lng: " + items[i].Longitude + " },"  + Environment.NewLine;

                //}
                //s = s.TrimEnd('\r', '\n', ',');
                //lblDebug.Text = s.ToString();
                //litMapCenter.Text = s.ToString();

             //   //    gv_ClientDetails.DataSource = items;
             //   //    gv_ClientDetails.DataBind();



            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        //public void GetMarkers()
        //{
        //    try
        //    {
                
        //        litMapCenter.Text = "{ lat: 41.69008, lng: -69.95197 }," + Environment.NewLine
        //            + "{ lat: 41.65008, lng: -69.85197 }";


        //    }
        //    catch (Exception ex)
        //    {
        //        Exceptions.ProcessModuleLoadException(this, ex);
        //    }

        //}


    }
}