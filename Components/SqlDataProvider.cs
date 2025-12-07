using System;
using System.Data;
using DotNetNuke.Framework.Providers;
using Microsoft.ApplicationBlocks.Data;

namespace GIBS.FBReports.Components
{
    public class SqlDataProvider : DataProvider
    {


        #region vars

        private const string providerType = "data";
        private const string moduleQualifier = "GIBS_";

        private ProviderConfiguration providerConfiguration = ProviderConfiguration.GetProviderConfiguration(providerType);
        private string connectionString;
        private string providerPath;
        private string objectQualifier;
        private string databaseOwner;

        #endregion

        #region cstor

        /// <summary>
        /// cstor used to create the sqlProvider with required parameters from the configuration
        /// section of web.config file
        /// </summary>
        public SqlDataProvider()
        {
            Provider provider = (Provider)providerConfiguration.Providers[providerConfiguration.DefaultProvider];
            connectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString();

            if (connectionString == string.Empty)
                connectionString = provider.Attributes["connectionString"];

            providerPath = provider.Attributes["providerPath"];

            objectQualifier = provider.Attributes["objectQualifier"];
            if (objectQualifier != string.Empty && !objectQualifier.EndsWith("_"))
                objectQualifier += "_";

            databaseOwner = provider.Attributes["databaseOwner"];
            if (databaseOwner != string.Empty && !databaseOwner.EndsWith("."))
                databaseOwner += ".";
        }

        #endregion

        #region properties

        public string ConnectionString
        {
            get { return connectionString; }
        }


        public string ProviderPath
        {
            get { return providerPath; }
        }

        public string ObjectQualifier
        {
            get { return objectQualifier; }
        }


        public string DatabaseOwner
        {
            get { return databaseOwner; }
        }

        #endregion

        #region private methods

        private string GetFullyQualifiedName(string name)
        {
            return DatabaseOwner + ObjectQualifier + moduleQualifier + name;
        }

        private object GetNull(object field)
        {
            return DotNetNuke.Common.Utilities.Null.GetNull(field, DBNull.Value);
        }

        #endregion

        #region override methods

        public override IDataReader FBReports_GetFoodOrderMenu()
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("FBReports_GetFoodOrderMenu"));
        }

        //FBReports_New_Clients_Report_THH
        public override IDataReader FBReports_New_Clients_Report_THH(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("FBReports_New_Clients_Report_THH"), startDate, endDate, portalId, serviceLocation);
        }


        public override IDataReader FBReports_THH_Served(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("FBReports_THH_Served"), startDate, endDate, portalId, serviceLocation);
        }


        public override IDataReader FBReports_Age_Groups_AFM(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("FBReports_Age_Groups_AFM"), startDate, endDate, portalId, serviceLocation);
        }

        public override IDataReader FBReports_Age_Groups_Clients(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("FBReports_Age_Groups_Clients"), startDate, endDate, portalId, serviceLocation);
        }

        //FBReports_Age_Groups_Clients
        //FBReports_Client_Visit_Details

        public override IDataReader FBReports_Client_Visit_Details(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("FBReports_Client_Visit_Details"), startDate, endDate, portalId, serviceLocation);
        }

        public override IDataReader FBReports_New_Clients_Report(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("FBReports_New_Clients_Report"), startDate, endDate, portalId, serviceLocation);
        }
        public override IDataReader FBReports_New_Clients_Age_Groups_AFM(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("FBReports_New_Clients_Age_Groups_AFM"), startDate, endDate, portalId, serviceLocation);
        }

        public override IDataReader FBReports_New_Clients_Age_Groups_Clients(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("FBReports_New_Clients_Age_Groups_Clients"), startDate, endDate, portalId, serviceLocation);
        }



        public override IDataReader FBReports_Distinct_Clients_By_City(DateTime startDate, DateTime endDate, int portalId, string serviceLocation)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("FBReports_Distinct_Clients_By_City"), startDate, endDate, portalId, serviceLocation);
        }

        public override IDataReader FBReports_HouseholdTotal_Report(DateTime startDate, DateTime endDate, int numberInFamily, int portalId)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("FBReports_HouseholdTotal_Report"), startDate, endDate, numberInFamily, portalId);
        }

        public override IDataReader FBReports_AFM_Age(DateTime startDate, DateTime endDate, int minAge, int maxAge, int portalId, string serviceLocation)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("FBReports_AFM_Age"), startDate, endDate, minAge, maxAge, portalId, serviceLocation);
        }

        public override IDataReader FBReports_MapClients(DateTime startDate, DateTime endDate)
        {
            return (IDataReader)SqlHelper.ExecuteReader(connectionString, GetFullyQualifiedName("FBReports_MapClients"), startDate, endDate);
        }

        #endregion
    }
}
