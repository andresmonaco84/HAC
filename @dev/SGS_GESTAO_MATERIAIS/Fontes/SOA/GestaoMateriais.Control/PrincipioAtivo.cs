
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using System.Data;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class PrincipioAtivo : Control, IPrincipioAtivo
	{
		private Model.PrincipioAtivo entity = new Model.PrincipioAtivo() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public PrincipioAtivoDataTable Sel(PrincipioAtivoDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
        public PrincipioAtivoDTO SelChave(PrincipioAtivoDTO dto)
		{	
			return entity.SelChave(dto);
		}

        /// <summary>
        /// Lista Materiais e Medicamentos relacionado ao principio ativo
        /// </summary>
        /// <param name="dto">PrincipioAtivoDTO</param>
        /// <returns>MaterialMedicamentoDataTable</returns>
        public MaterialMedicamentoDataTable SelMatMed(PrincipioAtivoDTO dto, MaterialMedicamentoDTO dtoMatMed)
        {
            if (int.Parse(dto.Idt.Value) != 0)
            {
                return entity.SelMatMed(dto, dtoMatMed);
            }
            else
            {
                return new MaterialMedicamentoDataTable();
            }
        }
		
		///<summary>
		/// Insere um registro
		/// </summary>
        public PrincipioAtivoDTO Ins(PrincipioAtivoDTO dto)
		{
			entity.Ins(dto);
			return dto;
		}
		///<summary>
		/// Apaga um registro
		/// </summary>		
        private void Del(PrincipioAtivoDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
        public void Upd(PrincipioAtivoDTO dto)
		{		
			entity.Upd(dto);
		}

        /// <summary>
        /// Salva Principio Ativo
        /// </summary>
        /// <param name="datatable"></param>         
        public PrincipioAtivoDataTable Grava( PrincipioAtivoDataTable dtbl)
        {
            try
            {
                //BeginTransaction();
                foreach (DataRow row in dtbl.Rows)
                {
                    PrincipioAtivoDTO dto = (PrincipioAtivoDTO)row;

                    if (row.RowState == DataRowState.Added)
                    {
                        this.Ins(dto);
                    }
                    if (row.RowState == DataRowState.Modified)
                    {
                        this.Upd(dto);
                    }                    
                    // Verifica linhas excluídas no GRID
                }

                DataTable dtbDeleted = dtbl.GetChanges(DataRowState.Deleted);
                if (dtbDeleted != null)
                {
                    PrincipioAtivoDTO dtoDel;
                    foreach (DataRow row in dtbDeleted.Rows)
                    {
                        if (!Convert.IsDBNull(row[DTO.PrincipioAtivoDTO.FieldNames.Idt, DataRowVersion.Original]))
                        {
                            dtoDel = new PrincipioAtivoDTO();
                            dtoDel.Idt.Value = Convert.ToInt64(row[PrincipioAtivoDTO.FieldNames.Idt, DataRowVersion.Original]);
                            dtoDel.DsPrincipioAtivo.Value = row[PrincipioAtivoDTO.FieldNames.DsPrincipioAtivo, DataRowVersion.Original].ToString();
                            this.Del(dtoDel);
                        }
                    }
                }
                //CommitTransaction();
                dtbl.AcceptChanges();
                return dtbl;
            }
            catch (Exception ex)
            {
                // RollbackTransaction();
                //throw new HacException(" Erro, foi realizado RollBack da transação ", ex);
                throw new HacException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Insere um matmed na lista de similares do Principio ativo
        /// </summary>
        /// <param name="dto"></param>
        private void InsMatMed(MaterialMedicamentoDTO dto)
        {
            entity.InsMatMed(dto);
        }

        /// <summary>
        /// Exclui matmed da relação de similares do principio ativo
        /// </summary>
        /// <param name="dto"></param>
        private void DelMatMed(MaterialMedicamentoDTO dto)
        {
            entity.DelMatMed(dto);
        }

        /// <summary>
        /// Salva todas as alterações nos similares do principio ativo
        /// </summary>
        /// <param name="dtbl"></param>
        public MaterialMedicamentoDataTable GravaSimilares(MaterialMedicamentoDataTable dtbl)
        {
            try
            {
                //BeginTransaction();
                foreach (DataRow row in dtbl.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        MaterialMedicamentoDTO dto = (MaterialMedicamentoDTO)row;

                        if (row.RowState == DataRowState.Added)
                        {
                            this.InsMatMed(dto);
                        }
                    }                    
                }

                DataTable dtbDeleted = dtbl.GetChanges(DataRowState.Deleted);
                if (dtbDeleted != null)
                {
                    MaterialMedicamentoDTO dtoDel;
                    foreach (DataRow row in dtbDeleted.Rows)
                    {
                        if (!Convert.IsDBNull(row[DTO.MaterialMedicamentoDTO.FieldNames.Idt, DataRowVersion.Original]))
                        {
                            dtoDel = new MaterialMedicamentoDTO();
                            dtoDel.Idt.Value = Convert.ToInt64(row[MaterialMedicamentoDTO.FieldNames.Idt, DataRowVersion.Original]);
                            dtoDel.IdtPrincipioAtivo.Value = row[MaterialMedicamentoDTO.FieldNames.IdtPrincipioAtivo, DataRowVersion.Original].ToString();
                            this.DelMatMed(dtoDel);
                        }
                    }
                }
                //CommitTransaction();
                dtbl.AcceptChanges();
                return dtbl;
            }
            catch (Exception ex)
            {
                // RollbackTransaction();
                //throw new HacException(" Erro, foi realizado RollBack da transação ", ex);
                throw new HacException(ex.Message, ex);
            }
        }

	}
}
