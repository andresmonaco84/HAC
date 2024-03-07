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
	/// Classe Entidade MatMedSimilarDataTable
	/// </summary>
	[Serializable()]
	public class MatMedSimilarDataTable : DataTable
	{
		
	    public MatMedSimilarDataTable()
            : base()
        {
            this.TableName = "DADOS";

            this.Columns.Add(MatMedSimilarDTO.FieldNames.IdPrincipioAtivo, typeof(decimal));
		    this.Columns.Add(MatMedSimilarDTO.FieldNames.IdProduto, typeof(decimal));
		    this.Columns.Add(MatMedSimilarDTO.FieldNames.FlAtivo, typeof(decimal));
		    this.Columns.Add(MatMedSimilarDTO.FieldNames.DtAtualizacao, typeof(DateTime));
		    this.Columns.Add(MatMedSimilarDTO.FieldNames.IdUsuario, typeof(decimal));
            this.Columns.Add(MatMedSimilarDTO.FieldNames.DsProduto, typeof(String));			
        }
		
        protected MatMedSimilarDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public MatMedSimilarDTO TypedRow(int index)
        {
            return (MatMedSimilarDTO)this.Rows[index];
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

        public void Add(MatMedSimilarDTO dto)
        {
            DataRow dtr = this.NewRow();

		    if (!dto.IdPrincipioAtivo.Value.IsNull) dtr[MatMedSimilarDTO.FieldNames.IdPrincipioAtivo] = (decimal)dto.IdPrincipioAtivo.Value;
            if (!dto.IdProduto.Value.IsNull) dtr[MatMedSimilarDTO.FieldNames.IdProduto] = (decimal)dto.IdProduto.Value;
		    if (!dto.FlAtivo.Value.IsNull) dtr[MatMedSimilarDTO.FieldNames.FlAtivo] = (decimal)dto.FlAtivo.Value;
		    if (!dto.DtAtualizacao.Value.IsNull) dtr[MatMedSimilarDTO.FieldNames.DtAtualizacao] = (DateTime)dto.DtAtualizacao.Value;
		    if (!dto.IdUsuario.Value.IsNull) dtr[MatMedSimilarDTO.FieldNames.IdUsuario] = (decimal)dto.IdUsuario.Value;
            if (!dto.DsProduto.Value.IsNull) dtr[MatMedSimilarDTO.FieldNames.DsProduto] = (String)dto.DsProduto.Value;

            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class MatMedSimilarDTO : MVC.DTO.DTOBase
    {
        public enum Ativo
        {
            NAO = 0,
            SIM = 1
        }

		private MVC.DTO.FieldDecimal cad_mtmd_priati_id;
		private MVC.DTO.FieldDecimal cad_mtmd_id;
		private MVC.DTO.FieldDecimal cad_fl_ativo;
		private MVC.DTO.FieldDateTime cad_mtmd_dt_atualizacao;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario;
        private MVC.DTO.FieldString ds_produto;

        public MatMedSimilarDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
            this.cad_mtmd_priati_id = new MVC.DTO.FieldDecimal(FieldNames.IdPrincipioAtivo, Captions.IdPrincipioAtivo, DbType.Decimal);
            this.cad_mtmd_id = new MVC.DTO.FieldDecimal(FieldNames.IdProduto, Captions.IdProduto, DbType.Decimal);
            this.cad_fl_ativo = new MVC.DTO.FieldDecimal(FieldNames.FlAtivo, Captions.FlAtivo, DbType.Decimal);
		    this.cad_mtmd_dt_atualizacao= new MVC.DTO.FieldDateTime(FieldNames.DtAtualizacao,Captions.DtAtualizacao);
            this.seg_usu_id_usuario = new MVC.DTO.FieldDecimal(FieldNames.IdUsuario, Captions.IdUsuario, DbType.Decimal);
            this.ds_produto = new MVC.DTO.FieldString(FieldNames.DsProduto, Captions.DsProduto, 100);
        }
 
        #region FieldNames

        public struct FieldNames
        {
		    public const string IdPrincipioAtivo="CAD_MTMD_PRIATI_ID";
		    public const string IdProduto="CAD_MTMD_ID";
		    public const string FlAtivo="CAD_FL_ATIVO";
		    public const string DtAtualizacao="CAD_MTMD_DT_ATUALIZACAO";
		    public const string IdUsuario="SEG_USU_ID_USUARIO";
            public const string DsProduto = "CAD_MTMD_NOMEFANTASIA";
        }		

        #endregion

        #region Captions

        public struct Captions
        {
		    public const string IdPrincipioAtivo="IDPRINCIPIOATIVO";
		    public const string IdProduto="IDPRODUTO";
		    public const string FlAtivo="FLATIVO";
		    public const string DtAtualizacao="DTATUALIZACAO";
		    public const string IdUsuario="IDUSUARIO";
            public const string DsProduto = "NOMEFANTASIA";
        }		

        #endregion
		
        #region Atributos Publicos
		
		public MVC.DTO.FieldDecimal IdPrincipioAtivo
		{
			get { return cad_mtmd_priati_id; }
			set { cad_mtmd_priati_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdProduto
		{
			get { return cad_mtmd_id; }
			set { cad_mtmd_id = value; }
		}
		
		public MVC.DTO.FieldDecimal FlAtivo
		{
			get { return cad_fl_ativo; }
			set { cad_fl_ativo = value; }
		}
		
		public MVC.DTO.FieldDateTime DtAtualizacao
		{
			get { return cad_mtmd_dt_atualizacao; }
			set { cad_mtmd_dt_atualizacao = value; }
		}
		
		public MVC.DTO.FieldDecimal IdUsuario
		{
			get { return seg_usu_id_usuario; }
			set { seg_usu_id_usuario = value; }
		}

        public MVC.DTO.FieldString DsProduto
        {
            get { return ds_produto; }
            set { ds_produto = value; }
        }							
			
		#endregion

        #region Operators

        public static explicit operator MatMedSimilarDTO(DataRow row)
        {
            MatMedSimilarDTO  dto = new MatMedSimilarDTO();
			
			dto.IdPrincipioAtivo.Value = row[FieldNames.IdPrincipioAtivo].ToString();
		
			dto.IdProduto.Value = row[FieldNames.IdProduto].ToString();
		
			dto.FlAtivo.Value = row[FieldNames.FlAtivo].ToString();
		
			dto.DtAtualizacao.Value = row[FieldNames.DtAtualizacao].ToString();
		
			dto.IdUsuario.Value = row[FieldNames.IdUsuario].ToString();

            dto.DsProduto.Value = row[FieldNames.DsProduto].ToString();
			
            return dto;
        }

        public static explicit operator MatMedSimilarDTO(XmlDocument xml)
        {
            MatMedSimilarDTO dto = new MatMedSimilarDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdPrincipioAtivo) != null) dto.IdPrincipioAtivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdPrincipioAtivo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdProduto) != null) dto.IdProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdProduto).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.FlAtivo) != null) dto.FlAtivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlAtivo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DtAtualizacao) != null) dto.DtAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtAtualizacao).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdUsuario) != null) dto.IdUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdUsuario).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.DsProduto) != null) dto.DsProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsProduto).InnerText;			
			
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdPrincipioAtivo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdPrincipioAtivo, null);
			
            XmlNode nodeIdProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.IdProduto, null);
			
            XmlNode nodeFlAtivo = xml.CreateNode(XmlNodeType.Element, FieldNames.FlAtivo, null);
			
            XmlNode nodeDtAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DtAtualizacao, null);
			
            XmlNode nodeIdUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdUsuario, null);

            XmlNode nodeDsProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.DsProduto, null);
			
			if (!this.IdPrincipioAtivo.Value.IsNull) nodeIdPrincipioAtivo.InnerText = this.IdPrincipioAtivo.Value;
			
			if (!this.IdProduto.Value.IsNull) nodeIdProduto.InnerText = this.IdProduto.Value;
			
			if (!this.FlAtivo.Value.IsNull) nodeFlAtivo.InnerText = this.FlAtivo.Value;
			
			if (!this.DtAtualizacao.Value.IsNull) nodeDtAtualizacao.InnerText = this.DtAtualizacao.Value;
			
			if (!this.IdUsuario.Value.IsNull) nodeIdUsuario.InnerText = this.IdUsuario.Value;

            if (!this.DsProduto.Value.IsNull) nodeDsProduto.InnerText = this.DsProduto.Value;

            nodeData.AppendChild(nodeIdPrincipioAtivo);
			
            nodeData.AppendChild(nodeIdProduto);
			
            nodeData.AppendChild(nodeFlAtivo);
			
            nodeData.AppendChild(nodeDtAtualizacao);
			
            nodeData.AppendChild(nodeIdUsuario);

            nodeData.AppendChild(nodeDsProduto);
						
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(MatMedSimilarDTO dto)
        {
            MatMedSimilarDataTable dtb = new MatMedSimilarDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.IdPrincipioAtivo] = dto.IdPrincipioAtivo.Value;
			
            dtr[FieldNames.IdProduto] = dto.IdProduto.Value;
			
            dtr[FieldNames.FlAtivo] = dto.FlAtivo.Value;
			
            dtr[FieldNames.DtAtualizacao] = dto.DtAtualizacao.Value;
			
            dtr[FieldNames.IdUsuario] = dto.IdUsuario.Value;

            dtr[FieldNames.DsProduto] = dto.DsProduto.Value;
			
            return dtr;
        }

        public static explicit operator XmlDocument(MatMedSimilarDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}