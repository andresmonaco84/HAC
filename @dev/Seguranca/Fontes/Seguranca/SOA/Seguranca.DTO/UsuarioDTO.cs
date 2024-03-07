
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using MVC = HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.Seguranca.DTO
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
            this.TableName = "DADOS";

			this.Columns.Add(UsuarioDTO.FieldNames.Idt, typeof(Decimal));
		    this.Columns.Add(UsuarioDTO.FieldNames.NmUsuario, typeof(String));
		    this.Columns.Add(UsuarioDTO.FieldNames.Login, typeof(String));
		    this.Columns.Add(UsuarioDTO.FieldNames.Email, typeof(String));
		    this.Columns.Add(UsuarioDTO.FieldNames.Senha, typeof(String));
		    this.Columns.Add(UsuarioDTO.FieldNames.Matricula, typeof(Decimal));
		    this.Columns.Add(UsuarioDTO.FieldNames.Telefone, typeof(String));
		    this.Columns.Add(UsuarioDTO.FieldNames.Ramal, typeof(String));
		    this.Columns.Add(UsuarioDTO.FieldNames.FlTrocarSenha, typeof(String));
		    this.Columns.Add(UsuarioDTO.FieldNames.FlSenhaNaoExpira, typeof(String));
		    this.Columns.Add(UsuarioDTO.FieldNames.DtExpiraSenha, typeof(DateTime));
		    this.Columns.Add(UsuarioDTO.FieldNames.Status, typeof(String));
		    this.Columns.Add(UsuarioDTO.FieldNames.FlResponsavelPerfilOk, typeof(String));
		    this.Columns.Add(UsuarioDTO.FieldNames.QtdLoginInvalido, typeof(Decimal));
		    this.Columns.Add(UsuarioDTO.FieldNames.DtAtualizacao, typeof(DateTime));
		    this.Columns.Add(UsuarioDTO.FieldNames.DtLoginInvalido, typeof(DateTime));
		    this.Columns.Add(UsuarioDTO.FieldNames.IdtUsuAtualizado, typeof(Decimal));
		    this.Columns.Add(UsuarioDTO.FieldNames.TpInterExter, typeof(String));
		    this.Columns.Add(UsuarioDTO.FieldNames.DsCargo, typeof(String));
		    this.Columns.Add(UsuarioDTO.FieldNames.IdtUsuarioSuperior, typeof(Decimal));
            this.Columns.Add(UsuarioDTO.FieldNames.CPF, typeof(Decimal));
            this.Columns.Add(UsuarioDTO.FieldNames.DataNascimento, typeof(DateTime));

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
		    if (!dto.NmUsuario.Value.IsNull) dtr[UsuarioDTO.FieldNames.NmUsuario] = (String)dto.NmUsuario.Value;
		    if (!dto.Login.Value.IsNull) dtr[UsuarioDTO.FieldNames.Login] = (String)dto.Login.Value;
		    if (!dto.Email.Value.IsNull) dtr[UsuarioDTO.FieldNames.Email] = (String)dto.Email.Value;
		    if (!dto.Senha.Value.IsNull) dtr[UsuarioDTO.FieldNames.Senha] = (String)dto.Senha.Value;
		    if (!dto.Matricula.Value.IsNull) dtr[UsuarioDTO.FieldNames.Matricula] = (Decimal)dto.Matricula.Value;
		    if (!dto.Telefone.Value.IsNull) dtr[UsuarioDTO.FieldNames.Telefone] = (String)dto.Telefone.Value;
		    if (!dto.Ramal.Value.IsNull) dtr[UsuarioDTO.FieldNames.Ramal] = (String)dto.Ramal.Value;
		    if (!dto.FlTrocarSenha.Value.IsNull) dtr[UsuarioDTO.FieldNames.FlTrocarSenha] = (String)dto.FlTrocarSenha.Value;
		    if (!dto.FlSenhaNaoExpira.Value.IsNull) dtr[UsuarioDTO.FieldNames.FlSenhaNaoExpira] = (String)dto.FlSenhaNaoExpira.Value;
		    if (!dto.DtExpiraSenha.Value.IsNull) dtr[UsuarioDTO.FieldNames.DtExpiraSenha] = (DateTime)dto.DtExpiraSenha.Value;
		    if (!dto.Status.Value.IsNull) dtr[UsuarioDTO.FieldNames.Status] = (String)dto.Status.Value;
		    if (!dto.FlResponsavelPerfilOk.Value.IsNull) dtr[UsuarioDTO.FieldNames.FlResponsavelPerfilOk] = (String)dto.FlResponsavelPerfilOk.Value;
		    if (!dto.QtdLoginInvalido.Value.IsNull) dtr[UsuarioDTO.FieldNames.QtdLoginInvalido] = (Decimal)dto.QtdLoginInvalido.Value;
		    if (!dto.DtAtualizacao.Value.IsNull) dtr[UsuarioDTO.FieldNames.DtAtualizacao] = (DateTime)dto.DtAtualizacao.Value;
		    if (!dto.DtLoginInvalido.Value.IsNull) dtr[UsuarioDTO.FieldNames.DtLoginInvalido] = (DateTime)dto.DtLoginInvalido.Value;
		    if (!dto.IdtUsuAtualizado.Value.IsNull) dtr[UsuarioDTO.FieldNames.IdtUsuAtualizado] = (Decimal)dto.IdtUsuAtualizado.Value;
		    if (!dto.TpInterExter.Value.IsNull) dtr[UsuarioDTO.FieldNames.TpInterExter] = (String)dto.TpInterExter.Value;
		    if (!dto.DsCargo.Value.IsNull) dtr[UsuarioDTO.FieldNames.DsCargo] = (String)dto.DsCargo.Value;
		    if (!dto.IdtUsuarioSuperior.Value.IsNull) dtr[UsuarioDTO.FieldNames.IdtUsuarioSuperior] = (Decimal)dto.IdtUsuarioSuperior.Value;
            if (!dto.CPF.Value.IsNull) dtr[UsuarioDTO.FieldNames.CPF] = (Decimal)dto.CPF.Value;
            if (!dto.DataNascimento.Value.IsNull) dtr[UsuarioDTO.FieldNames.DataNascimento] = (DateTime)dto.DataNascimento.Value;
			
            this.Rows.Add(dtr);
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
        private MVC.DTO.FieldDecimal seg_usu_nr_cpf;
        private MVC.DTO.FieldDateTime seg_usu_dt_nascimento;

        public UsuarioDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
			this.seg_usu_id_usuario= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		    this.seg_usu_ds_nome= new MVC.DTO.FieldString(FieldNames.NmUsuario,Captions.NmUsuario, 50);
		    this.seg_usu_ds_login= new MVC.DTO.FieldString(FieldNames.Login,Captions.Login, 20);
		    this.seg_usu_ds_email= new MVC.DTO.FieldString(FieldNames.Email,Captions.Email, 100);
		    this.seg_usu_cd_password= new MVC.DTO.FieldString(FieldNames.Senha,Captions.Senha, 32);
		    this.seg_usu_cd_matricula= new MVC.DTO.FieldDecimal(FieldNames.Matricula,Captions.Matricula, DbType.Decimal);
		    this.seg_usu_ds_telefone= new MVC.DTO.FieldString(FieldNames.Telefone,Captions.Telefone, 20);
		    this.seg_usu_ds_ramal= new MVC.DTO.FieldString(FieldNames.Ramal,Captions.Ramal, 20);
		    this.seg_usu_fl_trocar_senha_ok= new MVC.DTO.FieldString(FieldNames.FlTrocarSenha,Captions.FlTrocarSenha, 1);
		    this.seg_usu_fl_senha_nao_expira_ok= new MVC.DTO.FieldString(FieldNames.FlSenhaNaoExpira,Captions.FlSenhaNaoExpira, 1);
		    this.seg_usu_dt_expiracao= new MVC.DTO.FieldDateTime(FieldNames.DtExpiraSenha,Captions.DtExpiraSenha);
		    this.seg_usu_fl_status= new MVC.DTO.FieldString(FieldNames.Status,Captions.Status, 1);
		    this.seg_usu_fl_respons_perfil_ok= new MVC.DTO.FieldString(FieldNames.FlResponsavelPerfilOk,Captions.FlResponsavelPerfilOk, 1);
		    this.seg_usu_qt_login_invalido= new MVC.DTO.FieldDecimal(FieldNames.QtdLoginInvalido,Captions.QtdLoginInvalido, DbType.Decimal);
		    this.seg_usu_dt_ultima_atualizacao= new MVC.DTO.FieldDateTime(FieldNames.DtAtualizacao,Captions.DtAtualizacao);
		    this.seg_usu_dt_login_invalido= new MVC.DTO.FieldDateTime(FieldNames.DtLoginInvalido,Captions.DtLoginInvalido);
		    this.seg_usu_id_atualizado_por= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuAtualizado,Captions.IdtUsuAtualizado, DbType.Decimal);
		    this.seg_usu_tp_inter_exter= new MVC.DTO.FieldString(FieldNames.TpInterExter,Captions.TpInterExter, 1);
		    this.seg_usu_ds_cargo= new MVC.DTO.FieldString(FieldNames.DsCargo,Captions.DsCargo, 60);
		    this.seg_usu_id_usu_resp_superior= new MVC.DTO.FieldDecimal(FieldNames.IdtUsuarioSuperior,Captions.IdtUsuarioSuperior, DbType.Decimal);
            this.seg_usu_nr_cpf = new MVC.DTO.FieldDecimal(FieldNames.CPF, Captions.CPF, DbType.Decimal);
            this.seg_usu_dt_nascimento = new MVC.DTO.FieldDateTime(FieldNames.DataNascimento, Captions.DataNascimento);
        }
 
        #region FieldNames

        public struct FieldNames
        {
				public const string Idt="SEG_USU_ID_USUARIO";
		public const string NmUsuario="SEG_USU_DS_NOME";
		public const string Login="SEG_USU_DS_LOGIN";
		public const string Email="SEG_USU_DS_EMAIL";
		public const string Senha="SEG_USU_CD_PASSWORD";
		public const string Matricula="SEG_USU_CD_MATRICULA";
		public const string Telefone="SEG_USU_DS_TELEFONE";
		public const string Ramal="SEG_USU_DS_RAMAL";
		public const string FlTrocarSenha="SEG_USU_FL_TROCAR_SENHA_OK";
		public const string FlSenhaNaoExpira="SEG_USU_FL_SENHA_NAO_EXPIRA_OK";
		public const string DtExpiraSenha="SEG_USU_DT_EXPIRACAO";
		public const string Status="SEG_USU_FL_STATUS";
		public const string FlResponsavelPerfilOk="SEG_USU_FL_RESPONS_PERFIL_OK";
		public const string QtdLoginInvalido="SEG_USU_QT_LOGIN_INVALIDO";
		public const string DtAtualizacao="SEG_USU_DT_ULTIMA_ATUALIZACAO";
		public const string DtLoginInvalido="SEG_USU_DT_LOGIN_INVALIDO";
		public const string IdtUsuAtualizado="SEG_USU_ID_ATUALIZADO_POR";
		public const string TpInterExter="SEG_USU_TP_INTER_EXTER";
		public const string DsCargo="SEG_USU_DS_CARGO";
		public const string IdtUsuarioSuperior="SEG_USU_ID_USU_RESP_SUPERIOR";
        public const string CPF = "SEG_USU_NR_CPF";
        public const string DataNascimento = "SEG_USU_DT_NASCIMENTO";
        }		

        #endregion

        #region Captions
        public struct Captions
        {
				public const string Idt="IDT";
		public const string NmUsuario="NMUSUARIO";
		public const string Login="LOGIN";
		public const string Email="EMAIL";
		public const string Senha="SENHA";
		public const string Matricula="MATRICULA";
		public const string Telefone="TELEFONE";
		public const string Ramal="RAMAL";
		public const string FlTrocarSenha="FLTROCARSENHA";
		public const string FlSenhaNaoExpira="FLSENHANAOEXPIRA";
		public const string DtExpiraSenha="DTEXPIRASENHA";
		public const string Status="STATUS";
		public const string FlResponsavelPerfilOk="FLRESPONSAVELPERFILOK";
		public const string QtdLoginInvalido="QTDLOGININVALIDO";
		public const string DtAtualizacao="DTATUALIZACAO";
		public const string DtLoginInvalido="DTLOGININVALIDO";
		public const string IdtUsuAtualizado="IDTUSUATUALIZADO";
		public const string TpInterExter="TPINTEREXTER";
		public const string DsCargo="DSCARGO";
		public const string IdtUsuarioSuperior="IDTUSUARIOSUPERIOR";
        public const string CPF = "NRCPF";
        public const string DataNascimento = "DTNASCIMENTO";
        }		

        #endregion
		
        #region Atributos Publicos

		
		public MVC.DTO.FieldDecimal Idt
		{
			get { return seg_usu_id_usuario; }
			set { seg_usu_id_usuario = value; }
		}
		
		public MVC.DTO.FieldString NmUsuario
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
		
		public MVC.DTO.FieldString FlTrocarSenha
		{
			get { return seg_usu_fl_trocar_senha_ok; }
			set { seg_usu_fl_trocar_senha_ok = value; }
		}
		
		public MVC.DTO.FieldString FlSenhaNaoExpira
		{
			get { return seg_usu_fl_senha_nao_expira_ok; }
			set { seg_usu_fl_senha_nao_expira_ok = value; }
		}
		
		public MVC.DTO.FieldDateTime DtExpiraSenha
		{
			get { return seg_usu_dt_expiracao; }
			set { seg_usu_dt_expiracao = value; }
		}
		
		public MVC.DTO.FieldString Status
		{
			get { return seg_usu_fl_status; }
			set { seg_usu_fl_status = value; }
		}
		
		public MVC.DTO.FieldString FlResponsavelPerfilOk
		{
			get { return seg_usu_fl_respons_perfil_ok; }
			set { seg_usu_fl_respons_perfil_ok = value; }
		}
		
		public MVC.DTO.FieldDecimal QtdLoginInvalido
		{
			get { return seg_usu_qt_login_invalido; }
			set { seg_usu_qt_login_invalido = value; }
		}
		
		public MVC.DTO.FieldDateTime DtAtualizacao
		{
			get { return seg_usu_dt_ultima_atualizacao; }
			set { seg_usu_dt_ultima_atualizacao = value; }
		}
		
		public MVC.DTO.FieldDateTime DtLoginInvalido
		{
			get { return seg_usu_dt_login_invalido; }
			set { seg_usu_dt_login_invalido = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtUsuAtualizado
		{
			get { return seg_usu_id_atualizado_por; }
			set { seg_usu_id_atualizado_por = value; }
		}
		
		public MVC.DTO.FieldString TpInterExter
		{
			get { return seg_usu_tp_inter_exter; }
			set { seg_usu_tp_inter_exter = value; }
		}
		
		public MVC.DTO.FieldString DsCargo
		{
			get { return seg_usu_ds_cargo; }
			set { seg_usu_ds_cargo = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtUsuarioSuperior
		{
			get { return seg_usu_id_usu_resp_superior; }
			set { seg_usu_id_usu_resp_superior = value; }
		}

        public MVC.DTO.FieldDecimal CPF
        {
            get { return seg_usu_nr_cpf; }
            set { seg_usu_nr_cpf = value; }
        }

        public MVC.DTO.FieldDateTime DataNascimento
        {
            get { return seg_usu_dt_nascimento; }
            set { seg_usu_dt_nascimento = value; }
        }

		#endregion

        #region Operators

        public static explicit operator UsuarioDTO(DataRow row)
        {
            UsuarioDTO  dto = new UsuarioDTO();
			
				dto.Idt.Value = row[FieldNames.Idt].ToString();
			
				dto.NmUsuario.Value = row[FieldNames.NmUsuario].ToString();
			
				dto.Login.Value = row[FieldNames.Login].ToString();
			
				dto.Email.Value = row[FieldNames.Email].ToString();
			
				dto.Senha.Value = row[FieldNames.Senha].ToString();
			
				dto.Matricula.Value = row[FieldNames.Matricula].ToString();
			
				dto.Telefone.Value = row[FieldNames.Telefone].ToString();
			
				dto.Ramal.Value = row[FieldNames.Ramal].ToString();
			
				dto.FlTrocarSenha.Value = row[FieldNames.FlTrocarSenha].ToString();
			
				dto.FlSenhaNaoExpira.Value = row[FieldNames.FlSenhaNaoExpira].ToString();
			
				dto.DtExpiraSenha.Value = row[FieldNames.DtExpiraSenha].ToString();
			
				dto.Status.Value = row[FieldNames.Status].ToString();
			
				dto.FlResponsavelPerfilOk.Value = row[FieldNames.FlResponsavelPerfilOk].ToString();
			
				dto.QtdLoginInvalido.Value = row[FieldNames.QtdLoginInvalido].ToString();
			
				dto.DtAtualizacao.Value = row[FieldNames.DtAtualizacao].ToString();
			
				dto.DtLoginInvalido.Value = row[FieldNames.DtLoginInvalido].ToString();
			
				dto.IdtUsuAtualizado.Value = row[FieldNames.IdtUsuAtualizado].ToString();
			
				dto.TpInterExter.Value = row[FieldNames.TpInterExter].ToString();
			
				dto.DsCargo.Value = row[FieldNames.DsCargo].ToString();
			
				dto.IdtUsuarioSuperior.Value = row[FieldNames.IdtUsuarioSuperior].ToString();

                try
                {
                    dto.CPF.Value = row[FieldNames.CPF].ToString();
                }
                catch
                { //deixa passar se não tiver esta coluna                
                }

                try
                {
                    dto.DataNascimento.Value = row[FieldNames.DataNascimento].ToString();
                }
                catch
                { //deixa passar se não tiver esta coluna                
                }
			
            return dto;
        }

        public static explicit operator UsuarioDTO(XmlDocument xml)
        {
            UsuarioDTO dto = new UsuarioDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.NmUsuario) != null) dto.NmUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmUsuario).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Login) != null) dto.Login.Value = xml.FirstChild.SelectSingleNode(FieldNames.Login).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Email) != null) dto.Email.Value = xml.FirstChild.SelectSingleNode(FieldNames.Email).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Senha) != null) dto.Senha.Value = xml.FirstChild.SelectSingleNode(FieldNames.Senha).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Matricula) != null) dto.Matricula.Value = xml.FirstChild.SelectSingleNode(FieldNames.Matricula).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Telefone) != null) dto.Telefone.Value = xml.FirstChild.SelectSingleNode(FieldNames.Telefone).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Ramal) != null) dto.Ramal.Value = xml.FirstChild.SelectSingleNode(FieldNames.Ramal).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.FlTrocarSenha) != null) dto.FlTrocarSenha.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlTrocarSenha).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.FlSenhaNaoExpira) != null) dto.FlSenhaNaoExpira.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlSenhaNaoExpira).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DtExpiraSenha) != null) dto.DtExpiraSenha.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtExpiraSenha).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Status) != null) dto.Status.Value = xml.FirstChild.SelectSingleNode(FieldNames.Status).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.FlResponsavelPerfilOk) != null) dto.FlResponsavelPerfilOk.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlResponsavelPerfilOk).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.QtdLoginInvalido) != null) dto.QtdLoginInvalido.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdLoginInvalido).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DtAtualizacao) != null) dto.DtAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtAtualizacao).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DtLoginInvalido) != null) dto.DtLoginInvalido.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtLoginInvalido).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuAtualizado) != null) dto.IdtUsuAtualizado.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuAtualizado).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.TpInterExter) != null) dto.TpInterExter.Value = xml.FirstChild.SelectSingleNode(FieldNames.TpInterExter).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DsCargo) != null) dto.DsCargo.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsCargo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioSuperior) != null) dto.IdtUsuarioSuperior.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioSuperior).InnerText;			
			
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeNmUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.NmUsuario, null);
			
            XmlNode nodeLogin = xml.CreateNode(XmlNodeType.Element, FieldNames.Login, null);
			
            XmlNode nodeEmail = xml.CreateNode(XmlNodeType.Element, FieldNames.Email, null);
			
            XmlNode nodeSenha = xml.CreateNode(XmlNodeType.Element, FieldNames.Senha, null);
			
            XmlNode nodeMatricula = xml.CreateNode(XmlNodeType.Element, FieldNames.Matricula, null);
			
            XmlNode nodeTelefone = xml.CreateNode(XmlNodeType.Element, FieldNames.Telefone, null);
			
            XmlNode nodeRamal = xml.CreateNode(XmlNodeType.Element, FieldNames.Ramal, null);
			
            XmlNode nodeFlTrocarSenha = xml.CreateNode(XmlNodeType.Element, FieldNames.FlTrocarSenha, null);
			
            XmlNode nodeFlSenhaNaoExpira = xml.CreateNode(XmlNodeType.Element, FieldNames.FlSenhaNaoExpira, null);
			
            XmlNode nodeDtExpiraSenha = xml.CreateNode(XmlNodeType.Element, FieldNames.DtExpiraSenha, null);
			
            XmlNode nodeStatus = xml.CreateNode(XmlNodeType.Element, FieldNames.Status, null);
			
            XmlNode nodeFlResponsavelPerfilOk = xml.CreateNode(XmlNodeType.Element, FieldNames.FlResponsavelPerfilOk, null);
			
            XmlNode nodeQtdLoginInvalido = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdLoginInvalido, null);
			
            XmlNode nodeDtAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DtAtualizacao, null);
			
            XmlNode nodeDtLoginInvalido = xml.CreateNode(XmlNodeType.Element, FieldNames.DtLoginInvalido, null);
			
            XmlNode nodeIdtUsuAtualizado = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuAtualizado, null);
			
            XmlNode nodeTpInterExter = xml.CreateNode(XmlNodeType.Element, FieldNames.TpInterExter, null);
			
            XmlNode nodeDsCargo = xml.CreateNode(XmlNodeType.Element, FieldNames.DsCargo, null);
			
            XmlNode nodeIdtUsuarioSuperior = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuarioSuperior, null);
			
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			
			if (!this.NmUsuario.Value.IsNull) nodeNmUsuario.InnerText = this.NmUsuario.Value;
			
			if (!this.Login.Value.IsNull) nodeLogin.InnerText = this.Login.Value;
			
			if (!this.Email.Value.IsNull) nodeEmail.InnerText = this.Email.Value;
			
			if (!this.Senha.Value.IsNull) nodeSenha.InnerText = this.Senha.Value;
			
			if (!this.Matricula.Value.IsNull) nodeMatricula.InnerText = this.Matricula.Value;
			
			if (!this.Telefone.Value.IsNull) nodeTelefone.InnerText = this.Telefone.Value;
			
			if (!this.Ramal.Value.IsNull) nodeRamal.InnerText = this.Ramal.Value;
			
			if (!this.FlTrocarSenha.Value.IsNull) nodeFlTrocarSenha.InnerText = this.FlTrocarSenha.Value;
			
			if (!this.FlSenhaNaoExpira.Value.IsNull) nodeFlSenhaNaoExpira.InnerText = this.FlSenhaNaoExpira.Value;
			
			if (!this.DtExpiraSenha.Value.IsNull) nodeDtExpiraSenha.InnerText = this.DtExpiraSenha.Value;
			
			if (!this.Status.Value.IsNull) nodeStatus.InnerText = this.Status.Value;
			
			if (!this.FlResponsavelPerfilOk.Value.IsNull) nodeFlResponsavelPerfilOk.InnerText = this.FlResponsavelPerfilOk.Value;
			
			if (!this.QtdLoginInvalido.Value.IsNull) nodeQtdLoginInvalido.InnerText = this.QtdLoginInvalido.Value;
			
			if (!this.DtAtualizacao.Value.IsNull) nodeDtAtualizacao.InnerText = this.DtAtualizacao.Value;
			
			if (!this.DtLoginInvalido.Value.IsNull) nodeDtLoginInvalido.InnerText = this.DtLoginInvalido.Value;
			
			if (!this.IdtUsuAtualizado.Value.IsNull) nodeIdtUsuAtualizado.InnerText = this.IdtUsuAtualizado.Value;
			
			if (!this.TpInterExter.Value.IsNull) nodeTpInterExter.InnerText = this.TpInterExter.Value;
			
			if (!this.DsCargo.Value.IsNull) nodeDsCargo.InnerText = this.DsCargo.Value;
			
			if (!this.IdtUsuarioSuperior.Value.IsNull) nodeIdtUsuarioSuperior.InnerText = this.IdtUsuarioSuperior.Value;
			
			
            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodeNmUsuario);
			
            nodeData.AppendChild(nodeLogin);
			
            nodeData.AppendChild(nodeEmail);
			
            nodeData.AppendChild(nodeSenha);
			
            nodeData.AppendChild(nodeMatricula);
			
            nodeData.AppendChild(nodeTelefone);
			
            nodeData.AppendChild(nodeRamal);
			
            nodeData.AppendChild(nodeFlTrocarSenha);
			
            nodeData.AppendChild(nodeFlSenhaNaoExpira);
			
            nodeData.AppendChild(nodeDtExpiraSenha);
			
            nodeData.AppendChild(nodeStatus);
			
            nodeData.AppendChild(nodeFlResponsavelPerfilOk);
			
            nodeData.AppendChild(nodeQtdLoginInvalido);
			
            nodeData.AppendChild(nodeDtAtualizacao);
			
            nodeData.AppendChild(nodeDtLoginInvalido);
			
            nodeData.AppendChild(nodeIdtUsuAtualizado);
			
            nodeData.AppendChild(nodeTpInterExter);
			
            nodeData.AppendChild(nodeDsCargo);
			
            nodeData.AppendChild(nodeIdtUsuarioSuperior);
						
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(UsuarioDTO dto)
        {
            UsuarioDataTable dtb = new UsuarioDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
			
            dtr[FieldNames.NmUsuario] = dto.NmUsuario.Value;
			
            dtr[FieldNames.Login] = dto.Login.Value;
			
            dtr[FieldNames.Email] = dto.Email.Value;
			
            dtr[FieldNames.Senha] = dto.Senha.Value;
			
            dtr[FieldNames.Matricula] = dto.Matricula.Value;
			
            dtr[FieldNames.Telefone] = dto.Telefone.Value;
			
            dtr[FieldNames.Ramal] = dto.Ramal.Value;
			
            dtr[FieldNames.FlTrocarSenha] = dto.FlTrocarSenha.Value;
			
            dtr[FieldNames.FlSenhaNaoExpira] = dto.FlSenhaNaoExpira.Value;
			
            dtr[FieldNames.DtExpiraSenha] = dto.DtExpiraSenha.Value;
			
            dtr[FieldNames.Status] = dto.Status.Value;
			
            dtr[FieldNames.FlResponsavelPerfilOk] = dto.FlResponsavelPerfilOk.Value;
			
            dtr[FieldNames.QtdLoginInvalido] = dto.QtdLoginInvalido.Value;
			
            dtr[FieldNames.DtAtualizacao] = dto.DtAtualizacao.Value;
			
            dtr[FieldNames.DtLoginInvalido] = dto.DtLoginInvalido.Value;
			
            dtr[FieldNames.IdtUsuAtualizado] = dto.IdtUsuAtualizado.Value;
			
            dtr[FieldNames.TpInterExter] = dto.TpInterExter.Value;
			
            dtr[FieldNames.DsCargo] = dto.DsCargo.Value;
			
            dtr[FieldNames.IdtUsuarioSuperior] = dto.IdtUsuarioSuperior.Value;

            dtr[FieldNames.CPF] = dto.CPF.Value;

            dtr[FieldNames.DataNascimento] = dto.DataNascimento.Value;
			
            return dtr;
        }

        public static explicit operator XmlDocument(UsuarioDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}