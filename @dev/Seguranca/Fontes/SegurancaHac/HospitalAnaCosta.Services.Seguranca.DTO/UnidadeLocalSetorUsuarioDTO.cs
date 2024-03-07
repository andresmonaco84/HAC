
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
	/// Classe Entidade UnidadeLocalSetorUsuarioDataTable
	/// </summary>
	[Serializable()]
	public class UnidadeLocalSetorUsuarioDataTable : DataTable
	{
		
		public UnidadeLocalSetorUsuarioDataTable()
			: base()
		{
		
			this.TableName = "UnidadeLocalSetorUsuario";

					this.Columns.Add(UnidadeLocalSetorUsuarioDTO.FieldNames.Idt, typeof(Decimal));
		this.Columns.Add(UnidadeLocalSetorUsuarioDTO.FieldNames.IdtUsuario, typeof(Decimal));
		this.Columns.Add(UnidadeLocalSetorUsuarioDTO.FieldNames.IdtUnidade, typeof(Decimal));
		this.Columns.Add(UnidadeLocalSetorUsuarioDTO.FieldNames.IdtSetor, typeof(Decimal));
		this.Columns.Add(UnidadeLocalSetorUsuarioDTO.FieldNames.IdtLocalAtendimento, typeof(Decimal));
		this.Columns.Add(UnidadeLocalSetorUsuarioDTO.FieldNames.FlagStatus, typeof(String));
		this.Columns.Add(UnidadeLocalSetorUsuarioDTO.FieldNames.DataUltimaAtualizacao, typeof(DateTime));
		this.Columns.Add(UnidadeLocalSetorUsuarioDTO.FieldNames.IdtUsuarioAtualizadoPor, typeof(Decimal));


			

			DataColumn[] primaryKey = { this.Columns[UnidadeLocalSetorUsuarioDTO.FieldNames.Idt] };

			this.PrimaryKey = primaryKey;
		}
		
		protected UnidadeLocalSetorUsuarioDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
		: base(serializationInfo, streamingContext){}


		public UnidadeLocalSetorUsuarioDTO TypedRow(int index)
		{
			return (UnidadeLocalSetorUsuarioDTO)this.Rows[index];
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

		public void Add(UnidadeLocalSetorUsuarioDTO dto)
		{
			DataRow dtr = this.NewRow();


					if (!dto.Idt.Value.IsNull) dtr[UnidadeLocalSetorUsuarioDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		if (!dto.IdtUsuario.Value.IsNull) dtr[UnidadeLocalSetorUsuarioDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;
		if (!dto.IdtUnidade.Value.IsNull) dtr[UnidadeLocalSetorUsuarioDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;
		if (!dto.IdtSetor.Value.IsNull) dtr[UnidadeLocalSetorUsuarioDTO.FieldNames.IdtSetor] = (Decimal)dto.IdtSetor.Value;
		if (!dto.IdtLocalAtendimento.Value.IsNull) dtr[UnidadeLocalSetorUsuarioDTO.FieldNames.IdtLocalAtendimento] = (Decimal)dto.IdtLocalAtendimento.Value;
		if (!dto.FlagStatus.Value.IsNull) dtr[UnidadeLocalSetorUsuarioDTO.FieldNames.FlagStatus] = (String)dto.FlagStatus.Value;
		if (!dto.DataUltimaAtualizacao.Value.IsNull) dtr[UnidadeLocalSetorUsuarioDTO.FieldNames.DataUltimaAtualizacao] = (DateTime)dto.DataUltimaAtualizacao.Value;
		if (!dto.IdtUsuarioAtualizadoPor.Value.IsNull) dtr[UnidadeLocalSetorUsuarioDTO.FieldNames.IdtUsuarioAtualizadoPor] = (Decimal)dto.IdtUsuarioAtualizadoPor.Value;

			
			this.Rows.Add(dtr);
		}
		
		public UnidadeLocalSetorUsuarioEnumerator GetEnumerator()
		{
			return new UnidadeLocalSetorUsuarioEnumerator(this);
		}
	}
	
	// Inner class implements IEnumerator interface:
	public class UnidadeLocalSetorUsuarioEnumerator
	{
		private int position = -1;
		private DataTable dtb;

		public UnidadeLocalSetorUsuarioEnumerator(DataTable dtb)
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
		public UnidadeLocalSetorUsuarioDTO Current
		{
		get
			{
				UnidadeLocalSetorUsuarioDTO dto = new UnidadeLocalSetorUsuarioDTO();			
				dto.Idt.Value = dtb.Rows[position][UnidadeLocalSetorUsuarioDTO.FieldNames.Idt].ToString();
				dto.IdtUsuario.Value = dtb.Rows[position][UnidadeLocalSetorUsuarioDTO.FieldNames.IdtUsuario].ToString();
				dto.IdtUnidade.Value = dtb.Rows[position][UnidadeLocalSetorUsuarioDTO.FieldNames.IdtUnidade].ToString();
				dto.IdtSetor.Value = dtb.Rows[position][UnidadeLocalSetorUsuarioDTO.FieldNames.IdtSetor].ToString();
				dto.IdtLocalAtendimento.Value = dtb.Rows[position][UnidadeLocalSetorUsuarioDTO.FieldNames.IdtLocalAtendimento].ToString();
				dto.FlagStatus.Value = dtb.Rows[position][UnidadeLocalSetorUsuarioDTO.FieldNames.FlagStatus].ToString();
				dto.DataUltimaAtualizacao.Value = dtb.Rows[position][UnidadeLocalSetorUsuarioDTO.FieldNames.DataUltimaAtualizacao].ToString();
				dto.IdtUsuarioAtualizadoPor.Value = dtb.Rows[position][UnidadeLocalSetorUsuarioDTO.FieldNames.IdtUsuarioAtualizadoPor].ToString();
				
				return dto;
			}
		}
	}
	
	[Serializable()]
	public class UnidadeLocalSetorUsuarioDTO : MVC.DTO.DTOBase
	{	
				private MVC.DTO.FieldDecimal ass_uls_id;
		private MVC.DTO.FieldDecimal seg_usu_id_usuario;
		private MVC.DTO.FieldDecimal cad_uni_id_unidade;
		private MVC.DTO.FieldDecimal cad_set_id;
		private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
		private MVC.DTO.FieldString ass_uls_fl_status;
		private MVC.DTO.FieldDateTime ass_dt_ultima_atualizacao;
		private MVC.DTO.FieldDecimal ass_uls_id_usuario;

		
		public UnidadeLocalSetorUsuarioDTO()
		{
			InitializeComponent();
		}
		
		internal void InitializeComponent()
		{
					this.ass_uls_id= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		this.seg_usu_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario,Captions.IdtUsuario, DbType.Decimal);
		this.cad_uni_id_unidade= new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade,Captions.IdtUnidade, DbType.Decimal);
		this.cad_set_id= new MVC.DTO.FieldDecimal(FieldNames.IdtSetor,Captions.IdtSetor, DbType.Decimal);
		this.cad_lat_id_local_atendimento= new MVC.DTO.FieldDecimal(FieldNames.IdtLocalAtendimento,Captions.IdtLocalAtendimento, DbType.Decimal);
		this.ass_uls_fl_status= new MVC.DTO.FieldString(FieldNames.FlagStatus,Captions.FlagStatus, 1);
		this.ass_dt_ultima_atualizacao= new MVC.DTO.FieldDateTime(FieldNames.DataUltimaAtualizacao,Captions.DataUltimaAtualizacao);
		this.ass_uls_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuarioAtualizadoPor,Captions.IdtUsuarioAtualizadoPor, DbType.Decimal);
		
		}
 
		#region FieldNames

		public struct FieldNames
		{
				public const string Idt="ASS_ULS_ID";
		public const string IdtUsuario="SEG_USU_ID_USUARIO";
		public const string IdtUnidade="CAD_UNI_ID_UNIDADE";
		public const string IdtSetor="CAD_SET_ID";
		public const string IdtLocalAtendimento="CAD_LAT_ID_LOCAL_ATENDIMENTO";
		public const string FlagStatus="ASS_ULS_FL_STATUS";
		public const string DataUltimaAtualizacao="ASS_DT_ULTIMA_ATUALIZACAO";
		public const string IdtUsuarioAtualizadoPor="ASS_ULS_ID_USUARIO";
		
		}		

		#endregion

		#region Captions
		public struct Captions
		{
				public const string Idt="IDT";
		public const string IdtUsuario="IDTUSUARIO";
		public const string IdtUnidade="IDTUNIDADE";
		public const string IdtSetor="IDTSETOR";
		public const string IdtLocalAtendimento="IDTLOCALATENDIMENTO";
		public const string FlagStatus="FLAGSTATUS";
		public const string DataUltimaAtualizacao="DATAULTIMAATUALIZACAO";
		public const string IdtUsuarioAtualizadoPor="IDTUSUARIOATUALIZADOPOR";
		
		}		

		#endregion
		
		#region Atributos Publicos

		
			 
		public MVC.DTO.FieldDecimal Idt
		{
			get { return ass_uls_id; }
			set { ass_uls_id = value; }
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
		
			 
		public MVC.DTO.FieldDecimal IdtSetor
		{
			get { return cad_set_id; }
			set { cad_set_id = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtLocalAtendimento
		{
			get { return cad_lat_id_local_atendimento; }
			set { cad_lat_id_local_atendimento = value; }
		}
		
			 
		public MVC.DTO.FieldString FlagStatus
		{
			get { return ass_uls_fl_status; }
			set { ass_uls_fl_status = value; }
		}
		
			 
		public MVC.DTO.FieldDateTime DataUltimaAtualizacao
		{
			get { return ass_dt_ultima_atualizacao; }
			set { ass_dt_ultima_atualizacao = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtUsuarioAtualizadoPor
		{
			get { return ass_uls_id_usuario; }
			set { ass_uls_id_usuario = value; }
		}
					
			
		#endregion


		#region Operators

		public static explicit operator UnidadeLocalSetorUsuarioDTO(DataRow row)
		{
			UnidadeLocalSetorUsuarioDTO  dto = new UnidadeLocalSetorUsuarioDTO();
			dto.Idt.Value = row[FieldNames.Idt].ToString();
			dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();
			dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();
			dto.IdtSetor.Value = row[FieldNames.IdtSetor].ToString();
			dto.IdtLocalAtendimento.Value = row[FieldNames.IdtLocalAtendimento].ToString();
			dto.FlagStatus.Value = row[FieldNames.FlagStatus].ToString();
			dto.DataUltimaAtualizacao.Value = row[FieldNames.DataUltimaAtualizacao].ToString();
			dto.IdtUsuarioAtualizadoPor.Value = row[FieldNames.IdtUsuarioAtualizadoPor].ToString();
			
			
			return dto;
		}

		public static explicit operator UnidadeLocalSetorUsuarioDTO(XmlDocument xml)
		{
			UnidadeLocalSetorUsuarioDTO dto = new UnidadeLocalSetorUsuarioDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor) != null) dto.IdtSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalAtendimento) != null) dto.IdtLocalAtendimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalAtendimento).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.FlagStatus) != null) dto.FlagStatus.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlagStatus).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DataUltimaAtualizacao) != null) dto.DataUltimaAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataUltimaAtualizacao).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioAtualizadoPor) != null) dto.IdtUsuarioAtualizadoPor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioAtualizadoPor).InnerText;			
			
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			XmlNode nodeIdtUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);
			XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);
			XmlNode nodeIdtSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetor, null);
			XmlNode nodeIdtLocalAtendimento = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocalAtendimento, null);
			XmlNode nodeFlagStatus = xml.CreateNode(XmlNodeType.Element, FieldNames.FlagStatus, null);
			XmlNode nodeDataUltimaAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DataUltimaAtualizacao, null);
			XmlNode nodeIdtUsuarioAtualizadoPor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuarioAtualizadoPor, null);
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			if (!this.IdtUsuario.Value.IsNull) nodeIdtUsuario.InnerText = this.IdtUsuario.Value;
			if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;
			if (!this.IdtSetor.Value.IsNull) nodeIdtSetor.InnerText = this.IdtSetor.Value;
			if (!this.IdtLocalAtendimento.Value.IsNull) nodeIdtLocalAtendimento.InnerText = this.IdtLocalAtendimento.Value;
			if (!this.FlagStatus.Value.IsNull) nodeFlagStatus.InnerText = this.FlagStatus.Value;
			if (!this.DataUltimaAtualizacao.Value.IsNull) nodeDataUltimaAtualizacao.InnerText = this.DataUltimaAtualizacao.Value;
			if (!this.IdtUsuarioAtualizadoPor.Value.IsNull) nodeIdtUsuarioAtualizadoPor.InnerText = this.IdtUsuarioAtualizadoPor.Value;
			
			nodeData.AppendChild(nodeIdt);
			nodeData.AppendChild(nodeIdtUsuario);
			nodeData.AppendChild(nodeIdtUnidade);
			nodeData.AppendChild(nodeIdtSetor);
			nodeData.AppendChild(nodeIdtLocalAtendimento);
			nodeData.AppendChild(nodeFlagStatus);
			nodeData.AppendChild(nodeDataUltimaAtualizacao);
			nodeData.AppendChild(nodeIdtUsuarioAtualizadoPor);
						
			xml.AppendChild(nodeData);
			return xml;
		}

		public static explicit operator DataRow(UnidadeLocalSetorUsuarioDTO dto)
		{
			UnidadeLocalSetorUsuarioDataTable dtb = new UnidadeLocalSetorUsuarioDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.Idt] = dto.Idt.Value;
			dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;
			dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;
			dtr[FieldNames.IdtSetor] = dto.IdtSetor.Value;
			dtr[FieldNames.IdtLocalAtendimento] = dto.IdtLocalAtendimento.Value;
			dtr[FieldNames.FlagStatus] = dto.FlagStatus.Value;
			dtr[FieldNames.DataUltimaAtualizacao] = dto.DataUltimaAtualizacao.Value;
			dtr[FieldNames.IdtUsuarioAtualizadoPor] = dto.IdtUsuarioAtualizadoPor.Value;
			
			return dtr;
		}

		public static explicit operator XmlDocument(UnidadeLocalSetorUsuarioDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}

