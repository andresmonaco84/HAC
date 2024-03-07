
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
	/// Classe Entidade AssPerfilFuncionalidadeDataTable
	/// </summary>
	[Serializable()]
	public class AssPerfilFuncionalidadeDataTable : DataTable
	{
		
	    public AssPerfilFuncionalidadeDataTable()
            : base()
        {
            this.TableName = "DADOS";

			this.Columns.Add(AssPerfilFuncionalidadeDTO.FieldNames.IdtPerfil, typeof(Decimal));
		    this.Columns.Add(AssPerfilFuncionalidadeDTO.FieldNames.IdtModulo, typeof(Decimal));
		    this.Columns.Add(AssPerfilFuncionalidadeDTO.FieldNames.IdtFuncionalidade, typeof(Decimal));

            this.Columns.Add(AssPerfilFuncionalidadeDTO.FieldNames.NmPerfil, typeof(String));
            this.Columns.Add(AssPerfilFuncionalidadeDTO.FieldNames.NmFuncionalidade, typeof(String));



            DataColumn[] primaryKey = { this.Columns[AssPerfilFuncionalidadeDTO.FieldNames.IdtFuncionalidade], this.Columns[AssPerfilFuncionalidadeDTO.FieldNames.IdtModulo], this.Columns[AssPerfilFuncionalidadeDTO.FieldNames.IdtPerfil] };

            this.PrimaryKey = primaryKey;
        }
		
        protected AssPerfilFuncionalidadeDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public AssPerfilFuncionalidadeDTO TypedRow(int index)
        {
            return (AssPerfilFuncionalidadeDTO)this.Rows[index];
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

        public void Add(AssPerfilFuncionalidadeDTO dto)
        {
            DataRow dtr = this.NewRow();


			if (!dto.IdtPerfil.Value.IsNull) dtr[AssPerfilFuncionalidadeDTO.FieldNames.IdtPerfil] = (Decimal)dto.IdtPerfil.Value;
		    if (!dto.IdtModulo.Value.IsNull) dtr[AssPerfilFuncionalidadeDTO.FieldNames.IdtModulo] = (Decimal)dto.IdtModulo.Value;
		    if (!dto.IdtFuncionalidade.Value.IsNull) dtr[AssPerfilFuncionalidadeDTO.FieldNames.IdtFuncionalidade] = (Decimal)dto.IdtFuncionalidade.Value;

            if (!dto.NmPerfil.Value.IsNull) dtr[AssPerfilFuncionalidadeDTO.FieldNames.NmPerfil] = (String)dto.NmPerfil.Value;
            if (!dto.NmFuncionalidade.Value.IsNull) dtr[AssPerfilFuncionalidadeDTO.FieldNames.NmFuncionalidade] = (String)dto.NmFuncionalidade.Value;

			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class AssPerfilFuncionalidadeDTO : MVC.DTO.DTOBase
    {	
		private MVC.DTO.FieldDecimal seg_per_id_perfil;
		private MVC.DTO.FieldDecimal seg_mod_id_modulo;
		private MVC.DTO.FieldDecimal seg_fun_id_funcionalidade;
        private MVC.DTO.FieldString seg_per_nm_perfil;
        private MVC.DTO.FieldString seg_fun_nm_nome;



        public AssPerfilFuncionalidadeDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
		    this.seg_per_id_perfil= new MVC.DTO.FieldDecimal(FieldNames.IdtPerfil,Captions.IdtPerfil, DbType.Decimal);
		    this.seg_mod_id_modulo= new MVC.DTO.FieldDecimal(FieldNames.IdtModulo,Captions.IdtModulo, DbType.Decimal);
		    this.seg_fun_id_funcionalidade= new MVC.DTO.FieldDecimal(FieldNames.IdtFuncionalidade,Captions.IdtFuncionalidade, DbType.Decimal);
            this.seg_per_nm_perfil = new MVC.DTO.FieldString(FieldNames.NmPerfil, Captions.NmPerfil, 50);
            this.seg_fun_nm_nome = new MVC.DTO.FieldString(FieldNames.NmFuncionalidade, Captions.NmFuncionalidade, 50);
		
        }
 
        #region FieldNames

        public struct FieldNames
        {
		    public const string IdtPerfil="SEG_PER_ID_PERFIL";
		    public const string IdtModulo="SEG_MOD_ID_MODULO";
		    public const string IdtFuncionalidade="SEG_FUN_ID_FUNCIONALIDADE";
            public const string NmPerfil = "SEG_PER_NM_PERFIL";
            public const string NmFuncionalidade = "SEG_FUN_NM_NOME";

        }		

        #endregion

        #region Captions
        public struct Captions
        {
		    public const string IdtPerfil="IDTPERFIL";
		    public const string IdtModulo="IDTMODULO";
		    public const string IdtFuncionalidade="IDTFUNCIONALIDADE";
            public const string NmPerfil = "NMPERFIL";
            public const string NmFuncionalidade = "NMFUNCIONALIDADE";

        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal IdtPerfil
		{
			get { return seg_per_id_perfil; }
			set { seg_per_id_perfil = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtModulo
		{
			get { return seg_mod_id_modulo; }
			set { seg_mod_id_modulo = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtFuncionalidade
		{
			get { return seg_fun_id_funcionalidade; }
			set { seg_fun_id_funcionalidade = value; }
		}


        public MVC.DTO.FieldString NmPerfil
        {
            get { return seg_per_nm_perfil; }
            set { seg_per_nm_perfil = value; }
        }


        public MVC.DTO.FieldString NmFuncionalidade
        {
            get { return seg_fun_nm_nome; }
            set { seg_fun_nm_nome = value; }
        }

			
		#endregion


        #region Operators

        public static explicit operator AssPerfilFuncionalidadeDTO(DataRow row)
        {
            AssPerfilFuncionalidadeDTO  dto = new AssPerfilFuncionalidadeDTO();
			
			dto.IdtPerfil.Value = row[FieldNames.IdtPerfil].ToString();
			
			dto.IdtModulo.Value = row[FieldNames.IdtModulo].ToString();
			
			dto.IdtFuncionalidade.Value = row[FieldNames.IdtFuncionalidade].ToString();

            dto.NmPerfil.Value = row[FieldNames.NmPerfil].ToString();

            dto.NmFuncionalidade.Value = row[FieldNames.NmFuncionalidade].ToString();

            return dto;
        }

        public static explicit operator AssPerfilFuncionalidadeDTO(XmlDocument xml)
        {
            AssPerfilFuncionalidadeDTO dto = new AssPerfilFuncionalidadeDTO();
			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtPerfil) != null) dto.IdtPerfil.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtPerfil).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo) != null) dto.IdtModulo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFuncionalidade) != null) dto.IdtFuncionalidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFuncionalidade).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.NmPerfil) != null) dto.NmPerfil.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmPerfil).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.NmFuncionalidade) != null) dto.NmFuncionalidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmFuncionalidade).InnerText;

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdtPerfil = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtPerfil, null);
			
            XmlNode nodeIdtModulo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtModulo, null);
			
            XmlNode nodeIdtFuncionalidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFuncionalidade, null);

            XmlNode nodeNmPerfil = xml.CreateNode(XmlNodeType.Element, FieldNames.NmPerfil, null);

            XmlNode nodeNmFuncionalidade = xml.CreateNode(XmlNodeType.Element, FieldNames.NmFuncionalidade, null);

			
			if (!this.IdtPerfil.Value.IsNull) nodeIdtPerfil.InnerText = this.IdtPerfil.Value;
			
			if (!this.IdtModulo.Value.IsNull) nodeIdtModulo.InnerText = this.IdtModulo.Value;
			
			if (!this.IdtFuncionalidade.Value.IsNull) nodeIdtFuncionalidade.InnerText = this.IdtFuncionalidade.Value;

            if (!this.NmPerfil.Value.IsNull) nodeNmPerfil.InnerText = this.NmPerfil.Value;

            if (!this.NmFuncionalidade.Value.IsNull) nodeNmFuncionalidade.InnerText = this.NmFuncionalidade.Value;

			
            nodeData.AppendChild(nodeIdtPerfil);
			
            nodeData.AppendChild(nodeIdtModulo);
			
            nodeData.AppendChild(nodeIdtFuncionalidade);

            nodeData.AppendChild(nodeNmPerfil);

            nodeData.AppendChild(nodeNmFuncionalidade);

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(AssPerfilFuncionalidadeDTO dto)
        {
            AssPerfilFuncionalidadeDataTable dtb = new AssPerfilFuncionalidadeDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.IdtPerfil] = dto.IdtPerfil.Value;
			
            dtr[FieldNames.IdtModulo] = dto.IdtModulo.Value;
			
            dtr[FieldNames.IdtFuncionalidade] = dto.IdtFuncionalidade.Value;

            dtr[FieldNames.NmFuncionalidade] = dto.NmFuncionalidade.Value;

            dtr[FieldNames.NmPerfil] = dto.NmPerfil.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(AssPerfilFuncionalidadeDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


