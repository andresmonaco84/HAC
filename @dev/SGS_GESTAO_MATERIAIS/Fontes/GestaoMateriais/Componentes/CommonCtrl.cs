using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes.Exceptions;
using System.Drawing;

namespace HospitalAnaCosta.SGS.Componentes
{
    public class CommonCtrl
    {
        /// <summary>
        /// Faz a validação dos controles que devem que são necessários e estão no form
        /// </summary>
        /// <param name="controlOwner">instancia do controle container</param>
        /// <param name="recursive">caso falso, causa o erro ja no primeiro incidente</param>
        /// <exception cref="Dynamic.Windows.Forms.DynamicRequiredFieldException">Dispara um erro quando algum elemento obrigatório da tela nao foi preenchido</exception>
        public static void ValidateRequired(Control controlOwner, bool recursive)
        {
            // verifica se o 
            List<string> errorList = new List<string>();
            ValidateRequired(controlOwner, recursive, errorList);

            //cria uma lista de erros
            if (errorList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string err in errorList)
                {
                    sb.Append(err);
                    sb.Append("/n/r");
                }

                throw new HacRequiredFieldException(sb.ToString());
            }
        }

        private static void ValidateRequired(Control controlOwner, bool recursive, List<string> errorList)
        {
            //Caso o controle seja um IDynamicRequiredControl faz a validação
            if (controlOwner is IHacRequiredControl)
            {
                IHacRequiredControl ctrl = (IHacRequiredControl)controlOwner;
                // valida se eh requirido
                if (ctrl.Obrigatorio && controlOwner.Visible && controlOwner.Enabled)
                {
                    //Pede que o controle faça a validação
                    if (!ctrl.ValidateRequired())
                    {
                        //Caso nao seja necesário fazer a validação de todos os itens
                        if (!recursive)
                        {
                            throw new HacRequiredFieldException(ctrl.ObrigatorioMensagem);
                        }
                        else
                        {
                            errorList.Add(ctrl.ObrigatorioMensagem);
                        }
                    }
                }
            }
            // caso o controle tenha controles internos, faz a chamada recursiva
            if (controlOwner.HasChildren && controlOwner.Visible && controlOwner.Enabled)
            {
                foreach (Control ctrlChild in controlOwner.Controls)
                {
                    ValidateRequired(ctrlChild, recursive, errorList);
                }
            }
        }

        /// <summary>
        /// Faz a validacao para o tipo de dado digitado para verificacao 
        /// </summary>
        /// <param name="acceptdFormat"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidateContentType(AcceptedFormat acceptedFormat, string value)
        {
            bool ret = true;
            try
            {
                switch (acceptedFormat)
                {
                    case AcceptedFormat.Numerico:
                        Decimal i;
                        ret = Decimal.TryParse(value, out i);
                        break;
                    case AcceptedFormat.Decimal:
                        decimal d;
                        ret = decimal.TryParse(value, out d);
                        break;
                    case AcceptedFormat.Data:
                        DateTime dt;
                        ret = DateTime.TryParse(value, out dt);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        /// <summary>
        /// Faz a validacao para o tipo de dado digitado para verificacao 
        /// </summary>
        /// <param name="acceptdFormat"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidateContentType(AcceptedFormatMasked acceptedFormat, string value)
        {
            bool ret = true;
            try
            {
                switch (acceptedFormat)
                {
                    case AcceptedFormatMasked.Data:
                        DateTime dt;
                        ret = DateTime.TryParse(value, out dt);
                        break;
                    case AcceptedFormatMasked.Hora:
                        ret = DateTime.TryParse(value, out dt);
                        break;
                    case AcceptedFormatMasked.Telefone:
                        ret = true;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        /// <summary>
        /// Chama o metodo dentro do objeto passado como Parametro
        /// </summary>
        /// <param name="e"></param>
        /// <param name="controle"></param>
        public static void ValidaObjeto(Evento e, Control controle)
        {
            // chamada da FrmBase não precisa retornar NADA
            string Mensagem = string.Empty;

            if (controle is IHacRequiredControl)
            {
                IHacRequiredControl ctr = (IHacRequiredControl)controle;
                // chama metodo do objeto
                if (!ctr.ValidaObjeto(e, ref Mensagem))
                {
                    throw new HacRequiredFieldException(Mensagem);
                }
            }
        }

        public static void Controla(Evento e, Control controle)
        {
            string Mensagem = string.Empty;

            if (controle is IHacRequiredControl)
            {
                IHacRequiredControl ctr = (IHacRequiredControl)controle;
                // chama metodo do objeto
                ctr.Controla(e);
            }
        }

        public static void Habilitar(Control ctr )
        {            
            if (!(ctr is HacCheckBox) && !(ctr is HacRadioButton) && !(ctr is HacDataGridView))
                ctr.BackColor = Color.Honeydew;

            if (ctr is HacButton)
                ctr.BackColor = Color.Transparent;

            ctr.Enabled = true;
        }

        public static void Desabilitar(Control ctr)
        {
            if (!(ctr is HacCheckBox) && !(ctr is HacRadioButton) && !(ctr is HacDataGridView))
                ctr.BackColor = Color.White;

            if (ctr is HacButton)
                ctr.BackColor = Color.Transparent;

            ctr.Enabled = false;
        }

        /// <summary>
        /// Valida CPF
        /// </summary>
        /// <param name="numeroCPF">CPF</param>
        /// <returns></returns>
        public static bool ValidarCPF(string numeroCPF)
        {
            string valor = numeroCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                valor[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                    return false;

            return true;
        }

    }
}
