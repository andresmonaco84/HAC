
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
	/// Classe Entidade PedidoPadraoItensDataTable
	/// </summary>
	[Serializable()]
	public class PedidoPadraoItensDataTable : DataTable
	{		
	    public PedidoPadraoItensDataTable()
            : base()
        {
            this.TableName = "DADOS";

            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.Idt, typeof(Decimal));
		    this.Columns.Add(PedidoPadraoItensDTO.FieldNames.IdtProduto, typeof(Decimal));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.IdtPrincipioAtivo, typeof(Decimal));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.IdtLocal, typeof(Decimal));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.IdtUnidade, typeof(Decimal));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.IdtSetor, typeof(Decimal));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.DsProduto, typeof(String));
		    this.Columns.Add(PedidoPadraoItensDTO.FieldNames.Qtde, typeof(Decimal));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.EstoqueLocalQtde, typeof(Decimal));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.Fornecer, typeof(Decimal));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.Consumido, typeof(Decimal));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.Percentual, typeof(Decimal));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.OutrosConsumos, typeof(Decimal));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.ConsumoMedio, typeof(Decimal));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.PontoRessuprimento, typeof(Decimal));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.DsSetor, typeof(String));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.DsLocal, typeof(String));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.DsUnidade, typeof(String));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.DataDispensado, typeof(DateTime));

            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.DataAtualizado, typeof(DateTime));
            this.Columns.Add(PedidoPadraoItensDTO.FieldNames.DataRessupri, typeof(DateTime));

            //DataColumn[] primaryKey = { this.Columns[PedidoPadraoItensDTO.FieldNames.IdtProduto] };

            //this.PrimaryKey = primaryKey;
        }
		
        protected PedidoPadraoItensDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public PedidoPadraoItensDTO TypedRow(int index)
        {
            return (PedidoPadraoItensDTO)this.Rows[index];
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

        public void Add(PedidoPadraoItensDTO dto)
        {
            DataRow dtr = this.NewRow();

            if (!dto.Idt.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		    if (!dto.IdtProduto.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.IdtProduto] = (Decimal)dto.IdtProduto.Value;
            if (!dto.IdtPrincipioAtivo.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.IdtPrincipioAtivo] = (Decimal)dto.IdtPrincipioAtivo.Value;
            if (!dto.IdtSetor.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.IdtSetor] = (Decimal)dto.IdtSetor.Value;
            if (!dto.IdtLocal.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.IdtLocal] = (Decimal)dto.IdtLocal.Value;
            if (!dto.IdtUnidade.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;            

		    if (!dto.Qtde.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.Qtde] = (Decimal)dto.Qtde.Value;
            if (!dto.Consumido.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.Consumido] = (Decimal)dto.Consumido.Value;
            if (!dto.Percentual.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.Percentual] = (Decimal)dto.Percentual.Value;
            if (!dto.EstoqueLocalQtde.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.EstoqueLocalQtde] = (Decimal)dto.EstoqueLocalQtde.Value;
            if (!dto.DsProduto.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.DsProduto] = (String)dto.DsProduto.Value;
            if (!dto.Fornecer.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.Fornecer] = (Decimal)dto.Fornecer.Value;

            if (!dto.OutrosConsumos.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.OutrosConsumos] = (Decimal)dto.OutrosConsumos.Value;
            if (!dto.Consumido.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.Consumido] = (Decimal)dto.Consumido.Value;
            if (!dto.Percentual.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.Percentual] = (Decimal)dto.Percentual.Value;

            if (!dto.ConsumoMedio.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.ConsumoMedio] = (Decimal)dto.ConsumoMedio.Value;
            if (!dto.PontoRessuprimento.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.PontoRessuprimento] = (Decimal)dto.PontoRessuprimento.Value;

            if (!dto.DsSetor.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.DsSetor] = (String)dto.DsSetor.Value;
            if (!dto.DsLocal.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.DsLocal] = (String)dto.DsLocal.Value;
            if (!dto.DsUnidade.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.DsUnidade] = (String)dto.DsUnidade.Value;

            if (!dto.DataDispensado.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.DataDispensado] = (DateTime)dto.DataDispensado.Value;

            if (!dto.DataAtualizado.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.DataAtualizado] = (DateTime)dto.DataAtualizado.Value;
            if (!dto.DataRessupri.Value.IsNull) dtr[PedidoPadraoItensDTO.FieldNames.DataRessupri] = (DateTime)dto.DataRessupri.Value;

        this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class PedidoPadraoItensDTO : MVC.DTO.DTOBase
    {
        public enum StatusPedidoPadrao
        {
            CONFIRMAR = 0,
            CONFIRMADO = 1            
        }

		private MVC.DTO.FieldDecimal cad_mtmd_id;
        private MVC.DTO.FieldDecimal mtmd_pepad_id;
        private MVC.DTO.FieldDecimal cad_mtmd_priati_id;

        private MVC.DTO.FieldDecimal cad_set_id;
        private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
        private MVC.DTO.FieldDecimal cad_uni_id_unidade;

		private MVC.DTO.FieldDecimal mtmd_pedpad_qtde;
        private MVC.DTO.FieldDecimal qtde_estoque_local;
        private MVC.DTO.FieldString ds_produto;
        private MVC.DTO.FieldDecimal qtd_fornecer;
        private MVC.DTO.FieldDecimal outros_consumos;
        private MVC.DTO.FieldDecimal qtde_consumida;
        private MVC.DTO.FieldDecimal percentual_consumido;
        private MVC.DTO.FieldDecimal consumo_medio;
        private MVC.DTO.FieldDecimal mtmd_pedpad_percent_ressup;

        private MVC.DTO.FieldString cad_set_ds_setor;
        private MVC.DTO.FieldString cad_lat_ds_local_atendimento;
        private MVC.DTO.FieldString cad_uni_ds_unidade;

        private MVC.DTO.FieldDateTime mtmd_dt_dispensacao;

        private MVC.DTO.FieldDateTime mtmd_dt_atualizacao;

        private MVC.DTO.FieldDateTime mtmd_dt_ressuprimento;



        //ConsumoMedio consumo_medio

        public PedidoPadraoItensDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
		    this.cad_mtmd_id= new MVC.DTO.FieldDecimal(FieldNames.IdtProduto,Captions.IdtProduto, DbType.Decimal);
            this.mtmd_pepad_id = new MVC.DTO.FieldDecimal(FieldNames.Idt, Captions.Idt, DbType.Decimal);
            this.cad_mtmd_priati_id = new MVC.DTO.FieldDecimal(FieldNames.IdtPrincipioAtivo, Captions.IdtPrincipioAtivo, DbType.Decimal);
            this.cad_set_id = new MVC.DTO.FieldDecimal(FieldNames.IdtSetor, Captions.IdtSetor, DbType.Decimal);
            this.cad_lat_id_local_atendimento = new MVC.DTO.FieldDecimal(FieldNames.IdtLocal, Captions.IdtLocal, DbType.Decimal);
            this.cad_uni_id_unidade = new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade, Captions.IdtUnidade, DbType.Decimal);

		    this.mtmd_pedpad_qtde= new MVC.DTO.FieldDecimal(FieldNames.Qtde,Captions.Qtde, DbType.Decimal);
            this.qtde_estoque_local = new MVC.DTO.FieldDecimal(FieldNames.EstoqueLocalQtde, Captions.EstoqueLocalQtde, DbType.Decimal);
            this.ds_produto = new MVC.DTO.FieldString(FieldNames.DsProduto, Captions.DsProduto, 100);
            this.qtd_fornecer = new MVC.DTO.FieldDecimal(FieldNames.Fornecer, Captions.Fornecer, DbType.Decimal);
            this.outros_consumos = new MVC.DTO.FieldDecimal(FieldNames.OutrosConsumos, Captions.OutrosConsumos, DbType.Decimal);
            this.qtde_consumida = new MVC.DTO.FieldDecimal(FieldNames.Consumido, Captions.Consumido, DbType.Decimal);
            this.percentual_consumido = new MVC.DTO.FieldDecimal(FieldNames.Percentual, Captions.Percentual, DbType.Decimal);
            this.consumo_medio = new MVC.DTO.FieldDecimal(FieldNames.ConsumoMedio, Captions.ConsumoMedio, DbType.Decimal);
            this.mtmd_pedpad_percent_ressup = new MVC.DTO.FieldDecimal(FieldNames.PontoRessuprimento, Captions.PontoRessuprimento);

            this.cad_set_ds_setor = new MVC.DTO.FieldString(FieldNames.DsSetor, Captions.DsSetor, 100);
            this.cad_lat_ds_local_atendimento = new MVC.DTO.FieldString(FieldNames.DsLocal, Captions.DsLocal, 100);
            this.cad_uni_ds_unidade = new MVC.DTO.FieldString(FieldNames.DsUnidade, Captions.DsUnidade, 100);

            this.mtmd_dt_dispensacao = new MVC.DTO.FieldDateTime(FieldNames.DataDispensado, Captions.DataDispensado);
            this.mtmd_dt_atualizacao = new MVC.DTO.FieldDateTime(FieldNames.DataAtualizado, Captions.DataAtualizado);
            this.mtmd_dt_ressuprimento = new MVC.DTO.FieldDateTime(FieldNames.DataRessupri, Captions.DataRessupri);

        }
 
        #region FieldNames

        public struct FieldNames
        {
            public const string Idt = "MTMD_PEDPAD_ID";
		    public const string IdtProduto="CAD_MTMD_ID";
            public const string IdtPrincipioAtivo = "CAD_MTMD_PRIATI_ID";
            public const string IdtSetor="CAD_SET_ID";
            public const string IdtLocal="CAD_LAT_ID_LOCAL_ATENDIMENTO";
            public const string IdtUnidade="CAD_UNI_ID_UNIDADE";            

		    public const string Qtde="MTMD_PEDPAD_QTDE";
            public const string EstoqueLocalQtde = "QTDE_ESTOQUE_LOCAL";
            public const string DsProduto = "CAD_MTMD_NOMEFANTASIA";
            public const string Fornecer = "QTD_FORNECER";
            public const string OutrosConsumos = "OUTROS_CONSUMOS";
            public const string Consumido = "QTDE_CONSUMIDA";
            public const string Percentual = "PERCENTUAL_CONSUMIDO";
            public const string ConsumoMedio = "CONSUMO_MEDIO";
            public const string PontoRessuprimento = "MTMD_PEDPAD_PERCENT_RESSUP";

            public const string DsSetor = "CAD_SET_DS_SETOR";
            public const string DsLocal = "CAD_LAT_DS_LOCAL_ATENDIMENTO";
            public const string DsUnidade = "CAD_UNI_DS_UNIDADE";

            public const string DataDispensado = "MTMD_DT_DISPENSACAO";

            public const string DataAtualizado = "MTMD_DT_ATUALIZACAO";
            public const string DataRessupri = "MTMD_DT_RESSUPRIMENTO";

        }

        #endregion

        #region Captions
        public struct Captions
        {
            public const string Idt = "Idt";
		    public const string IdtProduto="IDTPRODUTO";
            public const string IdtPrincipioAtivo = "IdtPrincipioAtivo";
            public const string IdtSetor = "IDTSETOR";
            public const string IdtLocal = "IDTLOCAL";
            public const string IdtUnidade = "IDTUNIDADE";

		    public const string Qtde="QTDE";
            public const string EstoqueLocalQtde = "QTDEESTOQUELOCAL";
            public const string DsProduto = "DSPRODUTO";
            public const string Fornecer = "FORNECER";
            public const string OutrosConsumos = "OUTROSCONSUMOS";
            public const string Consumido = "QTDECONSUMIDA";
            public const string Percentual = "PERCENTUALCONSUMIDO";
            public const string ConsumoMedio = "CONSUMOMEDIO";
            public const string PontoRessuprimento = "PONTORESSUPRIMENTO";

            public const string DsSetor = "DSSETOR";
            public const string DsLocal = "DSLOCAL";
            public const string DsUnidade = "DSUNIDADE";

            public const string DataDispensado = "DATADISPENSADO";

            public const string DataAtualizado = "DATAATUALIZADO";
            public const string DataRessupri = "DATADISPENSADO";

        }		

        #endregion
		
        #region Atributos Publicos

        public MVC.DTO.FieldDecimal IdtPrincipioAtivo
        {
            get { return cad_mtmd_priati_id; }
            set { cad_mtmd_priati_id = value; }
        }
		
		public MVC.DTO.FieldDecimal IdtProduto
		{
			get { return cad_mtmd_id; }
			set { cad_mtmd_id = value; }
		}

        public MVC.DTO.FieldDecimal IdtSetor
        {
            get { return cad_set_id; }
            set { cad_set_id = value; }
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

		public MVC.DTO.FieldDecimal Idt
		{
            get { return mtmd_pepad_id; }
            set { mtmd_pepad_id = value; }
		}
		
		public MVC.DTO.FieldDecimal Qtde
		{
			get { return mtmd_pedpad_qtde; }
			set { mtmd_pedpad_qtde = value; }
		}

        public MVC.DTO.FieldDecimal EstoqueLocalQtde
        {
            get { return qtde_estoque_local; }
            set { qtde_estoque_local = value; }
        }

        public MVC.DTO.FieldString DsProduto
        {
            get { return ds_produto; }
            set { ds_produto = value; }
        }

        public MVC.DTO.FieldDecimal OutrosConsumos
        {
            get { return outros_consumos; }
            set { outros_consumos = value; }
        }

        public MVC.DTO.FieldDecimal Consumido
        {
            get { return qtde_consumida; }
            set { qtde_consumida = value; }
        }

        public MVC.DTO.FieldDecimal Percentual
        {
            get { return percentual_consumido; }
            set { percentual_consumido = value; }
        }

        public MVC.DTO.FieldDecimal Fornecer
        {
            get { return qtd_fornecer; }
            set { qtd_fornecer = value; }
        }

        public MVC.DTO.FieldDecimal ConsumoMedio
        {
            get { return consumo_medio; }
            set { consumo_medio = value; }
        }

        public MVC.DTO.FieldDecimal PontoRessuprimento
        {
            get { return mtmd_pedpad_percent_ressup; }
            set { mtmd_pedpad_percent_ressup = value; }
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

        public MVC.DTO.FieldDateTime DataDispensado
        {
            get { return mtmd_dt_dispensacao; }
            set { mtmd_dt_dispensacao = value; }
        }

        /// <summary>
        /// Data da última alteração/inclusão do item
        /// </summary>
        public MVC.DTO.FieldDateTime DataAtualizado
        {
            get { return mtmd_dt_atualizacao; }
            set { mtmd_dt_atualizacao = value; }
        }

        /// <summary>
        /// Data do último ressuprimento do produto na unidade
        /// </summary>
        public MVC.DTO.FieldDateTime DataRessupri
        {
            get { return mtmd_dt_ressuprimento; }
            set { mtmd_dt_ressuprimento = value; }
        }

        #endregion

        #region Operators

        public static explicit operator PedidoPadraoItensDTO(DataRow row)
        {
            PedidoPadraoItensDTO  dto = new PedidoPadraoItensDTO();

            dto.Idt.Value = row[FieldNames.Idt].ToString();
            dto.IdtPrincipioAtivo.Value = row[FieldNames.IdtPrincipioAtivo].ToString();
            dto.IdtProduto.Value = row[FieldNames.IdtProduto].ToString();

            dto.IdtSetor.Value = row[FieldNames.IdtSetor].ToString();
            dto.IdtLocal.Value = row[FieldNames.IdtLocal].ToString();
            dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();
						
			dto.Qtde.Value = row[FieldNames.Qtde].ToString();

            dto.EstoqueLocalQtde.Value = row[FieldNames.EstoqueLocalQtde].ToString();

            dto.DsProduto.Value = row[FieldNames.DsProduto].ToString();

            dto.OutrosConsumos.Value = row[FieldNames.OutrosConsumos].ToString();

            dto.Consumido.Value = row[FieldNames.Consumido].ToString();

            dto.Percentual.Value = row[FieldNames.Percentual].ToString();

            dto.Fornecer.Value = row[FieldNames.Fornecer].ToString();

            dto.ConsumoMedio.Value = row[FieldNames.ConsumoMedio].ToString();

            dto.PontoRessuprimento.Value = row[FieldNames.PontoRessuprimento].ToString();

            dto.DsSetor.Value = row[FieldNames.DsSetor].ToString();
            dto.DsLocal.Value = row[FieldNames.DsLocal].ToString();
            dto.DsUnidade.Value = row[FieldNames.DsUnidade].ToString();

            dto.DataDispensado.Value = row[FieldNames.DataDispensado].ToString();

            dto.DataAtualizado.Value = row[FieldNames.DataAtualizado].ToString();
            dto.DataRessupri.Value = row[FieldNames.DataRessupri].ToString();

            return dto;
        }

        public static explicit operator PedidoPadraoItensDTO(XmlDocument xml)
        {
            PedidoPadraoItensDTO dto = new PedidoPadraoItensDTO();
			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto) != null) dto.IdtProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtPrincipioAtivo) != null) dto.IdtPrincipioAtivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtPrincipioAtivo).InnerText;			
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor) != null) dto.IdtSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal) != null) dto.IdtLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.Qtde) != null) dto.Qtde.Value = xml.FirstChild.SelectSingleNode(FieldNames.Qtde).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.EstoqueLocalQtde) != null) dto.EstoqueLocalQtde.Value = xml.FirstChild.SelectSingleNode(FieldNames.EstoqueLocalQtde).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsProduto) != null) dto.DsProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsProduto).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Fornecer) != null) dto.Fornecer.Value = xml.FirstChild.SelectSingleNode(FieldNames.Fornecer).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Consumido) != null) dto.Consumido.Value = xml.FirstChild.SelectSingleNode(FieldNames.Consumido).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Percentual) != null) dto.Percentual.Value = xml.FirstChild.SelectSingleNode(FieldNames.Percentual).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.OutrosConsumos) != null) dto.OutrosConsumos.Value = xml.FirstChild.SelectSingleNode(FieldNames.OutrosConsumos).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.ConsumoMedio) != null) dto.ConsumoMedio.Value = xml.FirstChild.SelectSingleNode(FieldNames.ConsumoMedio).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.PontoRessuprimento) != null) dto.PontoRessuprimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.PontoRessuprimento).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsSetor) != null) dto.DsSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsSetor).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DsLocal) != null) dto.DsLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsLocal).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade) != null) dto.DsUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DataDispensado) != null) dto.DataDispensado.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataDispensado).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizado) != null) dto.DataAtualizado.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizado).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DataRessupri) != null) dto.DataRessupri.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataRessupri).InnerText;

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdtProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtProduto, null);
            XmlNode nodeIdtPrincipioAtivo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtPrincipioAtivo, null);
            XmlNode nodeIdtSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetor, null);
            XmlNode nodeIdtLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocal, null);
            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeQtde = xml.CreateNode(XmlNodeType.Element, FieldNames.Qtde, null);

            XmlNode nodeEstoqueLocalQtde = xml.CreateNode(XmlNodeType.Element, FieldNames.EstoqueLocalQtde, null);

            XmlNode nodeDsProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.DsProduto, null);

            XmlNode nodeOutrosConsumos = xml.CreateNode(XmlNodeType.Element, FieldNames.OutrosConsumos, null);

            XmlNode nodeConsumido = xml.CreateNode(XmlNodeType.Element, FieldNames.Consumido, null);

            XmlNode nodePercentual = xml.CreateNode(XmlNodeType.Element, FieldNames.Percentual, null);


            XmlNode nodeFornecer = xml.CreateNode(XmlNodeType.Element, FieldNames.Fornecer, null);

            XmlNode nodeConsumoMedio = xml.CreateNode(XmlNodeType.Element, FieldNames.ConsumoMedio, null);

            XmlNode nodePontoRessuprimento = xml.CreateNode(XmlNodeType.Element, FieldNames.PontoRessuprimento, null);

            XmlNode nodeDsSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.DsSetor, null);
            XmlNode nodeDsLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.DsLocal, null);
            XmlNode nodeDsUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidade, null);

            XmlNode nodeDataDispensado = xml.CreateNode(XmlNodeType.Element, FieldNames.DataDispensado, null);


            XmlNode nodeDataAtualizado = xml.CreateNode(XmlNodeType.Element, FieldNames.DataAtualizado, null);
            XmlNode nodeDataRessupri = xml.CreateNode(XmlNodeType.Element, FieldNames.DataRessupri, null);


            if (!this.IdtProduto.Value.IsNull) nodeIdtProduto.InnerText = this.IdtProduto.Value;
            if (!this.IdtPrincipioAtivo.Value.IsNull) nodeIdtPrincipioAtivo.InnerText = this.IdtPrincipioAtivo.Value;
            if (!this.IdtSetor.Value.IsNull) nodeIdtSetor.InnerText = this.IdtSetor.Value;
            if (!this.IdtLocal.Value.IsNull) nodeIdtLocal.InnerText = this.IdtLocal.Value;
            if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;
			
			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			
			if (!this.Qtde.Value.IsNull) nodeQtde.InnerText = this.Qtde.Value;

            if (!this.EstoqueLocalQtde.Value.IsNull) nodeEstoqueLocalQtde.InnerText = this.EstoqueLocalQtde.Value;

            if (!this.DsProduto.Value.IsNull) nodeDsProduto.InnerText = this.DsProduto.Value;


            if (!this.OutrosConsumos.Value.IsNull) nodeOutrosConsumos.InnerText = this.OutrosConsumos.Value;

            if (!this.Consumido.Value.IsNull) nodeConsumido.InnerText = this.Consumido.Value;

            if (!this.Percentual.Value.IsNull) nodePercentual.InnerText = this.Percentual.Value;


            if (!this.Fornecer.Value.IsNull) nodeFornecer.InnerText = this.Fornecer.Value;

            if (!this.ConsumoMedio.Value.IsNull) nodeConsumoMedio.InnerText = this.ConsumoMedio.Value;

            if (!this.PontoRessuprimento.Value.IsNull) nodePontoRessuprimento.InnerText = this.PontoRessuprimento.Value;

            if (!this.DsSetor.Value.IsNull) nodeDsSetor.InnerText = this.DsSetor.Value;
            if (!this.DsLocal.Value.IsNull) nodeDsLocal.InnerText = this.DsLocal.Value;
            if (!this.DsUnidade.Value.IsNull) nodeDsUnidade.InnerText = this.DsUnidade.Value;

            if (!this.DataDispensado.Value.IsNull) nodeDataDispensado.InnerText = this.DataDispensado.Value;

            if (!this.DataAtualizado.Value.IsNull) nodeDataAtualizado.InnerText = this.DataAtualizado.Value;
            if (!this.DataRessupri.Value.IsNull) nodeDataRessupri.InnerText = this.DataRessupri.Value;


            nodeData.AppendChild(nodeIdtProduto);
            nodeData.AppendChild(nodeIdtPrincipioAtivo);
            nodeData.AppendChild(nodeIdtSetor);
            nodeData.AppendChild(nodeIdtLocal);
            nodeData.AppendChild(nodeIdtUnidade);
			
            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodeQtde);

            nodeData.AppendChild(nodeEstoqueLocalQtde);

            nodeData.AppendChild(nodeDsProduto);

            nodeData.AppendChild(nodeOutrosConsumos);

            nodeData.AppendChild(nodeConsumido);

            nodeData.AppendChild(nodePercentual);
            
            nodeData.AppendChild(nodeFornecer);

            nodeData.AppendChild(nodeConsumoMedio);

            nodeData.AppendChild(nodePontoRessuprimento);

            nodeData.AppendChild(nodeDsSetor);
            nodeData.AppendChild(nodeDsLocal);
            nodeData.AppendChild(nodeDsUnidade);

            nodeData.AppendChild(nodeDataDispensado);

            nodeData.AppendChild(nodeDataAtualizado);
            nodeData.AppendChild(nodeDataRessupri);
            
            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(PedidoPadraoItensDTO dto)
        {
            PedidoPadraoItensDataTable dtb = new PedidoPadraoItensDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.IdtProduto] = dto.IdtProduto.Value;
            dtr[FieldNames.IdtPrincipioAtivo] = dto.IdtPrincipioAtivo.Value;
            dtr[FieldNames.IdtSetor] = dto.IdtSetor.Value;
            dtr[FieldNames.IdtLocal] = dto.IdtLocal.Value;
            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
					
            dtr[FieldNames.Qtde] = dto.Qtde.Value;

            dtr[FieldNames.EstoqueLocalQtde] = dto.EstoqueLocalQtde.Value;

            dtr[FieldNames.DsProduto] = dto.DsProduto.Value;

            dtr[FieldNames.OutrosConsumos] = dto.OutrosConsumos.Value;

            dtr[FieldNames.Consumido] = dto.Consumido.Value;

            dtr[FieldNames.Percentual] = dto.Percentual.Value;

            dtr[FieldNames.ConsumoMedio] = dto.ConsumoMedio.Value;

            dtr[FieldNames.Fornecer] = dto.Fornecer.Value;

            dtr[FieldNames.PontoRessuprimento] = dto.PontoRessuprimento.Value;

            dtr[FieldNames.DsSetor] = dto.DsSetor.Value;
            dtr[FieldNames.DsLocal] = dto.DsLocal.Value;
            dtr[FieldNames.DsUnidade] = dto.DsUnidade.Value;

            dtr[FieldNames.DataDispensado] = dto.DataDispensado.Value;
            dtr[FieldNames.DataAtualizado] = dto.DataAtualizado.Value;
            dtr[FieldNames.DataRessupri] = dto.DataRessupri.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(PedidoPadraoItensDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}
