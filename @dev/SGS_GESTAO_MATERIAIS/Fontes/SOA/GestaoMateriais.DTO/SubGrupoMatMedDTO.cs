
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
	/// Classe Entidade SubGrupoMatMedDataTable
	/// </summary>
	[Serializable()]
	public class SubGrupoMatMedDataTable : DataTable
	{
		
	    public SubGrupoMatMedDataTable()
            : base()
        {
            this.TableName = "DADOS";

		this.Columns.Add(SubGrupoMatMedDTO.FieldNames.Idt, typeof(Decimal));
		this.Columns.Add(SubGrupoMatMedDTO.FieldNames.IdtGrupo, typeof(Decimal));
		this.Columns.Add(SubGrupoMatMedDTO.FieldNames.DsSubGrupo, typeof(String));
        this.Columns.Add(SubGrupoMatMedDTO.FieldNames.DsGrupo, typeof(String));

            DataColumn[] primaryKey = { this.Columns[SubGrupoMatMedDTO.FieldNames.IdtGrupo], this.Columns[SubGrupoMatMedDTO.FieldNames.Idt] };

            this.PrimaryKey = primaryKey;
        }
		
        protected SubGrupoMatMedDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public SubGrupoMatMedDTO TypedRow(int index)
        {
            return (SubGrupoMatMedDTO)this.Rows[index];
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

        public void Add(SubGrupoMatMedDTO dto)
        {
            DataRow dtr = this.NewRow();


					if (!dto.Idt.Value.IsNull) dtr[SubGrupoMatMedDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		if (!dto.IdtGrupo.Value.IsNull) dtr[SubGrupoMatMedDTO.FieldNames.IdtGrupo] = (Decimal)dto.IdtGrupo.Value;
		if (!dto.DsSubGrupo.Value.IsNull) dtr[SubGrupoMatMedDTO.FieldNames.DsSubGrupo] = (String)dto.DsSubGrupo.Value;
        if (!dto.DsGrupo.Value.IsNull) dtr[SubGrupoMatMedDTO.FieldNames.DsGrupo] = (String)dto.DsGrupo.Value;

			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class SubGrupoMatMedDTO : MVC.DTO.DTOBase
    {	
			private MVC.DTO.FieldDecimal cad_mtmd_subgrupo_id;
		private MVC.DTO.FieldDecimal cad_mtmd_grupo_id;
		private MVC.DTO.FieldString cad_mtmd_subgrupo_descricao;
        private MVC.DTO.FieldString cad_mtmd_grupo_descricao;

        public SubGrupoMatMedDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
	        this.cad_mtmd_subgrupo_id= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
	        this.cad_mtmd_grupo_id= new MVC.DTO.FieldDecimal(FieldNames.IdtGrupo,Captions.IdtGrupo, DbType.Decimal);
	        this.cad_mtmd_subgrupo_descricao= new MVC.DTO.FieldString(FieldNames.DsSubGrupo,Captions.DsSubGrupo, 30);
            this.cad_mtmd_grupo_descricao = new MVC.DTO.FieldString(FieldNames.DsGrupo, Captions.DsGrupo, 30);
        }
 
        #region FieldNames

        public struct FieldNames
        {
				public const string Idt="CAD_MTMD_SUBGRUPO_ID";
		public const string IdtGrupo="CAD_MTMD_GRUPO_ID";
		public const string DsSubGrupo="CAD_MTMD_SUBGRUPO_DESCRICAO";
            public const string DsGrupo = "CAD_MTMD_GRUPO_DESCRICAO";
        }		

        #endregion

        #region Captions
        public struct Captions
        {
				public const string Idt="IDT";
		public const string IdtGrupo="GRUPOID";
		public const string DsSubGrupo="SUBGRUPODESCRICAO";
            public const string DsGrupo = "CADMTMDGRUPODESCRICAO";
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal Idt
		{
			get { return cad_mtmd_subgrupo_id; }
			set { cad_mtmd_subgrupo_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtGrupo
		{
			get { return cad_mtmd_grupo_id; }
			set { cad_mtmd_grupo_id = value; }
		}
		
		public MVC.DTO.FieldString DsSubGrupo
		{
			get { return cad_mtmd_subgrupo_descricao; }
			set { cad_mtmd_subgrupo_descricao = value; }
		}

        public MVC.DTO.FieldString DsGrupo
        {
            get { return cad_mtmd_grupo_descricao; }
            set { cad_mtmd_grupo_descricao = value; }
        }					
			
		#endregion


        #region Operators

        public static explicit operator SubGrupoMatMedDTO(DataRow row)
        {
            SubGrupoMatMedDTO  dto = new SubGrupoMatMedDTO();
			
				dto.Idt.Value = row[FieldNames.Idt].ToString();
			
				dto.IdtGrupo.Value = row[FieldNames.IdtGrupo].ToString();
			
				dto.DsSubGrupo.Value = row[FieldNames.DsSubGrupo].ToString();

                dto.DsGrupo.Value = row[FieldNames.DsGrupo].ToString();			
			
            return dto;
        }

        public static explicit operator SubGrupoMatMedDTO(XmlDocument xml)
        {
            SubGrupoMatMedDTO dto = new SubGrupoMatMedDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtGrupo) != null) dto.IdtGrupo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtGrupo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DsSubGrupo) != null) dto.DsSubGrupo.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsSubGrupo).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.DsGrupo) != null) dto.DsGrupo.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsGrupo).InnerText;			
			
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeGrupoId = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtGrupo, null);
			
            XmlNode nodeSubGrupoDescricao = xml.CreateNode(XmlNodeType.Element, FieldNames.DsSubGrupo, null);

            XmlNode nodeGrupoDescricao = xml.CreateNode(XmlNodeType.Element, FieldNames.DsGrupo, null);
			
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			
			if (!this.IdtGrupo.Value.IsNull) nodeGrupoId.InnerText = this.IdtGrupo.Value;
			
			if (!this.DsSubGrupo.Value.IsNull) nodeSubGrupoDescricao.InnerText = this.DsSubGrupo.Value;

            if (!this.DsGrupo.Value.IsNull) nodeGrupoDescricao.InnerText = this.DsGrupo.Value;			
			
            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodeGrupoId);
			
            nodeData.AppendChild(nodeSubGrupoDescricao);

            nodeData.AppendChild(nodeGrupoDescricao);
						
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(SubGrupoMatMedDTO dto)
        {
            SubGrupoMatMedDataTable dtb = new SubGrupoMatMedDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
			
            dtr[FieldNames.IdtGrupo] = dto.IdtGrupo.Value;
			
            dtr[FieldNames.DsSubGrupo] = dto.DsSubGrupo.Value;

            dtr[FieldNames.DsGrupo] = dto.DsGrupo.Value;
			
            return dtr;
        }

        public static explicit operator XmlDocument(SubGrupoMatMedDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


