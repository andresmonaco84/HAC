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
    public partial class HacCmbTipoPaciente : HacComboBox
    {
        public HacCmbTipoPaciente()
        {
            InitializeComponent();
        }

        public HacCmbTipoPaciente(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Inicializar()
        {
            CarregarComboTipoPaciente();
        }

        [Category("Hac")]
        protected void CarregarComboTipoPaciente()
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            list.Add(new ListItem("A", "AMBULATÓRIO"));
            list.Add(new ListItem("E", "EXTERNO"));
            list.Add(new ListItem("I", "INTERNADO"));
            list.Add(new ListItem("U", "URGÊNCIA"));

            this.ValueMember = ListItem.FieldNames.Key;
            this.DisplayMember = ListItem.FieldNames.Value;
            this.DataSource = list;
            this.SelectedValue = "-1";
        }
    }
}

