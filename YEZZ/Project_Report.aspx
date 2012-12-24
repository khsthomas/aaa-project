<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project_Report.aspx.cs" Inherits="APPGISMS.Project.Project_Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>專案圖層報表</title>
        <link type="text/css" rel="Stylesheet" href="../Style/SubPageStyle.css" />
        <link type="text/css" rel="Stylesheet" href="../Style/TopBottomLoyout.css" />
        <link type="text/css" rel="Stylesheet" href="../Style/LeftRightLoyout.css" />
        <link type="text/css" rel="Stylesheet" href="../Style/GridViewStyle.css" />
</head>
<body>
        <form id="form1" runat="server">
        <div class="MainPage">
            <AjaxCTLToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" />            
            <TSAControl:ErrorMessageControl ID="emcMsg" runat="server" CssClass="txtMessage" />
            <div class="div_button" style="position:absolute; margin:45px 0 0 634px;" >            
                <asp:Button ID="btnQuery" runat="server" Text="查詢資料" 
                    onclick="btnQuery_Click"  />
                <asp:Button ID="btnExpand" runat="server" Text="匯出資料" 
                    onclick="btnExpand_Click" />
            </div>
            <div class="div_top_bottom">
              <div class="slidetabsmenu">
                  <ul>
                      <li id="current"><a><span>專案圖層報表</span></a></li>
                  </ul>
              </div>
              <asp:UpdatePanel ID="upInput" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="tab_form" border="0">
                            <tr>
                                <td class="td_header td_header_2c_title">專案名稱</td>
                                <td class="td_control td_control_2c">
                                    <asp:DropDownList ID="ddlProjectName" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlProjectName_SelectedIndexChanged" />
                                </td>
                                <td class="td_header td_header_2c_title">公式名稱</td>
                                <td class="td_control td_control_2c">
                                    <asp:DropDownList ID="ddlFormulaName" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlFormulaName_SelectedIndexChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_header td_header_2c_title">年度</td>
                                <td class="td_control td_control_2c">
                                    <asp:DropDownList ID="ddlYearly" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlYearly_SelectedIndexChanged" />
                                </td>
                                <td class="td_header td_header_2c_title">分區</td>
                                <td class="td_control td_control_2c">
                                    <asp:DropDownList ID="ddlArea_Info" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlArea_Info_SelectedIndexChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_header td_header_2c_title">縣市</td>
                                <td class="td_control td_control_2c">
                                    <asp:DropDownList ID="ddlCounty_Info" runat="server" Visible="False" 
                                        Width="100px" />
                                </td>
                                <td class="td_header td_header_2c_title">顯示內容</td>
                                <td class="td_control td_control_2c" >
                                    <asp:CheckBoxList ID="cblDispaly" runat="server" RepeatDirection="Horizontal" BorderColor="White" BorderStyle="Solid" BorderWidth="2px">
                                        <asp:ListItem Value="1">牙醫分佈(╳)</asp:ListItem>
                                        <asp:ListItem Value="0">學校分佈(□)</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
          
            <div class="div_left_right">
            <div class ="left">
                <asp:UpdatePanel ID="upTree" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="panDistrict_Info" runat="server" Width="360px" Height="600px">
                        <asp:Image ID="MapArea" Width="100%" runat="server" Height="368px" />
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </div>
            </div>
            
            <div class="div_left_right">
                <div class ="right">
                <asp:UpdatePanel ID="upData" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="panDistribute" runat="server" Width="420px" Height="600px" ScrollBars="Auto">
                            <asp:GridView ID="tblDistribute" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" Width="100%" CssClass="GridViewStyle" 
                                GridLines="Vertical" 
                                DataKeyNames="DATA_YEAR,COUNTY_VARSION,COUNTY_NO,TOWN_NO">
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Center" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                                    <asp:BoundField DataField="Town_Name" HeaderText="鄉鎮市區" ReadOnly="True" />
                                    <asp:BoundField DataField="Doctor_Rate" HeaderText="醫師人口比" ReadOnly="True" />
                                    <asp:BoundField DataField="Person_Count" HeaderText="人口數" ReadOnly="True" />
                                    <asp:BoundField DataField="Person_Density" HeaderText="人口密度" ReadOnly="True" />
                                    <asp:BoundField DataField="Evaluate" HeaderText="(公式名稱)" ReadOnly="True" />                                    
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </div> 
            </div>
            
            
              </div>
         </div> 
        </form>
    </body>
</html>
