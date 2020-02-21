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
    public partial class Settings : ModuleSettingsBase
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
                    
                    FBReportsSettings settingsData = new FBReportsSettings(this.TabModuleId);

                    if (settingsData.FoodBankClientModuleID != null)
                    {

                        drpModuleID.SelectedValue = settingsData.FoodBankClientModuleID;
                    }
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
                 //   ListItem objListItem = new ListItem();

                    //objListItem.Value = mi.ModuleID.ToString();
                    //objListItem.Text = mi.ModuleTitle.ToString();

                    //drpModuleID.Items.Add(objListItem);

                    ListItem objListItemPage = new ListItem();
                    objListItemPage.Value = mi.TabID.ToString() + "-" + mi.ModuleID.ToString();
                    objListItemPage.Text = mi.ModuleTitle.ToString();

                    drpModuleID.Items.Add(objListItemPage);

                }
            }

            drpModuleID.Items.Insert(0, new ListItem(Localization.GetString("SelectModule", this.LocalResourceFile), "-1"));

        }

        //private void BindModules()
        //{
        //    //DotNetNuke.Entities.Modules.DesktopModuleController objDesktopModuleController = new DotNetNuke.Entities.Modules.DesktopModuleController();
        //    //DesktopModuleInfo objDesktopModuleInfo =  objDesktopModuleController.GetDesktopModuleByModuleName("FBClients");

        //    DotNetNuke.Entities.Modules.DesktopModuleController objDesktopModuleController = new DotNetNuke.Entities.Modules.DesktopModuleController();


        //    DotNetNuke.Entities.Modules.DesktopModuleInfo objDesktopModuleInfo = DotNetNuke.Entities.Modules.DesktopModuleController.GetDesktopModuleByModuleName("GIBS.FBClients", PortalId);


        //    if ((objDesktopModuleInfo != null))
        //    {
        //        TabController objTabController = new TabController();
        //        ArrayList objTabs = objTabController.GetTabs(PortalId);
        //        foreach (DotNetNuke.Entities.Tabs.TabInfo objTab in objTabs)
        //        {
        //            if ((objTab != null))
        //            {
        //                if ((objTab.IsDeleted == false))
        //                {
        //                    ModuleController objModules = new ModuleController();
        //                    foreach (KeyValuePair<int, ModuleInfo> pair in objModules.GetTabModules(objTab.TabID))
        //                    {
        //                        ModuleInfo objModule = pair.Value;
        //                        if ((objModule.IsDeleted == false))
        //                        {
        //                            if ((objModule.DesktopModuleID == objDesktopModuleInfo.DesktopModuleID))
        //                            {
        //                                //if (PortalSecurity.IsInRoles(objModule.AuthorizedEditRoles) == true & objModule.IsDeleted == false)
        //                                if (objModule.IsDeleted == false)
        //                                {
        //                                    string strPath = objTab.TabName;
        //                                    TabInfo objTabSelected = objTab;
        //                                    while (objTabSelected.ParentId != Null.NullInteger)
        //                                    {
        //                                        objTabSelected = objTabController.GetTab(objTabSelected.ParentId, objTab.PortalID, false);
        //                                        if ((objTabSelected == null))
        //                                        {
        //                                            break; // TODO: might not be correct. Was : Exit While
        //                                        }
        //                                        strPath = objTabSelected.TabName + " -> " + strPath;
        //                                    }

        //                                    ListItem objListItem = new ListItem();

        //                                    objListItem.Value = objModule.TabID.ToString() + "-" + objModule.ModuleID.ToString();
        //                                    objListItem.Text = strPath + " -> " + objModule.ModuleTitle;

        //                                    drpModuleID.Items.Add(objListItem);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        drpModuleID.Items.Insert(0, new ListItem(Localization.GetString("SelectModule", this.LocalResourceFile), "-1"));

        //    }
        //}



        /// <summary>
        /// handles updating the module settings for this control
        /// </summary>
        public override void UpdateSettings()
        {
            try
            {
                FBReportsSettings settingsData = new FBReportsSettings(this.TabModuleId);
                settingsData.FoodBankClientModuleID = drpModuleID.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }
    }
}