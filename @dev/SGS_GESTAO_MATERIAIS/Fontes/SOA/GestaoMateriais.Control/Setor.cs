using System;
using System.Data;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class Setor : Control, ISetor
	{
		private Model.Setor entity = new Model.Setor();

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public SetorDataTable Sel(SetorDTO dto)
		{	
			return entity.Sel(dto);
		}
        
        ///<summary>
        /// Listar todos os setores que são abastecidos pelo centro de dispensação
        /// </summary>	
        public SetorDataTable SelSetoresCentroDispensacao(SetorDTO dto)
        {
            return entity.SelSetoresCentroDispensacao(dto);
        }

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public SetorDTO SelChave(SetorDTO dto)
		{	
			return entity.SelChave(dto);
		}

        /// <summary>
        /// Obter almoxarifado central. Caso não exista, retorna null.
        /// </summary>
        public SetorDTO SelAlmoxarifadoCentral()
        {
            SetorDTO dtoSetor = new SetorDTO();

            dtoSetor.FlAlmoxCentral.Value = 1;

            SetorDataTable dtbSetor = this.Sel(dtoSetor);

            if (dtbSetor.Rows.Count > 0)
            {
                dtoSetor = (SetorDTO)dtbSetor.Rows[0];
            }
            else
            {
                dtoSetor = null;
            }

            return dtoSetor;
        }
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public SetorDTO Ins(SetorDTO dto)
		{
			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(SetorDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(SetorDTO dto)
		{
			entity.Upd(dto);
		}

        ///<summary>
        /// Atualiza o campo SubstituiAlmoxarifado
        /// </summary>		
        public void UpdSubstAlmox(SetorDTO dto)
        {
            entity.UpdSubstAlmox(dto);
        }

        public SetorDataTable FiltrarSetor(SetorDataTable dtb, string filtroSql)
        {            
            if (dtb != null)
            {
                DataView dtvSetores = new DataView(dtb, filtroSql, string.Empty, DataViewRowState.OriginalRows);
           
                dtb = new SetorDataTable();

                foreach (DataRow row in dtvSetores.ToTable().Rows)
                {
                    dtb.Add((SetorDTO)row);
                }
                
            }             
            return dtb;
        }

        ///<summary>
        /// Atualiza o Flag de Almoxarifado Central
        /// </summary>		
        public void GravarAlmoxarifadoCentral(SetorDTO dtoSetor)
        {
            entity.UpdAlmoxarifadoCentral(dtoSetor);
        }

        ///<summary>
        /// Atualiza o centro de dispensação do setor
        /// </summary>		
        public void GravarCentroDispensacao(SetorDTO dtoSetor)
        {
            entity.UpdCentroDispensacao(dtoSetor);
        }

        ///<summary>
        /// Atualiza os setores que são abastecidos pelo centro de dispensação
        /// </summary>		
        public void GravarSetoresCentroDispensacao(SetorDTO dtoSetorCentroDisp, SetorDataTable dtb)
        {
            try
            {
                //BeginTransaction();
                
                DataTable dtbDeleted = dtb.GetChanges(DataRowState.Deleted);

                if (dtbDeleted != null)
                {
                    SetorDTO dtoSetorDeletar = new SetorDTO();
                    foreach (DataRow row in dtbDeleted.Rows)
                    {
                        if (!Convert.IsDBNull(row[DTO.SetorDTO.FieldNames.Idt, DataRowVersion.Original]))
                        {
                            dtoSetorDeletar.Idt.Value = row[DTO.SetorDTO.FieldNames.Idt, DataRowVersion.Original].ToString();

                            entity.UpdCentroDispensacao(dtoSetorDeletar);
                        }
                    }
                }

                foreach (DataRow row in dtb.Rows)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        dtoSetorCentroDisp.Idt.Value = row[DTO.SetorDTO.FieldNames.Idt].ToString();

                        entity.UpdCentroDispensacao(dtoSetorCentroDisp);
                    }
                }            

                //CommitTransaction();
            }
            catch (Exception ex)
            {
                //RollbackTransaction();
                //throw new HacException(" Erro, foi realizado RollBack da transação ", ex);
                throw new HacException(ex.Message, ex);
            }               
        }

        /// <summary>
        /// Retorna os Setores sem leitos
        /// </summary>
        /// <param name="idtUnidade">idtUnidade</param>
        /// <returns>DataTable</returns>

        public void Salvar(SetorDTO dtoSetor)
        {
            try
            {
                BeginTransaction();

                SetorDTO dtoSetorTemp = new SetorDTO();
                dtoSetorTemp.IdtUnidade.Value = dtoSetor.IdtUnidade.Value;
                dtoSetorTemp.IdtLocalAtendimento.Value = dtoSetor.IdtLocalAtendimento.Value;
                dtoSetorTemp.Codigo.Value = dtoSetor.Codigo.Value;

                dtoSetor.DataUltimaAtualizacao.Value = DateTime.Now.Date;
                dtoSetor.IdtUsuarioUltimaAtualizacao.Value = 1;

                SetorDataTable dtbSetor = this.Sel(dtoSetorTemp);
                if (dtbSetor.Rows.Count > 0)
                {
                    dtoSetorTemp = dtbSetor.TypedRow(0);                               
                    dtoSetor.Idt.Value = dtoSetorTemp.Idt.Value;
                    entity.Upd(dtoSetor);
                }
                else
                {
                    entity.Ins(dtoSetor);
                }
                
                CommitTransaction();
            }
            catch (System.Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }
        }

        public SetorDataTable SelSetoresCentroCusto(string centroCusto)
        {
            return entity.SelSetoresCentroCusto(centroCusto);
        }
	}
}