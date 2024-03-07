
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
	/// Classe Entidade CodigoBarraDataTable
	/// </summary>
	[Serializable()]
	public class CodigoBarraDataTable : DataTable
	{
		
	    public CodigoBarraDataTable()
            : base()
        {
            this.TableName = "DADOS";

		this.Columns.Add(CodigoBarraDTO.FieldNames.IdtProduto, typeof(Decimal));
		this.Columns.Add(CodigoBarraDTO.FieldNames.IdtFilial, typeof(Decimal));
		this.Columns.Add(CodigoBarraDTO.FieldNames.IdtLote, typeof(Decimal));
		this.Columns.Add(CodigoBarraDTO.FieldNames.CdBarra, typeof(String));


			

            DataColumn[] primaryKey = {  };

            this.PrimaryKey = primaryKey;
        }
		
        protected CodigoBarraDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public CodigoBarraDTO TypedRow(int index)
        {
            return (CodigoBarraDTO)this.Rows[index];
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

        public void Add(CodigoBarraDTO dto)
        {
            DataRow dtr = this.NewRow();


					if (!dto.IdtProduto.Value.IsNull) dtr[CodigoBarraDTO.FieldNames.IdtProduto] = (Decimal)dto.IdtProduto.Value;
		if (!dto.IdtFilial.Value.IsNull) dtr[CodigoBarraDTO.FieldNames.IdtFilial] = (Decimal)dto.IdtFilial.Value;
		if (!dto.IdtLote.Value.IsNull) dtr[CodigoBarraDTO.FieldNames.IdtLote] = (Decimal)dto.IdtLote.Value;
		if (!dto.CdBarra.Value.IsNull) dtr[CodigoBarraDTO.FieldNames.CdBarra] = (String)dto.CdBarra.Value;

			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class CodigoBarraDTO : MVC.DTO.DTOBase
    {	
			private MVC.DTO.FieldDecimal cad_mtmd_id;
		private MVC.DTO.FieldDecimal cad_mtmd_filial_id;
		private MVC.DTO.FieldDecimal mtmd_lotest_id;
		private MVC.DTO.FieldString mtm_cd_barra;

        public CodigoBarraDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
				this.cad_mtmd_id= new MVC.DTO.FieldDecimal(FieldNames.IdtProduto,Captions.IdtProduto, DbType.Decimal);
		this.cad_mtmd_filial_id= new MVC.DTO.FieldDecimal(FieldNames.IdtFilial,Captions.IdtFilial, DbType.Decimal);
		this.mtmd_lotest_id= new MVC.DTO.FieldDecimal(FieldNames.IdtLote,Captions.IdtLote, DbType.Decimal);
		this.mtm_cd_barra= new MVC.DTO.FieldString(FieldNames.CdBarra,Captions.CdBarra, 60);
		
        }
 
        #region FieldNames

        public struct FieldNames
        {
				public const string IdtProduto="CAD_MTMD_ID";
		public const string IdtFilial="CAD_MTMD_FILIAL_ID";
		public const string IdtLote="MTMD_LOTEST_ID";
		public const string CdBarra="MTM_CD_BARRA";
		
        }		

        #endregion

        #region Captions
        public struct Captions
        {
				public const string IdtProduto="IDTPRODUTO";
		public const string IdtFilial="IDTFILIAL";
		public const string IdtLote="IDTLOTE";
		public const string CdBarra="CDBARRA";
		
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal IdtProduto
		{
			get { return cad_mtmd_id; }
			set { cad_mtmd_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtFilial
		{
			get { return cad_mtmd_filial_id; }
			set { cad_mtmd_filial_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtLote
		{
			get { return mtmd_lotest_id; }
			set { mtmd_lotest_id = value; }
		}
		
		public MVC.DTO.FieldString CdBarra
		{
			get { return mtm_cd_barra; }
			set { mtm_cd_barra = value; }
		}
					
			
		#endregion


        #region Operators

        public static explicit operator CodigoBarraDTO(DataRow row)
        {
            CodigoBarraDTO  dto = new CodigoBarraDTO();
			
				dto.IdtProduto.Value = row[FieldNames.IdtProduto].ToString();
			
				dto.IdtFilial.Value = row[FieldNames.IdtFilial].ToString();
			
				dto.IdtLote.Value = row[FieldNames.IdtLote].ToString();
			
				dto.CdBarra.Value = row[FieldNames.CdBarra].ToString();
			
			
            return dto;
        }

        public static explicit operator CodigoBarraDTO(XmlDocument xml)
        {
            CodigoBarraDTO dto = new CodigoBarraDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto) != null) dto.IdtProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial) != null) dto.IdtFilial.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLote) != null) dto.IdtLote.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLote).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.CdBarra) != null) dto.CdBarra.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdBarra).InnerText;			
			
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdtProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtProduto, null);
			
            XmlNode nodeIdtFilial = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFilial, null);
			
            XmlNode nodeIdtLote = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLote, null);
			
            XmlNode nodeCdBarra = xml.CreateNode(XmlNodeType.Element, FieldNames.CdBarra, null);
			
			
			if (!this.IdtProduto.Value.IsNull) nodeIdtProduto.InnerText = this.IdtProduto.Value;
			
			if (!this.IdtFilial.Value.IsNull) nodeIdtFilial.InnerText = this.IdtFilial.Value;
			
			if (!this.IdtLote.Value.IsNull) nodeIdtLote.InnerText = this.IdtLote.Value;
			
			if (!this.CdBarra.Value.IsNull) nodeCdBarra.InnerText = this.CdBarra.Value;
			
			
            nodeData.AppendChild(nodeIdtProduto);
			
            nodeData.AppendChild(nodeIdtFilial);
			
            nodeData.AppendChild(nodeIdtLote);
			
            nodeData.AppendChild(nodeCdBarra);
						
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(CodigoBarraDTO dto)
        {
            CodigoBarraDataTable dtb = new CodigoBarraDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.IdtProduto] = dto.IdtProduto.Value;
			
            dtr[FieldNames.IdtFilial] = dto.IdtFilial.Value;
			
            dtr[FieldNames.IdtLote] = dto.IdtLote.Value;
			
            dtr[FieldNames.CdBarra] = dto.CdBarra.Value;
			
            return dtr;
        }

        public static explicit operator XmlDocument(CodigoBarraDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


