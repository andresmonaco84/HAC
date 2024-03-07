
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
    /// Classe Entidade UsuarioFuncionalidadeDataTable
    /// </summary>
    [Serializable()]
    public class UsuarioFuncionalidadeDataTable : DataTable
    {

        public UsuarioFuncionalidadeDataTable()
            : base()
        {
            this.TableName = "DADOS";

            this.Columns.Add(UsuarioFuncionalidadeDTO.FieldNames.IdtPerfil, typeof(Decimal));
            this.Columns.Add(UsuarioFuncionalidadeDTO.FieldNames.IdtFuncionalidade, typeof(Decimal));


            this.Columns.Add(UsuarioFuncionalidadeDTO.FieldNames.IdtUsuario, typeof(Decimal));
            this.Columns.Add(UsuarioFuncionalidadeDTO.FieldNames.IdtUnidade, typeof(Decimal));
            this.Columns.Add(UsuarioFuncionalidadeDTO.FieldNames.IdtModulo, typeof(Decimal));
            this.Columns.Add(UsuarioFuncionalidadeDTO.FieldNames.NmPerfil, typeof(String));
            this.Columns.Add(UsuarioFuncionalidadeDTO.FieldNames.NmPagina, typeof(String));


            DataColumn[] primaryKey = { this.Columns[UsuarioFuncionalidadeDTO.FieldNames.IdtUnidade], this.Columns[UsuarioFuncionalidadeDTO.FieldNames.IdtPerfil], this.Columns[UsuarioFuncionalidadeDTO.FieldNames.IdtFuncionalidade] };

            this.PrimaryKey = primaryKey;
        }

        protected UsuarioFuncionalidadeDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }


        public UsuarioFuncionalidadeDTO TypedRow(int index)
        {
            return (UsuarioFuncionalidadeDTO)this.Rows[index];
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

        public void Add(UsuarioFuncionalidadeDTO dto)
        {
            DataRow dtr = this.NewRow();


            if (!dto.IdtPerfil.Value.IsNull) dtr[UsuarioFuncionalidadeDTO.FieldNames.IdtPerfil] = (Decimal)dto.IdtPerfil.Value;
            if (!dto.IdtUsuario.Value.IsNull) dtr[UsuarioFuncionalidadeDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;
            if (!dto.IdtFuncionalidade.Value.IsNull) dtr[UsuarioFuncionalidadeDTO.FieldNames.IdtFuncionalidade] = (Decimal)dto.IdtFuncionalidade.Value;


            if (!dto.IdtUnidade.Value.IsNull) dtr[UsuarioFuncionalidadeDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;
            if (!dto.IdtModulo.Value.IsNull) dtr[UsuarioFuncionalidadeDTO.FieldNames.IdtModulo] = (Decimal)dto.IdtModulo.Value;
            if (!dto.NmPerfil.Value.IsNull) dtr[UsuarioFuncionalidadeDTO.FieldNames.NmPerfil] = (String)dto.NmPerfil.Value;

            if (!dto.NmPagina.Value.IsNull) dtr[UsuarioFuncionalidadeDTO.FieldNames.NmPagina] = (String)dto.NmPagina.Value;




            this.Rows.Add(dtr);
        }
    }

    [Serializable()]
    public class UsuarioFuncionalidadeDTO : MVC.DTO.DTOBase
    {
        private MVC.DTO.FieldDecimal seg_per_id_perfil;
        private MVC.DTO.FieldDecimal seg_usu_id_usuario;
        private MVC.DTO.FieldDecimal cad_uni_id_unidade;
        private MVC.DTO.FieldDecimal seg_mod_id_modulo;

        private MVC.DTO.FieldDecimal seg_fun_id_funcionalidade;

        private MVC.DTO.FieldString seg_per_nm_perfil;

        private MVC.DTO.FieldString seg_fun_ds_nome_pagina;

        public UsuarioFuncionalidadeDTO()
        {
            InitializeComponent();
        }

        internal void InitializeComponent()
        {
            this.seg_per_id_perfil = new MVC.DTO.FieldDecimal(FieldNames.IdtPerfil, Captions.IdtPerfil, DbType.Decimal);
            this.seg_usu_id_usuario = new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario, Captions.IdtUsuario, DbType.Decimal);
            this.cad_uni_id_unidade = new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade, Captions.IdtUnidade, DbType.Decimal);
            this.seg_mod_id_modulo = new MVC.DTO.FieldDecimal(FieldNames.IdtModulo, Captions.IdtModulo, DbType.Decimal);
            this.seg_per_nm_perfil = new MVC.DTO.FieldString(FieldNames.NmPerfil, Captions.NmPerfil, 50);
            this.seg_fun_ds_nome_pagina = new MVC.DTO.FieldString(FieldNames.NmPagina, Captions.NmPagina, 50);

            this.seg_fun_id_funcionalidade = new MVC.DTO.FieldDecimal(FieldNames.IdtFuncionalidade, Captions.IdtFuncionalidade, DbType.Decimal);



        }

        #region FieldNames

        public struct FieldNames
        {
            public const string IdtPerfil = "SEG_PER_ID_PERFIL";
            public const string IdtUsuario = "SEG_USU_ID_USUARIO";
            public const string IdtUnidade = "CAD_UNI_ID_UNIDADE";
            public const string IdtModulo = "SEG_MOD_ID_MODULO";
            public const string NmPerfil = "SEG_PER_NM_PERFIL";
            public const string NmPagina = "SEG_FUN_DS_NOME_PAGINA";


            public const string IdtFuncionalidade = "SEG_FUN_ID_FUNCIONALIDADE";




        }

        #endregion

        #region Captions
        public struct Captions
        {
            public const string IdtPerfil = "IDTPERFIL";
            public const string IdtUsuario = "IDTUSUARIO";
            public const string IdtUnidade = "IDTUNIDADE";
            public const string IdtModulo = "IDTMODULO";
            public const string NmPerfil = "NMPERFIL";
            public const string NmPagina = "NMPAGINA";

            public const string IdtFuncionalidade = "IDTFUNCIONALIDADE";

        }

        #endregion

        #region Atributos Publicos


        public MVC.DTO.FieldDecimal IdtPerfil
        {
            get { return seg_per_id_perfil; }
            set { seg_per_id_perfil = value; }
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

        public MVC.DTO.FieldDecimal IdtModulo
        {
            get { return seg_mod_id_modulo; }
            set { seg_mod_id_modulo = value; }
        }

        public MVC.DTO.FieldString NmPerfil
        {
            get { return seg_per_nm_perfil; }
            set { seg_per_nm_perfil = value; }
        }

        /// <summary>
        /// Codigo para verificação de acesso a funcionalidade, normalmente o nome do objeto
        /// </summary>
        public MVC.DTO.FieldString NmPagina
        {
            get { return seg_fun_ds_nome_pagina; }
            set { seg_fun_ds_nome_pagina = value; }
        }


        public MVC.DTO.FieldDecimal IdtFuncionalidade
        {
            get { return seg_fun_id_funcionalidade; }
            set { seg_fun_id_funcionalidade = value; }
        }


        #endregion


        #region Operators

        public static explicit operator UsuarioFuncionalidadeDTO(DataRow row)
        {
            UsuarioFuncionalidadeDTO dto = new UsuarioFuncionalidadeDTO();

            dto.IdtPerfil.Value = row[FieldNames.IdtPerfil].ToString();

            dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();

            dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();

            dto.IdtModulo.Value = row[FieldNames.IdtModulo].ToString();

            dto.NmPerfil.Value = row[FieldNames.NmPerfil].ToString();

            dto.NmPagina.Value = row[FieldNames.NmPagina].ToString();

            dto.IdtFuncionalidade.Value = row[FieldNames.IdtFuncionalidade].ToString();


            return dto;
        }

        public static explicit operator UsuarioFuncionalidadeDTO(XmlDocument xml)
        {
            UsuarioFuncionalidadeDTO dto = new UsuarioFuncionalidadeDTO();

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtPerfil) != null) dto.IdtPerfil.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtPerfil).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo) != null) dto.IdtModulo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtModulo).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.NmPerfil) != null) dto.NmPerfil.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmPerfil).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.NmPagina) != null) dto.NmPagina.Value = xml.FirstChild.SelectSingleNode(FieldNames.NmPagina).InnerText;


            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFuncionalidade) != null) dto.IdtFuncionalidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFuncionalidade).InnerText;


            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);

            XmlNode nodeIdtPerfil = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtPerfil, null);

            XmlNode nodeIdtUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);

            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);

            XmlNode nodeIdtModulo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtModulo, null);

            XmlNode nodeNmPerfil = xml.CreateNode(XmlNodeType.Element, FieldNames.NmPerfil, null);

            XmlNode nodeNmPagina = xml.CreateNode(XmlNodeType.Element, FieldNames.NmPagina, null);

            XmlNode nodeIdtFuncionalidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFuncionalidade, null);




            if (!this.IdtPerfil.Value.IsNull) nodeIdtPerfil.InnerText = this.IdtPerfil.Value;

            if (!this.IdtUsuario.Value.IsNull) nodeIdtUsuario.InnerText = this.IdtUsuario.Value;

            if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;

            if (!this.IdtModulo.Value.IsNull) nodeIdtModulo.InnerText = this.IdtModulo.Value;

            if (!this.NmPerfil.Value.IsNull) nodeNmPerfil.InnerText = this.NmPerfil.Value;

            if (!this.NmPagina.Value.IsNull) nodeNmPagina.InnerText = this.NmPagina.Value;

            if (!this.IdtFuncionalidade.Value.IsNull) nodeIdtFuncionalidade.InnerText = this.IdtFuncionalidade.Value;





            nodeData.AppendChild(nodeIdtPerfil);

            nodeData.AppendChild(nodeIdtUsuario);

            nodeData.AppendChild(nodeIdtUnidade);

            nodeData.AppendChild(nodeIdtModulo);

            nodeData.AppendChild(nodeNmPerfil);

            nodeData.AppendChild(nodeNmPagina);

            nodeData.AppendChild(nodeIdtFuncionalidade);

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(UsuarioFuncionalidadeDTO dto)
        {
            UsuarioFuncionalidadeDataTable dtb = new UsuarioFuncionalidadeDataTable();
            DataRow dtr = dtb.NewRow();

            dtr[FieldNames.IdtPerfil] = dto.IdtPerfil.Value;

            dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;

            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;

            dtr[FieldNames.IdtModulo] = dto.IdtModulo.Value;

            dtr[FieldNames.NmPerfil] = dto.NmPerfil.Value;

            dtr[FieldNames.NmPagina] = dto.NmPagina.Value;

            dtr[FieldNames.IdtFuncionalidade] = dto.IdtFuncionalidade.Value;


            // SEG_FUN_ID_FUNCIONALIDADE IdtFuncionalidade seg_fun_id_funcionalidade nodeIdtFuncionalidade

            return dtr;
        }

        public static explicit operator XmlDocument(UsuarioFuncionalidadeDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


