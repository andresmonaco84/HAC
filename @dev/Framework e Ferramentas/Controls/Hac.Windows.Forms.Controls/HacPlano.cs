using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.Framework;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacPlano : HacUserControl
    {
        /// <summary>
        /// Plano
        /// </summary>
        private IPlano _Plano;
        public IPlano Plano
        {
            get
            {
                return _Plano != null ? _Plano : _Plano =
                    (IPlano)CommonServices.GetObject(typeof(IPlano));
            }
        }

        public HacPlano()
        {
            InitializeComponent();

            txtCodigoPlano.NaoAjustarEdicao = true;
            txtDescricaoPlano.NaoAjustarEdicao = true;
            this.Limpar = true;
        }

        ~HacPlano()
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

        private bool modoConsulta = false;
        [Category("Hac")]
        [Description("Modo consulta (exibe todos)")]
        public bool ModoConsulta
        {
            get { return modoConsulta; }
            set { modoConsulta = value; }
        }

        private bool limpar;
        [Category("Hac")]
        public bool Limpar
        {
            get { return limpar; }
            set
            {
                txtCodigoPlano.Limpar = value;
                txtDescricaoPlano.Limpar = value;
                limpar = value;
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
            txtCodigoPlano.Enabled = true;
            btnPesquisarPlano.Enabled = true;
            txtDescricaoPlano.Enabled = false;

            txtCodigoPlano.Text = string.Empty;
            txtDescricaoPlano.Text = string.Empty;

            _DtoPlano = null;
        }

        private bool enabled;

        public new bool Enabled
        {
            get { return enabled; }
            set
            {
                if (value)
                {
                    txtCodigoPlano.Enabled = true;
                    btnPesquisarPlano.Enabled = true;
                    txtDescricaoPlano.Enabled = false;
                }
                else
                {
                    txtCodigoPlano.Enabled = false;
                    btnPesquisarPlano.Enabled = false;
                    txtDescricaoPlano.Enabled = false;
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
                txtCodigoPlano.NaoAjustarEdicao = value;
                naoAjustarEdicao = value;
            }
        }

        private bool obrigatorio;
        public bool Obrigatorio
        {
            get { return obrigatorio; }
            set
            {
                txtCodigoPlano.Obrigatorio = value;
                obrigatorio = value;
            }
        }

        private string obrigatorioMensagem;
        public string ObrigatorioMensagem
        {
            get { return obrigatorioMensagem; }
            set
            {
                txtCodigoPlano.ObrigatorioMensagem = value;
                obrigatorioMensagem = value;
            }
        }

        private PlanoDTO PesquisarPlano(decimal idtPlano)
        {
            PlanoDataTable dtbPlano = null;
            PlanoDTO dtoPlano = null;

            if (idtConvenio != 0)
            {
                dtoPlano = new PlanoDTO();
                dtoPlano.IdtConvenio.Value = idtConvenio;
                dtoPlano.IdtPlano.Value = idtPlano;
                dtbPlano = Plano.Listar(dtoPlano);
                if (dtbPlano.Rows.Count > 0)
                {
                    dtoPlano = dtbPlano.TypedRow(0);
                }
            }
            return dtoPlano;
        }

        private PlanoDataTable PesquisarPlano(string codigoPlanoHAC)
        {
            PlanoDataTable dtbPlano = null;

            if (idtConvenio != 0)
            {
                PlanoDTO dtoPlano = new PlanoDTO();
                dtoPlano.IdtConvenio.Value = idtConvenio;
                if(idtConvenio != 281)
                dtoPlano.FlSituacaoPlano.Value = "A";
                if (codigoPlanoHAC != null) dtoPlano.CodigoPlanoHAC.Value = codigoPlanoHAC;

                dtbPlano = (PlanoDataTable)BasicFunctions.ValidarVigencia(PlanoDTO.FieldNames.DataInicioVigencia, PlanoDTO.FieldNames.DataFimVigencia, Plano.Listar(dtoPlano));
            }
            else
            {
                MessageBox.Show("Informe o Convênio!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return dtbPlano;
        }

        private void btnPesquisarPlano_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PlanoDataTable dtbPlano = PesquisarPlano(null);
            Cursor.Current = Cursors.Arrow;

            if (dtbPlano != null)
            {
                if (dtbPlano.Rows.Count == 0)
                {
                    
                        MessageBox.Show("Nenhum Plano cadastrado.", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    txtDescricaoPlano.Text = string.Empty;
                    _DtoPlano = null;
                }
                else
                {
                    PlanoDTO dtoPlano = Forms.FrmPesquisaPlano.AbrirPesquisaPlano(dtbPlano);

                    if (dtoPlano != null)
                    {
                        txtCodigoPlano.Text = dtoPlano.CodigoPlanoHAC.Value;
                        txtDescricaoPlano.Text = dtoPlano.NomePlano.Value;

                        _DtoPlano = dtoPlano;

                        CancelEventArgs eCancel = new CancelEventArgs();
                        eCancel.Cancel = !ValidarRegrasPlano();
                        OnPesquisar(eCancel);
                    }
                }
            }

            txtCodigoPlano.RetirarVermelhoCampo();
        }

        private void txtCodigoPlano_Leave(object sender, EventArgs e)
        {
            if (txtCodigoPlano.Text != string.Empty)
            {
                PlanoDataTable dtbPlano = PesquisarPlano(txtCodigoPlano.Text);

                if (dtbPlano != null)
                {
                    if (dtbPlano.Rows.Count == 0)
                    {   
                        
                            MessageBox.Show("Plano não encontrado!", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                        
                        txtDescricaoPlano.Text = string.Empty;
                        _DtoPlano = null;
                    }
                    else if (dtbPlano.Rows.Count == 1)
                    {
                        txtDescricaoPlano.DataBindings.Clear();
                        txtDescricaoPlano.DataBindings.Add(new Binding("Text",
                                dtbPlano, PlanoDTO.FieldNames.NomePlano));

                        _DtoPlano = dtbPlano.TypedRow(0);
                    }
                }
            }
            else
            {
                txtDescricaoPlano.Text = string.Empty;
                _DtoPlano = null;
            }

            CancelEventArgs eCancel = new CancelEventArgs();
            eCancel.Cancel = !ValidarRegrasPlano();
            OnPesquisar(eCancel);        
        }

        private bool ValidarRegrasPlano()
        {
            bool result = true;

            if (DtoPlano != null)
            {
                switch (DtoPlano.FlSituacaoPlano.Value)
                {
                    case "I":
                        if (modoConsulta)
                        {
                            MessageBox.Show("Plano Inativo.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = true;
                        }
                        else
                        {
                            MessageBox.Show("Plano Inativo, favor entrar em contato com o convênio.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Inicializar();
                            result = false;
                        }
                        
                        break;
                    case "S":
                        if (modoConsulta || (DtoPlano.IdtConvenio.Value != null && DtoPlano.IdtConvenio.Value == 281))
                        {
                            //pra acs - CONTRATO SUSPENSO – ATENDER – OBRIGATÓRIO O PACIENTE ASSINAR O TERMO DE RESPONSABILIDADE.
                            if (modoConsulta && (DtoPlano.IdtConvenio.Value != null && DtoPlano.IdtConvenio.Value != 281))
                                MessageBox.Show("ATENÇÃO: PLANO SUSPENSO.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = true;
                        }
                        else
                        {
                            MessageBox.Show("ATENÇÃO: PLANO SUSPENSO.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Inicializar();
                            result = false;
                        }
                
                        break;
                }
            }

            return result;
        }

        public void CarregarPlano(PlanoDTO dtoPlano)
        {
            CancelEventArgs eCancel = new CancelEventArgs();
            if (dtoPlano != null && !dtoPlano.IdtPlano.Value.IsNull)
            {
                dtoPlano = PesquisarPlano(Convert.ToDecimal(dtoPlano.IdtPlano.Value));
                txtCodigoPlano.Text = dtoPlano.CodigoPlanoHAC.Value;

                txtDescricaoPlano.Text = dtoPlano.NomePlano.Value;
                _DtoPlano = dtoPlano;
                eCancel.Cancel = !ValidarRegrasPlano();
            }
            else
            {
                eCancel.Cancel = true;
            }
            
            
            OnPesquisar(eCancel);
        }
        
        public void CarregarPlanoSemValidacao(PlanoDTO dtoPlano)
        {
            CancelEventArgs eCancel = new CancelEventArgs();
            if (dtoPlano != null && !dtoPlano.IdtPlano.Value.IsNull)
            {
                dtoPlano = PesquisarPlano(Convert.ToDecimal(dtoPlano.IdtPlano.Value));
                txtCodigoPlano.Text = dtoPlano.CodigoPlanoHAC.Value;

                txtDescricaoPlano.Text = dtoPlano.NomePlano.Value;
                _DtoPlano = dtoPlano;
                //eCancel.Cancel = !ValidarRegrasPlano();
            }
            else
            {
                eCancel.Cancel = true;
            }


            OnPesquisar(eCancel);
        }

        private PlanoDTO _DtoPlano;
        public PlanoDTO DtoPlano
        {
            get
            {
                return _DtoPlano;
            }
        }

        private int idtConvenio = 0;

        public int IdtConvenio
        {
            get { return idtConvenio; }
            set
            {
                if(value != idtConvenio && this.enabled)
                {
                    Inicializar();
                }
                idtConvenio = value;

            }
        }

    }
}

