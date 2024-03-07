
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
	/// Classe Entidade UnidadeDataTable
	/// </summary>
	[Serializable()]
	public class UnidadeDataTable : DataTable
	{
		
	    public UnidadeDataTable()
            : base()
        {
            this.TableName = "DADOS";

		    this.Columns.Add(UnidadeDTO.FieldNames.Idt, typeof(Decimal));
		    this.Columns.Add(UnidadeDTO.FieldNames.Imagem, typeof(String));
		    this.Columns.Add(UnidadeDTO.FieldNames.Status, typeof(String));
		    this.Columns.Add(UnidadeDTO.FieldNames.DtStatus, typeof(DateTime));
		    this.Columns.Add(UnidadeDTO.FieldNames.GravaAtendimentoFL, typeof(String));
		    this.Columns.Add(UnidadeDTO.FieldNames.LiberaAgendaFL, typeof(String));
		    this.Columns.Add(UnidadeDTO.FieldNames.GravaCodPacFL, typeof(String));
		    this.Columns.Add(UnidadeDTO.FieldNames.UnidadeMasterFL, typeof(Decimal));
		    this.Columns.Add(UnidadeDTO.FieldNames.IdtPessoa, typeof(Decimal));
		    this.Columns.Add(UnidadeDTO.FieldNames.NrCnes, typeof(String));
		    this.Columns.Add(UnidadeDTO.FieldNames.DtAtualizacao, typeof(DateTime));
		    this.Columns.Add(UnidadeDTO.FieldNames.IdtUsuario, typeof(Decimal));
		    this.Columns.Add(UnidadeDTO.FieldNames.CdHospitalar, typeof(String));
		    this.Columns.Add(UnidadeDTO.FieldNames.UnidHospitalar, typeof(String));
		    this.Columns.Add(UnidadeDTO.FieldNames.CronicoOK, typeof(String));
		    this.Columns.Add(UnidadeDTO.FieldNames.PrioridadeOK, typeof(String));
		    this.Columns.Add(UnidadeDTO.FieldNames.DsUnidade, typeof(String));


			

            DataColumn[] primaryKey = { this.Columns[UnidadeDTO.FieldNames.Idt] };

            this.PrimaryKey = primaryKey;
        }
		
        protected UnidadeDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public UnidadeDTO TypedRow(int index)
        {
            return (UnidadeDTO)this.Rows[index];
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

        public void Add(UnidadeDTO dto)
        {
            DataRow dtr = this.NewRow();


					if (!dto.Idt.Value.IsNull) dtr[UnidadeDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		if (!dto.Imagem.Value.IsNull) dtr[UnidadeDTO.FieldNames.Imagem] = (String)dto.Imagem.Value;
		if (!dto.Status.Value.IsNull) dtr[UnidadeDTO.FieldNames.Status] = (String)dto.Status.Value;
		if (!dto.DtStatus.Value.IsNull) dtr[UnidadeDTO.FieldNames.DtStatus] = (DateTime)dto.DtStatus.Value;
		if (!dto.GravaAtendimentoFL.Value.IsNull) dtr[UnidadeDTO.FieldNames.GravaAtendimentoFL] = (String)dto.GravaAtendimentoFL.Value;
		if (!dto.LiberaAgendaFL.Value.IsNull) dtr[UnidadeDTO.FieldNames.LiberaAgendaFL] = (String)dto.LiberaAgendaFL.Value;
		if (!dto.GravaCodPacFL.Value.IsNull) dtr[UnidadeDTO.FieldNames.GravaCodPacFL] = (String)dto.GravaCodPacFL.Value;
		if (!dto.UnidadeMasterFL.Value.IsNull) dtr[UnidadeDTO.FieldNames.UnidadeMasterFL] = (Decimal)dto.UnidadeMasterFL.Value;
		if (!dto.IdtPessoa.Value.IsNull) dtr[UnidadeDTO.FieldNames.IdtPessoa] = (Decimal)dto.IdtPessoa.Value;
		if (!dto.NrCnes.Value.IsNull) dtr[UnidadeDTO.FieldNames.NrCnes] = (String)dto.NrCnes.Value;
		if (!dto.DtAtualizacao.Value.IsNull) dtr[UnidadeDTO.FieldNames.DtAtualizacao] = (DateTime)dto.DtAtualizacao.Value;
		if (!dto.IdtUsuario.Value.IsNull) dtr[UnidadeDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;
		if (!dto.CdHospitalar.Value.IsNull) dtr[UnidadeDTO.FieldNames.CdHospitalar] = (String)dto.CdHospitalar.Value;
		if (!dto.UnidHospitalar.Value.IsNull) dtr[UnidadeDTO.FieldNames.UnidHospitalar] = (String)dto.UnidHospitalar.Value;
		if (!dto.CronicoOK.Value.IsNull) dtr[UnidadeDTO.FieldNames.CronicoOK] = (String)dto.CronicoOK.Value;
		if (!dto.PrioridadeOK.Value.IsNull) dtr[UnidadeDTO.FieldNames.PrioridadeOK] = (String)dto.PrioridadeOK.Value;
		if (!dto.DsUnidade.Value.IsNull) dtr[UnidadeDTO.FieldNames.DsUnidade] = (String)dto.DsUnidade.Value;

			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class UnidadeDTO : MVC.DTO.DTOBase
    {	
			private MVC.DTO.FieldDecimal cad_uni_id_unidade;
		private MVC.DTO.FieldString cad_uni_ds_imagem_associada;
		private MVC.DTO.FieldString cad_uni_fl_status;
		private MVC.DTO.FieldDateTime cad_uni_dt_ultimo_status;
		private MVC.DTO.FieldString cad_uni_fl_grava_atend_ok;
		private MVC.DTO.FieldString cad_uni_fl_libera_agenda_ok;
		private MVC.DTO.FieldString cad_uni_fl_grava_cd_pac_ok;
		private MVC.DTO.FieldDecimal cad_uni_id_unidade_master;
		private MVC.DTO.FieldDecimal cad_pes_id_pessoa;
		private MVC.DTO.FieldString cad_uni_nr_cnes;
		private MVC.DTO.FieldDateTime cad_uni_dt_ultima_atualizacao;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario;
		private MVC.DTO.FieldString cad_uni_cd_hospitalar;
		private MVC.DTO.FieldString cad_uni_cd_unid_hospitalar;
		private MVC.DTO.FieldString cad_uni_fl_cronico_ok;
		private MVC.DTO.FieldString cad_uni_fl_prioridade_ok;
		private MVC.DTO.FieldString cad_uni_ds_unidade;

        public UnidadeDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
				this.cad_uni_id_unidade= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		this.cad_uni_ds_imagem_associada= new MVC.DTO.FieldString(FieldNames.Imagem,Captions.Imagem, 100);
		this.cad_uni_fl_status= new MVC.DTO.FieldString(FieldNames.Status,Captions.Status, 1);
		this.cad_uni_dt_ultimo_status= new MVC.DTO.FieldDateTime(FieldNames.DtStatus,Captions.DtStatus);
		this.cad_uni_fl_grava_atend_ok= new MVC.DTO.FieldString(FieldNames.GravaAtendimentoFL,Captions.GravaAtendimentoFL, 1);
		this.cad_uni_fl_libera_agenda_ok= new MVC.DTO.FieldString(FieldNames.LiberaAgendaFL,Captions.LiberaAgendaFL, 1);
		this.cad_uni_fl_grava_cd_pac_ok= new MVC.DTO.FieldString(FieldNames.GravaCodPacFL,Captions.GravaCodPacFL, 1);
		this.cad_uni_id_unidade_master= new MVC.DTO.FieldDecimal(FieldNames.UnidadeMasterFL,Captions.UnidadeMasterFL, DbType.Decimal);
		this.cad_pes_id_pessoa= new MVC.DTO.FieldDecimal(FieldNames.IdtPessoa,Captions.IdtPessoa, DbType.Decimal);
		this.cad_uni_nr_cnes= new MVC.DTO.FieldString(FieldNames.NrCnes,Captions.NrCnes, 7);
		this.cad_uni_dt_ultima_atualizacao= new MVC.DTO.FieldDateTime(FieldNames.DtAtualizacao,Captions.DtAtualizacao);
		this.seg_usu_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario,Captions.IdtUsuario, DbType.Decimal);
		this.cad_uni_cd_hospitalar= new MVC.DTO.FieldString(FieldNames.CdHospitalar,Captions.CdHospitalar, 3);
		this.cad_uni_cd_unid_hospitalar= new MVC.DTO.FieldString(FieldNames.UnidHospitalar,Captions.UnidHospitalar, 4);
		this.cad_uni_fl_cronico_ok= new MVC.DTO.FieldString(FieldNames.CronicoOK,Captions.CronicoOK, 1);
		this.cad_uni_fl_prioridade_ok= new MVC.DTO.FieldString(FieldNames.PrioridadeOK,Captions.PrioridadeOK, 1);
		this.cad_uni_ds_unidade= new MVC.DTO.FieldString(FieldNames.DsUnidade,Captions.DsUnidade, 50);
		
        }
 
        #region FieldNames

        public struct FieldNames
        {
				public const string Idt="CAD_UNI_ID_UNIDADE";
		public const string Imagem="CAD_UNI_DS_IMAGEM_ASSOCIADA";
		public const string Status="CAD_UNI_FL_STATUS";
		public const string DtStatus="CAD_UNI_DT_ULTIMO_STATUS";
		public const string GravaAtendimentoFL="CAD_UNI_FL_GRAVA_ATEND_OK";
		public const string LiberaAgendaFL="CAD_UNI_FL_LIBERA_AGENDA_OK";
		public const string GravaCodPacFL="CAD_UNI_FL_GRAVA_CD_PAC_OK";
		public const string UnidadeMasterFL="CAD_UNI_ID_UNIDADE_MASTER";
		public const string IdtPessoa="CAD_PES_ID_PESSOA";
		public const string NrCnes="CAD_UNI_NR_CNES";
		public const string DtAtualizacao="CAD_UNI_DT_ULTIMA_ATUALIZACAO";
		public const string IdtUsuario="SEG_USU_ID_USUARIO";
		public const string CdHospitalar="CAD_UNI_CD_HOSPITALAR";
		public const string UnidHospitalar="CAD_UNI_CD_UNID_HOSPITALAR";
		public const string CronicoOK="CAD_UNI_FL_CRONICO_OK";
		public const string PrioridadeOK="CAD_UNI_FL_PRIORIDADE_OK";
		public const string DsUnidade="CAD_UNI_DS_UNIDADE";
		
        }		

        #endregion

        #region Captions
        public struct Captions
        {
				public const string Idt="IDT";
		public const string Imagem="IMAGEM";
		public const string Status="STATUS";
		public const string DtStatus="DTSTATUS";
		public const string GravaAtendimentoFL="GRAVAATENDIMENTOFL";
		public const string LiberaAgendaFL="LIBERAAGENDAFL";
		public const string GravaCodPacFL="GRAVACODPACFL";
		public const string UnidadeMasterFL="UNIDADEMASTERFL";
		public const string IdtPessoa="PESSOAIDT";
		public const string NrCnes="NRCNES";
		public const string DtAtualizacao="DTATUALIZACAO";
		public const string IdtUsuario="USUARIOIDT";
		public const string CdHospitalar="CDHOSPITALAR";
		public const string UnidHospitalar="UNIDHOSPITALAR";
		public const string CronicoOK="CRONICOOK";
		public const string PrioridadeOK="PRIORIDADEOK";
		public const string DsUnidade="DSUNIDADE";
		
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal Idt
		{
			get { return cad_uni_id_unidade; }
			set { cad_uni_id_unidade = value; }
		}
		
		public MVC.DTO.FieldString Imagem
		{
			get { return cad_uni_ds_imagem_associada; }
			set { cad_uni_ds_imagem_associada = value; }
		}
		
		public MVC.DTO.FieldString Status
		{
			get { return cad_uni_fl_status; }
			set { cad_uni_fl_status = value; }
		}
		
		public MVC.DTO.FieldDateTime DtStatus
		{
			get { return cad_uni_dt_ultimo_status; }
			set { cad_uni_dt_ultimo_status = value; }
		}
		
		public MVC.DTO.FieldString GravaAtendimentoFL
		{
			get { return cad_uni_fl_grava_atend_ok; }
			set { cad_uni_fl_grava_atend_ok = value; }
		}
		
		public MVC.DTO.FieldString LiberaAgendaFL
		{
			get { return cad_uni_fl_libera_agenda_ok; }
			set { cad_uni_fl_libera_agenda_ok = value; }
		}
		
		public MVC.DTO.FieldString GravaCodPacFL
		{
			get { return cad_uni_fl_grava_cd_pac_ok; }
			set { cad_uni_fl_grava_cd_pac_ok = value; }
		}
		
		public MVC.DTO.FieldDecimal UnidadeMasterFL
		{
			get { return cad_uni_id_unidade_master; }
			set { cad_uni_id_unidade_master = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtPessoa
		{
			get { return cad_pes_id_pessoa; }
			set { cad_pes_id_pessoa = value; }
		}
		
		public MVC.DTO.FieldString NrCnes
		{
			get { return cad_uni_nr_cnes; }
			set { cad_uni_nr_cnes = value; }
		}
		
		public MVC.DTO.FieldDateTime DtAtualizacao
		{
			get { return cad_uni_dt_ultima_atualizacao; }
			set { cad_uni_dt_ultima_atualizacao = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtUsuario
		{
			get { return seg_usu_id_usuario; }
			set { seg_usu_id_usuario = value; }
		}
		
		public MVC.DTO.FieldString CdHospitalar
		{
			get { return cad_uni_cd_hospitalar; }
			set { cad_uni_cd_hospitalar = value; }
		}
		
		public MVC.DTO.FieldString UnidHospitalar
		{
			get { return cad_uni_cd_unid_hospitalar; }
			set { cad_uni_cd_unid_hospitalar = value; }
		}
		
		public MVC.DTO.FieldString CronicoOK
		{
			get { return cad_uni_fl_cronico_ok; }
			set { cad_uni_fl_cronico_ok = value; }
		}
		
		public MVC.DTO.FieldString PrioridadeOK
		{
			get { return cad_uni_fl_prioridade_ok; }
			set { cad_uni_fl_prioridade_ok = value; }
		}
		
		public MVC.DTO.FieldString DsUnidade
		{
			get { return cad_uni_ds_unidade; }
			set { cad_uni_ds_unidade = value; }
		}
					
			
		#endregion


        #region Operators

        public static explicit operator UnidadeDTO(DataRow row)
        {
            UnidadeDTO  dto = new UnidadeDTO();
			
				dto.Idt.Value = row[FieldNames.Idt].ToString();
			
				dto.Imagem.Value = row[FieldNames.Imagem].ToString();
			
				dto.Status.Value = row[FieldNames.Status].ToString();
			
				dto.DtStatus.Value = row[FieldNames.DtStatus].ToString();
			
				dto.GravaAtendimentoFL.Value = row[FieldNames.GravaAtendimentoFL].ToString();
			
				dto.LiberaAgendaFL.Value = row[FieldNames.LiberaAgendaFL].ToString();
			
				dto.GravaCodPacFL.Value = row[FieldNames.GravaCodPacFL].ToString();
			
				dto.UnidadeMasterFL.Value = row[FieldNames.UnidadeMasterFL].ToString();
			
				dto.IdtPessoa.Value = row[FieldNames.IdtPessoa].ToString();
			
				dto.NrCnes.Value = row[FieldNames.NrCnes].ToString();
			
				dto.DtAtualizacao.Value = row[FieldNames.DtAtualizacao].ToString();
			
				dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();
			
				dto.CdHospitalar.Value = row[FieldNames.CdHospitalar].ToString();
			
				dto.UnidHospitalar.Value = row[FieldNames.UnidHospitalar].ToString();
			
				dto.CronicoOK.Value = row[FieldNames.CronicoOK].ToString();
			
				dto.PrioridadeOK.Value = row[FieldNames.PrioridadeOK].ToString();
			
				dto.DsUnidade.Value = row[FieldNames.DsUnidade].ToString();
			
			
            return dto;
        }

        public static explicit operator UnidadeDTO(XmlDocument xml)
        {
            UnidadeDTO dto = new UnidadeDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Imagem) != null) dto.Imagem.Value = xml.FirstChild.SelectSingleNode(FieldNames.Imagem).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Status) != null) dto.Status.Value = xml.FirstChild.SelectSingleNode(FieldNames.Status).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DtStatus) != null) dto.DtStatus.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtStatus).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.GravaAtendimentoFL) != null) dto.GravaAtendimentoFL.Value = xml.FirstChild.SelectSingleNode(FieldNames.GravaAtendimentoFL).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.LiberaAgendaFL) != null) dto.LiberaAgendaFL.Value = xml.FirstChild.SelectSingleNode(FieldNames.LiberaAgendaFL).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.GravaCodPacFL) != null) dto.GravaCodPacFL.Value = xml.FirstChild.SelectSingleNode(FieldNames.GravaCodPacFL).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeMasterFL) != null) dto.UnidadeMasterFL.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeMasterFL).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtPessoa) != null) dto.IdtPessoa.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtPessoa).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.NrCnes) != null) dto.NrCnes.Value = xml.FirstChild.SelectSingleNode(FieldNames.NrCnes).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DtAtualizacao) != null) dto.DtAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtAtualizacao).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.CdHospitalar) != null) dto.CdHospitalar.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdHospitalar).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.UnidHospitalar) != null) dto.UnidHospitalar.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidHospitalar).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.CronicoOK) != null) dto.CronicoOK.Value = xml.FirstChild.SelectSingleNode(FieldNames.CronicoOK).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.PrioridadeOK) != null) dto.PrioridadeOK.Value = xml.FirstChild.SelectSingleNode(FieldNames.PrioridadeOK).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade) != null) dto.DsUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade).InnerText;			
			
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeImagem = xml.CreateNode(XmlNodeType.Element, FieldNames.Imagem, null);
			
            XmlNode nodeStatus = xml.CreateNode(XmlNodeType.Element, FieldNames.Status, null);
			
            XmlNode nodeDtStatus = xml.CreateNode(XmlNodeType.Element, FieldNames.DtStatus, null);
			
            XmlNode nodeGravaAtendimentoFL = xml.CreateNode(XmlNodeType.Element, FieldNames.GravaAtendimentoFL, null);
			
            XmlNode nodeLiberaAgendaFL = xml.CreateNode(XmlNodeType.Element, FieldNames.LiberaAgendaFL, null);
			
            XmlNode nodeGravaCodPacFL = xml.CreateNode(XmlNodeType.Element, FieldNames.GravaCodPacFL, null);
			
            XmlNode nodeUnidadeMasterFL = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeMasterFL, null);
			
            XmlNode nodePessoaIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtPessoa, null);
			
            XmlNode nodeNrCnes = xml.CreateNode(XmlNodeType.Element, FieldNames.NrCnes, null);
			
            XmlNode nodeDtAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DtAtualizacao, null);
			
            XmlNode nodeUsuarioIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);
			
            XmlNode nodeCdHospitalar = xml.CreateNode(XmlNodeType.Element, FieldNames.CdHospitalar, null);
			
            XmlNode nodeUnidHospitalar = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidHospitalar, null);
			
            XmlNode nodeCronicoOK = xml.CreateNode(XmlNodeType.Element, FieldNames.CronicoOK, null);
			
            XmlNode nodePrioridadeOK = xml.CreateNode(XmlNodeType.Element, FieldNames.PrioridadeOK, null);
			
            XmlNode nodeDsUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidade, null);
			
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			
			if (!this.Imagem.Value.IsNull) nodeImagem.InnerText = this.Imagem.Value;
			
			if (!this.Status.Value.IsNull) nodeStatus.InnerText = this.Status.Value;
			
			if (!this.DtStatus.Value.IsNull) nodeDtStatus.InnerText = this.DtStatus.Value;
			
			if (!this.GravaAtendimentoFL.Value.IsNull) nodeGravaAtendimentoFL.InnerText = this.GravaAtendimentoFL.Value;
			
			if (!this.LiberaAgendaFL.Value.IsNull) nodeLiberaAgendaFL.InnerText = this.LiberaAgendaFL.Value;
			
			if (!this.GravaCodPacFL.Value.IsNull) nodeGravaCodPacFL.InnerText = this.GravaCodPacFL.Value;
			
			if (!this.UnidadeMasterFL.Value.IsNull) nodeUnidadeMasterFL.InnerText = this.UnidadeMasterFL.Value;
			
			if (!this.IdtPessoa.Value.IsNull) nodePessoaIdt.InnerText = this.IdtPessoa.Value;
			
			if (!this.NrCnes.Value.IsNull) nodeNrCnes.InnerText = this.NrCnes.Value;
			
			if (!this.DtAtualizacao.Value.IsNull) nodeDtAtualizacao.InnerText = this.DtAtualizacao.Value;
			
			if (!this.IdtUsuario.Value.IsNull) nodeUsuarioIdt.InnerText = this.IdtUsuario.Value;
			
			if (!this.CdHospitalar.Value.IsNull) nodeCdHospitalar.InnerText = this.CdHospitalar.Value;
			
			if (!this.UnidHospitalar.Value.IsNull) nodeUnidHospitalar.InnerText = this.UnidHospitalar.Value;
			
			if (!this.CronicoOK.Value.IsNull) nodeCronicoOK.InnerText = this.CronicoOK.Value;
			
			if (!this.PrioridadeOK.Value.IsNull) nodePrioridadeOK.InnerText = this.PrioridadeOK.Value;
			
			if (!this.DsUnidade.Value.IsNull) nodeDsUnidade.InnerText = this.DsUnidade.Value;
			
			
            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodeImagem);
			
            nodeData.AppendChild(nodeStatus);
			
            nodeData.AppendChild(nodeDtStatus);
			
            nodeData.AppendChild(nodeGravaAtendimentoFL);
			
            nodeData.AppendChild(nodeLiberaAgendaFL);
			
            nodeData.AppendChild(nodeGravaCodPacFL);
			
            nodeData.AppendChild(nodeUnidadeMasterFL);
			
            nodeData.AppendChild(nodePessoaIdt);
			
            nodeData.AppendChild(nodeNrCnes);
			
            nodeData.AppendChild(nodeDtAtualizacao);
			
            nodeData.AppendChild(nodeUsuarioIdt);
			
            nodeData.AppendChild(nodeCdHospitalar);
			
            nodeData.AppendChild(nodeUnidHospitalar);
			
            nodeData.AppendChild(nodeCronicoOK);
			
            nodeData.AppendChild(nodePrioridadeOK);
			
            nodeData.AppendChild(nodeDsUnidade);
						
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(UnidadeDTO dto)
        {
            UnidadeDataTable dtb = new UnidadeDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
			
            dtr[FieldNames.Imagem] = dto.Imagem.Value;
			
            dtr[FieldNames.Status] = dto.Status.Value;
			
            dtr[FieldNames.DtStatus] = dto.DtStatus.Value;
			
            dtr[FieldNames.GravaAtendimentoFL] = dto.GravaAtendimentoFL.Value;
			
            dtr[FieldNames.LiberaAgendaFL] = dto.LiberaAgendaFL.Value;
			
            dtr[FieldNames.GravaCodPacFL] = dto.GravaCodPacFL.Value;
			
            dtr[FieldNames.UnidadeMasterFL] = dto.UnidadeMasterFL.Value;
			
            dtr[FieldNames.IdtPessoa] = dto.IdtPessoa.Value;
			
            dtr[FieldNames.NrCnes] = dto.NrCnes.Value;
			
            dtr[FieldNames.DtAtualizacao] = dto.DtAtualizacao.Value;
			
            dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;
			
            dtr[FieldNames.CdHospitalar] = dto.CdHospitalar.Value;
			
            dtr[FieldNames.UnidHospitalar] = dto.UnidHospitalar.Value;
			
            dtr[FieldNames.CronicoOK] = dto.CronicoOK.Value;
			
            dtr[FieldNames.PrioridadeOK] = dto.PrioridadeOK.Value;
			
            dtr[FieldNames.DsUnidade] = dto.DsUnidade.Value;
			
            return dtr;
        }

        public static explicit operator XmlDocument(UnidadeDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


