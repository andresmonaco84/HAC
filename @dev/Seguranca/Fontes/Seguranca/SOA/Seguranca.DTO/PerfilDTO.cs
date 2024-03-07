
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
            this.Columns.Add(PerfilDTO.FieldNames.NmPerfil, typeof(String));
            this.Columns.Add(PerfilDTO.FieldNames.FlStatus, typeof(String));
            this.Columns.Add(PerfilDTO.FieldNames.DtAtualizacao, typeof(DateTime));
            this.Columns.Add(PerfilDTO.FieldNames.IdtUsuario, typeof(Decimal));
            // this.Columns.Add(PerfilDTO.FieldNames.IdtSistema, typeof(Decimal));
            this.Columns.Add(PerfilDTO.FieldNames.IdtModulo, typeof(Decimal));
            
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
            if (!dto.NmPerfil.Value.IsNull) dtr[PerfilDTO.FieldNames.NmPerfil] = (String)dto.NmPerfil.Value;
            if (!dto.FlStatus.Value.IsNull) dtr[PerfilDTO.FieldNames.FlStatus] = (String)dto.FlStatus.Value;
            if (!dto.DtAtualizacao.Value.IsNull) dtr[PerfilDTO.FieldNames.DtAtualizacao] = (DateTime)dto.DtAtualizacao.Value;
            if (!dto.IdtUsuario.Value.IsNull) dtr[PerfilDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;
            // if (!dto.IdtSistema.Value.IsNull) dtr[PerfilDTO.FieldNames.IdtSistema] = (Decimal)dto.IdtSistema.Value;
            if (!dto.IdtModulo.Value.IsNull) dtr[PerfilDTO.FieldNames.IdtModulo] = (Decimal)dto.IdtModulo.Value;



            this.Rows.Add(dtr);
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
        // private MVC.DTO.FieldDecimal seg_id_sistema;
        private MVC.DTO.FieldDecimal seg_mod_id_modulo;



        public PerfilDTO()
        {
            InitializeComponent();
        }

        internal void InitializeComponent()
        {
            this.seg_per_id_perfil = new MVC.DTO.FieldDecimal(FieldNames.Idt, Captions.Idt, DbType.Decimal);
            this.seg_per_nm_perfil = new MVC.DTO.FieldString(FieldNames.NmPerfil, Captions.NmPerfil, 50);
            this.seg_per_fl_status = new MVC.DTO.FieldString(FieldNames.FlStatus, Captions.FlStatus, 1);
            this.seg_per_dt_ultima_atualizacao = new MVC.DTO.FieldDateTime(FieldNames.DtAtualizacao, Captions.DtAtualizacao);
            this.seg_usu_id_usuario = new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario, Captions.IdtUsuario, DbType.Decimal);
            // this.seg_id_sistema= new MVC.DTO.FieldDecimal(FieldNames.IdtSistema,Captions.IdtSistema, DbType.Decimal);
            this.seg_mod_id_modulo = new MVC.DTO.FieldDecimal(FieldNames.IdtModulo, Captions.IdtModulo, DbType.Decimal);


        }

        #region FieldNames

        public struct FieldNames
        {
            public const string Idt = "SEG_PER_ID_PERFIL";
            public const string NmPerfil = "SEG_PER_NM_PERFIL";
            public const string FlStatus = "SEG_PER_FL_STATUS";
            public const string DtAtualizacao = "SEG_PER_DT_ULTIMA_ATUALIZACAO";
            public const string IdtUsuario = "SEG_USU_ID_USUARIO";
            // public const string IdtSistema="SEG_ID_SISTEMA";
            public const string IdtModulo = "SEG_MOD_ID_MODULO";

        }

        #endregion

        #region Captions
        public struct Captions
        {
            public const string Idt = "IDT";
            public const string NmPerfil = "NMPERFIL";
            public const string FlStatus = "FLSTATUS";
            public const string DtAtualizacao = "DTATUALIZACAO";
            public const string IdtUsuario = "IDTUSUARIO";
            // public const string IdtSistema="IDTSISTEMA";
            public const string IdtModulo = "IDTMODULO";



        }

        #endregion

        #region Atributos Publicos


        public MVC.DTO.FieldDecimal Idt
        {
            get { return seg_per_id_perfil; }
            set { seg_per_id_perfil = value; }
        }

        public MVC.DTO.FieldString NmPerfil
        {
            get { return seg_per_nm_perfil; }
            set { seg_per_nm_perfil = value; }
        }

        public MVC.DTO.FieldString FlStatus
        {
            get { return seg_per_fl_status; }
            set { seg_per_fl_status = value; }
        }

        public MVC.DTO.FieldDateTime DtAtualizacao
        {
            get { return seg_per_dt_ultima_atualizacao; }
            set { seg_per_dt_ultima_atualizacao = value; }
        }

        public MVC.DTO.FieldDecimal IdtUsuario
        {
            get { return seg_usu_id_usuario; }
            set { seg_usu_id_usuario = value; }
        }

        //public MVC.DTO.FieldDecimal IdtSistema
        //{
        //    get { return seg_id_sistema; }
        //    set { seg_id_sistema = value; }
        //}

        public MVC.DTO.FieldDecimal IdtModulo
        {
            get { return seg_mod_id_modulo; }
            set { seg_mod_id_modulo = value; }
        }


        #endregion


        #region Operators

        public static explicit operator PerfilDTO(DataRow row)
        {
            PerfilDTO dto = new PerfilDTO();

            dto.Idt.Value = row[FieldNames.Idt].ToString();

            dto.NmPerfil.Value = row[FieldNames.NmPerfil].ToString();

            dto.FlStatus.Value = row[FieldNames.FlStatus].ToString();

            dto.DtAtualizacao.Value = row[FieldNames.DtAtualizacao].ToString();

            dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();

            // dto.IdtSistema.Value = row[FieldNames.IdtSistema].ToString();

            dto.IdtModulo.Value = row[FieldNames.IdtModulo].ToString();

            return dto;
        }

        public static explicit operator PerfilDTO(XmlDocument xml)
        {
            PerfilDTO dto = new PerfilDTO();

            if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.NmPerfil) != null) dto.NmPerfil.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmPerfil).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.FlStatus) != null) dto.FlStatus.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlStatus).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DtAtualizacao) != null) dto.DtAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtAtualizacao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;

            // if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSistema) != null) dto.IdtSistema.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSistema).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo) != null) dto.IdtModulo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo).InnerText;


            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);

            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);

            XmlNode nodeNmPerfil = xml.CreateNode(XmlNodeType.Element, FieldNames.NmPerfil, null);

            XmlNode nodeFlStatus = xml.CreateNode(XmlNodeType.Element, FieldNames.FlStatus, null);

            XmlNode nodeDtAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DtAtualizacao, null);

            XmlNode nodeIdtUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);

            // XmlNode nodeIdtSistema = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSistema, null);

            XmlNode nodeIdtModulo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtModulo, null);


            if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;

            if (!this.NmPerfil.Value.IsNull) nodeNmPerfil.InnerText = this.NmPerfil.Value;

            if (!this.FlStatus.Value.IsNull) nodeFlStatus.InnerText = this.FlStatus.Value;

            if (!this.DtAtualizacao.Value.IsNull) nodeDtAtualizacao.InnerText = this.DtAtualizacao.Value;

            if (!this.IdtUsuario.Value.IsNull) nodeIdtUsuario.InnerText = this.IdtUsuario.Value;

            // if (!this.IdtSistema.Value.IsNull) nodeIdtSistema.InnerText = this.IdtSistema.Value;
            if (!this.IdtModulo.Value.IsNull) nodeIdtModulo.InnerText = this.IdtModulo.Value;




            nodeData.AppendChild(nodeIdt);

            nodeData.AppendChild(nodeNmPerfil);

            nodeData.AppendChild(nodeFlStatus);

            nodeData.AppendChild(nodeDtAtualizacao);

            nodeData.AppendChild(nodeIdtUsuario);

            // nodeData.AppendChild(nodeIdtSistema);

            nodeData.AppendChild(nodeIdtModulo);

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(PerfilDTO dto)
        {
            PerfilDataTable dtb = new PerfilDataTable();
            DataRow dtr = dtb.NewRow();

            dtr[FieldNames.Idt] = dto.Idt.Value;

            dtr[FieldNames.NmPerfil] = dto.NmPerfil.Value;

            dtr[FieldNames.FlStatus] = dto.FlStatus.Value;

            dtr[FieldNames.DtAtualizacao] = dto.DtAtualizacao.Value;

            dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;

            // dtr[FieldNames.IdtSistema] = dto.IdtSistema.Value;

            dtr[FieldNames.IdtModulo] = dto.IdtModulo.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(PerfilDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


