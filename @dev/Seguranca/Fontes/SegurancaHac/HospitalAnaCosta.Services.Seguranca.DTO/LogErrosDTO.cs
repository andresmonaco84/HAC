
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
	/// Classe Entidade LogErrosDataTable
	/// </summary>
	[Serializable()]
	public class LogErrosDataTable : DataTable
	{
		
		public LogErrosDataTable()
			: base()
		{
		
			this.TableName = "LogErros";

					this.Columns.Add(LogErrosDTO.FieldNames.Idt, typeof(Decimal));
		this.Columns.Add(LogErrosDTO.FieldNames.Data, typeof(DateTime));
		this.Columns.Add(LogErrosDTO.FieldNames.URL, typeof(String));
		this.Columns.Add(LogErrosDTO.FieldNames.Codigo, typeof(Decimal));
		this.Columns.Add(LogErrosDTO.FieldNames.Descricao, typeof(String));
		this.Columns.Add(LogErrosDTO.FieldNames.IdtUsuario, typeof(Decimal));
		this.Columns.Add(LogErrosDTO.FieldNames.StackTrace, typeof(String));


			

			DataColumn[] primaryKey = { this.Columns[LogErrosDTO.FieldNames.Idt] };

			this.PrimaryKey = primaryKey;
		}
		
		protected LogErrosDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
		: base(serializationInfo, streamingContext){}


		public LogErrosDTO TypedRow(int index)
		{
			return (LogErrosDTO)this.Rows[index];
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

		public void Add(LogErrosDTO dto)
		{
			DataRow dtr = this.NewRow();


					if (!dto.Idt.Value.IsNull) dtr[LogErrosDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		if (!dto.Data.Value.IsNull) dtr[LogErrosDTO.FieldNames.Data] = (DateTime)dto.Data.Value;
		if (!dto.URL.Value.IsNull) dtr[LogErrosDTO.FieldNames.URL] = (String)dto.URL.Value;
		if (!dto.Codigo.Value.IsNull) dtr[LogErrosDTO.FieldNames.Codigo] = (Decimal)dto.Codigo.Value;
		if (!dto.Descricao.Value.IsNull) dtr[LogErrosDTO.FieldNames.Descricao] = (String)dto.Descricao.Value;
		if (!dto.IdtUsuario.Value.IsNull) dtr[LogErrosDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;
		if (!dto.StackTrace.Value.IsNull) dtr[LogErrosDTO.FieldNames.StackTrace] = (String)dto.StackTrace.Value;

			
			this.Rows.Add(dtr);
		}
		
		public LogErrosEnumerator GetEnumerator()
		{
			return new LogErrosEnumerator(this);
		}
	}
	
	// Inner class implements IEnumerator interface:
	public class LogErrosEnumerator
	{
		private int position = -1;
		private DataTable dtb;

		public LogErrosEnumerator(DataTable dtb)
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
		public LogErrosDTO Current
		{
		get
			{
				LogErrosDTO dto = new LogErrosDTO();			
				dto.Idt.Value = dtb.Rows[position][LogErrosDTO.FieldNames.Idt].ToString();
				dto.Data.Value = dtb.Rows[position][LogErrosDTO.FieldNames.Data].ToString();
				dto.URL.Value = dtb.Rows[position][LogErrosDTO.FieldNames.URL].ToString();
				dto.Codigo.Value = dtb.Rows[position][LogErrosDTO.FieldNames.Codigo].ToString();
				dto.Descricao.Value = dtb.Rows[position][LogErrosDTO.FieldNames.Descricao].ToString();
				dto.IdtUsuario.Value = dtb.Rows[position][LogErrosDTO.FieldNames.IdtUsuario].ToString();
				dto.StackTrace.Value = dtb.Rows[position][LogErrosDTO.FieldNames.StackTrace].ToString();
				
				return dto;
			}
		}
	}
	
	[Serializable()]
	public class LogErrosDTO : MVC.DTO.DTOBase
	{	
				private MVC.DTO.FieldDecimal seg_err_id_erro;
		private MVC.DTO.FieldDateTime seg_err_dt_erro;
		private MVC.DTO.FieldString seg_err_ds_url_erro;
		private MVC.DTO.FieldDecimal seg_err_cd_codigo;
		private MVC.DTO.FieldString seg_err_ds_erro;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario;
		private MVC.DTO.FieldString seg_err_ds_stack_trace;

		
		public LogErrosDTO()
		{
			InitializeComponent();
		}
		
		internal void InitializeComponent()
		{
					this.seg_err_id_erro= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		this.seg_err_dt_erro= new MVC.DTO.FieldDateTime(FieldNames.Data,Captions.Data);
		this.seg_err_ds_url_erro= new MVC.DTO.FieldString(FieldNames.URL,Captions.URL, 2000);
		this.seg_err_cd_codigo= new MVC.DTO.FieldDecimal(FieldNames.Codigo,Captions.Codigo, DbType.Decimal);
		this.seg_err_ds_erro= new MVC.DTO.FieldString(FieldNames.Descricao,Captions.Descricao, 2000);
		this.seg_usu_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario,Captions.IdtUsuario, DbType.Decimal);
		this.seg_err_ds_stack_trace= new MVC.DTO.FieldString(FieldNames.StackTrace,Captions.StackTrace, 4000);
		
		}
 
		#region FieldNames

		public struct FieldNames
		{
				public const string Idt="SEG_ERR_ID_ERRO";
		public const string Data="SEG_ERR_DT_ERRO";
		public const string URL="SEG_ERR_DS_URL_ERRO";
		public const string Codigo="SEG_ERR_CD_CODIGO";
		public const string Descricao="SEG_ERR_DS_ERRO";
		public const string IdtUsuario="SEG_USU_ID_USUARIO";
		public const string StackTrace="SEG_ERR_DS_STACK_TRACE";
		
		}		

		#endregion

		#region Captions
		public struct Captions
		{
				public const string Idt="IDT";
		public const string Data="DATA";
		public const string URL="URL";
		public const string Codigo="CODIGO";
		public const string Descricao="DESCRICAO";
		public const string IdtUsuario="IDTUSUARIO";
		public const string StackTrace="STACKTRACE";
		
		}		

		#endregion
		
		#region Atributos Publicos

		
			 
		public MVC.DTO.FieldDecimal Idt
		{
			get { return seg_err_id_erro; }
			set { seg_err_id_erro = value; }
		}
		
			 
		public MVC.DTO.FieldDateTime Data
		{
			get { return seg_err_dt_erro; }
			set { seg_err_dt_erro = value; }
		}
		
			 
		public MVC.DTO.FieldString URL
		{
			get { return seg_err_ds_url_erro; }
			set { seg_err_ds_url_erro = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal Codigo
		{
			get { return seg_err_cd_codigo; }
			set { seg_err_cd_codigo = value; }
		}
		
			 
		public MVC.DTO.FieldString Descricao
		{
			get { return seg_err_ds_erro; }
			set { seg_err_ds_erro = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtUsuario
		{
			get { return seg_usu_id_usuario; }
			set { seg_usu_id_usuario = value; }
		}
		
			 
		public MVC.DTO.FieldString StackTrace
		{
			get { return seg_err_ds_stack_trace; }
			set { seg_err_ds_stack_trace = value; }
		}
					
			
		#endregion


		#region Operators

		public static explicit operator LogErrosDTO(DataRow row)
		{
			LogErrosDTO  dto = new LogErrosDTO();
			dto.Idt.Value = row[FieldNames.Idt].ToString();
			dto.Data.Value = row[FieldNames.Data].ToString();
			dto.URL.Value = row[FieldNames.URL].ToString();
			dto.Codigo.Value = row[FieldNames.Codigo].ToString();
			dto.Descricao.Value = row[FieldNames.Descricao].ToString();
			dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();
			dto.StackTrace.Value = row[FieldNames.StackTrace].ToString();
			
			
			return dto;
		}

		public static explicit operator LogErrosDTO(XmlDocument xml)
		{
			LogErrosDTO dto = new LogErrosDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Data) != null) dto.Data.Value = xml.FirstChild.SelectSingleNode(FieldNames.Data).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.URL) != null) dto.URL.Value = xml.FirstChild.SelectSingleNode(FieldNames.URL).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Codigo) != null) dto.Codigo.Value = xml.FirstChild.SelectSingleNode(FieldNames.Codigo).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Descricao) != null) dto.Descricao.Value = xml.FirstChild.SelectSingleNode(FieldNames.Descricao).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.StackTrace) != null) dto.StackTrace.Value = xml.FirstChild.SelectSingleNode(FieldNames.StackTrace).InnerText;			
			
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeRoot = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, FieldNames.Data, null);
			XmlNode nodeURL = xml.CreateNode(XmlNodeType.Element, FieldNames.URL, null);
			XmlNode nodeCodigo = xml.CreateNode(XmlNodeType.Element, FieldNames.Codigo, null);
			XmlNode nodeDescricao = xml.CreateNode(XmlNodeType.Element, FieldNames.Descricao, null);
			XmlNode nodeIdtUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);
			XmlNode nodeStackTrace = xml.CreateNode(XmlNodeType.Element, FieldNames.StackTrace, null);
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			if (!this.Data.Value.IsNull) nodeData.InnerText = this.Data.Value;
			if (!this.URL.Value.IsNull) nodeURL.InnerText = this.URL.Value;
			if (!this.Codigo.Value.IsNull) nodeCodigo.InnerText = this.Codigo.Value;
			if (!this.Descricao.Value.IsNull) nodeDescricao.InnerText = this.Descricao.Value;
			if (!this.IdtUsuario.Value.IsNull) nodeIdtUsuario.InnerText = this.IdtUsuario.Value;
			if (!this.StackTrace.Value.IsNull) nodeStackTrace.InnerText = this.StackTrace.Value;

            nodeRoot.AppendChild(nodeIdt);
            nodeRoot.AppendChild(nodeData);
            nodeRoot.AppendChild(nodeURL);
            nodeRoot.AppendChild(nodeCodigo);
            nodeRoot.AppendChild(nodeDescricao);
            nodeRoot.AppendChild(nodeIdtUsuario);
            nodeRoot.AppendChild(nodeStackTrace);

            xml.AppendChild(nodeRoot);
			return xml;
		}

		public static explicit operator DataRow(LogErrosDTO dto)
		{
			LogErrosDataTable dtb = new LogErrosDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.Idt] = dto.Idt.Value;
			dtr[FieldNames.Data] = dto.Data.Value;
			dtr[FieldNames.URL] = dto.URL.Value;
			dtr[FieldNames.Codigo] = dto.Codigo.Value;
			dtr[FieldNames.Descricao] = dto.Descricao.Value;
			dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;
			dtr[FieldNames.StackTrace] = dto.StackTrace.Value;
			
			return dtr;
		}

		public static explicit operator XmlDocument(LogErrosDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}

