<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YEZZ._Default" %>

<%@ Register src="Components/Calculator.ascx" tagname="Calculator" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <AjaxCTLToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />      
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
        <br />
        <asp:TextBox ID="txtFormula" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtFormulaValue" runat="server"></asp:TextBox>
        <asp:Button ID="btnShowCalculator" runat="server" Text="小算盤"/>   
    </div>   
    
    <AjaxCTLToolkit:ModalPopupExtender ID="mpeCalculator" runat="server" TargetControlID="btnShowCalculator"
        PopupControlID="panCalculator_Dialog"  BackgroundCssClass="DialogBackGround" />
    <asp:Panel ID="panCalculator_Dialog" runat="server" Style="display: none">
        <AjaxCTLToolkit:RoundedCornersExtender ID="rceCalculator_List" runat="server" TargetControlID="panCalculator_DialogWindow" BorderColor="#7B9623" Radius="12" />
        <asp:Panel ID="panCalculator_DialogWindow" runat="server" Width="500px" Height="220px" CssClass="DialogWindow">
            <div class="DialogTitle">公式編輯器</div>
            <asp:Panel ID="panCalculator_DialogContent" runat="server" Height="125px" CssClass="DialogContent" ScrollBars="Auto">
                <asp:UpdatePanel ID="upCalculator_List" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="DialogData">
                            <uc1:Calculator ID="calculator" runat="server" />                        
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <div class="DialogButton" align="center">
                <asp:Button ID="btnClose" runat="server" Text="關閉" onclick="btnClose_Click" />
            </div>
        </asp:Panel>
    </asp:Panel>    
    
    </form>
</body>
</html>
