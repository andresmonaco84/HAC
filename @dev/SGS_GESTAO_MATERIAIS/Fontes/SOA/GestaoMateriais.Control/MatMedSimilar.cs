using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using System.Data;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class MatMedSimilar : Control, IMatMedSimilar
	{
		private Model.MatMedSimilar entity = new Model.MatMedSimilar() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public MatMedSimilarDataTable Sel(MatMedSimilarDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public MatMedSimilarDataTable ListarSimilares(MatMedSimilarDTO dto, MaterialMedicamentoDTO dtoMatMed)
        {
            MatMedSimilarDataTable similares = entity.ListarSimilares(dto, dtoMatMed);

            if (similares.Select(string.Format("{0}={1}", MatMedSimilarDTO.FieldNames.IdProduto, dto.IdProduto.Value.ToString())).Length > 0)
            {
                similares.Select(string.Format("{0}={1}", MatMedSimilarDTO.FieldNames.IdProduto, dto.IdProduto.Value.ToString()))[0].Delete();
                similares.AcceptChanges();
            }            

            return similares;
        }
        
		///<summary>
		/// Insere um registro
		/// </summary>
		public MatMedSimilarDTO Ins(MatMedSimilarDTO dto)
		{
			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(MatMedSimilarDTO dto)
		{
			entity.Del(dto);
		}

        /// <summary>
        /// Salva Similares
        /// </summary>        
        public void Grava(MatMedSimilarDataTable dtbl, ref MatMedSimilarDTO dtoSimilar)
        {            
            try
            {
                if (dtoSimilar != null && !dtoSimilar.IdProduto.Value.IsNull)
                {
                    string strItensID = dtoSimilar.IdProduto.Value;
                    foreach (DataRow row in dtbl.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            strItensID += ", " + row[MatMedSimilarDTO.FieldNames.IdProduto].ToString();
                        }
                    }
                    DataTable dtbSetoresComSimilaresDuplicados = entity.ValidarSetoresComSimilaresDuplicados(strItensID);
                    if (dtbSetoresComSimilaresDuplicados.Rows.Count > 0)
                    {
                        string setores = string.Empty;
                        foreach (DataRow rowSetor in dtbSetoresComSimilaresDuplicados.Rows)
                        {
                            if (string.IsNullOrEmpty(setores)) setores += "(";
                            else if (!string.IsNullOrEmpty(setores)) setores += ", (";
                            setores += rowSetor["SETOR_SIMILAR_DUPLICADO"].ToString() + ")";
                        }
                        throw new HacException("Não foi possível efetuar a operação, pois os seguintes setores ficariam com mais de 1 similar cadastrado no Estoque Padrão referente a estes itens:\n\n" + setores + ".\n\nFavor acertar antes o Estoque Padrão (FIXO) destes setores, deixando apenas 1 destes itens.");
                    }
                }
                MatMedSimilarDTO dto = new MatMedSimilarDTO(); decimal idPA = 0;
                foreach (DataRow row in dtbl.Rows)
                {                   
                    if (row.RowState == DataRowState.Deleted)
                    {
                        if (Convert.ToInt64(row[MatMedSimilarDTO.FieldNames.IdPrincipioAtivo, DataRowVersion.Original]) != 0)
                        {
                            dto = new MatMedSimilarDTO();

                            dto.IdPrincipioAtivo.Value = Convert.ToInt64(row[MatMedSimilarDTO.FieldNames.IdPrincipioAtivo, DataRowVersion.Original]);
                            dto.IdProduto.Value = Convert.ToInt64(row[MatMedSimilarDTO.FieldNames.IdProduto, DataRowVersion.Original]);
                            dto.IdUsuario.Value = dtoSimilar.IdUsuario.Value;

                            this.Del(dto);
                        }                        
                    }
                    else if (row.RowState == DataRowState.Added)
                    {
                        dto = (MatMedSimilarDTO)row;
                        if (idPA != 0) dto.IdPrincipioAtivo.Value = idPA;
                        dto = this.Ins(dto);
                        //Insere similar do produto pai, quando este não tinha Principio Ativo
                        if (idPA == 0 && dtoSimilar.IdPrincipioAtivo.Value.ToString() != dto.IdPrincipioAtivo.Value.ToString())
                        {
                            idPA = (decimal)dto.IdPrincipioAtivo.Value;

                            dto = new MatMedSimilarDTO();

                            dto.IdPrincipioAtivo.Value = idPA;
                            dto.IdProduto.Value = dtoSimilar.IdProduto.Value;
                            dto.IdUsuario.Value = dtoSimilar.IdUsuario.Value;
                            dto.FlAtivo.Value = (byte)MatMedSimilarDTO.Ativo.SIM;
                            this.Ins(dto);
                        }
                        else if (idPA == 0)
                        {
                            idPA = (decimal)dto.IdPrincipioAtivo.Value;
                        }
                    }
                }                
                dtbl.AcceptChanges();

                if (idPA == 0 &&
                    (dtoSimilar != null && !dtoSimilar.IdPrincipioAtivo.Value.IsNull && dtoSimilar.IdPrincipioAtivo.Value.ToString() != "0"))
                    entity.AtualizarEstoqueOnlineSimilares(dtoSimilar);

                dtoSimilar.IdPrincipioAtivo.Value = idPA;

                if (idPA > 0)
                    entity.AtualizarEstoqueOnlineSimilares(dtoSimilar);
                //else if (idPA == 0 &&
                //         (dto != null && !dto.IdPrincipioAtivo.Value.IsNull && dto.IdPrincipioAtivo.Value.ToString() != "0"))
                //    entity.AtualizarEstoqueOnlineSimilares(dto);
            }
            catch (Exception ex)
            {                
                throw new HacException(ex.Message, ex);
            }
        }
	}
}