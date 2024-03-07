
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
	/// Classe Entidade LocalEstoqueDataTable
	/// </summary>
	[Serializable()]
	public class LocalEstoqueDataTable : DataTable
	{
		
	    public LocalEstoqueDataTable()
            : base()
        {
            this.TableName = "DADOS";

			this.Columns.Add(LocalEstoqueDTO.FieldNames.IdtLocalEstoque, typeof(decimal));
		    this.Columns.Add(LocalEstoqueDTO.FieldNames.DsLocalEstoque, typeof(string));
		    this.Columns.Add(LocalEstoqueDTO.FieldNames.IdtUnidade, typeof(decimal));
		    this.Columns.Add(LocalEstoqueDTO.FieldNames.IdtLocal, typeof(decimal));
		    this.Columns.Add(LocalEstoqueDTO.FieldNames.IdtSetor, typeof(decimal));
            this.Columns.Add(LocalEstoqueDTO.FieldNames.Ativo, typeof(decimal));
            this.Columns.Add(LocalEstoqueDTO.FieldNames.TpMovimentacaoEntrada, typeof(string));

            DataColumn[] primaryKey = { this.Columns[LocalEstoqueDTO.FieldNames.IdtLocalEstoque] };

            

            this.PrimaryKey = primaryKey;
        }
		
        protected LocalEstoqueDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public LocalEstoqueDTO TypedRow(int index)
        {
            return (LocalEstoqueDTO)this.Rows[index];
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

        public void Add(LocalEstoqueDTO dto)
        {
            DataRow dtr = this.NewRow();

			if (!dto.IdtLocalEstoque.Value.IsNull) dtr[LocalEstoqueDTO.FieldNames.IdtLocalEstoque] = (decimal)dto.IdtLocalEstoque.Value;
		    if (!dto.DsLocalEstoque.Value.IsNull) dtr[LocalEstoqueDTO.FieldNames.DsLocalEstoque] = (string)dto.DsLocalEstoque.Value;
		    if (!dto.IdtUnidade.Value.IsNull) dtr[LocalEstoqueDTO.FieldNames.IdtUnidade] = (decimal)dto.IdtUnidade.Value;
		    if (!dto.IdtLocal.Value.IsNull) dtr[LocalEstoqueDTO.FieldNames.IdtLocal] = (decimal)dto.IdtLocal.Value;
		    if (!dto.IdtSetor.Value.IsNull) dtr[LocalEstoqueDTO.FieldNames.IdtSetor] = (decimal)dto.IdtSetor.Value;
            if (!dto.Ativo.Value.IsNull) dtr[LocalEstoqueDTO.FieldNames.Ativo] = (decimal)dto.Ativo.Value;
            if (!dto.TpMovimentacaoEntrada.Value.IsNull) dtr[LocalEstoqueDTO.FieldNames.TpMovimentacaoEntrada] = (string)dto.TpMovimentacaoEntrada.Value;

			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class LocalEstoqueDTO : MVC.DTO.DTOBase
    {	
		private MVC.DTO.FieldDecimal mtmd_id_tp_ccusto;
		private MVC.DTO.FieldString mtmd_ds_tp_ccusto;
		private MVC.DTO.FieldDecimal cad_uni_id_unidade;
		private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
		private MVC.DTO.FieldDecimal cad_set_id;
        private MVC.DTO.FieldDecimal mtmd_mccusto_ativo;
        private MVC.DTO.FieldString mtmd_tipo_mov_entrada;

        

        public LocalEstoqueDTO()
        {
            InitializeComponent();
        }

        internal void InitializeComponent()
        {
            this.mtmd_id_tp_ccusto = new MVC.DTO.FieldDecimal(FieldNames.IdtLocalEstoque, Captions.IdtLocalEstoque, DbType.Decimal);
            this.mtmd_ds_tp_ccusto = new MVC.DTO.FieldString(FieldNames.DsLocalEstoque, Captions.DsLocalEstoque, 100);
            this.cad_uni_id_unidade = new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade, Captions.IdtUnidade, DbType.Decimal);
            this.cad_lat_id_local_atendimento = new MVC.DTO.FieldDecimal(FieldNames.IdtLocal, Captions.IdtLocal, DbType.Decimal);
            this.cad_set_id = new MVC.DTO.FieldDecimal(FieldNames.IdtSetor, Captions.IdtSetor, DbType.Decimal);
            this.mtmd_mccusto_ativo = new MVC.DTO.FieldDecimal(FieldNames.Ativo, Captions.Ativo, DbType.Decimal);
            this.mtmd_tipo_mov_entrada = new MVC.DTO.FieldString(FieldNames.TpMovimentacaoEntrada, Captions.TpMovimentacaoEntrada, 100);

            

        }
 
        #region FieldNames

        public struct FieldNames
        {
			public const string IdtLocalEstoque="MTMD_ID_TP_CCUSTO";
		    public const string DsLocalEstoque="MTMD_DS_TP_CCUSTO";
		    public const string IdtUnidade="CAD_UNI_ID_UNIDADE";
		    public const string IdtLocal="CAD_LAT_ID_LOCAL_ATENDIMENTO";
		    public const string IdtSetor="CAD_SET_ID";
            public const string Ativo = "MTMD_MCCUSTO_ATIVO";

            public const string TpMovimentacaoEntrada = "MTMD_TIPO_MOV_ENTRADA";

                       
        }		

        #endregion

        #region Captions
        public struct Captions
        {
			public const string IdtLocalEstoque="IDTLOCALESTOQUE";
		    public const string DsLocalEstoque="DsLocalEstoque";
		    public const string IdtUnidade="IDTUNIDADE";
		    public const string IdtLocal="IDTLOCAL";
            public const string IdtSetor = "IDTSETOR";
		    public const string Ativo="ATIVO";
            public const string TpMovimentacaoEntrada = "TPMOVIMENTACAOENTRADA";
                        
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal IdtLocalEstoque
		{
			get { return mtmd_id_tp_ccusto; }
			set { mtmd_id_tp_ccusto = value; }
		}
		
		public MVC.DTO.FieldString DsLocalEstoque
		{
			get { return mtmd_ds_tp_ccusto; }
			set { mtmd_ds_tp_ccusto = value; }
		}
		
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

        public MVC.DTO.FieldDecimal Ativo
        {
            get { return mtmd_mccusto_ativo; }
            set { mtmd_mccusto_ativo = value; }
        }

        /// <summary>
        /// Tipo de Movimentação gerada na entrada da nota no Sistema RM
        /// </summary>
        public MVC.DTO.FieldString TpMovimentacaoEntrada
        {
            get { return mtmd_tipo_mov_entrada; }
            set { mtmd_tipo_mov_entrada = value; }
        }
                
			
		#endregion


        #region Operators

        public static explicit operator LocalEstoqueDTO(DataRow row)
        {
            LocalEstoqueDTO  dto = new LocalEstoqueDTO();
			
				dto.IdtLocalEstoque.Value = row[FieldNames.IdtLocalEstoque].ToString();
			
				dto.DsLocalEstoque.Value = row[FieldNames.DsLocalEstoque].ToString();
			
				dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();
			
				dto.IdtLocal.Value = row[FieldNames.IdtLocal].ToString();
			
				dto.IdtSetor.Value = row[FieldNames.IdtSetor].ToString();

                dto.Ativo.Value = row[FieldNames.Ativo].ToString();

                dto.TpMovimentacaoEntrada.Value = row[FieldNames.TpMovimentacaoEntrada].ToString();
                            
			
            return dto;
        }

        public static explicit operator LocalEstoqueDTO(XmlDocument xml)
        {
            LocalEstoqueDTO dto = new LocalEstoqueDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalEstoque) != null) dto.IdtLocalEstoque.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalEstoque).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DsLocalEstoque) != null) dto.DsLocalEstoque.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsLocalEstoque).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal) != null) dto.IdtLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor) != null) dto.IdtSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.Ativo) != null) dto.Ativo.Value = xml.FirstChild.SelectSingleNode(FieldNames.Ativo).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.TpMovimentacaoEntrada) != null) dto.TpMovimentacaoEntrada.Value = xml.FirstChild.SelectSingleNode(FieldNames.TpMovimentacaoEntrada).InnerText;

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdtLocalEstoque = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocalEstoque, null);
			
            XmlNode nodeDsLocalEstoque = xml.CreateNode(XmlNodeType.Element, FieldNames.DsLocalEstoque, null);
			
            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);
			
            XmlNode nodeIdtLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocal, null);
			
            XmlNode nodeIdtSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetor, null);

            XmlNode nodeAtivo = xml.CreateNode(XmlNodeType.Element, FieldNames.Ativo, null);

            XmlNode nodeTpMovimentacaoEntrada = xml.CreateNode(XmlNodeType.Element, FieldNames.TpMovimentacaoEntrada, null);
                        
			
			if (!this.IdtLocalEstoque.Value.IsNull) nodeIdtLocalEstoque.InnerText = this.IdtLocalEstoque.Value;
			
			if (!this.DsLocalEstoque.Value.IsNull) nodeDsLocalEstoque.InnerText = this.DsLocalEstoque.Value;
			
			if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;
			
			if (!this.IdtLocal.Value.IsNull) nodeIdtLocal.InnerText = this.IdtLocal.Value;
			
			if (!this.IdtSetor.Value.IsNull) nodeIdtSetor.InnerText = this.IdtSetor.Value;

            if (!this.Ativo.Value.IsNull) nodeAtivo.InnerText = this.Ativo.Value;

            if (!this.TpMovimentacaoEntrada.Value.IsNull) nodeTpMovimentacaoEntrada.InnerText = this.TpMovimentacaoEntrada.Value;
                       

			
            nodeData.AppendChild(nodeIdtLocalEstoque);
			
            nodeData.AppendChild(nodeDsLocalEstoque);
			
            nodeData.AppendChild(nodeIdtUnidade);
			
            nodeData.AppendChild(nodeIdtLocal);
			
            nodeData.AppendChild(nodeIdtSetor);

            nodeData.AppendChild(nodeAtivo);

            nodeData.AppendChild(nodeTpMovimentacaoEntrada);
                        
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(LocalEstoqueDTO dto)
        {
            LocalEstoqueDataTable dtb = new LocalEstoqueDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.IdtLocalEstoque] = dto.IdtLocalEstoque.Value;
			
            dtr[FieldNames.DsLocalEstoque] = dto.DsLocalEstoque.Value;
			
            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;
			
            dtr[FieldNames.IdtLocal] = dto.IdtLocal.Value;
			
            dtr[FieldNames.IdtSetor] = dto.IdtSetor.Value;

            dtr[FieldNames.Ativo] = dto.Ativo.Value;

            dtr[FieldNames.TpMovimentacaoEntrada] = dto.TpMovimentacaoEntrada.Value;
                       
			
            return dtr;
        }

        public static explicit operator XmlDocument(LocalEstoqueDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


