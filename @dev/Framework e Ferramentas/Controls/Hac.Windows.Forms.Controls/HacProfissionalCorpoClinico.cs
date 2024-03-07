using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using System.Threading;

namespace Hac.Windows.Forms.Controls
{

    public partial class HacProfissionalCorpoClinico : HacUserControl
    {

        /// <summary>
        /// Internado Agenda Eletiva
        /// </summary>
        private IProfissional _profissionalCorpoClinico;
        public IProfissional ProfissionalCorpoClinico
        {
            get
            {
                return _profissionalCorpoClinico != null ? _profissionalCorpoClinico : _profissionalCorpoClinico =
                    (IProfissional)CommonServices.GetObject(typeof(IProfissional));
            }
        }

        /// <summary>
        /// Conselho Profissional
        /// </summary>
        private IConselhoProfissional _conselhoProfissional;
        public IConselhoProfissional ConselhoProfissional
        {
            get
            {
                return _conselhoProfissional != null ? _conselhoProfissional : _conselhoProfissional =
                    (IConselhoProfissional)CommonServices.GetObject(typeof(IConselhoProfissional));
            }
        }

        /// <summary>
        /// UF
        /// </summary>
        private IUF _uf;
        public IUF UF
        {
            get
            {
                return _uf != null ? _uf : _uf =
                    (IUF)CommonServices.GetObject(typeof(IUF));
            }
        }

        public HacProfissionalCorpoClinico()
        {
            InitializeComponent();

        }

        ~HacProfissionalCorpoClinico()
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
        protected virtual void OnPesquisar(EventArgs e)
        {            
            if (Pesquisar != null)
            {
                Pesquisar(this, e);
            }
        }

        public bool ProfissionalDigitadoCarregado
        {
            get 
            {
                if(txtCodigoProfissionalCorpoClinico.Text.Length > 0 && DtoProfissionalCorpoClinico == null)
                {
                    OnPesquisar(null);
                    if(DtoProfissionalCorpoClinico == null)
                    {
                        return false;
                    }
                        
                }
                
                if(txtCodigoProfissionalCorpoClinico.Text.Length == 0 && DtoProfissionalCorpoClinico != null)
                {
                    OnPesquisar(null);
                    {
                        return false;    
                    }
                }

                return true;
            }
        }
        

        public bool SomenteAnestesistas = false;
        public bool SomentePermiteLaudar = false;
      
            public void Inicializar()

        {
            CarregarTipoConselhoProfissionalCorpoClinico();
            CarregarUFConselhoProfissionalCorpoClinico();

            //Deverá sempre apresentar CRM como padrão 
            cboTipoConselhoProfissionalCorpoClinico.SelectedIndex = cboTipoConselhoProfissionalCorpoClinico.FindString("CRM");

            //Deverá sempre apresentar SP como padrão 
            cboUfConselhoProfissionalCorpoClinico.SelectedIndex = cboUfConselhoProfissionalCorpoClinico.FindString("SP");

            //O nome do profissional é apenas exibição
            cboTipoConselhoProfissionalCorpoClinico.Enabled = true;
            cboUfConselhoProfissionalCorpoClinico.Enabled = true;
            txtCodigoProfissionalCorpoClinico.Enabled = true;
            txtNomeProfissionalCorpoClinico.Enabled = false;
            btnPesquisarProfissionalResponsavelAlta.Enabled = true;

            txtCodigoProfissionalCorpoClinico.Text = string.Empty;
            txtNomeProfissionalCorpoClinico.Text = string.Empty;

            DtoProfissionalCorpoClinico = null;
        }

        private bool naoAjustarEdicao;
        public bool NaoAjustarEdicao
        {
            get { return naoAjustarEdicao; }
            set 
            {
                txtCodigoProfissionalCorpoClinico.NaoAjustarEdicao = value;
                txtNomeProfissionalCorpoClinico.NaoAjustarEdicao = value;
                naoAjustarEdicao = value; 
            }
        }

        private bool enabled;
        public new bool Enabled
        {
            get { return enabled; }
            set
            {
                if (value)
                {
                    cboTipoConselhoProfissionalCorpoClinico.Enabled = true;
                    cboUfConselhoProfissionalCorpoClinico.Enabled = true;
                    txtCodigoProfissionalCorpoClinico.Enabled = true;
                    txtNomeProfissionalCorpoClinico.Enabled = false;
                    btnPesquisarProfissionalResponsavelAlta.Enabled = true;
                }
                else
                {
                    cboTipoConselhoProfissionalCorpoClinico.Enabled = false;
                    cboUfConselhoProfissionalCorpoClinico.Enabled = false;
                    txtCodigoProfissionalCorpoClinico.Enabled = false;
                    txtNomeProfissionalCorpoClinico.Enabled = false;
                    btnPesquisarProfissionalResponsavelAlta.Enabled = false;
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
                txtCodigoProfissionalCorpoClinico.Obrigatorio = value;
                obrigatorio = value;
            }
        }

        private string obrigatorioMensagem;
        public string ObrigatorioMensagem
        {
            get { return obrigatorioMensagem; }
            set
            {
                txtCodigoProfissionalCorpoClinico.ObrigatorioMensagem = value;
                obrigatorioMensagem = value;
            }
        }

        private ProfissionalDataTable PesquisarProfissionalCorpoClinico(string ufConselho, string tipoConselho, string codigoConselho)
        {
            try
            {
                if(!SomenteAnestesistas)
                {
                    ProfissionalDataTable dtb = ProfissionalCorpoClinico.ListarProfissionaisComInativos90Dias(ufConselho, tipoConselho, codigoConselho);
                     if (SomentePermiteLaudar)
                     {
                         dtb = (ProfissionalDataTable)BasicFunctions.FiltrarDataTable(ProfissionalDTO.FieldNames.LaudoOk + "='S'", string.Empty, dtb);
                     }
                     return dtb;
                    
                }
                else
                {
                    ProfissionalDataTable dtb = ProfissionalCorpoClinico.ListarAnestesistas();
                    
                    if(codigoConselho != null)
                    {
                        dtb = (ProfissionalDataTable)BasicFunctions.FiltrarDataTable(ProfissionalDTO.FieldNames.ConselhoProfissional + "='" + codigoConselho + "'", string.Empty, dtb);    
                    }
                    return dtb;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ProfissionalDataTable PesquisarProfissionalCorpoClinico(int idtProfissional)
        {
            try
            {
                ProfissionalDTO dtoProfissionalCorpoClinico = new ProfissionalDTO();
                dtoProfissionalCorpoClinico.IdtProfissional.Value = idtProfissional;
                //dtoProfissionalCorpoClinico.AtivoOk.Value = "S";

                return ProfissionalCorpoClinico.Listar(dtoProfissionalCorpoClinico);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarTipoConselhoProfissionalCorpoClinico()
        {
            ConselhoProfissionalDTO dtoConselho = new ConselhoProfissionalDTO();
            cboTipoConselhoProfissionalCorpoClinico.DisplayMember = ConselhoProfissionalDTO.FieldNames.CodigoTipoConselho;
            cboTipoConselhoProfissionalCorpoClinico.ValueMember = ConselhoProfissionalDTO.FieldNames.CodigoTipoConselho;
            cboTipoConselhoProfissionalCorpoClinico.DataSource = ConselhoProfissional.Listar(dtoConselho);
            cboTipoConselhoProfissionalCorpoClinico.IniciaLista();
        }

        private void CarregarUFConselhoProfissionalCorpoClinico()
        {
            UFDTO dtoUF = new UFDTO();
            cboUfConselhoProfissionalCorpoClinico.DisplayMember = UFDTO.FieldNames.Codigo;
            cboUfConselhoProfissionalCorpoClinico.ValueMember = UFDTO.FieldNames.Codigo;
            cboUfConselhoProfissionalCorpoClinico.DataSource = UF.Listar(dtoUF);
            cboUfConselhoProfissionalCorpoClinico.IniciaLista();
        }

        public void btnPesquisarProfissionalCorpoClinico_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ProfissionalDataTable dtbProfissionalCorpoClinico =
                    PesquisarProfissionalCorpoClinico(cboUfConselhoProfissionalCorpoClinico.SelectedValue.ToString(),
                        cboTipoConselhoProfissionalCorpoClinico.SelectedValue.ToString().Trim(),
                        null);
            Cursor.Current = Cursors.Arrow;

            if (dtbProfissionalCorpoClinico.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Profissional encontrado para este UF/CRM!", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNomeProfissionalCorpoClinico.Text = string.Empty;
                _DtoProfissionalCorpoClinico = null;
            }
            else
            {
                ProfissionalDTO dtoProfissionalCorpoClinico = Forms.FrmPesquisaProfissionalCorpoClinico.AbrirPesquisaProfissionalCorpoClinico(dtbProfissionalCorpoClinico);

                if (dtoProfissionalCorpoClinico != null)
                {
                    cboTipoConselhoProfissionalCorpoClinico.SelectedValue = dtoProfissionalCorpoClinico.CodigoConselho.Value;
                    cboUfConselhoProfissionalCorpoClinico.SelectedValue = dtoProfissionalCorpoClinico.UFConselho.Value;
                    txtCodigoProfissionalCorpoClinico.Text = dtoProfissionalCorpoClinico.ConselhoProfissional.Value;
                    txtNomeProfissionalCorpoClinico.Text = dtoProfissionalCorpoClinico.Nome.Value;
                    _DtoProfissionalCorpoClinico = dtoProfissionalCorpoClinico;
                }
            }
            OnPesquisar(new EventArgs());
            
            txtCodigoProfissionalCorpoClinico.RetirarVermelhoCampo();
        
        }

        public void txtCodigoProfissionalCorpoClinico_Leave(object sender, EventArgs e)
        {
            if (txtCodigoProfissionalCorpoClinico.Text != string.Empty 
                && DtoProfissionalCorpoClinico != null 
                && !DtoProfissionalCorpoClinico.CodigoProfissional.Value.IsNull 
                && DtoProfissionalCorpoClinico.CodigoProfissional.Value.ToString().Trim() == txtCodigoProfissionalCorpoClinico.Text.ToString().Trim())
            {
                return;
            }

            if (txtCodigoProfissionalCorpoClinico.Text != string.Empty)
            {

                ProfissionalDataTable dtbProfissionalCorpoClinico =
                        PesquisarProfissionalCorpoClinico(cboUfConselhoProfissionalCorpoClinico.SelectedValue.ToString(),
                            cboTipoConselhoProfissionalCorpoClinico.SelectedValue.ToString().Trim(),
                            txtCodigoProfissionalCorpoClinico.Text);

                if (dtbProfissionalCorpoClinico.Rows.Count == 0)
                {
                    MessageBox.Show("Profissional não encontrado!", "Profissional Corpo Clínico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNomeProfissionalCorpoClinico.Text = string.Empty;
                    _DtoProfissionalCorpoClinico = null;
                }
                else if (dtbProfissionalCorpoClinico.Rows.Count == 1)
                {
                    txtNomeProfissionalCorpoClinico.DataBindings.Clear();
                    txtNomeProfissionalCorpoClinico.DataBindings.Add(new Binding("Text",
                            dtbProfissionalCorpoClinico, ProfissionalDTO.FieldNames.Nome));

                    _DtoProfissionalCorpoClinico = dtbProfissionalCorpoClinico.TypedRow(0);
                }
            }
            else
            {
                txtNomeProfissionalCorpoClinico.Text = string.Empty;
                _DtoProfissionalCorpoClinico = null;
            }
            OnPesquisar(new EventArgs());
        }

        public void CarregarProfissionalCorpoClinico(ProfissionalDTO dtoProfissionalCorpoClinico)
        {
            if (!dtoProfissionalCorpoClinico.IdtProfissional.Value.IsNull || !dtoProfissionalCorpoClinico.ConselhoProfissional.Value.IsNull)
            {

                ProfissionalDataTable dtbProfissionalCorpoClinico;
                if (!dtoProfissionalCorpoClinico.IdtProfissional.Value.IsNull)
                {
                    dtbProfissionalCorpoClinico =
                        PesquisarProfissionalCorpoClinico(Convert.ToInt32(dtoProfissionalCorpoClinico.IdtProfissional.Value));
                }
                else
                {
                    dtbProfissionalCorpoClinico =
                        PesquisarProfissionalCorpoClinico(dtoProfissionalCorpoClinico.UFConselho.Value,
                                                            dtoProfissionalCorpoClinico.CodigoConselho.Value,
                                                            dtoProfissionalCorpoClinico.ConselhoProfissional.Value);
                }


                if (dtbProfissionalCorpoClinico.Rows.Count > 0)
                {
                    txtNomeProfissionalCorpoClinico.DataBindings.Clear();
                    txtNomeProfissionalCorpoClinico.DataBindings.Add(new Binding("Text",
                            dtbProfissionalCorpoClinico, ProfissionalDTO.FieldNames.Nome));

                    dtoProfissionalCorpoClinico = dtbProfissionalCorpoClinico.TypedRow(0);
                    CarregarTipoConselhoProfissionalCorpoClinico();
                    CarregarUFConselhoProfissionalCorpoClinico();

                    cboTipoConselhoProfissionalCorpoClinico.SelectedValue = dtoProfissionalCorpoClinico.CodigoConselho.Value;
                    cboUfConselhoProfissionalCorpoClinico.SelectedValue = dtoProfissionalCorpoClinico.UFConselho.Value;
                    txtCodigoProfissionalCorpoClinico.Text = dtoProfissionalCorpoClinico.ConselhoProfissional.Value;

                    _DtoProfissionalCorpoClinico = dtoProfissionalCorpoClinico;
                }
                OnPesquisar(new EventArgs());
            }
        }

        private ProfissionalDTO _DtoProfissionalCorpoClinico;

        public ProfissionalDTO DtoProfissionalCorpoClinico
        {
            get
            {
                return _DtoProfissionalCorpoClinico;
            }
            set
            {
                _DtoProfissionalCorpoClinico = value;
            }
        }

        public void SetConselhoFixo(string conselho)
        {

            cboTipoConselhoProfissionalCorpoClinico.SelectedValue = conselho;
            cboTipoConselhoProfissionalCorpoClinico.Enabled = false;
        }
    }
}
