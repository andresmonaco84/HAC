<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<%@ Register Assembly="HacControlsExtender" Namespace="HacControlsExtender" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link rel="stylesheet" href="css/StyleSheet.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="50">
        <ProgressTemplate>
                            <div class="updateProgressInnerDiv">
        </div>
        <div class="updateProgressBoxAguarde">
            <div id="pnlPopup" class="progress" >
	
                <div class="container">
                    <div class="headerProgress">Aguarde...</div>
                    <div class="bodyProgress">
                        <img src="images/activity.gif" />
                    </div>
                </div>
            </div>
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>
        <cc1:updateprogressoverlayextender id="UpdateProgressOverlayExtender1" runat="server"
            targetcontrolid="UpdateProgress1" cssClass="updateProgress"></cc1:updateprogressoverlayextender>
    </form>
</body>
</html>
