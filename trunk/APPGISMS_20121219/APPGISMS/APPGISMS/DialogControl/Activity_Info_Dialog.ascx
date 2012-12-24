<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Activity_Info_Dialog.ascx.cs" Inherits="APPGISMS.DialogControl.Activity_Info_Dialog" %>

<asp:Panel ID="panDialog" runat="server" Style="display: none;">
    <AjaxCTLToolkit:RoundedCornersExtender ID="rceBrand_Info" runat="server" TargetControlID="panDialogWindow"
        BorderColor="#7B9623" Radius="12" />
    <asp:Panel ID="panDialogWindow" runat="server" Width="650px" Height="395px" CssClass="DialogWindow">
        <div class="DialogTitle">
            <asp:Label ID="lbTitle" runat="server" Text="活動資訊" /></div>
        <asp:Panel ID="panDialogContent" runat="server" Height="320px" CssClass="DialogContent" ScrollBars ="Auto" >
            <asp:UpdatePanel ID="upBrand_Info" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                    <div class="DialogSearch" style="padding-bottom:10px;" >
                        查詢字串：
                        <asp:TextBox ID="txtAct_Info" runat="server" Width="250px" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
                        <AjaxCTLToolkit:TextBoxWatermarkExtender ID="wtxtPro_Info" runat="server" TargetControlID="txtAct_Info"
                            WatermarkText="可輸入活動名稱等資訊" WatermarkCssClass="WaterMaskStyle" />
                    </div>
                   
                    <div class="DialogData">
                        <asp:GridView ID="grvAct_Info" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            CellPadding="4" CssClass="GridViewStyle" PageSize="8" DataKeyNames="ACTIVITY_SN"
                            GridLines="Vertical" Width="100%" OnPageIndexChanging="grvAct_Info_PageIndexChanging">
                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                            <RowStyle CssClass="GridViewRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" />
                            <PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Center" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="選擇">
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:RadioButton ID="rbtChoose" runat="server" AutoPostBack="true" OnCheckedChanged="rbtChoose_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ACTIVITY_NAME" HeaderText="活動名稱" />
                                <asp:BoundField DataField="ORGANIZER_NAME" HeaderText="承辦單位" />
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="hfDialog" runat="server" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <div class="DialogButton">
            <asp:Button ID="btnChoose" runat="server" Text="選擇" UseSubmitBehavior="False" OnClick="btnChoose_OnClick" />
            <asp:Button ID="btnCancel" runat="server" Text="取消" />
        </div>
    </asp:Panel>
</asp:Panel>
