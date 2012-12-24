<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Distribute_Map.aspx.cs" Inherits="APPGISMS.Report.Distribute_Map" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>醫缺圖層作業</title>
        <link type="text/css" rel="Stylesheet" href="../Style/SubPageStyle.css" />
        <link type="text/css" rel="Stylesheet" href="../Style/TopBottomLoyout.css" />
        <link type="text/css" rel="Stylesheet" href="../Style/LeftRightLoyout.css" />
        <link type="text/css" rel="Stylesheet" href="../Style/GridViewStyle.css" />
    </head>
    <body>
        <form id="form1" runat="server">
        <div class="MainPage">
            <asp:ScriptManager ID="ScriptManager1" runat="server" />            
            <TSAControl:ErrorMessageControl ID="emcMsg" runat="server" CssClass="txtMessage" />
            <div class="div_button" >            
                <asp:Button ID="btnQuery" runat="server" Text="查詢資料" onclick="btnQuery_OnClick" />
                <asp:Button ID="btnExpand" runat="server" Text="匯出資料" onclick="btnExpand_Click" />
            </div>
            <div class="div_top_bottom">
              <div class="slidetabsmenu">
                  <ul>
                      <li id="current"><a><span>醫缺圖層作業</span></a></li>
                  </ul>
              </div>
              <asp:UpdatePanel ID="upInput" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="tab_form" border="0">
                            <tr>
                                <td class="td_header td_header_2c_title">年度</td>
                                <td class="td_control td_control_2c">
                                    <asp:DropDownList ID="ddlYearly" runat="server" 
                                        DataSource="<%# getddlYearly() %>" DataTextField="DATA_YEAR" 
                                        DataValueField="DATA_YEAR" AutoPostBack="True" 
                                        onselectedindexchanged="ddlYearly_SelectedIndexChanged" />
                                </td>
                                <td class="td_header td_header_2c_title">分區</td>
                                <td class="td_control td_control_2c">
                                    <asp:DropDownList ID="ddlArea_Info" runat="server" AutoPostBack="True" 
                                        DataSource="<%# getddlArea() %>" DataTextField="CL_DESC" 
                                        DataValueField="CL_INF" onselectedindexchanged="ddlArea_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_header td_header_2c_title">縣市</td>
                                <td class="td_control td_control_2c">
                                    <asp:DropDownList ID="ddlCounty_Info" runat="server" 
                                        DataTextField="COUNTY_NAME" DataValueField="COUNTY_NO" Visible="False" 
                                        Width="100px" />
                                </td>
                                <td class="td_header td_header_2c_title">顯示內容</td>
                                <td class="td_control td_control_2c" >
                                    <asp:CheckBoxList ID="cblDispaly" runat="server" RepeatDirection="Horizontal">
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
                <asp:UpdatePanel ID="upData" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="panDistribute" runat="server" Width="400px" Height="600px" ScrollBars="Auto">
                            <asp:GridView ID="grvDistribute" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" Width="100%" CssClass="GridViewStyle" 
                                GridLines="Vertical" 
                                DataKeyNames="DATA_YEAR,COUNTY_VARSION,COUNTY_NO,TOWN_NO" 
                                onrowdatabound="grvDistribute_RowDataBound">
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
                                    <asp:BoundField DataField="Evaluate" HeaderText="醫療資源狀態" ReadOnly="True" />
                                    <asp:TemplateField HeaderText="顏色" Visible="False">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("LAYER_COLOR") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("LAYER_COLOR") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </div> 
            </div>
            
             <div class="div_left_right">
            <div class ="right">
                <asp:UpdatePanel ID="upTree" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="panDistrict_Info" runat="server" Width="410px" Height="600px">
                        <asp:Image ID="MapArea" Width="100%" runat="server" Height="368px" />
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
