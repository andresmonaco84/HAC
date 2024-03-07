
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;
using HospitalAnaCosta.Services.Seguranca.Interface;

namespace HospitalAnaCosta.Services.Seguranca.Control
{
	public class PerfilFuncionalidade : Control, IPerfilFuncionalidade
	{
		private Model.PerfilFuncionalidade entity = new Model.PerfilFuncionalidade() ;

		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public PerfilFuncionalidadeDataTable Listar(PerfilFuncionalidadeDTO dto)
		{	
			return entity.Listar(dto);
		}

		/// <summary>
		/// Obter pela chave
		/// </summary>
		public PerfilFuncionalidadeDTO Pesquisar(PerfilFuncionalidadeDTO dto)
		{	
			return entity.Pesquisar(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public PerfilFuncionalidadeDTO Incluir(PerfilFuncionalidadeDTO dto)
		{
			//PassportVO passportVO = (PassportVO)Credential;
			//dto.DataUltimaAtualizacao.Value = DateTime.Now;
			//dto.IdtUsuario.Value = passportVO.Usuario.Idt;

			entity.Incluir(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Excluir(PerfilFuncionalidadeDTO dto)
		{
			entity.Excluir(dto);
		}
	}
}
