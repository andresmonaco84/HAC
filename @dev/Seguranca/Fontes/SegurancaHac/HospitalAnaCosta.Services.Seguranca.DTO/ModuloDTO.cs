
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using MVC = HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.Services.Seguranca.DTO
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
		this.Columns.Add(ModuloDTO.FieldNames.Nome, typeof(String));
		this.Columns.Add(ModuloDTO.FieldNames.Descricao, typeof(String));
		this.Columns.Add(ModuloDTO.FieldNames.Codigo, typeof(String));
		this.Columns.Add(ModuloDTO.FieldNames.Sistema, typeof(String));
		this.Columns.Add(ModuloDTO.FieldNames.Versao, typeof(String));
		this.Columns.Add(ModuloDTO.FieldNames.DataVersao, typeof(DateTime));


			

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
		if (!dto.Nome.Value.IsNull) dtr[ModuloDTO.FieldNames.Nome] = (String)dto.Nome.Value;
		if (!dto.Descricao.Value.IsNull) dtr[ModuloDTO.FieldNames.Descricao] = (String)dto.Descricao.Value;
		if (!dto.Codigo.Value.IsNull) dtr[ModuloDTO.FieldNames.Codigo] = (String)dto.Codigo.Value;
		if (!dto.Sistema.Value.IsNull) dtr[ModuloDTO.FieldNames.Sistema] = (String)dto.Sistema.Value;
		if (!dto.Versao.Value.IsNull) dtr[ModuloDTO.FieldNames.Versao] = (String)dto.Versao.Value;
		if (!dto.DataVersao.Value.IsNull) dtr[ModuloDTO.FieldNames.DataVersao] = (DateTime)dto.DataVersao.Value;

			
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
				dto.Nome.Value = dtb.Rows[position][ModuloDTO.FieldNames.Nome].ToString();
				dto.Descricao.Value = dtb.Rows[position][ModuloDTO.FieldNames.Descricao].ToString();
				dto.Codigo.Value = dtb.Rows[position][ModuloDTO.FieldNames.Codigo].ToString();
				dto.Sistema.Value = dtb.Rows[position][ModuloDTO.FieldNames.Sistema].ToString();
				dto.Versao.Value = dtb.Rows[position][ModuloDTO.FieldNames.Versao].ToString();
				dto.DataVersao.Value = dtb.Rows[position][ModuloDTO.FieldNames.DataVersao].ToString();
				
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
		this.seg_mod_nm_modulo= new MVC.DTO.FieldString(FieldNames.Nome,Captions.Nome, 50);
		this.seg_mod_ds_modulo= new MVC.DTO.FieldString(FieldNames.Descricao,Captions.Descricao, 50);
		this.seg_mod_cd_modulo= new MVC.DTO.FieldString(FieldNames.Codigo,Captions.Codigo, 3);
		this.seg_mod_ds_sistema= new MVC.DTO.FieldString(FieldNames.Sistema,Captions.Sistema, 50);
		this.seg_mod_ds_versao= new MVC.DTO.FieldString(FieldNames.Versao,Captions.Versao, 15);
		this.seg_mod_dt_versao= new MVC.DTO.FieldDateTime(FieldNames.DataVersao,Captions.DataVersao);
		
		}
 
		#region FieldNames

		public struct FieldNames
		{
				public const string Idt="SEG_MOD_ID_MODULO";
		public const string Nome="SEG_MOD_NM_MODULO";
		public const string Descricao="SEG_MOD_DS_MODULO";
		public const string Codigo="SEG_MOD_CD_MODULO";
		public const string Sistema="SEG_MOD_DS_SISTEMA";
		public const string Versao="SEG_MOD_DS_VERSAO";
		public const string DataVersao="SEG_MOD_DT_VERSAO";
		
		}		

		#endregion

		#region Captions
		public struct Captions
		{
				public const string Idt="IDT";
		public const string Nome="NOME";
		public const string Descricao="DESCRICAO";
		public const string Codigo="CODIGO";
		public const string Sistema="SISTEMA";
		public const string Versao="VERSAO";
		public const string DataVersao="DATAVERSAO";
		
		}		

		#endregion
		
		#region Atributos Publicos

		
			 
		public MVC.DTO.FieldDecimal Idt
		{
			get { return seg_mod_id_modulo; }
			set { seg_mod_id_modulo = value; }
		}
		
			 
		public MVC.DTO.FieldString Nome
		{
			get { return seg_mod_nm_modulo; }
			set { seg_mod_nm_modulo = value; }
		}
		
			 
		public MVC.DTO.FieldString Descricao
		{
			get { return seg_mod_ds_modulo; }
			set { seg_mod_ds_modulo = value; }
		}
		
			 
		public MVC.DTO.FieldString Codigo
		{
			get { return seg_mod_cd_modulo; }
			set { seg_mod_cd_modulo = value; }
		}
		
			 
		public MVC.DTO.FieldString Sistema
		{
			get { return seg_mod_ds_sistema; }
			set { seg_mod_ds_sistema = value; }
		}
		
			 
		public MVC.DTO.FieldString Versao
		{
			get { return seg_mod_ds_versao; }
			set { seg_mod_ds_versao = value; }
		}
		
			 
		public MVC.DTO.FieldDateTime DataVersao
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
			dto.Nome.Value = row[FieldNames.Nome].ToString();
			dto.Descricao.Value = row[FieldNames.Descricao].ToString();
			dto.Codigo.Value = row[FieldNames.Codigo].ToString();
			dto.Sistema.Value = row[FieldNames.Sistema].ToString();
			dto.Versao.Value = row[FieldNames.Versao].ToString();
			dto.DataVersao.Value = row[FieldNames.DataVersao].ToString();
			
			
			return dto;
		}

		public static explicit operator ModuloDTO(XmlDocument xml)
		{
			ModuloDTO dto = new ModuloDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Nome) != null) dto.Nome.Value = xml.FirstChild.SelectSingleNode(FieldNames.Nome).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Descricao) != null) dto.Descricao.Value = xml.FirstChild.SelectSingleNode(FieldNames.Descricao).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Codigo) != null) dto.Codigo.Value = xml.FirstChild.SelectSingleNode(FieldNames.Codigo).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Sistema) != null) dto.Sistema.Value = xml.FirstChild.SelectSingleNode(FieldNames.Sistema).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Versao) != null) dto.Versao.Value = xml.FirstChild.SelectSingleNode(FieldNames.Versao).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DataVersao) != null) dto.DataVersao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataVersao).InnerText;			
			
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			XmlNode nodeNome = xml.CreateNode(XmlNodeType.Element, FieldNames.Nome, null);
			XmlNode nodeDescricao = xml.CreateNode(XmlNodeType.Element, FieldNames.Descricao, null);
			XmlNode nodeCodigo = xml.CreateNode(XmlNodeType.Element, FieldNames.Codigo, null);
			XmlNode nodeSistema = xml.CreateNode(XmlNodeType.Element, FieldNames.Sistema, null);
			XmlNode nodeVersao = xml.CreateNode(XmlNodeType.Element, FieldNames.Versao, null);
			XmlNode nodeDataVersao = xml.CreateNode(XmlNodeType.Element, FieldNames.DataVersao, null);
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			if (!this.Nome.Value.IsNull) nodeNome.InnerText = this.Nome.Value;
			if (!this.Descricao.Value.IsNull) nodeDescricao.InnerText = this.Descricao.Value;
			if (!this.Codigo.Value.IsNull) nodeCodigo.InnerText = this.Codigo.Value;
			if (!this.Sistema.Value.IsNull) nodeSistema.InnerText = this.Sistema.Value;
			if (!this.Versao.Value.IsNull) nodeVersao.InnerText = this.Versao.Value;
			if (!this.DataVersao.Value.IsNull) nodeDataVersao.InnerText = this.DataVersao.Value;
			
			nodeData.AppendChild(nodeIdt);
			nodeData.AppendChild(nodeNome);
			nodeData.AppendChild(nodeDescricao);
			nodeData.AppendChild(nodeCodigo);
			nodeData.AppendChild(nodeSistema);
			nodeData.AppendChild(nodeVersao);
			nodeData.AppendChild(nodeDataVersao);
						
			xml.AppendChild(nodeData);
			return xml;
		}

		public static explicit operator DataRow(ModuloDTO dto)
		{
			ModuloDataTable dtb = new ModuloDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.Idt] = dto.Idt.Value;
			dtr[FieldNames.Nome] = dto.Nome.Value;
			dtr[FieldNames.Descricao] = dto.Descricao.Value;
			dtr[FieldNames.Codigo] = dto.Codigo.Value;
			dtr[FieldNames.Sistema] = dto.Sistema.Value;
			dtr[FieldNames.Versao] = dto.Versao.Value;
			dtr[FieldNames.DataVersao] = dto.DataVersao.Value;
			
			return dtr;
		}

		public static explicit operator XmlDocument(ModuloDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}

