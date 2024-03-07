
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
	/// Classe Entidade MovimentacaoDataTable
	/// </summary>
	[Serializable()]
	public class MovimentacaoDataTable : DataTable
	{		
	    public MovimentacaoDataTable()
            : base()
        {
            this.TableName = "DADOS";

		    this.Columns.Add(MovimentacaoDTO.FieldNames.Idt, typeof(Decimal));
		    this.Columns.Add(MovimentacaoDTO.FieldNames.IdtLote, typeof(Decimal));
		    this.Columns.Add(MovimentacaoDTO.FieldNames.IdtProduto, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DataMovimento, typeof(DateTime));
		    this.Columns.Add(MovimentacaoDTO.FieldNames.Qtde, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DsSetor, typeof(String));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DsLocal, typeof(String));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DsUnidade, typeof(String));
		    this.Columns.Add(MovimentacaoDTO.FieldNames.FlFinalizado, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DsProduto, typeof(String));
            this.Columns.Add(MovimentacaoDTO.FieldNames.UnidadeVenda, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DsUnidadeVenda, typeof(String));
            this.Columns.Add(MovimentacaoDTO.FieldNames.FlFracionado, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.EstoqueLocal, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.EstoqueLocalFracionado, typeof(Decimal));

            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtLocal, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtUnidade, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtSetor, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtTipo, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtSubTipo, typeof(Decimal));

            // BAIXA 
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtUnidadeBaixa, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtLocalBaixa, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtSetorBaixa, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtTipoBaixa, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtSubTipoBaixa, typeof(Decimal));
            
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtFilial, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.QtdeLote, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.CdBarra, typeof(String));

            this.Columns.Add(MovimentacaoDTO.FieldNames.DsQtdeFracionado, typeof(String));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DsQtdeConsumo, typeof(String));
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtRequisicao, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.FlFaturado, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DataRessupri, typeof(DateTime));
            // atendimento
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtAtendimento, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.TpAtendimento, typeof(String));

            // SEGURANÇA
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtUsuario, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtUsuarioEstorno, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DsUsuario, typeof(String));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DsUsuarioEstorno, typeof(String));

            //COMPLEMENTO
            this.Columns.Add(MovimentacaoDTO.FieldNames.Obs, typeof(String));
            this.Columns.Add(MovimentacaoDTO.FieldNames.UsuarioRelatado, typeof(String));
            this.Columns.Add(MovimentacaoDTO.FieldNames.IdtLocalEstoque, typeof(Decimal));            

            // LISTA MOVIMENTACAO
            this.Columns.Add(MovimentacaoDTO.FieldNames.QtdeEntrada, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.QtdeEntradaOutros, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.QtdeSaida, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.QtdeSaidaOutros, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.QtdeAcerto, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DsSubtipoMov, typeof(String));
            this.Columns.Add(MovimentacaoDTO.FieldNames.SaldoMovimento, typeof(Decimal));

            this.Columns.Add(MovimentacaoDTO.FieldNames.FormOrigem, typeof(Decimal));                       
            
            this.Columns.Add(MovimentacaoDTO.FieldNames.CodProdutoMNE, typeof(String));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DsUnidadeCompra, typeof(String));
            this.Columns.Add(MovimentacaoDTO.FieldNames.ValorUnitario, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.ValorTotal, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DataAte, typeof(DateTime));
            this.Columns.Add(MovimentacaoDTO.FieldNames.Tabelamedica, typeof(String));

            this.Columns.Add(MovimentacaoDTO.FieldNames.FlEstornado, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.TpFracao, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.QtdConvertida, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DsQtdConvertida, typeof(String));
            
            this.Columns.Add(MovimentacaoDTO.FieldNames.DtFaturamento, typeof(DateTime));
            this.Columns.Add(MovimentacaoDTO.FieldNames.HrFaturamento, typeof(Decimal));

            this.Columns.Add(MovimentacaoDTO.FieldNames.TipoEmpresa, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.SubTipoMovFaturado, typeof(Decimal));

            this.Columns.Add(MovimentacaoDTO.FieldNames.SequenciaConsumoFaturamento, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.CodigoIBGEMunicipioHomeCare, typeof(String));

            this.Columns.Add(MovimentacaoDTO.FieldNames.idtMotivo, typeof(Decimal));
                        
            // Aux. p/ Relatorios
            this.Columns.Add(MovimentacaoDTO.FieldNames.DtIni, typeof(DateTime));
            this.Columns.Add(MovimentacaoDTO.FieldNames.DtFim, typeof(DateTime));

            this.Columns.Add(MovimentacaoDTO.FieldNames.CodLote, typeof(String));
            this.Columns.Add(MovimentacaoDTO.FieldNames.SaldoLoteSetor, typeof(Decimal));
            this.Columns.Add(MovimentacaoDTO.FieldNames.SaldoLoteTotal, typeof(Decimal));

            // DataColumn[] primaryKey = { this.Columns[MovimentacaoDTO.FieldNames.Idt] };
            // this.PrimaryKey = primaryKey;
        }
		
        protected MovimentacaoDataTable(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext){}


		public MovimentacaoDTO TypedRow(int index)
        {
            return (MovimentacaoDTO)this.Rows[index];
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

        public void Add(MovimentacaoDTO dto)
        {
            DataRow dtr = this.NewRow();

            if (!dto.Idt.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.Idt] = (Decimal)dto.Idt.Value;
		    if (!dto.IdtLocal.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtLocal] = (Decimal)dto.IdtLocal.Value;
		    if (!dto.IdtUnidade.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtUnidade] = (Decimal)dto.IdtUnidade.Value;
		    if (!dto.IdtSetor.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtSetor] = (Decimal)dto.IdtSetor.Value;
            if (!dto.DsSetor.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DsSetor] = (String)dto.DsSetor.Value;
            if (!dto.DsLocal.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DsLocal] = (String)dto.DsLocal.Value;
            if (!dto.DsUnidade.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DsUnidade] = (String)dto.DsUnidade.Value;
		    if (!dto.IdtLote.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtLote] = (Decimal)dto.IdtLote.Value;
		    if (!dto.IdtProduto.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtProduto] = (Decimal)dto.IdtProduto.Value;
		    if (!dto.IdtTipo.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtTipo] = (Decimal)dto.IdtTipo.Value;
		    if (!dto.IdtSubTipo.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtSubTipo] = (Decimal)dto.IdtSubTipo.Value;
            if (!dto.DataMovimento.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DataMovimento] = (DateTime)dto.DataMovimento.Value;
		    if (!dto.Qtde.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.Qtde] = (Decimal)dto.Qtde.Value;
		    if (!dto.FlFinalizado.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.FlFinalizado] = (Decimal)dto.FlFinalizado.Value;
            if (!dto.UnidadeVenda.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.UnidadeVenda] = (Decimal)dto.UnidadeVenda.Value;
            if (!dto.DsProduto.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DsProduto] = (String)dto.DsProduto.Value;
            if (!dto.DsUnidadeVenda.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DsUnidadeVenda] = (String)dto.DsUnidadeVenda.Value;
            if (!dto.FlFracionado.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.FlFracionado] = (Decimal)dto.FlFracionado.Value;
            if (!dto.EstoqueLocal.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.EstoqueLocal] = (Decimal)dto.EstoqueLocal.Value;
            if (!dto.EstoqueLocalFracionado.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.EstoqueLocalFracionado] = (Decimal)dto.EstoqueLocalFracionado.Value;
            if (!dto.IdtUnidadeBaixa.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtUnidadeBaixa] = (Decimal)dto.IdtUnidadeBaixa.Value;
            if (!dto.IdtLocalBaixa.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtLocalBaixa] = (Decimal)dto.IdtLocalBaixa.Value;
            if (!dto.IdtSetorBaixa.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtSetorBaixa] = (Decimal)dto.IdtSetorBaixa.Value;
            if (!dto.IdtTipoBaixa.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtTipoBaixa] = (Decimal)dto.IdtTipoBaixa.Value;
            if (!dto.IdtSubTipoBaixa.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtSubTipoBaixa] = (Decimal)dto.IdtSubTipoBaixa.Value;
            if (!dto.IdtFilial.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtFilial] = (Decimal)dto.IdtFilial.Value;
            if (!dto.QtdeLote.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.QtdeLote] = (Decimal)dto.QtdeLote.Value;
            if (!dto.CdBarra.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.CdBarra] = (String)dto.CdBarra.Value;
            if (!dto.DsQtdeFracionado.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DsQtdeFracionado] = (String)dto.DsQtdeFracionado.Value;
            if (!dto.DsQtdeConsumo.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DsQtdeConsumo] = (String)dto.DsQtdeConsumo.Value;
            if (!dto.IdtRequisicao.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtRequisicao] = (Decimal)dto.IdtRequisicao.Value;
            if (!dto.FlFaturado.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.FlFaturado] = (Decimal)dto.FlFaturado.Value;
            if (!dto.IdtAtendimento.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtAtendimento] = (Decimal)dto.IdtAtendimento.Value;
            if (!dto.TpAtendimento.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.TpAtendimento] = (String)dto.TpAtendimento.Value;
            if (!dto.DataRessupri.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DataRessupri] = (DateTime)dto.DataRessupri.Value;
            // SEGURANÇA
            if (!dto.IdtUsuario.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtUsuario] = (Decimal)dto.IdtUsuario.Value;
            if (!dto.IdtUsuarioEstorno.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtUsuarioEstorno] = (Decimal)dto.IdtUsuarioEstorno.Value;
            if (!dto.DsUsuario.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DsUsuario] = (String)dto.DsUsuario.Value;
            if (!dto.DsUsuarioEstorno.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DsUsuarioEstorno] = (String)dto.DsUsuarioEstorno.Value;

           // COMPLEMENTO
            if (!dto.Obs.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.Obs] = (String)dto.Obs.Value;
            if (!dto.UsuarioRelatado.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.UsuarioRelatado] = (String)dto.UsuarioRelatado.Value;
            if (!dto.IdtLocalEstoque.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.IdtLocalEstoque] = (Decimal)dto.IdtLocalEstoque.Value;

            //LISTA MOVIMENTO
            if (!dto.QtdeEntrada.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.QtdeEntrada] = (Decimal)dto.QtdeEntrada.Value;
            if (!dto.QtdeEntradaOutros.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.QtdeEntradaOutros] = (Decimal)dto.QtdeEntradaOutros.Value;
            if (!dto.QtdeSaida.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.QtdeSaida] = (Decimal)dto.QtdeSaida.Value;
            if (!dto.QtdeSaidaOutros.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.QtdeSaidaOutros] = (Decimal)dto.QtdeSaidaOutros.Value;
            if (!dto.QtdeAcerto.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.QtdeAcerto] = (Decimal)dto.QtdeAcerto.Value;
            if (!dto.DsSubtipoMov.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DsSubtipoMov] = (String)dto.DsSubtipoMov.Value;
            if (!dto.SaldoMovimento.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.SaldoMovimento] = (Decimal)dto.SaldoMovimento.Value;


            if (!dto.FormOrigem.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.FormOrigem] = (Decimal)dto.FormOrigem.Value;
            
            if (!dto.CodProdutoMNE.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.CodProdutoMNE] = (String)dto.CodProdutoMNE.Value;
            if (!dto.DsUnidadeCompra.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DsUnidadeCompra] = (String)dto.DsUnidadeCompra.Value;
            if (!dto.ValorUnitario.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.ValorUnitario] = (Decimal)dto.ValorUnitario.Value;
            if (!dto.ValorTotal.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.ValorTotal] = (Decimal)dto.ValorTotal.Value;
            if (!dto.DataAte.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DataAte] = (DateTime)dto.DataAte.Value;
            if (!dto.Tabelamedica.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.Tabelamedica] = (String)dto.Tabelamedica.Value;

            if (!dto.FlEstornado.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.FlEstornado] = (Decimal)dto.FlEstornado.Value;

            if (!dto.TpFracao.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.TpFracao] = (Decimal)dto.TpFracao.Value;
            if (!dto.QtdConvertida.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.QtdConvertida] = (Decimal)dto.QtdConvertida.Value;
            if (!dto.DsQtdConvertida.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DsQtdConvertida] = (String)dto.DsQtdConvertida.Value;

            if (!dto.DtFaturamento.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DtFaturamento] = (DateTime)dto.DtFaturamento.Value;
            if (!dto.HrFaturamento.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.HrFaturamento] = (Decimal)dto.HrFaturamento.Value;

            if (!dto.TipoEmpresa.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.TipoEmpresa] = (Decimal)dto.TipoEmpresa.Value;
            if (!dto.SubTipoMovFaturado.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.SubTipoMovFaturado] = (Decimal)dto.SubTipoMovFaturado.Value;

            if (!dto.SequenciaConsumoFaturamento.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.SequenciaConsumoFaturamento] = (Decimal)dto.SequenciaConsumoFaturamento.Value;
            if (!dto.CodigoIBGEMunicipioHomeCare.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.CodigoIBGEMunicipioHomeCare] = (String)dto.CodigoIBGEMunicipioHomeCare.Value;

            if (!dto.idtMotivo.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.idtMotivo] = (Decimal)dto.idtMotivo.Value;

            if (!dto.CodLote.Value.IsNull) dtr[EstoqueLocalDTO.FieldNames.CodLote] = (String)dto.CodLote.Value;
            if (!dto.SaldoLoteSetor.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.SaldoLoteSetor] = (Decimal)dto.SaldoLoteSetor.Value;
            if (!dto.SaldoLoteTotal.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.SaldoLoteTotal] = (Decimal)dto.SaldoLoteTotal.Value;

            if (!dto.DtIni.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DtIni] = (DateTime)dto.DtIni.Value;
            if (!dto.DtFim.Value.IsNull) dtr[MovimentacaoDTO.FieldNames.DtFim] = (DateTime)dto.DtFim.Value;
            
            this.Rows.Add(dtr);
        }
    }
	
    [Serializable()]
    public class MovimentacaoDTO : MVC.DTO.DTOBase
    {
        public enum TipoMovimento
        {
            ENTRADA = 1,
            SAIDA = 2,
            ACERTO = 3
        }

        public enum SubTipoMovimento
        {
            ENTRADA_FORNECEDOR = 1,
            TRANSFERENCIA_ENTRADA = 2,
            TRANSFERENCIA_SAIDA = 3,
            ENTRADA_RESSUPRIMENTO_REQ_AVULSA = 4,
            BAIXA_CENTRAL_REQ_AVULSA = 5,
            BAIXA_PERDA_QUEBRA = 6,
            ENTRADA_RESSUPRIMENTO_REQ_PADRAO = 7,                
            BAIXA_CENTRAL_REQ_PADRAO = 8,
            ENTRADA_RESSUPRIMENTO_PERSONALIZADO = 9,
            BAIXA_CENTRAL_PERSONALIZADO = 10,
            BAIXA_SETOR_CONSUMO_PACIENTE = 11,
            BAIXA_SETOR_AUTOMATICA = 12,
            ENTRADA_ESTORNO_LANCAMENTO = 13, // estorno lancamento não faturado
            MOVIMENTACAO_FRACIONADA = 14,
            BAIXA_ESTORNO_NOTA_FISCAL = 15,            
            CONSUMO_PACIENTE_ESTORNADO = 16, //Quando algum item tem este status, anteriormente ele tinha o status 11
            CONSUMO_PACIENTE_ESTORNADO_FRACIONADO = 17, //Quando algum item tem este status, anteriormente ele tinha o status 14
            BAIXA_CONSUMO_NAO_FATURADO_SETOR = 18,
            BAIXA_CONSUMO_CENTRO_CUSTO = 19, // BAIXA ESTOQUE DA ORIGEM PARA DISTRIBUIR DESPESA NO CENTRO DE CUSTO
            ACERTO_DE_ESTOQUE = 20, // NAO ESTA MAIS EM USO, FOI SUBSTITUIDO
            ENTRADA_RESSUPRIMENTO_CARRINHO_EMERGENCIA = 21,
            BAIXA_RESSUPRIMENTO_CARRINHO_EMERGENCIA = 22,
            DISPENSACAO_ESTORNO = 23,
            BAIXA_CONSUMO_CARRINHO_EMERGENCIA_NAO_FATURADO = 24,
            BAIXA_CONSUMO_CARRINHO_EMERGENCIA_FATURADO = 25,
            MOVIMENTACAO_FRACIONADA_CARRINHO_EMERGENCIA = 26,
            DISTRIBUICAO_DESPESA_CENTRO_CUSTO = 27, // MOVIMENTAÇÃO DE DISTRUIBUIÇÃO DE DESPESA PARA UNIDADE ( CENTRO DE CUSTO )
            DISTRIBUICAO_DESPESA_HOME_CARE = 28,     // MOVIMENTAÇÃO DE DISTRUIBUIÇÃO DE DESPESA PARA HOME CARE
            ESTORNO_CONSUMO_CENTRO_CUSTO = 29,  // ESTORNA BAIXA EM ESTOQUE DA MOVIMENTAÇÃO DE CONSUMO CENTRO DE CUSTO
            ACERTO_BAIXA = 30,
            ACERTO_ENTRADA = 31,
            CONVERSAO_INTEIRO_PARA_FRACIONADO = 32,
            CORRECAO_NOTA_FISCAL = 33,
            INFO_FATURAMENTO_CENTRO_CIRURGICO = 34,
            BAIXA_FRACIONADA_NAO_FATURADA = 35,
            MOVIMENTACAO_REUTILIZAVEL = 36,
            ESTORNO_MOVIMENTACAO_REUTILIZAVEL = 37,
            ESTORNO_BAIXA_FRACIONADA_NAO_FATURADA = 38,
            TRANSFERENCIA_ENTRADA_PACIENTE = 58,
            TRANSFERENCIA_SAIDA_PACIENTE = 59,
            BAIXA_CONS_DISP_AUTO_PACIENTE = 60,
            ENTRADA_EXTERNA_SEM_NF_NOVO_LOTE = 61,
            ENTRADA_EMPRESTIMO_OBTIDO = 62,
            ENTRADA_EMPRESTIMO_DEVOLVIDO = 63,
            BAIXA_EMPRESTIMO_CONCEDIDO = 64,
            BAIXA_EMPRESTIMO_DEVOLVIDO = 65,
            INFO_ENVIO_FATURAMENTO = 66,
            ENTRADA_RESSUPRIMENTO_ESTOQUE_LOCAL = 67,
            BAIXA_RESSUPRIMENTO_ESTOQUE_LOCAL = 68,
            DEVOLUCAO_SETOR_SEM_PEDIDO = 69,
            DEVOLUCAO_CONSIGNADO_FORNECEDOR = 70
        }

        public enum StatusMovimento
        {
            ABERTO,
            FECHADO
        }

        public enum Empresa
        {
            HAC = 1,
            ACS = 2
        }

        public enum SubTipoMovimentoFaturado
        {
            NAO = 0,
            SIM = 1
        }

        public enum Faturado
        {
            NAO = 0,
            SIM = 1
        }

        public enum GeraFaturamento
        {
            NAO = 0,
            SIM = 1
        }

        /// <summary>
        /// Utiliza o campo FlFinalizado (MTMD_MOV_FL_FINALIZADO)
        /// </summary>
        public enum StatusDivergencia
        {
            EM_DIVERGENCIA = 2,
            RESOLVIDA = 3
        }


        public enum TipoAtendimento
        {
            INTERNACAO = 0,
            AMBULATORIO = 1,
            EXTERNO = 2
        }


        public enum TelaOrigem
        {
            CONSUMO_PACIENTE = 0,
            DISPENSACAO = 1,
            LANCAMENTO_OUTRA_UNIDADE =  2,
            PEDIDO_CARRINHO_EMERGENCIA = 3,
            SOLICITACAO_MATERIAL = 4,
            PEDIDO_PERSONALISADO = 5,
            PEDIDO_PADRAO = 6
        }


        public enum Estornado
        {
            SIM=1,
            NAO=0
        }

		private MVC.DTO.FieldDecimal mtmd_mov_id;
		private MVC.DTO.FieldDecimal cad_lat_id_local_atendimento;
		private MVC.DTO.FieldDecimal cad_uni_id_unidade;
		private MVC.DTO.FieldDecimal cad_set_id;
        private MVC.DTO.FieldString cad_set_ds_setor;
        private MVC.DTO.FieldString cad_lat_ds_local_atendimento;
        private MVC.DTO.FieldString cad_uni_ds_unidade;
		private MVC.DTO.FieldDecimal mtmd_lotest_id;
		private MVC.DTO.FieldDecimal cad_mtmd_id;
		private MVC.DTO.FieldDecimal cad_mtmd_tpmov_id;
		private MVC.DTO.FieldDecimal cad_mtmd_subtp_id;
		private MVC.DTO.FieldDateTime mtmd_mov_data;
		private MVC.DTO.FieldDecimal mtmd_mov_qtde;
		private MVC.DTO.FieldDecimal mtmd_mov_fl_finalizado;
        private MVC.DTO.FieldString cad_mtmd_nomefantasia;
        private MVC.DTO.FieldDecimal cad_mtmd_unidade_venda;
        private MVC.DTO.FieldString cad_mtmd_unid_venda_ds;
        private MVC.DTO.FieldDecimal cad_mtmd_fl_fraciona;
        private MVC.DTO.FieldDecimal mtmd_estloc_qtde;
        private MVC.DTO.FieldDecimal mtmd_estloc_qtde_fracionada;
        private MVC.DTO.FieldDecimal cad_uni_id_unidade_s;
        private MVC.DTO.FieldDecimal cad_lat_id_local_s;
        private MVC.DTO.FieldDecimal cad_set_id_s;
        private MVC.DTO.FieldDecimal cad_mtmd_tpmov_s;
        private MVC.DTO.FieldDecimal cad_mtmd_subtp_s;
        private MVC.DTO.FieldDecimal cad_mtmd_filial_id;
        private MVC.DTO.FieldDecimal mtmd_estloc_qtde_lote;
        private MVC.DTO.FieldString mtm_cd_barra;
        private MVC.DTO.FieldString ds_qtde_fracionado;
        private MVC.DTO.FieldString ds_qtde_consumo;
        private MVC.DTO.FieldDecimal mtmd_req_id;
        private MVC.DTO.FieldDecimal mtmd_mov_fl_faturado;
        private MVC.DTO.FieldDateTime mtmd_dt_ressuprimento;
        private MVC.DTO.FieldDecimal atd_ate_id;
        private MVC.DTO.FieldString atd_ate_tp_paciente;

        // SEGURANÇA
        private MVC.DTO.FieldDecimal seg_usu_id_usuario;
        private MVC.DTO.FieldDecimal mtmd_id_usuario_estorno;
        private MVC.DTO.FieldString ds_usuario;
        private MVC.DTO.FieldString ds_usuario_estorno;

        // COMPLEMENTO
        private MVC.DTO.FieldString mtmd_mov_obs;
        private MVC.DTO.FieldString mtmd_mov_usu_relatado;
        private MVC.DTO.FieldDecimal mtmd_id_tp_ccusto;

        // LISTA MOVIMENTO
        private MVC.DTO.FieldDecimal qtde_entrada;
        private MVC.DTO.FieldDecimal qtde_entrada_outros;
        private MVC.DTO.FieldDecimal qtde_saida;
        private MVC.DTO.FieldDecimal qtde_saida_outros;
        private MVC.DTO.FieldDecimal qtde_acerto;
        private MVC.DTO.FieldString cad_mtmd_subtp_descricao;
        private MVC.DTO.FieldDecimal mtmd_mov_estoque_atual;

        private MVC.DTO.FieldDecimal form_origem;


        private MVC.DTO.FieldString cad_mtmd_codmne;
        private MVC.DTO.FieldString cad_mtmd_unid_compra_ds;
        private MVC.DTO.FieldDecimal valor_unitario;
        private MVC.DTO.FieldDecimal valor_total;
        private MVC.DTO.FieldDateTime mtmd_mov_data_ate;
        private MVC.DTO.FieldString tis_med_cd_tabelamedica;

        private MVC.DTO.FieldDecimal mtmd_mov_fl_estorno;

        private MVC.DTO.FieldDecimal mtmd_tp_fracao_id;
        private MVC.DTO.FieldDecimal mtmd_qtd_convertida;

        private MVC.DTO.FieldString ds_qtde_convertida;

        private MVC.DTO.FieldDateTime mtmd_mov_data_faturamento;
        private MVC.DTO.FieldDecimal mtmd_mov_hora_faturamento;

        private MVC.DTO.FieldDecimal mtmd_mov_tipo_empresa;
        private MVC.DTO.FieldDecimal mtmd_mov_subtipo_faturado;
        private MVC.DTO.FieldDecimal seq_paciente;

        private MVC.DTO.FieldString bnf_mun_cd_ibge;

        private MVC.DTO.FieldDecimal mtmd_id_motivo;

        private MVC.DTO.FieldString mtmd_cod_lote;
        private MVC.DTO.FieldDecimal mtmd_mov_saldo_lote_setor;
        private MVC.DTO.FieldDecimal mtmd_mov_saldo_lote_total;

        // RELATORIOS
        private MVC.DTO.FieldDateTime mtmd_data_ini;
        private MVC.DTO.FieldDateTime mtmd_data_fim;
        
        public MovimentacaoDTO()
        {
            InitializeComponent();
        }
		
        internal void InitializeComponent()
        {
		    this.mtmd_mov_id= new MVC.DTO.FieldDecimal(FieldNames.Idt,Captions.Idt, DbType.Decimal);
		    this.cad_lat_id_local_atendimento= new MVC.DTO.FieldDecimal(FieldNames.IdtLocal,Captions.IdtLocal, DbType.Decimal);
		    this.cad_uni_id_unidade= new MVC.DTO.FieldDecimal(FieldNames.IdtUnidade,Captions.IdtUnidade, DbType.Decimal);
		    this.cad_set_id= new MVC.DTO.FieldDecimal(FieldNames.IdtSetor,Captions.IdtSetor, DbType.Decimal);
            this.cad_lat_ds_local_atendimento = new MVC.DTO.FieldString(FieldNames.DsLocal, Captions.DsLocal);
            this.cad_set_ds_setor = new MVC.DTO.FieldString(FieldNames.DsSetor, Captions.DsSetor);
            this.cad_uni_ds_unidade = new MVC.DTO.FieldString(FieldNames.DsUnidade, Captions.DsUnidade);
		    this.mtmd_lotest_id= new MVC.DTO.FieldDecimal(FieldNames.IdtLote,Captions.IdtLote, DbType.Decimal);
		    this.cad_mtmd_id= new MVC.DTO.FieldDecimal(FieldNames.IdtProduto,Captions.IdtProduto, DbType.Decimal);
		    this.cad_mtmd_tpmov_id= new MVC.DTO.FieldDecimal(FieldNames.IdtTipo,Captions.IdtTipo, DbType.Decimal);
		    this.cad_mtmd_subtp_id= new MVC.DTO.FieldDecimal(FieldNames.IdtSubTipo,Captions.IdtSubTipo, DbType.Decimal);
            this.mtmd_mov_data = new MVC.DTO.FieldDateTime(FieldNames.DataMovimento, Captions.DataMovimento);
            this.mtmd_mov_qtde = new MVC.DTO.FieldDecimal(FieldNames.Qtde, Captions.Qtde, DbType.Decimal);
		    this.mtmd_mov_fl_finalizado= new MVC.DTO.FieldDecimal(FieldNames.FlFinalizado,Captions.FlFinalizado, DbType.Decimal);
            this.cad_mtmd_nomefantasia = new MVC.DTO.FieldString(FieldNames.DsProduto, Captions.DsProduto, 100);
            this.cad_mtmd_unidade_venda = new MVC.DTO.FieldDecimal(FieldNames.UnidadeVenda, Captions.UnidadeVenda, DbType.Decimal);
            this.cad_mtmd_unid_venda_ds = new MVC.DTO.FieldString(FieldNames.DsUnidadeVenda, Captions.DsUnidadeVenda, 100);
            this.cad_mtmd_fl_fraciona = new MVC.DTO.FieldDecimal(FieldNames.FlFracionado, Captions.FlFracionado, DbType.Decimal);
            this.mtmd_estloc_qtde = new MVC.DTO.FieldDecimal(FieldNames.EstoqueLocal, Captions.EstoqueLocal, DbType.Decimal);
            this.mtmd_estloc_qtde_fracionada = new MVC.DTO.FieldDecimal(FieldNames.EstoqueLocalFracionado, Captions.EstoqueLocalFracionado, DbType.Decimal);
            this.cad_uni_id_unidade_s = new MVC.DTO.FieldDecimal(FieldNames.IdtUnidadeBaixa, Captions.IdtUnidadeBaixa, DbType.Decimal);
            this.cad_lat_id_local_s = new MVC.DTO.FieldDecimal(FieldNames.IdtLocalBaixa, Captions.IdtLocalBaixa, DbType.Decimal);
            this.cad_set_id_s = new MVC.DTO.FieldDecimal(FieldNames.IdtSetorBaixa, Captions.IdtSetorBaixa, DbType.Decimal);
            this.cad_mtmd_tpmov_s = new MVC.DTO.FieldDecimal(FieldNames.IdtTipoBaixa, Captions.IdtTipoBaixa, DbType.Decimal);
            this.cad_mtmd_subtp_s = new MVC.DTO.FieldDecimal(FieldNames.IdtSubTipoBaixa, Captions.IdtSubTipoBaixa, DbType.Decimal);
            this.cad_mtmd_filial_id = new MVC.DTO.FieldDecimal(FieldNames.IdtFilial, Captions.IdtFilial, DbType.Decimal);
            this.mtmd_estloc_qtde_lote = new MVC.DTO.FieldDecimal(FieldNames.QtdeLote, Captions.QtdeLote, DbType.Decimal);
            this.mtm_cd_barra = new MVC.DTO.FieldString(FieldNames.CdBarra, Captions.CdBarra, 100);
            this.ds_qtde_fracionado = new MVC.DTO.FieldString(FieldNames.DsQtdeFracionado, Captions.DsQtdeFracionado, 100);
            this.ds_qtde_consumo = new MVC.DTO.FieldString(FieldNames.DsQtdeConsumo, Captions.DsQtdeConsumo, 100);
            this.mtmd_req_id = new MVC.DTO.FieldDecimal(FieldNames.IdtRequisicao, Captions.IdtRequisicao, DbType.Decimal);
            this.mtmd_mov_fl_faturado = new MVC.DTO.FieldDecimal(FieldNames.FlFaturado, Captions.FlFaturado, DbType.Decimal);
            this.mtmd_dt_ressuprimento = new MVC.DTO.FieldDateTime(FieldNames.DataRessupri, Captions.DataRessupri);
            this.atd_ate_id = new MVC.DTO.FieldDecimal(FieldNames.IdtAtendimento, Captions.IdtAtendimento, DbType.Decimal);
            this.atd_ate_tp_paciente = new MVC.DTO.FieldString(FieldNames.TpAtendimento, Captions.TpAtendimento, 100);

            // SEGURANÇA
            this.seg_usu_id_usuario = new MVC.DTO.FieldDecimal(FieldNames.IdtUsuario, Captions.IdtUsuario, DbType.Decimal);
            this.mtmd_id_usuario_estorno = new MVC.DTO.FieldDecimal(FieldNames.IdtUsuarioEstorno, Captions.IdtUsuarioEstorno, DbType.Decimal);
            this.ds_usuario = new MVC.DTO.FieldString(FieldNames.DsUsuario, Captions.DsUsuario, 100);
            this.ds_usuario_estorno = new MVC.DTO.FieldString(FieldNames.DsUsuarioEstorno, Captions.DsUsuarioEstorno, 100);

            // COMPLEMENTO
            this.mtmd_mov_obs = new MVC.DTO.FieldString(FieldNames.Obs, Captions.Obs, 100);
            this.mtmd_mov_usu_relatado = new MVC.DTO.FieldString(FieldNames.UsuarioRelatado, Captions.UsuarioRelatado, 50);
            this.mtmd_id_tp_ccusto = new MVC.DTO.FieldDecimal(FieldNames.IdtLocalEstoque, Captions.IdtLocalEstoque, DbType.Decimal);


            // LISTA MOVIMENTO

            this.qtde_entrada = new MVC.DTO.FieldDecimal(FieldNames.QtdeEntrada, Captions.QtdeEntrada, DbType.Decimal);
            this.qtde_entrada_outros = new MVC.DTO.FieldDecimal(FieldNames.QtdeEntradaOutros, Captions.QtdeEntradaOutros, DbType.Decimal);
            this.qtde_saida = new MVC.DTO.FieldDecimal(FieldNames.QtdeSaida, Captions.QtdeSaida, DbType.Decimal);
            this.qtde_saida_outros = new MVC.DTO.FieldDecimal(FieldNames.QtdeSaidaOutros, Captions.QtdeSaidaOutros, DbType.Decimal);
            this.qtde_acerto = new MVC.DTO.FieldDecimal(FieldNames.QtdeAcerto, Captions.QtdeAcerto, DbType.Decimal);
            this.cad_mtmd_subtp_descricao = new MVC.DTO.FieldString(FieldNames.DsSubtipoMov, Captions.DsSubtipoMov, 100);
            this.mtmd_mov_estoque_atual = new MVC.DTO.FieldDecimal(FieldNames.SaldoMovimento, Captions.SaldoMovimento, DbType.Decimal);

            this.form_origem = new MVC.DTO.FieldDecimal(FieldNames.FormOrigem, Captions.FormOrigem, DbType.Decimal);                      


            this.cad_mtmd_codmne = new MVC.DTO.FieldString(FieldNames.CodProdutoMNE, Captions.CodProdutoMNE, 10);
            this.cad_mtmd_unid_compra_ds = new MVC.DTO.FieldString(FieldNames.DsUnidadeCompra, Captions.DsUnidadeCompra, 100);
            this.valor_unitario = new MVC.DTO.FieldDecimal(FieldNames.ValorUnitario, Captions.ValorUnitario, DbType.Decimal);
            this.valor_total = new MVC.DTO.FieldDecimal(FieldNames.ValorTotal, Captions.ValorTotal, DbType.Decimal);
            this.mtmd_mov_data_ate = new MVC.DTO.FieldDateTime(FieldNames.DataAte, Captions.DataAte);
            this.tis_med_cd_tabelamedica = new MVC.DTO.FieldString(FieldNames.Tabelamedica, Captions.Tabelamedica, 2);

            this.mtmd_mov_fl_estorno = new MVC.DTO.FieldDecimal(FieldNames.FlEstornado, Captions.FlEstornado, DbType.Decimal);

            this.mtmd_tp_fracao_id = new MVC.DTO.FieldDecimal(FieldNames.TpFracao, Captions.TpFracao, DbType.Decimal);
            this.mtmd_qtd_convertida = new MVC.DTO.FieldDecimal(FieldNames.QtdConvertida, Captions.QtdConvertida, DbType.Decimal);

            this.ds_qtde_convertida = new MVC.DTO.FieldString(FieldNames.DsQtdConvertida, Captions.DsQtdConvertida, 100);
            this.mtmd_mov_data_faturamento = new MVC.DTO.FieldDateTime(FieldNames.DtFaturamento, Captions.DtFaturamento);
            this.mtmd_mov_hora_faturamento = new MVC.DTO.FieldDecimal(FieldNames.HrFaturamento, Captions.HrFaturamento, DbType.Decimal);
            this.mtmd_mov_tipo_empresa = new MVC.DTO.FieldDecimal(FieldNames.TipoEmpresa, Captions.TipoEmpresa, DbType.Decimal);
            this.mtmd_mov_subtipo_faturado = new MVC.DTO.FieldDecimal(FieldNames.SubTipoMovFaturado, Captions.SubTipoMovFaturado, DbType.Decimal);

            this.seq_paciente = new MVC.DTO.FieldDecimal(FieldNames.SequenciaConsumoFaturamento, Captions.SequenciaConsumoFaturamento, DbType.Decimal);
            this.ds_qtde_convertida = new MVC.DTO.FieldString(FieldNames.DsQtdConvertida, Captions.DsQtdConvertida, 100);
            this.bnf_mun_cd_ibge = new MVC.DTO.FieldString(FieldNames.CodigoIBGEMunicipioHomeCare, Captions.CodigoIBGEMunicipioHomeCare, 7);
            
            this.mtmd_id_motivo = new MVC.DTO.FieldDecimal(FieldNames.idtMotivo, Captions.idtMotivo, DbType.Decimal);

            this.mtmd_cod_lote = new MVC.DTO.FieldString(FieldNames.CodLote, Captions.CodLote);
            this.mtmd_mov_saldo_lote_setor = new MVC.DTO.FieldDecimal(FieldNames.SaldoLoteSetor, Captions.SaldoLoteSetor, DbType.Decimal);
            this.mtmd_mov_saldo_lote_total = new MVC.DTO.FieldDecimal(FieldNames.SaldoLoteTotal, Captions.SaldoLoteTotal, DbType.Decimal);

            // RELATORIO
            this.mtmd_data_ini = new MVC.DTO.FieldDateTime(FieldNames.DtIni, Captions.DtIni);
            this.mtmd_data_fim = new MVC.DTO.FieldDateTime(FieldNames.DtFim, Captions.DtFim);

        }
 
        #region FieldNames

        public struct FieldNames
        {            
			public const string Idt="MTMD_MOV_ID";
		    public const string IdtLocal="CAD_LAT_ID_LOCAL_ATENDIMENTO";
		    public const string IdtUnidade="CAD_UNI_ID_UNIDADE";
		    public const string IdtSetor="CAD_SET_ID";
            public const string DsSetor = "CAD_SET_DS_SETOR";
            public const string DsUnidade = "CAD_UNI_DS_UNIDADE";
            public const string DsLocal = "CAD_LAT_DS_LOCAL_ATENDIMENTO";
		    public const string IdtLote="MTMD_LOTEST_ID";
		    public const string IdtProduto="CAD_MTMD_ID";
		    public const string IdtTipo="CAD_MTMD_TPMOV_ID";
		    public const string IdtSubTipo="CAD_MTMD_SUBTP_ID";
            public const string DataMovimento = "MTMD_MOV_DATA";
            public const string Qtde = "MTMD_MOV_QTDE";
		    public const string FlFinalizado="MTMD_MOV_FL_FINALIZADO";
            public const string DsProduto = "CAD_MTMD_NOMEFANTASIA";
            public const string UnidadeVenda = "CAD_MTMD_UNIDADE_VENDA";
            public const string DsUnidadeVenda = "CAD_MTMD_UNID_VENDA_DS";
            public const string FlFracionado = "CAD_MTMD_FL_FRACIONA";
            public const string EstoqueLocal = "MTMD_ESTLOC_QTDE";
            public const string EstoqueLocalFracionado = "MTMD_ESTLOC_QTDE_FRACIONADA";
            public const string IdtUnidadeBaixa = "CAD_UNI_ID_UNIDADE_S";
            public const string IdtLocalBaixa = "CAD_LAT_ID_LOCAL_S";
            public const string IdtSetorBaixa = "CAD_SET_ID_S";
            public const string IdtTipoBaixa = "CAD_MTMD_TPMOV_S";
            public const string IdtSubTipoBaixa = "CAD_MTMD_SUBTP_S";
            public const string IdtFilial = "CAD_MTMD_FILIAL_ID";
            public const string QtdeLote = "MTMD_ESTLOC_QTDE_LOTE";
            public const string CdBarra = "MTM_CD_BARRA";
            public const string DsQtdeFracionado = "DS_QTDE";
            public const string DsQtdeConsumo = "DS_QTDE_CONSUMO";
            public const string IdtRequisicao = "MTMD_REQ_ID";
            public const string FlFaturado = "MTMD_MOV_FL_FATURADO";
            public const string DataRessupri = "MTMD_DT_RESSUPRIMENTO";
            public const string IdtAtendimento = "ATD_ATE_ID";
            public const string TpAtendimento = "ATD_ATE_TP_PACIENTE";

            // SEGURANÇA
            public const string IdtUsuario = "SEG_USU_ID_USUARIO";
            public const string IdtUsuarioEstorno = "MTMD_ID_USUARIO_ESTORNO";
            public const string DsUsuario = "DS_USUARIO";
            public const string DsUsuarioEstorno = "DS_USUARIO_ESTORNO";

            // COMPLEMENTO
            public const string Obs = "MTMD_MOV_OBS";
            public const string UsuarioRelatado = "MTMD_MOV_USU_RELATADO";
            public const string IdtLocalEstoque = "MTMD_ID_TP_CCUSTO";

            // LISTA MOVIMENTO
            public const string QtdeEntrada = "QTDE_ENTRADA";
            public const string QtdeEntradaOutros = "QTDE_ENTRADA_OUTROS";
            public const string QtdeSaida = "QTDE_SAIDA";
            public const string QtdeSaidaOutros = "QTDE_SAIDA_OUTROS";
            public const string QtdeAcerto = "QTDE_ACERTO";
            public const string DsSubtipoMov = "CAD_MTMD_SUBTP_DESCRICAO";

            public const string SaldoMovimento = "MTMD_MOV_ESTOQUE_ATUAL";

            public const string FormOrigem = "FORM_ORIGEM";
            
            public const string CodProdutoMNE = "CAD_MTMD_CODMNE";
            public const string DsUnidadeCompra = "CAD_MTMD_UNID_COMPRA_DS";
            public const string ValorUnitario = "VALOR_UNITARIO";
            public const string ValorTotal = "VALOR_TOTAL";
            public const string DataAte = "MTMD_MOV_DATA_ATE";
            public const string Tabelamedica = "TIS_MED_CD_TABELAMEDICA";

            public const string FlEstornado = "MTMD_MOV_FL_ESTORNO";

            public const string TpFracao = "MTMD_TP_FRACAO_ID";
            public const string QtdConvertida = "MTMD_QTD_CONVERTIDA";

            public const string DsQtdConvertida = "DS_QTDE_CONVERTIDA";

            public const string DtFaturamento = "MTMD_MOV_DATA_FATURAMENTO";
            public const string HrFaturamento = "MTMD_MOV_HORA_FATURAMENTO";
            public const string TipoEmpresa = "TIPO_EMPRESA";
            public const string SubTipoMovFaturado = "CAD_MTMD_FL_FATURA";
            public const string SequenciaConsumoFaturamento = "SEQ_PACIENTE";
            public const string CodigoIBGEMunicipioHomeCare = "BNF_MUN_CD_IBGE";

            public const string idtMotivo = "MTMD_ID_MOTIVO";

            public const string CodLote = "MTMD_COD_LOTE";
            public const string SaldoLoteSetor = "MTMD_MOV_SALDO_LOTE_SETOR";
            public const string SaldoLoteTotal = "MTMD_MOV_SALDO_LOTE_TOTAL";

            //RELATORIO
            public const string DtIni = "MTMD_DATA_INI";
            public const string DtFim = "MTMD_DATA_FIM";
                        
        }		

        #endregion

        #region Captions

        public struct Captions
        {
			public const string Idt="IDT";
		    public const string IdtLocal="IDTLOCAL";
		    public const string IdtUnidade="IDTUNIDADE";
		    public const string IdtSetor="IDTSETOR";
            public const string DsUnidade = "DSUNIDADE";
            public const string DsSetor = "DSSETOR";
            public const string DsLocal = "DSLOCAL";
		    public const string IdtLote="IDTLOTE";
		    public const string IdtProduto="IDTPRODUTO";
		    public const string IdtTipo="IDTTIPO";
		    public const string IdtSubTipo="IDTSUBTIPO";
            public const string DataMovimento = "DATAMOVIMENTO";
		    public const string Qtde="QTDE";
		    public const string FlFinalizado="FLFINALIZADO";
            public const string DsProduto = "DSPRODUTO";
            public const string UnidadeVenda = "UNIDADEVENDA";
            public const string DsUnidadeVenda = "CADMTMDUNIDVENDADS";
            public const string FlFracionado = "CADMTMDFLFRACIONA";
            public const string EstoqueLocal = "ESTOQUELOCAL";
            public const string EstoqueLocalFracionado = "ESTOQUELOCALFRACIONADO";
            public const string IdtUnidadeBaixa = "IDTUNIDADEBAIXA";
            public const string IdtLocalBaixa = "IDTLOCALBAIXA";
            public const string IdtSetorBaixa = "IDTSETORBAIXA";
            public const string IdtTipoBaixa = "IDTTIPOBAIXA";
            public const string IdtSubTipoBaixa = "IDTSUBTIPOBAIXA";
            public const string IdtFilial = "IDTFILIAL";
            public const string QtdeLote = "QTDELOTE";
            public const string CdBarra = "CDBARRA";
            public const string DsQtdeFracionado = "DSQTDEFRACIONADO";
            public const string DsQtdeConsumo = "DSQTDECONSUMO";
            public const string IdtRequisicao = "IDTREQUISICAO";
            public const string FlFaturado = "MTMDMOVFLFATURADO";
            public const string DataRessupri = "DATADISPENSADO";
            public const string IdtAtendimento = "IDTATENDIMENTO";
            public const string TpAtendimento = "TPATENDIMENTO";

            // SEGURANÇA
            public const string IdtUsuario = "IDTUSUARIO";
            public const string IdtUsuarioEstorno = "USUARIO_ESTORNO";
            public const string DsUsuario = "DS_USUARIO";
            public const string DsUsuarioEstorno = "DS_USUARIO_ESTORNO";

            // COMPLEMENTO
            public const string Obs = "OBS";
            public const string UsuarioRelatado = "USUARIORELATADO";
            public const string IdtLocalEstoque = "IDTCCUSTO";		


            //LISTA MOVIMENTO
            public const string QtdeEntrada = "QTDEENTRADA";
            public const string QtdeEntradaOutros = "QTDEENTRADAOUTROS";
            public const string QtdeSaida = "QTDESAIDA";
            public const string QtdeSaidaOutros = "QTDESAIDAOUTROS";
            public const string QtdeAcerto = "QTDEACERTO";
            public const string DsSubtipoMov = "DSSUBTIPOMOV";

            public const string SaldoMovimento = "SALDOMOVIMENTO";

            public const string FormOrigem = "FORMORIGEM";

            public const string CodProdutoMNE = "CAD_MTMD_CODMNE";
            public const string DsUnidadeCompra = "CAD_MTMD_UNID_COMPRA_DS";
            public const string ValorUnitario = "VALOR_UNITARIO";
            public const string ValorTotal = "VALOR_TOTAL";
            public const string DataAte = "MTMD_MOV_DATA_ATE";
            public const string Tabelamedica = "TABELAMEDICA";

            public const string FlEstornado = "FlEstornado";

            public const string TpFracao = "MTMD_TP_FRACAO_ID";
            public const string QtdConvertida = "MTMD_QTD_CONVERTIDA";

            public const string DsQtdConvertida = "DSQTDCONVERTIDA";

            public const string DtFaturamento = "DTFATURAMENTO";

            public const string HrFaturamento = "HRFATURAMENTO";
            public const string TipoEmpresa = "TIPOEMPRESA";
            public const string SubTipoMovFaturado = "CADMTMDFLFATURA";
            public const string SequenciaConsumoFaturamento = "SEQPACIENTE";
            public const string CodigoIBGEMunicipioHomeCare = "BNFMUNCDIBGE";

            public const string idtMotivo = "IDTMOTIVO";

            public const string CodLote = "CODLOTE";
            public const string SaldoLoteSetor = "MOVSALDOLOTESETOR";
            public const string SaldoLoteTotal = "MOVSALDOLOTETOTAL";

            public const string DtIni = "DTINI";
            public const string DtFim = "DTFIM";

        }		

        #endregion
		
        #region Atributos Publicos
		
		public MVC.DTO.FieldDecimal Idt
		{
			get { return mtmd_mov_id; }
			set { mtmd_mov_id = value; }
		}
			
		public MVC.DTO.FieldDecimal IdtLote
		{
			get { return mtmd_lotest_id; }
			set { mtmd_lotest_id = value; }
		}
		
		public MVC.DTO.FieldDecimal IdtProduto
		{
			get { return cad_mtmd_id; }
			set { cad_mtmd_id = value; }
		}

        /// <summary>
        /// Id do Local, na movimentação de transferência refere-se ao Local de Entrada
        /// </summary>
        public MVC.DTO.FieldDecimal IdtLocal
        {
            get { return cad_lat_id_local_atendimento; }
            set { cad_lat_id_local_atendimento = value; }
        }

        /// <summary>
        /// Id da Unidade, na Movimentação de Tranferência refere-se a unidade de Entrada
        /// </summary>
        public MVC.DTO.FieldDecimal IdtUnidade
        {
            get { return cad_uni_id_unidade; }
            set { cad_uni_id_unidade = value; }
        }

        /// <summary>
        /// Id do Setor, na Movimentação de tranferência refere-se ao Setor de Entrada
        /// </summary>
        public MVC.DTO.FieldDecimal IdtSetor
        {
            get { return cad_set_id; }
            set { cad_set_id = value; }
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

        /// <summary>
        /// Tipo de Movimentação ( Entrada/Saida ), no Movimento de Tranferência refere-se ao Tipo Entrada
        /// </summary>
		public MVC.DTO.FieldDecimal IdtTipo
		{
			get { return cad_mtmd_tpmov_id; }
			set { cad_mtmd_tpmov_id = value; }
		}
		
        /// <summary>
        /// Sub-Tipo Movimentação, no Movimento de Transferência refere-se ao Sub-Tipo de Entrada
        /// </summary>
		public MVC.DTO.FieldDecimal IdtSubTipo
		{
			get { return cad_mtmd_subtp_id; }
			set { cad_mtmd_subtp_id = value; }
		}

        public MVC.DTO.FieldDateTime DataMovimento
		{
			get { return mtmd_mov_data; }
			set { mtmd_mov_data = value; }
		}
		
        /// <summary>
        /// Quantidade Movimentada
        /// </summary>
		public MVC.DTO.FieldDecimal Qtde
		{
            get { return mtmd_mov_qtde; }
            set { mtmd_mov_qtde = value; }
		}
		
        /// <summary>
        /// Flag do Status do Movimento
        /// </summary>
		public MVC.DTO.FieldDecimal FlFinalizado
		{
			get { return mtmd_mov_fl_finalizado; }
			set { mtmd_mov_fl_finalizado = value; }
		}		

        /// <summary>
        /// Descrição do Produto que originou a movimentação
        /// </summary>
        public MVC.DTO.FieldString DsProduto
        {
            get { return cad_mtmd_nomefantasia; }
            set { cad_mtmd_nomefantasia = value; }
        }

        public MVC.DTO.FieldDecimal UnidadeVenda
        {
            get { return cad_mtmd_unidade_venda; }
            set { cad_mtmd_unidade_venda = value; }
        }

        /// <summary>
        /// Saldo do produto na unidade
        /// </summary>
        public MVC.DTO.FieldDecimal EstoqueLocal
        {
            get { return mtmd_estloc_qtde; }
            set { mtmd_estloc_qtde = value; }
        }

        /// <summary>
        /// Quantidade fracionada do Produto no estoque da unidade
        /// </summary>
        public MVC.DTO.FieldDecimal EstoqueLocalFracionado
        {
            get { return mtmd_estloc_qtde_fracionada; }
            set { mtmd_estloc_qtde_fracionada = value; }
        }

        /// <summary>
        /// Id da Unidade de Baixa, só é utilizado em movimentação de transferência entre dois setores
        /// </summary>
        public MVC.DTO.FieldDecimal IdtUnidadeBaixa
        {
            get { return cad_uni_id_unidade_s; }
            set { cad_uni_id_unidade_s = value; }
        }

        /// <summary>
        /// Id do Local de Baixa, só é utilizado em movimentação de transferência entre dois setores
        /// </summary>
        public MVC.DTO.FieldDecimal IdtLocalBaixa
        {
            get { return cad_lat_id_local_s; }
            set { cad_lat_id_local_s = value; }
        }

        /// <summary>
        /// Id do Setore de Baixa, só é utilizado em movimentação de transferência entre dois setores
        /// </summary>
        public MVC.DTO.FieldDecimal IdtSetorBaixa
        {
            get { return cad_set_id_s; }
            set { cad_set_id_s = value; }
        }

        /// <summary>
        /// Id do Tipo sempre deve ser Baixa, só é utilizado em movimentação de transferência entre dois setores
        /// </summary>
        public MVC.DTO.FieldDecimal IdtTipoBaixa
        {
            get { return cad_mtmd_tpmov_s; }
            set { cad_mtmd_tpmov_s = value; }
        }

        /// <summary>
        /// Id do Sub-Tipo da Baixa, só é utilizado em movimentação de transferência entre dois setores
        /// </summary>
        public MVC.DTO.FieldDecimal IdtSubTipoBaixa
        {
            get { return cad_mtmd_subtp_s; }
            set { cad_mtmd_subtp_s = value; }
        }

        /// <summary>
        /// Identificação do Estoque
        /// </summary>
        public MVC.DTO.FieldDecimal IdtFilial
        {
            get { return cad_mtmd_filial_id; }
            set { cad_mtmd_filial_id = value; }
        }

        public MVC.DTO.FieldDecimal QtdeLote
        {
            get { return mtmd_estloc_qtde_lote; }
            set { mtmd_estloc_qtde_lote = value; }
        }

        public MVC.DTO.FieldString CdBarra
        {
            get { return mtm_cd_barra; }
            set { mtm_cd_barra = value; }
        }

        /// <summary>
        /// quantidade consumida no momento
        /// </summary>
        public MVC.DTO.FieldString DsQtdeConsumo
        {
            get { return ds_qtde_consumo; }
            set { ds_qtde_consumo = value; }
        }

        /// <summary>
        /// quantidade total consumida + Descrição da unidade de venda  
        /// </summary>
        public MVC.DTO.FieldString DsQtdeFracionado
        {
            get { return ds_qtde_fracionado; }
            set { ds_qtde_fracionado = value; }
        }

        /// <summary>
        /// Número da requisição que gerou a movimentação, no caso de dispensação
        /// </summary>
        public MVC.DTO.FieldDecimal IdtRequisicao
        {
            get { return mtmd_req_id; }
            set { mtmd_req_id = value; }
        }

        public MVC.DTO.FieldDecimal IdtAtendimento
        {
            get { return atd_ate_id; }
            set { atd_ate_id = value; }
        }

        /// <summary>
        /// Tipo do Atendimento ( Internação/Ambulatorial )
        /// </summary>
        public MVC.DTO.FieldString TpAtendimento
        {
            get { return atd_ate_tp_paciente; }
            set { atd_ate_tp_paciente = value; }
        }

        //SEGURANÇA
        /// <summary>
        /// Id do Usuário Logado no sistema
        /// </summary>
        public MVC.DTO.FieldDecimal IdtUsuario
        {
            get { return seg_usu_id_usuario; }
            set { seg_usu_id_usuario = value; }
        }

        public MVC.DTO.FieldDecimal IdtUsuarioEstorno
        {
            get { return mtmd_id_usuario_estorno; }
            set { mtmd_id_usuario_estorno = value; }
        }

        public MVC.DTO.FieldString DsUsuario
        {
            get { return ds_usuario; }
            set { ds_usuario = value; }
        }

        public MVC.DTO.FieldString DsUsuarioEstorno
        {
            get { return ds_usuario_estorno; }
            set { ds_usuario_estorno = value; }
        }

        //COMPLEMENTO
        /// <summary>
        /// Observação da Movimentação ( complemento )
        /// </summary>
        public MVC.DTO.FieldString Obs
        {
            get { return mtmd_mov_obs; }
            set { mtmd_mov_obs = value; }
        }

        /// <summary>
        /// Usuário relacionado com o complemento da observação, normalmente usado para registro de perda ( complemento )
        /// </summary>
        public MVC.DTO.FieldString UsuarioRelatado
        {
            get { return mtmd_mov_usu_relatado; }
            set { mtmd_mov_usu_relatado = value; }
        }

        public MVC.DTO.FieldString DsUnidadeVenda
        {
            get { return cad_mtmd_unid_venda_ds; }
            set { cad_mtmd_unid_venda_ds = value; }
        }

        public MVC.DTO.FieldDecimal FlFracionado
        {
            get { return cad_mtmd_fl_fraciona; }
            set { cad_mtmd_fl_fraciona = value; }
        }

        public MVC.DTO.FieldDecimal FlFaturado
        {
            get { return mtmd_mov_fl_faturado; }
            set { mtmd_mov_fl_faturado = value; }
        }

        public MVC.DTO.FieldDecimal IdtLocalEstoque
        {
            get { return mtmd_id_tp_ccusto; }
            set { mtmd_id_tp_ccusto = value; }
        }

        /// <summary>
        /// Data do último ressuprimento do produto na unidade
        /// </summary>
        public MVC.DTO.FieldDateTime DataRessupri
        {
            get { return mtmd_dt_ressuprimento; }
            set { mtmd_dt_ressuprimento = value; }
        }

        public MVC.DTO.FieldDecimal QtdeEntrada
        {
            get { return qtde_entrada; }
            set { qtde_entrada = value; }
        }

        public MVC.DTO.FieldDecimal QtdeEntradaOutros
        {
            get { return qtde_entrada_outros; }
            set { qtde_entrada_outros = value; }
        }

        public MVC.DTO.FieldDecimal QtdeSaida
        {
            get { return qtde_saida; }
            set { qtde_saida = value; }
        }

        public MVC.DTO.FieldDecimal QtdeSaidaOutros
        {
            get { return qtde_saida_outros; }
            set { qtde_saida_outros = value; }
        }

        public MVC.DTO.FieldDecimal QtdeAcerto
        {
            get { return qtde_acerto; }
            set { qtde_acerto = value; }
        }

        public MVC.DTO.FieldString DsSubtipoMov
        {
            get { return cad_mtmd_subtp_descricao; }
            set { cad_mtmd_subtp_descricao = value; }
        }

        public MVC.DTO.FieldDecimal SaldoMovimento
        {
            get { return mtmd_mov_estoque_atual; }
            set { mtmd_mov_estoque_atual = value; }
        }

        /// <summary>
        /// Informa a origem do Form que está chamando a tela auxiliar
        /// </summary>
        public MVC.DTO.FieldDecimal FormOrigem
        {
            get { return form_origem; }
            set { form_origem = value; }
        }
               
        public MVC.DTO.FieldString CodProdutoMNE
        {
            get { return cad_mtmd_codmne; }
            set { cad_mtmd_codmne = value; }
        }

        public MVC.DTO.FieldString DsUnidadeCompra
        {
            get { return cad_mtmd_unid_compra_ds; }
            set { cad_mtmd_unid_compra_ds = value; }
        }

        public MVC.DTO.FieldDecimal ValorUnitario
        {
            get { return valor_unitario; }
            set { valor_unitario = value; }
        }

        public MVC.DTO.FieldDecimal ValorTotal
        {
            get { return valor_total; }
            set { valor_total = value; }
        }

        public MVC.DTO.FieldDateTime DataAte
        {
            get { return mtmd_mov_data_ate; }
            set { mtmd_mov_data_ate = value; }
        }

        public MVC.DTO.FieldString Tabelamedica
        {
            get { return tis_med_cd_tabelamedica; }
            set { tis_med_cd_tabelamedica = value; }
        }

        public MVC.DTO.FieldDecimal FlEstornado
        {
            get { return mtmd_mov_fl_estorno; }
            set { mtmd_mov_fl_estorno = value; }
        }


        public MVC.DTO.FieldDecimal TpFracao
        {
            get { return mtmd_tp_fracao_id; }
            set { mtmd_tp_fracao_id = value; }
        }

        public MVC.DTO.FieldDecimal QtdConvertida
        {
            get { return mtmd_qtd_convertida; }
            set { mtmd_qtd_convertida = value; }
        }

        public MVC.DTO.FieldString DsQtdConvertida
        {
            get { return ds_qtde_convertida; }
            set { ds_qtde_convertida = value; }
        }

        public MVC.DTO.FieldDateTime DtFaturamento
        {
            get { return mtmd_mov_data_faturamento; }
            set { mtmd_mov_data_faturamento = value; }
        }

        public MVC.DTO.FieldDecimal HrFaturamento
        {
            get { return mtmd_mov_hora_faturamento; }
            set { mtmd_mov_hora_faturamento = value; }
        }

        public MVC.DTO.FieldDecimal TipoEmpresa
        {
            get { return mtmd_mov_tipo_empresa; }
            set { mtmd_mov_tipo_empresa = value; }
        }

        public MVC.DTO.FieldDecimal SubTipoMovFaturado
        {
            get { return mtmd_mov_subtipo_faturado; }
            set { mtmd_mov_subtipo_faturado = value; }
        }

        public MVC.DTO.FieldDecimal SequenciaConsumoFaturamento
        {
            get { return seq_paciente; }
            set { seq_paciente = value; }
        }

        public MVC.DTO.FieldString CodigoIBGEMunicipioHomeCare
        {
            get { return bnf_mun_cd_ibge; }
            set { bnf_mun_cd_ibge = value; }
        }

        public MVC.DTO.FieldDecimal idtMotivo
        {
            get { return mtmd_id_motivo; }
            set { mtmd_id_motivo = value; }
        }

        public MVC.DTO.FieldString CodLote
        {
            get { return mtmd_cod_lote; }
            set { mtmd_cod_lote = value; }
        }

        public MVC.DTO.FieldDecimal SaldoLoteSetor
        {
            get { return mtmd_mov_saldo_lote_setor; }
            set { mtmd_mov_saldo_lote_setor = value; }
        }

        public MVC.DTO.FieldDecimal SaldoLoteTotal
        {
            get { return mtmd_mov_saldo_lote_total; }
            set { mtmd_mov_saldo_lote_total = value; }
        }

        public MVC.DTO.FieldDateTime DtIni
        {
            get { return mtmd_data_ini; }
            set { mtmd_data_ini = value; }
        }

        public MVC.DTO.FieldDateTime DtFim
        {
            get { return mtmd_data_fim; }
            set { mtmd_data_fim = value; }
        }

		#endregion

        #region Operators

        public static explicit operator MovimentacaoDTO(DataRow row)
        {
            MovimentacaoDTO  dto = new MovimentacaoDTO();
			
			dto.Idt.Value = row[FieldNames.Idt].ToString();
		
			dto.IdtLocal.Value = row[FieldNames.IdtLocal].ToString();
		
			dto.IdtUnidade.Value = row[FieldNames.IdtUnidade].ToString();
		
			dto.IdtSetor.Value = row[FieldNames.IdtSetor].ToString();

            dto.DsLocal.Value = row[FieldNames.DsLocal].ToString();

            dto.DsSetor.Value = row[FieldNames.DsSetor].ToString();

            dto.DsUnidade.Value = row[FieldNames.DsUnidade].ToString();
		
			dto.IdtLote.Value = row[FieldNames.IdtLote].ToString();
		
			dto.IdtProduto.Value = row[FieldNames.IdtProduto].ToString();
		
			dto.IdtTipo.Value = row[FieldNames.IdtTipo].ToString();
		
			dto.IdtSubTipo.Value = row[FieldNames.IdtSubTipo].ToString();

            dto.DataMovimento.Value = row[FieldNames.DataMovimento].ToString();
		
			dto.Qtde.Value = row[FieldNames.Qtde].ToString();
		
			dto.FlFinalizado.Value = row[FieldNames.FlFinalizado].ToString();
		
            dto.DsProduto.Value = row[FieldNames.DsProduto].ToString();            

            dto.UnidadeVenda.Value = row[FieldNames.UnidadeVenda].ToString();

            dto.DsUnidadeVenda.Value = row[FieldNames.DsUnidadeVenda].ToString();

            dto.FlFracionado.Value = row[FieldNames.FlFracionado].ToString();

            dto.EstoqueLocal.Value = row[FieldNames.EstoqueLocal].ToString();

            dto.EstoqueLocalFracionado.Value = row[FieldNames.EstoqueLocalFracionado].ToString();

            dto.IdtUnidadeBaixa.Value = row[FieldNames.IdtUnidadeBaixa].ToString();

            dto.IdtLocalBaixa.Value = row[FieldNames.IdtLocalBaixa].ToString();

            dto.IdtSetorBaixa.Value = row[FieldNames.IdtSetorBaixa].ToString();

            dto.IdtTipoBaixa.Value = row[FieldNames.IdtTipoBaixa].ToString();

            dto.IdtSubTipoBaixa.Value = row[FieldNames.IdtSubTipoBaixa].ToString();

            dto.IdtFilial.Value = row[FieldNames.IdtFilial].ToString();

            dto.QtdeLote.Value = row[FieldNames.QtdeLote].ToString();

            dto.CdBarra.Value = row[FieldNames.CdBarra].ToString();

            dto.DsQtdeFracionado.Value = row[FieldNames.DsQtdeFracionado].ToString();
            
            dto.DsQtdeConsumo.Value = row[FieldNames.DsQtdeConsumo].ToString();

            dto.IdtRequisicao.Value = row[FieldNames.IdtRequisicao].ToString();

            dto.IdtAtendimento.Value = row[FieldNames.IdtAtendimento].ToString();

            dto.TpAtendimento.Value = row[FieldNames.TpAtendimento].ToString();

            dto.DataRessupri.Value = row[FieldNames.DataRessupri].ToString();

            // SEGURANÇA
            dto.IdtUsuario.Value = row[FieldNames.IdtUsuario].ToString();
            dto.IdtUsuarioEstorno.Value = row[FieldNames.IdtUsuarioEstorno].ToString();
            dto.DsUsuario.Value = row[FieldNames.DsUsuario].ToString();
            dto.DsUsuarioEstorno.Value = row[FieldNames.DsUsuarioEstorno].ToString();

            // COMPLEMENTO
            dto.Obs.Value = row[FieldNames.Obs].ToString();

            dto.UsuarioRelatado.Value = row[FieldNames.UsuarioRelatado].ToString();

            dto.FlFaturado.Value = row[FieldNames.FlFaturado].ToString();

            dto.IdtLocalEstoque.Value = row[FieldNames.IdtLocalEstoque].ToString();

            //LISTA MOVIMENTO
            dto.QtdeEntrada.Value = row[FieldNames.QtdeEntrada].ToString();
            dto.QtdeEntradaOutros.Value = row[FieldNames.QtdeEntradaOutros].ToString();
            dto.QtdeSaida.Value = row[FieldNames.QtdeSaida].ToString();
            dto.QtdeSaidaOutros.Value = row[FieldNames.QtdeSaidaOutros].ToString();
            dto.QtdeAcerto.Value = row[FieldNames.QtdeAcerto].ToString();
            dto.DsSubtipoMov.Value = row[FieldNames.DsSubtipoMov].ToString();

            dto.SaldoMovimento.Value = row[FieldNames.SaldoMovimento].ToString();


            dto.FormOrigem.Value = row[FieldNames.FormOrigem].ToString();

            dto.CodProdutoMNE.Value = row[FieldNames.CodProdutoMNE].ToString();
            dto.DsUnidadeCompra.Value = row[FieldNames.DsUnidadeCompra].ToString();
            dto.ValorUnitario.Value = row[FieldNames.ValorUnitario].ToString();
            dto.ValorTotal.Value = row[FieldNames.ValorTotal].ToString();
            dto.DataAte.Value = row[FieldNames.DataAte].ToString();
            dto.Tabelamedica.Value = row[FieldNames.Tabelamedica].ToString();

            dto.FlEstornado.Value = row[FieldNames.FlEstornado].ToString();

            dto.TpFracao.Value = row[FieldNames.TpFracao].ToString();
            dto.QtdConvertida.Value = row[FieldNames.QtdConvertida].ToString();

            dto.DsQtdConvertida.Value = row[FieldNames.DsQtdConvertida].ToString();

            dto.DtFaturamento.Value = row[FieldNames.DtFaturamento].ToString();
            dto.HrFaturamento.Value = row[FieldNames.HrFaturamento].ToString();

            dto.TipoEmpresa.Value = row[FieldNames.TipoEmpresa].ToString();
            dto.SubTipoMovFaturado.Value = row[FieldNames.SubTipoMovFaturado].ToString();
            dto.SequenciaConsumoFaturamento.Value = row[FieldNames.SequenciaConsumoFaturamento].ToString();
            dto.CodigoIBGEMunicipioHomeCare.Value = row[FieldNames.CodigoIBGEMunicipioHomeCare].ToString();

            dto.idtMotivo.Value = row[FieldNames.idtMotivo].ToString();

            try
            {
                dto.CodLote.Value = row[FieldNames.CodLote].ToString();
                dto.SaldoLoteSetor.Value = row[FieldNames.SaldoLoteSetor].ToString();
                dto.SaldoLoteTotal.Value = row[FieldNames.SaldoLoteTotal].ToString();            
            }
            catch
            {
                //deixa passar se não tiver coluna
            }            

            // RELATORIOS

            dto.DtIni.Value = row[FieldNames.DtIni].ToString();
            dto.DtFim.Value = row[FieldNames.DtFim].ToString();

            return dto;
        }

        public static explicit operator MovimentacaoDTO(XmlDocument xml)
        {
            MovimentacaoDTO dto = new MovimentacaoDTO();
			
			if (xml.FirstChild.SelectSingleNode(FieldNames.Idt) != null) dto.Idt.Value = xml.FirstChild.SelectSingleNode(FieldNames.Idt).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal) != null) dto.IdtLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocal).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade) != null) dto.IdtUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidade).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor) != null) dto.IdtSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetor).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsLocal) != null) dto.DsLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsLocal).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsSetor) != null) dto.DsSetor.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsSetor).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade) != null) dto.DsUnidade.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidade).InnerText;
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLote) != null) dto.IdtLote.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLote).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto) != null) dto.IdtProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtProduto).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtTipo) != null) dto.IdtTipo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtTipo).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSubTipo) != null) dto.IdtSubTipo.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSubTipo).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DataMovimento) != null) dto.DataMovimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataMovimento).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.Qtde) != null) dto.Qtde.Value = xml.FirstChild.SelectSingleNode(FieldNames.Qtde).InnerText;			
		
			if (xml.FirstChild.SelectSingleNode(FieldNames.FlFinalizado) != null) dto.FlFinalizado.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlFinalizado).InnerText;			
		
            if (xml.FirstChild.SelectSingleNode(FieldNames.DsProduto) != null) dto.DsProduto.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsProduto).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.UnidadeVenda) != null) dto.UnidadeVenda.Value = xml.FirstChild.SelectSingleNode(FieldNames.UnidadeVenda).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeVenda) != null) dto.DsUnidadeVenda.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUnidadeVenda).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.FlFracionado) != null) dto.FlFracionado.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlFracionado).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.EstoqueLocal) != null) dto.EstoqueLocal.Value = xml.FirstChild.SelectSingleNode(FieldNames.EstoqueLocal).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.EstoqueLocalFracionado) != null) dto.EstoqueLocalFracionado.Value = xml.FirstChild.SelectSingleNode(FieldNames.EstoqueLocalFracionado).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidadeBaixa) != null) dto.IdtUnidadeBaixa.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUnidadeBaixa).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalBaixa) != null) dto.IdtLocalBaixa.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalBaixa).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSetorBaixa) != null) dto.IdtSetorBaixa.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSetorBaixa).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtTipoBaixa) != null) dto.IdtTipoBaixa.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtTipoBaixa).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtSubTipoBaixa) != null) dto.IdtSubTipoBaixa.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtSubTipoBaixa).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial) != null) dto.IdtFilial.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtFilial).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeLote) != null) dto.QtdeLote.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeLote).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.CdBarra) != null) dto.CdBarra.Value = xml.FirstChild.SelectSingleNode(FieldNames.CdBarra).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsQtdeFracionado) != null) dto.DsQtdeFracionado.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsQtdeFracionado).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsQtdeConsumo) != null) dto.DsQtdeConsumo.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsQtdeConsumo).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtRequisicao) != null) dto.IdtRequisicao.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtRequisicao).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtAtendimento) != null) dto.IdtAtendimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtAtendimento).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.TpAtendimento) != null) dto.TpAtendimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.TpAtendimento).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.FlFaturado) != null) dto.FlFaturado.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlFaturado).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DataRessupri) != null) dto.DataRessupri.Value = xml.FirstChild.SelectSingleNode(FieldNames.DataRessupri).InnerText;

            // SEGURANÇA
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario) != null) dto.IdtUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioEstorno) != null) dto.IdtUsuarioEstorno.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtUsuarioEstorno).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUsuario) != null) dto.DsUsuario.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUsuario).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DsUsuarioEstorno) != null) dto.DsUsuarioEstorno.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsUsuarioEstorno).InnerText;

            // COMPLEMENTO
            if (xml.FirstChild.SelectSingleNode(FieldNames.Obs) != null) dto.Obs.Value = xml.FirstChild.SelectSingleNode(FieldNames.Obs).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.UsuarioRelatado) != null) dto.UsuarioRelatado.Value = xml.FirstChild.SelectSingleNode(FieldNames.UsuarioRelatado).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalEstoque) != null) dto.IdtLocalEstoque.Value = xml.FirstChild.SelectSingleNode(FieldNames.IdtLocalEstoque).InnerText;
            
            // LISTA MOVIMENTO            
            if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeEntrada) != null) dto.QtdeEntrada.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeEntrada).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeEntradaOutros) != null) dto.QtdeEntradaOutros.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeEntradaOutros).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeSaida) != null) dto.QtdeSaida.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeSaida).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeSaidaOutros) != null) dto.QtdeSaidaOutros.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeSaidaOutros).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.QtdeAcerto) != null) dto.QtdeAcerto.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdeAcerto).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DsSubtipoMov) != null) dto.DsSubtipoMov.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsSubtipoMov).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.SaldoMovimento) != null) dto.SaldoMovimento.Value = xml.FirstChild.SelectSingleNode(FieldNames.SaldoMovimento).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.FormOrigem) != null) dto.FormOrigem.Value = xml.FirstChild.SelectSingleNode(FieldNames.FormOrigem).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.FlEstornado) != null) dto.FlEstornado.Value = xml.FirstChild.SelectSingleNode(FieldNames.FlEstornado).InnerText;


            if (xml.FirstChild.SelectSingleNode(FieldNames.TpFracao) != null) dto.TpFracao.Value = xml.FirstChild.SelectSingleNode(FieldNames.TpFracao).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.QtdConvertida) != null) dto.QtdConvertida.Value = xml.FirstChild.SelectSingleNode(FieldNames.QtdConvertida).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DsQtdConvertida) != null) dto.DsQtdConvertida.Value = xml.FirstChild.SelectSingleNode(FieldNames.DsQtdConvertida).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.DtFaturamento) != null) dto.DtFaturamento.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtFaturamento).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.HrFaturamento) != null) dto.HrFaturamento.Value = xml.FirstChild.SelectSingleNode(FieldNames.HrFaturamento).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.TipoEmpresa) != null) dto.TipoEmpresa.Value = xml.FirstChild.SelectSingleNode(FieldNames.TipoEmpresa).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.SubTipoMovFaturado) != null) dto.SubTipoMovFaturado.Value = xml.FirstChild.SelectSingleNode(FieldNames.SubTipoMovFaturado).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.SequenciaConsumoFaturamento) != null) dto.SequenciaConsumoFaturamento.Value = xml.FirstChild.SelectSingleNode(FieldNames.SequenciaConsumoFaturamento).InnerText;

            if (xml.FirstChild.SelectSingleNode(FieldNames.idtMotivo) != null) dto.idtMotivo.Value = xml.FirstChild.SelectSingleNode(FieldNames.idtMotivo).InnerText;


            if (xml.FirstChild.SelectSingleNode(FieldNames.DtIni) != null) dto.DtIni.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtIni).InnerText;
            if (xml.FirstChild.SelectSingleNode(FieldNames.DtFim) != null) dto.DtFim.Value = xml.FirstChild.SelectSingleNode(FieldNames.DtFim).InnerText;

            return dto;
        }

        public override XmlDocument GetXML()
        {
            XmlDocument xml = new XmlDocument();

            XmlNode nodeData = xml.CreateNode(XmlNodeType.Element, "DADOS", null);
			
            XmlNode nodeIdt = xml.CreateNode(XmlNodeType.Element, FieldNames.Idt, null);
			
            XmlNode nodeIdtLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocal, null);
			
            XmlNode nodeIdtUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidade, null);
			
            XmlNode nodeIdtSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetor, null);

            XmlNode nodeDsLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.DsLocal, null);

            XmlNode nodeDsSetor = xml.CreateNode(XmlNodeType.Element, FieldNames.DsSetor, null);

            XmlNode nodeDsUnidade = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidade, null);
			
            XmlNode nodeIdtLote = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLote, null);
			
            XmlNode nodeIdtProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtProduto, null);
			
            XmlNode nodeIdtTipo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtTipo, null);
			
            XmlNode nodeIdtSubTipo = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSubTipo, null);

            XmlNode nodeDataMovimento = xml.CreateNode(XmlNodeType.Element, FieldNames.DataMovimento, null);
			
            XmlNode nodeQtde = xml.CreateNode(XmlNodeType.Element, FieldNames.Qtde, null);
			
            XmlNode nodeFlFinalizado = xml.CreateNode(XmlNodeType.Element, FieldNames.FlFinalizado, null);
			
            XmlNode nodeDsProduto = xml.CreateNode(XmlNodeType.Element, FieldNames.DsProduto, null);

            XmlNode nodeDsUnidadeVenda = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUnidadeVenda, null);

            XmlNode nodeFracionado = xml.CreateNode(XmlNodeType.Element, FieldNames.FlFracionado, null);

            XmlNode nodeEstoqueLocal = xml.CreateNode(XmlNodeType.Element, FieldNames.EstoqueLocal, null);

            XmlNode nodeEstoqueLocalFracionado = xml.CreateNode(XmlNodeType.Element, FieldNames.EstoqueLocalFracionado, null);

            XmlNode nodeIdtUnidadeBaixa = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUnidadeBaixa, null);

            XmlNode nodeIdtLocalBaixa = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocalBaixa, null);

            XmlNode nodeIdtSetorBaixa = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSetorBaixa, null);

            XmlNode nodeIdtTipoBaixa = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtTipoBaixa, null);

            XmlNode nodeIdtSubTipoBaixa = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtSubTipoBaixa, null);

            XmlNode nodeIdtFilial = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtFilial, null);

            XmlNode nodeQtdeLote = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeLote, null);

            XmlNode nodeCdBarra = xml.CreateNode(XmlNodeType.Element, FieldNames.CdBarra, null);

            XmlNode nodeDsQtdeFracionado = xml.CreateNode(XmlNodeType.Element, FieldNames.DsQtdeFracionado, null);

            XmlNode nodeDsQtdeConsumo = xml.CreateNode(XmlNodeType.Element, FieldNames.DsQtdeConsumo, null);

            XmlNode nodeIdtRequisicao = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtRequisicao, null);

            XmlNode nodeIdtAtendimento = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtAtendimento, null);

            XmlNode nodeTpAtendimento = xml.CreateNode(XmlNodeType.Element, FieldNames.TpAtendimento, null);

            XmlNode nodeFlFaturado = xml.CreateNode(XmlNodeType.Element, FieldNames.FlFaturado, null);

            XmlNode nodeDataRessupri = xml.CreateNode(XmlNodeType.Element, FieldNames.DataRessupri, null);

            // SEGURANÇA
            XmlNode nodeIdtUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuario, null);
            XmlNode nodeIdtUsuarioEstorno = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtUsuarioEstorno, null);
            XmlNode nodeDsUsuario = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUsuario, null);
            XmlNode nodeDsUsuarioEstorno = xml.CreateNode(XmlNodeType.Element, FieldNames.DsUsuarioEstorno, null);

            // COMPLEMENTO
            XmlNode nodeObs = xml.CreateNode(XmlNodeType.Element, FieldNames.Obs, null);

            XmlNode nodeUsuarioRelatado = xml.CreateNode(XmlNodeType.Element, FieldNames.UsuarioRelatado, null);

            XmlNode nodeUnidadeVenda = xml.CreateNode(XmlNodeType.Element, FieldNames.UnidadeVenda, null);

            XmlNode nodeIdtLocalEstoque = xml.CreateNode(XmlNodeType.Element, FieldNames.IdtLocalEstoque, null);

            // LISTA MOVIEMNTO

            XmlNode nodeQtdeEntrada = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeEntrada, null);
            XmlNode nodeQtdeEntradaOutros = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeEntradaOutros, null);
            XmlNode nodeQtdeSaida = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeSaida, null);
            XmlNode nodeQtdeSaidaOutros = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeSaidaOutros, null);
            XmlNode nodeQtdeAcerto = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdeAcerto, null);
            XmlNode nodeDsSubtipoMov = xml.CreateNode(XmlNodeType.Element, FieldNames.DsSubtipoMov, null);
            XmlNode nodeSaldoMovimento = xml.CreateNode(XmlNodeType.Element, FieldNames.SaldoMovimento, null);

            XmlNode nodeFormOrigem = xml.CreateNode(XmlNodeType.Element, FieldNames.FormOrigem, null);


            XmlNode nodeFlEstornado = xml.CreateNode(XmlNodeType.Element, FieldNames.FlEstornado, null);

            XmlNode nodeTpFracao = xml.CreateNode(XmlNodeType.Element, FieldNames.TpFracao, null);
            XmlNode nodeQtdConvertida = xml.CreateNode(XmlNodeType.Element, FieldNames.QtdConvertida, null);

            XmlNode nodeDsQtdConvertida = xml.CreateNode(XmlNodeType.Element, FieldNames.DsQtdConvertida, null);

            XmlNode nodeDtFaturamento = xml.CreateNode(XmlNodeType.Element, FieldNames.DtFaturamento, null);
            XmlNode nodeHrFaturamento = xml.CreateNode(XmlNodeType.Element, FieldNames.HrFaturamento, null);
            XmlNode nodeTipoEmpresa = xml.CreateNode(XmlNodeType.Element, FieldNames.TipoEmpresa, null);
            XmlNode nodeSubTipoMovFaturado = xml.CreateNode(XmlNodeType.Element, FieldNames.SubTipoMovFaturado, null);
            XmlNode nodeSequenciaConsumoFaturamento = xml.CreateNode(XmlNodeType.Element, FieldNames.SequenciaConsumoFaturamento, null);

            XmlNode nodeidtMotivo = xml.CreateNode(XmlNodeType.Element, FieldNames.idtMotivo, null);

            // RELATORIOS
            XmlNode nodeDtIni = xml.CreateNode(XmlNodeType.Element, FieldNames.DtIni, null);
            XmlNode nodeDtFim = xml.CreateNode(XmlNodeType.Element, FieldNames.DtFim, null);
           

			if (!this.Idt.Value.IsNull) nodeIdt.InnerText = this.Idt.Value;
			
			if (!this.IdtLocal.Value.IsNull) nodeIdtLocal.InnerText = this.IdtLocal.Value;
			
			if (!this.IdtUnidade.Value.IsNull) nodeIdtUnidade.InnerText = this.IdtUnidade.Value;
			
			if (!this.IdtSetor.Value.IsNull) nodeIdtSetor.InnerText = this.IdtSetor.Value;

            if (!this.DsLocal.Value.IsNull) nodeDsLocal.InnerText = this.DsLocal.Value;

            if (!this.DsUnidade.Value.IsNull) nodeDsUnidade.InnerText = this.DsUnidade.Value;

            if (!this.DsSetor.Value.IsNull) nodeDsSetor.InnerText = this.DsSetor.Value;
			
			if (!this.IdtLote.Value.IsNull) nodeIdtLote.InnerText = this.IdtLote.Value;
			
			if (!this.IdtProduto.Value.IsNull) nodeIdtProduto.InnerText = this.IdtProduto.Value;
			
			if (!this.IdtTipo.Value.IsNull) nodeIdtTipo.InnerText = this.IdtTipo.Value;
			
			if (!this.IdtSubTipo.Value.IsNull) nodeIdtSubTipo.InnerText = this.IdtSubTipo.Value;

            if (!this.DataMovimento.Value.IsNull) nodeData.InnerText = this.DataMovimento.Value;
			
			if (!this.Qtde.Value.IsNull) nodeQtde.InnerText = this.Qtde.Value;
			
			if (!this.FlFinalizado.Value.IsNull) nodeFlFinalizado.InnerText = this.FlFinalizado.Value;
			
            if (!this.DsProduto.Value.IsNull) nodeDsProduto.InnerText = this.DsProduto.Value;

            if (!this.UnidadeVenda.Value.IsNull) nodeUnidadeVenda.InnerText = this.UnidadeVenda.Value;

            if (!this.DsUnidadeVenda.Value.IsNull) nodeDsUnidadeVenda.InnerText = this.DsUnidadeVenda.Value;

            if (!this.FlFracionado.Value.IsNull) nodeFracionado.InnerText = this.FlFracionado.Value;

            if (!this.EstoqueLocal.Value.IsNull) nodeEstoqueLocal.InnerText = this.EstoqueLocal.Value;

            if (!this.EstoqueLocalFracionado.Value.IsNull) nodeEstoqueLocalFracionado.InnerText = this.EstoqueLocalFracionado.Value;

            if (!this.IdtUnidadeBaixa.Value.IsNull) nodeIdtUnidadeBaixa.InnerText = this.IdtUnidadeBaixa.Value;

            if (!this.IdtLocalBaixa.Value.IsNull) nodeIdtLocalBaixa.InnerText = this.IdtLocalBaixa.Value;

            if (!this.IdtSetorBaixa.Value.IsNull) nodeIdtSetorBaixa.InnerText = this.IdtSetorBaixa.Value;

            if (!this.IdtTipoBaixa.Value.IsNull) nodeIdtTipoBaixa.InnerText = this.IdtTipoBaixa.Value;

            if (!this.IdtSubTipoBaixa.Value.IsNull) nodeIdtSubTipoBaixa.InnerText = this.IdtSubTipoBaixa.Value;

            if (!this.IdtFilial.Value.IsNull) nodeIdtFilial.InnerText = this.IdtFilial.Value;

            if (!this.QtdeLote.Value.IsNull) nodeQtdeLote.InnerText = this.QtdeLote.Value;

            if (!this.CdBarra.Value.IsNull) nodeCdBarra.InnerText = this.CdBarra.Value;

            if (!this.DsQtdeFracionado.Value.IsNull) nodeDsQtdeFracionado.InnerText = this.DsQtdeFracionado.Value;

            if (!this.DsQtdeConsumo.Value.IsNull) nodeDsQtdeConsumo.InnerText = this.DsQtdeConsumo.Value;

            if (!this.IdtRequisicao.Value.IsNull) nodeIdtRequisicao.InnerText = this.IdtRequisicao.Value;

            if (!this.IdtAtendimento.Value.IsNull) nodeIdtAtendimento.InnerText = this.IdtAtendimento.Value;

            if (!this.TpAtendimento.Value.IsNull) nodeTpAtendimento.InnerText = this.TpAtendimento.Value;

            if (!this.FlFaturado.Value.IsNull) nodeFlFaturado.InnerText = this.FlFaturado.Value;

            if (!this.DataRessupri.Value.IsNull) nodeDataRessupri.InnerText = this.DataRessupri.Value;

            // SEGURANÇA
            if (!this.IdtUsuario.Value.IsNull) nodeIdtUsuario.InnerText = this.IdtUsuario.Value;
            if (!this.IdtUsuarioEstorno.Value.IsNull) nodeIdtUsuarioEstorno.InnerText = this.IdtUsuarioEstorno.Value;
            if (!this.DsUsuario.Value.IsNull) nodeDsUsuario.InnerText = this.DsUsuario.Value;
            if (!this.DsUsuarioEstorno.Value.IsNull) nodeDsUsuarioEstorno.InnerText = this.DsUsuarioEstorno.Value;

            //COMPLEMENTO
            if (!this.Obs.Value.IsNull) nodeObs.InnerText = this.Obs.Value;

            if (!this.UsuarioRelatado.Value.IsNull) nodeUsuarioRelatado.InnerText = this.UsuarioRelatado.Value;

            if (!this.IdtLocalEstoque.Value.IsNull) nodeIdtLocalEstoque.InnerText = this.IdtLocalEstoque.Value;

            // LISTA MOVIMENTO
            if (!this.QtdeEntrada.Value.IsNull) nodeQtdeEntrada.InnerText = this.QtdeEntrada.Value;
            if (!this.QtdeEntradaOutros.Value.IsNull) nodeQtdeEntradaOutros.InnerText = this.QtdeEntradaOutros.Value;
            if (!this.QtdeSaida.Value.IsNull) nodeQtdeSaida.InnerText = this.QtdeSaida.Value;
            if (!this.QtdeSaidaOutros.Value.IsNull) nodeQtdeSaidaOutros.InnerText = this.QtdeSaidaOutros.Value;
            if (!this.QtdeAcerto.Value.IsNull) nodeQtdeAcerto.InnerText = this.QtdeAcerto.Value;
            if (!this.DsSubtipoMov.Value.IsNull) nodeDsSubtipoMov.InnerText = this.DsSubtipoMov.Value;
            if (!this.SaldoMovimento.Value.IsNull) nodeSaldoMovimento.InnerText = this.SaldoMovimento.Value;

            if (!this.FormOrigem.Value.IsNull) nodeFormOrigem.InnerText = this.FormOrigem.Value;

            if (!this.FlEstornado.Value.IsNull) nodeFlEstornado.InnerText = this.FlEstornado.Value;

            if (!this.TpFracao.Value.IsNull) nodeTpFracao.InnerText = this.TpFracao.Value;
            if (!this.QtdConvertida.Value.IsNull) nodeQtdConvertida.InnerText = this.QtdConvertida.Value;

            if (!this.DsQtdConvertida.Value.IsNull) nodeDsQtdConvertida.InnerText = this.DsQtdConvertida.Value;

            if (!this.DtFaturamento.Value.IsNull) nodeDtFaturamento.InnerText = this.DtFaturamento.Value;
            if (!this.HrFaturamento.Value.IsNull) nodeHrFaturamento.InnerText = this.HrFaturamento.Value;
            if (!this.TipoEmpresa.Value.IsNull) nodeTipoEmpresa.InnerText = this.TipoEmpresa.Value;
            if (!this.SubTipoMovFaturado.Value.IsNull) nodeSubTipoMovFaturado.InnerText = this.SubTipoMovFaturado.Value;
            if (!this.SequenciaConsumoFaturamento.Value.IsNull) nodeSequenciaConsumoFaturamento.InnerText = this.SequenciaConsumoFaturamento.Value;

            if (!this.idtMotivo.Value.IsNull) nodeidtMotivo.InnerText = this.idtMotivo.Value;

            // RELATORIOS
            if (!this.DtIni.Value.IsNull) nodeDtIni.InnerText = this.DtIni.Value;
            if (!this.DtFim.Value.IsNull) nodeDtFim.InnerText = this.DtFim.Value;

            nodeData.AppendChild(nodeIdt);
			
            nodeData.AppendChild(nodeIdtLocal);
			
            nodeData.AppendChild(nodeIdtUnidade);
			
            nodeData.AppendChild(nodeIdtSetor);

            nodeData.AppendChild(nodeDsLocal);

            nodeData.AppendChild(nodeDsUnidade);

            nodeData.AppendChild(nodeDsSetor);
			
            nodeData.AppendChild(nodeIdtLote);
			
            nodeData.AppendChild(nodeIdtProduto);
			
            nodeData.AppendChild(nodeIdtTipo);
			
            nodeData.AppendChild(nodeIdtSubTipo);

            nodeData.AppendChild(nodeDataMovimento);
			
            nodeData.AppendChild(nodeQtde);
			
            nodeData.AppendChild(nodeFlFinalizado);
			
            nodeData.AppendChild(nodeDsProduto);

            nodeData.AppendChild(nodeUnidadeVenda);

            nodeData.AppendChild(nodeDsUnidadeVenda);

            nodeData.AppendChild(nodeFracionado);

            nodeData.AppendChild(nodeEstoqueLocal);

            nodeEstoqueLocalFracionado.AppendChild(nodeEstoqueLocalFracionado);

            nodeData.AppendChild(nodeIdtUnidadeBaixa);

            nodeData.AppendChild(nodeIdtLocalBaixa);

            nodeData.AppendChild(nodeIdtSetorBaixa);

            nodeData.AppendChild(nodeIdtTipoBaixa);

            nodeData.AppendChild(nodeIdtSubTipoBaixa);

            nodeData.AppendChild(nodeIdtFilial);

            nodeData.AppendChild(nodeQtdeLote);

            nodeData.AppendChild(nodeCdBarra);

            nodeData.AppendChild(nodeDsQtdeFracionado);

            nodeData.AppendChild(nodeDsQtdeConsumo);

            nodeData.AppendChild(nodeIdtRequisicao);

            nodeData.AppendChild(nodeIdtAtendimento);

            nodeData.AppendChild(nodeTpAtendimento);

            nodeData.AppendChild(nodeFlFaturado);

            nodeData.AppendChild(nodeDataRessupri);
            
            // SEGURANÇA
            nodeData.AppendChild(nodeIdtUsuario);
            nodeData.AppendChild(nodeIdtUsuarioEstorno);
            nodeData.AppendChild(nodeDsUsuario);
            nodeData.AppendChild(nodeDsUsuarioEstorno);

            //COMPLEMENTO
            nodeData.AppendChild(nodeObs);

            nodeData.AppendChild(nodeUsuarioRelatado);

            nodeData.AppendChild(nodeIdtLocalEstoque);

            //LISTA MOVIMENTO
            nodeData.AppendChild(nodeQtdeEntrada);

            nodeData.AppendChild(nodeQtdeEntradaOutros);

            nodeData.AppendChild(nodeQtdeSaida);

            nodeData.AppendChild(nodeQtdeSaidaOutros);

            nodeData.AppendChild(nodeQtdeAcerto);

            nodeData.AppendChild(nodeDsSubtipoMov);

            nodeData.AppendChild(nodeSaldoMovimento);

            nodeData.AppendChild(nodeFormOrigem);

            nodeData.AppendChild(nodeFlEstornado);

            nodeData.AppendChild(nodeTpFracao);
            nodeData.AppendChild(nodeQtdConvertida);

            nodeData.AppendChild(nodeDsQtdConvertida);

            nodeData.AppendChild(nodeDtFaturamento);
            nodeData.AppendChild(nodeHrFaturamento);
            nodeData.AppendChild(nodeTipoEmpresa);
            nodeData.AppendChild(nodeSubTipoMovFaturado);
            nodeData.AppendChild(nodeSequenciaConsumoFaturamento);

            nodeData.AppendChild(nodeidtMotivo);

            nodeData.AppendChild(nodeDtIni);
            nodeData.AppendChild(nodeDtFim);

            xml.AppendChild(nodeData);

            return xml;
        }

        public static explicit operator DataRow(MovimentacaoDTO dto)
        {
            MovimentacaoDataTable dtb = new MovimentacaoDataTable();
            DataRow dtr = dtb.NewRow();
			
            dtr[FieldNames.Idt] = dto.Idt.Value;
			
            dtr[FieldNames.IdtLocal] = dto.IdtLocal.Value;
			
            dtr[FieldNames.IdtUnidade] = dto.IdtUnidade.Value;
			
            dtr[FieldNames.IdtSetor] = dto.IdtSetor.Value;

            dtr[FieldNames.DsSetor] = dto.DsSetor.Value;

            dtr[FieldNames.DsUnidade] = dto.DsUnidade.Value;

            dtr[FieldNames.DsLocal] = dto.DsLocal.Value;
			
            dtr[FieldNames.IdtLote] = dto.IdtLote.Value;
			
            dtr[FieldNames.IdtProduto] = dto.IdtProduto.Value;
			
            dtr[FieldNames.IdtTipo] = dto.IdtTipo.Value;
			
            dtr[FieldNames.IdtSubTipo] = dto.IdtSubTipo.Value;

            dtr[FieldNames.DataMovimento] = dto.DataMovimento.Value;
			
            dtr[FieldNames.Qtde] = dto.Qtde.Value;
			
            dtr[FieldNames.FlFinalizado] = dto.FlFinalizado.Value;
			
            dtr[FieldNames.DsProduto] = dto.DsProduto.Value;

            dtr[FieldNames.UnidadeVenda] = dto.UnidadeVenda.Value;

            dtr[FieldNames.DsUnidadeVenda] = dto.DsUnidadeVenda.Value;

            dtr[FieldNames.FlFracionado] = dto.FlFracionado.Value;

            dtr[FieldNames.EstoqueLocal] = dto.EstoqueLocal.Value;

            dtr[FieldNames.EstoqueLocalFracionado] = dto.EstoqueLocalFracionado.Value;

            dtr[FieldNames.IdtUnidadeBaixa] = dto.IdtUnidadeBaixa.Value;

            dtr[FieldNames.IdtLocalBaixa] = dto.IdtLocalBaixa.Value;

            dtr[FieldNames.IdtSetorBaixa] = dto.IdtSetorBaixa.Value;

            dtr[FieldNames.IdtTipoBaixa] = dto.IdtTipoBaixa.Value;

            dtr[FieldNames.IdtSubTipoBaixa] = dto.IdtSubTipoBaixa.Value;

            dtr[FieldNames.IdtFilial] = dto.IdtFilial.Value;

            dtr[FieldNames.QtdeLote] = dto.QtdeLote.Value;

            dtr[FieldNames.CdBarra] = dto.CdBarra.Value;

            dtr[FieldNames.DsQtdeFracionado] = dto.DsQtdeFracionado.Value;

            dtr[FieldNames.DsQtdeConsumo] = dto.DsQtdeConsumo.Value;

            dtr[FieldNames.IdtRequisicao] = dto.IdtRequisicao.Value;

            dtr[FieldNames.IdtAtendimento] = dto.IdtAtendimento.Value;

            dtr[FieldNames.TpAtendimento] = dto.TpAtendimento.Value;

            dtr[FieldNames.FlFaturado] = dto.FlFaturado.Value;

            dtr[FieldNames.DataRessupri] = dto.DataRessupri.Value;

            // SEGURANÇA
            dtr[FieldNames.IdtUsuario] = dto.IdtUsuario.Value;
            dtr[FieldNames.IdtUsuarioEstorno] = dto.IdtUsuarioEstorno.Value;
            dtr[FieldNames.DsUsuario] = dto.DsUsuario.Value;
            dtr[FieldNames.DsUsuarioEstorno] = dto.DsUsuarioEstorno.Value;

            // COMPLEMENTO
            dtr[FieldNames.Obs] = dto.Obs.Value;

            dtr[FieldNames.UsuarioRelatado] = dto.UsuarioRelatado.Value;

            dtr[FieldNames.IdtLocalEstoque] = dto.IdtLocalEstoque.Value;

            // LISTA MOVIMENTO
            dtr[FieldNames.QtdeEntrada] = dto.QtdeEntrada.Value;

            dtr[FieldNames.QtdeEntradaOutros] = dto.QtdeEntradaOutros.Value;

            dtr[FieldNames.QtdeSaida] = dto.QtdeSaida.Value;

            dtr[FieldNames.QtdeSaidaOutros] = dto.QtdeSaidaOutros.Value;

            dtr[FieldNames.QtdeAcerto] = dto.QtdeAcerto.Value;

            dtr[FieldNames.DsSubtipoMov] = dto.DsSubtipoMov.Value;

            dtr[FieldNames.SaldoMovimento] = dto.SaldoMovimento.Value;

            dtr[FieldNames.FormOrigem] = dto.FormOrigem.Value;


            dtr[FieldNames.CodProdutoMNE] = dto.CodProdutoMNE.Value;
            dtr[FieldNames.DsUnidadeCompra] = dto.DsUnidadeCompra.Value;
            dtr[FieldNames.ValorUnitario] = dto.ValorUnitario.Value;
            dtr[FieldNames.ValorTotal] = dto.ValorTotal.Value;
            dtr[FieldNames.DataAte] = dto.DataAte.Value;
            dtr[FieldNames.Tabelamedica] = dto.Tabelamedica.Value;

            dtr[FieldNames.FlEstornado] = dto.FlEstornado.Value;

            dtr[FieldNames.TpFracao] = dto.TpFracao.Value;
            dtr[FieldNames.QtdConvertida] = dto.QtdConvertida.Value;

            dtr[FieldNames.DsQtdConvertida] = dto.DsQtdConvertida.Value;

            dtr[FieldNames.DtFaturamento] = dto.DtFaturamento.Value;
            dtr[FieldNames.HrFaturamento] = dto.HrFaturamento.Value;
            dtr[FieldNames.TipoEmpresa] = dto.TipoEmpresa.Value;
            dtr[FieldNames.SubTipoMovFaturado] = dto.SubTipoMovFaturado.Value;
            dtr[FieldNames.SequenciaConsumoFaturamento] = dto.SequenciaConsumoFaturamento.Value;
            dtr[FieldNames.CodigoIBGEMunicipioHomeCare] = dto.CodigoIBGEMunicipioHomeCare.Value;

            dtr[FieldNames.idtMotivo] = dto.idtMotivo.Value;

            dtr[FieldNames.CodLote] = dto.CodLote.Value;
            dtr[FieldNames.SaldoLoteSetor] = dto.SaldoLoteSetor.Value;
            dtr[FieldNames.SaldoLoteTotal] = dto.SaldoLoteTotal.Value;
                        
            // RELATORIOS

            dtr[FieldNames.DtIni] = dto.DtIni.Value;
            dtr[FieldNames.DtFim] = dto.DtFim.Value;

            return dtr;
        }

        public static explicit operator XmlDocument(MovimentacaoDTO dto)
        {
            return dto.GetXML();
        }

        #endregion
    }
}