using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacDateTimePicker : DateTimePicker
    {
        private bool required;
        private string requiredMessageError;

        public HacDateTimePicker()
        {
            InitializeComponent();
        }

        public HacDateTimePicker(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// Mensagem usada caso o campo seja requerido e não for preenchido
        /// </summary>
        [Category("Hac")]
        public string RequiredMessageError
        {
            get { return requiredMessageError; }
            set { requiredMessageError = value; }
        }

        /// <summary>
        /// Indica se o campo é requerido
        /// </summary>
        /// 
        [Category("Hac")]
        public bool Required
        {
            get { return required; }
            set { required = value; }
        }
        #region "Metodos"
        /// <summary>
        /// Valida se o componente
        /// </summary>
        public void ValidateRequired(Control controlOwner)
        {
            CommonCtrl.ValidateRequired(controlOwner, false);
        }
        /// <summary>
        /// Faz a validação se o campo esta preenchido
        /// </summary>
        /// <returns></returns>
        public bool ValidateRequired()
        {
            return !string.IsNullOrEmpty(this.Value.ToString());
        }

        public void ValidaObjeto(Evento e)
        {
            switch (e)
            {
                case Evento.eNovo:
                    break;
                case Evento.eSalvar:
                    break;
                case Evento.eCancelar:
                    break;
                case Evento.eExcluir:
                    break;
                case Evento.eInicio:
                    break;
                default:
                    break;
            }


        }

        #endregion

    }
}
