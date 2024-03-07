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
    public class DoencaDiagnosticoDataTable : DataTable
    {
        public DoencaDiagnosticoDataTable()
            : base()
        {
            this.TableName = "DADOS";

            this.Columns.Add(DoencaDiagnosticoDTO.FieldNames.Id, typeof(decimal));
            this.Columns.Add(DoencaDiagnosticoDTO.FieldNames.Tipo, typeof(String));
            this.Columns.Add(DoencaDiagnosticoDTO.FieldNames.Descricao, typeof(String));
            this.Columns.Add(DoencaDiagnosticoDTO.FieldNames.IdUsuario, typeof(decimal));
        }

        protected DoencaDiagnosticoDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }

        public DoencaDiagnosticoDTO TypedRow(int index)
        {
            return (DoencaDiagnosticoDTO)this.Rows[index];
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

        public void Add(DoencaDiagnosticoDTO dto)
        {
            DataRow dtr = this.NewRow();

            if (!dto.Id.Value.IsNull) dtr[DoencaDiagnosticoDTO.FieldNames.Id] = (decimal)dto.Id.Value;
            if (!dto.Tipo.Value.IsNull) dtr[DoencaDiagnosticoDTO.FieldNames.Tipo] = (String)dto.Tipo.Value;
            if (!dto.Descricao.Value.IsNull) dtr[DoencaDiagnosticoDTO.FieldNames.Descricao] = (String)dto.Descricao.Value;
            if (!dto.IdUsuario.Value.IsNull) dtr[DoencaDiagnosticoDTO.FieldNames.IdUsuario] = (decimal)dto.IdUsuario.Value;

            this.Rows.Add(dtr);
        }
    }

    [Serializable()]
    public partial class DoencaDiagnosticoDTO : MVC.DTO.DTOBase
    {
        private MVC.DTO.FieldDecimal cad_mtmd_dodi_id;
        private MVC.DTO.FieldString cad_mtmd_dodi_tipo;
        private MVC.DTO.FieldString cad_mtmd_dodi_dsc;
        private MVC.DTO.FieldDecimal seg_usu_id_usuario;        

        public DoencaDiagnosticoDTO()
        {
            InitializeComponent();
        }        

        internal void InitializeComponent()
        {
            this.cad_mtmd_dodi_id = new MVC.DTO.FieldDecimal(FieldNames.Id, Captions.Id, DbType.Decimal);
            this.cad_mtmd_dodi_tipo = new MVC.DTO.FieldString(FieldNames.Tipo, Captions.Tipo, 2);
            this.cad_mtmd_dodi_dsc = new MVC.DTO.FieldString(FieldNames.Descricao, Captions.Descricao, 150);
            this.seg_usu_id_usuario = new MVC.DTO.FieldDecimal(FieldNames.IdUsuario, Captions.IdUsuario, DbType.Decimal);
        }

        #region FieldNames

        public struct FieldNames
        {
            public const string Id = "CAD_MTMD_DODI_ID";
            public const string Tipo = "CAD_MTMD_DODI_TIPO";
            public const string Descricao = "CAD_MTMD_DODI_DSC";
            public const string IdUsuario = "SEG_USU_ID_USUARIO";
        }

        #endregion

        #region Captions

        public struct Captions
        {
            public const string Id = "CAD_MTMD_DODI_ID";
            public const string Tipo = "CAD_MTMD_DODI_TIPO";
            public const string Descricao = "CAD_MTMD_DODI_DSC";
            public const string IdUsuario = "SEG_USU_ID_USUARIO";
        }

        #endregion

        #region Atributos Publicos

        public MVC.DTO.FieldDecimal Id
        {
            get { return cad_mtmd_dodi_id; }
            set { cad_mtmd_dodi_id = value; }
        }

        public MVC.DTO.FieldString Tipo
        {
            get { return cad_mtmd_dodi_tipo; }
            set { cad_mtmd_dodi_tipo = value; }
        }

        public MVC.DTO.FieldString Descricao
        {
            get { return cad_mtmd_dodi_dsc; }
            set { cad_mtmd_dodi_dsc = value; }
        }

        public MVC.DTO.FieldDecimal IdUsuario
        {
            get { return seg_usu_id_usuario; }
            set { seg_usu_id_usuario = value; }
        }

        #endregion

        #region Operators

        public static explicit operator DoencaDiagnosticoDTO(DataRow row)
        {
            DoencaDiagnosticoDTO dto = new DoencaDiagnosticoDTO();

            dto.Id.Value = row[FieldNames.Id].ToString();

            dto.Tipo.Value = row[FieldNames.Tipo].ToString();

            dto.Descricao.Value = row[FieldNames.Descricao].ToString();

            dto.IdUsuario.Value = row[FieldNames.IdUsuario].ToString();            

            return dto;
        }

        public static explicit operator DataRow(DoencaDiagnosticoDTO dto)
        {
            DoencaDiagnosticoDataTable dtb = new DoencaDiagnosticoDataTable();
            DataRow dtr = dtb.NewRow();

            dtr[FieldNames.Id] = dto.Id.Value;

            dtr[FieldNames.Tipo] = dto.Tipo.Value;

            dtr[FieldNames.Descricao] = dto.Tipo.Value;

            dtr[FieldNames.IdUsuario] = dto.IdUsuario.Value;            

            return dtr;
        }

        #endregion
    }
}