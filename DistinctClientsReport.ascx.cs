using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Configuration;
using System.Linq;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

using GIBS.FBReports.Components;
using DotNetNuke.Common;
using System.Drawing;
using System.IO;
using System.Web.UI.HtmlControls;
using Excel = Microsoft.Office.Interop.Excel;
using GIBS.Modules.FBReports.Components;
using System.Web;
using System.Data;
//using ClosedXML.Excel;

//using iTextSharp;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.xml;
//using iTextSharp.text.html;
//using iTextSharp.text.html.simpleparser;
using System.Text;

using DotNetNuke.Common.Controls;
using DotNetNuke.Common.Lists;
using DotNetNuke.Framework.JavaScriptLibraries;







namespace GIBS.Modules.FBReports
{
    public partial class DistinctClientsReport : PortalModuleBase, IActionable
    {
     
        private GridViewHelper helper;
        // To show custom operations...
        private List<int> mQuantities = new List<int>();


        static int myModID = 0;
        static int myTabID = 0;
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            try
            {
               

                if (!IsPostBack)
                {
                    GetSettings();
                    FillLocationsDropdown();
                    txtEndDate.Text = DateTime.Now.ToShortDateString();
                    txtStartDate.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
                    // RUN REPORT
                    //GetTotalInHouseholdServed();
                    //Fill_Age_Groups_AFM();
                    //Fill_Age_Groups_Clients();
                    GroupIt();
                    Fill_ClientsDetails();
                    //  txtEndDate.Text = 
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
               
                GroupIt();
                Fill_ClientsDetails();
                
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }



        public void Fill_ClientsDetails()
        {

            try
            {

                DateTime _startDate = DateTime.Parse(txtStartDate.Text.ToString());
                DateTime _endDate = DateTime.Parse(txtEndDate.Text.ToString());
                
                List<FBReportsInfo> items;
                FBReportsController controller = new FBReportsController();

                items = controller.FBReports_Distinct_Clients_By_City(_startDate, _endDate, this.PortalId, ddlLocations.SelectedValue.ToString());

                gv_ClientDetails.DataSource = items;
                gv_ClientDetails.DataBind();

                

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }



     

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

        public void GroupIt()
        {

            try
            {
              //  this.gv_ClientDetails.DataSource = null;
                this.gv_ClientDetails.Columns[0].Visible = true;
                this.gv_ClientDetails.Columns[1].Visible = true;
                this.gv_ClientDetails.Columns[2].Visible = true;
                this.gv_ClientDetails.Columns[3].Visible = true;
                this.gv_ClientDetails.Columns[4].Visible = true;



                helper = new GridViewHelper(this.gv_ClientDetails);
               

              //  helper.HideColumnsWithoutGroupSummary

                if (rblReportType.SelectedValue.ToString() == "Detail")
                {
                    helper.RegisterGroup("ClientCity", true, true);
           //         helper.RegisterGroup("CLIENT_AgeGroup", true, true);
                }
                else
                {
                    helper.SetSuppressGroup("ClientCity");
                    
                    
                }

                
                helper.RegisterSummary("HouseholdTotal", SummaryOperation.Sum, "ClientCity");

         //       helper.RegisterSummary("CLIENT_AgeGroup", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("ClientAdult", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("Client65Plus", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("ClientChild", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("ClientNoDOB", SummaryOperation.Sum, "ClientCity");

                helper.RegisterSummary("AFM_Adults", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("AFM_65Plus", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("AFM_Children", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("AFM_NoDOB", SummaryOperation.Sum, "ClientCity");
                helper.RegisterSummary("ClientID", SummaryOperation.Count, "ClientCity");

                
                helper.RegisterSummary("HouseholdTotal", SummaryOperation.Sum);

                helper.RegisterSummary("ClientAdult", SummaryOperation.Sum);
                helper.RegisterSummary("Client65Plus", SummaryOperation.Sum);
                helper.RegisterSummary("ClientChild", SummaryOperation.Sum);
                helper.RegisterSummary("ClientNoDOB", SummaryOperation.Sum);

                helper.RegisterSummary("AFM_Adults", SummaryOperation.Sum);
                helper.RegisterSummary("AFM_65Plus", SummaryOperation.Sum);
                helper.RegisterSummary("AFM_Children", SummaryOperation.Sum);
                helper.RegisterSummary("AFM_NoDOB", SummaryOperation.Sum);
                helper.RegisterSummary("ClientID", SummaryOperation.Count);


                // helper.RegisterGroup("ClientZipCode", true, true);
                helper.GroupHeader += new GroupEvent(helper_GroupHeader);
                helper.GroupSummary += new GroupEvent(helper_Bug);
                
                
                if (rblReportType.SelectedValue.ToString() == "Summary")
                {
                    helper.SetInvisibleColumnsWithoutGroupSummary();
                }
                else
                {
                // DO NOTHING
                    //helper.HideColumnsWithoutGroupSummary();
                    
                }
                
                helper.ApplyGroupSort();


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void gv_ClientDetails_Sorting(object sender, GridViewSortEventArgs e)
        {
            //gv_ClientDetails.DataSource = // Call to your data-binding routine
            //gv_ClientDetails.DataBind();
        }

        private void helper_ManualSummary(GridViewRow row)
        {
            GridViewRow newRow = helper.InsertGridRow(row);
            newRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            newRow.Cells[0].Text = String.Format("Total: {0} items, ", helper.GeneralSummaries["ClientCity"].Value, helper.GeneralSummaries["HouseholdTotal"].Value);
        }

        private void helper_GroupSummary(string groupName, object[] values, GridViewRow row)
        {
            row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            row.Cells[0].Text = "Média";
        }

        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == "ClientCity")
            {
                row.BackColor = Color.LightGray;
                row.Cells[0].Text = "&nbsp;&nbsp;<b>" + row.Cells[0].Text + "</b>";
                
            }
        }

        private void SaveQuantity(string column, string group, object value)
        {
            mQuantities.Add(Convert.ToInt32(value));
        }

        private object GetMinQuantity(string column, string group)
        {
            int[] qArray = new int[mQuantities.Count];
            mQuantities.CopyTo(qArray);
            Array.Sort(qArray);
            return qArray[0];
        }

        private void helper_Bug(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == null) return;

            row.BackColor = Color.LightCyan;
            row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            row.Cells[0].Text = values[0] + " TOTALS&nbsp;";
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

        //gv_ClientDetails



        //protected void ExportToPDF1(GridView gvReport, bool LandScape)
        //{
        //    int noOfColumns = 0, noOfRows = 0;
        //    DataTable tbl = null;

        //    if (gvReport.AutoGenerateColumns)
        //    {
        //        tbl = gvReport.DataSource as DataTable; // Gets the DataSource of the GridView Control.
        //        noOfColumns = tbl.Columns.Count;
        //        noOfRows = tbl.Rows.Count;
        //    }
        //    else
        //    {
        //        noOfColumns = gvReport.Columns.Count;
        //        noOfRows = gvReport.Rows.Count;
        //    }

        //    float HeaderTextSize = 8;
        //    float ReportNameSize = 10;
        //    float ReportTextSize = 8;
        //    float ApplicationNameSize = 7;

        //    // Creates a PDF document

        //    Document document = null;
        //    if (LandScape == true)
        //    {
        //        // Sets the document to A4 size and rotates it so that the     orientation of the page is Landscape.
        //        document = new Document(PageSize.A4.Rotate(), 0, 0, 15, 5);
        //    }
        //    else
        //    {
        //        document = new Document(PageSize.A4, 0, 0, 15, 5);
        //    }

        //    // Creates a PdfPTable with column count of the table equal to no of columns of the gridview or gridview datasource.
        //    iTextSharp.text.pdf.PdfPTable mainTable = new iTextSharp.text.pdf.PdfPTable(noOfColumns);

        //    // Sets the first 4 rows of the table as the header rows which will be repeated in all the pages.
        //    mainTable.HeaderRows = 4;

        //    // Creates a PdfPTable with 2 columns to hold the header in the exported PDF.
        //    iTextSharp.text.pdf.PdfPTable headerTable = new iTextSharp.text.pdf.PdfPTable(2);

        //    // Creates a phrase to hold the application name at the left hand side of the header.
        //    Phrase phApplicationName = new Phrase("Sample Application", FontFactory.GetFont("Arial", ApplicationNameSize, iTextSharp.text.Font.NORMAL));

        //    // Creates a PdfPCell which accepts a phrase as a parameter.
        //    PdfPCell clApplicationName = new PdfPCell(phApplicationName);
        //    // Sets the border of the cell to zero.
        //    clApplicationName.Border = PdfPCell.NO_BORDER;
        //    // Sets the Horizontal Alignment of the PdfPCell to left.
        //    clApplicationName.HorizontalAlignment = Element.ALIGN_LEFT;

        //    // Creates a phrase to show the current date at the right hand side of the header.
        //    Phrase phDate = new Phrase(DateTime.Now.Date.ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", ApplicationNameSize, iTextSharp.text.Font.NORMAL));

        //    // Creates a PdfPCell which accepts the date phrase as a parameter.
        //    PdfPCell clDate = new PdfPCell(phDate);
        //    // Sets the Horizontal Alignment of the PdfPCell to right.
        //    clDate.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    // Sets the border of the cell to zero.
        //    clDate.Border = PdfPCell.NO_BORDER;

        //    // Adds the cell which holds the application name to the headerTable.
        //    headerTable.AddCell(clApplicationName);
        //    // Adds the cell which holds the date to the headerTable.
        //    headerTable.AddCell(clDate);
        //    // Sets the border of the headerTable to zero.
        //    headerTable.DefaultCell.Border = PdfPCell.NO_BORDER;

        //    // Creates a PdfPCell that accepts the headerTable as a parameter and then adds that cell to the main PdfPTable.
        //    PdfPCell cellHeader = new PdfPCell(headerTable);
        //    cellHeader.Border = PdfPCell.NO_BORDER;
        //    // Sets the column span of the header cell to noOfColumns.
        //    cellHeader.Colspan = noOfColumns;
        //    // Adds the above header cell to the table.
        //    mainTable.AddCell(cellHeader);

        //    // Creates a phrase which holds the file name.
        //    Phrase phHeader = new Phrase("Sample Export", FontFactory.GetFont("Arial", ReportNameSize, iTextSharp.text.Font.BOLD));
        //    PdfPCell clHeader = new PdfPCell(phHeader);
        //    clHeader.Colspan = noOfColumns;
        //    clHeader.Border = PdfPCell.NO_BORDER;
        //    clHeader.HorizontalAlignment = Element.ALIGN_CENTER;
        //    mainTable.AddCell(clHeader);

        //    // Creates a phrase for a new line.
        //    Phrase phSpace = new Phrase("\n");
        //    PdfPCell clSpace = new PdfPCell(phSpace);
        //    clSpace.Border = PdfPCell.NO_BORDER;
        //    clSpace.Colspan = noOfColumns;
        //    mainTable.AddCell(clSpace);

        //    // Sets the gridview column names as table headers.
        //    for (int i = 0; i < noOfColumns; i++)
        //    {
        //        Phrase ph = null;

        //        if (gvReport.AutoGenerateColumns)
        //        {
        //            ph = new Phrase(tbl.Columns[i].ColumnName, FontFactory.GetFont("Arial", HeaderTextSize, iTextSharp.text.Font.BOLD));
        //        }
        //        else
        //        {
        //            ph = new Phrase(gvReport.Columns[i].HeaderText, FontFactory.GetFont("Arial", HeaderTextSize, iTextSharp.text.Font.BOLD));
        //        }

        //        mainTable.AddCell(ph);
        //    }

        //    // Reads the gridview rows and adds them to the mainTable
        //    for (int rowNo = 0; rowNo < noOfRows; rowNo++)
        //    {
        //        for (int columnNo = 0; columnNo < noOfColumns; columnNo++)
        //        {
        //            if (gvReport.AutoGenerateColumns)
        //            {
        //                string s = gvReport.Rows[rowNo].Cells[columnNo].Text.Trim();
        //                Phrase ph = new Phrase(s, FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL));
        //                mainTable.AddCell(ph);
        //            }
        //            else
        //            {
        //                if (gvReport.Columns[columnNo] is TemplateField)
        //                {
        //                    DataBoundLiteralControl lc = gvReport.Rows[rowNo].Cells[columnNo].Controls[0] as DataBoundLiteralControl;
        //                    string s = lc.Text.Trim();
        //                    Phrase ph = new Phrase(s, FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL));
        //                    mainTable.AddCell(ph);
        //                }
        //                else
        //                {
        //                    string s = gvReport.Rows[rowNo].Cells[columnNo].Text.Trim();
        //                    Phrase ph = new Phrase(s, FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL));
        //                    mainTable.AddCell(ph);
        //                }
        //            }
        //        }

        //        // Tells the mainTable to complete the row even if any cell is left incomplete.
        //        mainTable.CompleteRow();
        //    }

        //    // Gets the instance of the document created and writes it to the output stream of the Response object.
        //    PdfWriter.GetInstance(document, Response.OutputStream);

        //    // Creates a footer for the PDF document.
        // //   iTextSharp.text.html.HtmlUtilities.
        //    //HeaderFooter pdfFooter = new HeaderFooter(new Phrase(), true);
        //    //pdfFooter.Alignment = Element.ALIGN_CENTER;
        //    //pdfFooter.Border = iTextSharp.text.Rectangle.NO_BORDER;

        //    //// Sets the document footer to pdfFooter.
        //    //document.Footer = pdfFooter;
        //    // Opens the document.
        //    document.Open();
        //    // Adds the mainTable to the document.
        //    document.Add(mainTable);
        //    // Closes the document.
        //    document.Close();

        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment; filename=SampleExport.pdf");
        //    Response.End();
        //}







        //public void ExporttoExcel()
        //{

        //    Response.Clear();

        //    Response.AddHeader("content-disposition", "attachment;filename=MyFile.xls");

        //    Response.Charset = "";

        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //    Response.ContentType = "application/vnd.xls";


        //    System.IO.StringWriter stringWrite = new System.IO.StringWriter();


        //    HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        //    gv_ClientDetails.RenderControl(htmlWrite);

        //    Response.Write(stringWrite.ToString());

        //    Response.End();

        // //   Response.Redirect(NavigateURL(), true);


        //}

     

    }
}