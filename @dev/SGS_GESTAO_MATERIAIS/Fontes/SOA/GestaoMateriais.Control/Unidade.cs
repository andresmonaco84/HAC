using System.Data;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class Unidade : Control, IUnidade
	{
		private Model.Unidade entity = new Model.Unidade() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        //public UnidadeDataTable Sel(UnidadeDTO dto)
        //{
        //    return entity.Sel(dto);
        //}

        public DataTable Sel(UnidadeDTO dto)
        {
            return entity.Sel(dto);
        }



        /// <summary>
        /// Obter pela chave
        /// </summary>
		public UnidadeDTO SelChave(UnidadeDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public UnidadeDTO Ins(UnidadeDTO dto)
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
		public void Del(UnidadeDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(UnidadeDTO dto)
		{
            //PassportVO passportVO = (PassportVO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Upd(dto);
		}
        ///<summary>
        /// Listar unidades ativas associadas a Locais ativos - Carrega combo unidades que internam
        /// </summary>	
        public UnidadeDataTable ListarUnidadeDoLocal(UnidadeDTO dto, int? idtLocal)
        {
            return entity.ListarUnidadeDoLocal(dto, idtLocal);
        }

        public UnidadeDataTable ListarUnidadesMaster()
        {
            return entity.ListarUnidadesMaster();
        }
	}
}
