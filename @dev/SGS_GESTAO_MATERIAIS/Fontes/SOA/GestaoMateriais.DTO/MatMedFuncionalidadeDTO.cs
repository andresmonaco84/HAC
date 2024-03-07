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
	/// Classe Entidade MatMedFuncionalidadeDataTable
	/// </summary>
	[Serializable()]
	public class MatMedFuncionalidadeDataTable : DataTable
	{
		
	    public MatMedFuncionalidadeDataTable()
            : base()
        {
            this.TableName = "DADOS";

					this.Columns.Add(MatMedFuncionalidadeDTO.FieldNames.IdFuncionalidade, typeof(decimal));
		this.Columns.Add(MatMedFuncionalidadeDTO.FieldNames.IdProduto, typeof(decimal));
		this.Columns.Add(MatMedFuncionalidadeDTO.FieldNames.DataAtualizacao, typeof(DateTime));
		this.Columns.Add(MatMedFuncionalidadeDTO.FieldNames.IdUsuario, typeof(decimal));
        this.Columns.Add(MaterialMedicamentoDTO.FieldNames.NomeFantasia, typeof(String));
        this.Columns.Add(MatMedFuncionalidadeDTO.FieldNames.QtdeMaximaPedido, typeof(decimal));
			

            DataColumn[] primaryKey = { this.Columns[MatMedFuncionalidadeDTO.FieldNames.IdProduto], this.Columns[MatMedFuncionalidadeDTO.FieldNames.IdFuncionalidade] };

            this.PrimaryKey = primaryKey;
        }
		
        protected MatMedFuncionalidadeDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public MatMedFuncionalidadeDTO TypedRow(int index)
        {
            return (MatMedFuncionalidadeDTO)this.Rows[index];
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

        public void Add(MatMedFuncionalidadeDTO dto)
        {
            DataRow dtr = this.NewRow();


					if (!dto.IdFuncionalidade.Value.IsNull) dtr[MatMedFuncionalidadeDTO.FieldNames.IdFuncionalidade] = (decimal)dto.IdFuncionalidade.Value;
		if (!dto.IdProduto.Value.IsNull) dtr[MatMedFuncionalidadeDTO.FieldNames.IdProduto] = (decimal)dto.IdProduto.Value;
		if (!dto.DataAtualizacao.Value.IsNull) dtr[MatMedFuncionalidadeDTO.FieldNames.DataAtualizacao] = (DateTime)dto.DataAtualizacao.Value;
		if (!dto.IdUsuario.Value.IsNull) dtr[MatMedFuncionalidadeDTO.FieldNames.IdUsuario] = (decimal)dto.IdUsuario.Value;
        if (!dto.NomeFantasia.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.NomeFantasia] = (String)dto.NomeFantasia.Value;
        if (!dto.QtdeMaximaPedido.Value.IsNull) dtr[MatMedFuncionalidadeDTO.FieldNames.QtdeMaximaPedido] = (decimal)dto.QtdeMaximaPedido.Value;
			
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class MatMedFuncionalidadeDTO : MVC.DTO.DTOBase
    {	
			private MVC.DTO.FieldDecimal seg_fun_id_funcionalidade;
		private MVC.DTO.FieldDecimal cad_mtmd_id;
		private MVC.DTO.FieldDateTime mtmd_dt_atualizacao;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario;
        private MVC.DTO.FieldString cad_mtmd_nomefantasia;
        private MVC.DTO.FieldDecimal qtde_maxima_pedido;

        public MatMedFuncionalidadeDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
            this.seg_fun_id_funcionalidade = new MVC.DTO.FieldDecimal(FieldNames.IdFuncionalidade, Captions.IdFuncionalidade, DbType.Decimal);
            this.cad_mtmd_id = new MVC.DTO.FieldDecimal(FieldNames.IdProduto, Captions.IdProduto, DbType.Decimal);
            this.seg_usu_id_usuario = new MVC.DTO.FieldDecimal(FieldNames.IdUsuario, Captions.IdUsuario, DbType.Decimal);
            this.mtmd_dt_atualizacao= new MVC.DTO.FieldDateTime(FieldNames.DataAtualizacao,Captions.DataAtualizacao);		
            this.cad_mtmd_nomefantasia= new MVC.DTO.FieldString(FieldNames.NomeFantasia,Captions.NomeFantasia, 100);
            this.qtde_maxima_pedido = new MVC.DTO.FieldDecimal(FieldNames.QtdeMaximaPedido, Captions.QtdeMaximaPedido, DbType.Decimal);
        }
 
        #region FieldNames

        public struct FieldNames
        {
				public const string IdFuncionalidade="SEG_FUN_ID_FUNCIONALIDADE";
		public const string IdProduto="CAD_MTMD_ID";
		public const string DataAtualizacao="MTMD_DT_ATUALIZACAO";
		public const string IdUsuario="SEG_USU_ID_USUARIO";
            public const string NomeFantasia = "CAD_MTMD_NOMEFANTASIA";
            public const string QtdeMaximaPedido = "QTDE_MAXIMA_PEDIDO";
        }		

        #endregion

        #region Captions
        public struct Captions
        {
				public const string IdFuncionalidade="IDFUNCIONALIDADE";
		public const string IdProduto="IDPRODUTO";
		public const string DataAtualizacao="DATAATUALIZACAO";
		public const string IdUsuario="IDUSUARIO";
            public const string NomeFantasia = "NOMEFANTASIA";
            public const string QtdeMaximaPedido = "QTDEMAXIMAPEDIDO";
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal IdFuncionalidade
		{
			get { return seg_fun_id_funcionalidade; }
			set { seg_fun_id_funcionalidade = value; }
		}
		
		public MVC.DTO.FieldDecimal IdProduto
		{
			get { return cad_mtmd_id; }
			set { cad_mtmd_id = value; }
		}
		
		public MVC.DTO.FieldDateTime DataAtualizacao
		{
			get { return mtmd_dt_atualizacao; }
			set { mtmd_dt_atualizacao = value; }
		}
		
		public MVC.DTO.FieldDecimal IdUsuario
		{
			get { return seg_usu_id_usuario; }
			set { seg_usu_id_usuario = value; }
		}

        public MVC.DTO.FieldString NomeFantasia
        {
            get { return cad_mtmd_nomefantasia; }
            set { cad_mtmd_nomefantasia = value; }
        }

        public MVC.DTO.FieldDecimal QtdeMaximaPedido
        {
            get { return qtde_maxima_pedido; }
            set { qtde_maxima_pedido = value; }
        }	
		#endregion


        #region Operators

        public static explicit operator MatMedFuncionalidadeDTO(DataRow row)
        {
            MatMedFuncionalidadeDTO  dto = new MatMedFuncionalidadeDTO();
			
				dto.IdFuncionalidade.Value = row[FieldNames.IdFuncionalidade].ToString();
			
				dto.IdProduto.Value = row[FieldNames.IdProduto].ToString();
			
				dto.DataAtualizacao.Value = row[FieldNames.DataAtualizacao].ToString();
			
				dto.IdUsuario.Value = row[FieldNames.IdUsuario].ToString();

                dto.NomeFantasia.Value = row[FieldNames.NomeFantasia].ToString();

                dto.QtdeMaximaPedido.Value = row[FieldNames.QtdeMaximaPedido].ToString();
			
            return dto;
        }

        public static explicit operator MatMedFuncionalidadeDTO(XmlDocument xml)
        {
            MatMedFuncionalidadeDTO dto = new MatMedFuncionalidadeDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdFuncionalidade) != null) dto.IdFuncionalidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdFuncionalidade).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdProduto) != null) dto.IdProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdProduto).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizacao) != null) dto.DataAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizacao).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdUsuario) != null) dto.IdUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdUsuario).InnerText;			
			
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdFuncionalidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdFuncionalidade, null);
			
            XmlNode nodeIdProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.IdProduto, null);
			
            XmlNode nodeDataAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DataAtualizacao, null);
			
            XmlNode nodeIdUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdUsuario, null);
			
			
			if (!this.IdFuncionalidade.Value.IsNull) nodeIdFuncionalidade.InnerText = this.IdFuncionalidade.Value;
			
			if (!this.IdProduto.Value.IsNull) nodeIdProduto.InnerText = this.IdProduto.Value;
			
			if (!this.DataAtualizacao.Value.IsNull) nodeDataAtualizacao.InnerText = this.DataAtualizacao.Value;
			
			if (!this.IdUsuario.Value.IsNull) nodeIdUsuario.InnerText = this.IdUsuario.Value;
			
			
            nodeData.AppendChild(nodeIdFuncionalidade);
			
            nodeData.AppendChild(nodeIdProduto);
			
            nodeData.AppendChild(nodeDataAtualizacao);
			
            nodeData.AppendChild(nodeIdUsuario);
						
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(MatMedFuncionalidadeDTO dto)
        {
            MatMedFuncionalidadeDataTable dtb = new MatMedFuncionalidadeDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.IdFuncionalidade] = dto.IdFuncionalidade.Value;
			
            dtr[FieldNames.IdProduto] = dto.IdProduto.Value;
			
            dtr[FieldNames.DataAtualizacao] = dto.DataAtualizacao.Value;
			
            dtr[FieldNames.IdUsuario] = dto.IdUsuario.Value;

            dtr[FieldNames.NomeFantasia] = dto.NomeFantasia.Value;

            dtr[FieldNames.QtdeMaximaPedido] = dto.QtdeMaximaPedido.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(MatMedFuncionalidadeDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


