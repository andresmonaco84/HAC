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
	/// Classe Entidade MaterialMedicamentoDataTable
	/// </summary>
	[Serializable()]
	public class MaterialMedicamentoDataTable : DataTable
	{		
	    public MaterialMedicamentoDataTable()
            : base()
        {
            this.TableName = "DADOS";
            // Falta
            // CodGrMat, IdtFilial
            //
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.Idt, typeof(Decimal));
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.IdtPrincipioAtivo, typeof(Decimal));
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.IdtGrupo, typeof(Decimal));
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.IdtSubGrupo, typeof(Decimal));
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.Tabelamedica, typeof(String));
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.NomeFantasia, typeof(String));
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.Descricao, typeof(String));
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.CodMne, typeof(String));
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.CurvaAbc, typeof(String));
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.CdFabricante, typeof(String));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.FlFracionado, typeof(Decimal));
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.FlAtivo, typeof(Decimal));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.FlBaixaAutomatica, typeof(Decimal));
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.FlManterEstoque, typeof(Decimal));
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.FlReutilizavel, typeof(Decimal));
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.DtAtualizacao, typeof(DateTime));
		    this.Columns.Add(MaterialMedicamentoDTO.FieldNames.CdRm, typeof(String));

            //this.Columns.Add(MaterialMedicamentoDTO.FieldNames.IdtConvenio, typeof(Decimal));
            //this.Columns.Add(MaterialMedicamentoDTO.FieldNames.IdtPlano, typeof(Decimal));

            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.IdtFilial, typeof(Decimal));
            
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.IdtLote, typeof(Decimal));

            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.UnidadeVenda, typeof(Decimal));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.UnidadeCompra, typeof(Decimal));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.UnidadeControle, typeof(Decimal));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.UnidadeConsumo, typeof(Decimal));

            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.DsUnidadeVenda, typeof(String));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.DsUnidadeCompra, typeof(String));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.DsUnidadeControle, typeof(String));


            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.IdtSetor, typeof(Decimal));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.IdtLocal, typeof(Decimal));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.IdtUnidade, typeof(Decimal));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.TpPesquisa, typeof(Decimal));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.FlFaturado, typeof(Decimal));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.FlControlaLote, typeof(Decimal));

            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.TpFracao, typeof(Decimal));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.DsFracao, typeof(String));


            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.CustoMedio, typeof(Decimal));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.DtUltimoConsumo, typeof(DateTime));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.QtdeEstoqueContabil, typeof(Decimal));

            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.CodAnvisa, typeof(String));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia, typeof(String));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.CodGrupoAnvisa, typeof(String));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.FlDiluente, typeof(Decimal));

            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.Sal, typeof(String));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.FormaFarmaceutica, typeof(String));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.Dosagem, typeof(String));

            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.FlItemGeladeira, typeof(Decimal));
            this.Columns.Add(MaterialMedicamentoDTO.FieldNames.FlPadrao, typeof(Decimal));
            
            DataColumn[] primaryKey = { this.Columns[MaterialMedicamentoDTO.FieldNames.Idt] };

            this.PrimaryKey = primaryKey;
        }
		
        protected MaterialMedicamentoDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public MaterialMedicamentoDTO TypedRow(int index)
        {
            return (MaterialMedicamentoDTO)this.Rows[index];
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

        public void Add(MaterialMedicamentoDTO dto)
        {
            DataRow dtr = this.NewRow();

		    if (!dto.Idt.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		    if (!dto.IdtPrincipioAtivo.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.IdtPrincipioAtivo] = (Decimal)dto.IdtPrincipioAtivo.Value;
		    if (!dto.IdtGrupo.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.IdtGrupo] = (Decimal)dto.IdtGrupo.Value;
		    if (!dto.IdtSubGrupo.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.IdtSubGrupo] = (Decimal)dto.IdtSubGrupo.Value;
		    if (!dto.Tabelamedica.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.Tabelamedica] = (String)dto.Tabelamedica.Value;
		    if (!dto.NomeFantasia.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.NomeFantasia] = (String)dto.NomeFantasia.Value;
		    if (!dto.Descricao.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.Descricao] = (String)dto.Descricao.Value;
		    if (!dto.CodMne.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.CodMne] = (String)dto.CodMne.Value;
		    if (!dto.CurvaAbc.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.CurvaAbc] = (String)dto.CurvaAbc.Value;
		    if (!dto.CdFabricante.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.CdFabricante] = (String)dto.CdFabricante.Value;
            if (!dto.FlFracionado.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.FlFracionado] = (Decimal)dto.FlFracionado.Value;
		    if (!dto.FlAtivo.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.FlAtivo] = (Decimal)dto.FlAtivo.Value;
            if (!dto.FlBaixaAutomatica.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.FlBaixaAutomatica] = (Decimal)dto.FlBaixaAutomatica.Value;
		    if (!dto.FlManterEstoque.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.FlManterEstoque] = (Decimal)dto.FlManterEstoque.Value;
		    if (!dto.FlReutilizavel.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.FlReutilizavel] = (Decimal)dto.FlReutilizavel.Value;
		    if (!dto.DtAtualizacao.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.DtAtualizacao] = (DateTime)dto.DtAtualizacao.Value;
		    if (!dto.CdRm.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.CdRm] = (String)dto.CdRm.Value;

            //if (!dto.IdtConvenio.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.IdtConvenio] = (Decimal)dto.IdtConvenio.Value;
            //if (!dto.IdtPlano.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.IdtPlano] = (Decimal)dto.IdtPlano.Value;
            
            if (!dto.IdtFilial.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.IdtFilial] = (Decimal)dto.IdtFilial.Value;

            if (!dto.IdtLote.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.IdtLote] = (Decimal)dto.IdtLote.Value;

            if (!dto.UnidadeVenda.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.UnidadeVenda] = (Decimal)dto.UnidadeVenda.Value;
            if (!dto.UnidadeCompra.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.UnidadeCompra] = (Decimal)dto.UnidadeCompra.Value;
            if (!dto.UnidadeControle.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.UnidadeControle] = (Decimal)dto.UnidadeControle.Value;
            if (!dto.UnidadeConsumo.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.UnidadeConsumo] = (Decimal)dto.UnidadeConsumo.Value;

            if (!dto.DsUnidadeVenda.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.DsUnidadeVenda] = (String)dto.DsUnidadeVenda.Value;
            if (!dto.DsUnidadeCompra.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.DsUnidadeCompra] = (String)dto.DsUnidadeCompra.Value;
            if (!dto.DsUnidadeControle.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.DsUnidadeControle] = (String)dto.DsUnidadeControle.Value;

            if (!dto.IdtSetor.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.IdtSetor] = (Decimal)dto.IdtSetor.Value;
            if (!dto.IdtLocal.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.IdtLocal] = (Decimal)dto.IdtLocal.Value;
            if (!dto.IdtUnidade.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;
            if (!dto.TpPesquisa.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.TpPesquisa] = (Decimal)dto.TpPesquisa.Value;
            if (!dto.FlFaturado.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.FlFaturado] = (Decimal)dto.FlFaturado.Value;
            if (!dto.FlControlaLote.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.FlControlaLote] = (Decimal)dto.FlControlaLote.Value;

            if (!dto.TpFracao.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.TpFracao] = (Decimal)dto.TpFracao.Value;

            if (!dto.DsFracao.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.DsFracao] = (String)dto.DsFracao.Value;

            if (!dto.CustoMedio.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.CustoMedio] = (Decimal)dto.CustoMedio.Value;
            if (!dto.DtUltimoConsumo.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.DtUltimoConsumo] = (DateTime)dto.DtUltimoConsumo.Value;
            if (!dto.QtdeEstoqueContabil.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.QtdeEstoqueContabil] = (Decimal)dto.QtdeEstoqueContabil.Value;
            if (!dto.CodAnvisa.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.CodAnvisa] = (String)dto.CodAnvisa.Value;
            if (!dto.MedAltaVigilancia.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia] = (String)dto.MedAltaVigilancia.Value;
            if (!dto.CodGrupoAnvisa.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.CodGrupoAnvisa] = (String)dto.CodGrupoAnvisa.Value;
            if (!dto.FlDiluente.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.FlDiluente] = (Decimal)dto.FlDiluente.Value;

            if (!dto.Sal.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.Sal] = (String)dto.Sal.Value;
            if (!dto.FormaFarmaceutica.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.FormaFarmaceutica] = (String)dto.FormaFarmaceutica.Value;
            if (!dto.Dosagem.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.Dosagem] = (String)dto.Dosagem.Value;

            if (!dto.FlItemGeladeira.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.FlItemGeladeira] = (Decimal)dto.FlItemGeladeira.Value;
            if (!dto.FlPadrao.Value.IsNull) dtr[MaterialMedicamentoDTO.FieldNames.FlPadrao] = (Decimal)dto.FlPadrao.Value;

            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class MaterialMedicamentoDTO : MVC.DTO.DTOBase
    {
        public enum TipoMatMed
        {
            MATERIAL = 95,
            MEDICAMENTO = 96,
            TODOS = 0
        }

        public enum TipoFracionamento
        {
            GOTAS = 1
        }

        public enum Status
        {
            NAO = 0,
            SIM = 1
        }

        public enum Fracionado
        {
            NAO = 0,
            SIM = 1
        }

        public enum Reutilizavel
        {
            NAO = 0,
            SIM = 1
        }

        public enum Faturado
        {
            NAO = 0,
            SIM = 1
        }

        public enum BaixaAutomatica
        {
            NAO = 0,
            SIM = 1
        }

        /// <summary>
        /// Define qual o tipo de pesquisa que será realizado para buscar os produtos
        /// Sem Estoque = Não leva em conta a Filial do produto no estoque da unidade
        /// Com Estoque = Verifica se existe o Produto na Filial do Paciente
        /// </summary>
        public enum TipoDePesquisa
        {
            SEM_ESTOQUE = 0,
            COM_ESTOQUE = 1,
            COM_PERMISSAO_SUBGRUPO = 2,
            COM_PERMISSAO = 3
        }

		private MVC.DTO.FieldDecimal cad_mtmd_id;
		private MVC.DTO.FieldDecimal cad_mtmd_priati_id;
		private MVC.DTO.FieldDecimal cad_mtmd_grupo_id;
		private MVC.DTO.FieldDecimal cad_mtmd_subgrupo_id;
		private MVC.DTO.FieldString tis_med_cd_tabelamedica;
		private MVC.DTO.FieldString cad_mtmd_nomefantasia;
		private MVC.DTO.FieldString cad_mtmd_descricao;
		private MVC.DTO.FieldString cad_mtmd_codmne;
		private MVC.DTO.FieldString cad_mtmd_curva_abc;
		private MVC.DTO.FieldString cad_mtmd_cd_fabricante;
        private MVC.DTO.FieldDecimal cad_mtmd_fl_fraciona;
		private MVC.DTO.FieldDecimal cad_mtmd_fl_ativo;
        private MVC.DTO.FieldDecimal cad_mtmd_fl_baixa_automatica;
		private MVC.DTO.FieldDecimal cad_mtmd_fl_manter_estoque;
		private MVC.DTO.FieldDecimal cad_mtmd_fl_reutilizavel;
        private MVC.DTO.FieldDateTime cad_mtmd_dt_atualizacao;
		private MVC.DTO.FieldString cad_mtmd_cd_rm;

        //private MVC.DTO.FieldDecimal cad_cnv_id_convenio;
        //private MVC.DTO.FieldDecimal cad_pla_id_plano;
        
        private MVC.DTO.FieldDecimal cad_mtmd_filial_id;
        
        private MVC.DTO.FieldDecimal mtmd_lotest_id;

        // private MVC.DTO.FieldString ds_unidade_medida;
        private MVC.DTO.FieldDecimal cad_mtmd_unidade_venda;
        private MVC.DTO.FieldDecimal cad_mtmd_unidade_compra;
        private MVC.DTO.FieldDecimal cad_mtmd_unidade_controle;
        private MVC.DTO.FieldDecimal cad_mtmd_unidade_consumo;

        private MVC.DTO.FieldString cad_mtmd_unid_venda_ds;
        private MVC.DTO.FieldString cad_mtmd_unid_compra_ds;
        private MVC.DTO.FieldString cad_mtmd_unid_controle_ds;

        private MVC.DTO.FieldDecimal cad_set_id;
        private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
        private MVC.DTO.FieldDecimal cad_uni_id_unidade;

        private MVC.DTO.FieldDecimal tp_pesquisa;
        private MVC.DTO.FieldDecimal cad_mtmd_fl_faturado;
        private MVC.DTO.FieldDecimal cad_mtmd_fl_controla_lote;

        private MVC.DTO.FieldDecimal mtmd_tp_fracao_id;
        private MVC.DTO.FieldString mtmd_ds_tp_fracao;

        private MVC.DTO.FieldDecimal mtmd_custo_medio;
        private MVC.DTO.FieldDateTime dt_ultimo_consumo;
        private MVC.DTO.FieldDecimal mtmd_estcon_qtde;
        private MVC.DTO.FieldString cad_mtmd_cd_anvisa;
        private MVC.DTO.FieldString cad_mtmd_fl_mav;
        private MVC.DTO.FieldString cad_mtmd_cd_grupo_anvisa;
        private MVC.DTO.FieldDecimal cad_mtmd_fl_diluente;
        private MVC.DTO.FieldString cad_mtmd_priati_sal_dsc;
        private MVC.DTO.FieldString cad_mtmd_forma_farmaceutica;
        private MVC.DTO.FieldString cad_mtmd_dosagem_padronizada;

        private MVC.DTO.FieldDecimal mtmd_fl_geladeira;
        private MVC.DTO.FieldDecimal cad_mtmd_fl_padrao;

        public MaterialMedicamentoDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
		    this.cad_mtmd_id= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		    this.cad_mtmd_priati_id= new MVC.DTO.FieldDecimal(FieldNames.IdtPrincipioAtivo,Captions.IdtPrincipioAtivo, DbType.Decimal);
		    this.cad_mtmd_grupo_id= new MVC.DTO.FieldDecimal(FieldNames.IdtGrupo,Captions.IdtGrupo, DbType.Decimal);
		    this.cad_mtmd_subgrupo_id= new MVC.DTO.FieldDecimal(FieldNames.IdtSubGrupo,Captions.IdtSubGrupo, DbType.Decimal);
		    this.tis_med_cd_tabelamedica= new MVC.DTO.FieldString(FieldNames.Tabelamedica,Captions.Tabelamedica, 2);
		    this.cad_mtmd_nomefantasia= new MVC.DTO.FieldString(FieldNames.NomeFantasia,Captions.NomeFantasia, 100);
		    this.cad_mtmd_descricao= new MVC.DTO.FieldString(FieldNames.Descricao,Captions.Descricao, 50);
		    this.cad_mtmd_codmne= new MVC.DTO.FieldString(FieldNames.CodMne,Captions.CodMne, 10);
		    this.cad_mtmd_curva_abc= new MVC.DTO.FieldString(FieldNames.CurvaAbc,Captions.CurvaAbc, 1);
		    this.cad_mtmd_cd_fabricante= new MVC.DTO.FieldString(FieldNames.CdFabricante,Captions.CdFabricante, 15);
            this.cad_mtmd_fl_fraciona = new MVC.DTO.FieldDecimal(FieldNames.FlFracionado, Captions.FlFracionado, DbType.Decimal);
		    this.cad_mtmd_fl_ativo= new MVC.DTO.FieldDecimal(FieldNames.FlAtivo,Captions.FlAtivo, DbType.Decimal);
            this.cad_mtmd_fl_baixa_automatica = new MVC.DTO.FieldDecimal(FieldNames.FlBaixaAutomatica, Captions.FlBaixaAutomatica, DbType.Decimal);
		    this.cad_mtmd_fl_manter_estoque= new MVC.DTO.FieldDecimal(FieldNames.FlManterEstoque,Captions.FlManterEstoque, DbType.Decimal);
		    this.cad_mtmd_fl_reutilizavel= new MVC.DTO.FieldDecimal(FieldNames.FlReutilizavel,Captions.FlReutilizavel, DbType.Decimal);
            this.cad_mtmd_dt_atualizacao = new MVC.DTO.FieldDateTime(FieldNames.DtAtualizacao, Captions.DtAtualizacao);
		    this.cad_mtmd_cd_rm= new MVC.DTO.FieldString(FieldNames.CdRm,Captions.CdRm, 30);

            //this.cad_cnv_id_convenio = new MVC.DTO.FieldDecimal(FieldNames.IdtConvenio, Captions.IdtConvenio, DbType.Decimal);
            //this.cad_pla_id_plano = new MVC.DTO.FieldDecimal(FieldNames.IdtPlano, Captions.IdtPlano, DbType.Decimal);
            
            this.cad_mtmd_filial_id = new MVC.DTO.FieldDecimal(FieldNames.IdtFilial, Captions.IdtFilial, DbType.Decimal);
            
            this.mtmd_lotest_id = new MVC.DTO.FieldDecimal(FieldNames.IdtLote, Captions.IdtLote, DbType.Decimal);

            this.cad_mtmd_unidade_venda = new MVC.DTO.FieldDecimal(FieldNames.UnidadeVenda, Captions.UnidadeVenda, DbType.Decimal);
            this.cad_mtmd_unidade_compra = new MVC.DTO.FieldDecimal(FieldNames.UnidadeCompra, Captions.UnidadeCompra, DbType.Decimal);
            this.cad_mtmd_unidade_controle = new MVC.DTO.FieldDecimal(FieldNames.UnidadeControle, Captions.UnidadeControle, DbType.Decimal);
            this.cad_mtmd_unidade_consumo = new MVC.DTO.FieldDecimal(FieldNames.UnidadeConsumo, Captions.UnidadeConsumo, DbType.Decimal);

            this.cad_mtmd_unid_venda_ds = new MVC.DTO.FieldString(FieldNames.DsUnidadeVenda, Captions.DsUnidadeVenda, 100);
            this.cad_mtmd_unid_compra_ds = new MVC.DTO.FieldString(FieldNames.DsUnidadeCompra, Captions.DsUnidadeCompra, 100);
            this.cad_mtmd_unid_controle_ds = new MVC.DTO.FieldString(FieldNames.DsUnidadeControle, Captions.DsUnidadeControle, 100);

            this.cad_set_id = new MVC.DTO.FieldDecimal(FieldNames.IdtSetor, Captions.IdtSetor, DbType.Decimal);
            this.cad_lat_id_local_atendimento = new MVC.DTO.FieldDecimal(FieldNames.IdtLocal, Captions.IdtLocal, DbType.Decimal);
            this.cad_uni_id_unidade = new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade, Captions.IdtUnidade, DbType.Decimal);
            this.tp_pesquisa = new MVC.DTO.FieldDecimal(FieldNames.TpPesquisa, Captions.TpPesquisa, DbType.Decimal);
            this.cad_mtmd_fl_faturado = new MVC.DTO.FieldDecimal(FieldNames.FlFaturado, Captions.FlFaturado);
            this.cad_mtmd_fl_controla_lote = new MVC.DTO.FieldDecimal(FieldNames.FlControlaLote, Captions.FlControlaLote);

            this.mtmd_tp_fracao_id = new MVC.DTO.FieldDecimal(FieldNames.TpFracao, Captions.TpFracao);
            this.mtmd_ds_tp_fracao = new MVC.DTO.FieldString(FieldNames.DsFracao, Captions.DsFracao, 100);

            this.mtmd_custo_medio = new MVC.DTO.FieldDecimal(FieldNames.CustoMedio, Captions.CustoMedio);
            this.dt_ultimo_consumo = new MVC.DTO.FieldDateTime(FieldNames.DtUltimoConsumo, Captions.DtUltimoConsumo);
            this.mtmd_estcon_qtde = new MVC.DTO.FieldDecimal(FieldNames.QtdeEstoqueContabil, Captions.QtdeEstoqueContabil);

            this.cad_mtmd_cd_anvisa = new MVC.DTO.FieldString(FieldNames.CodAnvisa, Captions.CodAnvisa, 18);
            this.cad_mtmd_fl_mav = new MVC.DTO.FieldString(FieldNames.MedAltaVigilancia, Captions.MedAltaVigilancia, 1);
            this.cad_mtmd_cd_grupo_anvisa = new MVC.DTO.FieldString(FieldNames.CodGrupoAnvisa, Captions.CodGrupoAnvisa, 2);
            this.cad_mtmd_fl_diluente = new MVC.DTO.FieldDecimal(FieldNames.FlDiluente, Captions.FlDiluente);

            this.cad_mtmd_priati_sal_dsc = new MVC.DTO.FieldString(FieldNames.Sal, Captions.Sal, 100);
            this.cad_mtmd_forma_farmaceutica = new MVC.DTO.FieldString(FieldNames.FormaFarmaceutica, Captions.FormaFarmaceutica, 100);
            this.cad_mtmd_dosagem_padronizada = new MVC.DTO.FieldString(FieldNames.Dosagem, Captions.Dosagem, 100);

            this.mtmd_fl_geladeira = new MVC.DTO.FieldDecimal(FieldNames.FlItemGeladeira, Captions.FlItemGeladeira, DbType.Decimal);
            this.cad_mtmd_fl_padrao = new MVC.DTO.FieldDecimal(FieldNames.FlPadrao, Captions.FlPadrao, DbType.Decimal);
        } 
 
        #region FieldNames

        public struct FieldNames
        {
		    public const string Idt="CAD_MTMD_ID";
		    public const string IdtPrincipioAtivo="CAD_MTMD_PRIATI_ID";
		    public const string IdtGrupo="CAD_MTMD_GRUPO_ID";
		    public const string IdtSubGrupo="CAD_MTMD_SUBGRUPO_ID";
		    public const string Tabelamedica="TIS_MED_CD_TABELAMEDICA";
		    public const string NomeFantasia="CAD_MTMD_NOMEFANTASIA";
		    public const string Descricao="CAD_MTMD_DESCRICAO";
		    public const string CodMne="CAD_MTMD_CODMNE";
		    public const string CurvaAbc="CAD_MTMD_CURVA_ABC";
		    public const string CdFabricante="CAD_MTMD_CD_FABRICANTE";
		    public const string FlFracionado="CAD_MTMD_FL_FRACIONA";
		    public const string FlAtivo="CAD_MTMD_FL_ATIVO";
            public const string FlBaixaAutomatica = "CAD_MTMD_FL_BAIXA_AUTOMATICA";
		    public const string FlManterEstoque="CAD_MTMD_FL_MANTER_ESTOQUE";
		    public const string FlReutilizavel="CAD_MTMD_FL_REUTILIZAVEL";
            public const string DtAtualizacao = "CAD_MTMD_DT_ATUALIZACAO";
		    public const string CdRm="CAD_MTMD_CD_RM";

            //public const string IdtConvenio = "CAD_CNV_ID_CONVENIO";
            //public const string IdtPlano = "CAD_PLA_ID_PLANO";
            
            public const string IdtFilial = "CAD_MTMD_FILIAL_ID";

            public const string IdtLote = "MTMD_LOTEST_ID";

            public const string UnidadeVenda = "CAD_MTMD_UNIDADE_VENDA";
            public const string UnidadeCompra = "CAD_MTMD_UNIDADE_COMPRA";
            public const string UnidadeControle = "CAD_MTMD_UNIDADE_CONTROLE";
            public const string UnidadeConsumo = "CAD_MTMD_UNIDADE_CONSUMO";

            public const string DsUnidadeVenda = "CAD_MTMD_UNID_VENDA_DS";
            public const string DsUnidadeCompra = "CAD_MTMD_UNID_COMPRA_DS";
            public const string DsUnidadeControle = "CAD_MTMD_UNID_CONTROLE_DS";

            public const string IdtSetor = "CAD_SET_ID";
            public const string IdtLocal = "CAD_LAT_ID_LOCAL_ATENDIMENTO";
            public const string IdtUnidade = "CAD_UNI_ID_UNIDADE";
            public const string TpPesquisa = "TP_PESQUISA";
            public const string FlFaturado = "CAD_MTMD_FL_FATURADO";
            public const string FlControlaLote = "CAD_MTMD_FL_CONTROLA_LOTE";

            public const string TpFracao = "MTMD_TP_FRACAO_ID";

            public const string DsFracao = "MTMD_DS_TP_FRACAO";

            public const string CustoMedio = "MTMD_CUSTO_MEDIO";
            public const string DtUltimoConsumo = "DT_ULTIMO_CONSUMO";
            public const string QtdeEstoqueContabil = "MTMD_ESTCON_QTDE";
            public const string CodAnvisa = "CAD_MTMD_CD_ANVISA";
            public const string MedAltaVigilancia = "CAD_MTMD_FL_MAV";
            public const string CodGrupoAnvisa = "CAD_MTMD_CD_GRUPO_ANVISA";
            public const string FlDiluente = "CAD_MTMD_FL_DILUENTE";

            public const string Sal = "CAD_MTMD_PRIATI_SAL_DSC";
            public const string FormaFarmaceutica = "CAD_MTMD_FORMA_FARMACEUTICA";
            public const string Dosagem = "CAD_MTMD_DOSAGEM_PADRONIZADA";

            public const string FlItemGeladeira = "MTMD_FL_GELADEIRA";
            public const string FlPadrao = "CAD_MTMD_FL_PADRAO";
        }

        #endregion

        #region Captions
        public struct Captions
        {
		    public const string Idt="IDT";
		    public const string IdtPrincipioAtivo="IdtPrincipioAtivo";
		    public const string IdtGrupo="GRUPO";
		    public const string IdtSubGrupo="SUBGRUPO";
		    public const string Tabelamedica="TABELAMEDICA";
		    public const string NomeFantasia="NOMEFANTASIA";
		    public const string Descricao="DESCRICAO";
		    public const string CodMne="CODMNE";
		    public const string CurvaAbc="CURVAABC";
		    public const string CdFabricante="CDFABRICANTE";
		    public const string FlFracionado="FRACIONADO";
		    public const string FlAtivo="ATIVO";
            public const string FlBaixaAutomatica = "BAIXA_AUTOMATICA";
		    public const string FlManterEstoque="MANTERESTOQUE";
		    public const string FlReutilizavel="REUTILIZAVEL";
		    public const string DtAtualizacao="DTATUALIZACAO";
		    public const string CdRm="CDRM";
            
            //public const string IdtConvenio = "CAD_CNV_ID_CONVENIO";
            //public const string IdtPlano = "CAD_PLA_ID_PLANO";
            
            public const string IdtFilial = "CAD_MTMD_FILIAL_ID";

            public const string IdtLote = "IDTLOTE";

            public const string UnidadeVenda = "UNIDADEVENDA";
            public const string UnidadeCompra = "UNIDADECOMPRA";
            public const string UnidadeControle = "UNIDADECONTROLE";
            public const string UnidadeConsumo = "UNIDADECONSUMO";

            public const string DsUnidadeVenda = "DSUNIDADEVENDA";
            public const string DsUnidadeCompra = "DSUNIDADECOMPRA";
            public const string DsUnidadeControle = "DSUNIDADECONTROLE";


            public const string IdtSetor = "IdtSetor";
            public const string IdtLocal = "IdtLocal";
            public const string IdtUnidade = "IdtUnidade";

            public const string TpPesquisa = "TPPESQUISA";
            public const string FlFaturado = "FLFATURADO";
            public const string FlControlaLote = "FLCONTROLALOTE";

            public const string TpFracao = "TPFRACAO";

            public const string DsFracao = "DSFRACAO";

            public const string CustoMedio = "CUSTOMEDIO";
            public const string DtUltimoConsumo = "DTULTIMOCONSUMO";
            public const string QtdeEstoqueContabil = "QTDEESTOQUECONTABIL";

            public const string CodAnvisa = "CADMTMDCDANVISA";
            public const string MedAltaVigilancia = "CADMTMDFLMAV";
            public const string CodGrupoAnvisa = "CDGRUPOANVISA";
            public const string FlDiluente = "FLDILUENTE";

            public const string Sal = "PRIATISALDSC";
            public const string FormaFarmaceutica = "FORMAFARMACEUTICA";
            public const string Dosagem = "DOSAGEMPADRONIZADA";

            public const string FlItemGeladeira = "FLGELADEIRA";
            public const string FlPadrao = "FLPADRAO";
        }		

        #endregion
		
        #region Atributos Publicos
		
		public MVC.DTO.FieldDecimal Idt
		{
			get { return cad_mtmd_id; }
			set { cad_mtmd_id = value; }
		}
			
		public MVC.DTO.FieldDecimal IdtPrincipioAtivo
		{
			get { return cad_mtmd_priati_id; }
			set { cad_mtmd_priati_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtGrupo
		{
			get { return cad_mtmd_grupo_id; }
			set { cad_mtmd_grupo_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtSubGrupo
		{
			get { return cad_mtmd_subgrupo_id; }
			set { cad_mtmd_subgrupo_id = value; }
		}
		
        /// <summary>
        /// Informa tipo do Produto Material/Medicamento
        /// </summary>
		public MVC.DTO.FieldString Tabelamedica
		{
			get { return tis_med_cd_tabelamedica; }
			set { tis_med_cd_tabelamedica = value; }
		}
		
		public MVC.DTO.FieldString NomeFantasia
		{
			get { return cad_mtmd_nomefantasia; }
			set { cad_mtmd_nomefantasia = value; }
		}
		
		public MVC.DTO.FieldString Descricao
		{
			get { return cad_mtmd_descricao; }
			set { cad_mtmd_descricao = value; }
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

        /// <summary>
        /// Não está sendo utilizado
        /// </summary>
        public MVC.DTO.FieldDecimal UnidadeConsumo
        {
            get { return cad_mtmd_unidade_consumo; }
            set { cad_mtmd_unidade_consumo = value; }
        }

		public MVC.DTO.FieldString CodMne
		{
			get { return cad_mtmd_codmne; }
			set { cad_mtmd_codmne = value; }
		}
		
		public MVC.DTO.FieldString CurvaAbc
		{
			get { return cad_mtmd_curva_abc; }
			set { cad_mtmd_curva_abc = value; }
		}
		
		public MVC.DTO.FieldString CdFabricante
		{
			get { return cad_mtmd_cd_fabricante; }
			set { cad_mtmd_cd_fabricante = value; }
		}

        /// <summary>
        /// Informa se Produto é Fracionado=1 ou Inteiro=0
        /// </summary>
        public MVC.DTO.FieldDecimal FlFracionado
		{
			get { return cad_mtmd_fl_fraciona; }
			set { cad_mtmd_fl_fraciona = value; }
		}
		
        /// <summary>
        /// Informa se Produto está ativo? Ativo=1 Inativo=0
        /// </summary>
		public MVC.DTO.FieldDecimal FlAtivo
		{
			get { return cad_mtmd_fl_ativo; }
			set { cad_mtmd_fl_ativo = value; }
		}

        /// <summary>
        /// Informa se Produto é Baixa Automática, Não abastece o estoque do setor quando dispensado 
        /// </summary>
        public MVC.DTO.FieldDecimal FlBaixaAutomatica
        {
            get { return cad_mtmd_fl_baixa_automatica; }
            set { cad_mtmd_fl_baixa_automatica = value; }
        }
		
        /// <summary>
        /// Informa se produto mantem controle de estoque
        /// </summary>
		public MVC.DTO.FieldDecimal FlManterEstoque
		{
			get { return cad_mtmd_fl_manter_estoque; }
			set { cad_mtmd_fl_manter_estoque = value; }
		}
		
        /// <summary>
        /// Informa se produto pode ser reutilizado/ segue regra identica a de produtos fracionados
        /// </summary>
		public MVC.DTO.FieldDecimal FlReutilizavel
		{
			get { return cad_mtmd_fl_reutilizavel; }
			set { cad_mtmd_fl_reutilizavel = value; }
		}
		
        /// <summary>
        /// Data da última atualização do cadastro
        /// </summary>
		public MVC.DTO.FieldDateTime DtAtualizacao
		{
            get { return cad_mtmd_dt_atualizacao; }
			set { cad_mtmd_dt_atualizacao = value; }
		}
		
        /// <summary>
        /// Código do Produto na RM
        /// </summary>
		public MVC.DTO.FieldString CdRm
		{
			get { return cad_mtmd_cd_rm; }
			set { cad_mtmd_cd_rm = value; }
		}

        /// <summary>
        /// Não está sendo Utilizado ?
        /// </summary>
        //public MVC.DTO.FieldDecimal IdtConvenio
        //{
        //    get { return cad_cnv_id_convenio; }
        //    set { cad_cnv_id_convenio = value; }
        //}

        /// <summary>
        /// Não está sendo Utilizado ?
        /// </summary>
        //public MVC.DTO.FieldDecimal IdtPlano
        //{
        //    get { return cad_pla_id_plano; }
        //    set { cad_pla_id_plano = value; }
        //}

        /// <summary>
        /// Filial para pesquisa do Código de Barras
        /// </summary>
        public MVC.DTO.FieldDecimal IdtFilial
        {
            get { return cad_mtmd_filial_id; }
            set { cad_mtmd_filial_id = value; }
        }

        /// <summary>
        /// Lote para pesquisa do código de barras
        /// </summary>
        public MVC.DTO.FieldDecimal IdtLote
        {
            get { return mtmd_lotest_id; }
            set { mtmd_lotest_id = value; }
        }

        /// <summary>
        /// Descrição da Unidade de Venda
        /// </summary>
        public MVC.DTO.FieldString DsUnidadeVenda
        {
            get { return cad_mtmd_unid_venda_ds; }
            set { cad_mtmd_unid_venda_ds = value; }
        }

        /// <summary>
        /// Descrição da Unidade de Compra
        /// </summary>
        public MVC.DTO.FieldString DsUnidadeCompra
        {
            get { return cad_mtmd_unid_compra_ds; }
            set { cad_mtmd_unid_compra_ds = value; }
        }

        /// <summary>
        /// Descrição da Unidade de Controle
        /// </summary>
        public MVC.DTO.FieldString DsUnidadeControle
        {
            get { return cad_mtmd_unid_controle_ds; }
            set { cad_mtmd_unid_controle_ds = value; }
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
        /// Define se a filial de estoque do produto será levado em consideração para retorno do resultado da pesquisa
        /// ESTÁ EM USO ?
        /// </summary>
        public MVC.DTO.FieldDecimal TpPesquisa
        {
            get { return tp_pesquisa; }
            set { tp_pesquisa = value; }
        }
        /// <summary>
        /// Indica se Produto é cobrado no consumo (Envia para faturamento)
        /// </summary>
        public MVC.DTO.FieldDecimal FlFaturado
        {
            get { return cad_mtmd_fl_faturado; }
            set { cad_mtmd_fl_faturado = value; }
        }

        public MVC.DTO.FieldDecimal FlControlaLote
        {
            get { return cad_mtmd_fl_controla_lote; }
            set { cad_mtmd_fl_controla_lote = value; }
        }

        /// <summary>
        /// Id do Tipo de Fracionamento - Se existir conversão no fracionamento
        /// </summary>
        public MVC.DTO.FieldDecimal TpFracao
        {
            get { return mtmd_tp_fracao_id; }
            set { mtmd_tp_fracao_id = value; }
        }

        /// <summary>
        /// Descrição do tipo de Fraçãa. Se existir conversão no Fracionamento. EX: Gotas
        /// </summary>
        public MVC.DTO.FieldString DsFracao
        {
            get { return mtmd_ds_tp_fracao; }
            set { mtmd_ds_tp_fracao = value; }
        }

        /// <summary>
        /// Valor do Custo Médial Atual
        /// </summary>
        public MVC.DTO.FieldDecimal CustoMedio
        {
            get { return mtmd_custo_medio; }
            set { mtmd_custo_medio = value; }
        }

        /// <summary>
        /// Data da última baixa no estoque
        /// </summary>
        public MVC.DTO.FieldDateTime DtUltimoConsumo
        {
            get { return dt_ultimo_consumo; }
            set { dt_ultimo_consumo = value; }
        }


        /// <summary>
        /// Quantidade do Produto naSoma Geral do Hospital
        /// </summary>
        public MVC.DTO.FieldDecimal QtdeEstoqueContabil
        {
            get { return mtmd_estcon_qtde; }
            set { mtmd_estcon_qtde = value; }
        }

        public MVC.DTO.FieldString CodAnvisa
        {
            get { return cad_mtmd_cd_anvisa; }
            set { cad_mtmd_cd_anvisa = value; }
        }

        public MVC.DTO.FieldString MedAltaVigilancia
        {
            get { return cad_mtmd_fl_mav; }
            set { cad_mtmd_fl_mav = value; }
        }

        public MVC.DTO.FieldString CodGrupoAnvisa
        {
            get { return cad_mtmd_cd_grupo_anvisa; }
            set { cad_mtmd_cd_grupo_anvisa = value; }
        }

        public MVC.DTO.FieldDecimal FlDiluente
        {
            get { return cad_mtmd_fl_diluente; }
            set { cad_mtmd_fl_diluente = value; }
        }

        public MVC.DTO.FieldString Sal
        {
            get { return cad_mtmd_priati_sal_dsc; }
            set { cad_mtmd_priati_sal_dsc = value; }
        }

        public MVC.DTO.FieldString FormaFarmaceutica
        {
            get { return cad_mtmd_forma_farmaceutica; }
            set { cad_mtmd_forma_farmaceutica = value; }
        }

        public MVC.DTO.FieldString Dosagem
        {
            get { return cad_mtmd_dosagem_padronizada; }
            set { cad_mtmd_dosagem_padronizada = value; }
        }

        public MVC.DTO.FieldDecimal FlItemGeladeira
        {
            get { return mtmd_fl_geladeira; }
            set { mtmd_fl_geladeira = value; }
        }

        public MVC.DTO.FieldDecimal FlPadrao
        {
            get { return cad_mtmd_fl_padrao; }
            set { cad_mtmd_fl_padrao = value; }
        }

		#endregion
        
        #region Operators

        public static explicit operator MaterialMedicamentoDTO(DataRow row)
        {
            MaterialMedicamentoDTO  dto = new MaterialMedicamentoDTO();
			
				dto.Idt.Value = row[FieldNames.Idt].ToString();
					
				dto.IdtPrincipioAtivo.Value = row[FieldNames.IdtPrincipioAtivo].ToString();
			
				dto.IdtGrupo.Value = row[FieldNames.IdtGrupo].ToString();
			
				dto.IdtSubGrupo.Value = row[FieldNames.IdtSubGrupo].ToString();
			
				dto.Tabelamedica.Value = row[FieldNames.Tabelamedica].ToString();
			
				dto.NomeFantasia.Value = row[FieldNames.NomeFantasia].ToString();
			
				dto.Descricao.Value = row[FieldNames.Descricao].ToString();
			
				dto.UnidadeVenda.Value = row[FieldNames.UnidadeVenda].ToString();
			
				dto.UnidadeCompra.Value = row[FieldNames.UnidadeCompra].ToString();
			
				dto.UnidadeControle.Value = row[FieldNames.UnidadeControle].ToString();

                dto.UnidadeConsumo.Value = row[FieldNames.UnidadeConsumo].ToString();

				dto.CodMne.Value = row[FieldNames.CodMne].ToString();
			
				dto.CurvaAbc.Value = row[FieldNames.CurvaAbc].ToString();
			
				dto.CdFabricante.Value = row[FieldNames.CdFabricante].ToString();
			
				dto.FlFracionado.Value = row[FieldNames.FlFracionado].ToString();
			
				dto.FlAtivo.Value = row[FieldNames.FlAtivo].ToString();

                dto.FlBaixaAutomatica.Value = row[FieldNames.FlBaixaAutomatica].ToString();
			
				dto.FlManterEstoque.Value = row[FieldNames.FlManterEstoque].ToString();
			
				dto.FlReutilizavel.Value = row[FieldNames.FlReutilizavel].ToString();
			
				dto.DtAtualizacao.Value = row[FieldNames.DtAtualizacao].ToString();
			
				dto.CdRm.Value = row[FieldNames.CdRm].ToString();
			
                //dto.IdtConvenio.Value = row[FieldNames.IdtConvenio].ToString();
                //dto.IdtPlano.Value = row[FieldNames.IdtPlano].ToString();
                
                dto.IdtFilial.Value = row[FieldNames.IdtFilial].ToString();

                dto.IdtLote.Value = row[FieldNames.IdtLote].ToString();

                dto.DsUnidadeVenda.Value = row[FieldNames.DsUnidadeVenda].ToString();
                dto.DsUnidadeCompra.Value = row[FieldNames.DsUnidadeCompra].ToString();
                dto.DsUnidadeControle.Value = row[FieldNames.DsUnidadeControle].ToString();


                dto.IdtSetor.Value = row[FieldNames.IdtSetor].ToString();

                dto.IdtLocal.Value = row[FieldNames.IdtLocal].ToString();

                dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();

                dto.TpPesquisa.Value = row[FieldNames.TpPesquisa].ToString();

                dto.FlFaturado.Value = row[FieldNames.FlFaturado].ToString();

                dto.TpFracao.Value = row[FieldNames.TpFracao].ToString();

                dto.DsFracao.Value = row[FieldNames.DsFracao].ToString();

                dto.CustoMedio.Value = row[FieldNames.CustoMedio].ToString();
                dto.DtUltimoConsumo.Value = row[FieldNames.DtUltimoConsumo].ToString();
                dto.QtdeEstoqueContabil.Value = row[FieldNames.QtdeEstoqueContabil].ToString();

                try
                {
                    dto.CodAnvisa.Value = row[FieldNames.CodAnvisa].ToString();
                }                
                catch { //deixa passar se não tiver esta coluna                
                } 

                try
                {
                    dto.MedAltaVigilancia.Value = row[FieldNames.MedAltaVigilancia].ToString();
                }
                catch
                { //deixa passar se não tiver esta coluna                
                } 

                try
                {
                    dto.CodGrupoAnvisa.Value = row[FieldNames.CodGrupoAnvisa].ToString();
                }
                catch { //deixa passar se não tiver esta coluna                
                }

                try
                {
                    dto.FlControlaLote.Value = row[FieldNames.FlControlaLote].ToString();
                }
                catch
                { //deixa passar se não tiver esta coluna                
                }

                try
                {
                    dto.FlDiluente.Value = row[FieldNames.FlDiluente].ToString();
                }
                catch
                { //deixa passar se não tiver esta coluna                
                }

                try
                {
                    dto.Sal.Value = row[FieldNames.Sal].ToString();
                }
                catch
                { //deixa passar se não tiver esta coluna                
                }

                try
                {
                    dto.FormaFarmaceutica.Value = row[FieldNames.FormaFarmaceutica].ToString();
                }
                catch
                { //deixa passar se não tiver esta coluna                
                }

                try
                {
                    dto.Dosagem.Value = row[FieldNames.Dosagem].ToString();
                }
                catch
                { //deixa passar se não tiver esta coluna                
                }

                try
                {
                    dto.FlItemGeladeira.Value = row[FieldNames.FlItemGeladeira].ToString();
                }
                catch
                { //deixa passar se não tiver esta coluna                
                }

                try
                {
                    dto.FlPadrao.Value = row[FieldNames.FlPadrao].ToString();
                }
                catch
                { //deixa passar se não tiver esta coluna                
                } 

            return dto;
        }

        public static explicit operator MaterialMedicamentoDTO(XmlDocument xml)
        {
            MaterialMedicamentoDTO dto = new MaterialMedicamentoDTO();
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
					
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtPrincipioAtivo) != null) dto.IdtPrincipioAtivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtPrincipioAtivo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtGrupo) != null) dto.IdtGrupo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtGrupo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSubGrupo) != null) dto.IdtSubGrupo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSubGrupo).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Tabelamedica) != null) dto.Tabelamedica.Value = xml.FirstChild.SelectSingleNode(FieldNames.Tabelamedica).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.NomeFantasia) != null) dto.NomeFantasia.Value = xml.FirstChild.SelectSingleNode(FieldNames.NomeFantasia).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.Descricao) != null) dto.Descricao.Value = xml.FirstChild.SelectSingleNode(FieldNames.Descricao).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeVenda) != null) dto.UnidadeVenda.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeVenda).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeCompra) != null) dto.UnidadeCompra.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeCompra).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeControle) != null) dto.UnidadeControle.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeControle).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeConsumo) != null) dto.UnidadeConsumo.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeConsumo).InnerText;

				if (xml.FirstChild.SelectSingleNode(FieldNames.CodMne) != null) dto.CodMne.Value = xml.FirstChild.SelectSingleNode(FieldNames.CodMne).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.CurvaAbc) != null) dto.CurvaAbc.Value = xml.FirstChild.SelectSingleNode(FieldNames.CurvaAbc).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.CdFabricante) != null) dto.CdFabricante.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdFabricante).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.FlFracionado) != null) dto.FlFracionado.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlFracionado).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.FlAtivo) != null) dto.FlAtivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlAtivo).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.FlBaixaAutomatica) != null) dto.FlBaixaAutomatica.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlBaixaAutomatica).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.FlManterEstoque) != null) dto.FlManterEstoque.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlManterEstoque).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.FlReutilizavel) != null) dto.FlReutilizavel.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlReutilizavel).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.DtAtualizacao) != null) dto.DtAtualizacao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtAtualizacao).InnerText;			
			
				if (xml.FirstChild.SelectSingleNode(FieldNames.CdRm) != null) dto.CdRm.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdRm).InnerText;						
                
                //if (xml.FirstChild.SelectSingleNode(FieldNames.IdtConvenio) != null) dto.IdtConvenio.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtConvenio).InnerText;
                //if (xml.FirstChild.SelectSingleNode(FieldNames.IdtPlano) != null) dto.IdtPlano.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtPlano).InnerText;
                
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial) != null) dto.IdtFilial.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial).InnerText;
                
                if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLote) != null) dto.IdtLote.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLote).InnerText;


                if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeVenda) != null) dto.DsUnidadeVenda.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeVenda).InnerText;
                if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeCompra) != null) dto.DsUnidadeCompra.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeCompra).InnerText;
                if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeControle) != null) dto.DsUnidadeControle.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeControle).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor) != null) dto.IdtSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal) != null) dto.IdtLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.TpPesquisa) != null) dto.TpPesquisa.Value = xml.FirstChild.SelectSingleNode(FieldNames.TpPesquisa).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.FlFaturado) != null) dto.FlFaturado.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlFaturado).InnerText;

                if (xml.FirstChild.SelectSingleNode(FieldNames.TpFracao) != null) dto.TpFracao.Value = xml.FirstChild.SelectSingleNode(FieldNames.TpFracao).InnerText;
            
                if (xml.FirstChild.SelectSingleNode(FieldNames.DsFracao) != null) dto.DsFracao.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsFracao).InnerText;


                if (xml.FirstChild.SelectSingleNode(FieldNames.CustoMedio) != null) dto.CustoMedio.Value = xml.FirstChild.SelectSingleNode(FieldNames.CustoMedio).InnerText;
                if (xml.FirstChild.SelectSingleNode(FieldNames.DtUltimoConsumo) != null) dto.DtUltimoConsumo.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtUltimoConsumo).InnerText;
                if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeEstoqueContabil) != null) dto.QtdeEstoqueContabil.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeEstoqueContabil).InnerText;
                           
            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
						
            XmlNode nodeIdtPrincipioAtivo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtPrincipioAtivo, null);
			
            XmlNode nodeGrupo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtGrupo, null);
			
            XmlNode nodeSubGrupo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSubGrupo, null);
			
            XmlNode nodeTabelamedica = xml.CreateNode(XmlNodeType.Element, FieldNames.Tabelamedica, null);
			
            XmlNode nodeNomeFantasia = xml.CreateNode(XmlNodeType.Element, FieldNames.NomeFantasia, null);
			
            XmlNode nodeDescricao = xml.CreateNode(XmlNodeType.Element, FieldNames.Descricao, null);
			
            XmlNode nodeUnidadeVenda = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeVenda, null);
			
            XmlNode nodeUnidadeCompra = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeCompra, null);
			
            XmlNode nodeUnidadeControle = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeControle, null);

            XmlNode nodeUnidadeConsumo = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeConsumo, null);

            XmlNode nodeCodMne = xml.CreateNode(XmlNodeType.Element, FieldNames.CodMne, null);
			
            XmlNode nodeCurvaAbc = xml.CreateNode(XmlNodeType.Element, FieldNames.CurvaAbc, null);
			
            XmlNode nodeCdFabricante = xml.CreateNode(XmlNodeType.Element, FieldNames.CdFabricante, null);
			
            XmlNode nodeFracionado = xml.CreateNode(XmlNodeType.Element, FieldNames.FlFracionado, null);
			
            XmlNode nodeAtivo = xml.CreateNode(XmlNodeType.Element, FieldNames.FlAtivo, null);

            XmlNode nodeBaixaAutomatica = xml.CreateNode(XmlNodeType.Element, FieldNames.FlBaixaAutomatica, null);
			
            XmlNode nodeManterEstoque = xml.CreateNode(XmlNodeType.Element, FieldNames.FlManterEstoque, null);
			
            XmlNode nodeReutilizavel = xml.CreateNode(XmlNodeType.Element, FieldNames.FlReutilizavel, null);
			
            XmlNode nodeDtAtualizacao = xml.CreateNode(XmlNodeType.Element, FieldNames.DtAtualizacao, null);
			
            XmlNode nodeCdRm = xml.CreateNode(XmlNodeType.Element, FieldNames.CdRm, null);
			
            //XmlNode nodeIdtConvenio = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtConvenio, null);
            //XmlNode nodeIdtPlano = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtPlano, null);
            
            XmlNode nodeIdtFilial = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFilial, null);

            XmlNode nodeIdtLote = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLote, null);


            XmlNode nodeDsUnidadeVenda = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidadeVenda, null);
            XmlNode nodeDsUnidadeCompra = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidadeCompra, null);
            XmlNode nodeDsUnidadeControle = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidadeControle, null);


            XmlNode nodeIdtSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetor, null);

            XmlNode nodeIdtLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocal, null);

            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);

            XmlNode nodeTpPesquisa = xml.CreateNode(XmlNodeType.Element, FieldNames.TpPesquisa, null);

            XmlNode nodeFlFaturado = xml.CreateNode(XmlNodeType.Element, FieldNames.FlFaturado, null);

            XmlNode nodeTpFracao = xml.CreateNode(XmlNodeType.Element, FieldNames.TpFracao, null);

            XmlNode nodeDsFracao = xml.CreateNode(XmlNodeType.Element, FieldNames.DsFracao, null);

            XmlNode nodeCustoMedio = xml.CreateNode(XmlNodeType.Element, FieldNames.CustoMedio, null);

            XmlNode nodeDtUltimoConsumo = xml.CreateNode(XmlNodeType.Element, FieldNames.DtUltimoConsumo, null);

            XmlNode nodeQtdeEstoqueContabil = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeEstoqueContabil, null);



			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
						
			if (!this.IdtPrincipioAtivo.Value.IsNull) nodeIdtPrincipioAtivo.InnerText = this.IdtPrincipioAtivo.Value;
			
			if (!this.IdtGrupo.Value.IsNull) nodeGrupo.InnerText = this.IdtGrupo.Value;
			
			if (!this.IdtSubGrupo.Value.IsNull) nodeSubGrupo.InnerText = this.IdtSubGrupo.Value;
			
			if (!this.Tabelamedica.Value.IsNull) nodeTabelamedica.InnerText = this.Tabelamedica.Value;
			
			if (!this.NomeFantasia.Value.IsNull) nodeNomeFantasia.InnerText = this.NomeFantasia.Value;
			
			if (!this.Descricao.Value.IsNull) nodeDescricao.InnerText = this.Descricao.Value;
			
			if (!this.UnidadeVenda.Value.IsNull) nodeUnidadeVenda.InnerText = this.UnidadeVenda.Value;
			
			if (!this.UnidadeCompra.Value.IsNull) nodeUnidadeCompra.InnerText = this.UnidadeCompra.Value;
			
			if (!this.UnidadeControle.Value.IsNull) nodeUnidadeControle.InnerText = this.UnidadeControle.Value;

            if (!this.UnidadeConsumo.Value.IsNull) nodeUnidadeConsumo.InnerText = this.UnidadeConsumo.Value;

			if (!this.CodMne.Value.IsNull) nodeCodMne.InnerText = this.CodMne.Value;
			
			if (!this.CurvaAbc.Value.IsNull) nodeCurvaAbc.InnerText = this.CurvaAbc.Value;
			
			if (!this.CdFabricante.Value.IsNull) nodeCdFabricante.InnerText = this.CdFabricante.Value;
			
			if (!this.FlFracionado.Value.IsNull) nodeFracionado.InnerText = this.FlFracionado.Value;
			
			if (!this.FlAtivo.Value.IsNull) nodeAtivo.InnerText = this.FlAtivo.Value;

            if (!this.FlBaixaAutomatica.Value.IsNull) nodeBaixaAutomatica.InnerText = this.FlBaixaAutomatica.Value;
			
			if (!this.FlManterEstoque.Value.IsNull) nodeManterEstoque.InnerText = this.FlManterEstoque.Value;
			
			if (!this.FlReutilizavel.Value.IsNull) nodeReutilizavel.InnerText = this.FlReutilizavel.Value;
			
			if (!this.DtAtualizacao.Value.IsNull) nodeDtAtualizacao.InnerText = this.DtAtualizacao.Value;
			
			if (!this.CdRm.Value.IsNull) nodeCdRm.InnerText = this.CdRm.Value;
			
            //if (!this.IdtConvenio.Value.IsNull) nodeIdtConvenio.InnerText = this.IdtConvenio.Value;
            //if (!this.IdtPlano.Value.IsNull) nodeIdtPlano.InnerText = this.IdtPlano.Value;
            
            if (!this.IdtFilial.Value.IsNull) nodeIdtFilial.InnerText = this.IdtFilial.Value;
            
            if (!this.IdtLote.Value.IsNull) nodeIdtLote.InnerText = this.IdtLote.Value;

            if (!this.TpFracao.Value.IsNull) nodeTpFracao.InnerText = this.TpFracao.Value;

            if (!this.DsUnidadeVenda.Value.IsNull) nodeDsUnidadeVenda.InnerText = this.DsUnidadeVenda.Value;
            if (!this.DsUnidadeCompra.Value.IsNull) nodeDsUnidadeCompra.InnerText = this.DsUnidadeCompra.Value;
            if (!this.DsUnidadeControle.Value.IsNull) nodeDsUnidadeControle.InnerText = this.DsUnidadeControle.Value;


            if (!this.IdtSetor.Value.IsNull) nodeIdtSetor.InnerText = this.IdtSetor.Value;

            if (!this.IdtLocal.Value.IsNull) nodeIdtLocal.InnerText = this.IdtLocal.Value;

            if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;

            if (!this.TpPesquisa.Value.IsNull) nodeTpPesquisa.InnerText = this.TpPesquisa.Value;
            if (!this.FlFaturado.Value.IsNull) nodeFlFaturado.InnerText = this.FlFaturado.Value;

            if (!this.DsFracao.Value.IsNull) nodeDsFracao.InnerText = this.DsFracao.Value;

            if (!this.CustoMedio.Value.IsNull) nodeCustoMedio.InnerText = this.CustoMedio.Value;
            if (!this.DtUltimoConsumo.Value.IsNull) nodeDtUltimoConsumo.InnerText = this.DtUltimoConsumo.Value;
            if (!this.QtdeEstoqueContabil.Value.IsNull) nodeQtdeEstoqueContabil.InnerText = this.QtdeEstoqueContabil.Value;


            nodeData.AppendChild(nodeIdt);
						
            nodeData.AppendChild(nodeIdtPrincipioAtivo);
			
            nodeData.AppendChild(nodeGrupo);
			
            nodeData.AppendChild(nodeSubGrupo);
			
            nodeData.AppendChild(nodeTabelamedica);
			
            nodeData.AppendChild(nodeNomeFantasia);
			
            nodeData.AppendChild(nodeDescricao);
			
            nodeData.AppendChild(nodeUnidadeVenda);
			
            nodeData.AppendChild(nodeUnidadeCompra);
			
            nodeData.AppendChild(nodeUnidadeControle);

            nodeData.AppendChild(nodeUnidadeConsumo);

            nodeData.AppendChild(nodeCodMne);
			
            nodeData.AppendChild(nodeCurvaAbc);
			
            nodeData.AppendChild(nodeCdFabricante);
			
            nodeData.AppendChild(nodeFracionado);
			
            nodeData.AppendChild(nodeAtivo);

            nodeData.AppendChild(nodeBaixaAutomatica);
			
            nodeData.AppendChild(nodeManterEstoque);
			
            nodeData.AppendChild(nodeReutilizavel);
			
            nodeData.AppendChild(nodeDtAtualizacao);
			
            nodeData.AppendChild(nodeCdRm);

            //nodeData.AppendChild(nodeIdtConvenio);
            //nodeData.AppendChild(nodeIdtPlano);
            
            nodeData.AppendChild(nodeIdtFilial);

            nodeData.AppendChild(nodeIdtLote);

            nodeData.AppendChild(nodeDsUnidadeVenda);
            nodeData.AppendChild(nodeDsUnidadeCompra);
            nodeData.AppendChild(nodeDsUnidadeControle);

            nodeData.AppendChild(nodeIdtSetor);

            nodeData.AppendChild(nodeIdtLocal);

            nodeData.AppendChild(nodeIdtUnidade);

            nodeData.AppendChild(nodeTpPesquisa);
            nodeData.AppendChild(nodeFlFaturado);

            nodeData.AppendChild(nodeTpFracao);

            nodeData.AppendChild(nodeDsFracao);

            nodeData.AppendChild(nodeCustoMedio);
            nodeData.AppendChild(nodeDtUltimoConsumo);
            nodeData.AppendChild(nodeQtdeEstoqueContabil);

            xml.AppendChild(nodeData);
            return xml;
        }

        public static explicit operator DataRow(MaterialMedicamentoDTO dto)
        {
            MaterialMedicamentoDataTable dtb = new MaterialMedicamentoDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
						
            dtr[FieldNames.IdtPrincipioAtivo] = dto.IdtPrincipioAtivo.Value;
			
            dtr[FieldNames.IdtGrupo] = dto.IdtGrupo.Value;
			
            dtr[FieldNames.IdtSubGrupo] = dto.IdtSubGrupo.Value;
			
            dtr[FieldNames.Tabelamedica] = dto.Tabelamedica.Value;
			
            dtr[FieldNames.NomeFantasia] = dto.NomeFantasia.Value;
			
            dtr[FieldNames.Descricao] = dto.Descricao.Value;
			
            dtr[FieldNames.UnidadeVenda] = dto.UnidadeVenda.Value;
			
            dtr[FieldNames.UnidadeCompra] = dto.UnidadeCompra.Value;
			
            dtr[FieldNames.UnidadeControle] = dto.UnidadeControle.Value;

            dtr[FieldNames.UnidadeConsumo] = dto.UnidadeConsumo.Value;

            dtr[FieldNames.CodMne] = dto.CodMne.Value;
			
            dtr[FieldNames.CurvaAbc] = dto.CurvaAbc.Value;
			
            dtr[FieldNames.CdFabricante] = dto.CdFabricante.Value;
			
            dtr[FieldNames.FlFracionado] = dto.FlFracionado.Value;
			
            dtr[FieldNames.FlAtivo] = dto.FlAtivo.Value;

            dtr[FieldNames.FlBaixaAutomatica] = dto.FlBaixaAutomatica.Value;
			
            dtr[FieldNames.FlManterEstoque] = dto.FlManterEstoque.Value;
			
            dtr[FieldNames.FlReutilizavel] = dto.FlReutilizavel.Value;
			
            dtr[FieldNames.DtAtualizacao] = dto.DtAtualizacao.Value;
			
            dtr[FieldNames.CdRm] = dto.CdRm.Value;

            //dtr[FieldNames.IdtConvenio] = dto.IdtConvenio.Value;
            
            dtr[FieldNames.IdtFilial] = dto.IdtFilial.Value;

            dtr[FieldNames.IdtLote] = dto.IdtLote.Value;

            dtr[FieldNames.DsUnidadeVenda] = dto.DsUnidadeVenda.Value;

            dtr[FieldNames.DsUnidadeCompra] = dto.DsUnidadeCompra.Value;

            dtr[FieldNames.DsUnidadeControle] = dto.DsUnidadeControle.Value;

            dtr[FieldNames.IdtSetor] = dto.IdtSetor.Value;

            dtr[FieldNames.IdtLocal] = dto.IdtLocal.Value;

            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;

            dtr[FieldNames.TpPesquisa] = dto.TpPesquisa.Value;

            dtr[FieldNames.FlFaturado] = dto.FlFaturado.Value;

            dtr[FieldNames.FlControlaLote] = dto.FlControlaLote.Value;

            dtr[FieldNames.TpFracao] = dto.TpFracao.Value;

            dtr[FieldNames.DsFracao] = dto.DsFracao.Value;

            dtr[FieldNames.CustoMedio] = dto.CustoMedio.Value;
            dtr[FieldNames.DtUltimoConsumo] = dto.DtUltimoConsumo.Value;
            dtr[FieldNames.QtdeEstoqueContabil] = dto.QtdeEstoqueContabil.Value;
            dtr[FieldNames.CodAnvisa] = dto.CodAnvisa.Value;
            dtr[FieldNames.MedAltaVigilancia] = dto.MedAltaVigilancia.Value;
            dtr[FieldNames.CodGrupoAnvisa] = dto.CodGrupoAnvisa.Value;

            dtr[FieldNames.FlDiluente] = dto.FlDiluente.Value;

            dtr[FieldNames.Sal] = dto.Sal.Value;
            dtr[FieldNames.FormaFarmaceutica] = dto.FormaFarmaceutica.Value;
            dtr[FieldNames.Dosagem] = dto.Dosagem.Value;

            dtr[FieldNames.FlItemGeladeira] = dto.FlItemGeladeira.Value;
            dtr[FieldNames.FlPadrao] = dto.FlPadrao.Value;

            //DsFracao  MTMD_DS_TP_FRACAO mtmd_ds_tp_fracao nodeDsFracao

            return dtr;
        }

        public static explicit operator XmlDocument(MaterialMedicamentoDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}