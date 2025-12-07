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
    public partial class FoodOrder : PortalModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillOrderGrid();
        }

        public void FillOrderGrid()
        {

            try
            {

                List<FBReportsInfo> items;
                FBReportsController controller = new FBReportsController();
                items = controller.FBReports_GetFoodOrderMenu();
                if (items == null || items.Count == 0)
                {
                  
                }
                else
                {


                    // LabelDebug.Visible = false;
                    LabelRecordCount.Text = items.Count.ToString() + " Items";
                    
                    GridViewOrderSheet.DataSource = items;
                    GridViewOrderSheet.DataBind();
                }


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void GridViewOrderSheet_Sorting(object sender, GridViewSortEventArgs e)
        {

        }




        //  private string previousFirstColumnValue = "";
        Color colorChoice = Color.LightGoldenrodYellow;
        protected void GridViewOrderSheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                // Get the first column value of the current row
                string currentFirstColumnValue = e.Row.Cells[0].Text;

                // Check if it's not the first row
                if (e.Row.RowIndex != 0)
                {
                    // Get the first column value of the previous row
                    string previousFirstColumnValue = GridViewOrderSheet.Rows[e.Row.RowIndex - 1].Cells[0].Text;

                    // Check if the current first column value is different from the previous row's first column value
                    if (currentFirstColumnValue != previousFirstColumnValue)
                    {
                        // If the current row is the start of a new group, alternate between two colors
                        if (colorChoice == Color.LightGoldenrodYellow)
                        {
                            e.Row.Cells[0].BackColor = Color.AliceBlue;
                            colorChoice = Color.AliceBlue;
                        }
                        else
                        {
                            e.Row.Cells[0].BackColor = Color.LightGoldenrodYellow;
                            colorChoice = Color.LightGoldenrodYellow;
                        }
                    }
                    else
                    {
                        // Use the same color as the previous row if the first column value hasn't changed
                        e.Row.Cells[0].BackColor = colorChoice;
                    }
                }
                else
                {
                    // If it's the first row, color the first column cell with the initial color choice
                    e.Row.Cells[0].BackColor = Color.LightGoldenrodYellow;
                    colorChoice = Color.LightGoldenrodYellow;
                }



                int limit = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Limit"));
                DropDownList ddlQty = (DropDownList)e.Row.FindControl("DropDownListQty");

                for (int i = 1; i <= limit; i++)
                {
                    // do stuff
                    ListItem lst = new ListItem(i.ToString(), i.ToString());
                    ddlQty.Items.Add(lst); ;
                }



            }
        }

    }
}