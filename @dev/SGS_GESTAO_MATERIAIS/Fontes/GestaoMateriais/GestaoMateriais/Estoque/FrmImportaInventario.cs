using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    public partial class FrmImportaInventario : FrmBase
    {

        #region OBJETOS SERVIÇOS
        // Movimentos        
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }
        private MovimentacaoDTO dtoMovimentacao;
        private MovimentacaoDataTable dtbMovimentacao;
        #endregion


        public Boolean Importa(MovimentacaoDTO dto)
        {

            FrmImportaInventario imp = new FrmImportaInventario();
            imp.dtoMovimentacao = dto;
            imp.MdiParent = FrmPrincipal.ActiveForm;
            imp.Show();
            return true;
        }

        public FrmImportaInventario()
        {
            InitializeComponent();
        }

        private void hacButton1_Click(object sender, EventArgs e)
        {
            if (txtData.Text == string.Empty)
            {
                MessageBox.Show("Digite a data para Importar", "Importação Inventário", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtData.Focus();
            }
            else
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;                   
                    dtoMovimentacao.DtFaturamento.Value = txtData.Text;
                    int? idGrupo = null;
                    Movimento.ImportaInventario(dtoMovimentacao, idGrupo);
                    
                    MessageBox.Show("Informação Importada com sucesso " );

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não Foi Possivel Importar a Informação " + ex.Message);
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void FrmImportaInventario_Load(object sender, EventArgs e)
        {
            txtUnidade.Text = dtoMovimentacao.DsUnidade.Value;
            txtLocal.Text = dtoMovimentacao.DsLocal.Value;
            txtSetor.Text = dtoMovimentacao.DsSetor.Value;
            txtData.Focus();
        }

        private void hacButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}