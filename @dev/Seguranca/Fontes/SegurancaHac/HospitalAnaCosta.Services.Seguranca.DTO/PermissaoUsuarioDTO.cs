
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
	/// Classe Entidade PermissaoUsuarioDataTable
	/// </summary>
	[Serializable()]
	public class PermissaoUsuarioDataTable : DataTable
	{
		
		public PermissaoUsuarioDataTable()
			: base()
		{
		
			this.TableName = "PermissaoUsuario";

					this.Columns.Add(PermissaoUsuarioDTO.FieldNames.IdtPerfil, typeof(Decimal));
		this.Columns.Add(PermissaoUsuarioDTO.FieldNames.IdtUsuario, typeof(Decimal));
		this.Columns.Add(PermissaoUsuarioDTO.FieldNames.IdtUnidade, typeof(Decimal));
		this.Columns.Add(PermissaoUsuarioDTO.FieldNames.IdtModulo, typeof(Decimal));


			

			DataColumn[] primaryKey = { this.Columns[PermissaoUsuarioDTO.FieldNames.IdtUnidade], this.Columns[PermissaoUsuarioDTO.FieldNames.IdtModulo], this.Columns[PermissaoUsuarioDTO.FieldNames.IdtPerfil], this.Columns[PermissaoUsuarioDTO.FieldNames.IdtUsuario] };

			this.PrimaryKey = primaryKey;
		}
		
		protected PermissaoUsuarioDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
		: base(serializationInfo, streamingContext){}


		public PermissaoUsuarioDTO TypedRow(int index)
		{
			return (PermissaoUsuarioDTO)this.Rows[index];
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

		public void Add(PermissaoUsuarioDTO dto)
		{
			DataRow dtr = this.NewRow();


					if (!dto.IdtPerfil.Value.IsNull) dtr[PermissaoUsuarioDTO.FieldNames.IdtPerfil] = (Decimal)dto.IdtPerfil.Value;
		if (!dto.IdtUsuario.Value.IsNull) dtr[PermissaoUsuarioDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;
		if (!dto.IdtUnidade.Value.IsNull) dtr[PermissaoUsuarioDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;
		if (!dto.IdtModulo.Value.IsNull) dtr[PermissaoUsuarioDTO.FieldNames.IdtModulo] = (Decimal)dto.IdtModulo.Value;

			
			this.Rows.Add(dtr);
		}
		
		public PermissaoUsuarioEnumerator GetEnumerator()
		{
			return new PermissaoUsuarioEnumerator(this);
		}
	}
	
	// Inner class implements IEnumerator interface:
	public class PermissaoUsuarioEnumerator
	{
		private int position = -1;
		private DataTable dtb;

		public PermissaoUsuarioEnumerator(DataTable dtb)
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
		public PermissaoUsuarioDTO Current
		{
		get
			{
				PermissaoUsuarioDTO dto = new PermissaoUsuarioDTO();			
				dto.IdtPerfil.Value = dtb.Rows[position][PermissaoUsuarioDTO.FieldNames.IdtPerfil].ToString();
				dto.IdtUsuario.Value = dtb.Rows[position][PermissaoUsuarioDTO.FieldNames.IdtUsuario].ToString();
				dto.IdtUnidade.Value = dtb.Rows[position][PermissaoUsuarioDTO.FieldNames.IdtUnidade].ToString();
				dto.IdtModulo.Value = dtb.Rows[position][PermissaoUsuarioDTO.FieldNames.IdtModulo].ToString();
				
				return dto;
			}
		}
	}
	
	[Serializable()]
	public class PermissaoUsuarioDTO : MVC.DTO.DTOBase
	{	
				private MVC.DTO.FieldDecimal seg_per_id_perfil;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario;
		private MVC.DTO.FieldDecimal cad_uni_id_unidade;
		private MVC.DTO.FieldDecimal seg_mod_id_modulo;

		
		public PermissaoUsuarioDTO()
		{
			InitializeComponent();
		}
		
		internal void InitializeComponent()
		{
					this.seg_per_id_perfil= new MVC.DTO.FieldDecimal(FieldNames.IdtPerfil,Captions.IdtPerfil, DbType.Decimal);
		this.seg_usu_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario,Captions.IdtUsuario, DbType.Decimal);
		this.cad_uni_id_unidade= new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade,Captions.IdtUnidade, DbType.Decimal);
		this.seg_mod_id_modulo= new MVC.DTO.FieldDecimal(FieldNames.IdtModulo,Captions.IdtModulo, DbType.Decimal);
		
		}
 
		#region FieldNames

		public struct FieldNames
		{
				public const string IdtPerfil="SEG_PER_ID_PERFIL";
		public const string IdtUsuario="SEG_USU_ID_USUARIO";
		public const string IdtUnidade="CAD_UNI_ID_UNIDADE";
		public const string IdtModulo="SEG_MOD_ID_MODULO";
		
		}		

		#endregion

		#region Captions
		public struct Captions
		{
				public const string IdtPerfil="IDTPERFIL";
		public const string IdtUsuario="IDTUSUARIO";
		public const string IdtUnidade="IDTUNIDADE";
		public const string IdtModulo="IDTMODULO";
		
		}		

		#endregion
		
		#region Atributos Publicos

		
			 
		public MVC.DTO.FieldDecimal IdtPerfil
		{
			get { return seg_per_id_perfil; }
			set { seg_per_id_perfil = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtUsuario
		{
			get { return seg_usu_id_usuario; }
			set { seg_usu_id_usuario = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtUnidade
		{
			get { return cad_uni_id_unidade; }
			set { cad_uni_id_unidade = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtModulo
		{
			get { return seg_mod_id_modulo; }
			set { seg_mod_id_modulo = value; }
		}
					
			
		#endregion


		#region Operators

		public static explicit operator PermissaoUsuarioDTO(DataRow row)
		{
			PermissaoUsuarioDTO  dto = new PermissaoUsuarioDTO();
			dto.IdtPerfil.Value = row[FieldNames.IdtPerfil].ToString();
			dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();
			dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();
			dto.IdtModulo.Value = row[FieldNames.IdtModulo].ToString();
			
			
			return dto;
		}

		public static explicit operator PermissaoUsuarioDTO(XmlDocument xml)
		{
			PermissaoUsuarioDTO dto = new PermissaoUsuarioDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtPerfil) != null) dto.IdtPerfil.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtPerfil).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo) != null) dto.IdtModulo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo).InnerText;			
			
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeIdtPerfil = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtPerfil, null);
			XmlNode nodeIdtUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);
			XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);
			XmlNode nodeIdtModulo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtModulo, null);
			
			if (!this.IdtPerfil.Value.IsNull) nodeIdtPerfil.InnerText = this.IdtPerfil.Value;
			if (!this.IdtUsuario.Value.IsNull) nodeIdtUsuario.InnerText = this.IdtUsuario.Value;
			if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;
			if (!this.IdtModulo.Value.IsNull) nodeIdtModulo.InnerText = this.IdtModulo.Value;
			
			nodeData.AppendChild(nodeIdtPerfil);
			nodeData.AppendChild(nodeIdtUsuario);
			nodeData.AppendChild(nodeIdtUnidade);
			nodeData.AppendChild(nodeIdtModulo);
						
			xml.AppendChild(nodeData);
			return xml;
		}

		public static explicit operator DataRow(PermissaoUsuarioDTO dto)
		{
			PermissaoUsuarioDataTable dtb = new PermissaoUsuarioDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.IdtPerfil] = dto.IdtPerfil.Value;
			dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;
			dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;
			dtr[FieldNames.IdtModulo] = dto.IdtModulo.Value;
			
			return dtr;
		}

		public static explicit operator XmlDocument(PermissaoUsuarioDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}

