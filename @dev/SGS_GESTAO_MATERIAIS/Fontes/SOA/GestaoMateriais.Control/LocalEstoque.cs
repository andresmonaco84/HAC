
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class LocalEstoque : Control, ILocalEstoque
	{
        private Model.LocalEstoque entity = new Model.LocalEstoque();

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public LocalEstoqueDataTable Sel(LocalEstoqueDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
        public LocalEstoqueDTO SelChave(LocalEstoqueDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
        public LocalEstoqueDTO Ins(LocalEstoqueDTO dto)
		{
			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
        public void Del(LocalEstoqueDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
        public void Upd(LocalEstoqueDTO dto)
		{
			entity.Upd(dto);
		}

        public void Gravar(LocalEstoqueDTO dto)
        {
            try
            {
                // BeginTransaction();

                if (dto.IdtLocalEstoque.Value.IsNull)
                {
                    dto = this.Ins(dto);
                }
                else
                {
                    this.Upd(dto);
                }

                // CommitTransaction();
            }
            catch (Exception ex)
            {
                // RollbackTransaction();
                throw new HacException(" Erro, foi realizado RollBack da transação ", ex);
            }
        }

        public LocalEstoqueDataTable EstoqueUsuario(LocalEstoqueDTO dto)
        {
            return entity.EstoqueUsuario(dto);
        }

	}
}
