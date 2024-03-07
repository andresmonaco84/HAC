
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
	/// Classe Entidade TipoFracaoDataTable
	/// </summary>
	[Serializable()]
	public class TipoFracaoDataTable : DataTable
	{
		
	    public TipoFracaoDataTable()
            : base()
        {
            this.TableName = "DADOS";

			this.Columns.Add(TipoFracaoDTO.FieldNames.IdtTpFracao, typeof(Decimal));
		    this.Columns.Add(TipoFracaoDTO.FieldNames.DsTpFracao, typeof(String));
            this.Columns.Add(TipoFracaoDTO.FieldNames.QtdeConsumida, typeof(Decimal));
            this.Columns.Add(TipoFracaoDTO.FieldNames.QtdeConvertida, typeof(Decimal));

            DataColumn[] primaryKey = { this.Columns[TipoFracaoDTO.FieldNames.IdtTpFracao] };

            // this.PrimaryKey = primaryKey;
        }
		
        protected TipoFracaoDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public TipoFracaoDTO TypedRow(int index)
        {
            return (TipoFracaoDTO)this.Rows[index];
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

        public void Add(TipoFracaoDTO dto)
        {
            DataRow dtr = this.NewRow();


			if (!dto.IdtTpFracao.Value.IsNull) dtr[TipoFracaoDTO.FieldNames.IdtTpFracao] = (Decimal)dto.IdtTpFracao.Value;
		    if (!dto.DsTpFracao.Value.IsNull) dtr[TipoFracaoDTO.FieldNames.DsTpFracao] = (String)dto.DsTpFracao.Value;

            if (!dto.QtdeConsumida.Value.IsNull) dtr[TipoFracaoDTO.FieldNames.QtdeConsumida] = (Decimal)dto.QtdeConsumida.Value;

            if (!dto.QtdeConvertida.Value.IsNull) dtr[TipoFracaoDTO.FieldNames.QtdeConvertida] = (Decimal)dto.QtdeConvertida.Value;

            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class TipoFracaoDTO : MVC.DTO.DTOBase
    {	
		private MVC.DTO.FieldDecimal mtmd_tp_fracao_id;
		private MVC.DTO.FieldString mtmd_ds_tp_fracao;
        private MVC.DTO.FieldDecimal mtmd_mov_qtde;
        private MVC.DTO.FieldDecimal mtmd_qtd_convertida;

        public TipoFracaoDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
			this.mtmd_tp_fracao_id= new MVC.DTO.FieldDecimal(FieldNames.IdtTpFracao,Captions.IdtTpFracao, DbType.Decimal);
		    this.mtmd_ds_tp_fracao= new MVC.DTO.FieldString(FieldNames.DsTpFracao,Captions.DsTpFracao, 15);
            this.mtmd_mov_qtde = new MVC.DTO.FieldDecimal(FieldNames.QtdeConsumida, Captions.QtdeConsumida, DbType.Decimal);
            this.mtmd_qtd_convertida = new MVC.DTO.FieldDecimal(FieldNames.QtdeConvertida, Captions.QtdeConvertida, DbType.Decimal);
		
        }
 
        #region FieldNames

        public struct FieldNames
        {
			public const string IdtTpFracao="MTMD_TP_FRACAO_ID";
		    public const string DsTpFracao="MTMD_DS_TP_FRACAO";

            public const string QtdeConsumida = "MTMD_MOV_QTDE";
            public const string QtdeConvertida = "MTMD_QTD_CONVERTIDA";
	
        }		

        #endregion

        #region Captions
        public struct Captions
        {
			public const string IdtTpFracao="IDTTPFRACAO";
		    public const string DsTpFracao="DSTPFRACAO";

            public const string QtdeConsumida = "QTDECONSUMIDA";

            public const string QtdeConvertida = "QTDECONVERTIDA";
		
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal IdtTpFracao
		{
			get { return mtmd_tp_fracao_id; }
			set { mtmd_tp_fracao_id = value; }
		}
		
		public MVC.DTO.FieldString DsTpFracao
		{
			get { return mtmd_ds_tp_fracao; }
			set { mtmd_ds_tp_fracao = value; }
		}

        public MVC.DTO.FieldDecimal QtdeConsumida
        {
            get { return mtmd_mov_qtde; }
            set { mtmd_mov_qtde = value; }
        }

        public MVC.DTO.FieldDecimal QtdeConvertida
        {
            get { return mtmd_qtd_convertida; }
            set { mtmd_qtd_convertida = value; }
        }

		#endregion


        #region Operators

        public static explicit operator TipoFracaoDTO(DataRow row)
        {
            TipoFracaoDTO  dto = new TipoFracaoDTO();
			
			dto.IdtTpFracao.Value = row[FieldNames.IdtTpFracao].ToString();
			
			dto.DsTpFracao.Value = row[FieldNames.DsTpFracao].ToString();

            dto.QtdeConsumida.Value = row[FieldNames.QtdeConsumida].ToString();

            dto.QtdeConvertida.Value = row[FieldNames.QtdeConvertida].ToString();
                       

            return dto;
        }

        public static explicit operator TipoFracaoDTO(XmlDocument xml)
        {
            TipoFracaoDTO dto = new TipoFracaoDTO();
			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtTpFracao) != null) dto.IdtTpFracao.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtTpFracao).InnerText;			
			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DsTpFracao) != null) dto.DsTpFracao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsTpFracao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeConsumida) != null) dto.QtdeConsumida.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeConsumida).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeConvertida) != null) dto.QtdeConvertida.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeConvertida).InnerText;

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdtTpFracao = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtTpFracao, null);
			
            XmlNode nodeDsTpFracao = xml.CreateNode(XmlNodeType.Element, FieldNames.DsTpFracao, null);

            XmlNode nodeQtdeConsumida = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeConsumida, null);

            XmlNode nodeQtdeConvertida = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeConvertida, null);

			
			if (!this.IdtTpFracao.Value.IsNull) nodeIdtTpFracao.InnerText = this.IdtTpFracao.Value;
			
			if (!this.DsTpFracao.Value.IsNull) nodeDsTpFracao.InnerText = this.DsTpFracao.Value;

            if (!this.QtdeConsumida.Value.IsNull) nodeQtdeConsumida.InnerText = this.QtdeConsumida.Value;

            if (!this.QtdeConvertida.Value.IsNull) nodeQtdeConvertida.InnerText = this.QtdeConvertida.Value;


            nodeData.AppendChild(nodeIdtTpFracao);
			
            nodeData.AppendChild(nodeDsTpFracao);

            nodeData.AppendChild(nodeQtdeConvertida);
					
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(TipoFracaoDTO dto)
        {
            TipoFracaoDataTable dtb = new TipoFracaoDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.IdtTpFracao] = dto.IdtTpFracao.Value;
			
            dtr[FieldNames.DsTpFracao] = dto.DsTpFracao.Value;

            dtr[FieldNames.QtdeConsumida] = dto.QtdeConsumida.Value;

            dtr[FieldNames.QtdeConvertida] = dto.QtdeConvertida.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(TipoFracaoDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


