using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HospitalAnaCosta.Services.BeneficiarioACS.DTO;
using HospitalAnaCosta.Services.BeneficiarioACS.Control;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Control;

public partial class RelatorioMatMed : System.Web.UI.Page
{
    #region OBJETOS SERVIÇO

    private Movimentacao Movimento = new Movimentacao();

    #endregion

    private void CarregarRelatorio()
    {
        if (byte.Parse(Request.QueryString["tabelamedica"]) == (byte)MaterialMedicamentoDTO.TipoMatMed.MATERIAL)
        {
            lblTitulo.Text = "Material Médico Hospitalar - Internação Domiciliar";
        }
        else if (byte.Parse(Request.QueryString["tabelamedica"]) == (byte)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO)
        {
            lblTitulo.Text = "Medicamentos enviados para Internação Domiciliar";
        }
        else
        {
            lblTitulo.Text = "Produtos enviados para Internação Domiciliar";
        }

        lblDataDe.Text = DateTime.Parse(Request.QueryString["dt1"]).ToString("dd/MM/yyyy");
        lblDataAte.Text = DateTime.Parse(Request.QueryString["dt2"]).ToString("dd/MM/yyyy");
        if (!string.IsNullOrEmpty(Request.QueryString["cidade"])) lblCidade.Text = "- " + Request.QueryString["cidade"];

        MovimentacaoDTO dtoMov = new MovimentacaoDTO();

        dtoMov.TpAtendimento.Value = "H";
        dtoMov.DataMovimento.Value = lblDataDe.Text;
        dtoMov.DataAte.Value = lblDataAte.Text;
        dtoMov.Tabelamedica.Value = Request.QueryString["tabelamedica"];
        if (!string.IsNullOrEmpty(Request.QueryString["codIBGE"])) dtoMov.CodigoIBGEMunicipioHomeCare.Value = Request.QueryString["codIBGE"];

        MovimentacaoDataTable dtbMovimento = Movimento.HistoricoDespesaCentroCustoSintetico(dtoMov);
        grdResultado.DataSource = dtbMovimento;
        grdResultado.DataBind();

        lblTotal.Text = total.ToString("N");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (bool.Parse(Session["REMOVER_FUNCIONALIDADE_RELATORIOS"].ToString())) Response.Redirect("Default.aspx");
        CarregarRelatorio();
    }

    protected void lbtnExportar_Click(object sender, EventArgs e)
    {
        string fileName = "InternDomiciliar-ProdutosEnviados.xls";

        if (byte.Parse(Request.QueryString["tabelamedica"]) == (byte)MaterialMedicamentoDTO.TipoMatMed.MATERIAL)
        {
            fileName = "InternDomiciliar-MateriaisMedicosEnviados.xls";
        }
        else if (byte.Parse(Request.QueryString["tabelamedica"]) == (byte)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO)
        {
            fileName = "InternDomiciliar-MedicamentosEnviados.xls";
        }

        Response.Buffer = true;
        Response.ContentType = "application/vnd.msexcel";
        Response.AddHeader("Content-Type", "application/vnd.msexcel");
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
        pnlGeral.Visible = false;
        pnlTotal.Visible = false;
        Response.Flush();
    }

    private double total;
    protected void grdResultado_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {            
            total += double.Parse(e.Row.Cells[grdResultado.Columns.Count - 1].Text);
        }
    }
}