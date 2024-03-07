using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using Hac.Windows.Forms;
using HospitalAnaCosta.Framework;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacConvenio : HacUserControl
    {
        /// <summary>
        /// Convenio
        /// </summary>
        private IConvenio _Convenio;
        public IConvenio Convenio
        {
            get
            {
                return _Convenio != null ? _Convenio : _Convenio =
                    (IConvenio)CommonServices.GetObject(typeof(IConvenio));
            }
        }

        private ILog _ilog;
        protected ILog Log
        {
            get
            {
                return _ilog != null ? _ilog : _ilog = (ILog)CommonServices.GetObject(typeof(ILog));
            }
        }

        public DateTime DateTimeServ
        {
            get { return Log.DataHoraServ(); }
        }

        public HacConvenio()
        {
            InitializeComponent();

            txtCodigoConvenio.NaoAjustarEdicao = true;
            txtDescricaoConvenio.NaoAjustarEdicao = true;
            this.Limpar = true;
        }

        ~HacConvenio()
        {
            try
            {
                //_commonServices = null;
                _Convenio = null;
                _DtoConvenio = null;
                Dispose();
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }

        private bool modoConsulta = false;
        [Category("Hac")]
        [Description("Modo consulta (exibe todos)")]
        public bool ModoConsulta
        {
            get { return modoConsulta; }
            set { modoConsulta = value; }
        }

        [Category("Hac")]
        [Description("Estado Codigo Convenio")]
        public bool EstadoCodigoConvenio
        {
            get { return txtCodigoConvenio.Enabled; }
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
            //modoConsulta = false;
            txtCodigoConvenio.Enabled = true;
            btnPesquisarConvenio.Enabled = true;
            txtDescricaoConvenio.Enabled = false;            
            txtCodigoConvenio.Text = string.Empty;
            txtDescricaoConvenio.Text = string.Empty;

            _DtoConvenio = null;
        }

        public void Focus()
        {
            txtCodigoConvenio.Focus();
        }

        private bool enabled;

        public bool Enabled
        {
            get { return enabled; }
            set
            {
                if (value)
                {
                    txtCodigoConvenio.Enabled = true;
                    btnPesquisarConvenio.Enabled = true;
                    txtDescricaoConvenio.Enabled = false;
                }
                else
                {
                    txtCodigoConvenio.Enabled = false;
                    btnPesquisarConvenio.Enabled = false;
                    txtDescricaoConvenio.Enabled = false;
                }
                enabled = value;
            }
        }
                
        private bool obrigatorio;
        [Category("Hac")]
        public bool Obrigatorio
        {
            get { return obrigatorio; }
            set
            {
                txtCodigoConvenio.Obrigatorio = value;              
                obrigatorio = value;
            }
        }

        private string obrigatorioMensagem;
        [Category("Hac")]
        public string ObrigatorioMensagem
        {
            get { return obrigatorioMensagem; }
            set
            {
                txtCodigoConvenio.ObrigatorioMensagem = value;
                obrigatorioMensagem = value;
            }
        }

        private bool naoAjustarEdicao;
        [Category("Hac")]
        public bool NaoAjustarEdicao
        {
            get { return naoAjustarEdicao; }
            set
            {
                txtCodigoConvenio.NaoAjustarEdicao = value;
                txtDescricaoConvenio.NaoAjustarEdicao = value;
                naoAjustarEdicao = value;
            }
        }

        private bool limpar;
        [Category("Hac")]
        public bool Limpar
        {
            get { return limpar; }
            set
            {
                txtCodigoConvenio.Limpar = value;
                txtDescricaoConvenio.Limpar = value;
                limpar = value;
            }
        }

        private ConvenioDataTable PesquisarConvenio(string codigoHACPrestador)
        {
            ConvenioDTO dtoConvenio = new ConvenioDTO();

            if(!ModoConsulta)
                dtoConvenio.StatusConvenio.Value = "A";

            if (codigoHACPrestador != null) dtoConvenio.CodigoHACPrestador.Value = codigoHACPrestador;

            ConvenioDataTable dtbConvenio = Convenio.Listar(dtoConvenio);
            
            if(!ModoConsulta)
                dtbConvenio = (ConvenioDataTable)BasicFunctions.ValidarVigencia(DateTimeServ.Date, ConvenioDTO.FieldNames.DataInicioVigencia, ConvenioDTO.FieldNames.DataFimVigencia, dtbConvenio);

            return dtbConvenio;
        }

        private ConvenioDTO PesquisarConvenio(decimal idtConvenio)
        {
            ConvenioDataTable dtbConvenio = null;
            ConvenioDTO dtoConvenio = new ConvenioDTO();
 
            dtoConvenio.IdtConvenio.Value = idtConvenio;
            dtbConvenio = Convenio.Listar(dtoConvenio);
            if (dtbConvenio.Rows.Count > 0)
            {
                dtoConvenio = dtbConvenio.TypedRow(0);
            }

            return dtoConvenio;
        }

        private void btnPesquisarConvenio_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ConvenioDataTable dtbConvenio = PesquisarConvenio(null);
            Cursor.Current = Cursors.Arrow;

            if (dtbConvenio.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Convenio cadastrado.", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricaoConvenio.Text = string.Empty;
                _DtoConvenio = null;
            }
            else
            {
                ConvenioDTO dtoConvenio = Forms.FrmPesquisaConvenio.AbrirPesquisaConvenio(dtbConvenio);

                if (dtoConvenio != null)
                {
                    txtCodigoConvenio.Text = dtoConvenio.CodigoHACPrestador.Value;
                    txtDescricaoConvenio.Text = dtoConvenio.NomeFantasia.Value;

                    _DtoConvenio = dtoConvenio;
                    
                }
            }
            CancelEventArgs eCancel = new CancelEventArgs();
            eCancel.Cancel = !ValidarRegrasConvenio();
            OnPesquisar(eCancel);

            txtCodigoConvenio.RetirarVermelhoCampo();
        }

        private void txtCodigoConvenio_Leave(object sender, EventArgs e)
        {
            if (txtCodigoConvenio.Text != string.Empty)
            {
                ConvenioDataTable dtbConvenio = PesquisarConvenio(txtCodigoConvenio.Text);

                if (dtbConvenio.Rows.Count == 0)
                {
                    if (txtCodigoConvenio.Text.Length >= 4)
                        MessageBox.Show("Convenio não encontrado!", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtDescricaoConvenio.Text = string.Empty;
                    _DtoConvenio = null;
                }
                else if (dtbConvenio.Rows.Count == 1)
                {
                    txtDescricaoConvenio.DataBindings.Clear();
                    txtDescricaoConvenio.DataBindings.Add(new Binding("Text",
                            dtbConvenio, ConvenioDTO.FieldNames.NomeFantasia));

                    _DtoConvenio = dtbConvenio.TypedRow(0);
                }
            }
            else
            {
                txtDescricaoConvenio.Text = string.Empty;
                _DtoConvenio = null;
            }
            CancelEventArgs eCancel = new CancelEventArgs();
            eCancel.Cancel = !ValidarRegrasConvenio();
            OnPesquisar(eCancel);
        }        

        private void txtCodigoConvenio_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigoConvenio.Text != string.Empty)
            {
                ConvenioDataTable dtbConvenio = PesquisarConvenio(txtCodigoConvenio.Text);

                if (dtbConvenio.Rows.Count == 0)
                {
                    if (txtCodigoConvenio.Text.Length >= 5)
                        MessageBox.Show("Convenio não encontrado!", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtDescricaoConvenio.Text = string.Empty;
                    _DtoConvenio = null;
                }
                else if (dtbConvenio.Rows.Count == 1)
                {
                    txtDescricaoConvenio.DataBindings.Clear();
                    txtDescricaoConvenio.DataBindings.Add(new Binding("Text",
                            dtbConvenio, ConvenioDTO.FieldNames.NomeFantasia));

                    _DtoConvenio = dtbConvenio.TypedRow(0);
                }
            }
            else
            {
                txtDescricaoConvenio.Text = string.Empty;
                _DtoConvenio = null;
            }
            CancelEventArgs eCancel = new CancelEventArgs();
            eCancel.Cancel = !ValidarRegrasConvenio();
            OnPesquisar(eCancel);
        }        

        private bool ValidarRegrasConvenio()
        {
            bool result = true;

            if (DtoConvenio != null)
            {
                switch (DtoConvenio.StatusConvenio.Value)
                {
                    case "I":
                        if (modoConsulta)
                        {
                            //MessageBox.Show("Convênio Inativo.", ((FrmBase)this.FindForm()).Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Convênio Inativo, favor entrar em contato com o convênio.", ((FrmBase)this.FindForm()).Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Inicializar();
                            result = false;
                        }
                        
                        break;
                    case "S":
                        if (modoConsulta)
                        {
                            MessageBox.Show("Convênio Suspenso.", ((FrmBase)this.FindForm()).Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Convênio Suspenso, favor entrar em contato com o convênio.", ((FrmBase)this.FindForm()).Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Inicializar();
                            result = false;
                        }
                        
                        break;
                }
            }

            return result;
        }

        public void CarregarConvenio(ConvenioDTO dtoConvenio)
        {
            dtoConvenio = PesquisarConvenio(Convert.ToDecimal(dtoConvenio.IdtConvenio.Value));
            txtCodigoConvenio.Text = dtoConvenio.CodigoHACPrestador.Value;

            if (dtoConvenio != null)
            {                
                txtDescricaoConvenio.Text = dtoConvenio.NomeFantasia.Value;
                _DtoConvenio = dtoConvenio;
            }

            //CancelEventArgs eCancel = new CancelEventArgs();
            //eCancel.Cancel = !ValidarRegrasConvenio();
            //OnPesquisar(eCancel);
        }


        private ConvenioDTO _DtoConvenio;
        public ConvenioDTO DtoConvenio
        {
            get
            {
                return _DtoConvenio;
            }
        }
    }
}