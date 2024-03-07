using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HospitalAnaCosta.SGS.Seguranca.View;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.Seguranca.Forms
{
    public partial class FrmBaseSeguranca : FrmBase
    {
        public FrmBaseSeguranca()
        {
            InitializeComponent();
        }

        private CommonSeguranca _commonSeguranca;
        protected CommonSeguranca CommonSeguranca
        {
            get { return _commonSeguranca != null ? _commonSeguranca : _commonSeguranca = new CommonSeguranca(null); }
        }

        /// <summary>
        /// IAssPerfilFuncionalidade
        /// </summary>
        private IAssPerfilFuncionalidade _assPerfilFuncionalidade;
        public IAssPerfilFuncionalidade AssPerfilFuncionalidade
        {
            get
            {
                return _assPerfilFuncionalidade != null ? _assPerfilFuncionalidade : _assPerfilFuncionalidade =
                    (IAssPerfilFuncionalidade)CommonSeguranca.GetObject(typeof(IAssPerfilFuncionalidade));
            }
        }

        /// <summary>
        /// IAssPerfilUsuario
        /// </summary>
        private IAssPerfilUsuario _assPerfilUsuario;
        public IAssPerfilUsuario AssPerfilUsuario
        {
            get
            {
                return _assPerfilUsuario != null ? _assPerfilUsuario : _assPerfilUsuario =
                    (IAssPerfilUsuario)CommonSeguranca.GetObject(typeof(IAssPerfilUsuario));
            }
        }

        /// <summary>
        /// IAutentica
        /// </summary>
        private IAutentica _autentica;
        public IAutentica Autentica
        {
            get
            {
                return _autentica != null ? _autentica : _autentica =
                    (IAutentica)CommonSeguranca.GetObject(typeof(IAutentica));
            }
        }

        /// <summary>
        /// IFuncionalidade
        /// </summary>
        private IFuncionalidade _funcionalidade;
        public IFuncionalidade Funcionalidade
        {
            get
            {
                return _funcionalidade != null ? _funcionalidade : _funcionalidade =
                    (IFuncionalidade)CommonSeguranca.GetObject(typeof(IFuncionalidade));
            }
        }

        /// <summary>
        /// IModulo
        /// </summary>
        private IModulo _modulo;
        public IModulo Modulo
        {
            get
            {
                return _modulo != null ? _modulo : _modulo =
                    (IModulo)CommonSeguranca.GetObject(typeof(IModulo));
            }
        }

        /// <summary>
        /// IPerfil
        /// </summary>
        private IPerfil _perfil;
        public IPerfil Perfil
        {
            get
            {
                return _perfil != null ? _perfil : _perfil =
                    (IPerfil)CommonSeguranca.GetObject(typeof(IPerfil));
            }
        }
        
        /// <summary>
        /// IUsuario
        /// </summary>
        private IUsuario _usuario;
        public IUsuario Usuario
        {
            get
            {
                return _usuario != null ? _usuario : _usuario =
                    (IUsuario)CommonSeguranca.GetObject(typeof(IUsuario));
            }
        }

        private IUsuarioUnidade _usuarioUnidade;
        public IUsuarioUnidade UsuarioUnidade
        {
            get
            {
                return _usuarioUnidade != null ? _usuarioUnidade : _usuarioUnidade =
                    (IUsuarioUnidade)CommonSeguranca.GetObject(typeof(IUsuarioUnidade));
            }
        }

        private IUnidadeLocalSetorUsuario _unidadeLocalSetorUsuario;
        public IUnidadeLocalSetorUsuario UnidadeLocalSetorUsuario
        {
            get
            {
                return _unidadeLocalSetorUsuario != null ? _unidadeLocalSetorUsuario : _unidadeLocalSetorUsuario =
                    (IUnidadeLocalSetorUsuario)CommonSeguranca.GetObject(typeof(IUnidadeLocalSetorUsuario));
            }
        }
 
    }
}