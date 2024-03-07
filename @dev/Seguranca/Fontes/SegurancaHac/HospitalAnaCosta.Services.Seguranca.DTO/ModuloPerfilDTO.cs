
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
	/// Classe Entidade ModuloPerfilDataTable
	/// </summary>
	[Serializable()]
	public class ModuloPerfilDataTable : DataTable
	{
		
		public ModuloPerfilDataTable()
			: base()
		{
		
			this.TableName = "ModuloPerfil";

					this.Columns.Add(ModuloPerfilDTO.FieldNames.IdtPerfil   , typeof(Decimal));
		this.Columns.Add(ModuloPerfilDTO.FieldNames.IdtModulo, typeof(Decimal));


			

			DataColumn[] primaryKey = { this.Columns[ModuloPerfilDTO.FieldNames.IdtModulo], this.Columns[ModuloPerfilDTO.FieldNames.IdtPerfil] };

			this.PrimaryKey = primaryKey;
		}
		
		protected ModuloPerfilDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
		: base(serializationInfo, streamingContext){}


		public ModuloPerfilDTO TypedRow(int index)
		{
			return (ModuloPerfilDTO)this.Rows[index];
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

		public void Add(ModuloPerfilDTO dto)
		{
			DataRow dtr = this.NewRow();


					if (!dto.IdtPerfil.Value.IsNull) dtr[ModuloPerfilDTO.FieldNames.IdtPerfil] = (Decimal)dto.IdtPerfil.Value;
		if (!dto.IdtModulo.Value.IsNull) dtr[ModuloPerfilDTO.FieldNames.IdtModulo] = (Decimal)dto.IdtModulo.Value;

			
			this.Rows.Add(dtr);
		}
		
		public ModuloPerfilEnumerator GetEnumerator()
		{
			return new ModuloPerfilEnumerator(this);
		}
	}
	
	// Inner class implements IEnumerator interface:
	public class ModuloPerfilEnumerator
	{
		private int position = -1;
		private DataTable dtb;

		public ModuloPerfilEnumerator(DataTable dtb)
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
		public ModuloPerfilDTO Current
		{
		get
			{
				ModuloPerfilDTO dto = new ModuloPerfilDTO();			
				dto.IdtPerfil.Value = dtb.Rows[position][ModuloPerfilDTO.FieldNames.IdtPerfil].ToString();
				dto.IdtModulo.Value = dtb.Rows[position][ModuloPerfilDTO.FieldNames.IdtModulo].ToString();
				
				return dto;
			}
		}
	}
	
	[Serializable()]
	public class ModuloPerfilDTO : MVC.DTO.DTOBase
	{	
				private MVC.DTO.FieldDecimal seg_per_id_perfil;
		private MVC.DTO.FieldDecimal seg_mod_id_modulo;

		
		public ModuloPerfilDTO()
		{
			InitializeComponent();
		}
		
		internal void InitializeComponent()
		{
					this.seg_per_id_perfil= new MVC.DTO.FieldDecimal(FieldNames.IdtPerfil,Captions.IdtPerfil, DbType.Decimal);
		this.seg_mod_id_modulo= new MVC.DTO.FieldDecimal(FieldNames.IdtModulo,Captions.IdtModulo, DbType.Decimal);
		
		}
 
		#region FieldNames

		public struct FieldNames
		{
				public const string IdtPerfil="SEG_PER_ID_PERFIL";
		public const string IdtModulo="SEG_MOD_ID_MODULO";
		
		}		

		#endregion

		#region Captions
		public struct Captions
		{
				public const string IdtPerfil="IDTPERFIL";
		public const string IdtModulo="IDTMODULO";
		
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
					
			
		#endregion


		#region Operators

		public static explicit operator ModuloPerfilDTO(DataRow row)
		{
			ModuloPerfilDTO  dto = new ModuloPerfilDTO();
			dto.IdtPerfil.Value = row[FieldNames.IdtPerfil].ToString();
			dto.IdtModulo.Value = row[FieldNames.IdtModulo].ToString();
			
			
			return dto;
		}

		public static explicit operator ModuloPerfilDTO(XmlDocument xml)
		{
			ModuloPerfilDTO dto = new ModuloPerfilDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtPerfil) != null) dto.IdtPerfil.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtPerfil).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo) != null) dto.IdtModulo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo).InnerText;			
			
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeIdtPerfil = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtPerfil, null);
			XmlNode nodeIdtModulo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtModulo, null);
			
			if (!this.IdtPerfil.Value.IsNull) nodeIdtPerfil.InnerText = this.IdtPerfil.Value;
			if (!this.IdtModulo.Value.IsNull) nodeIdtModulo.InnerText = this.IdtModulo.Value;
			
			nodeData.AppendChild(nodeIdtPerfil);
			nodeData.AppendChild(nodeIdtModulo);
						
			xml.AppendChild(nodeData);
			return xml;
		}

		public static explicit operator DataRow(ModuloPerfilDTO dto)
		{
			ModuloPerfilDataTable dtb = new ModuloPerfilDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.IdtPerfil] = dto.IdtPerfil.Value;
			dtr[FieldNames.IdtModulo] = dto.IdtModulo.Value;
			
			return dtr;
		}

		public static explicit operator XmlDocument(ModuloPerfilDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}

