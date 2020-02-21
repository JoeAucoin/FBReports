using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common;

namespace GIBS.FBReports.Components
{
    /// <summary>
    /// Provides strong typed access to settings used by module
    /// </summary>
    public class FBReportsSettings : ModuleSettingsBase
    {
        
        #region public properties

        /// <summary>
        /// get/set template used to render the module content
        /// to the user 
        /// </summary>


        public string FoodBankClientModuleID
        {
            get
            {
                if (Settings.Contains("FoodBankClientModuleID"))
                    return Settings["FoodBankClientModuleID"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateTabModuleSetting(this.TabModuleId, "foodBankClientModuleID", value.ToString());
            }
        }


        #endregion
    }
}
