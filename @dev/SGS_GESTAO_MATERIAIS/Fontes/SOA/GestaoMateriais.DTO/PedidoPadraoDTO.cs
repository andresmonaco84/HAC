
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
	/// Classe Entidade PedidoPadraoDataTable
	/// </summary>
	[Serializable()]
	public class PedidoPadraoDataTable : DataTable
	{
		
	    public PedidoPadraoDataTable()
            : base()
        {
            this.TableName = "DADOS";

		    this.Columns.Add(PedidoPadraoDTO.FieldNames.Idt, typeof(Decimal));
		    this.Columns.Add(PedidoPadraoDTO.FieldNames.IdtLocal, typeof(Decimal));
		    this.Columns.Add(PedidoPadraoDTO.FieldNames.IdtUnidade, typeof(Decimal));
		    this.Columns.Add(PedidoPadraoDTO.FieldNames.IdtSetor, typeof(Decimal));
		    this.Columns.Add(PedidoPadraoDTO.FieldNames.IdtFilial, typeof(Decimal));
            this.Columns.Add(PedidoPadraoDTO.FieldNames.IdtUsuario, typeof(Decimal));
            this.Columns.Add(PedidoPadraoDTO.FieldNames.Periodo, typeof(Decimal));
            this.Columns.Add(PedidoPadraoDTO.FieldNames.Status, typeof(Decimal));
            this.Columns.Add(PedidoPadraoDTO.FieldNames.DataDispensado, typeof(DateTime));
            this.Columns.Add(PedidoPadraoDTO.FieldNames.DataUltimaRequisicao, typeof(DateTime));
            this.Columns.Add(PedidoPadraoDTO.FieldNames.DsSetor, typeof(String));
            this.Columns.Add(PedidoPadraoDTO.FieldNames.DsLocal, typeof(String));
            this.Columns.Add(PedidoPadraoDTO.FieldNames.DsUnidade, typeof(String));

            
            DataColumn[] primaryKey = { this.Columns[PedidoPadraoDTO.FieldNames.Idt] };

            this.PrimaryKey = primaryKey;
        }
		
        protected PedidoPadraoDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public PedidoPadraoDTO TypedRow(int index)
        {
            return (PedidoPadraoDTO)this.Rows[index];
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

        public void Add(PedidoPadraoDTO dto)
        {
            DataRow dtr = this.NewRow();

		    if (!dto.Idt.Value.IsNull) dtr[PedidoPadraoDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		    if (!dto.IdtLocal.Value.IsNull) dtr[PedidoPadraoDTO.FieldNames.IdtLocal] = (Decimal)dto.IdtLocal.Value;
		    if (!dto.IdtUnidade.Value.IsNull) dtr[PedidoPadraoDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;
		    if (!dto.IdtSetor.Value.IsNull) dtr[PedidoPadraoDTO.FieldNames.IdtSetor] = (Decimal)dto.IdtSetor.Value;
		    if (!dto.IdtFilial.Value.IsNull) dtr[PedidoPadraoDTO.FieldNames.IdtFilial] = (Decimal)dto.IdtFilial.Value;
            if (!dto.IdtUsuario.Value.IsNull) dtr[PedidoPadraoDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;
            if (!dto.Periodo.Value.IsNull) dtr[PedidoPadraoDTO.FieldNames.Periodo] = (Decimal)dto.Periodo.Value;
            if (!dto.Status.Value.IsNull) dtr[PedidoPadraoDTO.FieldNames.Status] = (Decimal)dto.Status.Value;
            if (!dto.DataDispensado.Value.IsNull) dtr[PedidoPadraoDTO.FieldNames.DataDispensado] = (DateTime)dto.DataDispensado.Value;
            if (!dto.DataUltimaRequisicao.Value.IsNull) dtr[PedidoPadraoDTO.FieldNames.DataUltimaRequisicao] = (DateTime)dto.DataUltimaRequisicao.Value;
            if (!dto.DsSetor.Value.IsNull) dtr[PedidoPadraoDTO.FieldNames.DsSetor] = (String)dto.DsSetor.Value;
            if (!dto.DsLocal.Value.IsNull) dtr[PedidoPadraoDTO.FieldNames.DsLocal] = (String)dto.DsLocal.Value;
            if (!dto.DsUnidade.Value.IsNull) dtr[PedidoPadraoDTO.FieldNames.DsUnidade] = (String)dto.DsUnidade.Value;
            

            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class PedidoPadraoDTO : MVC.DTO.DTOBase
    {
        public enum StatusPedidoPadrao
        {
            CONFIRMAR = 0,
            CONFIRMADO = 1            
        }

        private MVC.DTO.FieldDecimal mtmd_pepad_id;
		private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
		private MVC.DTO.FieldDecimal cad_uni_id_unidade;
		private MVC.DTO.FieldDecimal cad_set_id;
		private MVC.DTO.FieldDecimal cad_mtmd_filial_id;
        private MVC.DTO.FieldDecimal seg_usu_id_usuario;
        private MVC.DTO.FieldDecimal mtmd_periodo_dias;
        private MVC.DTO.FieldDecimal mtmd_fl_status;
        private MVC.DTO.FieldDateTime mtmd_dt_dispensacao;
        private MVC.DTO.FieldDateTime mtmd_dt_ult_requisicao;
        private MVC.DTO.FieldString cad_set_ds_setor;
        private MVC.DTO.FieldString cad_lat_ds_local_atendimento;
        private MVC.DTO.FieldString cad_uni_ds_unidade;
        

        public PedidoPadraoDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
            this.mtmd_pepad_id = new MVC.DTO.FieldDecimal(FieldNames.Idt, Captions.Idt, DbType.Decimal);
		    this.cad_lat_id_local_atendimento= new MVC.DTO.FieldDecimal(FieldNames.IdtLocal,Captions.IdtLocal, DbType.Decimal);
		    this.cad_uni_id_unidade= new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade,Captions.IdtUnidade, DbType.Decimal);
		    this.cad_set_id= new MVC.DTO.FieldDecimal(FieldNames.IdtSetor,Captions.IdtSetor, DbType.Decimal);
		    this.cad_mtmd_filial_id= new MVC.DTO.FieldDecimal(FieldNames.IdtFilial,Captions.IdtFilial, DbType.Decimal);
            this.seg_usu_id_usuario = new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario, Captions.IdtUsuario, DbType.Decimal);
            this.mtmd_periodo_dias = new MVC.DTO.FieldDecimal(FieldNames.Periodo, Captions.Periodo, DbType.Decimal);
            this.mtmd_fl_status = new MVC.DTO.FieldDecimal(FieldNames.Status, Captions.Status, DbType.Decimal);
            this.mtmd_dt_dispensacao = new MVC.DTO.FieldDateTime(FieldNames.DataDispensado, Captions.DataDispensado);
            this.mtmd_dt_ult_requisicao = new MVC.DTO.FieldDateTime(FieldNames.DataUltimaRequisicao, Captions.DataUltimaRequisicao);
            this.cad_lat_ds_local_atendimento = new MVC.DTO.FieldString(FieldNames.DsLocal, Captions.DsLocal);
            this.cad_set_ds_setor = new MVC.DTO.FieldString(FieldNames.DsSetor, Captions.DsSetor);
            this.cad_uni_ds_unidade = new MVC.DTO.FieldString(FieldNames.DsUnidade, Captions.DsUnidade);
            

        }
 
        #region FieldNames

        public struct FieldNames
        {
            public const string Idt = "MTMD_PEDPAD_ID";
		    public const string IdtLocal="CAD_LAT_ID_LOCAL_ATENDIMENTO";
		    public const string IdtUnidade="CAD_UNI_ID_UNIDADE";
		    public const string IdtSetor="CAD_SET_ID";
		    public const string IdtFilial="CAD_MTMD_FILIAL_ID";
            public const string IdtUsuario = "SEG_USU_ID_USUARIO";
            public const string Periodo = "MTMD_PERIODO_DIAS";
            public const string Status = "MTMD_FL_STATUS";
            public const string DataDispensado = "MTMD_DT_DISPENSACAO";
            public const string DataUltimaRequisicao = "MTMD_DT_ULT_REQUISICAO";
            public const string DsSetor = "CAD_SET_DS_SETOR";
            public const string DsUnidade = "CAD_UNI_DS_UNIDADE";
            public const string DsLocal = "CAD_LAT_DS_LOCAL_ATENDIMENTO";           
                        
        }

        #endregion

        #region Captions
        public struct Captions
        {
		    public const string Idt="Idt";
		    public const string IdtLocal="IDTLOCAL";
		    public const string IdtUnidade="IDTUNIDADE";
		    public const string IdtSetor="IDTSETOR";
		    public const string IdtFilial="IDTFILIAL";
            public const string IdtUsuario = "IDTUSUARIO";
            public const string Periodo = "PERIODO";
            public const string Status = "STATUS";
            public const string DataDispensado = "DATADISPENSADO";
            public const string DataUltimaRequisicao = "MTMD_DT_ULT_REQUISICAO";
            public const string DsUnidade = "DSUNIDADE";
            public const string DsSetor = "DSSETOR";
            public const string DsLocal = "DSLOCAL";
            
            
        }		

        #endregion
		
        #region Atributos Publicos
		
		public MVC.DTO.FieldDecimal Idt
		{
            get { return mtmd_pepad_id; }
            set { mtmd_pepad_id = value; }
		}

		public MVC.DTO.FieldDecimal IdtLocal
		{
			get { return cad_lat_id_local_atendimento; }
			set { cad_lat_id_local_atendimento = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtUnidade
		{
			get { return cad_uni_id_unidade; }
			set { cad_uni_id_unidade = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtSetor
		{
			get { return cad_set_id; }
			set { cad_set_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtFilial
		{
			get { return cad_mtmd_filial_id; }
			set { cad_mtmd_filial_id = value; }
		}
		
        public MVC.DTO.FieldDecimal IdtUsuario
        {
            get { return seg_usu_id_usuario; }
            set { seg_usu_id_usuario = value; }
        }

        public MVC.DTO.FieldDecimal Periodo
        {
            get { return mtmd_periodo_dias; }
            set { mtmd_periodo_dias = value; }
        }

        public MVC.DTO.FieldDecimal Status
        {
            get { return mtmd_fl_status; }
            set { mtmd_fl_status = value; }
        }

        public MVC.DTO.FieldDateTime DataDispensado
        {
            get { return mtmd_dt_dispensacao; }
            set { mtmd_dt_dispensacao = value; }
        }

        public MVC.DTO.FieldDateTime DataUltimaRequisicao
        {
            get { return mtmd_dt_ult_requisicao; }
            set { mtmd_dt_ult_requisicao = value; }
        }

        public MVC.DTO.FieldString DsSetor
        {
            get { return cad_set_ds_setor; }
            set { cad_set_ds_setor = value; }
        }

        public MVC.DTO.FieldString DsLocal
        {
            get { return cad_lat_ds_local_atendimento; }
            set { cad_lat_ds_local_atendimento = value; }
        }

        public MVC.DTO.FieldString DsUnidade
        {
            get { return cad_uni_ds_unidade; }
            set { cad_uni_ds_unidade = value; }
        }

        
		#endregion


        #region Operators

        public static explicit operator PedidoPadraoDTO(DataRow row)
        {
            PedidoPadraoDTO  dto = new PedidoPadraoDTO();
			
				dto.Idt.Value = row[FieldNames.Idt].ToString();
			
				dto.IdtLocal.Value = row[FieldNames.IdtLocal].ToString();
			
				dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();
			
				dto.IdtSetor.Value = row[FieldNames.IdtSetor].ToString();
			
				dto.IdtFilial.Value = row[FieldNames.IdtFilial].ToString();
			
                dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();

                dto.Periodo.Value = row[FieldNames.Periodo].ToString();

                dto.Status.Value = row[FieldNames.Status].ToString();

                dto.DataDispensado.Value = row[FieldNames.DataDispensado].ToString();

                dto.DataUltimaRequisicao.Value = row[FieldNames.DataUltimaRequisicao].ToString();

                dto.DsLocal.Value = row[FieldNames.DsLocal].ToString();

                dto.DsSetor.Value = row[FieldNames.DsSetor].ToString();

                dto.DsUnidade.Value = row[FieldNames.DsUnidade].ToString();
                

                
            return dto;
        }

        public static explicit operator PedidoPadraoDTO(XmlDocument xml)
        {
            PedidoPadraoDTO dto = new PedidoPadraoDTO();
			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal) != null) dto.IdtLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor) != null) dto.IdtSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial) != null) dto.IdtFilial.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial).InnerText;			
		
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Periodo) != null) dto.Periodo.Value = xml.FirstChild.SelectSingleNode(FieldNames.Periodo).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Status) != null) dto.Status.Value = xml.FirstChild.SelectSingleNode(FieldNames.Status).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DataDispensado) != null) dto.DataDispensado.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataDispensado).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DataUltimaRequisicao) != null) dto.DataUltimaRequisicao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataUltimaRequisicao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsLocal) != null) dto.DsLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsLocal).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsSetor) != null) dto.DsSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsSetor).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade) != null) dto.DsUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade).InnerText;         

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeIdtLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocal, null);
			
            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);
			
            XmlNode nodeIdtsetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetor, null);
			
            XmlNode nodeIdtFilial = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFilial, null);
			
            XmlNode nodeIdtUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);

            XmlNode nodePeriodo = xml.CreateNode(XmlNodeType.Element, FieldNames.Periodo, null);

            XmlNode nodeStatus = xml.CreateNode(XmlNodeType.Element, FieldNames.Status, null);

            XmlNode nodeDataDispensado = xml.CreateNode(XmlNodeType.Element, FieldNames.DataDispensado, null);

            XmlNode nodeDataUltimaRequisicao = xml.CreateNode(XmlNodeType.Element, FieldNames.DataUltimaRequisicao, null);

            XmlNode nodeDsLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.DsLocal, null);

            XmlNode nodeDsSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.DsSetor, null);

            XmlNode nodeDsUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidade, null);
           
                        
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			
			if (!this.IdtLocal.Value.IsNull) nodeIdtLocal.InnerText = this.IdtLocal.Value;
			
			if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;
			
			if (!this.IdtSetor.Value.IsNull) nodeIdtsetor.InnerText = this.IdtSetor.Value;
			
			if (!this.IdtFilial.Value.IsNull) nodeIdtFilial.InnerText = this.IdtFilial.Value;
			
            if (!this.Periodo.Value.IsNull) nodePeriodo.InnerText = this.Periodo.Value;

            if (!this.Status.Value.IsNull) nodeStatus.InnerText = this.Status.Value;

            if (!this.DataDispensado.Value.IsNull) nodeDataDispensado.InnerText = this.DataDispensado.Value;

            if (!this.DataUltimaRequisicao.Value.IsNull) nodeDataUltimaRequisicao.InnerText = this.DataUltimaRequisicao.Value;

            if (!this.DsLocal.Value.IsNull) nodeDsLocal.InnerText = this.DsLocal.Value;

            if (!this.DsUnidade.Value.IsNull) nodeDsUnidade.InnerText = this.DsUnidade.Value;

            if (!this.DsSetor.Value.IsNull) nodeDsSetor.InnerText = this.DsSetor.Value;            


            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodeIdtLocal);
			
            nodeData.AppendChild(nodeIdtUnidade);
			
            nodeData.AppendChild(nodeIdtsetor);
			
            nodeData.AppendChild(nodeIdtFilial);
			
            nodeData.AppendChild(nodePeriodo);

            nodeData.AppendChild(nodeStatus);

            nodeData.AppendChild(nodeDataDispensado);

            nodeData.AppendChild(nodeDataUltimaRequisicao);

            nodeData.AppendChild(nodeDsLocal);

            nodeData.AppendChild(nodeDsUnidade);

            nodeData.AppendChild(nodeDsSetor);

            xml.AppendChild(nodeData);
            
                       

            return xml;
        }

        public static explicit operator DataRow(PedidoPadraoDTO dto)
        {
            PedidoPadraoDataTable dtb = new PedidoPadraoDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
			
            dtr[FieldNames.IdtLocal] = dto.IdtLocal.Value;
			
            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;
			
            dtr[FieldNames.IdtSetor] = dto.IdtSetor.Value;
			
            dtr[FieldNames.IdtFilial] = dto.IdtFilial.Value;
			
            dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;

            dtr[FieldNames.Periodo] = dto.Periodo.Value;

            dtr[FieldNames.Status] = dto.Status.Value;

            dtr[FieldNames.DataDispensado] = dto.DataDispensado.Value;

            dtr[FieldNames.DataUltimaRequisicao] = dto.DataUltimaRequisicao.Value;

            dtr[FieldNames.DsSetor] = dto.DsSetor.Value;

            dtr[FieldNames.DsUnidade] = dto.DsUnidade.Value;

            dtr[FieldNames.DsLocal] = dto.DsLocal.Value;

            
                        
            return dtr;
        }

        public static explicit operator XmlDocument(PedidoPadraoDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}


