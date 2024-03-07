
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using System.Data;

namespace HospitalAnaCosta.SGS.Seguranca.Control
{
	public class AssPerfilFuncionalidade : Control, IAssPerfilFuncionalidade
	{
		private Model.AssPerfilFuncionalidade entity = new Model.AssPerfilFuncionalidade() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public AssPerfilFuncionalidadeDataTable Sel(AssPerfilFuncionalidadeDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public AssPerfilFuncionalidadeDTO SelChave(AssPerfilFuncionalidadeDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public AssPerfilFuncionalidadeDTO Ins(AssPerfilFuncionalidadeDTO dto)
		{
            //PassportDTO passportVO = (PassportDTO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;

			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(AssPerfilFuncionalidadeDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(AssPerfilFuncionalidadeDTO dto)
		{
            //PassportDTO passportVO = (PassportDTO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Upd(dto);
		}
         public DataTable ListarUsuarioSistemaUnidadeModuloPerfilFuncionalidade(int? idtUsuario, int? idtSistema, int? idtUnidade, int? idtModulo, int? idtPerfil, int? idtFuncionalidade)
        {
            return entity.ListarUsuarioSistemaUnidadeModuloPerfilFuncionalidade(idtUsuario, idtSistema, idtUnidade, idtModulo, idtPerfil, idtFuncionalidade);
        }
	}
}
