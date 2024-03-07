
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
	/// Classe Entidade PrincipioAtivoDataTable
	/// </summary>
	[Serializable()]
	public class PrincipioAtivoDataTable : DataTable
	{
		
	    public PrincipioAtivoDataTable()
            : base()
        {
            this.TableName = "DADOS";
		    this.Columns.Add(PrincipioAtivoDTO.FieldNames.Idt, typeof(Decimal));
    	    this.Columns.Add(PrincipioAtivoDTO.FieldNames.DsPrincipioAtivo, typeof(String));
            this.Columns.Add(PrincipioAtivoDTO.FieldNames.FlIrritante, typeof(Decimal));
            this.Columns.Add(PrincipioAtivoDTO.FieldNames.FlVesicante, typeof(Decimal));
            this.Columns.Add(PrincipioAtivoDTO.FieldNames.FlFlebitante, typeof(Decimal));
            this.Columns.Add(PrincipioAtivoDTO.FieldNames.DsOrientacao, typeof(String));
            this.Columns.Add(PrincipioAtivoDTO.FieldNames.IdtUsuario, typeof(Decimal));

            DataColumn[] primaryKey = { this.Columns[PrincipioAtivoDTO.FieldNames.Idt] };

            this.PrimaryKey = primaryKey;
        }
		
        protected PrincipioAtivoDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public PrincipioAtivoDTO TypedRow(int index)
        {
            return (PrincipioAtivoDTO)this.Rows[index];
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

        public void Add(PrincipioAtivoDTO dto)
        {
            DataRow dtr = this.NewRow();


					if (!dto.Idt.Value.IsNull) dtr[PrincipioAtivoDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		if (!dto.DsPrincipioAtivo.Value.IsNull) dtr[PrincipioAtivoDTO.FieldNames.DsPrincipioAtivo] = (String)dto.DsPrincipioAtivo.Value;

        if (!dto.FlIrritante.Value.IsNull) dtr[PrincipioAtivoDTO.FieldNames.FlIrritante] = (Decimal)dto.FlIrritante.Value;
        if (!dto.FlVesicante.Value.IsNull) dtr[PrincipioAtivoDTO.FieldNames.FlVesicante] = (Decimal)dto.FlVesicante.Value;
        if (!dto.FlFlebitante.Value.IsNull) dtr[PrincipioAtivoDTO.FieldNames.FlFlebitante] = (Decimal)dto.FlFlebitante.Value;
        if (!dto.DsOrientacao.Value.IsNull) dtr[PrincipioAtivoDTO.FieldNames.DsOrientacao] = (String)dto.DsOrientacao.Value;
        if (!dto.IdtUsuario.Value.IsNull) dtr[PrincipioAtivoDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;
			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class PrincipioAtivoDTO : MVC.DTO.DTOBase
    {	
		private MVC.DTO.FieldDecimal cad_mtmd_priati_id;
		private MVC.DTO.FieldString cad_mtmd_priati_descricao;
        private MVC.DTO.FieldDecimal cad_mtmd_fl_irritante;
        private MVC.DTO.FieldDecimal cad_mtmd_fl_vesicante;
        private MVC.DTO.FieldDecimal cad_mtmd_fl_flebitante;
        private MVC.DTO.FieldString cad_mtmd_orientacao;
        private MVC.DTO.FieldDecimal seg_usu_id_usuario;

        public PrincipioAtivoDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
			this.cad_mtmd_priati_id= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
            this.cad_mtmd_priati_descricao= new MVC.DTO.FieldString(FieldNames.DsPrincipioAtivo,Captions.DsPrincipioAtivo, 50);
            this.cad_mtmd_fl_irritante = new MVC.DTO.FieldDecimal(FieldNames.FlIrritante, Captions.FlIrritante, DbType.Decimal);
            this.cad_mtmd_fl_vesicante = new MVC.DTO.FieldDecimal(FieldNames.FlVesicante, Captions.FlVesicante, DbType.Decimal);
            this.cad_mtmd_fl_flebitante = new MVC.DTO.FieldDecimal(FieldNames.FlFlebitante, Captions.FlFlebitante, DbType.Decimal);
            this.cad_mtmd_orientacao = new MVC.DTO.FieldString(FieldNames.DsOrientacao, Captions.DsOrientacao, 100);
            this.seg_usu_id_usuario = new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario, Captions.IdtUsuario, DbType.Decimal);
        }
 
        #region FieldNames

        public struct FieldNames
        {
			public const string Idt="CAD_MTMD_PRIATI_ID";
		    public const string DsPrincipioAtivo="CAD_MTMD_PRIATI_DESCRICAO";
            public const string FlIrritante = "CAD_MTMD_FL_IRRITANTE";
            public const string FlVesicante = "CAD_MTMD_FL_VESICANTE";
            public const string FlFlebitante = "CAD_MTMD_FL_FLEBITANTE";
            public const string DsOrientacao = "CAD_MTMD_ORIENTACAO";
            public const string IdtUsuario = "SEG_USU_ID_USUARIO";
        }		

        #endregion

        #region Captions
        public struct Captions
        {
			public const string Idt="IDT";
		    public const string DsPrincipioAtivo="PRIATIDESCRICAO";
            public const string FlIrritante = "FLIRRITANTE";
            public const string FlVesicante = "FLVESICANTE";
            public const string FlFlebitante = "FLFLEBITANTE";
            public const string DsOrientacao = "ORIENTACAO";
            public const string IdtUsuario = "IDTUSUARIO";
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal Idt
		{
			get { return cad_mtmd_priati_id; }
			set { cad_mtmd_priati_id = value; }
		}
		
		public MVC.DTO.FieldString DsPrincipioAtivo
		{
			get { return cad_mtmd_priati_descricao; }
			set { cad_mtmd_priati_descricao = value; }
		}

        public MVC.DTO.FieldDecimal FlIrritante
        {
            get { return cad_mtmd_fl_irritante; }
            set { cad_mtmd_fl_irritante = value; }
        }

        public MVC.DTO.FieldDecimal FlVesicante
        {
            get { return cad_mtmd_fl_vesicante; }
            set { cad_mtmd_fl_vesicante = value; }
        }

        public MVC.DTO.FieldDecimal FlFlebitante
        {
            get { return cad_mtmd_fl_flebitante; }
            set { cad_mtmd_fl_flebitante = value; }
        }

        public MVC.DTO.FieldString DsOrientacao
        {
            get { return cad_mtmd_orientacao; }
            set { cad_mtmd_orientacao = value; }
        }

        public MVC.DTO.FieldDecimal IdtUsuario
        {
            get { return seg_usu_id_usuario; }
            set { seg_usu_id_usuario = value; }
        }

		#endregion


        #region Operators

        public static explicit operator PrincipioAtivoDTO(DataRow row)
        {
            PrincipioAtivoDTO  dto = new PrincipioAtivoDTO();
			
				dto.Idt.Value = row[FieldNames.Idt].ToString();
			
				dto.DsPrincipioAtivo.Value = row[FieldNames.DsPrincipioAtivo].ToString();

                dto.FlIrritante.Value = row[FieldNames.FlIrritante].ToString();
                dto.FlVesicante.Value = row[FieldNames.FlVesicante].ToString();
                dto.FlFlebitante.Value = row[FieldNames.FlFlebitante].ToString();
                dto.DsOrientacao.Value = row[FieldNames.DsOrientacao].ToString();
                dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();
			
            return dto;
        }

        public static explicit operator PrincipioAtivoDTO(XmlDocument xml)
        {
            PrincipioAtivoDTO dto = new PrincipioAtivoDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DsPrincipioAtivo) != null) dto.DsPrincipioAtivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsPrincipioAtivo).InnerText;			
			
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodePriAtiDescricao = xml.CreateNode(XmlNodeType.Element, FieldNames.DsPrincipioAtivo, null);
			
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			
			if (!this.DsPrincipioAtivo.Value.IsNull) nodePriAtiDescricao.InnerText = this.DsPrincipioAtivo.Value;
			
			
            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodePriAtiDescricao);
						
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(PrincipioAtivoDTO dto)
        {
            PrincipioAtivoDataTable dtb = new PrincipioAtivoDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
			
            dtr[FieldNames.DsPrincipioAtivo] = dto.DsPrincipioAtivo.Value;

            dtr[FieldNames.FlIrritante] = dto.FlIrritante.Value;
            dtr[FieldNames.FlVesicante] = dto.FlVesicante.Value;
            dtr[FieldNames.FlFlebitante] = dto.FlFlebitante.Value;            
            dtr[FieldNames.DsOrientacao] = dto.DsOrientacao.Value;
            dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;
			
            return dtr;
        }

        public static explicit operator XmlDocument(PrincipioAtivoDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}