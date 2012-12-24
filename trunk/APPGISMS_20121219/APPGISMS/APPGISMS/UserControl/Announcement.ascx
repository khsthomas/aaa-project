<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Announcement.ascx.cs" Inherits="APPGISMS.UserControl.Announcement" %>

<asp:UpdatePanel ID="upAnnounce" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:GridView ID="grvAnnounce" runat="server" AutoGenerateColumns="False" Width="100%"
            CssClass="GridViewStyle" EmptyDataText="無公告事項" BorderWidth="0"  
            AllowPaging="True" ShowHeader="False" PageSize="5" 
            OnPageIndexChanging="grvAnnounce_PageIndexChanging" OnRowCommand="grvAnnounce_RowCommand">
            <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <RowStyle Height="30px" CssClass="GridViewRowStyle"  BorderWidth="0"/>                                        
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" BorderWidth="0"/>
                    <EmptyDataRowStyle  Height="30px" CssClass="GridViewEmptyDataRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Center" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <FooterStyle CssClass="GridViewFooterStyle" />                 
            
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img src="../Images/Index/icon1.gif" /><asp:LinkButton ID="grv_lbSubject" runat="server" Text='<%# Bind("ANNOUNCE_SUBJECT") %>'
                            CommandName="Content" CommandArgument='<%# Bind("ANNOUNCE_ID") %>' CausesValidation="False" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CREATE_DATE"  DataFormatString="{0:d}">
                    <HeaderStyle Width="25%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
<hr style="width:400px;" />
<asp:UpdatePanel ID="upContent" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>      
        <asp:Panel ID="panContent_Title" runat="server" Visible="False" class="ResultTitle">
            公告內容</asp:Panel>
        <asp:DataList ID="dlAnncoune" runat="server" 
            GridLines="Both" RepeatColumns="1" 
            RepeatDirection="Horizontal" OnItemDataBound = "Item_Bound"
            Width="100%" HorizontalAlign="Center" BorderStyle="Solid" 
            BorderWidth="1px" BorderColor="#7B9623">
            <SelectedItemStyle Font-Bold="True"> 
            </SelectedItemStyle>
            <ItemTemplate>                        
                <table cellpadding="1" cellspacing="2" border="0" width="100%" style="height:22px; line-height:22px; padding-top:3px;">
                      <tr>
                        <td align="left" style="font-size:15px; background-color:#F0F4EC; font-weight:bolder; padding:5px 0;">
                            <asp:Label id="lbAnnounce_Sub" runat="server"  Text='<%# Bind("ANNOUNCE_SUBJECT") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label id="lbAnnounce_Content" runat="server" Text='<%# Bind("ANNOUNCE_CONTENT") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
     
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="grvAnnounce" EventName="RowCommand" />
    </Triggers>
</asp:UpdatePanel>
