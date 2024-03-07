
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
	/// Classe Entidade FuncionalidadeDataTable
	/// </summary>
	[Serializable()]
	public class FuncionalidadeDataTable : DataTable
	{
		
		public FuncionalidadeDataTable()
			: base()
		{
		
			this.TableName = "Funcionalidade";

					this.Columns.Add(FuncionalidadeDTO.FieldNames.Idt, typeof(Decimal));
		this.Columns.Add(FuncionalidadeDTO.FieldNames.Descricao, typeof(String));
		this.Columns.Add(FuncionalidadeDTO.FieldNames.FlagItemMenu, typeof(String));
		this.Columns.Add(FuncionalidadeDTO.FieldNames.IdtFuncionalidadePai, typeof(Decimal));
		this.Columns.Add(FuncionalidadeDTO.FieldNames.NomePagina, typeof(String));
		this.Columns.Add(FuncionalidadeDTO.FieldNames.Nome, typeof(String));
		this.Columns.Add(FuncionalidadeDTO.FieldNames.IdtModulo, typeof(Decimal));


			

			DataColumn[] primaryKey = { this.Columns[FuncionalidadeDTO.FieldNames.Idt] };

			this.PrimaryKey = primaryKey;
		}
		
		protected FuncionalidadeDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
		: base(serializationInfo, streamingContext){}


		public FuncionalidadeDTO TypedRow(int index)
		{
			return (FuncionalidadeDTO)this.Rows[index];
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

		public void Add(FuncionalidadeDTO dto)
		{
			DataRow dtr = this.NewRow();


					if (!dto.Idt.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		if (!dto.Descricao.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.Descricao] = (String)dto.Descricao.Value;
		if (!dto.FlagItemMenu.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.FlagItemMenu] = (String)dto.FlagItemMenu.Value;
		if (!dto.IdtFuncionalidadePai.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.IdtFuncionalidadePai] = (Decimal)dto.IdtFuncionalidadePai.Value;
		if (!dto.NomePagina.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.NomePagina] = (String)dto.NomePagina.Value;
		if (!dto.Nome.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.Nome] = (String)dto.Nome.Value;
		if (!dto.IdtModulo.Value.IsNull) dtr[FuncionalidadeDTO.FieldNames.IdtModulo] = (Decimal)dto.IdtModulo.Value;

			
			this.Rows.Add(dtr);
		}
		
		public FuncionalidadeEnumerator GetEnumerator()
		{
			return new FuncionalidadeEnumerator(this);
		}
	}
	
	// Inner class implements IEnumerator interface:
	public class FuncionalidadeEnumerator
	{
		private int position = -1;
		private DataTable dtb;

		public FuncionalidadeEnumerator(DataTable dtb)
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
		public FuncionalidadeDTO Current
		{
		get
			{
				FuncionalidadeDTO dto = new FuncionalidadeDTO();			
				dto.Idt.Value = dtb.Rows[position][FuncionalidadeDTO.FieldNames.Idt].ToString();
				dto.Descricao.Value = dtb.Rows[position][FuncionalidadeDTO.FieldNames.Descricao].ToString();
				dto.FlagItemMenu.Value = dtb.Rows[position][FuncionalidadeDTO.FieldNames.FlagItemMenu].ToString();
				dto.IdtFuncionalidadePai.Value = dtb.Rows[position][FuncionalidadeDTO.FieldNames.IdtFuncionalidadePai].ToString();
				dto.NomePagina.Value = dtb.Rows[position][FuncionalidadeDTO.FieldNames.NomePagina].ToString();
				dto.Nome.Value = dtb.Rows[position][FuncionalidadeDTO.FieldNames.Nome].ToString();
				dto.IdtModulo.Value = dtb.Rows[position][FuncionalidadeDTO.FieldNames.IdtModulo].ToString();
				
				return dto;
			}
		}
	}
	
	[Serializable()]
	public class FuncionalidadeDTO : MVC.DTO.DTOBase
	{	
				private MVC.DTO.FieldDecimal seg_fun_id_funcionalidade;
		private MVC.DTO.FieldString seg_fun_ds_descricao;
		private MVC.DTO.FieldString seg_fun_fl_item_menu_ok;
		private MVC.DTO.FieldDecimal seg_fun_id_funcionalidade_pai;
		private MVC.DTO.FieldString seg_fun_ds_nome_pagina;
		private MVC.DTO.FieldString seg_fun_nm_nome;
		private MVC.DTO.FieldDecimal seg_mod_id_modulo;

		
		public FuncionalidadeDTO()
		{
			InitializeComponent();
		}
		
		internal void InitializeComponent()
		{
					this.seg_fun_id_funcionalidade= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		this.seg_fun_ds_descricao= new MVC.DTO.FieldString(FieldNames.Descricao,Captions.Descricao, 100);
		this.seg_fun_fl_item_menu_ok= new MVC.DTO.FieldString(FieldNames.FlagItemMenu,Captions.FlagItemMenu, 1);
		this.seg_fun_id_funcionalidade_pai= new MVC.DTO.FieldDecimal(FieldNames.IdtFuncionalidadePai,Captions.IdtFuncionalidadePai, DbType.Decimal);
		this.seg_fun_ds_nome_pagina= new MVC.DTO.FieldString(FieldNames.NomePagina,Captions.NomePagina, 100);
		this.seg_fun_nm_nome= new MVC.DTO.FieldString(FieldNames.Nome,Captions.Nome, 50);
		this.seg_mod_id_modulo= new MVC.DTO.FieldDecimal(FieldNames.IdtModulo,Captions.IdtModulo, DbType.Decimal);
		
		}
 
		#region FieldNames

		public struct FieldNames
		{
				public const string Idt="SEG_FUN_ID_FUNCIONALIDADE";
		public const string Descricao="SEG_FUN_DS_DESCRICAO";
		public const string FlagItemMenu="SEG_FUN_FL_ITEM_MENU_OK";
		public const string IdtFuncionalidadePai="SEG_FUN_ID_FUNCIONALIDADE_PAI";
		public const string NomePagina="SEG_FUN_DS_NOME_PAGINA";
		public const string Nome="SEG_FUN_NM_NOME";
		public const string IdtModulo="SEG_MOD_ID_MODULO";
		
		}		

		#endregion

		#region Captions
		public struct Captions
		{
				public const string Idt="IDT";
		public const string Descricao="DESCRICAO";
		public const string FlagItemMenu="FLAGITEMMENU";
		public const string IdtFuncionalidadePai="IDTFUNCIONALIDADEPAI";
		public const string NomePagina="NOMEPAGINA";
		public const string Nome="NOME";
		public const string IdtModulo="IDTMODULO";
		
		}		

		#endregion
		
		#region Atributos Publicos

		
			 
		public MVC.DTO.FieldDecimal Idt
		{
			get { return seg_fun_id_funcionalidade; }
			set { seg_fun_id_funcionalidade = value; }
		}
		
			 
		public MVC.DTO.FieldString Descricao
		{
			get { return seg_fun_ds_descricao; }
			set { seg_fun_ds_descricao = value; }
		}
		
			 
		public MVC.DTO.FieldString FlagItemMenu
		{
			get { return seg_fun_fl_item_menu_ok; }
			set { seg_fun_fl_item_menu_ok = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtFuncionalidadePai
		{
			get { return seg_fun_id_funcionalidade_pai; }
			set { seg_fun_id_funcionalidade_pai = value; }
		}
		
			 
		public MVC.DTO.FieldString NomePagina
		{
			get { return seg_fun_ds_nome_pagina; }
			set { seg_fun_ds_nome_pagina = value; }
		}
		
			 
		public MVC.DTO.FieldString Nome
		{
			get { return seg_fun_nm_nome; }
			set { seg_fun_nm_nome = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtModulo
		{
			get { return seg_mod_id_modulo; }
			set { seg_mod_id_modulo = value; }
		}
					
			
		#endregion


		#region Operators

		public static explicit operator FuncionalidadeDTO(DataRow row)
		{
			FuncionalidadeDTO  dto = new FuncionalidadeDTO();
			dto.Idt.Value = row[FieldNames.Idt].ToString();
			dto.Descricao.Value = row[FieldNames.Descricao].ToString();
			dto.FlagItemMenu.Value = row[FieldNames.FlagItemMenu].ToString();
			dto.IdtFuncionalidadePai.Value = row[FieldNames.IdtFuncionalidadePai].ToString();
			dto.NomePagina.Value = row[FieldNames.NomePagina].ToString();
			dto.Nome.Value = row[FieldNames.Nome].ToString();
			dto.IdtModulo.Value = row[FieldNames.IdtModulo].ToString();
			
			
			return dto;
		}

		public static explicit operator FuncionalidadeDTO(XmlDocument xml)
		{
			FuncionalidadeDTO dto = new FuncionalidadeDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Descricao) != null) dto.Descricao.Value = xml.FirstChild.SelectSingleNode(FieldNames.Descricao).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.FlagItemMenu) != null) dto.FlagItemMenu.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlagItemMenu).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFuncionalidadePai) != null) dto.IdtFuncionalidadePai.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFuncionalidadePai).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.NomePagina) != null) dto.NomePagina.Value = xml.FirstChild.SelectSingleNode(FieldNames.NomePagina).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Nome) != null) dto.Nome.Value = xml.FirstChild.SelectSingleNode(FieldNames.Nome).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo) != null) dto.IdtModulo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo).InnerText;			
			
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			XmlNode nodeDescricao = xml.CreateNode(XmlNodeType.Element, FieldNames.Descricao, null);
			XmlNode nodeFlagItemMenu = xml.CreateNode(XmlNodeType.Element, FieldNames.FlagItemMenu, null);
			XmlNode nodeIdtFuncionalidadePai = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFuncionalidadePai, null);
			XmlNode nodeNomePagina = xml.CreateNode(XmlNodeType.Element, FieldNames.NomePagina, null);
			XmlNode nodeNome = xml.CreateNode(XmlNodeType.Element, FieldNames.Nome, null);
			XmlNode nodeIdtModulo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtModulo, null);
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			if (!this.Descricao.Value.IsNull) nodeDescricao.InnerText = this.Descricao.Value;
			if (!this.FlagItemMenu.Value.IsNull) nodeFlagItemMenu.InnerText = this.FlagItemMenu.Value;
			if (!this.IdtFuncionalidadePai.Value.IsNull) nodeIdtFuncionalidadePai.InnerText = this.IdtFuncionalidadePai.Value;
			if (!this.NomePagina.Value.IsNull) nodeNomePagina.InnerText = this.NomePagina.Value;
			if (!this.Nome.Value.IsNull) nodeNome.InnerText = this.Nome.Value;
			if (!this.IdtModulo.Value.IsNull) nodeIdtModulo.InnerText = this.IdtModulo.Value;
			
			nodeData.AppendChild(nodeIdt);
			nodeData.AppendChild(nodeDescricao);
			nodeData.AppendChild(nodeFlagItemMenu);
			nodeData.AppendChild(nodeIdtFuncionalidadePai);
			nodeData.AppendChild(nodeNomePagina);
			nodeData.AppendChild(nodeNome);
			nodeData.AppendChild(nodeIdtModulo);
						
			xml.AppendChild(nodeData);
			return xml;
		}

		public static explicit operator DataRow(FuncionalidadeDTO dto)
		{
			FuncionalidadeDataTable dtb = new FuncionalidadeDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.Idt] = dto.Idt.Value;
			dtr[FieldNames.Descricao] = dto.Descricao.Value;
			dtr[FieldNames.FlagItemMenu] = dto.FlagItemMenu.Value;
			dtr[FieldNames.IdtFuncionalidadePai] = dto.IdtFuncionalidadePai.Value;
			dtr[FieldNames.NomePagina] = dto.NomePagina.Value;
			dtr[FieldNames.Nome] = dto.Nome.Value;
			dtr[FieldNames.IdtModulo] = dto.IdtModulo.Value;
			
			return dtr;
		}

		public static explicit operator XmlDocument(FuncionalidadeDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}

