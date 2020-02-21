using System;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace GIBS.FBReports.Components
{
    public class FBReportsInfo
    {
        
        // REPORT SPECIFIC
        private int tHH_Served;
        private int householdTotal;
        private int client_AgeGroupSum;
        private string client_AgeGroup;
        private int aFM_AgeGroupSum;
        private string aFM_AgeGroup;

        private int aFM_Adults;
        private int aFM_65Plus;
        private int aFM_Children;
        private int aFM_NoDOB;

        private int clientAdult;
        private int client65Plus;
        private int clientChild;
        private int clientNoDOB;

        private DateTime startDate;
        private DateTime endDate;
        private int numberInFamily;

        private string serviceLocation;
        
        //private vars exposed thro the
        //properties
        //COMMON
        private int moduleId;
        private int portalId;
        private int createdByUserID;
        private DateTime createdOnDate;
        private int lastModifiedByUserID;
        private DateTime lastModifiedOnDate;
        private string createdByUserName = null;
        private string lastModifiedByUserName = null;

        //CLIENTS
        private int clientID;
        private string clientFirstName;
        private string clientMiddleInitial;
        private string clientLastName;
        private string clientFullName;
        private string clientSuffix;
        private DateTime clientDOB;
        private bool clientDOBVerify;
        private string clientAddress;
        private string clientCity;
        private string clientTown;
        private string clientState;
        private string clientZipCode;
        private string clientEmailAddress;
        private string clientIdCard;
        private string clientPhone;
        private string clientPhoneType;
        private int clientCaseWorker;
        private string caseWorkerName;
        private int clientAge;
        private DateTime lastVisitDate;
        private int aFMCount;
        private double latitude;
        private double longitude;
        private string clientPhoto;
        private string clientEthnicity;
        private string clientNote;
        private string clientUnit;

        // CLIENT ADDITIONAL FAMILY MEMBERS
        private int clAddFamMemID;
        private string clAddFamMemFirstName;
        private string clAddFamMemLastName;
        private DateTime clAddFamMemDOB;
        private int aFM_Age;
        private string aFMRelationship;
        private string aFMMiddleInitial;
        private string aFMSuffix;
        private bool aFMDOBVerify;
        private string aFMEthnicity;
        private string aFMGender;


        // CLIENT INCOME/EXPENSE
        private int ieID;
        private string ieType;
        private string ieDescription;
        private double ieAmount;



        // CLIENT VISITS
        private int visitID;
        private DateTime visitDate;
        private string visitNotes;
        private int visitNumBags;

        // CLIENT TrueFalseQuestions
        private int tfID;
        private string tfQuestion;
        private bool tfAnswer;


        /// <summary>
        /// empty cstor
        /// </summary>
        public FBReportsInfo()
        {
        }


        #region properties

        //ServiceLocation
        public string ServiceLocation
        {
            get { return serviceLocation; }
            set { serviceLocation = value; }
        }


        public int THH_Served
        {
            get { return tHH_Served; }
            set { tHH_Served = value; }
        }

        public int Client_AgeGroupSum
        {
            get { return client_AgeGroupSum; }
            set { client_AgeGroupSum = value; }
        }

        public string Client_AgeGroup
        {
            get { return client_AgeGroup; }
            set { client_AgeGroup = value; }
        }

        public int AFM_AgeGroupSum
        {
            get { return aFM_AgeGroupSum; }
            set { aFM_AgeGroupSum = value; }
        }

        public string AFM_AgeGroup
        {
            get { return aFM_AgeGroup; }
            set { aFM_AgeGroup = value; }
        }

        public int AFM_Adults
        {
            get { return aFM_Adults; }
            set { aFM_Adults = value; }
        }

        public int AFM_65Plus
        {
            get { return aFM_65Plus; }
            set { aFM_65Plus = value; }
        }

        public int AFM_Children
        {
            get { return aFM_Children; }
            set { aFM_Children = value; }
        }

        public int AFM_NoDOB
        {
            get { return aFM_NoDOB; }
            set { aFM_NoDOB = value; }
        }

        public int ClientAdult
        {
            get { return clientAdult; }
            set { clientAdult = value; }
        }

        public int Client65Plus
        {
            get { return client65Plus; }
            set { client65Plus = value; }
        }

        public int ClientChild
        {
            get { return clientChild; }
            set { clientChild = value; }
        }

        public int ClientNoDOB
        {
            get { return clientNoDOB; }
            set { clientNoDOB = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public int NumberInFamily
        {
            get { return numberInFamily; }
            set { numberInFamily = value; }
        }

        //householdTotal
        //HouseholdTotal

        public int HouseholdTotal
        {
            get { return householdTotal; }
            set { householdTotal = value; }
        }



        #region IncomeExpense

        public int IeID
        {
            get { return ieID; }
            set { ieID = value; }
        }

        public string IeType
        {
            get { return ieType; }
            set { ieType = value; }
        }

        public string IeDescription
        {
            get { return ieDescription; }
            set { ieDescription = value; }
        }

        public double IeAmount
        {
            get { return ieAmount; }
            set { ieAmount = value; }
        }

        #endregion


        // CLIENTS
        #region clients
        public int ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }

        public string ClientFirstName
        {
            get { return clientFirstName; }
            set { clientFirstName = value; }
        }

        public string ClientMiddleInitial
        {
            get { return clientMiddleInitial; }
            set { clientMiddleInitial = value; }
        }

        public string ClientLastName
        {
            get { return clientLastName; }
            set { clientLastName = value; }
        }

        public string ClientFullName
        {
            get { return clientFullName; }
            set { clientFullName = value; }
        }

        public string ClientSuffix
        {
            get { return clientSuffix; }
            set { clientSuffix = value; }

        }

        public DateTime ClientDOB
        {
            get { return clientDOB; }
            set { clientDOB = value; }
        }

        public bool ClientDOBVerify
        {
            get { return clientDOBVerify; }
            set { clientDOBVerify = value; }

        }

        public string ClientAddress
        {
            get { return clientAddress; }
            set { clientAddress = value; }
        }

        public string ClientCity
        {
            get { return clientCity; }
            set { clientCity = value; }
        }

        public string ClientTown
        {
            get { return clientTown; }
            set { clientTown = value; }
        }

        public string ClientState
        {
            get { return clientState; }
            set { clientState = value; }
        }

        public string ClientZipCode
        {
            get { return clientZipCode; }
            set { clientZipCode = value; }
        }

        public string ClientEmailAddress
        {
            get { return clientEmailAddress; }
            set { clientEmailAddress = value; }
        }

        public string ClientIdCard
        {
            get { return clientIdCard; }
            set { clientIdCard = value; }
        }

        public string ClientPhone
        {
            get { return clientPhone; }
            set { clientPhone = value; }
        }

        public string ClientPhoneType
        {
            get { return clientPhoneType; }
            set { clientPhoneType = value; }
        }

        public int ClientCaseWorker
        {
            get { return clientCaseWorker; }
            set { clientCaseWorker = value; }
        }

        public string CaseWorkerName
        {
            get { return caseWorkerName; }
            set { caseWorkerName = value; }
        }

        public int ClientAge
        {
            get { return clientAge; }
            set { clientAge = value; }
        }

        public DateTime LastVisitDate
        {
            get { return lastVisitDate; }
            set { lastVisitDate = value; }
        }

        public int AFMCount
        {
            get { return aFMCount; }
            set { aFMCount = value; }
        }

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public string ClientPhoto
        {
            get { return clientPhoto; }
            set { clientPhoto = value; }
        }

        public string ClientEthnicity
        {
            get { return clientEthnicity; }
            set { clientEthnicity = value; }
        }
        public string ClientNote
        {
            get { return clientNote; }
            set { clientNote = value; }
        }

        public string ClientUnit
        {
            get { return clientUnit; }
            set { clientUnit = value; }
        }

        #endregion

        // CLIENT ADDITIONAL FAMILY MEMBERS
        #region Clients AFM

        public int ClAddFamMemID
        {
            get { return clAddFamMemID; }
            set { clAddFamMemID = value; }
        }

        public string ClAddFamMemFirstName
        {
            get { return clAddFamMemFirstName; }
            set { clAddFamMemFirstName = value; }
        }

        public string ClAddFamMemLastName
        {
            get { return clAddFamMemLastName; }
            set { clAddFamMemLastName = value; }
        }

        public DateTime ClAddFamMemDOB
        {
            get { return clAddFamMemDOB; }
            set { clAddFamMemDOB = value; }
        }

        public int AFM_Age
        {
            get { return aFM_Age; }
            set { aFM_Age = value; }
        }

        public string AFMRelationship
        {
            get { return aFMRelationship; }
            set { aFMRelationship = value; }
        }

        public string AFMMiddleInitial
        {
            get { return aFMMiddleInitial; }
            set { aFMMiddleInitial = value; }
        }

        public string AFMSuffix
        {
            get { return aFMSuffix; }
            set { aFMSuffix = value; }
        }

        public bool AFMDOBVerify
        {
            get { return aFMDOBVerify; }
            set { aFMDOBVerify = value; }

        }

        public string AFMEthnicity
        {
            get { return aFMEthnicity; }
            set { aFMEthnicity = value; }
        }

        public string AFMGender
        {
            get { return aFMGender; }
            set { aFMGender = value; }
        }

        #endregion

        // CLIENT VISITS
        #region ClientVisits
        public int VisitID
        {
            get { return visitID; }
            set { visitID = value; }
        }

        public DateTime VisitDate
        {
            get { return visitDate; }
            set { visitDate = value; }
        }

        public string VisitNotes
        {
            get { return visitNotes; }
            set { visitNotes = value; }
        }

        public int VisitNumBags
        {
            get { return visitNumBags; }
            set { visitNumBags = value; }
        }

        #endregion


        // CLIENT TrueFalseQuestions
        public int TfID
        {
            get { return tfID; }
            set { tfID = value; }
        }

        public string TfQuestion
        {
            get { return tfQuestion; }
            set { tfQuestion = value; }
        }

        public bool TfAnswer
        {
            get { return tfAnswer; }
            set { tfAnswer = value; }

        }



        // COMMON
        #region Common
        public int ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
        }

        public int PortalId
        {
            get { return portalId; }
            set { portalId = value; }
        }

        public int CreatedByUserID
        {
            get { return createdByUserID; }
            set { createdByUserID = value; }
        }

        public DateTime CreatedOnDate
        {
            get { return createdOnDate; }
            set { createdOnDate = value; }
        }

        public int LastModifiedByUserID
        {
            get { return lastModifiedByUserID; }
            set { lastModifiedByUserID = value; }
        }

        public DateTime LastModifiedOnDate
        {
            get { return lastModifiedOnDate; }
            set { lastModifiedOnDate = value; }
        }

        public string LastModifiedByUserName
        {

            get { return lastModifiedByUserName; }
            set { lastModifiedByUserName = value; }

        }

        public string CreatedByUserName
        {
            get
            {

                if (createdByUserName == null)
                {
                    int portalId = PortalController.Instance.GetCurrentPortalSettings().PortalId;
                    UserController controller = new UserController();
                    UserInfo user = controller.GetUser(portalId, createdByUserID);
                    createdByUserName = user.DisplayName;
                }
                return createdByUserName;
            }
        }


        #endregion



        #endregion
    }
}
