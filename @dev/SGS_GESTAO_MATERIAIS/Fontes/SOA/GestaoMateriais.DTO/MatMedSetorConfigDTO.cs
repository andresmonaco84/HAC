
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
	/// Classe Entidade MatMedSetorConfigDataTable
	/// </summary>
	[Serializable()]
	public class MatMedSetorConfigDataTable : DataTable
	{		
	    public MatMedSetorConfigDataTable()
            : base()
        {
            this.TableName = "DADOS";

			this.Columns.Add(MatMedSetorConfigDTO.FieldNames.IdtLocal, typeof(decimal));
		    this.Columns.Add(MatMedSetorConfigDTO.FieldNames.IdtUnidade, typeof(decimal));
		    this.Columns.Add(MatMedSetorConfigDTO.FieldNames.Idtsetor, typeof(decimal));
            this.Columns.Add(MatMedSetorConfigDTO.FieldNames.IdtGrupo, typeof(decimal));
            this.Columns.Add(MatMedSetorConfigDTO.FieldNames.IdtSubGrupo, typeof(decimal));
            this.Columns.Add(GrupoMatMedDTO.FieldNames.DsGrupo, typeof(String));
            this.Columns.Add(SubGrupoMatMedDTO.FieldNames.DsSubGrupo, typeof(String));

            this.Columns.Add(MatMedSetorConfigDTO.FieldNames.AtendeTodosSetores, typeof(decimal));

            this.Columns.Add(MatMedSetorConfigDTO.FieldNames.AtendeTodasUnidades, typeof(decimal));
            this.Columns.Add(MatMedSetorConfigDTO.FieldNames.GerandoPedidoAutomatico, typeof(decimal));

            this.Columns.Add(MatMedSetorConfigDTO.FieldNames.IgnoraAlta, typeof(decimal));
            this.Columns.Add(MatMedSetorConfigDTO.FieldNames.IgnoraAltaHorasAte, typeof(decimal));
            this.Columns.Add(MatMedSetorConfigDTO.FieldNames.ConsomeParaOutroCentroCusto, typeof(decimal));
            this.Columns.Add(MatMedSetorConfigDTO.FieldNames.EstoqueUnificadoHAC, typeof(decimal));
            this.Columns.Add(MatMedSetorConfigDTO.FieldNames.SolicitaKit, typeof(decimal));
            this.Columns.Add(MatMedSetorConfigDTO.FieldNames.ControlaConsumoPaciente, typeof(decimal));
            this.Columns.Add(MatMedSetorConfigDTO.FieldNames.DataControlaConsumoPaciente, typeof(DateTime));
            this.Columns.Add(MatMedSetorConfigDTO.FieldNames.IdFuncionalidade, typeof(decimal));

            //DataColumn[] primaryKey = { this.Columns[MatMedSetorConfigDTO.FieldNames.IdtLocal], this.Columns[MatMedSetorConfigDTO.FieldNames.Idtsetor], 
            //this.Columns[MatMedSetorConfigDTO.FieldNames.IdtUnidade], this.Columns[MatMedSetorConfigDTO.FieldNames.IdtSubGrupo] };

            //this.PrimaryKey = primaryKey;
        }
		
        protected MatMedSetorConfigDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public MatMedSetorConfigDTO TypedRow(int index)
        {
            return (MatMedSetorConfigDTO)this.Rows[index];
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

        public void Add(MatMedSetorConfigDTO dto)
        {
            DataRow dtr = this.NewRow();

		    if (!dto.IdtLocal.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.IdtLocal] = (decimal)dto.IdtLocal.Value;
		    if (!dto.IdtUnidade.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.IdtUnidade] = (decimal)dto.IdtUnidade.Value;
		    if (!dto.Idtsetor.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.Idtsetor] = (decimal)dto.Idtsetor.Value;
            if (!dto.IdtGrupo.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.IdtGrupo] = (decimal)dto.IdtGrupo.Value;
            if (!dto.IdtSubGrupo.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.IdtSubGrupo] = (decimal)dto.IdtSubGrupo.Value;
            if (!dto.DsGrupo.Value.IsNull) dtr[GrupoMatMedDTO.FieldNames.DsGrupo] = (String)dto.DsGrupo.Value;
            if (!dto.DsSubGrupo.Value.IsNull) dtr[SubGrupoMatMedDTO.FieldNames.DsSubGrupo] = (String)dto.DsSubGrupo.Value;

            if (!dto.AtendeTodosSetores.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.AtendeTodosSetores] = (decimal)dto.AtendeTodosSetores.Value;
            if (!dto.IgnoraAlta.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.IgnoraAlta] = (decimal)dto.IgnoraAlta.Value;
            if (!dto.IgnoraAltaHorasAte.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.IgnoraAltaHorasAte] = (decimal)dto.IgnoraAltaHorasAte.Value;
            if (!dto.AtendeTodasUnidades.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.AtendeTodasUnidades] = (decimal)dto.AtendeTodasUnidades.Value;
            if (!dto.GerandoPedidoAutomatico.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.GerandoPedidoAutomatico] = (decimal)dto.GerandoPedidoAutomatico.Value;
            if (!dto.EstoqueUnificadoHAC.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.EstoqueUnificadoHAC] = (decimal)dto.EstoqueUnificadoHAC.Value;
            if (!dto.SolicitaKit.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.SolicitaKit] = (decimal)dto.SolicitaKit.Value;
            if (!dto.ControlaConsumoPaciente.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.ControlaConsumoPaciente] = (decimal)dto.ControlaConsumoPaciente.Value;
            if (!dto.DataControlaConsumoPaciente.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.DataControlaConsumoPaciente] = (DateTime)dto.DataControlaConsumoPaciente.Value;
            if (!dto.IdFuncionalidade.Value.IsNull) dtr[MatMedSetorConfigDTO.FieldNames.IdFuncionalidade] = (decimal)dto.IdFuncionalidade.Value;

            // AtendeTodasUnidades MTMD_ATENDE_PAC_TODAS_UNIDADES
            // GerandoPedidoAutomatico MTMD_CONSOME_DIRETO_PACIENTE

            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class MatMedSetorConfigDTO : MVC.DTO.DTOBase
    {
		private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
		private MVC.DTO.FieldDecimal cad_uni_id_unidade;
		private MVC.DTO.FieldDecimal cad_set_id;
        private MVC.DTO.FieldDecimal cad_mtmd_grupo_id;
        private MVC.DTO.FieldDecimal cad_mtmd_subgrupo_id;
        private MVC.DTO.FieldString cad_mtmd_grupo_descricao;
        private MVC.DTO.FieldString cad_mtmd_subgrupo_descricao;

        private MVC.DTO.FieldDecimal mtmd_atende_pac_todos_setores;
        private MVC.DTO.FieldDecimal mtmd_ignora_alta;
        private MVC.DTO.FieldDecimal mtmd_ignora_alta_horas_ate;
        private MVC.DTO.FieldDecimal mtmd_consome_centro_custo;

        private MVC.DTO.FieldDecimal mtmd_atende_pac_todas_unidades;
        private MVC.DTO.FieldDecimal mtmd_consome_direto_paciente;
        private MVC.DTO.FieldDecimal mtmd_estoque_unificado_hac;
        private MVC.DTO.FieldDecimal mtmd_solicita_kit;
        private MVC.DTO.FieldDecimal mtmd_controla_consumo_pac;
        private MVC.DTO.FieldDateTime mtmd_controla_cons_pac_data;
        private MVC.DTO.FieldDecimal mtmd_fun_id_funcionalidade;

        public MatMedSetorConfigDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
            this.cad_lat_id_local_atendimento = new MVC.DTO.FieldDecimal(FieldNames.IdtLocal, Captions.IdtLocal, DbType.Decimal);
            this.cad_uni_id_unidade = new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade, Captions.IdtUnidade, DbType.Decimal);
            this.cad_set_id = new MVC.DTO.FieldDecimal(FieldNames.Idtsetor, Captions.Idtsetor, DbType.Decimal);
            this.cad_mtmd_grupo_id = new MVC.DTO.FieldDecimal(FieldNames.IdtGrupo, Captions.IdtGrupo);
            this.cad_mtmd_subgrupo_id = new MVC.DTO.FieldDecimal(FieldNames.IdtSubGrupo, Captions.IdtSubGrupo);
            this.cad_mtmd_grupo_descricao = new MVC.DTO.FieldString(FieldNames.DsGrupo, Captions.DsGrupo, 30);
            this.cad_mtmd_subgrupo_descricao = new MVC.DTO.FieldString(FieldNames.DsSubGrupo, Captions.DsSubGrupo, 30);
            this.mtmd_atende_pac_todos_setores = new MVC.DTO.FieldDecimal(FieldNames.AtendeTodosSetores, Captions.AtendeTodosSetores, DbType.Decimal);
            this.mtmd_ignora_alta = new MVC.DTO.FieldDecimal(FieldNames.IgnoraAlta, Captions.IgnoraAlta, DbType.Decimal);
            this.mtmd_ignora_alta_horas_ate = new MVC.DTO.FieldDecimal(FieldNames.IgnoraAltaHorasAte, Captions.IgnoraAltaHorasAte, DbType.Decimal);                       
            this.mtmd_consome_centro_custo = new MVC.DTO.FieldDecimal(FieldNames.ConsomeParaOutroCentroCusto, Captions.ConsomeParaOutroCentroCusto, DbType.Decimal);
            this.mtmd_atende_pac_todas_unidades = new MVC.DTO.FieldDecimal(FieldNames.AtendeTodasUnidades, Captions.AtendeTodasUnidades, DbType.Decimal);
            this.mtmd_consome_direto_paciente = new MVC.DTO.FieldDecimal(FieldNames.GerandoPedidoAutomatico, Captions.GerandoPedidoAutomatico, DbType.Decimal);
            this.mtmd_estoque_unificado_hac = new MVC.DTO.FieldDecimal(FieldNames.EstoqueUnificadoHAC, Captions.EstoqueUnificadoHAC, DbType.Decimal);
            this.mtmd_solicita_kit = new MVC.DTO.FieldDecimal(FieldNames.SolicitaKit, Captions.SolicitaKit, DbType.Decimal);
            this.mtmd_controla_consumo_pac = new MVC.DTO.FieldDecimal(FieldNames.ControlaConsumoPaciente, Captions.ControlaConsumoPaciente, DbType.Decimal);
            this.mtmd_controla_cons_pac_data = new MVC.DTO.FieldDateTime(FieldNames.DataControlaConsumoPaciente, Captions.DataControlaConsumoPaciente);
            this.mtmd_fun_id_funcionalidade = new MVC.DTO.FieldDecimal(FieldNames.IdFuncionalidade, Captions.IdFuncionalidade, DbType.Decimal);
        }
 
        #region FieldNames

        public struct FieldNames
        {
			public const string IdtLocal="CAD_LAT_ID_LOCAL_ATENDIMENTO";
		    public const string IdtUnidade="CAD_UNI_ID_UNIDADE";
		    public const string Idtsetor="CAD_SET_ID";
            public const string IdtGrupo = "CAD_MTMD_GRUPO_ID";
            public const string IdtSubGrupo = "CAD_MTMD_SUBGRUPO_ID";
            public const string DsGrupo = "CAD_MTMD_GRUPO_DESCRICAO";
            public const string DsSubGrupo = "CAD_MTMD_SUBGRUPO_DESCRICAO";
            public const string AtendeTodosSetores = "MTMD_ATENDE_PAC_TODOS_SETORES";

            public const string IgnoraAlta = "MTMD_IGNORA_ALTA";
            public const string ConsomeParaOutroCentroCusto = "MTMD_CONSOME_CENTRO_CUSTO";

            public const string AtendeTodasUnidades = "MTMD_ATENDE_PAC_TODAS_UNIDADES";
            public const string GerandoPedidoAutomatico = "MTMD_CONSOME_DIRETO_PACIENTE";
            public const string IgnoraAltaHorasAte = "MTMD_IGNORA_ALTA_HORAS_ATE";
            public const string EstoqueUnificadoHAC = "MTMD_ESTOQUE_UNIFICADO_HAC";
            public const string SolicitaKit = "MTMD_SOLICITA_KIT";
            public const string ControlaConsumoPaciente = "MTMD_CONTROLA_CONSUMO_PAC";
            public const string DataControlaConsumoPaciente = "MTMD_CONTROLA_CONS_PAC_DATA";
            public const string IdFuncionalidade = "MTMD_FUN_ID_FUNCIONALIDADE";
        }		

        #endregion

        #region Captions

        public struct Captions
        {
			public const string IdtLocal="IDTLOCAL";
	        public const string IdtUnidade="IDTUNIDADE";
	        public const string Idtsetor="IDTSETOR";
            public const string IdtGrupo = "CADMTMDGRUPOID";
            public const string IdtSubGrupo = "CADMTMDSUBGRUPOID";
            public const string DsGrupo = "GRUPODESCRICAO";
            public const string DsSubGrupo = "SUBGRUPODESCRICAO";
            public const string AtendeTodosSetores = "ATENDETODOSSETORES";

            public const string IgnoraAlta = "IGNORAALTA";

            public const string ConsomeParaOutroCentroCusto = "CONSOMEPARAOUTROCENTROCUSTO";

            public const string AtendeTodasUnidades = "ATENDETODASUNIDADES";
            public const string GerandoPedidoAutomatico = "GerandoPedidoAutomatico";

            public const string IgnoraAltaHorasAte = "MTMDIGNORAALTAHORASATE";
            public const string EstoqueUnificadoHAC = "MTMDESTOQUEUNIFICADOHAC";
            public const string SolicitaKit = "MTMDSOLICITAKIT";
            public const string ControlaConsumoPaciente = "MTMDCONTROLACONSUMOPAC";
            public const string DataControlaConsumoPaciente = "MTMDCONTROLACONSPACDATA";
            public const string IdFuncionalidade = "FUNIDFUNCIONALIDADE";
        }		

        #endregion
		
        #region Atributos Publicos
		
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
		
		public MVC.DTO.FieldDecimal Idtsetor
		{
			get { return cad_set_id; }
			set { cad_set_id = value; }
		}

        public MVC.DTO.FieldDecimal IdtGrupo
        {
            get { return cad_mtmd_grupo_id; }
            set { cad_mtmd_grupo_id = value; }
        }

        public MVC.DTO.FieldDecimal IdtSubGrupo
        {
            get { return cad_mtmd_subgrupo_id; }
            set { cad_mtmd_subgrupo_id = value; }
        }

        public MVC.DTO.FieldString DsGrupo
        {
            get { return cad_mtmd_grupo_descricao; }
            set { cad_mtmd_grupo_descricao = value; }
        }

        public MVC.DTO.FieldString DsSubGrupo
        {
            get { return cad_mtmd_subgrupo_descricao; }
            set { cad_mtmd_subgrupo_descricao = value; }
        }

        /// <summary>
        /// Informa se o setor pode atender paciente internado em outro setor diferente do que ele vai consumir
        /// </summary>
        public MVC.DTO.FieldDecimal AtendeTodosSetores
        {
            get { return mtmd_atende_pac_todos_setores; }
            set { mtmd_atende_pac_todos_setores = value; }
        }

        /// <summary>
        /// Informa se setor pode ignorar a data da alta para buscar atendimento, OBS: Conta faturada pode ser visualizada não permite alteração
        /// </summary>
        public MVC.DTO.FieldDecimal IgnoraAlta
        {
            get { return mtmd_ignora_alta; }
            set { mtmd_ignora_alta = value; }
        }

        /// <summary>
        /// Verifica se Setor esta configurado para consumir produtos do seu estoque para outro setor
        /// </summary>
        public MVC.DTO.FieldDecimal ConsomeParaOutroCentroCusto
        {
            get { return mtmd_consome_centro_custo; }
            set { mtmd_consome_centro_custo = value; }
        }

        /// <summary>
        /// Verifia se pode consumir para pacientes de outras unidades
        /// </summary>
        public MVC.DTO.FieldDecimal AtendeTodasUnidades
        {
            get { return mtmd_atende_pac_todas_unidades; }
            set { mtmd_atende_pac_todas_unidades = value; }
        }

        /// <summary>
        /// Verifica se pedidos dispensados pelo almoxarifado são enviados direto para conta do paciente
        /// </summary>
        public MVC.DTO.FieldDecimal GerandoPedidoAutomatico
        {
            get { return mtmd_consome_direto_paciente; }
            set { mtmd_consome_direto_paciente = value; }
        }

        /// <summary>
        /// Informa se setor pode ignorar a data da alta até um limite de horas após a alta, para buscar atendimento
        /// </summary>
        public MVC.DTO.FieldDecimal IgnoraAltaHorasAte
        {
            get { return mtmd_ignora_alta_horas_ate; }
            set { mtmd_ignora_alta_horas_ate = value; }
        }

        public MVC.DTO.FieldDecimal EstoqueUnificadoHAC
        {
            get { return mtmd_estoque_unificado_hac; }
            set { mtmd_estoque_unificado_hac = value; }
        }

        public MVC.DTO.FieldDecimal SolicitaKit
        {
            get { return mtmd_solicita_kit; }
            set { mtmd_solicita_kit = value; }
        }

        public MVC.DTO.FieldDecimal ControlaConsumoPaciente
        {
            get { return mtmd_controla_consumo_pac; }
            set { mtmd_controla_consumo_pac = value; }
        }

        public MVC.DTO.FieldDateTime DataControlaConsumoPaciente
        {
            get { return mtmd_controla_cons_pac_data; }
            set { mtmd_controla_cons_pac_data = value; }
        }

        public MVC.DTO.FieldDecimal IdFuncionalidade
        {
            get { return mtmd_fun_id_funcionalidade; }
            set { mtmd_fun_id_funcionalidade = value; }
        }

		#endregion

        #region Operators

        public static explicit operator MatMedSetorConfigDTO(DataRow row)
        {
            MatMedSetorConfigDTO  dto = new MatMedSetorConfigDTO();
			
			dto.IdtLocal.Value = row[FieldNames.IdtLocal].ToString();
		
			dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();
		
			dto.Idtsetor.Value = row[FieldNames.Idtsetor].ToString();

            dto.IdtGrupo.Value = row[FieldNames.IdtGrupo].ToString();

            dto.IdtSubGrupo.Value = row[FieldNames.IdtSubGrupo].ToString();

            dto.DsGrupo.Value = row[FieldNames.DsGrupo].ToString();

            dto.DsSubGrupo.Value = row[FieldNames.DsSubGrupo].ToString();

            dto.AtendeTodosSetores.Value = row[FieldNames.AtendeTodosSetores].ToString();

            dto.IgnoraAlta.Value = row[FieldNames.IgnoraAlta].ToString();

            dto.ConsomeParaOutroCentroCusto.Value = row[FieldNames.ConsomeParaOutroCentroCusto].ToString();

            dto.AtendeTodasUnidades.Value = row[FieldNames.AtendeTodasUnidades].ToString();

            dto.GerandoPedidoAutomatico.Value = row[FieldNames.GerandoPedidoAutomatico].ToString();

            dto.IgnoraAltaHorasAte.Value = row[FieldNames.IgnoraAltaHorasAte].ToString();

            dto.EstoqueUnificadoHAC.Value = row[FieldNames.EstoqueUnificadoHAC].ToString();

            dto.SolicitaKit.Value = row[FieldNames.SolicitaKit].ToString();

            dto.ControlaConsumoPaciente.Value = row[FieldNames.ControlaConsumoPaciente].ToString();

            dto.DataControlaConsumoPaciente.Value = row[FieldNames.DataControlaConsumoPaciente].ToString();

            dto.IdFuncionalidade.Value = row[FieldNames.IdFuncionalidade].ToString();
            return dto;
        }

        public static explicit operator MatMedSetorConfigDTO(XmlDocument xml)
        {
            MatMedSetorConfigDTO dto = new MatMedSetorConfigDTO();
			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal) != null) dto.IdtLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.Idtsetor) != null) dto.Idtsetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idtsetor).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtGrupo) != null) dto.IdtGrupo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtGrupo).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSubGrupo) != null) dto.IdtSubGrupo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSubGrupo).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsGrupo) != null) dto.DsGrupo.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsGrupo).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsSubGrupo) != null) dto.DsSubGrupo.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsSubGrupo).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.AtendeTodosSetores) != null) dto.AtendeTodosSetores.Value = xml.FirstChild.SelectSingleNode(FieldNames.AtendeTodosSetores).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IgnoraAlta) != null) dto.IgnoraAlta.Value = xml.FirstChild.SelectSingleNode(FieldNames.IgnoraAlta).InnerText;
                        
            if (xml.FirstChild.SelectSingleNode(FieldNames.ConsomeParaOutroCentroCusto) != null) dto.ConsomeParaOutroCentroCusto.Value = xml.FirstChild.SelectSingleNode(FieldNames.ConsomeParaOutroCentroCusto).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.AtendeTodasUnidades) != null) dto.AtendeTodasUnidades.Value = xml.FirstChild.SelectSingleNode(FieldNames.AtendeTodasUnidades).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.GerandoPedidoAutomatico) != null) dto.GerandoPedidoAutomatico.Value = xml.FirstChild.SelectSingleNode(FieldNames.GerandoPedidoAutomatico).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IgnoraAltaHorasAte) != null) dto.IgnoraAltaHorasAte.Value = xml.FirstChild.SelectSingleNode(FieldNames.IgnoraAltaHorasAte).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.EstoqueUnificadoHAC) != null) dto.EstoqueUnificadoHAC.Value = xml.FirstChild.SelectSingleNode(FieldNames.EstoqueUnificadoHAC).InnerText;
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdtLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocal, null);
			
            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);
			
            XmlNode nodeIdtsetor = xml.CreateNode(XmlNodeType.Element, FieldNames.Idtsetor, null);

            XmlNode nodeIdtGrupo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtGrupo, null);

            XmlNode nodeIdtSubGrupo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSubGrupo, null);

            XmlNode nodeGrupoDescricao = xml.CreateNode(XmlNodeType.Element, FieldNames.DsGrupo, null);

            XmlNode nodeSubGrupoDescricao = xml.CreateNode(XmlNodeType.Element, FieldNames.DsSubGrupo, null);

            XmlNode nodeAtendeTodosSetores = xml.CreateNode(XmlNodeType.Element, FieldNames.AtendeTodosSetores, null);

            XmlNode nodeIgnoraAlta = xml.CreateNode(XmlNodeType.Element, FieldNames.IgnoraAlta, null);

            XmlNode nodeConsomeParaOutroCentroCusto = xml.CreateNode(XmlNodeType.Element, FieldNames.ConsomeParaOutroCentroCusto, null);

            XmlNode nodeAtendeTodasUnidades = xml.CreateNode(XmlNodeType.Element, FieldNames.AtendeTodasUnidades, null);

            XmlNode nodeGerandoPedidoAutomatico = xml.CreateNode(XmlNodeType.Element, FieldNames.GerandoPedidoAutomatico, null);

            XmlNode nodeIgnoraAltaHorasAte = xml.CreateNode(XmlNodeType.Element, FieldNames.IgnoraAltaHorasAte, null);

            XmlNode nodeEstoqueUnificadoHAC = xml.CreateNode(XmlNodeType.Element, FieldNames.EstoqueUnificadoHAC, null);

			if (!this.IdtLocal.Value.IsNull) nodeIdtLocal.InnerText = this.IdtLocal.Value;
			
			if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;
			
			if (!this.Idtsetor.Value.IsNull) nodeIdtsetor.InnerText = this.Idtsetor.Value;

            if (!this.IdtGrupo.Value.IsNull) nodeIdtGrupo.InnerText = this.IdtGrupo.Value;

            if (!this.IdtSubGrupo.Value.IsNull) nodeIdtSubGrupo.InnerText = this.IdtSubGrupo.Value;

            if (!this.DsGrupo.Value.IsNull) nodeGrupoDescricao.InnerText = this.DsGrupo.Value;

            if (!this.DsSubGrupo.Value.IsNull) nodeSubGrupoDescricao.InnerText = this.DsSubGrupo.Value;

            if (!this.AtendeTodosSetores.Value.IsNull) nodeAtendeTodosSetores.InnerText = this.AtendeTodosSetores.Value;

            if (!this.IgnoraAlta.Value.IsNull) nodeIgnoraAlta.InnerText = this.IgnoraAlta.Value;

            if (!this.IgnoraAltaHorasAte.Value.IsNull) nodeIgnoraAltaHorasAte.InnerText = this.IgnoraAltaHorasAte.Value;

            if (!this.ConsomeParaOutroCentroCusto.Value.IsNull) nodeConsomeParaOutroCentroCusto.InnerText = this.ConsomeParaOutroCentroCusto.Value;

            if (!this.AtendeTodasUnidades.Value.IsNull) nodeAtendeTodasUnidades.InnerText = this.AtendeTodasUnidades.Value;

            if (!this.GerandoPedidoAutomatico.Value.IsNull) nodeGerandoPedidoAutomatico.InnerText = this.GerandoPedidoAutomatico.Value;

            if (!this.EstoqueUnificadoHAC.Value.IsNull) nodeEstoqueUnificadoHAC.InnerText = this.EstoqueUnificadoHAC.Value;

            nodeData.AppendChild(nodeIdtLocal);
			
            nodeData.AppendChild(nodeIdtUnidade);
			
            nodeData.AppendChild(nodeIdtsetor);

            nodeData.AppendChild(nodeIdtGrupo);

            nodeData.AppendChild(nodeIdtSubGrupo);

            nodeData.AppendChild(nodeGrupoDescricao);

            nodeData.AppendChild(nodeSubGrupoDescricao);

            nodeData.AppendChild(nodeAtendeTodosSetores);

            nodeData.AppendChild(nodeIgnoraAlta);

            nodeData.AppendChild(nodeConsomeParaOutroCentroCusto);

            nodeData.AppendChild(nodeAtendeTodasUnidades);

            nodeData.AppendChild(nodeGerandoPedidoAutomatico);

            nodeData.AppendChild(nodeIgnoraAltaHorasAte);

            nodeData.AppendChild(nodeEstoqueUnificadoHAC);

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(MatMedSetorConfigDTO dto)
        {
            MatMedSetorConfigDataTable dtb = new MatMedSetorConfigDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.IdtLocal] = dto.IdtLocal.Value;
			
            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;
			
            dtr[FieldNames.Idtsetor] = dto.Idtsetor.Value;

            dtr[FieldNames.IdtGrupo] = dto.IdtGrupo.Value;

            dtr[FieldNames.IdtSubGrupo] = dto.IdtSubGrupo.Value;

            dtr[FieldNames.DsGrupo] = dto.DsGrupo.Value;

            dtr[FieldNames.DsSubGrupo] = dto.DsSubGrupo.Value;

            dtr[FieldNames.AtendeTodosSetores] = dto.AtendeTodosSetores.Value;

            dtr[FieldNames.IgnoraAlta] = dto.IgnoraAlta.Value;

            dtr[FieldNames.ConsomeParaOutroCentroCusto] = dto.ConsomeParaOutroCentroCusto.Value;

            dtr[FieldNames.AtendeTodasUnidades] = dto.AtendeTodasUnidades.Value;

            dtr[FieldNames.GerandoPedidoAutomatico] = dto.GerandoPedidoAutomatico.Value;

            dtr[FieldNames.IgnoraAltaHorasAte] = dto.IgnoraAltaHorasAte.Value;

            dtr[FieldNames.EstoqueUnificadoHAC] = dto.EstoqueUnificadoHAC.Value;

            dtr[FieldNames.SolicitaKit] = dto.SolicitaKit.Value;

            dtr[FieldNames.ControlaConsumoPaciente] = dto.ControlaConsumoPaciente.Value;

            dtr[FieldNames.DataControlaConsumoPaciente] = dto.DataControlaConsumoPaciente.Value;

            dtr[FieldNames.IdFuncionalidade] = dto.IdFuncionalidade.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(MatMedSetorConfigDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}