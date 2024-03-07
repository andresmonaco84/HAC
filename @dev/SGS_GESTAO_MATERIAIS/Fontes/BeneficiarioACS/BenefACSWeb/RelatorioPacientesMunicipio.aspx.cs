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
using HospitalAnaCosta.Services.BeneficiarioACS.View;
using HospitalAnaCosta.Services.BeneficiarioACS.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriaisView;

public partial class RelatorioPacientesMunicipio : System.Web.UI.Page
{
    #region OBJETOS SERVIÇO

    //CommonGestaoEstoque
    private GemCommon _commonGestaoEstoque;
    private GemCommon CommonGestaoEstoque
    {
        get { return _commonGestaoEstoque != null ? _commonGestaoEstoque : _commonGestaoEstoque = new GemCommon(null); }
    }

    private IMovimentacao _movimento;
    private IMovimentacao Movimento
    {
        get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)CommonGestaoEstoque.GetObject(typeof(IMovimentacao)); }
    }

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
        Response.ContentType = "application/x-msexcel";
        Response.AddHeader("Content-Type", "application/x-msexcel");
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "InternDomiciliar-PacientesCidade.xls"));
        pnlGeral.Visible = false;
        pnlTotal.Visible = false;
        Response.Flush();
    }        
}