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
using HospitalAnaCosta.SGS.GestaoMateriaisView;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.SGS.Cadastro.View;
using HospitalAnaCosta.SGS.Cadastro.Interface;

public partial class RelatorioGeral : System.Web.UI.Page
{
    #region OBJETOS SERVIÇO

    //CommonGestaoEstoque
    private GemCommon _commonGestaoEstoque;
    private GemCommon CommonGestaoEstoque
    {
        get { return _commonGestaoEstoque != null ? _commonGestaoEstoque : _commonGestaoEstoque = new GemCommon(null); }
    }

    //CommonBenefACS
    private CommonBeneficiarioACS _commonBenefACS;
    private CommonBeneficiarioACS CommonBenefACS
    {
        get { return _commonBenefACS != null ? _commonBenefACS : _commonBenefACS = new CommonBeneficiarioACS(null); }
    }   

    //CommonCadastro
    private CommonCadastro _commonCadastro;
    private CommonCadastro CommonCadastro
    {
        get { return _commonCadastro != null ? _commonCadastro : _commonCadastro = new CommonCadastro(null); }
    }    

    private IMovimentacao _movimento;
    private IMovimentacao Movimento
    {
        get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)CommonGestaoEstoque.GetObject(typeof(IMovimentacao)); }
    }

    //Beneficiario HomeCare
    private BenefHomeCareDTO dtoBenefHC;
    private IBenefHomeCare _benefHomeCare;
    protected IBenefHomeCare BenefHomeCare
    {
        get { return _benefHomeCare != null ? _benefHomeCare : _benefHomeCare = (IBenefHomeCare)CommonBenefACS.GetObject(typeof(IBenefHomeCare)); }
    }

    //TipoLogradouro
    private ITipoLogradouro _tipoLogradouro;
    protected ITipoLogradouro TipoLogradouro
    {
        get { return _tipoLogradouro != null ? _tipoLogradouro : _tipoLogradouro = (ITipoLogradouro)CommonCadastro.GetObject(typeof(ITipoLogradouro)); }
    }

    //Municipio
    private HospitalAnaCosta.SGS.Cadastro.Interface.IMunicipio _municipio;
    protected HospitalAnaCosta.SGS.Cadastro.Interface.IMunicipio Municipio
    {
        get { return _municipio != null ? _municipio : _municipio = (HospitalAnaCosta.SGS.Cadastro.Interface.IMunicipio)CommonCadastro.GetObject(typeof(HospitalAnaCosta.SGS.Cadastro.Interface.IMunicipio)); }
    }

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
        Response.ContentType = "application/x-msexcel";
        Response.AddHeader("Content-Type", "application/x-msexcel");
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