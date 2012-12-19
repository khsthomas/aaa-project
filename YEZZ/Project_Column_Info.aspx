<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project_Column_Info.aspx.cs" Inherits="APPGISMS.Project.Project_Column_Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>專案匯入欄位設定</title>
    <link type="text/css" rel="Stylesheet" href="../Style/SubPageStyle.css" />
    <link type="text/css" rel="Stylesheet" href="../Style/GridViewStyle.css" />
    <link type="text/css" rel="Stylesheet" href="../Style/TopBottomLoyout.css" />
    <link type="text/css" rel="Stylesheet" href="../Style/DialogStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class ="MainPage"> 
    <AjaxCTLToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />   
    <tsacontrol:errormessagecontrol id="emcMsg" runat="server" cssclass="txtMessage" />
     <div class="div_button" style="position:absolute; margin:45px 0 0 624px;">
        <asp:Button ID="btnQuery" runat="server" Text="查詢資料" onclick="btnQuery_Click"  />
        <asp:Button ID="btnImport" runat="server" Text="新增資料" 
             onclick="btnImport_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="變更資料" onclick="btnUpdate_Click"/>
    </div>
    <div class="div_top_bottom">
    <div class="slidetabsmenu">
            <ul>
                 <li id="current"><a><span>專案匯入欄位設定</span></a></li>
             </ul>
          </div>
        <table class="tab_form" border="0">      
           <tr>
                 <td class="td_header td_header_2c_title">專案名稱</td>
                 <td class="td_control td_control_2c"><asp:DropDownList ID="ddlProjectName" runat="server" Width="200" /></td>
                  <td class="td_header td_header_2c_title">欄位名稱</td>
                 <td class="td_control td_control_2c"><asp:TextBox ID="txtColumnName" runat="server"></asp:TextBox><asp:HiddenField ID="hfColumnId" runat="server" /></td>
           </tr>  
           <tr>
                 <td class="td_header td_header_2c_title">啟用狀態</td>
                  <td class="td_control td_control_2c"><asp:DropDownList ID="ddlStsInfo" runat="server" Width="100" /></td>
                 
                 <td class="td_header td_header_2c_title">欄位項次</td>
                 <td class="td_control td_control_2c">
                     <asp:DropDownList ID="ddlColumnOrder" runat="server" Width="100" /></td>
           </tr>             
        </table>
    </div>
    <br />
    <hr />
    <div class="div_top_bottom">
        <asp:GridView ID="tblProjectColumn" runat="server" AutoGenerateColumns="False" CellPadding="4"
            GridLines="Vertical" Width="100%" CssClass="GridViewStyle" AllowPaging="False" EmptyDataText="查無資料">
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <RowStyle CssClass="GridViewRowStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Center" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <FooterStyle CssClass="GridViewFooterStyle" />
            <Columns>
                <asp:TemplateField HeaderText="編輯">
                            <HeaderStyle Width="80px" />
                            <ItemStyle Width="120px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" ImageUrl="~/Images/Edit.png"
                                    ToolTip="編輯資料" />                                
                            </ItemTemplate>                            
                        </asp:TemplateField>                                        
                <asp:BoundField HeaderText="專案名稱" DataField="PROJECT_NAME">
                    <HeaderStyle Width="120px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="欄位名稱" DataField="COLUMN_NAME" >
                    <ItemStyle Width="120px"  />
                </asp:BoundField>
                <asp:BoundField HeaderText="欄位ID" DataField="COLUMN_ID" >
                    <ItemStyle CssClass="HiddenCol"/>
                    <HeaderStyle CssClass="HiddenHeader" />
                </asp:BoundField>
               <asp:BoundField HeaderText="啟用狀態"  DataField="STS_INFO">
                    <ItemStyle Width="80px"  />
                </asp:BoundField>
                 <asp:BoundField HeaderText="欄位項次" DataField="CUS_COLUMN_ORDER">
                    <ItemStyle Width="80px"  />
                </asp:BoundField>
            </Columns>
        </asp:GridView>

    </div> 
    </div> 
    </form>
</body>
</html>