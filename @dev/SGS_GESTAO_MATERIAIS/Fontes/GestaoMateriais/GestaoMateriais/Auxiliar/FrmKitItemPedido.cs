using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmKitItemPedido : FrmBase
    {
        RequisicaoItensDataTable _dtbItensKit;

        public FrmKitItemPedido()
        {
            InitializeComponent();
        }

        public static void Pesquisar(RequisicaoItensDataTable dtbItensKit)
        {
            FrmKitItemPedido frm = new FrmKitItemPedido();
            frm._dtbItensKit = dtbItensKit;
            frm.ShowDialog();
        }

        private void FrmKitItemPedido_Load(object sender, EventArgs e)
        {
            dtgPersonalisado.AutoGenerateColumns = false;
            dtgPersonalisado.ReadOnly = true;
            if (_dtbItensKit != null && _dtbItensKit.Rows.Count > 0)
            {
                dtgPersonalisado.DataSource = _dtbItensKit;
                dtgPersonalisado.ClearSelection();
                lblNumReq.Text = _dtbItensKit.TypedRow(0).Idt.Value;
            }
        }

        private void dtgPersonalisado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_dtbItensKit != null && _dtbItensKit.Rows.Count > 0)
            {
                if (dtgPersonalisado.Rows[e.RowIndex].Cells[colDsProd.Name].Value.ToString().ToUpper() ==
                    dtgPersonalisado.Rows[e.RowIndex].Cells[colKitItem.Name].Value.ToString().ToUpper())
                {
                    e.CellStyle.BackColor = Color.LightGray;
                    dtgPersonalisado.Rows[e.RowIndex].Cells[colKitItem.Name].Style.ForeColor = Color.LightGray;
                }
                else
                {
                    if (dtgPersonalisado.Columns[e.ColumnIndex].Name == colDsProd.Name ||
                        dtgPersonalisado.Columns[e.ColumnIndex].Name == colKitAssociado.Name)
                        e.CellStyle.ForeColor = Color.White;
                }
            }
        }
    }
}