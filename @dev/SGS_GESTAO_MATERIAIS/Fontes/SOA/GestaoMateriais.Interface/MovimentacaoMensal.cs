
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IMovimentacaoMensal
	{
		MovimentacaoMensalDataTable Sel(MovimentacaoMensalDTO dto);

		MovimentacaoMensalDTO Ins(MovimentacaoMensalDTO dto);

		void Del(MovimentacaoMensalDTO dto);
		
		void Upd(MovimentacaoMensalDTO dto);
		
		MovimentacaoMensalDTO SelChave(MovimentacaoMensalDTO dto);

        MovimentacaoMensalDTO ObtemIndiceRotatividade(MovimentacaoMensalDTO dto);

        System.Data.DataTable ObterValoresMovProdutos(int ano, byte mes, byte filial);

        System.Data.DataTable ObterValoresMovGrupo(int ano, byte mes, byte filial);

        System.Data.DataTable ObterQtdsConsumoCCusto(int ano, byte mes, byte filial);

        DateTime? ObterUltimaDataExecucaoFechamento();

        DateTime? ObterUltimaDataFechamento();

        void GerarPreviaMes();
	}
}
