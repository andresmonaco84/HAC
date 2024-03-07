
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;
using HospitalAnaCosta.Services.Seguranca.Interface;

namespace HospitalAnaCosta.Services.Seguranca.Control
{
	public class Modulo : Control, IModulo
	{
		private Model.Modulo entity = new Model.Modulo() ;

		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public ModuloDataTable Listar(ModuloDTO dto)
		{	
			return entity.Listar(dto);
		}

		/// <summary>
		/// Obter pela chave
		/// </summary>
		public ModuloDTO Pesquisar(ModuloDTO dto)
		{	
			return entity.Pesquisar(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public ModuloDTO Incluir(ModuloDTO dto)
		{
			//PassportVO passportVO = (PassportVO)Credential;
    		//dto.IdtUsuario.Value = passportVO.Usuario.Idt;

			entity.Incluir(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Excluir(ModuloDTO dto)
		{
			entity.Excluir(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Alterar(ModuloDTO dto)
		{
			//PassportVO passportVO = (PassportVO)Credential;
			//dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Alterar(dto);
		}

        public PassportDTO GetPassport()
        {
            return (PassportDTO)Credential;
        }
	}
}
