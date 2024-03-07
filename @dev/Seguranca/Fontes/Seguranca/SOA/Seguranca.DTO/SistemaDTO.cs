
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using MVC = HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.Seguranca.DTO
{
	/// <summary>
	/// Classe Entidade SistemaDataTable
	/// </summary>
	[Serializable()]
	public class SistemaDataTable : DataTable
	{
		
	    public SistemaDataTable()
            : base()
        {
            this.TableName = "DADOS";

					this.Columns.Add(SistemaDTO.FieldNames.Idt, typeof(Decimal));
		this.Columns.Add(SistemaDTO.FieldNames.NmSistema, typeof(String));


			

            DataColumn[] primaryKey = { this.Columns[SistemaDTO.FieldNames.Idt] };

            this.PrimaryKey = primaryKey;
        }
		
        protected SistemaDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public SistemaDTO TypedRow(int index)
        {
            return (SistemaDTO)this.Rows[index];
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

        public void Add(SistemaDTO dto)
        {
            DataRow dtr = this.NewRow();


					if (!dto.Idt.Value.IsNull) dtr[SistemaDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		if (!dto.NmSistema.Value.IsNull) dtr[SistemaDTO.FieldNames.NmSistema] = (String)dto.NmSistema.Value;

			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class SistemaDTO : MVC.DTO.DTOBase
    {	
			private MVC.DTO.FieldDecimal seg_id_sistema;
		private MVC.DTO.FieldString seg_nm_sistema;

        public SistemaDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
				this.seg_id_sistema= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		this.seg_nm_sistema= new MVC.DTO.FieldString(FieldNames.NmSistema,Captions.NmSistema, 50);
		
        }
 
        #region FieldNames

        public struct FieldNames
        {
				public const string Idt="SEG_ID_SISTEMA";
		public const string NmSistema="SEG_NM_SISTEMA";
		
        }		

        #endregion

        #region Captions
        public struct Captions
        {
				public const string Idt="IDT";
		public const string NmSistema="NMSISTEMA";
		
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal Idt
		{
			get { return seg_id_sistema; }
			set { seg_id_sistema = value; }
		}
		
		public MVC.DTO.FieldString NmSistema
		{
			get { return seg_nm_sistema; }
			set { seg_nm_sistema = value; }
		}
					
			
		#endregion


        #region Operators

        public static explicit operator SistemaDTO(DataRow row)
        {
            SistemaDTO  dto = new SistemaDTO();
			
				dto.Idt.Value = row[FieldNames.Idt].ToString();
			
				dto.NmSistema.Value = row[FieldNames.NmSistema].ToString();
			
			
            return dto;
        }

        public static explicit operator SistemaDTO(XmlDocument xml)
        {
            SistemaDTO dto = new SistemaDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.NmSistema) != null) dto.NmSistema.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmSistema).InnerText;			
			
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeNmSistema = xml.CreateNode(XmlNodeType.Element, FieldNames.NmSistema, null);
			
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			
			if (!this.NmSistema.Value.IsNull) nodeNmSistema.InnerText = this.NmSistema.Value;
			
			
            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodeNmSistema);
						
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(SistemaDTO dto)
        {
            SistemaDataTable dtb = new SistemaDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
			
            dtr[FieldNames.NmSistema] = dto.NmSistema.Value;
			
            return dtr;
        }

        public static explicit operator XmlDocument(SistemaDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


