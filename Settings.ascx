<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="GIBS.Modules.FBReports.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table cellspacing="0" cellpadding="2" border="0" summary="ModuleName1 Settings Design Table">

	<tr>
		<td class="SubHead" width="150"><dnn:label id="lblFoodBankClientModuleID" runat="server" suffix=":" controlname="drpModuleID"></dnn:label></td>
		<td valign="bottom">
			<asp:dropdownlist id="drpModuleID" Runat="server" Width="325" datavaluefield="ModuleID" datatextfield="ModuleTitle"
				CssClass="NormalTextBox"></asp:dropdownlist>
		</td>
	</tr>

</table>