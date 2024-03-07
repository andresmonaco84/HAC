using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.Services.BeneficiarioACS.DTO;
using Microsoft.Win32;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Impressao
{
    public class Utilitario
    {
        private const string _regPath = "Software\\Hospital_Ana_Costa\\GestaoMateriais";        

        public struct PortaComunicacao
        {
            public const string Serial1 = "COM1";
            public const string Paralela1 = "LPT1";
            public const string Serial2 = "COM2";
            public const string Paralela2 = "LPT2";
            public const string USB = "USB";
        }

        public enum ModeloImpressoraPedidos
        {
            BEMATECH = 0,
            BIXOLON = 1
        }

        public static string ModeloImpressoraPedidosNomeRegistro()
        {
            return "ModeloImpressoraPedidos";
        }

        public static string ModeloImpressoraPedidosNomeRegistroBixolon()
        {
            return "ModeloNomeImpressoraPedidosBIXOLON";
        }

        public static string TruncarCampo(string campo, byte qtdMaxCatacteres)
        {
            if (campo == null)
            {
                return string.Empty;
            }
            else
            {
                return (campo.Length > qtdMaxCatacteres) ? campo.Substring(0, qtdMaxCatacteres).Trim() : campo.Trim();
            }
        }

        public static string RetornarCidade(BenefHomeCareDTO dtoBenefHC)
        {
            MunicipioDTO dto = new MunicipioDTO();
            dto.CodigoIBGE.Value = dtoBenefHC.CodigoIBGEMunicipio.Value;
            return ((IMunicipio)Global.Common.GetObject(typeof(IMunicipio))).Pesquisar(dto).NomeMunicipio.Value;
        }

        public static string RetornarEndereco(BenefHomeCareDTO dtoBenefHC)
        {
            return string.Format("{0}, {1}, {2}/{3}", dtoBenefHC.Endereco.Value,
                                                      dtoBenefHC.NumeroEndereco.Value,
                                                      dtoBenefHC.Bairro.Value,
                                                      Utilitario.RetornarCidade(dtoBenefHC));
        }

        public static string FormatarCampo(string campo, byte qtdCatacteres)
        {
            if (campo == null)
            {
                return string.Empty.PadRight(qtdCatacteres, ' ');
            }
            else
            {
                return campo.Trim().PadRight(qtdCatacteres, ' ');
            }
        }

        public static string FormatarMatricula(string matricula, string codSeq)
        {
            return string.Format("{0}-{1}", matricula, codSeq);
        }

        public static string chr(int dec)
        {
            return Convert.ToChar(dec).ToString();
        }

        public static void RegistrarWindows(string valor, string nomeRegistro)
        {
            RegistryKey reg = Registry.CurrentUser;

            reg = reg.OpenSubKey(_regPath, true);

            if (reg == null)
            {
                reg = Microsoft.Win32.Registry.CurrentUser;
                reg = reg.CreateSubKey(_regPath);
            }

            reg.SetValue(nomeRegistro, valor);
        }

        public static string ObterRegistroWindows(string nomeRegistro)
        {
            RegistryKey reg = Registry.CurrentUser;

            reg = reg.OpenSubKey(_regPath, true);

            if (reg.GetValue(nomeRegistro) != null)
            {
                return reg.GetValue(nomeRegistro).ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}