<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YEZZ._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:LinkButton ID="LinkButton1" runat="server" 
            PostBackUrl="/Project_Column_Info.aspx">專案欄位設定</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" 
            PostBackUrl="/Project_Import_Maintain.aspx">資料維護</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton3" runat="server" 
            PostBackUrl="/Project_Layer_Info.aspx">專案圖層定義</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton4" runat="server" 
            PostBackUrl="/Project_Report.aspx">專案圖層報表</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
