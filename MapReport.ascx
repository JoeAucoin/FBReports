<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MapReport.ascx.cs" Inherits="GIBS.Modules.FBReports.MapReport" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnCssInclude ID="DnnCssInclude2" runat="server" FilePath="https://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/smoothness/jquery-ui.css" />

<asp:Label ID="lblDebug" runat="server" Text=""></asp:Label>

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
            <dnn:Label ID="lblEndDate" runat="server" CssClass="dnnFormLabel" AssociatedControlID="txtEndDate" Text="EnD Date" />
            <asp:TextBox ID="txtEndDate" runat="server" ClientIDMode="Static" /><asp:RequiredFieldValidator runat="server" id="reqEndDate" controltovalidate="txtEndDate" ResourceKey="RequiredEndDate" />
        </div>
	
    </fieldset>
</div>	



<div id="MapDiv" style="width: 100%; height: 500px; border:1px solid black; margin: 0 auto;"></div>

<input type="button" value="Reload markers" id="reloadMarkers">

<script src="https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/markerclusterer.js">
    </script>

<script async defer src='<%=GetGoogleURL() %>' type="text/javascript"></script>                		    
<script type="text/javascript">

    var markers = [<asp:Repeater ID="rptMarkers" runat="server">
            <ItemTemplate>
                {"title": '<%# Eval("ClientID") %>', "lat": '<%# Eval("Latitude") %>', "lng": '<%# Eval("Longitude") %>', "description": '<div><%# Eval("ClientLastName") %></div>'}
</ItemTemplate>
            <SeparatorTemplate>,</SeparatorTemplate>
        </asp:Repeater> ];


    function load() {

        
        // The location of Uluru
        var uluru = { lat: 41.69757038039064, lng: -70.20300119110104 };
       
        // The map, centered at Uluru
        var map = new google.maps.Map(
            document.getElementById('MapDiv'), { zoom: 10, center: uluru });
        var infoWindow = new google.maps.InfoWindow();

        for (i = 0; i < markers.length; i++) {
            var data = markers[i]
            var myLatlng = new google.maps.LatLng(data.lat, data.lng);
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: data.title
            });
            (function (marker, data) {
                google.maps.event.addListener(marker, "click", function (e) {
                    infoWindow.setContent(data.description);
                    infoWindow.open(map, marker);
                });
            })(marker, data);
        }


        //var labels = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';

        //var markers = locations.map(function (location, i) {
        //    return new google.maps.Marker({
        //        position: location,
        //        label: labels[i % labels.length]
        //    });
        //});


        //// Add a marker clusterer to manage the markers.
        var markerCluster = new MarkerClusterer(map, markers,
            { imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m' });





        document.getElementById('reloadMarkers').addEventListener('click', load);
    }



</script>