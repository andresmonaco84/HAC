using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HospitalAnaCosta.Services.BeneficiarioACS.Control;
using HospitalAnaCosta.Services.BeneficiarioACS.DTO;
using HospitalAnaCosta.SGS.Cadastro.Control;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

public partial class _Default : System.Web.UI.Page
{
    #region OBJETOS SERVIÇO
        
    private TipoLogradouro TipoLogradouro = new TipoLogradouro();
    private UF UF = new UF();
    private Municipio Municipio = new Municipio();
    private BenefHomeCare BenefHomeCare = new BenefHomeCare();    
    private BeneficiarioACS Beneficiario = new BeneficiarioACS();
    private BeneficiarioACSDTO dtoBeneficiario;
    
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

    #region FUNÇÕES

    private void CarregarComboTipoLogradouro()
    {
        ddlTipoLogradouro.DataTextField = TipoLogradouroDTO.FieldNames.Descricao;
        ddlTipoLogradouro.DataValueField = TipoLogradouroDTO.FieldNames.Codigo;
        ddlTipoLogradouro.DataSource = TipoLogradouro.Listar(new TipoLogradouroDTO());
        ddlTipoLogradouro.DataBind();
        ddlTipoLogradouro.Items.Insert(0, new ListItem("<Selecione>", string.Empty));
    }

    private void CarregarComboUF()
    {
        ddlUF.DataTextField = UFDTO.FieldNames.Codigo;
        ddlUF.DataValueField = UFDTO.FieldNames.Codigo;
        ddlUF.DataSource = UF.Listar(new UFDTO());
        ddlUF.DataBind();
        ddlUF.Items.Insert(0, new ListItem("<Selecione>", string.Empty));
    }

    private void CarregarComboCidade()
    {
        if (ddlUF.SelectedValue != string.Empty)
        {
            ddlCidade.DataTextField = HospitalAnaCosta.SGS.Cadastro.DTO.MunicipioDTO.FieldNames.NomeMunicipio;
            ddlCidade.DataValueField = HospitalAnaCosta.SGS.Cadastro.DTO.MunicipioDTO.FieldNames.CodigoIBGE;

            HospitalAnaCosta.SGS.Cadastro.DTO.MunicipioDTO dtoMun = new HospitalAnaCosta.SGS.Cadastro.DTO.MunicipioDTO();

            dtoMun.SiglaUF.Value = ddlUF.SelectedValue;

            ddlCidade.DataSource = Municipio.Listar(dtoMun);
            ddlCidade.DataBind();
            ddlCidade.Items.Insert(0, new ListItem("<Selecione>", string.Empty));
        }
        else
        {
            ddlCidade.Items.Clear();
        }        
    }

    private void Pesquisar()
    {
        dtoBeneficiario = new BeneficiarioACSDTO();

        if (txtNomePesquisa.Text != string.Empty) dtoBeneficiario.NomeBeneficiario.Value = txtNomePesquisa.Text.ToUpper();
        if (txtMatriculaPesquisa.Text != string.Empty) dtoBeneficiario.CodigoMatricula.Value = txtMatriculaPesquisa.Text;

        BeneficiarioACSDataTable dtbBenef = Beneficiario.Listar(dtoBeneficiario,
                                                                "A",
                                                                lblPesquisaNovo.Visible,
                                                                !lblPesquisaNovo.Visible);
        grdResultado.DataSource = dtbBenef;
        grdResultado.DataBind();
        grdResultado.Visible = true;
    }

    private void CarregarBenefHomeCare()
    {
        dtoBenefHC = null;
        dtoBenefHC.CodigoPlano.Value = dtoBeneficiario.CodigoEmpresa.Value;
        dtoBenefHC.CodigoLoja.Value = dtoBeneficiario.CodigoLoja.Value;
        dtoBenefHC.CodigoMatriculaBenef.Value = dtoBeneficiario.CodigoMatricula.Value;
        dtoBenefHC.CodigoSeqMatriculaBenef.Value = dtoBeneficiario.CodigoSeqMatricula.Value;
        dtoBenefHC.CodigoNumericoPlano.Value = dtoBeneficiario.CdNumericoEmpresa.Value;

        dtoBeneficiario = Beneficiario.Pesquisar(dtoBeneficiario);

        txtNome.Text = dtoBeneficiario.NomeBeneficiario.Value;
        txtDtNasc.Text = ((DateTime)dtoBeneficiario.DtNascimentoBeneficiario.Value).ToString("dd/MM/yyyy");
        txtRG.Text = dtoBeneficiario.CdRgBeneficiario.Value;
        txtCPF.Text = dtoBeneficiario.CdCpfBeneficiario.Value;
        if (txtCPF.Text != string.Empty)
        {
            txtCPF.Text = txtCPF.Text.PadLeft(11);
            txtCPF.Text = string.Format("{0}.{1}.{2}-{3}", txtCPF.Text.Substring(0, 3),
                                                           txtCPF.Text.Substring(3, 3),
                                                           txtCPF.Text.Substring(6, 3),
                                                           txtCPF.Text.Substring(9, 2)).Replace(" ", "");
        }
        txtConvenio.Text = dtoBeneficiario.DescricaoConvenio.Value;
        txtPlano.Text = dtoBeneficiario.CdPlanoBeneficiario.Value;
        txtMatricula.Text = this.FormatarMatricula(dtoBeneficiario.CodigoMatricula.Value, dtoBeneficiario.CodigoSeqMatricula.Value);
        cbAtivo.Checked = false;

        if (lblPesquisaNovo.Visible)
        {
            lblStatus.Text = "INCLUSÃO";
            cbAtivo.Checked = true;

            BenefHomeCareDTO dtoHCEndInc = BenefHomeCare.SelEnderecoIncluir(dtoBenefHC);

            if (dtoHCEndInc != null)
            {
                ddlTipoLogradouro.SelectedValue = dtoHCEndInc.TipoLogradouro.Value;
                txtEndereco.Text = dtoHCEndInc.Endereco.Value;
                txtNumero.Text = dtoHCEndInc.NumeroEndereco.Value;
                txtComplemento.Text = dtoHCEndInc.ComplementoEndereco.Value;
                ddlUF.SelectedValue = dtoHCEndInc.UF.Value;
                this.CarregarComboCidade();
                ddlCidade.SelectedValue = dtoHCEndInc.CodigoIBGEMunicipio.Value;
                txtBairro.Text = dtoHCEndInc.Bairro.Value;
                txtCep.Text = dtoHCEndInc.CEP.Value;
                //txtDDD.Text = dtoHCEndInc.DDD.Value;
                txtTelefone.Text = dtoHCEndInc.Telefone.Value;
            }
            else
            {
                this.LimparEndereco();
            }
        }
        else
        {
            lblStatus.Text = "ALTERAÇÃO";
            dtoBenefHC = BenefHomeCare.Sel(dtoBenefHC).TypedRow(0);

            if (dtoBenefHC.FlAtivo.Value == (byte)BenefHomeCareDTO.Ativo.SIM) cbAtivo.Checked = true;

            ddlTipoLogradouro.SelectedValue = dtoBenefHC.TipoLogradouro.Value;
            txtEndereco.Text = dtoBenefHC.Endereco.Value;
            txtNumero.Text = dtoBenefHC.NumeroEndereco.Value;
            txtComplemento.Text = dtoBenefHC.ComplementoEndereco.Value;
            ddlUF.SelectedValue = dtoBenefHC.UF.Value;
            this.CarregarComboCidade();
            ddlCidade.SelectedValue = dtoBenefHC.CodigoIBGEMunicipio.Value;
            txtBairro.Text = dtoBenefHC.Bairro.Value;
            txtCep.Text = dtoBenefHC.CEP.Value;
            //txtDDD.Text = dtoBenefHC.DDD.Value;
            txtTelefone.Text = dtoBenefHC.Telefone.Value;

            txtDataDe.Text = DateTime.Parse("1/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
            txtDataAte.Text = DateTime.Parse(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
        }

        pnlForm.Visible = true;
        pnlPesquisa.Visible = false;
    }

    private void LimparEndereco()
    {
        ddlTipoLogradouro.SelectedValue = string.Empty;
        txtEndereco.Text = string.Empty;
        txtNumero.Text = string.Empty;
        txtComplemento.Text = string.Empty;
        ddlUF.SelectedValue = string.Empty;
        ddlCidade.Items.Clear();
        txtBairro.Text = string.Empty;
        txtCep.Text = string.Empty;
        txtDDD.Text = string.Empty;
        txtTelefone.Text = string.Empty;
        ScriptManager.GetCurrent(this.Page).SetFocus(this.ddlTipoLogradouro);
    }

    private void Salvar()
    {
        dtoBenefHC.FlAtivo.Value = cbAtivo.Checked ? (byte)BenefHomeCareDTO.Ativo.SIM : (byte)BenefHomeCareDTO.Ativo.NAO;

        dtoBenefHC.TipoLogradouro.Value = ddlTipoLogradouro.SelectedValue;
        dtoBenefHC.Endereco.Value = txtEndereco.Text;
        dtoBenefHC.NumeroEndereco.Value = txtNumero.Text;
        dtoBenefHC.ComplementoEndereco.Value = txtComplemento.Text;
        dtoBenefHC.UF.Value = ddlUF.SelectedValue;
        dtoBenefHC.CodigoIBGEMunicipio.Value = ddlCidade.SelectedValue;
        dtoBenefHC.Bairro.Value = txtBairro.Text.Substring(0, 40);
        dtoBenefHC.CEP.Value = txtCep.Text;
        //dtoBenefHC.DDD.Value = txtDDD.Text;
        dtoBenefHC.Telefone.Value = txtTelefone.Text;

        BenefHomeCare.Gravar(dtoBenefHC);
        RotinaPesquisar();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(),
                       "alert('Registro salvo com sucesso');", true);
    }

    private void RotinaPesquisar()
    {
        lblStatus.Text = "PESQUISA";
        lblPesquisaNovo.Visible = false;
        pnlRelatorio.Visible = true;
        this.RotinaNovoPesquisar();        
    }

    private void RotinaNovo()
    {
        lblStatus.Text = "INCLUSÃO";
        lblPesquisaNovo.Visible = true;
        pnlRelatorio.Visible = false;
        this.RotinaNovoPesquisar();
    }

    private void RotinaNovoPesquisar()
    {
        grdResultado.Visible = false;
        pnlForm.Visible = false;
        pnlPesquisa.Visible = true;
        txtNomePesquisa.Text = string.Empty;
        txtMatriculaPesquisa.Text = string.Empty;
        Session.Remove("dtoBenefHC");
        ScriptManager.GetCurrent(this.Page).SetFocus(this.txtMatriculaPesquisa);
    }

    private string FormatarMatricula(string matricula, string codSeq)
    {
        return string.Format("{0}-{1}", matricula, codSeq);
    }

    #endregion

    #region EVENTOS

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (bool.Parse(Session["REMOVER_FUNCIONALIDADE_RELATORIOS"].ToString())) btnRelatorios.Visible = false;            
            this.CarregarComboTipoLogradouro();
            this.CarregarComboUF();
            pnlForm.Visible = false;
            pnlPesquisa.Visible = false;
            imbPesquisa.Attributes.Add("onClick", "return ValidarPesquisa();");
        }
        this.Form.DefaultButton = imbPesquisa.UniqueID;
    }

    protected void btnNovo_Click(object sender, EventArgs e)
    {
        this.RotinaNovo();
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        this.RotinaPesquisar();
    }

    protected void ddlUF_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.CarregarComboCidade();
    }

    protected void btnLimparEnd_Click(object sender, EventArgs e)
    {
        this.LimparEndereco();
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        this.Salvar();
        Session.Remove("dtoBenefHC");
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlForm.Visible = false;
        pnlPesquisa.Visible = true;
        Session.Remove("dtoBenefHC");
    }

    protected void grdResultado_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].Text = this.FormatarMatricula(e.Row.Cells[2].Text, grdResultado.DataKeys[e.Row.RowIndex]["CODSEQBEN"].ToString());
        }
    }

    protected void grdResultado_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdResultado.PageIndex = e.NewPageIndex;
        this.Pesquisar();
    }

    protected void grdResultado_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        dtoBeneficiario = new BeneficiarioACSDTO();

        dtoBeneficiario.CodigoEmpresa.Value = Server.HtmlDecode(grdResultado.DataKeys[e.NewSelectedIndex]["CODPLA"].ToString());
        dtoBeneficiario.CodigoLoja.Value = Server.HtmlDecode(grdResultado.DataKeys[e.NewSelectedIndex]["CODEST"].ToString());
        dtoBeneficiario.CodigoMatricula.Value = Server.HtmlDecode(grdResultado.DataKeys[e.NewSelectedIndex]["CODBEN"].ToString());
        dtoBeneficiario.CodigoSeqMatricula.Value = Server.HtmlDecode(grdResultado.DataKeys[e.NewSelectedIndex]["CODSEQBEN"].ToString());
        dtoBeneficiario.CdNumericoEmpresa.Value = Server.HtmlDecode(grdResultado.DataKeys[e.NewSelectedIndex]["CD_EMPRESA"].ToString());

        this.CarregarBenefHomeCare();
    }

    protected void imbPesquisa_Click(object sender, ImageClickEventArgs e)
    {
        grdResultado.PageIndex = 0;
        this.Pesquisar();
    }

    protected void btnGerarRelat_Click(object sender, EventArgs e)
    {
        string sintetico = "false";
        string filial = ((byte)FilialMatMedDTO.Filial.AMBOS).ToString();

        if (rbAcs.Checked) filial = ((byte)FilialMatMedDTO.Filial.ACS).ToString();
        if (rbHac.Checked) filial = ((byte)FilialMatMedDTO.Filial.HAC).ToString();

        if (cbSintetico.Checked) sintetico = "true";

        dtoBenefHC.NomeBeneficiario.Value = txtNome.Text;        

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(),
        string.Format("window.open('RelatorioPaciente.aspx?dt1={0}&dt2={1}&filial={2}&sintetico={3}','Nova','toolbar=no, scrollbars=yes, location=no, height=600, width=760, Left=180, top=30');",
                      txtDataDe.Text, txtDataAte.Text, filial, sintetico), true);
    }

    protected void btnRelatorios_Click(object sender, EventArgs e)
    {
        Response.Redirect("Relatorios.aspx");
    }

    protected void btnSair_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();        
        System.Web.Security.FormsAuthentication.SignOut();
        Response.Redirect("Default.aspx");
    }

    #endregion           
}