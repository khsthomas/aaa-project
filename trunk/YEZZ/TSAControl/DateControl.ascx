<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateControl.ascx.cs" Inherits="APPGISMS.TSAControl.DateControl" %>
<asp:DropDownList ID="ddlDate_Year" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDate_Year_SelectedIndexChanged" />
<asp:DropDownList ID="ddlDate_Month" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDate_Month_SelectedIndexChanged" />
<asp:DropDownList ID="ddlDate_Day" runat="server" Enabled="False" />