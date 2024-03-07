using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
// using HospitalAnaCosta.SGS.Cadastro.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IMatMedSetorConfig
	{
		MatMedSetorConfigDataTable Sel(MatMedSetorConfigDTO dto);

		MatMedSetorConfigDTO Ins(MatMedSetorConfigDTO dto);

		void Del(MatMedSetorConfigDTO dto);	
		
		MatMedSetorConfigDTO SelChave(MatMedSetorConfigDTO dto);

        /// <summary>
        /// Grava as configurações referentes ao setor
        /// </summary>
        void Gravar(SetorDTO dtoSetor, MatMedSetorConfigDTO dto, MatMedSetorConfigDataTable dtbMatMedSetorConfig, SetorDataTable dtbSetoresCentroDisp);

        MatMedSetorConfigDTO ConverteRequisicaoMatMedSetorConfig(RequisicaoDTO dto);

        MatMedSetorConfigDTO ConvertePedidoPadraoMatMedSetorConfig(PedidoPadraoDTO dto);

        MatMedSetorConfigDTO SetorCfg(MatMedSetorConfigDTO dto);

        void SetorCfgSalvar(MatMedSetorConfigDTO dto);

        SetorEstoqueConsumoDataTable SetorEstoqueConsumoObter(SetorEstoqueConsumoDTO dto);

        void SetorEstoqueConsumoSalvar(SetorEstoqueConsumoDTO dto);

        void SetorEstoqueConsumoExcluir(SetorEstoqueConsumoDTO dto);

        SetorEstoqueConsumoDataTable SetorEstoqueUnidadesQueConsomemObter(SetorEstoqueConsumoDTO dto);

        /// <summary>
        /// Verifica se Setor tem Acesso ao Produto sendo movimentado
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Verdadeiro/Falso</returns>
        bool SetorAcessoProduto(MovimentacaoDTO dto);

        bool ControlaConsumoPacienteSetor(MatMedSetorConfigDTO dtoSetorConfig, out DateTime? dtInicioControle);

        DateTime? DataUltimaGeracaoPedidosAutomaticosFarmacia();

        void GerarPedidosAutomaticosFarmacia(bool gerando, bool atualizarData);

        bool GerandoPedidosAutomaticosFarmacia();
	}
}