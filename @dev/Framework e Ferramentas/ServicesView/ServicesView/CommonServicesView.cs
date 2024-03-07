using System.Text.RegularExpressions;
using RMT = HospitalAnaCosta.Framework.Communication.Remoting;
using System.Configuration;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using HospitalAnaCosta.Services.CadastroFaturamento.Interface;
using HospitalAnaCosta.Services.Seguranca.Interface;
using HospitalAnaCosta.Services.Produto.Interface;
// using HospitalAnaCosta.Services.Cobranca.Interface;
using HospitalAnaCosta.Services.Email.Interface;
using HospitalAnaCosta.SGS.Internacao.Interface;

public class CommonServicesView
{

    private object credential = null;

    /// Possui os metodos comuns para toda a aplicacao 
    /// </summary>
    /// <param name="credential">credencial</param>
    public CommonServicesView(object Credential)
    {
        this.credential = Credential;
    }

    /// <summary>
    /// Salva/altera a credencial de quem esta fazendo a chamada
    /// </summary>
    public object Credential
    {
        get { return credential; }
        set { credential = value; }
    }

    /// <summary>
    /// Format o nome para inicial maiscula e restante minuscula
    /// </summary>
    /// <param name="Nome">String do nome</param>
    /// <returns>Nome formatado</returns>
    public string FormatNome(string Nome)
    {
        string text = Nome.ToLowerInvariant();
        string result = "";
        string pattern = @"\w+|\W+";

        foreach (Match m in Regex.Matches(text, pattern))
        {
            // get the matched string
            string x = m.ToString();
            // if the first char is lower case
            if (char.IsLower(x[0]))
                // capitalize it
                x = char.ToUpper(x[0]) + x.Substring(1, x.Length - 1);
            // collect all text
            result += x;
        }
        // Trata palavras de ligação: da, de, do, das, dos
        result = Regex.Replace(result, " De ", " de ");
        result = Regex.Replace(result, " Do ", " do ");
        result = Regex.Replace(result, " Dos ", " dos ");
        result = Regex.Replace(result, " Da ", " da ");
        result = Regex.Replace(result, " Das ", " das ");
        return result;
    }

    private static RMT.Client CreateClient()
    {
        RMT.Client client = new RMT.Client();
        string url = string.Empty;
        url = string.Format(@"TCP://{0}:{1}/", ConfigurationManager.AppSettings["HAC.REMOTING.SERVICES.PATH"],
            ConfigurationManager.AppSettings["HAC.REMOTING.SERVICES.PORT"]);

        RMT.ChannelType channelType = RMT.ChannelType.TCP;

        client.Url = url;
        client.AddChannel(channelType);
        return client;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <returns>Retorna uma instancia do codigo da control</returns>
    public virtual object GetObject(System.Type type)
    {
        object result = null;

        RMT.Client client = CreateClient();
        string tp = type.Name;
        switch (tp)
        {
            #region Cadastro
            case "IPacienteAtendimentoProcedimentoGuia":
                result = client.GetObject(typeof(IPacienteAtendimentoProcedimentoGuia), "HospitalAnaCosta.SGS.Cadastro.Control.PacienteAtendimentoProcedimentoGuia");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IGuiaAtendimento":
                result = client.GetObject(typeof(IGuiaAtendimento), "HospitalAnaCosta.SGS.Cadastro.Control.GuiaAtendimento");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IUnidade":
                result = client.GetObject(typeof(IUnidade), "HospitalAnaCosta.SGS.Cadastro.Control.Unidade");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ILocalAtendimento":
                result = client.GetObject(typeof(ILocalAtendimento), "HospitalAnaCosta.SGS.Cadastro.Control.LocalAtendimento");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ISetor":
                result = client.GetObject(typeof(ISetor), "HospitalAnaCosta.SGS.Cadastro.Control.Setor");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAtendimento":
                result = client.GetObject(typeof(IAtendimento), "HospitalAnaCosta.SGS.Cadastro.Control.Atendimento");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IPlano":
                result = client.GetObject(typeof(IPlano), "HospitalAnaCosta.SGS.Cadastro.Control.Plano");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IConvenio":
                result = client.GetObject(typeof(IConvenio), "HospitalAnaCosta.SGS.Cadastro.Control.Convenio");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoPessoaEmail":
                result = client.GetObject(typeof(IAssociacaoPessoaEmail), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoPessoaEmail");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoConvenioDocumentoLocalAtendimento":
                result = client.GetObject(typeof(IAssociacaoConvenioDocumentoLocalAtendimento), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoConvenioDocumentoLocalAtendimento");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoConvenioUnidade":
                result = client.GetObject(typeof(IAssociacaoConvenioUnidade), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoConvenioUnidade");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroPaciente":
                result = client.GetObject(typeof(ICadastroPaciente), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroPaciente");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IBeneficiario":
                result = client.GetObject(typeof(IBeneficiario), "HospitalAnaCosta.SGS.Cadastro.Control.Beneficiario");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroPessoa":
                result = client.GetObject(typeof(ICadastroPessoa), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroPessoa");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IConselhoProfissional":
                result = client.GetObject(typeof(IConselhoProfissional), "HospitalAnaCosta.SGS.Cadastro.Control.ConselhoProfissional");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IUF":
                result = client.GetObject(typeof(IUF), "HospitalAnaCosta.SGS.Cadastro.Control.UF");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IProfissionalSolicitante":
                result = client.GetObject(typeof(IProfissionalSolicitante), "HospitalAnaCosta.SGS.Cadastro.Control.ProfissionalSolicitante");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IEspecialidade":
                result = client.GetObject(typeof(IEspecialidade), "HospitalAnaCosta.SGS.Cadastro.Control.Especialidade");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IProfissional":
                result = client.GetObject(typeof(IProfissional), "HospitalAnaCosta.SGS.Cadastro.Control.Profissional");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ITipoTelefoneEndereco":
                result = client.GetObject(typeof(ITipoTelefoneEndereco), "HospitalAnaCosta.SGS.Cadastro.Control.TipoTelefoneEndereco");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoUnidadeLocalEspecialidade":
                result = client.GetObject(typeof(IAssociacaoUnidadeLocalEspecialidade), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoUnidadeLocalEspecialidade");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoUnidadeLocalEspecialidadeProfissional":
                result = client.GetObject(typeof(IAssociacaoUnidadeLocalEspecialidadeProfissional), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoUnidadeLocalEspecialidadeProfissional");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IMunicipio":
                result = client.GetObject(typeof(IMunicipio), "HospitalAnaCosta.SGS.Cadastro.Control.Municipio");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IMotivoObitoMulher":
                result = client.GetObject(typeof(IMotivoObitoMulher), "HospitalAnaCosta.SGS.Cadastro.Control.MotivoObitoMulher");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IProfissao":
                result = client.GetObject(typeof(IProfissao), "HospitalAnaCosta.SGS.Cadastro.Control.Profissao");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "INacionalidade":
                result = client.GetObject(typeof(INacionalidade), "HospitalAnaCosta.SGS.Cadastro.Control.Nacionalidade");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ITelefone":
                result = client.GetObject(typeof(ITelefone), "HospitalAnaCosta.SGS.Cadastro.Control.Telefone");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IEndereco":
                result = client.GetObject(typeof(IEndereco), "HospitalAnaCosta.SGS.Cadastro.Control.Endereco");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoConvenioTipoAtendimento":
                result = client.GetObject(typeof(IAssociacaoConvenioTipoAtendimento), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoConvenioTipoAtendimento");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoConvenioUnidadeLocalAtendimento":
                result = client.GetObject(typeof(IAssociacaoConvenioUnidadeLocalAtendimento), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoConvenioUnidadeLocalAtendimento");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ITipoAcomodacao":
                result = client.GetObject(typeof(ITipoAcomodacao), "HospitalAnaCosta.SGS.Cadastro.Control.TipoAcomodacao");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ITipoAcomodacaoACS":
                result = client.GetObject(typeof(ITipoAcomodacaoACS), "HospitalAnaCosta.SGS.Cadastro.Control.TipoAcomodacaoACS");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoConvenioUnidadeTipoAcomodacao":
                result = client.GetObject(typeof(IAssociacaoConvenioUnidadeTipoAcomodacao), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoConvenioUnidadeTipoAcomodacao");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IEscolaridade":
                result = client.GetObject(typeof(IEscolaridade), "HospitalAnaCosta.SGS.Cadastro.Control.Escolaridade");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ITipoLogradouro":
                result = client.GetObject(typeof(ITipoLogradouro), "HospitalAnaCosta.SGS.Cadastro.Control.TipoLogradouro");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IClinica":
                result = client.GetObject(typeof(IClinica), "HospitalAnaCosta.SGS.Cadastro.Control.Clinica");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoConvenioUnidadePlanoTipoAcomodacao":
                result = client.GetObject(typeof(IAssociacaoConvenioUnidadePlanoTipoAcomodacao), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoConvenioUnidadePlanoTipoAcomodacao");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ISubPlano":
                result = client.GetObject(typeof(ISubPlano), "HospitalAnaCosta.SGS.Cadastro.Control.SubPlano");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoPessoaEndereco":
                result = client.GetObject(typeof(IAssociacaoPessoaEndereco), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoPessoaEndereco");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoPessoaTelefone":
                result = client.GetObject(typeof(IAssociacaoPessoaTelefone), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoPessoaTelefone");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ITabelaMedica":
                result = client.GetObject(typeof(ITabelaMedica), "HospitalAnaCosta.SGS.Cadastro.Control.TabelaMedica");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IMotivoAlteracaoAuditoria":
                result = client.GetObject(typeof(IMotivoAlteracaoAuditoria), "HospitalAnaCosta.SGS.Cadastro.Control.MotivoAlteracaoAuditoria");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroFaturamentoMotivoPendencia":
                result = client.GetObject(typeof(ICadastroFaturamentoMotivoPendencia), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroFaturamentoMotivoPendencia");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroComposicaoTaxa":
                result = client.GetObject(typeof(ICadastroComposicaoTaxa), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroComposicaoTaxa");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoPlanoProdutoInternacao":
                result = client.GetObject(typeof(IAssociacaoPlanoProdutoInternacao), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoPlanoProdutoInternacao");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoConvenioPacote":
                result = client.GetObject(typeof(IAssociacaoConvenioPacote), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoConvenioPacote");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IPercentualCobrancaUrgenciaTipoProduto":
                result = client.GetObject(typeof(IPercentualCobrancaUrgenciaTipoProduto), "HospitalAnaCosta.SGS.Cadastro.Control.PercentualCobrancaUrgenciaTipoProduto");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoPlanoMaterialMedicamento":
                result = client.GetObject(typeof(IAssociacaoPlanoMaterialMedicamento), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoPlanoMaterialMedicamento");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoUnidadeLocalSetorCCustoClassContabil":
                result = client.GetObject(typeof(IAssociacaoUnidadeLocalSetorCCustoClassContabil), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoUnidadeLocalSetorCCustoClassContabil");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroCentroCusto":
                result = client.GetObject(typeof(ICadastroCentroCusto), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroCentroCusto");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroClassificacaoContabil":
                result = client.GetObject(typeof(ICadastroClassificacaoContabil), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroClassificacaoContabil");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IConvenioProdutoEquivalencia":
                result = client.GetObject(typeof(IConvenioProdutoEquivalencia), "HospitalAnaCosta.SGS.Cadastro.Control.ConvenioProdutoEquivalencia");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICodigoDespesaTISS":
                result = client.GetObject(typeof(ICodigoDespesaTISS), "HospitalAnaCosta.SGS.Cadastro.Control.CodigoDespesaTISS");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroDiariaAutomaticaConvenio":
                result = client.GetObject(typeof(ICadastroDiariaAutomaticaConvenio), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroDiariaAutomaticaConvenio");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroDiferencaDiariaAutomatica":
                result = client.GetObject(typeof(ICadastroDiferencaDiariaAutomatica), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroDiferencaDiariaAutomatica");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroPorteAnestesico":
                result = client.GetObject(typeof(ICadastroPorteAnestesico), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroPorteAnestesico");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroConvenioValorMoedaHospitalar":
                result = client.GetObject(typeof(ICadastroConvenioValorMoedaHospitalar), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroConvenioValorMoedaHospitalar");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ITipoTecnicaProduto":
                result = client.GetObject(typeof(ITipoTecnicaProduto), "HospitalAnaCosta.SGS.Cadastro.Control.TipoTecnicaProduto");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IViaAcesso":
                result = client.GetObject(typeof(IViaAcesso), "HospitalAnaCosta.SGS.Cadastro.Control.ViaAcesso");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroGrauParticipacaoTISS":
                result = client.GetObject(typeof(ICadastroGrauParticipacaoTISS), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroGrauParticipacaoTISS");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IPercentualGrauParticipacaoProfissionalSimultanea":
                result = client.GetObject(typeof(IPercentualGrauParticipacaoProfissionalSimultanea), "HospitalAnaCosta.SGS.Cadastro.Control.PercentualGrauParticipacaoProfissionalSimultanea");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroUnidadeMedidaConsumo":
                result = client.GetObject(typeof(ICadastroUnidadeMedidaConsumo), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroUnidadeMedidaConsumo");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IKitMaterialMedicamento":
                result = client.GetObject(typeof(IKitMaterialMedicamento), "HospitalAnaCosta.SGS.Cadastro.Control.KitMaterialMedicamento");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IExclusaoContratual":
                result = client.GetObject(typeof(IExclusaoContratual), "HospitalAnaCosta.SGS.Cadastro.Control.ExclusaoContratual");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IPacienteAtendimento":
                result = client.GetObject(typeof(IPacienteAtendimento), "HospitalAnaCosta.SGS.Cadastro.Control.PacienteAtendimento");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoUnidadeLocal":
                result = client.GetObject(typeof(IAssociacaoUnidadeLocal), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoUnidadeLocal");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IConvenioTabelaUtilizada":
                result = client.GetObject(typeof(IConvenioTabelaUtilizada), "HospitalAnaCosta.SGS.Cadastro.Control.ConvenioTabelaUtilizada");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ITipoAtendimento":
                result = client.GetObject(typeof(ITipoAtendimento), "HospitalAnaCosta.SGS.Cadastro.Control.TipoAtendimento");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IValorCobrancaMaterialMedicamento":
                result = client.GetObject(typeof(IValorCobrancaMaterialMedicamento), "HospitalAnaCosta.SGS.Cadastro.Control.ValorCobrancaMaterialMedicamento");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IPlanoProduto":
                result = client.GetObject(typeof(IValorCobrancaMaterialMedicamento), "HospitalAnaCosta.SGS.Cadastro.Control.PlanoProduto");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IPacienteAtendimentoProcedimento":
                result = client.GetObject(typeof(IPacienteAtendimentoProcedimento), "HospitalAnaCosta.SGS.Cadastro.Control.PacienteAtendimentoProcedimento");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "INotaFiscalMaterial":
                result = client.GetObject(typeof(INotaFiscalMaterial), "HospitalAnaCosta.SGS.Cadastro.Control.NotaFiscalMaterial");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroTipoAnestesia":
                result = client.GetObject(typeof(ICadastroTipoAnestesia), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroTipoAnestesia");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IProfissionalCBOS":
                result = client.GetObject(typeof(IProfissionalCBOS), "HospitalAnaCosta.SGS.Cadastro.Control.ProfissionalCBOS");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IGraduacaoProfissional":
                result = client.GetObject(typeof(IGraduacaoProfissional), "HospitalAnaCosta.SGS.Cadastro.Control.GraduacaoProfissional");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IProfissionalServicoFrequentado":
                result = client.GetObject(typeof(IProfissionalServicoFrequentado), "HospitalAnaCosta.SGS.Cadastro.Control.ProfissionalServicoFrequentado");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ILog":
                result = client.GetObject(typeof(ILog), "HospitalAnaCosta.SGS.Cadastro.Control.Log");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IConvenioUnidadeReferenciado":
                result = client.GetObject(typeof(IConvenioUnidadeReferenciado), "HospitalAnaCosta.SGS.Cadastro.Control.ConvenioUnidadeReferenciado");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IFeriado":
                result = client.GetObject(typeof(IFeriado), "HospitalAnaCosta.SGS.Cadastro.Control.Feriado");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IUnidadeLocalSubPlano":
                result = client.GetObject(typeof(IUnidadeLocalSubPlano), "HospitalAnaCosta.SGS.Cadastro.Control.UnidadeLocalSubPlano");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IUnidadeLocalSetorProcedimento":
                result = client.GetObject(typeof(IUnidadeLocalSetorProcedimento), "HospitalAnaCosta.SGS.Cadastro.Control.UnidadeLocalSetorProcedimento");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroBanco":
                result = client.GetObject(typeof(ICadastroBanco), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroBanco");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroMotivoDevolucaoCheque":
                result = client.GetObject(typeof(ICadastroMotivoDevolucaoCheque), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroMotivoDevolucaoCheque");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroTipoEmpresa":
                result = client.GetObject(typeof(ICadastroTipoEmpresa), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroTipoEmpresa");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ITipoCredenciaProfissional":
                result = client.GetObject(typeof(ITipoCredenciaProfissional), "HospitalAnaCosta.SGS.Cadastro.Control.TipoCredenciaProfissional");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IImposto":
                result = client.GetObject(typeof(IImposto), "HospitalAnaCosta.SGS.Cadastro.Control.Imposto");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IConvenioUnidadeImposto":
                result = client.GetObject(typeof(IConvenioUnidadeImposto), "HospitalAnaCosta.SGS.Cadastro.Control.ConvenioUnidadeImposto");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoBancoConta":
                result = client.GetObject(typeof(IAssociacaoBancoConta), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoBancoConta");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoProfissionalCFM":
                result = client.GetObject(typeof(IAssociacaoProfissionalCFM), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoProfissionalCFM");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoCFMCBOS":
                result = client.GetObject(typeof(IAssociacaoCFMCBOS), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoCFMCBOS");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAssociacaoProfissionalCFMAreaAtuacao":
                result = client.GetObject(typeof(IAssociacaoProfissionalCFMAreaAtuacao), "HospitalAnaCosta.SGS.Cadastro.Control.AssociacaoProfissionalCFMAreaAtuacao");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroEspecialidadeCFM":
                result = client.GetObject(typeof(ICadastroEspecialidadeCFM), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroEspecialidadeCFM");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroAreaAtuacao":
                result = client.GetObject(typeof(ICadastroAreaAtuacao), "HospitalAnaCosta.SGS.Cadastro.Control.CadastroAreaAtuacao");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IMailler":
                result =
                    client.GetObject(typeof(HospitalAnaCosta.SGS.Internacao.Interface.IMailler),
                                     "HospitalAnaCosta.SGS.Internacao.Control.Mailler");
                break;
            case "IIndicador":
                result = client.GetObject(typeof(IIndicador), "HospitalAnaCosta.SGS.Cadastro.Control.Indicador");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IIndicadorAtendimento":
                result = client.GetObject(typeof(IIndicadorAtendimento), "HospitalAnaCosta.SGS.Cadastro.Control.IndicadorAtendimento");
                ((HospitalAnaCosta.SGS.Cadastro.Interface.IControl)result).Credential = this.Credential;
                break;
            #endregion

            #region CadastroFaturamento
            case "IContaConsumo":
                result = client.GetObject(typeof(IContaConsumo), "HospitalAnaCosta.Services.CadastroFaturamento.Control.ContaConsumo");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IContaConsumoItem":
                result = client.GetObject(typeof(IContaConsumoItem), "HospitalAnaCosta.Services.CadastroFaturamento.Control.ContaConsumoItem");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IContaConsumoParcela":
                result = client.GetObject(typeof(IContaConsumoParcela), "HospitalAnaCosta.Services.CadastroFaturamento.Control.ContaConsumoParcela");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IControleLancamentoConvenio":
                result = client.GetObject(typeof(IControleLancamentoConvenio), "HospitalAnaCosta.Services.CadastroFaturamento.Control.ControleLancamentoConvenio");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IObservacaoSetor":
                result = client.GetObject(typeof(IObservacaoSetor), "HospitalAnaCosta.Services.CadastroFaturamento.Control.ObservacaoSetor");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;

            case "ITipoComandaSetor":
                result = client.GetObject(typeof(ITipoComandaSetor), "HospitalAnaCosta.Services.CadastroFaturamento.Control.TipoComandaSetor");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;

            case "ITipoComanda":
                result = client.GetObject(typeof(ITipoComanda), "HospitalAnaCosta.Services.CadastroFaturamento.Control.TipoComanda");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;

            case "ITipoComandaProduto":
                result = client.GetObject(typeof(ITipoComandaProduto), "HospitalAnaCosta.Services.CadastroFaturamento.Control.TipoComandaProduto");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IMovimentacaoComandaConsumo":
                result = client.GetObject(typeof(IMovimentacaoComandaConsumo), "HospitalAnaCosta.Services.CadastroFaturamento.Control.MovimentacaoComandaConsumo");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IFormaPagamento":
                result = client.GetObject(typeof(IFormaPagamento), "HospitalAnaCosta.Services.CadastroFaturamento.Control.FormaPagamento");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;

            case "ITipoFaturamento":
                result = client.GetObject(typeof(ITipoFaturamento), "HospitalAnaCosta.Services.CadastroFaturamento.Control.TipoFaturamento");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;

            case "ICronogramaFechamentoConvenio":
                result = client.GetObject(typeof(ICronogramaFechamentoConvenio), "HospitalAnaCosta.Services.CadastroFaturamento.Control.CronogramaFechamentoConvenio");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;

            case "INotaFiscal":
                result = client.GetObject(typeof(INotaFiscal), "HospitalAnaCosta.Services.CadastroFaturamento.Control.NotaFiscal");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IPercentualExameCobranca":
                result = client.GetObject(typeof(IPercentualExameCobranca), "HospitalAnaCosta.Services.CadastroFaturamento.Control.PercentualExameCobranca");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;

            case "ICadastroProcedimentoAutomatico":
                result = client.GetObject(typeof(ICadastroProcedimentoAutomatico), "HospitalAnaCosta.Services.CadastroFaturamento.Control.CadastroProcedimentoAutomatico");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IControleEmissaoLote":
                result = client.GetObject(typeof(IControleEmissaoLote), "HospitalAnaCosta.Services.CadastroFaturamento.Control.ControleEmissaoLote");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICaracteristicaMatMed":
                result = client.GetObject(typeof(ICaracteristicaMatMed), "HospitalAnaCosta.Services.CadastroFaturamento.Control.CaracteristicaMatMed");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ILoteContaParcelaNotaFiscal":
                result = client.GetObject(typeof(ILoteContaParcelaNotaFiscal), "HospitalAnaCosta.Services.CadastroFaturamento.Control.LoteContaParcelaNotaFiscal");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ILogErrosEmissao":
                result = client.GetObject(typeof(ILogErrosEmissao), "HospitalAnaCosta.Services.CadastroFaturamento.Control.LogErrosEmissao");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IControleFechamento":
                result = client.GetObject(typeof(IControleFechamento), "HospitalAnaCosta.Services.CadastroFaturamento.Control.ControleFechamento");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroFormularioExpedicao":
                result = client.GetObject(typeof(IControleFechamento), "HospitalAnaCosta.Services.CadastroFaturamento.Control.CadastroFormularioExpedicao");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IControleProntuario":
                result = client.GetObject(typeof(IControleProntuario), "HospitalAnaCosta.Services.CadastroFaturamento.Control.ControleProntuario");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAtendimentoResponsavel":
                result = client.GetObject(typeof(IAtendimentoResponsavel), "HospitalAnaCosta.Services.CadastroFaturamento.Control.AtendimentoResponsavel");
                ((HospitalAnaCosta.Services.CadastroFaturamento.Interface.IControl)result).Credential = this.Credential;
                break;
            #endregion

            #region Produto
            case "IEspecialidadeProcedimento":
                result = client.GetObject(typeof(IEspecialidadeProcedimento), "HospitalAnaCosta.Services.Produto.Control.EspecialidadeProcedimento");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroItemPacote":
                result = client.GetObject(typeof(ICadastroItemPacote), "HospitalAnaCosta.Services.Produto.Control.CadastroItemPacote");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IProduto":
                result = client.GetObject(typeof(IProduto), "HospitalAnaCosta.Services.Produto.Control.Produto");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;

            case "ITipoAtributoProduto":
                result = client.GetObject(typeof(ITipoAtributoProduto), "HospitalAnaCosta.Services.Produto.Control.TipoAtributoProduto");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IIndiceHospitalar":
                result = client.GetObject(typeof(IIndiceHospitalar), "HospitalAnaCosta.Services.Produto.Control.IndiceHospitalar");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IValorIndiceHospitalar":
                result = client.GetObject(typeof(IValorIndiceHospitalar), "HospitalAnaCosta.Services.Produto.Control.ValorIndiceHospitalar");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IGrupoProcedimento":
                result = client.GetObject(typeof(IGrupoProcedimento), "HospitalAnaCosta.Services.Produto.Control.GrupoProcedimento");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IConvenioValorProduto":
                result = client.GetObject(typeof(IConvenioValorProduto), "HospitalAnaCosta.Services.Produto.Control.ConvenioValorProduto");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IMaterialMedicamento":
                result = client.GetObject(typeof(IMaterialMedicamento), "HospitalAnaCosta.Services.Produto.Control.MaterialMedicamento");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IGrupoMatMed":
                result = client.GetObject(typeof(IGrupoMatMed), "HospitalAnaCosta.Services.Produto.Control.GrupoMatMed");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;

            case "ISubGrupoMatMed":
                result = client.GetObject(typeof(ISubGrupoMatMed), "HospitalAnaCosta.Services.Produto.Control.SubGrupoMatMed");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IBrasindice":
                result = client.GetObject(typeof(IBrasindice), "HospitalAnaCosta.Services.Produto.Control.Brasindice");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ISimpro":
                result = client.GetObject(typeof(ISimpro), "HospitalAnaCosta.Services.Produto.Control.Simpro");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IPercentualClassificacaoMedicamento":
                result = client.GetObject(typeof(IPercentualClassificacaoMedicamento), "HospitalAnaCosta.Services.Produto.Control.PercentualClassificacaoMedicamento");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IHistoricoProduto":
                result = client.GetObject(typeof(IHistoricoProduto), "HospitalAnaCosta.Services.Produto.Control.HistoricoProduto");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroApresentacaoProdutoMatMed":
                result = client.GetObject(typeof(ICadastroApresentacaoProdutoMatMed), "HospitalAnaCosta.Services.Produto.Control.CadastroApresentacaoProdutoMatMed");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ITipoListaMedicamento":
                result = client.GetObject(typeof(ITipoListaMedicamento), "HospitalAnaCosta.Services.Produto.Control.TipoListaMedicamento");
                ((HospitalAnaCosta.Services.Produto.Interface.IControl)result).Credential = this.Credential;
                break;
            #endregion

            #region Seguranca
            case "IFuncionalidade":
                result = client.GetObject(typeof(IFuncionalidade), "HospitalAnaCosta.Services.Seguranca.Control.Funcionalidade");
                ((HospitalAnaCosta.Services.Seguranca.Interface.IControl)result).Credential = this.Credential;
                break;

            case "ILogErros":
                result = client.GetObject(typeof(ILogErros), "HospitalAnaCosta.Services.Seguranca.Control.LogErros");
                ((HospitalAnaCosta.Services.Seguranca.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IModulo":
                result = client.GetObject(typeof(IModulo), "HospitalAnaCosta.Services.Seguranca.Control.Modulo");
                ((HospitalAnaCosta.Services.Seguranca.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IModuloPerfil":
                result = client.GetObject(typeof(IModuloPerfil), "HospitalAnaCosta.Services.Seguranca.Control.ModuloPerfil");
                ((HospitalAnaCosta.Services.Seguranca.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IParametro":
                result = client.GetObject(typeof(IParametro), "HospitalAnaCosta.Services.Seguranca.Control.Parametro");
                ((HospitalAnaCosta.Services.Seguranca.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IPerfil":
                result = client.GetObject(typeof(IPerfil), "HospitalAnaCosta.Services.Seguranca.Control.Perfil");
                ((HospitalAnaCosta.Services.Seguranca.Interface.IControl)result).Credential = this.Credential;
                break;

            case "ITrace":
                result = client.GetObject(typeof(ITrace), "HospitalAnaCosta.Services.Seguranca.Control.Trace");
                ((HospitalAnaCosta.Services.Seguranca.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IUsuario":
                result = client.GetObject(typeof(IUsuario), "HospitalAnaCosta.Services.Seguranca.Control.Usuario");
                ((HospitalAnaCosta.Services.Seguranca.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IUsuarioUnidade":
                result = client.GetObject(typeof(IUsuarioUnidade), "HospitalAnaCosta.Services.Seguranca.Control.UsuarioUnidade");
                ((HospitalAnaCosta.Services.Seguranca.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IPermissaoUsuario":
                result = client.GetObject(typeof(IPermissaoUsuario), "HospitalAnaCosta.Services.Seguranca.Control.PermissaoUsuario");
                ((HospitalAnaCosta.Services.Seguranca.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IPerfilFuncionalidade":
                result = client.GetObject(typeof(IPerfilFuncionalidade), "HospitalAnaCosta.Services.Seguranca.Control.PerfilFuncionalidade");
                ((HospitalAnaCosta.Services.Seguranca.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IUnidadeLocalSetorUsuario":
                result = client.GetObject(typeof(IUnidadeLocalSetorUsuario), "HospitalAnaCosta.Services.Seguranca.Control.UnidadeLocalSetorUsuario");
                ((HospitalAnaCosta.Services.Seguranca.Interface.IControl)result).Credential = this.Credential;
                break;
            #endregion

            #region Internacao
            case "IAtendimentoInternacao":
                result = client.GetObject(typeof(IAtendimentoInternacao), "HospitalAnaCosta.SGS.Internacao.Control.AtendimentoInternacao");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IAtendimentoInternacaoComplemento":
                result = client.GetObject(typeof(IAtendimentoInternacaoComplemento), "HospitalAnaCosta.SGS.Internacao.Control.AtendimentoInternacaoComplemento");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICadastroQuartoLeito":
                result = client.GetObject(typeof(ICadastroQuartoLeito), "HospitalAnaCosta.SGS.Internacao.Control.CadastroQuartoLeito");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ICID10":
                result = client.GetObject(typeof(ICID10), "HospitalAnaCosta.SGS.Internacao.Control.CID10");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IIndicadorAcidente":
                result = client.GetObject(typeof(IIndicadorAcidente), "HospitalAnaCosta.SGS.Internacao.Control.IndicadorAcidente");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IInternacaoAlta":
                result = client.GetObject(typeof(IInternacaoAlta), "HospitalAnaCosta.SGS.Internacao.Control.InternacaoAlta");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IInternacaoDadosRN":
                result = client.GetObject(typeof(IInternacaoDadosRN), "HospitalAnaCosta.SGS.Internacao.Control.InternacaoDadosRN");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IInternacaoDiagnostico":
                result = client.GetObject(typeof(IInternacaoDiagnostico), "HospitalAnaCosta.SGS.Internacao.Control.InternacaoDiagnostico");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IInternacaoObservacao":
                result = client.GetObject(typeof(IInternacaoObservacao), "HospitalAnaCosta.SGS.Internacao.Control.InternacaoObservacao");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IInternadoAgendaEletiva":
                result = client.GetObject(typeof(IInternadoAgendaEletiva), "HospitalAnaCosta.SGS.Internacao.Control.InternadoAgendaEletiva");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IInternadoCortesia":
                result = client.GetObject(typeof(IInternadoCortesia), "HospitalAnaCosta.SGS.Internacao.Control.InternadoCortesia");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IMotivoSaidaInternacao":
                result = client.GetObject(typeof(IMotivoSaidaInternacao), "HospitalAnaCosta.SGS.Internacao.Control.MotivoSaidaInternacao");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IMovimentacaoPacienteClinica":
                result = client.GetObject(typeof(IMovimentacaoPacienteClinica), "HospitalAnaCosta.SGS.Internacao.Control.MovimentacaoPacienteClinica");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IProcedimentoCIH":
                result = client.GetObject(typeof(IProcedimentoCIH), "HospitalAnaCosta.SGS.Internacao.Control.ProcedimentoCIH");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IRegimeInternacao":
                result = client.GetObject(typeof(IRegimeInternacao), "HospitalAnaCosta.SGS.Internacao.Control.RegimeInternacao");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ISituacaoQuartoLeito":
                result = client.GetObject(typeof(ISituacaoQuartoLeito), "HospitalAnaCosta.SGS.Internacao.Control.SituacaoQuartoLeito");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ITipoInternacao":
                result = client.GetObject(typeof(ITipoInternacao), "HospitalAnaCosta.SGS.Internacao.Control.TipoInternacao");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IMovimentacaoPacienteLeito":
                result = client.GetObject(typeof(IMovimentacaoPacienteLeito), "HospitalAnaCosta.SGS.Internacao.Control.MovimentacaoPacienteLeito");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IMovimentacaoPacienteSetor":
                result = client.GetObject(typeof(IMovimentacaoPacienteSetor), "HospitalAnaCosta.SGS.Internacao.Control.MovimentacaoPacienteSetor");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IInternacaoAcompanhante":
                result = client.GetObject(typeof(IInternacaoAcompanhante), "HospitalAnaCosta.SGS.Internacao.Control.InternacaoAcompanhante");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IInternadoDiferencaClasse":
                result = client.GetObject(typeof(IInternadoDiferencaClasse), "HospitalAnaCosta.SGS.Internacao.Control.InternadoDiferencaClasse");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IInternacaoEvolucaoPaciente":
                result = client.GetObject(typeof(IInternacaoEvolucaoPaciente), "HospitalAnaCosta.SGS.Internacao.Control.InternacaoEvolucaoPaciente");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IInternadoFaltaVagaTipoAcomodacao":
                result = client.GetObject(typeof(IInternadoFaltaVagaTipoAcomodacao), "HospitalAnaCosta.SGS.Internacao.Control.InternadoFaltaVagaTipoAcomodacao");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IContaParcelaRelatorio":
                result = client.GetObject(typeof(IContaParcelaRelatorio), "HospitalAnaCosta.SGS.Internacao.Control.ContaParcelaRelatorio");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IHistoricoSituacaoQuartoLeito":
                result = client.GetObject(typeof(IHistoricoSituacaoQuartoLeito), "HospitalAnaCosta.SGS.Internacao.Control.HistoricoSituacaoQuartoLeito");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;

            case "ICuidadoEspecificoPrescricaoMedica":
                    result = client.GetObject(typeof(ICuidadoEspecificoPrescricaoMedica), "HospitalAnaCosta.SGS.Internacao.Control.CuidadoEspecificoPrescricaoMedica");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IDietaPrescricaoMedica":
                    result = client.GetObject(typeof(IDietaPrescricaoMedica), "HospitalAnaCosta.SGS.Internacao.Control.DietaPrescricaoMedica");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IExamePrescricaoMedica":
                    result = client.GetObject(typeof(IExamePrescricaoMedica), "HospitalAnaCosta.SGS.Internacao.Control.ExamePrescricaoMedica");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IMedicamentoPrescricaoMedica":
                    result = client.GetObject(typeof(IMedicamentoPrescricaoMedica), "HospitalAnaCosta.SGS.Internacao.Control.MedicamentoPrescricaoMedica");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IPrescricaoMedica":
                    result = client.GetObject(typeof(IPrescricaoMedica), "HospitalAnaCosta.SGS.Internacao.Control.PrescricaoMedica");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "ISoroPrescricaoMedica":
                    result = client.GetObject(typeof(ISoroPrescricaoMedica), "HospitalAnaCosta.SGS.Internacao.Control.SoroPrescricaoMedica");
                    ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                    break;
                case "ICirurgiaRealizada":
                    result = client.GetObject(typeof(ICirurgiaRealizada), "HospitalAnaCosta.SGS.Internacao.Control.CirurgiaRealizada");
                    ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                    break;
                case "IProcedimentoCirurgiaRealizada":
                    result = client.GetObject(typeof(IProcedimentoCirurgiaRealizada), "HospitalAnaCosta.SGS.Internacao.Control.ProcedimentoCirurgiaRealizada");
                    ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                    break;
                case "IHistoricoStatusCirurgia":
                    result = client.GetObject(typeof(IHistoricoStatusCirurgia), "HospitalAnaCosta.SGS.Internacao.Control.HistoricoStatusCirurgia");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IPrescricaoProduto":
                    result = client.GetObject(typeof(IPrescricaoProduto), "HospitalAnaCosta.SGS.Internacao.Control.PrescricaoProduto");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IPrevisaoSaida":
                result = client.GetObject(typeof(HospitalAnaCosta.SGS.Internacao.Interface.IPrevisaoSaida), "HospitalAnaCosta.SGS.Internacao.Control.PrevisaoSaida");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IAntibioticoTerapia":
                result = client.GetObject(typeof(HospitalAnaCosta.SGS.Internacao.Interface.IAntibioticoTerapia), "HospitalAnaCosta.SGS.Internacao.Control.AntibioticoTerapia");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IComplementoHemodialiseEnfermagem":
                result = client.GetObject(typeof(HospitalAnaCosta.SGS.Internacao.Interface.IComplementoHemodialiseEnfermagem), "HospitalAnaCosta.SGS.Internacao.Control.ComplementoHemodialiseEnfermagem");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IInternacaoProfissionalProcedimento":
                result = client.GetObject(typeof(HospitalAnaCosta.SGS.Internacao.Interface.IInternacaoProfissionalProcedimento), "HospitalAnaCosta.SGS.Internacao.Control.InternacaoProfissionalProcedimento");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;

            case "IPrescricaoGestao":
                result = client.GetObject(typeof(HospitalAnaCosta.SGS.Internacao.Interface.IPrescricaoGestao), "HospitalAnaCosta.SGS.Internacao.Control.PrescricaoGestao");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            //case "IRequisicaoItensGestao":
            //    result = client.GetObject(typeof(HospitalAnaCosta.SGS.Internacao.Interface.IRequisicaoItensGestao), "HospitalAnaCosta.SGS.Internacao.Control.RequisicaoItensGestao");
            //    ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
            //    break;
            ////case "IRequisicaoGestao":
            ////    result = client.GetObject(typeof(HospitalAnaCosta.SGS.Internacao.Interface.IRequisicaoGestao), "HospitalAnaCosta.SGS.Internacao.Control.RequisicaoGestao");
            ////    ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
            ////    break;
            //case "IMaterialMedicamentoGestao":
            //    result = client.GetObject(typeof(HospitalAnaCosta.SGS.Internacao.Interface.IMaterialMedicamentoGestao), "HospitalAnaCosta.SGS.Internacao.Control.MaterialMedicamentoGestao");
            //    ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
            //    break;
            case "IDoencaDiagnosticoGestao":
                result = client.GetObject(typeof(HospitalAnaCosta.SGS.Internacao.Interface.IDoencaDiagnosticoGestao), "HospitalAnaCosta.SGS.Internacao.Control.DoencaDiagnosticoGestao");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            case "IPacienteGestao":
                result = client.GetObject(typeof(HospitalAnaCosta.SGS.Internacao.Interface.IPacienteGestao), "HospitalAnaCosta.SGS.Internacao.Control.PacienteGestao");
                ((HospitalAnaCosta.SGS.Internacao.Interface.IControl)result).Credential = this.Credential;
                break;
            #endregion

            #region Cobrança
            //case "ICadastroRestricaoAtendimento":
            //    result = client.GetObject(typeof(ICadastroRestricaoAtendimento), "HospitalAnaCosta.Services.Cobranca.Control.CadastroRestricaoAtendimento");
            //    ((HospitalAnaCosta.Services.Cobranca.Interface.IControl)result).Credential = this.Credential;
            //    break;

            #endregion

            #region Email

            case "IEmail":
                result = client.GetObject(typeof(HospitalAnaCosta.Services.Email.Interface.IEmail), "HospitalAnaCosta.Services.Email.Control.Email");
                ((HospitalAnaCosta.Services.Email.Interface.IControl)result).Credential = this.Credential;
                break;
            #endregion

            //case "ISMS":
            //    result = client.GetObject(typeof(HospitalAnaCosta.SGS.SMS.Interface.IEnviarSMS), "HospitalAnaCosta.SGS.SMS.Control.EnviarSMS");
            //    ((HospitalAnaCosta.SGS.SMS.Interface.IControl)result).Credential = this.Credential;
            //    break;

            //case "IMensagemPadrao":
            //    result = client.GetObject(typeof(HospitalAnaCosta.SGS.SMS.Interface.IMensagemPadrao), "HospitalAnaCosta.SGS.SMS.Control.MensagemPadrao");
            //    ((HospitalAnaCosta.SGS.SMS.Interface.IControl)result).Credential = this.Credential;
            //    break;

            //case "IMensagemEnviada":
            //    result = client.GetObject(typeof(HospitalAnaCosta.SGS.SMS.Interface.IMensagemEnviada), "HospitalAnaCosta.SGS.SMS.Control.MensagemEnviada");
            //    ((HospitalAnaCosta.SGS.SMS.Interface.IControl)result).Credential = this.Credential;
            //    break;
            //case "IMensagemRecebida":
            //    result = client.GetObject(typeof(HospitalAnaCosta.SGS.SMS.Interface.IMensagemRecebida), "HospitalAnaCosta.SGS.SMS.Control.MensagemRecebida");
            //    ((HospitalAnaCosta.SGS.SMS.Interface.IControl)result).Credential = this.Credential;
            //    break;
        }

        return result;
    }
}
