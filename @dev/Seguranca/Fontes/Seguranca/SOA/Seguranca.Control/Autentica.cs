using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;

namespace HospitalAnaCosta.SGS.Seguranca.Control
{
    public class Autentica : Control, IAutentica
    {
        private Model.Autentica entity = new Model.Autentica();

        private SegurancaDTO DtoGlobal = new SegurancaDTO();

        public SegurancaDTO Login(SegurancaDTO dto)
        {
            SegurancaDTO DTOSeguranca = new SegurancaDTO();
            DTOSeguranca =  entity.Login(dto);
            if (DTOSeguranca == null)
            {
                throw new HacException("Login ou Senha Inválido");
            }
            else if (DTOSeguranca.FlStatus.Value == (int)SegurancaDTO.Status.BLOQUEADO)
            {
                throw new HacException("Usuário BLOQUEADO");
            }
            else if (DTOSeguranca.FlStatus.Value == (int)SegurancaDTO.Status.INATIVO)
            {
                throw new HacException("Usuário INATIVO");
            }

            //UsuarioUnidadeDTO dtoUU = new UsuarioUnidadeDTO();

            //dtoUU.IdtUnidade.Value = dto.IdtUnidade.Value;
            //dtoUU.IdtUsuario.Value = DTOSeguranca.Idt.Value;

            //UsuarioUnidadeDataTable dtbUU = new UsuarioUnidade().Sel(dtoUU);

            //if (dtbUU.Rows.Count == 0 || dtbUU == null)
            //{
            //    throw new HacException("Usuário sem permissão de acesso nesta unidade");
            //}

            UnidadeLocalSetorUsuarioDTO dtoULS = new UnidadeLocalSetorUsuarioDTO();
            dtoULS.IdtUnidade.Value = dto.IdtUnidade.Value;
            dtoULS.IdtLocalAtendimento.Value = dto.IdtLocal.Value;
            dtoULS.IdtUsuario.Value = DTOSeguranca.Idt.Value;
            dtoULS.FlagStatus.Value = "A";
            UnidadeLocalSetorUsuarioDataTable dtbULS = new UnidadeLocalSetorUsuario().Sel(dtoULS);
            bool comPermissaoSetor = true;
            if (dtbULS.Rows.Count == 0)
                comPermissaoSetor = false;
            else if (dtbULS.Select(string.Format("{0}={1}", UnidadeLocalSetorUsuarioDTO.FieldNames.IdtSetor, dto.IdtSetor.Value)).Length == 0)
                comPermissaoSetor = false;

            if (!comPermissaoSetor) throw new HacException("Usuário sem permissão de acesso neste setor");
                        
            return DTOSeguranca;
        }

        public Boolean TrocaSenha(SegurancaDTO dto)
        {
            if (dto.Login.Value.IsNull)
            {
                throw new HacException("USUÁRIO NÃO PODE ESTAR EM BRANCO");
            }else if ( dto.Senha.Value.IsNull )
            {
                throw new HacException("DIGITE A SENHA ATUAL");
            }else if ( dto.NovaSenha.Value.IsNull )
            {
                throw new HacException("DIGITE A NOVA SENHA");
            }
            else if (dto.NovaSenha.Value == dto.Senha.Value)
            {
                throw new HacException("A NOVA SENHA NÃO PODE SER IDENTICA A SENHA ATUAL");
            }
            return entity.TrocaSenha(dto);
        }
       
    }
}