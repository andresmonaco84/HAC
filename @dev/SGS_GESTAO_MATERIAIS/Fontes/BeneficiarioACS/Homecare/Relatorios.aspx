<%@ Page Language="C#" AutoEventWireup="True" Codebehind="Relatorios.aspx.cs" Inherits="Relatorios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BENEFICIÁRIOS INTERNAÇÃO DOMICILIAR</title>
    <link href="css/Styles.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">         
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <AjaxControlToolkit:ToolkitScriptManager EnableScriptGlobalization="true" EnableScriptLocalization="True"
            ID="ToolkitScriptManager1" runat="server">
        </AjaxControlToolkit:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table align="center" style="border-right: green thin solid; border-top: green thin solid;
                        border-left: green thin solid; border-bottom: green thin solid; font-family: 'Courier New'"
                        width="800">
                        <tr>
                            <td>
                                <table style="width: 100%" align="center">
                                    <tr>
                                        <td align="center" colspan="4" style="width: 100%; height: 50px; background-color: Green;"
                                            valign="middle">
                                            <strong><font color="white" size="3">BENEFICIÁRIOS INTERNAÇÃO DOMICILIAR</font></strong></td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="4" style="width: 100%; background-color: #dcdcdc">
                                            <asp:Button ID="btnVoltar" runat="server" CssClass="button" OnClick="btnVoltar_Click"
                                                Text="Voltar" Width="70px" CausesValidation="False" /></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 5px; text-align: center">
                                            <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Size="Medium" Font-Underline="True">Relatórios</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbGeral" Font-Bold="true" runat="server" GroupName="TipoRelatorio"
                                                Text="Geral Analítico Ordenado Pela Data" Checked="True" />
                                            <br>
                                            <asp:RadioButton ID="rbMedicamento" Font-Bold="true" runat="server" GroupName="TipoRelatorio"
                                                Text="Medicamentos Utilizados no Período (Sintético)" />
                                            <br>
                                            <asp:RadioButton ID="rbMaterial" Font-Bold="true" runat="server" GroupName="TipoRelatorio"
                                                Text="Materiais Utilizados no Período (Sintético)" /></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlRelatorio" runat="server" Width="100%">
                                                <table cellpadding="2" style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid;
                                                    border-left: #dcdcdc thin solid; border-bottom: #dcdcdc thin solid; width: 100%;">
                                                    <tr>
                                                        <td colspan="3">
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 50px">
                                                                        Estado</td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlUF" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUF_SelectedIndexChanged"
                                                                            ValidationGroup="Cadastro" Width="100px">
                                                                        </asp:DropDownList></td>
                                                                    <td style="width: 50px; text-align: right;">
                                                                        Cidade</td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlCidade" runat="server" ValidationGroup="Cadastro" Width="220px">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCidade"
                                                                            Display="Dynamic" ErrorMessage="Preencha a Cidade" SetFocusOnError="True" Text=" * "
                                                                            ValidationGroup="Cidade"></asp:RequiredFieldValidator></td>
                                                                    <td>
                                                                        &nbsp;
                                                                        <asp:Button ID="btnPacientesCidade" runat="server" CssClass="button" OnClick="btnPacientesCidade_Click"
                                                                            Text="Pacientes por Cidade" Width="130px" ValidationGroup="Cidade" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap>
                                                            <strong>Período De</strong>
                                                        </td>
                                                        <td style="width: 200px; text-align: left" nowrap>
                                                            <asp:TextBox ID="txtDataDe" ValidationGroup="Relatorio" runat="server" Width="70px"
                                                                CssClass="textboxBranco" MaxLength="10"></asp:TextBox><AjaxControlToolkit:MaskedEditExtender
                                                                    ID="meeDataDe" runat="server" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="false"
                                                                    Mask="99/99/9999" MaskType="Date" CultureName="pt-BR" MessageValidatorTip="false"
                                                                    TargetControlID="txtDataDe">
                                                                </AjaxControlToolkit:MaskedEditExtender>
                                                            <AjaxControlToolkit:MaskedEditValidator ValidationGroup="Relatorio" ID="mevDataDe"
                                                                runat="server" ControlExtender="meeDataDe" ControlToValidate="txtDataDe" Display="Dynamic"
                                                                EmptyValueBlurredText=" * " EmptyValueMessage="Preencha a Data Início do Período"
                                                                InvalidValueBlurredMessage=" * " InvalidValueMessage="Data Início do Período Inválida"
                                                                IsValidEmpty="false" SetFocusOnError="True" ErrorMessage="*" MaximumValue="31/12/2077"
                                                                MaximumValueBlurredMessage="*" MaximumValueMessage="Ano da Data Início do Período deve ser inferior a 2078"
                                                                MinimumValue="1/1/1900" MinimumValueBlurredText="*" MinimumValueMessage="Ano da Data Início do Período deve ser superior a 1899"></AjaxControlToolkit:MaskedEditValidator>
                                                            <strong>a</strong>
                                                            <asp:TextBox ID="txtDataAte" ValidationGroup="Relatorio" runat="server" Width="70px"
                                                                CssClass="textboxBranco" MaxLength="10"></asp:TextBox><AjaxControlToolkit:MaskedEditExtender
                                                                    ID="meeDataAte" runat="server" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="false"
                                                                    Mask="99/99/9999" MaskType="Date" CultureName="pt-BR" MessageValidatorTip="false"
                                                                    TargetControlID="txtDataAte">
                                                                </AjaxControlToolkit:MaskedEditExtender>
                                                            <AjaxControlToolkit:MaskedEditValidator ValidationGroup="Relatorio" ID="mevDataAte"
                                                                runat="server" ControlExtender="meeDataAte" ControlToValidate="txtDataAte" Display="Dynamic"
                                                                EmptyValueBlurredText=" * " EmptyValueMessage="Preencha a Data do Término do Período"
                                                                InvalidValueBlurredMessage=" * " InvalidValueMessage="Data do Término do Período Inválida"
                                                                IsValidEmpty="false" SetFocusOnError="True" ErrorMessage="*" MaximumValue="31/12/2077"
                                                                MaximumValueBlurredMessage="*" MaximumValueMessage="Ano da Data do Término do Período deve ser inferior a 2078"
                                                                MinimumValue="1/1/1900" MinimumValueBlurredText="*" MinimumValueMessage="Ano da Data do Término do Período deve ser superior a 1899"></AjaxControlToolkit:MaskedEditValidator>
                                                        </td>
                                                        <td style="width: 100%; text-align: left">
                                                            <asp:Button ID="btnGerarRelat" runat="server" CssClass="button" OnClick="btnGerarRelat_Click"
                                                                Text="Gerar Relatório" Width="100px" ValidationGroup="Relatorio" /></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:ValidationSummary ID="vdsValidacao" runat="server" DisplayMode="BulletList"
                    EnableClientScript="true" ShowMessageBox="true" ValidationGroup="Cidade" ShowSummary="false" />
                <asp:ValidationSummary ID="vdsValidacaoRelatorio" runat="server" DisplayMode="BulletList"
                    EnableClientScript="true" ShowMessageBox="true" ValidationGroup="Relatorio" ShowSummary="false" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="50">
            <ProgressTemplate>
                <div class="updateProgressInnerDiv">
                </div>
                <div class="updateProgressBoxAguarde">
                    <asp:Image ID="imgAguarde" runat="server" ImageUrl="~/Img/img_aguarde.gif" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
