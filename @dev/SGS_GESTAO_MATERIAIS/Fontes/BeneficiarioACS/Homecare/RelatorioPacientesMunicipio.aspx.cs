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

public partial class RelatorioPacientesMunicipio : System.Web.UI.Page
{
    #region OBJETOS SERVIÇO

    private Movimentacao Movimento = new Movimentacao();

    #endregion

    private void CarregarRelatorio()
    {
        lblDataDe.Text = DateTime.Parse(Request.QueryString["dt1"]).ToString("dd/MM/yyyy");
        lblDataAte.Text = DateTime.Parse(Request.QueryString["dt2"]).ToString("dd/MM/yyyy");
        lblCidade.Text = "- " + Request.QueryString["cidade"];

        MovimentacaoDTO dtoMov = new MovimentacaoDTO();

        dtoMov.TpAtendimento.Value = "H";
        dtoMov.DataMovimento.Value = lblDataDe.Text;
        dtoMov.DataAte.Value = lblDataAte.Text;        
        dtoMov.CodigoIBGEMunicipioHomeCare.Value = Request.QueryString["codIBGE"];

        MovimentacaoDataTable dtbMovimento = Movimento.HistoricoDespesaCentroCustoPacientes(dtoMov);
        grdResultado.DataSource = dtbMovimento;
        grdResultado.DataBind();

        lblTotal.Text = grdResultado.Rows.Count.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (bool.Parse(Session["REMOVER_FUNCIONALIDADE_RELATORIOS"].ToString())) Response.Redirect("Default.aspx");
        CarregarRelatorio();
    }

    protected void lbtnExportar_Click(object sender, EventArgs e)
    {
        Response.Buffer = true;
        Response.ContentType = "application/vnd.msexcel";
        Response.AddHeader("Content-Type", "application/vnd.msexcel");
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "InternDomiciliar-PacientesCidade.xls"));
        pnlGeral.Visible = false;
        pnlTotal.Visible = false;
        Response.Flush();
    }        
}