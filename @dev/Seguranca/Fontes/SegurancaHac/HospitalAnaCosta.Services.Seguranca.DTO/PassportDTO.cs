using System;
using System.Collections.Generic;
using HospitalAnaCosta.SGS.Cadastro.DTO;

namespace HospitalAnaCosta.Services.Seguranca.DTO
{
    [Serializable()]
    public class PassportDTO
    {
        private UnidadeDTO _unidade;
        private UsuarioDTO _usuario;
        private LocalAtendimentoDTO _localatendimento;
        private SetorDTO _setor;
        private Dictionary<int, FuncionalidadeDTO> _funcionalidades;

        public UnidadeDTO Unidade
        {
            get { return _unidade; }
            set { _unidade = value; }
        }

        public UsuarioDTO Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public LocalAtendimentoDTO LocalAtendimento
        {
            get { return _localatendimento; }
            set { _localatendimento = value; }
        }

        public SetorDTO Setor
        {
            get { return _setor; }
            set { _setor = value; }
        }

        public Dictionary<int, FuncionalidadeDTO> Funcionalidades
        {
            get { return _funcionalidades; }
            set { _funcionalidades = value; }
        }

        /// <summary>
        /// Checa se o usuário possui uma determinada permissão.
        /// Se usuário autenticado for ADMIN, permitir acesso a todas as funcionalidades.
        /// </summary>
        /// <param name="idtFuncionalidade">Idt da Funcionalidade</param>
        /// <returns>boolean</returns>
        public bool CheckPermission(int idtFuncionalidade)
        {
            //Se usuário ADMIN, permitir acesso a todas as funcionalidades
            if (this.Usuario.Login.ToString().ToUpper() == "ADMIN")
                return true;
            else
                return _funcionalidades.ContainsKey(idtFuncionalidade);
        }
    }
}

	
