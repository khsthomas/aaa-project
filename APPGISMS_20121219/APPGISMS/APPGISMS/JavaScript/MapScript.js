var map = null;
var defaultCenter;
var defaultZoom = 7;
var zooming = defaultZoom;

var defaultSW;
var defaultNE;
var allowedBounds;
var aberration = 0.1; // this value is a good choice for germany 

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：載入地圖
// 修改人：
// 修改日期：
// </summary>
function load()
{
    if (GBrowserIsCompatible())
    {
        map = new GMap2(document.getElementById("map"));

        //地圖初始中心點
        defaultCenter = new GLatLng(23.850674, 120.986938);
        //地圖可視邊界
//        defaultSW = new GLatLng(20.354928, 115.543213);
//        defaultNE = new GLatLng(26.234302, 126.463623);
//        allowedBounds = new GLatLngBounds(defaultSW, defaultNE);

        //顯示地圖型態切換的控制項
        map.addControl(new GMapTypeControl());
        //比例尺
        map.addControl(new GScaleControl());
        //地形圖
        map.addMapType(G_PHYSICAL_MAP);
        //開啟滑鼠滾輪
        map.enableScrollWheelZoom();
        //以動畫方式zoom
        map.enableContinuousZoom();

        //限定Scale範圍
        var mt = map.getMapTypes();
        for (i = 0; i <= mt.length - 1; i++)
        {
            mt[i].getMinimumResolution = function() { return 7; }
            mt[i].getMaximumResolution = function() { return 16; }
        }

        //ZoomEnd事件
        GEvent.addListener(map, "zoomend", setZoomImage);
        //Move事件
        //GEvent.addListener(map, "move", checkBounds);
        
        map.setCenter(defaultCenter, defaultZoom);
    }
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：設定地圖控制圖示顯示狀態
// 修改人：
// 修改日期：
// </summary>
function setZoomImage(old_scale, new_scale)
{
    zooming = new_scale;
    switch (zooming)
    {
        case 7:
            ZoomImage(true, false, false, false, false, false, false, false, false, false, false, false, false);
            break;
        case 8:
            ZoomImage(false, true, false, false, false, false, false, false, false, false, false, false, false);
            break;
        case 9:
            ZoomImage(false, false, true, false, false, false, false, false, false, false, false, false, false);
            break;
        case 10:
            ZoomImage(false, false, false, true, false, false, false, false, false, false, false, false, false);
            break;
        case 11:
            ZoomImage(false, false, false, false, true, false, false, false, false, false, false, false, false);
            break;
        case 12:
            ZoomImage(false, false, false, false, false, true, false, false, false, false, false, false, false);
            break;
        case 13:
            ZoomImage(false, false, false, false, false, false, true, false, false, false, false, false, false);
            break;
        case 14:
            ZoomImage(false, false, false, false, false, false, false, true, false, false, false, false, false);
            break;
        case 15:
            ZoomImage(false, false, false, false, false, false, false, false, true, false, false, false, false);
            break;
        case 16:
            ZoomImage(false, false, false, false, false, false, false, false, false, true, false, false, false);
            break;
        case 17:
            ZoomImage(false, false, false, false, false, false, false, false, false, false, true, false, false);
            break;
        case 18:
            ZoomImage(false, false, false, false, false, false, false, false, false, false, false, true, false);
            break;
        case 19:
            ZoomImage(false, false, false, false, false, false, false, false, false, false, false, false, true);
            break;
    }
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：設定地圖控制圖示位置
// 修改人：
// 修改日期：
// </summary>
function ZoomImage(zoom1, zoom2, zoom3, zoom4, zoom5, zoom6, zoom7, zoom8, zoom9, zoom10, zoom11, zoom12, zoom13)
{
    var image_addr = '../Images/MapSacle/';

    $get('imgZoom1').src = image_addr + (zoom1 ? 'zooming_1.gif' : 'zoom_1.gif');
    $get('imgZoom2').src = image_addr + (zoom2 ? 'zooming_2.gif' : 'zoom_2.gif');
    $get('imgZoom3').src = image_addr + (zoom3 ? 'zooming_3.gif' : 'zoom_3.gif');
    $get('imgZoom4').src = image_addr + (zoom4 ? 'zooming_4.gif' : 'zoom_4.gif');
    $get('imgZoom5').src = image_addr + (zoom5 ? 'zooming_5.gif' : 'zoom_5.gif');
    $get('imgZoom6').src = image_addr + (zoom6 ? 'zooming_6.gif' : 'zoom_6.gif');
    $get('imgZoom7').src = image_addr + (zoom7 ? 'zooming_7.gif' : 'zoom_7.gif');
    $get('imgZoom8').src = image_addr + (zoom8 ? 'zooming_8.gif' : 'zoom_8.gif');
    $get('imgZoom9').src = image_addr + (zoom9 ? 'zooming_9.gif' : 'zoom_9.gif');
    $get('imgZoom10').src = image_addr + (zoom10 ? 'zooming_10.gif' : 'zoom_10.gif');
//    $get('imgZoom11').src = image_addr + (zoom11 ? 'zooming_11.gif' : 'zoom_11.gif');
//    $get('imgZoom12').src = image_addr + (zoom12 ? 'zooming_12.gif' : 'zoom_12.gif');
//    $get('imgZoom13').src = image_addr + (zoom13 ? 'zooming_13.gif' : 'zoom_13.gif');
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：特定比例尺放大
// 修改人：
// 修改日期：
// </summary>
function ZoomScale(scale)
{
    var pointXY = map.getCenter();
    map.setCenter(pointXY, parseInt(scale));
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：比例尺放大
// 修改人：
// 修改日期：
// </summary>
function ZoomIn()
{
    zoom = zooming + 1;
    if (zooming != 15)
        ZoomScale(zoom);
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：比例尺縮小
// 修改人：
// 修改日期：
// </summary>
function ZoomOut()
{
    zoom = zooming - 1;
    if (zooming != 7)
        ZoomScale(zoom);
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：特定座標定位
// 修改人：
// 修改日期：
// </summary>
function positionXY(x, y)
{
    var pointXY = new GLatLng(x, y);
    var myMarker = new GMarker(pointXY);
    map.clearOverlays();
    map.setCenter(pointXY, 15);

    map.addOverlay(myMarker, { clickable: false });
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：限制顯示範圍
// 修改人：
// 修改日期：
// </summary>
function checkBounds()
{
    var currentBounds = map.getBounds();
    //alert(currentBounds);
    var cSpan = currentBounds.toSpan(); // width and height of the bounds
    //alert(cSpan);
    var offsetX = cSpan.lng() / (2 + aberration); // we need a little border
    var offsetY = cSpan.lat() / (2 + aberration);
    //alert(offsetX + ',' + offsetY);
    var C = map.getCenter(); // current center coords
    var X = C.lng();
    var Y = C.lat();
    //alert(C);

    // now check if the current rectangle in the allowed area
    var checkSW = new GLatLng(C.lat() - offsetY, C.lng() - offsetX);
    var checkNE = new GLatLng(C.lat() + offsetY, C.lng() + offsetX);

    if (allowedBounds.containsLatLng(checkSW) &&
		allowedBounds.containsLatLng(checkNE))
    {
        return; // nothing to do
    }

    var AmaxX = allowedBounds.getNorthEast().lng();
    var AmaxY = allowedBounds.getNorthEast().lat();
    var AminX = allowedBounds.getSouthWest().lng();
    var AminY = allowedBounds.getSouthWest().lat();

    if (X < (AminX + offsetX)) { X = AminX + offsetX; }
    if (X > (AmaxX - offsetX)) { X = AmaxX - offsetX; }
    if (Y < (AminY + offsetY)) { Y = AminY + offsetY; }
    if (Y > (AmaxY - offsetY)) { Y = AmaxY - offsetY; }

    map.setCenter(new GLatLng(Y, X));
    return;
} 