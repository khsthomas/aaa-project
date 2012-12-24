<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search_Doctor.aspx.cs"
    Inherits="APPGISMS.SearchPage.Search_Doctor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>牙醫師查詢 </title>
    <link type="text/css" rel="stylesheet" href="../Style/SubPageStyle.css" />
    <link type="text/css" rel="Stylesheet" href="../Style/UserGridViewStyle.css" />
    <link type="text/css" rel="Stylesheet" href="../Style/DetailsViewStyle.css" />

    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;&amp;key=ABQIAAAAoxX6Czs-H1nP2Q3X1GRccxSrH0QOKtO33k6x9LZ69u795NKUcRT4VDwpniQPalvkpDQMfQ1KiabKLA"
        type="text/javascript"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/MapScript.js"></script>

</head>
<body onload="load()" onunload="GUnload">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <table border="0" class="MainPage">
        <tr>
            <td class="MessageBlack" valign="bottom">
                1.本站資料來源參考行政院衛生署公告。<br />
                2.系統資料更新中，如有問題請洽牙醫師全國聯合會。
            </td>
            <td class="QueryBlack">
                <asp:UpdatePanel ID="upTitle" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlQuery_Type" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="DOCTOR" Selected="True">依醫生名稱查詢</asp:ListItem>
                            <asp:ListItem Value="依醫生專長查詢" Enabled="False">依醫生專長查詢</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlCounty_Info" runat="server" DataSource='<%# getCountyInfo() %>'
                            DataTextField="COUNTY_NAME" DataValueField="COUNTY_NO" AutoPostBack="True" OnSelectedIndexChanged="ddlCounty_Info_SelectedIndexChanged" />
                        <asp:DropDownList ID="ddlTown_Info" runat="server" DataTextField="TOWN_NAME" DataValueField="TOWN_NO"
                            Enabled="False" />
                        <asp:TextBox ID="txtQuery" runat="server" Width="150px" />
                        <AjaxCTLToolkit:TextBoxWatermarkExtender ID="txtwaterSearch_Type" runat="server"
                            TargetControlID="txtQuery" WatermarkText="請輸入牙醫師姓名" WatermarkCssClass="WaterMaskStyle" />
                        <asp:Button ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlQuery_Type" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlCounty_Info" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="QueryListBlack" valign="top">
                <asp:UpdatePanel ID="upTab" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <AjaxCTLToolkit:TabContainer ID="tcDoctor" runat="server" ActiveTabIndex="0" Height="400px"
                            Width="400px" ScrollBars="Auto">
                            <AjaxCTLToolkit:TabPanel ID="tpAnnounce" runat="server" HeaderText="系統公告">
                                <ContentTemplate>
                                    <UserControl:Announcement id="annHospital" runat="server" />
                                </ContentTemplate>
                            </AjaxCTLToolkit:TabPanel>
                            <AjaxCTLToolkit:TabPanel ID="tpDoctor_List" runat="server" HeaderText="地圖查詢">
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="upResult" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                                        <ContentTemplate>
                                            <asp:Panel ID="panTitle" runat="server" Visible="False" CssClass="GridViewTitleStyle">
                                                牙醫師清單</asp:Panel>
                                            <asp:GridView ID="gvDoctor" runat="server" Width="95%" AutoGenerateColumns="False"
                                                AllowPaging="True" CellPadding="4" GridLines="None" ShowFooter="True" PageSize="13"
                                                EmptyDataText="查無資料" HorizontalAlign="Center" DataKeyNames="HOSPITAL_SN" CssClass="GridViewStyle"
                                                OnPageIndexChanging="gvDoctor_PageIndexChanging" OnRowDataBound="gvDoctor_RowDataBound"
                                                OnRowCommand="gvHospital_RowCommand" OnRowCreated="gvDoctor_RowCreated">
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" />
                                                <PagerStyle HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
                                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                <FooterStyle CssClass="GridViewFooterStyle" />
                                                <Columns>
                                                    <asp:BoundField DataField="DOCTOR_NAME" HeaderText="醫生">
                                                        <HeaderStyle Width="50px" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="院所" DataField="HOSPITAL_NAME">
                                                        <HeaderStyle Width="130px" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="x" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblX" runat="server" Text='<%# Bind("hospital_x") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="y" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblY" runat="server" Text='<%# Bind("hospital_y") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:ButtonField Text="定位" HeaderText="定位" CommandName="Detail">
                                                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                    </asp:ButtonField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="gvDoctor" EventName="PageIndexChanging" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </AjaxCTLToolkit:TabPanel>
                            <AjaxCTLToolkit:TabPanel ID="tp_Hospital_Info" runat="server" HeaderText="院所詳細資料"
                                Enabled="False">
                                <ContentTemplate>
                                    <UserControl:HospitalDetail id="hdDoctor" runat="server" />
                                </ContentTemplate>
                            </AjaxCTLToolkit:TabPanel>
                        </AjaxCTLToolkit:TabContainer>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td valign="top">
                <div id="map" class="MapBlack">
                </div>
            </td>
        </tr>
    </table>
    <div class="MapControl">
        <img alt="" src="../Images/MapSacle/zoom_in.gif" style="display: block; cursor: pointer;
            margin-bottom: 3px" onclick="ZoomIn()" />
        <img id="imgZoom10" alt="" src="../Images/MapSacle/zoom_10.gif" style="display: block;
            cursor: pointer;" onclick="ZoomScale(16);" />
        <img id="imgZoom9" alt="" src="../Images/MapSacle/zoom_9.gif" style="display: block;
            cursor: pointer;" onclick="ZoomScale(15);" />
        <img id="imgZoom8" alt="" src="../Images/MapSacle/zoom_8.gif" style="display: block;
            cursor: pointer;" onclick="ZoomScale(14);" />
        <img id="imgZoom7" alt="" src="../Images/MapSacle/zoom_7.gif" style="display: block;
            cursor: pointer;" onclick="ZoomScale(13);" />
        <img id="imgZoom6" alt="" src="../Images/MapSacle/zoom_6.gif" style="display: block;
            cursor: pointer;" onclick="ZoomScale(12);" />
        <img id="imgZoom5" alt="" src="../Images/MapSacle/zoom_5.gif" style="display: block;
            cursor: pointer;" onclick="ZoomScale(11);" />
        <img id="imgZoom4" alt="" src="../Images/MapSacle/zoom_4.gif" style="display: block;
            cursor: pointer;" onclick="ZoomScale(10);" />
        <img id="imgZoom3" alt="" src="../Images/MapSacle/zoom_3.gif" style="display: block;
            cursor: pointer;" onclick="ZoomScale(9);" />
        <img id="imgZoom2" alt="" src="../Images/MapSacle/zoom_2.gif" style="display: block;
            cursor: pointer;" onclick="ZoomScale(8);" />
        <img id="imgZoom1" alt="" src="../Images/MapSacle/zooming_1.gif" style="display: block;
            cursor: pointer;" onclick="ZoomScale(7);" />
        <img alt="" src="../Images/MapSacle/zoom_out.gif" style="display: block; cursor: pointer;
            margin-top: 3px" onclick="ZoomOut()" />
    </div>
    </form>
</body>
</html>
