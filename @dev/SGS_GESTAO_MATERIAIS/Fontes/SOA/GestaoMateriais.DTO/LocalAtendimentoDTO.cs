
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
	/// Classe Entidade LocalAtendimentoDataTable
	/// </summary>
	[Serializable()]
	public class LocalAtendimentoDataTable : DataTable
	{
		
	    public LocalAtendimentoDataTable()
            : base()
        {
            this.TableName = "DADOS";

		this.Columns.Add(LocalAtendimentoDTO.FieldNames.Idt, typeof(Decimal));
		this.Columns.Add(LocalAtendimentoDTO.FieldNames.DsLocalAtendimento, typeof(String));
		this.Columns.Add(LocalAtendimentoDTO.FieldNames.AtivoOK, typeof(String));
		this.Columns.Add(LocalAtendimentoDTO.FieldNames.DtAtualizacao, typeof(DateTime));
		this.Columns.Add(LocalAtendimentoDTO.FieldNames.IdtUsuario, typeof(Decimal));
		this.Columns.Add(LocalAtendimentoDTO.FieldNames.CdLocalAtendimento, typeof(String));
        this.Columns.Add(LocalAtendimentoDTO.FieldNames.IdtUnidade, typeof(Decimal));


			

            DataColumn[] primaryKey = { this.Columns[LocalAtendimentoDTO.FieldNames.Idt] };

            this.PrimaryKey = primaryKey;
        }
		
        protected LocalAtendimentoDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public LocalAtendimentoDTO TypedRow(int index)
        {
            return (LocalAtendimentoDTO)this.Rows[index];
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

        public void Add(LocalAtendimentoDTO dto)
        {
            DataRow dtr = this.NewRow();


		if (!dto.Idt.Value.IsNull) dtr[LocalAtendimentoDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		if (!dto.DsLocalAtendimento.Value.IsNull) dtr[LocalAtendimentoDTO.FieldNames.DsLocalAtendimento] = (String)dto.DsLocalAtendimento.Value;
		if (!dto.AtivoOK.Value.IsNull) dtr[LocalAtendimentoDTO.FieldNames.AtivoOK] = (String)dto.AtivoOK.Value;
		if (!dto.DtAtualizacao.Value.IsNull) dtr[LocalAtendimentoDTO.FieldNames.DtAtualizacao] = (DateTime)dto.DtAtualizacao.Value;
		if (!dto.IdtUsuario.Value.IsNull) dtr[LocalAtendimentoDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;
		if (!dto.CdLocalAtendimento.Value.IsNull) dtr[LocalAtendimentoDTO.FieldNames.CdLocalAtendimento] = (String)dto.CdLocalAtendimento.Value;
        if (!dto.IdtUnidade.Value.IsNull) dtr[LocalAtendimentoDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;

			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class LocalAtendimentoDTO : MVC.DTO.DTOBase
    {	
		private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
		private MVC.DTO.FieldString cad_lat_ds_local_atendimento;
		private MVC.DTO.FieldString cad_lat_fl_ativo_ok;
		private MVC.DTO.FieldDateTime cad_lat_dt_ultima_atualizacao;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario;
		private MVC.DTO.FieldString cad_lat_cd_local_atendimento;
        private MVC.DTO.FieldDecimal cad_uni_id_unidade;

        public LocalAtendimentoDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
		this.cad_lat_id_local_atendimento= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		this.cad_lat_ds_local_atendimento= new MVC.DTO.FieldString(FieldNames.DsLocalAtendimento,Captions.DsLocalAtendimento, 50);
		this.cad_lat_fl_ativo_ok= new MVC.DTO.FieldString(FieldNames.AtivoOK,Captions.AtivoOK, 1);
		this.cad_lat_dt_ultima_atualizacao= new MVC.DTO.FieldDateTime(FieldNames.DtAtualizacao,Captions.DtAtualizacao);
		this.seg_usu_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario,Captions.IdtUsuario, DbType.Decimal);
		this.cad_lat_cd_local_atendimento= new MVC.DTO.FieldString(FieldNames.CdLocalAtendimento,Captions.CdLocalAtendimento, 4);
        this.cad_uni_id_unidade = new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade, Captions.IdtUnidade, DbType.Decimal);
		
        }
 
        #region FieldNames

        public struct FieldNames
        {
		public const string Idt="CAD_LAT_ID_LOCAL_ATENDIMENTO";
		public const string DsLocalAtendimento="CAD_LAT_DS_LOCAL_ATENDIMENTO";
		public const string AtivoOK="CAD_LAT_FL_ATIVO_OK";
		public const string DtAtualizacao="CAD_LAT_DT_ULTIMA_ATUALIZACAO";
		public const string IdtUsuario="SEG_USU_ID_USUARIO";
		public const string CdLocalAtendimento="CAD_LAT_CD_LOCAL_ATENDIMENTO";
        public const string IdtUnidade = "cad_uni_id_unidade";
		
        }		

        #endregion

        #region Captions
        public struct Captions
        {
		public const string Idt="IDT";
		public const string DsLocalAtendimento="DSLOCALATENDIMENTO";
		public const string AtivoOK="ATIVOOK";
		public const string DtAtualizacao="DTATUALIZACAO";
		public const string IdtUsuario="USUARIOIDT";
		public const string CdLocalAtendimento="CDLOCALATENDIMENTO";
        public const string IdtUnidade = "CADUNIIDUNIDADE";
		
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal Idt
		{
			get { return cad_lat_id_local_atendimento; }
			set { cad_lat_id_local_atendimento = value; }
		}
		
		public MVC.DTO.FieldString DsLocalAtendimento
		{
			get { return cad_lat_ds_local_atendimento; }
			set { cad_lat_ds_local_atendimento = value; }
		}
		
		public MVC.DTO.FieldString AtivoOK
		{
			get { return cad_lat_fl_ativo_ok; }
			set { cad_lat_fl_ativo_ok = value; }
		}
		
		public MVC.DTO.FieldDateTime DtAtualizacao
		{
			get { return cad_lat_dt_ultima_atualizacao; }
			set { cad_lat_dt_ultima_atualizacao = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtUsuario
		{
			get { return seg_usu_id_usuario; }
			set { seg_usu_id_usuario = value; }
		}
		
		public MVC.DTO.FieldString CdLocalAtendimento
		{
			get { return cad_lat_cd_local_atendimento; }
			set { cad_lat_cd_local_atendimento = value; }
		}

        public MVC.DTO.FieldDecimal IdtUnidade
        {
            get { return cad_uni_id_unidade; }
            set { cad_uni_id_unidade = value; }
        }
			
		#endregion


        #region Operators

        public static explicit operator LocalAtendimentoDTO(DataRow row)
        {
            LocalAtendimentoDTO  dto = new LocalAtendimentoDTO();
			
				dto.Idt.Value = row[FieldNames.Idt].ToString();
			
				dto.DsLocalAtendimento.Value = row[FieldNames.DsLocalAtendimento].ToString();
			
				dto.AtivoOK.Value = row[FieldNames.AtivoOK].ToString();
			
				dto.DtAtualizacao.Value = row[FieldNames.DtAtualizacao].ToString();
			
				dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();
			
				dto.CdLocalAtendimento.Value = row[FieldNames.CdLocalAtendimento].ToString();
			
			
            return dto;
        }

        public static explicit operator LocalAtendimentoDTO(XmlDocument xml)
        {
            LocalAtendimentoDTO dto = new LocalAtendimentoDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DsLocalAtendimento) != null) dto.DsLocalAtendimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsLocalAtendimento).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.AtivoOK) != null) dto.AtivoOK.Value = xml.FirstChild.SelectSingleNode(FieldNames.AtivoOK).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DtAtualizacao) != null) dto.DtAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtAtualizacao).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.CdLocalAtendimento) != null) dto.CdLocalAtendimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdLocalAtendimento).InnerText;			
			
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeDsLocalAtendimento = xml.CreateNode(XmlNodeType.Element, FieldNames.DsLocalAtendimento, null);
			
            XmlNode nodeAtivoOK = xml.CreateNode(XmlNodeType.Element, FieldNames.AtivoOK, null);
			
            XmlNode nodeDtAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DtAtualizacao, null);
			
            XmlNode nodeUsuarioIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);
			
            XmlNode nodeCdLocalAtendimento = xml.CreateNode(XmlNodeType.Element, FieldNames.CdLocalAtendimento, null);
			
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			
			if (!this.DsLocalAtendimento.Value.IsNull) nodeDsLocalAtendimento.InnerText = this.DsLocalAtendimento.Value;
			
			if (!this.AtivoOK.Value.IsNull) nodeAtivoOK.InnerText = this.AtivoOK.Value;
			
			if (!this.DtAtualizacao.Value.IsNull) nodeDtAtualizacao.InnerText = this.DtAtualizacao.Value;
			
			if (!this.IdtUsuario.Value.IsNull) nodeUsuarioIdt.InnerText = this.IdtUsuario.Value;
			
			if (!this.CdLocalAtendimento.Value.IsNull) nodeCdLocalAtendimento.InnerText = this.CdLocalAtendimento.Value;
			
			
            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodeDsLocalAtendimento);
			
            nodeData.AppendChild(nodeAtivoOK);
			
            nodeData.AppendChild(nodeDtAtualizacao);
			
            nodeData.AppendChild(nodeUsuarioIdt);
			
            nodeData.AppendChild(nodeCdLocalAtendimento);
						
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(LocalAtendimentoDTO dto)
        {
            LocalAtendimentoDataTable dtb = new LocalAtendimentoDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
			
            dtr[FieldNames.DsLocalAtendimento] = dto.DsLocalAtendimento.Value;
			
            dtr[FieldNames.AtivoOK] = dto.AtivoOK.Value;
			
            dtr[FieldNames.DtAtualizacao] = dto.DtAtualizacao.Value;
			
            dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;
			
            dtr[FieldNames.CdLocalAtendimento] = dto.CdLocalAtendimento.Value;
			
            return dtr;
        }

        public static explicit operator XmlDocument(LocalAtendimentoDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


