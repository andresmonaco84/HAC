
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
	/// Classe Entidade EstoqueLocalDataTable
	/// </summary>
	[Serializable()]
	public class EstoqueLocalDataTable : DataTable
	{
		
	    public EstoqueLocalDataTable()
            : base()
        {
            this.TableName = "DADOS";

		
            this.Columns.Add(EstoqueLocalDTO.FieldNames.IdtProduto, typeof(Decimal));
		    this.Columns.Add(EstoqueLocalDTO.FieldNames.IdtLote, typeof(Decimal));
		    this.Columns.Add(EstoqueLocalDTO.FieldNames.IdtSetor, typeof(Decimal));
		    this.Columns.Add(EstoqueLocalDTO.FieldNames.IdtLocal, typeof(Decimal));
		    this.Columns.Add(EstoqueLocalDTO.FieldNames.IdtUnidade, typeof(Decimal));
		    this.Columns.Add(EstoqueLocalDTO.FieldNames.DataAtualizacao, typeof(DateTime));
		    this.Columns.Add(EstoqueLocalDTO.FieldNames.Qtde, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.QtdeLote, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.QtdePadrao, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.IdtFilial, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.FlPadrao, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.Consumido, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.Percentual, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.OutrosConsumos, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.DsProduto, typeof(String));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.QtdeFracionada, typeof(Decimal));

            this.Columns.Add(EstoqueLocalDTO.FieldNames.UnidadeVenda, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.UnidadeCompra, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.UnidadeControle, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.UnidadeConsumo, typeof(Decimal));

            this.Columns.Add(EstoqueLocalDTO.FieldNames.DsUnidadeVenda, typeof(String));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.DsUnidadeCompra, typeof(String));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.DsUnidadeControle, typeof(String));

            this.Columns.Add(EstoqueLocalDTO.FieldNames.DsUnidade, typeof(String));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.DsSetor, typeof(String));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.DsFilial, typeof(String));

            this.Columns.Add(EstoqueLocalDTO.FieldNames.Tabelamedica, typeof(String));

            this.Columns.Add(EstoqueLocalDTO.FieldNames.FlFracionado, typeof(Decimal));

            this.Columns.Add(EstoqueLocalDTO.FieldNames.IdtUsuario, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.Origem, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.SaldoMovimentacao, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.PontoRessuprimento, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.DataFornecimento, typeof(DateTime));

            this.Columns.Add(EstoqueLocalDTO.FieldNames.BaixaAutomatica, typeof(Decimal));

            this.Columns.Add(EstoqueLocalDTO.FieldNames.DsProdutoOriginal, typeof(String));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.IdtProdutoOriginal, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.IdtPrincipioAtivo, typeof(Decimal));

            this.Columns.Add(EstoqueLocalDTO.FieldNames.FlFaturado, typeof(Decimal));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.QtdCE, typeof(Decimal));


            this.Columns.Add(EstoqueLocalDTO.FieldNames.FlAtivo, typeof(Decimal));

            this.Columns.Add(EstoqueLocalDTO.FieldNames.FlReutilizavel, typeof(Decimal));

            this.Columns.Add(EstoqueLocalDTO.FieldNames.CodLote, typeof(String));
            this.Columns.Add(EstoqueLocalDTO.FieldNames.DataAtualizaLote, typeof(DateTime));

            //DataColumn[] primaryKey = { this.Columns[EstoqueLocalDTO.FieldNames.IdtProduto] };

            //this.PrimaryKey = primaryKey;
        }
		
        protected EstoqueLocalDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public EstoqueLocalDTO TypedRow(int index)
        {
            return (EstoqueLocalDTO)this.Rows[index];
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

        public void Add(EstoqueLocalDTO dto)
        {
            DataRow dtr = this.NewRow();


            if (!dto.IdtProduto.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.IdtProduto] = (Decimal)dto.IdtProduto.Value;
		    if (!dto.IdtLote.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.IdtLote] = (Decimal)dto.IdtLote.Value;
		    if (!dto.IdtSetor.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.IdtSetor] = (Decimal)dto.IdtSetor.Value;
		    if (!dto.IdtLocal.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.IdtLocal] = (Decimal)dto.IdtLocal.Value;
		    if (!dto.IdtUnidade.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;
		    if (!dto.DataAtualizacao.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.DataAtualizacao] = (DateTime)dto.DataAtualizacao.Value;
		    if (!dto.Qtde.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.Qtde] = (Decimal)dto.Qtde.Value;
            if (!dto.QtdeLote.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.QtdeLote] = (Decimal)dto.QtdeLote.Value;
            if (!dto.QtdePadrao.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.QtdePadrao] = (Decimal)dto.QtdePadrao.Value;
            if (!dto.DsProduto.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.DsProduto] = (String)dto.DsProduto.Value;
            if (!dto.IdtFilial.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.IdtFilial] = (Decimal)dto.IdtFilial.Value;
            if (!dto.FlPadrao.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.FlPadrao] = (Decimal)dto.FlPadrao.Value;

            if (!dto.OutrosConsumos.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.OutrosConsumos] = (Decimal)dto.OutrosConsumos.Value;
            if (!dto.Consumido.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.Consumido] = (Decimal)dto.Consumido.Value;
            if (!dto.Percentual.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.Percentual] = (Decimal)dto.Percentual.Value;
            if (!dto.QtdeFracionada.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.QtdeFracionada] = (Decimal)dto.QtdeFracionada.Value;

            if (!dto.UnidadeVenda.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.UnidadeVenda] = (Decimal)dto.UnidadeVenda.Value;
            if (!dto.UnidadeCompra.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.UnidadeCompra] = (Decimal)dto.UnidadeCompra.Value;
            if (!dto.UnidadeControle.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.UnidadeControle] = (Decimal)dto.UnidadeControle.Value;
            if (!dto.UnidadeConsumo.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.UnidadeConsumo] = (Decimal)dto.UnidadeConsumo.Value;

            if (!dto.DsUnidadeVenda.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.DsUnidadeVenda] = (String)dto.DsUnidadeVenda.Value;
            if (!dto.DsUnidadeCompra.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.DsUnidadeCompra] = (String)dto.DsUnidadeCompra.Value;
            if (!dto.DsUnidadeControle.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.DsUnidadeControle] = (String)dto.DsUnidadeControle.Value;

            if (!dto.DsUnidade.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.DsUnidade] = (String)dto.DsUnidade.Value;
            if (!dto.DsSetor.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.DsSetor] = (String)dto.DsSetor.Value;
            if (!dto.DsFilial.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.DsFilial] = (String)dto.DsFilial.Value;

            if (!dto.Tabelamedica.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.Tabelamedica] = (String)dto.Tabelamedica.Value;

            if (!dto.FlFracionado.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.FlFracionado] = (Decimal)dto.FlFracionado.Value;

            if (!dto.IdtUsuario.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;
            if (!dto.Origem.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.Origem] = (Decimal)dto.Origem.Value;

            if (!dto.SaldoMovimentacao.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.SaldoMovimentacao] = (Decimal)dto.SaldoMovimentacao.Value;

            if (!dto.DataFornecimento.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.DataFornecimento] = (DateTime)dto.DataFornecimento.Value;
            if (!dto.PontoRessuprimento.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.PontoRessuprimento] = (Decimal)dto.PontoRessuprimento.Value;

            if (!dto.BaixaAutomatica.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.BaixaAutomatica] = (Decimal)dto.BaixaAutomatica.Value;

            if (!dto.DsProdutoOriginal.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.DsProdutoOriginal] = (String)dto.DsProdutoOriginal.Value;
            if (!dto.IdtProdutoOriginal.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.IdtProdutoOriginal] = (Decimal)dto.IdtProdutoOriginal.Value;

            if (!dto.IdtPrincipioAtivo.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.IdtPrincipioAtivo] = (Decimal)dto.IdtPrincipioAtivo.Value;

            if (!dto.FlFaturado.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.FlFaturado] = (Decimal)dto.FlFaturado.Value;

            if (!dto.QtdCE.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.QtdCE] = (Decimal)dto.QtdCE.Value;

            if (!dto.FlAtivo.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.FlAtivo] = (Decimal)dto.FlAtivo.Value;

            if (!dto.FlReutilizavel.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.FlReutilizavel] = (Decimal)dto.FlReutilizavel.Value;

            if (!dto.CodLote.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.CodLote] = (String)dto.CodLote.Value;
            if (!dto.DataAtualizaLote.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.DataAtualizaLote] = (DateTime)dto.DataAtualizaLote.Value;

            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class EstoqueLocalDTO : MVC.DTO.DTOBase
    {	
		private MVC.DTO.FieldDecimal cad_mtmd_id;
	    private MVC.DTO.FieldDecimal mtmd_lotest_id;
	    private MVC.DTO.FieldDecimal cad_set_id;
	    private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
	    private MVC.DTO.FieldDecimal cad_uni_id_unidade;
	    private MVC.DTO.FieldDateTime mtmd_estloc_data;
	    private MVC.DTO.FieldDecimal mtmd_estloc_qtde;
        private MVC.DTO.FieldDecimal mtmd_estloc_qtde_lote;
        private MVC.DTO.FieldDecimal mtmd_pedpad_qtde;
        private MVC.DTO.FieldDecimal cad_mtmd_filial_id;
        private MVC.DTO.FieldDecimal flag_padrao;
        private MVC.DTO.FieldDecimal outros_consumos;
        private MVC.DTO.FieldDecimal qtde_consumida;
        private MVC.DTO.FieldDecimal percentual_consumido;
        private MVC.DTO.FieldString ds_produto;
        private MVC.DTO.FieldDecimal mtmd_estloc_qtde_fracionada;
        private MVC.DTO.FieldDecimal cad_mtmd_unidade_venda;
        private MVC.DTO.FieldDecimal cad_mtmd_unidade_compra;
        private MVC.DTO.FieldDecimal cad_mtmd_unidade_controle;
        private MVC.DTO.FieldDecimal cad_mtmd_unidade_consumo;
        private MVC.DTO.FieldString cad_mtmd_unid_venda_ds;
        private MVC.DTO.FieldString cad_mtmd_unid_compra_ds;
        private MVC.DTO.FieldString cad_mtmd_unid_controle_ds;
        private MVC.DTO.FieldString cad_uni_ds_unidade;
        private MVC.DTO.FieldString cad_set_ds_setor;
        private MVC.DTO.FieldString cad_mtmd_ds_filial;
        private MVC.DTO.FieldDecimal cad_mtmd_fl_fraciona;       
        private MVC.DTO.FieldString tis_med_cd_tabelamedica;
        private MVC.DTO.FieldDecimal seg_usu_id_usuario;
        private MVC.DTO.FieldDecimal origem;
        private MVC.DTO.FieldDecimal mtmd_mov_estoque_atual;
        private MVC.DTO.FieldDateTime mtmd_dt_ressuprimento;
        private MVC.DTO.FieldDecimal mtmd_pedpad_percent_ressup;

        private MVC.DTO.FieldDecimal cad_mtmd_fl_baixa_automatica;

        private MVC.DTO.FieldString ds_produto_original;
        private MVC.DTO.FieldDecimal mtmd_id_original;

        private MVC.DTO.FieldDecimal cad_mtmd_priati_id;

        private MVC.DTO.FieldDecimal cad_mtmd_fl_faturado;

        private MVC.DTO.FieldDecimal qtde_ce;

        private MVC.DTO.FieldDecimal cad_mtmd_fl_ativo;

        private MVC.DTO.FieldDecimal cad_mtmd_fl_reutilizavel;

        private MVC.DTO.FieldString mtmd_cod_lote;        
        private MVC.DTO.FieldDateTime mtmd_data_atual_lote;

        public EstoqueLocalDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
            this.cad_mtmd_id = new MVC.DTO.FieldDecimal(FieldNames.IdtProduto, Captions.IdtProduto, DbType.Decimal);
		    this.mtmd_lotest_id= new MVC.DTO.FieldDecimal(FieldNames.IdtLote,Captions.IdtLote, DbType.Decimal);
		    this.cad_set_id= new MVC.DTO.FieldDecimal(FieldNames.IdtSetor,Captions.IdtSetor, DbType.Decimal);
		    this.cad_lat_id_local_atendimento= new MVC.DTO.FieldDecimal(FieldNames.IdtLocal,Captions.IdtLocal, DbType.Decimal);
		    this.cad_uni_id_unidade= new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade,Captions.IdtUnidade, DbType.Decimal);
		    this.mtmd_estloc_data= new MVC.DTO.FieldDateTime(FieldNames.DataAtualizacao,Captions.DataAtualizacao);
		    this.mtmd_estloc_qtde= new MVC.DTO.FieldDecimal(FieldNames.Qtde,Captions.Qtde, DbType.Decimal);
            this.mtmd_estloc_qtde_lote = new MVC.DTO.FieldDecimal(FieldNames.QtdeLote, Captions.QtdeLote, DbType.Decimal);
            this.mtmd_pedpad_qtde = new MVC.DTO.FieldDecimal(FieldNames.QtdePadrao, Captions.QtdePadrao, DbType.Decimal);
            this.cad_mtmd_filial_id = new MVC.DTO.FieldDecimal(FieldNames.IdtFilial, Captions.IdtFilial, DbType.Decimal);
            this.flag_padrao = new MVC.DTO.FieldDecimal(FieldNames.FlPadrao, Captions.FlPadrao, DbType.Decimal);
            this.outros_consumos = new MVC.DTO.FieldDecimal(FieldNames.OutrosConsumos, Captions.OutrosConsumos, DbType.Decimal);
            this.qtde_consumida = new MVC.DTO.FieldDecimal(FieldNames.Consumido, Captions.Consumido, DbType.Decimal);
            this.percentual_consumido = new MVC.DTO.FieldDecimal(FieldNames.Percentual, Captions.Percentual, DbType.Decimal);
            this.ds_produto = new MVC.DTO.FieldString(FieldNames.DsProduto, Captions.DsProduto, 100);
            this.mtmd_estloc_qtde_fracionada = new MVC.DTO.FieldDecimal(FieldNames.QtdeFracionada, Captions.QtdeFracionada, DbType.Decimal);
            
            this.cad_mtmd_unidade_venda = new MVC.DTO.FieldDecimal(FieldNames.UnidadeVenda, Captions.UnidadeVenda, DbType.Decimal);
            this.cad_mtmd_unidade_compra = new MVC.DTO.FieldDecimal(FieldNames.UnidadeCompra, Captions.UnidadeCompra, DbType.Decimal);
            this.cad_mtmd_unidade_controle = new MVC.DTO.FieldDecimal(FieldNames.UnidadeControle, Captions.UnidadeControle, DbType.Decimal);
            this.cad_mtmd_unidade_consumo = new MVC.DTO.FieldDecimal(FieldNames.UnidadeConsumo, Captions.UnidadeConsumo, DbType.Decimal);

            this.cad_mtmd_unid_venda_ds = new MVC.DTO.FieldString(FieldNames.DsUnidadeVenda, Captions.DsUnidadeVenda, 100);
            this.cad_mtmd_unid_compra_ds = new MVC.DTO.FieldString(FieldNames.DsUnidadeCompra, Captions.DsUnidadeCompra, 100);
            this.cad_mtmd_unid_controle_ds = new MVC.DTO.FieldString(FieldNames.DsUnidadeControle, Captions.DsUnidadeControle, 100);

            this.cad_uni_ds_unidade = new MVC.DTO.FieldString(FieldNames.DsUnidade, Captions.DsUnidade);
            this.cad_set_ds_setor = new MVC.DTO.FieldString(FieldNames.DsSetor, Captions.DsSetor);
            this.cad_mtmd_ds_filial = new MVC.DTO.FieldString(FieldNames.DsFilial, Captions.DsFilial);

            this.tis_med_cd_tabelamedica = new MVC.DTO.FieldString(FieldNames.Tabelamedica, Captions.Tabelamedica);
            this.cad_mtmd_fl_fraciona = new MVC.DTO.FieldDecimal(FieldNames.FlFracionado, Captions.FlFracionado, DbType.Decimal);

            this.seg_usu_id_usuario = new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario, Captions.IdtUsuario, DbType.Decimal);
            this.origem = new MVC.DTO.FieldDecimal(FieldNames.Origem, Captions.Origem, DbType.Decimal);

            this.SaldoMovimentacao = new MVC.DTO.FieldDecimal(FieldNames.SaldoMovimentacao, Captions.SaldoMovimentacao, DbType.Decimal);

            this.mtmd_dt_ressuprimento = new MVC.DTO.FieldDateTime(FieldNames.DataFornecimento, Captions.DataFornecimento);
            this.mtmd_pedpad_percent_ressup = new MVC.DTO.FieldDecimal(FieldNames.PontoRessuprimento, Captions.PontoRessuprimento);

            this.cad_mtmd_fl_baixa_automatica = new MVC.DTO.FieldDecimal(FieldNames.BaixaAutomatica, Captions.BaixaAutomatica);

            this.ds_produto_original = new MVC.DTO.FieldString(FieldNames.DsProdutoOriginal, Captions.DsProdutoOriginal);
            this.mtmd_id_original = new MVC.DTO.FieldDecimal(FieldNames.IdtProdutoOriginal, Captions.IdtProdutoOriginal);

            this.cad_mtmd_priati_id = new MVC.DTO.FieldDecimal(FieldNames.IdtPrincipioAtivo, Captions.IdtPrincipioAtivo);

            this.cad_mtmd_fl_faturado = new MVC.DTO.FieldDecimal(FieldNames.FlFaturado, Captions.FlFaturado);

            this.qtde_ce = new MVC.DTO.FieldDecimal(FieldNames.FlFaturado, Captions.QtdCE);

            this.cad_mtmd_fl_ativo = new MVC.DTO.FieldDecimal(FieldNames.FlAtivo, Captions.FlAtivo);

            this.cad_mtmd_fl_reutilizavel = new MVC.DTO.FieldDecimal(FieldNames.FlReutilizavel, Captions.FlReutilizavel);

            this.mtmd_cod_lote = new MVC.DTO.FieldString(FieldNames.CodLote, Captions.CodLote);
            this.mtmd_data_atual_lote = new MVC.DTO.FieldDateTime(FieldNames.DataAtualizaLote, Captions.DataAtualizaLote);
        }
 
        #region FieldNames

        public struct FieldNames
        {
            /// <summary>
            /// Id do Produto
            /// </summary>
            public const string IdtProduto = "CAD_MTMD_ID";
		    public const string IdtLote="MTMD_LOTEST_ID";
		    public const string IdtSetor="CAD_SET_ID";
		    public const string IdtLocal="CAD_LAT_ID_LOCAL_ATENDIMENTO";
		    public const string IdtUnidade="CAD_UNI_ID_UNIDADE";
		    public const string DataAtualizacao="MTMD_ESTLOC_DATA";
            /// <summary>
            /// Qtde em Estoque (Inteiro) UNIDADE DE CONTROLE
            /// </summary>
		    public const string Qtde="MTMD_ESTLOC_QTDE";
            public const string QtdeLote = "MTMD_ESTLOC_QTDE_LOTE";
            public const string QtdePadrao = "MTMD_PEDPAD_QTDE";
            public const string IdtFilial = "CAD_MTMD_FILIAL_ID";
            public const string FlPadrao = "MTMD_ESTLOC_FL_PADRAO";
            public const string OutrosConsumos = "OUTROS_CONSUMOS";
            /// <summary>
            /// Calculo da qtde consumida desde a última reposição
            /// </summary>
            public const string Consumido = "QTDE_CONSUMIDA";
            public const string Percentual = "PERCENTUAL_CONSUMIDO";
            public const string DsProduto = "CAD_MTMD_NOMEFANTASIA";
            /// <summary>
            /// Qtde em estoque ( fracionada ) UNIDADE DE CONSUMO
            /// </summary>
            public const string QtdeFracionada = "MTMD_ESTLOC_QTDE_FRACIONADA";

            public const string UnidadeVenda = "CAD_MTMD_UNIDADE_VENDA";
            public const string UnidadeCompra = "CAD_MTMD_UNIDADE_COMPRA";
            public const string UnidadeControle = "CAD_MTMD_UNIDADE_CONTROLE";
            public const string UnidadeConsumo = "CAD_MTMD_UNIDADE_CONSUMO";

            public const string DsUnidadeVenda = "CAD_MTMD_UNID_VENDA_DS";
            public const string DsUnidadeCompra = "CAD_MTMD_UNID_COMPRA_DS";
            public const string DsUnidadeControle = "CAD_MTMD_UNID_CONTROLE_DS";

            public const string DsUnidade = "CAD_UNI_DS_UNIDADE";
            public const string DsSetor = "CAD_SET_DS_SETOR";
            public const string DsFilial = "CAD_MTMD_FILIAL_DESCRICAO";
            public const string Tabelamedica = "TIS_MED_CD_TABELAMEDICA";
            public const string FlFracionado = "CAD_MTMD_FL_FRACIONA";
            public const string IdtUsuario = "SEG_USU_ID_USUARIO";
            public const string Origem = "ORIGEM";

            public const string SaldoMovimentacao = "MTMD_MOV_ESTOQUE_ATUAL";

            public const string DataFornecimento = "MTMD_DT_RESSUPRIMENTO";
            public const string PontoRessuprimento = "MTMD_PEDPAD_PERCENT_RESSUP";

            public const string BaixaAutomatica = "CAD_MTMD_FL_BAIXA_AUTOMATICA";

            public const string DsProdutoOriginal = "DS_PRODUTO_ORIGINAL";
            public const string IdtProdutoOriginal = "MTMD_ID_ORIGINAL";

            public const string IdtPrincipioAtivo = "CAD_MTMD_PRIATI_ID";

            public const string FlFaturado = "CAD_MTMD_FL_FATURADO";

            public const string QtdCE = "QTDE_CE";

            public const string FlAtivo = "CAD_MTMD_FL_ATIVO";

            public const string FlReutilizavel = "CAD_MTMD_FL_REUTILIZAVEL";

            public const string CodLote = "MTMD_COD_LOTE";
            public const string DataAtualizaLote = "MTMD_DATA_ATUAL_LOTE";
        }		

        #endregion

        #region Captions
        public struct Captions
        {
            public const string IdtProduto = "IDT";
		    public const string IdtLote="IdtLote";
		    public const string IdtSetor="IdtSetor";
		    public const string IdtLocal="IdtLocal";
		    public const string IdtUnidade="IdtUnidade";
		    public const string DataAtualizacao="DATAATUALIZACAO";
            
		    public const string Qtde="QTDE";
            public const string QtdeLote = "QTDELOTE";
            public const string QtdePadrao = "MTMDPEDPADQTDE";
            public const string IdtFilial = "IDTFILIAL";
            public const string FlPadrao = "MTMDESTLOCFLPADRAO";
            public const string OutrosConsumos = "OUTROSCONSUMOS";
            
            public const string Consumido = "QTDECONSUMIDA";
            public const string Percentual = "PERCENTUALCONSUMIDO";
            public const string DsProduto = "DSPRODUTO";
            
            public const string QtdeFracionada = "QTDEFRACIONADA";

            public const string UnidadeVenda = "UNIDADEVENDA";
            public const string UnidadeCompra = "UNIDADECOMPRA";
            public const string UnidadeControle = "UNIDADECONTROLE";
            public const string UnidadeConsumo = "UNIDADECONSUMO";

            public const string DsUnidadeVenda = "DSUNIDADEVENDA";
            public const string DsUnidadeCompra = "DSUNIDADECOMPRA";
            public const string DsUnidadeControle = "DSUNIDADECONTROLE";

            public const string DsUnidade = "CADUNIDSUNIDADE";
            public const string DsSetor = "CADSETDSSETOR";
            public const string DsFilial = "CADMTMDFILIALDESCRICAO";

            public const string Tabelamedica = "TABELAMEDICA";

            public const string FlFracionado = "FLFRACIONADO";
            public const string IdtUsuario = "SEGUSUIDUSUARIO";
            public const string Origem = "ORIGEM";

            public const string SaldoMovimentacao = "SALDOMOVIMENTACAO";

            public const string DataFornecimento = "DATAFORNECIMENTO";

            public const string PontoRessuprimento = "PONTORESSUPRIMENTO";


            public const string BaixaAutomatica = "BAIXAAUTOMATICA";

            public const string DsProdutoOriginal = "DSPRODUTOORIGINAL";
            public const string IdtProdutoOriginal = "BAIXAAUTOMATICA";

            public const string IdtPrincipioAtivo = "IDTPRINCIPIOATIVO";

            public const string FlFaturado = "FLFATURADO";

            public const string QtdCE = "QTDCE";

            public const string FlAtivo = "FLATIVO";

            public const string FlReutilizavel = "FLREUTILIZAVEL";

            public const string CodLote = "CODLOTE";
            public const string DataAtualizaLote = "DATAATUALLOTE";
        }		

        #endregion
		
        #region Atributos Publicos

        /// <summary>
        /// Id do Produto
        /// </summary>
        public MVC.DTO.FieldDecimal IdtProduto
		{
			get { return cad_mtmd_id; }
			set { cad_mtmd_id = value; }
		}
		/// <summary>
		/// Id do Lote
		/// </summary>
		public MVC.DTO.FieldDecimal IdtLote
		{
			get { return mtmd_lotest_id; }
			set { mtmd_lotest_id = value; }
		}

		/// <summary>
		/// Id do Setor de Atendimento
		/// </summary>
		public MVC.DTO.FieldDecimal IdtSetor
		{
			get { return cad_set_id; }
			set { cad_set_id = value; }
		}
		
        /// <summary>
        /// Id do Local de Atendimento
        /// </summary>
		public MVC.DTO.FieldDecimal IdtLocal
		{
			get { return cad_lat_id_local_atendimento; }
			set { cad_lat_id_local_atendimento = value; }
		}		

        /// <summary>
        /// Id da Unidade de Atendimento
        /// </summary>
		public MVC.DTO.FieldDecimal IdtUnidade
		{
			get { return cad_uni_id_unidade; }
			set { cad_uni_id_unidade = value; }
		}
		
        /// <summary>
        /// Data da Atualização do Estoque
        /// </summary>
		public MVC.DTO.FieldDateTime DataAtualizacao
		{
			get { return mtmd_estloc_data; }
			set { mtmd_estloc_data = value; }
		}
		
        /// <summary>
        /// Saldo conforme filtro passado para pesquisa, Filtro: Unidade ou Unidade por Lote
        /// </summary>
		public MVC.DTO.FieldDecimal Qtde
		{
			get { return mtmd_estloc_qtde; }
			set { mtmd_estloc_qtde = value; }
		}

        public MVC.DTO.FieldDecimal QtdeLote
        {
            get { return mtmd_estloc_qtde_lote; }
            set { mtmd_estloc_qtde_lote = value; }
        }

        public MVC.DTO.FieldDecimal QtdePadrao
        {
            get { return mtmd_pedpad_qtde; }
            set { mtmd_pedpad_qtde = value; }
        }

        public MVC.DTO.FieldDecimal IdtFilial
        {
            get { return cad_mtmd_filial_id; }
            set { cad_mtmd_filial_id = value; }
        }

        public MVC.DTO.FieldDecimal FlPadrao
        {
            get { return flag_padrao; }
            set { flag_padrao = value; }
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

        public MVC.DTO.FieldString DsProduto
        {
            get { return ds_produto; }
            set { ds_produto = value; }
        }

        public MVC.DTO.FieldDecimal QtdeFracionada
        {
            get { return mtmd_estloc_qtde_fracionada; }
            set { mtmd_estloc_qtde_fracionada = value; }
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

        public MVC.DTO.FieldDecimal UnidadeControle
        {
            get { return cad_mtmd_unidade_controle; }
            set { cad_mtmd_unidade_controle = value; }
        }

        public MVC.DTO.FieldDecimal UnidadeConsumo
        {
            get { return cad_mtmd_unidade_consumo; }
            set { cad_mtmd_unidade_consumo = value; }
        }

        public MVC.DTO.FieldString DsUnidadeVenda
        {
            get { return cad_mtmd_unid_venda_ds; }
            set { cad_mtmd_unid_venda_ds = value; }
        }

        public MVC.DTO.FieldString DsUnidadeCompra
        {
            get { return cad_mtmd_unid_compra_ds; }
            set { cad_mtmd_unid_compra_ds = value; }
        }

        public MVC.DTO.FieldString DsUnidadeControle
        {
            get { return cad_mtmd_unid_controle_ds; }
            set { cad_mtmd_unid_controle_ds = value; }
        }

        public MVC.DTO.FieldString DsUnidade
        {
            get { return cad_uni_ds_unidade; }
            set { cad_uni_ds_unidade = value; }
        }

        public MVC.DTO.FieldString DsSetor
        {
            get { return cad_set_ds_setor; }
            set { cad_set_ds_setor = value; }
        }

        public MVC.DTO.FieldString DsFilial
        {
            get { return cad_mtmd_ds_filial; }
            set { cad_mtmd_ds_filial = value; }
        }

        /// <summary>
        /// Tipo do Produto: Material ou Medicamento
        /// </summary>
        public MVC.DTO.FieldString Tabelamedica
        {
            get { return tis_med_cd_tabelamedica; }
            set { tis_med_cd_tabelamedica = value; }
        }

        public MVC.DTO.FieldDecimal FlFracionado
        {
            get { return cad_mtmd_fl_fraciona; }
            set { cad_mtmd_fl_fraciona = value; }
        }

        public MVC.DTO.FieldDecimal IdtUsuario
        {
            get { return seg_usu_id_usuario; }
            set { seg_usu_id_usuario = value; }
        }

        public MVC.DTO.FieldDecimal Origem
        {
            get { return origem; }
            set { origem = value; }
        }

        public MVC.DTO.FieldDecimal PontoRessuprimento
        {
            get { return mtmd_pedpad_percent_ressup; }
            set { mtmd_pedpad_percent_ressup = value; }
        }

        /// <summary>
        /// Saldo do Produto no momento do último ressuprimento ( Reposição de estoque )
        /// </summary>
        public MVC.DTO.FieldDecimal SaldoMovimentacao
        {
            get { return mtmd_mov_estoque_atual; }
            set { mtmd_mov_estoque_atual = value; }
        }

        public MVC.DTO.FieldDateTime DataFornecimento
        {
            get { return mtmd_dt_ressuprimento; }
            set { mtmd_dt_ressuprimento = value; }
        }

        public MVC.DTO.FieldDecimal BaixaAutomatica
        {
            get { return cad_mtmd_fl_baixa_automatica; }
            set { cad_mtmd_fl_baixa_automatica = value; }
        }

        /// <summary>
        /// Retorna Id do Produto Original´- se este campo estiver preenchido ele é similiar ao
        /// originalmente cadastrado no pedido/Requisição
        /// </summary>
        public MVC.DTO.FieldDecimal IdtProdutoOriginal
        {
            get { return mtmd_id_original; }
            set { mtmd_id_original = value; }
        }


        /// <summary>
        /// Retorna Descrição do Produto originalmente solicitado na requisição
        /// Se estiver preeenchido ele é similar ao da requisição
        /// </summary>
        public MVC.DTO.FieldString DsProdutoOriginal
        {
            get { return ds_produto_original; }
            set { ds_produto_original = value; }
        }

        public MVC.DTO.FieldDecimal IdtPrincipioAtivo
        {
            get { return cad_mtmd_priati_id; }
            set { cad_mtmd_priati_id = value; }
        }

        public MVC.DTO.FieldDecimal FlFaturado
        {
            get { return cad_mtmd_fl_faturado; }
            set { cad_mtmd_fl_faturado = value; }
        }

        public MVC.DTO.FieldDecimal QtdCE
        {
            get { return qtde_ce; }
            set { qtde_ce = value; }
        }

        public MVC.DTO.FieldDecimal FlAtivo
        {
            get { return cad_mtmd_fl_ativo; }
            set { cad_mtmd_fl_ativo = value; }
        }

        public MVC.DTO.FieldDecimal FlReutilizavel
        {
            get { return cad_mtmd_fl_reutilizavel; }
            set { cad_mtmd_fl_reutilizavel = value; }
        }

        public MVC.DTO.FieldString CodLote
        {
            get { return mtmd_cod_lote; }
            set { mtmd_cod_lote = value; }
        }

        public MVC.DTO.FieldDateTime DataAtualizaLote
        {
            get { return mtmd_data_atual_lote; }
            set { mtmd_data_atual_lote = value; }
        }

		#endregion

        #region Operators

        public static explicit operator EstoqueLocalDTO(DataRow row)
        {
            EstoqueLocalDTO  dto = new EstoqueLocalDTO();

            dto.IdtProduto.Value = row[FieldNames.IdtProduto].ToString();
			
			dto.IdtLote.Value = row[FieldNames.IdtLote].ToString();
		
			dto.IdtSetor.Value = row[FieldNames.IdtSetor].ToString();
		
			dto.IdtLocal.Value = row[FieldNames.IdtLocal].ToString();
		
			dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();
		
			dto.DataAtualizacao.Value = row[FieldNames.DataAtualizacao].ToString();
		
			dto.Qtde.Value = row[FieldNames.Qtde].ToString();

            dto.QtdeLote.Value = row[FieldNames.QtdeLote].ToString();

            dto.QtdePadrao.Value = row[FieldNames.QtdePadrao].ToString();

            dto.OutrosConsumos.Value = row[FieldNames.OutrosConsumos].ToString();

            dto.Consumido.Value = row[FieldNames.Consumido].ToString();

            dto.Percentual.Value = row[FieldNames.Percentual].ToString();

            dto.IdtFilial.Value = row[FieldNames.IdtFilial].ToString();

            dto.FlPadrao.Value = row[FieldNames.FlPadrao].ToString();

            dto.DsProduto.Value = row[FieldNames.DsProduto].ToString();

            dto.QtdeFracionada.Value = row[FieldNames.QtdeFracionada].ToString();

            dto.UnidadeVenda.Value = row[FieldNames.UnidadeVenda].ToString();

            dto.UnidadeCompra.Value = row[FieldNames.UnidadeCompra].ToString();

            dto.UnidadeControle.Value = row[FieldNames.UnidadeControle].ToString();

            dto.UnidadeConsumo.Value = row[FieldNames.UnidadeConsumo].ToString();

            dto.DsUnidadeVenda.Value = row[FieldNames.DsUnidadeVenda].ToString();
            dto.DsUnidadeCompra.Value = row[FieldNames.DsUnidadeCompra].ToString();
            dto.DsUnidadeControle.Value = row[FieldNames.DsUnidadeControle].ToString();

            dto.DsUnidade.Value = row[FieldNames.DsUnidade].ToString();
            dto.DsSetor.Value = row[FieldNames.DsSetor].ToString();
            dto.DsFilial.Value = row[FieldNames.DsFilial].ToString();

            dto.Tabelamedica.Value = row[FieldNames.Tabelamedica].ToString();

            dto.FlFracionado.Value = row[FieldNames.FlFracionado].ToString();

            dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();
            dto.Origem.Value = row[FieldNames.Origem].ToString();

            dto.SaldoMovimentacao.Value = row[FieldNames.SaldoMovimentacao].ToString();

            dto.DataFornecimento.Value = row[FieldNames.DataFornecimento].ToString();
            dto.PontoRessuprimento.Value = row[FieldNames.PontoRessuprimento].ToString();

            dto.BaixaAutomatica.Value = row[FieldNames.BaixaAutomatica].ToString();

            dto.DsProdutoOriginal.Value = row[FieldNames.DsProdutoOriginal].ToString();
            dto.IdtProdutoOriginal.Value = row[FieldNames.IdtProdutoOriginal].ToString();

            dto.IdtPrincipioAtivo.Value = row[FieldNames.IdtPrincipioAtivo].ToString();

            dto.FlFaturado.Value = row[FieldNames.FlFaturado].ToString();

            dto.QtdCE.Value = row[FieldNames.QtdCE].ToString();

            dto.FlAtivo.Value = row[FieldNames.FlAtivo].ToString();

            dto.FlReutilizavel.Value = row[FieldNames.FlReutilizavel].ToString();

            try
            {
                dto.CodLote.Value = row[FieldNames.CodLote].ToString();
                dto.DataAtualizaLote.Value = row[FieldNames.DataAtualizaLote].ToString();
            }
            catch
            {
                //deixa passar se não tiver coluna
            }
            return dto;
        }

        public static explicit operator EstoqueLocalDTO(XmlDocument xml)
        {
            EstoqueLocalDTO dto = new EstoqueLocalDTO();

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto) != null) dto.IdtProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto).InnerText;			
			
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLote) != null) dto.IdtLote.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLote).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor) != null) dto.IdtSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal) != null) dto.IdtLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizacao) != null) dto.DataAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataAtualizacao).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.Qtde) != null) dto.Qtde.Value = xml.FirstChild.SelectSingleNode(FieldNames.Qtde).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeLote) != null) dto.QtdeLote.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeLote).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.QtdePadrao) != null) dto.QtdePadrao.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdePadrao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial) != null) dto.IdtFilial.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.FlPadrao) != null) dto.FlPadrao.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlPadrao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Consumido) != null) dto.Consumido.Value = xml.FirstChild.SelectSingleNode(FieldNames.Consumido).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Percentual) != null) dto.Percentual.Value = xml.FirstChild.SelectSingleNode(FieldNames.Percentual).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.OutrosConsumos) != null) dto.OutrosConsumos.Value = xml.FirstChild.SelectSingleNode(FieldNames.OutrosConsumos).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsProduto) != null) dto.DsProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsProduto).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeFracionada) != null) dto.QtdeFracionada.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeFracionada).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeVenda) != null) dto.UnidadeVenda.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeVenda).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeCompra) != null) dto.UnidadeCompra.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeCompra).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeControle) != null) dto.UnidadeControle.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeControle).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeConsumo) != null) dto.UnidadeConsumo.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeConsumo).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeVenda) != null) dto.DsUnidadeVenda.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeVenda).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeCompra) != null) dto.DsUnidadeCompra.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeCompra).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeControle) != null) dto.DsUnidadeControle.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeControle).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade) != null) dto.DsUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DsSetor) != null) dto.DsSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsSetor).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DsFilial) != null) dto.DsFilial.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsFilial).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.Tabelamedica) != null) dto.Tabelamedica.Value = xml.FirstChild.SelectSingleNode(FieldNames.Tabelamedica).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.FlFracionado) != null) dto.FlFracionado.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlFracionado).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.Origem) != null) dto.Origem.Value = xml.FirstChild.SelectSingleNode(FieldNames.Origem).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.SaldoMovimentacao) != null) dto.SaldoMovimentacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.SaldoMovimentacao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DataFornecimento) != null) dto.DataFornecimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataFornecimento).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.PontoRessuprimento) != null) dto.PontoRessuprimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.PontoRessuprimento).InnerText;


            if (xml.FirstChild.SelectSingleNode(FieldNames.BaixaAutomatica) != null) dto.BaixaAutomatica.Value = xml.FirstChild.SelectSingleNode(FieldNames.BaixaAutomatica).InnerText;


            if (xml.FirstChild.SelectSingleNode(FieldNames.DsProdutoOriginal) != null) dto.DsProdutoOriginal.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsProdutoOriginal).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtProdutoOriginal) != null) dto.IdtProdutoOriginal.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtProdutoOriginal).InnerText;
            
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtPrincipioAtivo) != null) dto.IdtPrincipioAtivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtPrincipioAtivo).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.FlFaturado) != null) dto.FlFaturado.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlFaturado).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.QtdCE) != null) dto.QtdCE.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdCE).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.FlAtivo) != null) dto.FlAtivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlAtivo).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.FlReutilizavel) != null) dto.FlReutilizavel.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlReutilizavel).InnerText;

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);

            XmlNode nodeIdtProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtProduto, null);
			
            XmlNode nodeIdtLote = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLote, null);
			
            XmlNode nodeIdtSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetor, null);
			
            XmlNode nodeIdtLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocal, null);
			
            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);
			
            XmlNode nodeDataAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DataAtualizacao, null);
			
            XmlNode nodeQtde = xml.CreateNode(XmlNodeType.Element, FieldNames.Qtde, null);

            XmlNode nodeQtdeLote = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeLote, null);

            XmlNode nodeQtdePadrao = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdePadrao, null);

            XmlNode nodeIdtFilial = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFilial, null);

            XmlNode nodeFlPadrao = xml.CreateNode(XmlNodeType.Element, FieldNames.FlPadrao, null);

            XmlNode nodeOutrosConsumos = xml.CreateNode(XmlNodeType.Element, FieldNames.OutrosConsumos, null);

            XmlNode nodeConsumido = xml.CreateNode(XmlNodeType.Element, FieldNames.Consumido, null);

            XmlNode nodePercentual = xml.CreateNode(XmlNodeType.Element, FieldNames.Percentual, null);

            XmlNode nodeDsProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.DsProduto, null);

            XmlNode nodeQtdeFracionada = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeFracionada, null);

            XmlNode nodeUnidadeVenda = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeVenda, null);

            XmlNode nodeUnidadeCompra = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeCompra, null);

            XmlNode nodeUnidadeControle = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeControle, null);

            XmlNode nodeUnidadeConsumo = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeConsumo, null);
            XmlNode nodeDsUnidadeVenda = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidadeVenda, null);
            XmlNode nodeDsUnidadeCompra = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidadeCompra, null);
            XmlNode nodeDsUnidadeControle = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidadeControle, null);

            XmlNode nodeDsUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidade, null);
            XmlNode nodeDsSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.DsSetor, null);
            XmlNode nodeDsFilial = xml.CreateNode(XmlNodeType.Element, FieldNames.DsFilial, null);

            XmlNode nodeTabelamedica = xml.CreateNode(XmlNodeType.Element, FieldNames.Tabelamedica, null);

            XmlNode nodeFlFracionado = xml.CreateNode(XmlNodeType.Element, FieldNames.FlFracionado, null);

            XmlNode nodeIdtUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);
            XmlNode nodeOrigem = xml.CreateNode(XmlNodeType.Element, FieldNames.Origem, null);

            XmlNode nodeSaldoMovimentacao = xml.CreateNode(XmlNodeType.Element, FieldNames.SaldoMovimentacao, null);

            XmlNode nodeDataFornecimento = xml.CreateNode(XmlNodeType.Element, FieldNames.DataFornecimento, null);
            XmlNode nodePontoRessuprimento = xml.CreateNode(XmlNodeType.Element, FieldNames.PontoRessuprimento, null);


            XmlNode nodeBaixaAutomatica = xml.CreateNode(XmlNodeType.Element, FieldNames.BaixaAutomatica, null);

            XmlNode nodeDsProdutoOriginal = xml.CreateNode(XmlNodeType.Element, FieldNames.DsProdutoOriginal, null);
            XmlNode nodeIdtProdutoOriginal = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtProdutoOriginal, null);

            XmlNode nodeIdtPrincipioAtivo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtPrincipioAtivo, null);

            XmlNode nodeFlFaturado = xml.CreateNode(XmlNodeType.Element, FieldNames.FlFaturado, null);

            XmlNode nodeQtdCE = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdCE, null);

            XmlNode nodeFlAtivo = xml.CreateNode(XmlNodeType.Element, FieldNames.FlAtivo, null);

            XmlNode nodeFlReutilizavel = xml.CreateNode(XmlNodeType.Element, FieldNames.FlReutilizavel, null);
                       


            if (!this.IdtProduto.Value.IsNull) nodeIdtProduto.InnerText = this.IdtProduto.Value;
			
			if (!this.IdtLote.Value.IsNull) nodeIdtLote.InnerText = this.IdtLote.Value;
			
			if (!this.IdtSetor.Value.IsNull) nodeIdtSetor.InnerText = this.IdtSetor.Value;
			
			if (!this.IdtLocal.Value.IsNull) nodeIdtLocal.InnerText = this.IdtLocal.Value;
			
			if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;
			
			if (!this.DataAtualizacao.Value.IsNull) nodeDataAtualizacao.InnerText = this.DataAtualizacao.Value;
			
			if (!this.Qtde.Value.IsNull) nodeQtde.InnerText = this.Qtde.Value;

            if (!this.QtdeLote.Value.IsNull) nodeQtdeLote.InnerText = this.QtdeLote.Value;

            if (!this.QtdePadrao.Value.IsNull) nodeQtdePadrao.InnerText = this.QtdePadrao.Value;

            if (!this.IdtFilial.Value.IsNull) nodeIdtFilial.InnerText = this.IdtFilial.Value;

            if (!this.FlPadrao.Value.IsNull) nodeFlPadrao.InnerText = this.FlPadrao.Value;

            if (!this.OutrosConsumos.Value.IsNull) nodeOutrosConsumos.InnerText = this.OutrosConsumos.Value;

            if (!this.Consumido.Value.IsNull) nodeConsumido.InnerText = this.Consumido.Value;

            if (!this.Percentual.Value.IsNull) nodePercentual.InnerText = this.Percentual.Value;

            if (!this.DsProduto.Value.IsNull) nodeDsProduto.InnerText = this.DsProduto.Value;

            if (!this.QtdeFracionada.Value.IsNull) nodeQtdeFracionada.InnerText = this.QtdeFracionada.Value;

            if (!this.UnidadeVenda.Value.IsNull) nodeUnidadeVenda.InnerText = this.UnidadeVenda.Value;

            if (!this.UnidadeCompra.Value.IsNull) nodeUnidadeCompra.InnerText = this.UnidadeCompra.Value;

            if (!this.UnidadeControle.Value.IsNull) nodeUnidadeControle.InnerText = this.UnidadeControle.Value;

            if (!this.UnidadeConsumo.Value.IsNull) nodeUnidadeConsumo.InnerText = this.UnidadeConsumo.Value;

            if (!this.DsUnidadeVenda.Value.IsNull) nodeDsUnidadeVenda.InnerText = this.DsUnidadeVenda.Value;
            if (!this.DsUnidadeCompra.Value.IsNull) nodeDsUnidadeCompra.InnerText = this.DsUnidadeCompra.Value;
            if (!this.DsUnidadeControle.Value.IsNull) nodeDsUnidadeControle.InnerText = this.DsUnidadeControle.Value;

            if (!this.DsUnidade.Value.IsNull) nodeDsUnidade.InnerText = this.DsUnidade.Value;
            if (!this.DsSetor.Value.IsNull) nodeDsSetor.InnerText = this.DsSetor.Value;
            if (!this.DsFilial.Value.IsNull) nodeDsFilial.InnerText = this.DsFilial.Value;

            if (!this.Tabelamedica.Value.IsNull) nodeTabelamedica.InnerText = this.Tabelamedica.Value;

            if (!this.FlFracionado.Value.IsNull) nodeFlFracionado.InnerText = this.FlFracionado.Value;

            if (!this.IdtUsuario.Value.IsNull) nodeIdtUsuario.InnerText = this.IdtUsuario.Value;
            if (!this.Origem.Value.IsNull) nodeOrigem.InnerText = this.Origem.Value;

            if (!this.SaldoMovimentacao.Value.IsNull) nodeSaldoMovimentacao.InnerText = this.SaldoMovimentacao.Value;

            if (!this.DataFornecimento.Value.IsNull) nodeDataFornecimento.InnerText = this.DataFornecimento.Value;
            if (!this.PontoRessuprimento.Value.IsNull) nodePontoRessuprimento.InnerText = this.PontoRessuprimento.Value;

            if (!this.BaixaAutomatica.Value.IsNull) nodeBaixaAutomatica.InnerText = this.BaixaAutomatica.Value;

            if (!this.DsProdutoOriginal.Value.IsNull) nodeDsProdutoOriginal.InnerText = this.DsProdutoOriginal.Value;
            if (!this.IdtProdutoOriginal.Value.IsNull) nodeIdtProdutoOriginal.InnerText = this.IdtProdutoOriginal.Value;

            if (!this.IdtPrincipioAtivo.Value.IsNull) nodeIdtPrincipioAtivo.InnerText = this.IdtPrincipioAtivo.Value;


            if (!this.FlFaturado.Value.IsNull) nodeFlFaturado.InnerText = this.FlFaturado.Value;

            if (!this.QtdCE.Value.IsNull) nodeQtdCE.InnerText = this.QtdCE.Value;


            if (!this.FlAtivo.Value.IsNull) nodeFlAtivo.InnerText = this.FlAtivo.Value;


            if (!this.FlReutilizavel.Value.IsNull) nodeFlReutilizavel.InnerText = this.FlReutilizavel.Value;
                        

            nodeData.AppendChild(nodeIdtProduto);
			
            nodeData.AppendChild(nodeIdtLote);
			
            nodeData.AppendChild(nodeIdtSetor);
			
            nodeData.AppendChild(nodeIdtLocal);
			
            nodeData.AppendChild(nodeIdtUnidade);
			
            nodeData.AppendChild(nodeDataAtualizacao);
			
            nodeData.AppendChild(nodeQtde);

            nodeData.AppendChild(nodeQtdeLote);

            nodeData.AppendChild(nodeQtdePadrao);

            nodeData.AppendChild(nodeIdtFilial);

            nodeData.AppendChild(nodeFlPadrao);

            nodeData.AppendChild(nodeOutrosConsumos);

            nodeData.AppendChild(nodeConsumido);

            nodeData.AppendChild(nodePercentual);

            nodeData.AppendChild(nodeDsProduto);

            nodeQtdeFracionada.AppendChild(nodeQtdeFracionada);

            nodeData.AppendChild(nodeUnidadeVenda);

            nodeData.AppendChild(nodeUnidadeCompra);

            nodeData.AppendChild(nodeUnidadeControle);

            nodeData.AppendChild(nodeUnidadeConsumo);

            nodeData.AppendChild(nodeDsUnidadeVenda);
            nodeData.AppendChild(nodeDsUnidadeCompra);
            nodeData.AppendChild(nodeDsUnidadeControle);

            nodeData.AppendChild(nodeDsUnidade);
            nodeData.AppendChild(nodeDsSetor);
            nodeData.AppendChild(nodeDsFilial);

            nodeData.AppendChild(nodeTabelamedica);

            nodeData.AppendChild(nodeFlFracionado);

            nodeData.AppendChild(nodeIdtUsuario);
            nodeData.AppendChild(nodeOrigem);

            nodeData.AppendChild(nodeDataFornecimento);
            nodeData.AppendChild(nodePontoRessuprimento);

            nodeData.AppendChild(nodeBaixaAutomatica);

            nodeData.AppendChild(nodeDsProdutoOriginal);
            nodeData.AppendChild(nodeIdtProdutoOriginal);

            nodeData.AppendChild(nodeIdtPrincipioAtivo);

            nodeData.AppendChild(nodeFlFaturado);

            nodeData.AppendChild(nodeQtdCE);

            nodeData.AppendChild(nodeFlAtivo);

            nodeData.AppendChild(nodeFlReutilizavel);
                       

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(EstoqueLocalDTO dto)
        {
            EstoqueLocalDataTable dtb = new EstoqueLocalDataTable();
            DataRow dtr = dtb.NewRow();

            dtr[FieldNames.IdtProduto] = dto.IdtProduto.Value;
			
            dtr[FieldNames.IdtLote] = dto.IdtLote.Value;
			
            dtr[FieldNames.IdtSetor] = dto.IdtSetor.Value;
			
            dtr[FieldNames.IdtLocal] = dto.IdtLocal.Value;
			
            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;
			
            dtr[FieldNames.DataAtualizacao] = dto.DataAtualizacao.Value;
			
            dtr[FieldNames.Qtde] = dto.Qtde.Value;

            dtr[FieldNames.QtdeLote] = dto.QtdeLote.Value;

            dtr[FieldNames.QtdePadrao] = dto.QtdePadrao.Value;

            dtr[FieldNames.IdtFilial] = dto.IdtFilial.Value;

            dtr[FieldNames.FlPadrao] = dto.FlPadrao.Value;

            dtr[FieldNames.OutrosConsumos] = dto.OutrosConsumos.Value;

            dtr[FieldNames.Consumido] = dto.Consumido.Value;

            dtr[FieldNames.Percentual] = dto.Percentual.Value;

            dtr[FieldNames.DsProduto] = dto.DsProduto.Value;

            dtr[FieldNames.QtdeFracionada] = dto.QtdeFracionada.Value;

            dtr[FieldNames.UnidadeVenda] = dto.UnidadeVenda.Value;

            dtr[FieldNames.UnidadeCompra] = dto.UnidadeCompra.Value;

            dtr[FieldNames.UnidadeControle] = dto.UnidadeControle.Value;

            dtr[FieldNames.UnidadeConsumo] = dto.UnidadeConsumo.Value;

            dtr[FieldNames.DsUnidadeVenda] = dto.DsUnidadeVenda.Value;
            dtr[FieldNames.DsUnidadeCompra] = dto.DsUnidadeCompra.Value;
            dtr[FieldNames.DsUnidadeControle] = dto.DsUnidadeControle.Value;

            dtr[FieldNames.DsUnidade] = dto.DsUnidade.Value;
            dtr[FieldNames.DsSetor] = dto.DsSetor.Value;
            dtr[FieldNames.DsFilial] = dto.DsFilial.Value;

            dtr[FieldNames.Tabelamedica] = dto.Tabelamedica.Value;

            dtr[FieldNames.FlFracionado] = dto.FlFracionado.Value;

            dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;
            dtr[FieldNames.Origem] = dto.Origem.Value;

            dtr[FieldNames.SaldoMovimentacao] = dto.SaldoMovimentacao.Value;

            dtr[FieldNames.DataFornecimento] = dto.DataFornecimento.Value;
            dtr[FieldNames.PontoRessuprimento] = dto.PontoRessuprimento.Value;

            dtr[FieldNames.BaixaAutomatica] = dto.BaixaAutomatica.Value;

            dtr[FieldNames.DsProdutoOriginal] = dto.DsProdutoOriginal.Value;
            dtr[FieldNames.IdtProdutoOriginal] = dto.IdtProdutoOriginal.Value;


            dtr[FieldNames.IdtPrincipioAtivo] = dto.IdtPrincipioAtivo.Value;


            dtr[FieldNames.FlFaturado] = dto.FlFaturado.Value;


            dtr[FieldNames.QtdCE] = dto.QtdCE.Value;

            dtr[FieldNames.FlAtivo] = dto.FlAtivo.Value;

            dtr[FieldNames.FlReutilizavel] = dto.FlReutilizavel.Value;

            dtr[FieldNames.CodLote] = dto.CodLote.Value;

            dtr[FieldNames.DataAtualizaLote] = dto.DataAtualizaLote.Value;


            // FlReutilizavel cad_mtmd_fl_reutilizavel nodeFlReutilizavel
            // CAD_MTMD_FL_ATIVO FlAtivo cad_mtmd_fl_ativo nodeFlAtivo

            return dtr;
        }

        public static explicit operator XmlDocument(EstoqueLocalDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}