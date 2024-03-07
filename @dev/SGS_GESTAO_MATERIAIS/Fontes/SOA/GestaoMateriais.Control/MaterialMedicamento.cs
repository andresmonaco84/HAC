using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using System.Data;
//using HospitalAnaCosta.SGS.GestaoMateriaisView;
//using HospitalAnaCosta.SGS.Cadastro.DTO;
//using HospitalAnaCosta.SGS.Cadastro.Interface;
//using HospitalAnaCosta.SGS.Cadastro.Control;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
    public class MaterialMedicamento : Control, IMaterialMedicamento
    {
        // private Setor Setor = new Setor();
        //private static GemCommon _common;
        //private static GemCommon Common
        //{
        //    //get { return _common != null ? _common : _common = new GemCommon(dtoSeguranca); }
        //    get { return _common != null ? _common : _common = new GemCommon(null); }
        //}
        //private ISetor _setor;
        //private ISetor Setor
        //{
        //    get { return _setor != null ? _setor : _setor = (ISetor)Common.GetObject( typeof(ISetor)); }
        //}

        private Model.MaterialMedicamento entity = new Model.MaterialMedicamento();


        /// <summary>
        /// Busca consumo de 3 meses anteriores da data passada como parâmetro, o parâmetro qtdMesesAnteriores está sendo ignorada na procedure
        /// </summary>
        /// <param name="dtoMatMed"></param>
        /// <param name="qtdMesesAnteriores"></param>
        /// <returns></returns>
        public MovimentacaoDataTable ObterConsumoUltimosMeses(MaterialMedicamentoDTO dtoMatMed, byte qtdMesesAnteriores)
        {
            return entity.ObterConsumoUltimosMeses(dtoMatMed, qtdMesesAnteriores);
        }


        public decimal ObterRotatividade(MaterialMedicamentoDTO dtoMatMed, DateTime dataInicio, DateTime dataTermino)
        {
            return entity.ObterRotatividade(dtoMatMed, dataInicio, dataTermino);
        }

        /// <summary>
        /// Busca valores de Consumo/Entrada/I.R. do periodo passadado como parâmetro
        /// </summary>
        /// <param name="dtoMatMed"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataTermino"></param>
        /// <param name="consumoMedio"></param>
        /// <param name="iRotatividade"></param>
        /// <param name="Entrada"></param>
        public void ObterStatusConsumo(MaterialMedicamentoDTO dtoMatMed,
                                       DateTime dataInicio,
                                       DateTime dataTermino,
                                       out decimal consumoMedio,
                                       out decimal iRotatividade,
                                       out decimal Entrada)
        {
            entity.ObterStatusConsumo(dtoMatMed, dataInicio, dataTermino, out consumoMedio, out iRotatividade, out Entrada);
        }

        public void ObterStatusConsumo(MaterialMedicamentoDTO dtoMatMed, out decimal qtdEstoqueContabil, out DateTime? ultimoConsumo)
        {
            entity.ObterStatusConsumo(dtoMatMed, out qtdEstoqueContabil, out ultimoConsumo);
        }

        public decimal ObterCustoMedio(MovimentacaoDTO dto)
        {
            return entity.ObterCustoMedio(dto);
        }

        /// <summary>
        /// Seleciona os materiais e medicamentos os quais o setor possui permissão.
        /// Se dtoSetor = null, não filtra os registros de acordo com a permissão, 
        /// trazendo todos os registros de acordo com o dtoMatMed.
        /// </summary>    
        // public MaterialMedicamentoDataTable SelSubGrupoSetorPermissao(MaterialMedicamentoDTO dtoMatMed, SetorDTO dtoSetor)
        public MaterialMedicamentoDataTable SelSubGrupoSetorPermissao(MaterialMedicamentoDTO dtoMatMed)
        {
            // dtoMatMed.IdtUnidade.Value = dtoSetor.IdtUnidade.Value;
            // dtoMatMed.IdtLocal.Value = dtoSetor.IdtLocalAtendimento.Value;
            // dtoMatMed.IdtSetor.Value = dtoSetor.Idt.Value;
            //MaterialMedicamentoDataTable dtbMatMed = entity.Sel(dtoMatMed);

            //if (dtoMatMed != null)
            //{
            //    MatMedSetorConfig matMedSetCfg = new MatMedSetorConfig();
            //    MatMedSetorConfigDataTable dtbMatMedSetorConfig;
            //    MatMedSetorConfigDTO dtoMatMedSetorConfig = new MatMedSetorConfigDTO();
            //    MaterialMedicamentoDTO dtoMatMedAux;

            //    dtoMatMedSetorConfig.Idtsetor.Value = dtoMatMed.IdtSetor.Value;
            //    dtoMatMedSetorConfig.IdtUnidade.Value = dtoMatMed.IdtUnidade.Value;
            //    dtoMatMedSetorConfig.IdtLocal.Value = dtoMatMed.IdtLocal.Value;

            //    dtbMatMedSetorConfig = matMedSetCfg.Sel(dtoMatMedSetorConfig);

            //    for (int nCount = 0; nCount < dtbMatMed.Rows.Count; nCount++)
            //    {
            //        dtoMatMedAux = (MaterialMedicamentoDTO)dtbMatMed.Rows[nCount];
            //        //Se não encontrar o sub grupo do produto na tabela de configuração, remove ele do DataTable de retorno
            //        if (dtbMatMedSetorConfig.Select(string.Format("{0} = {1} AND {2} = {3}",
            //            MatMedSetorConfigDTO.FieldNames.IdtSubGrupo,
            //            dtoMatMedAux.IdtSubGrupo.Value,
            //            MatMedSetorConfigDTO.FieldNames.IdtGrupo,
            //            dtoMatMedAux.IdtGrupo.Value), string.Empty).Length == 0)
            //        {
            //            dtbMatMed.Rows[nCount].Delete();
            //        }                    
            //    }                

            //    dtbMatMed.AcceptChanges();
            //}

            // return dtbMatMed;
            return entity.SelSubGrupoSetorPermissao(dtoMatMed);
        }

        public MaterialMedicamentoDataTable SelSubGrupoSetorPermissao(MaterialMedicamentoDTO dtoMatMed, bool comEstoqueAlmox)
        {
            return entity.SelSubGrupoSetorPermissao(dtoMatMed, comEstoqueAlmox);
        }

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public MaterialMedicamentoDataTable Sel(MaterialMedicamentoDTO dto)
        {
            return entity.Sel(dto);
        }

        /// <summary>
        /// Obter pela chave
        /// </summary>
        public MaterialMedicamentoDTO SelChave(MaterialMedicamentoDTO dto)
        {
            return entity.SelChave(dto);
        }

        ///<summary>
        /// Insere um registro
        /// </summary>
        public MaterialMedicamentoDTO Ins(MaterialMedicamentoDTO dto)
        {
            entity.Ins(dto);
            return dto;
        }

        ///<summary>
        /// Apaga um registro
        /// </summary>		
        public void Del(MaterialMedicamentoDTO dto)
        {
            entity.Del(dto);
        }

        ///<summary>
        /// Atualiza um registro
        /// </summary>		
        public void Upd(MaterialMedicamentoDTO dto)
        {
            entity.Upd(dto);
        }

        /// <summary>
        /// Busca todas as informações do produto pelo código de barras
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MaterialMedicamentoDTO BuscaCodigoBarra(CodigoBarraDTO dto)
        {
            CodigoBarra codigoBarra = new CodigoBarra();
            CodigoBarraDataTable dtbCodigoBarra = new CodigoBarraDataTable();

            MaterialMedicamento MatMed = new MaterialMedicamento();
            MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
            // MaterialMedicamentoDataTable dtbMatMed = new MaterialMedicamentoDataTable();
            dtbCodigoBarra = codigoBarra.Sel(dto, null);
            if (dtbCodigoBarra.Rows.Count == 0) return null;
            dtoMatMed.Idt.Value = Convert.ToDecimal(dtbCodigoBarra.Rows[0][CodigoBarraDTO.FieldNames.IdtProduto].ToString());
            dtoMatMed = MatMed.SelChave(dtoMatMed);
            dtoMatMed.IdtLote.Value = Convert.ToDecimal(dtbCodigoBarra.Rows[0][CodigoBarraDTO.FieldNames.IdtLote].ToString());
            dtoMatMed.IdtFilial.Value = dto.IdtFilial.Value;
            return dtoMatMed;

        }

        public MaterialMedicamentoDTO InfoContabil(MaterialMedicamentoDTO dto)
        {
            // para mater as informações ja carregadas no dto
            MaterialMedicamentoDTO dtoBusca = new MaterialMedicamentoDTO();
            dtoBusca.Idt.Value = dto.Idt.Value;
            dtoBusca.IdtFilial.Value = dto.IdtFilial.Value;
            dtoBusca = entity.InfoContabil(dtoBusca);
            if (dtoBusca != null)
            {
                dto.CustoMedio.Value = dtoBusca.CustoMedio.Value;
                dto.DtUltimoConsumo.Value = dtoBusca.DtUltimoConsumo.Value;
                dto.QtdeEstoqueContabil.Value = dtoBusca.QtdeEstoqueContabil.Value;
            }

            return dto;
        }

        public void InserirMarca(decimal idProduto, decimal numMarca, string descricaoMarca, decimal idUsuario)
        {
            entity.InserirMarca(idProduto, numMarca, descricaoMarca, idUsuario);
        }

        public void AtualizarMarca(decimal idProduto, decimal numMarca, string descricaoMarca, decimal idUsuario)
        {
            entity.AtualizarMarca(idProduto, numMarca, descricaoMarca, idUsuario);
        }

        public void ExcluirMarca(decimal idProduto, decimal numMarca)
        {
            entity.ExcluirMarca(idProduto, numMarca);
        }

        public DataTable SelMarcas(decimal idProduto)
        {
            return entity.SelMarcas(idProduto);
        }

        public DataTable SelEnderecos(decimal idProduto)
        {
            return entity.SelEnderecos(idProduto);
        }

        public void AtualizarEnderecos(decimal idProduto, decimal? numEndHAC, decimal? numEndACS)
        {
            entity.AtualizarEnderecos(idProduto, numEndHAC, numEndACS);
        }

        public bool ProdutoPedidoAutomatico(MaterialMedicamentoDTO dtoMatMed)
        {
            if (decimal.Parse(dtoMatMed.Tabelamedica.Value.ToString()) == (decimal)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO && 
                dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.NAO)
                return true;

            return false;
        }

        public void AtualizarDiluente(MaterialMedicamentoDTO dto)
        {
            entity.AtualizarDiluente(dto);
        }

        public void AtualizarPrincipioAtivo(MaterialMedicamentoDTO dto)
        {
            entity.AtualizarPrincipioAtivo(dto);
        }
    }
}