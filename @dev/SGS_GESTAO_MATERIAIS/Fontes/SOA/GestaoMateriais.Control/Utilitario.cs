using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Model;
using System.Data;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
    public class Utilitario : Control, IUtilitario
    {
        public DateTime ObterDataHoraServidor()
        {
            return DateTime.Now;
        }

        public object ValidarVigencia(DateTime _dataValidar, string _dataInicioField, string _dataFimField, object _dtb)
        {
            object dtb = ((DataTable)_dtb).Clone();
            StringBuilder sb = new StringBuilder();
            //DataView dv = ((DataTable)_dtb).DefaultView;
            DataView dv = new DataView((DataTable)_dtb);
            sb.AppendLine(_dataInicioField).Append(" <= '").Append(_dataValidar.ToString("dd/MM/yyyy HH:mm")).Append("'");
            sb.AppendLine(" AND (").Append(_dataFimField).Append(" IS NULL OR ").Append(_dataFimField).Append(" >= '").Append(_dataValidar.ToString("dd/MM/yyyy HH:mm")).Append("')");

            dv.RowFilter = sb.ToString();

            for (int i = 0; i < dv.Count; i++)
            {
                ((DataTable)dtb).ImportRow(dv[i].Row);
            }

            return dtb;
        }

        /// <summary>
        /// E-mail da Paula Medina
        /// </summary>   
        public string EmailResponsavelAlmoxarifadoCentral()
        {
            return "paula.carvalho@anacosta.com.br";
        }

        public string EmailFarmaciaClinica()
        {
            return "farmacia.clinica@anacosta.com.br";
        }

        /// <summary>
        /// Celular da Nina
        /// </summary>        
        public string CelularResponsavelTI()
        {
            return "13997857273";
        }

        /// <summary>
        /// Celular da Paula Medina
        /// </summary>   
        public string CelularResponsavelFarmacia()
        {
            return "13997237155";
        }

        public void EnviarSMS(string destino, string texto)
        {
            new Model.FilialMatMed().EnviarSMS(destino, texto);
        }

        public void EnviarEmail(string destino, string texto, string assunto)
        {
            new Model.FilialMatMed().EnviarEmail(destino, texto, assunto);
        }
    }
}