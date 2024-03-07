
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using MVC = HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.Seguranca.DTO
{
	/// <summary>
	/// Classe Entidade ModuloDataTable
	/// </summary>
	[Serializable()]
	public class ModuloDataTable : DataTable
	{
		
		public ModuloDataTable()
			: base()
		{
		
			this.TableName = "Modulo";

					this.Columns.Add(ModuloDTO.FieldNames.Idt, typeof(Decimal));
		this.Columns.Add(ModuloDTO.FieldNames.NmModulo, typeof(String));
		this.Columns.Add(ModuloDTO.FieldNames.DsModulo, typeof(String));
		this.Columns.Add(ModuloDTO.FieldNames.CdModulo, typeof(String));
		this.Columns.Add(ModuloDTO.FieldNames.DsSistema, typeof(String));
		this.Columns.Add(ModuloDTO.FieldNames.DsVersao, typeof(String));
		this.Columns.Add(ModuloDTO.FieldNames.DtVersao, typeof(DateTime));


			

			DataColumn[] primaryKey = { this.Columns[ModuloDTO.FieldNames.Idt] };

			this.PrimaryKey = primaryKey;
		}
		
		protected ModuloDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
		: base(serializationInfo, streamingContext){}


		public ModuloDTO TypedRow(int index)
		{
			return (ModuloDTO)this.Rows[index];
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

		public void Add(ModuloDTO dto)
		{
			DataRow dtr = this.NewRow();


					if (!dto.Idt.Value.IsNull) dtr[ModuloDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		if (!dto.NmModulo.Value.IsNull) dtr[ModuloDTO.FieldNames.NmModulo] = (String)dto.NmModulo.Value;
		if (!dto.DsModulo.Value.IsNull) dtr[ModuloDTO.FieldNames.DsModulo] = (String)dto.DsModulo.Value;
		if (!dto.CdModulo.Value.IsNull) dtr[ModuloDTO.FieldNames.CdModulo] = (String)dto.CdModulo.Value;
		if (!dto.DsSistema.Value.IsNull) dtr[ModuloDTO.FieldNames.DsSistema] = (String)dto.DsSistema.Value;
		if (!dto.DsVersao.Value.IsNull) dtr[ModuloDTO.FieldNames.DsVersao] = (String)dto.DsVersao.Value;
		if (!dto.DtVersao.Value.IsNull) dtr[ModuloDTO.FieldNames.DtVersao] = (DateTime)dto.DtVersao.Value;

			
			this.Rows.Add(dtr);
		}
		
		public ModuloEnumerator GetEnumerator()
		{
			return new ModuloEnumerator(this);
		}
	}
	
	// Inner class implements IEnumerator interface:
	public class ModuloEnumerator
	{
		private int position = -1;
		private DataTable dtb;

		public ModuloEnumerator(DataTable dtb)
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
		public ModuloDTO Current
		{
		get
			{
				ModuloDTO dto = new ModuloDTO();			
				dto.Idt.Value = dtb.Rows[position][ModuloDTO.FieldNames.Idt].ToString();
				dto.NmModulo.Value = dtb.Rows[position][ModuloDTO.FieldNames.NmModulo].ToString();
				dto.DsModulo.Value = dtb.Rows[position][ModuloDTO.FieldNames.DsModulo].ToString();
				dto.CdModulo.Value = dtb.Rows[position][ModuloDTO.FieldNames.CdModulo].ToString();
				dto.DsSistema.Value = dtb.Rows[position][ModuloDTO.FieldNames.DsSistema].ToString();
				dto.DsVersao.Value = dtb.Rows[position][ModuloDTO.FieldNames.DsVersao].ToString();
				dto.DtVersao.Value = dtb.Rows[position][ModuloDTO.FieldNames.DtVersao].ToString();
				
				return dto;
			}
		}
	}
	
	[Serializable()]
	public class ModuloDTO : MVC.DTO.DTOBase
	{	
				private MVC.DTO.FieldDecimal seg_mod_id_modulo;
		private MVC.DTO.FieldString seg_mod_nm_modulo;
		private MVC.DTO.FieldString seg_mod_ds_modulo;
		private MVC.DTO.FieldString seg_mod_cd_modulo;
		private MVC.DTO.FieldString seg_mod_ds_sistema;
		private MVC.DTO.FieldString seg_mod_ds_versao;
		private MVC.DTO.FieldDateTime seg_mod_dt_versao;

		
		public ModuloDTO()
		{
			InitializeComponent();
		}
		
		internal void InitializeComponent()
		{
					this.seg_mod_id_modulo= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		this.seg_mod_nm_modulo= new MVC.DTO.FieldString(FieldNames.NmModulo,Captions.NmModulo, 50);
		this.seg_mod_ds_modulo= new MVC.DTO.FieldString(FieldNames.DsModulo,Captions.DsModulo, 50);
		this.seg_mod_cd_modulo= new MVC.DTO.FieldString(FieldNames.CdModulo,Captions.CdModulo, 3);
		this.seg_mod_ds_sistema= new MVC.DTO.FieldString(FieldNames.DsSistema,Captions.DsSistema, 50);
		this.seg_mod_ds_versao= new MVC.DTO.FieldString(FieldNames.DsVersao,Captions.DsVersao, 15);
		this.seg_mod_dt_versao= new MVC.DTO.FieldDateTime(FieldNames.DtVersao,Captions.DtVersao);
		
		}
 
		#region FieldNames

		public struct FieldNames
		{
				public const string Idt="SEG_MOD_ID_MODULO";
		public const string NmModulo="SEG_MOD_NM_MODULO";
		public const string DsModulo="SEG_MOD_DS_MODULO";
		public const string CdModulo="SEG_MOD_CD_MODULO";
		public const string DsSistema="SEG_MOD_DS_SISTEMA";
		public const string DsVersao="SEG_MOD_DS_VERSAO";
		public const string DtVersao="SEG_MOD_DT_VERSAO";
		
		}		

		#endregion

		#region Captions
		public struct Captions
		{
				public const string Idt="IDT";
		public const string NmModulo="NMMODULO";
		public const string DsModulo="DSMODULO";
		public const string CdModulo="CDMODULO";
		public const string DsSistema="DSSISTEMA";
		public const string DsVersao="DSVERSAO";
		public const string DtVersao="DTVERSAO";
		
		}		

		#endregion
		
		#region Atributos Publicos

		
			 
		public MVC.DTO.FieldDecimal Idt
		{
			get { return seg_mod_id_modulo; }
			set { seg_mod_id_modulo = value; }
		}
		
			 
		public MVC.DTO.FieldString NmModulo
		{
			get { return seg_mod_nm_modulo; }
			set { seg_mod_nm_modulo = value; }
		}
		
			 
		public MVC.DTO.FieldString DsModulo
		{
			get { return seg_mod_ds_modulo; }
			set { seg_mod_ds_modulo = value; }
		}
		
			 
		public MVC.DTO.FieldString CdModulo
		{
			get { return seg_mod_cd_modulo; }
			set { seg_mod_cd_modulo = value; }
		}
		
			 
		public MVC.DTO.FieldString DsSistema
		{
			get { return seg_mod_ds_sistema; }
			set { seg_mod_ds_sistema = value; }
		}
		
			 
		public MVC.DTO.FieldString DsVersao
		{
			get { return seg_mod_ds_versao; }
			set { seg_mod_ds_versao = value; }
		}
		
			 
		public MVC.DTO.FieldDateTime DtVersao
		{
			get { return seg_mod_dt_versao; }
			set { seg_mod_dt_versao = value; }
		}
					
			
		#endregion


		#region Operators

		public static explicit operator ModuloDTO(DataRow row)
		{
			ModuloDTO  dto = new ModuloDTO();
			dto.Idt.Value = row[FieldNames.Idt].ToString();
			dto.NmModulo.Value = row[FieldNames.NmModulo].ToString();
			dto.DsModulo.Value = row[FieldNames.DsModulo].ToString();
			dto.CdModulo.Value = row[FieldNames.CdModulo].ToString();
			dto.DsSistema.Value = row[FieldNames.DsSistema].ToString();
			dto.DsVersao.Value = row[FieldNames.DsVersao].ToString();
			dto.DtVersao.Value = row[FieldNames.DtVersao].ToString();
			
			
			return dto;
		}

		public static explicit operator ModuloDTO(XmlDocument xml)
		{
			ModuloDTO dto = new ModuloDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.NmModulo) != null) dto.NmModulo.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmModulo).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DsModulo) != null) dto.DsModulo.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsModulo).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.CdModulo) != null) dto.CdModulo.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdModulo).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DsSistema) != null) dto.DsSistema.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsSistema).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DsVersao) != null) dto.DsVersao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsVersao).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DtVersao) != null) dto.DtVersao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtVersao).InnerText;			
			
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			XmlNode nodeNmModulo = xml.CreateNode(XmlNodeType.Element, FieldNames.NmModulo, null);
			XmlNode nodeDsModulo = xml.CreateNode(XmlNodeType.Element, FieldNames.DsModulo, null);
			XmlNode nodeCdModulo = xml.CreateNode(XmlNodeType.Element, FieldNames.CdModulo, null);
			XmlNode nodeDsSistema = xml.CreateNode(XmlNodeType.Element, FieldNames.DsSistema, null);
			XmlNode nodeDsVersao = xml.CreateNode(XmlNodeType.Element, FieldNames.DsVersao, null);
			XmlNode nodeDtVersao = xml.CreateNode(XmlNodeType.Element, FieldNames.DtVersao, null);
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			if (!this.NmModulo.Value.IsNull) nodeNmModulo.InnerText = this.NmModulo.Value;
			if (!this.DsModulo.Value.IsNull) nodeDsModulo.InnerText = this.DsModulo.Value;
			if (!this.CdModulo.Value.IsNull) nodeCdModulo.InnerText = this.CdModulo.Value;
			if (!this.DsSistema.Value.IsNull) nodeDsSistema.InnerText = this.DsSistema.Value;
			if (!this.DsVersao.Value.IsNull) nodeDsVersao.InnerText = this.DsVersao.Value;
			if (!this.DtVersao.Value.IsNull) nodeDtVersao.InnerText = this.DtVersao.Value;
			
			nodeData.AppendChild(nodeIdt);
			nodeData.AppendChild(nodeNmModulo);
			nodeData.AppendChild(nodeDsModulo);
			nodeData.AppendChild(nodeCdModulo);
			nodeData.AppendChild(nodeDsSistema);
			nodeData.AppendChild(nodeDsVersao);
			nodeData.AppendChild(nodeDtVersao);
						
			xml.AppendChild(nodeData);
			return xml;
		}

		public static explicit operator DataRow(ModuloDTO dto)
		{
			ModuloDataTable dtb = new ModuloDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.Idt] = dto.Idt.Value;
			dtr[FieldNames.NmModulo] = dto.NmModulo.Value;
			dtr[FieldNames.DsModulo] = dto.DsModulo.Value;
			dtr[FieldNames.CdModulo] = dto.CdModulo.Value;
			dtr[FieldNames.DsSistema] = dto.DsSistema.Value;
			dtr[FieldNames.DsVersao] = dto.DsVersao.Value;
			dtr[FieldNames.DtVersao] = dto.DtVersao.Value;
			
			return dtr;
		}

		public static explicit operator XmlDocument(ModuloDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}

