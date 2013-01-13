<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calculator.ascx.cs" Inherits="YEZZ.Components.Calculator" %>
<script type="text/javascript">
<!--
    function insertAtCursor(elementRefId, valueToInsert) {
        var elementRef = document.getElementById(elementRefId);

        if (elementRef == null)
            return;
             
        if ( document.selection )
        {
            // Internet Explorer...

            elementRef.focus();
            var selectionRange = document.selection.createRange();
            selectionRange.text = valueToInsert;
        }
        else if ( (elementRef.selectionStart) || (elementRef.selectionStart == '0') ) 
        {
            // Mozilla/Netscape...

            var startPos = elementRef.selectionStart;
            var endPos = elementRef.selectionEnd;
            elementRef.value = elementRef.value.substring(0, startPos) +
            valueToInsert + elementRef.value.substring(endPos, elementRef.value.length);
        } 
        else 
        {
            elementRef.value += valueToInsert;
        }
    }
// -->
</script>

<asp:Panel ID=pnlCalculator runat="server">

     <table align="center">
        <tr>
            <td colspan="5"><asp:TextBox ID="txtFormula" runat="server" Width="100%"></asp:TextBox></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>區域別</td>
            <td><asp:DropDownList ID="ddlArea" runat="server"></asp:DropDownList></td>
            <td>數值別</td>
            <td><asp:DropDownList ID="ddlValueType" runat="server"></asp:DropDownList></td>                    
            <td><asp:Button ID="btnInsert" runat="server" Text="Insert" onclick="btnInsert_Click"/></td>
            <td colspan="2"><asp:Button ID="btnPlus" runat="server" Text="+" onclick="btnPlus_Click"/>
            <asp:Button ID="btnMinus" runat="server" Text="-" onclick="btnMinus_Click"/>
            <asp:Button ID="btnMultiple" runat="server" Text="*" onclick="btnMultiple_Click"/>
            <asp:Button ID="btnDivide" runat="server" Text="/" onclick="btnDivide_Click"/>
        </tr>
     </table>

</asp:Panel>