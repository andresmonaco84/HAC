using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using HacFramework.Windows.Helpers;

namespace HospitalAnaCosta.SGS.Componentes
{
    public partial class HacPeriodoHrsGerarPedido : HacComboBox
    {
        public HacPeriodoHrsGerarPedido(IContainer container)
        {
            InitializeComponent();            
        }

        public void Carregar()
        {
            List<ListItem> list = new List<ListItem>();
            //list.Add(new ListItem("-1", ""));
            list.Add(new ListItem("4", "4 hrs"));
            list.Add(new ListItem("6", "6 hrs"));
            list.Add(new ListItem("8", "8 hrs"));
            list.Add(new ListItem("12", "12 hrs"));
            list.Add(new ListItem("24", "24 hrs"));

            this.ValueMember = ListItem.FieldNames.Key;
            this.DisplayMember = ListItem.FieldNames.Value;
            this.DataSource = list;
            this.IniciaLista();
        }

        protected override void OnSelectedIndexChanged(EventArgs e) {}
    }
}