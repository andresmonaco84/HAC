using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.Services.CadastroFaturamento.DTO;
using HospitalAnaCosta.SGS.Cadastro.Control;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
    public class LivroRegistroMovimentos : Control, ILivroRegistroMovimentos
    {
        private Model.LivroRegistroMovimentos entity = new Model.LivroRegistroMovimentos();

        public LivroRegistroMovimentosDataTable GerarDados(LivroRegistroMovimentosDTO dto, int ano, int mes, bool excluirDadoPosterior)
        {
            return entity.GerarDados(dto, ano, mes, excluirDadoPosterior);
        }

        public LivroRegistroMovimentosDataTable Listar(LivroRegistroMovimentosDTO dto, int ano, int mes)
        {
            return entity.Listar(dto, ano, mes);
        }

        public void AtualizarItem(LivroRegistroMovimentosDTO dto)
        {
            entity.AtualizarItem(dto);
        }

        public DataTable ObterResponsavel(string tipoReponsavel, int idUnidade)
        {
            return entity.ObterResponsavel(tipoReponsavel, idUnidade);
        }

        public DateTime? ObterUltimaDataRegistro(int idProduto, int idUnidade)
        {
            return entity.ObterUltimaDataRegistro(idProduto, idUnidade);
        }
    }
}