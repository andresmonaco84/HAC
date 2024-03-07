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
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.SGS.Cadastro.Control;

public partial class RelatorioGeral : System.Web.UI.Page
{
    #region OBJETOS SERVIÇO

    private Movimentacao Movimento = new Movimentacao();
    private BenefHomeCare BenefHomeCare = new BenefHomeCare();
    private TipoLogradouro TipoLogradouro = new TipoLogradouro();
    private HospitalAnaCosta.SGS.Cadastro.Control.Municipio Municipio = new HospitalAnaCosta.SGS.Cadastro.Control.Municipio();
    private BenefHomeCareDTO dtoBenefHC;

    #endregion   
 
    #region MÉTODOS

    private string RetornarTpLogradouro(BenefHomeCareDTO dtoBenefHC)
    {
        TipoLogradouroDTO dto = new TipoLogradouroDTO();
        dto.Codigo.Value = dtoBenefHC.TipoLogradouro.Value;
        return TipoLogradouro.Pesquisar(dto).Descricao.Value;
    }

    private string RetornarCidade(BenefHomeCareDTO dtoBenefHC)
    {
        HospitalAnaCosta.SGS.Cadastro.DTO.MunicipioDTO dto = new HospitalAnaCosta.SGS.Cadastro.DTO.MunicipioDTO();
        dto.CodigoIBGE.Value = dtoBenefHC.CodigoIBGEMunicipio.Value;
        return Municipio.Pesquisar(dto).NomeMunicipio.Value;
    }

    private string RetornarEndereco(BenefHomeCareDTO dtoBenefHC)
    {
        return string.Format("{0} {1}, {2} -{3}-{4}", RetornarTpLogradouro(dtoBenefHC),
                                                      dtoBenefHC.Endereco.Value, 
                                                      dtoBenefHC.NumeroEndereco.Value, 
                                                      dtoBenefHC.Bairro.Value,
                                                      RetornarCidade(dtoBenefHC));
    }

    private void CarregarRelatorio()
    {
        lblDataDe.Text = DateTime.Parse(Request.QueryString["dt1"]).ToString("dd/MM/yyyy");
        lblDataAte.Text = DateTime.Parse(Request.QueryString["dt2"]).ToString("dd/MM/yyyy");
        if (!string.IsNullOrEmpty(Request.QueryString["cidade"])) lblCidade.Text = "- " + Request.QueryString["cidade"];        

        MovimentacaoDTO dtoMov = new MovimentacaoDTO();

        dtoMov.TpAtendimento.Value = "H";
        dtoMov.DataMovimento.Value = lblDataDe.Text;
        dtoMov.DataAte.Value = lblDataAte.Text;
        if (!string.IsNullOrEmpty(Request.QueryString["codIBGE"])) dtoMov.CodigoIBGEMunicipioHomeCare.Value = Request.QueryString["codIBGE"];
        
        MovimentacaoDataTable dtbMovimento = Movimento.HistoricoDespesaCentroCusto(dtoMov);
        grdResultado.DataSource = dtbMovimento;
        grdResultado.DataBind();
    }

    #endregion

    #region EVENTOS

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
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=InternDomiciliar-FornecimentoGeral.xls"));
        pnlGeral.Visible = false;
        Response.Flush();
    }

    protected void grdResultado_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (dtoBenefHC == null) dtoBenefHC = new BenefHomeCareDTO();

            dtoBenefHC.CodigoHomeCare.Value = grdResultado.DataKeys[e.Row.RowIndex]["ATD_ATE_ID"].ToString();
            dtoBenefHC = BenefHomeCare.SelChave(dtoBenefHC);

            if (!dtoBenefHC.NomeBeneficiario.Value.IsNull)
            {
                e.Row.Cells[5].Text = dtoBenefHC.NomeBeneficiario.Value;
            }
            else
            {
                e.Row.Cells[5].Text = "NÃO INFORMADO";
            }            

            try
            {
                string endereco = RetornarEndereco(dtoBenefHC);

                if (string.IsNullOrEmpty(endereco))
                {
                    e.Row.Cells[6].Text = "NÃO INFORMADO";
                }
                else
                {
                    e.Row.Cells[6].Text = endereco;
                }                
            }
            catch
            {
                e.Row.Cells[6].Text = "NÃO INFORMADO CORRETAMENTE";
            }            
        }
    }

    #endregion
}