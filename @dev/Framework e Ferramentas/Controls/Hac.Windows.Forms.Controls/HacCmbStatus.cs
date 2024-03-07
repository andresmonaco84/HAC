using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using System.Data;
using HacFramework.Windows.Helpers;
using System.Windows.Forms;

namespace Hac.Windows.Forms.Controls
{     
    public partial class HacCmbStatus : HacComboBox
    {
        public HacCmbStatus()
        {
            InitializeComponent();
        }

        public HacCmbStatus(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Inicializar()
        {
            CarregarComboStatus();
        }

        [Category("Hac")]
        protected void CarregarComboStatus()
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            list.Add(new ListItem("A", "ATIVO"));
            list.Add(new ListItem("I", "INATIVO"));

            this.ValueMember = ListItem.FieldNames.Key;
            this.DisplayMember = ListItem.FieldNames.Value;
            this.DataSource = list;
            this.SelectedValue = "-1";
        }
    }
}

