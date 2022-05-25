﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewClientsReport.ascx.cs" Inherits="GIBS.Modules.FBReports.NewClientsReport" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnCssInclude ID="DnnCssInclude1" runat="server" FilePath="~/DesktopModules/GIBS/FBReports/Style.css" />
<dnn:DnnCssInclude ID="DnnCssInclude2" runat="server" FilePath="https://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/redmond/jquery-ui.css" />

<script type="text/javascript">

    $(function () {
        $("#txtStartDate").datepicker({
            numberOfMonths: 2,
            showButtonPanel: false,
            showCurrentAtPos: 0
        });
        $("#txtEndDate").datepicker({
            numberOfMonths: 2,
            showButtonPanel: false,
            showCurrentAtPos: 0
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
		<dnn:Label runat="server" ID="lblReportType" ControlName="rblReportType" ResourceKey="lblReportType" />
		<asp:RadioButtonList ID="rblReportType" runat="server" RepeatDirection="Horizontal" CellPadding="10" CellSpacing="10">
            <asp:ListItem Text="&nbsp;Summary" Value="Summary" Selected="True"></asp:ListItem>
            <asp:ListItem Text="&nbsp;Detail" Value="Detail"></asp:ListItem>
            </asp:RadioButtonList>
		</div>		
    </fieldset>
</div>	

   
<div style="float:left; padding-right:20px;">
<asp:GridView ID="gv_Age_Groups_Clients" runat="server" Width="250px" AutoGenerateColumns="False" CssClass="mGridFlex" resourcekey="gv_Age_Groups_Clients" >
<AlternatingRowStyle CssClass="alt" />    
<PagerStyle CssClass="pgr" />  
<PagerSettings Mode="NumericFirstLast" /> 
    <Columns>
       <asp:BoundField HeaderText="Client Age Group" DataField="Client_AgeGroup" ItemStyle-VerticalAlign="Top" ></asp:BoundField>
        <asp:BoundField HeaderText="Count" DataField="Client_AgeGroupSum" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
    </Columns>
</asp:GridView>	
</div>

<div>
<asp:GridView ID="gv_Age_Groups_AFM" runat="server" Width="250px" AutoGenerateColumns="False" CssClass="mGridFlex" resourcekey="gv_Age_Groups_AFM" >
<AlternatingRowStyle CssClass="alt" />    
<PagerStyle CssClass="pgr" />  
<PagerSettings Mode="NumericFirstLast" /> 
    <Columns>
       <asp:BoundField HeaderText="AFM Age Group" DataField="AFM_AgeGroup" ItemStyle-VerticalAlign="Top" ></asp:BoundField>
        <asp:BoundField HeaderText="Count" DataField="AFM_AgeGroupSum" ItemStyle-VerticalAlign="Top" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
    </Columns>
</asp:GridView>	
</div>
<p><asp:Label ID="lblTHHServed" runat="server" Text="" Visible="false"></asp:Label></p>



<asp:GridView ID="gv_ClientDetails" runat="server"          
    AutoGenerateColumns="False" CssClass="dnnGrid"  
    resourcekey="gv_ClientDetails" EnableViewState="False" DataKeyNames="ClientID" OnSorting="gv_ClientDetails_Sorting" Width="100%" >
    <HeaderStyle CssClass="dnnGridHeader" HorizontalAlign="Center" />
    
    <RowStyle CssClass="dnnGridItem" />
    <AlternatingRowStyle CssClass="dnnGridAltItem" />
    <FooterStyle CssClass="dnnGridFooter" />
    <Columns>

      <asp:BoundField HeaderText="City" DataField="ClientCity" SortExpression="ClientCity" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
      
       <asp:BoundField HeaderText="Client Name" DataField="ClientFullName" SortExpression="ClientFullName" ItemStyle-VerticalAlign="Top" ></asp:BoundField>
        <asp:BoundField HeaderText="Age" Visible="False" DataField="ClientAge" SortExpression="ClientAge" ItemStyle-VerticalAlign="Top" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
		<asp:BoundField HeaderText="Town" DataField="ClientTown" SortExpression="ClientTown" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
		<asp:BoundField HeaderText="Entry Date" DataField="CreatedOnDate" DataFormatString="{0:MM/dd/yyyy}"  SortExpression="ClientTown" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
		
		<asp:BoundField HeaderText="Client" DataField="ClientID" SortExpression="ClientID" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ></asp:BoundField>

 <asp:BoundField HeaderText="Client Adult" DataField="ClientAdult" SortExpression="ClientAdult" ItemStyle-VerticalAlign="Top" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField HeaderText="Client 65Plus" DataField="Client65Plus" SortExpression="Client65Plus" ItemStyle-VerticalAlign="Top" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField HeaderText="Client Child" DataField="ClientChild" SortExpression="ClientChild" ItemStyle-VerticalAlign="Top" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField HeaderText="Client NoDOB" DataField="ClientNoDOB" SortExpression="ClientNoDOB" ItemStyle-VerticalAlign="Top" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>


        <asp:BoundField HeaderText="AFM Adults" DataField="AFM_Adults" SortExpression="AFM_Adults" ItemStyle-VerticalAlign="Top" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField HeaderText="AFM Children" DataField="AFM_Children" SortExpression="AFM_Children" ItemStyle-VerticalAlign="Top" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField HeaderText="AFM 65Plus" DataField="AFM_65Plus" SortExpression="AFM_65Plus" ItemStyle-VerticalAlign="Top" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:BoundField HeaderText="AFM NoDOB" DataField="AFM_NoDOB" SortExpression="AFM_NoDOB" ItemStyle-VerticalAlign="Top" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>


		<asp:BoundField HeaderText="Household Total" DataField="HouseholdTotal" SortExpression="HouseholdTotal" HtmlEncode="False" ItemStyle-VerticalAlign="Top" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        
    </Columns>
</asp:GridView>	