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
    public partial class HacCmbDiaSemana : HacComboBox
    {
        public HacCmbDiaSemana()
        {
            InitializeComponent();            
        }

        public HacCmbDiaSemana(IContainer container)
        {
            container.Add(this);

            InitializeComponent();            
        }

        public void Inicializar()
        {
            CarregarComboDiaSemana();
        }
                
        [Category("Hac")]
        protected void CarregarComboDiaSemana()
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            list.Add(new ListItem("1", "Segunda-feira".ToUpper()));
            list.Add(new ListItem("2", "Terça-feira".ToUpper()));
            list.Add(new ListItem("3", "Quarta-feira".ToUpper()));
            list.Add(new ListItem("4", "Quinta-feira".ToUpper()));
            list.Add(new ListItem("5", "Sexta-feira".ToUpper()));
            list.Add(new ListItem("6", "Sábado".ToUpper()));
            list.Add(new ListItem("7", "Domingo".ToUpper()));

            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ValueMember = ListItem.FieldNames.Key;
            this.DisplayMember = ListItem.FieldNames.Value;
            this.DataSource = list;
            this.SelectedValue = "-1";
        }
    }
}