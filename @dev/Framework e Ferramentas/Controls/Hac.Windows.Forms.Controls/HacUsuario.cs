using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using HospitalAnaCosta.Services.Seguranca.Interface;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacUsuario : HacUserControl
    {

        /// <summary>
        /// Usuario
        /// </summary>
        private IUsuario _Usuario;
        public IUsuario Usuario
        {
            get
            {
                return _Usuario != null ? _Usuario : _Usuario =
                    (IUsuario)CommonServices.GetObject(typeof(IUsuario));
            }
        }

        public HacUsuario()
        {
            InitializeComponent();

            txtMatricula.NaoAjustarEdicao = true;
            txtNomeUsuario.NaoAjustarEdicao = true;
        }

        ~HacUsuario()
        {
            try
            {
                Dispose();
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }

        public void Inicializar()
        {
            //O nome do procedimento é apenas exibição
            txtMatricula.Enabled = true;
            btnPesquisarUsuario.Enabled = true;
            txtNomeUsuario.Enabled = false;

            txtMatricula.Text = string.Empty;
            txtNomeUsuario.Text = string.Empty;

            _DtoUsuario = null;
        }

        private bool enabled;

        public new bool Enabled
        {
            get { return enabled; }
            set
            {
                if (value)
                {
                    txtMatricula.Enabled = true;
                    btnPesquisarUsuario.Enabled = true;
                    txtNomeUsuario.Enabled = false;
                }
                else
                {
                    txtMatricula.Enabled = false;
                    btnPesquisarUsuario.Enabled = false;
                    txtNomeUsuario.Enabled = false;
                }
                enabled = value;
            }
        }

        private bool obrigatorio;
        public bool Obrigatorio
        {
            get { return obrigatorio; }
            set
            {
                txtMatricula.Obrigatorio = value;
                obrigatorio = value;
            }
        }

        private string obrigatorioMensagem;
        public string ObrigatorioMensagem
        {
            get { return obrigatorioMensagem; }
            set
            {
                txtMatricula.ObrigatorioMensagem = value;
                obrigatorioMensagem = value;
            }
        }

        private UsuarioDataTable PesquisarUsuario(UsuarioDTO dtoUsuario)
        {
            UsuarioDataTable dtbUsuario = Usuario.Listar(dtoUsuario);
            foreach (DataRow drUsuario in dtbUsuario.Rows)
            {
                dtoUsuario = (UsuarioDTO)drUsuario;
                if (dtoUsuario.Matricula.Value.IsNull)
                {
                    drUsuario[UsuarioDTO.FieldNames.Matricula] = "0000";
                }                
            }
            return dtbUsuario;
        }

        private void btnPesquisarUsuario_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UsuarioDTO dtoUsuario = new UsuarioDTO();
            UsuarioDataTable dtbUsuario = PesquisarUsuario(dtoUsuario);
            Cursor.Current = Cursors.Arrow;

            if (dtbUsuario.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Usuario cadastrado.", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatricula.Text = string.Empty;
                _DtoUsuario = null;
            }
            else
            {
                AbreListaUsuario(dtbUsuario);
            }
            txtMatricula.RetirarVermelhoCampo();
        }

        private void AbreListaUsuario(UsuarioDataTable dtbUsuario)
        {
            UsuarioDTO dtoUsuario = Forms.FrmPesquisaUsuario.AbrirPesquisaUsuario(dtbUsuario);

            if (dtoUsuario != null)
            {
                txtMatricula.Text = dtoUsuario.Matricula.Value;
                txtNomeUsuario.Text = dtoUsuario.Nome.Value;

                _DtoUsuario = dtoUsuario;
            }
        }

        private void txtMatricula_Leave(object sender, EventArgs e)
        {
            if (txtMatricula.Text != string.Empty)
            {
                UsuarioDTO dtoUsuario = new UsuarioDTO();
                dtoUsuario.Matricula.Value = txtMatricula.Text;
                UsuarioDataTable dtbUsuario = PesquisarUsuario(dtoUsuario);

                if (dtbUsuario.Rows.Count == 0)
                {
                    MessageBox.Show("Usuario não encontrado!", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNomeUsuario.Text = string.Empty;
                    _DtoUsuario = null;
                }
                else if (dtbUsuario.Rows.Count == 1)
                {
                    txtNomeUsuario.DataBindings.Clear();
                    txtNomeUsuario.DataBindings.Add(new Binding("Text",
                            dtbUsuario, UsuarioDTO.FieldNames.Nome));

                    _DtoUsuario = dtbUsuario.TypedRow(0);
                }
                else if (dtbUsuario.Rows.Count > 1)
                {
                    AbreListaUsuario(dtbUsuario);
                }
            }
            else
            {
                txtNomeUsuario.Text = string.Empty;
                _DtoUsuario = null;
            }
        }

        public void CarregarUsuario(UsuarioDTO dtoUsuario)
        {
            UsuarioDataTable dtbUsuario = PesquisarUsuario(dtoUsuario);

            if (dtbUsuario.Rows.Count > 0)
            {
                txtMatricula.Text = dtbUsuario.TypedRow(0).Matricula.Value;
                txtNomeUsuario.DataBindings.Clear();
                txtNomeUsuario.DataBindings.Add(new Binding("Text",
                        dtbUsuario, UsuarioDTO.FieldNames.Nome));

                _DtoUsuario = dtbUsuario.TypedRow(0);
            }
        }

        private UsuarioDTO _DtoUsuario;
        public UsuarioDTO DtoUsuario
        {
            get
            {
                return _DtoUsuario;
            }
        }

    }
}
