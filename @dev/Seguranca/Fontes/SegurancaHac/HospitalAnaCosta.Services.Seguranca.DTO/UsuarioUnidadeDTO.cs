
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
	/// Classe Entidade UsuarioUnidadeDataTable
	/// </summary>
	[Serializable()]
	public class UsuarioUnidadeDataTable : DataTable
	{
		
		public UsuarioUnidadeDataTable()
			: base()
		{
		
			this.TableName = "UsuarioUnidade";

					this.Columns.Add(UsuarioUnidadeDTO.FieldNames.IdtUsuario, typeof(Decimal));
		this.Columns.Add(UsuarioUnidadeDTO.FieldNames.IdtUnidade, typeof(Decimal));


			

			DataColumn[] primaryKey = { this.Columns[UsuarioUnidadeDTO.FieldNames.IdtUnidade], this.Columns[UsuarioUnidadeDTO.FieldNames.IdtUsuario] };

			this.PrimaryKey = primaryKey;
		}
		
		protected UsuarioUnidadeDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
		: base(serializationInfo, streamingContext){}


		public UsuarioUnidadeDTO TypedRow(int index)
		{
			return (UsuarioUnidadeDTO)this.Rows[index];
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

		public void Add(UsuarioUnidadeDTO dto)
		{
			DataRow dtr = this.NewRow();


					if (!dto.IdtUsuario.Value.IsNull) dtr[UsuarioUnidadeDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;
		if (!dto.IdtUnidade.Value.IsNull) dtr[UsuarioUnidadeDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;

			
			this.Rows.Add(dtr);
		}
		
		public UsuarioUnidadeEnumerator GetEnumerator()
		{
			return new UsuarioUnidadeEnumerator(this);
		}
	}
	
	// Inner class implements IEnumerator interface:
	public class UsuarioUnidadeEnumerator
	{
		private int position = -1;
		private DataTable dtb;

		public UsuarioUnidadeEnumerator(DataTable dtb)
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
		public UsuarioUnidadeDTO Current
		{
		get
			{
				UsuarioUnidadeDTO dto = new UsuarioUnidadeDTO();			
				dto.IdtUsuario.Value = dtb.Rows[position][UsuarioUnidadeDTO.FieldNames.IdtUsuario].ToString();
				dto.IdtUnidade.Value = dtb.Rows[position][UsuarioUnidadeDTO.FieldNames.IdtUnidade].ToString();
				
				return dto;
			}
		}
	}
	
	[Serializable()]
	public class UsuarioUnidadeDTO : MVC.DTO.DTOBase
	{	
				private MVC.DTO.FieldDecimal seg_usu_id_usuario;
		private MVC.DTO.FieldDecimal cad_uni_id_unidade;

		
		public UsuarioUnidadeDTO()
		{
			InitializeComponent();
		}
		
		internal void InitializeComponent()
		{
					this.seg_usu_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario,Captions.IdtUsuario, DbType.Decimal);
		this.cad_uni_id_unidade= new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade,Captions.IdtUnidade, DbType.Decimal);
		
		}
 
		#region FieldNames

		public struct FieldNames
		{
				public const string IdtUsuario="SEG_USU_ID_USUARIO";
		public const string IdtUnidade="CAD_UNI_ID_UNIDADE";
		
		}		

		#endregion

		#region Captions
		public struct Captions
		{
				public const string IdtUsuario="IDTUSUARIO";
		public const string IdtUnidade="IDTUNIDADE";
		
		}		

		#endregion
		
		#region Atributos Publicos

		
			 
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
					
			
		#endregion


		#region Operators

		public static explicit operator UsuarioUnidadeDTO(DataRow row)
		{
			UsuarioUnidadeDTO  dto = new UsuarioUnidadeDTO();
			dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();
			dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();
			
			
			return dto;
		}

		public static explicit operator UsuarioUnidadeDTO(XmlDocument xml)
		{
			UsuarioUnidadeDTO dto = new UsuarioUnidadeDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;			
			
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeIdtUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);
			XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);
			
			if (!this.IdtUsuario.Value.IsNull) nodeIdtUsuario.InnerText = this.IdtUsuario.Value;
			if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;
			
			nodeData.AppendChild(nodeIdtUsuario);
			nodeData.AppendChild(nodeIdtUnidade);
						
			xml.AppendChild(nodeData);
			return xml;
		}

		public static explicit operator DataRow(UsuarioUnidadeDTO dto)
		{
			UsuarioUnidadeDataTable dtb = new UsuarioUnidadeDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;
			dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;
			
			return dtr;
		}

		public static explicit operator XmlDocument(UsuarioUnidadeDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}

