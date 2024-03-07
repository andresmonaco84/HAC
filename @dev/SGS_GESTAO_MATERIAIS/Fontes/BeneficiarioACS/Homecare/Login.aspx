<%@ Page Language="C#" AutoEventWireup="True" Codebehind="Login.aspx.cs" Inherits="Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="css/Styles.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table>
            <tr>
                <td style="height: 150px">
                </td>
            </tr>
        </table>
        <table align="center" cellspacing="0" cellpadding="2" border="1">
            <tr>
                <td>
                    <table cellspacing="2" cellpadding="0" width="250" border="0">
                        <tr>
                            <td style="font-weight: bold; color: white; background-color: green" class="label"
                                align="center" colspan="2">
                                Log In - Beneficiários ACS</td>
                        </tr>
                        <tr>
                            <td class="label" align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário:&nbsp;</asp:Label></td>
                            <td align="left">
                                <asp:TextBox ID="UserName" runat="server" Width="170px" MaxLength="20" CssClass="textboxBranco"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" SetFocusOnError="True"
                                    ValidationGroup="logLogin" ToolTip="Usuário é obrigatório." ErrorMessage="Usuário é obrigatório."
                                    ControlToValidate="UserName">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="label" align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:&nbsp;</asp:Label></td>
                            <td align="left">
                                <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" CssClass="textboxBranco"
                                    TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" SetFocusOnError="True"
                                    ValidationGroup="logLogin" ToolTip="Senha é obrigatória." ErrorMessage="Senha é obrigatória."
                                    ControlToValidate="Password">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="text-align: right">
                                <asp:CheckBox ID="RememberMe" runat="server" Text="Lembrar usuário da próxima vez" Checked="True">
                                </asp:CheckBox>
                            </td>
                        </tr>                        
                        <tr>
                            <td align="right" colspan="3">
                                <asp:Button ID="LoginButton" runat="server" BorderWidth="1px" ForeColor="Green" Font-Size="0.8em"
                                    Font-Names="Verdana" BorderStyle="Solid" BorderColor="#C5BBAF" BackColor="White"
                                    ValidationGroup="logLogin" Text="Log In" CommandName="Login" OnClick="LoginButton_Click"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="vdsValidacao" runat="server" DisplayMode="BulletList"
        EnableClientScript="true" ShowMessageBox="true" ShowSummary="false" ValidationGroup="logLogin" />
    </form>
</body>
</html>
