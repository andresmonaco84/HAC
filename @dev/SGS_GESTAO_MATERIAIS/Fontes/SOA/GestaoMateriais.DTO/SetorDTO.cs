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
	/// Classe Entidade SetorDataTable
	/// </summary>
	[Serializable()]
	public class SetorDataTable : DataTable
	{
		
	    public SetorDataTable()
            : base()
        {
            this.TableName = "Setor";
		    this.Columns.Add(SetorDTO.FieldNames.Idt, typeof(Decimal));
		    this.Columns.Add(SetorDTO.FieldNames.Codigo, typeof(String));
		    this.Columns.Add(SetorDTO.FieldNames.Descricao, typeof(String));
		    this.Columns.Add(SetorDTO.FieldNames.NumeroTelefone, typeof(String));
		    this.Columns.Add(SetorDTO.FieldNames.SubstituiAlmoxarifado, typeof(String));
		    this.Columns.Add(SetorDTO.FieldNames.PossuiEstoqueProprio, typeof(String));
		    this.Columns.Add(SetorDTO.FieldNames.FlAtivo, typeof(String));
		    this.Columns.Add(SetorDTO.FieldNames.GravaAtendimento, typeof(String));
		    this.Columns.Add(SetorDTO.FieldNames.IdtUsuarioUltimaAtualizacao, typeof(Decimal));
		    this.Columns.Add(SetorDTO.FieldNames.NumeroAndar, typeof(Decimal));
		    this.Columns.Add(SetorDTO.FieldNames.DataUltimaAtualizacao, typeof(DateTime));
		    this.Columns.Add(SetorDTO.FieldNames.IdtUnidade, typeof(Decimal));
		    this.Columns.Add(SetorDTO.FieldNames.IdtLocalAtendimento, typeof(Decimal));
		    this.Columns.Add(SetorDTO.FieldNames.IdtRamal, typeof(Decimal));
		    this.Columns.Add(SetorDTO.FieldNames.DescricaoProcedencia, typeof(String));
		    this.Columns.Add(SetorDTO.FieldNames.AtendeServicoMulher, typeof(String));
            this.Columns.Add(SetorDTO.FieldNames.UnidadeAlmoxarifado, typeof(Decimal));
            this.Columns.Add(SetorDTO.FieldNames.LocalAlmoxarifado, typeof(Decimal));
            this.Columns.Add(SetorDTO.FieldNames.SetorAlmoxarifado, typeof(Decimal));
            this.Columns.Add(SetorDTO.FieldNames.DsUnidade, typeof(String));
            this.Columns.Add(SetorDTO.FieldNames.DsLocal, typeof(String));
            this.Columns.Add(SetorDTO.FieldNames.FlAlmoxCentral, typeof(Decimal));
            this.Columns.Add(SetorDTO.FieldNames.PermiteInternacao, typeof(String));
            this.Columns.Add(SetorDTO.FieldNames.PreferencialACS, typeof(String));
            this.Columns.Add(SetorDTO.FieldNames.MovimentaPacienteInternado, typeof(String));
            this.Columns.Add(SetorDTO.FieldNames.PermiteLiberarLeito, typeof(String));
            this.Columns.Add(SetorDTO.FieldNames.SetorFarmacia, typeof(Decimal));
            this.Columns.Add(SetorDTO.FieldNames.CarrinhoEmergSetorPai, typeof(Decimal));

            DataColumn[] primaryKey = { this.Columns[SetorDTO.FieldNames.Idt] };

            this.PrimaryKey = primaryKey;
        }
		
        protected SetorDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}

		public SetorDTO TypedRow(int index)
        {
            return (SetorDTO)this.Rows[index];
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

        public void Add(SetorDTO dto)
        {
            DataRow dtr = this.NewRow();

		    if (!dto.Idt.Value.IsNull) dtr[SetorDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		    if (!dto.Codigo.Value.IsNull) dtr[SetorDTO.FieldNames.Codigo] = (String)dto.Codigo.Value;
		    if (!dto.Descricao.Value.IsNull) dtr[SetorDTO.FieldNames.Descricao] = (String)dto.Descricao.Value;
		    if (!dto.NumeroTelefone.Value.IsNull) dtr[SetorDTO.FieldNames.NumeroTelefone] = (String)dto.NumeroTelefone.Value;
		    if (!dto.SubstituiAlmoxarifado.Value.IsNull) dtr[SetorDTO.FieldNames.SubstituiAlmoxarifado] = (String)dto.SubstituiAlmoxarifado.Value;
		    if (!dto.PossuiEstoqueProprio.Value.IsNull) dtr[SetorDTO.FieldNames.PossuiEstoqueProprio] = (String)dto.PossuiEstoqueProprio.Value;
		    if (!dto.FlAtivo.Value.IsNull) dtr[SetorDTO.FieldNames.FlAtivo] = (String)dto.FlAtivo.Value;
		    if (!dto.GravaAtendimento.Value.IsNull) dtr[SetorDTO.FieldNames.GravaAtendimento] = (String)dto.GravaAtendimento.Value;
		    if (!dto.IdtUsuarioUltimaAtualizacao.Value.IsNull) dtr[SetorDTO.FieldNames.IdtUsuarioUltimaAtualizacao] = (Decimal)dto.IdtUsuarioUltimaAtualizacao.Value;
		    if (!dto.NumeroAndar.Value.IsNull) dtr[SetorDTO.FieldNames.NumeroAndar] = (Decimal)dto.NumeroAndar.Value;
		    if (!dto.DataUltimaAtualizacao.Value.IsNull) dtr[SetorDTO.FieldNames.DataUltimaAtualizacao] = (DateTime)dto.DataUltimaAtualizacao.Value;
		    if (!dto.IdtUnidade.Value.IsNull) dtr[SetorDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;
		    if (!dto.IdtLocalAtendimento.Value.IsNull) dtr[SetorDTO.FieldNames.IdtLocalAtendimento] = (Decimal)dto.IdtLocalAtendimento.Value;
		    if (!dto.IdtRamal.Value.IsNull) dtr[SetorDTO.FieldNames.IdtRamal] = (Decimal)dto.IdtRamal.Value;
		    if (!dto.DescricaoProcedencia.Value.IsNull) dtr[SetorDTO.FieldNames.DescricaoProcedencia] = (String)dto.DescricaoProcedencia.Value;
		    if (!dto.AtendeServicoMulher.Value.IsNull) dtr[SetorDTO.FieldNames.AtendeServicoMulher] = (String)dto.AtendeServicoMulher.Value;
            if (!dto.UnidadeAlmoxarifado.Value.IsNull) dtr[SetorDTO.FieldNames.UnidadeAlmoxarifado] = (Decimal)dto.UnidadeAlmoxarifado.Value;
            if (!dto.LocalAlmoxarifado.Value.IsNull) dtr[SetorDTO.FieldNames.LocalAlmoxarifado] = (Decimal)dto.LocalAlmoxarifado.Value;
            if (!dto.SetorAlmoxarifado.Value.IsNull) dtr[SetorDTO.FieldNames.SetorAlmoxarifado] = (Decimal)dto.SetorAlmoxarifado.Value;
            if (!dto.DsUnidade.Value.IsNull) dtr[SetorDTO.FieldNames.DsUnidade] = (String)dto.DsUnidade.Value;
            if (!dto.DsLocal.Value.IsNull) dtr[SetorDTO.FieldNames.DsLocal] = (String)dto.DsLocal.Value;
            if (!dto.FlAlmoxCentral.Value.IsNull) dtr[SetorDTO.FieldNames.FlAlmoxCentral] = (Decimal)dto.FlAlmoxCentral.Value;
            if (!dto.PermiteInternacao.Value.IsNull) dtr[SetorDTO.FieldNames.PermiteInternacao] = (String)dto.PermiteInternacao.Value;
            if (!dto.PreferencialACS.Value.IsNull) dtr[SetorDTO.FieldNames.PreferencialACS] = (String)dto.PreferencialACS.Value;
            if (!dto.MovimentaPacienteInternado.Value.IsNull) dtr[SetorDTO.FieldNames.MovimentaPacienteInternado] = (String)dto.MovimentaPacienteInternado.Value;
            if (!dto.PermiteLiberarLeito.Value.IsNull) dtr[SetorDTO.FieldNames.PermiteLiberarLeito] = (String)dto.PermiteLiberarLeito.Value;
            if (!dto.SetorFarmacia.Value.IsNull) dtr[SetorDTO.FieldNames.SetorFarmacia] = (Decimal)dto.SetorFarmacia.Value;
            if (!dto.CarrinhoEmergSetorPai.Value.IsNull) dtr[SetorDTO.FieldNames.CarrinhoEmergSetorPai] = (Decimal)dto.CarrinhoEmergSetorPai.Value;

            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class SetorDTO : MVC.DTO.DTOBase
    {
        public enum AlmoxarifadoCentral
        {
            NAO = 0,
            SIM = 1
        }

		private MVC.DTO.FieldDecimal cad_set_id;
		private MVC.DTO.FieldString cad_set_cd_setor;
		private MVC.DTO.FieldString cad_set_ds_setor;
		private MVC.DTO.FieldString cad_set_nr_telefone;
		private MVC.DTO.FieldString cad_set_fl_substalmox_ok;
		private MVC.DTO.FieldString cad_set_fl_estqproprio_ok;
		private MVC.DTO.FieldString cad_set_fl_ativo_ok;
		private MVC.DTO.FieldString cad_set_fl_gravaatend_ok;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario;
		private MVC.DTO.FieldDecimal cad_set_nr_andar;
		private MVC.DTO.FieldDateTime cad_set_dt_ultima_atualizacao;
		private MVC.DTO.FieldDecimal cad_uni_id_unidade;
		private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
		private MVC.DTO.FieldDecimal cad_set_nr_ramal;
		private MVC.DTO.FieldString cad_set_ds_procedencia;
		private MVC.DTO.FieldString cad_set_fl_atendservmul_ok;
        private MVC.DTO.FieldDecimal cad_set_unidade_almox;
        private MVC.DTO.FieldDecimal cad_set_local_almox;
        private MVC.DTO.FieldDecimal cad_set_setor_almox;
        private MVC.DTO.FieldString cad_set_ds_unidade;
        private MVC.DTO.FieldString cad_set_ds_local;
        private MVC.DTO.FieldDecimal cad_set_almox_central;
        private MVC.DTO.FieldString cad_set_fl_permiteintern_ok;
        private MVC.DTO.FieldString cad_set_fl_preferenc_acs_ok;
        private MVC.DTO.FieldString cad_set_fl_movimentapacint_ok;
        private MVC.DTO.FieldString cad_set_fl_permitelibleito_ok;
        private MVC.DTO.FieldDecimal cad_set_setor_farmacia;
        private MVC.DTO.FieldDecimal cad_set_ce_setor_pai;

        public SetorDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
		    this.cad_set_id = new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		    this.cad_set_cd_setor= new MVC.DTO.FieldString(FieldNames.Codigo,Captions.Codigo, 4);
		    this.cad_set_ds_setor= new MVC.DTO.FieldString(FieldNames.Descricao,Captions.Descricao, 50);
		    this.cad_set_nr_telefone= new MVC.DTO.FieldString(FieldNames.NumeroTelefone,Captions.NumeroTelefone, 20);
		    this.cad_set_fl_substalmox_ok= new MVC.DTO.FieldString(FieldNames.SubstituiAlmoxarifado,Captions.SubstituiAlmoxarifado, 1);
		    this.cad_set_fl_estqproprio_ok= new MVC.DTO.FieldString(FieldNames.PossuiEstoqueProprio,Captions.PossuiEstoqueProprio, 1);
		    this.cad_set_fl_ativo_ok= new MVC.DTO.FieldString(FieldNames.FlAtivo,Captions.FlAtivo, 1);
		    this.cad_set_fl_gravaatend_ok= new MVC.DTO.FieldString(FieldNames.GravaAtendimento,Captions.GravaAtendimento, 1);
		    this.seg_usu_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuarioUltimaAtualizacao,Captions.IdtUsuarioUltimaAtualizacao, DbType.Decimal);
		    this.cad_set_nr_andar= new MVC.DTO.FieldDecimal(FieldNames.NumeroAndar,Captions.NumeroAndar, DbType.Decimal);
		    this.cad_set_dt_ultima_atualizacao= new MVC.DTO.FieldDateTime(FieldNames.DataUltimaAtualizacao,Captions.DataUltimaAtualizacao);
		    this.cad_uni_id_unidade= new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade,Captions.IdtUnidade, DbType.Decimal);
		    this.cad_lat_id_local_atendimento= new MVC.DTO.FieldDecimal(FieldNames.IdtLocalAtendimento,Captions.IdtLocalAtendimento, DbType.Decimal);
		    this.cad_set_nr_ramal= new MVC.DTO.FieldDecimal(FieldNames.IdtRamal,Captions.IdtRamal, DbType.Decimal);
		    this.cad_set_ds_procedencia= new MVC.DTO.FieldString(FieldNames.DescricaoProcedencia,Captions.DescricaoProcedencia, 20);
		    this.cad_set_fl_atendservmul_ok= new MVC.DTO.FieldString(FieldNames.AtendeServicoMulher,Captions.AtendeServicoMulher, 1);
            this.cad_set_unidade_almox = new MVC.DTO.FieldDecimal(FieldNames.UnidadeAlmoxarifado, Captions.UnidadeAlmoxarifado, DbType.Decimal);
            this.cad_set_local_almox = new MVC.DTO.FieldDecimal(FieldNames.LocalAlmoxarifado, Captions.LocalAlmoxarifado, DbType.Decimal);
            this.cad_set_setor_almox = new MVC.DTO.FieldDecimal(FieldNames.SetorAlmoxarifado, Captions.SetorAlmoxarifado, DbType.Decimal);
            this.cad_set_ds_unidade = new MVC.DTO.FieldString(FieldNames.DsUnidade, Captions.DsUnidade, 50);
            this.cad_set_ds_local = new MVC.DTO.FieldString(FieldNames.DsLocal, Captions.DsLocal, 50);
            this.cad_set_almox_central = new MVC.DTO.FieldDecimal(FieldNames.FlAlmoxCentral, Captions.FlAlmoxCentral, DbType.Decimal);
            this.cad_set_fl_permiteintern_ok = new MVC.DTO.FieldString(FieldNames.PermiteInternacao, Captions.PermiteInternacao, 1);
            this.cad_set_fl_preferenc_acs_ok = new MVC.DTO.FieldString(FieldNames.PreferencialACS, Captions.PreferencialACS, 1);
            this.cad_set_fl_movimentapacint_ok = new MVC.DTO.FieldString(FieldNames.MovimentaPacienteInternado, Captions.MovimentaPacienteInternado, 1);
            this.cad_set_fl_permitelibleito_ok = new MVC.DTO.FieldString(FieldNames.PermiteLiberarLeito, Captions.PermiteLiberarLeito, 1);
            this.cad_set_setor_farmacia = new MVC.DTO.FieldDecimal(FieldNames.SetorFarmacia, Captions.SetorFarmacia, DbType.Decimal);
            this.cad_set_ce_setor_pai = new MVC.DTO.FieldDecimal(FieldNames.CarrinhoEmergSetorPai, Captions.CarrinhoEmergSetorPai, DbType.Decimal);
        }
 
        #region FieldNames

        public struct FieldNames
        {
			public const string Idt="CAD_SET_ID";
	        public const string Codigo="CAD_SET_CD_SETOR";
	        public const string Descricao="CAD_SET_DS_SETOR";
	        public const string NumeroTelefone="CAD_SET_NR_TELEFONE";
	        public const string SubstituiAlmoxarifado="CAD_SET_FL_SUBSTALMOX_OK";
	        public const string PossuiEstoqueProprio="CAD_SET_FL_ESTQPROPRIO_OK";
	        public const string FlAtivo="CAD_SET_FL_ATIVO_OK";
	        public const string GravaAtendimento="CAD_SET_FL_GRAVAATEND_OK";
	        public const string IdtUsuarioUltimaAtualizacao="SEG_USU_ID_USUARIO";
	        public const string NumeroAndar="CAD_SET_NR_ANDAR";
	        public const string DataUltimaAtualizacao="CAD_SET_DT_ULTIMA_ATUALIZACAO";
	        public const string IdtUnidade="CAD_UNI_ID_UNIDADE";
	        public const string IdtLocalAtendimento="CAD_LAT_ID_LOCAL_ATENDIMENTO";
	        public const string IdtRamal="CAD_SET_NR_RAMAL";
	        public const string DescricaoProcedencia="CAD_SET_DS_PROCEDENCIA";
	        public const string AtendeServicoMulher="CAD_SET_FL_ATENDSERVMUL_OK";
            public const string UnidadeAlmoxarifado = "CAD_SET_UNIDADE_ALMOX";
            public const string LocalAlmoxarifado = "CAD_SET_LOCAL_ALMOX";
            public const string SetorAlmoxarifado = "CAD_SET_SETOR_ALMOX";
            public const string DsUnidade = "CAD_UNI_DS_UNIDADE";
            public const string DsLocal = "CAD_LAT_DS_LOCAL_ATENDIMENTO";
            public const string FlAlmoxCentral = "CAD_SET_ALMOX_CENTRAL";
            public const string PermiteInternacao = "CAD_SET_FL_PERMITEINTERN_OK";
            public const string PreferencialACS = "CAD_SET_FL_PREFERENC_ACS_OK";
            public const string MovimentaPacienteInternado = "CAD_SET_FL_MOVIMENTAPACINT_OK";
            public const string PermiteLiberarLeito = "CAD_SET_FL_PERMITELIBLEITO_OK";
            public const string SetorFarmacia = "CAD_SET_SETOR_FARMACIA";
            public const string CarrinhoEmergSetorPai = "CAD_SET_CE_SETOR_PAI";
        }		

        #endregion

        #region Captions
        public struct Captions
        {
			public const string Idt="IDT";
	        public const string Codigo="CODIGO";
	        public const string Descricao="DESCRICAO";
	        public const string NumeroTelefone="NUMEROTELEFONE";
	        public const string SubstituiAlmoxarifado="SUBSTITUIALMOXARIFADO";
	        public const string PossuiEstoqueProprio="POSSUIESTOQUEPROPRIO";
	        public const string FlAtivo="ATIVO";
	        public const string GravaAtendimento="GRAVAATENDIMENTO";
	        public const string IdtUsuarioUltimaAtualizacao="IDTUSUARIOULTIMAATUALIZACAO";
	        public const string NumeroAndar="NUMEROANDAR";
	        public const string DataUltimaAtualizacao="DATAULTIMAATUALIZACAO";
	        public const string IdtUnidade="IDTUNIDADE";
	        public const string IdtLocalAtendimento="IDTLOCALATENDIMENTO";
	        public const string IdtRamal="IDTRAMAL";
	        public const string DescricaoProcedencia="DESCRICAOPROCEDENCIA";
	        public const string AtendeServicoMulher="ATENDESERVICOMULHER";
            public const string UnidadeAlmoxarifado = "CADSETUNIDADEALMOX";
            public const string LocalAlmoxarifado = "CADSETLOCALALMOX";
            public const string SetorAlmoxarifado = "CADSETSETORALMOX";
            public const string DsUnidade = "CADSETDSUNIDADE";
            public const string DsLocal = "CADSETDSLOCAL";
            public const string FlAlmoxCentral = "CADSETALMOXCENTRAL";
            public const string PermiteInternacao = "PERMITEINTERNACAO";
            public const string PreferencialACS = "PREFERENCIALACS";
            public const string MovimentaPacienteInternado = "MOVIMENTAPACIENTEINTERNADO";
            public const string PermiteLiberarLeito = "PERMITELIBERARLEITO";
            public const string SetorFarmacia = "SETOR_FARMACIA";
            public const string CarrinhoEmergSetorPai = "CE_SETOR_PAI";
        }		

        #endregion
		
        #region Atributos Publicos

		public MVC.DTO.FieldDecimal Idt
		{
			get { return cad_set_id; }
			set { cad_set_id = value; }
		}
		
		public MVC.DTO.FieldString Codigo
		{
			get { return cad_set_cd_setor; }
			set { cad_set_cd_setor = value; }
		}
		
		public MVC.DTO.FieldString Descricao
		{
			get { return cad_set_ds_setor; }
			set { cad_set_ds_setor = value; }
		}
		
		public MVC.DTO.FieldString NumeroTelefone
		{
			get { return cad_set_nr_telefone; }
			set { cad_set_nr_telefone = value; }
		}
		
		public MVC.DTO.FieldString SubstituiAlmoxarifado
		{
			get { return cad_set_fl_substalmox_ok; }
			set { cad_set_fl_substalmox_ok = value; }
		}
		
		public MVC.DTO.FieldString PossuiEstoqueProprio
		{
			get { return cad_set_fl_estqproprio_ok; }
			set { cad_set_fl_estqproprio_ok = value; }
		}
		
		public MVC.DTO.FieldString FlAtivo
		{
			get { return cad_set_fl_ativo_ok; }
			set { cad_set_fl_ativo_ok = value; }
		}
		
		public MVC.DTO.FieldString GravaAtendimento
		{
			get { return cad_set_fl_gravaatend_ok; }
			set { cad_set_fl_gravaatend_ok = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtUsuarioUltimaAtualizacao
		{
			get { return seg_usu_id_usuario; }
			set { seg_usu_id_usuario = value; }
		}
		
		public MVC.DTO.FieldDecimal NumeroAndar
		{
			get { return cad_set_nr_andar; }
			set { cad_set_nr_andar = value; }
		}
		
		public MVC.DTO.FieldDateTime DataUltimaAtualizacao
		{
			get { return cad_set_dt_ultima_atualizacao; }
			set { cad_set_dt_ultima_atualizacao = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtUnidade
		{
			get { return cad_uni_id_unidade; }
			set { cad_uni_id_unidade = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtLocalAtendimento
		{
			get { return cad_lat_id_local_atendimento; }
			set { cad_lat_id_local_atendimento = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtRamal
		{
			get { return cad_set_nr_ramal; }
			set { cad_set_nr_ramal = value; }
		}
		
		public MVC.DTO.FieldString DescricaoProcedencia
		{
			get { return cad_set_ds_procedencia; }
			set { cad_set_ds_procedencia = value; }
		}
		
		public MVC.DTO.FieldString AtendeServicoMulher
		{
			get { return cad_set_fl_atendservmul_ok; }
			set { cad_set_fl_atendservmul_ok = value; }
		}

        public MVC.DTO.FieldDecimal UnidadeAlmoxarifado
        {
            get { return cad_set_unidade_almox; }
            set { cad_set_unidade_almox = value; }
        }

        public MVC.DTO.FieldDecimal LocalAlmoxarifado
        {
            get { return cad_set_local_almox; }
            set { cad_set_local_almox = value; }
        }

        public MVC.DTO.FieldDecimal SetorAlmoxarifado
        {
            get { return cad_set_setor_almox; }
            set { cad_set_setor_almox = value; }
        }

        public MVC.DTO.FieldString DsUnidade
        {
            get { return cad_set_ds_unidade; }
            set { cad_set_ds_unidade = value; }
        }

        public MVC.DTO.FieldString DsLocal
        {
            get { return cad_set_ds_local; }
            set { cad_set_ds_local = value; }
        }

        public MVC.DTO.FieldDecimal FlAlmoxCentral
        {
            get { return cad_set_almox_central; }
            set { cad_set_almox_central = value; }
        }

        public MVC.DTO.FieldString PermiteInternacao
        {
            get { return cad_set_fl_permiteintern_ok; }
            set { cad_set_fl_permiteintern_ok = value; }
        }

        public MVC.DTO.FieldString PreferencialACS
        {
            get { return cad_set_fl_preferenc_acs_ok; }
            set { cad_set_fl_preferenc_acs_ok = value; }
        }

        public MVC.DTO.FieldString MovimentaPacienteInternado
        {
            get { return cad_set_fl_movimentapacint_ok; }
            set { cad_set_fl_movimentapacint_ok = value; }
        }

        public MVC.DTO.FieldString PermiteLiberarLeito
        {
            get { return cad_set_fl_permitelibleito_ok; }
            set { cad_set_fl_permitelibleito_ok = value; }
        }

        public MVC.DTO.FieldDecimal SetorFarmacia
        {
            get { return cad_set_setor_farmacia; }
            set { cad_set_setor_farmacia = value; }
        }

        public MVC.DTO.FieldDecimal CarrinhoEmergSetorPai
        {
            get { return cad_set_ce_setor_pai; }
            set { cad_set_ce_setor_pai = value; }
        }
		#endregion

        #region Operators

        public static explicit operator SetorDTO(DataRow row)
        {
            SetorDTO  dto = new SetorDTO();
			
			dto.Idt.Value = row[FieldNames.Idt].ToString();
		
			dto.Codigo.Value = row[FieldNames.Codigo].ToString();
		
			dto.Descricao.Value = row[FieldNames.Descricao].ToString();
		
			dto.NumeroTelefone.Value = row[FieldNames.NumeroTelefone].ToString();
		
			dto.SubstituiAlmoxarifado.Value = row[FieldNames.SubstituiAlmoxarifado].ToString();
		
			dto.PossuiEstoqueProprio.Value = row[FieldNames.PossuiEstoqueProprio].ToString();
		
			dto.FlAtivo.Value = row[FieldNames.FlAtivo].ToString();
		
			dto.GravaAtendimento.Value = row[FieldNames.GravaAtendimento].ToString();
		
			dto.IdtUsuarioUltimaAtualizacao.Value = row[FieldNames.IdtUsuarioUltimaAtualizacao].ToString();
		
			dto.NumeroAndar.Value = row[FieldNames.NumeroAndar].ToString();
		
			dto.DataUltimaAtualizacao.Value = row[FieldNames.DataUltimaAtualizacao].ToString();
		
			dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();
		
			dto.IdtLocalAtendimento.Value = row[FieldNames.IdtLocalAtendimento].ToString();
		
			dto.IdtRamal.Value = row[FieldNames.IdtRamal].ToString();
		
			dto.DescricaoProcedencia.Value = row[FieldNames.DescricaoProcedencia].ToString();
		
			dto.AtendeServicoMulher.Value = row[FieldNames.AtendeServicoMulher].ToString();

            dto.UnidadeAlmoxarifado.Value = row[FieldNames.UnidadeAlmoxarifado].ToString();

            dto.LocalAlmoxarifado.Value = row[FieldNames.LocalAlmoxarifado].ToString();

            dto.SetorAlmoxarifado.Value = row[FieldNames.SetorAlmoxarifado].ToString();

            dto.DsUnidade.Value = row[FieldNames.DsUnidade].ToString();

            dto.DsLocal.Value = row[FieldNames.DsLocal].ToString();

            dto.FlAlmoxCentral.Value = row[FieldNames.FlAlmoxCentral].ToString();

            dto.PermiteInternacao.Value = row[FieldNames.PermiteInternacao].ToString();

            dto.PreferencialACS.Value = row[FieldNames.PreferencialACS].ToString();

            dto.MovimentaPacienteInternado.Value = row[FieldNames.MovimentaPacienteInternado].ToString();
            
            dto.PermiteLiberarLeito.Value = row[FieldNames.PermiteLiberarLeito].ToString();

            dto.SetorFarmacia.Value = row[FieldNames.SetorFarmacia].ToString();

            dto.CarrinhoEmergSetorPai.Value = row[FieldNames.CarrinhoEmergSetorPai].ToString();

            return dto;
        }

        public static explicit operator SetorDTO(XmlDocument xml)
        {
            SetorDTO dto = new SetorDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Codigo) != null) dto.Codigo.Value = xml.FirstChild.SelectSingleNode(FieldNames.Codigo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Descricao) != null) dto.Descricao.Value = xml.FirstChild.SelectSingleNode(FieldNames.Descricao).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.NumeroTelefone) != null) dto.NumeroTelefone.Value = xml.FirstChild.SelectSingleNode(FieldNames.NumeroTelefone).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.SubstituiAlmoxarifado) != null) dto.SubstituiAlmoxarifado.Value = xml.FirstChild.SelectSingleNode(FieldNames.SubstituiAlmoxarifado).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.PossuiEstoqueProprio) != null) dto.PossuiEstoqueProprio.Value = xml.FirstChild.SelectSingleNode(FieldNames.PossuiEstoqueProprio).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.FlAtivo) != null) dto.FlAtivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlAtivo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.GravaAtendimento) != null) dto.GravaAtendimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.GravaAtendimento).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioUltimaAtualizacao) != null) dto.IdtUsuarioUltimaAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioUltimaAtualizacao).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.NumeroAndar) != null) dto.NumeroAndar.Value = xml.FirstChild.SelectSingleNode(FieldNames.NumeroAndar).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DataUltimaAtualizacao) != null) dto.DataUltimaAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataUltimaAtualizacao).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalAtendimento) != null) dto.IdtLocalAtendimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalAtendimento).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtRamal) != null) dto.IdtRamal.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtRamal).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DescricaoProcedencia) != null) dto.DescricaoProcedencia.Value = xml.FirstChild.SelectSingleNode(FieldNames.DescricaoProcedencia).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.AtendeServicoMulher) != null) dto.AtendeServicoMulher.Value = xml.FirstChild.SelectSingleNode(FieldNames.AtendeServicoMulher).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeAlmoxarifado) != null) dto.UnidadeAlmoxarifado.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeAlmoxarifado).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.LocalAlmoxarifado) != null) dto.LocalAlmoxarifado.Value = xml.FirstChild.SelectSingleNode(FieldNames.LocalAlmoxarifado).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.SetorAlmoxarifado) != null) dto.SetorAlmoxarifado.Value = xml.FirstChild.SelectSingleNode(FieldNames.SetorAlmoxarifado).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade) != null) dto.DsUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.DsLocal) != null) dto.DsLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsLocal).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.FlAlmoxCentral) != null) dto.FlAlmoxCentral.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlAlmoxCentral).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.PermiteInternacao) != null) dto.PermiteInternacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.PermiteInternacao).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.PreferencialACS) != null) dto.PreferencialACS.Value = xml.FirstChild.SelectSingleNode(FieldNames.PreferencialACS).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.MovimentaPacienteInternado) != null) dto.MovimentaPacienteInternado.Value = xml.FirstChild.SelectSingleNode(FieldNames.MovimentaPacienteInternado).InnerText;
                
                if (xml.FirstChild.SelectSingleNode(FieldNames.PermiteLiberarLeito) != null) dto.PermiteLiberarLeito.Value = xml.FirstChild.SelectSingleNode(FieldNames.PermiteLiberarLeito).InnerText;
			
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeCodigo = xml.CreateNode(XmlNodeType.Element, FieldNames.Codigo, null);
			
            XmlNode nodeDescricao = xml.CreateNode(XmlNodeType.Element, FieldNames.Descricao, null);
			
            XmlNode nodeNumeroTelefone = xml.CreateNode(XmlNodeType.Element, FieldNames.NumeroTelefone, null);
			
            XmlNode nodeSubstituiAlmoxarifado = xml.CreateNode(XmlNodeType.Element, FieldNames.SubstituiAlmoxarifado, null);
			
            XmlNode nodePossuiEstoqueProprio = xml.CreateNode(XmlNodeType.Element, FieldNames.PossuiEstoqueProprio, null);
			
            XmlNode nodeAtivo = xml.CreateNode(XmlNodeType.Element, FieldNames.FlAtivo, null);
			
            XmlNode nodeGravaAtendimento = xml.CreateNode(XmlNodeType.Element, FieldNames.GravaAtendimento, null);
			
            XmlNode nodeIdtUsuarioUltimaAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuarioUltimaAtualizacao, null);
			
            XmlNode nodeNumeroAndar = xml.CreateNode(XmlNodeType.Element, FieldNames.NumeroAndar, null);
			
            XmlNode nodeDataUltimaAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DataUltimaAtualizacao, null);
			
            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);
			
            XmlNode nodeIdtLocalAtendimento = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocalAtendimento, null);
			
            XmlNode nodeIdtRamal = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtRamal, null);
			
            XmlNode nodeDescricaoProcedencia = xml.CreateNode(XmlNodeType.Element, FieldNames.DescricaoProcedencia, null);
			
            XmlNode nodeAtendeServicoMulher = xml.CreateNode(XmlNodeType.Element, FieldNames.AtendeServicoMulher, null);

            XmlNode nodeUnidadeAlmoxarifado = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeAlmoxarifado, null);

            XmlNode nodeLocalAlmoxarifado = xml.CreateNode(XmlNodeType.Element, FieldNames.LocalAlmoxarifado, null);

            XmlNode nodeSetorAlmoxarifado = xml.CreateNode(XmlNodeType.Element, FieldNames.SetorAlmoxarifado, null);

            XmlNode nodeDsUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidade, null);

            XmlNode nodeDsLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.DsLocal, null);

            XmlNode nodeFlAlmoxCentral = xml.CreateNode(XmlNodeType.Element, FieldNames.FlAlmoxCentral, null);
         
            XmlNode nodePermiteInternacao = xml.CreateNode(XmlNodeType.Element, FieldNames.PermiteInternacao, null);

            XmlNode nodePreferencialACS = xml.CreateNode(XmlNodeType.Element, FieldNames.PreferencialACS, null);

            XmlNode nodeMovimentaPacienteInternado = xml.CreateNode(XmlNodeType.Element, FieldNames.MovimentaPacienteInternado, null);
            
            XmlNode nodePermiteLiberarLeito = xml.CreateNode(XmlNodeType.Element, FieldNames.PermiteLiberarLeito, null);
			
                     			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			
			if (!this.Codigo.Value.IsNull) nodeCodigo.InnerText = this.Codigo.Value;
			
			if (!this.Descricao.Value.IsNull) nodeDescricao.InnerText = this.Descricao.Value;
			
			if (!this.NumeroTelefone.Value.IsNull) nodeNumeroTelefone.InnerText = this.NumeroTelefone.Value;
			
			if (!this.SubstituiAlmoxarifado.Value.IsNull) nodeSubstituiAlmoxarifado.InnerText = this.SubstituiAlmoxarifado.Value;
			
			if (!this.PossuiEstoqueProprio.Value.IsNull) nodePossuiEstoqueProprio.InnerText = this.PossuiEstoqueProprio.Value;
			
			if (!this.FlAtivo.Value.IsNull) nodeAtivo.InnerText = this.FlAtivo.Value;
			
			if (!this.GravaAtendimento.Value.IsNull) nodeGravaAtendimento.InnerText = this.GravaAtendimento.Value;
			
			if (!this.IdtUsuarioUltimaAtualizacao.Value.IsNull) nodeIdtUsuarioUltimaAtualizacao.InnerText = this.IdtUsuarioUltimaAtualizacao.Value;
			
			if (!this.NumeroAndar.Value.IsNull) nodeNumeroAndar.InnerText = this.NumeroAndar.Value;
			
			if (!this.DataUltimaAtualizacao.Value.IsNull) nodeDataUltimaAtualizacao.InnerText = this.DataUltimaAtualizacao.Value;
			
			if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;
			
			if (!this.IdtLocalAtendimento.Value.IsNull) nodeIdtLocalAtendimento.InnerText = this.IdtLocalAtendimento.Value;
			
			if (!this.IdtRamal.Value.IsNull) nodeIdtRamal.InnerText = this.IdtRamal.Value;
			
			if (!this.DescricaoProcedencia.Value.IsNull) nodeDescricaoProcedencia.InnerText = this.DescricaoProcedencia.Value;
			
			if (!this.AtendeServicoMulher.Value.IsNull) nodeAtendeServicoMulher.InnerText = this.AtendeServicoMulher.Value;

            if (!this.UnidadeAlmoxarifado.Value.IsNull) nodeUnidadeAlmoxarifado.InnerText = this.UnidadeAlmoxarifado.Value;

            if (!this.LocalAlmoxarifado.Value.IsNull) nodeLocalAlmoxarifado.InnerText = this.LocalAlmoxarifado.Value;

            if (!this.SetorAlmoxarifado.Value.IsNull) nodeSetorAlmoxarifado.InnerText = this.SetorAlmoxarifado.Value;

            if (!this.DsUnidade.Value.IsNull) nodeDsUnidade.InnerText = this.DsUnidade.Value;

            if (!this.DsLocal.Value.IsNull) nodeDsLocal.InnerText = this.DsLocal.Value;

            if (!this.FlAlmoxCentral.Value.IsNull) nodeFlAlmoxCentral.InnerText = this.FlAlmoxCentral.Value;

            if (!this.PermiteInternacao.Value.IsNull) nodePermiteInternacao.InnerText = this.PermiteInternacao.Value;

            if (!this.PreferencialACS.Value.IsNull) nodePreferencialACS.InnerText = this.PreferencialACS.Value;

            if (!this.MovimentaPacienteInternado.Value.IsNull) nodeMovimentaPacienteInternado.InnerText = this.MovimentaPacienteInternado.Value;
            
            if (!this.PermiteLiberarLeito.Value.IsNull) nodePermiteLiberarLeito.InnerText = this.PermiteLiberarLeito.Value;
			
            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodeCodigo);
			
            nodeData.AppendChild(nodeDescricao);
			
            nodeData.AppendChild(nodeNumeroTelefone);
			
            nodeData.AppendChild(nodeSubstituiAlmoxarifado);
			
            nodeData.AppendChild(nodePossuiEstoqueProprio);
			
            nodeData.AppendChild(nodeAtivo);
			
            nodeData.AppendChild(nodeGravaAtendimento);
			
            nodeData.AppendChild(nodeIdtUsuarioUltimaAtualizacao);
			
            nodeData.AppendChild(nodeNumeroAndar);
			
            nodeData.AppendChild(nodeDataUltimaAtualizacao);
			
            nodeData.AppendChild(nodeIdtUnidade);
			
            nodeData.AppendChild(nodeIdtLocalAtendimento);
			
            nodeData.AppendChild(nodeIdtRamal);
			
            nodeData.AppendChild(nodeDescricaoProcedencia);
			
            nodeData.AppendChild(nodeAtendeServicoMulher);

            nodeData.AppendChild(nodeUnidadeAlmoxarifado);

            nodeData.AppendChild(nodeLocalAlmoxarifado);

            nodeData.AppendChild(nodeSetorAlmoxarifado);

            nodeData.AppendChild(nodeDsUnidade);

            nodeData.AppendChild(nodeDsLocal);

            nodeData.AppendChild(nodeFlAlmoxCentral);

            nodeData.AppendChild(nodePermiteInternacao);

            nodeData.AppendChild(nodePreferencialACS);
            
            nodeData.AppendChild(nodeMovimentaPacienteInternado);
            
            nodeData.AppendChild(nodePermiteLiberarLeito);
            
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(SetorDTO dto)
        {
            SetorDataTable dtb = new SetorDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
			
            dtr[FieldNames.Codigo] = dto.Codigo.Value;
			
            dtr[FieldNames.Descricao] = dto.Descricao.Value;
			
            dtr[FieldNames.NumeroTelefone] = dto.NumeroTelefone.Value;
			
            dtr[FieldNames.SubstituiAlmoxarifado] = dto.SubstituiAlmoxarifado.Value;
			
            dtr[FieldNames.PossuiEstoqueProprio] = dto.PossuiEstoqueProprio.Value;
			
            dtr[FieldNames.FlAtivo] = dto.FlAtivo.Value;
			
            dtr[FieldNames.GravaAtendimento] = dto.GravaAtendimento.Value;
			
            dtr[FieldNames.IdtUsuarioUltimaAtualizacao] = dto.IdtUsuarioUltimaAtualizacao.Value;
			
            dtr[FieldNames.NumeroAndar] = dto.NumeroAndar.Value;
			
            dtr[FieldNames.DataUltimaAtualizacao] = dto.DataUltimaAtualizacao.Value;
			
            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;
			
            dtr[FieldNames.IdtLocalAtendimento] = dto.IdtLocalAtendimento.Value;
			
            dtr[FieldNames.IdtRamal] = dto.IdtRamal.Value;
			
            dtr[FieldNames.DescricaoProcedencia] = dto.DescricaoProcedencia.Value;
			
            dtr[FieldNames.AtendeServicoMulher] = dto.AtendeServicoMulher.Value;

            dtr[FieldNames.UnidadeAlmoxarifado] = dto.UnidadeAlmoxarifado.Value;

            dtr[FieldNames.LocalAlmoxarifado] = dto.LocalAlmoxarifado.Value;

            dtr[FieldNames.SetorAlmoxarifado] = dto.SetorAlmoxarifado.Value;

            dtr[FieldNames.DsUnidade] = dto.DsUnidade.Value;

            dtr[FieldNames.DsLocal] = dto.DsLocal.Value;

            dtr[FieldNames.FlAlmoxCentral] = dto.FlAlmoxCentral.Value;

            dtr[FieldNames.PermiteInternacao] = dto.PermiteInternacao.Value;

            dtr[FieldNames.PreferencialACS] = dto.PreferencialACS.Value;

            dtr[FieldNames.MovimentaPacienteInternado] = dto.MovimentaPacienteInternado.Value;
            
            dtr[FieldNames.PermiteLiberarLeito] = dto.PermiteLiberarLeito.Value;

            dtr[FieldNames.SetorFarmacia] = dto.SetorFarmacia.Value;

            dtr[FieldNames.CarrinhoEmergSetorPai] = dto.CarrinhoEmergSetorPai.Value;
            return dtr;
        }

        public static explicit operator XmlDocument(SetorDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}