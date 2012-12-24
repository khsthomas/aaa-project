<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Dialog.ascx.cs" Inherits="APPGISMS.DialogControl.Dialog" %>
<asp:Label ID="lbDialog" runat="server" Width="200px" />
<asp:Button ID="btnDialog" runat="server" Text="..." />
<asp:LinkButton ID="lbtnClear" runat="server" Visible="False" Text="清空" Font-Size="10pt" OnClick="lbtnClear_Click" />
<asp:Label ID="lbDialog_Must" runat="server" Text="(必選)" Font-Size="10pt" ForeColor="Red" Visible="False" />
<AjaxCTLToolkit:ModalPopupExtender ID="mpeDialog" runat="server" TargetControlID="btnDialog"  BackgroundCssClass="DialogBackGround" />
<asp:Label ID="lbReturnValue" runat="server" Visible="False" />
<asp:Label ID="lbReturnText" runat="server" Visible="False" />