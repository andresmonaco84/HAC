
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;

namespace HospitalAnaCosta.SGS.Seguranca.Control
{
	public class Funcionalidade : Control, IFuncionalidade
	{
		private Model.Funcionalidade entity = new Model.Funcionalidade() ;        
        
        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public FuncionalidadeDataTable Sel(FuncionalidadeDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public FuncionalidadeDTO SelChave(FuncionalidadeDTO dto)
		{	
			return entity.SelChave(dto);
		}

	
		///<summary>
		/// Insere um registro
		/// </summary>
		public FuncionalidadeDTO Ins(FuncionalidadeDTO dto)
		{
            //PassportDTO passportVO = (PassportDTO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;
			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(FuncionalidadeDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(FuncionalidadeDTO dto)
		{
            //PassportDTO passportVO = (PassportDTO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;
			entity.Upd(dto);
		}

        public FuncionalidadeDTO Gravar(FuncionalidadeDTO dto)
        {
            if (dto.Idt.Value.IsNull)
            {
                entity.Ins(dto);
            }
            else
            {
                entity.Upd(dto);
            }
            return dto;
        }
	}
}
