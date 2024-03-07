using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace HospitalAnaCosta.Framework
{
    public class BasicFunctions
    {
        #region "Criptografia"

        /// <summary>
        /// Decriptografa string passada por parâmetro
        /// </summary>
        /// <param name="strToEncrypt">String que será decriptografada</param>
        /// <returns>String Decriptografada</returns>
        public static string DecryptFromBase64String(string strToDecrypt)
        {
            if (strToDecrypt == null || strToDecrypt == "") return "";

            byte[] inputByteArray = Convert.FromBase64String(strToDecrypt);
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(inputByteArray);
        }

        /// <summary>
        /// Criptografa string passada por parâmetro
        /// </summary>
        /// <param name="strToEncrypt">String que será criptografada</param>
        /// <returns>String Criptografada</returns>
        public static string EncryptToBase64String(string strToEncrypt)
        {
            if (strToEncrypt == null || strToEncrypt == "")
                return "";

            byte[] bytInputArray = System.Text.Encoding.UTF8.GetBytes(strToEncrypt);
            return Convert.ToBase64String(bytInputArray);
        }

        /// <summary>
        /// Criptografa string informada utilizando MD5 Hash
        /// </summary>
        /// <param name="value">Valor Informado a ser criptografado</param>
        /// <returns>String Criptografada</returns>
        public static string CriptografarMd5Hash(string value)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// Compara a string informada com uma string já convertida para MD5 Hash
        /// </summary>
        /// <param name="value">Valor informado e ainda não convertido para MD5 Hash</param>
        /// <param name="hash">String já convertida em MD5 Hash, usada para comparação</param>
        /// <returns>True, se as strings forem iguais; False, se as strings forem diferentes</returns>
        public static bool VerificarMd5Hash(string value, string hash)
        {
            string hashOfInput = CriptografarMd5Hash(value);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion "FIM - Criptografia"

        #region "Manipulação de Datas"

        #region "Conversão Data"

        /// <summary>
        /// Converte para um string a partir de um objeto DateTime
        /// </summary>
        /// <param name="datData">Objeto DateTime</param>
        /// <returns>Data no formato dd/MM/yyyy</returns>
        public static string ConverterDataString(DateTime? datData)
        {
            return ConverterDataString(datData, "dd/MM/yyyy");
        }

        /// <summary>
        /// Converte para um string a partir de um objeto DateTime
        /// </summary>
        /// <param name="datData">Objeto DateTime</param>
        /// <param name="strTipo">Formato da Data (dd/MM/yyyy, MM/dd/yyyy ...)</param>
        /// <returns>Data no formato passado</returns>
        public static string ConverterDataString(DateTime? datData, string strFormato)
        {
            if (datData == null)
            {
                return null;
            }

            try
            {
                return Convert.ToDateTime(datData).ToString(strFormato);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Converte para DateTime a partir de uma String no format dd/MM/yyyy
        /// </summary>
        /// <param name="strData">Data no formato dd/MM/yyyy</param>
        /// <param name="strHora">Hora no formato hh:mm:ss</param>
        /// <returns>Data</returns>
        public static DateTime ConverterStringData(string strData, string strHora)
        {
            try
            {
                if (string.IsNullOrEmpty(strHora))
                {
                    return Convert.ToDateTime(String.Format("{0}/{1}/{2}", strData.Substring(6, 4), strData.Substring(3, 2), strData.Substring(0, 2)));
                }
                else
                {
                    return Convert.ToDateTime(String.Format("{0}/{1}/{2} {3}:{4}:{5}", strData.Substring(6, 4), strData.Substring(3, 2), strData.Substring(0, 2), strHora.Substring(0, 2), strHora.Substring(3, 2), strHora.Substring(6, 2)));
                }
            }
            catch (Exception)
            {
                throw new System.Exception("Erro ao tentar converter data String para DateTime. Formato de data inválido.");
            }
        }

        #endregion "FIM - Conversão Data"

        /// <summary>
        /// Retorna por extenso o dia informado
        /// </summary>
        /// <param name="dt">Data</param>
        /// <returns>String com dia da semana da data por extenso</returns>
        public static string DiaSemanaExtenso(DateTime dt)
        {
            System.Collections.ArrayList arrDay = new System.Collections.ArrayList();
            arrDay.Add("Domingo");
            arrDay.Add("Segunda-feira");
            arrDay.Add("Terça-feira");
            arrDay.Add("Quarta-feira");
            arrDay.Add("Quinta-feira");
            arrDay.Add("Sexta-feira");
            arrDay.Add("Sábado");

            int idxDia = Convert.ToInt32(dt.DayOfWeek);
            return arrDay[idxDia].ToString();
        }

        /// <summary>
        /// Retorna o nome do mês por extenso
        /// </summary>
        /// <param name="intMes">Número do mês - 0 - 12</param>
        /// <returns>Nome do mês por extenso</returns>
        public static string RetornaMes(int intMes)
        {
            switch (intMes)
            {
                case 1:
                    return "Janeiro";
                case 2:
                    return "Fevereiro";
                case 3:
                    return "Março";
                case 4:
                    return "Abril";
                case 5:
                    return "Maio";
                case 6:
                    return "Junho";
                case 7:
                    return "Julho";
                case 8:
                    return "Agosto";
                case 9:
                    return "Setembro";
                case 10:
                    return "Outubro";
                case 11:
                    return "Novembro";
                case 12:
                    return "Dezembro";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Retorna o número do mês a partir do seu nome
        /// </summary>
        /// <param name="strNomeMes">Nome do mês</param>
        /// <returns>Número do mês</returns>
        public static int RetornaMes(string strNomeMes)
        {
            switch (strNomeMes.ToUpper())
            {
                case "JANEIRO":
                    return 1;
                case "FEVEREIRO":
                    return 2;
                case "MARÇO":
                    return 3;
                case "ABRIL":
                    return 4;
                case "MAIO":
                    return 5;
                case "JUNHO":
                    return 6;
                case "JULHO":
                    return 7;
                case "AGOSTO":
                    return 8;
                case "SETEMBRO":
                    return 9;
                case "OUTUBRO":
                    return 10;
                case "NOVEMBRO":
                    return 11;
                case "DEZEMBRO":
                    return 12;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Retorna o Último dia do Mês atual
        /// </summary>
        /// <returns>DateTime</returns>
        public static DateTime UltimoDiaDoMesAtual()
        {
            DateTime dt;
            if (DateTime.Today.Month == 12)
            {
                dt = new DateTime(DateTime.Today.Year + 1, 11, 1);
                dt = dt.AddDays(-1);
            }
            else
            {
                dt = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1);
                dt = dt.AddDays(-1);
            }

            return dt;
        }

        /// <summary>
        /// Retorna a Última Data do Mês/Ano informado
        /// </summary>
        /// <param name="iMes">Mês</param>
        /// <param name="iAno">Ano</param>
        /// <returns>(DateTime) Último dia do mês/ano informado</returns>
        public static DateTime UltimaDataDoMes(int iMes, int iAno)
        {
            DateTime dt;
            if (iMes == 12)
            {
                dt = new DateTime(iAno + 1, 11, 1);
                dt = dt.AddDays(-1);
            }
            else
            {
                dt = new DateTime(iAno, iMes + 1, 1);
                dt = dt.AddDays(-1);
            }

            return dt;
        }

        /// <summary>
        /// Retorna o Último dia do Mês/Ano informado
        /// </summary>
        /// <param name="intMes">Mês</param>
        /// <param name="intAno">Ano</param>
        /// <returns>Último dia do mês/ano informado</returns>
        public static int UltimoDiaDoMes(int intMes, int intAno)
        {
            DateTime datRetorno;

            if (intMes == 12)
            {
                datRetorno = new DateTime(intAno + 1, 11, 1);
                datRetorno = datRetorno.AddDays(-1);
            }
            else
            {
                datRetorno = new DateTime(intAno, intMes + 1, 1);
                datRetorno = datRetorno.AddDays(-1);
            }

            return datRetorno.Day;
        }

        /// <summary>
        /// Retorna as horas e os minutos em separado.
        /// Por exemplo, é utilizado o formato 745, para corresponder a 7:45h. A função retorna 7 (retorno) e 45 (no parametro)
        /// </summary>
        /// <param name="ref int horaMin">Hora e minuto concatenados</param>
        /// <returns>Hora e minuto separados</returns>
        public static int RetornarHoraMinutoSeparados(ref int horaMin) { 
            int ret = 0;
            if (horaMin.ToString().Length > 2)
            {
                ret = Convert.ToInt32(horaMin.ToString().Remove(horaMin.ToString().Length - 2));
                horaMin = Convert.ToInt32(horaMin.ToString().Substring(horaMin.ToString().Length - 2));
            }
            return ret;
        }

        public static DateTime JuntarData(DateTime _data, string _hora)
        {
            DateTime dataRetorno = new DateTime();

            if (_data != new DateTime() && _hora != "" && ValidarData(_data.ToString()))
            {
                _hora = _hora.PadLeft(4, Convert.ToChar("0"));
                int hora = Convert.ToInt32(_hora.Substring(0, 2));
                int minuto = Convert.ToInt32(_hora.Substring(2, 2));

                dataRetorno = new DateTime(_data.Year, _data.Month, _data.Day, hora, minuto, 0);
            }

            return dataRetorno;
        }

        public static bool ValidarData(string _data)
        {
            DateTime dataOut = new DateTime();
            return DateTime.TryParse(_data, out dataOut);
        }

        public static bool ValidarDataInicioFim(String _txtInicio, String _txtFim)
        {
            StringBuilder busMessage = new StringBuilder();

            if (_txtInicio.Length > 0)
            {
                if (Convert.ToDateTime(_txtInicio) < DateTime.Now.Date)
                {
                    busMessage.Append("A data não pode ser menor que a data atual.");
                }
            }

            if (_txtFim.Length > 0)
            {
                if (_txtInicio.Length > 0 && _txtFim.Length > 0)
                {
                    if (Convert.ToDateTime(_txtInicio) > Convert.ToDateTime(_txtFim))
                    {
                        if (busMessage.Length > 0)
                        {
                            busMessage.Append("\n");
                        }
                        busMessage.Append("A data inicial não pode ser maior que a data final.");
                    }
                }
            }

            if (busMessage.Length > 0)
            {
                throw new HacException(busMessage.ToString());
            }

            return true;
        }

        /// <summary>
        /// Filtrar um DataTable tipado para trazer registros dentro da vigencia pela data atual
        /// </summary>
        /// <param name="_dataInicioField">DTO.FieldNames.DataInicioVigencia</param>
        /// <param name="_dataFimField">DTO.FieldNames.DataFimVigencia</param>
        /// <param name="_dtb">DataTable</param>
        /// <returns></returns>
        public static object ValidarVigencia(string _dataInicioField, string _dataFimField, object _dtb)
        {

            return ValidarVigencia(DateTime.Now, _dataInicioField, _dataFimField, _dtb);

        }

        /// <summary>
        /// Filtrar um DataTable tipado para trazer registros dentro da vigencia pela data atual
        /// </summary>
        /// <param name="_dataInicioField">DTO.FieldNames.DataInicioVigencia</param>
        /// <param name="_dataFimField">DTO.FieldNames.DataFimVigencia</param>
        /// <param name="_dataValidar">Data Validação</param>
        /// <param name="_dtb">DataTable</param>
        /// <returns></returns>
        public static object ValidarVigencia(DateTime _dataValidar, string _dataInicioField, string _dataFimField, object _dtb)
        {
            object dtb = ((DataTable)_dtb).Clone();
            StringBuilder sb = new StringBuilder();
            //DataView dv = ((DataTable)_dtb).DefaultView;
            DataView dv = new DataView((DataTable)_dtb);
            sb.AppendLine(_dataInicioField).Append(" <= #").Append(_dataValidar.Date.ToString("MM/dd/yyyy")).Append("#");
            sb.AppendLine(" AND (").Append(_dataFimField).Append(" IS NULL OR ").Append(_dataFimField).Append(" >= #").Append(_dataValidar.Date.ToString("MM/dd/yyyy")).Append("#)");

            dv.RowFilter = sb.ToString();

            for (int i = 0; i < dv.Count; i++)
            {
                ((DataTable)dtb).ImportRow(dv[i].Row);
            }

            return dtb;
        }

        /// <summary>
        /// Método para fazer validação que
        /// verifica se existe ou não registro em vigência no DataTable,
        /// de acordo com o período passado por parâmetro.
        /// </summary>
        /// <param name="dtb"></param>
        /// <param name="dtIniNovo"></param>
        /// <param name="dtFimNovo">Opcional</param>
        /// <param name="dataInicioField"></param>
        /// <param name="dataFimField"></param>
        /// <param name="idtField"></param>
        /// <param name="idt">Quando inclusão, este campo deve ser null ou igual a 0</param>
        /// <returns></returns>
        public static bool ExisteRegistroVigencia(DataTable dtb,
                                                  DateTime dtIniNovo,
                                                  DateTime? dtFimNovo,
                                                  string dataInicioField,
                                                  string dataFimField,
                                                  string idtField,
                                                  Decimal? idt)
        {
            try
            {
                bool regVigencia = false;
                DateTime dtIniComparar, dtFimComparar;
                if (dtFimNovo == null) dtFimNovo = DateTime.MaxValue;
                if (dtFimNovo < dtIniNovo) return true;
                if (idt == null) idt = 0;
                foreach (DataRow row in dtb.Rows)
                {
                    if (idt.Value == 0 || row[idtField].ToString() != idt.Value.ToString())
                    {
                        dtIniComparar = DateTime.Parse(row[dataInicioField].ToString());
                        if (!string.IsNullOrEmpty(row[dataFimField].ToString()))
                        {
                            dtFimComparar = DateTime.Parse(row[dataFimField].ToString());
                            if ((dtIniNovo >= dtIniComparar && dtFimNovo <= dtFimComparar) ||
                                (dtIniNovo >= dtIniComparar && dtIniNovo <= dtFimComparar) ||
                                (dtFimNovo >= dtIniComparar && dtFimNovo <= dtFimComparar))
                            {
                                regVigencia = true;
                                break;
                            }
                        }
                        else
                        {
                            if ((dtIniNovo >= dtIniComparar) ||
                                (dtIniNovo <= dtIniComparar && dtFimNovo >= dtIniComparar))
                            {
                                regVigencia = true;
                                break;
                            }
                        }
                    }
                }
                return regVigencia;
            }
            catch (Exception ex)
            {
                throw new HacException(string.Format("Houve o seguinte erro ao validar vigência: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Filtrar um DataTable tipado.
        /// </summary>
        /// <param name="_rowfilter"></param>
        /// <param name="_sortOrder"></param>
        /// <param name="_dtb"></param>
        /// <returns></returns>
        public static object FiltrarDataTable(string _rowfilter, string _sortOrder, object _dtb)
        {
            object dtb = ((DataTable)_dtb).Clone();
            //DataView dv = ((DataTable)_dtb).DefaultView;
            DataView dv = new DataView((DataTable)_dtb);
            dv.RowFilter = _rowfilter;
            dv.Sort = _sortOrder;
            for (int i = 0; i < dv.Count; i++)
            {
                ((DataTable)dtb).ImportRow(dv[i].Row);
            }

            return dtb;
        }


        #endregion "FIM - Manipulação de Datas"

        #region "Manipulação de Strings"

        /// <summary>
        /// Remove a formatação do texto, deixando apenas letras e números
        /// Ex: Messabox.Show(RemoverFormatacao("33.564.887/0001-21"))
        ///     Resultado = 33567887000121
        /// </summary>
        /// <param name="value">String com formatação</param>
        /// <returns>String sem formatação, contendo apenas letras e números</returns>
        public static string RemoverFormatacao(string value)
        {
            string strTextoSemFormatacao = null;

            if (String.IsNullOrEmpty(value))
                return null;

            //Verifica cada caracter se é numérico
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsLetterOrDigit(value, i))
                {
                    strTextoSemFormatacao = strTextoSemFormatacao + value.Substring(i, 1);
                }
            }
            return strTextoSemFormatacao;
        }
        public static string RemoverCaracteresAlfanumericos(string value)
        {
            string strTextoSemFormatacao = null;

            if (String.IsNullOrEmpty(value))
                return null;

            //Verifica cada caracter se é numérico
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsDigit(value, i))
                {
                    strTextoSemFormatacao = strTextoSemFormatacao + value.Substring(i, 1);
                }
            }
            return strTextoSemFormatacao;
        }
        /// <summary>
        /// Formata um CEP no formato 99999-999
        /// </summary>
        /// <param name="value">CEP à ser formatado</param>
        /// <returns>CEP formatado</returns>
        public static string FormatarCEP(string value)
        {
            string strCEP = RemoverFormatacao(value);
            if (strCEP.Length != 8)
                return strCEP;

            strCEP = value.Substring(0, 5) + "-" +
                     value.Substring(5, 3);
            return strCEP;
        }

        /// <summary>
        /// Formata um CNPJ válido para o formato 99.999.9999/9999-99
        /// </summary>
        /// <param name="value">CNPJ à ser formatado</param>
        /// <returns>CNPJ formatado</returns>
        public static string FormatarCNPJ(string value)
        {
            string strCnpjFormatado = value.PadLeft(14, '0');
            strCnpjFormatado = strCnpjFormatado.Substring(0, 2) + "." +
                               strCnpjFormatado.Substring(2, 3) + "." +
                               strCnpjFormatado.Substring(5, 3) + "/" +
                               strCnpjFormatado.Substring(8, 4) + "-" +
                               strCnpjFormatado.Substring(12);
            return strCnpjFormatado;
        }

        //TODO: Falta implementar FormatarCPF
        /// <summary>
        /// Formata um CPF válido para o formato 999.999.999/99
        /// </summary>
        /// <param name="value">CPF à ser formatado</param>
        /// <returns>CPF formatado</returns>
        public static string FormatarCPF(string value)
        {
            string strCpfFormatado = value.PadLeft(11, '0');
            strCpfFormatado = strCpfFormatado.Substring(0, 3) + "." +
                               strCpfFormatado.Substring(3, 3) + "." +
                               strCpfFormatado.Substring(6, 3) + "/" +
                               strCpfFormatado.Substring(9);
            return strCpfFormatado;
        }


        public static string ConvertXmlToString(System.Xml.XmlDocument doc)
        {
            if (doc == null) return "";

            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(stringWriter);

            xmlTextWriter.Formatting = System.Xml.Formatting.Indented;
            xmlTextWriter.Indentation = 4;

            doc.WriteTo(xmlTextWriter);

            return stringWriter.ToString();
        }

        public static string Right(string var, int length)
        {
            return var.Length > length ? var.Substring(length) : var;
        }

        public static string Left(string var, int length)
        {
            return var.Length > length ? var.Substring(0, length) : var;
        }

        #endregion "FIM - Manipulação de Strings"

        #region "Verificação Tipo"

        /// <summary>
        /// Verifica se o objeto passado é numérico
        /// </summary>
        /// <param name="objValor">Objeto a ser comparado</param>
        /// <returns>
        /// True : Numérico
        /// False: Não Numérico
        /// </returns>
        public static bool IsNumeric(object objValor)
        {
            // Verifica se não é null ou em branco
            if (objValor != null && objValor.ToString() != String.Empty)
            {
                string strTexto = objValor.ToString();

                // Verifica cada caracter se é numérico
                for (int i = 0; i < strTexto.Length; i++)
                {
                    if (!char.IsNumber(strTexto, i))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifica se o objeto passado é numérico e se suporta o tipo de dados passado
        /// </summary>
        /// <param name="objValor">Objeto a ser comparado</param>
        /// <param name="typTipo">typeof (tipo a ser comparado)</param>
        /// <returns>
        /// True : Numérico
        /// False: Não Numérico
        /// </returns>
        public static bool IsNumeric(object objValor, Type typTipo)
        {
            // Verifica se não é null ou em branco
            if (objValor != null && objValor.ToString() != String.Empty)
            {
                string strTexto = objValor.ToString();

                if (typTipo == typeof(Int16))
                {
                    try
                    {
                        Int16 value = Convert.ToInt16(strTexto);
                    }
                    catch
                    {
                        return false;
                    }
                }
                else if (typTipo == typeof(Int32))
                {
                    try
                    {
                        Int32 value = Convert.ToInt32(strTexto);
                    }
                    catch
                    {
                        return false;
                    }
                }
                else if (typTipo == typeof(Int64))
                {
                    try
                    {
                        Int64 value = Convert.ToInt64(strTexto);
                    }
                    catch
                    {
                        return false;
                    }
                }
                else if (typTipo == typeof(Decimal))
                {
                    try
                    {
                        Decimal value = Convert.ToDecimal(strTexto);
                    }
                    catch
                    {
                        return false;
                    }
                }
                else if (typTipo == typeof(double))
                {
                    try
                    {
                        double value = Convert.ToDouble(strTexto);
                    }
                    catch
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        #endregion "FIM - Verificação Tipo"

    }

    #region "Documentos CPF e CNPJ"
    public class Documentos
    {
        /// <summary>
        /// Validação de CPF
        /// </summary>
        /// <param name="strCPF">CPF</param>
        /// <returns>
        /// True : CPF válido
        /// False: CPF inválido
        /// </returns>
        public static bool CheckCPF(string strCPF)
        {
            // Valida digitos
            RegexOptions options = new RegexOptions();
            options |= RegexOptions.Singleline;

            if (Regex.IsMatch(strCPF, "[^0-9]+", options))
            {
                return false;
            }

            // Valida se não é 00000000000, 99999999999
            for (int intCtr = 0; intCtr < 10; intCtr++)
            {
                if (Regex.IsMatch(strCPF, "^[" + intCtr.ToString() + "]+", options))
                {
                    Match mc = Regex.Match(strCPF, "^[" + intCtr.ToString() + "]+", options);

                    if (mc.Length >= 11)
                    {
                        return false;
                    }
                }
            }

            // Calculo de validação
            int intSoma, intResto;
            int[] arrIntDigitos;

            if (strCPF.Length == 0)
            {
                return (true);
            }

            if (strCPF.Length != 11)
            {
                return (false);
            }

            arrIntDigitos = new int[11];

            for (int intCtr = 0; intCtr < 11; intCtr++)
            {
                switch (strCPF.Substring(intCtr, 1))
                {
                    case "0":
                        arrIntDigitos[intCtr] = 0; 
                        break;
                    case "1":
                        arrIntDigitos[intCtr] = 1; 
                        break;
                    case "2":
                        arrIntDigitos[intCtr] = 2; 
                        break;
                    case "3":
                        arrIntDigitos[intCtr] = 3; 
                        break;
                    case "4":
                        arrIntDigitos[intCtr] = 4; 
                        break;
                    case "5":
                        arrIntDigitos[intCtr] = 5; 
                        break;
                    case "6":
                        arrIntDigitos[intCtr] = 6; 
                        break;
                    case "7":
                        arrIntDigitos[intCtr] = 7; 
                        break;
                    case "8":
                        arrIntDigitos[intCtr] = 8; 
                        break;
                    case "9":
                        arrIntDigitos[intCtr] = 9; 
                        break;
                }
            }

            intSoma = 0;

            for (int intCtr = 0; intCtr < 9; intCtr++)
            {
                intSoma = intSoma + (arrIntDigitos[intCtr] * (10 - intCtr));
            }

            intResto = 11 - (intSoma - ((intSoma / 11) * 11));

            if ((intResto == 10) || (intResto == 11))
            {
                intResto = 0;
            }

            if (intResto != arrIntDigitos[9])
            {
                return (false);
            }

            intSoma = 0;

            for (int intCtr = 0; intCtr < 10; intCtr++)
            {
                intSoma = intSoma + (arrIntDigitos[intCtr] * (11 - intCtr));
            }

            intResto = 11 - (intSoma - ((intSoma / 11) * 11));

            if ((intResto == 10) || (intResto == 11))
            {
                intResto = 0;
            }

            if (intResto != arrIntDigitos[10])
            {
                return (false);
            }

            return true;
        }

        /// <summary>
        /// Validação de CNPJ
        /// </summary>
        /// <param name="CNPJ">CNPJ</param>
        /// <returns>
        /// True : CNPJ válido
        /// False: CNPJ inválido
        /// </returns>
        public static bool CheckCNPJ(string strCNPJ)
        {
            bool[] arrBlnCNPJOk;
            int[] arrIntDigitos, arrIntSoma, arrIntResultado;
            string ftmt;

            if (strCNPJ == "00000000000000")
            {
                return false;
            }

            ftmt = "6543298765432";
            arrIntDigitos = new int[14];
            arrIntSoma = new int[2];
            arrIntSoma[0] = 0;
            arrIntSoma[1] = 0;
            arrIntResultado = new int[2];
            arrIntResultado[0] = 0;
            arrIntResultado[1] = 0;
            arrBlnCNPJOk = new bool[2];
            arrBlnCNPJOk[0] = false;
            arrBlnCNPJOk[1] = false;

            for (int intDigito = 0; intDigito < 14; intDigito++)
            {
                arrIntDigitos[intDigito] = int.Parse(strCNPJ.Substring(intDigito, 1));

                if (intDigito <= 11)
                {
                    arrIntSoma[0] += (arrIntDigitos[intDigito] * int.Parse(ftmt.Substring(intDigito + 1, 1)));
                }

                if (intDigito <= 12)
                {
                    arrIntSoma[1] += (arrIntDigitos[intDigito] * int.Parse(ftmt.Substring(intDigito, 1)));
                }
            }

            for (int intDigito = 0; intDigito < 2; intDigito++)
            {
                arrIntResultado[intDigito] = (arrIntSoma[intDigito] % 11);

                if ((arrIntResultado[intDigito] == 0) || (arrIntResultado[intDigito] == 1))
                {
                    arrBlnCNPJOk[intDigito] = (arrIntDigitos[12 + intDigito] == 0);
                }
                else
                {
                    arrBlnCNPJOk[intDigito] = (arrIntDigitos[12 + intDigito] == (11 - arrIntResultado[intDigito]));
                }
            }

            return (arrBlnCNPJOk[0] && arrBlnCNPJOk[1]);
        }        
    }

    #endregion "FIM - Documentos CPF e CNPJ"
        
    #region "Classe Extenso"

    /// <summary>
    /// Classe contendo métodos que retornam números por extenso
    /// </summary>
    public class Extenso
    {
        #region "Campos privados"

        private String[] _u = {
								  "", "um", "dois", "três", "quatro", 
								  "cinco", "seis", "sete", "oito", "nove", 
								  "dez", "onze", "doze", "treze", "quatorze",
								  "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" 
                              };

        private String[] _d = {
								  "", "", "vinte", "trinta", "quarenta",
								  "cinquenta", "sessenta", "setenta", "oitenta", "noventa" 
                              };

        private String[] _c = {
								  "", "cento", "duzentos", "trezentos", "quatrocentos",
								  "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos"
                              };

        private String[] nome = { 
									"hum bilhão", " bilhões", "hum milhão", " milhões" 
                                };
        #endregion "FIM - Campos privados"

        #region "Numero Por Extenso"

        /// <summary>
        /// Retorna o número passado por extenso
        /// </summary>
        /// <param name="decValor">Valor que será retornado por extenso</param>
        /// <returns>Valor por extenso</returns>
        public string NumeroPorExtenso(decimal decValor)
        {
            if (decValor == 0)
            {
                return "zero";
            }

            #region "Calcula valores"

            Decimal mil_milhoes;
            Decimal milhoes;
            Decimal milhares;
            Decimal unidades;
            Decimal centavos;
            Decimal n = (long)decValor;
            Decimal frac = decValor - n;

            // Mil-Milhões
            mil_milhoes = (n - n % 1000000000) / 1000000000;
            n -= mil_milhoes * 1000000000;

            // Milhões
            milhoes = (n - n % 1000000) / 1000000;
            n -= milhoes * 1000000;

            // Milhares
            milhares = (n - n % 1000) / 1000;
            n -= milhares * 1000;

            // Unidades
            unidades = n;

            // Arredondamento de centavos
            centavos = (long)(frac * 100);

            if ((long)(frac * 1000 % 10) > 5)
            {
                centavos++;
            }

            #endregion "FIM - Calcula valores"

            #region "Monta valor por extenso"

            StringBuilder s = new StringBuilder();

            if (mil_milhoes > 0)
            {
                if (mil_milhoes == 1)
                {
                    s.Append(nome[0]);
                }
                else
                {
                    s.Append(NumeroPorExtenso1a999(mil_milhoes));
                    s.Append(nome[1]);
                }

                if ((unidades == 0) && ((milhares == 0) && (milhoes > 0)))
                {
                    s.Append(" e ");
                }
                else if ((unidades != 0) || ((milhares != 0) || (milhoes != 0)))
                {
                    s.Append(", ");
                }
            }

            if (milhoes > 0)
            {
                if (milhoes == 1)
                {
                    s.Append(nome[2]);
                }
                else
                {
                    s.Append(NumeroPorExtenso1a999(milhoes));
                    s.Append(nome[3]);
                }

                if ((unidades == 0) && (milhares > 0))
                {
                    s.Append(" e ");
                }
                else if ((unidades != 0) || (milhares != 0))
                {
                    s.Append(", ");
                }
            }

            if (milhares > 0)
            {
                if (milhares != 1)
                {
                    s.Append(NumeroPorExtenso1a999(milhares));
                }

                s.Append("hum mil");

                if (unidades > 0)
                {
                    if ((milhares > 100) && (unidades > 100))
                    {
                        s.Append(", ");
                    }
                    else if (((unidades % 100) != 0) || ((unidades % 100 == 0) && (milhares < 10)))
                    {
                        s.Append(" e ");
                    }
                    else
                    {
                        s.Append(" ");
                    }
                }
            }

            s.Append(NumeroPorExtenso1a999(unidades));

            if (decValor > 0)
            {
                s.Append(((long)decValor == 1L) ? " real" : " reais");
            }

            if (centavos != 0)
            {
                s.Append(" e ");
                s.Append(NumeroPorExtenso1a999(centavos));
                s.Append((centavos == 1) ? " centavo" : " centavos");
            }

            #endregion "FIM - Monta valor por extenso"

            return s.ToString();
        }

        #endregion "FIM - Numero Por Extenso"

        #region "Numero Por Extenso (1 a 999)"

        /// <summary>
        /// Retorna o número passado por extenso
        /// </summary>
        /// <param name="decValor">Valor que será retornado por extenso</param>
        /// <returns>Valor por extenso</returns>
        private string NumeroPorExtenso1a999(decimal decValor)
        {
            #region "Verifica valor"

            if (decValor > 999)
            {
                return "Erro: número > 999";
            }

            if (decValor < 0)
            {
                return "Erro: número < 0";
            }

            #endregion "FIM - Verifica valor"

            #region "Monta valor por extenso"

            if (decValor == 100)
            {
                return "cem";
            }

            string extensoDoNumero = String.Empty;

            if (decValor > 99)
            {
                extensoDoNumero += _c[(int)(decValor / 100)];

                if (decValor % 100 > 0)
                {
                    extensoDoNumero += " e ";
                }
            }

            if (decValor % 100 < 20)
            {
                extensoDoNumero += _u[(int)decValor % 100];
            }
            else
            {
                extensoDoNumero += _d[((int)decValor % 100) / 10];

                if ((decValor % 10 > 0) && (decValor > 10))
                {
                    extensoDoNumero += " e ";
                    extensoDoNumero += _u[(int)decValor % 10];
                }
            }

            #endregion "FIM - Monta valor por extenso"

            return extensoDoNumero;
        }

        #endregion "FIM - Numero Por Extenso (1 a 999)"
    }

    #endregion "FIM - Classe Extenso"

    #region "Conversão horas/minutos"
    public class Hora
    {
        /// <summary>
        /// Converte horas no formato HH:MM em minutos
        /// </summary>
        /// <param name="sQtdHoras">Quantidade de horas, ex: 160:00 </param>
        /// <returns>Minutos</returns>
        public static decimal? ConverteHHMM2Minutos(string sQtdHoras)
        {
            if (sQtdHoras != null && sQtdHoras.Trim().Length > 0)
            {
                if (sQtdHoras.Length > 6)
                    throw new Exception("Quantidade de horas não pode ter mais que 6 caracteres");

                //Recupero a posição do caractes ":"
                int iPosicao2Pontos = sQtdHoras.IndexOf(':');

                //Recupero as Horas
                string sHoras = sQtdHoras.Substring(0, iPosicao2Pontos);

                //Recupero os minutos
                string sMinutos = sQtdHoras.Substring(iPosicao2Pontos + 1);

                //Converto Horas em minutos
                decimal dMinutos = Convert.ToDecimal(sHoras) * 60;

                //Somo os minutos calculados com o minutos
                dMinutos += Convert.ToDecimal(sMinutos);
                return dMinutos;
            }
            else
                return null;
        }

        /// <summary>
        /// Converte Minutos em Horas no formato HH:MM
        /// </summary>
        /// <param name="pdQtdMinutos">Quantidade de minutos</param>
        /// <returns>String com hora no formato HH:MM, ex: 160:00</returns>
        public static string ConverteMinutos2HHMM(decimal? pdQtdMinutos)
        {
            if (pdQtdMinutos == null || pdQtdMinutos == 0)
            {
                return "00:00";
            }
            else
            {
                decimal dQtdMinutos = (decimal)pdQtdMinutos;
                //Recupera a qtd de horas inteiras
                decimal dQtdHoras = System.Math.Round(dQtdMinutos / 60, 2);
                int iHoraInteiras = (int)dQtdHoras;

                //Recupera a quantidade de minutos
                decimal dMinutos = (dQtdMinutos / 60) - iHoraInteiras;
                dMinutos = System.Math.Round(dMinutos, 2);

                dMinutos = dMinutos * 60;
                int iMinutosInteiros = (int)dMinutos;

                string sHoras = iHoraInteiras.ToString().PadLeft(2, '0');
                sHoras = sHoras + ":" + iMinutosInteiros.ToString().PadLeft(2, '0');

                return sHoras;
            }
        }
    #endregion "FIM - Conversão horas/minutos"
       
    }
    
}
