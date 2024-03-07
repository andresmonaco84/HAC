<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="_Default"    UICulture="auto" Culture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BENEFICIÁRIOS INTERNAÇÃO DOMICILIAR</title>
    <link href="css/Styles.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">         
    
    function ValidarPesquisa()
    {   
        if (document.getElementById("<%= this.txtMatriculaPesquisa.ClientID %>").value == "" &&
            document.getElementById("<%= this.txtNomePesquisa.ClientID %>").value == "")     
        {
            alert("Digite a Matrícula ou o Nome");
            document.getElementById("<%= this.txtMatriculaPesquisa.ClientID %>").focus();
            return false;
        }   
        if (document.getElementById("<%= this.txtMatriculaPesquisa.ClientID %>").value == "")
        {
            if (document.getElementById("<%= this.txtNomePesquisa.ClientID %>").value.length <= 4)
            {
                alert("Digite mais de 4 caracteres no campo Nome");
                document.getElementById("<%= this.txtNomePesquisa.ClientID %>").focus();
                return false; 
            }
        }        
        return true;         
    }  
    
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
                                        <td align="center" style="width: 100%; height: 50px; background-color: Green;"
                                            valign="middle">
                                            <strong><font color="white" size="3">BENEFICIÁRIOS INTERNAÇÃO DOMICILIAR</font></strong></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 100%; background-color: #dcdcdc">
                                            <asp:Button ID="btnNovo" runat="server" CssClass="button" Text="Novo" Width="80px"
                                                OnClick="btnNovo_Click" CausesValidation="False" />
                                            <asp:Button ID="btnPesquisar" runat="server" CssClass="button" Text="Pesquisar" Width="80px"
                                                OnClick="btnPesquisar_Click" CausesValidation="False" />
                                            <asp:Button ID="btnRelatorios" runat="server" CssClass="button" Text="Relatórios"
                                                Width="80px" OnClick="btnRelatorios_Click" CausesValidation="False" />
                                            <asp:Button ID="btnSair" runat="server" CssClass="button" Text="Sair" Width="80px"
                                                OnClick="btnSair_Click" CausesValidation="False" /></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 5px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 5px; text-align: center">
                                            <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Size="Medium" Font-Underline="True"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 5px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlForm" runat="server" HorizontalAlign="Center">
                                                <table width="100%" style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid;
                                                    border-left: #dcdcdc thin solid; border-bottom: #dcdcdc thin solid;">
                                                    <tr>
                                                        <td>
                                                            <table cellpadding="2" style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid;
                                                                border-left: #dcdcdc thin solid; border-bottom: #dcdcdc thin solid; width: 90%;">
                                                                <tr class="BarraTitulo">
                                                                    <td align="left" colspan="4" style="height: 5px; font-weight: bold">
                                                                        Identificação</td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Nome
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtNome" runat="server" MaxLength="50" Width="300px" ReadOnly="True"
                                                                            CssClass="textboxBranco"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" style="width: 70px">
                                                                        Dt. Nasc.</td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtDtNasc" runat="server" MaxLength="10" ReadOnly="True" Width="100px"
                                                                            CssClass="textboxBranco"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        RG</td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtRG" runat="server" MaxLength="50" ReadOnly="True" Width="100px"
                                                                            CssClass="textboxBranco"></asp:TextBox></td>
                                                                    <td align="left">
                                                                        CPF</td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtCPF" runat="server" MaxLength="50" ReadOnly="True" Width="100px"
                                                                            CssClass="textboxBranco"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Convênio</td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtConvenio" runat="server" MaxLength="50" ReadOnly="True" Width="300px"
                                                                            CssClass="textboxBranco"></asp:TextBox></td>
                                                                    <td align="left">
                                                                        Plano</td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtPlano" runat="server" MaxLength="10" ReadOnly="True" Width="50px"
                                                                            CssClass="textboxBranco"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Matrícula</td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtMatricula" runat="server" CssClass="textboxBranco" MaxLength="50"
                                                                            ReadOnly="True" Width="100px"></asp:TextBox></td>
                                                                    <td align="right" colspan="2">
                                                                        <asp:CheckBox ID="cbAtivo" runat="server" Font-Bold="True" Text="ATIVO" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellpadding="2" style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid;
                                                                border-left: #dcdcdc thin solid; border-bottom: #dcdcdc thin solid; width: 90%;">
                                                                <tr class="BarraTitulo">
                                                                    <td align="left" colspan="3" style="height: 5px; font-weight: bold">
                                                                        Endereço</td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" nowrap="nowrap">
                                                                    </td>
                                                                    <td align="left">
                                                                    </td>
                                                                    <td align="left" style="width: 40px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" nowrap="nowrap" style="width: 100px">
                                                                        Tipo Logradouro</td>
                                                                    <td align="left">
                                                                        &nbsp;<asp:DropDownList ID="ddlTipoLogradouro" ValidationGroup="Cadastro" runat="server"
                                                                            Width="160px">
                                                                        </asp:DropDownList></td>
                                                                    <td align="right" colspan="1">
                                                                        <asp:Button ID="btnLimparEnd" runat="server" CssClass="button" OnClick="btnLimparEnd_Click"
                                                                            Text="Limpar Endereço" Width="120px" CausesValidation="False" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" nowrap="nowrap">
                                                                        Logradouro</td>
                                                                    <td align="left" colspan="2">
                                                                        &nbsp;<asp:TextBox ID="txtEndereco" ValidationGroup="Cadastro" runat="server" MaxLength="80"
                                                                            Width="300px" CssClass="textboxBranco"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvEndereco" ValidationGroup="Cadastro" runat="server"
                                                                            ControlToValidate="txtEndereco" Display="Dynamic" ErrorMessage="Preencha o Logradouro"
                                                                            SetFocusOnError="True" Text=" * "></asp:RequiredFieldValidator>
                                                                        N°
                                                                        <asp:TextBox ID="txtNumero" ValidationGroup="Cadastro" runat="server" MaxLength="15"
                                                                            Width="60px" CssClass="textboxBranco"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" nowrap="nowrap">
                                                                        Complemento</td>
                                                                    <td align="left" colspan="2" style="width: 310px; height: 17px">
                                                                        &nbsp;<asp:TextBox ID="txtComplemento" ValidationGroup="Cadastro" runat="server"
                                                                            MaxLength="20" Width="300px" CssClass="textboxBranco"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" nowrap="nowrap">
                                                                        Estado</td>
                                                                    <td align="left" colspan="2">
                                                                        <table>
                                                                            <tr>
                                                                                <td nowrap="nowrap" style="width: 120px">
                                                                                    <asp:DropDownList ValidationGroup="Cadastro" ID="ddlUF" runat="server" OnSelectedIndexChanged="ddlUF_SelectedIndexChanged"
                                                                                        Width="100px" AutoPostBack="True">
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ValidationGroup="Cadastro" ID="RequiredFieldValidator2"
                                                                                        runat="server" ControlToValidate="ddlUF" Display="Dynamic" ErrorMessage="Preencha o Estado"
                                                                                        SetFocusOnError="True" Text=" * "></asp:RequiredFieldValidator></td>
                                                                                <td style="width: 50px">
                                                                                    &nbsp;Cidade</td>
                                                                                <td nowrap="nowrap" style="width: 240px">
                                                                                    <asp:DropDownList ID="ddlCidade" ValidationGroup="Cadastro" runat="server" Width="220px">
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ValidationGroup="Cadastro" ID="RequiredFieldValidator3"
                                                                                        runat="server" ControlToValidate="ddlCidade" Display="Dynamic" ErrorMessage="Preencha a Cidade"
                                                                                        SetFocusOnError="True" Text=" * "></asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" nowrap="nowrap">
                                                                        Bairro</td>
                                                                    <td align="left" colspan="2">
                                                                        &nbsp;<asp:TextBox ID="txtBairro" ValidationGroup="Cadastro" runat="server" MaxLength="40"
                                                                            Width="200px" CssClass="textboxBranco"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ValidationGroup="Cadastro" ID="RequiredFieldValidator1"
                                                                            runat="server" ControlToValidate="txtBairro" Display="Dynamic" ErrorMessage="Preencha o Bairro"
                                                                            SetFocusOnError="True" Text=" * "></asp:RequiredFieldValidator>&nbsp; CEP
                                                                        <asp:TextBox ID="txtCep" ValidationGroup="Cadastro" runat="server" MaxLength="8"
                                                                            Width="70px" CssClass="textboxBranco"></asp:TextBox><AjaxControlToolkit:FilteredTextBoxExtender
                                                                                ID="fteCep" runat="server" FilterType="Numbers" TargetControlID="txtCep">
                                                                            </AjaxControlToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" nowrap="nowrap">
                                                                        Telefone</td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtDDD" ValidationGroup="Cadastro" runat="server" MaxLength="4"
                                                                            Width="33px" Visible="False" CssClass="textboxBranco"></asp:TextBox>
                                                                        &nbsp;<asp:TextBox ID="txtTelefone" ValidationGroup="Cadastro" runat="server" MaxLength="20"
                                                                            Width="100px" CssClass="textboxBranco"></asp:TextBox></td>
                                                                    <td align="left">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSalvar" runat="server" CssClass="button" OnClick="btnSalvar_Click"
                                                                Text="Salvar" Width="80px" ValidationGroup="Cadastro" />&nbsp;
                                                            <asp:Button ID="btnCancelar" runat="server" CssClass="button" OnClick="btnCancelar_Click"
                                                                Text="Cancelar" Width="80px" CausesValidation="False" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="pnlRelatorio" runat="server" Visible="false">
                                                                <table cellpadding="2" style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid;
                                                                    border-left: #dcdcdc thin solid; border-bottom: #dcdcdc thin solid; width: 90%;">
                                                                    <tr>
                                                                        <td style="text-align: left" colspan="3">
                                                                            <span style="font-size: 12pt; text-decoration: underline"><strong>RELATÓRIO DO PACIENTE</strong></span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="text-align: left; height: 10px" colspan="3">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 135px; text-align: right">
                                                                            <strong>Período De</strong>
                                                                        </td>
                                                                        <td style="width: 200px; text-align: left">
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
                                                                        <td style="height: 100%; text-align: left">
                                                                            <asp:Button ID="btnGerarRelat" runat="server" CssClass="button" OnClick="btnGerarRelat_Click"
                                                                                Text="Gerar Relatório" Width="100px" ValidationGroup="Relatorio" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 135px; text-align: right">
                                                                            <strong>Estoque</strong></td>
                                                                        <td style="width: 200px; text-align: left">
                                                                            <asp:RadioButton ID="rbAmbos" runat="server" GroupName="Estoque" Text="AMBOS" Checked="True" />
                                                                            <asp:RadioButton ID="rbHac" runat="server" GroupName="Estoque" Text="HAC" />
                                                                            <asp:RadioButton ID="rbAcs" runat="server" GroupName="Estoque" Text="ACS" />
                                                                        </td>
                                                                        <td rowspan="2" style="height: 100%; text-align: left">
                                                                            <asp:CheckBox ID="cbSintetico" runat="server" Font-Bold="True" Text="Sintético" /></td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlPesquisa" runat="server" HorizontalAlign="Center">
                                                <table cellpadding="2" width="100%" style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid;
                                                    border-left: #dcdcdc thin solid; border-bottom: #dcdcdc thin solid;">
                                                    <tr>
                                                        <td align="left" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblPesquisaNovo" runat="server" Font-Bold="True" Text="Pesquise o beneficiário a ser inserido na internação domiciliar"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="height: 5px">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        Matrícula</td>
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="txtMatriculaPesquisa" runat="server" CssClass="textboxBranco" MaxLength="7"
                                                                            Width="80px"></asp:TextBox>
                                                                        <AjaxControlToolkit:FilteredTextBoxExtender ID="fteMat" runat="server" FilterType="Numbers"
                                                                            TargetControlID="txtMatriculaPesquisa">
                                                                        </AjaxControlToolkit:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Nome</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtNomePesquisa" runat="server" Width="200px" CssClass="textboxBranco"
                                                                            MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:ImageButton ID="imbPesquisa" runat="server" ImageUrl="~/Img/img_lupa.gif" OnClick="imbPesquisa_Click" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="grdResultado" runat="server" AutoGenerateColumns="False" BorderColor="#CCD4D1"
                                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="1" EmptyDataText="O sistema não encontrou nenhum registro"
                                                                OnRowDataBound="grdResultado_RowDataBound" Width="70%" AllowPaging="True" OnPageIndexChanging="grdResultado_PageIndexChanging"
                                                                OnSelectedIndexChanging="grdResultado_SelectedIndexChanging" DataKeyNames="CODPLA,CODEST,CODBEN,CODSEQBEN,CD_EMPRESA"
                                                                Visible="False" PageSize="15">
                                                                <RowStyle CssClass="ItemStyleLST" />
                                                                <Columns>
                                                                    <asp:CommandField SelectText="Selecionar" ShowSelectButton="True">
                                                                        <HeaderStyle CssClass="Th_Header" />
                                                                        <ItemStyle CssClass="ItemGrid" HorizontalAlign="Center" ForeColor="Black" />
                                                                    </asp:CommandField>
                                                                    <asp:BoundField DataField="NOMBEN" HeaderText="Nome">
                                                                        <HeaderStyle CssClass="Th_Header" />
                                                                        <ItemStyle CssClass="ItemGrid" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="CODBEN" HeaderText="Matrícula">
                                                                        <HeaderStyle CssClass="Th_Header" />
                                                                        <ItemStyle CssClass="ItemGrid" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DATNASBEN" HeaderText="Dt. Nascimento" DataFormatString="{0:dd/MM/yyyy}"
                                                                        HtmlEncode="False">
                                                                        <HeaderStyle CssClass="Th_Header" />
                                                                        <ItemStyle CssClass="ItemGrid" HorizontalAlign="Center" Width="100px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="CODPLA" HeaderText="Plano">
                                                                        <HeaderStyle CssClass="Th_Header" />
                                                                        <ItemStyle CssClass="ItemGrid" HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <AlternatingRowStyle CssClass="AlternateItemStyleLST" />
                                                            </asp:GridView>
                                                        </td>
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
                    EnableClientScript="true" ShowMessageBox="true" ValidationGroup="Cadastro" ShowSummary="false" />
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
