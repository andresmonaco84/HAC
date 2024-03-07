using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
    public class Kit : Control, IKit
    {
        private Model.Kit entity = new Model.Kit();

        public KitDTO Gravar(KitDTO dto, int idUsuario)
        {
            entity.Gravar(dto, idUsuario);
            return dto;
        }

        public void GravarItem(KitDTO dto, int idUsuario)
        {
            entity.GravarItem(dto, idUsuario);
        }

        public void ExcluirItem(KitDTO dto)
        {
            entity.ExcluirItem(dto);
        }

        public KitDataTable Listar(KitDTO dto)
        {
            return entity.Listar(dto);
        }

        public KitDataTable ListarItem(KitDTO dto)
        {
            return entity.ListarItem(dto);
        }

        public DataTable ListarSaldo(int? idSaldo, MovimentacaoDTO dto)
        {
            return entity.ListarSaldo(idSaldo, dto);
        }

        public void GravarSaldo(int idSaldo, int idKit, MovimentacaoDTO dto)
        {
            MovimentacaoDTO dtoMovPesquisa = new MovimentacaoDTO();
            dtoMovPesquisa.IdtProduto.Value = dto.IdtProduto.Value;
            if (!dto.CodLote.Value.IsNull)
                dtoMovPesquisa.CodLote.Value = dto.CodLote.Value;
            DataTable dtbSaldo = entity.ListarSaldo(idSaldo, dtoMovPesquisa);

            if (dtbSaldo.Rows.Count == 0)
                entity.InsSaldoKit(idSaldo, idKit, dto);
            else
                entity.UpdSaldoKit(idSaldo, dto);
        }

        public int GerarSaldoID()
        {
            return entity.GerarSaldoID();
        }

        public void UpdSaldoKitImpressp(int idSaldo)
        {
            entity.UpdSaldoKitImpressp(idSaldo);
        }

        public KitDataTable ListarMateriaisAplicaMedicamento(MaterialMedicamentoDTO dtoMedicamento)
        {
            return entity.ListarMateriaisAplicaMedicamento(dtoMedicamento);
        }

        public KitDataTable ListarMedicamentosAssociadosAplicaKit(KitDTO dto)
        {
            return entity.ListarMedicamentosAssociadosAplicaKit(dto);
        }

        public void InsMedicamentoAssociadoAplicaKit(KitDTO dto, int idUsuario)
        {
            entity.InsMedicamentoAssociadoAplicaKit(dto, idUsuario);
        }

        public void ExcluirMedicamentoAssociadoAplicaKit(KitDTO dto, int idUsuario)
        {
            entity.ExcluirMedicamentoAssociadoAplicaKit(dto, idUsuario);
        }
    }
}