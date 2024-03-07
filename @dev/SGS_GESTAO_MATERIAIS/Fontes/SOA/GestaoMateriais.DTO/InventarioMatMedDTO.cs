
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
	/// Classe Entidade InventarioMatMedDataTable
	/// </summary>
	[Serializable()]
	public class InventarioMatMedDataTable : DataTable
	{
		
		public InventarioMatMedDataTable()
			: base()
		{
		
			this.TableName = "InventarioMatMed";

					this.Columns.Add(InventarioMatMedDTO.FieldNames.IdProduto, typeof(Decimal));
		this.Columns.Add(InventarioMatMedDTO.FieldNames.IdFilial, typeof(Decimal));
		this.Columns.Add(InventarioMatMedDTO.FieldNames.IdSetor, typeof(Decimal));
		this.Columns.Add(InventarioMatMedDTO.FieldNames.DataInventario, typeof(DateTime));
		this.Columns.Add(InventarioMatMedDTO.FieldNames.Qtde1, typeof(Decimal));
		this.Columns.Add(InventarioMatMedDTO.FieldNames.Qtde2, typeof(Decimal));
		this.Columns.Add(InventarioMatMedDTO.FieldNames.Qtde3, typeof(Decimal));
		this.Columns.Add(InventarioMatMedDTO.FieldNames.QtdeFinal, typeof(Decimal));
		this.Columns.Add(InventarioMatMedDTO.FieldNames.DtAtualizacao, typeof(DateTime));
		this.Columns.Add(InventarioMatMedDTO.FieldNames.IdUsuario, typeof(Decimal));
        this.Columns.Add(InventarioMatMedDTO.FieldNames.FlAndamento, typeof(Decimal));
        this.Columns.Add(InventarioMatMedDTO.FieldNames.Fechamento, typeof(Decimal));
        this.Columns.Add(InventarioMatMedDTO.FieldNames.FlMedicamento, typeof(Decimal));
        this.Columns.Add(InventarioMatMedDTO.FieldNames.CodLote, typeof(String));
        this.Columns.Add(InventarioMatMedDTO.FieldNames.NumLoteFab, typeof(String));
        this.Columns.Add(InventarioMatMedDTO.FieldNames.IdtGrupo, typeof(Decimal));
		}
		
		protected InventarioMatMedDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
		: base(serializationInfo, streamingContext){}


		public InventarioMatMedDTO TypedRow(int index)
		{
			return (InventarioMatMedDTO)this.Rows[index];
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

		public void Add(InventarioMatMedDTO dto)
		{
			DataRow dtr = this.NewRow();

					if (!dto.IdProduto.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.IdProduto] = (Decimal)dto.IdProduto.Value;
		if (!dto.IdFilial.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.IdFilial] = (Decimal)dto.IdFilial.Value;
		if (!dto.IdSetor.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.IdSetor] = (Decimal)dto.IdSetor.Value;
		if (!dto.DataInventario.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.DataInventario] = (DateTime)dto.DataInventario.Value;
		if (!dto.Qtde1.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.Qtde1] = (Decimal)dto.Qtde1.Value;
		if (!dto.Qtde2.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.Qtde2] = (Decimal)dto.Qtde2.Value;
		if (!dto.Qtde3.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.Qtde3] = (Decimal)dto.Qtde3.Value;
		if (!dto.QtdeFinal.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.QtdeFinal] = (Decimal)dto.QtdeFinal.Value;
		if (!dto.DtAtualizacao.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.DtAtualizacao] = (DateTime)dto.DtAtualizacao.Value;
		if (!dto.IdUsuario.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.IdUsuario] = (Decimal)dto.IdUsuario.Value;
        if (!dto.FlAndamento.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.FlAndamento] = (Decimal)dto.FlAndamento.Value;
        if (!dto.Fechamento.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.Fechamento] = (Decimal)dto.Fechamento.Value;
        if (!dto.FlMedicamento.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.FlMedicamento] = (Decimal)dto.FlMedicamento.Value;
        if (!dto.CodLote.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.CodLote] = (String)dto.CodLote.Value;
        if (!dto.NumLoteFab.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.NumLoteFab] = (String)dto.NumLoteFab.Value;
        if (!dto.IdtGrupo.Value.IsNull) dtr[InventarioMatMedDTO.FieldNames.IdtGrupo] = (Decimal)dto.IdtGrupo.Value;
			this.Rows.Add(dtr);
		}
		
		public InventarioMatMedEnumerator GetEnumerator()
		{
			return new InventarioMatMedEnumerator(this);
		}
	}
	
	// Inner class implements IEnumerator interface:
	public class InventarioMatMedEnumerator
	{
		private int position = -1;
		private DataTable dtb;

		public InventarioMatMedEnumerator(DataTable dtb)
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
		public InventarioMatMedDTO Current
		{
		get
			{
				InventarioMatMedDTO dto = new InventarioMatMedDTO();			
				dto.IdProduto.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.IdProduto].ToString();
				dto.IdFilial.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.IdFilial].ToString();
				dto.IdSetor.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.IdSetor].ToString();
				dto.DataInventario.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.DataInventario].ToString();
				dto.Qtde1.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.Qtde1].ToString();
				dto.Qtde2.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.Qtde2].ToString();
				dto.Qtde3.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.Qtde3].ToString();
				dto.QtdeFinal.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.QtdeFinal].ToString();
				dto.DtAtualizacao.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.DtAtualizacao].ToString();
				dto.IdUsuario.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.IdUsuario].ToString();
                dto.FlAndamento.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.FlAndamento].ToString();
                dto.Fechamento.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.Fechamento].ToString();
                dto.FlMedicamento.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.FlMedicamento].ToString();
                dto.CodLote.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.CodLote].ToString();
                dto.NumLoteFab.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.NumLoteFab].ToString();
                dto.IdtGrupo.Value = dtb.Rows[position][InventarioMatMedDTO.FieldNames.IdtGrupo].ToString();
				return dto;
			}
		}
	}
	
	[Serializable()]
	public class InventarioMatMedDTO : MVC.DTO.DTOBase
	{	
				private MVC.DTO.FieldDecimal cad_mtmd_id;
		private MVC.DTO.FieldDecimal cad_mtmd_filial_id;
		private MVC.DTO.FieldDecimal cad_set_id;
		private MVC.DTO.FieldDateTime cad_mtmd_dt_inventario;
		private MVC.DTO.FieldDecimal cad_mtmd_qtde_1;
		private MVC.DTO.FieldDecimal cad_mtmd_qtde_2;
		private MVC.DTO.FieldDecimal cad_mtmd_qtde_3;
		private MVC.DTO.FieldDecimal cad_mtmd_qtde_final;
		private MVC.DTO.FieldDateTime cad_mtmd_dt_atualizacao;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario;
        private MVC.DTO.FieldDecimal cad_mtmd_andamento;
        private MVC.DTO.FieldDecimal cad_mtmd_fechamento;
        private MVC.DTO.FieldDecimal fl_medicamento;
        private MVC.DTO.FieldString mtmd_cod_lote;
        private MVC.DTO.FieldString mtmd_num_lote;
        private MVC.DTO.FieldDecimal cad_mtmd_grupo_id;
		
		public InventarioMatMedDTO()
		{
			InitializeComponent();
		}
		
		internal void InitializeComponent()
		{
					this.cad_mtmd_id= new MVC.DTO.FieldDecimal(FieldNames.IdProduto,Captions.IdProduto, DbType.Decimal);
		this.cad_mtmd_filial_id= new MVC.DTO.FieldDecimal(FieldNames.IdFilial,Captions.IdFilial, DbType.Decimal);
		this.cad_set_id= new MVC.DTO.FieldDecimal(FieldNames.IdSetor,Captions.IdSetor, DbType.Decimal);
		this.cad_mtmd_dt_inventario= new MVC.DTO.FieldDateTime(FieldNames.DataInventario,Captions.DataInventario);
		this.cad_mtmd_qtde_1= new MVC.DTO.FieldDecimal(FieldNames.Qtde1,Captions.Qtde1, DbType.Decimal);
		this.cad_mtmd_qtde_2= new MVC.DTO.FieldDecimal(FieldNames.Qtde2,Captions.Qtde2, DbType.Decimal);
		this.cad_mtmd_qtde_3= new MVC.DTO.FieldDecimal(FieldNames.Qtde3,Captions.Qtde3, DbType.Decimal);
		this.cad_mtmd_qtde_final= new MVC.DTO.FieldDecimal(FieldNames.QtdeFinal,Captions.QtdeFinal, DbType.Decimal);
		this.cad_mtmd_dt_atualizacao= new MVC.DTO.FieldDateTime(FieldNames.DtAtualizacao,Captions.DtAtualizacao);
		this.seg_usu_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.IdUsuario,Captions.IdUsuario, DbType.Decimal);
        this.cad_mtmd_andamento = new MVC.DTO.FieldDecimal(FieldNames.FlAndamento, Captions.FlAndamento, DbType.Decimal);
        this.cad_mtmd_fechamento = new MVC.DTO.FieldDecimal(FieldNames.Fechamento, Captions.Fechamento, DbType.Decimal);
        this.fl_medicamento = new MVC.DTO.FieldDecimal(FieldNames.FlMedicamento, Captions.FlMedicamento, DbType.Decimal);
        this.mtmd_cod_lote = new MVC.DTO.FieldString(FieldNames.CodLote, Captions.CodLote);
        this.mtmd_num_lote = new MVC.DTO.FieldString(FieldNames.NumLoteFab, Captions.NumLoteFab);
        this.cad_mtmd_grupo_id = new MVC.DTO.FieldDecimal(FieldNames.IdtGrupo, Captions.IdtGrupo, DbType.Decimal);
		}
 
		#region FieldNames

		public struct FieldNames
		{
				public const string IdProduto="CAD_MTMD_ID";
		public const string IdFilial="CAD_MTMD_FILIAL_ID";
		public const string IdSetor="CAD_SET_ID";
		public const string DataInventario="CAD_MTMD_DT_INVENTARIO";
		public const string Qtde1="CAD_MTMD_QTDE_1";
		public const string Qtde2="CAD_MTMD_QTDE_2";
		public const string Qtde3="CAD_MTMD_QTDE_3";
		public const string QtdeFinal="CAD_MTMD_QTDE_FINAL";
		public const string DtAtualizacao="CAD_MTMD_DT_ATUALIZACAO";
		public const string IdUsuario="SEG_USU_ID_USUARIO";
            public const string FlAndamento = "CAD_MTMD_ANDAMENTO";
            public const string Fechamento = "CAD_MTMD_FECHAMENTO";
            public const string FlMedicamento = "FL_MEDICAMENTO";
            public const string CodLote = "MTMD_COD_LOTE";
            public const string NumLoteFab = "MTMD_NUM_LOTE";
            public const string IdtGrupo = "CAD_MTMD_GRUPO_ID";
		}		

		#endregion

		#region Captions
		public struct Captions
		{
				public const string IdProduto="IDPRODUTO";
		public const string IdFilial="IDFILIAL";
		public const string IdSetor="IDSETOR";
		public const string DataInventario="DATAINVENTARIO";
		public const string Qtde1="QTDE1";
		public const string Qtde2="QTDE2";
		public const string Qtde3="QTDE3";
		public const string QtdeFinal="QTDEFINAL";
		public const string DtAtualizacao="DTATUALIZACAO";
		public const string IdUsuario="IDUSUARIO";
            public const string FlAndamento = "CADMTMDANDAMENTO";
            public const string Fechamento = "CADMTMDFECHAMENTO";
            public const string FlMedicamento = "FLMEDICAMENTO";
            public const string CodLote = "MTMDCODLOTE";
            public const string NumLoteFab = "MTMDNUMLOTE";
            public const string IdtGrupo = "GRUPOID";
		}		

		#endregion
		
		#region Atributos Publicos

		
			 
		public MVC.DTO.FieldDecimal IdProduto
		{
			get { return cad_mtmd_id; }
			set { cad_mtmd_id = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdFilial
		{
			get { return cad_mtmd_filial_id; }
			set { cad_mtmd_filial_id = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdSetor
		{
			get { return cad_set_id; }
			set { cad_set_id = value; }
		}
		
			 
		public MVC.DTO.FieldDateTime DataInventario
		{
			get { return cad_mtmd_dt_inventario; }
			set { cad_mtmd_dt_inventario = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal Qtde1
		{
			get { return cad_mtmd_qtde_1; }
			set { cad_mtmd_qtde_1 = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal Qtde2
		{
			get { return cad_mtmd_qtde_2; }
			set { cad_mtmd_qtde_2 = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal Qtde3
		{
			get { return cad_mtmd_qtde_3; }
			set { cad_mtmd_qtde_3 = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal QtdeFinal
		{
			get { return cad_mtmd_qtde_final; }
			set { cad_mtmd_qtde_final = value; }
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

        public MVC.DTO.FieldDecimal FlAndamento
        {
            get { return cad_mtmd_andamento; }
            set { cad_mtmd_andamento = value; }
        }

        public MVC.DTO.FieldDecimal Fechamento
        {
            get { return cad_mtmd_fechamento; }
            set { cad_mtmd_fechamento = value; }
        }

        public MVC.DTO.FieldDecimal FlMedicamento
        {
            get { return fl_medicamento; }
            set { fl_medicamento = value; }
        }

        public MVC.DTO.FieldString CodLote
        {
            get { return mtmd_cod_lote; }
            set { mtmd_cod_lote = value; }
        }

        public MVC.DTO.FieldString NumLoteFab
        {
            get { return mtmd_num_lote; }
            set { mtmd_num_lote = value; }
        }

        public MVC.DTO.FieldDecimal IdtGrupo
        {
            get { return cad_mtmd_grupo_id; }
            set { cad_mtmd_grupo_id = value; }
        }

		#endregion

		#region Operators

		public static explicit operator InventarioMatMedDTO(DataRow row)
		{
			InventarioMatMedDTO  dto = new InventarioMatMedDTO();
			dto.IdProduto.Value = row[FieldNames.IdProduto].ToString();
			dto.IdFilial.Value = row[FieldNames.IdFilial].ToString();
			dto.IdSetor.Value = row[FieldNames.IdSetor].ToString();
			dto.DataInventario.Value = row[FieldNames.DataInventario].ToString();
			dto.Qtde1.Value = row[FieldNames.Qtde1].ToString();
			dto.Qtde2.Value = row[FieldNames.Qtde2].ToString();
			dto.Qtde3.Value = row[FieldNames.Qtde3].ToString();
			dto.QtdeFinal.Value = row[FieldNames.QtdeFinal].ToString();
			dto.DtAtualizacao.Value = row[FieldNames.DtAtualizacao].ToString();
			dto.IdUsuario.Value = row[FieldNames.IdUsuario].ToString();
            dto.FlAndamento.Value = row[FieldNames.FlAndamento].ToString();
            dto.Fechamento.Value = row[FieldNames.Fechamento].ToString();
            dto.FlMedicamento.Value = row[FieldNames.FlMedicamento].ToString();
            try
            {
                dto.CodLote.Value = row[FieldNames.CodLote].ToString();
                dto.NumLoteFab.Value = row[FieldNames.NumLoteFab].ToString();
                dto.IdtGrupo.Value = row[FieldNames.IdtGrupo].ToString();
            }
            catch
            {
                //deixa passar se não tiver coluna
                dto.IdtGrupo.Value = 0;
            }
			return dto;
		}

		public static explicit operator InventarioMatMedDTO(XmlDocument xml)
		{
			InventarioMatMedDTO dto = new InventarioMatMedDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdProduto) != null) dto.IdProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdProduto).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdFilial) != null) dto.IdFilial.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdFilial).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdSetor) != null) dto.IdSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdSetor).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DataInventario) != null) dto.DataInventario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataInventario).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Qtde1) != null) dto.Qtde1.Value = xml.FirstChild.SelectSingleNode(FieldNames.Qtde1).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Qtde2) != null) dto.Qtde2.Value = xml.FirstChild.SelectSingleNode(FieldNames.Qtde2).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Qtde3) != null) dto.Qtde3.Value = xml.FirstChild.SelectSingleNode(FieldNames.Qtde3).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeFinal) != null) dto.QtdeFinal.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeFinal).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DtAtualizacao) != null) dto.DtAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtAtualizacao).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdUsuario) != null) dto.IdUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdUsuario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.FlAndamento) != null) dto.FlAndamento.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlAndamento).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.Fechamento) != null) dto.Fechamento.Value = xml.FirstChild.SelectSingleNode(FieldNames.Fechamento).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.FlMedicamento) != null) dto.FlMedicamento.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlMedicamento).InnerText;
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeIdProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.IdProduto, null);
			XmlNode nodeIdFilial = xml.CreateNode(XmlNodeType.Element, FieldNames.IdFilial, null);
			XmlNode nodeIdSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdSetor, null);
			XmlNode nodeDataInventario = xml.CreateNode(XmlNodeType.Element, FieldNames.DataInventario, null);
			XmlNode nodeQtde1 = xml.CreateNode(XmlNodeType.Element, FieldNames.Qtde1, null);
			XmlNode nodeQtde2 = xml.CreateNode(XmlNodeType.Element, FieldNames.Qtde2, null);
			XmlNode nodeQtde3 = xml.CreateNode(XmlNodeType.Element, FieldNames.Qtde3, null);
			XmlNode nodeQtdeFinal = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeFinal, null);
			XmlNode nodeDtAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DtAtualizacao, null);
			XmlNode nodeIdUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdUsuario, null);
			
			if (!this.IdProduto.Value.IsNull) nodeIdProduto.InnerText = this.IdProduto.Value;
			if (!this.IdFilial.Value.IsNull) nodeIdFilial.InnerText = this.IdFilial.Value;
			if (!this.IdSetor.Value.IsNull) nodeIdSetor.InnerText = this.IdSetor.Value;
			if (!this.DataInventario.Value.IsNull) nodeDataInventario.InnerText = this.DataInventario.Value;
			if (!this.Qtde1.Value.IsNull) nodeQtde1.InnerText = this.Qtde1.Value;
			if (!this.Qtde2.Value.IsNull) nodeQtde2.InnerText = this.Qtde2.Value;
			if (!this.Qtde3.Value.IsNull) nodeQtde3.InnerText = this.Qtde3.Value;
			if (!this.QtdeFinal.Value.IsNull) nodeQtdeFinal.InnerText = this.QtdeFinal.Value;
			if (!this.DtAtualizacao.Value.IsNull) nodeDtAtualizacao.InnerText = this.DtAtualizacao.Value;
			if (!this.IdUsuario.Value.IsNull) nodeIdUsuario.InnerText = this.IdUsuario.Value;
			
			nodeData.AppendChild(nodeIdProduto);
			nodeData.AppendChild(nodeIdFilial);
			nodeData.AppendChild(nodeIdSetor);
			nodeData.AppendChild(nodeDataInventario);
			nodeData.AppendChild(nodeQtde1);
			nodeData.AppendChild(nodeQtde2);
			nodeData.AppendChild(nodeQtde3);
			nodeData.AppendChild(nodeQtdeFinal);
			nodeData.AppendChild(nodeDtAtualizacao);
			nodeData.AppendChild(nodeIdUsuario);
						
			xml.AppendChild(nodeData);
			return xml;
		}

		public static explicit operator DataRow(InventarioMatMedDTO dto)
		{
			InventarioMatMedDataTable dtb = new InventarioMatMedDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.IdProduto] = dto.IdProduto.Value;
			dtr[FieldNames.IdFilial] = dto.IdFilial.Value;
			dtr[FieldNames.IdSetor] = dto.IdSetor.Value;
			dtr[FieldNames.DataInventario] = dto.DataInventario.Value;
			dtr[FieldNames.Qtde1] = dto.Qtde1.Value;
			dtr[FieldNames.Qtde2] = dto.Qtde2.Value;
			dtr[FieldNames.Qtde3] = dto.Qtde3.Value;
			dtr[FieldNames.QtdeFinal] = dto.QtdeFinal.Value;
			dtr[FieldNames.DtAtualizacao] = dto.DtAtualizacao.Value;
			dtr[FieldNames.IdUsuario] = dto.IdUsuario.Value;
            dtr[FieldNames.FlAndamento] = dto.FlAndamento.Value;
            dtr[FieldNames.Fechamento] = dto.Fechamento.Value;
            dtr[FieldNames.FlMedicamento] = dto.FlMedicamento.Value;
            dtr[FieldNames.CodLote] = dto.CodLote.Value;
            dtr[FieldNames.NumLoteFab] = dto.NumLoteFab.Value;
            dtr[FieldNames.IdtGrupo] = dto.IdtGrupo.Value;
			return dtr;
		}

		public static explicit operator XmlDocument(InventarioMatMedDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}