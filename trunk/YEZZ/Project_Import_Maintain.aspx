<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project_Import_Maintain.aspx.cs" Inherits="APPGISMS.Project.Project_Import_Maintain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>(專案名稱)資料維護</title>
    <link type="text/css" rel="Stylesheet" href="../Style/SubPageStyle.css" />
    <link type="text/css" rel="Stylesheet" href="../Style/GridViewStyle.css" />
    <link type="text/css" rel="Stylesheet" href="../Style/TopBottomLoyout.css" />
    <link type="text/css" rel="Stylesheet" href="../Style/DialogStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="MainPage">
    <AjaxCTLToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />  
                            <asp:GridView ID="tblError_List" runat="server" 
             AutoGenerateColumns="False" Width="100%"
                                CellPadding="4" CssClass="GridViewStyle" 
             GridLines="Vertical">
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Center" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                                    <asp:BoundField HeaderText="列資訊" DataField="ROW_INFO">
                                        <HeaderStyle Width="50%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="錯誤訊息" DataField="ERROR_MESSAGES" />
                                </Columns>
                            </asp:GridView>
    <tsacontrol:errormessagecontrol id="emcMsg" runat="server" cssclass="txtMessage" />
     <div class="div_button" style="position:absolute; margin:45px 0 0 424px;">
        <asp:Button ID="btnQuery" runat="server" Text="查詢資料" onclick="btnQuery_Click"  />
        <asp:Button ID="btnImport" runat="server" Text="匯入資料" 
             onclick="btnImport_Click"  />
        <asp:Button ID="btnOutput" runat="server" Text="匯出資料" 
             onclick="btnOutput_Click" />
        <asp:Button ID="btnSample" runat="server" Text="匯入範例" 
             onclick="btnSample_Click" />
    </div>
    <div class="div_top_bottom">
     <div class="slidetabsmenu">
            <ul>
                 <li id="current"><a><span><asp:Label ID="lblProjectName" runat="server" Text="(專案名稱)"></asp:Label>資料維護</span></a></li>
             </ul>
          </div>
        <table class="tab_form" border="0">
               <tr>
                    <td class="td_header td_header_2c_title">專案名稱</td>
                    <td class="td_control td_control_2c"><asp:DropDownList ID="ddlProjectName" 
                            runat="server" Width="200" AutoPostBack="True" 
                            onselectedindexchanged="ddlProjectName_SelectedIndexChanged" /></td>
               </tr>
            <tr align="center">                
                <td class="td_control_2c" colspan="2" >
                    <asp:FileUpload ID="fuImportData" runat="server"  Width="380px"  style="margin-top:8px; margin-bottom:8px; padding-top:8px;" />
                    <br />
                    <span style="color:Red;">請選取逗點分隔(*.csv)檔案格式，且限制檔案大小為10MB</span>
                </td>
            </tr>
        </table>
    
    <br />
    <hr />

        <asp:GridView ID="tblHospital" runat="server" AutoGenerateColumns="False" CellPadding="4"
            GridLines="Vertical" Width="100%" CssClass="GridViewStyle" AllowPaging="False" EmptyDataText="查無資料">
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <RowStyle CssClass="GridViewRowStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Center" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <FooterStyle CssClass="GridViewFooterStyle" />
            <Columns>
                <asp:BoundField HeaderText="醫事機構代號" DataField="HOSPITAL_NO">
                    <HeaderStyle Width="180px" />
                </asp:BoundField>
                 <asp:BoundField HeaderText="醫師ID" DataField="DOCTOR_ID">
                    <HeaderStyle Width="80px" />
                </asp:BoundField>
                 <asp:BoundField HeaderText="起始日期" DataField="PROJECT_SDATE">
                    <HeaderStyle Width="120px" />
                </asp:BoundField>
                   <asp:BoundField HeaderText="結束日期" DataField="PROJECT_EDATE">
                    <HeaderStyle Width="120px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="備註" DataField="PROJECT_REMARK">
                      <HeaderStyle Width="200px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
   <br />
   <div style="padding:20px 0 6px 0; font-size:15px; font-weight:bolder;">醫事違規資料</div>    
   <asp:GridView ID="tblViolation" runat="server" AutoGenerateColumns="False" CellPadding="4"
            GridLines="Vertical" Width="100%" CssClass="GridViewStyle" AllowPaging="False" EmptyDataText="查無資料">
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <RowStyle CssClass="GridViewRowStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Center" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <FooterStyle CssClass="GridViewFooterStyle" />
            <Columns>
                <asp:BoundField HeaderText="醫事機構代號" DataField="HOSPITAL_NO">
                    <HeaderStyle Width="180px" />
                </asp:BoundField>
                 <asp:BoundField HeaderText="醫師ID" DataField="HOSPITAL_NO">
                    <HeaderStyle Width="80px" />
                </asp:BoundField>                 
                <asp:BoundField HeaderText="備註" DataField="PROJECT_REMARK">
                      <HeaderStyle Width="200px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        
    <asp:HiddenField ID="hfSample" runat="server" />        
    <AjaxCTLToolkit:ModalPopupExtender id="mpeSample_Info" runat="server" targetcontrolid="hfSample"
        popupcontrolid="panDialogSample_Info" cancelcontrolid="btnCancel" backgroundcssclass="DialogBackGround" />
    <asp:Panel ID="panDialogSample_Info" runat="server" Style="display: none">
        <AjaxCTLToolkit:RoundedCornersExtender id="rceSample_Info" runat="server" targetcontrolid="panSample_Info" bordercolor="#7B9623" radius="12" />
        <asp:Panel ID="panSample_Info" runat="server" Width="800px" Height="440px" CssClass="DialogWindow">
            <div class="DialogTitle">匯入Excel檔案範例</div>
            <asp:Panel ID="panSample_Info_DialogContent" runat="server" Height="360px" CssClass="DialogContent" >
                <asp:UpdatePanel ID="upSample_Info" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                         <table align="center">
                            <tr>
                               <td><span style ="padding-left:18px; padding-bottom:18px;">於Excel 檔中，依規定的欄位格式建立醫缺執業院所資料(如下圖所示)， 並以『CSV(逗點分隔值)檔案』儲存檔案。</span></td>
                            </tr>                           
                            <tr>
                                <td align="center">
                                    <asp:GridView ID="tblSample" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        GridLines="Vertical" Width="100%" CssClass="GridViewStyle" AllowPaging="False" EmptyDataText="查無資料">
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" />
                                        <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Center" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hfExcel_Info" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <div class="DialogButton" align="center">
                <asp:Button ID="btnCancel" runat="server" Text="關閉" />
            </div>
        </asp:Panel>
    </asp:Panel>
     <%--Excel 檔案匯入錯誤清單--%>
    <asp:HiddenField ID="hfError_Dialog" runat="server" />
    <AjaxCTLToolkit:ModalPopupExtender ID="mpeError_List" runat="server" TargetControlID="hfError_Dialog"
        PopupControlID="panError_Dialog" CancelControlID="btnClose" BackgroundCssClass="DialogBackGround" />
    <asp:Panel ID="panError_Dialog" runat="server" Style="display: none">
        <AjaxCTLToolkit:RoundedCornersExtender ID="rceError_List" runat="server" TargetControlID="panError_DialogWindow" BorderColor="#7B9623" Radius="12" />
        <asp:Panel ID="panError_DialogWindow" runat="server" Width="600px" Height="420px" CssClass="DialogWindow">
            <div class="DialogTitle">匯入失敗清單</div>
            <asp:Panel ID="panError_DialogContent" runat="server" Height="345px" CssClass="DialogContent" ScrollBars="Auto">
                <asp:UpdatePanel ID="upError_List" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="DialogData">
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <div class="DialogButton" align="center">
                <asp:Button ID="btnClose" runat="server" Text="關閉" />
            </div>
        </asp:Panel>
    </asp:Panel>
    </div> 
    </div> 
    </form>
</body>
</html>
