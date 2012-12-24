var varFunAddres = 'http://211.21.159.128/GISMS/';

function menuMain_OnMouseOver(objSelected, sub_id)
{
    //停止關閉子選單
    clearTimeout(varCloseSubTime);
    if (varCloseMainTime != null)
        clearTimeout(varCloseMainTime);

    //設定選取項目顏色
    setMenuColose(objSelected);
    
    var objSub = $get(sub_id);
    var varSubLength = objSubMenu.length;
    for (i = 0; i <= varSubLength - 1; i++)
    {
        objSubMenu[i].style.display = objSubMenu[i].id == sub_id ? 'block' : 'none';
    }
}

function menuMain_OnMouseOut(obj, sub_id)
{   
    varCloseMainTime = window.setTimeout(
            function()
            {
                var objSub = $get(sub_id);
                objSub.style.display = 'none';
            }, 500
        );
}

function menuMain_OnClick(varFun_Url)
{
    var objFrame = $get('mainfrm');
    objFrame.src = varFun_Url;
}

function menuSub_OnMouseOver(obj)
{
    var varImageUrl = varHostUrl + 'Images/MainPage/TopSubOver.png';
    obj.style.backgroundImage = 'url(' + varImageUrl + ')';
    clearTimeout(varCloseMainTime);
    if (varCloseSubTime != null)
        clearTimeout(varCloseSubTime);
}

function menuSub_OnMouseOut(obj, sub_id, main_id)
{
 
    varCloseSubTime = window.setTimeout(
            function()
            {
                var objMain = $get(main_id);
              
                var objSub = $get(sub_id);
                objSub.style.display = 'none';
            }, 400
        );
}

function setMenuColose(obj)
{
    //取得選取物件之父元素
    var objParent = obj.parentNode;
    var objMain = objParent.childNodes;
    var varMainLength = objMain.length;
    

}

function $get(ControlId)
{
    return document.getElementById(ControlId);
}

var geoXml;

function btnSearch_ClientClick()
{
    WS_GetXY.getTownXY($get('selCounty').value, $get('selTown').value, ZoomToTown);
}

function ZoomToTown(result)
{
    if (result)
    {
        var array_data = result.split(",");
        var x = array_data[0];
        var y = array_data[1];
        var s = array_data[2];
        positionTown(x, y, s);

        map.clearOverlays();
        //        //var kml_url = "http://120.125.84.67/CDA_KML/" + $get('selCounty').value + "/" + $get('selTown').value + ".kml";
        //        geoXml = new GGeoXml (kml_url);
        //        map.addOverlay(geoXml);
    }
}