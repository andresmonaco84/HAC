
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
	/// Classe Entidade HistoricoNotaFiscalDataTable
	/// </summary>
	[Serializable()]
	public class HistoricoNotaFiscalDataTable : DataTable
	{
		
	    public HistoricoNotaFiscalDataTable()
            : base()
        {
            this.TableName = "DADOS";

			this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.IdtProduto, typeof(decimal));
		    this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.IdtFilial, typeof(decimal));
		    this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.NrNota, typeof(string));
		    this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.CustoMedio, typeof(decimal));
		    this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.DataPrcMedio, typeof(DateTime));
		    this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.Qtde, typeof(decimal));
		    this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.PrecoUnitario, typeof(decimal));
            this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.DsProduto, typeof(String));
            this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.IdtLote, typeof(decimal));
            this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.CodLote, typeof(String));
            this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.NumLote, typeof(String));
            this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.DataValidadeProduto, typeof(DateTime));
            this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.DsFornecedor, typeof(String));
            this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.TpMovimento, typeof(String));
            this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.UnidadeCompra, typeof(String));
            this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.SaldoAnterior, typeof(decimal));
            this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.QtdeTotalNota, typeof(decimal));
            this.Columns.Add(HistoricoNotaFiscalDTO.FieldNames.IdMovRM, typeof(Decimal));
        }
		
        protected HistoricoNotaFiscalDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public HistoricoNotaFiscalDTO TypedRow(int index)
        {
            return (HistoricoNotaFiscalDTO)this.Rows[index];
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

        public void Add(HistoricoNotaFiscalDTO dto)
        {
            DataRow dtr = this.NewRow();

			if (!dto.IdtProduto.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.IdtProduto] = (decimal)dto.IdtProduto.Value;
		    if (!dto.IdtFilial.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.IdtFilial] = (decimal)dto.IdtFilial.Value;
		    if (!dto.NrNota.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.NrNota] = (string)dto.NrNota.Value;
		    if (!dto.CustoMedio.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.CustoMedio] = (decimal)dto.CustoMedio.Value;
		    if (!dto.DataPrcMedio.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.DataPrcMedio] = (DateTime)dto.DataPrcMedio.Value;
		    if (!dto.Qtde.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.Qtde] = (decimal)dto.Qtde.Value;
		    if (!dto.PrecoUnitario.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.PrecoUnitario] = (decimal)dto.PrecoUnitario.Value;
            if (!dto.DsProduto.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.DsProduto] = (String)dto.DsProduto.Value;
            if (!dto.IdtLote.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.IdtLote] = (decimal)dto.IdtLote.Value;
            if (!dto.CodLote.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.CodLote] = (String)dto.CodLote.Value;
            if (!dto.NumLote.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.NumLote] = (String)dto.NumLote.Value;
            if (!dto.DataValidadeProduto.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.DataValidadeProduto] = (DateTime)dto.DataValidadeProduto.Value;

            if (!dto.DsFornecedor.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.DsFornecedor] = (String)dto.DsFornecedor.Value;
            if (!dto.TpMovimento.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.TpMovimento] = (String)dto.TpMovimento.Value;
            if (!dto.UnidadeCompra.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.UnidadeCompra] = (String)dto.UnidadeCompra.Value;

            if (!dto.SaldoAnterior.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.SaldoAnterior] = (decimal)dto.SaldoAnterior.Value;
            if (!dto.QtdeTotalNota.Value.IsNull) dtr[HistoricoNotaFiscalDTO.FieldNames.QtdeTotalNota] = (decimal)dto.QtdeTotalNota.Value;
            if (!dto.IdMovRM.Value.IsNull) dtr[HistoricoNFEstornoDTO.FieldNames.IdMovRM] = (Decimal)dto.IdMovRM.Value;            

            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class HistoricoNotaFiscalDTO : MVC.DTO.DTOBase
    {	
		private MVC.DTO.FieldDecimal cad_mtmd_id;
		private MVC.DTO.FieldDecimal cad_mtmd_filial_id;
		private MVC.DTO.FieldString mtmd_nr_nota;
		private MVC.DTO.FieldDecimal mtmd_custo_medio;
		private MVC.DTO.FieldDateTime mtmd_data_prc_medio;
		private MVC.DTO.FieldDecimal mtmd_qtde;
		private MVC.DTO.FieldDecimal mtmd_preco_unitario;
        private MVC.DTO.FieldString ds_produto;
        private MVC.DTO.FieldDecimal mtmd_lotest_id;
        private MVC.DTO.FieldString mtmd_cod_lote;
        private MVC.DTO.FieldString mtmd_num_lote;
        private MVC.DTO.FieldDateTime mtmd_dt_validade;

        private MVC.DTO.FieldString ds_fornecedor;
        private MVC.DTO.FieldString tp_movimento;
        private MVC.DTO.FieldString unidade_compra;

        private MVC.DTO.FieldDecimal mtmd_estcon_qtde_anterior;

        private MVC.DTO.FieldDecimal qtd_total_nota;
        private MVC.DTO.FieldDecimal idmov;

        public HistoricoNotaFiscalDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
            this.cad_mtmd_id = new MVC.DTO.FieldDecimal(FieldNames.IdtProduto, Captions.IdtProduto);
            this.cad_mtmd_filial_id = new MVC.DTO.FieldDecimal(FieldNames.IdtFilial, Captions.IdtFilial);
            this.mtmd_nr_nota = new MVC.DTO.FieldString(FieldNames.NrNota, Captions.NrNota);
            this.mtmd_custo_medio = new MVC.DTO.FieldDecimal(FieldNames.CustoMedio, Captions.CustoMedio);
            this.mtmd_data_prc_medio = new MVC.DTO.FieldDateTime(FieldNames.DataPrcMedio, Captions.DataPrcMedio);
            this.mtmd_qtde = new MVC.DTO.FieldDecimal(FieldNames.Qtde, Captions.Qtde);
            this.mtmd_preco_unitario = new MVC.DTO.FieldDecimal(FieldNames.PrecoUnitario, Captions.PrecoUnitario);
            this.ds_produto = new MVC.DTO.FieldString(FieldNames.DsProduto, Captions.DsProduto, 100);
            this.mtmd_lotest_id = new MVC.DTO.FieldDecimal(FieldNames.IdtLote, Captions.IdtLote);
            this.mtmd_cod_lote = new MVC.DTO.FieldString(FieldNames.CodLote, Captions.CodLote, 50);
            this.mtmd_num_lote = new MVC.DTO.FieldString(FieldNames.NumLote, Captions.NumLote, 50);
            this.mtmd_dt_validade = new MVC.DTO.FieldDateTime(FieldNames.DataValidadeProduto, Captions.DataValidadeProduto);
            this.ds_fornecedor = new MVC.DTO.FieldString(FieldNames.DsFornecedor, Captions.DsFornecedor, 100);
            this.tp_movimento = new MVC.DTO.FieldString(FieldNames.TpMovimento, Captions.TpMovimento, 100);
            this.unidade_compra = new MVC.DTO.FieldString(FieldNames.UnidadeCompra, Captions.UnidadeCompra, 100);

            this.mtmd_estcon_qtde_anterior = new MVC.DTO.FieldDecimal(FieldNames.SaldoAnterior, Captions.SaldoAnterior);

            this.qtd_total_nota = new MVC.DTO.FieldDecimal(FieldNames.QtdeTotalNota, Captions.QtdeTotalNota);
            this.idmov = new MVC.DTO.FieldDecimal(FieldNames.IdMovRM, Captions.IdMovRM, DbType.Decimal);            
        }
 
        #region FieldNames

        public struct FieldNames
        {
			public const string IdtProduto="CAD_MTMD_ID";
	        public const string IdtFilial="CAD_MTMD_FILIAL_ID";
	        public const string NrNota="MTMD_NR_NOTA";
	        public const string CustoMedio="MTMD_CUSTO_MEDIO";
	        public const string DataPrcMedio="MTMD_DATA_PRC_MEDIO";
	        public const string Qtde="MTMD_QTDE";
	        public const string PrecoUnitario="MTMD_PRECO_UNITARIO";
            public const string DsProduto = "CAD_MTMD_NOMEFANTASIA";
            public const string IdtLote = "MTMD_LOTEST_ID";
            public const string CodLote = "MTMD_COD_LOTE";
            public const string NumLote = "MTMD_NUM_LOTE";
            public const string DataValidadeProduto = "MTMD_DT_VALIDADE";

            public const string DsFornecedor = "DS_FORNECEDOR";
            public const string TpMovimento = "TP_MOVIMENTO";
            public const string UnidadeCompra = "UNIDADE_COMPRA";

            public const string SaldoAnterior = "MTMD_ESTCON_QTDE_ANTERIOR";

            public const string QtdeTotalNota = "QTD_TOTAL_NOTA";
            public const string IdMovRM = "IDMOV";
        }		

        #endregion

        #region Captions
        public struct Captions
        {
			public const string IdtProduto="IDTPRODUTO";
		    public const string IdtFilial="IDTFILIAL";
		    public const string NrNota="NRNOTA";
		    public const string CustoMedio="CUSTOMEDIO";
		    public const string DataPrcMedio="DATAPRCMEDIO";
		    public const string Qtde="QTDE";
		    public const string PrecoUnitario="PRECOUNITARIO";
            public const string DsProduto = "NOMEFANTASIA";
            public const string IdtLote = "MTMDLOTESTID";
            public const string CodLote = "MTMDCODLOTE";
            public const string NumLote = "MTMDNUMLOTE";
            public const string DataValidadeProduto = "MTMDDTVALIDADE";

            public const string DsFornecedor = "DSFORNECEDOR";
            public const string TpMovimento = "TPMOVIMENTO";
            public const string UnidadeCompra = "UNIDADECOMPRA";

            public const string SaldoAnterior = "SALDOANTERIOR";

            public const string QtdeTotalNota = "QTDETOTALNOTA";
            public const string IdMovRM = "IDMOVRM";
        }		

        #endregion
		
        #region Atributos Publicos

        public MVC.DTO.FieldString DsProduto
        {
            get { return ds_produto; }
            set { ds_produto = value; }
        }		

		public MVC.DTO.FieldDecimal IdtProduto
		{
			get { return cad_mtmd_id; }
			set { cad_mtmd_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtFilial
		{
			get { return cad_mtmd_filial_id; }
			set { cad_mtmd_filial_id = value; }
		}
		
		public MVC.DTO.FieldString NrNota
		{
			get { return mtmd_nr_nota; }
			set { mtmd_nr_nota = value; }
		}
		
		public MVC.DTO.FieldDecimal CustoMedio
		{
			get { return mtmd_custo_medio; }
			set { mtmd_custo_medio = value; }
		}
		
		public MVC.DTO.FieldDateTime DataPrcMedio
		{
			get { return mtmd_data_prc_medio; }
			set { mtmd_data_prc_medio = value; }
		}
		
		public MVC.DTO.FieldDecimal Qtde
		{
			get { return mtmd_qtde; }
			set { mtmd_qtde = value; }
		}
		
		public MVC.DTO.FieldDecimal PrecoUnitario
		{
			get { return mtmd_preco_unitario; }
			set { mtmd_preco_unitario = value; }
		}

        public MVC.DTO.FieldDecimal IdtLote
        {
            get { return mtmd_lotest_id; }
            set { mtmd_lotest_id = value; }
        }

        public MVC.DTO.FieldString CodLote
        {
            get { return mtmd_cod_lote; }
            set { mtmd_cod_lote = value; }
        }

        public MVC.DTO.FieldString NumLote
        {
            get { return mtmd_num_lote; }
            set { mtmd_num_lote = value; }
        }

        public MVC.DTO.FieldDateTime DataValidadeProduto
        {
            get { return mtmd_dt_validade; }
            set { mtmd_dt_validade = value; }
        }

        public MVC.DTO.FieldString DsFornecedor
        {
            get { return ds_fornecedor; }
            set { ds_fornecedor = value; }
        }


        public MVC.DTO.FieldString TpMovimento
        {
            get { return tp_movimento; }
            set { tp_movimento = value; }
        }

        public MVC.DTO.FieldString UnidadeCompra
        {
            get { return unidade_compra; }
            set { unidade_compra = value; }
        }


        public MVC.DTO.FieldDecimal SaldoAnterior
        {
            get { return mtmd_estcon_qtde_anterior; }
            set { mtmd_estcon_qtde_anterior = value; }
        }


        public MVC.DTO.FieldDecimal QtdeTotalNota
        {
            get { return qtd_total_nota; }
            set { qtd_total_nota = value; }
        }

        public MVC.DTO.FieldDecimal IdMovRM
        {
            get { return idmov; }
            set { idmov = value; }
        }

		#endregion

        #region Operators

        public static explicit operator HistoricoNotaFiscalDTO(DataRow row)
        {
            HistoricoNotaFiscalDTO  dto = new HistoricoNotaFiscalDTO();
		
			dto.IdtProduto.Value = row[FieldNames.IdtProduto].ToString();
		
			dto.IdtFilial.Value = row[FieldNames.IdtFilial].ToString();
		
			dto.NrNota.Value = row[FieldNames.NrNota].ToString();
		
			dto.CustoMedio.Value = row[FieldNames.CustoMedio].ToString();
		
			dto.DataPrcMedio.Value = row[FieldNames.DataPrcMedio].ToString();
		
			dto.Qtde.Value = row[FieldNames.Qtde].ToString();
		
			dto.PrecoUnitario.Value = row[FieldNames.PrecoUnitario].ToString();

            dto.DsProduto.Value = row[FieldNames.DsProduto].ToString();

            dto.IdtLote.Value = row[FieldNames.IdtLote].ToString();            

            dto.NumLote.Value = row[FieldNames.NumLote].ToString();

            dto.DataValidadeProduto.Value = row[FieldNames.DataValidadeProduto].ToString();

            dto.DsFornecedor.Value = row[FieldNames.DsFornecedor].ToString();
            dto.TpMovimento.Value = row[FieldNames.TpMovimento].ToString();
            dto.UnidadeCompra.Value = row[FieldNames.UnidadeCompra].ToString();

            dto.SaldoAnterior.Value = row[FieldNames.SaldoAnterior].ToString();


            dto.QtdeTotalNota.Value = row[FieldNames.QtdeTotalNota].ToString();

            try
            {
                dto.IdMovRM.Value = row[FieldNames.IdMovRM].ToString();
                dto.CodLote.Value = row[FieldNames.CodLote].ToString();
            }
            catch
            {
                //deixa passar se não tiver coluna
            }            

            return dto;
        }

        public static explicit operator HistoricoNotaFiscalDTO(XmlDocument xml)
        {
            HistoricoNotaFiscalDTO dto = new HistoricoNotaFiscalDTO();
			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto) != null) dto.IdtProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial) != null) dto.IdtFilial.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.NrNota) != null) dto.NrNota.Value = xml.FirstChild.SelectSingleNode(FieldNames.NrNota).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.CustoMedio) != null) dto.CustoMedio.Value = xml.FirstChild.SelectSingleNode(FieldNames.CustoMedio).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.DataPrcMedio) != null) dto.DataPrcMedio.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataPrcMedio).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.Qtde) != null) dto.Qtde.Value = xml.FirstChild.SelectSingleNode(FieldNames.Qtde).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.PrecoUnitario) != null) dto.PrecoUnitario.Value = xml.FirstChild.SelectSingleNode(FieldNames.PrecoUnitario).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsProduto) != null) dto.DsProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsProduto).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLote) != null) dto.IdtLote.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLote).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.NumLote) != null) dto.NumLote.Value = xml.FirstChild.SelectSingleNode(FieldNames.NumLote).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DataValidadeProduto) != null) dto.DataValidadeProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataValidadeProduto).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsFornecedor) != null) dto.DsFornecedor.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsFornecedor).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.TpMovimento) != null) dto.TpMovimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.TpMovimento).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeCompra) != null) dto.UnidadeCompra.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeCompra).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.SaldoAnterior) != null) dto.SaldoAnterior.Value = xml.FirstChild.SelectSingleNode(FieldNames.SaldoAnterior).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeTotalNota) != null) dto.QtdeTotalNota.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeTotalNota).InnerText;
                       

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdtProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtProduto, null);
			
            XmlNode nodeIdtFilial = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFilial, null);
			
            XmlNode nodeNrNota = xml.CreateNode(XmlNodeType.Element, FieldNames.NrNota, null);
			
            XmlNode nodeCustoMedio = xml.CreateNode(XmlNodeType.Element, FieldNames.CustoMedio, null);
			
            XmlNode nodeDataPrcMedio = xml.CreateNode(XmlNodeType.Element, FieldNames.DataPrcMedio, null);
			
            XmlNode nodeQtde = xml.CreateNode(XmlNodeType.Element, FieldNames.Qtde, null);
			
            XmlNode nodePrecoUnitario = xml.CreateNode(XmlNodeType.Element, FieldNames.PrecoUnitario, null);

            XmlNode nodeDsProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.DsProduto, null);

            XmlNode nodeIdtLote = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLote, null);

            XmlNode nodeNumLote = xml.CreateNode(XmlNodeType.Element, FieldNames.NumLote, null);

            XmlNode nodeDataValidadeProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.DataValidadeProduto, null);

            XmlNode nodeDsFornecedor = xml.CreateNode(XmlNodeType.Element, FieldNames.DsFornecedor, null);
            XmlNode nodeTpMovimento = xml.CreateNode(XmlNodeType.Element, FieldNames.TpMovimento, null);
            XmlNode nodeUnidadeCompra = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeCompra, null);

            XmlNode nodeSaldoAnterior = xml.CreateNode(XmlNodeType.Element, FieldNames.SaldoAnterior, null);

            XmlNode nodeQtdeTotalNota = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeTotalNota, null);
            
            

			if (!this.IdtProduto.Value.IsNull) nodeIdtProduto.InnerText = this.IdtProduto.Value;
			
			if (!this.IdtFilial.Value.IsNull) nodeIdtFilial.InnerText = this.IdtFilial.Value;
			
			if (!this.NrNota.Value.IsNull) nodeNrNota.InnerText = this.NrNota.Value;
			
			if (!this.CustoMedio.Value.IsNull) nodeCustoMedio.InnerText = this.CustoMedio.Value;
			
			if (!this.DataPrcMedio.Value.IsNull) nodeDataPrcMedio.InnerText = this.DataPrcMedio.Value;
			
			if (!this.Qtde.Value.IsNull) nodeQtde.InnerText = this.Qtde.Value;
			
			if (!this.PrecoUnitario.Value.IsNull) nodePrecoUnitario.InnerText = this.PrecoUnitario.Value;

            if (!this.DsProduto.Value.IsNull) nodeDsProduto.InnerText = this.DsProduto.Value;

            if (!this.IdtLote.Value.IsNull) nodeIdtLote.InnerText = this.IdtLote.Value;

            if (!this.NumLote.Value.IsNull) nodeNumLote.InnerText = this.NumLote.Value;

            if (!this.DataValidadeProduto.Value.IsNull) nodeDataValidadeProduto.InnerText = this.DataValidadeProduto.Value;

            if (!this.DsFornecedor.Value.IsNull) nodeDsFornecedor.InnerText = this.DsFornecedor.Value;
            if (!this.TpMovimento.Value.IsNull) nodeTpMovimento.InnerText = this.TpMovimento.Value;
            if (!this.UnidadeCompra.Value.IsNull) nodeUnidadeCompra.InnerText = this.UnidadeCompra.Value;

            if (!this.SaldoAnterior.Value.IsNull) nodeSaldoAnterior.InnerText = this.SaldoAnterior.Value;

            if (!this.QtdeTotalNota.Value.IsNull) nodeQtdeTotalNota.InnerText = this.QtdeTotalNota.Value;

                        

            nodeData.AppendChild(nodeIdtProduto);
			
            nodeData.AppendChild(nodeIdtFilial);
			
            nodeData.AppendChild(nodeNrNota);
			
            nodeData.AppendChild(nodeCustoMedio);
			
            nodeData.AppendChild(nodeDataPrcMedio);
			
            nodeData.AppendChild(nodeQtde);
			
            nodeData.AppendChild(nodePrecoUnitario);

            nodeData.AppendChild(nodeDsProduto);

            nodeData.AppendChild(nodeIdtLote);

            nodeData.AppendChild(nodeNumLote);

            nodeData.AppendChild(nodeDataValidadeProduto);

            nodeData.AppendChild(nodeDsFornecedor);
            nodeData.AppendChild(nodeTpMovimento);
            nodeData.AppendChild(nodeUnidadeCompra);

            nodeData.AppendChild(nodeSaldoAnterior);

            nodeData.AppendChild(nodeQtdeTotalNota);

                     


            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(HistoricoNotaFiscalDTO dto)
        {
            HistoricoNotaFiscalDataTable dtb = new HistoricoNotaFiscalDataTable();
            DataRow dtr = dtb.NewRow();
			            
            dtr[FieldNames.IdtProduto] = dto.IdtProduto.Value;
			
            dtr[FieldNames.IdtFilial] = dto.IdtFilial.Value;
			
            dtr[FieldNames.NrNota] = dto.NrNota.Value;
			
            dtr[FieldNames.CustoMedio] = dto.CustoMedio.Value;
			
            dtr[FieldNames.DataPrcMedio] = dto.DataPrcMedio.Value;
			
            dtr[FieldNames.Qtde] = dto.Qtde.Value;
			
            dtr[FieldNames.PrecoUnitario] = dto.PrecoUnitario.Value;

            dtr[FieldNames.DsProduto] = dto.DsProduto.Value;

            dtr[FieldNames.IdtLote] = dto.IdtLote.Value;

            dtr[FieldNames.NumLote] = dto.NumLote.Value;

            dtr[FieldNames.DataValidadeProduto] = dto.DataValidadeProduto.Value;

            dtr[FieldNames.DsFornecedor] = dto.DsFornecedor.Value;
            dtr[FieldNames.TpMovimento] = dto.TpMovimento.Value;
            dtr[FieldNames.UnidadeCompra] = dto.UnidadeCompra.Value;

            dtr[FieldNames.SaldoAnterior] = dto.SaldoAnterior.Value;

            dtr[FieldNames.QtdeTotalNota] = dto.QtdeTotalNota.Value;
            
            dtr[FieldNames.IdMovRM] = dto.IdMovRM.Value;

            dtr[FieldNames.CodLote] = dto.CodLote.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(HistoricoNotaFiscalDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}