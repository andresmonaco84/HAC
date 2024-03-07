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
    /// Classe Entidade InternacaoLegadoDataTable
    /// </summary>
    [Serializable()]
    public class PacienteDataTable : DataTable
    {

        public PacienteDataTable()
            : base()
        {
            this.TableName = "DADOS";
            // ATENDIMENTO
            this.Columns.Add(PacienteDTO.FieldNames.Idt, typeof(Decimal));
            this.Columns.Add(PacienteDTO.FieldNames.TpAtendimento, typeof(String));
            this.Columns.Add(PacienteDTO.FieldNames.CdQuarto, typeof(Decimal));
            this.Columns.Add(PacienteDTO.FieldNames.CdLeito, typeof(Decimal));
            this.Columns.Add(PacienteDTO.FieldNames.DtAtendimento, typeof(DateTime));
            this.Columns.Add(PacienteDTO.FieldNames.DataAtendimento, typeof(DateTime));

            //PACIENTE
            this.Columns.Add(PacienteDTO.FieldNames.NmPaciente, typeof(String));
            this.Columns.Add(PacienteDTO.FieldNames.NmSocial, typeof(String));
            this.Columns.Add(PacienteDTO.FieldNames.DtNascimento, typeof(DateTime));
            this.Columns.Add(PacienteDTO.FieldNames.NmMae, typeof(String));
            this.Columns.Add(PacienteDTO.FieldNames.Credencial, typeof(String));

            //CONVENIO
            this.Columns.Add(PacienteDTO.FieldNames.IdtConvenio, typeof(String));
            this.Columns.Add(PacienteDTO.FieldNames.CdEmpresa, typeof(String));
            this.Columns.Add(PacienteDTO.FieldNames.DsEmpresa, typeof(String));
            //PLANO
            this.Columns.Add(PacienteDTO.FieldNames.IdtPlano, typeof(Decimal));
            this.Columns.Add(PacienteDTO.FieldNames.NmPlano, typeof(String));
            this.Columns.Add(PacienteDTO.FieldNames.TpPlano, typeof(String));
            this.Columns.Add(PacienteDTO.FieldNames.CdPlano, typeof(String));


            // Setores
            this.Columns.Add(PacienteDTO.FieldNames.IdtSetor, typeof(Decimal));
            this.Columns.Add(PacienteDTO.FieldNames.IdtLocalAtendimento, typeof(Decimal));
            this.Columns.Add(PacienteDTO.FieldNames.IdtUnidade, typeof(Decimal));
            this.Columns.Add(PacienteDTO.FieldNames.DsSetor, typeof(String));
            this.Columns.Add(PacienteDTO.FieldNames.DsLocal, typeof(String));
            this.Columns.Add(PacienteDTO.FieldNames.DsUnidade, typeof(String));

            this.Columns.Add(PacienteDTO.FieldNames.DtTransf, typeof(DateTime));
            this.Columns.Add(PacienteDTO.FieldNames.HrTransf, typeof(Decimal));

            this.Columns.Add(PacienteDTO.FieldNames.DtAlta, typeof(DateTime));

            this.Columns.Add(PacienteDTO.FieldNames.ContaFaturada, typeof(Decimal));



            // DataColumn[] primaryKey = { this.Columns[AtendimentoDTO.FieldNames.Idt] };

            // this.PrimaryKey = primaryKey;
        }

        protected PacienteDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }

        public PacienteDTO TypedRow(int index)
        {
            return (PacienteDTO)this.Rows[index];
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

        public void Add(PacienteDTO dto)
        {
            DataRow dtr = this.NewRow();
            // ATENDIMENTO
            if (!dto.Idt.Value.IsNull) dtr[PacienteDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
            if (!dto.TpAtendimento.Value.IsNull) dtr[PacienteDTO.FieldNames.TpAtendimento] = (String)dto.TpAtendimento.Value;
            if (!dto.CdQuarto.Value.IsNull) dtr[PacienteDTO.FieldNames.CdQuarto] = (Decimal)dto.CdQuarto.Value;
            if (!dto.DtAtendimento.Value.IsNull) dtr[PacienteDTO.FieldNames.DtAtendimento] = (DateTime)dto.DtAtendimento.Value;
            if (!dto.DataAtendimento.Value.IsNull) dtr[PacienteDTO.FieldNames.DataAtendimento] = (DateTime)dto.DataAtendimento.Value;

            //PACIENTE
            if (!dto.NmPaciente.Value.IsNull) dtr[PacienteDTO.FieldNames.NmPaciente] = (String)dto.NmPaciente.Value;
            if (!dto.NmSocial.Value.IsNull) dtr[PacienteDTO.FieldNames.NmSocial] = (String)dto.NmSocial.Value;
            if (!dto.DtNascimento.Value.IsNull) dtr[PacienteDTO.FieldNames.DtNascimento] = (DateTime)dto.DtNascimento.Value;
            if (!dto.NmMae.Value.IsNull) dtr[PacienteDTO.FieldNames.NmMae] = (String)dto.NmMae.Value;
            if (!dto.Credencial.Value.IsNull) dtr[PacienteDTO.FieldNames.Credencial] = (String)dto.Credencial.Value;

            //CONVENIO
            if (!dto.IdtConvenio.Value.IsNull) dtr[PacienteDTO.FieldNames.IdtConvenio] = (String)dto.IdtConvenio.Value;
            if (!dto.DsEmpresa.Value.IsNull) dtr[PacienteDTO.FieldNames.DsEmpresa] = (String)dto.DsEmpresa.Value;
            if (!dto.CdEmpresa.Value.IsNull) dtr[PacienteDTO.FieldNames.CdEmpresa] = (String)dto.CdEmpresa.Value;


            //PLANO
            if (!dto.IdtPlano.Value.IsNull) dtr[PacienteDTO.FieldNames.IdtPlano] = (Decimal)dto.IdtPlano.Value;
            if (!dto.TpPlano.Value.IsNull) dtr[PacienteDTO.FieldNames.TpPlano] = (String)dto.TpPlano.Value;
            if (!dto.NmPlano.Value.IsNull) dtr[PacienteDTO.FieldNames.NmPlano] = (String)dto.NmPlano.Value;
            if (!dto.CdPlano.Value.IsNull) dtr[PacienteDTO.FieldNames.CdPlano] = (String)dto.CdPlano.Value;


            // Setores
            if (!dto.IdtSetor.Value.IsNull) dtr[PacienteDTO.FieldNames.IdtSetor] = (Decimal)dto.IdtSetor.Value;
            if (!dto.IdtLocalAtendimento.Value.IsNull) dtr[PacienteDTO.FieldNames.IdtLocalAtendimento] = (Decimal)dto.IdtLocalAtendimento.Value;
            if (!dto.IdtUnidade.Value.IsNull) dtr[PacienteDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;
            if (!dto.DsSetor.Value.IsNull) dtr[PacienteDTO.FieldNames.DsSetor] = (String)dto.DsSetor.Value;
            if (!dto.DsLocal.Value.IsNull) dtr[PacienteDTO.FieldNames.DsLocal] = (String)dto.DsLocal.Value;
            if (!dto.DsUnidade.Value.IsNull) dtr[PacienteDTO.FieldNames.DsUnidade] = (String)dto.DsUnidade.Value;


            if (!dto.DtTransf.Value.IsNull) dtr[PacienteDTO.FieldNames.DtTransf] = (DateTime)dto.DtTransf.Value;
            if (!dto.HrTransf.Value.IsNull) dtr[PacienteDTO.FieldNames.HrTransf] = (Decimal)dto.HrTransf.Value;

            if (!dto.DtAlta.Value.IsNull) dtr[PacienteDTO.FieldNames.DtAlta] = (DateTime)dto.DtTransf.Value;

            if (!dto.ContaFaturada.Value.IsNull) dtr[PacienteDTO.FieldNames.ContaFaturada] = (Decimal)dto.ContaFaturada.Value;


            this.Rows.Add(dtr);
        }
    }

    [Serializable()]
    public class PacienteDTO : MVC.DTO.DTOBase
    {
        public struct TipoAtendimentoSGS
        {
            public const string AMBULATORIO = "A";
            public const string INTERNADO = "I";
            public const string URGENCIA = "U";
        }

        public enum TipoAtendimento
        {
            AMBULATORIO = 65,
            INTERNADO = 73,
            URGENCIA = 85
        }

        public enum LocalAtendimento
        {
            AMBULATORIO = 27,
            CONSULTORIO = 28,
            INTERNADO = 29,
            PRONTO_SOCORRO = 30,
            ALMOXARIFADO = 31,
            CENTRO_CIRURGICO = 32,
            ATENDIMENTO_DOMICILIAR = 46
        }

        public enum Faturada
        {
            NAO = 0,
            SIM = 1
        }

        private MVC.DTO.FieldDecimal atd_ate_id;
        private MVC.DTO.FieldString atd_ate_tp_paciente;
        private MVC.DTO.FieldDecimal cod_quarto;
        private MVC.DTO.FieldDecimal cod_leito;
        private MVC.DTO.FieldDateTime atd_ate_dt_atendimento;
        private MVC.DTO.FieldDateTime atd_dt_atendimento;

        //PACIENTE
        private MVC.DTO.FieldString cad_pes_nm_pessoa;
        private MVC.DTO.FieldString cad_pes_nm_razaosocial;
        private MVC.DTO.FieldDateTime cad_pes_dt_nascimento;
        private MVC.DTO.FieldString cad_pac_cd_credencial;
        private MVC.DTO.FieldString cad_pes_nm_nomemae;

        //CONVENIO
        private MVC.DTO.FieldDecimal cad_cnv_id_convenio;
        private MVC.DTO.FieldString cad_cnv_nm_convenio;
        private MVC.DTO.FieldString cad_cnv_cd_hac_prestador;

        //PLANO
        private MVC.DTO.FieldDecimal cad_pla_id_plano;
        private MVC.DTO.FieldString cad_pla_cd_tipoplano;
        private MVC.DTO.FieldString cad_pla_nm_nome_plano;
        private MVC.DTO.FieldString cad_pla_cd_plano;

        // Setores
        private MVC.DTO.FieldDecimal cad_set_id;
        private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
        private MVC.DTO.FieldDecimal cad_uni_id_unidade;
        private MVC.DTO.FieldString cad_set_ds_setor;
        private MVC.DTO.FieldString cad_lat_ds_local_atendimento;
        private MVC.DTO.FieldString cad_uni_ds_unidade;

        private MVC.DTO.FieldDateTime dt_transf;
        private MVC.DTO.FieldDecimal hr_transf;

        private MVC.DTO.FieldDateTime dt_alta;

        private MVC.DTO.FieldDecimal conta_faturada;




        public PacienteDTO()
        {
            InitializeComponent();
        }

        internal void InitializeComponent()
        {
            this.atd_ate_id = new MVC.DTO.FieldDecimal(FieldNames.Idt, Captions.Idt, DbType.Decimal);
            this.atd_ate_tp_paciente = new MVC.DTO.FieldString(FieldNames.TpAtendimento, Captions.TpAtendimento, 2);
            this.cod_quarto = new MVC.DTO.FieldDecimal(FieldNames.CdQuarto, Captions.CdQuarto, DbType.Decimal);
            this.cod_leito = new MVC.DTO.FieldDecimal(FieldNames.CdLeito, Captions.CdLeito, DbType.Decimal);
            this.atd_ate_dt_atendimento = new MVC.DTO.FieldDateTime(FieldNames.DtAtendimento, Captions.DtAtendimento);
            this.atd_dt_atendimento = new MVC.DTO.FieldDateTime(FieldNames.DataAtendimento, Captions.DataAtendimento);

            //PACIENTE
            this.cad_pes_nm_pessoa = new MVC.DTO.FieldString(FieldNames.NmPaciente, Captions.NmPaciente, 100);
            this.cad_pes_nm_razaosocial = new MVC.DTO.FieldString(FieldNames.NmSocial, Captions.NmSocial, 100);
            this.cad_pes_dt_nascimento = new MVC.DTO.FieldDateTime(FieldNames.DtNascimento, Captions.DtNascimento);
            this.cad_pac_cd_credencial = new MVC.DTO.FieldString(FieldNames.Credencial, Captions.Credencial, 20);
            this.cad_pes_nm_nomemae = new MVC.DTO.FieldString(FieldNames.NmMae, Captions.NmMae, 100);

            //CONVENIO
            this.cad_cnv_id_convenio = new MVC.DTO.FieldDecimal(FieldNames.IdtConvenio, Captions.IdtConvenio, DbType.Decimal);
            this.cad_cnv_nm_convenio = new MVC.DTO.FieldString(FieldNames.DsEmpresa, Captions.DsEmpresa, 53);
            this.cad_cnv_cd_hac_prestador = new MVC.DTO.FieldString(FieldNames.CdEmpresa, Captions.CdEmpresa, 53);


            //PLANO
            this.cad_pla_id_plano = new MVC.DTO.FieldDecimal(FieldNames.IdtPlano, Captions.IdtPlano, DbType.Decimal);
            this.cad_pla_nm_nome_plano = new MVC.DTO.FieldString(FieldNames.NmPlano, Captions.NmPlano, 4);
            this.cad_pla_cd_tipoplano = new MVC.DTO.FieldString(FieldNames.TpPlano, Captions.TpPlano, 100);
            this.cad_pla_cd_plano = new MVC.DTO.FieldString(FieldNames.CdPlano, Captions.CdPlano, 5);


            // Setores
            this.cad_set_id = new MVC.DTO.FieldDecimal(FieldNames.IdtSetor, Captions.IdtSetor, DbType.Decimal);
            this.cad_lat_id_local_atendimento = new MVC.DTO.FieldDecimal(FieldNames.IdtLocalAtendimento, Captions.IdtLocalAtendimento, DbType.Decimal);
            this.cad_uni_id_unidade = new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade, Captions.IdtUnidade, DbType.Decimal);
            this.cad_lat_ds_local_atendimento = new MVC.DTO.FieldString(FieldNames.DsLocal, Captions.DsLocal);
            this.cad_set_ds_setor = new MVC.DTO.FieldString(FieldNames.DsSetor, Captions.DsSetor);
            this.cad_uni_ds_unidade = new MVC.DTO.FieldString(FieldNames.DsUnidade, Captions.DsUnidade);


            this.dt_transf = new MVC.DTO.FieldDateTime(FieldNames.DtTransf, Captions.DtTransf);
            this.hr_transf = new MVC.DTO.FieldDecimal(FieldNames.HrTransf, Captions.HrTransf, DbType.Decimal);

            this.dt_alta = new MVC.DTO.FieldDateTime(FieldNames.DtAlta, Captions.DtAlta);

            this.conta_faturada = new MVC.DTO.FieldDecimal(FieldNames.ContaFaturada, Captions.ContaFaturada, DbType.Decimal);

        }

        #region FieldNames

        public struct FieldNames
        {
            public const string Idt = "ATD_ATE_ID";
            public const string TpAtendimento = "ATD_ATE_TP_PACIENTE";
            public const string CdQuarto = "COD_QUARTO";
            public const string CdLeito = "COD_LEITO";
            public const string DtAtendimento = "ATD_ATE_DT_ATENDIMENTO";
            public const string DataAtendimento = "DT_INT";
            
            //PACIENTE
            public const string DtNascimento = "CAD_PES_DT_NASCIMENTO";
            public const string NmPaciente = "CAD_PES_NM_PESSOA";
            public const string NmSocial = "CAD_PES_NM_RAZAOSOCIAL";
            public const string NmMae = "CAD_PES_NM_NOMEMAE";
            public const string Credencial = "CAD_PAC_CD_CREDENCIAL";

            //CONVENIO
            public const string IdtConvenio = "CAD_CNV_ID_CONVENIO";
            public const string DsEmpresa = "CAD_CNV_NM_CONVENIO";
            public const string CdEmpresa = "CAD_CNV_CD_HAC_PRESTADOR";

            //PLANO
            public const string IdtPlano = "CAD_PLA_ID_PLANO";
            public const string TpPlano = "CAD_PLA_CD_TIPOPLANO";
            public const string NmPlano = "CAD_PLA_NM_NOME_PLANO";
            public const string CdPlano = "CAD_PLA_CD_PLANO";

            //Setores
            public const string IdtSetor = "CAD_SET_ID";
            public const string IdtLocalAtendimento = "CAD_LAT_ID_LOCAL_ATENDIMENTO";
            public const string IdtUnidade = "CAD_UNI_ID_UNIDADE";
            public const string DsSetor = "CAD_SET_DS_SETOR";
            public const string DsUnidade = "CAD_UNI_DS_UNIDADE";
            public const string DsLocal = "CAD_LAT_DS_LOCAL_ATENDIMENTO";

            public const string DtTransf = "DT_TRANSF";
            public const string HrTransf = "HR_TRANSF";

            public const string DtAlta = "DT_ALTA";

            public const string ContaFaturada = "CONTA_FATURADA";
        }

        #endregion

        #region Captions
        public struct Captions
        {

            public const string Idt = "IDT";
            public const string TpAtendimento = "TPATENDIMENTO";
            public const string NmPaciente = "NOMEPACIENTE";
            public const string NmSocial = "NMSOCIAL";
            public const string DsEmpresa = "DsEmpresa";
            public const string IdtConvenio = "CdConvenio";
            public const string CdQuarto = "CdQuarto";
            public const string CdLeito = "CdLeito";
            public const string DtAtendimento = "ATDATEDTATENDIMENTO";
            public const string DataAtendimento = "DTINT";
            public const string DtNascimento = "DATANASCIMENTO";
            public const string NmMae = "NMNOMEMAE";
            public const string Credencial = "CDCREDENCIAL";

            public const string CdEmpresa = "CDEMPRESA";

            public const string IdtPlano = "IDTPLANO";
            public const string NmPlano = "NMPLANO";
            public const string TpPlano = "CADPLACDTIPOPLANO";
            public const string CdPlano = "CDPLANO";

            //Setores
            public const string IdtSetor = "IdtSetor";
            public const string IdtLocalAtendimento = "IdtLocalAtendimento";
            public const string IdtUnidade = "IdtUnidade";
            public const string DsUnidade = "DSUNIDADE";
            public const string DsSetor = "DSSETOR";
            public const string DsLocal = "DSLOCAL";


            public const string DtTransf = "DTTRANSF";
            public const string HrTransf = "HRTRANSF";


            public const string DtAlta = "DTALTA";

            public const string ContaFaturada = "CONTAFATURADA";


        }

        #endregion

        #region Atributos Publicos

        /// <summary>
        /// Sequencia do Atendimento
        /// </summary>
        public MVC.DTO.FieldDecimal Idt
        {
            get { return atd_ate_id; }
            set { atd_ate_id = value; }
        }

        /// <summary>
        /// Tipo de Atendimento: Ambulatorial ou Internação
        /// </summary>
        public MVC.DTO.FieldString TpAtendimento
        {
            get { return atd_ate_tp_paciente; }
            set { atd_ate_tp_paciente = value; }
        }
        /// <summary>
        /// Código do Quarto
        /// </summary>
        public MVC.DTO.FieldDecimal CdQuarto
        {
            get { return cod_quarto; }
            set { cod_quarto = value; }
        }
        /// <summary>
        /// Código do Leito
        /// </summary>
        public MVC.DTO.FieldDecimal CdLeito
        {
            get { return cod_leito; }
            set { cod_leito = value; }
        }
        /// <summary>
        /// Data do Atendimento
        /// </summary>
        public MVC.DTO.FieldDateTime DtAtendimento
        {
            get { return atd_ate_dt_atendimento; }
            set { atd_ate_dt_atendimento = value; }
        }

        /// <summary>
        /// Data do Atendimento utilizada na PRC_CAD_ATENDIMENTO_SID
        /// </summary>
        public MVC.DTO.FieldDateTime DataAtendimento
        {
            get { return atd_dt_atendimento; }
            set { atd_dt_atendimento = value; }
        }

        // PACIENTE
        /// <summary>
        /// Nome Paciente
        /// </summary>
        public MVC.DTO.FieldString NmPaciente
        {
            get { return cad_pes_nm_pessoa; }
            set { cad_pes_nm_pessoa = value; }
        }

        /// <summary>
        /// Nome Social do Paciente
        /// </summary>
        public MVC.DTO.FieldString NmSocial
        {
            get { return cad_pes_nm_razaosocial; }
            set { cad_pes_nm_razaosocial = value; }
        }

        /// <summary>
        /// Data de Nascimento do Paciente
        /// </summary>
        public MVC.DTO.FieldDateTime DtNascimento
        {
            get { return cad_pes_dt_nascimento; }
            set { cad_pes_dt_nascimento = value; }
        }

        public MVC.DTO.FieldString NmMae
        {
            get { return cad_pes_nm_nomemae; }
            set { cad_pes_nm_nomemae = value; }
        }

        public MVC.DTO.FieldString Credencial
        {
            get { return cad_pac_cd_credencial; }
            set { cad_pac_cd_credencial = value; }
        }

        //CONVÊNIO
        /// <summary>
        /// Id do Convênio
        /// </summary>
        public MVC.DTO.FieldDecimal IdtConvenio
        {
            get { return cad_cnv_id_convenio; }
            set { cad_cnv_id_convenio = value; }
        }
        /// <summary>
        /// Descrição do Convenio
        /// </summary>
        public MVC.DTO.FieldString DsEmpresa
        {
            get { return cad_cnv_nm_convenio; }
            set { cad_cnv_nm_convenio = value; }
        }

        /// <summary>
        /// Código da Empresa
        /// </summary>
        public MVC.DTO.FieldString CdEmpresa
        {
            get { return cad_cnv_cd_hac_prestador; }
            set { cad_cnv_cd_hac_prestador = value; }
        }


        //PLANO
        /// <summary>
        /// Id do Plano
        /// </summary>
        public MVC.DTO.FieldDecimal IdtPlano
        {
            get { return cad_pla_id_plano; }
            set { cad_pla_id_plano = value; }
        }
        /// <summary>
        /// Tipo de Plano: GB/PL/SP
        /// </summary>       
        public MVC.DTO.FieldString TpPlano
        {
            get { return cad_pla_cd_tipoplano; }
            set { cad_pla_cd_tipoplano = value; }
        }
        /// <summary>
        /// Descrição do Plano
        /// </summary>
        public MVC.DTO.FieldString NmPlano
        {
            get { return cad_pla_nm_nome_plano; }
            set { cad_pla_nm_nome_plano = value; }
        }

        /// <summary>
        /// Código do Plano
        /// </summary>
        public MVC.DTO.FieldString CdPlano
        {
            get { return cad_pla_cd_plano; }
            set { cad_pla_cd_plano = value; }
        }


        //SETORES
        /// <summary>
        /// Id do Setor de Atendimento
        /// </summary>
        public MVC.DTO.FieldDecimal IdtSetor
        {
            get { return cad_set_id; }
            set { cad_set_id = value; }
        }

        /// <summary>
        /// Id do Local de Atendimento
        /// </summary>
        public MVC.DTO.FieldDecimal IdtLocalAtendimento
        {
            get { return cad_lat_id_local_atendimento; }
            set { cad_lat_id_local_atendimento = value; }
        }

        /// <summary>
        /// Id da Unidade de Atendimento
        /// </summary>
        public MVC.DTO.FieldDecimal IdtUnidade
        {
            get { return cad_uni_id_unidade; }
            set { cad_uni_id_unidade = value; }
        }

        /// <summary>
        /// Descricao do Setor de Atendimento
        /// </summary>
        public MVC.DTO.FieldString DsSetor
        {
            get { return cad_set_ds_setor; }
            set { cad_set_ds_setor = value; }
        }

        /// <summary>
        /// Descrição do Local do Atendimento
        /// </summary>
        public MVC.DTO.FieldString DsLocal
        {
            get { return cad_lat_ds_local_atendimento; }
            set { cad_lat_ds_local_atendimento = value; }
        }

        /// <summary>
        /// Descrição da Unidade de Atendimento
        /// </summary>
        public MVC.DTO.FieldString DsUnidade
        {
            get { return cad_uni_ds_unidade; }
            set { cad_uni_ds_unidade = value; }
        }


        public MVC.DTO.FieldDateTime DtTransf
        {
            get { return dt_transf; }
            set { dt_transf = value; }
        }


        public MVC.DTO.FieldDecimal HrTransf
        {
            get { return hr_transf; }
            set { hr_transf = value; }
        }

        public MVC.DTO.FieldDateTime DtAlta
        {
            get { return dt_alta; }
            set { dt_alta = value; }
        }



        public MVC.DTO.FieldDecimal ContaFaturada
        {
            get { return conta_faturada; }
            set { conta_faturada = value; }
        }


        #endregion

        #region Operators

        public static explicit operator PacienteDTO(DataRow row)
        {
            PacienteDTO dto = new PacienteDTO();

            dto.Idt.Value = row[FieldNames.Idt].ToString();
            
            dto.TpAtendimento.Value = row[FieldNames.TpAtendimento].ToString();

            dto.CdQuarto.Value = row[FieldNames.CdQuarto].ToString();

            dto.CdLeito.Value = row[FieldNames.CdLeito].ToString();

            dto.DtAtendimento.Value = row[FieldNames.DtAtendimento].ToString();
            dto.DataAtendimento.Value = row[FieldNames.DataAtendimento].ToString();

            //PACIENTE
            dto.NmPaciente.Value = row[FieldNames.NmPaciente].ToString();

            dto.DtNascimento.Value = row[FieldNames.DtNascimento].ToString();

            try
            {
                dto.NmMae.Value = row[FieldNames.NmMae].ToString();
                dto.Credencial.Value = row[FieldNames.Credencial].ToString();
            }
            catch
            {
                //deixa passar se não tiver coluna
            } 

            // CONVÊNIO
            dto.IdtConvenio.Value = row[FieldNames.IdtConvenio].ToString();
            
            dto.DsEmpresa.Value = row[FieldNames.DsEmpresa].ToString();

            dto.CdEmpresa.Value = row[FieldNames.CdEmpresa].ToString();


            //PLANO
            dto.IdtPlano.Value = row[FieldNames.IdtPlano].ToString();
            dto.NmPlano.Value = row[FieldNames.NmPlano].ToString();
            dto.TpPlano.Value = row[FieldNames.TpPlano].ToString();
            dto.CdPlano.Value = row[FieldNames.CdPlano].ToString();


            //Setores
            dto.IdtSetor.Value = row[FieldNames.IdtSetor].ToString();

            dto.IdtLocalAtendimento.Value = row[FieldNames.IdtLocalAtendimento].ToString();

            dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();

            dto.DsLocal.Value = row[FieldNames.DsLocal].ToString();

            dto.DsSetor.Value = row[FieldNames.DsSetor].ToString();

            dto.DsUnidade.Value = row[FieldNames.DsUnidade].ToString();

            dto.DtTransf.Value = row[FieldNames.DtTransf].ToString();
            dto.HrTransf.Value = row[FieldNames.HrTransf].ToString();

            dto.DtAlta.Value = row[FieldNames.DtAlta].ToString();

            dto.ContaFaturada.Value = row[FieldNames.ContaFaturada].ToString();

            return dto;
        }

        public static explicit operator PacienteDTO(XmlDocument xml)
        {
            PacienteDTO dto = new PacienteDTO();

            if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.TpAtendimento) != null) dto.TpAtendimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.TpAtendimento).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.CdQuarto) != null) dto.CdQuarto.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdQuarto).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.CdLeito) != null) dto.CdLeito.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdLeito).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DtAtendimento) != null) dto.DtAtendimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtAtendimento).InnerText;

            //PACIENTE
            if (xml.FirstChild.SelectSingleNode(FieldNames.NmPaciente) != null) dto.NmPaciente.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmPaciente).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DtNascimento) != null) dto.DtNascimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtNascimento).InnerText;

            //CONVÊNIO
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtConvenio) != null) dto.IdtConvenio.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtConvenio).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsEmpresa) != null) dto.DsEmpresa.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsEmpresa).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.CdEmpresa) != null) dto.CdEmpresa.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdEmpresa).InnerText;


            //PLANO
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtPlano) != null) dto.IdtPlano.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtPlano).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.NmPlano) != null) dto.NmPlano.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmPlano).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.TpPlano) != null) dto.TpPlano.Value = xml.FirstChild.SelectSingleNode(FieldNames.TpPlano).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CdPlano) != null) dto.CdPlano.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdPlano).InnerText;


            // SETORES
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor) != null) dto.IdtSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalAtendimento) != null) dto.IdtLocalAtendimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalAtendimento).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsLocal) != null) dto.DsLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsLocal).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsSetor) != null) dto.DsSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsSetor).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade) != null) dto.DsUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DtTransf) != null) dto.DtTransf.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtTransf).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.HrTransf) != null) dto.HrTransf.Value = xml.FirstChild.SelectSingleNode(FieldNames.HrTransf).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DtAlta) != null) dto.DtAlta.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtAlta).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.ContaFaturada) != null) dto.ContaFaturada.Value = xml.FirstChild.SelectSingleNode(FieldNames.ContaFaturada).InnerText;

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);

            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);

            XmlNode nodeTpAtendimento = xml.CreateNode(XmlNodeType.Element, FieldNames.TpAtendimento, null);

            XmlNode nodeCdQuarto = xml.CreateNode(XmlNodeType.Element, FieldNames.CdQuarto, null);

            XmlNode nodeCdLeito = xml.CreateNode(XmlNodeType.Element, FieldNames.CdLeito, null);

            XmlNode nodeDtAtendimento = xml.CreateNode(XmlNodeType.Element, FieldNames.DtAtendimento, null);


            //PACIENTE
            XmlNode nodeNmPaciente = xml.CreateNode(XmlNodeType.Element, FieldNames.NmPaciente, null);

            XmlNode nodeDtNascimento = xml.CreateNode(XmlNodeType.Element, FieldNames.DtNascimento, null);


            //CONVENIO
            XmlNode nodeIdtConvenio = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtConvenio, null);

            XmlNode nodeDsEmpresa = xml.CreateNode(XmlNodeType.Element, FieldNames.DsEmpresa, null);

            XmlNode nodeCdEmpresa = xml.CreateNode(XmlNodeType.Element, FieldNames.CdEmpresa, null);



            //PLANO
            XmlNode nodeIdtPlano = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtPlano, null);
            XmlNode nodeNmPlano = xml.CreateNode(XmlNodeType.Element, FieldNames.NmPlano, null);
            XmlNode nodeTpPlano = xml.CreateNode(XmlNodeType.Element, FieldNames.TpPlano, null);
            XmlNode nodeCdPlano = xml.CreateNode(XmlNodeType.Element, FieldNames.CdPlano, null);


            //Setores
            XmlNode nodeIdtSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetor, null);

            XmlNode nodeIdtLocalAtendimento = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocalAtendimento, null);

            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);

            XmlNode nodeDsLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.DsLocal, null);

            XmlNode nodeDsSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.DsSetor, null);

            XmlNode nodeDsUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidade, null);

            XmlNode nodeDtTransf = xml.CreateNode(XmlNodeType.Element, FieldNames.DtTransf, null);
            XmlNode nodeHrTransf = xml.CreateNode(XmlNodeType.Element, FieldNames.HrTransf, null);

            XmlNode nodeDtAlta = xml.CreateNode(XmlNodeType.Element, FieldNames.DtAlta, null);


            XmlNode noContaFaturada = xml.CreateNode(XmlNodeType.Element, FieldNames.ContaFaturada, null);


            //ATENDIMENTO
            if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;

            if (!this.TpAtendimento.Value.IsNull) nodeTpAtendimento.InnerText = this.TpAtendimento.Value;

            if (!this.CdQuarto.Value.IsNull) nodeCdQuarto.InnerText = this.CdQuarto.Value;

            if (!this.CdLeito.Value.IsNull) nodeCdLeito.InnerText = this.CdLeito.Value;

            if (!this.DtAtendimento.Value.IsNull) nodeDtAtendimento.InnerText = this.DtAtendimento.Value;

            //PACIENTE
            if (!this.NmPaciente.Value.IsNull) nodeNmPaciente.InnerText = this.NmPaciente.Value;

            if (!this.DtNascimento.Value.IsNull) nodeDtNascimento.InnerText = this.DtNascimento.Value;


            //CONVÊNIO
            if (!this.IdtConvenio.Value.IsNull) nodeIdtConvenio.InnerText = this.IdtConvenio.Value;

            if (!this.DsEmpresa.Value.IsNull) nodeDsEmpresa.InnerText = this.DsEmpresa.Value;

            if (!this.CdEmpresa.Value.IsNull) nodeCdEmpresa.InnerText = this.CdEmpresa.Value;

            //PLANO
            if (!this.IdtPlano.Value.IsNull) nodeIdtPlano.InnerText = this.IdtPlano.Value;
            if (!this.NmPlano.Value.IsNull) nodeNmPlano.InnerText = this.NmPlano.Value;
            if (!this.TpPlano.Value.IsNull) nodeTpPlano.InnerText = this.TpPlano.Value;
            if (!this.CdPlano.Value.IsNull) nodeCdPlano.InnerText = this.CdPlano.Value;

            //Setores
            if (!this.IdtSetor.Value.IsNull) nodeIdtSetor.InnerText = this.IdtSetor.Value;

            if (!this.IdtLocalAtendimento.Value.IsNull) nodeIdtLocalAtendimento.InnerText = this.IdtLocalAtendimento.Value;

            if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;

            if (!this.DsLocal.Value.IsNull) nodeDsLocal.InnerText = this.DsLocal.Value;

            if (!this.DsUnidade.Value.IsNull) nodeDsUnidade.InnerText = this.DsUnidade.Value;

            if (!this.DsSetor.Value.IsNull) nodeDsSetor.InnerText = this.DsSetor.Value;


            if (!this.DtTransf.Value.IsNull) nodeDtTransf.InnerText = this.DtTransf.Value;
            if (!this.HrTransf.Value.IsNull) nodeHrTransf.InnerText = this.HrTransf.Value;

            if (!this.DtAlta.Value.IsNull) nodeDtAlta.InnerText = this.DtAlta.Value;

            if (!this.ContaFaturada.Value.IsNull) noContaFaturada.InnerText = this.ContaFaturada.Value;

            // ATENDIMENTO
            nodeData.AppendChild(nodeIdt);

            nodeData.AppendChild(nodeTpAtendimento);

            nodeData.AppendChild(nodeCdQuarto);

            nodeData.AppendChild(nodeCdLeito);

            nodeData.AppendChild(nodeDtAtendimento);


            //PACIENTE
            nodeData.AppendChild(nodeNmPaciente);

            nodeData.AppendChild(nodeDtNascimento);

            //CONVÊNIO
            nodeData.AppendChild(nodeIdtConvenio);

            nodeData.AppendChild(nodeDsEmpresa);

            nodeData.AppendChild(nodeCdEmpresa);

            //PLANO
            nodeData.AppendChild(nodeIdtPlano);

            nodeData.AppendChild(nodeNmPlano);

            nodeData.AppendChild(nodeTpPlano);

            nodeData.AppendChild(nodeCdPlano);


            //Setores
            nodeData.AppendChild(nodeIdtSetor);

            nodeData.AppendChild(nodeIdtLocalAtendimento);

            nodeData.AppendChild(nodeIdtUnidade);

            nodeData.AppendChild(nodeDsLocal);

            nodeData.AppendChild(nodeDsUnidade);

            nodeData.AppendChild(nodeDsSetor);

            nodeData.AppendChild(nodeDtTransf);
            nodeData.AppendChild(nodeHrTransf);


            nodeData.AppendChild(nodeDtAlta);

            nodeData.AppendChild(noContaFaturada);

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(PacienteDTO dto)
        {
            InternacaoLegadoDataTable dtb = new InternacaoLegadoDataTable();
            DataRow dtr = dtb.NewRow();

            dtr[FieldNames.Idt] = dto.Idt.Value;

            dtr[FieldNames.TpAtendimento] = dto.TpAtendimento.Value;

            dtr[FieldNames.CdQuarto] = dto.CdQuarto.Value;

            dtr[FieldNames.CdLeito] = dto.CdLeito.Value;

            dtr[FieldNames.DtAtendimento] = dto.DtAtendimento.Value;
            dtr[FieldNames.DataAtendimento] = dto.DataAtendimento.Value;

            //PACIENTE
            dtr[FieldNames.NmPaciente] = dto.NmPaciente.Value;

            dtr[FieldNames.DtNascimento] = dto.DtNascimento.Value;

            dtr[FieldNames.NmMae] = dto.NmMae.Value;

            dtr[FieldNames.Credencial] = dto.Credencial.Value;

            //CONVÊNIO
            dtr[FieldNames.IdtConvenio] = dto.IdtConvenio.Value;

            dtr[FieldNames.DsEmpresa] = dto.DsEmpresa.Value;

            dtr[FieldNames.CdEmpresa] = dto.CdEmpresa.Value;


            //PLANO
            dtr[FieldNames.IdtPlano] = dto.IdtPlano.Value;

            dtr[FieldNames.NmPlano] = dto.NmPlano.Value;

            dtr[FieldNames.TpPlano] = dto.TpPlano.Value;

            dtr[FieldNames.CdPlano] = dto.CdPlano.Value;

            //Setores
            dtr[FieldNames.IdtSetor] = dto.IdtSetor.Value;

            dtr[FieldNames.IdtLocalAtendimento] = dto.IdtLocalAtendimento.Value;

            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;

            dtr[FieldNames.DsSetor] = dto.DsSetor.Value;

            dtr[FieldNames.DsUnidade] = dto.DsUnidade.Value;

            dtr[FieldNames.DsLocal] = dto.DsLocal.Value;

            dtr[FieldNames.DtTransf] = dto.DtTransf.Value;
            dtr[FieldNames.HrTransf] = dto.HrTransf.Value;

            dtr[FieldNames.DtAlta] = dto.DtAlta.Value;


            dtr[FieldNames.ContaFaturada] = dto.ContaFaturada.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(PacienteDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}