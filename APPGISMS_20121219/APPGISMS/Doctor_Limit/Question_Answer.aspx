<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question_Answer.aspx.cs"
    Inherits="APPGISMS.Doctor_Limit.Question_Answer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Q&A</title>
    <link type="text/css" rel="Stylesheet" href="../Style/SubPageStyle.css" />

    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.4.2.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            var h3 = $(".accordion h3");
            $(".accordion h3:eq(0)").addClass("active"); //1.首先获取第一个H3标签添加class；
            $(".accordion p").hide(); //在获取除了第一个p标签以外的所有标签都隐藏； $(".accordion p:gt(0)").hide();
            h3.click(function() {
                $(this).next("p").slideToggle("fast ")//查找下一个p标签添加动画，并查找它的兄弟节点是否显示，如果显示就隐藏
.siblings("p:visible").fadeOut("fast ");
                $(this).toggleClass("active"); //给H3标签添加class（如果有就不添加 没有就添加），查找兄弟节点移除class 
                $(this).siblings("h3").removeClass("active");
            });
        }); 
    </script>

    <style type="text/css">
        .accordion
        {
            margin-left: 10%;
            margin-right: 10%;
            margin-top: 10px;
            width: 570px;
            width: 1000px;
            border-bottom: solid 1px #c4c4c4;
            position: absolute;
            font: 75%/120% Arial, Helvetica, sans-serif;
        }
        .accordion h3
        {
            background: #e9e7e7 url(../Images/Q&A/arrow-square.gif) no-repeat right -51px;
            padding: 7px 15px;
            margin: 0;
            font: bold 120%/100% Arial, Helvetica, sans-serif;
            border: solid 1px #c4c4c4;
            border-bottom: none;
            cursor: pointer;
        }
        .accordion h3:hover
        {
            background-color: #e3e2e2;
        }
        .accordion h3.active
        {
            background-position: right 5px;
        }
        .accordion p
        {
            background: #f7f7f7;
            margin: 0;
            padding: 10px 15px 20px;
            border-left: solid 1px #c4c4c4;
            border-right: solid 1px #c4c4c4;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h2>
        Q&A</h2>
    <div class="accordion">
        <h3>
            Q1.登入後，沒有顯示管理平台的視窗，這是為什麼？</h3>
        <p>
            A1.有可能是您的管理平台被IE瀏覽器的快顯封鎖程式封鎖。請點選網頁上方的警示訊息，選擇「永遠允許來自這個網站的快顯(A)...」。<br />
            <br />
            <asp:Image ID="imgA1_1" runat="server" src="../Images/Q&A/A1_1.png" />
            <br />
            <br />
            或請至工具列>網際網路選項>隱私權>快顯封鎖程式中點「設定」，將網址211.21.159.128新增至允許的網站。<br />
            <br />
            <asp:Image ID="imgA1_2" runat="server" src="../Images/Q&A/A1_2.png" /><br />
            <br />
            若您有安裝Google工具列，請按一下工具列中的扳手<asp:Image ID="Image1" runat="server" src="../Images/Q&A/toolbar_wrench.gif" />圖示，選擇「工具」
            標籤，取消勾選「彈出式視窗攔截器」 核取方塊，並按下儲存。
        </p>
        <h3>
            Q2.忘記密碼應如何處理？</h3>
        <p>
            A2.若您忘記密碼，請聯絡全聯會系統管理員。<br />
            <br />
            聯絡方式請來信到den13501@cda.org.tw 鄭至軒。<br />
            <br />
        </p>
    </div>
    </form>
</body>
</html>
