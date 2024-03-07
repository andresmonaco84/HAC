
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
	/// Classe Entidade GrupoMatMedDataTable
	/// </summary>
	[Serializable()]
	public class GrupoMatMedDataTable : DataTable
	{
		
	    public GrupoMatMedDataTable()
            : base()
        {
            this.TableName = "DADOS";
            // FALTA 
            // FlAtivo
		    this.Columns.Add(GrupoMatMedDTO.FieldNames.Idt, typeof(Decimal));
		    this.Columns.Add(GrupoMatMedDTO.FieldNames.DsGrupo, typeof(String));
            this.Columns.Add(GrupoMatMedDTO.FieldNames.FlAtivo, typeof(String));
            DataColumn[] primaryKey = { this.Columns[GrupoMatMedDTO.FieldNames.Idt] };

            this.PrimaryKey = primaryKey;
        }
		
        protected GrupoMatMedDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public GrupoMatMedDTO TypedRow(int index)
        {
            return (GrupoMatMedDTO)this.Rows[index];
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

        public void Add(GrupoMatMedDTO dto)
        {
            DataRow dtr = this.NewRow();


			if (!dto.Idt.Value.IsNull) dtr[GrupoMatMedDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		    if (!dto.DsGrupo.Value.IsNull) dtr[GrupoMatMedDTO.FieldNames.DsGrupo] = (String)dto.DsGrupo.Value;
            if (!dto.FlAtivo.Value.IsNull) dtr[GrupoMatMedDTO.FieldNames.FlAtivo] = (Decimal)dto.FlAtivo.Value;
			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class GrupoMatMedDTO : MVC.DTO.DTOBase
    {

        public enum status
        {
            INATIVO = 0,
            ATIVO =1
        }

	    private MVC.DTO.FieldDecimal cad_mtmd_grupo_id;
		private MVC.DTO.FieldString cad_mtmd_grupo_descricao;
        private MVC.DTO.FieldDecimal cad_mtmd_fl_ativo;

        public GrupoMatMedDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
		    this.cad_mtmd_grupo_id= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		    this.cad_mtmd_grupo_descricao= new MVC.DTO.FieldString(FieldNames.DsGrupo,Captions.DsGrupo, 30);
            this.cad_mtmd_fl_ativo = new MVC.DTO.FieldDecimal(FieldNames.FlAtivo, Captions.FlAtivo, DbType.Decimal);
		
        }
 
        #region FieldNames

        public struct FieldNames
        {
		    public const string Idt="CAD_MTMD_GRUPO_ID";
		    public const string DsGrupo="CAD_MTMD_GRUPO_DESCRICAO";
            public const string FlAtivo = "CAD_MTMD_FL_ATIVO";		
        }		

        #endregion

        #region Captions
        public struct Captions
        {
		    public const string Idt="IDT";
		    public const string DsGrupo="GRUPODESCRICAO";
            public const string FlAtivo = "CADMTMDFLATIVO";		
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal Idt
		{
			get { return cad_mtmd_grupo_id; }
			set { cad_mtmd_grupo_id = value; }
		}
		
		public MVC.DTO.FieldString DsGrupo
		{
			get { return cad_mtmd_grupo_descricao; }
			set { cad_mtmd_grupo_descricao = value; }
		}

        public MVC.DTO.FieldDecimal FlAtivo
        {
            get { return cad_mtmd_fl_ativo; }
            set { cad_mtmd_fl_ativo = value; }
        }
			
		#endregion


        #region Operators

        public static explicit operator GrupoMatMedDTO(DataRow row)
        {
            GrupoMatMedDTO  dto = new GrupoMatMedDTO();
		
			dto.Idt.Value = row[FieldNames.Idt].ToString();
		
			dto.DsGrupo.Value = row[FieldNames.DsGrupo].ToString();

            dto.FlAtivo.Value = row[FieldNames.FlAtivo].ToString();			

            return dto;
        }

        public static explicit operator GrupoMatMedDTO(XmlDocument xml)
        {
            GrupoMatMedDTO dto = new GrupoMatMedDTO();
			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.DsGrupo) != null) dto.DsGrupo.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsGrupo).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.FlAtivo) != null) dto.FlAtivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlAtivo).InnerText;						

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeGrupoDescricao = xml.CreateNode(XmlNodeType.Element, FieldNames.DsGrupo, null);

            XmlNode nodeFlAtivo = xml.CreateNode(XmlNodeType.Element, FieldNames.FlAtivo, null);

            if (!this.FlAtivo.Value.IsNull) nodeFlAtivo.InnerText = this.FlAtivo.Value;
			
			if (!this.DsGrupo.Value.IsNull) nodeGrupoDescricao.InnerText = this.DsGrupo.Value;

            if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;			

            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodeGrupoDescricao);

            nodeData.AppendChild(nodeFlAtivo);
						
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(GrupoMatMedDTO dto)
        {
            GrupoMatMedDataTable dtb = new GrupoMatMedDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
			
            dtr[FieldNames.DsGrupo] = dto.DsGrupo.Value;

            dtr[FieldNames.FlAtivo] = dto.FlAtivo.Value;
			
            return dtr;
        }

        public static explicit operator XmlDocument(GrupoMatMedDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


