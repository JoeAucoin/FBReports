<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HouseholdTotal_Report.ascx.cs" Inherits="GIBS.Modules.FBReports.HouseholdTotal_Report" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnCssInclude ID="DnnCssInclude1" runat="server" FilePath="~/DesktopModules/GIBS/FBReports/Style.css" />
<dnn:DnnCssInclude ID="DnnCssInclude2" runat="server" FilePath="https://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/redmond/jquery-ui.css" />

<script type="text/javascript">

    $(function () {
        $("#txtStartDate").datepicker({
            numberOfMonths: 2,
            showButtonPanel: false,
            showCurrentAtPos: 1
        });
        $("#txtEndDate").datepicker({
            numberOfMonths: 2,
            showButtonPanel: false,
            showCurrentAtPos: 1
        });
    });

 </script>

 <div style="position:relative;float:right;padding-right:30px;">
    <asp:Button ID="btnRunReport" runat="server" ResourceKey="btnRunReport" onclick="btnRunReport_Click" CssClass="dnnPrimaryAction" /> 
     
     </div>          



<div class="dnnForm" id="form-demo">
    <fieldset>
        <div class="dnnFormItem">
		<dnn:Label runat="server" ID="lblLocation" ControlName="ddlLocations" ResourceKey="lblLocation" />
		<asp:DropDownList ID="ddlLocations" runat="server">
            </asp:DropDownList>
		</div>

		<div class="dnnFormItem">
            <dnn:Label ID="lblStartDate" runat="server" CssClass="dnnFormLabel" AssociatedControlID="txtStartDate" Text="Start Date" />
            <asp:TextBox ID="txtStartDate" runat="server" ClientIDMode="Static" /><asp:RequiredFieldValidator runat="server" id="reqStartDate" controltovalidate="txtStartDate" ResourceKey="RequiredStartDate" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label ID="lblEndDate" runat="server" CssClass="dnnFormLabel" AssociatedControlID="txtEndDate" Text="Start Date" />
            <asp:TextBox ID="txtEndDate" runat="server" ClientIDMode="Static" /><asp:RequiredFieldValidator runat="server" id="reqEndDate" controltovalidate="txtEndDate" ResourceKey="RequiredEndDate" />
        </div>
		<div class="dnnFormItem">
		<dnn:Label runat="server" ID="lblTHH" ControlName="ddlTHH" ResourceKey="lblTHH" />
		<asp:DropDownList ID="ddlTHH" runat="server">
            <asp:ListItem Text="1 or More" Value="1"></asp:ListItem>
            <asp:ListItem Text="2 or More" Value="2"></asp:ListItem>
            <asp:ListItem Text="3 or More" Value="3" Selected="True"></asp:ListItem>
            <asp:ListItem Text="4 or More" Value="4"></asp:ListItem>
            <asp:ListItem Text="5 or More" Value="5"></asp:ListItem>
            <asp:ListItem Text="6 or More" Value="6"></asp:ListItem>
            </asp:DropDownList>
		</div>		
    </fieldset>
</div>	

   




<asp:GridView ID="gv_ClientDetails" runat="server"          
    AutoGenerateColumns="False" CssClass="mGridFlex"  
    resourcekey="gv_ClientDetails" EnableViewState="False" DataKeyNames="ClientID" OnSorting="gv_ClientDetails_Sorting" >
<AlternatingRowStyle CssClass="alt" />    
<PagerStyle CssClass="pgr" />  
<PagerSettings Mode="NumericFirstLast" /> 
    <Columns>

      
      
       <asp:BoundField HeaderText="Client Name" DataField="ClientFullName" SortExpression="ClientFullName" ItemStyle-VerticalAlign="Top" ></asp:BoundField>
        <asp:BoundField HeaderText="Age" Visible="False" DataField="ClientAge" SortExpression="ClientAge" ItemStyle-VerticalAlign="Top" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
		
        <asp:BoundField HeaderText="Town" Visible="False" DataField="ClientCity" SortExpression="ClientCity" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
        <asp:BoundField HeaderText="Village" DataField="ClientTown" SortExpression="ClientTown" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
		<asp:BoundField HeaderText="Entry Date" Visible="False" DataField="CreatedOnDate" DataFormatString="{0:MM/dd/yyyy}"  SortExpression="ClientTown" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
		
		<asp:BoundField HeaderText="ClientID" DataField="ClientID" SortExpression="ClientID" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ></asp:BoundField>

        <asp:BoundField HeaderText="AFM Adults" DataField="AFM_Adults" SortExpression="AFM_Adults" ItemStyle-VerticalAlign="Top" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField HeaderText="AFM Children" DataField="AFM_Children" SortExpression="AFM_Children" ItemStyle-VerticalAlign="Top" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField HeaderText="AFM 65Plus" DataField="AFM_65Plus" SortExpression="AFM_65Plus" ItemStyle-VerticalAlign="Top" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField HeaderText="AFM NoDOB" DataField="AFM_NoDOB" SortExpression="AFM_NoDOB" ItemStyle-VerticalAlign="Top" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>


		<asp:BoundField HeaderText="Household Total" DataField="HouseholdTotal" SortExpression="HouseholdTotal" HtmlEncode="False" ItemStyle-VerticalAlign="Top" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        
    </Columns>
</asp:GridView>	