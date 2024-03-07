using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using HacFramework.Windows.Helpers;
using System.Windows.Forms;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacCmbMes : HacComboBox
    {
        public HacCmbMes()
        {
            InitializeComponent();            
        }

        public HacCmbMes(IContainer container)
        {
            container.Add(this);

            InitializeComponent();            
        }

        public void Inicializar()
        {
            CarregarComboMes();
        }

        [Category("Hac")]
        protected void CarregarComboMes()
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            list.Add(new ListItem("1", "Janeiro".ToUpper()));
            list.Add(new ListItem("2", "Fevereito".ToUpper()));
            list.Add(new ListItem("3", "Março".ToUpper()));
            list.Add(new ListItem("4", "Abril".ToUpper()));
            list.Add(new ListItem("5", "Maio".ToUpper()));
            list.Add(new ListItem("6", "Junho".ToUpper()));
            list.Add(new ListItem("7", "Julho".ToUpper()));
            list.Add(new ListItem("8", "Agosto".ToUpper()));
            list.Add(new ListItem("9", "Setembro".ToUpper()));
            list.Add(new ListItem("10", "Outubro".ToUpper()));
            list.Add(new ListItem("11", "Novembro".ToUpper()));
            list.Add(new ListItem("12", "Dezembro".ToUpper()));

            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ValueMember = ListItem.FieldNames.Key;
            this.DisplayMember = ListItem.FieldNames.Value;
            this.DataSource = list;
            this.SelectedValue = "-1";
        }
    }
}
