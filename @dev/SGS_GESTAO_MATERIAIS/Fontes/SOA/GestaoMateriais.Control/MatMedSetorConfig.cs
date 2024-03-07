using System;
using System.Text;
using HospitalAnaCosta.Framework;
using System.Data;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
    public class MatMedSetorConfig : Control, IMatMedSetorConfig
    {
        private Setor Setor = new Setor();

        private Model.MatMedSetorConfig entity = new Model.MatMedSetorConfig();

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public MatMedSetorConfigDataTable Sel(MatMedSetorConfigDTO dto)
        {
            return entity.Sel(dto);
        }

        /// <summary>
        /// Obter pela chave
        /// </summary>
        public MatMedSetorConfigDTO SelChave(MatMedSetorConfigDTO dto)
        {
            return entity.SelChave(dto);
        }

        ///<summary>
        /// Insere um registro
        /// </summary>
        public MatMedSetorConfigDTO Ins(MatMedSetorConfigDTO dto)
        {
            entity.Ins(dto);
            return dto;
        }

        ///<summary>
        /// Apaga um registro
        /// </summary>		
        public void Del(MatMedSetorConfigDTO dto)
        {
            entity.Del(dto);
        }

        /// <summary>
        /// Grava as configurações referentes ao setor
        /// </summary>        
        public void Gravar(SetorDTO dtoSetor,
                           MatMedSetorConfigDTO dtoMatMedSetorConfig, 
                           MatMedSetorConfigDataTable dtbMatMedSetorConfig,
                           SetorDataTable dtbSetoresCentroDisp)
        {
            try
            {
                //BeginTransaction();

                Setor.GravarAlmoxarifadoCentral(dtoSetor);
                Setor.UpdSubstAlmox(dtoSetor);

                SetorDTO dtoSetorAlmoxCentral = Setor.SelAlmoxarifadoCentral();

                //Se o setor é o Almoxarifado Central ou um Centro de Dispensação, ou ainda o Centro de Dispensação é o
                //Almoxarifado Central, limpa os campos referente ao Centro de Dispensação do setor
                if (dtoSetor.SetorAlmoxarifado.Value.IsNull ||
                    dtoSetor.SetorAlmoxarifado.Value.ToString() == dtoSetorAlmoxCentral.Idt.Value.ToString() ||
                    dtoSetorAlmoxCentral.Idt.Value.ToString() == dtoSetor.Idt.Value.ToString() ||
                    dtoSetorAlmoxCentral.SetorAlmoxarifado.Value == "S")
                {
                    dtoSetor.UnidadeAlmoxarifado.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
                    dtoSetor.LocalAlmoxarifado.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
                    dtoSetor.SetorAlmoxarifado.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
                }                

                //Atualiza o Centro de Dispensação do setor
                Setor.GravarCentroDispensacao(dtoSetor);

                if (dtbMatMedSetorConfig != null)
                {
                    DataTable dtbAdded = dtbMatMedSetorConfig.GetChanges(DataRowState.Added);
                    DataTable dtbDeleted = dtbMatMedSetorConfig.GetChanges(DataRowState.Deleted);

                    if (dtbDeleted != null)
                    {
                        foreach (DataRow row in dtbDeleted.Rows)
                        {
                            if (!Convert.IsDBNull(row[SubGrupoMatMedDTO.FieldNames.Idt, DataRowVersion.Original]) &&
                                !Convert.IsDBNull(row[SubGrupoMatMedDTO.FieldNames.IdtGrupo, DataRowVersion.Original]))
                            {
                                dtoMatMedSetorConfig.IdtSubGrupo.Value = Convert.ToInt64(row[SubGrupoMatMedDTO.FieldNames.Idt, DataRowVersion.Original]);
                                dtoMatMedSetorConfig.IdtGrupo.Value = Convert.ToInt64(row[SubGrupoMatMedDTO.FieldNames.IdtGrupo, DataRowVersion.Original]);

                                this.Del(dtoMatMedSetorConfig);
                            }
                        }
                    }
                    else if (dtbAdded != null)
                    {
                        dtoMatMedSetorConfig.IdtGrupo.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
                        dtoMatMedSetorConfig.IdtSubGrupo.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();

                        //Deleta todos os subgrupos do setor antes de adicionar a nova lista,
                        //pois todas as rows são DataRowState.Added
                        this.Del(dtoMatMedSetorConfig);

                        //Atualiza os subgrupos de mat/med de acesso do setor
                        foreach (DataRow row in dtbAdded.Rows)
                        {
                            dtoMatMedSetorConfig.IdtSubGrupo.Value = Convert.ToInt64(row[SubGrupoMatMedDTO.FieldNames.Idt]);
                            dtoMatMedSetorConfig.IdtGrupo.Value = Convert.ToInt64(row[SubGrupoMatMedDTO.FieldNames.IdtGrupo]);

                            this.Ins(dtoMatMedSetorConfig);
                        }
                    }
                    else if (dtbAdded == null && dtbMatMedSetorConfig.Rows.Count == 0) //Não foi nada deletado de forma unitária, nada adicionado e não há nenhum registro em memória, deleta tudo do setor
                    {
                        dtoMatMedSetorConfig.IdtGrupo.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
                        dtoMatMedSetorConfig.IdtSubGrupo.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();

                        this.Del(dtoMatMedSetorConfig);
                    }                        
                }            
           
                //Se o setor é um centro de dispensação, grava os setores os quais são abastecidos por ele
                if (dtbSetoresCentroDisp != null)
                {
                    if (dtbSetoresCentroDisp.Rows.Count != 0)
                    {
                        dtoSetor.UnidadeAlmoxarifado.Value = dtoSetor.IdtUnidade.Value;
                        dtoSetor.LocalAlmoxarifado.Value = dtoSetor.IdtLocalAtendimento.Value;
                        dtoSetor.SetorAlmoxarifado.Value = dtoSetor.Idt.Value;

                        Setor.GravarSetoresCentroDispensacao(dtoSetor, dtbSetoresCentroDisp);
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

        public MatMedSetorConfigDTO ConverteRequisicaoMatMedSetorConfig(RequisicaoDTO dto)
        {
            MatMedSetorConfigDTO dtoMatMedSetorConfig = new MatMedSetorConfigDTO();
            if (dto != null)
            {
                dtoMatMedSetorConfig.IdtLocal = dto.IdtLocal;
                dtoMatMedSetorConfig.IdtUnidade = dto.IdtUnidade;
                dtoMatMedSetorConfig.Idtsetor = dto.IdtSetor;
            }
            return dtoMatMedSetorConfig;
        }

        public MatMedSetorConfigDTO ConvertePedidoPadraoMatMedSetorConfig(PedidoPadraoDTO dto)
        {
            MatMedSetorConfigDTO dtoMatMedSetorConfig = new MatMedSetorConfigDTO();
            if (dto != null)
            {
                dtoMatMedSetorConfig.IdtLocal = dto.IdtLocal;
                dtoMatMedSetorConfig.IdtUnidade = dto.IdtUnidade;
                dtoMatMedSetorConfig.Idtsetor = dto.IdtSetor;
            }
            return dtoMatMedSetorConfig;
        }


        public MatMedSetorConfigDTO SetorCfg(MatMedSetorConfigDTO dto)
        {
            return entity.SetorCfg(dto);
        }

        public void SetorCfgSalvar(MatMedSetorConfigDTO dto)
        {
            entity.SetorCfgSalvar(dto);
        }

        /// <summary>
        /// Obtem em qual estoque a unidade vai consumir
        /// </summary>
        /// <param name="dto">Unidade que desejo saber onde cosumir</param>
        /// <returns>Estoques onde esta undiade vai consumir</returns>
        public SetorEstoqueConsumoDataTable SetorEstoqueConsumoObter(SetorEstoqueConsumoDTO dto)
        {
            return entity.SetorEstoqueConsumoObter(dto);
        }

        /// <summary>
        /// Salva em qual estoque a unidade vai consumir
        /// </summary>
        /// <param name="dto">Unidade sem estoque que vai buscar em outro setor</param>
        public void SetorEstoqueConsumoSalvar(SetorEstoqueConsumoDTO dto)
        {
            entity.SetorEstoqueConsumoSalvar(dto);

        }

        /// <summary>
        /// Exclui estoque que a undiade consume
        /// </summary>
        /// <param name="dto"></param>
        public void SetorEstoqueConsumoExcluir(SetorEstoqueConsumoDTO dto)
        {
            entity.SetorEstoqueConsumoExcluir(dto);

        }

        /// <summary>
        /// Obtem unidades que consomem do estoque passado como parâmetro
        /// </summary>
        /// <param name="dto">Unidade para consulta</param>
        /// <returns></returns>
        public SetorEstoqueConsumoDataTable SetorEstoqueUnidadesQueConsomemObter(SetorEstoqueConsumoDTO dto)
        {
           return entity.SetorEstoqueUnidadesQueConsomemObter(dto);
        }

        /// <summary>
        /// Verifica se Setor tem Acesso ao Produto sendo movimentado
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Verdadeiro/Falso</returns>
        public bool SetorAcessoProduto(MovimentacaoDTO dto)
        {
            return entity.SetorAcessoProduto(dto);
        }

        public bool ControlaConsumoPacienteSetor(MatMedSetorConfigDTO dtoSetorConfig, out DateTime? dtInicioControle)
        {
            dtInicioControle = null;
            dtoSetorConfig = SetorCfg(dtoSetorConfig);
            if (dtoSetorConfig.ControlaConsumoPaciente.Value.IsNull) dtoSetorConfig.ControlaConsumoPaciente.Value = 0;
            if (dtoSetorConfig.ControlaConsumoPaciente.Value == 1 && !dtoSetorConfig.DataControlaConsumoPaciente.Value.IsNull)
            {
                dtInicioControle = dtoSetorConfig.DataControlaConsumoPaciente.Value;
                return true;
            }

            return false;
        }

        public DateTime? DataUltimaGeracaoPedidosAutomaticosFarmacia()
        {
            return entity.DataUltimaGeracaoPedidosAutomaticosFarmacia();
        }

        public void GerarPedidosAutomaticosFarmacia(bool gerando, bool atualizarData)
        {
            entity.GerarPedidosAutomaticosFarmacia(gerando, atualizarData);
        }

        public bool GerandoPedidosAutomaticosFarmacia()
        {
            return entity.GerandoPedidosAutomaticosFarmacia();
        }
    }
}