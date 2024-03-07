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
using HacFramework.Windows.Helpers;


namespace Hac.Windows.Forms.Controls
{
    public partial class HacBancoConta : HacUserControl
    {

        /// <summary>
        /// CadastroBanco
        /// </summary>
        private ICadastroBanco _cadastroBanco;
        public ICadastroBanco CadastroBanco
        {
            get
            {
                return _cadastroBanco != null ? _cadastroBanco : _cadastroBanco =
                    (ICadastroBanco)CommonServices.GetObject(typeof(ICadastroBanco));
            }
        }

         /// <summary>
        /// AssociacaoBancoConta
        /// </summary>
        private IAssociacaoBancoConta _associacaoBancoConta;
        public IAssociacaoBancoConta AssociacaoBancoConta
        {
            get
            {
                return _associacaoBancoConta != null ? _associacaoBancoConta : _associacaoBancoConta =
                    (IAssociacaoBancoConta)CommonServices.GetObject(typeof(IAssociacaoBancoConta));
            }
        }

        

        public HacBancoConta()
        {
            InitializeComponent();

            cboAgenciaConta.NaoAjustarEdicao = true;
            cboBanco.NaoAjustarEdicao = true;
            this.Limpar = true;
        }

        ~HacBancoConta()
        {
            try
            {
                //_CommonServices = null;
                _cadastroBanco = null;
                _associacaoBancoConta = null;
                idtAssociacaoBancoConta = 0;
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
            CarregarComboBanco();
            idtAssociacaoBancoConta = 0;
        }

        public void Focus()
        {
            cboBanco.Focus();
        }

        private bool enabled;

        public bool Enabled
        {
            get { return enabled; }
            set
            {
                if (value)
                {
                    cboAgenciaConta.Enabled = true;
                    cboBanco.Enabled = true;
                }
                else
                {
                    cboAgenciaConta.Enabled = false;
                    cboBanco.Enabled = false;
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
                cboBanco.Obrigatorio = value;
                cboAgenciaConta.Obrigatorio = value;
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
                cboBanco.ObrigatorioMensagem = value;
                cboAgenciaConta.ObrigatorioMensagem = value;
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
                cboAgenciaConta.NaoAjustarEdicao = value;
                cboBanco.NaoAjustarEdicao = value;
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
                cboAgenciaConta.Limpar = value;
                cboBanco.Limpar = value;
                limpar = value;
            }
        }


        private Int32 idtAssociacaoBancoConta;
        [Category("Hac")]
        public Int32 IdtAssociacaoBancoConta
        {
            get { return idtAssociacaoBancoConta; }
            set
            {
                IdtAssociacaoBancoConta = value;
                IdtAssociacaoBancoConta = value;
                
            }
        }

        public void CarregarComboBanco()
        {
            CadastroBancoDTO dtoCadastroBanco = new CadastroBancoDTO();
            dtoCadastroBanco.FlagAtivo.Value = "A";
            cboBanco.DataSource = null;
            DataTable dtbCadastroBanco = new DataTable();
            dtbCadastroBanco = CadastroBanco.Listar(dtoCadastroBanco);
            DataView dv = dtbCadastroBanco.DefaultView;
            dv.Sort = string.Format("{0} ASC", CadastroBancoDTO.FieldNames.Nome);
            dtbCadastroBanco = dv.ToTable();
            CarregarComboComSelecione(cboBanco, dtbCadastroBanco, CadastroBancoDTO.FieldNames.Idt, CadastroBancoDTO.FieldNames.Codigo, CadastroBancoDTO.FieldNames.Nome);
            
        }

        private void CarregarComboAgenciaConta()
        {
            DataTable dtb = new DataTable();
            AssociacaoBancoContaDTO dtoBCT = new AssociacaoBancoContaDTO();
            dtoBCT.IdtBanco.Value = Convert.ToInt32(cboBanco.SelectedValue);
            dtb = AssociacaoBancoConta.Listar(dtoBCT);
            DataView dv = dtb.DefaultView;
            dv.Sort = string.Format("{0}, {1}, {2}, {3} ASC",
                AssociacaoBancoContaDTO.FieldNames.CodigoAgencia,
                AssociacaoBancoContaDTO.FieldNames.DigitoVerificadorAgencia,
                AssociacaoBancoContaDTO.FieldNames.NumeroConta,
                AssociacaoBancoContaDTO.FieldNames.DigitoVerificadorConta);
            dtb = dv.ToTable();
            //CarregarComboComSelecione(cboAgenciaConta, dtb, AssociacaoBancoContaDTO.FieldNames.Idt, AssociacaoBancoContaDTO.FieldNames.CodigoAgencia);

            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));

            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                string strAgenciaConta = string.Format("{0}-{1} / {2}-{3} / {4}",
                                                       dtb.Rows[i][AssociacaoBancoContaDTO.FieldNames.CodigoAgencia].ToString(),
                                                       dtb.Rows[i][AssociacaoBancoContaDTO.FieldNames.DigitoVerificadorAgencia].ToString(),
                                                       dtb.Rows[i][AssociacaoBancoContaDTO.FieldNames.NumeroConta].ToString(),
                                                       dtb.Rows[i][AssociacaoBancoContaDTO.FieldNames.DigitoVerificadorConta].ToString(),
                                                       dtb.Rows[i][AssociacaoBancoContaDTO.FieldNames.CodigoContaCaixaRM].ToString());
                strAgenciaConta = strAgenciaConta.Replace("- ", " ");
                list.Add(new ListItem(dtb.Rows[i][AssociacaoBancoContaDTO.FieldNames.Idt].ToString(), strAgenciaConta));
            }

            cboAgenciaConta.ValueMember = ListItem.FieldNames.Key;
            cboAgenciaConta.DisplayMember = ListItem.FieldNames.Value;
            cboAgenciaConta.DataSource = list;
            cboAgenciaConta.SelectedIndex = 0;
            //cboAgenciaConta.DataSource = dtb;
        }

        private void cboBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBanco.SelectedIndex > 0)
            {
                CarregarComboAgenciaConta();
            }
            else
            {
                cboAgenciaConta.DataSource = null;
            }
        }

        private void cboAgenciaConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgenciaConta.SelectedIndex > 0)
            {
                idtAssociacaoBancoConta = Convert.ToInt32(cboAgenciaConta.SelectedValue);
            }
            else
            {
                idtAssociacaoBancoConta = 0;
            }
        }

         protected void CarregarComboComSelecione(ComboBox objCombo, DataTable dtbDados, string nomeKey, string nomeValue1,string nomeValue2)
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));

            for (int i = 0; i < dtbDados.Rows.Count; i++)
            {
                list.Add(new ListItem(dtbDados.Rows[i][nomeKey].ToString(), string.Format("{0} - {1}", dtbDados.Rows[i][nomeValue1].ToString(),dtbDados.Rows[i][nomeValue2].ToString())));
            }

            objCombo.ValueMember = ListItem.FieldNames.Key;
            objCombo.DisplayMember = ListItem.FieldNames.Value;
            objCombo.DataSource = list;
            if (objCombo.Items.Count > 1)
                objCombo.SelectedIndex = 0;
        }
      
    }
}