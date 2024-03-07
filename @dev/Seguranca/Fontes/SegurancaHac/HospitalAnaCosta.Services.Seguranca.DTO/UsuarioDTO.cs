
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
	/// Classe Entidade UsuarioDataTable
	/// </summary>
	[Serializable()]
	public class UsuarioDataTable : DataTable
	{
		
		public UsuarioDataTable()
			: base()
		{
		
			this.TableName = "Usuario";

					this.Columns.Add(UsuarioDTO.FieldNames.Idt, typeof(Decimal));
		this.Columns.Add(UsuarioDTO.FieldNames.Nome, typeof(String));
		this.Columns.Add(UsuarioDTO.FieldNames.Login, typeof(String));
		this.Columns.Add(UsuarioDTO.FieldNames.Email, typeof(String));
		this.Columns.Add(UsuarioDTO.FieldNames.Senha, typeof(String));
		this.Columns.Add(UsuarioDTO.FieldNames.Matricula, typeof(Decimal));
		this.Columns.Add(UsuarioDTO.FieldNames.Telefone, typeof(String));
		this.Columns.Add(UsuarioDTO.FieldNames.Ramal, typeof(String));
		this.Columns.Add(UsuarioDTO.FieldNames.FlagTrocarSenha, typeof(String));
		this.Columns.Add(UsuarioDTO.FieldNames.FlagSenhaNaoExpira, typeof(String));
		this.Columns.Add(UsuarioDTO.FieldNames.DataExpiracaoSenha, typeof(DateTime));
		this.Columns.Add(UsuarioDTO.FieldNames.FlagStatus, typeof(String));
		this.Columns.Add(UsuarioDTO.FieldNames.FlagResponsavelPerfil, typeof(String));
		this.Columns.Add(UsuarioDTO.FieldNames.QuantidadeLoginInvalido, typeof(Decimal));
		this.Columns.Add(UsuarioDTO.FieldNames.DataUltimaAtualizacao, typeof(DateTime));
		this.Columns.Add(UsuarioDTO.FieldNames.DataLoginInvalido, typeof(DateTime));
		this.Columns.Add(UsuarioDTO.FieldNames.IdtUsuarioAtualizacao, typeof(Decimal));
		this.Columns.Add(UsuarioDTO.FieldNames.Tipo, typeof(String));
		this.Columns.Add(UsuarioDTO.FieldNames.Cargo, typeof(String));
		this.Columns.Add(UsuarioDTO.FieldNames.IdtUsuarioSuperior, typeof(Decimal));


			

			DataColumn[] primaryKey = { this.Columns[UsuarioDTO.FieldNames.Idt] };

			this.PrimaryKey = primaryKey;
		}
		
		protected UsuarioDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
		: base(serializationInfo, streamingContext){}


		public UsuarioDTO TypedRow(int index)
		{
			return (UsuarioDTO)this.Rows[index];
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

		public void Add(UsuarioDTO dto)
		{
			DataRow dtr = this.NewRow();


					if (!dto.Idt.Value.IsNull) dtr[UsuarioDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		if (!dto.Nome.Value.IsNull) dtr[UsuarioDTO.FieldNames.Nome] = (String)dto.Nome.Value;
		if (!dto.Login.Value.IsNull) dtr[UsuarioDTO.FieldNames.Login] = (String)dto.Login.Value;
		if (!dto.Email.Value.IsNull) dtr[UsuarioDTO.FieldNames.Email] = (String)dto.Email.Value;
		if (!dto.Senha.Value.IsNull) dtr[UsuarioDTO.FieldNames.Senha] = (String)dto.Senha.Value;
		if (!dto.Matricula.Value.IsNull) dtr[UsuarioDTO.FieldNames.Matricula] = (Decimal)dto.Matricula.Value;
		if (!dto.Telefone.Value.IsNull) dtr[UsuarioDTO.FieldNames.Telefone] = (String)dto.Telefone.Value;
		if (!dto.Ramal.Value.IsNull) dtr[UsuarioDTO.FieldNames.Ramal] = (String)dto.Ramal.Value;
		if (!dto.FlagTrocarSenha.Value.IsNull) dtr[UsuarioDTO.FieldNames.FlagTrocarSenha] = (String)dto.FlagTrocarSenha.Value;
		if (!dto.FlagSenhaNaoExpira.Value.IsNull) dtr[UsuarioDTO.FieldNames.FlagSenhaNaoExpira] = (String)dto.FlagSenhaNaoExpira.Value;
		if (!dto.DataExpiracaoSenha.Value.IsNull) dtr[UsuarioDTO.FieldNames.DataExpiracaoSenha] = (DateTime)dto.DataExpiracaoSenha.Value;
		if (!dto.FlagStatus.Value.IsNull) dtr[UsuarioDTO.FieldNames.FlagStatus] = (String)dto.FlagStatus.Value;
		if (!dto.FlagResponsavelPerfil.Value.IsNull) dtr[UsuarioDTO.FieldNames.FlagResponsavelPerfil] = (String)dto.FlagResponsavelPerfil.Value;
		if (!dto.QuantidadeLoginInvalido.Value.IsNull) dtr[UsuarioDTO.FieldNames.QuantidadeLoginInvalido] = (Decimal)dto.QuantidadeLoginInvalido.Value;
		if (!dto.DataUltimaAtualizacao.Value.IsNull) dtr[UsuarioDTO.FieldNames.DataUltimaAtualizacao] = (DateTime)dto.DataUltimaAtualizacao.Value;
		if (!dto.DataLoginInvalido.Value.IsNull) dtr[UsuarioDTO.FieldNames.DataLoginInvalido] = (DateTime)dto.DataLoginInvalido.Value;
		if (!dto.IdtUsuarioAtualizacao.Value.IsNull) dtr[UsuarioDTO.FieldNames.IdtUsuarioAtualizacao] = (Decimal)dto.IdtUsuarioAtualizacao.Value;
		if (!dto.Tipo.Value.IsNull) dtr[UsuarioDTO.FieldNames.Tipo] = (String)dto.Tipo.Value;
		if (!dto.Cargo.Value.IsNull) dtr[UsuarioDTO.FieldNames.Cargo] = (String)dto.Cargo.Value;
		if (!dto.IdtUsuarioSuperior.Value.IsNull) dtr[UsuarioDTO.FieldNames.IdtUsuarioSuperior] = (Decimal)dto.IdtUsuarioSuperior.Value;

			
			this.Rows.Add(dtr);
		}
		
		public UsuarioEnumerator GetEnumerator()
		{
			return new UsuarioEnumerator(this);
		}
	}
	
	// Inner class implements IEnumerator interface:
	public class UsuarioEnumerator
	{
		private int position = -1;
		private DataTable dtb;

		public UsuarioEnumerator(DataTable dtb)
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
		public UsuarioDTO Current
		{
		get
			{
				UsuarioDTO dto = new UsuarioDTO();			
				dto.Idt.Value = dtb.Rows[position][UsuarioDTO.FieldNames.Idt].ToString();
				dto.Nome.Value = dtb.Rows[position][UsuarioDTO.FieldNames.Nome].ToString();
				dto.Login.Value = dtb.Rows[position][UsuarioDTO.FieldNames.Login].ToString();
				dto.Email.Value = dtb.Rows[position][UsuarioDTO.FieldNames.Email].ToString();
				dto.Senha.Value = dtb.Rows[position][UsuarioDTO.FieldNames.Senha].ToString();
				dto.Matricula.Value = dtb.Rows[position][UsuarioDTO.FieldNames.Matricula].ToString();
				dto.Telefone.Value = dtb.Rows[position][UsuarioDTO.FieldNames.Telefone].ToString();
				dto.Ramal.Value = dtb.Rows[position][UsuarioDTO.FieldNames.Ramal].ToString();
				dto.FlagTrocarSenha.Value = dtb.Rows[position][UsuarioDTO.FieldNames.FlagTrocarSenha].ToString();
				dto.FlagSenhaNaoExpira.Value = dtb.Rows[position][UsuarioDTO.FieldNames.FlagSenhaNaoExpira].ToString();
				dto.DataExpiracaoSenha.Value = dtb.Rows[position][UsuarioDTO.FieldNames.DataExpiracaoSenha].ToString();
				dto.FlagStatus.Value = dtb.Rows[position][UsuarioDTO.FieldNames.FlagStatus].ToString();
				dto.FlagResponsavelPerfil.Value = dtb.Rows[position][UsuarioDTO.FieldNames.FlagResponsavelPerfil].ToString();
				dto.QuantidadeLoginInvalido.Value = dtb.Rows[position][UsuarioDTO.FieldNames.QuantidadeLoginInvalido].ToString();
				dto.DataUltimaAtualizacao.Value = dtb.Rows[position][UsuarioDTO.FieldNames.DataUltimaAtualizacao].ToString();
				dto.DataLoginInvalido.Value = dtb.Rows[position][UsuarioDTO.FieldNames.DataLoginInvalido].ToString();
				dto.IdtUsuarioAtualizacao.Value = dtb.Rows[position][UsuarioDTO.FieldNames.IdtUsuarioAtualizacao].ToString();
				dto.Tipo.Value = dtb.Rows[position][UsuarioDTO.FieldNames.Tipo].ToString();
				dto.Cargo.Value = dtb.Rows[position][UsuarioDTO.FieldNames.Cargo].ToString();
				dto.IdtUsuarioSuperior.Value = dtb.Rows[position][UsuarioDTO.FieldNames.IdtUsuarioSuperior].ToString();
				
				return dto;
			}
		}
	}
	
	[Serializable()]
	public class UsuarioDTO : MVC.DTO.DTOBase
	{	
				private MVC.DTO.FieldDecimal seg_usu_id_usuario;
		private MVC.DTO.FieldString seg_usu_ds_nome;
		private MVC.DTO.FieldString seg_usu_ds_login;
		private MVC.DTO.FieldString seg_usu_ds_email;
		private MVC.DTO.FieldString seg_usu_cd_password;
		private MVC.DTO.FieldDecimal seg_usu_cd_matricula;
		private MVC.DTO.FieldString seg_usu_ds_telefone;
		private MVC.DTO.FieldString seg_usu_ds_ramal;
		private MVC.DTO.FieldString seg_usu_fl_trocar_senha_ok;
		private MVC.DTO.FieldString seg_usu_fl_senha_nao_expira_ok;
		private MVC.DTO.FieldDateTime seg_usu_dt_expiracao;
		private MVC.DTO.FieldString seg_usu_fl_status;
		private MVC.DTO.FieldString seg_usu_fl_respons_perfil_ok;
		private MVC.DTO.FieldDecimal seg_usu_qt_login_invalido;
		private MVC.DTO.FieldDateTime seg_usu_dt_ultima_atualizacao;
		private MVC.DTO.FieldDateTime seg_usu_dt_login_invalido;
		private MVC.DTO.FieldDecimal seg_usu_id_atualizado_por;
		private MVC.DTO.FieldString seg_usu_tp_inter_exter;
		private MVC.DTO.FieldString seg_usu_ds_cargo;
		private MVC.DTO.FieldDecimal seg_usu_id_usu_resp_superior;

		
		public UsuarioDTO()
		{
			InitializeComponent();
		}
		
		internal void InitializeComponent()
		{
					this.seg_usu_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		this.seg_usu_ds_nome= new MVC.DTO.FieldString(FieldNames.Nome,Captions.Nome, 50);
		this.seg_usu_ds_login= new MVC.DTO.FieldString(FieldNames.Login,Captions.Login, 20);
		this.seg_usu_ds_email= new MVC.DTO.FieldString(FieldNames.Email,Captions.Email, 100);
		this.seg_usu_cd_password= new MVC.DTO.FieldString(FieldNames.Senha,Captions.Senha, 32);
		this.seg_usu_cd_matricula= new MVC.DTO.FieldDecimal(FieldNames.Matricula,Captions.Matricula, DbType.Decimal);
		this.seg_usu_ds_telefone= new MVC.DTO.FieldString(FieldNames.Telefone,Captions.Telefone, 20);
		this.seg_usu_ds_ramal= new MVC.DTO.FieldString(FieldNames.Ramal,Captions.Ramal, 20);
		this.seg_usu_fl_trocar_senha_ok= new MVC.DTO.FieldString(FieldNames.FlagTrocarSenha,Captions.FlagTrocarSenha, 1);
		this.seg_usu_fl_senha_nao_expira_ok= new MVC.DTO.FieldString(FieldNames.FlagSenhaNaoExpira,Captions.FlagSenhaNaoExpira, 1);
		this.seg_usu_dt_expiracao= new MVC.DTO.FieldDateTime(FieldNames.DataExpiracaoSenha,Captions.DataExpiracaoSenha);
		this.seg_usu_fl_status= new MVC.DTO.FieldString(FieldNames.FlagStatus,Captions.FlagStatus, 1);
		this.seg_usu_fl_respons_perfil_ok= new MVC.DTO.FieldString(FieldNames.FlagResponsavelPerfil,Captions.FlagResponsavelPerfil, 1);
		this.seg_usu_qt_login_invalido= new MVC.DTO.FieldDecimal(FieldNames.QuantidadeLoginInvalido,Captions.QuantidadeLoginInvalido, DbType.Decimal);
		this.seg_usu_dt_ultima_atualizacao= new MVC.DTO.FieldDateTime(FieldNames.DataUltimaAtualizacao,Captions.DataUltimaAtualizacao);
		this.seg_usu_dt_login_invalido= new MVC.DTO.FieldDateTime(FieldNames.DataLoginInvalido,Captions.DataLoginInvalido);
		this.seg_usu_id_atualizado_por= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuarioAtualizacao,Captions.IdtUsuarioAtualizacao, DbType.Decimal);
		this.seg_usu_tp_inter_exter= new MVC.DTO.FieldString(FieldNames.Tipo,Captions.Tipo, 1);
		this.seg_usu_ds_cargo= new MVC.DTO.FieldString(FieldNames.Cargo,Captions.Cargo, 60);
		this.seg_usu_id_usu_resp_superior= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuarioSuperior,Captions.IdtUsuarioSuperior, DbType.Decimal);
		
		}
 
		#region FieldNames

		public struct FieldNames
		{
				public const string Idt="SEG_USU_ID_USUARIO";
		public const string Nome="SEG_USU_DS_NOME";
		public const string Login="SEG_USU_DS_LOGIN";
		public const string Email="SEG_USU_DS_EMAIL";
		public const string Senha="SEG_USU_CD_PASSWORD";
		public const string Matricula="SEG_USU_CD_MATRICULA";
		public const string Telefone="SEG_USU_DS_TELEFONE";
		public const string Ramal="SEG_USU_DS_RAMAL";
		public const string FlagTrocarSenha="SEG_USU_FL_TROCAR_SENHA_OK";
		public const string FlagSenhaNaoExpira="SEG_USU_FL_SENHA_NAO_EXPIRA_OK";
		public const string DataExpiracaoSenha="SEG_USU_DT_EXPIRACAO";
		public const string FlagStatus="SEG_USU_FL_STATUS";
		public const string FlagResponsavelPerfil="SEG_USU_FL_RESPONS_PERFIL_OK";
		public const string QuantidadeLoginInvalido="SEG_USU_QT_LOGIN_INVALIDO";
		public const string DataUltimaAtualizacao="SEG_USU_DT_ULTIMA_ATUALIZACAO";
		public const string DataLoginInvalido="SEG_USU_DT_LOGIN_INVALIDO";
		public const string IdtUsuarioAtualizacao="SEG_USU_ID_ATUALIZADO_POR";
		public const string Tipo="SEG_USU_TP_INTER_EXTER";
		public const string Cargo="SEG_USU_DS_CARGO";
		public const string IdtUsuarioSuperior="SEG_USU_ID_USU_RESP_SUPERIOR";
		
		}		

		#endregion

		#region Captions
		public struct Captions
		{
				public const string Idt="IDT";
		public const string Nome="NOME";
		public const string Login="LOGIN";
		public const string Email="EMAIL";
		public const string Senha="SENHA";
		public const string Matricula="MATRICULA";
		public const string Telefone="TELEFONE";
		public const string Ramal="RAMAL";
		public const string FlagTrocarSenha="FLAGTROCARSENHA";
		public const string FlagSenhaNaoExpira="FLAGSENHANAOEXPIRA";
		public const string DataExpiracaoSenha="DATAEXPIRACAOSENHA";
		public const string FlagStatus="FLAGSTATUS";
		public const string FlagResponsavelPerfil="FLAGRESPONSAVELPERFIL";
		public const string QuantidadeLoginInvalido="QUANTIDADELOGININVALIDO";
		public const string DataUltimaAtualizacao="DATAULTIMAATUALIZACAO";
		public const string DataLoginInvalido="DATALOGININVALIDO";
		public const string IdtUsuarioAtualizacao="IDTUSUARIOATUALIZACAO";
		public const string Tipo="TIPO";
		public const string Cargo="CARGO";
		public const string IdtUsuarioSuperior="IDTUSUARIOSUPERIOR";
		
		}		

		#endregion
		
		#region Atributos Publicos

		
			 
		public MVC.DTO.FieldDecimal Idt
		{
			get { return seg_usu_id_usuario; }
			set { seg_usu_id_usuario = value; }
		}
		
			 
		public MVC.DTO.FieldString Nome
		{
			get { return seg_usu_ds_nome; }
			set { seg_usu_ds_nome = value; }
		}
		
			 
		public MVC.DTO.FieldString Login
		{
			get { return seg_usu_ds_login; }
			set { seg_usu_ds_login = value; }
		}
		
			 
		public MVC.DTO.FieldString Email
		{
			get { return seg_usu_ds_email; }
			set { seg_usu_ds_email = value; }
		}
		
			 
		public MVC.DTO.FieldString Senha
		{
			get { return seg_usu_cd_password; }
			set { seg_usu_cd_password = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal Matricula
		{
			get { return seg_usu_cd_matricula; }
			set { seg_usu_cd_matricula = value; }
		}
		
			 
		public MVC.DTO.FieldString Telefone
		{
			get { return seg_usu_ds_telefone; }
			set { seg_usu_ds_telefone = value; }
		}
		
			 
		public MVC.DTO.FieldString Ramal
		{
			get { return seg_usu_ds_ramal; }
			set { seg_usu_ds_ramal = value; }
		}
		
			 
		public MVC.DTO.FieldString FlagTrocarSenha
		{
			get { return seg_usu_fl_trocar_senha_ok; }
			set { seg_usu_fl_trocar_senha_ok = value; }
		}
		
			 
		public MVC.DTO.FieldString FlagSenhaNaoExpira
		{
			get { return seg_usu_fl_senha_nao_expira_ok; }
			set { seg_usu_fl_senha_nao_expira_ok = value; }
		}
		
			 
		public MVC.DTO.FieldDateTime DataExpiracaoSenha
		{
			get { return seg_usu_dt_expiracao; }
			set { seg_usu_dt_expiracao = value; }
		}
		
			 
		public MVC.DTO.FieldString FlagStatus
		{
			get { return seg_usu_fl_status; }
			set { seg_usu_fl_status = value; }
		}
		
			 
		public MVC.DTO.FieldString FlagResponsavelPerfil
		{
			get { return seg_usu_fl_respons_perfil_ok; }
			set { seg_usu_fl_respons_perfil_ok = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal QuantidadeLoginInvalido
		{
			get { return seg_usu_qt_login_invalido; }
			set { seg_usu_qt_login_invalido = value; }
		}
		
			 
		public MVC.DTO.FieldDateTime DataUltimaAtualizacao
		{
			get { return seg_usu_dt_ultima_atualizacao; }
			set { seg_usu_dt_ultima_atualizacao = value; }
		}
		
			 
		public MVC.DTO.FieldDateTime DataLoginInvalido
		{
			get { return seg_usu_dt_login_invalido; }
			set { seg_usu_dt_login_invalido = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtUsuarioAtualizacao
		{
			get { return seg_usu_id_atualizado_por; }
			set { seg_usu_id_atualizado_por = value; }
		}
		
			 
		public MVC.DTO.FieldString Tipo
		{
			get { return seg_usu_tp_inter_exter; }
			set { seg_usu_tp_inter_exter = value; }
		}
		
			 
		public MVC.DTO.FieldString Cargo
		{
			get { return seg_usu_ds_cargo; }
			set { seg_usu_ds_cargo = value; }
		}
		
			 
		public MVC.DTO.FieldDecimal IdtUsuarioSuperior
		{
			get { return seg_usu_id_usu_resp_superior; }
			set { seg_usu_id_usu_resp_superior = value; }
		}
					
			
		#endregion


		#region Operators

		public static explicit operator UsuarioDTO(DataRow row)
		{
			UsuarioDTO  dto = new UsuarioDTO();
			dto.Idt.Value = row[FieldNames.Idt].ToString();
			dto.Nome.Value = row[FieldNames.Nome].ToString();
			dto.Login.Value = row[FieldNames.Login].ToString();
			dto.Email.Value = row[FieldNames.Email].ToString();
			dto.Senha.Value = row[FieldNames.Senha].ToString();
			dto.Matricula.Value = row[FieldNames.Matricula].ToString();
			dto.Telefone.Value = row[FieldNames.Telefone].ToString();
			dto.Ramal.Value = row[FieldNames.Ramal].ToString();
			dto.FlagTrocarSenha.Value = row[FieldNames.FlagTrocarSenha].ToString();
			dto.FlagSenhaNaoExpira.Value = row[FieldNames.FlagSenhaNaoExpira].ToString();
			dto.DataExpiracaoSenha.Value = row[FieldNames.DataExpiracaoSenha].ToString();
			dto.FlagStatus.Value = row[FieldNames.FlagStatus].ToString();
			dto.FlagResponsavelPerfil.Value = row[FieldNames.FlagResponsavelPerfil].ToString();
			dto.QuantidadeLoginInvalido.Value = row[FieldNames.QuantidadeLoginInvalido].ToString();
			dto.DataUltimaAtualizacao.Value = row[FieldNames.DataUltimaAtualizacao].ToString();
			dto.DataLoginInvalido.Value = row[FieldNames.DataLoginInvalido].ToString();
			dto.IdtUsuarioAtualizacao.Value = row[FieldNames.IdtUsuarioAtualizacao].ToString();
			dto.Tipo.Value = row[FieldNames.Tipo].ToString();
			dto.Cargo.Value = row[FieldNames.Cargo].ToString();
			dto.IdtUsuarioSuperior.Value = row[FieldNames.IdtUsuarioSuperior].ToString();
			
			
			return dto;
		}

		public static explicit operator UsuarioDTO(XmlDocument xml)
		{
			UsuarioDTO dto = new UsuarioDTO();
			if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Nome) != null) dto.Nome.Value = xml.FirstChild.SelectSingleNode(FieldNames.Nome).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Login) != null) dto.Login.Value = xml.FirstChild.SelectSingleNode(FieldNames.Login).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Email) != null) dto.Email.Value = xml.FirstChild.SelectSingleNode(FieldNames.Email).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Senha) != null) dto.Senha.Value = xml.FirstChild.SelectSingleNode(FieldNames.Senha).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Matricula) != null) dto.Matricula.Value = xml.FirstChild.SelectSingleNode(FieldNames.Matricula).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Telefone) != null) dto.Telefone.Value = xml.FirstChild.SelectSingleNode(FieldNames.Telefone).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Ramal) != null) dto.Ramal.Value = xml.FirstChild.SelectSingleNode(FieldNames.Ramal).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.FlagTrocarSenha) != null) dto.FlagTrocarSenha.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlagTrocarSenha).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.FlagSenhaNaoExpira) != null) dto.FlagSenhaNaoExpira.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlagSenhaNaoExpira).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DataExpiracaoSenha) != null) dto.DataExpiracaoSenha.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataExpiracaoSenha).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.FlagStatus) != null) dto.FlagStatus.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlagStatus).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.FlagResponsavelPerfil) != null) dto.FlagResponsavelPerfil.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlagResponsavelPerfil).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.QuantidadeLoginInvalido) != null) dto.QuantidadeLoginInvalido.Value = xml.FirstChild.SelectSingleNode(FieldNames.QuantidadeLoginInvalido).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DataUltimaAtualizacao) != null) dto.DataUltimaAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataUltimaAtualizacao).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.DataLoginInvalido) != null) dto.DataLoginInvalido.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataLoginInvalido).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioAtualizacao) != null) dto.IdtUsuarioAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioAtualizacao).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Tipo) != null) dto.Tipo.Value = xml.FirstChild.SelectSingleNode(FieldNames.Tipo).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Cargo) != null) dto.Cargo.Value = xml.FirstChild.SelectSingleNode(FieldNames.Cargo).InnerText;			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioSuperior) != null) dto.IdtUsuarioSuperior.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioSuperior).InnerText;			
			
			return dto;
		}

		public override XmlDocument GetXML()
		{
			XmlDocument xml = new XmlDocument();
			XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			XmlNode nodeNome = xml.CreateNode(XmlNodeType.Element, FieldNames.Nome, null);
			XmlNode nodeLogin = xml.CreateNode(XmlNodeType.Element, FieldNames.Login, null);
			XmlNode nodeEmail = xml.CreateNode(XmlNodeType.Element, FieldNames.Email, null);
			XmlNode nodeSenha = xml.CreateNode(XmlNodeType.Element, FieldNames.Senha, null);
			XmlNode nodeMatricula = xml.CreateNode(XmlNodeType.Element, FieldNames.Matricula, null);
			XmlNode nodeTelefone = xml.CreateNode(XmlNodeType.Element, FieldNames.Telefone, null);
			XmlNode nodeRamal = xml.CreateNode(XmlNodeType.Element, FieldNames.Ramal, null);
			XmlNode nodeFlagTrocarSenha = xml.CreateNode(XmlNodeType.Element, FieldNames.FlagTrocarSenha, null);
			XmlNode nodeFlagSenhaNaoExpira = xml.CreateNode(XmlNodeType.Element, FieldNames.FlagSenhaNaoExpira, null);
			XmlNode nodeDataExpiracaoSenha = xml.CreateNode(XmlNodeType.Element, FieldNames.DataExpiracaoSenha, null);
			XmlNode nodeFlagStatus = xml.CreateNode(XmlNodeType.Element, FieldNames.FlagStatus, null);
			XmlNode nodeFlagResponsavelPerfil = xml.CreateNode(XmlNodeType.Element, FieldNames.FlagResponsavelPerfil, null);
			XmlNode nodeQuantidadeLoginInvalido = xml.CreateNode(XmlNodeType.Element, FieldNames.QuantidadeLoginInvalido, null);
			XmlNode nodeDataUltimaAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DataUltimaAtualizacao, null);
			XmlNode nodeDataLoginInvalido = xml.CreateNode(XmlNodeType.Element, FieldNames.DataLoginInvalido, null);
			XmlNode nodeIdtUsuarioAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuarioAtualizacao, null);
			XmlNode nodeTipo = xml.CreateNode(XmlNodeType.Element, FieldNames.Tipo, null);
			XmlNode nodeCargo = xml.CreateNode(XmlNodeType.Element, FieldNames.Cargo, null);
			XmlNode nodeIdtUsuarioSuperior = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuarioSuperior, null);
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			if (!this.Nome.Value.IsNull) nodeNome.InnerText = this.Nome.Value;
			if (!this.Login.Value.IsNull) nodeLogin.InnerText = this.Login.Value;
			if (!this.Email.Value.IsNull) nodeEmail.InnerText = this.Email.Value;
			if (!this.Senha.Value.IsNull) nodeSenha.InnerText = this.Senha.Value;
			if (!this.Matricula.Value.IsNull) nodeMatricula.InnerText = this.Matricula.Value;
			if (!this.Telefone.Value.IsNull) nodeTelefone.InnerText = this.Telefone.Value;
			if (!this.Ramal.Value.IsNull) nodeRamal.InnerText = this.Ramal.Value;
			if (!this.FlagTrocarSenha.Value.IsNull) nodeFlagTrocarSenha.InnerText = this.FlagTrocarSenha.Value;
			if (!this.FlagSenhaNaoExpira.Value.IsNull) nodeFlagSenhaNaoExpira.InnerText = this.FlagSenhaNaoExpira.Value;
			if (!this.DataExpiracaoSenha.Value.IsNull) nodeDataExpiracaoSenha.InnerText = this.DataExpiracaoSenha.Value;
			if (!this.FlagStatus.Value.IsNull) nodeFlagStatus.InnerText = this.FlagStatus.Value;
			if (!this.FlagResponsavelPerfil.Value.IsNull) nodeFlagResponsavelPerfil.InnerText = this.FlagResponsavelPerfil.Value;
			if (!this.QuantidadeLoginInvalido.Value.IsNull) nodeQuantidadeLoginInvalido.InnerText = this.QuantidadeLoginInvalido.Value;
			if (!this.DataUltimaAtualizacao.Value.IsNull) nodeDataUltimaAtualizacao.InnerText = this.DataUltimaAtualizacao.Value;
			if (!this.DataLoginInvalido.Value.IsNull) nodeDataLoginInvalido.InnerText = this.DataLoginInvalido.Value;
			if (!this.IdtUsuarioAtualizacao.Value.IsNull) nodeIdtUsuarioAtualizacao.InnerText = this.IdtUsuarioAtualizacao.Value;
			if (!this.Tipo.Value.IsNull) nodeTipo.InnerText = this.Tipo.Value;
			if (!this.Cargo.Value.IsNull) nodeCargo.InnerText = this.Cargo.Value;
			if (!this.IdtUsuarioSuperior.Value.IsNull) nodeIdtUsuarioSuperior.InnerText = this.IdtUsuarioSuperior.Value;
			
			nodeData.AppendChild(nodeIdt);
			nodeData.AppendChild(nodeNome);
			nodeData.AppendChild(nodeLogin);
			nodeData.AppendChild(nodeEmail);
			nodeData.AppendChild(nodeSenha);
			nodeData.AppendChild(nodeMatricula);
			nodeData.AppendChild(nodeTelefone);
			nodeData.AppendChild(nodeRamal);
			nodeData.AppendChild(nodeFlagTrocarSenha);
			nodeData.AppendChild(nodeFlagSenhaNaoExpira);
			nodeData.AppendChild(nodeDataExpiracaoSenha);
			nodeData.AppendChild(nodeFlagStatus);
			nodeData.AppendChild(nodeFlagResponsavelPerfil);
			nodeData.AppendChild(nodeQuantidadeLoginInvalido);
			nodeData.AppendChild(nodeDataUltimaAtualizacao);
			nodeData.AppendChild(nodeDataLoginInvalido);
			nodeData.AppendChild(nodeIdtUsuarioAtualizacao);
			nodeData.AppendChild(nodeTipo);
			nodeData.AppendChild(nodeCargo);
			nodeData.AppendChild(nodeIdtUsuarioSuperior);
						
			xml.AppendChild(nodeData);
			return xml;
		}

		public static explicit operator DataRow(UsuarioDTO dto)
		{
			UsuarioDataTable dtb = new UsuarioDataTable();
			DataRow dtr = dtb.NewRow();
			dtr[FieldNames.Idt] = dto.Idt.Value;
			dtr[FieldNames.Nome] = dto.Nome.Value;
			dtr[FieldNames.Login] = dto.Login.Value;
			dtr[FieldNames.Email] = dto.Email.Value;
			dtr[FieldNames.Senha] = dto.Senha.Value;
			dtr[FieldNames.Matricula] = dto.Matricula.Value;
			dtr[FieldNames.Telefone] = dto.Telefone.Value;
			dtr[FieldNames.Ramal] = dto.Ramal.Value;
			dtr[FieldNames.FlagTrocarSenha] = dto.FlagTrocarSenha.Value;
			dtr[FieldNames.FlagSenhaNaoExpira] = dto.FlagSenhaNaoExpira.Value;
			dtr[FieldNames.DataExpiracaoSenha] = dto.DataExpiracaoSenha.Value;
			dtr[FieldNames.FlagStatus] = dto.FlagStatus.Value;
			dtr[FieldNames.FlagResponsavelPerfil] = dto.FlagResponsavelPerfil.Value;
			dtr[FieldNames.QuantidadeLoginInvalido] = dto.QuantidadeLoginInvalido.Value;
			dtr[FieldNames.DataUltimaAtualizacao] = dto.DataUltimaAtualizacao.Value;
			dtr[FieldNames.DataLoginInvalido] = dto.DataLoginInvalido.Value;
			dtr[FieldNames.IdtUsuarioAtualizacao] = dto.IdtUsuarioAtualizacao.Value;
			dtr[FieldNames.Tipo] = dto.Tipo.Value;
			dtr[FieldNames.Cargo] = dto.Cargo.Value;
			dtr[FieldNames.IdtUsuarioSuperior] = dto.IdtUsuarioSuperior.Value;
			
			return dtr;
		}

		public static explicit operator XmlDocument(UsuarioDTO dto)
		{
			return dto.GetXML();
		}

		#endregion
	}
}

