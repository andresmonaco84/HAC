using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using MVC = HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.DTO
{
    [Serializable()]
    public class PrescricaoDataTable : DataTable
    {
        public PrescricaoDataTable()
            : base()
        {
            this.TableName = "DADOS";

            this.Columns.Add(PrescricaoDTO.FieldNames.IdPrescricao, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.IdAtendimento, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.Status, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.CRM, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.DataInclusao, typeof(DateTime));
            
            this.Columns.Add(PrescricaoDTO.FieldNames.IdProduto, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.QtdDia, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.QtdTotal, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.QtdDispensada, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.DataInicioConsumo, typeof(DateTime));

            this.Columns.Add(PrescricaoDTO.FieldNames.DataLimiteConsumo, typeof(DateTime));

            this.Columns.Add(PrescricaoDTO.FieldNames.StatusItem, typeof(decimal));
            
            this.Columns.Add(PrescricaoDTO.FieldNames.ObservacaoItem, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.FlInternadoUTI, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.FlVentilaMecanica, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.CirurgiaDsc, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.AcessoVascularDsc, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.SondaVesicalDsc, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.OutrosDsc, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.Peso, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.Creatinina, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.ProcedenciaPaciente, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.DataAssinaturaSCIH, typeof(DateTime));

            this.Columns.Add(PrescricaoDTO.FieldNames.UFConselhoProfissional, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.InformacoesComplementares, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.Via, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.FlAutorizado, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.ParecerSCIH, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.ParecerData, typeof(DateTime));

            this.Columns.Add(PrescricaoDTO.FieldNames.IdProfissionalSCIH, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.IdUsuarioAlteracao, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.DataAlteracao, typeof(DateTime));

            this.Columns.Add(PrescricaoDTO.FieldNames.CulturaSequencial, typeof(decimal));
            
            this.Columns.Add(PrescricaoDTO.FieldNames.DataCultura, typeof(DateTime));

            this.Columns.Add(PrescricaoDTO.FieldNames.Material, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.Microorganismo, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.SensibilidadeMIC, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.IdDoencaDiagnostico, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.IdPrescricaoMedica, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.IdMedicamentoPrescricaoMedica, typeof(decimal));

            this.Columns.Add(PrescricaoDTO.FieldNames.InternacaoPrevia, typeof(String));

            this.Columns.Add(PrescricaoDTO.FieldNames.AtmPrevio, typeof(String));
        }

        protected PrescricaoDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }

        public PrescricaoDTO TypedRow(int index)
        {
            return (PrescricaoDTO)this.Rows[index];
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

        public void Add(PrescricaoDTO dto)
        {
            DataRow dtr = this.NewRow();

            if (!dto.IdPrescricao.Value.IsNull) dtr[PrescricaoDTO.FieldNames.IdPrescricao] = (decimal)dto.IdPrescricao.Value;
            if (!dto.IdAtendimento.Value.IsNull) dtr[PrescricaoDTO.FieldNames.IdAtendimento] = (decimal)dto.IdAtendimento.Value;
            if (!dto.Status.Value.IsNull) dtr[PrescricaoDTO.FieldNames.Status] = (decimal)dto.Status.Value;
            if (!dto.CRM.Value.IsNull) dtr[PrescricaoDTO.FieldNames.CRM] = (String)dto.CRM.Value;
            if (!dto.DataInclusao.Value.IsNull) dtr[PrescricaoDTO.FieldNames.DataInclusao] = (DateTime)dto.DataInclusao.Value;
            if (!dto.IdProduto.Value.IsNull) dtr[PrescricaoDTO.FieldNames.IdProduto] = (decimal)dto.IdProduto.Value;
            if (!dto.QtdDia.Value.IsNull) dtr[PrescricaoDTO.FieldNames.QtdDia] = (decimal)dto.QtdDia.Value;
            if (!dto.QtdTotal.Value.IsNull) dtr[PrescricaoDTO.FieldNames.QtdTotal] = (decimal)dto.QtdTotal.Value;
            if (!dto.QtdDispensada.Value.IsNull) dtr[PrescricaoDTO.FieldNames.QtdDispensada] = (decimal)dto.QtdDispensada.Value;
            if (!dto.DataInicioConsumo.Value.IsNull) dtr[PrescricaoDTO.FieldNames.DataInicioConsumo] = (DateTime)dto.DataInicioConsumo.Value;
            if (!dto.DataLimiteConsumo.Value.IsNull) dtr[PrescricaoDTO.FieldNames.DataLimiteConsumo] = (DateTime)dto.DataLimiteConsumo.Value;
            if (!dto.ObservacaoItem.Value.IsNull) dtr[PrescricaoDTO.FieldNames.ObservacaoItem] = (String)dto.ObservacaoItem.Value;

            if (!dto.FlInternadoUTI.Value.IsNull) dtr[PrescricaoDTO.FieldNames.FlInternadoUTI] = (decimal)dto.FlInternadoUTI.Value;
            if (!dto.FlVentilaMecanica.Value.IsNull) dtr[PrescricaoDTO.FieldNames.FlVentilaMecanica] = (decimal)dto.FlVentilaMecanica.Value;
            if (!dto.CirurgiaDsc.Value.IsNull) dtr[PrescricaoDTO.FieldNames.CirurgiaDsc] = (String)dto.CirurgiaDsc.Value;
            if (!dto.AcessoVascularDsc.Value.IsNull) dtr[PrescricaoDTO.FieldNames.AcessoVascularDsc] = (String)dto.AcessoVascularDsc.Value;
            if (!dto.SondaVesicalDsc.Value.IsNull) dtr[PrescricaoDTO.FieldNames.SondaVesicalDsc] = (String)dto.SondaVesicalDsc.Value;
            if (!dto.OutrosDsc.Value.IsNull) dtr[PrescricaoDTO.FieldNames.OutrosDsc] = (String)dto.OutrosDsc.Value;
            if (!dto.Peso.Value.IsNull) dtr[PrescricaoDTO.FieldNames.Peso] = (decimal)dto.Peso.Value;
            if (!dto.Creatinina.Value.IsNull) dtr[PrescricaoDTO.FieldNames.Creatinina] = (String)dto.Creatinina.Value;
            if (!dto.ProcedenciaPaciente.Value.IsNull) dtr[PrescricaoDTO.FieldNames.ProcedenciaPaciente] = (decimal)dto.ProcedenciaPaciente.Value;
            if (!dto.DataAssinaturaSCIH.Value.IsNull) dtr[PrescricaoDTO.FieldNames.DataAssinaturaSCIH] = (DateTime)dto.DataAssinaturaSCIH.Value;
            if (!dto.UFConselhoProfissional.Value.IsNull) dtr[PrescricaoDTO.FieldNames.UFConselhoProfissional] = (String)dto.UFConselhoProfissional.Value;
            if (!dto.InformacoesComplementares.Value.IsNull) dtr[PrescricaoDTO.FieldNames.InformacoesComplementares] = (String)dto.InformacoesComplementares.Value;

            if (!dto.Via.Value.IsNull) dtr[PrescricaoDTO.FieldNames.Via] = (String)dto.Via.Value;
            if (!dto.FlAutorizado.Value.IsNull) dtr[PrescricaoDTO.FieldNames.FlAutorizado] = (decimal)dto.FlAutorizado.Value;
            if (!dto.ParecerSCIH.Value.IsNull) dtr[PrescricaoDTO.FieldNames.ParecerSCIH] = (String)dto.ParecerSCIH.Value;
            if (!dto.ParecerData.Value.IsNull) dtr[PrescricaoDTO.FieldNames.ParecerData] = (DateTime)dto.ParecerData.Value;
            if (!dto.IdProfissionalSCIH.Value.IsNull) dtr[PrescricaoDTO.FieldNames.IdProfissionalSCIH] = (decimal)dto.IdProfissionalSCIH.Value;
            if (!dto.IdUsuarioAlteracao.Value.IsNull) dtr[PrescricaoDTO.FieldNames.IdUsuarioAlteracao] = (decimal)dto.IdUsuarioAlteracao.Value;
            if (!dto.DataAlteracao.Value.IsNull) dtr[PrescricaoDTO.FieldNames.DataAlteracao] = (DateTime)dto.DataAlteracao.Value;

            if (!dto.CulturaSequencial.Value.IsNull) dtr[PrescricaoDTO.FieldNames.CulturaSequencial] = (decimal)dto.CulturaSequencial.Value;
            if (!dto.ParecerData.Value.IsNull) dtr[PrescricaoDTO.FieldNames.DataCultura] = (DateTime)dto.DataCultura.Value;
            if (!dto.Material.Value.IsNull) dtr[PrescricaoDTO.FieldNames.Material] = (String)dto.Material.Value;
            if (!dto.Microorganismo.Value.IsNull) dtr[PrescricaoDTO.FieldNames.Microorganismo] = (String)dto.Microorganismo.Value;
            if (!dto.SensibilidadeMIC.Value.IsNull) dtr[PrescricaoDTO.FieldNames.SensibilidadeMIC] = (String)dto.SensibilidadeMIC.Value;
            if (!dto.IdDoencaDiagnostico.Value.IsNull) dtr[PrescricaoDTO.FieldNames.IdDoencaDiagnostico] = (decimal)dto.IdDoencaDiagnostico.Value;
            if (!dto.IdPrescricaoMedica.Value.IsNull) dtr[PrescricaoDTO.FieldNames.IdPrescricaoMedica] = (decimal)dto.IdPrescricaoMedica.Value;
            if (!dto.IdMedicamentoPrescricaoMedica.Value.IsNull) dtr[PrescricaoDTO.FieldNames.IdMedicamentoPrescricaoMedica] = (decimal)dto.IdMedicamentoPrescricaoMedica.Value;
            if (!dto.InternacaoPrevia.Value.IsNull) dtr[PrescricaoDTO.FieldNames.InternacaoPrevia] = (String)dto.InternacaoPrevia.Value;
            if (!dto.AtmPrevio.Value.IsNull) dtr[PrescricaoDTO.FieldNames.AtmPrevio] = (String)dto.AtmPrevio.Value;

            this.Rows.Add(dtr);
        }
    }

    [Serializable()]
    public partial class PrescricaoDTO : MVC.DTO.DTOBase
    {
        public enum ProcedenciaPacienteEnum
        {
            Está_Internado = 1,
            Instituição_de_Isosos = 2,
            Outro_Hospital = 3,
            Casa = 4
        }

        private MVC.DTO.FieldDecimal cad_mtmd_prescricao_id;
        private MVC.DTO.FieldDecimal atd_ate_id;
        private MVC.DTO.FieldDecimal cad_mtmd_prescricao_status;
        private MVC.DTO.FieldString cad_mtmd_crm;
        private MVC.DTO.FieldDateTime cad_mtmd_dt_inclusao;

        private MVC.DTO.FieldDecimal cad_mtmd_prc_internado_uti;
        private MVC.DTO.FieldDecimal cad_mtmd_prc_ventila_mecanica;
        private MVC.DTO.FieldString cad_mtmd_prc_cirurgia;
        private MVC.DTO.FieldString cad_mtmd_prc_acesso_vascular;
        private MVC.DTO.FieldString cad_mtmd_prc_sonda_vesical;
        private MVC.DTO.FieldString cad_mtmd_prc_outros;
        private MVC.DTO.FieldDecimal cad_mtmd_prc_peso;
        private MVC.DTO.FieldString cad_mtmd_prc_creatinina;
        private MVC.DTO.FieldDecimal cad_mtmd_prc_procedencia_pac;
        private MVC.DTO.FieldDateTime cad_mtmd_dt_assinatura_scih;
        private MVC.DTO.FieldString cad_pso_sg_uf_conselho;
        private MVC.DTO.FieldString cad_mtmd_prc_inf_compl;        
        
        private MVC.DTO.FieldDecimal cad_mtmd_id;
        private MVC.DTO.FieldDecimal cad_mtmd_prc_qtde_dia;
        private MVC.DTO.FieldDecimal cad_mtmd_prc_qtde_total;
        private MVC.DTO.FieldDecimal cad_mtmd_prc_qtde_disp;
        private MVC.DTO.FieldDateTime cad_mtmd_dt_inicio_cons;
        private MVC.DTO.FieldDateTime cad_mtmd_dt_fim_cons;
        private MVC.DTO.FieldDecimal cad_mtmd_prc_item_status;        
        private MVC.DTO.FieldString cad_mtmd_prc_obs;

        private MVC.DTO.FieldString cad_mtmd_prc_via;
        private MVC.DTO.FieldDecimal cad_mtmd_prc_autorizado;
        private MVC.DTO.FieldString cad_mtmd_prc_parecer_scih;
        private MVC.DTO.FieldDateTime cad_mtmd_prc_parecer_data;
        private MVC.DTO.FieldDecimal cad_pro_id_prof_scih;
        private MVC.DTO.FieldDecimal seg_usu_id_alteracao;
        private MVC.DTO.FieldDateTime cad_mtmd_dt_alteracao;

        private MVC.DTO.FieldDecimal cad_mtmd_cultura_seq;
        private MVC.DTO.FieldDateTime cad_mtmd_data_cultura;
        private MVC.DTO.FieldString cad_mtmd_material;
        private MVC.DTO.FieldString cad_mtmd_microorganismo;
        private MVC.DTO.FieldString cad_mtmd_sensibilidade_mic;
        private MVC.DTO.FieldDecimal cad_mtmd_dodi_id;
        private MVC.DTO.FieldDecimal atd_pme_id;
        private MVC.DTO.FieldDecimal atd_mpm_id;
        private MVC.DTO.FieldString fl_internacao_previa;
        private MVC.DTO.FieldString cad_mtmd_prc_atm_previo;
        
        public PrescricaoDTO()
        {
            InitializeComponent();
        }

        internal void InitializeComponent()
        {
            this.cad_mtmd_prescricao_id = new MVC.DTO.FieldDecimal(FieldNames.IdPrescricao, Captions.IdPrescricao, DbType.Decimal);
            this.atd_ate_id = new MVC.DTO.FieldDecimal(FieldNames.IdAtendimento, Captions.IdAtendimento, DbType.Decimal);
            this.cad_mtmd_prescricao_status = new MVC.DTO.FieldDecimal(FieldNames.Status, Captions.Status, DbType.Decimal);
            this.cad_mtmd_crm = new MVC.DTO.FieldString(FieldNames.CRM, Captions.CRM, 15);
            this.cad_mtmd_dt_inclusao = new MVC.DTO.FieldDateTime(FieldNames.DataInclusao, Captions.DataInclusao);

            this.cad_mtmd_prc_internado_uti = new MVC.DTO.FieldDecimal(FieldNames.FlInternadoUTI, Captions.FlInternadoUTI, DbType.Decimal);
            this.cad_mtmd_prc_ventila_mecanica = new MVC.DTO.FieldDecimal(FieldNames.FlVentilaMecanica, Captions.FlVentilaMecanica, DbType.Decimal);
            this.cad_mtmd_prc_cirurgia = new MVC.DTO.FieldString(FieldNames.CirurgiaDsc, Captions.CirurgiaDsc, 200);
            this.cad_mtmd_prc_acesso_vascular = new MVC.DTO.FieldString(FieldNames.AcessoVascularDsc, Captions.AcessoVascularDsc, 200);
            this.cad_mtmd_prc_sonda_vesical = new MVC.DTO.FieldString(FieldNames.SondaVesicalDsc, Captions.SondaVesicalDsc, 200);
            this.cad_mtmd_prc_outros = new MVC.DTO.FieldString(FieldNames.OutrosDsc, Captions.OutrosDsc, 200);
            this.cad_mtmd_prc_peso = new MVC.DTO.FieldDecimal(FieldNames.Peso, Captions.Peso, DbType.Decimal);
            this.cad_mtmd_prc_creatinina = new MVC.DTO.FieldString(FieldNames.Creatinina, Captions.Creatinina, 10);
            this.cad_mtmd_prc_procedencia_pac = new MVC.DTO.FieldDecimal(FieldNames.ProcedenciaPaciente, Captions.ProcedenciaPaciente, DbType.Decimal);
            this.cad_mtmd_dt_assinatura_scih = new MVC.DTO.FieldDateTime(FieldNames.DataAssinaturaSCIH, Captions.DataAssinaturaSCIH);
            this.cad_pso_sg_uf_conselho = new MVC.DTO.FieldString(FieldNames.UFConselhoProfissional, Captions.UFConselhoProfissional, 2);
            this.cad_mtmd_prc_inf_compl = new MVC.DTO.FieldString(FieldNames.InformacoesComplementares, Captions.InformacoesComplementares, 300);

            this.cad_mtmd_id = new MVC.DTO.FieldDecimal(FieldNames.IdProduto, Captions.IdProduto, DbType.Decimal);
            this.cad_mtmd_prc_qtde_dia = new MVC.DTO.FieldDecimal(FieldNames.QtdDia, Captions.QtdDia, DbType.Decimal);
            this.cad_mtmd_prc_qtde_total = new MVC.DTO.FieldDecimal(FieldNames.QtdTotal, Captions.QtdTotal, DbType.Decimal);
            this.cad_mtmd_prc_qtde_disp = new MVC.DTO.FieldDecimal(FieldNames.QtdDispensada, Captions.QtdDispensada, DbType.Decimal);
            this.cad_mtmd_dt_inicio_cons = new MVC.DTO.FieldDateTime(FieldNames.DataInicioConsumo, Captions.DataInicioConsumo);
            this.cad_mtmd_dt_fim_cons = new MVC.DTO.FieldDateTime(FieldNames.DataLimiteConsumo, Captions.DataLimiteConsumo);
            this.cad_mtmd_prc_item_status = new MVC.DTO.FieldDecimal(FieldNames.StatusItem, Captions.StatusItem, DbType.Decimal);
            this.cad_mtmd_prc_obs = new MVC.DTO.FieldString(FieldNames.ObservacaoItem, Captions.ObservacaoItem, 100);

            this.cad_mtmd_prc_via = new MVC.DTO.FieldString(FieldNames.Via, Captions.Via, 2);
            this.cad_mtmd_prc_autorizado = new MVC.DTO.FieldDecimal(FieldNames.FlAutorizado, Captions.FlAutorizado, DbType.Decimal);
            this.cad_mtmd_prc_parecer_scih = new MVC.DTO.FieldString(FieldNames.ParecerSCIH, Captions.ParecerSCIH, 300);
            this.cad_mtmd_prc_parecer_data = new MVC.DTO.FieldDateTime(FieldNames.ParecerData, Captions.ParecerData);
            this.cad_pro_id_prof_scih = new MVC.DTO.FieldDecimal(FieldNames.IdProfissionalSCIH, Captions.IdProfissionalSCIH, DbType.Decimal);
            this.seg_usu_id_alteracao = new MVC.DTO.FieldDecimal(FieldNames.IdUsuarioAlteracao, Captions.IdUsuarioAlteracao, DbType.Decimal);
            this.cad_mtmd_dt_alteracao = new MVC.DTO.FieldDateTime(FieldNames.DataAlteracao, Captions.DataAlteracao);

            this.cad_mtmd_cultura_seq = new MVC.DTO.FieldDecimal(FieldNames.CulturaSequencial, Captions.CulturaSequencial, DbType.Decimal);
            this.cad_mtmd_data_cultura = new MVC.DTO.FieldDateTime(FieldNames.DataCultura, Captions.DataCultura);
            this.cad_mtmd_material = new MVC.DTO.FieldString(FieldNames.Material, Captions.Material, 200);
            this.cad_mtmd_microorganismo = new MVC.DTO.FieldString(FieldNames.Microorganismo, Captions.Microorganismo, 200);
            this.cad_mtmd_sensibilidade_mic = new MVC.DTO.FieldString(FieldNames.SensibilidadeMIC, Captions.SensibilidadeMIC, 200);
            this.cad_mtmd_dodi_id = new MVC.DTO.FieldDecimal(FieldNames.IdDoencaDiagnostico, Captions.IdDoencaDiagnostico, DbType.Decimal);
            this.atd_pme_id = new MVC.DTO.FieldDecimal(FieldNames.IdPrescricaoMedica, Captions.IdPrescricaoMedica, DbType.Decimal);
            this.atd_mpm_id = new MVC.DTO.FieldDecimal(FieldNames.IdMedicamentoPrescricaoMedica, Captions.IdMedicamentoPrescricaoMedica, DbType.Decimal);
            this.fl_internacao_previa = new MVC.DTO.FieldString(FieldNames.InternacaoPrevia, Captions.InternacaoPrevia, 1);
            this.cad_mtmd_prc_atm_previo = new MVC.DTO.FieldString(FieldNames.AtmPrevio, Captions.AtmPrevio, 200);
        }

        #region FieldNames

        public struct FieldNames
        {
            public const string IdPrescricao = "CAD_MTMD_PRESCRICAO_ID";
            public const string IdAtendimento = "ATD_ATE_ID";
            public const string Status = "CAD_MTMD_PRESCRICAO_STATUS";
            public const string CRM = "CAD_MTMD_CRM";
            public const string DataInclusao = "CAD_MTMD_DT_INCLUSAO";

            public const string FlInternadoUTI = "CAD_MTMD_PRC_INTERNADO_UTI";
            public const string FlVentilaMecanica = "CAD_MTMD_PRC_VENTILA_MECANICA";
            public const string CirurgiaDsc = "CAD_MTMD_PRC_CIRURGIA";
            public const string AcessoVascularDsc = "CAD_MTMD_PRC_ACESSO_VASCULAR";
            public const string SondaVesicalDsc = "CAD_MTMD_PRC_SONDA_VESICAL";
            public const string OutrosDsc = "CAD_MTMD_PRC_OUTROS";
            public const string Peso = "CAD_MTMD_PRC_PESO";
            public const string Creatinina = "CAD_MTMD_PRC_CREATININA";
            public const string ProcedenciaPaciente = "CAD_MTMD_PRC_PROCEDENCIA_PAC";
            public const string DataAssinaturaSCIH = "CAD_MTMD_DT_ASSINATURA_SCIH";
            public const string UFConselhoProfissional = "CAD_PSO_SG_UF_CONSELHO";
            public const string InformacoesComplementares = "CAD_MTMD_PRC_INF_COMPL";

            public const string IdProduto = "CAD_MTMD_ID";
            public const string QtdDia = "CAD_MTMD_PRC_QTDE_DIA";
            public const string QtdTotal = "CAD_MTMD_PRC_QTDE_TOTAL";
            public const string QtdDispensada = "CAD_MTMD_PRC_QTDE_DISP";
            public const string DataInicioConsumo = "CAD_MTMD_DT_INICIO_CONS";
            public const string DataLimiteConsumo = "CAD_MTMD_DT_FIM_CONS";
            public const string StatusItem = "CAD_MTMD_PRC_ITEM_STATUS";
            public const string ObservacaoItem = "CAD_MTMD_PRC_OBS";

            public const string Via = "CAD_MTMD_PRC_VIA";
            public const string FlAutorizado = "CAD_MTMD_PRC_AUTORIZADO";
            public const string ParecerSCIH = "CAD_MTMD_PRC_PARECER_SCIH";
            public const string ParecerData = "CAD_MTMD_PRC_PARECER_DATA";
            public const string IdProfissionalSCIH = "CAD_PRO_ID_PROF_SCIH";
            public const string IdUsuarioAlteracao = "SEG_USU_ID_ALTERACAO";
            public const string DataAlteracao = "CAD_MTMD_DT_ALTERACAO";

            public const string CulturaSequencial = "CAD_MTMD_CULTURA_SEQ";
            public const string DataCultura = "CAD_MTMD_DATA_CULTURA";
            public const string Material = "CAD_MTMD_MATERIAL";
            public const string Microorganismo = "CAD_MTMD_MICROORGANISMO";
            public const string SensibilidadeMIC = "CAD_MTMD_SENSIBILIDADE_MIC";
            public const string IdDoencaDiagnostico = "CAD_MTMD_DODI_ID";
            public const string IdPrescricaoMedica = "ATD_PME_ID";
            public const string IdMedicamentoPrescricaoMedica = "ATD_MPM_ID";
            public const string InternacaoPrevia = "FL_INTERNACAO_PREVIA";
            public const string AtmPrevio = "CAD_MTMD_PRC_ATM_PREVIO";
        }

        #endregion

        #region Captions

        public struct Captions
        {
            public const string IdPrescricao = "CAD_MTMD_PRESCRICAO_ID";
            public const string IdAtendimento = "ATD_ATE_ID";
            public const string Status = "CAD_MTMD_PRESCRICAO_STATUS";
            public const string CRM = "CAD_MTMD_CRM";
            public const string DataInclusao = "CAD_MTMD_DT_INCLUSAO";

            public const string FlInternadoUTI = "CAD_MTMD_PRC_INTERNADO_UTI";
            public const string FlVentilaMecanica = "CAD_MTMD_PRC_VENTILA_MECANICA";
            public const string CirurgiaDsc = "CAD_MTMD_PRC_CIRURGIA";
            public const string AcessoVascularDsc = "CAD_MTMD_PRC_ACESSO_VASCULAR";
            public const string SondaVesicalDsc = "CAD_MTMD_PRC_SONDA_VESICAL";
            public const string OutrosDsc = "CAD_MTMD_PRC_OUTROS";
            public const string Peso = "CAD_MTMD_PRC_PESO";
            public const string Creatinina = "CAD_MTMD_PRC_CREATININA";
            public const string ProcedenciaPaciente = "CAD_MTMD_PRC_PROCEDENCIA_PAC";
            public const string DataAssinaturaSCIH = "CAD_MTMD_DT_ASSINATURA_SCIH";
            public const string UFConselhoProfissional = "CAD_PSO_SG_UF_CONSELHO";
            public const string InformacoesComplementares = "CAD_MTMD_PRC_INF_COMPL";

            public const string IdProduto = "CAD_MTMD_ID";
            public const string QtdDia = "CAD_MTMD_PRC_QTDE_DIA";
            public const string QtdTotal = "CAD_MTMD_PRC_QTDE_TOTAL";
            public const string QtdDispensada = "CAD_MTMD_PRC_QTDE_DISP";
            public const string DataInicioConsumo = "CAD_MTMD_DT_INICIO_CONS";
            public const string DataLimiteConsumo = "CAD_MTMD_DT_FIM_CONS";
            public const string StatusItem = "CAD_MTMD_PRC_ITEM_STATUS";
            public const string ObservacaoItem = "CAD_MTMD_PRC_OBS";

            public const string Via = "CAD_MTMD_PRC_VIA";
            public const string FlAutorizado = "CAD_MTMD_PRC_AUTORIZADO";
            public const string ParecerSCIH = "CAD_MTMD_PRC_PARECER_SCIH";
            public const string ParecerData = "CAD_MTMD_PRC_PARECER_DATA";
            public const string IdProfissionalSCIH = "CAD_PRO_ID_PROF_SCIH";
            public const string IdUsuarioAlteracao = "SEG_USU_ID_ALTERACAO";
            public const string DataAlteracao = "CAD_MTMD_DT_ALTERACAO";

            public const string CulturaSequencial = "CAD_MTMD_CULTURA_SEQ";
            public const string DataCultura = "CAD_MTMD_DATA_CULTURA";
            public const string Material = "CAD_MTMD_MATERIAL";
            public const string Microorganismo = "CAD_MTMD_MICROORGANISMO";
            public const string SensibilidadeMIC = "CAD_MTMD_SENSIBILIDADE_MIC";
            public const string IdDoencaDiagnostico = "CAD_MTMD_DODI_ID";
            public const string IdPrescricaoMedica = "ATD_PME_ID";
            public const string IdMedicamentoPrescricaoMedica = "ATD_MPM_ID";
            public const string InternacaoPrevia = "FL_INTERNACAO_PREVIA";
            public const string AtmPrevio = "CAD_MTMD_PRC_ATM_PREVIO";
        }

        #endregion

        #region Atributos Publicos

        public MVC.DTO.FieldDecimal IdPrescricao
        {
            get { return cad_mtmd_prescricao_id; }
            set { cad_mtmd_prescricao_id = value; }
        }

        public MVC.DTO.FieldDecimal IdAtendimento
        {
            get { return atd_ate_id; }
            set { atd_ate_id = value; }
        }

        public MVC.DTO.FieldDecimal Status
        {
            get { return cad_mtmd_prescricao_status; }
            set { cad_mtmd_prescricao_status = value; }
        }

        public MVC.DTO.FieldString CRM
        {
            get { return cad_mtmd_crm; }
            set { cad_mtmd_crm = value; }
        }

        public MVC.DTO.FieldDateTime DataInclusao
        {
            get { return cad_mtmd_dt_inclusao; }
            set { cad_mtmd_dt_inclusao = value; }
        }

        public MVC.DTO.FieldDecimal FlInternadoUTI
        {
            get { return cad_mtmd_prc_internado_uti; }
            set { cad_mtmd_prc_internado_uti = value; }
        }

        public MVC.DTO.FieldDecimal FlVentilaMecanica
        {
            get { return cad_mtmd_prc_ventila_mecanica; }
            set { cad_mtmd_prc_ventila_mecanica = value; }
        }

        public MVC.DTO.FieldString CirurgiaDsc
        {
            get { return cad_mtmd_prc_cirurgia; }
            set { cad_mtmd_prc_cirurgia = value; }
        }

        public MVC.DTO.FieldString AcessoVascularDsc
        {
            get { return cad_mtmd_prc_acesso_vascular; }
            set { cad_mtmd_prc_acesso_vascular = value; }
        }

        public MVC.DTO.FieldString SondaVesicalDsc
        {
            get { return cad_mtmd_prc_sonda_vesical; }
            set { cad_mtmd_prc_sonda_vesical = value; }
        }

        public MVC.DTO.FieldString OutrosDsc
        {
            get { return cad_mtmd_prc_outros; }
            set { cad_mtmd_prc_outros = value; }
        }

        public MVC.DTO.FieldDecimal Peso
        {
            get { return cad_mtmd_prc_peso; }
            set { cad_mtmd_prc_peso = value; }
        }

        public MVC.DTO.FieldString Creatinina
        {
            get { return cad_mtmd_prc_creatinina; }
            set { cad_mtmd_prc_creatinina = value; }
        }

        public MVC.DTO.FieldDecimal ProcedenciaPaciente
        {
            get { return cad_mtmd_prc_procedencia_pac; }
            set { cad_mtmd_prc_procedencia_pac = value; }
        }

        public MVC.DTO.FieldDateTime DataAssinaturaSCIH
        {
            get { return cad_mtmd_dt_assinatura_scih; }
            set { cad_mtmd_dt_assinatura_scih = value; }
        }

        public MVC.DTO.FieldString UFConselhoProfissional
        {
            get { return cad_pso_sg_uf_conselho; }
            set { cad_pso_sg_uf_conselho = value; }
        }

        public MVC.DTO.FieldString InformacoesComplementares
        {
            get { return cad_mtmd_prc_inf_compl; }
            set { cad_mtmd_prc_inf_compl = value; }
        }

        public MVC.DTO.FieldDecimal IdProduto
        {
            get { return cad_mtmd_id; }
            set { cad_mtmd_id = value; }
        }

        public MVC.DTO.FieldDecimal QtdDia
        {
            get { return cad_mtmd_prc_qtde_dia; }
            set { cad_mtmd_prc_qtde_dia = value; }
        }

        public MVC.DTO.FieldDecimal QtdTotal
        {
            get { return cad_mtmd_prc_qtde_total; }
            set { cad_mtmd_prc_qtde_total = value; }
        }

        public MVC.DTO.FieldDecimal QtdDispensada
        {
            get { return cad_mtmd_prc_qtde_disp; }
            set { cad_mtmd_prc_qtde_disp = value; }
        }

        public MVC.DTO.FieldDateTime DataInicioConsumo
        {
            get { return cad_mtmd_dt_inicio_cons; }
            set { cad_mtmd_dt_inicio_cons = value; }
        }

        public MVC.DTO.FieldDateTime DataLimiteConsumo
        {
            get { return cad_mtmd_dt_fim_cons; }
            set { cad_mtmd_dt_fim_cons = value; }
        }

        public MVC.DTO.FieldDecimal StatusItem
        {
            get { return cad_mtmd_prc_item_status; }
            set { cad_mtmd_prc_item_status = value; }
        }

        public MVC.DTO.FieldString ObservacaoItem
        {
            get { return cad_mtmd_prc_obs; }
            set { cad_mtmd_prc_obs = value; }
        }

        public MVC.DTO.FieldString Via
        {
            get { return cad_mtmd_prc_via; }
            set { cad_mtmd_prc_via = value; }
        }

        public MVC.DTO.FieldDecimal FlAutorizado
        {
            get { return cad_mtmd_prc_autorizado; }
            set { cad_mtmd_prc_autorizado = value; }
        }

        public MVC.DTO.FieldString ParecerSCIH
        {
            get { return cad_mtmd_prc_parecer_scih; }
            set { cad_mtmd_prc_parecer_scih = value; }
        }

        public MVC.DTO.FieldDateTime ParecerData
        {
            get { return cad_mtmd_prc_parecer_data; }
            set { cad_mtmd_prc_parecer_data = value; }
        }

        public MVC.DTO.FieldDecimal IdProfissionalSCIH
        {
            get { return cad_pro_id_prof_scih; }
            set { cad_pro_id_prof_scih = value; }
        }

        public MVC.DTO.FieldDecimal IdUsuarioAlteracao
        {
            get { return seg_usu_id_alteracao; }
            set { seg_usu_id_alteracao = value; }
        }

        public MVC.DTO.FieldDateTime DataAlteracao
        {
            get { return cad_mtmd_dt_alteracao; }
            set { cad_mtmd_dt_alteracao = value; }
        }

        public MVC.DTO.FieldDateTime DataCultura
        {
            get { return cad_mtmd_data_cultura; }
            set { cad_mtmd_data_cultura = value; }
        }

        public MVC.DTO.FieldString Material
        {
            get { return cad_mtmd_material; }
            set { cad_mtmd_material = value; }
        }

        public MVC.DTO.FieldString Microorganismo
        {
            get { return cad_mtmd_microorganismo; }
            set { cad_mtmd_microorganismo = value; }
        }

        public MVC.DTO.FieldString SensibilidadeMIC
        {
            get { return cad_mtmd_sensibilidade_mic; }
            set { cad_mtmd_sensibilidade_mic = value; }
        }

        public MVC.DTO.FieldDecimal IdDoencaDiagnostico
        {
            get { return cad_mtmd_dodi_id; }
            set { cad_mtmd_dodi_id = value; }
        }

        public MVC.DTO.FieldDecimal CulturaSequencial
        {
            get { return cad_mtmd_cultura_seq; }
            set { cad_mtmd_cultura_seq = value; }
        }

        public MVC.DTO.FieldDecimal IdPrescricaoMedica
        {
            get { return atd_pme_id; }
            set { atd_pme_id = value; }
        }

        public MVC.DTO.FieldDecimal IdMedicamentoPrescricaoMedica
        {
            get { return atd_mpm_id; }
            set { atd_mpm_id = value; }
        }

        public MVC.DTO.FieldString InternacaoPrevia
        {
            get { return fl_internacao_previa; }
            set { fl_internacao_previa = value; }
        }

        public MVC.DTO.FieldString AtmPrevio
        {
            get { return cad_mtmd_prc_atm_previo; }
            set { cad_mtmd_prc_atm_previo = value; }
        }
        #endregion

        #region Operators

        public static explicit operator PrescricaoDTO(DataRow row)
        {
            PrescricaoDTO dto = new PrescricaoDTO();

            dto.IdPrescricao.Value = row[FieldNames.IdPrescricao].ToString();

            dto.IdAtendimento.Value = row[FieldNames.IdAtendimento].ToString();

            dto.Status.Value = row[FieldNames.Status].ToString();

            dto.CRM.Value = row[FieldNames.CRM].ToString();

            dto.DataInclusao.Value = row[FieldNames.DataInclusao].ToString();

            dto.IdProduto.Value = row[FieldNames.IdProduto].ToString();

            dto.QtdDia.Value = row[FieldNames.QtdDia].ToString();

            dto.QtdTotal.Value = row[FieldNames.QtdTotal].ToString();

            dto.QtdDispensada.Value = row[FieldNames.QtdDispensada].ToString();

            dto.DataInicioConsumo.Value = row[FieldNames.DataInicioConsumo].ToString();

            dto.DataLimiteConsumo.Value = row[FieldNames.DataLimiteConsumo].ToString();

            dto.StatusItem.Value = row[FieldNames.StatusItem].ToString();

            dto.ObservacaoItem.Value = row[FieldNames.ObservacaoItem].ToString();

            dto.FlInternadoUTI.Value = row[FieldNames.FlInternadoUTI].ToString();
            dto.FlVentilaMecanica.Value = row[FieldNames.FlVentilaMecanica].ToString();
            dto.CirurgiaDsc.Value = row[FieldNames.CirurgiaDsc].ToString();
            dto.AcessoVascularDsc.Value = row[FieldNames.AcessoVascularDsc].ToString();
            dto.SondaVesicalDsc.Value = row[FieldNames.SondaVesicalDsc].ToString();
            dto.OutrosDsc.Value = row[FieldNames.OutrosDsc].ToString();
            dto.Peso.Value = row[FieldNames.Peso].ToString();
            dto.Creatinina.Value = row[FieldNames.Creatinina].ToString();
            dto.ProcedenciaPaciente.Value = row[FieldNames.ProcedenciaPaciente].ToString();
            dto.DataAssinaturaSCIH.Value = row[FieldNames.DataAssinaturaSCIH].ToString();
            dto.UFConselhoProfissional.Value = row[FieldNames.UFConselhoProfissional].ToString();
            dto.InformacoesComplementares.Value = row[FieldNames.InformacoesComplementares].ToString();
            dto.Via.Value = row[FieldNames.Via].ToString();
            dto.FlAutorizado.Value = row[FieldNames.FlAutorizado].ToString();
            dto.ParecerSCIH.Value = row[FieldNames.ParecerSCIH].ToString();
            dto.ParecerData.Value = row[FieldNames.ParecerData].ToString();
            dto.IdProfissionalSCIH.Value = row[FieldNames.IdProfissionalSCIH].ToString();
            dto.IdUsuarioAlteracao.Value = row[FieldNames.IdUsuarioAlteracao].ToString();
            dto.DataAlteracao.Value = row[FieldNames.DataAlteracao].ToString();

            dto.DataCultura.Value = row[FieldNames.DataCultura].ToString();

            dto.Material.Value = row[FieldNames.Material].ToString();

            dto.Microorganismo.Value = row[FieldNames.Microorganismo].ToString();

            dto.SensibilidadeMIC.Value = row[FieldNames.SensibilidadeMIC].ToString();

            dto.IdDoencaDiagnostico.Value = row[FieldNames.IdDoencaDiagnostico].ToString();

            dto.CulturaSequencial.Value = row[FieldNames.CulturaSequencial].ToString();

            dto.IdPrescricaoMedica.Value = row[FieldNames.IdPrescricaoMedica].ToString();
            dto.IdMedicamentoPrescricaoMedica.Value = row[FieldNames.IdMedicamentoPrescricaoMedica].ToString();

            dto.InternacaoPrevia.Value = row[FieldNames.InternacaoPrevia].ToString();
            dto.AtmPrevio.Value = row[FieldNames.AtmPrevio].ToString();

            return dto;
        }

        public static explicit operator DataRow(PrescricaoDTO dto)
        {
            PrescricaoDataTable dtb = new PrescricaoDataTable();
            DataRow dtr = dtb.NewRow();

            dtr[FieldNames.IdPrescricao] = dto.IdPrescricao.Value;

            dtr[FieldNames.IdAtendimento] = dto.IdAtendimento.Value;

            dtr[FieldNames.Status] = dto.Status.Value;

            dtr[FieldNames.CRM] = dto.CRM.Value;

            dtr[FieldNames.DataInclusao] = dto.DataInclusao.Value;

            dtr[FieldNames.IdProduto] = dto.IdProduto.Value;

            dtr[FieldNames.QtdDia] = dto.QtdDia.Value;

            dtr[FieldNames.QtdTotal] = dto.QtdTotal.Value;

            dtr[FieldNames.QtdDispensada] = dto.QtdDispensada.Value;

            dtr[FieldNames.DataInicioConsumo] = dto.DataInicioConsumo.Value;

            dtr[FieldNames.DataLimiteConsumo] = dto.DataLimiteConsumo.Value;

            dtr[FieldNames.StatusItem] = dto.StatusItem.Value;

            dtr[FieldNames.ObservacaoItem] = dto.ObservacaoItem.Value;

            dtr[FieldNames.FlInternadoUTI] = dto.FlInternadoUTI.Value;

            dtr[FieldNames.FlVentilaMecanica] = dto.FlVentilaMecanica.Value;

            dtr[FieldNames.CirurgiaDsc] = dto.CirurgiaDsc.Value;

            dtr[FieldNames.AcessoVascularDsc] = dto.AcessoVascularDsc.Value;

            dtr[FieldNames.SondaVesicalDsc] = dto.SondaVesicalDsc.Value;

            dtr[FieldNames.OutrosDsc] = dto.OutrosDsc.Value;

            dtr[FieldNames.Peso] = dto.Peso.Value;

            dtr[FieldNames.Creatinina] = dto.Creatinina.Value;

            dtr[FieldNames.ProcedenciaPaciente] = dto.ProcedenciaPaciente.Value;

            dtr[FieldNames.DataAssinaturaSCIH] = dto.DataAssinaturaSCIH.Value;

            dtr[FieldNames.UFConselhoProfissional] = dto.UFConselhoProfissional.Value;

            dtr[FieldNames.InformacoesComplementares] = dto.InformacoesComplementares.Value;

            dtr[FieldNames.Via] = dto.Via.Value;

            dtr[FieldNames.FlAutorizado] = dto.FlAutorizado.Value;

            dtr[FieldNames.ParecerSCIH] = dto.ParecerSCIH.Value;

            dtr[FieldNames.ParecerData] = dto.ParecerData.Value;

            dtr[FieldNames.IdProfissionalSCIH] = dto.IdProfissionalSCIH.Value;

            dtr[FieldNames.IdUsuarioAlteracao] = dto.IdUsuarioAlteracao.Value;

            dtr[FieldNames.DataAlteracao] = dto.DataAlteracao.Value;

            dtr[FieldNames.DataCultura] = dto.DataCultura.Value;

            dtr[FieldNames.Material] = dto.Material.Value;

            dtr[FieldNames.Microorganismo] = dto.Microorganismo.Value;

            dtr[FieldNames.SensibilidadeMIC] = dto.SensibilidadeMIC.Value;

            dtr[FieldNames.IdDoencaDiagnostico] = dto.IdDoencaDiagnostico.Value;

            dtr[FieldNames.CulturaSequencial] = dto.CulturaSequencial.Value;

            dtr[FieldNames.IdPrescricaoMedica] = dto.IdPrescricaoMedica.Value;

            dtr[FieldNames.IdMedicamentoPrescricaoMedica] = dto.IdMedicamentoPrescricaoMedica.Value;

            dtr[FieldNames.InternacaoPrevia] = dto.InternacaoPrevia.Value;
            dtr[FieldNames.AtmPrevio] = dto.AtmPrevio.Value;

            return dtr;
        }

        #endregion
    }
}