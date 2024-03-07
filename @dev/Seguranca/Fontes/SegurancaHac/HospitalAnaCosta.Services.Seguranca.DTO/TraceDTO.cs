
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
	/// Classe Entidade TraceDataTable
	/// </summary>
	[Serializable()]
	public class TraceDataTable : DataTable
	{
		
		public TraceDataTable()
			: base()
		{
		
			this.TableName = "Trace";

					this.Columns.Add(TraceDTO.FieldNames.Idt, typeof(Decimal));
		this.Columns.Add(TraceDTO.FieldNames.Data, typeof(DateTime));
		this.Columns.Add(TraceDTO.FieldNames.IP, typeof(String));
		this.Columns.Add(TraceDTO.FieldNames.URL, typeof(String));
		this.Columns.Add(TraceDTO.FieldNames.IdtUsuario, typeof(Decimal));


			

			DataColumn[] primaryKey = { this.Columns[TraceDTO.FieldNames.Idt] };

			this.PrimaryKey = primaryKey;
		}
		
		protected TraceDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
		: base(serializationInfo, streamingContext){}


		public TraceDTO TypedRow(int index)
		{
			return (TraceDTO)this.Rows[index];
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

		public void Add(TraceDTO dto)
		{
			DataRow dtr = this.NewRow();


					if (!dto.Idt.Value.IsNull) dtr[TraceDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		if (!dto.Data.Value.IsNull) dtr[TraceDTO.FieldNames.Data] = (DateTime)dto.Data.Value;
		if (!dto.IP.Value.IsNull) dtr[TraceDTO.FieldNames.IP] = (String)dto.IP.Value;
		if (!dto.URL.Value.IsNull) dtr[TraceDTO.FieldNames.URL] = (String)dto.URL.Value;
		if (!dto.IdtUsuario.Value.IsNull) dtr[TraceDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;

			
			this.Rows.Add(dtr);
		}
		
		public TraceEnumerator GetEnumerator()
		{
			return new TraceEnumerator(this);
		}
	}
	
	// Inner class implements IEnumerator interface:
	public class TraceEnumerator
	{
		private int position = -1;
		private DataTable dtb;

		public TraceEnumerator(DataTable dtb)
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
		public TraceDTO Current
		{
		get
			{
				TraceDTO dto = new TraceDTO();			
				dto.Idt.Value = dtb.Rows[position][TraceDTO.FieldNames.Idt].ToString();
				dto.Data.Value = dtb.Rows[position][TraceDTO.FieldNames.Data].ToString();
				dto.IP.Value = dtb.Rows[position][TraceDTO.FieldNames.IP].ToString();
				dto.URL.Value = dtb.Rows[position][TraceDTO.FieldNames.URL].ToString();
				dto.IdtUsuario.Value = dtb.Rows[position][TraceDTO.FieldNames.IdtUsuario].ToString();
				
				return dto;
			}
		}
	}
	
	[Serializable()]
	public class TraceDTO : MVC.DTO.DTOBase
	{	
				private MVC.DTO.FieldDecimal seg_tra_id_trace;
		private MVC.DTO.FieldDateTime seg_tra_dt_trace;
		private MVC.DTO.FieldString seg_tra_nr_ip;
		private MVC.DTO.FieldString seg_tra_ds_url;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario;

		
		public TraceDTO()
		{
			InitializeComponent();
		}
		
		internal void InitializeComponent()
		{
					this.seg_tra_id_trace= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		this.seg_tra_dt_trace= new MVC.DTO.FieldDateTime(FieldNames.Data,Captions.Data);
		this.seg_tra_nr_ip= new MVC.DTO.FieldString(FieldNames.IP,Captions.IP, 15);
		this.seg_tra_ds_url= new MVC.DTO.FieldString(FieldNames.URL,Captions.URL, 2000);
		this.seg_usu_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario,Captions.IdtUsuario, DbType.Decimal);
		
		}
 
		#region FieldNames

		public struct FieldNames
		{
				public const string Idt="SEG_TRA_ID_TRACE";
		public const string Data="SEG_TRA_DT_TRACE";
		public const string IP="SEG_TRA_NR_IP";
		public const string URL="SEG_TRA_DS_URL";
		public const string IdtUsuario="SEG_USU_ID_USUARIO";
		
		}		

		#endregion

		#region Captions
		public struct Captions
		{
				public const string Idt="IDT";
		public const string Data="DATA";
		public const string IP="IP";
		public const string URL="URL";
		public const string IdtUsuario="IDTUSUARIO";
		
		}		

		#endregion
		
		#region Atributos Publicos

		
			 
		public MVC.DTO.FieldDecimal Idt
		{
			get { return seg_tra_id_trace; }
			set { seg_tra_id_trace = value; }
		}
		
			 
		public MVC.DTO.FieldDateTime Data
		{
			get { return seg_tra_dt_trace; }
			set { seg_tra_dt_trace = value; }
		}
		
			 
		public MVC.DTO.FieldString IP
		{
			get { return seg_tra_nr_ip; }
			set { seg_tra_nr_ip = value; }
		}
		
			 
		public MVC.DTO.FieldString URL
		{
			get { return seg_tra_ds_url; }
			set { seg_tra_ds_url = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtUsuario
		{
			get { return seg_usu_id_usuario; }
			set { seg_usu_id_usuario = value; }
		}
					
			
		#endregion


		#region Operators

		public static explicit operator TraceDTO(DataRow row)
		{
			TraceDTO  dto = new TraceDTO();
			dto.Idt.Value = row[FieldNames.Idt].ToString();
			dto.Data.Value = row[FieldNames.Data].ToString();
			dto.IP.Value = row[FieldNames.IP].ToString();
			dto.URL.Value = row[FieldNames.URL].ToString();
			dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();
			
			
			return dto;
		}

		public static explicit operator TraceDTO(XmlDocument xml)
		{
			TraceDTO dto = new TraceDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Data) != null) dto.Data.Value = xml.FirstChild.SelectSingleNode(FieldNames.Data).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IP) != null) dto.IP.Value = xml.FirstChild.SelectSingleNode(FieldNames.IP).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.URL) != null) dto.URL.Value = xml.FirstChild.SelectSingleNode(FieldNames.URL).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;			
			
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeRoot = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, FieldNames.Data, null);
			XmlNode nodeIP = xml.CreateNode(XmlNodeType.Element, FieldNames.IP, null);
			XmlNode nodeURL = xml.CreateNode(XmlNodeType.Element, FieldNames.URL, null);
			XmlNode nodeIdtUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			if (!this.Data.Value.IsNull) nodeData.InnerText = this.Data.Value;
			if (!this.IP.Value.IsNull) nodeIP.InnerText = this.IP.Value;
			if (!this.URL.Value.IsNull) nodeURL.InnerText = this.URL.Value;
			if (!this.IdtUsuario.Value.IsNull) nodeIdtUsuario.InnerText = this.IdtUsuario.Value;

            nodeRoot.AppendChild(nodeIdt);
            nodeRoot.AppendChild(nodeData);
            nodeRoot.AppendChild(nodeIP);
            nodeRoot.AppendChild(nodeURL);
            nodeRoot.AppendChild(nodeIdtUsuario);

            xml.AppendChild(nodeRoot);
			return xml;
		}

		public static explicit operator DataRow(TraceDTO dto)
		{
			TraceDataTable dtb = new TraceDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.Idt] = dto.Idt.Value;
			dtr[FieldNames.Data] = dto.Data.Value;
			dtr[FieldNames.IP] = dto.IP.Value;
			dtr[FieldNames.URL] = dto.URL.Value;
			dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;
			
			return dtr;
		}

		public static explicit operator XmlDocument(TraceDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}

