// </summary>
// 撰寫人：Tina
// 撰寫日期：2012/05/09
// 功能簡述：頁面初始Link
// 修改人：
// 修改日期：
// </summary>
function initPageLink() {
    //取得使用者功能資料
    APPGISMS.WebServices.FunctionWebService.getLinkInfo(onCreateLink);

}

// </summary>
// 撰寫人：Tina
// 撰寫日期：2012/05/09
// 功能簡述：取得連結資料
// 修改人：
// 修改日期：
// </summary>
function onCreateLink(result, response, context) {
    for (var i = 0; i < 5; i++) {
        var fields = result[i].split('|');
        createLinkItem(fields[0], fields[1]);
    }
}

// </summary>
// 撰寫人：Tina
// 撰寫日期：2012/05/09
// 功能簡述：建立連結
// 修改人：
// 修改日期：
// </summary>
function createLinkItem(varLink_Name, varLink_Url) {
    //取得主功能選單物件
    var objMainMenu = $get('ulLink');

    var li = document.createElement('li');
    var link = document.createElement('a');
    link.target = "_blank";
    link.href = varLink_Url;
    var text = document.createTextNode(varLink_Name);

    link.appendChild(text);
    li.appendChild(link);
    objMainMenu.appendChild(li);

}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：頁面初始
// 修改人：
// 修改日期：
// </summary>
function initPageMenu(user_id)
{
    //頁面可用Width
    var varWidnowWidth = window.screen.availWidth;
    //功能可用Width
    var varFunctionWidth = varWidnowWidth - 0;
    //var varFunctionWidth = varWidnowWidth - 538;
    //可顯示功能個數
    varFunTotalCount = parseInt(varFunctionWidth / 141);
    //varFunTotalCount = parseInt(varFunctionWidth / 140);
    $get('ulMainFunction').style.width = varFunctionWidth;
    //取得使用者功能資料
    APPGISMS.WebServices.FunctionWebService.getFunctionInfo(user_id, onCreateMenu);
    APPGISMS.WebServices.FunctionWebService.getLinkInfo(onCreateLink);
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：取得使用者功能資料
// 修改人：
// 修改日期：
// </summary>
function onCreateMenu(result, response, context)
{
    //fields[0]=FUN_ID
    //fields[1]=FUN_NAME
    //fields[2]=FUN_URL
    //fields[3]=PARENT_FUN_ID
    //fields[4]=FUN_TYPE
    
    //主子功能總個數
    var varFunctionCount = result.length;
    for (var i = 0; i <= varFunctionCount - 1; i++)
    {
        var fields = result[i].split('|');
        //主功能
        if (fields[4] == 'MAIN')
        {
            varMenuCount = varMenuCount + 1;
            createMainMenuItem(fields[1]);
            varNowFunId = fields[0];
        }
        //子功能
        else
            createSubMenuItem(fields[1], fields[2]);
    }
    
    //判斷可顯示功能個數是否小於使用者功能個數
    if (varFunTotalCount < varMenuCount)
    {
        //顯示向右箭頭
        $get('imgFunctionRight').style.display = 'block';
        //使用者功能頁數
        if (varMenuCount % varFunTotalCount == 0)
            varMenuPageCount = parseInt(varMenuCount / varFunTotalCount);
        else
            varMenuPageCount = parseInt(varMenuCount / varFunTotalCount) + 1;
        varMenuPageIndex = 1;
        //隱藏功能
        for (var i = varFunTotalCount; i <= varMenuCount - 1; i++)
            objMenu[i].style.display = 'none';
    } 
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：建立主功能選單
// 修改人：
// 修改日期：
// </summary>
function createMainMenuItem(varFun_Name)
{
    //取得主功能選單物件
    var objMainMenu = $get('ulMainFunction');
    //主功能物件ID
    var varMain_Id = 'divMain_' + varMenuCount;
    //子功能容器物件ID
    var varSub_Id = 'divSub_' + varMenuCount;
    
    //建立主功能物件
    var li = document.createElement('li');
    var link = document.createElement('a');
    var text = document.createTextNode(varFun_Name);
   
    li.setAttribute('id', varMain_Id);
    li.onmouseover = function() { menuMain_OnMouseOver(this, varSub_Id); };
    li.onmouseout = function() { menuMain_OnMouseOut(this, varSub_Id); };
    link.appendChild(text);
    //li.appendChild(text);
    li.appendChild(link);
    objMainMenu.appendChild(li);    
    objMenu[varMenuCount - 1] = li;
    
    //建立子功能容器物件
    var div = document.createElement('div');
    div.setAttribute('id', varSub_Id);
    var varSubPosition = varMenuCount % varFunTotalCount == 0 ? varFunTotalCount : varMenuCount % varFunTotalCount;
    div.style.left = varMenuPosition + 144 * (varSubPosition - 1);
    objSubMenu[varMenuCount - 1] = div;
    $get('form1').appendChild(div);
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：建立主功能選單
// 修改人：
// 修改日期：
// </summary>
function createSubMenuItem(varFun_Name, varFun_Url)
{
    //子功能物件
    var objFrame = $get('divSubMenu');
    //主功能物件ID
    var varMain_Id = 'divMain_' + varMenuCount;
    //子功能容器物件ID
    var varSub_Id = 'divSub_' + varMenuCount;
    
    //建立子功能
    var div = objSubMenu[varMenuCount - 1];
    var ul = document.createElement('ul');
    var li = document.createElement('li');
    var link = document.createElement('a');
//  link.setAttribute('href', function() { menuMain_OnClick(varFun_Url); });
    var text = document.createTextNode(varFun_Name);
    li.onmouseover = function() { menuSub_OnMouseOver(this); };
    li.onmouseout = function() { menuSub_OnMouseOut(this, varSub_Id, varMain_Id); };
    li.onclick = function() { menuMain_OnClick(varFun_Url); };
    
    //li.appendChild(text);
    link.appendChild(text);
    li.appendChild(link);
    ul.appendChild(li);
    div.appendChild(ul);
    
    objFrame.appendChild(div);

    var objSub = $get(varSub_Id);
    objSub.style.display = 'none';
    
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：功能列向左移動
// 修改人：
// 修改日期：
// </summary>
function imgFunctionLeft_Click()
{
    //上一頁
    varMenuPageIndex--;
    //起始位置
    var varStartIndex = (varFunTotalCount * (varMenuPageIndex - 1)) + 1;
    //結束位置
    var varEndIndex = varFunTotalCount * varMenuPageIndex;
    controlMainFunction(varStartIndex, varEndIndex);
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：功能列向右移動
// 修改人：
// 修改日期：
// </summary>
function imgFunctionRight_Click()
{
    //起始位置
    var varStartIndex = (varFunTotalCount * varMenuPageIndex) + 1;
    //下一頁
    varMenuPageIndex++;
    //結束位置
    var varEndIndex = varFunTotalCount * varMenuPageIndex;
    controlMainFunction(varStartIndex, varEndIndex);
}

// </summary>
// 撰寫人：Oliver
// 撰寫日期：2010/04/23
// 功能簡述：顯示/隱藏功能與箭頭
// 修改人：
// 修改日期：
// </summary>
function controlMainFunction(varStartIndex, varEndIndex)
{
    //顯示/隱藏功能
    for (var i = 0; i <= varMenuCount - 1; i++)
    {
        if (i >= varStartIndex - 1 && i <= varEndIndex - 1)
            objMenu[i].style.display = 'inline';
        else
            objMenu[i].style.display = 'none';
    }
    
    //顯示/隱藏箭頭
    $get('imgFunctionLeft').style.display = varMenuPageIndex == 1 ? 'none' : 'block';
    $get('imgFunctionRight').style.display = varMenuPageIndex == varMenuPageCount ? 'none' : 'block';
}