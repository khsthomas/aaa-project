<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TreeViewControl.ascx.cs" Inherits="TSAControl.TreeViewControl" %>
<script language="javascript" type="text/javascript">
    function postBackByObject()
    {
        var o = window.event.srcElement;
        if (o.tagName == "INPUT" && o.type == "checkbox")
        {
            if (varUpdatePanel_ClientID != "" && varUpdatePanel_ClientID != null)
                __doPostBack(varUpdatePanel_ClientID, "");
            else
                __doPostBack("", "");
        }
    }
</script>

<asp:Label ID="lbMessage" runat="server" Visible="False" Font-Size="10pt" ForeColor="Red" />
<asp:TreeView ID="trvControl" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" ForeColor="Black" onclick="postBackByObject();"
    OnSelectedNodeChanged="trvControl_SelectedNodeChanged" OnTreeNodeCheckChanged="trvControl_TreeNodeCheckChanged"
    OnTreeNodeExpanded="trvControl_TreeNodeExpanded">
    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
    <SelectedNodeStyle BackColor="#B5B5B5" HorizontalPadding="0px" VerticalPadding="0px" />
    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="3px" VerticalPadding="2px" />
</asp:TreeView>
<script language="javascript" type="text/javascript">
    var varUpdatePanel_ClientID = '<%= strUpdatePanelID %>';
</script>