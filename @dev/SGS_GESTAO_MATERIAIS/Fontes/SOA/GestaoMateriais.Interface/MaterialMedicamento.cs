using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
// using HospitalAnaCosta.SGS.Cadastro.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IMaterialMedicamento
	{
		MaterialMedicamentoDataTable Sel(MaterialMedicamentoDTO dto);

        MaterialMedicamentoDTO Ins(MaterialMedicamentoDTO dto);

		void Del(MaterialMedicamentoDTO dto);
		
		void Upd(MaterialMedicamentoDTO dto);
		
		MaterialMedicamentoDTO SelChave(MaterialMedicamentoDTO dto);

        MaterialMedicamentoDTO BuscaCodigoBarra(CodigoBarraDTO dto);

        /// <summary>
        /// Busca Informações atuais do Produto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        MaterialMedicamentoDTO InfoContabil(MaterialMedicamentoDTO dto);

        /// <summary>
        /// Obtem Consumo Médio/Entrada/Ind. Rotatividade
        /// </summary>
        /// <param name="dtoMatMed"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataTermino"></param>
        /// <param name="consumoMedio"></param>
        /// <param name="iRotatividade"></param>
        /// <param name="Entrada"></param>
        void ObterStatusConsumo(MaterialMedicamentoDTO dtoMatMed,  DateTime dataInicio, DateTime dataTermino, out decimal consumoMedio, out decimal iRotatividade, out decimal Entrada);

        /// <summary>
        /// Obtem Qtd em estoque hoje e data do ultimo consumo
        /// </summary>
        /// <param name="dtoMatMed"></param>
        /// <param name="qtdEstoqueContabil"></param>
        /// <param name="ultimoConsumo"></param>
        void ObterStatusConsumo(MaterialMedicamentoDTO dtoMatMed, out decimal qtdEstoqueContabil,out DateTime? ultimoConsumo);

        decimal ObterCustoMedio(MovimentacaoDTO dto);
        

        decimal ObterRotatividade(MaterialMedicamentoDTO dtoMatMed, DateTime dataInicio, DateTime dataTermino);

        /// <summary>
        /// ObterConsumoUltimosMeses (já traz ordenado pelos meses)
        /// </summary>        
        MovimentacaoDataTable ObterConsumoUltimosMeses(MaterialMedicamentoDTO dtoMatMed, byte qtdMesesAnteriores);

        /// <summary>
        /// Seleciona os materiais e medicamentos os quais o setor possui permissão.
        /// Se dtoSetor = null, não filtra os registros de acordo com a permissão, 
        /// trazendo todos os registros de acordo com o dtoMatMed.
        /// </summary>
        MaterialMedicamentoDataTable SelSubGrupoSetorPermissao(MaterialMedicamentoDTO dtoMatMed);
        //MaterialMedicamentoDataTable SelSubGrupoSetorPermissao(MaterialMedicamentoDTO dtoMatMed, SetorDTO dtoSetor);

        MaterialMedicamentoDataTable SelSubGrupoSetorPermissao(MaterialMedicamentoDTO dto, bool comEstoqueAlmox);

        void InserirMarca(decimal idProduto, decimal numMarca, string descricaoMarca, decimal idUsuario);

        void AtualizarMarca(decimal idProduto, decimal numMarca, string descricaoMarca, decimal idUsuario);

        void ExcluirMarca(decimal idProduto, decimal numMarca);

        System.Data.DataTable SelMarcas(decimal idProduto);

        System.Data.DataTable SelEnderecos(decimal idProduto);

        void AtualizarEnderecos(decimal idProduto, decimal? numEndHAC, decimal? numEndACS);

        bool ProdutoPedidoAutomatico(MaterialMedicamentoDTO dtoMatMed);

        void AtualizarDiluente(MaterialMedicamentoDTO dto);

        void AtualizarPrincipioAtivo(MaterialMedicamentoDTO dto);
	}
}