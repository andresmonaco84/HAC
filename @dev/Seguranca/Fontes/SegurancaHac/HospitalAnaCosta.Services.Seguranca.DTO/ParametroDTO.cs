
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
	/// Classe Entidade ParametroDataTable
	/// </summary>
	[Serializable()]
	public class ParametroDataTable : DataTable
	{
		
		public ParametroDataTable()
			: base()
		{
		
			this.TableName = "Parametro";

					this.Columns.Add(ParametroDTO.FieldNames.Codigo, typeof(Decimal));
		this.Columns.Add(ParametroDTO.FieldNames.Nome, typeof(String));
		this.Columns.Add(ParametroDTO.FieldNames.Valor, typeof(String));


			

			DataColumn[] primaryKey = { this.Columns[ParametroDTO.FieldNames.Codigo] };

			this.PrimaryKey = primaryKey;
		}
		
		protected ParametroDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
		: base(serializationInfo, streamingContext){}


		public ParametroDTO TypedRow(int index)
		{
			return (ParametroDTO)this.Rows[index];
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

		public void Add(ParametroDTO dto)
		{
			DataRow dtr = this.NewRow();


					if (!dto.Codigo.Value.IsNull) dtr[ParametroDTO.FieldNames.Codigo] = (Decimal)dto.Codigo.Value;
		if (!dto.Nome.Value.IsNull) dtr[ParametroDTO.FieldNames.Nome] = (String)dto.Nome.Value;
		if (!dto.Valor.Value.IsNull) dtr[ParametroDTO.FieldNames.Valor] = (String)dto.Valor.Value;

			
			this.Rows.Add(dtr);
		}
		
		public ParametroEnumerator GetEnumerator()
		{
			return new ParametroEnumerator(this);
		}
	}
	
	// Inner class implements IEnumerator interface:
	public class ParametroEnumerator
	{
		private int position = -1;
		private DataTable dtb;

		public ParametroEnumerator(DataTable dtb)
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
		public ParametroDTO Current
		{
		get
			{
				ParametroDTO dto = new ParametroDTO();			
				dto.Codigo.Value = dtb.Rows[position][ParametroDTO.FieldNames.Codigo].ToString();
				dto.Nome.Value = dtb.Rows[position][ParametroDTO.FieldNames.Nome].ToString();
				dto.Valor.Value = dtb.Rows[position][ParametroDTO.FieldNames.Valor].ToString();
				
				return dto;
			}
		}
	}
	
	[Serializable()]
	public class ParametroDTO : MVC.DTO.DTOBase
	{	
				private MVC.DTO.FieldDecimal seg_par_cd;
		private MVC.DTO.FieldString seg_par_nm_parametro;
		private MVC.DTO.FieldString seg_par_vl_parametro;

		
		public ParametroDTO()
		{
			InitializeComponent();
		}
		
		internal void InitializeComponent()
		{
					this.seg_par_cd= new MVC.DTO.FieldDecimal(FieldNames.Codigo,Captions.Codigo, DbType.Decimal);
		this.seg_par_nm_parametro= new MVC.DTO.FieldString(FieldNames.Nome,Captions.Nome, 200);
		this.seg_par_vl_parametro= new MVC.DTO.FieldString(FieldNames.Valor,Captions.Valor, 100);
		
		}
 
		#region FieldNames

		public struct FieldNames
		{
				public const string Codigo="SEG_PAR_CD";
		public const string Nome="SEG_PAR_NM_PARAMETRO";
		public const string Valor="SEG_PAR_VL_PARAMETRO";
		
		}		

		#endregion

		#region Captions
		public struct Captions
		{
				public const string Codigo="CODIGO";
		public const string Nome="NOME";
		public const string Valor="VALOR";
		
		}		

		#endregion
		
		#region Atributos Publicos

		
			 
		public MVC.DTO.FieldDecimal Codigo
		{
			get { return seg_par_cd; }
			set { seg_par_cd = value; }
		}
		
			 
		public MVC.DTO.FieldString Nome
		{
			get { return seg_par_nm_parametro; }
			set { seg_par_nm_parametro = value; }
		}
		
			 
		public MVC.DTO.FieldString Valor
		{
			get { return seg_par_vl_parametro; }
			set { seg_par_vl_parametro = value; }
		}
					
			
		#endregion


		#region Operators

		public static explicit operator ParametroDTO(DataRow row)
		{
			ParametroDTO  dto = new ParametroDTO();
			dto.Codigo.Value = row[FieldNames.Codigo].ToString();
			dto.Nome.Value = row[FieldNames.Nome].ToString();
			dto.Valor.Value = row[FieldNames.Valor].ToString();
			
			
			return dto;
		}

		public static explicit operator ParametroDTO(XmlDocument xml)
		{
			ParametroDTO dto = new ParametroDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.Codigo) != null) dto.Codigo.Value = xml.FirstChild.SelectSingleNode(FieldNames.Codigo).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Nome) != null) dto.Nome.Value = xml.FirstChild.SelectSingleNode(FieldNames.Nome).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Valor) != null) dto.Valor.Value = xml.FirstChild.SelectSingleNode(FieldNames.Valor).InnerText;			
			
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeCodigo = xml.CreateNode(XmlNodeType.Element, FieldNames.Codigo, null);
			XmlNode nodeNome = xml.CreateNode(XmlNodeType.Element, FieldNames.Nome, null);
			XmlNode nodeValor = xml.CreateNode(XmlNodeType.Element, FieldNames.Valor, null);
			
			if (!this.Codigo.Value.IsNull) nodeCodigo.InnerText = this.Codigo.Value;
			if (!this.Nome.Value.IsNull) nodeNome.InnerText = this.Nome.Value;
			if (!this.Valor.Value.IsNull) nodeValor.InnerText = this.Valor.Value;
			
			nodeData.AppendChild(nodeCodigo);
			nodeData.AppendChild(nodeNome);
			nodeData.AppendChild(nodeValor);
						
			xml.AppendChild(nodeData);
			return xml;
		}

		public static explicit operator DataRow(ParametroDTO dto)
		{
			ParametroDataTable dtb = new ParametroDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.Codigo] = dto.Codigo.Value;
			dtr[FieldNames.Nome] = dto.Nome.Value;
			dtr[FieldNames.Valor] = dto.Valor.Value;
			
			return dtr;
		}

		public static explicit operator XmlDocument(ParametroDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}

