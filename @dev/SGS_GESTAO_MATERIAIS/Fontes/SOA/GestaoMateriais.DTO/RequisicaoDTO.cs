
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
    /// <summary>
    /// Classe Entidade RequisicaoDataTable
    /// </summary>
    [Serializable()]
    public class RequisicaoDataTable : DataTable
    {
        public RequisicaoDataTable()
            : base()
        {
            this.TableName = "DADOS";

            this.Columns.Add(RequisicaoDTO.FieldNames.Idt, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.IdtReqRef, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.Status, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.Urgencia, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.DataAtualizacao, typeof(DateTime));

            this.Columns.Add(RequisicaoDTO.FieldNames.IdtSetor, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.IdtLocal, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.IdtUnidade, typeof(Decimal));

            this.Columns.Add(RequisicaoDTO.FieldNames.DsSetor, typeof(String));
            this.Columns.Add(RequisicaoDTO.FieldNames.DsLocal, typeof(String));
            this.Columns.Add(RequisicaoDTO.FieldNames.DsUnidade, typeof(String));


            this.Columns.Add(RequisicaoDTO.FieldNames.IdtTipoRequisicao, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.IdtUsuario, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.IdtFilial, typeof(Decimal));

            this.Columns.Add(RequisicaoDTO.FieldNames.IdtAtendimento, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.TpAtendimento, typeof(String));

            this.Columns.Add(RequisicaoDTO.FieldNames.DataRequisicao, typeof(DateTime));
            this.Columns.Add(RequisicaoDTO.FieldNames.DataRequisicao2, typeof(DateTime));
            this.Columns.Add(RequisicaoDTO.FieldNames.IdtUsuarioRequisicao, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.DsUsuarioRequisicao, typeof(String));

            this.Columns.Add(RequisicaoDTO.FieldNames.DataDispensacao, typeof(DateTime));
            this.Columns.Add(RequisicaoDTO.FieldNames.IdtUsuarioDispensacao, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.DsUsuarioDispensacao, typeof(String));

            this.Columns.Add(RequisicaoDTO.FieldNames.FlPendente, typeof(Decimal));

            this.Columns.Add(RequisicaoDTO.FieldNames.DsTipoRequisicao, typeof(String));

            this.Columns.Add(RequisicaoDTO.FieldNames.IdKit, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.DescricaoKit, typeof(String));

            this.Columns.Add(RequisicaoDTO.FieldNames.SetorFarmacia, typeof(Decimal));

            this.Columns.Add(RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraIniVigencia, typeof(DateTime));
            this.Columns.Add(RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraFimVigencia, typeof(DateTime));
            this.Columns.Add(RequisicaoDTO.FieldNames.SetorPedidoAutoHoraInicioProcesso, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.SetorPedidoAutoHorasTotaisGerar, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.SetorPedidoAutoHorasPeriodoDose, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.SetorPedidoAutoHorasMinimaIniciar, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.SetorPedidoAutoFlItensImediatos, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.SetorPedidoAutoFlTotalImediato, typeof(Decimal));
            this.Columns.Add(RequisicaoDTO.FieldNames.SetorPedidoAutoFlNaoGerar, typeof(Decimal));

            //DataColumn[] primaryKey = { this.Columns[RequisicaoDTO.FieldNames.Idt] };

            //this.PrimaryKey = primaryKey;
        }

        protected RequisicaoDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }


        public RequisicaoDTO TypedRow(int index)
        {
            return (RequisicaoDTO)this.Rows[index];
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

        public void Add(RequisicaoDTO dto)
        {
            DataRow dtr = this.NewRow();

            if (!dto.SetorPedidoAutoDtHoraIniVigencia.Value.IsNull) dtr[RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraIniVigencia] = (DateTime)dto.SetorPedidoAutoDtHoraIniVigencia.Value;
            if (!dto.SetorPedidoAutoDtHoraFimVigencia.Value.IsNull) dtr[RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraFimVigencia] = (DateTime)dto.SetorPedidoAutoDtHoraFimVigencia.Value;
            if (!dto.SetorPedidoAutoHoraInicioProcesso.Value.IsNull) dtr[RequisicaoDTO.FieldNames.SetorPedidoAutoHoraInicioProcesso] = (Decimal)dto.SetorPedidoAutoHoraInicioProcesso.Value;
            if (!dto.SetorPedidoAutoHorasTotaisGerar.Value.IsNull) dtr[RequisicaoDTO.FieldNames.SetorPedidoAutoHorasTotaisGerar] = (Decimal)dto.SetorPedidoAutoHorasTotaisGerar.Value;
            if (!dto.SetorPedidoAutoHorasPeriodoDose.Value.IsNull) dtr[RequisicaoDTO.FieldNames.SetorPedidoAutoHorasPeriodoDose] = (Decimal)dto.SetorPedidoAutoHorasPeriodoDose.Value;
            if (!dto.SetorPedidoAutoHorasMinimaIniciar.Value.IsNull) dtr[RequisicaoDTO.FieldNames.SetorPedidoAutoHorasMinimaIniciar] = (Decimal)dto.SetorPedidoAutoHorasMinimaIniciar.Value;
            if (!dto.SetorPedidoAutoFlItensImediatos.Value.IsNull) dtr[RequisicaoDTO.FieldNames.SetorPedidoAutoFlItensImediatos] = (Decimal)dto.SetorPedidoAutoFlItensImediatos.Value;
            if (!dto.SetorPedidoAutoFlTotalImediato.Value.IsNull) dtr[RequisicaoDTO.FieldNames.SetorPedidoAutoFlTotalImediato] = (Decimal)dto.SetorPedidoAutoFlTotalImediato.Value;
            if (!dto.SetorPedidoAutoFlNaoGerar.Value.IsNull) dtr[RequisicaoDTO.FieldNames.SetorPedidoAutoFlNaoGerar] = (Decimal)dto.SetorPedidoAutoFlNaoGerar.Value;

            if (!dto.Idt.Value.IsNull) dtr[RequisicaoDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
            // if (!dto.NrInternacaoLegado.Value.IsNull) dtr[RequisicaoDTO.FieldNames.NrInternacaoLegado] = (Decimal)dto.NrInternacaoLegado.Value;
            if (!dto.Status.Value.IsNull) dtr[RequisicaoDTO.FieldNames.Status] = (Decimal)dto.Status.Value;
            if (!dto.Urgencia.Value.IsNull) dtr[RequisicaoDTO.FieldNames.Urgencia] = (Decimal)dto.Urgencia.Value;
            if (!dto.DataAtualizacao.Value.IsNull) dtr[RequisicaoDTO.FieldNames.DataAtualizacao] = (DateTime)dto.DataAtualizacao.Value;
            if (!dto.IdtSetor.Value.IsNull) dtr[RequisicaoDTO.FieldNames.IdtSetor] = (Decimal)dto.IdtSetor.Value;
            if (!dto.IdtLocal.Value.IsNull) dtr[RequisicaoDTO.FieldNames.IdtLocal] = (Decimal)dto.IdtLocal.Value;
            if (!dto.IdtUnidade.Value.IsNull) dtr[RequisicaoDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;

            if (!dto.DsSetor.Value.IsNull) dtr[RequisicaoDTO.FieldNames.DsSetor] = (String)dto.DsSetor.Value;
            if (!dto.DsLocal.Value.IsNull) dtr[RequisicaoDTO.FieldNames.DsLocal] = (String)dto.DsLocal.Value;
            if (!dto.DsUnidade.Value.IsNull) dtr[RequisicaoDTO.FieldNames.DsUnidade] = (String)dto.DsUnidade.Value;

            if (!dto.IdtTipoRequisicao.Value.IsNull) dtr[RequisicaoDTO.FieldNames.IdtTipoRequisicao] = (Decimal)dto.IdtTipoRequisicao.Value;
            if (!dto.IdtUsuario.Value.IsNull) dtr[RequisicaoDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;
            if (!dto.IdtFilial.Value.IsNull) dtr[RequisicaoDTO.FieldNames.IdtFilial] = (Decimal)dto.IdtFilial.Value;


            if (!dto.IdtAtendimento.Value.IsNull) dtr[RequisicaoDTO.FieldNames.IdtAtendimento] = (Decimal)dto.IdtAtendimento.Value;
            if (!dto.TpAtendimento.Value.IsNull) dtr[RequisicaoDTO.FieldNames.TpAtendimento] = (String)dto.TpAtendimento.Value;

            if (!dto.IdtUsuarioRequisicao.Value.IsNull) dtr[RequisicaoDTO.FieldNames.IdtUsuarioRequisicao] = (Decimal)dto.IdtUsuarioRequisicao.Value;
            if (!dto.DsUsuarioRequisicao.Value.IsNull) dtr[RequisicaoDTO.FieldNames.DsUsuarioRequisicao] = (String)dto.DsUsuarioRequisicao.Value;
            if (!dto.DataRequisicao.Value.IsNull) dtr[RequisicaoDTO.FieldNames.DataRequisicao] = (DateTime)dto.DataRequisicao.Value;
            if (!dto.DataRequisicao2.Value.IsNull) dtr[RequisicaoDTO.FieldNames.DataRequisicao2] = (DateTime)dto.DataRequisicao2.Value;
            if (!dto.IdtUsuarioDispensacao.Value.IsNull) dtr[RequisicaoDTO.FieldNames.IdtAtendimento] = (Decimal)dto.IdtAtendimento.Value;
            if (!dto.DataDispensacao.Value.IsNull) dtr[RequisicaoDTO.FieldNames.DataDispensacao] = (DateTime)dto.DataDispensacao.Value;
            if (!dto.DsUsuarioDispensacao.Value.IsNull) dtr[RequisicaoDTO.FieldNames.DsUsuarioDispensacao] = (String)dto.DsUsuarioDispensacao.Value;
            if (!dto.FlPendente.Value.IsNull) dtr[RequisicaoDTO.FieldNames.FlPendente] = (Decimal)dto.FlPendente.Value;
            if (!dto.IdtReqRef.Value.IsNull) dtr[RequisicaoDTO.FieldNames.IdtReqRef] = (Decimal)dto.IdtReqRef.Value;
            if (!dto.IdKit.Value.IsNull) dtr[RequisicaoDTO.FieldNames.IdKit] = (Decimal)dto.IdKit.Value;
            if (!dto.DescricaoKit.Value.IsNull) dtr[RequisicaoDTO.FieldNames.DescricaoKit] = (String)dto.DescricaoKit.Value;
            if (!dto.DsTipoRequisicao.Value.IsNull) dtr[RequisicaoDTO.FieldNames.DsTipoRequisicao] = (String)dto.DsTipoRequisicao.Value;

            if (!dto.SetorFarmacia.Value.IsNull) dtr[RequisicaoDTO.FieldNames.SetorFarmacia] = (Decimal)dto.SetorFarmacia.Value;

            this.Rows.Add(dtr);
        }
    }

    [Serializable()]
    public class RequisicaoDTO : MVC.DTO.DTOBase
    {

        public enum StatusRequisicao
        {
            CANCELADA = 0,
            ABERTA = 1,
            FECHADA = 2,
            DISPENSADA_ALMOX = 3, // SALVA E DEVE ESTAR SENDO ENVIADA AO SETOR
            RECEBIDA_UNIDADE = 4, // UNIDADE CONFIRMOU RECEBIMENTO DO PEDIDO ( EM DESUSO )
            IMPRESSO = 5,         // IMPRESSO NO ALMOXARIFADO
            CANCELADA_POR_ALTA = 6, // PACIENTE RECEBEU ALTA DEPOIS DO PEDIDO REALIZADO
            REGISTRANDO_DISPENSACAO = 7, // O ALMOXARIFE ESTA REGISTRANDO O PRODUTO PARA DISPENSAR
            DEVOLVIDO_ENFERMAGEM = 8, // DEVOLVIDO PELA ENFERMAGEM PARA REENVIO DO ALMOX.
            TRANSFERIDO_PACIENTE = 9 // PACIENTE TRANSFERIDO DE SETOR
        }

        public enum TipoRequisicao
        {
            PERSONALIZADO = 0,
            PADRAO = 1,
            IMPRESSOS_MAT_EXPEDIENTE = 2,
            CARRINHO_EMERGENCIA = 3,
            INTERNACAO_DOMICILIAR = 4,
            CENTRO_CIRURGICO = 5,
            HIGIENIZACAO = 6,
            OUTROS = 7, //Avulso
            ESTOQUE_LOCAL_MAT_MED = 8,
            MANUTENCAO = 9
        }

        public enum Pendente
        {
            NAO = 0,
            SIM = 1
        }

        private MVC.DTO.FieldDecimal mtmd_req_id;
        // private MVC.DTO.FieldDecimal nr_seqinter;
        private MVC.DTO.FieldDecimal mtmd_req_fl_status;
        private MVC.DTO.FieldDecimal mtmd_req_fl_urgencia;
        private MVC.DTO.FieldDateTime mtmd_req_dt_atualizacao;

        private MVC.DTO.FieldString cad_set_ds_setor;
        private MVC.DTO.FieldString cad_lat_ds_local_atendimento;
        private MVC.DTO.FieldString cad_uni_ds_unidade;

        private MVC.DTO.FieldDecimal cad_set_id;
        private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
        private MVC.DTO.FieldDecimal cad_uni_id_unidade;

        private MVC.DTO.FieldDecimal mtm_tipo_requisicao;
        private MVC.DTO.FieldDecimal cad_mtmd_filial_id;
        private MVC.DTO.FieldDecimal seg_usu_id_usuario;

        private MVC.DTO.FieldDecimal atd_ate_id;
        private MVC.DTO.FieldString atd_ate_tp_paciente;


        private MVC.DTO.FieldDecimal mtmd_id_usuario_requisicao;
        private MVC.DTO.FieldString ds_usuario_requisicao;
        private MVC.DTO.FieldDateTime mtmd_data_requisicao;
        private MVC.DTO.FieldDateTime mtmd_data_requisicao2;
        private MVC.DTO.FieldDecimal mtmd_id_usuario_dispensacao;
        private MVC.DTO.FieldString ds_usuario_dispensacao;
        private MVC.DTO.FieldDateTime mtmd_data_dispensacao;
        private MVC.DTO.FieldDecimal mtmd_fl_pendente;
        private MVC.DTO.FieldDecimal mtmd_req_id_ref;
        private MVC.DTO.FieldDecimal cad_mtmd_kit_id;
        private MVC.DTO.FieldString cad_mtmd_kit_dsc;
        private MVC.DTO.FieldString mtmd_ds_tipo_requisicao;
        private MVC.DTO.FieldDecimal cad_set_setor_farmacia;

        private MVC.DTO.FieldDateTime ras_data_hora_ini_vig;
        private MVC.DTO.FieldDateTime ras_data_hora_fim_vig;
        private MVC.DTO.FieldDecimal ras_hora_inicio_processo;
        private MVC.DTO.FieldDecimal ras_qtd_hrs_total_gerar;
        private MVC.DTO.FieldDecimal ras_qtd_hrs_periodo_gerar;
        private MVC.DTO.FieldDecimal ras_qtd_hrs_minima_iniciar;
        private MVC.DTO.FieldDecimal ras_fl_imediato_auto;
        private MVC.DTO.FieldDecimal ras_fl_req_total_imediato;
        private MVC.DTO.FieldDecimal ras_fl_req_nao_gerar;

        public RequisicaoDTO()
        {
            InitializeComponent();
        }

        internal void InitializeComponent()
        {
            this.mtmd_req_id = new MVC.DTO.FieldDecimal(FieldNames.Idt, Captions.Idt, DbType.Decimal);
            // this.nr_seqinter= new MVC.DTO.FieldDecimal(FieldNames.NrInternacaoLegado,Captions.NrInternacaoLegado, DbType.Decimal);
            this.mtmd_req_fl_status = new MVC.DTO.FieldDecimal(FieldNames.Status, Captions.Status, DbType.Decimal);
            this.mtmd_req_fl_urgencia = new MVC.DTO.FieldDecimal(FieldNames.Urgencia, Captions.Urgencia, DbType.Decimal);
            this.mtmd_req_dt_atualizacao = new MVC.DTO.FieldDateTime(FieldNames.DataAtualizacao, Captions.DataAtualizacao);

            this.cad_set_id = new MVC.DTO.FieldDecimal(FieldNames.IdtSetor, Captions.IdtSetor);
            this.cad_lat_id_local_atendimento = new MVC.DTO.FieldDecimal(FieldNames.IdtLocal, Captions.IdtLocal);
            this.cad_uni_id_unidade = new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade, Captions.IdtUnidade);

            this.cad_lat_ds_local_atendimento = new MVC.DTO.FieldString(FieldNames.DsLocal, Captions.DsLocal);
            this.cad_set_ds_setor = new MVC.DTO.FieldString(FieldNames.DsSetor, Captions.DsSetor);
            this.cad_uni_ds_unidade = new MVC.DTO.FieldString(FieldNames.DsUnidade, Captions.DsUnidade);

            this.IdtTipoRequisicao = new MVC.DTO.FieldDecimal(FieldNames.IdtTipoRequisicao, Captions.IdtTipoRequisicao);
            this.cad_mtmd_filial_id = new MVC.DTO.FieldDecimal(FieldNames.IdtFilial, Captions.IdtFilial, DbType.Decimal);
            this.seg_usu_id_usuario = new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario, Captions.IdtUsuario, DbType.Decimal);

            this.atd_ate_id = new MVC.DTO.FieldDecimal(FieldNames.IdtAtendimento, Captions.IdtAtendimento, DbType.Decimal);
            this.atd_ate_tp_paciente = new MVC.DTO.FieldString(FieldNames.TpAtendimento, Captions.TpAtendimento, 100);

            this.mtmd_id_usuario_requisicao = new MVC.DTO.FieldDecimal(FieldNames.Status, Captions.Status, DbType.Decimal);
            this.ds_usuario_requisicao = new MVC.DTO.FieldString(FieldNames.DsUsuarioRequisicao, Captions.DsUsuarioRequisicao);
            this.mtmd_data_requisicao = new MVC.DTO.FieldDateTime(FieldNames.DataRequisicao, Captions.DataRequisicao);
            this.mtmd_data_requisicao2 = new MVC.DTO.FieldDateTime(FieldNames.DataRequisicao2, Captions.DataRequisicao2);
            this.mtmd_id_usuario_dispensacao = new MVC.DTO.FieldDecimal(FieldNames.IdtUsuarioDispensacao, Captions.IdtUsuarioDispensacao, DbType.Decimal);
            this.ds_usuario_dispensacao = new MVC.DTO.FieldString(FieldNames.DsUsuarioDispensacao, Captions.DsUsuarioDispensacao, 100);
            this.mtmd_data_dispensacao = new MVC.DTO.FieldDateTime(FieldNames.DataDispensacao, Captions.DataDispensacao);

            this.mtmd_fl_pendente = new MVC.DTO.FieldDecimal(FieldNames.FlPendente, Captions.FlPendente);
            this.mtmd_req_id_ref = new MVC.DTO.FieldDecimal(FieldNames.IdtReqRef, Captions.IdtReqRef, DbType.Decimal);
            this.cad_mtmd_kit_id = new MVC.DTO.FieldDecimal(FieldNames.IdKit, Captions.IdKit, DbType.Decimal);
            this.cad_mtmd_kit_dsc = new MVC.DTO.FieldString(FieldNames.DescricaoKit, Captions.DescricaoKit, 100);
            this.mtmd_ds_tipo_requisicao = new MVC.DTO.FieldString(FieldNames.DsTipoRequisicao, Captions.DsTipoRequisicao, 100);
            this.cad_set_setor_farmacia = new MVC.DTO.FieldDecimal(FieldNames.SetorFarmacia, Captions.SetorFarmacia, DbType.Decimal);

            this.ras_data_hora_ini_vig = new MVC.DTO.FieldDateTime(FieldNames.SetorPedidoAutoDtHoraIniVigencia, Captions.SetorPedidoAutoDtHoraIniVigencia);
            this.ras_data_hora_fim_vig = new MVC.DTO.FieldDateTime(FieldNames.SetorPedidoAutoDtHoraFimVigencia, Captions.SetorPedidoAutoDtHoraFimVigencia);
            this.ras_hora_inicio_processo = new MVC.DTO.FieldDecimal(FieldNames.SetorPedidoAutoHoraInicioProcesso, Captions.SetorPedidoAutoHoraInicioProcesso);
            this.ras_qtd_hrs_total_gerar = new MVC.DTO.FieldDecimal(FieldNames.SetorPedidoAutoHorasTotaisGerar, Captions.SetorPedidoAutoHorasTotaisGerar);
            this.ras_qtd_hrs_periodo_gerar = new MVC.DTO.FieldDecimal(FieldNames.SetorPedidoAutoHorasPeriodoDose, Captions.SetorPedidoAutoHorasPeriodoDose);
            this.ras_qtd_hrs_minima_iniciar = new MVC.DTO.FieldDecimal(FieldNames.SetorPedidoAutoHorasMinimaIniciar, Captions.SetorPedidoAutoHorasMinimaIniciar);
            this.ras_fl_imediato_auto = new MVC.DTO.FieldDecimal(FieldNames.SetorPedidoAutoFlItensImediatos, Captions.SetorPedidoAutoFlItensImediatos);
            this.ras_fl_req_total_imediato = new MVC.DTO.FieldDecimal(FieldNames.SetorPedidoAutoFlTotalImediato, Captions.SetorPedidoAutoFlTotalImediato);
            this.ras_fl_req_nao_gerar = new MVC.DTO.FieldDecimal(FieldNames.SetorPedidoAutoFlNaoGerar, Captions.SetorPedidoAutoFlNaoGerar);
        }

        #region FieldNames

        public struct FieldNames
        {
            public const string Idt = "MTMD_REQ_ID";

            public const string Status = "MTMD_REQ_FL_STATUS";
            public const string Urgencia = "MTMD_REQ_FL_URGENCIA";
            public const string DataAtualizacao = "MTMD_REQ_DT_ATUALIZACAO";

            public const string IdtSetor = "CAD_SET_ID";
            public const string IdtLocal = "CAD_LAT_ID_LOCAL_ATENDIMENTO";
            public const string IdtUnidade = "CAD_UNI_ID_UNIDADE";

            public const string DsSetor = "CAD_SET_DS_SETOR";
            public const string DsUnidade = "CAD_UNI_DS_UNIDADE";
            public const string DsLocal = "CAD_LAT_DS_LOCAL_ATENDIMENTO";

            public const string IdtTipoRequisicao = "MTM_TIPO_REQUISICAO";
            public const string IdtFilial = "CAD_MTMD_FILIAL_ID";
            public const string IdtUsuario = "SEG_USU_ID_USUARIO";


            public const string IdtAtendimento = "ATD_ATE_ID";
            public const string TpAtendimento = "ATD_ATE_TP_PACIENTE";


            public const string DataRequisicao = "MTMD_DATA_REQUISICAO";
            public const string DataRequisicao2 = "MTMD_DATA_REQUISICAO2";
            public const string IdtUsuarioRequisicao = "MTMD_ID_USUARIO_REQUISICAO";
            public const string DsUsuarioRequisicao = "DS_USUARIO_REQUISICAO";
            public const string DataDispensacao = "MTMD_DATA_DISPENSACAO";
            public const string IdtUsuarioDispensacao = "MTMD_ID_USUARIO_DISPENSACAO";
            public const string DsUsuarioDispensacao = "DS_USUARIO_DISPENSACAO";

            public const string FlPendente = "MTMD_FL_PENDENTE";
            public const string IdtReqRef = "MTMD_REQ_ID_REF";
            public const string IdKit = "CAD_MTMD_KIT_ID";
            public const string DescricaoKit = "CAD_MTMD_KIT_DSC";
            public const string DsTipoRequisicao = "MTMD_DS_TIPO_REQUISICAO";
            public const string SetorFarmacia = "CAD_SET_SETOR_FARMACIA";

            public const string SetorPedidoAutoDtHoraIniVigencia = "RAS_DATA_HORA_INI_VIG";
            public const string SetorPedidoAutoDtHoraFimVigencia = "RAS_DATA_HORA_FIM_VIG";
            public const string SetorPedidoAutoHoraInicioProcesso = "RAS_HORA_INICIO_PROCESSO";
            public const string SetorPedidoAutoHorasTotaisGerar = "RAS_QTD_HRS_TOTAL_GERAR";
            public const string SetorPedidoAutoHorasPeriodoDose = "RAS_QTD_HRS_PERIODO_GERAR";
            public const string SetorPedidoAutoHorasMinimaIniciar = "RAS_QTD_HRS_MINIMA_INICIAR";
            public const string SetorPedidoAutoFlItensImediatos = "RAS_FL_IMEDIATO_AUTO";
            public const string SetorPedidoAutoFlTotalImediato = "RAS_FL_REQ_TOTAL_IMEDIATO";
            public const string SetorPedidoAutoFlNaoGerar = "RAS_FL_REQ_NAO_GERAR";
        }

        #endregion

        #region Captions
        public struct Captions
        {
            public const string Idt = "IDT";
            // public const string NrInternacaoLegado="NRINTERNACAOLEGADO";
            public const string Status = "STATUS";
            public const string Urgencia = "URGENCIA";
            public const string DataAtualizacao = "DATAATUALIZACAO";
            //
            public const string IdtSetor = "IdtSetor";
            public const string IdtLocal = "IdtLocal";
            public const string IdtUnidade = "IdtUnidade";
            public const string DsUnidade = "DSUNIDADE";
            public const string DsSetor = "DSSETOR";
            public const string DsLocal = "DSLOCAL";


            public const string IdtTipoRequisicao = "MTMTIPOREQUISICAO";
            public const string IdtFilial = "IDTFILIAL";
            public const string IdtUsuario = "IDTUSUARIO";

            public const string IdtAtendimento = "IDTATENDIMENTO";
            public const string TpAtendimento = "TPATENDIMENTO";

            public const string DataRequisicao = "DATAREQUISICAO";
            public const string DataRequisicao2 = "DATAREQUISICAO2";
            public const string IdtUsuarioRequisicao = "IDTUSUARIOREQUISICAO";
            public const string DsUsuarioRequisicao = "DSUSUARIOREQUISICAO";
            public const string DataDispensacao = "DATADISPENSACAO";
            public const string IdtUsuarioDispensacao = "IDTUSUARIODISPENSACAO";
            public const string DsUsuarioDispensacao = "DSUSUARIODISPENSACAO";
            public const string FlPendente = "FLPENDENTE";
            public const string IdtReqRef = "MTMDREQIDREF";
            public const string IdKit = "CADMTMDKITID";
            public const string DescricaoKit = "KIT_DSC";
            public const string DsTipoRequisicao = "DSTIPOREQUISICAO";
            public const string SetorFarmacia = "SETOR_FARMACIA";

            public const string SetorPedidoAutoDtHoraIniVigencia = "RAS_DATA_HORA_INI_VIG";
            public const string SetorPedidoAutoDtHoraFimVigencia = "RAS_DATA_HORA_FIM_VIG";
            public const string SetorPedidoAutoHoraInicioProcesso = "RAS_HORA_INICIO_PROCESSO";
            public const string SetorPedidoAutoHorasTotaisGerar = "RAS_QTD_HRS_TOTAL_GERAR";
            public const string SetorPedidoAutoHorasPeriodoDose = "RAS_QTD_HRS_PERIODO_GERAR";
            public const string SetorPedidoAutoHorasMinimaIniciar = "RAS_QTD_HRS_MINIMA_INICIAR";
            public const string SetorPedidoAutoFlItensImediatos = "RAS_FL_IMEDIATO_AUTO";
            public const string SetorPedidoAutoFlTotalImediato = "RAS_FL_REQ_TOTAL_IMEDIATO";
            public const string SetorPedidoAutoFlNaoGerar = "RAS_FL_REQ_NAO_GERAR";
        }

        #endregion

        #region Atributos Publicos

        public MVC.DTO.FieldDateTime SetorPedidoAutoDtHoraIniVigencia
        {
            get { return ras_data_hora_ini_vig; }
            set { ras_data_hora_ini_vig = value; }
        }

        public MVC.DTO.FieldDateTime SetorPedidoAutoDtHoraFimVigencia
        {
            get { return ras_data_hora_fim_vig; }
            set { ras_data_hora_fim_vig = value; }
        }

        public MVC.DTO.FieldDecimal SetorPedidoAutoHoraInicioProcesso
        {
            get { return ras_hora_inicio_processo; }
            set { ras_hora_inicio_processo = value; }
        }

        public MVC.DTO.FieldDecimal SetorPedidoAutoHorasTotaisGerar
        {
            get { return ras_qtd_hrs_total_gerar; }
            set { ras_qtd_hrs_total_gerar = value; }
        }

        public MVC.DTO.FieldDecimal SetorPedidoAutoHorasPeriodoDose
        {
            get { return ras_qtd_hrs_periodo_gerar; }
            set { ras_qtd_hrs_periodo_gerar = value; }
        }

        public MVC.DTO.FieldDecimal SetorPedidoAutoHorasMinimaIniciar
        {
            get { return ras_qtd_hrs_minima_iniciar; }
            set { ras_qtd_hrs_minima_iniciar = value; }
        }

        public MVC.DTO.FieldDecimal SetorPedidoAutoFlItensImediatos
        {
            get { return ras_fl_imediato_auto; }
            set { ras_fl_imediato_auto = value; }
        }

        public MVC.DTO.FieldDecimal SetorPedidoAutoFlTotalImediato
        {
            get { return ras_fl_req_total_imediato; }
            set { ras_fl_req_total_imediato = value; }
        }

        public MVC.DTO.FieldDecimal SetorPedidoAutoFlNaoGerar
        {
            get { return ras_fl_req_nao_gerar; }
            set { ras_fl_req_nao_gerar = value; }
        }

        public MVC.DTO.FieldDecimal IdtFilial
        {
            get { return cad_mtmd_filial_id; }
            set { cad_mtmd_filial_id = value; }
        }

        public MVC.DTO.FieldDecimal Idt
        {
            get { return mtmd_req_id; }
            set { mtmd_req_id = value; }
        }

        public MVC.DTO.FieldDecimal IdtReqRef
        {
            get { return mtmd_req_id_ref; }
            set { mtmd_req_id_ref = value; }
        }

        public MVC.DTO.FieldDecimal Status
        {
            get { return mtmd_req_fl_status; }
            set { mtmd_req_fl_status = value; }
        }

        public MVC.DTO.FieldDecimal Urgencia
        {
            get { return mtmd_req_fl_urgencia; }
            set { mtmd_req_fl_urgencia = value; }
        }

        public MVC.DTO.FieldDateTime DataAtualizacao
        {
            get { return mtmd_req_dt_atualizacao; }
            set { mtmd_req_dt_atualizacao = value; }
        }

        public MVC.DTO.FieldDecimal IdtSetor
        {
            get { return cad_set_id; }
            set { cad_set_id = value; }
        }

        public MVC.DTO.FieldString DsSetor
        {
            get { return cad_set_ds_setor; }
            set { cad_set_ds_setor = value; }
        }

        public MVC.DTO.FieldString DsLocal
        {
            get { return cad_lat_ds_local_atendimento; }
            set { cad_lat_ds_local_atendimento = value; }
        }

        public MVC.DTO.FieldString DsUnidade
        {
            get { return cad_uni_ds_unidade; }
            set { cad_uni_ds_unidade = value; }
        }

        public MVC.DTO.FieldDecimal IdtLocal
        {
            get { return cad_lat_id_local_atendimento; }
            set { cad_lat_id_local_atendimento = value; }
        }


        public MVC.DTO.FieldDecimal IdtUnidade
        {
            get { return cad_uni_id_unidade; }
            set { cad_uni_id_unidade = value; }
        }

        public MVC.DTO.FieldDecimal IdtTipoRequisicao
        {
            get { return mtm_tipo_requisicao; }
            set { mtm_tipo_requisicao = value; }
        }

        /// <summary>
        /// Id Usuário Logado
        /// </summary>
        public MVC.DTO.FieldDecimal IdtUsuario
        {
            get { return seg_usu_id_usuario; }
            set { seg_usu_id_usuario = value; }
        }

        /// <summary>
        /// Sequencia do Atendimento
        /// </summary>
        public MVC.DTO.FieldDecimal IdtAtendimento
        {
            get { return atd_ate_id; }
            set { atd_ate_id = value; }
        }

        /// <summary>
        /// Tipo de Atendimento: Ambulatorio/Internado/Urgência
        /// </summary>
        public MVC.DTO.FieldString TpAtendimento
        {
            get { return atd_ate_tp_paciente; }
            set { atd_ate_tp_paciente = value; }
        }

        /// <summary>
        /// Data em que a requisição foi enviada para o almoxarifado
        /// </summary>
        public MVC.DTO.FieldDateTime DataRequisicao
        {
            get { return mtmd_data_requisicao; }
            set { mtmd_data_requisicao = value; }
        }

        /// <summary>
        /// Data Fim p/ fazer filtro da pesquisa
        /// </summary>
        public MVC.DTO.FieldDateTime DataRequisicao2
        {
            get { return mtmd_data_requisicao2; }
            set { mtmd_data_requisicao2 = value; }
        }

        /// <summary>
        /// Id do Usuário que realizou o fechamento da requisição
        /// </summary>
        public MVC.DTO.FieldDecimal IdtUsuarioRequisicao
        {
            get { return mtmd_id_usuario_requisicao; }
            set { mtmd_id_usuario_requisicao = value; }
        }

        /// <summary>
        /// Data em que a requisição foi dispensada pelo almoxarifado
        /// </summary>
        public MVC.DTO.FieldDateTime DataDispensacao
        {
            get { return mtmd_data_dispensacao; }
            set { mtmd_data_dispensacao = value; }
        }

        /// <summary>
        /// Id do usuário que realizou a dispensação
        /// </summary>
        public MVC.DTO.FieldDecimal IdtUsuarioDispensacao
        {
            get { return mtmd_id_usuario_dispensacao; }
            set { mtmd_id_usuario_dispensacao = value; }
        }

        public MVC.DTO.FieldString DsUsuarioRequisicao
        {
            get { return ds_usuario_requisicao; }
            set { ds_usuario_requisicao = value; }
        }

        public MVC.DTO.FieldString DsUsuarioDispensacao
        {
            get { return ds_usuario_dispensacao; }
            set { ds_usuario_dispensacao = value; }
        }

        /// <summary>
        /// Indica se a Requisição é de itens pendentes
        /// </summary>
        public MVC.DTO.FieldDecimal FlPendente
        {
            get { return mtmd_fl_pendente; }
            set { mtmd_fl_pendente = value; }
        }

        public MVC.DTO.FieldDecimal IdKit
        {
            get { return cad_mtmd_kit_id; }
            set { cad_mtmd_kit_id = value; }
        }

        public MVC.DTO.FieldString DescricaoKit
        {
            get { return cad_mtmd_kit_dsc; }
            set { cad_mtmd_kit_dsc = value; }
        }

        public MVC.DTO.FieldString DsTipoRequisicao
        {
            get { return mtmd_ds_tipo_requisicao; }
            set { mtmd_ds_tipo_requisicao = value; }
        }

        public MVC.DTO.FieldDecimal SetorFarmacia
        {
            get { return cad_set_setor_farmacia; }
            set { cad_set_setor_farmacia = value; }
        }

        #endregion

        #region Operators

        public static explicit operator RequisicaoDTO(DataRow row)
        {
            RequisicaoDTO dto = new RequisicaoDTO();

            dto.SetorPedidoAutoDtHoraIniVigencia.Value = row[FieldNames.SetorPedidoAutoDtHoraIniVigencia].ToString();
            dto.SetorPedidoAutoDtHoraFimVigencia.Value = row[FieldNames.SetorPedidoAutoDtHoraFimVigencia].ToString();
            dto.SetorPedidoAutoHoraInicioProcesso.Value = row[FieldNames.SetorPedidoAutoHoraInicioProcesso].ToString();
            dto.SetorPedidoAutoHorasTotaisGerar.Value = row[FieldNames.SetorPedidoAutoHorasTotaisGerar].ToString();
            dto.SetorPedidoAutoHorasPeriodoDose.Value = row[FieldNames.SetorPedidoAutoHorasPeriodoDose].ToString();
            dto.SetorPedidoAutoHorasMinimaIniciar.Value = row[FieldNames.SetorPedidoAutoHorasMinimaIniciar].ToString();
            dto.SetorPedidoAutoFlItensImediatos.Value = row[FieldNames.SetorPedidoAutoFlItensImediatos].ToString();
            dto.SetorPedidoAutoFlTotalImediato.Value = row[FieldNames.SetorPedidoAutoFlTotalImediato].ToString();
            dto.SetorPedidoAutoFlNaoGerar.Value = row[FieldNames.SetorPedidoAutoFlNaoGerar].ToString();

            dto.Idt.Value = row[FieldNames.Idt].ToString();

            dto.Status.Value = row[FieldNames.Status].ToString();

            dto.Urgencia.Value = row[FieldNames.Urgencia].ToString();

            dto.DataAtualizacao.Value = row[FieldNames.DataAtualizacao].ToString();

            dto.IdtSetor.Value = row[FieldNames.IdtSetor].ToString();

            dto.IdtLocal.Value = row[FieldNames.IdtLocal].ToString();

            dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();

            dto.DsLocal.Value = row[FieldNames.DsLocal].ToString();

            dto.DsSetor.Value = row[FieldNames.DsSetor].ToString();

            dto.DsUnidade.Value = row[FieldNames.DsUnidade].ToString();

            dto.IdtTipoRequisicao.Value = row[FieldNames.IdtTipoRequisicao].ToString();

            dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();

            dto.IdtFilial.Value = row[FieldNames.IdtFilial].ToString();

            dto.IdtAtendimento.Value = row[FieldNames.IdtAtendimento].ToString();

            dto.TpAtendimento.Value = row[FieldNames.TpAtendimento].ToString();

            dto.DataRequisicao.Value = row[FieldNames.DataRequisicao].ToString();

            dto.DataRequisicao2.Value = row[FieldNames.DataRequisicao2].ToString();

            dto.IdtUsuarioRequisicao.Value = row[FieldNames.IdtUsuarioRequisicao].ToString();

            dto.DataDispensacao.Value = row[FieldNames.DataDispensacao].ToString();

            dto.IdtUsuarioDispensacao.Value = row[FieldNames.IdtUsuarioDispensacao].ToString();

            dto.DsUsuarioRequisicao.Value = row[FieldNames.DsUsuarioRequisicao].ToString();

            dto.DsUsuarioDispensacao.Value = row[FieldNames.DsUsuarioDispensacao].ToString();

            dto.FlPendente.Value = row[FieldNames.FlPendente].ToString();

            dto.IdtReqRef.Value = row[FieldNames.IdtReqRef].ToString();

            dto.IdKit.Value = row[FieldNames.IdKit].ToString();

            dto.DescricaoKit.Value = row[FieldNames.DescricaoKit].ToString();

            dto.DsTipoRequisicao.Value = row[FieldNames.DsTipoRequisicao].ToString();

            dto.SetorFarmacia.Value = row[FieldNames.SetorFarmacia].ToString();

            return dto;
        }

        public static explicit operator RequisicaoDTO(XmlDocument xml)
        {
            RequisicaoDTO dto = new RequisicaoDTO();

            if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtReqRef) != null) dto.IdtReqRef.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtReqRef).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Status) != null) dto.Status.Value = xml.FirstChild.SelectSingleNode(FieldNames.Status).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizacao) != null) dto.DataAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizacao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor) != null) dto.IdtSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal) != null) dto.IdtLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal).InnerText;


            if (xml.FirstChild.SelectSingleNode(FieldNames.DsLocal) != null) dto.DsLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsLocal).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsSetor) != null) dto.DsSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsSetor).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade) != null) dto.DsUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtTipoRequisicao) != null) dto.IdtTipoRequisicao.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtTipoRequisicao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial) != null) dto.IdtFilial.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtAtendimento) != null) dto.IdtAtendimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtAtendimento).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.TpAtendimento) != null) dto.TpAtendimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.TpAtendimento).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DataRequisicao) != null) dto.DataRequisicao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataRequisicao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DataRequisicao2) != null) dto.DataRequisicao2.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataRequisicao2).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioRequisicao) != null) dto.IdtUsuarioRequisicao.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioRequisicao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DataDispensacao) != null) dto.DataDispensacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataDispensacao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioDispensacao) != null) dto.IdtUsuarioDispensacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioDispensacao).InnerText;


            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUsuarioRequisicao) != null) dto.DsUsuarioRequisicao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUsuarioRequisicao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUsuarioDispensacao) != null) dto.DsUsuarioDispensacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUsuarioDispensacao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.FlPendente) != null) dto.FlPendente.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlPendente).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsTipoRequisicao) != null) dto.DsTipoRequisicao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsTipoRequisicao).InnerText;


            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);

            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);

            // XmlNode nodeNrInternacaoLegado = xml.CreateNode(XmlNodeType.Element, FieldNames.NrInternacaoLegado, null);

            XmlNode nodeStatus = xml.CreateNode(XmlNodeType.Element, FieldNames.Status, null);

            XmlNode nodeDataAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DataAtualizacao, null);

            XmlNode nodeIdtSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetor, null);

            XmlNode nodeIdtLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocal, null);

            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);

            XmlNode nodeDsLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.DsLocal, null);

            XmlNode nodeDsSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.DsSetor, null);

            XmlNode nodeDsUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidade, null);

            XmlNode nodeIdtTipoRequisicao = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtTipoRequisicao, null);

            XmlNode nodeIdtUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);

            XmlNode nodeIdtFilial = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFilial, null);

            XmlNode nodeIdtAtendimento = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtAtendimento, null);

            XmlNode nodeTpAtendimento = xml.CreateNode(XmlNodeType.Element, FieldNames.TpAtendimento, null);

            XmlNode nodeDataRequisicao = xml.CreateNode(XmlNodeType.Element, FieldNames.DataRequisicao, null);
            XmlNode nodeDataRequisicao2 = xml.CreateNode(XmlNodeType.Element, FieldNames.DataRequisicao2, null);

            XmlNode nodeIdtUsuarioRequisicao = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuarioRequisicao, null);

            XmlNode nodeDataDispensacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DataDispensacao, null);

            XmlNode nodeIdtUsuarioDispensacao = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuarioDispensacao, null);

            XmlNode nodeDsUsuarioRequisicao = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUsuarioRequisicao, null);

            XmlNode nodeDsUsuarioDispensacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUsuarioDispensacao, null);

            XmlNode nodeFlPendente = xml.CreateNode(XmlNodeType.Element, FieldNames.FlPendente, null);

            XmlNode nodeIdtReqRef = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtReqRef, null);

            XmlNode nodeDsTipoRequisicao = xml.CreateNode(XmlNodeType.Element, FieldNames.DsTipoRequisicao, null);

            if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;

            if (!this.Status.Value.IsNull) nodeStatus.InnerText = this.Status.Value;

            if (!this.DataAtualizacao.Value.IsNull) nodeDataAtualizacao.InnerText = this.DataAtualizacao.Value;

            if (!this.IdtSetor.Value.IsNull) nodeIdtSetor.InnerText = this.IdtSetor.Value;

            if (!this.IdtLocal.Value.IsNull) nodeIdtLocal.InnerText = this.IdtLocal.Value;

            if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;

            if (!this.DsLocal.Value.IsNull) nodeDsLocal.InnerText = this.DsLocal.Value;

            if (!this.DsUnidade.Value.IsNull) nodeDsUnidade.InnerText = this.DsUnidade.Value;

            if (!this.DsSetor.Value.IsNull) nodeDsSetor.InnerText = this.DsSetor.Value;

            if (!this.IdtTipoRequisicao.Value.IsNull) nodeIdtTipoRequisicao.InnerText = this.IdtTipoRequisicao.Value;

            if (!this.IdtUsuario.Value.IsNull) nodeIdtUsuario.InnerText = this.IdtUsuario.Value;

            if (!this.IdtFilial.Value.IsNull) nodeIdtFilial.InnerText = this.IdtFilial.Value;

            if (!this.IdtAtendimento.Value.IsNull) nodeIdtAtendimento.InnerText = this.IdtAtendimento.Value;

            if (!this.TpAtendimento.Value.IsNull) nodeTpAtendimento.InnerText = this.TpAtendimento.Value;

            if (!this.DataRequisicao.Value.IsNull) nodeDataRequisicao.InnerText = this.DataRequisicao.Value;
            if (!this.DataRequisicao2.Value.IsNull) nodeDataRequisicao2.InnerText = this.DataRequisicao2.Value;
            if (!this.IdtUsuarioRequisicao.Value.IsNull) nodeIdtUsuarioRequisicao.InnerText = this.IdtUsuarioRequisicao.Value;

            if (!this.DataDispensacao.Value.IsNull) nodeDataDispensacao.InnerText = this.DataDispensacao.Value;

            if (!this.IdtUsuarioDispensacao.Value.IsNull) nodeIdtUsuarioDispensacao.InnerText = this.IdtUsuarioDispensacao.Value;

            if (!this.DsUsuarioRequisicao.Value.IsNull) nodeDsUsuarioRequisicao.InnerText = this.DsUsuarioRequisicao.Value;

            if (!this.DsUsuarioDispensacao.Value.IsNull) nodeDsUsuarioDispensacao.InnerText = this.DsUsuarioDispensacao.Value;

            if (!this.FlPendente.Value.IsNull) nodeFlPendente.InnerText = this.FlPendente.Value;

            if (!this.IdtReqRef.Value.IsNull) nodeIdtReqRef.InnerText = this.IdtReqRef.Value;

            if (!this.DsTipoRequisicao.Value.IsNull) nodeDsTipoRequisicao.InnerText = this.DsTipoRequisicao.Value;


            nodeData.AppendChild(nodeIdt);

            nodeData.AppendChild(nodeIdtReqRef);

            nodeData.AppendChild(nodeStatus);

            nodeData.AppendChild(nodeDataAtualizacao);

            nodeData.AppendChild(nodeIdtSetor);

            nodeData.AppendChild(nodeIdtLocal);

            nodeData.AppendChild(nodeIdtUnidade);

            nodeData.AppendChild(nodeDsLocal);

            nodeData.AppendChild(nodeDsUnidade);

            nodeData.AppendChild(nodeDsSetor);

            nodeData.AppendChild(nodeIdtTipoRequisicao);

            nodeData.AppendChild(nodeIdtUsuario);

            nodeData.AppendChild(nodeIdtFilial);

            nodeData.AppendChild(nodeIdtAtendimento);

            nodeData.AppendChild(nodeTpAtendimento);

            nodeData.AppendChild(nodeDataRequisicao);
            nodeData.AppendChild(nodeDataRequisicao2);
            nodeData.AppendChild(nodeIdtUsuarioRequisicao);

            nodeData.AppendChild(nodeDataDispensacao);

            nodeData.AppendChild(nodeIdtUsuarioDispensacao);

            nodeData.AppendChild(nodeDsUsuarioRequisicao);

            nodeData.AppendChild(nodeDsUsuarioDispensacao);

            nodeData.AppendChild(nodeFlPendente);

            nodeData.AppendChild(nodeDsTipoRequisicao);

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(RequisicaoDTO dto)
        {
            RequisicaoDataTable dtb = new RequisicaoDataTable();
            DataRow dtr = dtb.NewRow();

            dtr[FieldNames.SetorPedidoAutoDtHoraIniVigencia] = dto.SetorPedidoAutoDtHoraIniVigencia.Value;
            dtr[FieldNames.SetorPedidoAutoDtHoraFimVigencia] = dto.SetorPedidoAutoDtHoraFimVigencia.Value;
            dtr[FieldNames.SetorPedidoAutoHoraInicioProcesso] = dto.SetorPedidoAutoHoraInicioProcesso.Value;
            dtr[FieldNames.SetorPedidoAutoHorasTotaisGerar] = dto.SetorPedidoAutoHorasTotaisGerar.Value;
            dtr[FieldNames.SetorPedidoAutoHorasPeriodoDose] = dto.SetorPedidoAutoHorasPeriodoDose.Value;
            dtr[FieldNames.SetorPedidoAutoHorasMinimaIniciar] = dto.SetorPedidoAutoHorasMinimaIniciar.Value;
            dtr[FieldNames.SetorPedidoAutoFlItensImediatos] = dto.SetorPedidoAutoFlItensImediatos.Value;
            dtr[FieldNames.SetorPedidoAutoFlTotalImediato] = dto.SetorPedidoAutoFlTotalImediato.Value;
            dtr[FieldNames.SetorPedidoAutoFlNaoGerar] = dto.SetorPedidoAutoFlNaoGerar.Value;

            dtr[FieldNames.Idt] = dto.Idt.Value;

            dtr[FieldNames.Status] = dto.Status.Value;

            dtr[FieldNames.Urgencia] = dto.Urgencia.Value;

            dtr[FieldNames.IdtSetor] = dto.IdtSetor.Value;

            dtr[FieldNames.IdtLocal] = dto.IdtLocal.Value;

            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;

            dtr[FieldNames.DsSetor] = dto.DsSetor.Value;

            dtr[FieldNames.DsUnidade] = dto.DsUnidade.Value;

            dtr[FieldNames.DsLocal] = dto.DsLocal.Value;

            dtr[FieldNames.IdtTipoRequisicao] = dto.IdtTipoRequisicao.Value;

            dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;

            dtr[FieldNames.IdtFilial] = dto.IdtFilial.Value;

            dtr[FieldNames.IdtAtendimento] = dto.IdtAtendimento.Value;

            dtr[FieldNames.TpAtendimento] = dto.TpAtendimento.Value;

            dtr[FieldNames.DataRequisicao] = dto.DataRequisicao.Value;
            dtr[FieldNames.DataRequisicao2] = dto.DataRequisicao2.Value;
            dtr[FieldNames.IdtUsuarioRequisicao] = dto.IdtUsuarioRequisicao.Value;

            dtr[FieldNames.DataDispensacao] = dto.DataDispensacao.Value;

            dtr[FieldNames.IdtUsuarioDispensacao] = dto.IdtUsuarioDispensacao.Value;

            dtr[FieldNames.DsUsuarioRequisicao] = dto.DsUsuarioRequisicao.Value;

            dtr[FieldNames.DsUsuarioDispensacao] = dto.DsUsuarioDispensacao.Value;

            dtr[FieldNames.FlPendente] = dto.FlPendente.Value;

            dtr[FieldNames.IdtReqRef] = dto.IdtReqRef.Value;

            dtr[FieldNames.IdKit] = dto.IdKit.Value;

            dtr[FieldNames.DescricaoKit] = dto.DescricaoKit.Value;

            dtr[FieldNames.DsTipoRequisicao] = dto.DsTipoRequisicao.Value;

            dtr[FieldNames.SetorFarmacia] = dto.SetorFarmacia.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(RequisicaoDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}