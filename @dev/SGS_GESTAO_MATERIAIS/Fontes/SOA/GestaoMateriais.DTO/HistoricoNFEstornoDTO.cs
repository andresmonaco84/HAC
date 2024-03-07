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
	/// Classe Entidade HistoricoNFEstornoDataTable
	/// </summary>
	[Serializable()]
	public class HistoricoNFEstornoDataTable : DataTable
	{
		
		public HistoricoNFEstornoDataTable()
			: base()
		{
		
			this.TableName = "HistoricoNFEstorno";

			this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.IdtProduto, typeof(Decimal));
		    this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.IdtProdutoAcerto, typeof(Decimal));
		    this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.IdtFilial, typeof(Decimal));
		    this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.NrNota, typeof(String));
		    this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.IdMovRM, typeof(Decimal));
		    this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.QtdeEstorno, typeof(Decimal));
		    this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.DsFornecedor, typeof(String));
		    this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.TpMov, typeof(String));
		    this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.Motivo, typeof(String));
		    this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.IdMovSGS, typeof(Decimal));
		    this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.DataAtualizacao, typeof(DateTime));
		    this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.UsuarioAtualizacao, typeof(Decimal));
            this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.Status, typeof(Decimal));
            this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.DataAcerto, typeof(DateTime));
            this.Columns.Add(HistoricoNFEstornoDTO.FieldNames.IdtLote, typeof(Decimal));

            //DataColumn[] primaryKey = { this.Columns[HistoricoNFEstornoDTO.FieldNames.IdtFilial], this.Columns[HistoricoNFEstornoDTO.FieldNames.IdtProduto], this.Columns[HistoricoNFEstornoDTO.FieldNames.IdMovRM], this.Columns[HistoricoNFEstornoDTO.FieldNames.NrNota] };

            //this.PrimaryKey = primaryKey;
		}
		
		protected HistoricoNFEstornoDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
		: base(serializationInfo, streamingContext){}


		public HistoricoNFEstornoDTO TypedRow(int index)
		{
			return (HistoricoNFEstornoDTO)this.Rows[index];
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

		public void Add(HistoricoNFEstornoDTO dto)
		{
			DataRow dtr = this.NewRow();

			if (!dto.IdtProduto.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.IdtProduto] = (Decimal)dto.IdtProduto.Value;
		    if (!dto.IdtProdutoAcerto.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.IdtProdutoAcerto] = (Decimal)dto.IdtProdutoAcerto.Value;
		    if (!dto.IdtFilial.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.IdtFilial] = (Decimal)dto.IdtFilial.Value;
		    if (!dto.NrNota.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.NrNota] = (String)dto.NrNota.Value;
		    if (!dto.IdMovRM.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.IdMovRM] = (Decimal)dto.IdMovRM.Value;
		    if (!dto.QtdeEstorno.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.QtdeEstorno] = (Decimal)dto.QtdeEstorno.Value;
		    if (!dto.DsFornecedor.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.DsFornecedor] = (String)dto.DsFornecedor.Value;
		    if (!dto.TpMov.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.TpMov] = (String)dto.TpMov.Value;
		    if (!dto.Motivo.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.Motivo] = (String)dto.Motivo.Value;
		    if (!dto.IdMovSGS.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.IdMovSGS] = (Decimal)dto.IdMovSGS.Value;
		    if (!dto.DataAtualizacao.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.DataAtualizacao] = (DateTime)dto.DataAtualizacao.Value;
		    if (!dto.UsuarioAtualizacao.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.UsuarioAtualizacao] = (Decimal)dto.UsuarioAtualizacao.Value;
            if (!dto.StatusEstorno.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.Status] = (Decimal)dto.StatusEstorno.Value;
            if (!dto.DataAcerto.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.DataAcerto] = (DateTime)dto.DataAcerto.Value;
            if (!dto.IdtLote.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.IdtLote] = (Decimal)dto.IdtLote.Value;
			this.Rows.Add(dtr);
		}
		
		public HistoricoNFEstornoEnumerator GetEnumerator()
		{
			return new HistoricoNFEstornoEnumerator(this);
		}
	}
	
	// Inner class implements IEnumerator interface:
	public class HistoricoNFEstornoEnumerator
	{
		private int position = -1;
		private DataTable dtb;

		public HistoricoNFEstornoEnumerator(DataTable dtb)
		{
			this.dtb = dtb;
		}

		// Declare the MoveNext method required by IEnumerator:
		public bool MoveNext()
		{
			if (position < dtb.Rows.Count - 1)
			{
				position++;
				return true;
			}
			else
			{
				return false;
			}
		}

		// Declare the Reset method required by IEnumerator:
		public void Reset()
		{
			position = -1;
		}

		// Declare the Current property required by IEnumerator:
		public HistoricoNFEstornoDTO Current
		{
		get
			{
				HistoricoNFEstornoDTO dto = new HistoricoNFEstornoDTO();			
				dto.IdtProduto.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.IdtProduto].ToString();
				dto.IdtProdutoAcerto.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.IdtProdutoAcerto].ToString();
				dto.IdtFilial.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.IdtFilial].ToString();
				dto.NrNota.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.NrNota].ToString();
				dto.IdMovRM.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.IdMovRM].ToString();
				dto.QtdeEstorno.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.QtdeEstorno].ToString();
				dto.DsFornecedor.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.DsFornecedor].ToString();
				dto.TpMov.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.TpMov].ToString();
				dto.Motivo.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.Motivo].ToString();
				dto.IdMovSGS.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.IdMovSGS].ToString();
				dto.DataAtualizacao.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.DataAtualizacao].ToString();
				dto.UsuarioAtualizacao.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.UsuarioAtualizacao].ToString();
                dto.StatusEstorno.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.Status].ToString();
                dto.DataAcerto.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.DataAcerto].ToString();
                dto.IdtLote.Value = dtb.Rows[position][HistoricoNFEstornoDTO.FieldNames.IdtLote].ToString();
				return dto;
			}
		}
	}
	
	[Serializable()]
	public class HistoricoNFEstornoDTO : MVC.DTO.DTOBase
	{
        public enum Status
        {
            PENDENTE_ACERTO = 0,
            OK = 1
        }

		private MVC.DTO.FieldDecimal cad_mtmd_id;
		private MVC.DTO.FieldDecimal cad_mtmd_id_acerto;
		private MVC.DTO.FieldDecimal cad_mtmd_filial_id;
		private MVC.DTO.FieldString mtmd_nr_nota;
		private MVC.DTO.FieldDecimal idmov;
		private MVC.DTO.FieldDecimal mtmd_qtde;
		private MVC.DTO.FieldString ds_fornecedor;
		private MVC.DTO.FieldString tp_movimento;
		private MVC.DTO.FieldString nf_motivo_estorno;
		private MVC.DTO.FieldDecimal mtmd_mov_id;
		private MVC.DTO.FieldDateTime mtmd_mov_data;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario;
        private MVC.DTO.FieldDecimal status;
        private MVC.DTO.FieldDateTime mtmd_mov_data_acerto;
        private MVC.DTO.FieldDecimal mtmd_lotest_id;
		
		public HistoricoNFEstornoDTO()
		{
			InitializeComponent();
		}
		
		internal void InitializeComponent()
		{
		    this.cad_mtmd_id= new MVC.DTO.FieldDecimal(FieldNames.IdtProduto,Captions.IdtProduto, DbType.Decimal);
		    this.cad_mtmd_id_acerto= new MVC.DTO.FieldDecimal(FieldNames.IdtProdutoAcerto,Captions.IdtProdutoAcerto, DbType.Decimal);
		    this.cad_mtmd_filial_id= new MVC.DTO.FieldDecimal(FieldNames.IdtFilial,Captions.IdtFilial, DbType.Decimal);
		    this.mtmd_nr_nota= new MVC.DTO.FieldString(FieldNames.NrNota,Captions.NrNota, 35);
		    this.idmov= new MVC.DTO.FieldDecimal(FieldNames.IdMovRM,Captions.IdMovRM, DbType.Decimal);
		    this.mtmd_qtde= new MVC.DTO.FieldDecimal(FieldNames.QtdeEstorno,Captions.QtdeEstorno, DbType.Decimal);
		    this.ds_fornecedor= new MVC.DTO.FieldString(FieldNames.DsFornecedor,Captions.DsFornecedor, 100);
		    this.tp_movimento= new MVC.DTO.FieldString(FieldNames.TpMov,Captions.TpMov, 10);
		    this.nf_motivo_estorno= new MVC.DTO.FieldString(FieldNames.Motivo,Captions.Motivo, 100);
		    this.mtmd_mov_id= new MVC.DTO.FieldDecimal(FieldNames.IdMovSGS,Captions.IdMovSGS, DbType.Decimal);
		    this.mtmd_mov_data= new MVC.DTO.FieldDateTime(FieldNames.DataAtualizacao,Captions.DataAtualizacao);
		    this.seg_usu_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.UsuarioAtualizacao,Captions.UsuarioAtualizacao, DbType.Decimal);
            this.status = new MVC.DTO.FieldDecimal(FieldNames.Status, Captions.Status, DbType.Decimal);
            this.mtmd_mov_data_acerto = new MVC.DTO.FieldDateTime(FieldNames.DataAcerto, Captions.DataAcerto);
            this.mtmd_lotest_id = new MVC.DTO.FieldDecimal(FieldNames.IdtLote, Captions.IdtLote);
		}
 
		#region FieldNames

		public struct FieldNames
		{
			public const string IdtProduto="CAD_MTMD_ID";
		    public const string IdtProdutoAcerto="CAD_MTMD_ID_ACERTO";
		    public const string IdtFilial="CAD_MTMD_FILIAL_ID";
		    public const string NrNota="MTMD_NR_NOTA";
		    public const string IdMovRM="IDMOV";
		    public const string QtdeEstorno="MTMD_QTDE";
		    public const string DsFornecedor="DS_FORNECEDOR";
		    public const string TpMov="TP_MOVIMENTO";
		    public const string Motivo="NF_MOTIVO_ESTORNO";
		    public const string IdMovSGS="MTMD_MOV_ID";
		    public const string DataAtualizacao="MTMD_MOV_DATA";
		    public const string UsuarioAtualizacao="SEG_USU_ID_USUARIO";
            public const string Status = "STATUS";
            public const string DataAcerto = "MTMD_MOV_DATA_ACERTO";
            public const string IdtLote = "MTMD_LOTEST_ID";
		}		

		#endregion

		#region Captions
		public struct Captions
		{
			public const string IdtProduto="IDTPRODUTO";
		    public const string IdtProdutoAcerto="IDTPRODUTOACERTO";
		    public const string IdtFilial="IDTFILIAL";
		    public const string NrNota="NRNOTA";
		    public const string IdMovRM="IDMOVRM";
		    public const string QtdeEstorno="QTDEESTORNO";
		    public const string DsFornecedor="DSFORNECEDOR";
		    public const string TpMov="TPMOV";
		    public const string Motivo="MOTIVO";
		    public const string IdMovSGS="IDMOVSGS";
		    public const string DataAtualizacao="DATAATUALIZACAO";
		    public const string UsuarioAtualizacao="USUARIOATUALIZACAO";
            public const string Status = "STATUS";
            public const string DataAcerto = "MTMDMOVDATAACERTO";
            public const string IdtLote = "MTMDLOTESTID";
		}		

		#endregion
		
        #region Atributos Publicos		
			 
		public MVC.DTO.FieldDecimal IdtProduto
		{
			get { return cad_mtmd_id; }
			set { cad_mtmd_id = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtProdutoAcerto
		{
			get { return cad_mtmd_id_acerto; }
			set { cad_mtmd_id_acerto = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtFilial
		{
			get { return cad_mtmd_filial_id; }
			set { cad_mtmd_filial_id = value; }
		}
		
			 
		public MVC.DTO.FieldString NrNota
		{
			get { return mtmd_nr_nota; }
			set { mtmd_nr_nota = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdMovRM
		{
			get { return idmov; }
			set { idmov = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal QtdeEstorno
		{
			get { return mtmd_qtde; }
			set { mtmd_qtde = value; }
		}
		
			 
		public MVC.DTO.FieldString DsFornecedor
		{
			get { return ds_fornecedor; }
			set { ds_fornecedor = value; }
		}
		
			 
		public MVC.DTO.FieldString TpMov
		{
			get { return tp_movimento; }
			set { tp_movimento = value; }
		}
		
			 
		public MVC.DTO.FieldString Motivo
		{
			get { return nf_motivo_estorno; }
			set { nf_motivo_estorno = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdMovSGS
		{
			get { return mtmd_mov_id; }
			set { mtmd_mov_id = value; }
		}
		
			 
		public MVC.DTO.FieldDateTime DataAtualizacao
		{
			get { return mtmd_mov_data; }
			set { mtmd_mov_data = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal UsuarioAtualizacao
		{
			get { return seg_usu_id_usuario; }
			set { seg_usu_id_usuario = value; }
		}


        public MVC.DTO.FieldDecimal StatusEstorno
        {
            get { return status; }
            set { status = value; }
        }


        public MVC.DTO.FieldDateTime DataAcerto
        {
            get { return mtmd_mov_data_acerto; }
            set { mtmd_mov_data_acerto = value; }
        }

        public MVC.DTO.FieldDecimal IdtLote
        {
            get { return mtmd_lotest_id; }
            set { mtmd_lotest_id = value; }
        }
			
		#endregion

		#region Operators

		public static explicit operator HistoricoNFEstornoDTO(DataRow row)
		{
			HistoricoNFEstornoDTO  dto = new HistoricoNFEstornoDTO();
			dto.IdtProduto.Value = row[FieldNames.IdtProduto].ToString();
			dto.IdtProdutoAcerto.Value = row[FieldNames.IdtProdutoAcerto].ToString();
			dto.IdtFilial.Value = row[FieldNames.IdtFilial].ToString();
			dto.NrNota.Value = row[FieldNames.NrNota].ToString();
			dto.IdMovRM.Value = row[FieldNames.IdMovRM].ToString();
			dto.QtdeEstorno.Value = row[FieldNames.QtdeEstorno].ToString();
			dto.DsFornecedor.Value = row[FieldNames.DsFornecedor].ToString();
			dto.TpMov.Value = row[FieldNames.TpMov].ToString();
			dto.Motivo.Value = row[FieldNames.Motivo].ToString();
			dto.IdMovSGS.Value = row[FieldNames.IdMovSGS].ToString();
			dto.DataAtualizacao.Value = row[FieldNames.DataAtualizacao].ToString();
			dto.UsuarioAtualizacao.Value = row[FieldNames.UsuarioAtualizacao].ToString();
            dto.StatusEstorno.Value = row[FieldNames.Status].ToString();
            dto.DataAcerto.Value = row[FieldNames.DataAcerto].ToString();
            dto.IdtLote.Value = row[FieldNames.IdtLote].ToString();
			return dto;
		}

		public static explicit operator HistoricoNFEstornoDTO(XmlDocument xml)
		{
			HistoricoNFEstornoDTO dto = new HistoricoNFEstornoDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto) != null) dto.IdtProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtProdutoAcerto) != null) dto.IdtProdutoAcerto.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtProdutoAcerto).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial) != null) dto.IdtFilial.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.NrNota) != null) dto.NrNota.Value = xml.FirstChild.SelectSingleNode(FieldNames.NrNota).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdMovRM) != null) dto.IdMovRM.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdMovRM).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeEstorno) != null) dto.QtdeEstorno.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeEstorno).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DsFornecedor) != null) dto.DsFornecedor.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsFornecedor).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.TpMov) != null) dto.TpMov.Value = xml.FirstChild.SelectSingleNode(FieldNames.TpMov).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Motivo) != null) dto.Motivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.Motivo).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdMovSGS) != null) dto.IdMovSGS.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdMovSGS).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizacao) != null) dto.DataAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizacao).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.UsuarioAtualizacao) != null) dto.UsuarioAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.UsuarioAtualizacao).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.Status) != null) dto.status.Value = xml.FirstChild.SelectSingleNode(FieldNames.Status).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DataAcerto) != null) dto.DataAcerto.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataAcerto).InnerText;
			
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeIdtProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtProduto, null);
			XmlNode nodeIdtProdutoAcerto = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtProdutoAcerto, null);
			XmlNode nodeIdtFilial = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFilial, null);
			XmlNode nodeNrNota = xml.CreateNode(XmlNodeType.Element, FieldNames.NrNota, null);
			XmlNode nodeIdMovRM = xml.CreateNode(XmlNodeType.Element, FieldNames.IdMovRM, null);
			XmlNode nodeQtdeEstorno = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeEstorno, null);
			XmlNode nodeDsFornecedor = xml.CreateNode(XmlNodeType.Element, FieldNames.DsFornecedor, null);
			XmlNode nodeTpMov = xml.CreateNode(XmlNodeType.Element, FieldNames.TpMov, null);
			XmlNode nodeMotivo = xml.CreateNode(XmlNodeType.Element, FieldNames.Motivo, null);
			XmlNode nodeIdMovSGS = xml.CreateNode(XmlNodeType.Element, FieldNames.IdMovSGS, null);
			XmlNode nodeDataAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DataAtualizacao, null);
			XmlNode nodeUsuarioAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.UsuarioAtualizacao, null);
            XmlNode nodeStatus = xml.CreateNode(XmlNodeType.Element, FieldNames.Status, null);
            XmlNode nodeDataAcerto = xml.CreateNode(XmlNodeType.Element, FieldNames.DataAcerto, null);
			
			if (!this.IdtProduto.Value.IsNull) nodeIdtProduto.InnerText = this.IdtProduto.Value;
			if (!this.IdtProdutoAcerto.Value.IsNull) nodeIdtProdutoAcerto.InnerText = this.IdtProdutoAcerto.Value;
			if (!this.IdtFilial.Value.IsNull) nodeIdtFilial.InnerText = this.IdtFilial.Value;
			if (!this.NrNota.Value.IsNull) nodeNrNota.InnerText = this.NrNota.Value;
			if (!this.IdMovRM.Value.IsNull) nodeIdMovRM.InnerText = this.IdMovRM.Value;
			if (!this.QtdeEstorno.Value.IsNull) nodeQtdeEstorno.InnerText = this.QtdeEstorno.Value;
			if (!this.DsFornecedor.Value.IsNull) nodeDsFornecedor.InnerText = this.DsFornecedor.Value;
			if (!this.TpMov.Value.IsNull) nodeTpMov.InnerText = this.TpMov.Value;
			if (!this.Motivo.Value.IsNull) nodeMotivo.InnerText = this.Motivo.Value;
			if (!this.IdMovSGS.Value.IsNull) nodeIdMovSGS.InnerText = this.IdMovSGS.Value;
			if (!this.DataAtualizacao.Value.IsNull) nodeDataAtualizacao.InnerText = this.DataAtualizacao.Value;
			if (!this.UsuarioAtualizacao.Value.IsNull) nodeUsuarioAtualizacao.InnerText = this.UsuarioAtualizacao.Value;
            if (!this.StatusEstorno.Value.IsNull) nodeStatus.InnerText = this.StatusEstorno.Value;
            if (!this.DataAcerto.Value.IsNull) nodeDataAcerto.InnerText = this.DataAcerto.Value;
			
			nodeData.AppendChild(nodeIdtProduto);
			nodeData.AppendChild(nodeIdtProdutoAcerto);
			nodeData.AppendChild(nodeIdtFilial);
			nodeData.AppendChild(nodeNrNota);
			nodeData.AppendChild(nodeIdMovRM);
			nodeData.AppendChild(nodeQtdeEstorno);
			nodeData.AppendChild(nodeDsFornecedor);
			nodeData.AppendChild(nodeTpMov);
			nodeData.AppendChild(nodeMotivo);
			nodeData.AppendChild(nodeIdMovSGS);
			nodeData.AppendChild(nodeDataAtualizacao);
			nodeData.AppendChild(nodeUsuarioAtualizacao);
            nodeData.AppendChild(nodeStatus);
            nodeData.AppendChild(nodeDataAcerto);
						
			xml.AppendChild(nodeData);
			return xml;
		}

		public static explicit operator DataRow(HistoricoNFEstornoDTO dto)
		{
			HistoricoNFEstornoDataTable dtb = new HistoricoNFEstornoDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.IdtProduto] = dto.IdtProduto.Value;
			dtr[FieldNames.IdtProdutoAcerto] = dto.IdtProdutoAcerto.Value;
			dtr[FieldNames.IdtFilial] = dto.IdtFilial.Value;
			dtr[FieldNames.NrNota] = dto.NrNota.Value;
			dtr[FieldNames.IdMovRM] = dto.IdMovRM.Value;
			dtr[FieldNames.QtdeEstorno] = dto.QtdeEstorno.Value;
			dtr[FieldNames.DsFornecedor] = dto.DsFornecedor.Value;
			dtr[FieldNames.TpMov] = dto.TpMov.Value;
			dtr[FieldNames.Motivo] = dto.Motivo.Value;
			dtr[FieldNames.IdMovSGS] = dto.IdMovSGS.Value;
			dtr[FieldNames.DataAtualizacao] = dto.DataAtualizacao.Value;
			dtr[FieldNames.UsuarioAtualizacao] = dto.UsuarioAtualizacao.Value;
            dtr[FieldNames.Status] = dto.StatusEstorno.Value;
            dtr[FieldNames.DataAcerto] = dto.DataAcerto.Value;
            dtr[FieldNames.IdtLote] = dto.IdtLote.Value;
			return dtr;
		}

		public static explicit operator XmlDocument(HistoricoNFEstornoDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}