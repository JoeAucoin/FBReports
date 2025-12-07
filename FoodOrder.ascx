<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FoodOrder.ascx.cs" Inherits="GIBS.Modules.FBReports.FoodOrder" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>
<link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/redmond/jquery-ui.css" />

<p>
    <asp:Label ID="LabelRecordCount" runat="server" Text="LabelRecordCount"></asp:Label>
</p>

<asp:GridView ID="GridViewOrderSheet" runat="server" HorizontalAlign="Center" OnSorting="GridViewOrderSheet_Sorting"
    AutoGenerateColumns="False" OnRowDataBound="GridViewOrderSheet_RowDataBound" CssClass="table table-striped">
     <Columns>
        
         <asp:BoundField HeaderText="Category" DataField="ProductCategory" Visible="true" HeaderStyle-Font-Bold="true"></asp:BoundField>
        <asp:BoundField HeaderText="Product" DataField="ProductName" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true"></asp:BoundField>
        <asp:BoundField HeaderText="Limit" DataField="Limit" ItemStyle-VerticalAlign="Top" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Order" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Bold="true">                     
            <ItemTemplate>
                <asp:HiddenField ID="HiddenFieldProductID" Value='<%# Eval("ProductID") %>' runat="server" />
                <asp:DropDownList ID="DropDownListQty" runat="server"><asp:ListItem Text="---" Value="0" /></asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField HeaderText="ProductID" DataField="ProductID" Visible="false"></asp:BoundField>
     </Columns>

</asp:GridView>