using System;
using System.Text;
using HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
    public interface IUtilitario
    {
        DateTime ObterDataHoraServidor();

        object ValidarVigencia(DateTime _dataValidar, string _dataInicioField, string _dataFimField, object _dtb);

        string EmailResponsavelAlmoxarifadoCentral();

        string CelularResponsavelTI();

        string CelularResponsavelFarmacia();

        void EnviarSMS(string destino, string texto);

        void EnviarEmail(string destino, string texto, string assunto);
    }
}