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
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriaisView;

public partial class RelatorioPaciente : System.Web.UI.Page
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

    protected BenefHomeCareDTO dtoBenefHC
    {
        get
        {
            if (Session["dtoBenefHC"] == null) Session["dtoBenefHC"] = new BenefHomeCareDTO();
            return (BenefHomeCareDTO)Session["dtoBenefHC"];
        }
        set { Session["dtoBenefHC"] = value; }
    }

    #endregion

    #region MÉTODOS

    private string FormatarMatricula(string matricula, string codSeq)
    {
        return string.Format("{0}-{1}", matricula, codSeq);
    }

    private void CarregarRelatorio()
    {
        lblNome.Text = dtoBenefHC.NomeBeneficiario.Value;
        lblTipoPlano.Text = dtoBenefHC.CodigoPlano.Value;
        lblMatricula.Text = FormatarMatricula(dtoBenefHC.CodigoMatriculaBenef.Value, dtoBenefHC.CodigoSeqMatriculaBenef.Value);
        lblDataDe.Text = DateTime.Parse(Request.QueryString["dt1"]).ToString("dd/MM/yyyy");
        lblDataAte.Text = DateTime.Parse(Request.QueryString["dt2"]).ToString("dd/MM/yyyy");

        MovimentacaoDTO dtoMov = new MovimentacaoDTO();

        dtoMov.TpAtendimento.Value = "H";
        dtoMov.IdtAtendimento.Value = dtoBenefHC.CodigoHomeCare.Value;
        dtoMov.DataMovimento.Value = lblDataDe.Text;
        dtoMov.DataAte.Value = lblDataAte.Text;

        if (Request.QueryString["filial"] != ((byte)FilialMatMedDTO.Filial.AMBOS).ToString())
        {
            dtoMov.IdtFilial.Value = Request.QueryString["filial"];
        }

        MovimentacaoDataTable dtbMovimento;

        if (bool.Parse(Request.QueryString["sintetico"]))
        {
            dtbMovimento = Movimento.HistoricoDespesaCentroCustoSintetico(dtoMov);
            //Remove a coluna 'Data' do grid
            //grdResultado.Columns.RemoveAt(0);
            grdResultado.Columns[0].Visible = false;
        }
        else
        {
            dtbMovimento = Movimento.HistoricoDespesaCentroCusto(dtoMov);
        }

        grdResultado.DataSource = dtbMovimento;
        grdResultado.DataBind();

        //lblTotal.Text = total.ToString("N");
    }

    #endregion

    #region EVENTOS

    protected void Page_Load(object sender, EventArgs e)
    {        
        CarregarRelatorio();
    }

    protected void lbtnExportar_Click(object sender, EventArgs e)
    {
        Response.Buffer = true;
        Response.ContentType = "application/x-msexcel";
        Response.AddHeader("Content-Type", "application/x-msexcel");
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=InternDomiciliar-RelatorioPaciente_{0}.xls", lblMatricula.Text));
        pnlGeral.Visible = false;
        pnlTotal.Visible = false;
        Response.Flush();
    }

    //private double total;
    protected void grdResultado_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    total += double.Parse(e.Row.Cells[grdResultado.Columns.Count - 1].Text);
        //}
    }

    #endregion
}