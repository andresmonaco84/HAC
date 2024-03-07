using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
    public interface ILivroRegistroMovimentos
    {
        LivroRegistroMovimentosDataTable GerarDados(LivroRegistroMovimentosDTO dto, int ano, int mes, bool excluirDadoPosterior);

        LivroRegistroMovimentosDataTable Listar(LivroRegistroMovimentosDTO dto, int ano, int mes);

        void AtualizarItem(LivroRegistroMovimentosDTO dto);

        System.Data.DataTable ObterResponsavel(string tipoReponsavel, int idUnidade);

        DateTime? ObterUltimaDataRegistro(int idProduto, int idUnidade);
    }
}