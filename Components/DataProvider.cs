using System;
using System.Data;
using DotNetNuke;
using DotNetNuke.Framework;

namespace GIBS.FBReports.Components
{
    public abstract class DataProvider
    {

        #region common methods

        /// <summary>
        /// var that is returned in the this singleton
        /// pattern
        /// </summary>
        private static DataProvider instance = null;

        /// <summary>
        /// private static cstor that is used to init an
        /// instance of this class as a singleton
        /// </summary>
        static DataProvider()
        {
            instance = (DataProvider)Reflection.CreateObject("data", "GIBS.FBReports.Components", "");
        }

        /// <summary>
        /// Exposes the singleton object used to access the database with
        /// the conrete dataprovider
        /// </summary>
        /// <returns></returns>
        public static DataProvider Instance()
        {
            return instance;
        }

        #endregion


        #region Abstract methods

        /* implement the methods that the dataprovider should */

        //FBReports_THH_Served
        // FBReports_Age_Groups_AFM
        // FBReports_Age_Groups_Clients
        // FBReports_Client_Visit_Details
        //FBReports_New_Clients_Report_THH


        public abstract IDataReader FBReports_New_Clients_Report_THH(DateTime startDate, DateTime endDate, int portalId, string serviceLocation);

        public abstract IDataReader FBReports_THH_Served(DateTime startDate, DateTime endDate, int portalId, string serviceLocation);
        public abstract IDataReader FBReports_Age_Groups_AFM(DateTime startDate, DateTime endDate, int portalId, string serviceLocation);
        public abstract IDataReader FBReports_Age_Groups_Clients(DateTime startDate, DateTime endDate, int portalId, string serviceLocation);
        public abstract IDataReader FBReports_Client_Visit_Details(DateTime startDate, DateTime endDate, int portalId, string serviceLocation);

        public abstract IDataReader FBReports_New_Clients_Report(DateTime startDate, DateTime endDate, int portalId, string serviceLocation);
        public abstract IDataReader FBReports_New_Clients_Age_Groups_AFM(DateTime startDate, DateTime endDate, int portalId, string serviceLocation);
        public abstract IDataReader FBReports_New_Clients_Age_Groups_Clients(DateTime startDate, DateTime endDate, int portalId, string serviceLocation);


        public abstract IDataReader FBReports_Distinct_Clients_By_City(DateTime startDate, DateTime endDate, int portalId, string serviceLocation);

        public abstract IDataReader FBReports_HouseholdTotal_Report(DateTime startDate, DateTime endDate, int numberInFamily, int portalId);

        public abstract IDataReader FBReports_AFM_Age(DateTime startDate, DateTime endDate, int minAge, int maxAge, int portalId, string serviceLocation);

        public abstract IDataReader FBReports_MapClients(DateTime startDate, DateTime endDate);

        #endregion

    }



}
