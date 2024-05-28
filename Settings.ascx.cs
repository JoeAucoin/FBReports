using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

using GIBS.FBReports.Components;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Tabs;
using System.Collections;
using System.Collections.Generic;
using DotNetNuke.Security;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Localization;

namespace GIBS.Modules.FBReports
{
    public partial class Settings : FBReportsSettings
    {

        /// <summary>
        /// handles the loading of the module setting for this
        /// control
        /// </summary>
        public override void LoadSettings()
        {
            try
            {
                if (!IsPostBack)
                {
                    BindModules();
              

                    //GoogleMapAPIKey
                    if (Settings.Contains("GoogleMapAPIKey"))
                    {
                        txtGoogleMapAPIKey.Text= Settings["GoogleMapAPIKey"].ToString();
                      
                    }

                 //   LabelDebug.Text = FoodBankClientModuleID.ToString();

                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }


        private void BindModules()
        {
            
            DotNetNuke.Entities.Modules.ModuleController mc = new ModuleController();
            ArrayList existMods = mc.GetModulesByDefinition(this.PortalId, "GIBS Food Bank Client Manager");

            foreach (DotNetNuke.Entities.Modules.ModuleInfo mi in existMods)
            {
                if (!mi.IsDeleted)
                {
                 
                    ListItem objListItemPage = new ListItem();
                    objListItemPage.Value = mi.TabID.ToString() + "-" + mi.ModuleID.ToString();
                    objListItemPage.Text = mi.ModuleTitle.ToString();

                    drpModuleID.Items.Add(objListItemPage);

                }
            }

            drpModuleID.Items.Insert(0, new ListItem(Localization.GetString("SelectModule", this.LocalResourceFile), "-1"));
        
            if (Settings.Contains("foodBankClientModuleID"))
            {
                drpModuleID.SelectedValue = Settings["foodBankClientModuleID"].ToString();
             //   LabelDebug.Text = Settings["foodBankClientModuleID"].ToString();
                
            }

        }




        /// <summary>
        /// handles updating the module settings for this control
        /// </summary>
        public override void UpdateSettings()
        {
            try
            {
               
                FoodBankClientModuleID = drpModuleID.SelectedValue.ToString();
                GoogleMapAPIKey = txtGoogleMapAPIKey.Text.ToString();
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }
    }
}