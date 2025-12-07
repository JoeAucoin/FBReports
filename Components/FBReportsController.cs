using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace GIBS.FBReports.Components
{
    public class FBReportsController : IPortable
    {

        #region public method

        public List<FBReportsInfo> FBReports_GetFoodOrderMenu()
        {
            return CBO.FillCollection<FBReportsInfo>(DataProvider.Instance().FBReports_GetFoodOrderMenu());
        }

        public FBReportsInfo FBReports_New_Clients_Report_THH(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
          return CBO.FillObject<FBReportsInfo>(DataProvider.Instance().FBReports_New_Clients_Report_THH(startDate, endDate, portalId, serviceLocation));
        }

        public FBReportsInfo FBReports_THH_Served(DateTime startDate, DateTime endDate, int portalId, string serviceLocation) 
        {
            return CBO.FillObject<FBReportsInfo>(DataProvider.Instance().FBReports_THH_Served(startDate, endDate, portalId, serviceLocation));
        }

        //FBReports_Age_Groups_AFM
        public List<FBReportsInfo> FBReports_Age_Groups_AFM(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return CBO.FillCollection<FBReportsInfo>(DataProvider.Instance().FBReports_Age_Groups_AFM(startDate, endDate, portalId, serviceLocation));
        }

        
        // FBReports_Age_Groups_Clients
        public List<FBReportsInfo> FBReports_Age_Groups_Clients(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return CBO.FillCollection<FBReportsInfo>(DataProvider.Instance().FBReports_Age_Groups_Clients(startDate, endDate, portalId, serviceLocation));
        }
        // FBReports_Client_Visit_Details
        public List<FBReportsInfo> FBReports_Client_Visit_Details(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return CBO.FillCollection<FBReportsInfo>(DataProvider.Instance().FBReports_Client_Visit_Details(startDate, endDate, portalId, serviceLocation));
        }


        // NEW CLIENTS REPORT
        public List<FBReportsInfo> FBReports_New_Clients_Report(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return CBO.FillCollection<FBReportsInfo>(DataProvider.Instance().FBReports_New_Clients_Report(startDate, endDate, portalId, serviceLocation));
        }

        public List<FBReportsInfo> FBReports_New_Clients_Age_Groups_AFM(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return CBO.FillCollection<FBReportsInfo>(DataProvider.Instance().FBReports_New_Clients_Age_Groups_AFM(startDate, endDate, portalId, serviceLocation));
        }

        public List<FBReportsInfo> FBReports_New_Clients_Age_Groups_Clients(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return CBO.FillCollection<FBReportsInfo>(DataProvider.Instance().FBReports_New_Clients_Age_Groups_Clients(startDate, endDate, portalId, serviceLocation));
        }
        
        public List<FBReportsInfo> FBReports_Distinct_Clients_By_City(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return CBO.FillCollection<FBReportsInfo>(DataProvider.Instance().FBReports_Distinct_Clients_By_City(startDate, endDate, portalId, serviceLocation));
        }

        public List<FBReportsInfo> FBReports_HouseholdTotal_Report(DateTime startDate, DateTime endDate, int numberInFamily, int portalId)
        {
            return CBO.FillCollection<FBReportsInfo>(DataProvider.Instance().FBReports_HouseholdTotal_Report(startDate, endDate, numberInFamily, portalId));
        }

        public List<FBReportsInfo> FBReports_AFM_Age(DateTime startDate, DateTime endDate, int minAge, int maxAge, int portalId, string serviceLocation)
        {
            return CBO.FillCollection<FBReportsInfo>(DataProvider.Instance().FBReports_AFM_Age(startDate, endDate, minAge, maxAge, portalId, serviceLocation));
        }

        public List<FBReportsInfo> FBReports_MapClients(DateTime startDate, DateTime endDate)
        {
            return CBO.FillCollection<FBReportsInfo>(DataProvider.Instance().FBReports_MapClients(startDate, endDate));
        }

        

        #endregion



        #region IPortable Members

        /// <summary>
        /// Exports a module to xml
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public string ExportModule(int moduleID)
        {
            StringBuilder sb = new StringBuilder();

            //List<FBReportsInfo> infos = GetFBReportss(moduleID);

            //if (infos.Count > 0)
            //{
            //    sb.Append("<FBReportss>");
            //    foreach (FBReportsInfo info in infos)
            //    {
            //        sb.Append("<FBReports>");
            //        sb.Append("<content>");
            //        sb.Append(XmlUtils.XMLEncode(info.Content));
            //        sb.Append("</content>");
            //        sb.Append("</FBReports>");
            //    }
            //    sb.Append("</FBReportss>");
            //}

            return sb.ToString();
        }

        /// <summary>
        /// imports a module from an xml file
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <param name="Content"></param>
        /// <param name="Version"></param>
        /// <param name="UserID"></param>
        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "FBReportss");

            foreach (XmlNode info in infos.SelectNodes("FBReports"))
            {
                //FBReportsInfo FBReportsInfo = new FBReportsInfo();
                //FBReportsInfo.ModuleId = ModuleID;
                //FBReportsInfo.Content = info.SelectSingleNode("content").InnerText;
                //FBReportsInfo.CreatedByUser = UserID;

                //AddFBReports(FBReportsInfo);
            }
        }

        #endregion
    }
}
