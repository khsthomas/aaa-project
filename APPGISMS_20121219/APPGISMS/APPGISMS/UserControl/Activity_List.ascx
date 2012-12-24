<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Activity_List.ascx.cs"
    Inherits="APPGISMS.UserControl.Activity_List" %>
<link type="text/css" rel="Stylesheet" href="../Style/UserGridViewStyle.css" />
<link type="text/css" rel ="Stylesheet" href="../Style/DialogStyle.css" />

<asp:UpdatePanel ID="upActivity_List" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <%-- <div class="GridViewTitleStyle">
            活動訊息</div>--%>
        <asp:GridView ID="grvActivity_List" runat="server" AutoGenerateColumns="False" Width="100%" 
            CssClass="GridViewStyle" EmptyDataText="無活動訊息" AllowPaging="True" 
            DataKeyNames="ACTIVITY_SN" PageSize="15" OnPageIndexChanging="grvActivity_List_PageIndexChanging"
            OnRowCommand="grvActivity_List_RowCommand" OnRowDataBound="grvActivity_list_RowDataBound">
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <RowStyle CssClass="GridViewRowStyle" Height="30px" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" Height="30px" />
            <PagerStyle HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <Columns>
                <asp:BoundField DataField="ACTIVITY_DATE" HeaderText="活動期間">
                    <HeaderStyle Width="35%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="活動名稱">
                    <HeaderStyle Width="35%" />
                    <ItemTemplate>
                        <asp:LinkButton ID="grv_lbSubject" runat="server" Text='<%# Bind("ACTIVITY_NAME") %>'
                            CommandName="Content" CommandArgument='<%# Bind("ACTIVITY_SN") %>' CausesValidation="False" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="承辦人" DataField="ORGANIZER_NAME" />
                <asp:BoundField HeaderText="活動狀態" DataField="ACTIVITY_STATE" > <HeaderStyle Width="10%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="報名">
                  <HeaderStyle Width="10%" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lbRegis_sts" runat="server" Text='<%# Bind("REGISTRATION_STATE") %>'
                            Visible="false"></asp:Label>
                        <asp:Button ID="btnRegis" runat="server" Text="線上報名" CommandName="btnRegis_Click" CommandArgument='<%# Bind("ACTIVITY_SN") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="upContent" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="panContent_Title" runat="server" Visible="False" Width="100%" CssClass="DetailsViewHeaderStyle">
            活動概述</asp:Panel>
        <asp:DetailsView ID="dtAnncoune" runat="server" AutoGenerateRows="False" CssClass="DetailsViewStyle"
            Width="100%" OnDataBound="dtActivity_List_DataBound" 
            onitemcommand="getActivity_ListContent_ItemCommand">
            <FieldHeaderStyle CssClass="DetailsViewFieldHeaderStyle" />
            <RowStyle CssClass="DetailsViewRowStyle" Height="30px" />
            <AlternatingRowStyle CssClass="DetailsViewAlternatingRowStyle" />
            <HeaderStyle CssClass="DetailsViewFieldHeaderStyle" />
            <Fields>
                <asp:TemplateField HeaderText="活動名稱">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server"  Text='<%# Bind("ACTIVITY_NAME") %>'></asp:Label>
                        <asp:LinkButton ID="lbtnActivity_Name" runat="server" CausesValidation="false"  Text ="活動詳細"  Font-Bold ="true" 
                        CommandArgument='<%# Bind("ACTIVITY_SN") %>'  CommandName ="Activity" ForeColor="Red"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="活動期間" DataField="ACTIVITY_DATE" HeaderStyle-Width = "100px"/>
                <asp:BoundField HeaderText="活動內容" DataField="ACTIVITY_CONTENT" HeaderStyle-Width = "100px" />
                <asp:BoundField HeaderText="活動狀態" DataField="ACTIVITY_STATE" HeaderStyle-Width = "100px" />
                <asp:BoundField HeaderText="承辦人" DataField="ORGANIZER_NAME" HeaderStyle-Width = "100px"/>
                <asp:BoundField HeaderText="報名期間" DataField="APPLY_TIME" HeaderStyle-Width = "100px"/>
                <asp:BoundField HeaderText="活動對象" DataField="ACTIVITY_TYPE_INFO" HeaderStyle-Width = "100px"/>
                <asp:BoundField HeaderText="報名方式" DataField="REGISTRATION_MODE" HeaderStyle-Width = "100px"/>
                <asp:BoundField HeaderText="報名人數" DataField="REGISTRATION_NUMBER" HeaderStyle-Width = "100px"/>
                <asp:BoundField HeaderText="活動電話" DataField="ACTIVITY_TEL" HeaderStyle-Width = "100px"/>
                <asp:BoundField HeaderText="活動信箱" DataField="ACTIVITY_MAIL" HeaderStyle-Width = "100px"/>
                <asp:TemplateField HeaderText="簡章下載">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnFile" runat="server" CausesValidation="false" 
                            CommandArgument='<%# Bind("ATTACH_NAME") %>'  Text='<%# Bind("FILE_ATTACH") %>' CommandName ="File"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
        </asp:DetailsView>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="grvActivity_List" EventName="RowCommand" />
        <asp:PostBackTrigger ControlID="dtAnncoune" />
    </Triggers>
</asp:UpdatePanel>
