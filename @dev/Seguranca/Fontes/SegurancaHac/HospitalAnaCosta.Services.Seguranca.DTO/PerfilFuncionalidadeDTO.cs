
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
	/// Classe Entidade PerfilFuncionalidadeDataTable
	/// </summary>
	[Serializable()]
	public class PerfilFuncionalidadeDataTable : DataTable
	{
		
		public PerfilFuncionalidadeDataTable()
			: base()
		{
		
			this.TableName = "PerfilFuncionalidade";

					this.Columns.Add(PerfilFuncionalidadeDTO.FieldNames.IdtPerfil, typeof(Decimal));
		this.Columns.Add(PerfilFuncionalidadeDTO.FieldNames.IdtModulo, typeof(Decimal));
		this.Columns.Add(PerfilFuncionalidadeDTO.FieldNames.IdtFuncionalidade, typeof(Decimal));


			

			DataColumn[] primaryKey = { this.Columns[PerfilFuncionalidadeDTO.FieldNames.IdtFuncionalidade], this.Columns[PerfilFuncionalidadeDTO.FieldNames.IdtModulo], this.Columns[PerfilFuncionalidadeDTO.FieldNames.IdtPerfil] };

			this.PrimaryKey = primaryKey;
		}
		
		protected PerfilFuncionalidadeDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
		: base(serializationInfo, streamingContext){}


		public PerfilFuncionalidadeDTO TypedRow(int index)
		{
			return (PerfilFuncionalidadeDTO)this.Rows[index];
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

		public void Add(PerfilFuncionalidadeDTO dto)
		{
			DataRow dtr = this.NewRow();


					if (!dto.IdtPerfil.Value.IsNull) dtr[PerfilFuncionalidadeDTO.FieldNames.IdtPerfil] = (Decimal)dto.IdtPerfil.Value;
		if (!dto.IdtModulo.Value.IsNull) dtr[PerfilFuncionalidadeDTO.FieldNames.IdtModulo] = (Decimal)dto.IdtModulo.Value;
		if (!dto.IdtFuncionalidade.Value.IsNull) dtr[PerfilFuncionalidadeDTO.FieldNames.IdtFuncionalidade] = (Decimal)dto.IdtFuncionalidade.Value;

			
			this.Rows.Add(dtr);
		}
		
		public PerfilFuncionalidadeEnumerator GetEnumerator()
		{
			return new PerfilFuncionalidadeEnumerator(this);
		}
	}
	
	// Inner class implements IEnumerator interface:
	public class PerfilFuncionalidadeEnumerator
	{
		private int position = -1;
		private DataTable dtb;

		public PerfilFuncionalidadeEnumerator(DataTable dtb)
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
		public PerfilFuncionalidadeDTO Current
		{
		get
			{
				PerfilFuncionalidadeDTO dto = new PerfilFuncionalidadeDTO();			
				dto.IdtPerfil.Value = dtb.Rows[position][PerfilFuncionalidadeDTO.FieldNames.IdtPerfil].ToString();
				dto.IdtModulo.Value = dtb.Rows[position][PerfilFuncionalidadeDTO.FieldNames.IdtModulo].ToString();
				dto.IdtFuncionalidade.Value = dtb.Rows[position][PerfilFuncionalidadeDTO.FieldNames.IdtFuncionalidade].ToString();
				
				return dto;
			}
		}
	}
	
	[Serializable()]
	public class PerfilFuncionalidadeDTO : MVC.DTO.DTOBase
	{	
				private MVC.DTO.FieldDecimal seg_per_id_perfil;
		private MVC.DTO.FieldDecimal seg_mod_id_modulo;
		private MVC.DTO.FieldDecimal seg_fun_id_funcionalidade;

		
		public PerfilFuncionalidadeDTO()
		{
			InitializeComponent();
		}
		
		internal void InitializeComponent()
		{
					this.seg_per_id_perfil= new MVC.DTO.FieldDecimal(FieldNames.IdtPerfil,Captions.IdtPerfil, DbType.Decimal);
		this.seg_mod_id_modulo= new MVC.DTO.FieldDecimal(FieldNames.IdtModulo,Captions.IdtModulo, DbType.Decimal);
		this.seg_fun_id_funcionalidade= new MVC.DTO.FieldDecimal(FieldNames.IdtFuncionalidade,Captions.IdtFuncionalidade, DbType.Decimal);
		
		}
 
		#region FieldNames

		public struct FieldNames
		{
				public const string IdtPerfil="SEG_PER_ID_PERFIL";
		public const string IdtModulo="SEG_MOD_ID_MODULO";
		public const string IdtFuncionalidade="SEG_FUN_ID_FUNCIONALIDADE";
		
		}		

		#endregion

		#region Captions
		public struct Captions
		{
				public const string IdtPerfil="IDTPERFIL";
		public const string IdtModulo="IDTMODULO";
		public const string IdtFuncionalidade="IDTFUNCIONALIDADE";
		
		}		

		#endregion
		
		#region Atributos Publicos

		
			 
		public MVC.DTO.FieldDecimal IdtPerfil
		{
			get { return seg_per_id_perfil; }
			set { seg_per_id_perfil = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtModulo
		{
			get { return seg_mod_id_modulo; }
			set { seg_mod_id_modulo = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtFuncionalidade
		{
			get { return seg_fun_id_funcionalidade; }
			set { seg_fun_id_funcionalidade = value; }
		}
					
			
		#endregion


		#region Operators

		public static explicit operator PerfilFuncionalidadeDTO(DataRow row)
		{
			PerfilFuncionalidadeDTO  dto = new PerfilFuncionalidadeDTO();
			dto.IdtPerfil.Value = row[FieldNames.IdtPerfil].ToString();
			dto.IdtModulo.Value = row[FieldNames.IdtModulo].ToString();
			dto.IdtFuncionalidade.Value = row[FieldNames.IdtFuncionalidade].ToString();
			
			
			return dto;
		}

		public static explicit operator PerfilFuncionalidadeDTO(XmlDocument xml)
		{
			PerfilFuncionalidadeDTO dto = new PerfilFuncionalidadeDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtPerfil) != null) dto.IdtPerfil.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtPerfil).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo) != null) dto.IdtModulo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFuncionalidade) != null) dto.IdtFuncionalidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFuncionalidade).InnerText;			
			
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeIdtPerfil = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtPerfil, null);
			XmlNode nodeIdtModulo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtModulo, null);
			XmlNode nodeIdtFuncionalidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFuncionalidade, null);
			
			if (!this.IdtPerfil.Value.IsNull) nodeIdtPerfil.InnerText = this.IdtPerfil.Value;
			if (!this.IdtModulo.Value.IsNull) nodeIdtModulo.InnerText = this.IdtModulo.Value;
			if (!this.IdtFuncionalidade.Value.IsNull) nodeIdtFuncionalidade.InnerText = this.IdtFuncionalidade.Value;
			
			nodeData.AppendChild(nodeIdtPerfil);
			nodeData.AppendChild(nodeIdtModulo);
			nodeData.AppendChild(nodeIdtFuncionalidade);
						
			xml.AppendChild(nodeData);
			return xml;
		}

		public static explicit operator DataRow(PerfilFuncionalidadeDTO dto)
		{
			PerfilFuncionalidadeDataTable dtb = new PerfilFuncionalidadeDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.IdtPerfil] = dto.IdtPerfil.Value;
			dtr[FieldNames.IdtModulo] = dto.IdtModulo.Value;
			dtr[FieldNames.IdtFuncionalidade] = dto.IdtFuncionalidade.Value;
			
			return dtr;
		}

		public static explicit operator XmlDocument(PerfilFuncionalidadeDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}

