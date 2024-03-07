using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;



namespace HospitalAnaCosta.SGS.Componentes
{
    public partial class HacCmbSetor : HacComboBox
    {
        private string _nomeComboLocal;
        [Category("Hac")]
        [Description("Nome do objeto combo referente ao Local. Se este campo não está preenchido, ele pega todo objeto HacCmbLocal")]
        public string NomeComboLocal
        {
            get { return _nomeComboLocal; }
            set { _nomeComboLocal = value; }
        }

        private bool _internacao;
        private bool _comEstoque;

        [Category("Hac")]
        public bool Internacao
        {
            get { return _internacao; }
            set { _internacao = value; }
        }

        [Category("Hac")]
        public bool ComEstoque
        {
            get { return _comEstoque; }
            set { _comEstoque = value; }
        }

        #region SERVICO
        private ISetor _setor;
        protected ISetor Setor
        {
            get { return _setor != null ? _setor : _setor = (ISetor)GlobalComponentes.Componentes.GetObject(typeof(ISetor)); }
        }

        private IUnidadeLocalSetorUsuario _seervicosetorusuario;
        protected IUnidadeLocalSetorUsuario ServicoSetorUsuario
        {
            get { return _seervicosetorusuario != null ? _seervicosetorusuario : _seervicosetorusuario = (IUnidadeLocalSetorUsuario)GlobalComponentes.Seguranca.GetObject(typeof(IUnidadeLocalSetorUsuario)); }
        }

        #endregion

        private bool _setorusuario;
        [Category("Hac")]
        [DisplayName("Filtra Setore Usuário")]
        [Description("Filtra Setores que usuário tem acesso")]
        public bool SetorUsuario
        {
            get { return _setorusuario; }
            set { _setorusuario = value; }
        }

        private decimal _idtusuario;
        [Category("Hac")]
        [Description("ID do usuário conectado")]
        public decimal IdtUsuario
        {
            get { return _idtusuario; }
            set { _idtusuario = value; }
        }



        public HacCmbSetor()
        {            
            InitializeComponent();
            Internacao = true;
            ComEstoque = true;
        }
        
        public HacCmbSetor(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Internacao = true;
            ComEstoque = true;
        }

        public void CarregaSetor(SetorDTO dtoSetor)
        {
            this.Limpa();
            this.ValueMember = SetorDTO.FieldNames.Idt;
            this.DisplayMember = SetorDTO.FieldNames.Descricao;
            //this.DataSource = Setor.Sel(dtoSetor).DefaultView;

            if (_setorusuario)
            {
                if (_idtusuario == 0)
                {
                    MessageBox.Show("Falta ID do usuário", "Dentro Componente", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;

                }
                UnidadeLocalSetorUsuarioDTO dto = new UnidadeLocalSetorUsuarioDTO();
                dto.IdtUnidade.Value = dtoSetor.IdtUnidade.Value;
                dto.IdtLocalAtendimento.Value = dtoSetor.IdtLocalAtendimento.Value;
                dto.IdtUsuario.Value = _idtusuario;
                this.DataSource = ServicoSetorUsuario.Sel(dto);
            }
            else
            {
                if (ComEstoque)
                    dtoSetor.PossuiEstoqueProprio.Value = "S";

                this.DataSource = Setor.Sel(dtoSetor);
            }

            this.IniciaLista();
        }
        
        private HacCmbLocal FindLocal(ControlCollection controls)
        {
            Control control = null;
            foreach (Control ctr in controls)
            {
                if ((ctr is HacCmbLocal && string.IsNullOrEmpty(this.NomeComboLocal)) ||
                    (ctr is HacCmbLocal && ctr.Name == this.NomeComboLocal))
                {
                    control = ctr;
                    break;
                }
                else
                {
                    control = FindLocal(ctr.Controls);
                    if (control != null) break;
                }
            }
            return control == null ? null : (HacCmbLocal)control;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            HacCmbLocal cmbLocal = FindLocal(this.FindForm().Controls);

            if (cmbLocal != null)
            {
                if (cmbLocal.SelectedIndex == -1)
                {
                    if (this.SelectedIndex == -1) this.Limpa();
                }                
            }            
            
            base.OnSelectedIndexChanged(e);
        }

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True.        
        /// </summary>
        public void LimparCmbSetor()
        {
            if (this.Limpar) this.LimparComboBox();
        }

        /// <summary>
        /// Zera o DataSource e os itens deste combo
        /// </summary>
        public void Limpa()
        {
            this.DataSource = null;
            this.Items.Clear();
            this.Text = string.Empty;
        }
    }
}