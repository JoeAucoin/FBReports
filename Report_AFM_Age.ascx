<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Report_AFM_Age.ascx.cs" Inherits="GIBS.Modules.FBReports.Report_AFM_Age" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>



<dnn:DnnCssInclude ID="DnnCssInclude2" runat="server" FilePath="https://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/redmond/jquery-ui.css" />
<dnn:DnnCssInclude ID="DnnCssInclude1" runat="server" FilePath="~/DesktopModules/GIBS/FBReports/Style.css" />



<script language="javascript" type="text/javascript">

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



    function open_in_new_tab(url) {
     //   alert(url);
        var win = window.open(url, '_blank');
        win.focus();
   //     window.open(url, '_blank');
        return false;
    }

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
		<dnn:Label runat="server" ID="lblMinAge" ControlName="ddlMinAge" ResourceKey="lblMinAge" />
		<asp:DropDownList ID="ddlMinAge" runat="server">
        <asp:ListItem Text="< 1" Value="0"></asp:ListItem>
            </asp:DropDownList>
		</div>	
		<div class="dnnFormItem">
		<dnn:Label runat="server" ID="lblMaxAge" ControlName="ddlMaxAge" ResourceKey="lblMaxAge" />
		<asp:DropDownList ID="ddlMaxAge" runat="server">
            </asp:DropDownList>
		</div>		
    </fieldset>
</div>

   <h2>
<asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</h2>



<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ClientID">

<HeaderStyle CssClass="dnnGridHeader" HorizontalAlign="Center" />
    
    <RowStyle CssClass="dnnGridItem" />
    <AlternatingRowStyle CssClass="dnnGridAltItem" />
    <FooterStyle CssClass="dnnGridFooter" />
    <Columns>


<asp:TemplateField HeaderText="Client" >
        <ItemTemplate>
           <asp:Label ID="lblName" runat="server" Text='<%# Eval("ClientFirstName") +" "+ Eval("ClientLastName")%>' ></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>

<asp:TemplateField HeaderText="Household Member" >
        <ItemTemplate>
           <asp:Label ID="lblHouseholdName" runat="server" Text='<%# Eval("ClAddFamMemFirstName") +" "+ Eval("ClAddFamMemLastName")%>' ></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
     

        <asp:BoundField DataField="AFMGender" HeaderText="Gender"  FooterText=" " HeaderStyle-Width="50px" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField DataField="ClAddFamMemDOB" HeaderText="DOB" DataFormatString="{0:MM/dd/yyyy}" HeaderStyle-Width="60px" ItemStyle-Width="60px"  ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField DataField="AFM_Age" HeaderText="Age" HeaderStyle-Width="40px" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField DataField="AFMDOBVerify" HeaderText="Verified"  FooterText=" " HeaderStyle-Width="50px" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField DataField="ClientTown" HeaderText="Village"  />
        <asp:BoundField DataField="ClientID" HeaderText="ClientID" ItemStyle-Width="60px" HeaderStyle-Width="60px" />
 
    </Columns>

</asp:GridView>



