using System;

namespace HospitalAnaCosta.Services.Seguranca.DTO
{
    [Serializable()]
    public partial class PassportAuthenticationDTO 
    {
        public PassportAuthenticationDTO()
        {
        }

        private UsuarioDTO _usuario;
        private PassportAuthenticationStatusEnum _passportAuthenticationStatus;

        [Serializable()]
        public enum PassportAuthenticationStatusEnum
        {
            UsuarioNaoCadastrado = 1,
            SenhaInvalida = 2,
            UsuarioInativo = 3,
            UsuarioBloqueado = 4,
            SenhaExpirada = 5,
            NecessarioTrocarSenha = 6,
            AutenticacaoOk = 7,
            UsuarioNaoPertenceAUnidade = 8,
            UsuarioNaoPertenceALocal = 9,
            UsuarioNaoPerteceASetor = 10
        }

        #region "Propriedades"
        public UsuarioDTO Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public PassportAuthenticationStatusEnum PassportAuthenticationStatus
        {
            get { return _passportAuthenticationStatus; }
            set { _passportAuthenticationStatus = value; }
        }

        #endregion

        public enum StatusUsuarioEnum
        {
            Ativo = 'A',
            Inativo = 'I',
            Bloqueado = 'B'
        }
    }
}
