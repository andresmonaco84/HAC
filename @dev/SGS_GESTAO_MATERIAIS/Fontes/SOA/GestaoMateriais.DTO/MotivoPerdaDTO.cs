
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
	/// Classe Entidade MotivoPerdaDataTable
	/// </summary>
	[Serializable()]
	public class MotivoPerdaDataTable : DataTable
	{
		
	    public MotivoPerdaDataTable()
            : base()
        {
            this.TableName = "DADOS";

		this.Columns.Add(MotivoPerdaDTO.FieldNames.idtMotivo, typeof(Decimal));
		this.Columns.Add(MotivoPerdaDTO.FieldNames.DsMotivo, typeof(String));
		this.Columns.Add(MotivoPerdaDTO.FieldNames.FlObrigaObs, typeof(Decimal));


			 

            DataColumn[] primaryKey = {  };

            this.PrimaryKey = primaryKey;
        }
		
        protected MotivoPerdaDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public MotivoPerdaDTO TypedRow(int index)
        {
            return (MotivoPerdaDTO)this.Rows[index];
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

        public void Add(MotivoPerdaDTO dto)
        {
            DataRow dtr = this.NewRow();


					if (!dto.idtMotivo.Value.IsNull) dtr[MotivoPerdaDTO.FieldNames.idtMotivo] = (Decimal)dto.idtMotivo.Value;
		if (!dto.DsMotivo.Value.IsNull) dtr[MotivoPerdaDTO.FieldNames.DsMotivo] = (String)dto.DsMotivo.Value;
		if (!dto.FlObrigaObs.Value.IsNull) dtr[MotivoPerdaDTO.FieldNames.FlObrigaObs] = (Decimal)dto.FlObrigaObs.Value;

			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class MotivoPerdaDTO : MVC.DTO.DTOBase
    {	
			private MVC.DTO.FieldDecimal mtmd_id_motivo;
		private MVC.DTO.FieldString mtmd_ds_motivo;
		private MVC.DTO.FieldDecimal mtmd_fl_obriga_obs;

        public MotivoPerdaDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
				this.mtmd_id_motivo= new MVC.DTO.FieldDecimal(FieldNames.idtMotivo,Captions.idtMotivo, DbType.Decimal);
		this.mtmd_ds_motivo= new MVC.DTO.FieldString(FieldNames.DsMotivo,Captions.DsMotivo, 30);
		this.mtmd_fl_obriga_obs= new MVC.DTO.FieldDecimal(FieldNames.FlObrigaObs,Captions.FlObrigaObs, DbType.Decimal);
		
        }
 
        #region FieldNames

        public struct FieldNames
        {
				public const string idtMotivo="MTMD_ID_MOTIVO";
		public const string DsMotivo="MTMD_DS_MOTIVO";
		public const string FlObrigaObs="MTMD_FL_OBRIGA_OBS";
		
        }		

        #endregion

        #region Captions
        public struct Captions
        {
				public const string idtMotivo="idtMotivo";
		public const string DsMotivo="DSMOTIVO";
		public const string FlObrigaObs="FLOBRIGAOBS";
		
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal idtMotivo
		{
			get { return mtmd_id_motivo; }
			set { mtmd_id_motivo = value; }
		}
		
		public MVC.DTO.FieldString DsMotivo
		{
			get { return mtmd_ds_motivo; }
			set { mtmd_ds_motivo = value; }
		}
		
		public MVC.DTO.FieldDecimal FlObrigaObs
		{
			get { return mtmd_fl_obriga_obs; }
			set { mtmd_fl_obriga_obs = value; }
		}
					
			
		#endregion


        #region Operators

        public static explicit operator MotivoPerdaDTO(DataRow row)
        {
            MotivoPerdaDTO  dto = new MotivoPerdaDTO();
			
				dto.idtMotivo.Value = row[FieldNames.idtMotivo].ToString();
			
				dto.DsMotivo.Value = row[FieldNames.DsMotivo].ToString();
			
				dto.FlObrigaObs.Value = row[FieldNames.FlObrigaObs].ToString();
			
			
            return dto;
        }

        public static explicit operator MotivoPerdaDTO(XmlDocument xml)
        {
            MotivoPerdaDTO dto = new MotivoPerdaDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.idtMotivo) != null) dto.idtMotivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.idtMotivo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DsMotivo) != null) dto.DsMotivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsMotivo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.FlObrigaObs) != null) dto.FlObrigaObs.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlObrigaObs).InnerText;			
			
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeidtMotivo = xml.CreateNode(XmlNodeType.Element, FieldNames.idtMotivo, null);
			
            XmlNode nodeDsMotivo = xml.CreateNode(XmlNodeType.Element, FieldNames.DsMotivo, null);
			
            XmlNode nodeFlObrigaObs = xml.CreateNode(XmlNodeType.Element, FieldNames.FlObrigaObs, null);
			
			
			if (!this.idtMotivo.Value.IsNull) nodeidtMotivo.InnerText = this.idtMotivo.Value;
			
			if (!this.DsMotivo.Value.IsNull) nodeDsMotivo.InnerText = this.DsMotivo.Value;
			
			if (!this.FlObrigaObs.Value.IsNull) nodeFlObrigaObs.InnerText = this.FlObrigaObs.Value;
			
			
            nodeData.AppendChild(nodeidtMotivo);
			
            nodeData.AppendChild(nodeDsMotivo);
			
            nodeData.AppendChild(nodeFlObrigaObs);
						
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(MotivoPerdaDTO dto)
        {
            MotivoPerdaDataTable dtb = new MotivoPerdaDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.idtMotivo] = dto.idtMotivo.Value;
			
            dtr[FieldNames.DsMotivo] = dto.DsMotivo.Value;
			
            dtr[FieldNames.FlObrigaObs] = dto.FlObrigaObs.Value;
			
            return dtr;
        }

        public static explicit operator XmlDocument(MotivoPerdaDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


