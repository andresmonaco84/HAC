<%@ Page Language="C#" AutoEventWireup="True" Codebehind="RelatorioPacientesMunicipio.aspx.cs"
    Inherits="RelatorioPacientesMunicipio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RELATÓRIO DE INTERNAÇÃO DOMICILIAR</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Panel ID="pnlGeral" runat="server">
                            <table id="Table1" style="font-family: Arial; font-size: 12pt;" cellspacing="1" cellpadding="1"
                                width="700" align="center" border="0">
                                <tr>
                                    <td>
                                        <table id="tbFuncionalidades" width="100%">
                                            <tr>
                                                <td style="width: 50%; text-align: left">
                                                    <a href="#" onclick="document.getElementById('tbFuncionalidades').style.display='none'; javascript:window.print(); document.getElementById('tbFuncionalidades').style.display='';">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="Img\bt_imprimir.gif"></asp:Image></a>
                                                </td>
                                                <td style="width: 50%; text-align: right">
                                                    <asp:LinkButton ID="lbtnExportar" runat="server" Font-Bold="True" Font-Size="Smaller"
                                                        OnClick="lbtnExportar_Click">Exportar Dados Excel</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <hr>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Img/logo_hac.JPG" /></td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">
                                        <strong><span style="font-family: Arial; font-size: 12pt;">
                                            <asp:Label ID="lblTitulo" runat="server">Relatório de Intern. Domiciliar de Pacientes por Cidade</asp:Label></span>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        _____________________________________________________________________________</td>
                                </tr>
                                <tr>
                                    <td style="height: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="font-family: Arial; font-size: 12pt;" id="Table2" cellspacing="0" cellpadding="0"
                                            width="100%" border="0">
                                            <tr>
                                                <td style="width: 60px">
                                                    <span style="font-size: 10pt">Período:</span></td>
                                                <td>
                                                    <asp:Label ID="lblDataDe" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:Label>
                                                    <span style="font-size: 10pt">a</span>
                                                    <asp:Label ID="lblDataAte" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:Label>
                                                    <asp:Label ID="lblCidade" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlGrid" runat="server">
                            <asp:GridView ID="grdResultado" runat="server" AutoGenerateColumns="False" BorderColor="Silver"
                                BorderStyle="Solid" BorderWidth="0px" CellPadding="2" EmptyDataText="Nenhum paciente encontrado no período nesta cidade"
                                Font-Size="Smaller" Font-Names="Arial" Width="640px" DataKeyNames="ATD_ATE_ID">
                                <Columns>
                                    <asp:BoundField DataField="ATD_ATE_ID" HeaderText="ID">
                                        <ItemStyle HorizontalAlign="center" Font-Size="Smaller" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NOMBEN" HeaderText="Paciente">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CODCON" HeaderText="Plano">
                                        <ItemStyle HorizontalAlign="center" Font-Size="Smaller" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle BackColor="Silver" />
                                <AlternatingRowStyle BackColor="Gainsboro" />
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlTotal" Width="640px" runat="server" HorizontalAlign="Right">
                <table style="width: 100%; text-align: right">
                    <tr>
                        <td align="left" width="70%">
                            <span style="font-size: 8pt; font-family: Arial"></span>
                        </td>
                        <td align="right" width="30%">
                            <asp:Label ID="Label1" runat="server" Text="Total de Pacientes:" Font-Names="Arial"
                                Font-Size="Smaller"></asp:Label>&nbsp;&nbsp;<asp:Label ID="lblTotal" runat="server"
                                    Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
