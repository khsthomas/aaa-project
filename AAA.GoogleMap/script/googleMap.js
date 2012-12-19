function init() {
    var latlng = new google.maps.LatLng(-34.397, 150.644);
    //var latlng = new google.maps.LatLng(x, y);
    var myOpions =
            { zoom: 8,
                center: latlng,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
    var map = new google.maps.Map(document.getElementById("googleMap"), myOpions);
}