<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hospital_Repeat.aspx.cs" Inherits="APPGISMS.ManageTool.Hospital_Repeat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>院所重覆資料處理</title>
        <link type="text/css" rel="Stylesheet" href="../Style/SubPageStyle.css" />
        <link type="text/css" rel="Stylesheet" href="../Style/GridViewStyle.css" />
        <link type="text/css" rel="Stylesheet" href="../Style/LeftRightLoyout.css" />
        <link type="text/css" rel="Stylesheet" href="../Style/DialogStyle.css" />
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <h2>院所重覆資料處理</h2>
            <TSAControl:ErrorMessageControl ID="emcMsg" runat="server" CssClass="txtMessage" />
            <div class="div_button">
                <asp:Button ID="btnShow" runat="server" Text="顯示院所資料" OnClick="btnShow_Click"/>
                <asp:Button ID="btnUpdate" runat="server" Text="更新院所資料" OnClick="btnUpdate_Click" />
            </div>
            <asp:Panel ID="panHospital_Info" runat="server" CssClass="div_left_right" Width="400px" Height="500px" ScrollBars="Auto">
                <asp:UpdatePanel ID="upQuery" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCounty_Info" runat="server" DataSource='<%# getCountyInfo() %>' DataTextField="COUNTY_NAME"
                        DataValueField="COUNTY_NO" AutoPostBack="True" OnSelectedIndexChanged="ddlCounty_Info_SelectedIndexChanged" />
                        <asp:DropDownList ID="ddlTown_Info" runat="server" DataTextField="TOWN_NAME" DataValueField="TOWN_NO" Enabled="False" />
                        <asp:TextBox ID="txtHospital_Name" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <hr />
                <asp:UpdatePanel ID="upHospital_Info" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvHospital_Info" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" CssClass="GridViewStyle" 
                            GridLines="Vertical" DataKeyNames="HOSPITAL_SN" EmptyDataText="無牙醫院所資料">
                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                            <RowStyle CssClass="GridViewRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" />
                            <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Center" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderStyle Width="10%" />
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:RadioButton ID="grv_rbtHospital_Info" runat="server" Checked='<%# Convert.ToBoolean(Eval("MAIN_CHOOSE")) %>'
                                            AutoPostBack="True" OnCheckedChanged="grv_rbtHospital_Info_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="HOSPITAL_SN" HeaderText="醫事編號">
                                    <HeaderStyle Width="30%" />
                                    <ItemStyle Width="30%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HOSPITAL_NAME" HeaderText="院所名稱" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Panel ID="panHospital_Doctor" runat="server" CssClass="div_left_right" Width="400px" Height="500px" ScrollBars="Auto">
                <asp:UpdatePanel ID="upHospital_Doctor" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvHospital_Doctor" runat="server" AutoGenerateColumns="False" Width="100%" 
                            CellPadding="4" CssClass="GridViewStyle" GridLines="Vertical">
                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                            <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" />
                            <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Center" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <Columns>
                                <asp:BoundField DataField="HOSPITAL_SN" HeaderText="醫事編號" />
                                <asp:BoundField DataField="DOCTOR_SN" HeaderText="醫師編號" />
                                <asp:BoundField DataField="DOCTOR_NAME" HeaderText="醫師姓名" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
        </form>
    </body>
</html>
