using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using HospitalAnaCosta.SGS.Cadastro.DTO;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacSubPlano : HacUserControl
    {

        /// <summary>
        /// SubPlano
        /// </summary>
        /// <summary>
        /// SubPlano
        /// </summary>
        private ISubPlano _subPlano;
        protected ISubPlano SubPlano
        {
            get
            {
                return
                    _subPlano != null ? _subPlano : _subPlano = (ISubPlano)CommonServices.GetObject(typeof(ISubPlano));
            }
        }

        public HacSubPlano()
        {
            InitializeComponent();

            txtCodigoSubPlano.NaoAjustarEdicao = true;
            txtDescricaoSubPlano.NaoAjustarEdicao = true;
        }

        ~HacSubPlano()
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

        public delegate void PesquisarDelegate(object sender, EventArgs e);

        [Category("Hac")]
        public event PesquisarDelegate Pesquisar;

        [Category("Hac")]
        protected virtual void OnPesquisar(CancelEventArgs e)
        {
            if (Pesquisar != null)
            {

                Pesquisar(this, e);
            }
        }

        public void Inicializar()
        {
            //O nome do procedimento é apenas exibição
            txtCodigoSubPlano.Enabled = true;
            btnPesquisarSubPlano.Enabled = true;
            txtDescricaoSubPlano.Enabled = false;

            txtCodigoSubPlano.Text = string.Empty;
            txtDescricaoSubPlano.Text = string.Empty;

            _DtoSubPlano = null;
            idtPlano = 0;
            idtConvenio = 0;
        }

        private bool enabled;

        public new bool Enabled
        {
            get { return enabled; }
            set
            {
                if (value)
                {
                    txtCodigoSubPlano.Enabled = true;
                    btnPesquisarSubPlano.Enabled = true;
                    txtDescricaoSubPlano.Enabled = false;
                }
                else
                {
                    txtCodigoSubPlano.Enabled = false;
                    btnPesquisarSubPlano.Enabled = false;
                    txtDescricaoSubPlano.Enabled = false;
                }
                enabled = value;
            }
        }

        private bool naoAjustarEdicao;
        public bool NaoAjustarEdicao
        {
            get { return naoAjustarEdicao; }
            set
            {
                txtCodigoSubPlano.NaoAjustarEdicao = value;
                naoAjustarEdicao = value;
            }
        }

        private bool obrigatorio;
        public bool Obrigatorio
        {
            get { return obrigatorio; }
            set
            {
                txtCodigoSubPlano.Obrigatorio = value;
                obrigatorio = value;
            }
        }

        private string obrigatorioMensagem;
        public string ObrigatorioMensagem
        {
            get { return obrigatorioMensagem; }
            set
            {
                txtCodigoSubPlano.ObrigatorioMensagem = value;
                obrigatorioMensagem = value;
            }
        }

        private SubPlanoDataTable PesquisarSubPlano(string codigoSubPlanoHAC)
        {
            SubPlanoDataTable dtbSubPlano = null;

            if (idtConvenio != 0)
            {
                SubPlanoDTO dtoSubPlano = new SubPlanoDTO();
                dtoSubPlano.IdtConvenio.Value = idtConvenio;

                if (codigoSubPlanoHAC != null)
                {
                    dtoSubPlano.Codigo.Value = codigoSubPlanoHAC;
                    dtoSubPlano.Status.Value = "A";
                    dtbSubPlano = SubPlano.Listar(dtoSubPlano);
                }
                else
                {
                    dtbSubPlano = SubPlano.ListarSubPanosPorUnidadeLocalConvenioPlano(idtUnidade, idtLocal, idtConvenio.ToString(), idtPlano.ToString());
                    if (dtbSubPlano.Rows.Count == 0)
                    {
                        dtbSubPlano = SubPlano.ListarSubPanosPorUnidadeLocalConvenioPlano(idtUnidade, idtLocal, idtConvenio.ToString(), null);
                        if (dtbSubPlano.Rows.Count == 0)
                        {
                            dtbSubPlano = SubPlano.Listar(dtoSubPlano);
                        }
                    }
                }
            }
            else
            {
                StringBuilder stbMessage = new StringBuilder();
                stbMessage.Append("Informe o Convênio.");
                if (idtPlano == 0)
                {
                    stbMessage.Append("\nInforme o Plano.");
                }
                MessageBox.Show(stbMessage.ToString(), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return dtbSubPlano;
        }

        private void btnPesquisarSubPlano_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SubPlanoDataTable dtbSubPlano = PesquisarSubPlano(null);
            Cursor.Current = Cursors.Arrow;

            if (dtbSubPlano != null)
            {
                if (dtbSubPlano.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhum SubPlano cadastrado.", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescricaoSubPlano.Text = string.Empty;
                    _DtoSubPlano = null;
                }
                else
                {
                    SubPlanoDTO dtoSubPlano = Forms.FrmPesquisaSubPlano.AbrirPesquisaSubPlano(dtbSubPlano);

                    if (dtoSubPlano != null)
                    {
                        txtCodigoSubPlano.Text = dtoSubPlano.Codigo.Value;
                        txtDescricaoSubPlano.Text = dtoSubPlano.Descricao.Value;

                        _DtoSubPlano = dtoSubPlano;
                    }
                }
            }
            CancelEventArgs eCancel = new CancelEventArgs();
            eCancel.Cancel = !ValidarRegrasSubPlano();
            OnPesquisar(eCancel);

            txtCodigoSubPlano.RetirarVermelhoCampo();
        }

        private void txtCodigoSubPlano_Leave(object sender, EventArgs e)
        {
            if (txtCodigoSubPlano.Text != string.Empty)
            {
                SubPlanoDataTable dtbSubPlano = PesquisarSubPlano(txtCodigoSubPlano.Text);
              

                if (dtbSubPlano != null)
                {
                    if (dtbSubPlano.Rows.Count == 0)
                    {
                        MessageBox.Show("Sub Plano não encontrado!", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDescricaoSubPlano.Text = string.Empty;
                        _DtoSubPlano = null;
                    }
                    else if (dtbSubPlano.Rows.Count == 1)
                    {
                        txtDescricaoSubPlano.DataBindings.Clear();
                        txtDescricaoSubPlano.DataBindings.Add(new Binding("Text",
                                dtbSubPlano, SubPlanoDTO.FieldNames.Descricao));

                        _DtoSubPlano = dtbSubPlano.TypedRow(0);
                    }
                    CancelEventArgs eCancel = new CancelEventArgs();
                    eCancel.Cancel = !ValidarRegrasSubPlano();
                    OnPesquisar(eCancel);
                }
            }
            else
            {
                txtDescricaoSubPlano.Text = string.Empty;
                _DtoSubPlano = null;
            }
        }
        
        private bool ValidarRegrasSubPlano()
        {
            bool result = true;

            if (DtoSubPlano != null)
            {
                switch (DtoSubPlano.Status.Value)
                {
                    case "I":
                        MessageBox.Show("Sub Plano Inativo, favor entrar em contato com o convênio.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Inicializar();
                        result = false;
                        break;
                    case "S":
                        MessageBox.Show("Sub Plano Suspenso, favor entrar em contato com o convênio.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Inicializar();
                        result = false;
                        break;
                }
            }

            return result;
        }

        public void CarregarSubPlano(SubPlanoDTO dtoSubPlano)
        {
            if (dtoSubPlano.Codigo.Value.IsNull && !dtoSubPlano.Idt.Value.IsNull)
                dtoSubPlano = SubPlano.Pesquisar(dtoSubPlano);
            
            SubPlanoDataTable dtbSubPlano = PesquisarSubPlano(dtoSubPlano.Codigo.Value);

            if (dtbSubPlano != null && dtbSubPlano.Rows.Count > 0)
            {
                dtoSubPlano = dtbSubPlano.TypedRow(0);
                txtCodigoSubPlano.Text = dtoSubPlano.Codigo.Value;

                if (dtoSubPlano != null)
                {
                    txtDescricaoSubPlano.Text = dtoSubPlano.Descricao.Value;
                    _DtoSubPlano = dtoSubPlano;
                }
            }
            CancelEventArgs eCancel = new CancelEventArgs();
            eCancel.Cancel = !ValidarRegrasSubPlano();
            OnPesquisar(eCancel);
        }



        public bool SubPlanoDigitadoCarregado
        {
            get
            {
                if (txtCodigoSubPlano.Text.Length > 0 && DtoSubPlano == null)
                {
                    OnPesquisar(null);
                    if (DtoSubPlano == null)
                    {
                        return false;
                    }

                }

                if (txtCodigoSubPlano.Text.Length == 0 && DtoSubPlano != null)
                {
                    OnPesquisar(null);
                    {
                        return false;
                    }
                }

                return true;
            }
        }



        private SubPlanoDTO _DtoSubPlano;
        public SubPlanoDTO DtoSubPlano
        {
            get
            {
                return _DtoSubPlano;
            }
        }

        private int idtConvenio;

        public int IdtConvenio
        {
            get { return idtConvenio; }
            set { idtConvenio = value; }
        }

        private int idtPlano;

        public int IdtPlano
        {
            get { return idtPlano; }
            set { idtPlano = value; }
        }

        private int idtUnidade;

        public int IdtUnidade
        {
            get { return idtUnidade; }
            set { idtUnidade = value; }
        }

        private int idtLocal;

        public int IdtLocal
        {
            get { return idtLocal; }
            set { idtLocal = value; }
        }
    }
}
