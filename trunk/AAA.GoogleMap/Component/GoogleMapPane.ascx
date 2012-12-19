<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoogleMapPane.ascx.cs" Inherits="AAA.GoogleMap.Component.GoogleMapPane" %>
<style type="text/css">
    html { height : 100%}
    body {height : 100%; margin : 0px; padding : 0px}
    #googleMap { height : 100% }
</style>
<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
<script type="text/javascript">

    var locations = new Array();
    
    locations[0] = new Array();
    locations[0][0] = -34.397;
    locations[0][1] = 150.644;
    
    locations[1] = new Array();
    locations[1][0] = -34.382;
    locations[1][1] = 150.024;
    
    locations[2] = new Array();
    locations[2][0] = -34.377;
    locations[2][1] = 149.024;
    
    
    function addMarker(map, latlng, title) {
        var marker = new google.maps.Marker({position : latlng, map : map, title : title});
    }

    function mark() {
        if (locations == null)
            reutrn;

        if (locations.length == 0)
            return;
    
        var latlng = new google.maps.LatLng(locations[0][0], locations[0][1]);
        var myOpions =
                {   
                    zoom: 8,
                    center: latlng,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };
        var map = new google.maps.Map(document.getElementById("googleMap"), myOpions);
    
        for(var i = 0; i < locations.length; i++)
        {
            addMarker(map, new google.maps.LatLng(locations[i][0], locations[i][1]), "I'm Here" + i);
            
        }
        
    }


</script>
<div id="googleMap" style="width:100%;height:100%"></div>
<button onclick="mark();">Display</button>
