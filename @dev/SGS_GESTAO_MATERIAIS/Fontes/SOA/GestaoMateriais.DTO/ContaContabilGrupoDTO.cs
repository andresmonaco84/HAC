
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
    /// Classe Entidade ContaContabilGrupoDataTable
    /// </summary>
    [Serializable()]
    public class ContaContabilGrupoDataTable : DataTable
    {

        public ContaContabilGrupoDataTable()
            : base()
        {

            this.TableName = "ContaContabilGrupo";

            this.Columns.Add(ContaContabilGrupoDTO.FieldNames.TipoMov, typeof(String));
            this.Columns.Add(ContaContabilGrupoDTO.FieldNames.IdGrupo, typeof(Decimal));
            this.Columns.Add(ContaContabilGrupoDTO.FieldNames.DataIni, typeof(DateTime));
            this.Columns.Add(ContaContabilGrupoDTO.FieldNames.DataFim, typeof(DateTime));
            this.Columns.Add(ContaContabilGrupoDTO.FieldNames.CodColigada, typeof(Decimal));
            this.Columns.Add(ContaContabilGrupoDTO.FieldNames.IdSetor, typeof(Decimal));
            this.Columns.Add(ContaContabilGrupoDTO.FieldNames.ContaCredito, typeof(String));
            this.Columns.Add(ContaContabilGrupoDTO.FieldNames.ContaCreditoDescricao, typeof(String));
            this.Columns.Add(ContaContabilGrupoDTO.FieldNames.ContaDebito, typeof(String));
            this.Columns.Add(ContaContabilGrupoDTO.FieldNames.ContaDebitoDescricao, typeof(String));
            this.Columns.Add(ContaContabilGrupoDTO.FieldNames.DataAtualizacao, typeof(DateTime));
            this.Columns.Add(ContaContabilGrupoDTO.FieldNames.IdUsuario, typeof(Decimal));

            //DataColumn[] primaryKey = { this.Columns[ContaContabilGrupoDTO.FieldNames.CodColigada], this.Columns[ContaContabilGrupoDTO.FieldNames.DataIni], this.Columns[ContaContabilGrupoDTO.FieldNames.IdGrupo], this.Columns[ContaContabilGrupoDTO.FieldNames.TipoMov], this.Columns[ContaContabilGrupoDTO.FieldNames.IdSetor] };

            //this.PrimaryKey = primaryKey;
        }

        protected ContaContabilGrupoDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }


        public ContaContabilGrupoDTO TypedRow(int index)
        {
            return (ContaContabilGrupoDTO)this.Rows[index];
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

        public void Add(ContaContabilGrupoDTO dto)
        {
            DataRow dtr = this.NewRow();


            if (!dto.TipoMov.Value.IsNull) dtr[ContaContabilGrupoDTO.FieldNames.TipoMov] = (String)dto.TipoMov.Value;
            if (!dto.IdGrupo.Value.IsNull) dtr[ContaContabilGrupoDTO.FieldNames.IdGrupo] = (Decimal)dto.IdGrupo.Value;
            if (!dto.DataIni.Value.IsNull) dtr[ContaContabilGrupoDTO.FieldNames.DataIni] = (DateTime)dto.DataIni.Value;
            if (!dto.DataFim.Value.IsNull) dtr[ContaContabilGrupoDTO.FieldNames.DataFim] = (DateTime)dto.DataFim.Value;
            if (!dto.CodColigada.Value.IsNull) dtr[ContaContabilGrupoDTO.FieldNames.CodColigada] = (Decimal)dto.CodColigada.Value;
            if (!dto.IdSetor.Value.IsNull) dtr[ContaContabilGrupoDTO.FieldNames.IdSetor] = (Decimal)dto.IdSetor.Value;
            if (!dto.ContaCredito.Value.IsNull) dtr[ContaContabilGrupoDTO.FieldNames.ContaCredito] = (String)dto.ContaCredito.Value;
            if (!dto.ContaCreditoDescricao.Value.IsNull) dtr[ContaContabilGrupoDTO.FieldNames.ContaCreditoDescricao] = (String)dto.ContaCreditoDescricao.Value;
            if (!dto.ContaDebito.Value.IsNull) dtr[ContaContabilGrupoDTO.FieldNames.ContaDebito] = (String)dto.ContaDebito.Value;
            if (!dto.ContaDebitoDescricao.Value.IsNull) dtr[ContaContabilGrupoDTO.FieldNames.ContaDebitoDescricao] = (String)dto.ContaDebitoDescricao.Value;
            if (!dto.DataAtualizacao.Value.IsNull) dtr[ContaContabilGrupoDTO.FieldNames.DataAtualizacao] = (DateTime)dto.DataAtualizacao.Value;
            if (!dto.IdUsuario.Value.IsNull) dtr[ContaContabilGrupoDTO.FieldNames.IdUsuario] = (Decimal)dto.IdUsuario.Value;


            this.Rows.Add(dtr);
        }

        public ContaContabilGrupoEnumerator GetEnumerator()
        {
            return new ContaContabilGrupoEnumerator(this);
        }
    }

    // Inner class implements IEnumerator interface:
    public class ContaContabilGrupoEnumerator
    {
        private int position = -1;
        private DataTable dtb;

        public ContaContabilGrupoEnumerator(DataTable dtb)
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
        public ContaContabilGrupoDTO Current
        {
            get
            {
                ContaContabilGrupoDTO dto = new ContaContabilGrupoDTO();
                dto.TipoMov.Value = dtb.Rows[position][ContaContabilGrupoDTO.FieldNames.TipoMov].ToString();
                dto.IdGrupo.Value = dtb.Rows[position][ContaContabilGrupoDTO.FieldNames.IdGrupo].ToString();
                dto.DataIni.Value = dtb.Rows[position][ContaContabilGrupoDTO.FieldNames.DataIni].ToString();
                dto.DataFim.Value = dtb.Rows[position][ContaContabilGrupoDTO.FieldNames.DataFim].ToString();
                dto.CodColigada.Value = dtb.Rows[position][ContaContabilGrupoDTO.FieldNames.CodColigada].ToString();
                dto.IdSetor.Value = dtb.Rows[position][ContaContabilGrupoDTO.FieldNames.IdSetor].ToString();
                dto.ContaCredito.Value = dtb.Rows[position][ContaContabilGrupoDTO.FieldNames.ContaCredito].ToString();
                dto.ContaCreditoDescricao.Value = dtb.Rows[position][ContaContabilGrupoDTO.FieldNames.ContaCreditoDescricao].ToString();
                dto.ContaDebito.Value = dtb.Rows[position][ContaContabilGrupoDTO.FieldNames.ContaDebito].ToString();
                dto.ContaDebitoDescricao.Value = dtb.Rows[position][ContaContabilGrupoDTO.FieldNames.ContaDebitoDescricao].ToString();
                dto.DataAtualizacao.Value = dtb.Rows[position][ContaContabilGrupoDTO.FieldNames.DataAtualizacao].ToString();
                dto.IdUsuario.Value = dtb.Rows[position][ContaContabilGrupoDTO.FieldNames.IdUsuario].ToString();

                return dto;
            }
        }
    }

    [Serializable()]
    public class ContaContabilGrupoDTO : MVC.DTO.DTOBase
    {
        private MVC.DTO.FieldString cad_mtmd_tipo_mov;
        private MVC.DTO.FieldDecimal cad_mtmd_grupo_id;
        private MVC.DTO.FieldDateTime cad_mtmd_dt_ini_vig;
        private MVC.DTO.FieldDateTime cad_mtmd_dt_fim_vig;
        private MVC.DTO.FieldDecimal cad_mtmd_cod_coligada;
        private MVC.DTO.FieldDecimal cad_set_id;
        private MVC.DTO.FieldString cad_cod_conta_cred;
        private MVC.DTO.FieldString cad_cod_conta_cred_descricao;
        private MVC.DTO.FieldString cad_cod_conta_deb;
        private MVC.DTO.FieldString cad_cod_conta_deb_descricao;
        private MVC.DTO.FieldDateTime seg_dt_atualizacao;
        private MVC.DTO.FieldDecimal seg_usu_id_usuario;


        public ContaContabilGrupoDTO()
        {
            InitializeComponent();
        }

        internal void InitializeComponent()
        {
            this.cad_mtmd_tipo_mov = new MVC.DTO.FieldString(FieldNames.TipoMov, Captions.TipoMov, 1);
            this.cad_mtmd_grupo_id = new MVC.DTO.FieldDecimal(FieldNames.IdGrupo, Captions.IdGrupo, DbType.Decimal);
            this.cad_mtmd_dt_ini_vig = new MVC.DTO.FieldDateTime(FieldNames.DataIni, Captions.DataIni);
            this.cad_mtmd_dt_fim_vig = new MVC.DTO.FieldDateTime(FieldNames.DataFim, Captions.DataFim);
            this.cad_mtmd_cod_coligada = new MVC.DTO.FieldDecimal(FieldNames.CodColigada, Captions.CodColigada, DbType.Decimal);
            this.cad_set_id = new MVC.DTO.FieldDecimal(FieldNames.IdSetor, Captions.IdSetor, DbType.Decimal);
            this.cad_cod_conta_cred = new MVC.DTO.FieldString(FieldNames.ContaCredito, Captions.ContaCredito, 20);
            this.cad_cod_conta_cred_descricao = new MVC.DTO.FieldString(FieldNames.ContaCreditoDescricao, Captions.ContaCreditoDescricao, 50);
            this.cad_cod_conta_deb = new MVC.DTO.FieldString(FieldNames.ContaDebito, Captions.ContaDebito, 20);
            this.cad_cod_conta_deb_descricao = new MVC.DTO.FieldString(FieldNames.ContaDebitoDescricao, Captions.ContaDebitoDescricao, 50);
            this.seg_dt_atualizacao = new MVC.DTO.FieldDateTime(FieldNames.DataAtualizacao, Captions.DataAtualizacao);
            this.seg_usu_id_usuario = new MVC.DTO.FieldDecimal(FieldNames.IdUsuario, Captions.IdUsuario, DbType.Decimal);

        }

        #region FieldNames

        public struct FieldNames
        {
            public const string TipoMov = "CAD_MTMD_TIPO_MOV";
            public const string IdGrupo = "CAD_MTMD_GRUPO_ID";
            public const string DataIni = "CAD_MTMD_DT_INI_VIG";
            public const string DataFim = "CAD_MTMD_DT_FIM_VIG";
            public const string CodColigada = "CAD_MTMD_COD_COLIGADA";
            public const string IdSetor = "CAD_SET_ID";
            public const string ContaCredito = "CAD_COD_CONTA_CRED";
            public const string ContaCreditoDescricao = "CAD_COD_CONTA_CRED_DESCRICAO";
            public const string ContaDebito = "CAD_COD_CONTA_DEB";
            public const string ContaDebitoDescricao = "CAD_COD_CONTA_DEB_DESCRICAO";
            public const string DataAtualizacao = "SEG_DT_ATUALIZACAO";
            public const string IdUsuario = "SEG_USU_ID_USUARIO";

        }

        #endregion

        #region Captions
        public struct Captions
        {
            public const string TipoMov = "TIPOMOV";
            public const string IdGrupo = "IDGRUPO";
            public const string DataIni = "DATAINI";
            public const string DataFim = "DATAFIM";
            public const string CodColigada = "CODCOLIGADA";
            public const string IdSetor = "IDSETOR";
            public const string ContaCredito = "CONTACREDITO";
            public const string ContaCreditoDescricao = "CONTACREDITODESCRICAO";
            public const string ContaDebito = "CONTADEBITO";
            public const string ContaDebitoDescricao = "CONTADEBITODESCRICAO";
            public const string DataAtualizacao = "DATAATUALIZACAO";
            public const string IdUsuario = "IDUSUARIO";

        }

        #endregion

        #region Atributos Publicos



        public MVC.DTO.FieldString TipoMov
        {
            get { return cad_mtmd_tipo_mov; }
            set { cad_mtmd_tipo_mov = value; }
        }


        public MVC.DTO.FieldDecimal IdGrupo
        {
            get { return cad_mtmd_grupo_id; }
            set { cad_mtmd_grupo_id = value; }
        }


        public MVC.DTO.FieldDateTime DataIni
        {
            get { return cad_mtmd_dt_ini_vig; }
            set { cad_mtmd_dt_ini_vig = value; }
        }


        public MVC.DTO.FieldDateTime DataFim
        {
            get { return cad_mtmd_dt_fim_vig; }
            set { cad_mtmd_dt_fim_vig = value; }
        }


        public MVC.DTO.FieldDecimal CodColigada
        {
            get { return cad_mtmd_cod_coligada; }
            set { cad_mtmd_cod_coligada = value; }
        }


        public MVC.DTO.FieldDecimal IdSetor
        {
            get { return cad_set_id; }
            set { cad_set_id = value; }
        }


        public MVC.DTO.FieldString ContaCredito
        {
            get { return cad_cod_conta_cred; }
            set { cad_cod_conta_cred = value; }
        }


        public MVC.DTO.FieldString ContaCreditoDescricao
        {
            get { return cad_cod_conta_cred_descricao; }
            set { cad_cod_conta_cred_descricao = value; }
        }


        public MVC.DTO.FieldString ContaDebito
        {
            get { return cad_cod_conta_deb; }
            set { cad_cod_conta_deb = value; }
        }


        public MVC.DTO.FieldString ContaDebitoDescricao
        {
            get { return cad_cod_conta_deb_descricao; }
            set { cad_cod_conta_deb_descricao = value; }
        }


        public MVC.DTO.FieldDateTime DataAtualizacao
        {
            get { return seg_dt_atualizacao; }
            set { seg_dt_atualizacao = value; }
        }


        public MVC.DTO.FieldDecimal IdUsuario
        {
            get { return seg_usu_id_usuario; }
            set { seg_usu_id_usuario = value; }
        }


        #endregion


        #region Operators

        public static explicit operator ContaContabilGrupoDTO(DataRow row)
        {
            ContaContabilGrupoDTO dto = new ContaContabilGrupoDTO();
            dto.TipoMov.Value = row[FieldNames.TipoMov].ToString();
            dto.IdGrupo.Value = row[FieldNames.IdGrupo].ToString();
            dto.DataIni.Value = row[FieldNames.DataIni].ToString();
            dto.DataFim.Value = row[FieldNames.DataFim].ToString();
            dto.CodColigada.Value = row[FieldNames.CodColigada].ToString();
            dto.IdSetor.Value = row[FieldNames.IdSetor].ToString();
            dto.ContaCredito.Value = row[FieldNames.ContaCredito].ToString();
            dto.ContaCreditoDescricao.Value = row[FieldNames.ContaCreditoDescricao].ToString();
            dto.ContaDebito.Value = row[FieldNames.ContaDebito].ToString();
            dto.ContaDebitoDescricao.Value = row[FieldNames.ContaDebitoDescricao].ToString();
            dto.DataAtualizacao.Value = row[FieldNames.DataAtualizacao].ToString();
            dto.IdUsuario.Value = row[FieldNames.IdUsuario].ToString();


            return dto;
        }

        public static explicit operator ContaContabilGrupoDTO(XmlDocument xml)
        {
            ContaContabilGrupoDTO dto = new ContaContabilGrupoDTO();
            if (xml.FirstChild.SelectSingleNode(FieldNames.TipoMov) != null) dto.TipoMov.Value = xml.FirstChild.SelectSingleNode(FieldNames.TipoMov).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdGrupo) != null) dto.IdGrupo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdGrupo).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DataIni) != null) dto.DataIni.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataIni).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DataFim) != null) dto.DataFim.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataFim).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.CodColigada) != null) dto.CodColigada.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodColigada).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdSetor) != null) dto.IdSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdSetor).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.ContaCredito) != null) dto.ContaCredito.Value = xml.FirstChild.SelectSingleNode(FieldNames.ContaCredito).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.ContaCreditoDescricao) != null) dto.ContaCreditoDescricao.Value = xml.FirstChild.SelectSingleNode(FieldNames.ContaCreditoDescricao).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.ContaDebito) != null) dto.ContaDebito.Value = xml.FirstChild.SelectSingleNode(FieldNames.ContaDebito).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.ContaDebitoDescricao) != null) dto.ContaDebitoDescricao.Value = xml.FirstChild.SelectSingleNode(FieldNames.ContaDebitoDescricao).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizacao) != null) dto.DataAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizacao).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdUsuario) != null) dto.IdUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdUsuario).InnerText;

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
            XmlNode nodeTipoMov = xml.CreateNode(XmlNodeType.Element, FieldNames.TipoMov, null);
            XmlNode nodeIdGrupo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdGrupo, null);
            XmlNode nodeDataIni = xml.CreateNode(XmlNodeType.Element, FieldNames.DataIni, null);
            XmlNode nodeDataFim = xml.CreateNode(XmlNodeType.Element, FieldNames.DataFim, null);
            XmlNode nodeCodColigada = xml.CreateNode(XmlNodeType.Element, FieldNames.CodColigada, null);
            XmlNode nodeIdSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdSetor, null);
            XmlNode nodeContaCredito = xml.CreateNode(XmlNodeType.Element, FieldNames.ContaCredito, null);
            XmlNode nodeContaCreditoDescricao = xml.CreateNode(XmlNodeType.Element, FieldNames.ContaCreditoDescricao, null);
            XmlNode nodeContaDebito = xml.CreateNode(XmlNodeType.Element, FieldNames.ContaDebito, null);
            XmlNode nodeContaDebitoDescricao = xml.CreateNode(XmlNodeType.Element, FieldNames.ContaDebitoDescricao, null);
            XmlNode nodeDataAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DataAtualizacao, null);
            XmlNode nodeIdUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdUsuario, null);

            if (!this.TipoMov.Value.IsNull) nodeTipoMov.InnerText = this.TipoMov.Value;
            if (!this.IdGrupo.Value.IsNull) nodeIdGrupo.InnerText = this.IdGrupo.Value;
            if (!this.DataIni.Value.IsNull) nodeDataIni.InnerText = this.DataIni.Value;
            if (!this.DataFim.Value.IsNull) nodeDataFim.InnerText = this.DataFim.Value;
            if (!this.CodColigada.Value.IsNull) nodeCodColigada.InnerText = this.CodColigada.Value;
            if (!this.IdSetor.Value.IsNull) nodeIdSetor.InnerText = this.IdSetor.Value;
            if (!this.ContaCredito.Value.IsNull) nodeContaCredito.InnerText = this.ContaCredito.Value;
            if (!this.ContaCreditoDescricao.Value.IsNull) nodeContaCreditoDescricao.InnerText = this.ContaCreditoDescricao.Value;
            if (!this.ContaDebito.Value.IsNull) nodeContaDebito.InnerText = this.ContaDebito.Value;
            if (!this.ContaDebitoDescricao.Value.IsNull) nodeContaDebitoDescricao.InnerText = this.ContaDebitoDescricao.Value;
            if (!this.DataAtualizacao.Value.IsNull) nodeDataAtualizacao.InnerText = this.DataAtualizacao.Value;
            if (!this.IdUsuario.Value.IsNull) nodeIdUsuario.InnerText = this.IdUsuario.Value;

            nodeData.AppendChild(nodeTipoMov);
            nodeData.AppendChild(nodeIdGrupo);
            nodeData.AppendChild(nodeDataIni);
            nodeData.AppendChild(nodeDataFim);
            nodeData.AppendChild(nodeCodColigada);
            nodeData.AppendChild(nodeIdSetor);
            nodeData.AppendChild(nodeContaCredito);
            nodeData.AppendChild(nodeContaCreditoDescricao);
            nodeData.AppendChild(nodeContaDebito);
            nodeData.AppendChild(nodeContaDebitoDescricao);
            nodeData.AppendChild(nodeDataAtualizacao);
            nodeData.AppendChild(nodeIdUsuario);

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(ContaContabilGrupoDTO dto)
        {
            ContaContabilGrupoDataTable dtb = new ContaContabilGrupoDataTable();
            DataRow dtr = dtb.NewRow();
            dtr[FieldNames.TipoMov] = dto.TipoMov.Value;
            dtr[FieldNames.IdGrupo] = dto.IdGrupo.Value;
            dtr[FieldNames.DataIni] = dto.DataIni.Value;
            dtr[FieldNames.DataFim] = dto.DataFim.Value;
            dtr[FieldNames.CodColigada] = dto.CodColigada.Value;
            dtr[FieldNames.IdSetor] = dto.IdSetor.Value;
            dtr[FieldNames.ContaCredito] = dto.ContaCredito.Value;
            dtr[FieldNames.ContaCreditoDescricao] = dto.ContaCreditoDescricao.Value;
            dtr[FieldNames.ContaDebito] = dto.ContaDebito.Value;
            dtr[FieldNames.ContaDebitoDescricao] = dto.ContaDebitoDescricao.Value;
            dtr[FieldNames.DataAtualizacao] = dto.DataAtualizacao.Value;
            dtr[FieldNames.IdUsuario] = dto.IdUsuario.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(ContaContabilGrupoDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}

