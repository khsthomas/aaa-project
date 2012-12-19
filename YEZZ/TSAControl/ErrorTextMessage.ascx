<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ErrorTextMessage.ascx.cs" Inherits="TSAControl.ErrorTextMessage" %>
<asp:UpdatePanel ID="upErrorMessage" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" ReadOnly="True" Text = "錯誤訊息顯示區"></asp:TextBox>
    </ContentTemplate>
</asp:UpdatePanel>