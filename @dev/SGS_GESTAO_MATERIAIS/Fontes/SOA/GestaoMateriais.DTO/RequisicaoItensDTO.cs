
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
	/// Classe Entidade RequisicaoItensDataTable 
	/// </summary>
	[Serializable()]
	public class RequisicaoItensDataTable : DataTable
	{		
	    public RequisicaoItensDataTable()
            : base()
        {
            this.TableName = "DADOS";

		    this.Columns.Add(RequisicaoItensDTO.FieldNames.Idt, typeof(Decimal));
		    this.Columns.Add(RequisicaoItensDTO.FieldNames.IdtProduto, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.DsProduto, typeof(String));
		    this.Columns.Add(RequisicaoItensDTO.FieldNames.QtdSolicitada, typeof(Decimal));
		    this.Columns.Add(RequisicaoItensDTO.FieldNames.QtdFornecida, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.DsUnidadeVenda, typeof(String));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.EstoqueLocalQtde, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.EstoqueCentDispQtde, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.UnidadeControle, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.UnidadeVenda, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.UnidadeCompra, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.QtdePadrao, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.EstoqueLocalPadraoQtde, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.IdtUsuarioDispensacao, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.DsProdutoOriginal, typeof(String));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.IdPrescricao, typeof(decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.IdtLote, typeof(decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.IdKitItem, typeof(decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.QtdKitItemMultiplica, typeof(decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.FlItemGeladeira, typeof(Decimal));

            this.Columns.Add(RequisicaoItensDTO.FieldNames.IdtNovo, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.DataHoraGerar, typeof(DateTime));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.IdUsuarioPedidoAutoCancelado, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.HorasPeriodoDose, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.QtdPedidoGerar, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente, typeof(DateTime));

            this.Columns.Add(RequisicaoItensDTO.FieldNames.IdPrescricaoItemInternacao, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.IdPrescricaoInternacao, typeof(Decimal));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.JustificativaCancelamento, typeof(String));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.DoseAdministrar, typeof(String));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.ObservacaoItem, typeof(String));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.StatusPrescricaoItem, typeof(String));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.TipoPrescricaoItem, typeof(String));
            this.Columns.Add(RequisicaoItensDTO.FieldNames.Via, typeof(String));

            //DataColumn[] primaryKey = { this.Columns[RequisicaoItensDTO.FieldNames.IdtProduto] };

            //this.PrimaryKey = primaryKey;
        }
		
        protected RequisicaoItensDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public RequisicaoItensDTO TypedRow(int index)
        {
            return (RequisicaoItensDTO)this.Rows[index];
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

        public void Add(RequisicaoItensDTO dto)
        {
            DataRow dtr = this.NewRow();

            if (!dto.IdtNovo.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.IdtNovo] = (Decimal)dto.IdtNovo.Value;
            if (!dto.DataHoraGerar.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.DataHoraGerar] = (DateTime)dto.DataHoraGerar.Value;
            if (!dto.IdUsuarioPedidoAutoCancelado.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.IdUsuarioPedidoAutoCancelado] = (Decimal)dto.IdUsuarioPedidoAutoCancelado.Value;
            if (!dto.HorasPeriodoDose.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.HorasPeriodoDose] = (Decimal)dto.HorasPeriodoDose.Value;
            if (!dto.QtdPedidoGerar.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.QtdPedidoGerar] = (Decimal)dto.QtdPedidoGerar.Value;
            if (!dto.DataHoraAdmPaciente.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente] = (DateTime)dto.DataHoraAdmPaciente.Value;

        if (!dto.IdtPrincipioAtivo.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.IdtPrincipioAtivo] = (Decimal)dto.IdtPrincipioAtivo.Value;
		if (!dto.Idt.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		if (!dto.IdtProduto.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.IdtProduto] = (Decimal)dto.IdtProduto.Value;
        if (!dto.DsProduto.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.DsProduto] = (String)dto.DsProduto.Value;
		if (!dto.QtdSolicitada.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.QtdSolicitada] = (Decimal)dto.QtdSolicitada.Value;
		if (!dto.QtdFornecida.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.QtdFornecida] = (Decimal)dto.QtdFornecida.Value;
        if (!dto.DsUnidadeVenda.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.DsUnidadeVenda] = (String)dto.DsUnidadeVenda.Value;
        if (!dto.EstoqueLocalQtde.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.EstoqueLocalQtde] = (Decimal)dto.EstoqueLocalQtde.Value;
        if (!dto.EstoqueCentDispQtde.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.EstoqueCentDispQtde] = (Decimal)dto.EstoqueCentDispQtde.Value;
        if (!dto.UnidadeControle.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.UnidadeControle] = (Decimal)dto.UnidadeControle.Value;
        if (!dto.UnidadeVenda.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.UnidadeVenda] = (Decimal)dto.UnidadeVenda.Value;
        if (!dto.UnidadeCompra.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.UnidadeCompra] = (Decimal)dto.UnidadeCompra.Value;
        if (!dto.QtdePadrao.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.QtdePadrao] = (Decimal)dto.QtdePadrao.Value;
        if (!dto.EstoqueLocalPadraoQtde.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.EstoqueLocalPadraoQtde] = (Decimal)dto.EstoqueLocalPadraoQtde.Value;
        if (!dto.IdtUsuarioDispensacao.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.IdtUsuarioDispensacao] = (Decimal)dto.IdtUsuarioDispensacao.Value;
        if (!dto.DsProdutoOriginal.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.DsProdutoOriginal] = (String)dto.DsProdutoOriginal.Value;
        if (!dto.IdPrescricao.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.IdPrescricao] = (decimal)dto.IdPrescricao.Value;
        if (!dto.IdtLote.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.IdtLote] = (decimal)dto.IdtLote.Value;
        if (!dto.IdKitItem.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.IdKitItem] = (decimal)dto.IdKitItem.Value;
        if (!dto.QtdKitItemMultiplica.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.QtdKitItemMultiplica] = (decimal)dto.QtdKitItemMultiplica.Value;

        if (!dto.IdPrescricaoItemInternacao.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.IdPrescricaoItemInternacao] = (Decimal)dto.IdPrescricaoItemInternacao.Value;
        if (!dto.IdPrescricaoInternacao.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.IdPrescricaoInternacao] = (Decimal)dto.IdPrescricaoInternacao.Value;
        if (!dto.JustificativaCancelamento.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.JustificativaCancelamento] = (String)dto.JustificativaCancelamento.Value;
        if (!dto.DoseAdministrar.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.DoseAdministrar] = (String)dto.DoseAdministrar.Value;
        if (!dto.ObservacaoItem.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.ObservacaoItem] = (String)dto.ObservacaoItem.Value;
        if (!dto.StatusPrescricaoItem.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.StatusPrescricaoItem] = (String)dto.StatusPrescricaoItem.Value;
        if (!dto.TipoPrescricaoItem.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.TipoPrescricaoItem] = (String)dto.TipoPrescricaoItem.Value;
        if (!dto.Via.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.Via] = (String)dto.Via.Value;

        if (!dto.FlItemGeladeira.Value.IsNull) dtr[RequisicaoItensDTO.FieldNames.FlItemGeladeira] = (Decimal)dto.FlItemGeladeira.Value;

        this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class RequisicaoItensDTO : MVC.DTO.DTOBase
    {	
		private MVC.DTO.FieldDecimal mtmd_req_id;
		private MVC.DTO.FieldDecimal cad_mtmd_id;
        private MVC.DTO.FieldString ds_produto;
		private MVC.DTO.FieldDecimal mtmd_reqitem_qtd_solicitada;
		private MVC.DTO.FieldDecimal mtmd_reqitem_qtd_fornecida;
        private MVC.DTO.FieldString ds_unidade_venda;
        private MVC.DTO.FieldDecimal mtmd_estloc_qtde;
        private MVC.DTO.FieldDecimal cad_mtmd_unidade_controle;
        private MVC.DTO.FieldDecimal cad_mtmd_unidade_venda;
        private MVC.DTO.FieldDecimal cad_mtmd_unidade_compra;
        private MVC.DTO.FieldDecimal mtmd_pedpad_qtde;
        private MVC.DTO.FieldDecimal mtmd_estloc_centdisp_qtde;
        private MVC.DTO.FieldDecimal cad_mtmd_priati_id;
        private MVC.DTO.FieldDecimal mtmd_estpadrao_local_qtde;
        private MVC.DTO.FieldDecimal mtmd_id_usuario_dispensacao;
        private MVC.DTO.FieldString ds_produto_original;
        private MVC.DTO.FieldDecimal cad_mtmd_prescricao_id;
        private MVC.DTO.FieldDecimal mtmd_lotest_id;
        private MVC.DTO.FieldDecimal cad_mtmd_kit_id_item;
        private MVC.DTO.FieldDecimal mtmd_qtd_kit_multiplica;
        private MVC.DTO.FieldDecimal mtmd_fl_geladeira;

        private MVC.DTO.FieldDecimal mtmd_req_id_novo;
        private MVC.DTO.FieldDateTime ria_data_hora_gerar;        
        private MVC.DTO.FieldDecimal ria_seg_id_usuario_cancelado;
        private MVC.DTO.FieldDecimal ria_qtd_hrs_periodo_dose;
        private MVC.DTO.FieldDecimal ria_qtd_pedido;
        private MVC.DTO.FieldDateTime ria_data_hora_adm_pac;

        private MVC.DTO.FieldDecimal atd_mpm_id;
        private MVC.DTO.FieldDecimal atd_pme_id;
        private MVC.DTO.FieldString mtmd_reqitem_cancel_just;
        private MVC.DTO.FieldString dose_adm;
        private MVC.DTO.FieldString obs_item;
        private MVC.DTO.FieldString status_prescricao_item;
        private MVC.DTO.FieldString atd_mpm_tipo;
        private MVC.DTO.FieldString mtmd_via;

        public RequisicaoItensDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
		    this.mtmd_req_id= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		    this.cad_mtmd_id= new MVC.DTO.FieldDecimal(FieldNames.IdtProduto,Captions.IdtProduto, DbType.Decimal);
            this.ds_produto = new MVC.DTO.FieldString(FieldNames.DsProduto, Captions.DsProduto, 100);
		    this.mtmd_reqitem_qtd_solicitada= new MVC.DTO.FieldDecimal(FieldNames.QtdSolicitada,Captions.QtdSolicitada, DbType.Decimal);
		    this.mtmd_reqitem_qtd_fornecida= new MVC.DTO.FieldDecimal(FieldNames.QtdFornecida,Captions.QtdFornecida, DbType.Decimal);
            this.ds_unidade_venda = new MVC.DTO.FieldString(FieldNames.DsUnidadeVenda, Captions.DsUnidadeVenda, 30);
            this.mtmd_estloc_qtde = new MVC.DTO.FieldDecimal(FieldNames.EstoqueLocalQtde, Captions.EstoqueLocalQtde, DbType.Decimal);
            this.cad_mtmd_unidade_controle = new MVC.DTO.FieldDecimal(FieldNames.UnidadeControle, Captions.UnidadeControle, DbType.Decimal);
            this.cad_mtmd_unidade_venda = new MVC.DTO.FieldDecimal(FieldNames.UnidadeVenda, Captions.UnidadeVenda, DbType.Decimal);
            this.cad_mtmd_unidade_compra = new MVC.DTO.FieldDecimal(FieldNames.UnidadeCompra, Captions.UnidadeCompra, DbType.Decimal);
            this.mtmd_pedpad_qtde = new MVC.DTO.FieldDecimal(FieldNames.QtdePadrao, Captions.QtdePadrao, DbType.Decimal);
            this.cad_mtmd_priati_id = new MVC.DTO.FieldDecimal(FieldNames.IdtPrincipioAtivo, Captions.IdtPrincipioAtivo, DbType.Decimal);
            this.mtmd_estloc_centdisp_qtde = new MVC.DTO.FieldDecimal(FieldNames.EstoqueCentDispQtde, Captions.EstoqueCentDispQtde, DbType.Decimal);
            this.mtmd_estpadrao_local_qtde = new MVC.DTO.FieldDecimal(FieldNames.EstoqueLocalPadraoQtde, Captions.EstoqueLocalPadraoQtde, DbType.Decimal);
            this.mtmd_id_usuario_dispensacao = new MVC.DTO.FieldDecimal(FieldNames.IdtUsuarioDispensacao, Captions.IdtUsuarioDispensacao, DbType.Decimal);
            this.ds_produto_original = new MVC.DTO.FieldString(FieldNames.DsProdutoOriginal, Captions.DsProdutoOriginal, 100);
            this.cad_mtmd_prescricao_id = new MVC.DTO.FieldDecimal(FieldNames.IdPrescricao, Captions.IdPrescricao, DbType.Decimal);
            this.mtmd_lotest_id = new MVC.DTO.FieldDecimal(FieldNames.IdtLote, Captions.IdtLote, DbType.Decimal);
            this.cad_mtmd_kit_id_item = new MVC.DTO.FieldDecimal(FieldNames.IdKitItem, Captions.IdKitItem, DbType.Decimal);
            this.mtmd_qtd_kit_multiplica = new MVC.DTO.FieldDecimal(FieldNames.QtdKitItemMultiplica, Captions.QtdKitItemMultiplica, DbType.Decimal);
            this.mtmd_fl_geladeira = new MVC.DTO.FieldDecimal(FieldNames.FlItemGeladeira, Captions.FlItemGeladeira, DbType.Decimal);

            this.mtmd_req_id_novo = new MVC.DTO.FieldDecimal(FieldNames.IdtNovo, Captions.IdtNovo, DbType.Decimal);
            this.ria_data_hora_gerar = new MVC.DTO.FieldDateTime(FieldNames.DataHoraGerar, Captions.DataHoraGerar);
            this.ria_seg_id_usuario_cancelado = new MVC.DTO.FieldDecimal(FieldNames.IdUsuarioPedidoAutoCancelado, Captions.IdUsuarioPedidoAutoCancelado, DbType.Decimal);
            this.ria_qtd_hrs_periodo_dose = new MVC.DTO.FieldDecimal(FieldNames.HorasPeriodoDose, Captions.HorasPeriodoDose, DbType.Decimal);
            this.ria_qtd_pedido = new MVC.DTO.FieldDecimal(FieldNames.QtdPedidoGerar, Captions.QtdPedidoGerar, DbType.Decimal);
            this.ria_data_hora_adm_pac = new MVC.DTO.FieldDateTime(FieldNames.DataHoraAdmPaciente, Captions.DataHoraAdmPaciente);

            this.atd_mpm_id = new MVC.DTO.FieldDecimal(FieldNames.IdPrescricaoItemInternacao, Captions.IdPrescricaoItemInternacao, DbType.Decimal);
            this.atd_pme_id = new MVC.DTO.FieldDecimal(FieldNames.IdPrescricaoInternacao, Captions.IdPrescricaoInternacao, DbType.Decimal);
            this.mtmd_reqitem_cancel_just = new MVC.DTO.FieldString(FieldNames.JustificativaCancelamento, Captions.JustificativaCancelamento, 100);
            this.dose_adm = new MVC.DTO.FieldString(FieldNames.DoseAdministrar, Captions.DoseAdministrar, 50);
            this.obs_item = new MVC.DTO.FieldString(FieldNames.ObservacaoItem, Captions.ObservacaoItem, 500);
            this.status_prescricao_item = new MVC.DTO.FieldString(FieldNames.StatusPrescricaoItem, Captions.StatusPrescricaoItem, 2);
            this.atd_mpm_tipo = new MVC.DTO.FieldString(FieldNames.TipoPrescricaoItem, Captions.TipoPrescricaoItem, 3);
            this.mtmd_via = new MVC.DTO.FieldString(FieldNames.Via, Captions.Via, 20);
        }
 
        #region FieldNames

        public struct FieldNames
        {
		    public const string Idt="MTMD_REQ_ID";
		    public const string IdtProduto="CAD_MTMD_ID";
            public const string DsProduto ="CAD_MTMD_NOMEFANTASIA";
		    public const string QtdSolicitada="MTMD_REQITEM_QTD_SOLICITADA";
		    public const string QtdFornecida="MTMD_REQITEM_QTD_FORNECIDA";
            public const string DsUnidadeVenda = "CAD_MTMD_UNID_VENDA_DS";
            public const string EstoqueLocalQtde = "MTMD_ESTLOC_QTDE";
            public const string UnidadeControle = "CAD_MTMD_UNIDADE_CONTROLE";
            public const string UnidadeVenda = "CAD_MTMD_UNIDADE_VENDA";
            public const string UnidadeCompra = "CAD_MTMD_UNIDADE_COMPRA";
            public const string QtdePadrao = "MTMD_PEDPAD_QTDE";
            public const string IdtPrincipioAtivo = "CAD_MTMD_PRIATI_ID";
            public const string EstoqueCentDispQtde = "MTMD_ESTLOC_CENTDISP_QTDE";
            public const string EstoqueLocalPadraoQtde = "MTMD_ESTPADRAO_LOCAL_QTDE";
            public const string IdtUsuarioDispensacao = "MTMD_ID_USUARIO_DISPENSACAO";
            public const string DsProdutoOriginal = "DS_PRODUTO_ORIGINAL";
            public const string IdPrescricao = "CAD_MTMD_PRESCRICAO_ID";
            public const string IdtLote = "MTMD_LOTEST_ID";
            public const string IdKitItem = "CAD_MTMD_KIT_ID_ITEM";
            public const string QtdKitItemMultiplica = "MTMD_QTD_KIT_MULTIPLICA";
            public const string FlItemGeladeira = "MTMD_FL_GELADEIRA";

            public const string IdtNovo = "MTMD_REQ_ID_NOVO";
            public const string DataHoraGerar = "RIA_DATA_HORA_GERAR";
            public const string IdUsuarioPedidoAutoCancelado = "RIA_SEG_ID_USUARIO_CANCELADO";
            public const string HorasPeriodoDose = "RIA_QTD_HRS_PERIODO_DOSE";
            public const string QtdPedidoGerar = "RIA_QTD_PEDIDO";
            public const string DataHoraAdmPaciente = "RIA_DATA_HORA_ADM_PAC";

            public const string IdPrescricaoItemInternacao = "ATD_MPM_ID";
            public const string IdPrescricaoInternacao = "ATD_PME_ID";
            public const string JustificativaCancelamento = "MTMD_REQITEM_CANCEL_JUST";
            public const string DoseAdministrar = "DOSE_ADM";
            public const string ObservacaoItem = "DS_OBSERVACAO";
            public const string StatusPrescricaoItem = "STATUS_PRESCRICAO_ITEM";
            public const string TipoPrescricaoItem = "ATD_MPM_TIPO";
            public const string Via = "MTMD_REQ_VIA";
        }

        #endregion

        #region Captions

        public struct Captions
        {
		    public const string Idt="IDT";
		    public const string IdtProduto="IdtProduto";
		    public const string QtdSolicitada="QTDSOLICITADA";
		    public const string QtdFornecida="QTDFORNECIDA";
            public const string DsProduto = "NOMEFANTASIA";
            public const string DsUnidadeVenda = "DSUNIDADEVENDA";
            public const string EstoqueLocalQtde = "MTMDESTLOCQTDE";
            public const string UnidadeControle = "UNIDADECONTROLE";
            public const string UnidadeVenda = "UNIDADEVENDA";
            public const string UnidadeCompra = "UNIDADECOMPRA";
            public const string QtdePadrao = "QTDEPADRAO";
            public const string IdtPrincipioAtivo = "IdtPrincipioAtivo";
            public const string EstoqueCentDispQtde = "MTMDESTLOCCENTDISPQTDE";
            public const string EstoqueLocalPadraoQtde = "MTMDESTPADRAOLOCALQTDE";
            public const string IdtUsuarioDispensacao = "IDTUSUARIODISPENSACAO";
            public const string DsProdutoOriginal = "DSPRODUTOORIGINAL";
            public const string IdPrescricao = "CADMTMDPRESCRICAOID";
            public const string IdtLote = "IDTLOTE";
            public const string IdKitItem = "KITIDITEM";
            public const string QtdKitItemMultiplica = "QTDKITMULTIPLICA";
            public const string FlItemGeladeira = "FLGELADEIRA";

            public const string IdtNovo = "MTMD_REQ_ID_NOVO";
            public const string DataHoraGerar = "RIA_DATA_HORA_GERAR";
            public const string IdUsuarioPedidoAutoCancelado = "RIA_SEG_ID_USUARIO_CANCELADO";
            public const string HorasPeriodoDose = "RIA_QTD_HRS_PERIODO_DOSE";
            public const string QtdPedidoGerar = "RIA_QTD_PEDIDO";
            public const string DataHoraAdmPaciente = "RIA_DATA_HORA_ADM_PAC";

            public const string IdPrescricaoItemInternacao = "ATD_MPM_ID";
            public const string IdPrescricaoInternacao = "ATD_PME_ID";
            public const string JustificativaCancelamento = "MTMD_REQITEM_CANCEL_JUST";
            public const string DoseAdministrar = "DOSE_ADM";
            public const string ObservacaoItem = "DS_OBSERVACAO";
            public const string StatusPrescricaoItem = "STATUS_PRESCRICAO_ITEM";
            public const string TipoPrescricaoItem = "ATD_MPM_TIPO";
            public const string Via = "MTMD_REQ_VIA";
        }		

        #endregion
		
        #region Atributos Publicos

        public MVC.DTO.FieldDecimal IdtNovo
        {
            get { return mtmd_req_id_novo; }
            set { mtmd_req_id_novo = value; }
        }

        public MVC.DTO.FieldDateTime DataHoraGerar
        {
            get { return ria_data_hora_gerar; }
            set { ria_data_hora_gerar = value; }
        }

        public MVC.DTO.FieldDecimal IdUsuarioPedidoAutoCancelado
        {
            get { return ria_seg_id_usuario_cancelado; }
            set { ria_seg_id_usuario_cancelado = value; }
        }

        public MVC.DTO.FieldDecimal HorasPeriodoDose
        {
            get { return ria_qtd_hrs_periodo_dose; }
            set { ria_qtd_hrs_periodo_dose = value; }
        }

        public MVC.DTO.FieldDecimal QtdPedidoGerar
        {
            get { return ria_qtd_pedido; }
            set { ria_qtd_pedido = value; }
        }

        public MVC.DTO.FieldDateTime DataHoraAdmPaciente
        {
            get { return ria_data_hora_adm_pac; }
            set { ria_data_hora_adm_pac = value; }
        }

		public MVC.DTO.FieldDecimal Idt
		{
			get { return mtmd_req_id; }
			set { mtmd_req_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtProduto
		{
			get { return cad_mtmd_id; }
			set { cad_mtmd_id = value; }
		}

        public MVC.DTO.FieldString DsProduto
        {
            get { return ds_produto; }
            set { ds_produto = value; }
        }		

		public MVC.DTO.FieldDecimal QtdSolicitada
		{
			get { return mtmd_reqitem_qtd_solicitada; }
			set { mtmd_reqitem_qtd_solicitada = value; }
		}
		
		public MVC.DTO.FieldDecimal QtdFornecida
		{
			get { return mtmd_reqitem_qtd_fornecida; }
			set { mtmd_reqitem_qtd_fornecida = value; }
		}					

		public MVC.DTO.FieldDecimal UnidadeControle
		{
            get { return cad_mtmd_unidade_controle; }
            set { cad_mtmd_unidade_controle = value; }
		}

        public MVC.DTO.FieldDecimal UnidadeVenda
        {
            get { return cad_mtmd_unidade_venda; }
            set { cad_mtmd_unidade_venda = value; }
        }

        public MVC.DTO.FieldDecimal UnidadeCompra
        {
            get { return cad_mtmd_unidade_compra; }
            set { cad_mtmd_unidade_compra = value; }
        }

        public MVC.DTO.FieldString DsUnidadeVenda
        {
            get { return ds_unidade_venda; }
            set { ds_unidade_venda = value; }
        }

        public MVC.DTO.FieldDecimal EstoqueLocalQtde
        {
            get { return mtmd_estloc_qtde; }
            set { mtmd_estloc_qtde = value; }
        }

        public MVC.DTO.FieldDecimal EstoqueCentDispQtde
        {
            get { return mtmd_estloc_centdisp_qtde; }
            set { mtmd_estloc_centdisp_qtde = value; }
        }

        public MVC.DTO.FieldDecimal QtdePadrao
        {
            get { return mtmd_pedpad_qtde; }
            set { mtmd_pedpad_qtde = value; }
        }

        public MVC.DTO.FieldDecimal IdtPrincipioAtivo
        {
            get { return cad_mtmd_priati_id; }
            set { cad_mtmd_priati_id = value; }
        }

        public MVC.DTO.FieldDecimal EstoqueLocalPadraoQtde
        {
            get { return mtmd_estpadrao_local_qtde; }
            set { mtmd_estpadrao_local_qtde = value; }
        }

        public MVC.DTO.FieldDecimal IdtUsuarioDispensacao
        {
            get { return mtmd_id_usuario_dispensacao; }
            set { mtmd_id_usuario_dispensacao = value; }
        }

        /// <summary>
        /// descrição do Produto original da requisição, se produto atual for um similar
        /// </summary>
        public MVC.DTO.FieldString DsProdutoOriginal
        {
            get { return ds_produto_original; }
            set { ds_produto_original = value; }
        }

        public MVC.DTO.FieldDecimal IdPrescricao
        {
            get { return cad_mtmd_prescricao_id; }
            set { cad_mtmd_prescricao_id = value; }
        }

        public MVC.DTO.FieldDecimal IdtLote
        {
            get { return mtmd_lotest_id; }
            set { mtmd_lotest_id = value; }
        }

        public MVC.DTO.FieldDecimal IdKitItem
        {
            get { return cad_mtmd_kit_id_item; }
            set { cad_mtmd_kit_id_item = value; }        
        }

        public MVC.DTO.FieldDecimal QtdKitItemMultiplica
        {
            get { return mtmd_qtd_kit_multiplica; }
            set { mtmd_qtd_kit_multiplica = value; }
        }

        public MVC.DTO.FieldDecimal IdPrescricaoItemInternacao
        {
            get { return atd_mpm_id; }
            set { atd_mpm_id = value; }
        }

        public MVC.DTO.FieldDecimal IdPrescricaoInternacao
        {
            get { return atd_pme_id; }
            set { atd_pme_id = value; }
        }

        public MVC.DTO.FieldString JustificativaCancelamento
        {
            get { return ds_produto_original; }
            set { mtmd_reqitem_cancel_just = value; }
        }

        public MVC.DTO.FieldString DoseAdministrar
        {
            get { return dose_adm; }
            set { dose_adm = value; }
        }

        public MVC.DTO.FieldString ObservacaoItem
        {
            get { return obs_item; }
            set { obs_item = value; }
        }

        public MVC.DTO.FieldString StatusPrescricaoItem
        {
            get { return status_prescricao_item; }
            set { status_prescricao_item = value; }
        }

        public MVC.DTO.FieldString TipoPrescricaoItem
        {
            get { return atd_mpm_tipo; }
            set { atd_mpm_tipo = value; }
        }

        public MVC.DTO.FieldString Via
        {
            get { return mtmd_via; }
            set { mtmd_via = value; }
        }

        public MVC.DTO.FieldDecimal FlItemGeladeira
        {
            get { return mtmd_fl_geladeira; }
            set { mtmd_fl_geladeira = value; }
        }

		#endregion

        #region Operators

        public static explicit operator RequisicaoItensDTO(DataRow row)
        {
                RequisicaoItensDTO  dto = new RequisicaoItensDTO();

				dto.Idt.Value = row[FieldNames.Idt].ToString();
			
				dto.IdtProduto.Value = row[FieldNames.IdtProduto].ToString();

                dto.DsProduto.Value = row[FieldNames.DsProduto].ToString();
			
				dto.QtdSolicitada.Value = row[FieldNames.QtdSolicitada].ToString();
			
				dto.QtdFornecida.Value = row[FieldNames.QtdFornecida].ToString();

                dto.DsUnidadeVenda.Value = row[FieldNames.DsUnidadeVenda].ToString();

                dto.EstoqueLocalQtde.Value = row[FieldNames.EstoqueLocalQtde].ToString();
                dto.EstoqueCentDispQtde.Value = row[FieldNames.EstoqueCentDispQtde].ToString();

                dto.UnidadeControle.Value = row[FieldNames.UnidadeControle].ToString();
                dto.UnidadeVenda.Value = row[FieldNames.UnidadeVenda].ToString();
                dto.UnidadeCompra.Value = row[FieldNames.UnidadeCompra].ToString();
                dto.QtdePadrao.Value = row[FieldNames.QtdePadrao].ToString();
                dto.IdtPrincipioAtivo.Value = row[FieldNames.IdtPrincipioAtivo].ToString();
                dto.EstoqueLocalPadraoQtde.Value = row[FieldNames.EstoqueLocalPadraoQtde].ToString();
                dto.IdtUsuarioDispensacao.Value = row[FieldNames.IdtUsuarioDispensacao].ToString();

                dto.DsProdutoOriginal.Value = row[FieldNames.DsProdutoOriginal].ToString();
                dto.IdPrescricao.Value = row[FieldNames.IdPrescricao].ToString();

                try
                {
                    dto.IdtLote.Value = row[FieldNames.IdtLote].ToString();
                    dto.IdKitItem.Value = row[FieldNames.IdKitItem].ToString();
                    dto.QtdKitItemMultiplica.Value = row[FieldNames.QtdKitItemMultiplica].ToString();

                    dto.IdtNovo.Value = row[FieldNames.IdtNovo].ToString();
                    dto.DataHoraGerar.Value = row[FieldNames.DataHoraGerar].ToString();
                    dto.IdUsuarioPedidoAutoCancelado.Value = row[FieldNames.IdUsuarioPedidoAutoCancelado].ToString();
                    dto.HorasPeriodoDose.Value = row[FieldNames.HorasPeriodoDose].ToString();
                    dto.QtdPedidoGerar.Value = row[FieldNames.QtdPedidoGerar].ToString();
                    dto.DataHoraAdmPaciente.Value = row[FieldNames.DataHoraAdmPaciente].ToString();

                    dto.IdPrescricaoItemInternacao.Value = row[FieldNames.IdPrescricaoItemInternacao].ToString();
                    dto.IdPrescricaoInternacao.Value = row[FieldNames.IdPrescricaoInternacao].ToString();
                    dto.JustificativaCancelamento.Value = row[FieldNames.JustificativaCancelamento].ToString();
                    dto.DoseAdministrar.Value = row[FieldNames.DoseAdministrar].ToString();
                    dto.ObservacaoItem.Value = row[FieldNames.ObservacaoItem].ToString();
                    dto.StatusPrescricaoItem.Value = row[FieldNames.StatusPrescricaoItem].ToString();
                    dto.TipoPrescricaoItem.Value = row[FieldNames.TipoPrescricaoItem].ToString();
                    dto.Via.Value = row[FieldNames.Via].ToString();

                    dto.FlItemGeladeira.Value = row[FieldNames.FlItemGeladeira].ToString();    
                }
                catch
                {
                    //deixa passar se não tiver coluna
                }    
                
            return dto;
        }

        public static explicit operator RequisicaoItensDTO(XmlDocument xml)
        {
            RequisicaoItensDTO dto = new RequisicaoItensDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto) != null) dto.IdtProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.DsProduto) != null) dto.DsProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsProduto).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.QtdSolicitada) != null) dto.QtdSolicitada.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdSolicitada).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.QtdFornecida) != null) dto.QtdFornecida.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdFornecida).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeVenda) != null) dto.DsUnidadeVenda.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeVenda).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.EstoqueLocalQtde) != null) dto.EstoqueLocalQtde.Value = xml.FirstChild.SelectSingleNode(FieldNames.EstoqueLocalQtde).InnerText;
                if (xml.FirstChild.SelectSingleNode(FieldNames.EstoqueCentDispQtde) != null) dto.EstoqueCentDispQtde.Value = xml.FirstChild.SelectSingleNode(FieldNames.EstoqueCentDispQtde).InnerText;
                if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeControle) != null) dto.UnidadeControle.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeControle).InnerText;
                if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeVenda) != null) dto.UnidadeVenda.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeVenda).InnerText;
                if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeCompra) != null) dto.UnidadeCompra.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeCompra).InnerText;
                if (xml.FirstChild.SelectSingleNode(FieldNames.IdtPrincipioAtivo) != null) dto.IdtPrincipioAtivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtPrincipioAtivo).InnerText;
                if (xml.FirstChild.SelectSingleNode(FieldNames.QtdePadrao) != null) dto.QtdePadrao.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdePadrao).InnerText;
                if (xml.FirstChild.SelectSingleNode(FieldNames.EstoqueLocalPadraoQtde) != null) dto.EstoqueLocalPadraoQtde.Value = xml.FirstChild.SelectSingleNode(FieldNames.EstoqueLocalPadraoQtde).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioDispensacao) != null) dto.IdtUsuarioDispensacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioDispensacao).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.DsProdutoOriginal) != null) dto.DsProdutoOriginal.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsProdutoOriginal).InnerText;

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeIdtProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtProduto, null);

            XmlNode nodeDsProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.DsProduto, null);
			
            XmlNode nodeQtdSolicitada = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdSolicitada, null);
			
            XmlNode nodeQtdFornecida = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdFornecida, null);

            XmlNode nodeDsUnidadeVenda = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidadeVenda, null);

            XmlNode nodeEstoqueLocalQtde = xml.CreateNode(XmlNodeType.Element, FieldNames.EstoqueLocalQtde, null);
            XmlNode nodeEstoqueCentDispQtde = xml.CreateNode(XmlNodeType.Element, FieldNames.EstoqueCentDispQtde, null);
            XmlNode nodeUnidadeControle = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeControle, null);
            XmlNode nodeUnidadeVenda = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeVenda, null);
            XmlNode nodeUnidadeCompra = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeCompra, null);

            XmlNode nodeQtdePadrao = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdePadrao, null);
            XmlNode nodeIdtPrincipioAtivo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtPrincipioAtivo, null);
            XmlNode nodeEstoqueLocalPadraoQtde = xml.CreateNode(XmlNodeType.Element, FieldNames.EstoqueLocalPadraoQtde, null);
            XmlNode nodeIdtUsuarioDispensacao = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuarioDispensacao, null);

            XmlNode nodeDsProdutoOriginal = xml.CreateNode(XmlNodeType.Element, FieldNames.DsProdutoOriginal, null);
                        

			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
            if (!this.IdtPrincipioAtivo.Value.IsNull) nodeIdtPrincipioAtivo.InnerText = this.IdtPrincipioAtivo.Value;
			if (!this.IdtProduto.Value.IsNull) nodeIdtProduto.InnerText = this.IdtProduto.Value;

            if (!this.DsProduto.Value.IsNull) nodeDsProduto.InnerText = this.DsProduto.Value;
			
			if (!this.QtdSolicitada.Value.IsNull) nodeQtdSolicitada.InnerText = this.QtdSolicitada.Value;
			
			if (!this.QtdFornecida.Value.IsNull) nodeQtdFornecida.InnerText = this.QtdFornecida.Value;

            if (!this.DsUnidadeVenda.Value.IsNull) nodeDsUnidadeVenda.InnerText = this.DsUnidadeVenda.Value;

            if (!this.EstoqueLocalQtde.Value.IsNull) nodeEstoqueLocalQtde.InnerText = this.EstoqueLocalQtde.Value;
            if (!this.EstoqueCentDispQtde.Value.IsNull) nodeEstoqueCentDispQtde.InnerText = this.EstoqueCentDispQtde.Value;
            if (!this.UnidadeControle.Value.IsNull) nodeUnidadeControle.InnerText = this.UnidadeControle.Value;
            if (!this.UnidadeVenda.Value.IsNull) nodeUnidadeVenda.InnerText = this.UnidadeVenda.Value;
            if (!this.UnidadeCompra.Value.IsNull) nodeUnidadeCompra.InnerText = this.UnidadeCompra.Value;
            if (!this.EstoqueLocalPadraoQtde.Value.IsNull) nodeEstoqueLocalPadraoQtde.InnerText = this.EstoqueLocalPadraoQtde.Value;
            if (!this.QtdePadrao.Value.IsNull) nodeQtdePadrao.InnerText = this.QtdePadrao.Value;
            if (!this.IdtUsuarioDispensacao.Value.IsNull) nodeIdtUsuarioDispensacao.InnerText = this.IdtUsuarioDispensacao.Value;

            if (!this.DsProdutoOriginal.Value.IsNull) nodeDsProdutoOriginal.InnerText = this.DsProdutoOriginal.Value;

                      

            nodeData.AppendChild(nodeIdt);
            nodeData.AppendChild(nodeIdtPrincipioAtivo);
            nodeData.AppendChild(nodeIdtProduto);

            nodeData.AppendChild(nodeDsProduto);
			
            nodeData.AppendChild(nodeQtdSolicitada);

            nodeData.AppendChild(nodeDsUnidadeVenda);

            nodeData.AppendChild(nodeEstoqueLocalQtde);
            nodeData.AppendChild(nodeEstoqueCentDispQtde);
            nodeData.AppendChild(nodeUnidadeControle);
            nodeData.AppendChild(nodeUnidadeVenda);
            nodeData.AppendChild(nodeUnidadeCompra);
            nodeData.AppendChild(nodeEstoqueLocalPadraoQtde);
            nodeData.AppendChild(nodeQtdePadrao);
            nodeData.AppendChild(nodeIdtUsuarioDispensacao);
            nodeData.AppendChild(nodeDsProdutoOriginal);
                      

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(RequisicaoItensDTO dto)
        {
            RequisicaoItensDataTable dtb = new RequisicaoItensDataTable();
            DataRow dtr = dtb.NewRow();

            dtr[FieldNames.IdtNovo] = dto.IdtNovo.Value;
            dtr[FieldNames.DataHoraGerar] = dto.DataHoraGerar.Value;
            dtr[FieldNames.IdUsuarioPedidoAutoCancelado] = dto.IdUsuarioPedidoAutoCancelado.Value;
            dtr[FieldNames.HorasPeriodoDose] = dto.HorasPeriodoDose.Value;
            dtr[FieldNames.QtdPedidoGerar] = dto.QtdPedidoGerar.Value;
            dtr[FieldNames.DataHoraAdmPaciente] = dto.DataHoraAdmPaciente.Value;

            dtr[FieldNames.Idt] = dto.Idt.Value;
            dtr[FieldNames.IdtPrincipioAtivo] = dto.IdtPrincipioAtivo.Value;
            dtr[FieldNames.IdtProduto] = dto.IdtProduto.Value;

            dtr[FieldNames.DsProduto] = dto.DsProduto.Value;
			
            dtr[FieldNames.QtdSolicitada] = dto.QtdSolicitada.Value;
			
            dtr[FieldNames.QtdFornecida] = dto.QtdFornecida.Value;

            dtr[FieldNames.DsUnidadeVenda] = dto.DsUnidadeVenda.Value;

            dtr[FieldNames.EstoqueLocalQtde] = dto.EstoqueLocalQtde.Value;
            dtr[FieldNames.EstoqueCentDispQtde] = dto.EstoqueCentDispQtde.Value;
            dtr[FieldNames.UnidadeControle] = dto.UnidadeControle.Value;
            dtr[FieldNames.UnidadeVenda] = dto.UnidadeVenda.Value;
            dtr[FieldNames.UnidadeCompra] = dto.UnidadeCompra.Value;
            dtr[FieldNames.EstoqueLocalPadraoQtde] = dto.EstoqueLocalPadraoQtde.Value;
            dtr[FieldNames.QtdePadrao] = dto.QtdePadrao.Value;
            dtr[FieldNames.IdtUsuarioDispensacao] = dto.IdtUsuarioDispensacao.Value;

            dtr[FieldNames.DsProdutoOriginal] = dto.DsProdutoOriginal.Value;
            dtr[FieldNames.IdPrescricao] = dto.IdPrescricao.Value;
            dtr[FieldNames.IdtLote] = dto.IdtLote.Value;
            dtr[FieldNames.IdKitItem] = dto.IdKitItem.Value;
            dtr[FieldNames.QtdKitItemMultiplica] = dto.QtdKitItemMultiplica.Value;

            dtr[FieldNames.IdPrescricaoItemInternacao] = dto.IdPrescricaoItemInternacao.Value;
            dtr[FieldNames.IdPrescricaoInternacao] = dto.IdPrescricaoInternacao.Value;
            dtr[FieldNames.JustificativaCancelamento] = dto.JustificativaCancelamento.Value;
            dtr[FieldNames.DoseAdministrar] = dto.DoseAdministrar.Value;
            dtr[FieldNames.ObservacaoItem] = dto.ObservacaoItem.Value;
            dtr[FieldNames.StatusPrescricaoItem] = dto.StatusPrescricaoItem.Value;
            dtr[FieldNames.TipoPrescricaoItem] = dto.TipoPrescricaoItem.Value;
            dtr[FieldNames.Via] = dto.Via.Value;
            dtr[FieldNames.FlItemGeladeira] = dto.FlItemGeladeira.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(RequisicaoItensDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}