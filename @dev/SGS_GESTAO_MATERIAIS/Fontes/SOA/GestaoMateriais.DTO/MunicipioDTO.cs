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
    /// <summary>
    /// Classe Entidade MunicipioDataTable
    /// </summary>
    [Serializable()]
    public class MunicipioDataTable : DataTable
    {

        public MunicipioDataTable()
            : base()
        {

            this.TableName = "DADOS";

            this.Columns.Add(MunicipioDTO.FieldNames.CodigoIBGE, typeof(String));
            this.Columns.Add(MunicipioDTO.FieldNames.SiglaUF, typeof(String));
            this.Columns.Add(MunicipioDTO.FieldNames.NomeMunicipio, typeof(String));




            DataColumn[] primaryKey = { this.Columns[MunicipioDTO.FieldNames.CodigoIBGE] };

            this.PrimaryKey = primaryKey;
        }

        protected MunicipioDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }


        public MunicipioDTO TypedRow(int index)
        {
            return (MunicipioDTO)this.Rows[index];
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

        public void Add(MunicipioDTO dto)
        {
            DataRow dtr = this.NewRow();


            if (!dto.CodigoIBGE.Value.IsNull) dtr[MunicipioDTO.FieldNames.CodigoIBGE] = (String)dto.CodigoIBGE.Value;
            if (!dto.SiglaUF.Value.IsNull) dtr[MunicipioDTO.FieldNames.SiglaUF] = (String)dto.SiglaUF.Value;
            if (!dto.NomeMunicipio.Value.IsNull) dtr[MunicipioDTO.FieldNames.NomeMunicipio] = (String)dto.NomeMunicipio.Value;


            this.Rows.Add(dtr);
        }

        public MunicipioEnumerator GetEnumerator()
        {
            return new MunicipioEnumerator(this);
        }
    }

    // Inner class implements IEnumerator interface:
    public class MunicipioEnumerator
    {
        private int position = -1;
        private DataTable dtb;

        public MunicipioEnumerator(DataTable dtb)
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
        public MunicipioDTO Current
        {
            get
            {
                MunicipioDTO dto = new MunicipioDTO();
                dto.CodigoIBGE.Value = dtb.Rows[position][MunicipioDTO.FieldNames.CodigoIBGE].ToString();
                dto.SiglaUF.Value = dtb.Rows[position][MunicipioDTO.FieldNames.SiglaUF].ToString();
                dto.NomeMunicipio.Value = dtb.Rows[position][MunicipioDTO.FieldNames.NomeMunicipio].ToString();

                return dto;
            }
        }
    }

    [Serializable()]
    public class MunicipioDTO : MVC.DTO.DTOBase
    {
        private MVC.DTO.FieldString aux_mun_cd_ibge;
        private MVC.DTO.FieldString aux_mun_sg_uf;
        private MVC.DTO.FieldString aux_mun_nm_municipio;


        public MunicipioDTO()
        {
            InitializeComponent();
        }

        internal void InitializeComponent()
        {
            this.aux_mun_cd_ibge = new MVC.DTO.FieldString(FieldNames.CodigoIBGE, Captions.CodigoIBGE, 7);
            this.aux_mun_sg_uf = new MVC.DTO.FieldString(FieldNames.SiglaUF, Captions.SiglaUF, 2);
            this.aux_mun_nm_municipio = new MVC.DTO.FieldString(FieldNames.NomeMunicipio, Captions.NomeMunicipio, 50);

        }

        #region FieldNames

        public struct FieldNames
        {
            public const string CodigoIBGE = "AUX_MUN_CD_IBGE";
            public const string SiglaUF = "AUX_MUN_SG_UF";
            public const string NomeMunicipio = "AUX_MUN_NM_MUNICIPIO";

        }

        #endregion

        #region Captions
        public struct Captions
        {
            public const string CodigoIBGE = "CODIGOIBGE";
            public const string SiglaUF = "SIGLAUF";
            public const string NomeMunicipio = "NOMEMUNICIPIO";

        }

        #endregion

        #region Atributos Publicos



        public MVC.DTO.FieldString CodigoIBGE
        {
            get { return aux_mun_cd_ibge; }
            set { aux_mun_cd_ibge = value; }
        }


        public MVC.DTO.FieldString SiglaUF
        {
            get { return aux_mun_sg_uf; }
            set { aux_mun_sg_uf = value; }
        }


        public MVC.DTO.FieldString NomeMunicipio
        {
            get { return aux_mun_nm_municipio; }
            set { aux_mun_nm_municipio = value; }
        }


        #endregion


        #region Operators

        public static explicit operator MunicipioDTO(DataRow row)
        {
            MunicipioDTO dto = new MunicipioDTO();
            dto.CodigoIBGE.Value = row[FieldNames.CodigoIBGE].ToString();
            dto.SiglaUF.Value = row[FieldNames.SiglaUF].ToString();
            dto.NomeMunicipio.Value = row[FieldNames.NomeMunicipio].ToString();


            return dto;
        }

        public static explicit operator MunicipioDTO(XmlDocument xml)
        {
            MunicipioDTO dto = new MunicipioDTO();
            if (xml.FirstChild.SelectSingleNode(FieldNames.CodigoIBGE) != null) dto.CodigoIBGE.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodigoIBGE).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.SiglaUF) != null) dto.SiglaUF.Value = xml.FirstChild.SelectSingleNode(FieldNames.SiglaUF).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.NomeMunicipio) != null) dto.NomeMunicipio.Value = xml.FirstChild.SelectSingleNode(FieldNames.NomeMunicipio).InnerText;

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
            XmlNode nodeCodigoIBGE = xml.CreateNode(XmlNodeType.Element, FieldNames.CodigoIBGE, null);
            XmlNode nodeSiglaUF = xml.CreateNode(XmlNodeType.Element, FieldNames.SiglaUF, null);
            XmlNode nodeNomeMunicipio = xml.CreateNode(XmlNodeType.Element, FieldNames.NomeMunicipio, null);

            if (!this.CodigoIBGE.Value.IsNull) nodeCodigoIBGE.InnerText = this.CodigoIBGE.Value;
            if (!this.SiglaUF.Value.IsNull) nodeSiglaUF.InnerText = this.SiglaUF.Value;
            if (!this.NomeMunicipio.Value.IsNull) nodeNomeMunicipio.InnerText = this.NomeMunicipio.Value;

            nodeData.AppendChild(nodeCodigoIBGE);
            nodeData.AppendChild(nodeSiglaUF);
            nodeData.AppendChild(nodeNomeMunicipio);

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(MunicipioDTO dto)
        {
            MunicipioDataTable dtb = new MunicipioDataTable();
            DataRow dtr = dtb.NewRow();
            dtr[FieldNames.CodigoIBGE] = dto.CodigoIBGE.Value;
            dtr[FieldNames.SiglaUF] = dto.SiglaUF.Value;
            dtr[FieldNames.NomeMunicipio] = dto.NomeMunicipio.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(MunicipioDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}