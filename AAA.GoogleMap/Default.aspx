<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AAA.GoogleMap._Default" %>

<%@ Register src="Component/GoogleMapPane.ascx" tagname="GoogleMapPane" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title></title>
</head>
<body>
    <form id="form1" runat="server">                       
    </form>        
    
    <uc1:GoogleMapPane ID="googleMap" runat="server" />
    
</body>
</html>
