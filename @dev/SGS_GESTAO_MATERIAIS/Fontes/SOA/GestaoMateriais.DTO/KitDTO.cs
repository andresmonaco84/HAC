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
    public class KitDataTable : DataTable
    {
        public KitDataTable()
            : base()
        {
            this.TableName = "DADOS";

            this.Columns.Add(KitDTO.FieldNames.IdKit, typeof(decimal));
            this.Columns.Add(KitDTO.FieldNames.IdProduto, typeof(decimal));
            this.Columns.Add(KitDTO.FieldNames.QtdeItem, typeof(decimal));
            this.Columns.Add(KitDTO.FieldNames.Ativo, typeof(decimal));
            this.Columns.Add(KitDTO.FieldNames.Descricao, typeof(String));
            this.Columns.Add(KitDTO.FieldNames.IdSetor, typeof(decimal));
        }

        protected KitDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}

		public KitDTO TypedRow(int index)
        {
            return (KitDTO)this.Rows[index];
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

        public void Add(KitDTO dto)
        {
            DataRow dtr = this.NewRow();

            if (!dto.IdKit.Value.IsNull) dtr[KitDTO.FieldNames.IdKit] = (decimal)dto.IdKit.Value;
            if (!dto.IdProduto.Value.IsNull) dtr[KitDTO.FieldNames.IdProduto] = (decimal)dto.IdProduto.Value;
            if (!dto.QtdeItem.Value.IsNull) dtr[KitDTO.FieldNames.QtdeItem] = (decimal)dto.QtdeItem.Value;
            if (!dto.Ativo.Value.IsNull) dtr[KitDTO.FieldNames.Ativo] = (decimal)dto.Ativo.Value;
            if (!dto.Descricao.Value.IsNull) dtr[KitDTO.FieldNames.Descricao] = (String)dto.Descricao.Value;
            if (!dto.IdSetor.Value.IsNull) dtr[KitDTO.FieldNames.IdSetor] = (decimal)dto.IdSetor.Value;

            this.Rows.Add(dtr);
        }
    }

    [Serializable()]
    public partial class KitDTO : MVC.DTO.DTOBase
    {
        private MVC.DTO.FieldDecimal cad_mtmd_kit_id;        
        private MVC.DTO.FieldDecimal cad_mtmd_id;
        private MVC.DTO.FieldDecimal cad_mtmd_qtde;
        private MVC.DTO.FieldDecimal cad_mtmd_kit_status;
        private MVC.DTO.FieldString cad_mtmd_kit_dsc;
        private MVC.DTO.FieldDecimal cad_set_id;

        public KitDTO()
        {
            InitializeComponent();
        }

        internal void InitializeComponent()
        {
            this.cad_mtmd_kit_id = new MVC.DTO.FieldDecimal(FieldNames.IdKit, Captions.IdKit, DbType.Decimal);
            this.cad_mtmd_id = new MVC.DTO.FieldDecimal(FieldNames.IdProduto, Captions.IdProduto, DbType.Decimal);
            this.cad_mtmd_qtde = new MVC.DTO.FieldDecimal(FieldNames.QtdeItem, Captions.QtdeItem, DbType.Decimal);
            this.cad_mtmd_kit_status = new MVC.DTO.FieldDecimal(FieldNames.Ativo, Captions.Ativo, DbType.Decimal);
            this.cad_mtmd_kit_dsc = new MVC.DTO.FieldString(FieldNames.Descricao, Captions.Descricao, 100);
            this.cad_set_id = new MVC.DTO.FieldDecimal(FieldNames.IdSetor, Captions.IdSetor, DbType.Decimal);
        }

        #region FieldNames

        public struct FieldNames
        {
            public const string IdKit = "CAD_MTMD_KIT_ID";                        
            public const string IdProduto = "CAD_MTMD_ID";
            public const string QtdeItem = "CAD_MTMD_QTDE";
            public const string Ativo = "CAD_MTMD_KIT_STATUS";
            public const string Descricao = "CAD_MTMD_KIT_DSC";
            public const string IdSetor = "CAD_SET_ID";
        }

        #endregion

        #region Captions

        public struct Captions
        {
            public const string IdKit = "KIT_ID";            
            public const string IdProduto = "MTMD_ID";
            public const string QtdeItem = "QTDE";
            public const string Ativo = "KIT_STATUS";
            public const string Descricao = "KIT_DSC";
            public const string IdSetor = "CAD_SET_ID";
        }

        #endregion

        #region Atributos Publicos

        public MVC.DTO.FieldDecimal IdKit
        {
            get { return cad_mtmd_kit_id; }
            set { cad_mtmd_kit_id = value; }
        }

        public MVC.DTO.FieldDecimal IdProduto
        {
            get { return cad_mtmd_id; }
            set { cad_mtmd_id = value; }
        }

        public MVC.DTO.FieldDecimal QtdeItem
        {
            get { return cad_mtmd_qtde; }
            set { cad_mtmd_qtde = value; }
        }

        public MVC.DTO.FieldDecimal Ativo
        {
            get { return cad_mtmd_kit_status; }
            set { cad_mtmd_kit_status = value; }
        }

        public MVC.DTO.FieldString Descricao
        {
            get { return cad_mtmd_kit_dsc; }
            set { cad_mtmd_kit_dsc = value; }
        }

        public MVC.DTO.FieldDecimal IdSetor
        {
            get { return cad_set_id; }
            set { cad_set_id = value; }
        }

        #endregion

        #region Operators

        public static explicit operator KitDTO(DataRow row)
        {
            KitDTO dto = new KitDTO();

            dto.IdKit.Value = row[FieldNames.IdKit].ToString();

            dto.IdProduto.Value = row[FieldNames.IdProduto].ToString();

            dto.QtdeItem.Value = row[FieldNames.QtdeItem].ToString();

            dto.Ativo.Value = row[FieldNames.Ativo].ToString();

            dto.Descricao.Value = row[FieldNames.Descricao].ToString();

            dto.IdSetor.Value = row[FieldNames.IdSetor].ToString();

            return dto;
        }

        public static explicit operator DataRow(KitDTO dto)
        {
            KitDataTable dtb = new KitDataTable();
            DataRow dtr = dtb.NewRow();

            dtr[FieldNames.IdKit] = dto.IdKit.Value;

            dtr[FieldNames.IdProduto] = dto.IdProduto.Value;

            dtr[FieldNames.QtdeItem] = dto.QtdeItem.Value;

            dtr[FieldNames.Ativo] = dto.Ativo.Value;

            dtr[FieldNames.Descricao] = dto.Descricao.Value;

            dtr[FieldNames.IdSetor] = dto.IdSetor.Value;

            return dtr;
        }

        #endregion
    }
}
