<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<%@ Register Assembly="HacAjaxControlsExtender" Namespace="HacAjaxControlsExtender" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="Javascript" type="text/javascript">
    /********************************************
    | Função: EscreveLetra()
    | Retorno: Retorno string de método server Escreve -> (res)
    |
    |
    \********************************************/
    function EscreveLetra()
    {
        PageMethods.Escreve(respostaCliente)
    }
    /********************************************
    | Função: respostaCliente
    | Retorno: Recebe a resposta oriunda do método server Escreve
    |
    |
    \********************************************/
    function respostaCliente(res)
    {
        alert(res);
    }
</script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" GroupingText="Testes" Height="50px" Width="275px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="2 segundos." /><asp:DropDownList
                ID="DropDownList1" runat="server">
                <asp:ListItem>aaaaaaaaaaaaaaa</asp:ListItem>
                <asp:ListItem>aaaaaaaaaaaa</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="4 segundos." />
                <asp:Button ID="Button3" runat="server" Text="Page Methods" /></asp:Panel>
            &nbsp;&nbsp;<br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" /><br />
            &nbsp;
        </ContentTemplate>
    </asp:UpdatePanel>
    &nbsp;&nbsp;<br />
    &nbsp;&nbsp;
    <br />
    <br />
</asp:Content>

