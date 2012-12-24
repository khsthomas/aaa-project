<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hospital_Doctor_Count.aspx.cs" Inherits="APPGISMS.StatisticsInfo.Hospital_Doctor_Count" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head id="Head1" runat="server">
        <title>牙醫院所分布狀況</title>
        <link type="text/css" rel="Stylesheet" href="../Style/GridViewStyle.css" />
    </head>
    <body>
        <form id="form1" runat="server">
            <br />
            <asp:GridView ID="grvStatistics_Info" runat="server" Width="400px" AutoGenerateColumns="False" CellPadding="4" GridLines="Vertical"
                HorizontalAlign="Center" CssClass="GridViewStyle">
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle"/>
                <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" />
                <PagerStyle HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    <asp:BoundField HeaderText="縣市" DataField="COUNTY_NAME">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="院所個數" DataField="HOSPITAL_COUNT">
                        <HeaderStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Right" Font-Names="Arial" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="醫師個數" DataField="DOCTOR_COUNT">
                        <HeaderStyle Width="150px" />
                        <ItemStyle HorizontalAlign="Right" Font-Names="Arial" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </form>
    </body>
</html>
