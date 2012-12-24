//var varKmlUrl = 'http://211.21.159.128/KML/';
//var varKmlUrl = 'http://localhost/KML/';
//var varKmlUrl = 'http://211.21.159.128/TEST3/';
var varKmlUrl = 'http://gis.cda.org.tw/TEST3/';
var varDispalyPoint = true;
var geoXml;


// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：取得縣市鄉鎮區座標
// 修改人：
// 修改日期：
// </summary>
function btnSearch_ClientClick()
{
    if ($get('ddlCounty_Info').value != 'NoChoose')
        APPGISMS.WebServices.GetPositionService.getTownXY($get('ddlCounty_Info').value, $get('ddlTown_Info').value, ZoomToTown);
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：特定縣市鄉鎮區定位
// 修改人：
// 修改日期：
// </summary>
function ZoomToTown(result)
{
    if (result)
    {
        //特定縣市鄉鎮區定位
        var array_data = result.split(",");
        var x = array_data[0];
        var y = array_data[1];
        var s = array_data[2];
        positionTown(x, y, s);

        //顯示特定縣市鄉鎮區點位
        if (varDispalyPoint)
        {
            map.clearOverlays();
            var kml_url = varKmlUrl + $get('ddlCounty_Info').value + "/" + $get('ddlTown_Info').value + ".kml";
            geoXml = new GGeoXml (kml_url);
            map.addOverlay(geoXml);
        }
    }
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：特定縣市鄉鎮區定位
// 修改人：
// 修改日期：
// </summary>
function positionTown(x, y, scale)
{
    map.setCenter(new GLatLng(x, y), parseInt(scale));
}