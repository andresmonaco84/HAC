<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default5.aspx.cs" Inherits="Default5" %>

<%@ Register Assembly="HacAjaxControlsExtender" Namespace="HacAjaxControlsExtender"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
        <link rel="stylesheet" href="css/StyleSheet.css" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <cc1:LoadingPageExtender ID="HacLoadingPageExtender1" runat="server" LoadingDiv="carregando"  />        
    <div>
            
    <div id="carregando" style="width:98%">
        <div class="updateProgressBoxAguarde" style="width:98%">
            <div id="pnlPopup" class="progress">
	
                <div class="container">
                    <div class="headerProgress">Aguarde...</div>
                    <div class="bodyProgress">
                        <img src="images/activity.gif" />
                    </div>
                </div>
            </div>
            </div>
            </div>

    </div>


    <img src="http://lh3.google.com.br/holdack182/RyUvFdkE7jI/AAAAAAAAAD0/xRvPWCngarY/Interlagos-21-10-2007-A%20102.jpg?imgmax=512" alt="" />

    </form>
    
</body>
</html>
