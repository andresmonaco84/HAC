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
    [Serializable()]
    public class SegurancaDataTable : DataTable
    {
        public SegurancaDataTable()
            : base()
        {
            this.TableName = "DADOS";

            this.Columns.Add(SegurancaDTO.FieldNames.Idt, typeof(Decimal));
            this.Columns.Add(SegurancaDTO.FieldNames.Login, typeof(String));
            this.Columns.Add(SegurancaDTO.FieldNames.NmUsuario, typeof(String));
            this.Columns.Add(SegurancaDTO.FieldNames.DsUnidade, typeof(String));
            this.Columns.Add(SegurancaDTO.FieldNames.DsLocal, typeof(String));
            this.Columns.Add(SegurancaDTO.FieldNames.DsSetor, typeof(String));
            this.Columns.Add(SegurancaDTO.FieldNames.IdtUnidade, typeof(Decimal));
            this.Columns.Add(SegurancaDTO.FieldNames.IdtLocal, typeof(Decimal));
            this.Columns.Add(SegurancaDTO.FieldNames.IdtSetor, typeof(Decimal));
            this.Columns.Add(SegurancaDTO.FieldNames.IdtNivelSegurancaTeste, typeof(Decimal));
            this.Columns.Add(SegurancaDTO.FieldNames.CdSetor, typeof(String));
            this.Columns.Add(SegurancaDTO.FieldNames.FlStatus, typeof(Decimal));
            this.Columns.Add(SegurancaDTO.FieldNames.Senha, typeof(String));
            this.Columns.Add(SegurancaDTO.FieldNames.NovaSenha, typeof(String));
            this.Columns.Add(SegurancaDTO.FieldNames.Servidor, typeof(String));
            this.Columns.Add(SegurancaDTO.FieldNames.Ip, typeof(String));

            DataColumn[] primaryKey = { this.Columns[SegurancaDTO.FieldNames.Idt] };


            this.PrimaryKey = primaryKey;

            

        }
        protected SegurancaDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }


        public SegurancaDTO TypedRow(int index)
        {
            return (SegurancaDTO)this.Rows[index];
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

        public void Add(SegurancaDTO dto)
        {
            DataRow dtr = this.NewRow();


            if (!dto.Idt.Value.IsNull) dtr[SegurancaDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
            if (!dto.NmUsuario.Value.IsNull) dtr[SegurancaDTO.FieldNames.NmUsuario] = (String)dto.NmUsuario.Value;

            if (!dto.DsUnidade.Value.IsNull) dtr[SegurancaDTO.FieldNames.DsUnidade] = (String)dto.DsUnidade.Value;
            if (!dto.DsLocal.Value.IsNull) dtr[SegurancaDTO.FieldNames.DsLocal] = (String)dto.DsLocal.Value;
            if (!dto.DsSetor.Value.IsNull) dtr[SegurancaDTO.FieldNames.DsSetor] = (String)dto.DsSetor.Value;

            if (!dto.IdtUnidade.Value.IsNull) dtr[SegurancaDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;
            if (!dto.IdtLocal.Value.IsNull) dtr[SegurancaDTO.FieldNames.IdtLocal] = (Decimal)dto.IdtLocal.Value;
            if (!dto.IdtSetor.Value.IsNull) dtr[SegurancaDTO.FieldNames.IdtSetor] = (Decimal)dto.IdtSetor.Value;

            if (!dto.IdtNivelSegurancaTeste.Value.IsNull) dtr[SegurancaDTO.FieldNames.IdtNivelSegurancaTeste] = (Decimal)dto.IdtNivelSegurancaTeste.Value;

            if (!dto.IdtNivelSegurancaTeste.Value.IsNull) dtr[SegurancaDTO.FieldNames.CdSetor] = (String)dto.CdSetor.Value;

            if (!dto.Login.Value.IsNull) dtr[SegurancaDTO.FieldNames.Login] = (String)dto.Login.Value;
            if (!dto.FlStatus.Value.IsNull) dtr[SegurancaDTO.FieldNames.FlStatus] = (Decimal)dto.FlStatus.Value;
            if (!dto.Senha.Value.IsNull) dtr[SegurancaDTO.FieldNames.Senha] = (String)dto.Senha.Value;
            if (!dto.NovaSenha.Value.IsNull) dtr[SegurancaDTO.FieldNames.NovaSenha] = (String)dto.NovaSenha.Value;

            if (!dto.Servidor.Value.IsNull) dtr[SegurancaDTO.FieldNames.Servidor] = (String)dto.Servidor.Value;
            if (!dto.Ip.Value.IsNull) dtr[SegurancaDTO.FieldNames.Ip] = (String)dto.Ip.Value;


            this.Rows.Add(dtr);
        }

    }

    [Serializable()]
    public class SegurancaDTO : MVC.DTO.DTOBase
    {

        public enum NivelSeguranca
        {
            GESTOR = 0,
            COORDENADOR = 1,
            OPERADOR = 2
        }


        public enum Modulo
        {
            GestaoMateriais = 43
        }

        public enum Status
        {
            INATIVO = 0,
            ATIVO = 1,
            BLOQUEADO = 2
        }

        private MVC.DTO.FieldDecimal seg_usu_id_usuario;
        private MVC.DTO.FieldString seg_usu_ds_nome;
        private MVC.DTO.FieldDecimal cad_uni_id_unidade;
        private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
        private MVC.DTO.FieldDecimal cad_set_id;
        private MVC.DTO.FieldString cad_uni_ds_unidade;
        private MVC.DTO.FieldString cad_lat_ds_local_atendimento;
        private MVC.DTO.FieldString cad_set_ds_setor;
        private MVC.DTO.FieldDecimal id_nivel_seguranca;
        private MVC.DTO.FieldString cd_setor;
        private MVC.DTO.FieldDecimal seg_usu_fl_status;
        private MVC.DTO.FieldString seg_usu_ds_login;
        private MVC.DTO.FieldString seg_usu_cd_password;

        private MVC.DTO.FieldString nova_senha;
        private MVC.DTO.FieldString servidor_bd;
        private MVC.DTO.FieldString ip_usuario;


        public SegurancaDTO()
        {
            InitializeComponent();
        }

        internal void InitializeComponent()
        {
            this.seg_usu_id_usuario = new MVC.DTO.FieldDecimal(FieldNames.Idt, Captions.Idt, DbType.Decimal);
            this.seg_usu_ds_nome = new MVC.DTO.FieldString(FieldNames.NmUsuario, Captions.NmUsuario, 60);
            this.cad_uni_ds_unidade = new MVC.DTO.FieldString(FieldNames.DsUnidade, Captions.DsUnidade, 60);
            this.cad_lat_ds_local_atendimento = new MVC.DTO.FieldString(FieldNames.DsLocal, Captions.DsLocal, 60);
            this.cad_set_ds_setor = new MVC.DTO.FieldString(FieldNames.DsSetor, Captions.DsSetor, 60);
            this.cad_uni_id_unidade = new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade, Captions.IdtUnidade, DbType.Decimal);
            this.cad_lat_id_local_atendimento = new MVC.DTO.FieldDecimal(FieldNames.IdtLocal, Captions.IdtLocal, DbType.Decimal);
            this.cad_set_id = new MVC.DTO.FieldDecimal(FieldNames.IdtSetor, Captions.IdtSetor, DbType.Decimal);
            this.id_nivel_seguranca = new MVC.DTO.FieldDecimal(FieldNames.IdtNivelSegurancaTeste, Captions.IdtNivelSegurancaTeste, DbType.Decimal);
            this.cd_setor = new MVC.DTO.FieldString(FieldNames.CdSetor, Captions.CdSetor, 5);
            this.seg_usu_ds_login = new MVC.DTO.FieldString(FieldNames.Login, Captions.Login, 20);
            this.seg_usu_fl_status = new MVC.DTO.FieldDecimal(FieldNames.FlStatus, Captions.FlStatus, DbType.Decimal);
            this.seg_usu_cd_password = new MVC.DTO.FieldString(FieldNames.Senha, Captions.Senha, 32);
            this.nova_senha = new MVC.DTO.FieldString(FieldNames.NovaSenha, Captions.NovaSenha, 32);

            this.servidor_bd = new MVC.DTO.FieldString(FieldNames.Servidor, Captions.Servidor, 32);
            this.ip_usuario = new MVC.DTO.FieldString(FieldNames.Ip, Captions.Ip, 32);

        }

        #region FieldNames

        public struct FieldNames
        {
            public const string Idt = "SEG_USU_ID_USUARIO";
            public const string NmUsuario = "SEG_USU_DS_NOME";
            public const string IdtUnidade = "CAD_UNI_ID_UNIDADE";
            public const string IdtLocal = "CAD_LAT_ID_LOCAL_ATENDIMENTO";
            public const string IdtSetor = "CAD_SET_ID";
            public const string DsUnidade = "CAD_UNI_DS_UNIDADE";
            public const string DsLocal = "CAD_LAT_DS_LOCAL_ATENDIMENTO";
            public const string DsSetor = "CAD_SET_DS_SETOR";
            public const string IdtNivelSegurancaTeste = "ID_NIVEL_SEGURANCA";
            public const string CdSetor = "CD_SETOR";
            public const string Login = "SEG_USU_DS_LOGIN";
            public const string FlStatus = "SEG_USU_FL_STATUS";
            public const string Senha = "SEG_USU_CD_PASSWORD";
            public const string NovaSenha = "NOVA_SENHA";

            public const string Servidor = "SERVIDOR_BD";
            public const string Ip = "IP_USUARIO";
        }

        #endregion

        #region Captions
        public struct Captions
        {
            public const string Idt = "IDUSUARIO";
            public const string NmUsuario = "NMUSUARIO";

            public const string DsUnidade = "DSUNIDADE";
            public const string DsLocal = "DSLOCAL";
            public const string DsSetor = "DSSETOR";

            public const string IdtUnidade = "IDUNIDADE";
            public const string IdtLocal = "IDLOCAL";
            public const string IdtSetor = "IDSETOR";
            public const string IdtNivelSegurancaTeste = "IDNIVELSEGURANCA";
            public const string CdSetor = "CDSETOR";

            public const string Login = "LOGIN";
            public const string FlStatus = "FLSTATUS";
            public const string Senha = "SENHA";
            public const string NovaSenha = "NOVASENHA";
            public const string Servidor = "SERVIDOR";
            public const string Ip = "IP";                      
        }

        #endregion

        #region Atributos Publicos

        public MVC.DTO.FieldDecimal Idt
        {
            get { return seg_usu_id_usuario; }
            set { seg_usu_id_usuario = value; }
        }

        /// <summary>
        /// Nome do Usuário
        /// </summary>
        public MVC.DTO.FieldString NmUsuario
        {
            get { return seg_usu_ds_nome; }
            set { seg_usu_ds_nome = value; }
        }

        public MVC.DTO.FieldString DsUnidade
        {
            get { return cad_uni_ds_unidade; }
            set { cad_uni_ds_unidade = value; }
        }

        public MVC.DTO.FieldString DsLocal
        {
            get { return cad_lat_ds_local_atendimento; }
            set { cad_lat_ds_local_atendimento = value; }
        }

        public MVC.DTO.FieldString DsSetor
        {
            get { return cad_set_ds_setor; }
            set { cad_set_ds_setor = value; }
        }

        public MVC.DTO.FieldDecimal IdtUnidade
        {
            get { return cad_uni_id_unidade; }
            set { cad_uni_id_unidade = value; }
        }

        public MVC.DTO.FieldDecimal IdtLocal
        {
            get { return cad_lat_id_local_atendimento; }
            set { cad_lat_id_local_atendimento = value; }
        }

        public MVC.DTO.FieldDecimal IdtSetor
        {
            get { return cad_set_id; }
            set { cad_set_id = value; }
        }

        public MVC.DTO.FieldDecimal IdtNivelSegurancaTeste
        {
            get { return id_nivel_seguranca; }
            set { id_nivel_seguranca = value; }
        }


        /// <summary>
        /// Campo para compatibilidade do legado
        /// </summary>
        public MVC.DTO.FieldString CdSetor
        {
            get { return cd_setor; }
            set { cd_setor = value; }
        }

        /// <summary>
        /// Login do Usuário
        /// </summary>
        public MVC.DTO.FieldString Login
        {
            get { return seg_usu_ds_login; }
            set { seg_usu_ds_login = value; }
        }

        /// <summary>
        /// Status do Usuário Ativo/Inativo/Bloqueado
        /// </summary>
        public MVC.DTO.FieldDecimal FlStatus
        {
            get { return seg_usu_fl_status; }
            set { seg_usu_fl_status = value; }
        }


        public MVC.DTO.FieldString Senha
        {
            get { return seg_usu_cd_password; }
            set { seg_usu_cd_password = value; }
        }

        
        /// <summary>
        /// Utilizado na troca de senha
        /// </summary>
        public MVC.DTO.FieldString NovaSenha
        {
            get { return nova_senha; }
            set { nova_senha = value; }
        }


        /// <summary>
        /// Banco de Dados Conectado
        /// </summary>
        public MVC.DTO.FieldString Servidor
        {
            get { return servidor_bd; }
            set { servidor_bd = value; }
        }

        /// <summary>
        /// Endereço TCP do usuário conectado
        /// </summary>
        public MVC.DTO.FieldString Ip
        {
            get { return ip_usuario; }
            set { ip_usuario = value; }
        }

        #endregion


        #region Operators

        public static explicit operator SegurancaDTO(DataRow row)
        {
            SegurancaDTO dto = new SegurancaDTO();

            dto.Idt.Value = row[FieldNames.Idt].ToString();

            dto.NmUsuario.Value = row[FieldNames.NmUsuario].ToString();

            dto.DsUnidade.Value = row[FieldNames.DsUnidade].ToString();

            dto.DsLocal.Value = row[FieldNames.DsLocal].ToString();

            dto.DsSetor.Value = row[FieldNames.DsSetor].ToString();

            dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();

            dto.IdtLocal.Value = row[FieldNames.IdtLocal].ToString();

            dto.IdtSetor.Value = row[FieldNames.IdtSetor].ToString();

            dto.IdtNivelSegurancaTeste.Value = row[FieldNames.IdtNivelSegurancaTeste].ToString();

            dto.CdSetor.Value = row[FieldNames.CdSetor].ToString();

            dto.Login.Value = row[FieldNames.Login].ToString();

            dto.FlStatus.Value = row[FieldNames.FlStatus].ToString();

            dto.Senha.Value = row[FieldNames.Senha].ToString();

            dto.NovaSenha.Value = row[FieldNames.NovaSenha].ToString();

            dto.Servidor.Value = row[FieldNames.Servidor].ToString();

            dto.Ip.Value = row[FieldNames.Ip].ToString();

            return dto;
        }

        public static explicit operator SegurancaDTO(XmlDocument xml)
        {
            SegurancaDTO dto = new SegurancaDTO();

            if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.NmUsuario) != null) dto.NmUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmUsuario).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade) != null) dto.DsUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsLocal) != null) dto.DsLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsLocal).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.NmUsuario) != null) dto.NmUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmUsuario).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsSetor) != null) dto.DsSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsSetor).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal) != null) dto.IdtLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor) != null) dto.IdtSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtNivelSegurancaTeste) != null) dto.IdtNivelSegurancaTeste.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtNivelSegurancaTeste).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.CdSetor) != null) dto.CdSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdSetor).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Login) != null) dto.Login.Value = xml.FirstChild.SelectSingleNode(FieldNames.Login).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.FlStatus) != null) dto.FlStatus.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlStatus).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Senha) != null) dto.Senha.Value = xml.FirstChild.SelectSingleNode(FieldNames.Senha).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.NovaSenha) != null) dto.NovaSenha.Value = xml.FirstChild.SelectSingleNode(FieldNames.NovaSenha).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Servidor) != null) dto.Servidor.Value = xml.FirstChild.SelectSingleNode(FieldNames.Servidor).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Ip) != null) dto.Ip.Value = xml.FirstChild.SelectSingleNode(FieldNames.Ip).InnerText;

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);

            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);

            XmlNode nodeNmUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.NmUsuario, null);

            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);

            XmlNode nodeIdtLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocal, null);

            XmlNode nodeIdtSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetor, null);

            XmlNode nodeDsLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.DsLocal, null);

            XmlNode nodeDsSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.DsSetor, null);

            XmlNode nodeDsUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidade, null);

            XmlNode nodeIdtNivelSegurancaTeste = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtNivelSegurancaTeste, null);

            XmlNode nodeCdSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.CdSetor, null);

            XmlNode nodeLogin = xml.CreateNode(XmlNodeType.Element, FieldNames.Login, null);

            XmlNode nodeFlStatus = xml.CreateNode(XmlNodeType.Element, FieldNames.FlStatus, null);

            XmlNode nodeSenha = xml.CreateNode(XmlNodeType.Element, FieldNames.Senha, null);

            XmlNode nodeNovaSenha = xml.CreateNode(XmlNodeType.Element, FieldNames.NovaSenha, null);

            XmlNode nodeServidor = xml.CreateNode(XmlNodeType.Element, FieldNames.Servidor, null);

            XmlNode nodeIp = xml.CreateNode(XmlNodeType.Element, FieldNames.Ip, null);

            if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;

            if (!this.NmUsuario.Value.IsNull) nodeNmUsuario.InnerText = this.NmUsuario.Value;

            if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;

            if (!this.IdtLocal.Value.IsNull) nodeIdtLocal.InnerText = this.IdtLocal.Value;

            if (!this.IdtSetor.Value.IsNull) nodeIdtSetor.InnerText = this.IdtSetor.Value;

            if (!this.DsLocal.Value.IsNull) nodeDsLocal.InnerText = this.DsLocal.Value;

            if (!this.DsSetor.Value.IsNull) nodeDsSetor.InnerText = this.DsSetor.Value;

            if (!this.DsUnidade.Value.IsNull) nodeDsUnidade.InnerText = this.DsUnidade.Value;

            if (!this.IdtNivelSegurancaTeste.Value.IsNull) nodeIdtNivelSegurancaTeste.InnerText = this.IdtNivelSegurancaTeste.Value;

            if (!this.CdSetor.Value.IsNull) nodeCdSetor.InnerText = this.CdSetor.Value;

            if (!this.Login.Value.IsNull) nodeLogin.InnerText = this.Login.Value;

            if (!this.FlStatus.Value.IsNull) nodeFlStatus.InnerText = this.FlStatus.Value;

            if (!this.Senha.Value.IsNull) nodeSenha.InnerText = this.Senha.Value;

            if (!this.NovaSenha.Value.IsNull) nodeNovaSenha.InnerText = this.NovaSenha.Value;

            if (!this.Servidor.Value.IsNull) nodeServidor.InnerText = this.Servidor.Value;

            if (!this.Ip.Value.IsNull) nodeIp.InnerText = this.Ip.Value;


            nodeData.AppendChild(nodeIdt);

            nodeData.AppendChild(nodeNmUsuario);

            nodeData.AppendChild(nodeIdtUnidade);

            nodeData.AppendChild(nodeIdtLocal);

            nodeData.AppendChild(nodeIdtSetor);

            nodeData.AppendChild(nodeDsLocal);

            nodeData.AppendChild(nodeDsSetor);

            nodeData.AppendChild(nodeDsUnidade);

            nodeData.AppendChild(nodeIdtNivelSegurancaTeste);

            nodeData.AppendChild(nodeCdSetor);

            nodeData.AppendChild(nodeLogin);

            nodeData.AppendChild(nodeFlStatus);

            nodeData.AppendChild(nodeSenha);

            nodeData.AppendChild(nodeNovaSenha);

            nodeData.AppendChild(nodeServidor);

            nodeData.AppendChild(nodeIp);

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(SegurancaDTO dto)
        {
            SegurancaDataTable dtb = new SegurancaDataTable();
            DataRow dtr = dtb.NewRow();

            dtr[FieldNames.Idt] = dto.Idt.Value;

            dtr[FieldNames.NmUsuario] = dto.NmUsuario.Value;

            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;

            dtr[FieldNames.IdtLocal] = dto.IdtLocal.Value;

            dtr[FieldNames.IdtSetor] = dto.IdtSetor.Value;

            dtr[FieldNames.DsLocal] = dto.DsLocal.Value;

            dtr[FieldNames.DsSetor] = dto.DsSetor.Value;

            dtr[FieldNames.DsUnidade] = dto.DsUnidade.Value;

            dtr[FieldNames.IdtNivelSegurancaTeste] = dto.IdtNivelSegurancaTeste.Value;

            dtr[FieldNames.CdSetor] = dto.CdSetor.Value;

            dtr[FieldNames.Login] = dto.Login.Value;

            dtr[FieldNames.FlStatus] = dto.FlStatus.Value;

            dtr[FieldNames.Senha] = dto.Senha.Value;

            dtr[FieldNames.NovaSenha] = dto.NovaSenha.Value;

            dtr[FieldNames.Servidor] = dto.Servidor.Value;

            dtr[FieldNames.Ip] = dto.Ip.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(SegurancaDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }

}
