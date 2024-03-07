using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
    public interface IPrescricao
    {
        PrescricaoDTO Gravar(PrescricaoDTO dto);

        void GravarInformacoesExtras(PrescricaoDTO dto);

        void GravarItem(PrescricaoDTO dto);

        void GravarItem(PrescricaoDTO dto, bool enviaSMSDataLimiteAlterada);

        void GravarParecerSCIH(PrescricaoDTO dto);        

        void ExcluirItem(PrescricaoDTO dto);

        void GravarCultura(PrescricaoDTO dto);

        void ExcluirCultura(PrescricaoDTO dto);

        PrescricaoDataTable ListarCultura(PrescricaoDTO dto);

        PrescricaoDataTable ListarItem(PrescricaoDTO dto, bool pendencias);

        PrescricaoDataTable ListarItem(PrescricaoDTO dto, bool pendencias, bool trazerSetorPaciente, PacienteDTO dtoPaciente);

        PrescricaoDataTable ListarItensPrescricoesAnterioresPaciente(PrescricaoDTO dto);

        System.Data.DataTable ListarProfissionalCorpoClinico(string numConselho, string ufConselho, string codConselho, decimal? idProfissional);

        System.Data.DataTable ListarProfissionalSolicitante(string numConselho, string ufConselho, string codConselho);

        void AssociarDoencaDiagnostico(PrescricaoDTO dto);

        void DesassociarDoencaDiagnostico(PrescricaoDTO dto);

        PrescricaoDataTable ListarDoencaDiagnostico(PrescricaoDTO dto, DoencaDiagnosticoDTO dtoDoDi);

        DataTable ListarPacientesSetor(PrescricaoDTO dto, decimal? idUnidade, decimal? idLocal, decimal? idSetor, int? idadeDe, int? idadeAte, char? sexo);
        
        DataTable ListarPacientesClinico(PrescricaoDTO dto, DoencaDiagnosticoDTO dtoDoDi, bool? comCultura);
        
        DataTable ListarMedicamentosEstatisticaAnalitico(PrescricaoDTO dto, bool? comModificacao, int? qtdDiasDe, int? qtdDiasAte);
        
        DataTable ListarMedicamentosEstatisticaPercentual(PrescricaoDTO dto);

        DataTable ListarFormulariosCompletos(PrescricaoDTO dto);

        DataTable ListarDataAtualizacaoItemPrescricao(decimal idtPrescricao);
    }
}