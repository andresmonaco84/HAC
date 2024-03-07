
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;
using HospitalAnaCosta.Services.Seguranca.Interface;

namespace HospitalAnaCosta.Services.Seguranca.Control
{
	public class Funcionalidade : Control, IFuncionalidade
	{
		private Model.Funcionalidade entity = new Model.Funcionalidade() ;

		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public FuncionalidadeDataTable Listar(FuncionalidadeDTO dto)
		{	
			return entity.Listar(dto);
		}

		/// <summary>
		/// Obter pela chave
		/// </summary>
		public FuncionalidadeDTO Pesquisar(FuncionalidadeDTO dto)
		{	
			return entity.Pesquisar(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public FuncionalidadeDTO Incluir(FuncionalidadeDTO dto)
		{
			//PassportVO passportVO = (PassportVO)Credential;
			//dto.IdtUsuario.Value = passportVO.Usuario.Idt;

			entity.Incluir(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Excluir(FuncionalidadeDTO dto)
		{
			entity.Excluir(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Alterar(FuncionalidadeDTO dto)
		{
			//PassportVO passportVO = (PassportVO)Credential;
    		//dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Alterar(dto);
		}

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public FuncionalidadeDataTable ListarPorUsuarioUnidade(decimal idtUnidade, UsuarioDTO dtoUsuario, decimal idtModulo)
        {
            return entity.ListarPorUsuarioUnidade(idtUnidade, dtoUsuario, idtModulo);
        }

        /// <summary>
        /// Listar por Módulo
        /// </summary>
        public FuncionalidadeDataTable ListarPorModulo(decimal idtModulo)
        {
            return entity.ListarPorModulo(idtModulo);
        }

        public FuncionalidadeDataTable ListarPorUsuario(UsuarioDTO dtoUsuario, decimal? idtModulo)
        {
            return entity.ListarPorUsuario(dtoUsuario, idtModulo);
        }
	}
}
