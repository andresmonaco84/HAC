using HospitalAnaCosta.Services.Seguranca.DTO;
using System;

namespace HospitalAnaCosta.Services.Seguranca.Interface
{
    public interface IUsuario
    {
        UsuarioDataTable Listar(UsuarioDTO dto);

        UsuarioDTO Incluir(UsuarioDTO dto);

        void Excluir(UsuarioDTO dto);

        void Alterar(UsuarioDTO dto);

        UsuarioDTO Pesquisar(UsuarioDTO dto);

        PassportAuthenticationDTO Autenticar(int idtUnidade, string login, string senha,int idtLocal, int idtSetor);

        PassportDTO ObterPassport(int idtUnidade, UsuarioDTO usuario, int? idtLocalAtendimento, int? idtSetor, Decimal idtModulo);

        void TrocarSenha(string login, string senhaAtual, string novaSenha);

        void PrimeiroAcesso(string login, string novaSenha);

        PassportAuthenticationDTO AutenticarParaProntuarioEletronico(int idtUnidade, string login, string senha, int idtLocal, int idtSetor);

        string GeraToken(string usuario, bool recuperar, bool alterar);
    }
}