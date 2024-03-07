<%@ Page Language="C#" AutoEventWireup="True" Codebehind="RelatorioPaciente.aspx.cs"
    Inherits="RelatorioPaciente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RELAT�RIO DE INTERNA��O DOMICILIAR</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Panel ID="pnlGeral" runat="server">
                            <table id="Table1" style="font-family: Arial; font-size: 12pt;" cellspacing="1" cellpadding="1"
                                width="700px" align="center" border="0">
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
                                    <td style="height: 2px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">
                                        <strong><span style="font-family: Arial; font-size: 12pt;">Controle de Mat/Med utilizados
                                            na Intern. Domiciliar para pacientes A.C.S.</span> </strong>
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
                                                <td nowrap>
                                                    <span style="font-size: 10pt">Nome do Paciente:&nbsp;</span></td>
                                                <td style="width: 100%">
                                                    <asp:Label ID="lblNome" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 18px">
                                                    <span style="font-size: 10pt">Tipo de Plano:</span></td>
                                                <td style="height: 18px">
                                                    <asp:Label ID="lblTipoPlano" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:Label>&nbsp;&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="font-size: 10pt">Matr�cula:</span></td>
                                                <td>
                                                    <asp:Label ID="lblMatricula" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="font-size: 10pt">Per�odo:</span></td>
                                                <td>
                                                    <asp:Label ID="lblDataDe" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:Label>
                                                    <span style="font-size: 10pt">a</span>
                                                    <asp:Label ID="lblDataAte" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:Label></td>
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
                                BorderStyle="Solid" BorderWidth="0px" CellPadding="1" EmptyDataText="Nenhum produto consumido"
                                Font-Size="Smaller" Font-Names="Arial" Width="640px" OnRowDataBound="grdResultado_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="MTMD_MOV_DATA" DataFormatString="{0:dd/MM/yyyy HH:mm}"
                                        HeaderText="Data" HtmlEncode="False">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" Font-Size="Smaller" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CAD_MTMD_CODMNE" HeaderText="Cod. Produto">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" Font-Size="Smaller" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CAD_MTMD_NOMEFANTASIA" HeaderText="Descri&#231;&#227;o Mat/Med">
                                        <ItemStyle HorizontalAlign="Left" Width="210px" Font-Size="Smaller" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MTMD_MOV_QTDE" HeaderText="Qtd.">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" Font-Size="Smaller" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CAD_MTMD_UNID_VENDA_DS" HeaderText="Unidade">
                                        <ItemStyle HorizontalAlign="Left" Width="120px" Font-Size="Smaller" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VALOR_UNITARIO" Visible="True" DataFormatString="{0:N}"
                                        HeaderText="Valor Unit&#225;rio (R$)">
                                        <ItemStyle HorizontalAlign="Right" Width="80px" Font-Size="Smaller" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VALOR_TOTAL" Visible="True" DataFormatString="{0:N}"
                                        HeaderText="Valor Total (R$)">
                                        <ItemStyle HorizontalAlign="Right" Width="80px" Font-Size="Smaller" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle BackColor="Silver" />
                                <AlternatingRowStyle BackColor="Gainsboro" />
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlTotal" Visible="True" Width="640px" runat="server" HorizontalAlign="Right">
                <table style="width: 100%; text-align: right">
                    <tr>
                        <td align="left" width="70%">
                            <span style="font-size: 8pt; font-family: Arial"></span></td>
                        <td align="right" width="30%">
                            <asp:Label ID="Label1" runat="server" Text="Total:" Font-Names="Arial" Font-Size="Smaller"></asp:Label>&nbsp;&nbsp;<asp:Label
                                ID="lblTotal" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
