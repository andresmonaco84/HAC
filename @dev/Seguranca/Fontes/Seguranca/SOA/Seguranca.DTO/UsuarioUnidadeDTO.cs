
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
	/// Classe Entidade UsuarioUnidadeDataTable
	/// </summary>
	[Serializable()]
	public class UsuarioUnidadeDataTable : DataTable
	{
		
	    public UsuarioUnidadeDataTable()    : base()
        {
            this.TableName = "DADOS";
            this.Columns.Add(UsuarioUnidadeDTO.FieldNames.IdtUsuario, typeof(decimal));
            this.Columns.Add(UsuarioUnidadeDTO.FieldNames.IdtUnidade, typeof(decimal));
            this.Columns.Add(UsuarioUnidadeDTO.FieldNames.DsUnidade, typeof(string));

            

			

            DataColumn[] primaryKey = { this.Columns[UsuarioUnidadeDTO.FieldNames.IdtUnidade] };

            this.PrimaryKey = primaryKey;
        }
		
        protected UsuarioUnidadeDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public UsuarioUnidadeDTO TypedRow(int index)
        {
            return (UsuarioUnidadeDTO)this.Rows[index];
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

        public void Add(UsuarioUnidadeDTO dto)
        {
            DataRow dtr = this.NewRow();
			if (!dto.IdtUsuario.Value.IsNull) dtr[UsuarioUnidadeDTO.FieldNames.IdtUsuario] = (decimal)dto.IdtUsuario.Value;
    		if (!dto.IdtUnidade.Value.IsNull) dtr[UsuarioUnidadeDTO.FieldNames.IdtUnidade] = (decimal)dto.IdtUnidade.Value;
            if (!dto.DsUnidade.Value.IsNull) dtr[UsuarioUnidadeDTO.FieldNames.DsUnidade] = (string)dto.DsUnidade.Value;            
			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class UsuarioUnidadeDTO : MVC.DTO.DTOBase
    {	
		private MVC.DTO.FieldDecimal seg_usu_id_usuario;
		private MVC.DTO.FieldDecimal cad_uni_id_unidade;
        private MVC.DTO.FieldString cad_uni_ds_unidade;

        



        public UsuarioUnidadeDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
            this.seg_usu_id_usuario = new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario, Captions.IdtUsuario, DbType.Decimal);
            this.cad_uni_id_unidade = new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade, Captions.IdtUnidade, DbType.Decimal);
            this.cad_uni_ds_unidade = new MVC.DTO.FieldString(FieldNames.DsUnidade, Captions.DsUnidade, 100);            

        }
 
        #region FieldNames

        public struct FieldNames
        {
            public const string IdtUsuario="SEG_USU_ID_USUARIO";
		    public const string IdtUnidade="CAD_UNI_ID_UNIDADE";
            public const string DsUnidade = "CAD_UNI_DS_UNIDADE";            
		
        }		

        #endregion

        #region Captions
        public struct Captions
        {
			
            public const string IdtUsuario="IDTUSUARIO";
		    public const string IdtUnidade="IDTUNIDADE";
            public const string DsUnidade = "DSUNIDADE";
            
		
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal IdtUsuario
		{
			get { return seg_usu_id_usuario; }
			set { seg_usu_id_usuario = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtUnidade
		{
			get { return cad_uni_id_unidade; }
			set { cad_uni_id_unidade = value; }
		}

        public MVC.DTO.FieldString DsUnidade
        {
            get { return cad_uni_ds_unidade; }
            set { cad_uni_ds_unidade = value; }
        }
        
			
		#endregion


        #region Operators

        public static explicit operator UsuarioUnidadeDTO(DataRow row)
        {
            UsuarioUnidadeDTO  dto = new UsuarioUnidadeDTO();			
			dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();			
			dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();

            dto.DsUnidade.Value = row[FieldNames.DsUnidade].ToString();
                        
			
            return dto;
        }

        public static explicit operator UsuarioUnidadeDTO(XmlDocument xml)
        {
            UsuarioUnidadeDTO dto = new UsuarioUnidadeDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade) != null) dto.DsUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade).InnerText;
                        
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdtUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);			
            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);
            XmlNode nodeDsUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidade, null);			
			
			if (!this.IdtUsuario.Value.IsNull) nodeIdtUsuario.InnerText = this.IdtUsuario.Value;			
			if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;
            if (!this.DsUnidade.Value.IsNull) nodeDsUnidade.InnerText = this.DsUnidade.Value;			
			
            nodeData.AppendChild(nodeIdtUsuario);			
            nodeData.AppendChild(nodeIdtUnidade);
            nodeData.AppendChild(nodeDsUnidade);
            
            
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(UsuarioUnidadeDTO dto)
        {
            UsuarioUnidadeDataTable dtb = new UsuarioUnidadeDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;			
            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;
            dtr[FieldNames.DsUnidade] = dto.DsUnidade.Value;

            //DsUnidade cad_uni_ds_unidade nodeDsUnidade            
			
            return dtr;
        }

        public static explicit operator XmlDocument(UsuarioUnidadeDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


