
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class CodigoBarra : Control, ICodigoBarra
	{
		private Model.CodigoBarra entity = new Model.CodigoBarra() ;

        public CodigoBarraDataTable SelMedicamentoSemNF(HistoricoNotaFiscalDTO dtoHNF, decimal idUsuario, decimal idSetorMov)
        {
            return entity.SelMedicamentoSemNF(dtoHNF, idUsuario, idSetorMov);
        }

        /// <summary>
        /// Listar o cod. barra avulso
        /// </summary>
        public CodigoBarraDTO SelAvulso(CodigoBarraDTO dto, decimal idUsuario)
        {
            return entity.SelAvulso(dto, idUsuario);
        }

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public CodigoBarraDataTable Sel(CodigoBarraDTO dto, decimal? idUsuario)
		{
            return entity.Sel(dto, idUsuario);
		}
        
		///<summary>
		/// Insere um registro
		/// </summary>
		public CodigoBarraDTO Ins(CodigoBarraDTO dto)
		{
            //PassportVO passportVO = (PassportVO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;

			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(CodigoBarraDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(CodigoBarraDTO dto)
		{
            //PassportVO passportVO = (PassportVO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Upd(dto);
		}


        /// <summary>
        /// Verifica se um código de barras já está associado a um produto.
        /// </summary>
        /// <param name="dto">Objeto contendo as informações que serão usadas para a pesquisa.</param>
        public bool Existe(CodigoBarraDTO dto)
        {            
            CodigoBarraDataTable dataTableCodigoBarra = this.Sel(dto, null);

            return (dataTableCodigoBarra.Rows.Count > 0);            
        }


        /// <summary>
        /// Insere ou atualiza um registro.
        /// </summary>
        /// <param name="dto">Objeto contendo os valores.</param>
        public void Gravar(CodigoBarraDTO dto)
        {           
            // BeginTransaction();

            this.Ins(dto);
            
            // CommitTransaction();            
        }

        /// <summary>
        /// Caso não possua cod. barra, retorna próprio ID
        /// </summary>
        /// <param name="idFilial"></param>
        /// <param name="idProduto"></param>
        /// <returns></returns>
        public string ObterCodigo(decimal idFilial, decimal idProduto)
        {
            return entity.ObterCodigo(idFilial, idProduto);
        }
	}
}
