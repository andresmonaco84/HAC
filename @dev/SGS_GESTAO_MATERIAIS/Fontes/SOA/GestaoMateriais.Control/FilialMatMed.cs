using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
// using HospitalAnaCosta.SGS.Cadastro.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class FilialMatMed : Control, IFilialMatMed
	{
		private Model.FilialMatMed entity = new Model.FilialMatMed() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public FilialMatMedDataTable Sel(FilialMatMedDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public FilialMatMedDTO SelChave(FilialMatMedDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public FilialMatMedDTO Ins(FilialMatMedDTO dto)
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
		public void Del(FilialMatMedDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(FilialMatMedDTO dto)
		{
            //PassportVO passportVO = (PassportVO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Upd(dto);
		}

        /// <summary>
        /// Retorna a filial de acordo com o tipo de plano de uma internação
        /// </summary>        
        public FilialMatMedDTO.Filial ObterFilialAtendimento(FilialMatMedDTO dto)
        {
            if (dto.TpPlano.ToString().ToUpper() == "SP" || dto.TpPlano.ToString().ToUpper() == "PA" || dto.TpPlano.ToString().ToUpper() == "FU")
            {
                return FilialMatMedDTO.Filial.HAC;
            }
            else
            {
                return FilialMatMedDTO.Filial.ACS;
            }            
        }

        public System.Data.DataTable ObterDadosFilialRM(decimal idFilial)
        {
            return entity.ObterDadosFilialRM(idFilial);
        }

        public System.Data.DataTable ObterEmpresaEmprestimo(decimal? idEmpresa)
        {
            return entity.ObterEmpresaEmprestimo(idEmpresa);
        }

        public System.Data.DataTable InserirEmpresaEmprestimo(string descricaoEmpresa, string cnpjEmpresa)
        {
            return entity.InserirEmpresaEmprestimo(descricaoEmpresa, cnpjEmpresa);
        }
	}
}