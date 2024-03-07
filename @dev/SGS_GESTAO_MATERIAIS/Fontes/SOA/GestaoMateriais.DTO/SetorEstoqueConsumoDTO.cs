
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
	/// Classe Entidade SetorEstoqueConsumoDataTable
	/// </summary>
	[Serializable()]
	public class SetorEstoqueConsumoDataTable : DataTable
	{
		
	    public SetorEstoqueConsumoDataTable()
            : base()
        {
            this.TableName = "DADOS";

			this.Columns.Add(SetorEstoqueConsumoDTO.FieldNames.IdtUnidade, typeof(Decimal));
		    this.Columns.Add(SetorEstoqueConsumoDTO.FieldNames.IdtLocal, typeof(Decimal));
		    this.Columns.Add(SetorEstoqueConsumoDTO.FieldNames.IdtSetor, typeof(Decimal));
		    this.Columns.Add(SetorEstoqueConsumoDTO.FieldNames.IdtFilial, typeof(Decimal));
		    this.Columns.Add(SetorEstoqueConsumoDTO.FieldNames.IdtLocalConsumo, typeof(Decimal));
		    this.Columns.Add(SetorEstoqueConsumoDTO.FieldNames.IdtUnidadeConsumo, typeof(Decimal));
		    this.Columns.Add(SetorEstoqueConsumoDTO.FieldNames.IdtSetorConsumo, typeof(Decimal));


            this.Columns.Add(SetorEstoqueConsumoDTO.FieldNames.DsLocalConsumo, typeof(String));
            this.Columns.Add(SetorEstoqueConsumoDTO.FieldNames.DsUnidadeConsumo, typeof(String));
            this.Columns.Add(SetorEstoqueConsumoDTO.FieldNames.DsSetorConsumo, typeof(String));
            this.Columns.Add(SetorEstoqueConsumoDTO.FieldNames.DsFilial, typeof(String));


			

            DataColumn[] primaryKey = {  };

            this.PrimaryKey = primaryKey;
        }
		
        protected SetorEstoqueConsumoDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public SetorEstoqueConsumoDTO TypedRow(int index)
        {
            return (SetorEstoqueConsumoDTO)this.Rows[index];
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

        public void Add(SetorEstoqueConsumoDTO dto)
        {
            DataRow dtr = this.NewRow();


			if (!dto.IdtUnidade.Value.IsNull) dtr[SetorEstoqueConsumoDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;
		    if (!dto.IdtLocal.Value.IsNull) dtr[SetorEstoqueConsumoDTO.FieldNames.IdtLocal] = (Decimal)dto.IdtLocal.Value;
		    if (!dto.IdtSetor.Value.IsNull) dtr[SetorEstoqueConsumoDTO.FieldNames.IdtSetor] = (Decimal)dto.IdtSetor.Value;
		    if (!dto.IdtFilial.Value.IsNull) dtr[SetorEstoqueConsumoDTO.FieldNames.IdtFilial] = (Decimal)dto.IdtFilial.Value;
		    if (!dto.IdtLocalConsumo.Value.IsNull) dtr[SetorEstoqueConsumoDTO.FieldNames.IdtLocalConsumo] = (Decimal)dto.IdtLocalConsumo.Value;
		    if (!dto.IdtUnidadeConsumo.Value.IsNull) dtr[SetorEstoqueConsumoDTO.FieldNames.IdtUnidadeConsumo] = (Decimal)dto.IdtUnidadeConsumo.Value;
		    if (!dto.IdtSetorConsumo.Value.IsNull) dtr[SetorEstoqueConsumoDTO.FieldNames.IdtSetorConsumo] = (Decimal)dto.IdtSetorConsumo.Value;

            if (!dto.DsLocalConsumo.Value.IsNull) dtr[SetorEstoqueConsumoDTO.FieldNames.DsLocalConsumo] = (String)dto.DsLocalConsumo.Value;

            if (!dto.DsSetorConsumo.Value.IsNull) dtr[SetorEstoqueConsumoDTO.FieldNames.DsSetorConsumo] = (String)dto.DsSetorConsumo.Value;
            if (!dto.DsUnidadeConsumo.Value.IsNull) dtr[SetorEstoqueConsumoDTO.FieldNames.DsUnidadeConsumo] = (String)dto.DsUnidadeConsumo.Value;
            if (!dto.DsFilial.Value.IsNull) dtr[SetorEstoqueConsumoDTO.FieldNames.DsFilial] = (String)dto.DsFilial.Value;
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class SetorEstoqueConsumoDTO : MVC.DTO.DTOBase
    {	
			private MVC.DTO.FieldDecimal cad_uni_id_unidade;
		private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
		private MVC.DTO.FieldDecimal cad_set_id;
		private MVC.DTO.FieldDecimal cad_mtmd_filial_id;
		private MVC.DTO.FieldDecimal mtmd_local_estoque_consumo;
		private MVC.DTO.FieldDecimal mtmd_unidade_estoque_consumo;
		private MVC.DTO.FieldDecimal mtmd_setor_estoque_consumo;

        private MVC.DTO.FieldString cad_uni_ds_unidade;
        private MVC.DTO.FieldString cad_lat_ds_local_atendimento;
        private MVC.DTO.FieldString cad_set_ds_setor;
        private MVC.DTO.FieldString cad_mtmd_filial_descricao;

        public SetorEstoqueConsumoDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
				this.cad_uni_id_unidade= new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade,Captions.IdtUnidade, DbType.Decimal);
		    this.cad_lat_id_local_atendimento= new MVC.DTO.FieldDecimal(FieldNames.IdtLocal,Captions.IdtLocal, DbType.Decimal);
		    this.cad_set_id= new MVC.DTO.FieldDecimal(FieldNames.IdtSetor,Captions.IdtSetor, DbType.Decimal);
		    this.cad_mtmd_filial_id= new MVC.DTO.FieldDecimal(FieldNames.IdtFilial,Captions.IdtFilial, DbType.Decimal);
		    this.mtmd_local_estoque_consumo= new MVC.DTO.FieldDecimal(FieldNames.IdtLocalConsumo,Captions.IdtLocalConsumo, DbType.Decimal);
		    this.mtmd_unidade_estoque_consumo= new MVC.DTO.FieldDecimal(FieldNames.IdtUnidadeConsumo,Captions.IdtUnidadeConsumo, DbType.Decimal);
		    this.mtmd_setor_estoque_consumo= new MVC.DTO.FieldDecimal(FieldNames.IdtSetorConsumo,Captions.IdtSetorConsumo, DbType.Decimal);


            this.cad_uni_ds_unidade = new MVC.DTO.FieldString(FieldNames.DsUnidadeConsumo, Captions.DsUnidadeConsumo, 100);
            this.cad_lat_ds_local_atendimento = new MVC.DTO.FieldString(FieldNames.DsLocalConsumo, Captions.DsLocalConsumo, 100);
            this.cad_set_ds_setor = new MVC.DTO.FieldString(FieldNames.DsSetorConsumo, Captions.DsSetorConsumo, 100);
            this.cad_mtmd_filial_descricao = new MVC.DTO.FieldString(FieldNames.DsFilial, Captions.DsFilial, 100);


        }
 
        #region FieldNames

        public struct FieldNames
        {
				public const string IdtUnidade="CAD_UNI_ID_UNIDADE";
		    public const string IdtLocal="CAD_LAT_ID_LOCAL_ATENDIMENTO";
		    public const string IdtSetor="CAD_SET_ID";
		    public const string IdtFilial="CAD_MTMD_FILIAL_ID";
		    public const string IdtLocalConsumo="MTMD_LOCAL_ESTOQUE_CONSUMO";
		    public const string IdtUnidadeConsumo="MTMD_UNIDADE_ESTOQUE_CONSUMO";
		    public const string IdtSetorConsumo="MTMD_SETOR_ESTOQUE_CONSUMO";

            public const string DsUnidadeConsumo = "CAD_UNI_DS_UNIDADE";
            public const string DsLocalConsumo = "CAD_LAT_DS_LOCAL_ATENDIMENTO";
            public const string DsSetorConsumo = "CAD_SET_DS_SETOR";
            public const string DsFilial = "CAD_MTMD_FILIAL_DESCRICAO";
		
        }		

        #endregion

        #region Captions
        public struct Captions
        {
			public const string IdtUnidade="IDTUNIDADE";
		    public const string IdtLocal="IDTLOCAL";
		    public const string IdtSetor="IDTSETOR";
		    public const string IdtFilial="IDTFILIAL";
		    public const string IdtLocalConsumo="IDTLOCALCONSUMO";
		    public const string IdtUnidadeConsumo="IDTUNIDADECONSUMO";
		    public const string IdtSetorConsumo="IDTSETORCONSUMO";

            public const string DsUnidadeConsumo = "DSUNIDADECONSUMO";
            public const string DsLocalConsumo = "DSLOCALCONSUMO";
            public const string DsSetorConsumo = "DSSETORCONSUMO";
            public const string DsFilial = "DSFILIAL";

        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal IdtUnidade
		{
			get { return cad_uni_id_unidade; }
			set { cad_uni_id_unidade = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtLocal
		{
			get { return cad_lat_id_local_atendimento; }
			set { cad_lat_id_local_atendimento = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtSetor
		{
			get { return cad_set_id; }
			set { cad_set_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtFilial
		{
			get { return cad_mtmd_filial_id; }
			set { cad_mtmd_filial_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtLocalConsumo
		{
			get { return mtmd_local_estoque_consumo; }
			set { mtmd_local_estoque_consumo = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtUnidadeConsumo
		{
			get { return mtmd_unidade_estoque_consumo; }
			set { mtmd_unidade_estoque_consumo = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtSetorConsumo
		{
			get { return mtmd_setor_estoque_consumo; }
			set { mtmd_setor_estoque_consumo = value; }
		}


        public MVC.DTO.FieldString DsUnidadeConsumo
        {
            get { return cad_uni_ds_unidade; }
            set { cad_uni_ds_unidade = value; }
        }


        public MVC.DTO.FieldString DsLocalConsumo
        {
            get { return cad_lat_ds_local_atendimento; }
            set { cad_lat_ds_local_atendimento = value; }
        }

        public MVC.DTO.FieldString DsSetorConsumo
        {
            get { return cad_set_ds_setor; }
            set { cad_set_ds_setor = value; }
        }

        public MVC.DTO.FieldString DsFilial
        {
            get { return cad_mtmd_filial_descricao; }
            set { cad_mtmd_filial_descricao = value; }
        }
			
		#endregion


        #region Operators

        public static explicit operator SetorEstoqueConsumoDTO(DataRow row)
        {
            SetorEstoqueConsumoDTO  dto = new SetorEstoqueConsumoDTO();
			
				dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();
			
				dto.IdtLocal.Value = row[FieldNames.IdtLocal].ToString();
			
				dto.IdtSetor.Value = row[FieldNames.IdtSetor].ToString();
			
				dto.IdtFilial.Value = row[FieldNames.IdtFilial].ToString();
			
				dto.IdtLocalConsumo.Value = row[FieldNames.IdtLocalConsumo].ToString();
			
				dto.IdtUnidadeConsumo.Value = row[FieldNames.IdtUnidadeConsumo].ToString();
			
				dto.IdtSetorConsumo.Value = row[FieldNames.IdtSetorConsumo].ToString();


                dto.DsUnidadeConsumo.Value = row[FieldNames.DsUnidadeConsumo].ToString();

                dto.DsLocalConsumo.Value = row[FieldNames.DsLocalConsumo].ToString();

                dto.DsSetorConsumo.Value = row[FieldNames.DsSetorConsumo].ToString();

                dto.DsFilial.Value = row[FieldNames.DsFilial].ToString();

            return dto;
        }

        public static explicit operator SetorEstoqueConsumoDTO(XmlDocument xml)
        {
            SetorEstoqueConsumoDTO dto = new SetorEstoqueConsumoDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal) != null) dto.IdtLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor) != null) dto.IdtSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial) != null) dto.IdtFilial.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalConsumo) != null) dto.IdtLocalConsumo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalConsumo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidadeConsumo) != null) dto.IdtUnidadeConsumo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidadeConsumo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetorConsumo) != null) dto.IdtSetorConsumo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetorConsumo).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeConsumo) != null) dto.DsUnidadeConsumo.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeConsumo).InnerText;
                if (xml.FirstChild.SelectSingleNode(FieldNames.DsLocalConsumo) != null) dto.DsLocalConsumo.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsLocalConsumo).InnerText;
                if (xml.FirstChild.SelectSingleNode(FieldNames.DsSetorConsumo) != null) dto.DsSetorConsumo.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsSetorConsumo).InnerText;
                if (xml.FirstChild.SelectSingleNode(FieldNames.DsFilial) != null) dto.DsFilial.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsFilial).InnerText;

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);
			
            XmlNode nodeIdtLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocal, null);
			
            XmlNode nodeIdtSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetor, null);
			
            XmlNode nodeIdtFilial = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFilial, null);
			
            XmlNode nodeIdtLocalConsumo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocalConsumo, null);
			
            XmlNode nodeIdtUnidadeConsumo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidadeConsumo, null);
			
            XmlNode nodeIdtSetorConsumo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetorConsumo, null);

            XmlNode nodeDsUnidadeConsumo = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidadeConsumo, null);
            XmlNode nodeDsLocalConsumo = xml.CreateNode(XmlNodeType.Element, FieldNames.DsLocalConsumo, null);
            XmlNode nodeDsSetorConsumo = xml.CreateNode(XmlNodeType.Element, FieldNames.DsSetorConsumo, null);
            XmlNode nodeDsFilial = xml.CreateNode(XmlNodeType.Element, FieldNames.DsFilial, null);

			
			if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;
			
			if (!this.IdtLocal.Value.IsNull) nodeIdtLocal.InnerText = this.IdtLocal.Value;
			
			if (!this.IdtSetor.Value.IsNull) nodeIdtSetor.InnerText = this.IdtSetor.Value;
			
			if (!this.IdtFilial.Value.IsNull) nodeIdtFilial.InnerText = this.IdtFilial.Value;
			
			if (!this.IdtLocalConsumo.Value.IsNull) nodeIdtLocalConsumo.InnerText = this.IdtLocalConsumo.Value;
			
			if (!this.IdtUnidadeConsumo.Value.IsNull) nodeIdtUnidadeConsumo.InnerText = this.IdtUnidadeConsumo.Value;
			
			if (!this.IdtSetorConsumo.Value.IsNull) nodeIdtSetorConsumo.InnerText = this.IdtSetorConsumo.Value;

            if (!this.DsUnidadeConsumo.Value.IsNull) nodeDsUnidadeConsumo.InnerText = this.DsUnidadeConsumo.Value;
            if (!this.DsLocalConsumo.Value.IsNull) nodeDsLocalConsumo.InnerText = this.DsLocalConsumo.Value;
            if (!this.DsSetorConsumo.Value.IsNull) nodeDsSetorConsumo.InnerText = this.DsSetorConsumo.Value;
            if (!this.DsFilial.Value.IsNull) nodeDsFilial.InnerText = this.DsFilial.Value;
			
            nodeData.AppendChild(nodeIdtUnidade);
			
            nodeData.AppendChild(nodeIdtLocal);
			
            nodeData.AppendChild(nodeIdtSetor);
			
            nodeData.AppendChild(nodeIdtFilial);
			
            nodeData.AppendChild(nodeIdtLocalConsumo);
			
            nodeData.AppendChild(nodeIdtUnidadeConsumo);
			
            nodeData.AppendChild(nodeIdtSetorConsumo);

            nodeData.AppendChild(nodeDsUnidadeConsumo);
            nodeData.AppendChild(nodeDsLocalConsumo);
            nodeData.AppendChild(nodeDsSetorConsumo);
            nodeData.AppendChild(nodeDsFilial);

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(SetorEstoqueConsumoDTO dto)
        {
            SetorEstoqueConsumoDataTable dtb = new SetorEstoqueConsumoDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;
			
            dtr[FieldNames.IdtLocal] = dto.IdtLocal.Value;
			
            dtr[FieldNames.IdtSetor] = dto.IdtSetor.Value;
			
            dtr[FieldNames.IdtFilial] = dto.IdtFilial.Value;
			
            dtr[FieldNames.IdtLocalConsumo] = dto.IdtLocalConsumo.Value;
			
            dtr[FieldNames.IdtUnidadeConsumo] = dto.IdtUnidadeConsumo.Value;
			
            dtr[FieldNames.IdtSetorConsumo] = dto.IdtSetorConsumo.Value;

            dtr[FieldNames.DsUnidadeConsumo] = dto.DsUnidadeConsumo.Value;
            dtr[FieldNames.DsLocalConsumo] = dto.DsLocalConsumo.Value;
            dtr[FieldNames.DsSetorConsumo] = dto.DsSetorConsumo.Value;
            dtr[FieldNames.DsFilial] = dto.DsFilial.Value;


            return dtr;
        }

        public static explicit operator XmlDocument(SetorEstoqueConsumoDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


