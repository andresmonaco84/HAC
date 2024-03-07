using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
    public interface IPaciente
    {
        PacienteDataTable Sel(PacienteDTO dto);

        /// <summary>
        /// Configura o tipo de atendimento pelo local de atendimento
        /// </summary>
        /// <param name="dtoAtendimento"></param>
        /// <returns></returns>
        PacienteDTO ObterTipoAtendimento(PacienteDTO dtoAtendimento);

        /// <summary>
        /// Listar todos os registros NÃO limitando pela data da alta
        /// </summary>
        PacienteDTO SelChave(PacienteDTO dto);

        int ObterQtdeRegistrosContaFaturadaComNF(decimal idtAtendimento);

        System.Data.DataTable ObterPaciente(decimal idAtendimento);

        string ObterPacienteEndereco(decimal idAtendimento);

        System.Data.DataTable ListarInternacoesAnterioresPaciente(decimal idAtendimento);

        bool ControlaConsumoPacienteSetor(decimal idAtendimento, MatMedSetorConfigDTO dtoSetorConfig);

        bool AnteriorControleConsumo(int idAtendimento);
    }
}