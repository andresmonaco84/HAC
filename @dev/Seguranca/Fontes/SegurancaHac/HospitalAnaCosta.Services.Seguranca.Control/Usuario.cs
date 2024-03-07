using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;
using HospitalAnaCosta.Services.Seguranca.Interface;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.SGS.Cadastro.Control;
using System.Configuration;

namespace HospitalAnaCosta.Services.Seguranca.Control
{
    public class Usuario : Control, IUsuario
    {
        private Model.Usuario entity = new Model.Usuario();

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public UsuarioDataTable Listar(UsuarioDTO dto)
        {
            return entity.Listar(dto);
        }

        /// <summary>
        /// Obter pela chave
        /// </summary>
        public UsuarioDTO Pesquisar(UsuarioDTO dto)
        {
            return entity.Pesquisar(dto);
        }

        ///<summary>
        /// Insere um registro
        /// </summary>
        public UsuarioDTO Incluir(UsuarioDTO dto)
        {
            PassportDTO dtoPassport = (PassportDTO)Credential;
            dto.DataUltimaAtualizacao.Value = DateTime.Now;
            dto.IdtUsuarioAtualizacao.Value = dtoPassport.Usuario.Idt.Value;

            entity.Incluir(dto);
            return dto;
        }

        ///<summary>
        /// Apaga um registro
        /// </summary>		
        public void Excluir(UsuarioDTO dto)
        {
            entity.Excluir(dto);
        }

        ///<summary>
        /// Atualiza um registro
        /// </summary>		
        public void Alterar(UsuarioDTO dto)
        {
            PassportDTO dtoPassport = (PassportDTO)Credential;
            dto.DataUltimaAtualizacao.Value = DateTime.Now;
            if (dtoPassport != null)
                dto.IdtUsuarioAtualizacao.Value = dtoPassport.Usuario.Idt.Value;
            
            entity.Alterar(dto);
        }

        /// <summary>
        /// Realiza a autenticação no sistema, retornando usuário e status da autenticação
        /// </summary>
        /// <param name="idtUnidade"></param>
        /// <param name="login">Login do usuário</param>
        /// <param name="senha">Senha</param>
        /// <param name="idtLocal"></param>
        /// <param name="idtSetor"></param>
        /// <returns>PassportAuthenticationVO</returns>
        /// 
        public PassportAuthenticationDTO Autenticar(int idtUnidade, string login, string senha, int idtLocal, int idtSetor)
        {
            PassportAuthenticationDTO enPassportAuthenticationDTO = Autenticar(login, senha);
            string message = string.Empty;

            UsuarioDTO dtoUsuario = enPassportAuthenticationDTO.Usuario;

            //OK
            if (message == string.Empty)
            {
                #region "Verifica se é necesário trocar senha"

                if (dtoUsuario.FlagTrocarSenha.Value == "S")
                {
                    enPassportAuthenticationDTO.PassportAuthenticationStatus =
                        PassportAuthenticationDTO.PassportAuthenticationStatusEnum.NecessarioTrocarSenha;
                    message = "Operação não realizada!!! \n Trocar Senha!!! É necessário que você altere sua senha.";
                }

                #endregion
            }

            //OK
            if (message == string.Empty)
            {
                #region "Verifica Senha Expirada"

                if (dtoUsuario.DataExpiracaoSenha.Value <= DateTime.Now.Date &&
                    dtoUsuario.FlagSenhaNaoExpira.Value == "N")
                {
                    enPassportAuthenticationDTO.PassportAuthenticationStatus =
                        PassportAuthenticationDTO.PassportAuthenticationStatusEnum.SenhaExpirada;
                    message = "Operação não realizada!!! \n Senha Expirada!!! É necessário que você altere sua senha.";
                }

                #endregion
            }

            //OK
            #region "Verifica se Usuário pertence à Unidade informada"

            UsuarioUnidade usuarioUnidade = new UsuarioUnidade();
            UsuarioUnidadeDTO dtoUsuarioUnidade = new UsuarioUnidadeDTO();

            dtoUsuarioUnidade.IdtUsuario.Value = dtoUsuario.Idt.Value;

            UsuarioUnidadeDataTable dtbUsuarioUnidade = usuarioUnidade.Listar(dtoUsuarioUnidade);
            
            bool blnPertenceAUnidade = false;

            if (dtbUsuarioUnidade.Rows.Count > 0)
            {
                foreach (UsuarioUnidadeDTO dtoUsuarioUnidadeFor in dtbUsuarioUnidade)
                {
                    if (dtoUsuarioUnidadeFor.IdtUnidade.Value == idtUnidade)
                    {
                        blnPertenceAUnidade = true;
                        break;
                    }
                }
                if (!blnPertenceAUnidade)
                {
                    enPassportAuthenticationDTO.PassportAuthenticationStatus =
                        PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioNaoPertenceAUnidade;
                    message = "Operação não realizada!!! \n Usuário não pertence a Unidade informada, altere a Unidade.";
                }
            }

            #endregion


            if (message == string.Empty)
            {
                //OK
                #region "Verifica se Usuário pertence ao local informado"

                UnidadeLocalSetorUsuario unidadeLocalSetorUsuarioLocal = new UnidadeLocalSetorUsuario();
                UnidadeLocalSetorUsuarioDTO dtoUnidadeLocalSetorUsuarioLocal = new UnidadeLocalSetorUsuarioDTO();

                dtoUnidadeLocalSetorUsuarioLocal.IdtUsuario.Value = dtoUsuario.Idt.Value;

                UnidadeLocalSetorUsuarioDataTable dtbUnidadeLocalSetorUsuarioLocal =
                    unidadeLocalSetorUsuarioLocal.Listar(dtoUnidadeLocalSetorUsuarioLocal);

                bool blnPertenceLocal = false;
                if (dtbUnidadeLocalSetorUsuarioLocal.Rows.Count > 0)
                {
                    foreach (
                        UnidadeLocalSetorUsuarioDTO dtoUnidadeLocalSetorUsuarioFor in dtbUnidadeLocalSetorUsuarioLocal)
                    {
                        if (dtoUnidadeLocalSetorUsuarioFor.IdtLocalAtendimento.Value == idtLocal)
                        {
                            blnPertenceLocal = true;
                            break;
                        }
                    }
                    if (!blnPertenceLocal)
                    {
                        enPassportAuthenticationDTO.PassportAuthenticationStatus =
                            PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioNaoPertenceALocal;
                        message = "Operação não realizada!!! \n Usuário não pertence ao Local informado, altere o Local.";
                    }
                }

                #endregion
            }

            if (message == string.Empty)
            {
                //OK

                #region "Verifica se Usuário pertence ao Setor informado"

                UnidadeLocalSetorUsuario unidadeLocalSetorUsuario = new UnidadeLocalSetorUsuario();
                UnidadeLocalSetorUsuarioDTO dtoUnidadeLocalSetorUsuario = new UnidadeLocalSetorUsuarioDTO();

                dtoUnidadeLocalSetorUsuario.IdtUsuario.Value = dtoUsuario.Idt.Value;

                UnidadeLocalSetorUsuarioDataTable dtbUnidadeLocalSetorUsuario =
                    unidadeLocalSetorUsuario.Listar(dtoUnidadeLocalSetorUsuario);

                bool blnPertenceSetor = false;
                if (dtbUnidadeLocalSetorUsuario.Rows.Count > 0)
                {
                    foreach (UnidadeLocalSetorUsuarioDTO dtoUnidadeLocalSetorUsuarioFor in dtbUnidadeLocalSetorUsuario)
                    {
                        if (dtoUnidadeLocalSetorUsuarioFor.IdtSetor.Value == idtSetor)
                        {
                            blnPertenceSetor = true;
                            break;
                        }
                    }
                    if (!blnPertenceSetor)
                    {
                        enPassportAuthenticationDTO.PassportAuthenticationStatus =
                            PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioNaoPerteceASetor;
                        message =
                            "Operação não realizada!!! \n Usuário não pertence ao Setor informado, altere o setor.";
                    }
                }

                #endregion
            }

            if (message != string.Empty)
            {
                throw new HacException(message);
            }

            return enPassportAuthenticationDTO;
       
        }

        public PassportAuthenticationDTO AutenticarParaProntuarioEletronico(int idtUnidade, string login, string senha, int idtLocal, int idtSetor)
        {
            PassportAuthenticationDTO enPassportAuthenticationDTO = AutenticarParaProntuarioEletronico(login, senha);
            string message = string.Empty;

            UsuarioDTO dtoUsuario = enPassportAuthenticationDTO.Usuario;

            //OK
            if (message == string.Empty)
            {
                #region "Verifica se é necesário trocar senha"

                if (dtoUsuario.FlagTrocarSenha.Value == "S")
                {
                    enPassportAuthenticationDTO.PassportAuthenticationStatus =
                        PassportAuthenticationDTO.PassportAuthenticationStatusEnum.NecessarioTrocarSenha;
                    message = "Operação não realizada!!! \n Trocar Senha!!! É necessário que você altere sua senha.";
                }

                #endregion
            }

            //OK
            if (message == string.Empty)
            {
                #region "Verifica Senha Expirada"

                if (dtoUsuario.DataExpiracaoSenha.Value <= DateTime.Now.Date &&
                    dtoUsuario.FlagSenhaNaoExpira.Value == "N")
                {
                    enPassportAuthenticationDTO.PassportAuthenticationStatus =
                        PassportAuthenticationDTO.PassportAuthenticationStatusEnum.SenhaExpirada;
                    message = "Operação não realizada!!! \n Senha Expirada!!! É necessário que você altere sua senha.";
                }

                #endregion
            }

            //OK
            #region "Verifica se Usuário pertence à Unidade informada"

            UsuarioUnidade usuarioUnidade = new UsuarioUnidade();
            UsuarioUnidadeDTO dtoUsuarioUnidade = new UsuarioUnidadeDTO();

            dtoUsuarioUnidade.IdtUsuario.Value = dtoUsuario.Idt.Value;

            UsuarioUnidadeDataTable dtbUsuarioUnidade = usuarioUnidade.Listar(dtoUsuarioUnidade);

            bool blnPertenceAUnidade = false;

            if (dtbUsuarioUnidade.Rows.Count > 0)
            {
                foreach (UsuarioUnidadeDTO dtoUsuarioUnidadeFor in dtbUsuarioUnidade)
                {
                    if (dtoUsuarioUnidadeFor.IdtUnidade.Value == idtUnidade)
                    {
                        blnPertenceAUnidade = true;
                        break;
                    }
                }
                if (!blnPertenceAUnidade)
                {
                    enPassportAuthenticationDTO.PassportAuthenticationStatus =
                        PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioNaoPertenceAUnidade;
                    message = "Operação não realizada!!! \n Usuário não pertence a Unidade informada, altere a Unidade.";
                }
            }

            #endregion


            if (message == string.Empty)
            {
                //OK
                #region "Verifica se Usuário pertence ao local informado"

                UnidadeLocalSetorUsuario unidadeLocalSetorUsuarioLocal = new UnidadeLocalSetorUsuario();
                UnidadeLocalSetorUsuarioDTO dtoUnidadeLocalSetorUsuarioLocal = new UnidadeLocalSetorUsuarioDTO();

                dtoUnidadeLocalSetorUsuarioLocal.IdtUsuario.Value = dtoUsuario.Idt.Value;

                UnidadeLocalSetorUsuarioDataTable dtbUnidadeLocalSetorUsuarioLocal =
                    unidadeLocalSetorUsuarioLocal.Listar(dtoUnidadeLocalSetorUsuarioLocal);

                bool blnPertenceLocal = false;
                if (dtbUnidadeLocalSetorUsuarioLocal.Rows.Count > 0)
                {
                    foreach (
                        UnidadeLocalSetorUsuarioDTO dtoUnidadeLocalSetorUsuarioFor in dtbUnidadeLocalSetorUsuarioLocal)
                    {
                        if (dtoUnidadeLocalSetorUsuarioFor.IdtLocalAtendimento.Value == idtLocal)
                        {
                            blnPertenceLocal = true;
                            break;
                        }
                    }
                    if (!blnPertenceLocal)
                    {
                        enPassportAuthenticationDTO.PassportAuthenticationStatus =
                            PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioNaoPertenceALocal;
                        message = "Operação não realizada!!! \n Usuário não pertence ao Local informado, altere o Local.";
                    }
                }

                #endregion
            }

            if (message == string.Empty)
            {
                //OK

                #region "Verifica se Usuário pertence ao Setor informado"

                UnidadeLocalSetorUsuario unidadeLocalSetorUsuario = new UnidadeLocalSetorUsuario();
                UnidadeLocalSetorUsuarioDTO dtoUnidadeLocalSetorUsuario = new UnidadeLocalSetorUsuarioDTO();

                dtoUnidadeLocalSetorUsuario.IdtUsuario.Value = dtoUsuario.Idt.Value;

                UnidadeLocalSetorUsuarioDataTable dtbUnidadeLocalSetorUsuario =
                    unidadeLocalSetorUsuario.Listar(dtoUnidadeLocalSetorUsuario);

                bool blnPertenceSetor = false;
                if (dtbUnidadeLocalSetorUsuario.Rows.Count > 0)
                {
                    foreach (UnidadeLocalSetorUsuarioDTO dtoUnidadeLocalSetorUsuarioFor in dtbUnidadeLocalSetorUsuario)
                    {
                        if (dtoUnidadeLocalSetorUsuarioFor.IdtSetor.Value == idtSetor)
                        {
                            blnPertenceSetor = true;
                            break;
                        }
                    }
                    if (!blnPertenceSetor)
                    {
                        enPassportAuthenticationDTO.PassportAuthenticationStatus =
                            PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioNaoPerteceASetor;
                        message =
                            "Operação não realizada!!! \n Usuário não pertence ao Setor informado, altere o setor.";
                    }
                }

                #endregion
            }

            if (message != string.Empty)
            {
                throw new HacException(message);
            }

            return enPassportAuthenticationDTO;

        }
         //OK
        public PassportAuthenticationDTO AutenticarParaProntuarioEletronico(string login, string senha )
        {
            PassportAuthenticationDTO enPassportAuthenticationDTO = new PassportAuthenticationDTO();

            Usuario usuario = new Usuario();
            UsuarioDTO dtoUsuario = new UsuarioDTO();
            string message = string.Empty;

            dtoUsuario.Login.Value = login.ToUpper();

            UsuarioDataTable dtbUsuario = usuario.Listar(dtoUsuario);

            if (dtbUsuario.Rows.Count == 0)
            {
                enPassportAuthenticationDTO.PassportAuthenticationStatus = PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioNaoCadastrado;
                message = "Operação não realizada!!! \n Usuário não Cadastrado!!! Seu usuário não está cadastrado.";
            }
            else if (dtbUsuario.Rows.Count > 0)
            {
                dtoUsuario = dtbUsuario.TypedRow(0);

                //ok
                if (message == string.Empty)
                {
                    #region "Verifica Usuário Bloqueado"

                    if (dtoUsuario.FlagStatus.Value == PassportAuthenticationDTO.StatusUsuarioEnum.Bloqueado.ToString())
                    {
                        enPassportAuthenticationDTO.PassportAuthenticationStatus = PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioBloqueado;
                        message = "Operação não realizada!!! \n Usuário Bloqueado!!! Seu usuário está bloqueado.";
                    }

                    #endregion
                }

                //OK
                if (message == string.Empty)
                {
                    #region "Verifica Usuário Inativo"

                    if (dtoUsuario.FlagStatus.Value == PassportAuthenticationDTO.StatusUsuarioEnum.Inativo.ToString())
                    {
                        enPassportAuthenticationDTO.PassportAuthenticationStatus =
                            PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioInativo;
                        message = "Operação não realizada!!! \n Usuário Inativo!!! Seu usuário está inativo.";
                    }

                    #endregion
                }


                ////OK
                //if (message == string.Empty)
                //{
                //    #region "Verifica Senha Inválida"

                //    UsuarioDTO dtoUsuarioSenha = new UsuarioDTO();

                //    dtoUsuarioSenha.Idt.Value = dtoUsuario.Idt.Value;

                //    dtoUsuarioSenha = usuario.Pesquisar(dtoUsuarioSenha);

                //    string senhaUsuario = dtoUsuarioSenha.Senha.Value;
                //    string senhaInformadaCriptografada = BasicFunctions.CriptografarMd5Hash(senha.ToUpper());

                //    if (senhaInformadaCriptografada != senhaUsuario)
                //    {
                //        enPassportAuthenticationDTO.PassportAuthenticationStatus =
                //            PassportAuthenticationDTO.PassportAuthenticationStatusEnum.SenhaInvalida;
                //        message = "Operação não realizada!!! \n Senha Invalida!!! Sua senha está inválida, digite novamente.";
                //    }

                //    #endregion
                //}

            }

            if (message == string.Empty)
            {
                enPassportAuthenticationDTO.PassportAuthenticationStatus = PassportAuthenticationDTO.PassportAuthenticationStatusEnum.AutenticacaoOk;
            }
            else
            {
                throw new HacException(message);
            }

            //Atribui Usuário ao PassportAutentication
            enPassportAuthenticationDTO.Usuario = dtoUsuario;
            return enPassportAuthenticationDTO;   
        }
        //OK
        public PassportAuthenticationDTO Autenticar(string login, string senha)
        {
            PassportAuthenticationDTO enPassportAuthenticationDTO = new PassportAuthenticationDTO();

            Usuario usuario = new Usuario();
            UsuarioDTO dtoUsuario = new UsuarioDTO();
            string message = string.Empty;

            dtoUsuario.Login.Value = login.ToUpper();

            UsuarioDataTable dtbUsuario = usuario.Listar(dtoUsuario);

            if (dtbUsuario.Rows.Count == 0)
            {
                enPassportAuthenticationDTO.PassportAuthenticationStatus = PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioNaoCadastrado;
                message = "Operação não realizada!!! \n Usuário não Cadastrado!!! Seu usuário não está cadastrado.";
            }
            else if (dtbUsuario.Rows.Count > 0)
            {
                dtoUsuario = dtbUsuario.TypedRow(0);
                
                //ok
                if (message == string.Empty)
                {
                    #region "Verifica Usuário Bloqueado"

                    if (dtoUsuario.FlagStatus.Value == PassportAuthenticationDTO.StatusUsuarioEnum.Bloqueado.ToString())
                    {
                        enPassportAuthenticationDTO.PassportAuthenticationStatus =
                            PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioBloqueado;
                        message = "Operação não realizada!!! \n Usuário Bloqueado!!! Seu usuário está bloqueado.";
                    }

                    #endregion
                }

                //OK
                if (message == string.Empty)
                {   
                    #region "Verifica Usuário Inativo"

                    if (dtoUsuario.FlagStatus.Value == PassportAuthenticationDTO.StatusUsuarioEnum.Inativo.ToString())
                    {
                        enPassportAuthenticationDTO.PassportAuthenticationStatus =
                            PassportAuthenticationDTO.PassportAuthenticationStatusEnum.UsuarioInativo;
                        message = "Operação não realizada!!! \n Usuário Inativo!!! Seu usuário está inativo.";
                    }

                    #endregion
                }


                //OK
                if (message == string.Empty)
                {
                    #region "Verifica Senha Inválida"

                    UsuarioDTO dtoUsuarioSenha = new UsuarioDTO();

                    dtoUsuarioSenha.Idt.Value = dtoUsuario.Idt.Value;

                    dtoUsuarioSenha = usuario.Pesquisar(dtoUsuarioSenha);

                    string senhaUsuario = dtoUsuarioSenha.Senha.Value;
                    string senhaInformadaCriptografada = BasicFunctions.CriptografarMd5Hash(senha.ToUpper());

                    if (senhaInformadaCriptografada != senhaUsuario)
                    {
                        enPassportAuthenticationDTO.PassportAuthenticationStatus =
                            PassportAuthenticationDTO.PassportAuthenticationStatusEnum.SenhaInvalida;
                        message = "Operação não realizada!!! \n Senha Invalida!!! Sua senha está inválida, digite novamente.";
                    }

                    #endregion
                }

            }

            if (message == string.Empty)
            {
                enPassportAuthenticationDTO.PassportAuthenticationStatus = PassportAuthenticationDTO.PassportAuthenticationStatusEnum.AutenticacaoOk;    
            }
            else
            {
                throw new HacException(message);
            }

            //Atribui Usuário ao PassportAutentication
            enPassportAuthenticationDTO.Usuario = dtoUsuario;
            return enPassportAuthenticationDTO;   
        }

        /// <summary>
        /// Recupera o Passport do Usuário, onde através dele é possível saber qual sua Unidade e
        /// suas permissões
        /// </summary>
        /// <param name="idtUnidade"></param>
        /// <param name="usuario"></param>
        /// <param name="idtLocalAtendimento"></param>
        /// <param name="idtSetor"></param>
        /// <returns></returns>
        public PassportDTO ObterPassport(int idtUnidade, UsuarioDTO usuario, int? idtLocalAtendimento, int? idtSetor, Decimal idtModulo)
        {
            PassportDTO dtoPassport = new PassportDTO();
            dtoPassport.Usuario = usuario;

            //Recupera a Unidade onde o usuário se logou
            Unidade unidade = new Unidade();
            UnidadeDTO dtoUnidade = new UnidadeDTO();
            dtoUnidade.Idt.Value = Convert.ToInt32(idtUnidade);
            dtoPassport.Unidade = unidade.SelChave(dtoUnidade);

            //Recupera o Local de Atendimento onde o usuário se logou
            LocalAtendimento localAtendimento = new LocalAtendimento();
            LocalAtendimentoDTO dtoLocalAtendimento = new LocalAtendimentoDTO();
            dtoLocalAtendimento.Idt.Value = Convert.ToInt32(idtLocalAtendimento);
            if (idtLocalAtendimento != null) dtoPassport.LocalAtendimento = localAtendimento.SelChave(dtoLocalAtendimento);

            // Recupera o Setor onde o usuário se logou
            Setor setor = new Setor();
            SetorDTO dtoSetor = new SetorDTO();
            dtoSetor.Idt.Value = Convert.ToInt32(idtSetor);
            if (idtSetor != null) dtoPassport.Setor = setor.SelChave(dtoSetor);


            Funcionalidade funcionalidade = new Funcionalidade();
            FuncionalidadeDTO dtoFuncionalidade = new FuncionalidadeDTO();
            FuncionalidadeDataTable dtbFuncionalidade = new FuncionalidadeDataTable();
            dtoFuncionalidade.Idt.Value = Convert.ToInt32(usuario.Idt.Value);
            dtbFuncionalidade = funcionalidade.ListarPorUsuarioUnidade(idtUnidade, usuario, idtModulo);

            Dictionary<int, FuncionalidadeDTO> lstFuncionalidadesPassport = new Dictionary<int, FuncionalidadeDTO>();
            foreach (FuncionalidadeDTO enFuncionalidadeDTO in dtbFuncionalidade)
            {
                lstFuncionalidadesPassport.Add((int)enFuncionalidadeDTO.Idt.Value, enFuncionalidadeDTO);
            }

            dtoPassport.Funcionalidades = lstFuncionalidadesPassport;
            return dtoPassport;

        }

        public void TrocarSenha(string login, string senhaAtual, string novaSenha)
        {
            try
            {
                PassportAuthenticationDTO dtoPassportAuthentication = Autenticar(login, senhaAtual);
                Usuario usuario = new Usuario();
                UsuarioDTO dtoUsuario = dtoPassportAuthentication.Usuario;
                dtoUsuario.Senha.Value = BasicFunctions.CriptografarMd5Hash(novaSenha);
                dtoUsuario.FlagTrocarSenha.Value = "N";
                dtoUsuario.IdtUsuarioAtualizacao.Value = dtoUsuario.Idt.Value;
                usuario.Alterar(dtoUsuario);         
            }
            catch (HacException ex)
            {
                throw ex;
            }

        }
        public void PrimeiroAcesso(string login, string novaSenha)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioDTO dto = new UsuarioDTO();
                dto.Login.Value = login;
                DataTable dtb = usuario.Listar(dto);
                if (dtb.Rows.Count > 0)
                {
                    dto = usuario.Listar(dto).TypedRow(0);
                    if (dto.Senha.Value.IsNull)
                    {
                        dto.Senha.Value = BasicFunctions.CriptografarMd5Hash(novaSenha);
                        dto.FlagTrocarSenha.Value = "N";
                    }
                }
                dto.IdtUsuarioAtualizacao.Value = dto.Idt.Value;
                usuario.Alterar(dto);
                

            }
            catch (HacException ex)
            {
                throw ex;
            }

        }

        public string GeraToken(string usuario, bool recuperar, bool alterar)
        {
            Random r = new Random();
            int token = r.Next(1,int.MaxValue);
            string acao = recuperar ? "RECUPERAR" : alterar ? "ALTERAR" : string.Empty;
            string result =string.Empty;
            try
            {
                result = entity.GeraToken(usuario+token.ToString(), acao);
            }
            catch (Exception)
            {
                r = new Random();
                token = r.Next(1,int.MaxValue);
                result = entity.GeraToken(usuario+token.ToString(), acao);
            }
            return result;
        }
    }
}
