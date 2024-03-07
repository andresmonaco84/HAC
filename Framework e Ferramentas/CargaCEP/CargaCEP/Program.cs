using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CargaCEP
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //TipoLogradouro(@"C:\cep\macro\DNE_GU_TIPOS_LOGRADOURO.TXT");

            //Municipio(@"C:\cep\macro\DNE_GU_LOCALIDADES.TXT");

            //Bairros(@"C:\cep\macro\DNE_GU_BAIRROS.TXT");

            Logradouros(@"C:\cep\ceps");

            Console.ReadLine();
        }



        static void Logradouros(string caminho)
        {
            var list = new List<Tipo>();
            var listIbge = new List<Tipo>();


            using (var data = new Data())
            {
                var tipoLogradouros = data.Result("select tis_tlg_cd_tplogradouro, tis_tlg_ds_tplogradouro from tb_tis_tlg_tp_logradouro");

                foreach (DataRow row in tipoLogradouros.Rows)
                {
                    list.Add(new Tipo
                    {
                        Codigo = row["tis_tlg_cd_tplogradouro"].ToString(),
                        Texto = row["tis_tlg_ds_tplogradouro"].ToString().ToString()
                    });
                }
            }

            //using (var data = new Data())
            //{
            //    var ibgetipo = data.Result("select cc.bid_codmun ibge, cc.bid_codmunaux dne  from aux_municipio cc");

            //    foreach (DataRow row in ibgetipo.Rows)
            //    {
            //        list.Add(new Tipo
            //        {
            //            Codigo = row["ibge"].ToString(),
            //            Texto = row["dne"].ToString().ToString()
            //        });
            //    }
            //}


            foreach (var filepath in Directory.GetFiles(caminho))
            {


                int counter = 0;
                string line;

                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader(filepath, Encoding.GetEncoding("iso8859-1"));
                while ((line = file.ReadLine()) != null)
                {
                    counter++;

                    if (counter == 1)
                        continue;

                    var coduf = "";
                    var codmunicipio = "";
                    var nomemunicipio = "";
                    var endereco = "";
                    var bairro = "";
                    var cep = "";
                    var dstipologradouro = "";
                    var codtipologradouro = "";
                    var ibge = "";
                    var tipo = "";
                    var preposicao = "";
                    var patente = "";
                    var complemento = "";

                    var n1 = 0;
                    var n2 = 0;
                    var lado = "";

                    var nomecompleto = "";

                    try
                    {
                        coduf = line.Substring(1, 2).Trim();

                        nomemunicipio = line.Substring(17, 72).Replace('\'', ' ').Trim().ToUpper().RemoveAccents();
                        bairro = line.Substring(94, 8).Replace('\'', ' ').Trim().ToUpper().RemoveAccents();
                        endereco = line.Substring(374, 72).Replace('\'', ' ').Trim();
                        cep = line.Substring(518, 8).Trim();
                        dstipologradouro = line.Substring(259, 26).Replace('\'', ' ').Trim();

                        codmunicipio = line.Substring(9, 8).Trim();

                        tipo = line.Substring(259, 26).Trim() + " ";

                        if (line.Substring(285, 3).Trim() != string.Empty)
                        {
                            preposicao = ", " + line.Substring(285, 3).Trim();
                        }
                        if (line.Substring(288, 72).Trim() != string.Empty)
                        {
                            patente = line.Substring(288, 72).Trim() + " ";
                        }

                        nomecompleto = (patente + endereco + preposicao).ToUpper().RemoveAccents();

                        var tipoCodigo = list.Where(e => e.Texto.Trim().RemoveAccents().ToUpper() == dstipologradouro.RemoveAccents().ToUpper().Trim()).FirstOrDefault();
                        if (tipoCodigo != null)
                        {
                            codtipologradouro = tipoCodigo.Codigo.Trim();
                        }


                        Int32.TryParse(line.Substring(527, 11).Trim(), out n1);
                        Int32.TryParse(line.Substring(538, 11).Trim(), out n2);


                        lado = line.Substring(549, 1);

                        if (n1 > 0 && n2 > 0)
                        {
                            complemento = string.Format("(DO {0} AO {1}) ", n1, n2);
                        }

                        if (n1 == 0 && n2 > 0)
                        {
                            complemento = string.Format("(ATE {1}) ", n1, n2);
                        }

                        if (n1 > 0 && n2 == 0)
                        {
                            complemento = string.Format("(A PARTIR DO {0}) ", n1, n2);
                        }
                        

                        if (lado.Trim() != string.Empty)
                        {
                            switch (lado)
                            {
                                case "D":
                                    complemento = complemento + "(LADO DIREITO)";
                                    break;
                                case "E":
                                    complemento = complemento + "(LADO ESQUERDO)";
                                    break;
                                case "A":
                                    complemento = complemento + "(AMBOS OS LADOS)";
                                    break;
                                case "I":
                                    complemento = complemento + "(LADO IMPAR)";
                                    break;
                                case "P":
                                    complemento = complemento + "(LADO PAR)";
                                    break;
                                default:
                                    break;
                            }

                        }                       



                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        continue;
                    }

                    string sqlString = string.Format("insert into tb_aux_cep\n" +
                                                    "(aux_cep_cd_cep,\n" +
                                                    " aux_cep_nm_logradouro,\n" +
                                                    " aux_mun_sg_uf,\n" +
                                                    " aux_mun_cd_municipio,\n" +
                                                    " aux_bai_cd_bairro,\n" +
                                                    " tis_tlg_cd_tplogradouro, complemento)\n" +
                                                    " values\n" +
                                                    " (\n" +
                                                    " '{0}',\n" +
                                                    " '{1}',\n" +
                                                    " '{2}',\n" +
                                                    " '{3}',\n" +
                                                    " '{4}',\n" +
                                                    " '{5}', '{6}')", cep, nomecompleto, coduf, codmunicipio, bairro, codtipologradouro, complemento.Trim());

                    using (var data = new Data())
                    {
                        data.ExecuteCommand(sqlString);
                    }


                    Console.WriteLine(string.Format("{0} - {1} - {2}", coduf, nomemunicipio, nomecompleto));

                }

                file.Close();
                file.Dispose();
            }

        }

        static void Bairros(string caminho)
        {


            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(caminho, Encoding.GetEncoding("iso8859-1"));
            while ((line = file.ReadLine()) != null)
            {
                counter++;

                if (counter == 1)
                    continue;

                var codmunicipio = "";
                var nome = "";
                var coddne = "";
                var cep = "";

                try
                {
                    coddne = line.Substring(94, 8).Trim();
                    codmunicipio = line.Substring(09, 8).Trim();
                    cep = line.Substring(09, 8).Trim();
                    nome = line.Substring(102, 72).Replace('\'', ' ').Trim().ToUpper().RemoveAccents();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                string sqlString = string.Format("insert into sgs.TB_AUX_BAI_BAIRRO\n" +
                                                    "(aux_bai_cd_local,\n" +
                                                    " aux_bai_nm_bairro,\n" +
                                                    " aux_mun_cd_local, AUX_BAI_CEP)\n" +
                                                    " values\n" +
                                                    " ( '{0}',\n" +
                                                    "   '{1}',\n" +
                                                    "   '{2}')",
                                                coddne, nome, codmunicipio);
                var data = new Data();
                data.ExecuteCommand(sqlString);
                Console.WriteLine(codmunicipio + " - " + nome);

            }

            file.Close();
            file.Dispose();
        }

        static void Municipio(string caminho)
        {


            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(caminho, Encoding.GetEncoding("iso8859-1"));
            while ((line = file.ReadLine()) != null)
            {
                counter++;

                if (counter == 1)
                    continue;

                var coduf = "";
                var codmunicipio = "";
                var nome = "";
                var coddne = "";
                var cep = "";

                try
                {
                    coddne = line.Substring(11, 8).Trim();
                    coduf = line.Substring(3, 2).Trim();
                    codmunicipio = line.Substring(154, 7).Trim();
                    cep = line.Substring(91, 8).Trim();
                    if (codmunicipio.Trim().Length == 0)
                    {
                        continue;
                    }
                    nome = line.Substring(19, 72).Replace('\'', ' ').Trim().ToUpper().RemoveAccents();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                //string sqlString = string.Format("insert into  tb_aux_mun_municipio mun\n" +
                //                "(mun.aux_mun_cd_ibge, mun.aux_mun_sg_uf, mun.aux_mun_nm_municipio, mun.aux_mun_cd_local, mun.aux_mun_cep)\n" +
                //                "values ('{0}', '{1}', '{2}', '{3}', '{4}')",
                //                                codmunicipio, coduf, nome, coddne, cep);

                //try
                //{
                //    var data = new Data();
                //    data.ExecuteCommand(sqlString);
                //}
                //catch (Exception)
                //{

                //}

                var sqlString = string.Format("update tb_aux_mun_municipio mun\n" +
                                                "set mun.aux_mun_sg_uf = '{1}',\n" +
                                                "    mun.aux_mun_nm_municipio = '{2}',\n" +
                                                "    mun.aux_mun_cd_local = '{3}',\n" +
                                                "    mun.aux_mun_cep = '{4}'\n" +
                                                "    where mun.aux_mun_cd_ibge = '{0}' AND mun.aux_mun_cd_local = '{3}'",
                                            codmunicipio, coduf, nome, coddne, cep);

                try
                {


                    var data = new Data();

                    data.ExecuteCommand(sqlString);
                }
                catch (Exception)
                {


                }


                Console.WriteLine(codmunicipio + " - " + nome + " - " + coduf);



            }

            file.Close();
            file.Dispose();
        }

        static void TipoLogradouro(string caminho)
        {
            var data = new Data();

            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(caminho, Encoding.GetEncoding("iso8859-1"));
            while ((line = file.ReadLine()) != null)
            {
                counter++;

                if (counter == 1)
                    continue;

                var cod = "";
                var nome = "";
                var abreviatura = "";

                try
                {
                    cod = line.Substring(4, 3).Trim();
                    nome = line.Substring(7, 72).Trim().RemoveAccents().ToUpper();
                    abreviatura = line.Substring(79, 15).Trim().RemoveAccents().ToUpper();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                    continue;
                }

                //tb_tis_tlg_tp_logradouro tl
                string sqlString = string.Format("insert into tb_tis_tlg_tp_logradouro tl\n" +
                                                "(tl.tis_tlg_cd_tplogradouro, tl.tis_tlg_ds_tplogradouro)\n" +
                                                "values\n" +
                                                "('{0}','{1}')", cod, nome);
                try
                {
                    data.ExecuteCommand(sqlString);
                }
                catch (Exception)
                {

                }


                //TIPO_LOGR
                sqlString = string.Format("insert into TIPO_LOGR T\n" +
                                        "(t.chave_tipo, t.log_tipo, t.nome_tipo, t.abrev_tipo)\n" +
                                        "values\n" +
                                        "({0},1,'{1}', '{2}')", cod, nome, abreviatura);
                try
                {
                    data.ExecuteCommand(sqlString);
                }
                catch (Exception)
                {

                }


                Console.WriteLine(line);



            }

            file.Close();
        }
    }

    public class Tipo
    {
        public string Codigo { get; set; }
        public string Texto { get; set; }

    }

    public static class Extensions
    {
        public static string RemoveAccents(this string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
    }




}
