using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class ContaContabilGrupo : Control, IContaContabilGrupo
	{
		private Model.ContaContabilGrupo entity = new Model.ContaContabilGrupo() ;

		/// <summary>
		/// Listar todos os registros
		/// </summary>
        public ContaContabilGrupoDataTable Listar(ContaContabilGrupoDTO dto, byte trazerTodosGrupos)
		{
            return entity.Listar(dto, trazerTodosGrupos);
		}

		/// <summary>
		/// Obter pela chave
		/// </summary>
		public ContaContabilGrupoDTO Pesquisar(ContaContabilGrupoDTO dto)
		{	
			return entity.Pesquisar(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public ContaContabilGrupoDTO Incluir(ContaContabilGrupoDTO dto)
		{
			//PassportVO passportVO = (PassportVO)Credential;
			dto.DataAtualizacao.Value = DateTime.Now;
			//dto.IdtUsuario.Value = passportVO.Usuario.Idt;

			entity.Incluir(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Excluir(ContaContabilGrupoDTO dto)
		{
			entity.Excluir(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Alterar(ContaContabilGrupoDTO dto)
		{
			//PassportVO passportVO = (PassportVO)Credential;
            dto.DataAtualizacao.Value = DateTime.Now;
			//dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Alterar(dto);
		}

        public string ObterDescricaoContaRM(string conta)
        {
            System.Data.DataTable dtb = entity.ObterContaRM(conta);
            if (dtb.Rows.Count > 0)
                return dtb.Rows[0]["DESCRICAO"].ToString();

            return null;
        }
	}
}