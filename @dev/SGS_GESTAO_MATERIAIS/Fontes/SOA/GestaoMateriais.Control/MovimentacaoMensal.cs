
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class MovimentacaoMensal : Control, IMovimentacaoMensal
	{
		private Model.MovimentacaoMensal entity = new Model.MovimentacaoMensal() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public MovimentacaoMensalDataTable Sel(MovimentacaoMensalDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public MovimentacaoMensalDTO SelChave(MovimentacaoMensalDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public MovimentacaoMensalDTO Ins(MovimentacaoMensalDTO dto)
		{
            /*
            PassportVO passportVO = (PassportVO)Credential;
            dto.DataUltimaAtualizacao.Value = DateTime.Now;
            dto.IdtUsuario.Value = passportVO.Usuario.Idt;
            */
			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(MovimentacaoMensalDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(MovimentacaoMensalDTO dto)
		{
            /*
            PassportVO passportVO = (PassportVO)Credential;
            dto.DataUltimaAtualizacao.Value = DateTime.Now;
            dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		*/
			entity.Upd(dto);
		}

        public MovimentacaoMensalDTO ObtemIndiceRotatividade(MovimentacaoMensalDTO dto)
        {
            return entity.ObtemIndiceRotatividade(dto);
        }

        public System.Data.DataTable ObterValoresMovProdutos(int ano, byte mes, byte filial)
        {
            return entity.ObterValoresMovProdutos(ano, mes, filial);
        }

        public System.Data.DataTable ObterValoresMovGrupo(int ano, byte mes, byte filial)
        {
            return entity.ObterValoresMovGrupo(ano, mes, filial);
        }

        public System.Data.DataTable ObterQtdsConsumoCCusto(int ano, byte mes, byte filial)
        {
            return entity.ObterQtdsConsumoCCusto(ano, mes, filial);
        }

        public DateTime? ObterUltimaDataExecucaoFechamento()
        {
            return entity.ObterUltimaDataExecucaoFechamento();
        }

        public DateTime? ObterUltimaDataFechamento()
        {
            return entity.ObterUltimaDataFechamento();
        }

        public void GerarPreviaMes()
        {
            entity.GerarPreviaMes();
        }
	}
}