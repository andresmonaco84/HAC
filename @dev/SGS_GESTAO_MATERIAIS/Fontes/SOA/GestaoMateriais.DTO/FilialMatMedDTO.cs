
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
	/// Classe Entidade FilialMatMedDataTable
	/// </summary>
	[Serializable()]
	public class FilialMatMedDataTable : DataTable
	{
		
	    public FilialMatMedDataTable()
            : base()
        {
            this.TableName = "DADOS";

			this.Columns.Add(FilialMatMedDTO.FieldNames.Idt, typeof(Decimal));
		    this.Columns.Add(FilialMatMedDTO.FieldNames.DsFilial, typeof(String));
            this.Columns.Add(FilialMatMedDTO.FieldNames.TpPlano, typeof(String));
        


			

            DataColumn[] primaryKey = { this.Columns[FilialMatMedDTO.FieldNames.Idt] };

            this.PrimaryKey = primaryKey;
        }
		
        protected FilialMatMedDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public FilialMatMedDTO TypedRow(int index)
        {
            return (FilialMatMedDTO)this.Rows[index];
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

        public void Add(FilialMatMedDTO dto)
        {
            DataRow dtr = this.NewRow();


			if (!dto.Idt.Value.IsNull) dtr[FilialMatMedDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		    if (!dto.DsFilial.Value.IsNull) dtr[FilialMatMedDTO.FieldNames.DsFilial] = (String)dto.DsFilial.Value;
            if (!dto.TpPlano.Value.IsNull) dtr[FilialMatMedDTO.FieldNames.TpPlano] = (String)dto.TpPlano.Value;
            

			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class FilialMatMedDTO : MVC.DTO.DTOBase
    {

        public enum Filial
        {
            HAC = 1,
            ACS = 2,
            AMBOS = 3,
            CARRINHO_EMERGENCIA = 4,
            CONSIGNADO = 5
        }

		private MVC.DTO.FieldDecimal cad_mtmd_filial_id;
		private MVC.DTO.FieldString cad_mtmd_filial_descricao;
        private MVC.DTO.FieldString cad_pla_cd_tipoplano;


        public FilialMatMedDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
			this.cad_mtmd_filial_id= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		    this.cad_mtmd_filial_descricao= new MVC.DTO.FieldString(FieldNames.DsFilial,Captions.DsFilial, 30);
            this.cad_mtmd_filial_descricao = new MVC.DTO.FieldString(FieldNames.DsFilial, Captions.DsFilial, 30);
            this.cad_mtmd_filial_descricao = new MVC.DTO.FieldString(FieldNames.DsFilial, Captions.DsFilial, 30);
            this.cad_pla_cd_tipoplano = new MVC.DTO.FieldString(FieldNames.TpPlano, Captions.TpPlano, 30);

            
		
        }
 
        #region FieldNames

        public struct FieldNames
        {
			public const string Idt="CAD_MTMD_FILIAL_ID";
		    public const string DsFilial="CAD_MTMD_FILIAL_DESCRICAO";
            public const string TpPlano = "CAD_PLA_CD_TIPOPLANO";

            
		
        }		

        #endregion

        #region Captions
        public struct Captions
        {
			public const string Idt="IDT";
		    public const string DsFilial="DSFILIAL";
            public const string TpPlano = "TPPLANO";            
		
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal Idt
		{
			get { return cad_mtmd_filial_id; }
			set { cad_mtmd_filial_id = value; }
		}
		
		public MVC.DTO.FieldString DsFilial
		{
			get { return cad_mtmd_filial_descricao; }
			set { cad_mtmd_filial_descricao = value; }
		}

        public MVC.DTO.FieldString TpPlano
        {
            get { return cad_pla_cd_tipoplano; }
            set { cad_pla_cd_tipoplano = value; }
        }        
			
		#endregion


        #region Operators

        public static explicit operator FilialMatMedDTO(DataRow row)
        {
            FilialMatMedDTO  dto = new FilialMatMedDTO();
			
				dto.Idt.Value = row[FieldNames.Idt].ToString();
			
				dto.DsFilial.Value = row[FieldNames.DsFilial].ToString();

                dto.TpPlano.Value = row[FieldNames.TpPlano].ToString();                
			
			
            return dto;
        }

        public static explicit operator FilialMatMedDTO(XmlDocument xml)
        {
            FilialMatMedDTO dto = new FilialMatMedDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DsFilial) != null) dto.DsFilial.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsFilial).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.TpPlano) != null) dto.TpPlano.Value = xml.FirstChild.SelectSingleNode(FieldNames.TpPlano).InnerText;

			
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeDsFilial = xml.CreateNode(XmlNodeType.Element, FieldNames.DsFilial, null);

            XmlNode nodeTpPlano = xml.CreateNode(XmlNodeType.Element, FieldNames.TpPlano, null);

            			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			
			if (!this.DsFilial.Value.IsNull) nodeDsFilial.InnerText = this.DsFilial.Value;

            if (!this.TpPlano.Value.IsNull) nodeTpPlano.InnerText = this.TpPlano.Value;
         
			
			
            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodeDsFilial);

            nodeData.AppendChild(nodeTpPlano);


            
						
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(FilialMatMedDTO dto)
        {
            FilialMatMedDataTable dtb = new FilialMatMedDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
			
            dtr[FieldNames.DsFilial] = dto.DsFilial.Value;

            dtr[FieldNames.TpPlano] = dto.TpPlano.Value;


            return dtr;
        }

        public static explicit operator XmlDocument(FilialMatMedDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


