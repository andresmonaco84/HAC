using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Componentes;
// using HospitalAnaCosta.SGS.CadastroForms;


namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmTiposCCusto : FrmBase
    {
        public FrmTiposCCusto()
        {
            InitializeComponent();
        }

        #region Objetos Serviço

        // MovimentacaoTipoCCusto
        private LocalEstoqueDTO dtoLocalEstoque;
        private ILocalEstoque _movimentacaoTipoCCusto;
        private ILocalEstoque LocalEstoque
        {
            get { return _movimentacaoTipoCCusto != null ? _movimentacaoTipoCCusto : _movimentacaoTipoCCusto = (ILocalEstoque)Global.Common.GetObject(typeof(ILocalEstoque)); }
        }

        #endregion                

        #region Métodos

        private void CarregaInfoLocalEstoque(LocalEstoqueDTO dto)
        {            
            if (!dto.IdtLocalEstoque.Value.IsNull)
            {
                txtIdtTipoCCusto.Text = this.dtoLocalEstoque.IdtLocalEstoque.Value.ToString();
                txtDescTipoCCusto.Text = this.dtoLocalEstoque.DsLocalEstoque.Value;
                txtTpMovimentacao.Text = dtoLocalEstoque.TpMovimentacaoEntrada.Value;
                cmbUnidade.SelectedValue = this.dtoLocalEstoque.IdtUnidade.Value;
                cmbLocal.SelectedValue = this.dtoLocalEstoque.IdtLocal.Value;
                cmbSetor.SelectedValue = this.dtoLocalEstoque.IdtSetor.Value;
                chbAtivo.Checked = this.dtoLocalEstoque.Ativo.Value == 1 ? true : false;
            }            
        }

        private bool Salvar()
        {
            try
            {
                if (this.Validar())
                {
                    this.dtoLocalEstoque = new LocalEstoqueDTO();

                    //Verifica se está em modo de alteração
                    if (cmbLocalEstoque.Enabled)
                    {
                        this.dtoLocalEstoque.IdtLocalEstoque.Value = decimal.Parse(cmbLocalEstoque.SelectedValue.ToString());
                    }
                    
                    dtoLocalEstoque.DsLocalEstoque.Value = txtDescTipoCCusto.Text;
                    dtoLocalEstoque.IdtUnidade.Value = decimal.Parse(cmbUnidade.SelectedValue.ToString());
                    dtoLocalEstoque.IdtLocal.Value = decimal.Parse(cmbLocal.SelectedValue.ToString());
                    dtoLocalEstoque.IdtSetor.Value = decimal.Parse(cmbSetor.SelectedValue.ToString());
                    dtoLocalEstoque.TpMovimentacaoEntrada.Value = txtTpMovimentacao.Text;
                    dtoLocalEstoque.Ativo.Value = chbAtivo.Checked ? 1 : 0;

                    LocalEstoque.Gravar(this.dtoLocalEstoque);
                                        
                    MessageBox.Show("Registro Salvo com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool Validar()
        {
            return true;
        }

        private void CarregarComboLocalEstoque()
        {
            LocalEstoqueDTO dtoLocEstoque = new LocalEstoqueDTO();
            
            cmbLocalEstoque.DisplayMember = LocalEstoqueDTO.FieldNames.DsLocalEstoque;
            cmbLocalEstoque.ValueMember = LocalEstoqueDTO.FieldNames.IdtLocalEstoque;
            cmbLocalEstoque.DataSource = this.LocalEstoque.Sel(dtoLocEstoque);
            cmbLocalEstoque.IniciaLista();
        }

        private void CarregarDTO(decimal IdtLocalEstoque)
        {
            LocalEstoqueDTO dtoLocEstoque = new LocalEstoqueDTO();

            dtoLocEstoque.IdtLocalEstoque.Value = IdtLocalEstoque;

            this.dtoLocalEstoque = this.LocalEstoque.SelChave(dtoLocEstoque);
        }

        private void ConfigurarControles()
        {
            txtDescTipoCCusto.Enabled = true;
            // base.Controla(Evento.eEditar);
            // tsHac.Controla(Evento.eEditar);
            txtTpMovimentacao.Enabled = true;
            chbAtivo.Enabled = true;            
            cmbUnidade.Enabled = true;
            cmbLocal.Enabled = true;
            cmbSetor.Enabled = true;
        }

        private void ConfigurarTela(bool edicaoRegistroExistente)
        {
            cmbLocalEstoque.Enabled = edicaoRegistroExistente;
        }

        #endregion

        #region Eventos

        private void FrmTiposCCusto_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            CarregarComboLocalEstoque();
        }

        private bool tsHac_NovoClick(object sender)
        {
            this.ConfigurarTela(false);
            
            return true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            this.dtoLocalEstoque = null;

            this.ConfigurarTela(true);

            return true;
        }

        private bool tsHac_SalvarClick(object sender)
        {
            bool retorno = this.Salvar();

            this.CarregarComboLocalEstoque();

            this.ConfigurarTela(true);

            return retorno;
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //tsHac.Controla(Evento.eCancelar);
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //tsHac.Controla(Evento.eCancelar);
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //tsHac.Controla(Evento.eCancelar);
        }

        private void cmbTiposCCusto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tsHac.Controla(Evento.eEditar);
            this.CarregarDTO(decimal.Parse(cmbLocalEstoque.SelectedValue.ToString()));
            this.CarregaInfoLocalEstoque(this.dtoLocalEstoque);
            this.ConfigurarControles();
        }
      
        #endregion                
    }
}