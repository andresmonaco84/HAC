<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <link href="css/Styles.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td style="height: 150px">
                </td>
            </tr>
        </table>
        <table align="center" cellspacing="2" cellpadding="2" >
            <tr>
                <td style="text-align: center">
                    <table cellspacing="2" cellpadding="0" width="200" border="0">
                        <tr>
                            <td align="center" class="label" colspan="2" style="font-weight: bold; color: white;">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/sgs.gif" /></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; color: white; background-color: blue" class="label"
                                align="center" colspan="2">
                                Prontuário Eletrônico P.S.</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="text-align: center; height: 5px">
                            </td>
                        </tr>
                        <tr>
                            <td class="label" align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUsuario">Usuário:&nbsp;</asp:Label></td>
                            <td align="left">
                                <asp:TextBox ID="txtUsuario" runat="server" Width="170px" MaxLength="20" CssClass="textboxBranco"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" SetFocusOnError="True"
                                    ValidationGroup="logLogin" ToolTip="Usuário é obrigatório." ErrorMessage="Usuário é obrigatório."
                                    ControlToValidate="txtUsuario">*</asp:RequiredFieldValidator>
                                &nbsp;&nbsp;
                                <asp:ImageButton ID="btnHelp" runat="server" ImageUrl="~/Img/interrogacao.png" height="25px"  OnClientClick="abreHelp(); return false;" AlternateText="Ajuda" ToolTip="Ajuda" />
                            </td>
                        </tr>
                        <tr>
                            <td class="label" align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtSenha">Senha:&nbsp;</asp:Label></td>
                            <td align="left">
                                <asp:TextBox ID="txtSenha" runat="server" Font-Size="0.8em" CssClass="textboxBranco"
                                    TextMode="Password" MaxLength="12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" SetFocusOnError="True"
                                    ValidationGroup="logLogin" ToolTip="Senha é obrigatória." ErrorMessage="Senha é obrigatória."
                                    ControlToValidate="txtSenha">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="text-align: center; height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="text-align: center">
                                <asp:Button ID="btnCriar" runat="server" CssClass="button" OnClick="btnCriar_Click" Text="Criar Usuário" ValidationGroup="logLogin" Width="100px" />&nbsp;
                                <asp:Button ID="btnAlterar" runat="server" CssClass="button" OnClick="btnAlterar_Click" Text="Alterar Senha" ValidationGroup="logLogin" Width="100px" />&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" colspan="3">
                                &nbsp;</td>
                        </tr>
                          <tr>
                            <td align="center" colspan="3">
                               <asp:Label ID="lblMensagem" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                              
                        </tr>
                         <tr>
                            <td align="right" colspan="3">
                                </td>
                        </tr>
                            <tr>
                            <td align="center" colspan="3" style="text-align: center; height: 5px">
                            </td>
                        </tr>
                          <tr>
                            <td align="center" colspan="3" style="text-align: center; height: 5px">
                            </td>
                        </tr>
                         <tr>
                            <td style="font-weight: bold; color: white; background-color: green" class="label"
                                align="center" colspan="2">
                                SGS Web - Internação - Faturamento</td>
                        </tr>
                          <tr>
                            <td align="center" colspan="3" style="text-align: center; height: 5px">
                            </td>
                        </tr>
                        <tr>
                            <td class="label" align="right">
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="txtUsuario">Usuário:&nbsp;</asp:Label></td>
                            <td align="left">
                                <asp:TextBox ID="txtSGSUsuario" runat="server" Width="170px" MaxLength="20" CssClass="textboxBranco"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="True"
                                    ValidationGroup="logSGSLogin" ToolTip="Usuário é obrigatório." ErrorMessage="Usuário é obrigatório."
                                    ControlToValidate="txtSGSUsuario">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="label" align="right">
                                <asp:Label ID="Label2" runat="server" AssociatedControlID="txtSenha">Senha:&nbsp;</asp:Label></td>
                            <td align="left">
                                <asp:TextBox ID="txtSGSSenha" runat="server" Font-Size="0.8em" CssClass="textboxBrancoA" MaxLength="12" Value="hac123" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="True"
                                    ValidationGroup="logSGSLogin" ToolTip="Senha é obrigatória." ErrorMessage="Senha é obrigatória."
                                    ControlToValidate="txtSGSSenha">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="text-align: center; height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="text-align: center">
                                <asp:Button ID="btnSGSCriarUsuario" runat="server" CssClass="button"  Visible="false" Text="Criar Usuário" ValidationGroup="logSGSLogin" Width="100px" />&nbsp;
                                <asp:Button ID="btnSGSAlterarSenha" runat="server" CssClass="button"  Text="Alterar Senha" ValidationGroup="logSGSLogin" Width="100px" OnClick="btnSGSAlterarSenha_Click" />&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" colspan="3">
                                &nbsp;</td>
                        </tr>
             <tr>
                            <td align="center" colspan="3">
                               <asp:Label ID="lblSGSMensagem" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                              
                        </tr>
                    </table>
                  
                    </td>

                <td style="text-align: center"  width="455">
     

                       <table cellspacing="2" cellpadding="0" width="450" style="border-collapse: collapse;" border="1"  id="tbHelp" >
                             <tr style="font-weight: bold; color: white; background-color: black" class="label" align="center" colspan="2">
                                 <td colspan="2">Help</td>
                                 </tr>
                            <tr style="height:30px">
                            <td align="center" class="label"  colspan="2" style="font-weight: bold">
                                <asp:Label ID="Label4" runat="server" > Seguir o padrão abaixo para cadastro de usuário e reset de senhas no PE:
                                    </asp:Label>
                            </td>
                            
                            </tr>
                        <tr style="height:30px">
                            <td align="center" class="label"  >
                                <asp:Label ID="Label3" runat="server" > Usuário PE Médicos (CRM)
                                    </asp:Label>
                            </td>
                             <td align="center" class="label"   >
                                <asp:Label ID="Label11" runat="server" > nº do conselho (ex.: 123456)
                                </asp:Label>
                              </td>
                            </tr>
                        <tr style="height:30px">
                            <td align="center" class="label"  >
                                <asp:Label ID="Label5" runat="server" > Usuário PE Buco Maxilo (CRO)</asp:Label>
                            </td>
                              <td align="center" class="label"  >
                                <asp:Label ID="Label12" runat="server" > nº do conselho + O (ex.: 123456O)
                                </asp:Label>
                            </td>
                        </tr>
                        <tr style="height:30px">
                            <td align="center" class="label"  >
                                <asp:Label ID="Label6" runat="server" > Usuário PE Nutricionista/Fono/Psicologo</asp:Label>
                            </td>
                             <td align="center" class="label"  >
                                <asp:Label ID="Label9" runat="server" > nº do conselho + N ou FA ou P (ex.: 123456N, ex.: 123456FA, ex.: 123456P) </asp:Label>
                            </td>
                        </tr>
                        <tr style="height:30px">
                            <td align="center" class="label"  >
                                <asp:Label ID="Label7" runat="server" > Senha para todos</asp:Label>
                            </td>
                             <td align="center" class="label"  >
                                <asp:Label ID="Label10" runat="server" > nº do conselho</asp:Label>
                            </td>
                       <%-- </tr>
                            <tr style="height:60px">
                            <td align="center" class="label"  >
                                <asp:Label ID="Label4" runat="server" ></asp:Label>
                            </td>
                             <td align="center" class="label"  >
                                <asp:Label ID="Label8" runat="server" ></asp:Label>
                            </td>
                        </tr>
                            <tr style="height:20px">
                            <td align="center" class="label" colspan="2" >
                                <asp:Label ID="Label13" runat="server" visible="false"> Após alterar a senha no SGS, o sistema irá pedir a troca de senha.</asp:Label>
                            </td>
                           
                        </tr>--%>
                      
                     </table>
                </td>
            </tr>
            
        </table>
        <asp:ValidationSummary ID="vdsValidacao" runat="server" DisplayMode="BulletList"
            EnableClientScript="true" ShowMessageBox="true" ShowSummary="false" ValidationGroup="logLogin" />
    </form>

    
<script type="text/javascript">
 
    window.onload = function () {
        document.getElementById("tbHelp").style.display = "none";
    };
        
    
    function abreHelp() {
        var x = document.getElementById("tbHelp");
        if (x.style.display === "none") {
            x.style.display = "block";
        } else {
            x.style.display = "none";
        }
    }
</script>
</body>
</html>

