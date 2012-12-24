<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextBoxExtender.ascx.cs" Inherits="TSAControl.TextBoxExtender" %>
<script language="javascript" type="text/javascript">
    var varSubmitButton = '<%= strSubmit_Button_ID %>';
    function TextBoxInputEnter()
    {
        if (event.keyCode == 13)
        {
            __doPostBack(varSubmitButton, '');
        }
    }
</script>