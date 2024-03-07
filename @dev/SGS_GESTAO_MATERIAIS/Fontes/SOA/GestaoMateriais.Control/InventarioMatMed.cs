using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class InventarioMatMed : Control, IInventarioMatMed
	{
		private Model.InventarioMatMed entity = new Model.InventarioMatMed() ;

		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public InventarioMatMedDataTable Listar(InventarioMatMedDTO dto)
		{	
			return entity.Listar(dto);
		}

        /// <summary>
        /// Listar o andamento/fechamento do inventário
        /// </summary>
        public InventarioMatMedDataTable ListarControle(InventarioMatMedDTO dto)
        {
            return entity.ListarControle(dto);
        }

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Excluir(InventarioMatMedDTO dto)
		{
			entity.Excluir(dto);
		}
                
        public void Gravar(InventarioMatMedDTO dto)
        {            
            entity.Gravar(dto, null, null);
        }

        public void Gravar(InventarioMatMedDTO dto, string codBarraImport, int? qtdeImport)
        {
            entity.Gravar(dto, codBarraImport, qtdeImport);
        }

        public void AtivarInventario(InventarioMatMedDTO dto, bool apenasMateriaisEmGeral)
        {
            entity.AtivarInventario(dto, apenasMateriaisEmGeral);
        }

        public void FecharInventario(InventarioMatMedDTO dto)
        {
            entity.FecharInventario(dto);
        }

        public DataTable ListarArquivosSalvosImportacaoPalmTXT(InventarioMatMedDTO dto)
        {
            return entity.ListarArquivosSalvosImportacaoPalmTXT(dto);
        }

        public void ExcluirArquivoSalvoImportacaoPalmTXT(InventarioMatMedDTO dto)
        {
            DataTable dtbItens = entity.ListarItensLogImportacaoPalmTXT(dto);
            if (dtbItens.Rows.Count > 0)
            {
                int qtde;
                InventarioMatMedDTO dtoInvPesquisa;
                InventarioMatMedDTO dtoExclusao = new InventarioMatMedDTO();
                dtoExclusao.Fechamento.Value = dtbItens.Rows[0][InventarioMatMedDTO.FieldNames.Fechamento].ToString();
                dtoExclusao.IdFilial.Value = dtbItens.Rows[0][InventarioMatMedDTO.FieldNames.IdFilial].ToString();
                dtoExclusao.IdSetor.Value = dtbItens.Rows[0][InventarioMatMedDTO.FieldNames.IdSetor].ToString();
                dtoExclusao.DataInventario.Value = dto.DataInventario.Value;
                dtoExclusao.IdUsuario.Value = dto.IdUsuario.Value;
                if (!dto.IdtGrupo.Value.IsNull) dtoExclusao.IdtGrupo.Value = dto.IdtGrupo.Value;
                foreach (DataRow row in dtbItens.Rows)
                {
                    if (row[InventarioMatMedDTO.FieldNames.IdProduto] == null ||
                        string.IsNullOrEmpty(row[InventarioMatMedDTO.FieldNames.IdProduto].ToString())) continue;

                    qtde = int.Parse(row["CAD_MTMD_QTDE"].ToString());

                    dtoExclusao.IdProduto.Value = row[InventarioMatMedDTO.FieldNames.IdProduto].ToString();
                    dtoExclusao.CodLote.Value = row[InventarioMatMedDTO.FieldNames.CodLote].ToString();
                    dtoExclusao.DtAtualizacao.Value = row["INV_LOG_DATA_REGISTRO"].ToString();
                    dtoExclusao.Qtde1.Value = new Framework.DTO.TypeDecimal();
                    dtoExclusao.Qtde2.Value = new Framework.DTO.TypeDecimal();
                    dtoExclusao.Qtde3.Value = new Framework.DTO.TypeDecimal();
                    dtoExclusao.QtdeFinal.Value = new Framework.DTO.TypeDecimal();

                    dtoInvPesquisa = new InventarioMatMedDTO();
                    dtoInvPesquisa.IdSetor.Value = dtoExclusao.IdSetor.Value;
                    dtoInvPesquisa.IdFilial.Value = dtoExclusao.IdFilial.Value;
                    dtoInvPesquisa.DataInventario.Value = dtoExclusao.DataInventario.Value;
                    dtoInvPesquisa.IdProduto.Value = dtoExclusao.IdProduto.Value;
                    dtoInvPesquisa.FlMedicamento.Value = dtoExclusao.CodLote.Value.ToString() == "0" ? 0 : 1;
                    if (dtoExclusao.CodLote.Value.ToString() != "0") dtoInvPesquisa.CodLote.Value = row[InventarioMatMedDTO.FieldNames.CodLote].ToString();
                    dtoInvPesquisa = this.Listar(dtoInvPesquisa).TypedRow(0);                    

                    switch ((int)(dtoExclusao.Fechamento.Value + 1))
                    {
                        case 1:
                            if (!dtoInvPesquisa.Qtde1.Value.IsNull)
                            {
                                dtoExclusao.QtdeFinal.Value = (int)dtoInvPesquisa.Qtde1.Value - qtde;
                                if (dtoExclusao.QtdeFinal.Value < 0) dtoExclusao.QtdeFinal.Value = 0;
                                dtoExclusao.Qtde1.Value = dtoExclusao.QtdeFinal.Value;
                                this.Gravar(dtoExclusao);
                            }
                            break;
                        case 2:
                            if (!dtoInvPesquisa.Qtde2.Value.IsNull)
                            {
                                dtoExclusao.QtdeFinal.Value = (int)dtoInvPesquisa.Qtde2.Value - qtde;
                                if (dtoExclusao.QtdeFinal.Value < 0) dtoExclusao.QtdeFinal.Value = 0;
                                dtoExclusao.Qtde2.Value = dtoExclusao.QtdeFinal.Value;
                                this.Gravar(dtoExclusao);
                            }
                            break;
                        case 3:
                            if (!dtoInvPesquisa.Qtde3.Value.IsNull)
                            {
                                dtoExclusao.QtdeFinal.Value = (int)dtoInvPesquisa.Qtde3.Value - qtde;
                                if (dtoExclusao.QtdeFinal.Value < 0) dtoExclusao.QtdeFinal.Value = 0;
                                dtoExclusao.Qtde3.Value = dtoExclusao.QtdeFinal.Value;
                                this.Gravar(dtoExclusao);
                            }
                            break;
                    }
                    
                    this.ExcluirItemLogImportacaoPalmTXT(dtoExclusao, row["INV_LOG_CD_BARRA"].ToString(), qtde);
                }
                dtoExclusao.DtAtualizacao.Value = dtbItens.Rows[0]["INV_LOG_DATA_INI_PROCESSO"].ToString();
                entity.ExcluirHashImportacaoPalmTXT(dtoExclusao);
            }            
        }

        public void ExcluirItemLogImportacaoPalmTXT(InventarioMatMedDTO dto, string codBarraImport, int? qtdeImport)
        {
            entity.ExcluirItemLogImportacaoPalmTXT(dto, codBarraImport, qtdeImport);
        }

        public DataTable ListarItensLogImportacaoPalmTXT(InventarioMatMedDTO dto)
        {
            return entity.ListarItensLogImportacaoPalmTXT(dto);
        }

        public DataTable ListarTXT(InventarioMatMedDTO dto)
        {
            return entity.ListarTXT(dto);
        }

        public DataTable SetoresSemContagem(DateTime dataDe, DateTime dataAte)
        {
            return entity.SetoresSemContagem(dataDe, dataAte);
        }

        /// <summary>
        /// InventarioImportado
        /// </summary>        
        /// <returns>Se já importado, retorna a Data da importação</returns>
        public DateTime? InventarioImportado(InventarioMatMedDTO dto)
        {
            InventarioMatMedDataTable dtbInv = entity.ListarControle(dto);
            if (dtbInv.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtbInv.Rows[0]["MTMD_DT_IMPORT"].ToString()))
                    return DateTime.Parse(dtbInv.Rows[0]["MTMD_DT_IMPORT"].ToString());
            }
            return null;
        }

        public bool InventarioImportando(InventarioMatMedDTO dto, DateTime _dataInicioInv)
        {
            return entity.InventarioImportando(dto, _dataInicioInv);
        }

        public void InserirHash(InventarioMatMedDTO dto, string hash)
        {
            entity.InserirHash(dto, hash);
        }

        public DataTable ListarHashImportacaoPalmTXT(InventarioMatMedDTO dto, string hash)
        {
            return entity.ListarHashImportacaoPalmTXT(dto, hash);
        }
	}
}