
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
	/// Classe Entidade PerfilDataTable
	/// </summary>
	[Serializable()]
	public class PerfilDataTable : DataTable
	{
		
		public PerfilDataTable()
			: base()
		{
		
			this.TableName = "Perfil";

					this.Columns.Add(PerfilDTO.FieldNames.Idt, typeof(Decimal));
		this.Columns.Add(PerfilDTO.FieldNames.Nome, typeof(String));
		this.Columns.Add(PerfilDTO.FieldNames.FlagStatus, typeof(String));
		this.Columns.Add(PerfilDTO.FieldNames.DataAtualizacao, typeof(DateTime));
		this.Columns.Add(PerfilDTO.FieldNames.IdtUsuario, typeof(Decimal));


			

			DataColumn[] primaryKey = { this.Columns[PerfilDTO.FieldNames.Idt] };

			this.PrimaryKey = primaryKey;
		}
		
		protected PerfilDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
		: base(serializationInfo, streamingContext){}


		public PerfilDTO TypedRow(int index)
		{
			return (PerfilDTO)this.Rows[index];
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

		public void Add(PerfilDTO dto)
		{
			DataRow dtr = this.NewRow();


					if (!dto.Idt.Value.IsNull) dtr[PerfilDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		if (!dto.Nome.Value.IsNull) dtr[PerfilDTO.FieldNames.Nome] = (String)dto.Nome.Value;
		if (!dto.FlagStatus.Value.IsNull) dtr[PerfilDTO.FieldNames.FlagStatus] = (String)dto.FlagStatus.Value;
		if (!dto.DataAtualizacao.Value.IsNull) dtr[PerfilDTO.FieldNames.DataAtualizacao] = (DateTime)dto.DataAtualizacao.Value;
		if (!dto.IdtUsuario.Value.IsNull) dtr[PerfilDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;

			
			this.Rows.Add(dtr);
		}
		
		public PerfilEnumerator GetEnumerator()
		{
			return new PerfilEnumerator(this);
		}
	}
	
	// Inner class implements IEnumerator interface:
	public class PerfilEnumerator
	{
		private int position = -1;
		private DataTable dtb;

		public PerfilEnumerator(DataTable dtb)
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
		public PerfilDTO Current
		{
		get
			{
				PerfilDTO dto = new PerfilDTO();			
				dto.Idt.Value = dtb.Rows[position][PerfilDTO.FieldNames.Idt].ToString();
				dto.Nome.Value = dtb.Rows[position][PerfilDTO.FieldNames.Nome].ToString();
				dto.FlagStatus.Value = dtb.Rows[position][PerfilDTO.FieldNames.FlagStatus].ToString();
				dto.DataAtualizacao.Value = dtb.Rows[position][PerfilDTO.FieldNames.DataAtualizacao].ToString();
				dto.IdtUsuario.Value = dtb.Rows[position][PerfilDTO.FieldNames.IdtUsuario].ToString();
				
				return dto;
			}
		}
	}
	
	[Serializable()]
	public class PerfilDTO : MVC.DTO.DTOBase
	{	
				private MVC.DTO.FieldDecimal seg_per_id_perfil;
		private MVC.DTO.FieldString seg_per_nm_perfil;
		private MVC.DTO.FieldString seg_per_fl_status;
		private MVC.DTO.FieldDateTime seg_per_dt_ultima_atualizacao;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario;

		
		public PerfilDTO()
		{
			InitializeComponent();
		}
		
		internal void InitializeComponent()
		{
					this.seg_per_id_perfil= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		this.seg_per_nm_perfil= new MVC.DTO.FieldString(FieldNames.Nome,Captions.Nome, 50);
		this.seg_per_fl_status= new MVC.DTO.FieldString(FieldNames.FlagStatus,Captions.FlagStatus, 1);
		this.seg_per_dt_ultima_atualizacao= new MVC.DTO.FieldDateTime(FieldNames.DataAtualizacao,Captions.DataAtualizacao);
		this.seg_usu_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario,Captions.IdtUsuario, DbType.Decimal);
		
		}
 
		#region FieldNames

		public struct FieldNames
		{
				public const string Idt="SEG_PER_ID_PERFIL";
		public const string Nome="SEG_PER_NM_PERFIL";
		public const string FlagStatus="SEG_PER_FL_STATUS";
		public const string DataAtualizacao="SEG_PER_DT_ULTIMA_ATUALIZACAO";
		public const string IdtUsuario="SEG_USU_ID_USUARIO";
		
		}		

		#endregion

		#region Captions
		public struct Captions
		{
				public const string Idt="IDT";
		public const string Nome="NOME";
		public const string FlagStatus="FLAGSTATUS";
		public const string DataAtualizacao="DATAATUALIZACAO";
		public const string IdtUsuario="IDTUSUARIO";
		
		}		

		#endregion
		
		#region Atributos Publicos

		
			 
		public MVC.DTO.FieldDecimal Idt
		{
			get { return seg_per_id_perfil; }
			set { seg_per_id_perfil = value; }
		}
		
			 
		public MVC.DTO.FieldString Nome
		{
			get { return seg_per_nm_perfil; }
			set { seg_per_nm_perfil = value; }
		}
		
			 
		public MVC.DTO.FieldString FlagStatus
		{
			get { return seg_per_fl_status; }
			set { seg_per_fl_status = value; }
		}
		
			 
		public MVC.DTO.FieldDateTime DataAtualizacao
		{
			get { return seg_per_dt_ultima_atualizacao; }
			set { seg_per_dt_ultima_atualizacao = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtUsuario
		{
			get { return seg_usu_id_usuario; }
			set { seg_usu_id_usuario = value; }
		}
					
			
		#endregion


		#region Operators

		public static explicit operator PerfilDTO(DataRow row)
		{
			PerfilDTO  dto = new PerfilDTO();
			dto.Idt.Value = row[FieldNames.Idt].ToString();
			dto.Nome.Value = row[FieldNames.Nome].ToString();
			dto.FlagStatus.Value = row[FieldNames.FlagStatus].ToString();
			dto.DataAtualizacao.Value = row[FieldNames.DataAtualizacao].ToString();
			dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();
			
			
			return dto;
		}

		public static explicit operator PerfilDTO(XmlDocument xml)
		{
			PerfilDTO dto = new PerfilDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Nome) != null) dto.Nome.Value = xml.FirstChild.SelectSingleNode(FieldNames.Nome).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.FlagStatus) != null) dto.FlagStatus.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlagStatus).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizacao) != null) dto.DataAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizacao).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;			
			
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			XmlNode nodeNome = xml.CreateNode(XmlNodeType.Element, FieldNames.Nome, null);
			XmlNode nodeFlagStatus = xml.CreateNode(XmlNodeType.Element, FieldNames.FlagStatus, null);
			XmlNode nodeDataAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DataAtualizacao, null);
			XmlNode nodeIdtUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			if (!this.Nome.Value.IsNull) nodeNome.InnerText = this.Nome.Value;
			if (!this.FlagStatus.Value.IsNull) nodeFlagStatus.InnerText = this.FlagStatus.Value;
			if (!this.DataAtualizacao.Value.IsNull) nodeDataAtualizacao.InnerText = this.DataAtualizacao.Value;
			if (!this.IdtUsuario.Value.IsNull) nodeIdtUsuario.InnerText = this.IdtUsuario.Value;
			
			nodeData.AppendChild(nodeIdt);
			nodeData.AppendChild(nodeNome);
			nodeData.AppendChild(nodeFlagStatus);
			nodeData.AppendChild(nodeDataAtualizacao);
			nodeData.AppendChild(nodeIdtUsuario);
						
			xml.AppendChild(nodeData);
			return xml;
		}

		public static explicit operator DataRow(PerfilDTO dto)
		{
			PerfilDataTable dtb = new PerfilDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.Idt] = dto.Idt.Value;
			dtr[FieldNames.Nome] = dto.Nome.Value;
			dtr[FieldNames.FlagStatus] = dto.FlagStatus.Value;
			dtr[FieldNames.DataAtualizacao] = dto.DataAtualizacao.Value;
			dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;
			
			return dtr;
		}

		public static explicit operator XmlDocument(PerfilDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}

