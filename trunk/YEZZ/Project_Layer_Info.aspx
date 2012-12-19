<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project_Layer_Info.aspx.cs" Inherits="APPGISMS.Project.Project_Layer_Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>專案圖層定義</title>
    <link type="text/css" rel="Stylesheet" href="../Style/SubPageStyle.css" />
    <link type="text/css" rel="Stylesheet" href="../Style/GridViewStyle.css" />
    <link type="text/css" rel="Stylesheet" href="../Style/TopBottomLoyout.css" />
    <link type="text/css" rel="Stylesheet" href="../Style/DialogStyle.css" />
</head>
<script type = "text/javascript">
function colorChanged(sender) 
{
    sender.get_element().style.backgroundColor = "#" + sender.get_selectedColor();  
}
</script>


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
    <asp:HiddenField ID="hfRowIndex" runat="server"/>
    <div class="div_top_bottom">
    <div class="slidetabsmenu">
            <ul>
                 <li id="current"><a><span>專案圖層定義</span></a></li>
             </ul>
          </div>
        <table class="tab_form" border="0">      
           <tr>
                 <td class="td_header td_header_2c_title">專案名稱</td>
                 <td class="td_control td_control_2c"><asp:DropDownList ID="ddlProjectName" runat="server" /></td>
                  <td class="td_header td_header_2c_title">啟用狀態</td>
                 <td class="td_control td_control_2c"><asp:DropDownList ID="ddlStsInfo" runat="server" /></td>
           </tr>  
            <tr>
                 <td class="td_header td_header_2c_title">圖層狀態</td>
                 <td class="td_control td_control_2c">
                     <asp:TextBox ID="txtLayerType" runat="server"></asp:TextBox></td>
                 <td class="td_header td_header_2c_title">圖層顏色</td>
                 <td class="td_control td_control_2c">
                     <asp:TextBox ID="txtLayerColor" runat="server" Text="" 
                         ontextchanged="txtLayerColor_TextChanged" />
                     <AjaxCTLToolkit:ColorPickerExtender ID="txtLayerColor_ColorPickerExtender" 
                         runat="server" Enabled="True" TargetControlID="txtLayerColor" OnClientColorSelectionChanged="colorChanged">
                     </AjaxCTLToolkit:ColorPickerExtender>
                 </td>
           </tr> 
             <tr>
                 <td class="td_header td_header_2c_title">公式名稱</td>
                 <td class="td_control td_control_2c" colspan="3">
                     <asp:DropDownList ID="ddlFormulaName" runat="server" 
                         onselectedindexchanged="ddlFormulaName_SelectedIndexChanged" 
                         AutoPostBack="True" /></td>                
           </tr> 
           <tr>
            <td class="td_header td_header_2c_title">圖層定義</td>
                 <td class="td_control td_control_2c" colspan="3">
                     <asp:Label ID="lblFormulaName" runat="server" Text="(公式名稱)"></asp:Label><asp:TextBox ID="txtStart"
                         runat="server"></asp:TextBox><asp:DropDownList ID="ddlDefinition" runat="server" />
                     <asp:TextBox ID="txtEnd" runat="server"></asp:TextBox></td>
           </tr>
           <tr>
                 <td class="td_header td_header_2c_title">備註</td>
                  <td class="td_control td_control_2c" colspan="3">
                      <asp:TextBox ID="txtLayerRemark" runat="server" TextMode="MultiLine" Width="480px" ></asp:TextBox></td> 
           </tr>
        </table>
    </div>
    <br />
    <hr />
    <div class="div_top_bottom">
        <asp:GridView ID="tblProjectFormula" runat="server" AutoGenerateColumns="False" CellPadding="4"
            GridLines="Vertical" Width="100%" CssClass="GridViewStyle" 
            AllowPaging="False" EmptyDataText="查無資料" 
            onrowediting="tblProjectFormula_RowEditing">
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
                <asp:BoundField HeaderText="專案ID" DataField="PROJECT_SN">
                    <HeaderStyle CssClass="HiddenHeader" />
                    <ItemStyle CssClass="HiddenCol" />
                </asp:BoundField>
                <asp:BoundField HeaderText="公式名稱" DataField="FORMULA_NAME">
                    <HeaderStyle Width="120px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="公式ID" DataField="FORMULA_ID">
                    <HeaderStyle CssClass="HiddenHeader" />
                    <ItemStyle CssClass="HiddenCol" />
                </asp:BoundField>
                <asp:BoundField HeaderText="圖層定義" DataField="LAYER_TYPE">
                    <ItemStyle Width="80px"  />
                </asp:BoundField>
                <asp:BoundField HeaderText="LAYER_START" DataField="LAYER_START">
                    <HeaderStyle CssClass="HiddenHeader" />
                    <ItemStyle CssClass="HiddenCol" />
                </asp:BoundField>
                <asp:BoundField HeaderText="LAYER_DEFINITION" DataField="LAYER_DEFINITION">
                    <HeaderStyle CssClass="HiddenHeader" />
                    <ItemStyle CssClass="HiddenCol" />
                </asp:BoundField>
                <asp:BoundField HeaderText="LAYER_END" DataField="LAYER_END">
                    <HeaderStyle CssClass="HiddenHeader" />
                    <ItemStyle CssClass="HiddenCol" />
                </asp:BoundField>
                 <asp:BoundField HeaderText="圖層顏色" DataField="LAYER_COLOR">
                    <ItemStyle Width="80px" />
                </asp:BoundField>
                 <asp:BoundField HeaderText="啟用狀態" DataField="STS_INFO">
                    <ItemStyle Width="80px"  />
                </asp:BoundField>
                 <asp:BoundField HeaderText="備註" DataField="LAYER_REMARK">
                    <ItemStyle Width="120px"  />
                </asp:BoundField>
            </Columns>
        </asp:GridView>

    </div> 
    </div> 
    </form>
</body>
</html>