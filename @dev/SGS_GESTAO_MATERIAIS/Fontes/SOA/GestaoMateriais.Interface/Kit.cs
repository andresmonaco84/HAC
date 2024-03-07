using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
    public interface IKit
    {
        KitDTO Gravar(KitDTO dto, int idUsuario);

        void GravarItem(KitDTO dto, int idUsuario);

        void ExcluirItem(KitDTO dto);

        KitDataTable Listar(KitDTO dto);

        KitDataTable ListarItem(KitDTO dto);

        System.Data.DataTable ListarSaldo(int? idSaldo, MovimentacaoDTO dto);

        void GravarSaldo(int idSaldo, int idKit, MovimentacaoDTO dto);

        int GerarSaldoID();

        void UpdSaldoKitImpressp(int idSaldo);

        KitDataTable ListarMateriaisAplicaMedicamento(MaterialMedicamentoDTO dtoMedicamento);

        KitDataTable ListarMedicamentosAssociadosAplicaKit(KitDTO dto);

        void InsMedicamentoAssociadoAplicaKit(KitDTO dto, int idUsuario);

        void ExcluirMedicamentoAssociadoAplicaKit(KitDTO dto, int idUsuario);
    }
}