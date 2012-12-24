<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Activ_Announce.ascx.cs"
    Inherits="APPGISMS.UserControl.Activ_Announce" %>
<asp:UpdatePanel ID="upActiv_Announce" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:GridView ID="grvActiv_Announce" runat="server" AutoGenerateColumns="False" Width="100%"
            CssClass="GridViewStyle" EmptyDataText="無公告事項" AllowPaging="True"
            PageSize="5" OnPageIndexChanging="grvActiv_Announce_PageIndexChanging" OnRowCommand="grvActiv_Announce_RowCommand">
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <RowStyle CssClass="GridViewRowStyle" Height="30px" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" Height="30px" />
            <PagerStyle HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <Columns>
                <asp:BoundField DataField="CREATE_DATE" HeaderText="公告日期" DataFormatString="{0:d}">
                    <HeaderStyle Width="25%" />
                    <ItemStyle HorizontalAlign="Center"  />
                </asp:BoundField>
                <asp:TemplateField HeaderText="公告主旨" HeaderStyle-HorizontalAlign ="Left" >
                    <ItemTemplate>
                        <asp:LinkButton ID="grv_lbSubject" runat="server" Text='<%# Bind("T_ANNOUNCEMENT_OBJECT") %>'
                            CommandName="Content" CommandArgument='<%# Bind("ANNOUNCEMENT_ID") %>' CausesValidation="False" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>  
<br />

<asp:UpdatePanel ID="upContent" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
         <asp:Panel ID="panContent_Title" runat="server" Visible="False" class="ResultTitle" >
            公告內容</asp:Panel>
        <asp:DetailsView ID="dtAnncoune" runat="server" AutoGenerateRows="False" CssClass="DetailsViewStyle"
            Width="100%" Style="border:solid 1px #7B9623; padding:5px 4px;" OnDataBound="dtActiv_Announce_DataBound">
            <FieldHeaderStyle CssClass="DetailsViewFieldHeaderStyle" BorderColor="#7B9623" BorderStyle="Solid" BorderWidth="1px" />
            <RowStyle CssClass="DetailsViewRowStyle" Height="30px"  BorderColor="#7B9623" BorderStyle="Solid" BorderWidth="1px" />
            <AlternatingRowStyle CssClass="DetailsViewAlternatingRowStyle"  />
            <HeaderStyle CssClass="DetailsViewHeaderStyle" />
            <Fields>
                <asp:BoundField HeaderText="公告主旨" DataField="ANNOUNCEMENT_OBJECT">
                <HeaderStyle Width="120px" BorderColor="#7B9623" BorderStyle="Solid" BorderWidth="0px" /> 
                 <ItemStyle Width ="400px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="活動名稱" DataField="ACTIVITY_NAME">
                 <HeaderStyle Width="120px" BorderColor="#7B9623" BorderStyle="Solid" BorderWidth="0px" /> 
                <ItemStyle Width ="400px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="公告日期" DataField="CREATE_DATE" DataFormatString="{0:d}">
                 <HeaderStyle Width="120px" BorderColor="#7B9623" BorderStyle="Solid" BorderWidth="0px" /> 
                <ItemStyle Width ="400px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="公告內容" DataField="ANNOUNCEMENT_CONTENT">
              <HeaderStyle Width="120px" BorderColor="#7B9623" BorderStyle="Solid" BorderWidth="0px" /> 
                    <ItemStyle Height="80px" Width ="400px" />
                </asp:BoundField>
            </Fields>
        </asp:DetailsView>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="grvActiv_Announce" EventName="RowCommand" />
    </Triggers>
</asp:UpdatePanel>
