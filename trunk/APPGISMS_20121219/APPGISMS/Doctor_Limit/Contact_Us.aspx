<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact_Us.aspx.cs" Inherits="APPGISMS.Doctor_Limit.Contact_Us" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>聯絡我們</title>
    <link type="text/css" rel="Stylesheet" href="../Style/SubPageStyle.css" />
    <link type="text/css" rel="Stylesheet" href="../Style/GridViewStyle.css" />
    <link type="text/css" rel="Stylesheet" href="../Style/TopBottomLoyout.css" />
</head>
<body>
    <form id="form1" runat="server">
    <h2>
        聯絡我們</h2>
    如有任何疑問，請聯絡我們。
    <div class="div_top_bottom">
        <asp:GridView ID="grvContacter_List" runat="server" AutoGenerateColumns="False" CellPadding="4"
            GridLines="Vertical" Width="100%" CssClass="GridViewStyle"
            AllowPaging="True" EmptyDataText="無公告資料">
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <RowStyle CssClass="GridViewRowStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Center" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <FooterStyle CssClass="GridViewFooterStyle" />
            <Columns>
                <asp:BoundField HeaderText="聯絡人" DataField="Contacter">
                    <HeaderStyle Width="35%" />
                </asp:BoundField>
                <asp:BoundField HeaderText="信箱" DataField="Mail">
                    <ItemStyle Font-Size="10pt" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
