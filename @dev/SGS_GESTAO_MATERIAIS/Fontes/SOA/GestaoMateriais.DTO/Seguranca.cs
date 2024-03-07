using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using MVC = HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.DTO
{
    [Serializable()]
    public class SegurancaDataTable : DataTable
    {
        public SegurancaDataTable() : base()
        {
            this.TableName = "DADOS";

		    this.Columns.Add(SegurancaDTO.FieldNames.Idt, typeof(Decimal));
            this.Columns.Add(SegurancaDTO.FieldNames.NmUsuario, typeof(String));
            this.Columns.Add(SegurancaDTO.FieldNames.DsUnidade, typeof(String));
            this.Columns.Add(SegurancaDTO.FieldNames.DsLocal, typeof(String));
            this.Columns.Add(SegurancaDTO.FieldNames.DsSetor, typeof(String));
            this.Columns.Add(SegurancaDTO.FieldNames.IdtUnidade, typeof(Decimal));
		    this.Columns.Add(SegurancaDTO.FieldNames.IdtLocal, typeof(Decimal));
		    this.Columns.Add(SegurancaDTO.FieldNames.IdtSetor, typeof(Decimal));
            this.Columns.Add(SegurancaDTO.FieldNames.IdtNivelSeguranca, typeof(Decimal));
            this.Columns.Add(SegurancaDTO.FieldNames.CdSetor, typeof(String));



            DataColumn[] primaryKey = { this.Columns[SegurancaDTO.FieldNames.Idt] };

            this.PrimaryKey = primaryKey;

        }
        protected SegurancaDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


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

            if (!dto.IdtNivelSeguranca.Value.IsNull) dtr[SegurancaDTO.FieldNames.IdtNivelSeguranca] = (Decimal)dto.IdtNivelSeguranca.Value;

            if (!dto.IdtNivelSeguranca.Value.IsNull) dtr[SegurancaDTO.FieldNames.CdSetor] = (String)dto.CdSetor.Value;

            // CdSetor

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


        private MVC.DTO.FieldDecimal id_usuario;
        private MVC.DTO.FieldString nm_usuario;
        private MVC.DTO.FieldDecimal id_unidade;
        private MVC.DTO.FieldDecimal id_local;
        private MVC.DTO.FieldDecimal id_setor;
        private MVC.DTO.FieldString ds_unidade;
        private MVC.DTO.FieldString ds_local;
        private MVC.DTO.FieldString ds_setor;
        private MVC.DTO.FieldDecimal id_nivel_seguranca;
        private MVC.DTO.FieldString  cd_setor;



        public SegurancaDTO()
        {
            InitializeComponent();
        }

        internal void InitializeComponent()
        {
            this.id_usuario = new MVC.DTO.FieldDecimal(FieldNames.Idt, Captions.Idt, DbType.Decimal);
            this.nm_usuario = new MVC.DTO.FieldString(FieldNames.NmUsuario, Captions.NmUsuario, 60);
            this.ds_unidade = new MVC.DTO.FieldString(FieldNames.DsUnidade, Captions.DsUnidade, 60);
            this.ds_local = new MVC.DTO.FieldString(FieldNames.DsLocal, Captions.DsLocal, 60);
            this.ds_setor = new MVC.DTO.FieldString(FieldNames.DsSetor, Captions.DsSetor, 60);
            this.id_unidade = new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade, Captions.IdtUnidade, DbType.Decimal);
            this.id_local = new MVC.DTO.FieldDecimal(FieldNames.IdtLocal, Captions.IdtLocal, DbType.Decimal);
            this.id_setor = new MVC.DTO.FieldDecimal(FieldNames.IdtSetor, Captions.IdtSetor, DbType.Decimal);
            this.id_nivel_seguranca = new MVC.DTO.FieldDecimal(FieldNames.IdtNivelSeguranca, Captions.IdtNivelSeguranca, DbType.Decimal);

            this.cd_setor = new MVC.DTO.FieldString(FieldNames.CdSetor, Captions.CdSetor, 5);
            


        }

        #region FieldNames

        public struct FieldNames
        {
            public const string Idt = "id_usuario";
            public const string NmUsuario = "nm_usuario";
            public const string IdtUnidade = "id_unidade";
            public const string IdtLocal = "id_local";
            public const string IdtSetor = "id_setor";
            public const string DsUnidade = "ds_unidade";
            public const string DsLocal = "ds_local";
            public const string DsSetor = "ds_setor";
            public const string IdtNivelSeguranca = "id_nivel_seguranca";
            public const string CdSetor = "cd_setor";


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
            public const string IdtNivelSeguranca = "IDNIVELSEGURANCA";
            public const string CdSetor = "CDSETOR";
            

        }

        #endregion

        #region Atributos Publicos

        public MVC.DTO.FieldDecimal Idt
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        public MVC.DTO.FieldString NmUsuario
        {
            get { return nm_usuario; }
            set { nm_usuario = value; }
        }

        public MVC.DTO.FieldString DsUnidade
        {
            get { return ds_unidade; }
            set { ds_unidade = value; }
        }

        public MVC.DTO.FieldString DsLocal
        {
            get { return ds_local; }
            set { ds_local = value; }
        }

        public MVC.DTO.FieldString DsSetor
        {
            get { return ds_setor; }
            set { ds_setor = value; }
        }

        public MVC.DTO.FieldDecimal IdtUnidade
        {
            get { return id_unidade; }
            set { id_unidade = value; }
        }


        public MVC.DTO.FieldDecimal IdtLocal
        {
            get { return id_local; }
            set { id_local = value; }
        }

        public MVC.DTO.FieldDecimal IdtSetor
        {
            get { return id_setor; }
            set { id_setor = value; }
        }

        public MVC.DTO.FieldDecimal IdtNivelSeguranca
        {
            get { return id_nivel_seguranca; }
            set { id_nivel_seguranca = value; }
        }

        public MVC.DTO.FieldString CdSetor
        {
            get { return cd_setor; }
            set { cd_setor = value; }
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

            dto.IdtNivelSeguranca.Value = row[FieldNames.IdtNivelSeguranca].ToString();

            dto.CdSetor.Value = row[FieldNames.CdSetor].ToString();



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

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtNivelSeguranca) != null) dto.IdtNivelSeguranca.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtNivelSeguranca).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.CdSetor) != null) dto.CdSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdSetor).InnerText;


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

            XmlNode nodeIdtNivelSeguranca = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtNivelSeguranca, null);

            XmlNode nodeCdSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.CdSetor, null);




            if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;

            if (!this.NmUsuario.Value.IsNull) nodeNmUsuario.InnerText = this.NmUsuario.Value;

            if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;

            if (!this.IdtLocal.Value.IsNull) nodeIdtLocal.InnerText = this.IdtLocal.Value;

            if (!this.IdtSetor.Value.IsNull) nodeIdtSetor.InnerText = this.IdtSetor.Value;

            if (!this.DsLocal.Value.IsNull) nodeDsLocal.InnerText = this.DsLocal.Value;

            if (!this.DsSetor.Value.IsNull) nodeDsSetor.InnerText = this.DsSetor.Value;

            if (!this.DsUnidade.Value.IsNull) nodeDsUnidade.InnerText = this.DsUnidade.Value;

            if (!this.IdtNivelSeguranca.Value.IsNull) nodeIdtNivelSeguranca.InnerText = this.IdtNivelSeguranca.Value;

            if (!this.CdSetor.Value.IsNull) nodeCdSetor.InnerText = this.CdSetor.Value;




            nodeData.AppendChild(nodeIdt);

            nodeData.AppendChild(nodeNmUsuario);

            nodeData.AppendChild(nodeIdtUnidade);

            nodeData.AppendChild(nodeIdtLocal);

            nodeData.AppendChild(nodeIdtSetor);

            nodeData.AppendChild(nodeDsLocal);

            nodeData.AppendChild(nodeDsSetor);

            nodeData.AppendChild(nodeDsUnidade);

            nodeData.AppendChild(nodeIdtNivelSeguranca);

            nodeData.AppendChild(nodeCdSetor);



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

            dtr[FieldNames.DsUnidade] = dto.IdtNivelSeguranca.Value;

            dtr[FieldNames.CdSetor] = dto.CdSetor.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(SegurancaDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }    

}
