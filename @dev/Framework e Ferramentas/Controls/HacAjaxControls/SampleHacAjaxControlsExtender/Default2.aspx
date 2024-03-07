<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="HacControlsExtender" Namespace="HacControlsExtender" TagPrefix="cc2" %>

<%@ Register Assembly="HacAjaxControlsExtender" Namespace="HacAjaxControlsExtender" TagPrefix="cc1" %>

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
        &nbsp;</div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel2" runat="server" GroupingText="Testes" Height="50px" Width="275px">
                    <asp:Button ID="btnPanel" runat="server" OnClick="btnPanel_Click" Text="Teste de Controle" /></asp:Panel>
                <input id="Button1" type="button" value="button" />
                <input id="Button2" type="button" value="button" /><br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                Carregando...<br />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <cc2:UpdateProgressOverlayExtender ID="UpdateProgressOverlayExtender1" runat="server"
            ControlToOverlayID="Panel2" CssClass="updateProgress" TargetControlID="UpdateProgress1" />
        
    </form>
</body>
</html>
