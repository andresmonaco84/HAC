using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using MVC = HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.Services.BeneficiarioACS.DTO
{
    /// <summary>
    /// Classe Entidade BeneficiarioDataTable
    /// </summary>
    [Serializable()]
    public class BeneficiarioACSDataTable : DataTable
    {

        public BeneficiarioACSDataTable()
            : base()
        {

            this.TableName = "DADOS";

            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CodigoEmpresa, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CodigoLoja, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CodigoMatricula, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CodigoSeqMatricula, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.NomeBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdPadraoAtendimentoBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdPadraoCobrancaBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IndicacaoTitular, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.SexoBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdGrauParentesco, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdEstadoCivilBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtNascimentoBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtIngressoBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtAdmissaoEmpresaBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtSaidaBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdOcupacaoBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdCargoBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdSituacaoBeneficiario, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtLimiteBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtSituacaoBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdCpfBeneficiario, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdRgBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdAcordoBeneficiario, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdPlanoBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.VlCobrancaBeneficiario, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CodTipoPad, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DataMIEXC, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdSituacaoABeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdCarenciaBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IndPag, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtAtuIndPag, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IndNegociacao, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DataTod, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdadeBen, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.NmMaeBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdCancelamentoAns, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdAutorizacaoANS, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.VlPerc, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdProfissionalBeneficiario, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtAlteracaoBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdNumericoEmpresa, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdCopartExameBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdCopartConsultaBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdCronicoBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdCopartBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdCredencialBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.VlCobrancaAtual, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DataCobrancaAtual, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DataRefCobrancaAtual, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtEmissaoCredencial, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdSituacaoJuridico, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DsJuridicoBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdSuspensaoBoleto, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdDoenteCronico, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdDiagnosticoCronico, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdRepasseBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtExclusaoFatura, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdLocalRepasseBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdPiacBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdCurativoBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtInicioCurativoBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdHomecareBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtInicioHomecareBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdMedicoFamBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtInicioMedicoFamBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdSegRemissaoBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdPlanoBemBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtInicioCronicoBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtInicioPlanoBemBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtInicioRepasseBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtFinalRepasseBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdRepasseBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DsLocalRepasseBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdRepasseEmprBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtFimPlanoBemBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdPlanoBemBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdAcessorioBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdNacionalidadeBeneficiario, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdPaisBeneficiario, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdOrgaoEmissorBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.NmPaisEmissorBeneficiario, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdPisPasepBeneficiario, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdAcidenteTrabalhoBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdPiacBeneficiario, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdDocumentoBeneficiario, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdNaturezaDocBeneficiario, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DtExpedDocBeneficiario, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdAtividadePrincipalBeneficiario, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdOperacao, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.IdCartaoAutorizador, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DataCartaoAutorizador, typeof(DateTime));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.NomeReduzido, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.NmLogin, typeof(String));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CdContrato, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DgContrato, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.CodigoPlanoANSOrigem, typeof(Decimal));
            this.Columns.Add(BeneficiarioACSDTO.FieldNames.DescricaoConvenio, typeof(String));

            //DataColumn[] primaryKey = { this.Columns[BeneficiarioACSDTO.FieldNames.CdNumericoEmpresa], this.Columns[BeneficiarioACSDTO.FieldNames.CodigoMatricula], this.Columns[BeneficiarioACSDTO.FieldNames.CodigoEmpresa], this.Columns[BeneficiarioACSDTO.FieldNames.CodigoLoja], this.Columns[BeneficiarioACSDTO.FieldNames.CodigoSeqMatricula] };

            //this.PrimaryKey = primaryKey;
        }

        protected BeneficiarioACSDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }


        public BeneficiarioACSDTO TypedRow(int index)
        {
            return (BeneficiarioACSDTO)this.Rows[index];
        }

        public string GetXml()
        {
            string ret;
            UTF8Encoding utf8 = new UTF8Encoding();

            MemoryStream stream = new MemoryStream();
            this.WriteXml(stream);
            ret = utf8.GetString(stream.ToArray());
            stream.Close();
            return ret;
        }

        public XmlDocument WriteXml()
        {
            XmlDocument ret = new XmlDocument();
            ret.LoadXml(this.GetXml());
            return ret;
        }

        public void Add(BeneficiarioACSDTO dto)
        {
            DataRow dtr = this.NewRow();


            if (!dto.CodigoEmpresa.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CodigoEmpresa] = (String)dto.CodigoEmpresa.Value;
            if (!dto.CodigoLoja.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CodigoLoja] = (Decimal)dto.CodigoLoja.Value;
            if (!dto.CodigoMatricula.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CodigoMatricula] = (Decimal)dto.CodigoMatricula.Value;
            if (!dto.CodigoSeqMatricula.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CodigoSeqMatricula] = (Decimal)dto.CodigoSeqMatricula.Value;
            if (!dto.NomeBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.NomeBeneficiario] = (String)dto.NomeBeneficiario.Value;
            if (!dto.CdPadraoAtendimentoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdPadraoAtendimentoBeneficiario] = (String)dto.CdPadraoAtendimentoBeneficiario.Value;
            if (!dto.CdPadraoCobrancaBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdPadraoCobrancaBeneficiario] = (String)dto.CdPadraoCobrancaBeneficiario.Value;
            if (!dto.IndicacaoTitular.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IndicacaoTitular] = (String)dto.IndicacaoTitular.Value;
            if (!dto.SexoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.SexoBeneficiario] = (String)dto.SexoBeneficiario.Value;
            if (!dto.CdGrauParentesco.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdGrauParentesco] = (String)dto.CdGrauParentesco.Value;
            if (!dto.CdEstadoCivilBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdEstadoCivilBeneficiario] = (String)dto.CdEstadoCivilBeneficiario.Value;
            if (!dto.DtNascimentoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtNascimentoBeneficiario] = (DateTime)dto.DtNascimentoBeneficiario.Value;
            if (!dto.DtIngressoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtIngressoBeneficiario] = (DateTime)dto.DtIngressoBeneficiario.Value;
            if (!dto.DtAdmissaoEmpresaBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtAdmissaoEmpresaBeneficiario] = (DateTime)dto.DtAdmissaoEmpresaBeneficiario.Value;
            if (!dto.DtSaidaBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtSaidaBeneficiario] = (DateTime)dto.DtSaidaBeneficiario.Value;
            if (!dto.CdOcupacaoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdOcupacaoBeneficiario] = (String)dto.CdOcupacaoBeneficiario.Value;
            if (!dto.CdCargoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdCargoBeneficiario] = (String)dto.CdCargoBeneficiario.Value;
            if (!dto.CdSituacaoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdSituacaoBeneficiario] = (Decimal)dto.CdSituacaoBeneficiario.Value;
            if (!dto.DtLimiteBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtLimiteBeneficiario] = (DateTime)dto.DtLimiteBeneficiario.Value;
            if (!dto.DtSituacaoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtSituacaoBeneficiario] = (DateTime)dto.DtSituacaoBeneficiario.Value;
            if (!dto.CdCpfBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdCpfBeneficiario] = (Decimal)dto.CdCpfBeneficiario.Value;
            if (!dto.CdRgBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdRgBeneficiario] = (String)dto.CdRgBeneficiario.Value;
            if (!dto.CdAcordoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdAcordoBeneficiario] = (Decimal)dto.CdAcordoBeneficiario.Value;
            if (!dto.CdPlanoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdPlanoBeneficiario] = (String)dto.CdPlanoBeneficiario.Value;
            if (!dto.VlCobrancaBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.VlCobrancaBeneficiario] = (Decimal)dto.VlCobrancaBeneficiario.Value;
            if (!dto.CodTipoPad.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CodTipoPad] = (String)dto.CodTipoPad.Value;
            if (!dto.DataMIEXC.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DataMIEXC] = (DateTime)dto.DataMIEXC.Value;
            if (!dto.CdSituacaoABeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdSituacaoABeneficiario] = (String)dto.CdSituacaoABeneficiario.Value;
            if (!dto.CdCarenciaBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdCarenciaBeneficiario] = (String)dto.CdCarenciaBeneficiario.Value;
            if (!dto.IndPag.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IndPag] = (String)dto.IndPag.Value;
            if (!dto.DtAtuIndPag.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtAtuIndPag] = (DateTime)dto.DtAtuIndPag.Value;
            if (!dto.IndNegociacao.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IndNegociacao] = (String)dto.IndNegociacao.Value;
            if (!dto.DataTod.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DataTod] = (DateTime)dto.DataTod.Value;
            if (!dto.IdadeBen.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdadeBen] = (Decimal)dto.IdadeBen.Value;
            if (!dto.NmMaeBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.NmMaeBeneficiario] = (String)dto.NmMaeBeneficiario.Value;
            if (!dto.IdCancelamentoAns.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdCancelamentoAns] = (String)dto.IdCancelamentoAns.Value;
            if (!dto.IdAutorizacaoANS.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdAutorizacaoANS] = (String)dto.IdAutorizacaoANS.Value;
            if (!dto.VlPerc.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.VlPerc] = (Decimal)dto.VlPerc.Value;
            if (!dto.CdProfissionalBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdProfissionalBeneficiario] = (Decimal)dto.CdProfissionalBeneficiario.Value;
            if (!dto.DtAlteracaoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtAlteracaoBeneficiario] = (DateTime)dto.DtAlteracaoBeneficiario.Value;
            if (!dto.CdNumericoEmpresa.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdNumericoEmpresa] = (Decimal)dto.CdNumericoEmpresa.Value;
            if (!dto.IdCopartExameBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdCopartExameBeneficiario] = (String)dto.IdCopartExameBeneficiario.Value;
            if (!dto.IdCopartConsultaBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdCopartConsultaBeneficiario] = (String)dto.IdCopartConsultaBeneficiario.Value;
            if (!dto.IdCronicoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdCronicoBeneficiario] = (String)dto.IdCronicoBeneficiario.Value;
            if (!dto.IdCopartBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdCopartBeneficiario] = (String)dto.IdCopartBeneficiario.Value;
            if (!dto.IdCredencialBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdCredencialBeneficiario] = (String)dto.IdCredencialBeneficiario.Value;
            if (!dto.VlCobrancaAtual.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.VlCobrancaAtual] = (Decimal)dto.VlCobrancaAtual.Value;
            if (!dto.DataCobrancaAtual.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DataCobrancaAtual] = (DateTime)dto.DataCobrancaAtual.Value;
            if (!dto.DataRefCobrancaAtual.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DataRefCobrancaAtual] = (DateTime)dto.DataRefCobrancaAtual.Value;
            if (!dto.DtEmissaoCredencial.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtEmissaoCredencial] = (DateTime)dto.DtEmissaoCredencial.Value;
            if (!dto.IdSituacaoJuridico.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdSituacaoJuridico] = (String)dto.IdSituacaoJuridico.Value;
            if (!dto.DsJuridicoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DsJuridicoBeneficiario] = (String)dto.DsJuridicoBeneficiario.Value;
            if (!dto.IdSuspensaoBoleto.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdSuspensaoBoleto] = (String)dto.IdSuspensaoBoleto.Value;
            if (!dto.IdDoenteCronico.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdDoenteCronico] = (String)dto.IdDoenteCronico.Value;
            if (!dto.CdDiagnosticoCronico.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdDiagnosticoCronico] = (String)dto.CdDiagnosticoCronico.Value;
            if (!dto.IdRepasseBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdRepasseBeneficiario] = (String)dto.IdRepasseBeneficiario.Value;
            if (!dto.DtExclusaoFatura.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtExclusaoFatura] = (DateTime)dto.DtExclusaoFatura.Value;
            if (!dto.CdLocalRepasseBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdLocalRepasseBeneficiario] = (String)dto.CdLocalRepasseBeneficiario.Value;
            if (!dto.IdPiacBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdPiacBeneficiario] = (String)dto.IdPiacBeneficiario.Value;
            if (!dto.IdCurativoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdCurativoBeneficiario] = (String)dto.IdCurativoBeneficiario.Value;
            if (!dto.DtInicioCurativoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtInicioCurativoBeneficiario] = (DateTime)dto.DtInicioCurativoBeneficiario.Value;
            if (!dto.IdHomecareBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdHomecareBeneficiario] = (String)dto.IdHomecareBeneficiario.Value;
            if (!dto.DtInicioHomecareBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtInicioHomecareBeneficiario] = (DateTime)dto.DtInicioHomecareBeneficiario.Value;
            if (!dto.IdMedicoFamBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdMedicoFamBeneficiario] = (String)dto.IdMedicoFamBeneficiario.Value;
            if (!dto.DtInicioMedicoFamBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtInicioMedicoFamBeneficiario] = (DateTime)dto.DtInicioMedicoFamBeneficiario.Value;
            if (!dto.IdSegRemissaoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdSegRemissaoBeneficiario] = (String)dto.IdSegRemissaoBeneficiario.Value;
            if (!dto.IdPlanoBemBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdPlanoBemBeneficiario] = (String)dto.IdPlanoBemBeneficiario.Value;
            if (!dto.DtInicioCronicoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtInicioCronicoBeneficiario] = (DateTime)dto.DtInicioCronicoBeneficiario.Value;
            if (!dto.DtInicioPlanoBemBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtInicioPlanoBemBeneficiario] = (DateTime)dto.DtInicioPlanoBemBeneficiario.Value;
            if (!dto.DtInicioRepasseBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtInicioRepasseBeneficiario] = (DateTime)dto.DtInicioRepasseBeneficiario.Value;
            if (!dto.DtFinalRepasseBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtFinalRepasseBeneficiario] = (DateTime)dto.DtFinalRepasseBeneficiario.Value;
            if (!dto.CdRepasseBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdRepasseBeneficiario] = (String)dto.CdRepasseBeneficiario.Value;
            if (!dto.DsLocalRepasseBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DsLocalRepasseBeneficiario] = (String)dto.DsLocalRepasseBeneficiario.Value;
            if (!dto.IdRepasseEmprBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdRepasseEmprBeneficiario] = (String)dto.IdRepasseEmprBeneficiario.Value;
            if (!dto.DtFimPlanoBemBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtFimPlanoBemBeneficiario] = (DateTime)dto.DtFimPlanoBemBeneficiario.Value;
            if (!dto.CdPlanoBemBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdPlanoBemBeneficiario] = (String)dto.CdPlanoBemBeneficiario.Value;
            if (!dto.IdAcessorioBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdAcessorioBeneficiario] = (String)dto.IdAcessorioBeneficiario.Value;
            if (!dto.CdNacionalidadeBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdNacionalidadeBeneficiario] = (Decimal)dto.CdNacionalidadeBeneficiario.Value;
            if (!dto.CdPaisBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdPaisBeneficiario] = (Decimal)dto.CdPaisBeneficiario.Value;
            if (!dto.CdOrgaoEmissorBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdOrgaoEmissorBeneficiario] = (String)dto.CdOrgaoEmissorBeneficiario.Value;
            if (!dto.NmPaisEmissorBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.NmPaisEmissorBeneficiario] = (Decimal)dto.NmPaisEmissorBeneficiario.Value;
            if (!dto.CdPisPasepBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdPisPasepBeneficiario] = (Decimal)dto.CdPisPasepBeneficiario.Value;
            if (!dto.IdAcidenteTrabalhoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdAcidenteTrabalhoBeneficiario] = (String)dto.IdAcidenteTrabalhoBeneficiario.Value;
            if (!dto.CdPiacBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdPiacBeneficiario] = (Decimal)dto.CdPiacBeneficiario.Value;
            if (!dto.CdDocumentoBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdDocumentoBeneficiario] = (String)dto.CdDocumentoBeneficiario.Value;
            if (!dto.CdNaturezaDocBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdNaturezaDocBeneficiario] = (Decimal)dto.CdNaturezaDocBeneficiario.Value;
            if (!dto.DtExpedDocBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DtExpedDocBeneficiario] = (DateTime)dto.DtExpedDocBeneficiario.Value;
            if (!dto.CdAtividadePrincipalBeneficiario.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdAtividadePrincipalBeneficiario] = (Decimal)dto.CdAtividadePrincipalBeneficiario.Value;
            if (!dto.IdOperacao.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdOperacao] = (String)dto.IdOperacao.Value;
            if (!dto.IdCartaoAutorizador.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.IdCartaoAutorizador] = (String)dto.IdCartaoAutorizador.Value;
            if (!dto.DataCartaoAutorizador.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DataCartaoAutorizador] = (DateTime)dto.DataCartaoAutorizador.Value;
            if (!dto.NomeReduzido.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.NomeReduzido] = (String)dto.NomeReduzido.Value;
            if (!dto.NmLogin.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.NmLogin] = (String)dto.NmLogin.Value;
            if (!dto.CdContrato.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CdContrato] = (Decimal)dto.CdContrato.Value;
            if (!dto.DgContrato.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DgContrato] = (Decimal)dto.DgContrato.Value;
            if (!dto.CodigoPlanoANSOrigem.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.CodigoPlanoANSOrigem] = (Decimal)dto.CodigoPlanoANSOrigem.Value;
            if (!dto.DescricaoConvenio.Value.IsNull) dtr[BeneficiarioACSDTO.FieldNames.DescricaoConvenio] = (String)dto.DescricaoConvenio.Value;

            this.Rows.Add(dtr);
        }

        public BeneficiarioEnumerator GetEnumerator()
        {
            return new BeneficiarioEnumerator(this);
        }
    }

    // Inner class implements IEnumerator interface:
    public class BeneficiarioEnumerator
    {
        private int position = -1;
        private DataTable dtb;

        public BeneficiarioEnumerator(DataTable dtb)
        {
            this.dtb = dtb;
        }

        // Declare the MoveNext method required by IEnumerator:
        public bool MoveNext()
        {
            if (position < dtb.Rows.Count - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Declare the Reset method required by IEnumerator:
        public void Reset()
        {
            position = -1;
        }

        // Declare the Current property required by IEnumerator:
        public BeneficiarioACSDTO Current
        {
            get
            {
                BeneficiarioACSDTO dto = new BeneficiarioACSDTO();
                dto.CodigoEmpresa.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CodigoEmpresa].ToString();
                dto.CodigoLoja.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CodigoLoja].ToString();
                dto.CodigoMatricula.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CodigoMatricula].ToString();
                dto.CodigoSeqMatricula.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CodigoSeqMatricula].ToString();
                dto.NomeBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.NomeBeneficiario].ToString();
                dto.CdPadraoAtendimentoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdPadraoAtendimentoBeneficiario].ToString();
                dto.CdPadraoCobrancaBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdPadraoCobrancaBeneficiario].ToString();
                dto.IndicacaoTitular.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IndicacaoTitular].ToString();
                dto.SexoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.SexoBeneficiario].ToString();
                dto.CdGrauParentesco.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdGrauParentesco].ToString();
                dto.CdEstadoCivilBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdEstadoCivilBeneficiario].ToString();
                dto.DtNascimentoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtNascimentoBeneficiario].ToString();
                dto.DtIngressoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtIngressoBeneficiario].ToString();
                dto.DtAdmissaoEmpresaBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtAdmissaoEmpresaBeneficiario].ToString();
                dto.DtSaidaBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtSaidaBeneficiario].ToString();
                dto.CdOcupacaoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdOcupacaoBeneficiario].ToString();
                dto.CdCargoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdCargoBeneficiario].ToString();
                dto.CdSituacaoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdSituacaoBeneficiario].ToString();
                dto.DtLimiteBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtLimiteBeneficiario].ToString();
                dto.DtSituacaoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtSituacaoBeneficiario].ToString();
                dto.CdCpfBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdCpfBeneficiario].ToString();
                dto.CdRgBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdRgBeneficiario].ToString();
                dto.CdAcordoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdAcordoBeneficiario].ToString();
                dto.CdPlanoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdPlanoBeneficiario].ToString();
                dto.VlCobrancaBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.VlCobrancaBeneficiario].ToString();
                dto.CodTipoPad.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CodTipoPad].ToString();
                dto.DataMIEXC.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DataMIEXC].ToString();
                dto.CdSituacaoABeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdSituacaoABeneficiario].ToString();
                dto.CdCarenciaBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdCarenciaBeneficiario].ToString();
                dto.IndPag.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IndPag].ToString();
                dto.DtAtuIndPag.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtAtuIndPag].ToString();
                dto.IndNegociacao.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IndNegociacao].ToString();
                dto.DataTod.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DataTod].ToString();
                dto.IdadeBen.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdadeBen].ToString();
                dto.NmMaeBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.NmMaeBeneficiario].ToString();
                dto.IdCancelamentoAns.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdCancelamentoAns].ToString();
                dto.IdAutorizacaoANS.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdAutorizacaoANS].ToString();
                dto.VlPerc.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.VlPerc].ToString();
                dto.CdProfissionalBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdProfissionalBeneficiario].ToString();
                dto.DtAlteracaoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtAlteracaoBeneficiario].ToString();
                dto.CdNumericoEmpresa.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdNumericoEmpresa].ToString();
                dto.IdCopartExameBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdCopartExameBeneficiario].ToString();
                dto.IdCopartConsultaBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdCopartConsultaBeneficiario].ToString();
                dto.IdCronicoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdCronicoBeneficiario].ToString();
                dto.IdCopartBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdCopartBeneficiario].ToString();
                dto.IdCredencialBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdCredencialBeneficiario].ToString();
                dto.VlCobrancaAtual.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.VlCobrancaAtual].ToString();
                dto.DataCobrancaAtual.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DataCobrancaAtual].ToString();
                dto.DataRefCobrancaAtual.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DataRefCobrancaAtual].ToString();
                dto.DtEmissaoCredencial.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtEmissaoCredencial].ToString();
                dto.IdSituacaoJuridico.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdSituacaoJuridico].ToString();
                dto.DsJuridicoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DsJuridicoBeneficiario].ToString();
                dto.IdSuspensaoBoleto.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdSuspensaoBoleto].ToString();
                dto.IdDoenteCronico.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdDoenteCronico].ToString();
                dto.CdDiagnosticoCronico.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdDiagnosticoCronico].ToString();
                dto.IdRepasseBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdRepasseBeneficiario].ToString();
                dto.DtExclusaoFatura.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtExclusaoFatura].ToString();
                dto.CdLocalRepasseBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdLocalRepasseBeneficiario].ToString();
                dto.IdPiacBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdPiacBeneficiario].ToString();
                dto.IdCurativoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdCurativoBeneficiario].ToString();
                dto.DtInicioCurativoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtInicioCurativoBeneficiario].ToString();
                dto.IdHomecareBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdHomecareBeneficiario].ToString();
                dto.DtInicioHomecareBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtInicioHomecareBeneficiario].ToString();
                dto.IdMedicoFamBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdMedicoFamBeneficiario].ToString();
                dto.DtInicioMedicoFamBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtInicioMedicoFamBeneficiario].ToString();
                dto.IdSegRemissaoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdSegRemissaoBeneficiario].ToString();
                dto.IdPlanoBemBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdPlanoBemBeneficiario].ToString();
                dto.DtInicioCronicoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtInicioCronicoBeneficiario].ToString();
                dto.DtInicioPlanoBemBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtInicioPlanoBemBeneficiario].ToString();
                dto.DtInicioRepasseBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtInicioRepasseBeneficiario].ToString();
                dto.DtFinalRepasseBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtFinalRepasseBeneficiario].ToString();
                dto.CdRepasseBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdRepasseBeneficiario].ToString();
                dto.DsLocalRepasseBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DsLocalRepasseBeneficiario].ToString();
                dto.IdRepasseEmprBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdRepasseEmprBeneficiario].ToString();
                dto.DtFimPlanoBemBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtFimPlanoBemBeneficiario].ToString();
                dto.CdPlanoBemBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdPlanoBemBeneficiario].ToString();
                dto.IdAcessorioBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdAcessorioBeneficiario].ToString();
                dto.CdNacionalidadeBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdNacionalidadeBeneficiario].ToString();
                dto.CdPaisBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdPaisBeneficiario].ToString();
                dto.CdOrgaoEmissorBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdOrgaoEmissorBeneficiario].ToString();
                dto.NmPaisEmissorBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.NmPaisEmissorBeneficiario].ToString();
                dto.CdPisPasepBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdPisPasepBeneficiario].ToString();
                dto.IdAcidenteTrabalhoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdAcidenteTrabalhoBeneficiario].ToString();
                dto.CdPiacBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdPiacBeneficiario].ToString();
                dto.CdDocumentoBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdDocumentoBeneficiario].ToString();
                dto.CdNaturezaDocBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdNaturezaDocBeneficiario].ToString();
                dto.DtExpedDocBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DtExpedDocBeneficiario].ToString();
                dto.CdAtividadePrincipalBeneficiario.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdAtividadePrincipalBeneficiario].ToString();
                dto.IdOperacao.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdOperacao].ToString();
                dto.IdCartaoAutorizador.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.IdCartaoAutorizador].ToString();
                dto.DataCartaoAutorizador.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DataCartaoAutorizador].ToString();
                dto.NomeReduzido.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.NomeReduzido].ToString();
                dto.NmLogin.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.NmLogin].ToString();
                dto.CdContrato.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CdContrato].ToString();
                dto.DgContrato.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DgContrato].ToString();
                dto.CodigoPlanoANSOrigem.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.CodigoPlanoANSOrigem].ToString();
                dto.DescricaoConvenio.Value = dtb.Rows[position][BeneficiarioACSDTO.FieldNames.DescricaoConvenio].ToString();

                return dto;
            }
        }
    }

    [Serializable()]
    public class BeneficiarioACSDTO : MVC.DTO.DTOBase
    {
        private MVC.DTO.FieldString codcon;
        private MVC.DTO.FieldDecimal codest;
        private MVC.DTO.FieldDecimal codben;
        private MVC.DTO.FieldDecimal codseqben;
        private MVC.DTO.FieldString nomben;
        private MVC.DTO.FieldString codpadateben;
        private MVC.DTO.FieldString codpadcobben;
        private MVC.DTO.FieldString codindben;
        private MVC.DTO.FieldString sexben;
        private MVC.DTO.FieldString codgrapar;
        private MVC.DTO.FieldString estcivben;
        private MVC.DTO.FieldDateTime datnasben;
        private MVC.DTO.FieldDateTime datingconben;
        private MVC.DTO.FieldDateTime datadmemp;
        private MVC.DTO.FieldDateTime datsaiconben;
        private MVC.DTO.FieldString ocuempben;
        private MVC.DTO.FieldString carproben;
        private MVC.DTO.FieldDecimal codsitben;
        private MVC.DTO.FieldDateTime datlimben;
        private MVC.DTO.FieldDateTime datsitben;
        private MVC.DTO.FieldDecimal cpfben;
        private MVC.DTO.FieldString rgben;
        private MVC.DTO.FieldDecimal codaco;
        private MVC.DTO.FieldString codpla;
        private MVC.DTO.FieldDecimal valcob;
        private MVC.DTO.FieldString codtippad;
        private MVC.DTO.FieldDateTime datemiexc;
        private MVC.DTO.FieldString sitati;
        private MVC.DTO.FieldString codtipcarben;
        private MVC.DTO.FieldString indpag;
        private MVC.DTO.FieldDateTime dt_atu_indpag;
        private MVC.DTO.FieldString ind_negociacao;
        private MVC.DTO.FieldDateTime datfatod;
        private MVC.DTO.FieldDecimal idadeben;
        private MVC.DTO.FieldString maeben;
        private MVC.DTO.FieldString canc_ans;
        private MVC.DTO.FieldString id_autorizacao_ans;
        private MVC.DTO.FieldDecimal vlperc;
        private MVC.DTO.FieldDecimal codpro;
        private MVC.DTO.FieldDateTime dataltben;
        private MVC.DTO.FieldDecimal cd_empresa;
        private MVC.DTO.FieldString id_copart_exame;
        private MVC.DTO.FieldString id_copart_consulta;
        private MVC.DTO.FieldString id_cronico;
        private MVC.DTO.FieldString co_part;
        private MVC.DTO.FieldString id_emissao_carteirinha;
        private MVC.DTO.FieldDecimal vl_cobranca_atual;
        private MVC.DTO.FieldDateTime dt_cobranca_atual;
        private MVC.DTO.FieldDateTime dt_ref_cobranca_atual;
        private MVC.DTO.FieldDateTime dt_emissao_carteirinha;
        private MVC.DTO.FieldString id_contencioso;
        private MVC.DTO.FieldString ds_contencioso;
        private MVC.DTO.FieldString id_suspensao_boleto;
        private MVC.DTO.FieldString id_doente_cronico;
        private MVC.DTO.FieldString cd_cid_cronico;
        private MVC.DTO.FieldString id_repasse;
        private MVC.DTO.FieldDateTime dt_exclusao_fatura;
        private MVC.DTO.FieldString cd_local_repasse;
        private MVC.DTO.FieldString id_pac;
        private MVC.DTO.FieldString id_curativo;
        private MVC.DTO.FieldDateTime dt_ini_curativo;
        private MVC.DTO.FieldString id_homecare;
        private MVC.DTO.FieldDateTime dt_ini_homecare;
        private MVC.DTO.FieldString id_medfamilia;
        private MVC.DTO.FieldDateTime dt_ini_medfamilia;
        private MVC.DTO.FieldString id_seguro_remissao;
        private MVC.DTO.FieldString id_plano_bem;
        private MVC.DTO.FieldDateTime dt_ini_cronico;
        private MVC.DTO.FieldDateTime dt_ini_plano_bem;
        private MVC.DTO.FieldDateTime dt_inicio_repasse;
        private MVC.DTO.FieldDateTime dt_final_repasse;
        private MVC.DTO.FieldString cd_empresa_repasse;
        private MVC.DTO.FieldString ds_localidade;
        private MVC.DTO.FieldString id_empresa_repassada;
        private MVC.DTO.FieldDateTime dt_fim_plano_bem;
        private MVC.DTO.FieldString cd_plano_bem;
        private MVC.DTO.FieldString id_acessorio;
        private MVC.DTO.FieldDecimal codnac;
        private MVC.DTO.FieldDecimal codpais;
        private MVC.DTO.FieldString orgao_emissor_rg;
        private MVC.DTO.FieldDecimal pais_emissor_rg;
        private MVC.DTO.FieldDecimal pispasep;
        private MVC.DTO.FieldString ind_acidente_trabalho;
        private MVC.DTO.FieldDecimal codpac;
        private MVC.DTO.FieldString docben;
        private MVC.DTO.FieldDecimal cod_natdoc;
        private MVC.DTO.FieldDateTime dt_expedoc;
        private MVC.DTO.FieldDecimal cod_ativprinc;
        private MVC.DTO.FieldString idoper;
        private MVC.DTO.FieldString id_cartao_autorizador;
        private MVC.DTO.FieldDateTime dt_cartao_autorizador;
        private MVC.DTO.FieldString nm_reduzido;
        private MVC.DTO.FieldString ds_login;
        private MVC.DTO.FieldDecimal cd_cco;
        private MVC.DTO.FieldDecimal dv_cco;
        private MVC.DTO.FieldDecimal cdplanoans_origem;
        private MVC.DTO.FieldString cad_cnv_nm_fantasia;

        public enum RetornoBenef
        {
            Inativo = 0,
            Ativo = 1,
            Transferido = 2,
            NaoExiste = 3
        }

        public BeneficiarioACSDTO()
        {
            InitializeComponent();
        }

        internal void InitializeComponent()
        {
            this.codcon = new MVC.DTO.FieldString(FieldNames.CodigoEmpresa, Captions.CodigoEmpresa, 4);
            this.codest = new MVC.DTO.FieldDecimal(FieldNames.CodigoLoja, Captions.CodigoLoja, DbType.Decimal);
            this.codben = new MVC.DTO.FieldDecimal(FieldNames.CodigoMatricula, Captions.CodigoMatricula, DbType.Decimal);
            this.codseqben = new MVC.DTO.FieldDecimal(FieldNames.CodigoSeqMatricula, Captions.CodigoSeqMatricula, DbType.Decimal);
            this.nomben = new MVC.DTO.FieldString(FieldNames.NomeBeneficiario, Captions.NomeBeneficiario, 52);
            this.codpadateben = new MVC.DTO.FieldString(FieldNames.CdPadraoAtendimentoBeneficiario, Captions.CdPadraoAtendimentoBeneficiario, 3);
            this.codpadcobben = new MVC.DTO.FieldString(FieldNames.CdPadraoCobrancaBeneficiario, Captions.CdPadraoCobrancaBeneficiario, 3);
            this.codindben = new MVC.DTO.FieldString(FieldNames.IndicacaoTitular, Captions.IndicacaoTitular, 1);
            this.sexben = new MVC.DTO.FieldString(FieldNames.SexoBeneficiario, Captions.SexoBeneficiario, 1);
            this.codgrapar = new MVC.DTO.FieldString(FieldNames.CdGrauParentesco, Captions.CdGrauParentesco, 2);
            this.estcivben = new MVC.DTO.FieldString(FieldNames.CdEstadoCivilBeneficiario, Captions.CdEstadoCivilBeneficiario, 1);
            this.datnasben = new MVC.DTO.FieldDateTime(FieldNames.DtNascimentoBeneficiario, Captions.DtNascimentoBeneficiario);
            this.datingconben = new MVC.DTO.FieldDateTime(FieldNames.DtIngressoBeneficiario, Captions.DtIngressoBeneficiario);
            this.datadmemp = new MVC.DTO.FieldDateTime(FieldNames.DtAdmissaoEmpresaBeneficiario, Captions.DtAdmissaoEmpresaBeneficiario);
            this.datsaiconben = new MVC.DTO.FieldDateTime(FieldNames.DtSaidaBeneficiario, Captions.DtSaidaBeneficiario);
            this.ocuempben = new MVC.DTO.FieldString(FieldNames.CdOcupacaoBeneficiario, Captions.CdOcupacaoBeneficiario, 15);
            this.carproben = new MVC.DTO.FieldString(FieldNames.CdCargoBeneficiario, Captions.CdCargoBeneficiario, 15);
            this.codsitben = new MVC.DTO.FieldDecimal(FieldNames.CdSituacaoBeneficiario, Captions.CdSituacaoBeneficiario, DbType.Decimal);
            this.datlimben = new MVC.DTO.FieldDateTime(FieldNames.DtLimiteBeneficiario, Captions.DtLimiteBeneficiario);
            this.datsitben = new MVC.DTO.FieldDateTime(FieldNames.DtSituacaoBeneficiario, Captions.DtSituacaoBeneficiario);
            this.cpfben = new MVC.DTO.FieldDecimal(FieldNames.CdCpfBeneficiario, Captions.CdCpfBeneficiario, DbType.Decimal);
            this.rgben = new MVC.DTO.FieldString(FieldNames.CdRgBeneficiario, Captions.CdRgBeneficiario, 15);
            this.codaco = new MVC.DTO.FieldDecimal(FieldNames.CdAcordoBeneficiario, Captions.CdAcordoBeneficiario, DbType.Decimal);
            this.codpla = new MVC.DTO.FieldString(FieldNames.CdPlanoBeneficiario, Captions.CdPlanoBeneficiario, 15);
            this.valcob = new MVC.DTO.FieldDecimal(FieldNames.VlCobrancaBeneficiario, Captions.VlCobrancaBeneficiario, DbType.Decimal);
            this.codtippad = new MVC.DTO.FieldString(FieldNames.CodTipoPad, Captions.CodTipoPad, 1);
            this.datemiexc = new MVC.DTO.FieldDateTime(FieldNames.DataMIEXC, Captions.DataMIEXC);
            this.sitati = new MVC.DTO.FieldString(FieldNames.CdSituacaoABeneficiario, Captions.CdSituacaoABeneficiario, 1);
            this.codtipcarben = new MVC.DTO.FieldString(FieldNames.CdCarenciaBeneficiario, Captions.CdCarenciaBeneficiario, 3);
            this.indpag = new MVC.DTO.FieldString(FieldNames.IndPag, Captions.IndPag, 1);
            this.dt_atu_indpag = new MVC.DTO.FieldDateTime(FieldNames.DtAtuIndPag, Captions.DtAtuIndPag);
            this.ind_negociacao = new MVC.DTO.FieldString(FieldNames.IndNegociacao, Captions.IndNegociacao, 1);
            this.datfatod = new MVC.DTO.FieldDateTime(FieldNames.DataTod, Captions.DataTod);
            this.idadeben = new MVC.DTO.FieldDecimal(FieldNames.IdadeBen, Captions.IdadeBen, DbType.Decimal);
            this.maeben = new MVC.DTO.FieldString(FieldNames.NmMaeBeneficiario, Captions.NmMaeBeneficiario, 52);
            this.canc_ans = new MVC.DTO.FieldString(FieldNames.IdCancelamentoAns, Captions.IdCancelamentoAns, 1);
            this.id_autorizacao_ans = new MVC.DTO.FieldString(FieldNames.IdAutorizacaoANS, Captions.IdAutorizacaoANS, 1);
            this.vlperc = new MVC.DTO.FieldDecimal(FieldNames.VlPerc, Captions.VlPerc, DbType.Decimal);
            this.codpro = new MVC.DTO.FieldDecimal(FieldNames.CdProfissionalBeneficiario, Captions.CdProfissionalBeneficiario, DbType.Decimal);
            this.dataltben = new MVC.DTO.FieldDateTime(FieldNames.DtAlteracaoBeneficiario, Captions.DtAlteracaoBeneficiario);
            this.cd_empresa = new MVC.DTO.FieldDecimal(FieldNames.CdNumericoEmpresa, Captions.CdNumericoEmpresa, DbType.Decimal);
            this.id_copart_exame = new MVC.DTO.FieldString(FieldNames.IdCopartExameBeneficiario, Captions.IdCopartExameBeneficiario, 1);
            this.id_copart_consulta = new MVC.DTO.FieldString(FieldNames.IdCopartConsultaBeneficiario, Captions.IdCopartConsultaBeneficiario, 1);
            this.id_cronico = new MVC.DTO.FieldString(FieldNames.IdCronicoBeneficiario, Captions.IdCronicoBeneficiario, 1);
            this.co_part = new MVC.DTO.FieldString(FieldNames.IdCopartBeneficiario, Captions.IdCopartBeneficiario, 1);
            this.id_emissao_carteirinha = new MVC.DTO.FieldString(FieldNames.IdCredencialBeneficiario, Captions.IdCredencialBeneficiario, 1);
            this.vl_cobranca_atual = new MVC.DTO.FieldDecimal(FieldNames.VlCobrancaAtual, Captions.VlCobrancaAtual, DbType.Decimal);
            this.dt_cobranca_atual = new MVC.DTO.FieldDateTime(FieldNames.DataCobrancaAtual, Captions.DataCobrancaAtual);
            this.dt_ref_cobranca_atual = new MVC.DTO.FieldDateTime(FieldNames.DataRefCobrancaAtual, Captions.DataRefCobrancaAtual);
            this.dt_emissao_carteirinha = new MVC.DTO.FieldDateTime(FieldNames.DtEmissaoCredencial, Captions.DtEmissaoCredencial);
            this.id_contencioso = new MVC.DTO.FieldString(FieldNames.IdSituacaoJuridico, Captions.IdSituacaoJuridico, 1);
            this.ds_contencioso = new MVC.DTO.FieldString(FieldNames.DsJuridicoBeneficiario, Captions.DsJuridicoBeneficiario, 2000);
            this.id_suspensao_boleto = new MVC.DTO.FieldString(FieldNames.IdSuspensaoBoleto, Captions.IdSuspensaoBoleto, 1);
            this.id_doente_cronico = new MVC.DTO.FieldString(FieldNames.IdDoenteCronico, Captions.IdDoenteCronico, 1);
            this.cd_cid_cronico = new MVC.DTO.FieldString(FieldNames.CdDiagnosticoCronico, Captions.CdDiagnosticoCronico, 5);
            this.id_repasse = new MVC.DTO.FieldString(FieldNames.IdRepasseBeneficiario, Captions.IdRepasseBeneficiario, 1);
            this.dt_exclusao_fatura = new MVC.DTO.FieldDateTime(FieldNames.DtExclusaoFatura, Captions.DtExclusaoFatura);
            this.cd_local_repasse = new MVC.DTO.FieldString(FieldNames.CdLocalRepasseBeneficiario, Captions.CdLocalRepasseBeneficiario, 2);
            this.id_pac = new MVC.DTO.FieldString(FieldNames.IdPiacBeneficiario, Captions.IdPiacBeneficiario, 1);
            this.id_curativo = new MVC.DTO.FieldString(FieldNames.IdCurativoBeneficiario, Captions.IdCurativoBeneficiario, 1);
            this.dt_ini_curativo = new MVC.DTO.FieldDateTime(FieldNames.DtInicioCurativoBeneficiario, Captions.DtInicioCurativoBeneficiario);
            this.id_homecare = new MVC.DTO.FieldString(FieldNames.IdHomecareBeneficiario, Captions.IdHomecareBeneficiario, 1);
            this.dt_ini_homecare = new MVC.DTO.FieldDateTime(FieldNames.DtInicioHomecareBeneficiario, Captions.DtInicioHomecareBeneficiario);
            this.id_medfamilia = new MVC.DTO.FieldString(FieldNames.IdMedicoFamBeneficiario, Captions.IdMedicoFamBeneficiario, 1);
            this.dt_ini_medfamilia = new MVC.DTO.FieldDateTime(FieldNames.DtInicioMedicoFamBeneficiario, Captions.DtInicioMedicoFamBeneficiario);
            this.id_seguro_remissao = new MVC.DTO.FieldString(FieldNames.IdSegRemissaoBeneficiario, Captions.IdSegRemissaoBeneficiario, 1);
            this.id_plano_bem = new MVC.DTO.FieldString(FieldNames.IdPlanoBemBeneficiario, Captions.IdPlanoBemBeneficiario, 1);
            this.dt_ini_cronico = new MVC.DTO.FieldDateTime(FieldNames.DtInicioCronicoBeneficiario, Captions.DtInicioCronicoBeneficiario);
            this.dt_ini_plano_bem = new MVC.DTO.FieldDateTime(FieldNames.DtInicioPlanoBemBeneficiario, Captions.DtInicioPlanoBemBeneficiario);
            this.dt_inicio_repasse = new MVC.DTO.FieldDateTime(FieldNames.DtInicioRepasseBeneficiario, Captions.DtInicioRepasseBeneficiario);
            this.dt_final_repasse = new MVC.DTO.FieldDateTime(FieldNames.DtFinalRepasseBeneficiario, Captions.DtFinalRepasseBeneficiario);
            this.cd_empresa_repasse = new MVC.DTO.FieldString(FieldNames.CdRepasseBeneficiario, Captions.CdRepasseBeneficiario, 4);
            this.ds_localidade = new MVC.DTO.FieldString(FieldNames.DsLocalRepasseBeneficiario, Captions.DsLocalRepasseBeneficiario, 14);
            this.id_empresa_repassada = new MVC.DTO.FieldString(FieldNames.IdRepasseEmprBeneficiario, Captions.IdRepasseEmprBeneficiario, 20);
            this.dt_fim_plano_bem = new MVC.DTO.FieldDateTime(FieldNames.DtFimPlanoBemBeneficiario, Captions.DtFimPlanoBemBeneficiario);
            this.cd_plano_bem = new MVC.DTO.FieldString(FieldNames.CdPlanoBemBeneficiario, Captions.CdPlanoBemBeneficiario, 15);
            this.id_acessorio = new MVC.DTO.FieldString(FieldNames.IdAcessorioBeneficiario, Captions.IdAcessorioBeneficiario, 1);
            this.codnac = new MVC.DTO.FieldDecimal(FieldNames.CdNacionalidadeBeneficiario, Captions.CdNacionalidadeBeneficiario, DbType.Decimal);
            this.codpais = new MVC.DTO.FieldDecimal(FieldNames.CdPaisBeneficiario, Captions.CdPaisBeneficiario, DbType.Decimal);
            this.orgao_emissor_rg = new MVC.DTO.FieldString(FieldNames.CdOrgaoEmissorBeneficiario, Captions.CdOrgaoEmissorBeneficiario, 20);
            this.pais_emissor_rg = new MVC.DTO.FieldDecimal(FieldNames.NmPaisEmissorBeneficiario, Captions.NmPaisEmissorBeneficiario, DbType.Decimal);
            this.pispasep = new MVC.DTO.FieldDecimal(FieldNames.CdPisPasepBeneficiario, Captions.CdPisPasepBeneficiario, DbType.Decimal);
            this.ind_acidente_trabalho = new MVC.DTO.FieldString(FieldNames.IdAcidenteTrabalhoBeneficiario, Captions.IdAcidenteTrabalhoBeneficiario, 1);
            this.codpac = new MVC.DTO.FieldDecimal(FieldNames.CdPiacBeneficiario, Captions.CdPiacBeneficiario, DbType.Decimal);
            this.docben = new MVC.DTO.FieldString(FieldNames.CdDocumentoBeneficiario, Captions.CdDocumentoBeneficiario, 30);
            this.cod_natdoc = new MVC.DTO.FieldDecimal(FieldNames.CdNaturezaDocBeneficiario, Captions.CdNaturezaDocBeneficiario, DbType.Decimal);
            this.dt_expedoc = new MVC.DTO.FieldDateTime(FieldNames.DtExpedDocBeneficiario, Captions.DtExpedDocBeneficiario);
            this.cod_ativprinc = new MVC.DTO.FieldDecimal(FieldNames.CdAtividadePrincipalBeneficiario, Captions.CdAtividadePrincipalBeneficiario, DbType.Decimal);
            this.idoper = new MVC.DTO.FieldString(FieldNames.IdOperacao, Captions.IdOperacao, 30);
            this.id_cartao_autorizador = new MVC.DTO.FieldString(FieldNames.IdCartaoAutorizador, Captions.IdCartaoAutorizador, 1);
            this.dt_cartao_autorizador = new MVC.DTO.FieldDateTime(FieldNames.DataCartaoAutorizador, Captions.DataCartaoAutorizador);
            this.nm_reduzido = new MVC.DTO.FieldString(FieldNames.NomeReduzido, Captions.NomeReduzido, 27);
            this.ds_login = new MVC.DTO.FieldString(FieldNames.NmLogin, Captions.NmLogin, 30);
            this.cd_cco = new MVC.DTO.FieldDecimal(FieldNames.CdContrato, Captions.CdContrato, DbType.Decimal);
            this.dv_cco = new MVC.DTO.FieldDecimal(FieldNames.DgContrato, Captions.DgContrato, DbType.Decimal);
            this.cdplanoans_origem = new MVC.DTO.FieldDecimal(FieldNames.CodigoPlanoANSOrigem, Captions.CodigoPlanoANSOrigem, DbType.Decimal);
            this.cad_cnv_nm_fantasia = new MVC.DTO.FieldString(FieldNames.DescricaoConvenio, Captions.DescricaoConvenio, 60);
        }

        #region FieldNames

        public struct FieldNames
        {
            public const string CodigoEmpresa = "CODCON";
            public const string CodigoLoja = "CODEST";
            public const string CodigoMatricula = "CODBEN";
            public const string CodigoSeqMatricula = "CODSEQBEN";
            public const string NomeBeneficiario = "NOMBEN";
            public const string CdPadraoAtendimentoBeneficiario = "CODPADATEBEN";
            public const string CdPadraoCobrancaBeneficiario = "CODPADCOBBEN";
            public const string IndicacaoTitular = "CODINDBEN";
            public const string SexoBeneficiario = "SEXBEN";
            public const string CdGrauParentesco = "CODGRAPAR";
            public const string CdEstadoCivilBeneficiario = "ESTCIVBEN";
            public const string DtNascimentoBeneficiario = "DATNASBEN";
            public const string DtIngressoBeneficiario = "DATINGCONBEN";
            public const string DtAdmissaoEmpresaBeneficiario = "DATADMEMP";
            public const string DtSaidaBeneficiario = "DATSAICONBEN";
            public const string CdOcupacaoBeneficiario = "OCUEMPBEN";
            public const string CdCargoBeneficiario = "CARPROBEN";
            public const string CdSituacaoBeneficiario = "CODSITBEN";
            public const string DtLimiteBeneficiario = "DATLIMBEN";
            public const string DtSituacaoBeneficiario = "DATSITBEN";
            public const string CdCpfBeneficiario = "CPFBEN";
            public const string CdRgBeneficiario = "RGBEN";
            public const string CdAcordoBeneficiario = "CODACO";
            public const string CdPlanoBeneficiario = "CODPLA";
            public const string VlCobrancaBeneficiario = "VALCOB";
            public const string CodTipoPad = "CODTIPPAD";
            public const string DataMIEXC = "DATEMIEXC";
            public const string CdSituacaoABeneficiario = "SITATI";
            public const string CdCarenciaBeneficiario = "CODTIPCARBEN";
            public const string IndPag = "INDPAG";
            public const string DtAtuIndPag = "DT_ATU_INDPAG";
            public const string IndNegociacao = "IND_NEGOCIACAO";
            public const string DataTod = "DATFATOD";
            public const string IdadeBen = "IDADEBEN";
            public const string NmMaeBeneficiario = "MAEBEN";
            public const string IdCancelamentoAns = "CANC_ANS";
            public const string IdAutorizacaoANS = "ID_AUTORIZACAO_ANS";
            public const string VlPerc = "VLPERC";
            public const string CdProfissionalBeneficiario = "CODPRO";
            public const string DtAlteracaoBeneficiario = "DATALTBEN";
            public const string CdNumericoEmpresa = "CD_EMPRESA";
            public const string IdCopartExameBeneficiario = "ID_COPART_EXAME";
            public const string IdCopartConsultaBeneficiario = "ID_COPART_CONSULTA";
            public const string IdCronicoBeneficiario = "ID_CRONICO";
            public const string IdCopartBeneficiario = "CO_PART";
            public const string IdCredencialBeneficiario = "ID_EMISSAO_CARTEIRINHA";
            public const string VlCobrancaAtual = "VL_COBRANCA_ATUAL";
            public const string DataCobrancaAtual = "DT_COBRANCA_ATUAL";
            public const string DataRefCobrancaAtual = "DT_REF_COBRANCA_ATUAL";
            public const string DtEmissaoCredencial = "DT_EMISSAO_CARTEIRINHA";
            public const string IdSituacaoJuridico = "ID_CONTENCIOSO";
            public const string DsJuridicoBeneficiario = "DS_CONTENCIOSO";
            public const string IdSuspensaoBoleto = "ID_SUSPENSAO_BOLETO";
            public const string IdDoenteCronico = "ID_DOENTE_CRONICO";
            public const string CdDiagnosticoCronico = "CD_CID_CRONICO";
            public const string IdRepasseBeneficiario = "ID_REPASSE";
            public const string DtExclusaoFatura = "DT_EXCLUSAO_FATURA";
            public const string CdLocalRepasseBeneficiario = "CD_LOCAL_REPASSE";
            public const string IdPiacBeneficiario = "ID_PAC";
            public const string IdCurativoBeneficiario = "ID_CURATIVO";
            public const string DtInicioCurativoBeneficiario = "DT_INI_CURATIVO";
            public const string IdHomecareBeneficiario = "ID_HOMECARE";
            public const string DtInicioHomecareBeneficiario = "DT_INI_HOMECARE";
            public const string IdMedicoFamBeneficiario = "ID_MEDFAMILIA";
            public const string DtInicioMedicoFamBeneficiario = "DT_INI_MEDFAMILIA";
            public const string IdSegRemissaoBeneficiario = "ID_SEGURO_REMISSAO";
            public const string IdPlanoBemBeneficiario = "ID_PLANO_BEM";
            public const string DtInicioCronicoBeneficiario = "DT_INI_CRONICO";
            public const string DtInicioPlanoBemBeneficiario = "DT_INI_PLANO_BEM";
            public const string DtInicioRepasseBeneficiario = "DT_INICIO_REPASSE";
            public const string DtFinalRepasseBeneficiario = "DT_FINAL_REPASSE";
            public const string CdRepasseBeneficiario = "CD_EMPRESA_REPASSE";
            public const string DsLocalRepasseBeneficiario = "DS_LOCALIDADE";
            public const string IdRepasseEmprBeneficiario = "ID_EMPRESA_REPASSADA";
            public const string DtFimPlanoBemBeneficiario = "DT_FIM_PLANO_BEM";
            public const string CdPlanoBemBeneficiario = "CD_PLANO_BEM";
            public const string IdAcessorioBeneficiario = "ID_ACESSORIO";
            public const string CdNacionalidadeBeneficiario = "CODNAC";
            public const string CdPaisBeneficiario = "CODPAIS";
            public const string CdOrgaoEmissorBeneficiario = "ORGAO_EMISSOR_RG";
            public const string NmPaisEmissorBeneficiario = "PAIS_EMISSOR_RG";
            public const string CdPisPasepBeneficiario = "PISPASEP";
            public const string IdAcidenteTrabalhoBeneficiario = "IND_ACIDENTE_TRABALHO";
            public const string CdPiacBeneficiario = "CODPAC";
            public const string CdDocumentoBeneficiario = "DOCBEN";
            public const string CdNaturezaDocBeneficiario = "COD_NATDOC";
            public const string DtExpedDocBeneficiario = "DT_EXPEDOC";
            public const string CdAtividadePrincipalBeneficiario = "COD_ATIVPRINC";
            public const string IdOperacao = "IDOPER";
            public const string IdCartaoAutorizador = "ID_CARTAO_AUTORIZADOR";
            public const string DataCartaoAutorizador = "DT_CARTAO_AUTORIZADOR";
            public const string NomeReduzido = "NM_REDUZIDO";
            public const string NmLogin = "DS_LOGIN";
            public const string CdContrato = "CD_CCO";
            public const string DgContrato = "DV_CCO";
            public const string CodigoPlanoANSOrigem = "CDPLANOANS_ORIGEM";
            public const string DescricaoConvenio = "CAD_CNV_NM_FANTASIA";
        }

        #endregion

        #region Captions

        public struct Captions
        {
            public const string CodigoEmpresa = "CODIGOEMPRESA";
            public const string CodigoLoja = "CODIGOLOJA";
            public const string CodigoMatricula = "CODIGOMATRICULA";
            public const string CodigoSeqMatricula = "CODIGOSEQMATRICULA";
            public const string NomeBeneficiario = "NOMEBENEFICIARIO";
            public const string CdPadraoAtendimentoBeneficiario = "CDPADRAOATENDIMENTOBENEFICIARIO";
            public const string CdPadraoCobrancaBeneficiario = "CDPADRAOCOBRANCABENEFICIARIO";
            public const string IndicacaoTitular = "INDICACAOTITULAR";
            public const string SexoBeneficiario = "SEXOBENEFICIARIO";
            public const string CdGrauParentesco = "CDGRAUPARENTESCO";
            public const string CdEstadoCivilBeneficiario = "CDESTADOCIVILBENEFICIARIO";
            public const string DtNascimentoBeneficiario = "DTNASCIMENTOBENEFICIARIO";
            public const string DtIngressoBeneficiario = "DTINGRESSOBENEFICIARIO";
            public const string DtAdmissaoEmpresaBeneficiario = "DTADMISSAOEMPRESABENEFICIARIO";
            public const string DtSaidaBeneficiario = "DTSAIDABENEFICIARIO";
            public const string CdOcupacaoBeneficiario = "CDOCUPACAOBENEFICIARIO";
            public const string CdCargoBeneficiario = "CDCARGOBENEFICIARIO";
            public const string CdSituacaoBeneficiario = "CDSITUACAOBENEFICIARIO";
            public const string DtLimiteBeneficiario = "DTLIMITEBENEFICIARIO";
            public const string DtSituacaoBeneficiario = "DTSITUACAOBENEFICIARIO";
            public const string CdCpfBeneficiario = "CDCPFBENEFICIARIO";
            public const string CdRgBeneficiario = "CDRGBENEFICIARIO";
            public const string CdAcordoBeneficiario = "CDACORDOBENEFICIARIO";
            public const string CdPlanoBeneficiario = "CDPLANOBENEFICIARIO";
            public const string VlCobrancaBeneficiario = "VLCOBRANCABENEFICIARIO";
            public const string CodTipoPad = "CODTIPOPAD";
            public const string DataMIEXC = "DATAMIEXC";
            public const string CdSituacaoABeneficiario = "CDSITUACAOABENEFICIARIO";
            public const string CdCarenciaBeneficiario = "CDCARENCIABENEFICIARIO";
            public const string IndPag = "INDPAG";
            public const string DtAtuIndPag = "DTATUINDPAG";
            public const string IndNegociacao = "INDNEGOCIACAO";
            public const string DataTod = "DATATOD";
            public const string IdadeBen = "IDADEBEN";
            public const string NmMaeBeneficiario = "NMMAEBENEFICIARIO";
            public const string IdCancelamentoAns = "IDCANCELAMENTOANS";
            public const string IdAutorizacaoANS = "IDAUTORIZACAOANS";
            public const string VlPerc = "VLPERC";
            public const string CdProfissionalBeneficiario = "CDPROFISSIONALBENEFICIARIO";
            public const string DtAlteracaoBeneficiario = "DTALTERACAOBENEFICIARIO";
            public const string CdNumericoEmpresa = "CDNUMERICOEMPRESA";
            public const string IdCopartExameBeneficiario = "IDCOPARTEXAMEBENEFICIARIO";
            public const string IdCopartConsultaBeneficiario = "IDCOPARTCONSULTABENEFICIARIO";
            public const string IdCronicoBeneficiario = "IDCRONICOBENEFICIARIO";
            public const string IdCopartBeneficiario = "IDCOPARTBENEFICIARIO";
            public const string IdCredencialBeneficiario = "IDCREDENCIALBENEFICIARIO";
            public const string VlCobrancaAtual = "VLCOBRANCAATUAL";
            public const string DataCobrancaAtual = "DATACOBRANCAATUAL";
            public const string DataRefCobrancaAtual = "DATAREFCOBRANCAATUAL";
            public const string DtEmissaoCredencial = "DTEMISSAOCREDENCIAL";
            public const string IdSituacaoJuridico = "IDSITUACAOJURIDICO";
            public const string DsJuridicoBeneficiario = "DSJURIDICOBENEFICIARIO";
            public const string IdSuspensaoBoleto = "IDSUSPENSAOBOLETO";
            public const string IdDoenteCronico = "IDDOENTECRONICO";
            public const string CdDiagnosticoCronico = "CDDIAGNOSTICOCRONICO";
            public const string IdRepasseBeneficiario = "IDREPASSEBENEFICIARIO";
            public const string DtExclusaoFatura = "DTEXCLUSAOFATURA";
            public const string CdLocalRepasseBeneficiario = "CDLOCALREPASSEBENEFICIARIO";
            public const string IdPiacBeneficiario = "IDPIACBENEFICIARIO";
            public const string IdCurativoBeneficiario = "IDCURATIVOBENEFICIARIO";
            public const string DtInicioCurativoBeneficiario = "DTINICIOCURATIVOBENEFICIARIO";
            public const string IdHomecareBeneficiario = "IDHOMECAREBENEFICIARIO";
            public const string DtInicioHomecareBeneficiario = "DTINICIOHOMECAREBENEFICIARIO";
            public const string IdMedicoFamBeneficiario = "IDMEDICOFAMBENEFICIARIO";
            public const string DtInicioMedicoFamBeneficiario = "DTINICIOMEDICOFAMBENEFICIARIO";
            public const string IdSegRemissaoBeneficiario = "IDSEGREMISSAOBENEFICIARIO";
            public const string IdPlanoBemBeneficiario = "IDPLANOBEMBENEFICIARIO";
            public const string DtInicioCronicoBeneficiario = "DTINICIOCRONICOBENEFICIARIO";
            public const string DtInicioPlanoBemBeneficiario = "DTINICIOPLANOBEMBENEFICIARIO";
            public const string DtInicioRepasseBeneficiario = "DTINICIOREPASSEBENEFICIARIO";
            public const string DtFinalRepasseBeneficiario = "DTFINALREPASSEBENEFICIARIO";
            public const string CdRepasseBeneficiario = "CDREPASSEBENEFICIARIO";
            public const string DsLocalRepasseBeneficiario = "DSLOCALREPASSEBENEFICIARIO";
            public const string IdRepasseEmprBeneficiario = "IDREPASSEEMPRBENEFICIARIO";
            public const string DtFimPlanoBemBeneficiario = "DTFIMPLANOBEMBENEFICIARIO";
            public const string CdPlanoBemBeneficiario = "CDPLANOBEMBENEFICIARIO";
            public const string IdAcessorioBeneficiario = "IDACESSORIOBENEFICIARIO";
            public const string CdNacionalidadeBeneficiario = "CDNACIONALIDADEBENEFICIARIO";
            public const string CdPaisBeneficiario = "CDPAISBENEFICIARIO";
            public const string CdOrgaoEmissorBeneficiario = "CDORGAOEMISSORBENEFICIARIO";
            public const string NmPaisEmissorBeneficiario = "NMPAISEMISSORBENEFICIARIO";
            public const string CdPisPasepBeneficiario = "CDPISPASEPBENEFICIARIO";
            public const string IdAcidenteTrabalhoBeneficiario = "IDACIDENTETRABALHOBENEFICIARIO";
            public const string CdPiacBeneficiario = "CDPIACBENEFICIARIO";
            public const string CdDocumentoBeneficiario = "CDDOCUMENTOBENEFICIARIO";
            public const string CdNaturezaDocBeneficiario = "CDNATUREZADOCBENEFICIARIO";
            public const string DtExpedDocBeneficiario = "DTEXPEDDOCBENEFICIARIO";
            public const string CdAtividadePrincipalBeneficiario = "CDATIVIDADEPRINCIPALBENEFICIARIO";
            public const string IdOperacao = "IDOPERACAO";
            public const string IdCartaoAutorizador = "IDCARTAOAUTORIZADOR";
            public const string DataCartaoAutorizador = "DATACARTAOAUTORIZADOR";
            public const string NomeReduzido = "NOMEREDUZIDO";
            public const string NmLogin = "NMLOGIN";
            public const string CdContrato = "CDCONTRATO";
            public const string DgContrato = "DGCONTRATO";
            public const string CodigoPlanoANSOrigem = "CODIGOPLANOANSORIGEM";
            public const string DescricaoConvenio = "CADPLANMNOMEPLANO";
        }

        #endregion

        #region Atributos Publicos

        public MVC.DTO.FieldString CodigoEmpresa
        {
            get { return codcon; }
            set { codcon = value; }
        }


        public MVC.DTO.FieldDecimal CodigoLoja
        {
            get { return codest; }
            set { codest = value; }
        }


        public MVC.DTO.FieldDecimal CodigoMatricula
        {
            get { return codben; }
            set { codben = value; }
        }


        public MVC.DTO.FieldDecimal CodigoSeqMatricula
        {
            get { return codseqben; }
            set { codseqben = value; }
        }


        public MVC.DTO.FieldString NomeBeneficiario
        {
            get { return nomben; }
            set { nomben = value; }
        }


        public MVC.DTO.FieldString CdPadraoAtendimentoBeneficiario
        {
            get { return codpadateben; }
            set { codpadateben = value; }
        }


        public MVC.DTO.FieldString CdPadraoCobrancaBeneficiario
        {
            get { return codpadcobben; }
            set { codpadcobben = value; }
        }


        public MVC.DTO.FieldString IndicacaoTitular
        {
            get { return codindben; }
            set { codindben = value; }
        }


        public MVC.DTO.FieldString SexoBeneficiario
        {
            get { return sexben; }
            set { sexben = value; }
        }


        public MVC.DTO.FieldString CdGrauParentesco
        {
            get { return codgrapar; }
            set { codgrapar = value; }
        }


        public MVC.DTO.FieldString CdEstadoCivilBeneficiario
        {
            get { return estcivben; }
            set { estcivben = value; }
        }


        public MVC.DTO.FieldDateTime DtNascimentoBeneficiario
        {
            get { return datnasben; }
            set { datnasben = value; }
        }


        public MVC.DTO.FieldDateTime DtIngressoBeneficiario
        {
            get { return datingconben; }
            set { datingconben = value; }
        }


        public MVC.DTO.FieldDateTime DtAdmissaoEmpresaBeneficiario
        {
            get { return datadmemp; }
            set { datadmemp = value; }
        }


        public MVC.DTO.FieldDateTime DtSaidaBeneficiario
        {
            get { return datsaiconben; }
            set { datsaiconben = value; }
        }


        public MVC.DTO.FieldString CdOcupacaoBeneficiario
        {
            get { return ocuempben; }
            set { ocuempben = value; }
        }


        public MVC.DTO.FieldString CdCargoBeneficiario
        {
            get { return carproben; }
            set { carproben = value; }
        }


        public MVC.DTO.FieldDecimal CdSituacaoBeneficiario
        {
            get { return codsitben; }
            set { codsitben = value; }
        }


        public MVC.DTO.FieldDateTime DtLimiteBeneficiario
        {
            get { return datlimben; }
            set { datlimben = value; }
        }


        public MVC.DTO.FieldDateTime DtSituacaoBeneficiario
        {
            get { return datsitben; }
            set { datsitben = value; }
        }


        public MVC.DTO.FieldDecimal CdCpfBeneficiario
        {
            get { return cpfben; }
            set { cpfben = value; }
        }


        public MVC.DTO.FieldString CdRgBeneficiario
        {
            get { return rgben; }
            set { rgben = value; }
        }


        public MVC.DTO.FieldDecimal CdAcordoBeneficiario
        {
            get { return codaco; }
            set { codaco = value; }
        }


        public MVC.DTO.FieldString CdPlanoBeneficiario
        {
            get { return codpla; }
            set { codpla = value; }
        }


        public MVC.DTO.FieldDecimal VlCobrancaBeneficiario
        {
            get { return valcob; }
            set { valcob = value; }
        }


        public MVC.DTO.FieldString CodTipoPad
        {
            get { return codtippad; }
            set { codtippad = value; }
        }


        public MVC.DTO.FieldDateTime DataMIEXC
        {
            get { return datemiexc; }
            set { datemiexc = value; }
        }


        public MVC.DTO.FieldString CdSituacaoABeneficiario
        {
            get { return sitati; }
            set { sitati = value; }
        }


        public MVC.DTO.FieldString CdCarenciaBeneficiario
        {
            get { return codtipcarben; }
            set { codtipcarben = value; }
        }


        public MVC.DTO.FieldString IndPag
        {
            get { return indpag; }
            set { indpag = value; }
        }


        public MVC.DTO.FieldDateTime DtAtuIndPag
        {
            get { return dt_atu_indpag; }
            set { dt_atu_indpag = value; }
        }


        public MVC.DTO.FieldString IndNegociacao
        {
            get { return ind_negociacao; }
            set { ind_negociacao = value; }
        }


        public MVC.DTO.FieldDateTime DataTod
        {
            get { return datfatod; }
            set { datfatod = value; }
        }


        public MVC.DTO.FieldDecimal IdadeBen
        {
            get { return idadeben; }
            set { idadeben = value; }
        }


        public MVC.DTO.FieldString NmMaeBeneficiario
        {
            get { return maeben; }
            set { maeben = value; }
        }


        public MVC.DTO.FieldString IdCancelamentoAns
        {
            get { return canc_ans; }
            set { canc_ans = value; }
        }


        public MVC.DTO.FieldString IdAutorizacaoANS
        {
            get { return id_autorizacao_ans; }
            set { id_autorizacao_ans = value; }
        }


        public MVC.DTO.FieldDecimal VlPerc
        {
            get { return vlperc; }
            set { vlperc = value; }
        }


        public MVC.DTO.FieldDecimal CdProfissionalBeneficiario
        {
            get { return codpro; }
            set { codpro = value; }
        }


        public MVC.DTO.FieldDateTime DtAlteracaoBeneficiario
        {
            get { return dataltben; }
            set { dataltben = value; }
        }


        public MVC.DTO.FieldDecimal CdNumericoEmpresa
        {
            get { return cd_empresa; }
            set { cd_empresa = value; }
        }


        public MVC.DTO.FieldString IdCopartExameBeneficiario
        {
            get { return id_copart_exame; }
            set { id_copart_exame = value; }
        }


        public MVC.DTO.FieldString IdCopartConsultaBeneficiario
        {
            get { return id_copart_consulta; }
            set { id_copart_consulta = value; }
        }


        public MVC.DTO.FieldString IdCronicoBeneficiario
        {
            get { return id_cronico; }
            set { id_cronico = value; }
        }


        public MVC.DTO.FieldString IdCopartBeneficiario
        {
            get { return co_part; }
            set { co_part = value; }
        }


        public MVC.DTO.FieldString IdCredencialBeneficiario
        {
            get { return id_emissao_carteirinha; }
            set { id_emissao_carteirinha = value; }
        }


        public MVC.DTO.FieldDecimal VlCobrancaAtual
        {
            get { return vl_cobranca_atual; }
            set { vl_cobranca_atual = value; }
        }


        public MVC.DTO.FieldDateTime DataCobrancaAtual
        {
            get { return dt_cobranca_atual; }
            set { dt_cobranca_atual = value; }
        }


        public MVC.DTO.FieldDateTime DataRefCobrancaAtual
        {
            get { return dt_ref_cobranca_atual; }
            set { dt_ref_cobranca_atual = value; }
        }


        public MVC.DTO.FieldDateTime DtEmissaoCredencial
        {
            get { return dt_emissao_carteirinha; }
            set { dt_emissao_carteirinha = value; }
        }


        public MVC.DTO.FieldString IdSituacaoJuridico
        {
            get { return id_contencioso; }
            set { id_contencioso = value; }
        }


        public MVC.DTO.FieldString DsJuridicoBeneficiario
        {
            get { return ds_contencioso; }
            set { ds_contencioso = value; }
        }


        public MVC.DTO.FieldString IdSuspensaoBoleto
        {
            get { return id_suspensao_boleto; }
            set { id_suspensao_boleto = value; }
        }


        public MVC.DTO.FieldString IdDoenteCronico
        {
            get { return id_doente_cronico; }
            set { id_doente_cronico = value; }
        }


        public MVC.DTO.FieldString CdDiagnosticoCronico
        {
            get { return cd_cid_cronico; }
            set { cd_cid_cronico = value; }
        }


        public MVC.DTO.FieldString IdRepasseBeneficiario
        {
            get { return id_repasse; }
            set { id_repasse = value; }
        }


        public MVC.DTO.FieldDateTime DtExclusaoFatura
        {
            get { return dt_exclusao_fatura; }
            set { dt_exclusao_fatura = value; }
        }


        public MVC.DTO.FieldString CdLocalRepasseBeneficiario
        {
            get { return cd_local_repasse; }
            set { cd_local_repasse = value; }
        }


        public MVC.DTO.FieldString IdPiacBeneficiario
        {
            get { return id_pac; }
            set { id_pac = value; }
        }


        public MVC.DTO.FieldString IdCurativoBeneficiario
        {
            get { return id_curativo; }
            set { id_curativo = value; }
        }


        public MVC.DTO.FieldDateTime DtInicioCurativoBeneficiario
        {
            get { return dt_ini_curativo; }
            set { dt_ini_curativo = value; }
        }


        public MVC.DTO.FieldString IdHomecareBeneficiario
        {
            get { return id_homecare; }
            set { id_homecare = value; }
        }


        public MVC.DTO.FieldDateTime DtInicioHomecareBeneficiario
        {
            get { return dt_ini_homecare; }
            set { dt_ini_homecare = value; }
        }


        public MVC.DTO.FieldString IdMedicoFamBeneficiario
        {
            get { return id_medfamilia; }
            set { id_medfamilia = value; }
        }


        public MVC.DTO.FieldDateTime DtInicioMedicoFamBeneficiario
        {
            get { return dt_ini_medfamilia; }
            set { dt_ini_medfamilia = value; }
        }


        public MVC.DTO.FieldString IdSegRemissaoBeneficiario
        {
            get { return id_seguro_remissao; }
            set { id_seguro_remissao = value; }
        }


        public MVC.DTO.FieldString IdPlanoBemBeneficiario
        {
            get { return id_plano_bem; }
            set { id_plano_bem = value; }
        }


        public MVC.DTO.FieldDateTime DtInicioCronicoBeneficiario
        {
            get { return dt_ini_cronico; }
            set { dt_ini_cronico = value; }
        }


        public MVC.DTO.FieldDateTime DtInicioPlanoBemBeneficiario
        {
            get { return dt_ini_plano_bem; }
            set { dt_ini_plano_bem = value; }
        }


        public MVC.DTO.FieldDateTime DtInicioRepasseBeneficiario
        {
            get { return dt_inicio_repasse; }
            set { dt_inicio_repasse = value; }
        }


        public MVC.DTO.FieldDateTime DtFinalRepasseBeneficiario
        {
            get { return dt_final_repasse; }
            set { dt_final_repasse = value; }
        }


        public MVC.DTO.FieldString CdRepasseBeneficiario
        {
            get { return cd_empresa_repasse; }
            set { cd_empresa_repasse = value; }
        }


        public MVC.DTO.FieldString DsLocalRepasseBeneficiario
        {
            get { return ds_localidade; }
            set { ds_localidade = value; }
        }


        public MVC.DTO.FieldString IdRepasseEmprBeneficiario
        {
            get { return id_empresa_repassada; }
            set { id_empresa_repassada = value; }
        }


        public MVC.DTO.FieldDateTime DtFimPlanoBemBeneficiario
        {
            get { return dt_fim_plano_bem; }
            set { dt_fim_plano_bem = value; }
        }


        public MVC.DTO.FieldString CdPlanoBemBeneficiario
        {
            get { return cd_plano_bem; }
            set { cd_plano_bem = value; }
        }


        public MVC.DTO.FieldString IdAcessorioBeneficiario
        {
            get { return id_acessorio; }
            set { id_acessorio = value; }
        }


        public MVC.DTO.FieldDecimal CdNacionalidadeBeneficiario
        {
            get { return codnac; }
            set { codnac = value; }
        }


        public MVC.DTO.FieldDecimal CdPaisBeneficiario
        {
            get { return codpais; }
            set { codpais = value; }
        }


        public MVC.DTO.FieldString CdOrgaoEmissorBeneficiario
        {
            get { return orgao_emissor_rg; }
            set { orgao_emissor_rg = value; }
        }


        public MVC.DTO.FieldDecimal NmPaisEmissorBeneficiario
        {
            get { return pais_emissor_rg; }
            set { pais_emissor_rg = value; }
        }


        public MVC.DTO.FieldDecimal CdPisPasepBeneficiario
        {
            get { return pispasep; }
            set { pispasep = value; }
        }


        public MVC.DTO.FieldString IdAcidenteTrabalhoBeneficiario
        {
            get { return ind_acidente_trabalho; }
            set { ind_acidente_trabalho = value; }
        }


        public MVC.DTO.FieldDecimal CdPiacBeneficiario
        {
            get { return codpac; }
            set { codpac = value; }
        }


        public MVC.DTO.FieldString CdDocumentoBeneficiario
        {
            get { return docben; }
            set { docben = value; }
        }


        public MVC.DTO.FieldDecimal CdNaturezaDocBeneficiario
        {
            get { return cod_natdoc; }
            set { cod_natdoc = value; }
        }


        public MVC.DTO.FieldDateTime DtExpedDocBeneficiario
        {
            get { return dt_expedoc; }
            set { dt_expedoc = value; }
        }


        public MVC.DTO.FieldDecimal CdAtividadePrincipalBeneficiario
        {
            get { return cod_ativprinc; }
            set { cod_ativprinc = value; }
        }


        public MVC.DTO.FieldString IdOperacao
        {
            get { return idoper; }
            set { idoper = value; }
        }


        public MVC.DTO.FieldString IdCartaoAutorizador
        {
            get { return id_cartao_autorizador; }
            set { id_cartao_autorizador = value; }
        }


        public MVC.DTO.FieldDateTime DataCartaoAutorizador
        {
            get { return dt_cartao_autorizador; }
            set { dt_cartao_autorizador = value; }
        }


        public MVC.DTO.FieldString NomeReduzido
        {
            get { return nm_reduzido; }
            set { nm_reduzido = value; }
        }


        public MVC.DTO.FieldString NmLogin
        {
            get { return ds_login; }
            set { ds_login = value; }
        }


        public MVC.DTO.FieldDecimal CdContrato
        {
            get { return cd_cco; }
            set { cd_cco = value; }
        }


        public MVC.DTO.FieldDecimal DgContrato
        {
            get { return dv_cco; }
            set { dv_cco = value; }
        }


        public MVC.DTO.FieldDecimal CodigoPlanoANSOrigem
        {
            get { return cdplanoans_origem; }
            set { cdplanoans_origem = value; }
        }

        public MVC.DTO.FieldString DescricaoConvenio
        {
            get { return cad_cnv_nm_fantasia; }
            set { cad_cnv_nm_fantasia = value; }
        }

        #endregion

        #region Operators

        public static explicit operator BeneficiarioACSDTO(DataRow row)
        {
            BeneficiarioACSDTO dto = new BeneficiarioACSDTO();
            dto.CodigoEmpresa.Value = row[FieldNames.CodigoEmpresa].ToString();
            dto.CodigoLoja.Value = row[FieldNames.CodigoLoja].ToString();
            dto.CodigoMatricula.Value = row[FieldNames.CodigoMatricula].ToString();
            dto.CodigoSeqMatricula.Value = row[FieldNames.CodigoSeqMatricula].ToString();
            dto.NomeBeneficiario.Value = row[FieldNames.NomeBeneficiario].ToString();
            dto.CdPadraoAtendimentoBeneficiario.Value = row[FieldNames.CdPadraoAtendimentoBeneficiario].ToString();
            dto.CdPadraoCobrancaBeneficiario.Value = row[FieldNames.CdPadraoCobrancaBeneficiario].ToString();
            dto.IndicacaoTitular.Value = row[FieldNames.IndicacaoTitular].ToString();
            dto.SexoBeneficiario.Value = row[FieldNames.SexoBeneficiario].ToString();
            dto.CdGrauParentesco.Value = row[FieldNames.CdGrauParentesco].ToString();
            dto.CdEstadoCivilBeneficiario.Value = row[FieldNames.CdEstadoCivilBeneficiario].ToString();
            dto.DtNascimentoBeneficiario.Value = row[FieldNames.DtNascimentoBeneficiario].ToString();
            dto.DtIngressoBeneficiario.Value = row[FieldNames.DtIngressoBeneficiario].ToString();
            dto.DtAdmissaoEmpresaBeneficiario.Value = row[FieldNames.DtAdmissaoEmpresaBeneficiario].ToString();
            dto.DtSaidaBeneficiario.Value = row[FieldNames.DtSaidaBeneficiario].ToString();
            dto.CdOcupacaoBeneficiario.Value = row[FieldNames.CdOcupacaoBeneficiario].ToString();
            dto.CdCargoBeneficiario.Value = row[FieldNames.CdCargoBeneficiario].ToString();
            dto.CdSituacaoBeneficiario.Value = row[FieldNames.CdSituacaoBeneficiario].ToString();
            dto.DtLimiteBeneficiario.Value = row[FieldNames.DtLimiteBeneficiario].ToString();
            dto.DtSituacaoBeneficiario.Value = row[FieldNames.DtSituacaoBeneficiario].ToString();
            dto.CdCpfBeneficiario.Value = row[FieldNames.CdCpfBeneficiario].ToString();
            dto.CdRgBeneficiario.Value = row[FieldNames.CdRgBeneficiario].ToString();
            dto.CdAcordoBeneficiario.Value = row[FieldNames.CdAcordoBeneficiario].ToString();
            dto.CdPlanoBeneficiario.Value = row[FieldNames.CdPlanoBeneficiario].ToString();
            dto.VlCobrancaBeneficiario.Value = row[FieldNames.VlCobrancaBeneficiario].ToString();
            dto.CodTipoPad.Value = row[FieldNames.CodTipoPad].ToString();
            dto.DataMIEXC.Value = row[FieldNames.DataMIEXC].ToString();
            dto.CdSituacaoABeneficiario.Value = row[FieldNames.CdSituacaoABeneficiario].ToString();
            dto.CdCarenciaBeneficiario.Value = row[FieldNames.CdCarenciaBeneficiario].ToString();
            dto.IndPag.Value = row[FieldNames.IndPag].ToString();
            dto.DtAtuIndPag.Value = row[FieldNames.DtAtuIndPag].ToString();
            dto.IndNegociacao.Value = row[FieldNames.IndNegociacao].ToString();
            dto.DataTod.Value = row[FieldNames.DataTod].ToString();
            dto.IdadeBen.Value = row[FieldNames.IdadeBen].ToString();
            dto.NmMaeBeneficiario.Value = row[FieldNames.NmMaeBeneficiario].ToString();
            dto.IdCancelamentoAns.Value = row[FieldNames.IdCancelamentoAns].ToString();
            dto.IdAutorizacaoANS.Value = row[FieldNames.IdAutorizacaoANS].ToString();
            dto.VlPerc.Value = row[FieldNames.VlPerc].ToString();
            dto.CdProfissionalBeneficiario.Value = row[FieldNames.CdProfissionalBeneficiario].ToString();
            dto.DtAlteracaoBeneficiario.Value = row[FieldNames.DtAlteracaoBeneficiario].ToString();
            dto.CdNumericoEmpresa.Value = row[FieldNames.CdNumericoEmpresa].ToString();
            dto.IdCopartExameBeneficiario.Value = row[FieldNames.IdCopartExameBeneficiario].ToString();
            dto.IdCopartConsultaBeneficiario.Value = row[FieldNames.IdCopartConsultaBeneficiario].ToString();
            dto.IdCronicoBeneficiario.Value = row[FieldNames.IdCronicoBeneficiario].ToString();
            dto.IdCopartBeneficiario.Value = row[FieldNames.IdCopartBeneficiario].ToString();
            dto.IdCredencialBeneficiario.Value = row[FieldNames.IdCredencialBeneficiario].ToString();
            dto.VlCobrancaAtual.Value = row[FieldNames.VlCobrancaAtual].ToString();
            dto.DataCobrancaAtual.Value = row[FieldNames.DataCobrancaAtual].ToString();
            dto.DataRefCobrancaAtual.Value = row[FieldNames.DataRefCobrancaAtual].ToString();
            dto.DtEmissaoCredencial.Value = row[FieldNames.DtEmissaoCredencial].ToString();
            dto.IdSituacaoJuridico.Value = row[FieldNames.IdSituacaoJuridico].ToString();
            dto.DsJuridicoBeneficiario.Value = row[FieldNames.DsJuridicoBeneficiario].ToString();
            dto.IdSuspensaoBoleto.Value = row[FieldNames.IdSuspensaoBoleto].ToString();
            dto.IdDoenteCronico.Value = row[FieldNames.IdDoenteCronico].ToString();
            dto.CdDiagnosticoCronico.Value = row[FieldNames.CdDiagnosticoCronico].ToString();
            dto.IdRepasseBeneficiario.Value = row[FieldNames.IdRepasseBeneficiario].ToString();
            dto.DtExclusaoFatura.Value = row[FieldNames.DtExclusaoFatura].ToString();
            dto.CdLocalRepasseBeneficiario.Value = row[FieldNames.CdLocalRepasseBeneficiario].ToString();
            dto.IdPiacBeneficiario.Value = row[FieldNames.IdPiacBeneficiario].ToString();
            dto.IdCurativoBeneficiario.Value = row[FieldNames.IdCurativoBeneficiario].ToString();
            dto.DtInicioCurativoBeneficiario.Value = row[FieldNames.DtInicioCurativoBeneficiario].ToString();
            dto.IdHomecareBeneficiario.Value = row[FieldNames.IdHomecareBeneficiario].ToString();
            dto.DtInicioHomecareBeneficiario.Value = row[FieldNames.DtInicioHomecareBeneficiario].ToString();
            dto.IdMedicoFamBeneficiario.Value = row[FieldNames.IdMedicoFamBeneficiario].ToString();
            dto.DtInicioMedicoFamBeneficiario.Value = row[FieldNames.DtInicioMedicoFamBeneficiario].ToString();
            dto.IdSegRemissaoBeneficiario.Value = row[FieldNames.IdSegRemissaoBeneficiario].ToString();
            dto.IdPlanoBemBeneficiario.Value = row[FieldNames.IdPlanoBemBeneficiario].ToString();
            dto.DtInicioCronicoBeneficiario.Value = row[FieldNames.DtInicioCronicoBeneficiario].ToString();
            dto.DtInicioPlanoBemBeneficiario.Value = row[FieldNames.DtInicioPlanoBemBeneficiario].ToString();
            dto.DtInicioRepasseBeneficiario.Value = row[FieldNames.DtInicioRepasseBeneficiario].ToString();
            dto.DtFinalRepasseBeneficiario.Value = row[FieldNames.DtFinalRepasseBeneficiario].ToString();
            dto.CdRepasseBeneficiario.Value = row[FieldNames.CdRepasseBeneficiario].ToString();
            dto.DsLocalRepasseBeneficiario.Value = row[FieldNames.DsLocalRepasseBeneficiario].ToString();
            dto.IdRepasseEmprBeneficiario.Value = row[FieldNames.IdRepasseEmprBeneficiario].ToString();
            dto.DtFimPlanoBemBeneficiario.Value = row[FieldNames.DtFimPlanoBemBeneficiario].ToString();
            dto.CdPlanoBemBeneficiario.Value = row[FieldNames.CdPlanoBemBeneficiario].ToString();
            dto.IdAcessorioBeneficiario.Value = row[FieldNames.IdAcessorioBeneficiario].ToString();
            dto.CdNacionalidadeBeneficiario.Value = row[FieldNames.CdNacionalidadeBeneficiario].ToString();
            dto.CdPaisBeneficiario.Value = row[FieldNames.CdPaisBeneficiario].ToString();
            dto.CdOrgaoEmissorBeneficiario.Value = row[FieldNames.CdOrgaoEmissorBeneficiario].ToString();
            dto.NmPaisEmissorBeneficiario.Value = row[FieldNames.NmPaisEmissorBeneficiario].ToString();
            dto.CdPisPasepBeneficiario.Value = row[FieldNames.CdPisPasepBeneficiario].ToString();
            dto.IdAcidenteTrabalhoBeneficiario.Value = row[FieldNames.IdAcidenteTrabalhoBeneficiario].ToString();
            dto.CdPiacBeneficiario.Value = row[FieldNames.CdPiacBeneficiario].ToString();
            dto.CdDocumentoBeneficiario.Value = row[FieldNames.CdDocumentoBeneficiario].ToString();
            dto.CdNaturezaDocBeneficiario.Value = row[FieldNames.CdNaturezaDocBeneficiario].ToString();
            dto.DtExpedDocBeneficiario.Value = row[FieldNames.DtExpedDocBeneficiario].ToString();
            dto.CdAtividadePrincipalBeneficiario.Value = row[FieldNames.CdAtividadePrincipalBeneficiario].ToString();
            dto.IdOperacao.Value = row[FieldNames.IdOperacao].ToString();
            dto.IdCartaoAutorizador.Value = row[FieldNames.IdCartaoAutorizador].ToString();
            dto.DataCartaoAutorizador.Value = row[FieldNames.DataCartaoAutorizador].ToString();
            dto.NomeReduzido.Value = row[FieldNames.NomeReduzido].ToString();
            dto.NmLogin.Value = row[FieldNames.NmLogin].ToString();
            dto.CdContrato.Value = row[FieldNames.CdContrato].ToString();
            dto.DgContrato.Value = row[FieldNames.DgContrato].ToString();
            dto.CodigoPlanoANSOrigem.Value = row[FieldNames.CodigoPlanoANSOrigem].ToString();
            dto.DescricaoConvenio.Value = row[FieldNames.DescricaoConvenio].ToString();

            return dto;
        }

        public static explicit operator BeneficiarioACSDTO(XmlDocument xml)
        {
            BeneficiarioACSDTO dto = new BeneficiarioACSDTO();
            if (xml.FirstChild.SelectSingleNode(FieldNames.CodigoEmpresa) != null) dto.CodigoEmpresa.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodigoEmpresa).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CodigoLoja) != null) dto.CodigoLoja.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodigoLoja).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CodigoMatricula) != null) dto.CodigoMatricula.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodigoMatricula).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CodigoSeqMatricula) != null) dto.CodigoSeqMatricula.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodigoSeqMatricula).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.NomeBeneficiario) != null) dto.NomeBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.NomeBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdPadraoAtendimentoBeneficiario) != null) dto.CdPadraoAtendimentoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdPadraoAtendimentoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdPadraoCobrancaBeneficiario) != null) dto.CdPadraoCobrancaBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdPadraoCobrancaBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IndicacaoTitular) != null) dto.IndicacaoTitular.Value = xml.FirstChild.SelectSingleNode(FieldNames.IndicacaoTitular).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.SexoBeneficiario) != null) dto.SexoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.SexoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdGrauParentesco) != null) dto.CdGrauParentesco.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdGrauParentesco).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdEstadoCivilBeneficiario) != null) dto.CdEstadoCivilBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdEstadoCivilBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtNascimentoBeneficiario) != null) dto.DtNascimentoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtNascimentoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtIngressoBeneficiario) != null) dto.DtIngressoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtIngressoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtAdmissaoEmpresaBeneficiario) != null) dto.DtAdmissaoEmpresaBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtAdmissaoEmpresaBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtSaidaBeneficiario) != null) dto.DtSaidaBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtSaidaBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdOcupacaoBeneficiario) != null) dto.CdOcupacaoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdOcupacaoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdCargoBeneficiario) != null) dto.CdCargoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdCargoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdSituacaoBeneficiario) != null) dto.CdSituacaoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdSituacaoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtLimiteBeneficiario) != null) dto.DtLimiteBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtLimiteBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtSituacaoBeneficiario) != null) dto.DtSituacaoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtSituacaoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdCpfBeneficiario) != null) dto.CdCpfBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdCpfBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdRgBeneficiario) != null) dto.CdRgBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdRgBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdAcordoBeneficiario) != null) dto.CdAcordoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdAcordoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdPlanoBeneficiario) != null) dto.CdPlanoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdPlanoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.VlCobrancaBeneficiario) != null) dto.VlCobrancaBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.VlCobrancaBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CodTipoPad) != null) dto.CodTipoPad.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodTipoPad).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DataMIEXC) != null) dto.DataMIEXC.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataMIEXC).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdSituacaoABeneficiario) != null) dto.CdSituacaoABeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdSituacaoABeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdCarenciaBeneficiario) != null) dto.CdCarenciaBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdCarenciaBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IndPag) != null) dto.IndPag.Value = xml.FirstChild.SelectSingleNode(FieldNames.IndPag).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtAtuIndPag) != null) dto.DtAtuIndPag.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtAtuIndPag).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IndNegociacao) != null) dto.IndNegociacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.IndNegociacao).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DataTod) != null) dto.DataTod.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataTod).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdadeBen) != null) dto.IdadeBen.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdadeBen).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.NmMaeBeneficiario) != null) dto.NmMaeBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmMaeBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdCancelamentoAns) != null) dto.IdCancelamentoAns.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdCancelamentoAns).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdAutorizacaoANS) != null) dto.IdAutorizacaoANS.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdAutorizacaoANS).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.VlPerc) != null) dto.VlPerc.Value = xml.FirstChild.SelectSingleNode(FieldNames.VlPerc).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdProfissionalBeneficiario) != null) dto.CdProfissionalBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdProfissionalBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtAlteracaoBeneficiario) != null) dto.DtAlteracaoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtAlteracaoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdNumericoEmpresa) != null) dto.CdNumericoEmpresa.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdNumericoEmpresa).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdCopartExameBeneficiario) != null) dto.IdCopartExameBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdCopartExameBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdCopartConsultaBeneficiario) != null) dto.IdCopartConsultaBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdCopartConsultaBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdCronicoBeneficiario) != null) dto.IdCronicoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdCronicoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdCopartBeneficiario) != null) dto.IdCopartBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdCopartBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdCredencialBeneficiario) != null) dto.IdCredencialBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdCredencialBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.VlCobrancaAtual) != null) dto.VlCobrancaAtual.Value = xml.FirstChild.SelectSingleNode(FieldNames.VlCobrancaAtual).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DataCobrancaAtual) != null) dto.DataCobrancaAtual.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataCobrancaAtual).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DataRefCobrancaAtual) != null) dto.DataRefCobrancaAtual.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataRefCobrancaAtual).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtEmissaoCredencial) != null) dto.DtEmissaoCredencial.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtEmissaoCredencial).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdSituacaoJuridico) != null) dto.IdSituacaoJuridico.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdSituacaoJuridico).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DsJuridicoBeneficiario) != null) dto.DsJuridicoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsJuridicoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdSuspensaoBoleto) != null) dto.IdSuspensaoBoleto.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdSuspensaoBoleto).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdDoenteCronico) != null) dto.IdDoenteCronico.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdDoenteCronico).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdDiagnosticoCronico) != null) dto.CdDiagnosticoCronico.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdDiagnosticoCronico).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdRepasseBeneficiario) != null) dto.IdRepasseBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdRepasseBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtExclusaoFatura) != null) dto.DtExclusaoFatura.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtExclusaoFatura).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdLocalRepasseBeneficiario) != null) dto.CdLocalRepasseBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdLocalRepasseBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdPiacBeneficiario) != null) dto.IdPiacBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdPiacBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdCurativoBeneficiario) != null) dto.IdCurativoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdCurativoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtInicioCurativoBeneficiario) != null) dto.DtInicioCurativoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtInicioCurativoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdHomecareBeneficiario) != null) dto.IdHomecareBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdHomecareBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtInicioHomecareBeneficiario) != null) dto.DtInicioHomecareBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtInicioHomecareBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdMedicoFamBeneficiario) != null) dto.IdMedicoFamBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdMedicoFamBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtInicioMedicoFamBeneficiario) != null) dto.DtInicioMedicoFamBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtInicioMedicoFamBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdSegRemissaoBeneficiario) != null) dto.IdSegRemissaoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdSegRemissaoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdPlanoBemBeneficiario) != null) dto.IdPlanoBemBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdPlanoBemBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtInicioCronicoBeneficiario) != null) dto.DtInicioCronicoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtInicioCronicoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtInicioPlanoBemBeneficiario) != null) dto.DtInicioPlanoBemBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtInicioPlanoBemBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtInicioRepasseBeneficiario) != null) dto.DtInicioRepasseBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtInicioRepasseBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtFinalRepasseBeneficiario) != null) dto.DtFinalRepasseBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtFinalRepasseBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdRepasseBeneficiario) != null) dto.CdRepasseBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdRepasseBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DsLocalRepasseBeneficiario) != null) dto.DsLocalRepasseBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsLocalRepasseBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdRepasseEmprBeneficiario) != null) dto.IdRepasseEmprBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdRepasseEmprBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtFimPlanoBemBeneficiario) != null) dto.DtFimPlanoBemBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtFimPlanoBemBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdPlanoBemBeneficiario) != null) dto.CdPlanoBemBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdPlanoBemBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdAcessorioBeneficiario) != null) dto.IdAcessorioBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdAcessorioBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdNacionalidadeBeneficiario) != null) dto.CdNacionalidadeBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdNacionalidadeBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdPaisBeneficiario) != null) dto.CdPaisBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdPaisBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdOrgaoEmissorBeneficiario) != null) dto.CdOrgaoEmissorBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdOrgaoEmissorBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.NmPaisEmissorBeneficiario) != null) dto.NmPaisEmissorBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmPaisEmissorBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdPisPasepBeneficiario) != null) dto.CdPisPasepBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdPisPasepBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdAcidenteTrabalhoBeneficiario) != null) dto.IdAcidenteTrabalhoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdAcidenteTrabalhoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdPiacBeneficiario) != null) dto.CdPiacBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdPiacBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdDocumentoBeneficiario) != null) dto.CdDocumentoBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdDocumentoBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdNaturezaDocBeneficiario) != null) dto.CdNaturezaDocBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdNaturezaDocBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtExpedDocBeneficiario) != null) dto.DtExpedDocBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtExpedDocBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdAtividadePrincipalBeneficiario) != null) dto.CdAtividadePrincipalBeneficiario.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdAtividadePrincipalBeneficiario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdOperacao) != null) dto.IdOperacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdOperacao).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdCartaoAutorizador) != null) dto.IdCartaoAutorizador.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdCartaoAutorizador).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DataCartaoAutorizador) != null) dto.DataCartaoAutorizador.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataCartaoAutorizador).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.NomeReduzido) != null) dto.NomeReduzido.Value = xml.FirstChild.SelectSingleNode(FieldNames.NomeReduzido).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.NmLogin) != null) dto.NmLogin.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmLogin).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdContrato) != null) dto.CdContrato.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdContrato).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DgContrato) != null) dto.DgContrato.Value = xml.FirstChild.SelectSingleNode(FieldNames.DgContrato).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CodigoPlanoANSOrigem) != null) dto.CodigoPlanoANSOrigem.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodigoPlanoANSOrigem).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DescricaoConvenio) != null) dto.DescricaoConvenio.Value = xml.FirstChild.SelectSingleNode(FieldNames.DescricaoConvenio).InnerText;

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
            XmlNode nodeCodigoEmpresa = xml.CreateNode(XmlNodeType.Element, FieldNames.CodigoEmpresa, null);
            XmlNode nodeCodigoLoja = xml.CreateNode(XmlNodeType.Element, FieldNames.CodigoLoja, null);
            XmlNode nodeCodigoMatricula = xml.CreateNode(XmlNodeType.Element, FieldNames.CodigoMatricula, null);
            XmlNode nodeCodigoSeqMatricula = xml.CreateNode(XmlNodeType.Element, FieldNames.CodigoSeqMatricula, null);
            XmlNode nodeNomeBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.NomeBeneficiario, null);
            XmlNode nodeCdPadraoAtendimentoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdPadraoAtendimentoBeneficiario, null);
            XmlNode nodeCdPadraoCobrancaBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdPadraoCobrancaBeneficiario, null);
            XmlNode nodeIndicacaoTitular = xml.CreateNode(XmlNodeType.Element, FieldNames.IndicacaoTitular, null);
            XmlNode nodeSexoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.SexoBeneficiario, null);
            XmlNode nodeCdGrauParentesco = xml.CreateNode(XmlNodeType.Element, FieldNames.CdGrauParentesco, null);
            XmlNode nodeCdEstadoCivilBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdEstadoCivilBeneficiario, null);
            XmlNode nodeDtNascimentoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtNascimentoBeneficiario, null);
            XmlNode nodeDtIngressoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtIngressoBeneficiario, null);
            XmlNode nodeDtAdmissaoEmpresaBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtAdmissaoEmpresaBeneficiario, null);
            XmlNode nodeDtSaidaBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtSaidaBeneficiario, null);
            XmlNode nodeCdOcupacaoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdOcupacaoBeneficiario, null);
            XmlNode nodeCdCargoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdCargoBeneficiario, null);
            XmlNode nodeCdSituacaoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdSituacaoBeneficiario, null);
            XmlNode nodeDtLimiteBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtLimiteBeneficiario, null);
            XmlNode nodeDtSituacaoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtSituacaoBeneficiario, null);
            XmlNode nodeCdCpfBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdCpfBeneficiario, null);
            XmlNode nodeCdRgBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdRgBeneficiario, null);
            XmlNode nodeCdAcordoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdAcordoBeneficiario, null);
            XmlNode nodeCdPlanoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdPlanoBeneficiario, null);
            XmlNode nodeVlCobrancaBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.VlCobrancaBeneficiario, null);
            XmlNode nodeCodTipoPad = xml.CreateNode(XmlNodeType.Element, FieldNames.CodTipoPad, null);
            XmlNode nodeDataMIEXC = xml.CreateNode(XmlNodeType.Element, FieldNames.DataMIEXC, null);
            XmlNode nodeCdSituacaoABeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdSituacaoABeneficiario, null);
            XmlNode nodeCdCarenciaBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdCarenciaBeneficiario, null);
            XmlNode nodeIndPag = xml.CreateNode(XmlNodeType.Element, FieldNames.IndPag, null);
            XmlNode nodeDtAtuIndPag = xml.CreateNode(XmlNodeType.Element, FieldNames.DtAtuIndPag, null);
            XmlNode nodeIndNegociacao = xml.CreateNode(XmlNodeType.Element, FieldNames.IndNegociacao, null);
            XmlNode nodeDataTod = xml.CreateNode(XmlNodeType.Element, FieldNames.DataTod, null);
            XmlNode nodeIdadeBen = xml.CreateNode(XmlNodeType.Element, FieldNames.IdadeBen, null);
            XmlNode nodeNmMaeBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.NmMaeBeneficiario, null);
            XmlNode nodeIdCancelamentoAns = xml.CreateNode(XmlNodeType.Element, FieldNames.IdCancelamentoAns, null);
            XmlNode nodeIdAutorizacaoANS = xml.CreateNode(XmlNodeType.Element, FieldNames.IdAutorizacaoANS, null);
            XmlNode nodeVlPerc = xml.CreateNode(XmlNodeType.Element, FieldNames.VlPerc, null);
            XmlNode nodeCdProfissionalBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdProfissionalBeneficiario, null);
            XmlNode nodeDtAlteracaoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtAlteracaoBeneficiario, null);
            XmlNode nodeCdNumericoEmpresa = xml.CreateNode(XmlNodeType.Element, FieldNames.CdNumericoEmpresa, null);
            XmlNode nodeIdCopartExameBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdCopartExameBeneficiario, null);
            XmlNode nodeIdCopartConsultaBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdCopartConsultaBeneficiario, null);
            XmlNode nodeIdCronicoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdCronicoBeneficiario, null);
            XmlNode nodeIdCopartBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdCopartBeneficiario, null);
            XmlNode nodeIdCredencialBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdCredencialBeneficiario, null);
            XmlNode nodeVlCobrancaAtual = xml.CreateNode(XmlNodeType.Element, FieldNames.VlCobrancaAtual, null);
            XmlNode nodeDataCobrancaAtual = xml.CreateNode(XmlNodeType.Element, FieldNames.DataCobrancaAtual, null);
            XmlNode nodeDataRefCobrancaAtual = xml.CreateNode(XmlNodeType.Element, FieldNames.DataRefCobrancaAtual, null);
            XmlNode nodeDtEmissaoCredencial = xml.CreateNode(XmlNodeType.Element, FieldNames.DtEmissaoCredencial, null);
            XmlNode nodeIdSituacaoJuridico = xml.CreateNode(XmlNodeType.Element, FieldNames.IdSituacaoJuridico, null);
            XmlNode nodeDsJuridicoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DsJuridicoBeneficiario, null);
            XmlNode nodeIdSuspensaoBoleto = xml.CreateNode(XmlNodeType.Element, FieldNames.IdSuspensaoBoleto, null);
            XmlNode nodeIdDoenteCronico = xml.CreateNode(XmlNodeType.Element, FieldNames.IdDoenteCronico, null);
            XmlNode nodeCdDiagnosticoCronico = xml.CreateNode(XmlNodeType.Element, FieldNames.CdDiagnosticoCronico, null);
            XmlNode nodeIdRepasseBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdRepasseBeneficiario, null);
            XmlNode nodeDtExclusaoFatura = xml.CreateNode(XmlNodeType.Element, FieldNames.DtExclusaoFatura, null);
            XmlNode nodeCdLocalRepasseBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdLocalRepasseBeneficiario, null);
            XmlNode nodeIdPiacBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdPiacBeneficiario, null);
            XmlNode nodeIdCurativoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdCurativoBeneficiario, null);
            XmlNode nodeDtInicioCurativoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtInicioCurativoBeneficiario, null);
            XmlNode nodeIdHomecareBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdHomecareBeneficiario, null);
            XmlNode nodeDtInicioHomecareBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtInicioHomecareBeneficiario, null);
            XmlNode nodeIdMedicoFamBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdMedicoFamBeneficiario, null);
            XmlNode nodeDtInicioMedicoFamBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtInicioMedicoFamBeneficiario, null);
            XmlNode nodeIdSegRemissaoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdSegRemissaoBeneficiario, null);
            XmlNode nodeIdPlanoBemBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdPlanoBemBeneficiario, null);
            XmlNode nodeDtInicioCronicoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtInicioCronicoBeneficiario, null);
            XmlNode nodeDtInicioPlanoBemBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtInicioPlanoBemBeneficiario, null);
            XmlNode nodeDtInicioRepasseBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtInicioRepasseBeneficiario, null);
            XmlNode nodeDtFinalRepasseBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtFinalRepasseBeneficiario, null);
            XmlNode nodeCdRepasseBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdRepasseBeneficiario, null);
            XmlNode nodeDsLocalRepasseBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DsLocalRepasseBeneficiario, null);
            XmlNode nodeIdRepasseEmprBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdRepasseEmprBeneficiario, null);
            XmlNode nodeDtFimPlanoBemBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtFimPlanoBemBeneficiario, null);
            XmlNode nodeCdPlanoBemBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdPlanoBemBeneficiario, null);
            XmlNode nodeIdAcessorioBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdAcessorioBeneficiario, null);
            XmlNode nodeCdNacionalidadeBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdNacionalidadeBeneficiario, null);
            XmlNode nodeCdPaisBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdPaisBeneficiario, null);
            XmlNode nodeCdOrgaoEmissorBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdOrgaoEmissorBeneficiario, null);
            XmlNode nodeNmPaisEmissorBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.NmPaisEmissorBeneficiario, null);
            XmlNode nodeCdPisPasepBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdPisPasepBeneficiario, null);
            XmlNode nodeIdAcidenteTrabalhoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdAcidenteTrabalhoBeneficiario, null);
            XmlNode nodeCdPiacBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdPiacBeneficiario, null);
            XmlNode nodeCdDocumentoBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdDocumentoBeneficiario, null);
            XmlNode nodeCdNaturezaDocBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdNaturezaDocBeneficiario, null);
            XmlNode nodeDtExpedDocBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.DtExpedDocBeneficiario, null);
            XmlNode nodeCdAtividadePrincipalBeneficiario = xml.CreateNode(XmlNodeType.Element, FieldNames.CdAtividadePrincipalBeneficiario, null);
            XmlNode nodeIdOperacao = xml.CreateNode(XmlNodeType.Element, FieldNames.IdOperacao, null);
            XmlNode nodeIdCartaoAutorizador = xml.CreateNode(XmlNodeType.Element, FieldNames.IdCartaoAutorizador, null);
            XmlNode nodeDataCartaoAutorizador = xml.CreateNode(XmlNodeType.Element, FieldNames.DataCartaoAutorizador, null);
            XmlNode nodeNomeReduzido = xml.CreateNode(XmlNodeType.Element, FieldNames.NomeReduzido, null);
            XmlNode nodeNmLogin = xml.CreateNode(XmlNodeType.Element, FieldNames.NmLogin, null);
            XmlNode nodeCdContrato = xml.CreateNode(XmlNodeType.Element, FieldNames.CdContrato, null);
            XmlNode nodeDgContrato = xml.CreateNode(XmlNodeType.Element, FieldNames.DgContrato, null);
            XmlNode nodeCodigoPlanoANSOrigem = xml.CreateNode(XmlNodeType.Element, FieldNames.CodigoPlanoANSOrigem, null);
            XmlNode nodeDescricaoConvenio = xml.CreateNode(XmlNodeType.Element, FieldNames.DescricaoConvenio, null);

            if (!this.CodigoEmpresa.Value.IsNull) nodeCodigoEmpresa.InnerText = this.CodigoEmpresa.Value;
            if (!this.CodigoLoja.Value.IsNull) nodeCodigoLoja.InnerText = this.CodigoLoja.Value;
            if (!this.CodigoMatricula.Value.IsNull) nodeCodigoMatricula.InnerText = this.CodigoMatricula.Value;
            if (!this.CodigoSeqMatricula.Value.IsNull) nodeCodigoSeqMatricula.InnerText = this.CodigoSeqMatricula.Value;
            if (!this.NomeBeneficiario.Value.IsNull) nodeNomeBeneficiario.InnerText = this.NomeBeneficiario.Value;
            if (!this.CdPadraoAtendimentoBeneficiario.Value.IsNull) nodeCdPadraoAtendimentoBeneficiario.InnerText = this.CdPadraoAtendimentoBeneficiario.Value;
            if (!this.CdPadraoCobrancaBeneficiario.Value.IsNull) nodeCdPadraoCobrancaBeneficiario.InnerText = this.CdPadraoCobrancaBeneficiario.Value;
            if (!this.IndicacaoTitular.Value.IsNull) nodeIndicacaoTitular.InnerText = this.IndicacaoTitular.Value;
            if (!this.SexoBeneficiario.Value.IsNull) nodeSexoBeneficiario.InnerText = this.SexoBeneficiario.Value;
            if (!this.CdGrauParentesco.Value.IsNull) nodeCdGrauParentesco.InnerText = this.CdGrauParentesco.Value;
            if (!this.CdEstadoCivilBeneficiario.Value.IsNull) nodeCdEstadoCivilBeneficiario.InnerText = this.CdEstadoCivilBeneficiario.Value;
            if (!this.DtNascimentoBeneficiario.Value.IsNull) nodeDtNascimentoBeneficiario.InnerText = this.DtNascimentoBeneficiario.Value;
            if (!this.DtIngressoBeneficiario.Value.IsNull) nodeDtIngressoBeneficiario.InnerText = this.DtIngressoBeneficiario.Value;
            if (!this.DtAdmissaoEmpresaBeneficiario.Value.IsNull) nodeDtAdmissaoEmpresaBeneficiario.InnerText = this.DtAdmissaoEmpresaBeneficiario.Value;
            if (!this.DtSaidaBeneficiario.Value.IsNull) nodeDtSaidaBeneficiario.InnerText = this.DtSaidaBeneficiario.Value;
            if (!this.CdOcupacaoBeneficiario.Value.IsNull) nodeCdOcupacaoBeneficiario.InnerText = this.CdOcupacaoBeneficiario.Value;
            if (!this.CdCargoBeneficiario.Value.IsNull) nodeCdCargoBeneficiario.InnerText = this.CdCargoBeneficiario.Value;
            if (!this.CdSituacaoBeneficiario.Value.IsNull) nodeCdSituacaoBeneficiario.InnerText = this.CdSituacaoBeneficiario.Value;
            if (!this.DtLimiteBeneficiario.Value.IsNull) nodeDtLimiteBeneficiario.InnerText = this.DtLimiteBeneficiario.Value;
            if (!this.DtSituacaoBeneficiario.Value.IsNull) nodeDtSituacaoBeneficiario.InnerText = this.DtSituacaoBeneficiario.Value;
            if (!this.CdCpfBeneficiario.Value.IsNull) nodeCdCpfBeneficiario.InnerText = this.CdCpfBeneficiario.Value;
            if (!this.CdRgBeneficiario.Value.IsNull) nodeCdRgBeneficiario.InnerText = this.CdRgBeneficiario.Value;
            if (!this.CdAcordoBeneficiario.Value.IsNull) nodeCdAcordoBeneficiario.InnerText = this.CdAcordoBeneficiario.Value;
            if (!this.CdPlanoBeneficiario.Value.IsNull) nodeCdPlanoBeneficiario.InnerText = this.CdPlanoBeneficiario.Value;
            if (!this.VlCobrancaBeneficiario.Value.IsNull) nodeVlCobrancaBeneficiario.InnerText = this.VlCobrancaBeneficiario.Value;
            if (!this.CodTipoPad.Value.IsNull) nodeCodTipoPad.InnerText = this.CodTipoPad.Value;
            if (!this.DataMIEXC.Value.IsNull) nodeDataMIEXC.InnerText = this.DataMIEXC.Value;
            if (!this.CdSituacaoABeneficiario.Value.IsNull) nodeCdSituacaoABeneficiario.InnerText = this.CdSituacaoABeneficiario.Value;
            if (!this.CdCarenciaBeneficiario.Value.IsNull) nodeCdCarenciaBeneficiario.InnerText = this.CdCarenciaBeneficiario.Value;
            if (!this.IndPag.Value.IsNull) nodeIndPag.InnerText = this.IndPag.Value;
            if (!this.DtAtuIndPag.Value.IsNull) nodeDtAtuIndPag.InnerText = this.DtAtuIndPag.Value;
            if (!this.IndNegociacao.Value.IsNull) nodeIndNegociacao.InnerText = this.IndNegociacao.Value;
            if (!this.DataTod.Value.IsNull) nodeDataTod.InnerText = this.DataTod.Value;
            if (!this.IdadeBen.Value.IsNull) nodeIdadeBen.InnerText = this.IdadeBen.Value;
            if (!this.NmMaeBeneficiario.Value.IsNull) nodeNmMaeBeneficiario.InnerText = this.NmMaeBeneficiario.Value;
            if (!this.IdCancelamentoAns.Value.IsNull) nodeIdCancelamentoAns.InnerText = this.IdCancelamentoAns.Value;
            if (!this.IdAutorizacaoANS.Value.IsNull) nodeIdAutorizacaoANS.InnerText = this.IdAutorizacaoANS.Value;
            if (!this.VlPerc.Value.IsNull) nodeVlPerc.InnerText = this.VlPerc.Value;
            if (!this.CdProfissionalBeneficiario.Value.IsNull) nodeCdProfissionalBeneficiario.InnerText = this.CdProfissionalBeneficiario.Value;
            if (!this.DtAlteracaoBeneficiario.Value.IsNull) nodeDtAlteracaoBeneficiario.InnerText = this.DtAlteracaoBeneficiario.Value;
            if (!this.CdNumericoEmpresa.Value.IsNull) nodeCdNumericoEmpresa.InnerText = this.CdNumericoEmpresa.Value;
            if (!this.IdCopartExameBeneficiario.Value.IsNull) nodeIdCopartExameBeneficiario.InnerText = this.IdCopartExameBeneficiario.Value;
            if (!this.IdCopartConsultaBeneficiario.Value.IsNull) nodeIdCopartConsultaBeneficiario.InnerText = this.IdCopartConsultaBeneficiario.Value;
            if (!this.IdCronicoBeneficiario.Value.IsNull) nodeIdCronicoBeneficiario.InnerText = this.IdCronicoBeneficiario.Value;
            if (!this.IdCopartBeneficiario.Value.IsNull) nodeIdCopartBeneficiario.InnerText = this.IdCopartBeneficiario.Value;
            if (!this.IdCredencialBeneficiario.Value.IsNull) nodeIdCredencialBeneficiario.InnerText = this.IdCredencialBeneficiario.Value;
            if (!this.VlCobrancaAtual.Value.IsNull) nodeVlCobrancaAtual.InnerText = this.VlCobrancaAtual.Value;
            if (!this.DataCobrancaAtual.Value.IsNull) nodeDataCobrancaAtual.InnerText = this.DataCobrancaAtual.Value;
            if (!this.DataRefCobrancaAtual.Value.IsNull) nodeDataRefCobrancaAtual.InnerText = this.DataRefCobrancaAtual.Value;
            if (!this.DtEmissaoCredencial.Value.IsNull) nodeDtEmissaoCredencial.InnerText = this.DtEmissaoCredencial.Value;
            if (!this.IdSituacaoJuridico.Value.IsNull) nodeIdSituacaoJuridico.InnerText = this.IdSituacaoJuridico.Value;
            if (!this.DsJuridicoBeneficiario.Value.IsNull) nodeDsJuridicoBeneficiario.InnerText = this.DsJuridicoBeneficiario.Value;
            if (!this.IdSuspensaoBoleto.Value.IsNull) nodeIdSuspensaoBoleto.InnerText = this.IdSuspensaoBoleto.Value;
            if (!this.IdDoenteCronico.Value.IsNull) nodeIdDoenteCronico.InnerText = this.IdDoenteCronico.Value;
            if (!this.CdDiagnosticoCronico.Value.IsNull) nodeCdDiagnosticoCronico.InnerText = this.CdDiagnosticoCronico.Value;
            if (!this.IdRepasseBeneficiario.Value.IsNull) nodeIdRepasseBeneficiario.InnerText = this.IdRepasseBeneficiario.Value;
            if (!this.DtExclusaoFatura.Value.IsNull) nodeDtExclusaoFatura.InnerText = this.DtExclusaoFatura.Value;
            if (!this.CdLocalRepasseBeneficiario.Value.IsNull) nodeCdLocalRepasseBeneficiario.InnerText = this.CdLocalRepasseBeneficiario.Value;
            if (!this.IdPiacBeneficiario.Value.IsNull) nodeIdPiacBeneficiario.InnerText = this.IdPiacBeneficiario.Value;
            if (!this.IdCurativoBeneficiario.Value.IsNull) nodeIdCurativoBeneficiario.InnerText = this.IdCurativoBeneficiario.Value;
            if (!this.DtInicioCurativoBeneficiario.Value.IsNull) nodeDtInicioCurativoBeneficiario.InnerText = this.DtInicioCurativoBeneficiario.Value;
            if (!this.IdHomecareBeneficiario.Value.IsNull) nodeIdHomecareBeneficiario.InnerText = this.IdHomecareBeneficiario.Value;
            if (!this.DtInicioHomecareBeneficiario.Value.IsNull) nodeDtInicioHomecareBeneficiario.InnerText = this.DtInicioHomecareBeneficiario.Value;
            if (!this.IdMedicoFamBeneficiario.Value.IsNull) nodeIdMedicoFamBeneficiario.InnerText = this.IdMedicoFamBeneficiario.Value;
            if (!this.DtInicioMedicoFamBeneficiario.Value.IsNull) nodeDtInicioMedicoFamBeneficiario.InnerText = this.DtInicioMedicoFamBeneficiario.Value;
            if (!this.IdSegRemissaoBeneficiario.Value.IsNull) nodeIdSegRemissaoBeneficiario.InnerText = this.IdSegRemissaoBeneficiario.Value;
            if (!this.IdPlanoBemBeneficiario.Value.IsNull) nodeIdPlanoBemBeneficiario.InnerText = this.IdPlanoBemBeneficiario.Value;
            if (!this.DtInicioCronicoBeneficiario.Value.IsNull) nodeDtInicioCronicoBeneficiario.InnerText = this.DtInicioCronicoBeneficiario.Value;
            if (!this.DtInicioPlanoBemBeneficiario.Value.IsNull) nodeDtInicioPlanoBemBeneficiario.InnerText = this.DtInicioPlanoBemBeneficiario.Value;
            if (!this.DtInicioRepasseBeneficiario.Value.IsNull) nodeDtInicioRepasseBeneficiario.InnerText = this.DtInicioRepasseBeneficiario.Value;
            if (!this.DtFinalRepasseBeneficiario.Value.IsNull) nodeDtFinalRepasseBeneficiario.InnerText = this.DtFinalRepasseBeneficiario.Value;
            if (!this.CdRepasseBeneficiario.Value.IsNull) nodeCdRepasseBeneficiario.InnerText = this.CdRepasseBeneficiario.Value;
            if (!this.DsLocalRepasseBeneficiario.Value.IsNull) nodeDsLocalRepasseBeneficiario.InnerText = this.DsLocalRepasseBeneficiario.Value;
            if (!this.IdRepasseEmprBeneficiario.Value.IsNull) nodeIdRepasseEmprBeneficiario.InnerText = this.IdRepasseEmprBeneficiario.Value;
            if (!this.DtFimPlanoBemBeneficiario.Value.IsNull) nodeDtFimPlanoBemBeneficiario.InnerText = this.DtFimPlanoBemBeneficiario.Value;
            if (!this.CdPlanoBemBeneficiario.Value.IsNull) nodeCdPlanoBemBeneficiario.InnerText = this.CdPlanoBemBeneficiario.Value;
            if (!this.IdAcessorioBeneficiario.Value.IsNull) nodeIdAcessorioBeneficiario.InnerText = this.IdAcessorioBeneficiario.Value;
            if (!this.CdNacionalidadeBeneficiario.Value.IsNull) nodeCdNacionalidadeBeneficiario.InnerText = this.CdNacionalidadeBeneficiario.Value;
            if (!this.CdPaisBeneficiario.Value.IsNull) nodeCdPaisBeneficiario.InnerText = this.CdPaisBeneficiario.Value;
            if (!this.CdOrgaoEmissorBeneficiario.Value.IsNull) nodeCdOrgaoEmissorBeneficiario.InnerText = this.CdOrgaoEmissorBeneficiario.Value;
            if (!this.NmPaisEmissorBeneficiario.Value.IsNull) nodeNmPaisEmissorBeneficiario.InnerText = this.NmPaisEmissorBeneficiario.Value;
            if (!this.CdPisPasepBeneficiario.Value.IsNull) nodeCdPisPasepBeneficiario.InnerText = this.CdPisPasepBeneficiario.Value;
            if (!this.IdAcidenteTrabalhoBeneficiario.Value.IsNull) nodeIdAcidenteTrabalhoBeneficiario.InnerText = this.IdAcidenteTrabalhoBeneficiario.Value;
            if (!this.CdPiacBeneficiario.Value.IsNull) nodeCdPiacBeneficiario.InnerText = this.CdPiacBeneficiario.Value;
            if (!this.CdDocumentoBeneficiario.Value.IsNull) nodeCdDocumentoBeneficiario.InnerText = this.CdDocumentoBeneficiario.Value;
            if (!this.CdNaturezaDocBeneficiario.Value.IsNull) nodeCdNaturezaDocBeneficiario.InnerText = this.CdNaturezaDocBeneficiario.Value;
            if (!this.DtExpedDocBeneficiario.Value.IsNull) nodeDtExpedDocBeneficiario.InnerText = this.DtExpedDocBeneficiario.Value;
            if (!this.CdAtividadePrincipalBeneficiario.Value.IsNull) nodeCdAtividadePrincipalBeneficiario.InnerText = this.CdAtividadePrincipalBeneficiario.Value;
            if (!this.IdOperacao.Value.IsNull) nodeIdOperacao.InnerText = this.IdOperacao.Value;
            if (!this.IdCartaoAutorizador.Value.IsNull) nodeIdCartaoAutorizador.InnerText = this.IdCartaoAutorizador.Value;
            if (!this.DataCartaoAutorizador.Value.IsNull) nodeDataCartaoAutorizador.InnerText = this.DataCartaoAutorizador.Value;
            if (!this.NomeReduzido.Value.IsNull) nodeNomeReduzido.InnerText = this.NomeReduzido.Value;
            if (!this.NmLogin.Value.IsNull) nodeNmLogin.InnerText = this.NmLogin.Value;
            if (!this.CdContrato.Value.IsNull) nodeCdContrato.InnerText = this.CdContrato.Value;
            if (!this.DgContrato.Value.IsNull) nodeDgContrato.InnerText = this.DgContrato.Value;
            if (!this.CodigoPlanoANSOrigem.Value.IsNull) nodeCodigoPlanoANSOrigem.InnerText = this.CodigoPlanoANSOrigem.Value;
            if (!this.DescricaoConvenio.Value.IsNull) nodeDescricaoConvenio.InnerText = this.DescricaoConvenio.Value;

            nodeData.AppendChild(nodeCodigoEmpresa);
            nodeData.AppendChild(nodeCodigoLoja);
            nodeData.AppendChild(nodeCodigoMatricula);
            nodeData.AppendChild(nodeCodigoSeqMatricula);
            nodeData.AppendChild(nodeNomeBeneficiario);
            nodeData.AppendChild(nodeCdPadraoAtendimentoBeneficiario);
            nodeData.AppendChild(nodeCdPadraoCobrancaBeneficiario);
            nodeData.AppendChild(nodeIndicacaoTitular);
            nodeData.AppendChild(nodeSexoBeneficiario);
            nodeData.AppendChild(nodeCdGrauParentesco);
            nodeData.AppendChild(nodeCdEstadoCivilBeneficiario);
            nodeData.AppendChild(nodeDtNascimentoBeneficiario);
            nodeData.AppendChild(nodeDtIngressoBeneficiario);
            nodeData.AppendChild(nodeDtAdmissaoEmpresaBeneficiario);
            nodeData.AppendChild(nodeDtSaidaBeneficiario);
            nodeData.AppendChild(nodeCdOcupacaoBeneficiario);
            nodeData.AppendChild(nodeCdCargoBeneficiario);
            nodeData.AppendChild(nodeCdSituacaoBeneficiario);
            nodeData.AppendChild(nodeDtLimiteBeneficiario);
            nodeData.AppendChild(nodeDtSituacaoBeneficiario);
            nodeData.AppendChild(nodeCdCpfBeneficiario);
            nodeData.AppendChild(nodeCdRgBeneficiario);
            nodeData.AppendChild(nodeCdAcordoBeneficiario);
            nodeData.AppendChild(nodeCdPlanoBeneficiario);
            nodeData.AppendChild(nodeVlCobrancaBeneficiario);
            nodeData.AppendChild(nodeCodTipoPad);
            nodeData.AppendChild(nodeDataMIEXC);
            nodeData.AppendChild(nodeCdSituacaoABeneficiario);
            nodeData.AppendChild(nodeCdCarenciaBeneficiario);
            nodeData.AppendChild(nodeIndPag);
            nodeData.AppendChild(nodeDtAtuIndPag);
            nodeData.AppendChild(nodeIndNegociacao);
            nodeData.AppendChild(nodeDataTod);
            nodeData.AppendChild(nodeIdadeBen);
            nodeData.AppendChild(nodeNmMaeBeneficiario);
            nodeData.AppendChild(nodeIdCancelamentoAns);
            nodeData.AppendChild(nodeIdAutorizacaoANS);
            nodeData.AppendChild(nodeVlPerc);
            nodeData.AppendChild(nodeCdProfissionalBeneficiario);
            nodeData.AppendChild(nodeDtAlteracaoBeneficiario);
            nodeData.AppendChild(nodeCdNumericoEmpresa);
            nodeData.AppendChild(nodeIdCopartExameBeneficiario);
            nodeData.AppendChild(nodeIdCopartConsultaBeneficiario);
            nodeData.AppendChild(nodeIdCronicoBeneficiario);
            nodeData.AppendChild(nodeIdCopartBeneficiario);
            nodeData.AppendChild(nodeIdCredencialBeneficiario);
            nodeData.AppendChild(nodeVlCobrancaAtual);
            nodeData.AppendChild(nodeDataCobrancaAtual);
            nodeData.AppendChild(nodeDataRefCobrancaAtual);
            nodeData.AppendChild(nodeDtEmissaoCredencial);
            nodeData.AppendChild(nodeIdSituacaoJuridico);
            nodeData.AppendChild(nodeDsJuridicoBeneficiario);
            nodeData.AppendChild(nodeIdSuspensaoBoleto);
            nodeData.AppendChild(nodeIdDoenteCronico);
            nodeData.AppendChild(nodeCdDiagnosticoCronico);
            nodeData.AppendChild(nodeIdRepasseBeneficiario);
            nodeData.AppendChild(nodeDtExclusaoFatura);
            nodeData.AppendChild(nodeCdLocalRepasseBeneficiario);
            nodeData.AppendChild(nodeIdPiacBeneficiario);
            nodeData.AppendChild(nodeIdCurativoBeneficiario);
            nodeData.AppendChild(nodeDtInicioCurativoBeneficiario);
            nodeData.AppendChild(nodeIdHomecareBeneficiario);
            nodeData.AppendChild(nodeDtInicioHomecareBeneficiario);
            nodeData.AppendChild(nodeIdMedicoFamBeneficiario);
            nodeData.AppendChild(nodeDtInicioMedicoFamBeneficiario);
            nodeData.AppendChild(nodeIdSegRemissaoBeneficiario);
            nodeData.AppendChild(nodeIdPlanoBemBeneficiario);
            nodeData.AppendChild(nodeDtInicioCronicoBeneficiario);
            nodeData.AppendChild(nodeDtInicioPlanoBemBeneficiario);
            nodeData.AppendChild(nodeDtInicioRepasseBeneficiario);
            nodeData.AppendChild(nodeDtFinalRepasseBeneficiario);
            nodeData.AppendChild(nodeCdRepasseBeneficiario);
            nodeData.AppendChild(nodeDsLocalRepasseBeneficiario);
            nodeData.AppendChild(nodeIdRepasseEmprBeneficiario);
            nodeData.AppendChild(nodeDtFimPlanoBemBeneficiario);
            nodeData.AppendChild(nodeCdPlanoBemBeneficiario);
            nodeData.AppendChild(nodeIdAcessorioBeneficiario);
            nodeData.AppendChild(nodeCdNacionalidadeBeneficiario);
            nodeData.AppendChild(nodeCdPaisBeneficiario);
            nodeData.AppendChild(nodeCdOrgaoEmissorBeneficiario);
            nodeData.AppendChild(nodeNmPaisEmissorBeneficiario);
            nodeData.AppendChild(nodeCdPisPasepBeneficiario);
            nodeData.AppendChild(nodeIdAcidenteTrabalhoBeneficiario);
            nodeData.AppendChild(nodeCdPiacBeneficiario);
            nodeData.AppendChild(nodeCdDocumentoBeneficiario);
            nodeData.AppendChild(nodeCdNaturezaDocBeneficiario);
            nodeData.AppendChild(nodeDtExpedDocBeneficiario);
            nodeData.AppendChild(nodeCdAtividadePrincipalBeneficiario);
            nodeData.AppendChild(nodeIdOperacao);
            nodeData.AppendChild(nodeIdCartaoAutorizador);
            nodeData.AppendChild(nodeDataCartaoAutorizador);
            nodeData.AppendChild(nodeNomeReduzido);
            nodeData.AppendChild(nodeNmLogin);
            nodeData.AppendChild(nodeCdContrato);
            nodeData.AppendChild(nodeDgContrato);
            nodeData.AppendChild(nodeCodigoPlanoANSOrigem);
            nodeData.AppendChild(nodeDescricaoConvenio);

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(BeneficiarioACSDTO dto)
        {
            BeneficiarioACSDataTable dtb = new BeneficiarioACSDataTable();
            DataRow dtr = dtb.NewRow();
            dtr[FieldNames.CodigoEmpresa] = dto.CodigoEmpresa.Value;
            dtr[FieldNames.CodigoLoja] = dto.CodigoLoja.Value;
            dtr[FieldNames.CodigoMatricula] = dto.CodigoMatricula.Value;
            dtr[FieldNames.CodigoSeqMatricula] = dto.CodigoSeqMatricula.Value;
            dtr[FieldNames.NomeBeneficiario] = dto.NomeBeneficiario.Value;
            dtr[FieldNames.CdPadraoAtendimentoBeneficiario] = dto.CdPadraoAtendimentoBeneficiario.Value;
            dtr[FieldNames.CdPadraoCobrancaBeneficiario] = dto.CdPadraoCobrancaBeneficiario.Value;
            dtr[FieldNames.IndicacaoTitular] = dto.IndicacaoTitular.Value;
            dtr[FieldNames.SexoBeneficiario] = dto.SexoBeneficiario.Value;
            dtr[FieldNames.CdGrauParentesco] = dto.CdGrauParentesco.Value;
            dtr[FieldNames.CdEstadoCivilBeneficiario] = dto.CdEstadoCivilBeneficiario.Value;
            dtr[FieldNames.DtNascimentoBeneficiario] = dto.DtNascimentoBeneficiario.Value;
            dtr[FieldNames.DtIngressoBeneficiario] = dto.DtIngressoBeneficiario.Value;
            dtr[FieldNames.DtAdmissaoEmpresaBeneficiario] = dto.DtAdmissaoEmpresaBeneficiario.Value;
            dtr[FieldNames.DtSaidaBeneficiario] = dto.DtSaidaBeneficiario.Value;
            dtr[FieldNames.CdOcupacaoBeneficiario] = dto.CdOcupacaoBeneficiario.Value;
            dtr[FieldNames.CdCargoBeneficiario] = dto.CdCargoBeneficiario.Value;
            dtr[FieldNames.CdSituacaoBeneficiario] = dto.CdSituacaoBeneficiario.Value;
            dtr[FieldNames.DtLimiteBeneficiario] = dto.DtLimiteBeneficiario.Value;
            dtr[FieldNames.DtSituacaoBeneficiario] = dto.DtSituacaoBeneficiario.Value;
            dtr[FieldNames.CdCpfBeneficiario] = dto.CdCpfBeneficiario.Value;
            dtr[FieldNames.CdRgBeneficiario] = dto.CdRgBeneficiario.Value;
            dtr[FieldNames.CdAcordoBeneficiario] = dto.CdAcordoBeneficiario.Value;
            dtr[FieldNames.CdPlanoBeneficiario] = dto.CdPlanoBeneficiario.Value;
            dtr[FieldNames.VlCobrancaBeneficiario] = dto.VlCobrancaBeneficiario.Value;
            dtr[FieldNames.CodTipoPad] = dto.CodTipoPad.Value;
            dtr[FieldNames.DataMIEXC] = dto.DataMIEXC.Value;
            dtr[FieldNames.CdSituacaoABeneficiario] = dto.CdSituacaoABeneficiario.Value;
            dtr[FieldNames.CdCarenciaBeneficiario] = dto.CdCarenciaBeneficiario.Value;
            dtr[FieldNames.IndPag] = dto.IndPag.Value;
            dtr[FieldNames.DtAtuIndPag] = dto.DtAtuIndPag.Value;
            dtr[FieldNames.IndNegociacao] = dto.IndNegociacao.Value;
            dtr[FieldNames.DataTod] = dto.DataTod.Value;
            dtr[FieldNames.IdadeBen] = dto.IdadeBen.Value;
            dtr[FieldNames.NmMaeBeneficiario] = dto.NmMaeBeneficiario.Value;
            dtr[FieldNames.IdCancelamentoAns] = dto.IdCancelamentoAns.Value;
            dtr[FieldNames.IdAutorizacaoANS] = dto.IdAutorizacaoANS.Value;
            dtr[FieldNames.VlPerc] = dto.VlPerc.Value;
            dtr[FieldNames.CdProfissionalBeneficiario] = dto.CdProfissionalBeneficiario.Value;
            dtr[FieldNames.DtAlteracaoBeneficiario] = dto.DtAlteracaoBeneficiario.Value;
            dtr[FieldNames.CdNumericoEmpresa] = dto.CdNumericoEmpresa.Value;
            dtr[FieldNames.IdCopartExameBeneficiario] = dto.IdCopartExameBeneficiario.Value;
            dtr[FieldNames.IdCopartConsultaBeneficiario] = dto.IdCopartConsultaBeneficiario.Value;
            dtr[FieldNames.IdCronicoBeneficiario] = dto.IdCronicoBeneficiario.Value;
            dtr[FieldNames.IdCopartBeneficiario] = dto.IdCopartBeneficiario.Value;
            dtr[FieldNames.IdCredencialBeneficiario] = dto.IdCredencialBeneficiario.Value;
            dtr[FieldNames.VlCobrancaAtual] = dto.VlCobrancaAtual.Value;
            dtr[FieldNames.DataCobrancaAtual] = dto.DataCobrancaAtual.Value;
            dtr[FieldNames.DataRefCobrancaAtual] = dto.DataRefCobrancaAtual.Value;
            dtr[FieldNames.DtEmissaoCredencial] = dto.DtEmissaoCredencial.Value;
            dtr[FieldNames.IdSituacaoJuridico] = dto.IdSituacaoJuridico.Value;
            dtr[FieldNames.DsJuridicoBeneficiario] = dto.DsJuridicoBeneficiario.Value;
            dtr[FieldNames.IdSuspensaoBoleto] = dto.IdSuspensaoBoleto.Value;
            dtr[FieldNames.IdDoenteCronico] = dto.IdDoenteCronico.Value;
            dtr[FieldNames.CdDiagnosticoCronico] = dto.CdDiagnosticoCronico.Value;
            dtr[FieldNames.IdRepasseBeneficiario] = dto.IdRepasseBeneficiario.Value;
            dtr[FieldNames.DtExclusaoFatura] = dto.DtExclusaoFatura.Value;
            dtr[FieldNames.CdLocalRepasseBeneficiario] = dto.CdLocalRepasseBeneficiario.Value;
            dtr[FieldNames.IdPiacBeneficiario] = dto.IdPiacBeneficiario.Value;
            dtr[FieldNames.IdCurativoBeneficiario] = dto.IdCurativoBeneficiario.Value;
            dtr[FieldNames.DtInicioCurativoBeneficiario] = dto.DtInicioCurativoBeneficiario.Value;
            dtr[FieldNames.IdHomecareBeneficiario] = dto.IdHomecareBeneficiario.Value;
            dtr[FieldNames.DtInicioHomecareBeneficiario] = dto.DtInicioHomecareBeneficiario.Value;
            dtr[FieldNames.IdMedicoFamBeneficiario] = dto.IdMedicoFamBeneficiario.Value;
            dtr[FieldNames.DtInicioMedicoFamBeneficiario] = dto.DtInicioMedicoFamBeneficiario.Value;
            dtr[FieldNames.IdSegRemissaoBeneficiario] = dto.IdSegRemissaoBeneficiario.Value;
            dtr[FieldNames.IdPlanoBemBeneficiario] = dto.IdPlanoBemBeneficiario.Value;
            dtr[FieldNames.DtInicioCronicoBeneficiario] = dto.DtInicioCronicoBeneficiario.Value;
            dtr[FieldNames.DtInicioPlanoBemBeneficiario] = dto.DtInicioPlanoBemBeneficiario.Value;
            dtr[FieldNames.DtInicioRepasseBeneficiario] = dto.DtInicioRepasseBeneficiario.Value;
            dtr[FieldNames.DtFinalRepasseBeneficiario] = dto.DtFinalRepasseBeneficiario.Value;
            dtr[FieldNames.CdRepasseBeneficiario] = dto.CdRepasseBeneficiario.Value;
            dtr[FieldNames.DsLocalRepasseBeneficiario] = dto.DsLocalRepasseBeneficiario.Value;
            dtr[FieldNames.IdRepasseEmprBeneficiario] = dto.IdRepasseEmprBeneficiario.Value;
            dtr[FieldNames.DtFimPlanoBemBeneficiario] = dto.DtFimPlanoBemBeneficiario.Value;
            dtr[FieldNames.CdPlanoBemBeneficiario] = dto.CdPlanoBemBeneficiario.Value;
            dtr[FieldNames.IdAcessorioBeneficiario] = dto.IdAcessorioBeneficiario.Value;
            dtr[FieldNames.CdNacionalidadeBeneficiario] = dto.CdNacionalidadeBeneficiario.Value;
            dtr[FieldNames.CdPaisBeneficiario] = dto.CdPaisBeneficiario.Value;
            dtr[FieldNames.CdOrgaoEmissorBeneficiario] = dto.CdOrgaoEmissorBeneficiario.Value;
            dtr[FieldNames.NmPaisEmissorBeneficiario] = dto.NmPaisEmissorBeneficiario.Value;
            dtr[FieldNames.CdPisPasepBeneficiario] = dto.CdPisPasepBeneficiario.Value;
            dtr[FieldNames.IdAcidenteTrabalhoBeneficiario] = dto.IdAcidenteTrabalhoBeneficiario.Value;
            dtr[FieldNames.CdPiacBeneficiario] = dto.CdPiacBeneficiario.Value;
            dtr[FieldNames.CdDocumentoBeneficiario] = dto.CdDocumentoBeneficiario.Value;
            dtr[FieldNames.CdNaturezaDocBeneficiario] = dto.CdNaturezaDocBeneficiario.Value;
            dtr[FieldNames.DtExpedDocBeneficiario] = dto.DtExpedDocBeneficiario.Value;
            dtr[FieldNames.CdAtividadePrincipalBeneficiario] = dto.CdAtividadePrincipalBeneficiario.Value;
            dtr[FieldNames.IdOperacao] = dto.IdOperacao.Value;
            dtr[FieldNames.IdCartaoAutorizador] = dto.IdCartaoAutorizador.Value;
            dtr[FieldNames.DataCartaoAutorizador] = dto.DataCartaoAutorizador.Value;
            dtr[FieldNames.NomeReduzido] = dto.NomeReduzido.Value;
            dtr[FieldNames.NmLogin] = dto.NmLogin.Value;
            dtr[FieldNames.CdContrato] = dto.CdContrato.Value;
            dtr[FieldNames.DgContrato] = dto.DgContrato.Value;
            dtr[FieldNames.CodigoPlanoANSOrigem] = dto.CodigoPlanoANSOrigem.Value;
            dtr[FieldNames.DescricaoConvenio] = dto.DescricaoConvenio.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(BeneficiarioACSDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}