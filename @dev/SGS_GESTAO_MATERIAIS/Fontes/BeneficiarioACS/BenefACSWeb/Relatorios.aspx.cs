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
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Cadastro.View;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using CadastroDTO = HospitalAnaCosta.SGS.Cadastro.DTO;

public partial class Relatorios : System.Web.UI.Page
{
    private string _fimScriptComum = ",'Nova','toolbar=no, scrollbars=yes, location=no, height=600, width=760, Left=180, top=30');";

    #region OBJETOS SERVIÇO
        
    //CommonCadastro
    private CommonCadastro _commonCadastro;
    private CommonCadastro CommonCadastro
    {
        get { return _commonCadastro != null ? _commonCadastro : _commonCadastro = new CommonCadastro(null); }
    }
        
    //UF
    private IUF _uf;
    protected IUF UF
    {
        get { return _uf != null ? _uf : _uf = (IUF)CommonCadastro.GetObject(typeof(IUF)); }
    }

    //Municipio
    private IMunicipio _municipio;
    protected IMunicipio Municipio
    {
        get { return _municipio != null ? _municipio : _municipio = (IMunicipio)CommonCadastro.GetObject(typeof(IMunicipio)); }
    }       

    #endregion

    #region FUNÇÕES
    
    private void CarregarComboUF()
    {
        ddlUF.DataTextField = CadastroDTO.UFDTO.FieldNames.Codigo;
        ddlUF.DataValueField = CadastroDTO.UFDTO.FieldNames.Codigo;
        ddlUF.DataSource = UF.Listar(new CadastroDTO.UFDTO());
        ddlUF.DataBind();
        ddlUF.Items.Insert(0, new ListItem("<TODOS>", string.Empty));
    }

    private void CarregarComboCidade()
    {
        if (ddlUF.SelectedValue != string.Empty)
        {
            ddlCidade.DataTextField = HospitalAnaCosta.SGS.Cadastro.DTO.MunicipioDTO.FieldNames.NomeMunicipio;
            ddlCidade.DataValueField = HospitalAnaCosta.SGS.Cadastro.DTO.MunicipioDTO.FieldNames.CodigoIBGE;

            HospitalAnaCosta.SGS.Cadastro.DTO.MunicipioDTO dtoMun = new HospitalAnaCosta.SGS.Cadastro.DTO.MunicipioDTO();

            dtoMun.SiglaUF.Value = ddlUF.SelectedValue;

            ddlCidade.DataSource = new DataView(Municipio.Listar(dtoMun), string.Empty, CadastroDTO.MunicipioDTO.FieldNames.NomeMunicipio, DataViewRowState.CurrentRows);
            ddlCidade.DataBind();
            ddlCidade.Items.Insert(0, new ListItem("<TODAS>", string.Empty));
        }
        else
        {
            ddlCidade.Items.Clear();
        }
    }

    #endregion

    #region EVENTOS

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (bool.Parse(Session["REMOVER_FUNCIONALIDADE_RELATORIOS"].ToString())) Response.Redirect("Default.aspx");            
            this.CarregarComboUF();
            ddlCidade.Items.Insert(0, new ListItem("<TODAS>", string.Empty));
            txtDataDe.Text = DateTime.Parse("1/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
            txtDataAte.Text = DateTime.Parse(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
        }
    }

    protected void btnGerarRelat_Click(object sender, EventArgs e)
    {        
        string cidade = ddlCidade.SelectedValue == string.Empty ? string.Empty : ddlCidade.SelectedItem.Text;
        if (rbGeral.Checked)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(),
            string.Format("window.open('RelatorioGeral.aspx?dt1={0}&dt2={1}&codIBGE={2}&cidade={3}'{4}", txtDataDe.Text, txtDataAte.Text, ddlCidade.SelectedValue, cidade, _fimScriptComum), true);
        }
        else if (rbMaterial.Checked)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(),
            string.Format("window.open('RelatorioMatMed.aspx?dt1={0}&dt2={1}&tabelamedica={2}&codIBGE={3}&cidade={4}'{5}", txtDataDe.Text, txtDataAte.Text, (byte)MaterialMedicamentoDTO.TipoMatMed.MATERIAL, ddlCidade.SelectedValue, cidade, _fimScriptComum), true);
        }
        else if (rbMedicamento.Checked)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(),
            string.Format("window.open('RelatorioMatMed.aspx?dt1={0}&dt2={1}&tabelamedica={2}&codIBGE={3}&cidade={4}'{5}", txtDataDe.Text, txtDataAte.Text, (byte)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO, ddlCidade.SelectedValue, cidade, _fimScriptComum), true);
        } 
    }

    protected void btnPacientesCidade_Click(object sender, EventArgs e)
    {
        string cidade = ddlCidade.SelectedValue == string.Empty ? string.Empty : ddlCidade.SelectedItem.Text;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(),
            string.Format("window.open('RelatorioPacientesMunicipio.aspx?dt1={0}&dt2={1}&codIBGE={2}&cidade={3}'{4}", txtDataDe.Text, txtDataAte.Text, ddlCidade.SelectedValue, cidade, _fimScriptComum), true);
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void ddlUF_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.CarregarComboCidade();
    }

    #endregion        
}