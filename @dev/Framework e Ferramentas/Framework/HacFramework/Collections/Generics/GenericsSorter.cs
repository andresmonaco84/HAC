using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace HospitalAnaCosta.Framework.Collections.Generics
{   
    /// <summary>
    /// Classe que ordena uma lista de generics
    /// </summary>
    public class GenericsSorter<T>
    {
        #region "MÉTODOS PRIVADOS"

        /// <summary>
        /// Retorna o resultado da comparação dos dois objetos
        /// </summary>
        /// <param name="obj1">Primeiro objeto a ser comparado</param>
        /// <param name="obj2">Segundo objeto a ser comparado</param>
        /// <param name="strNomePropriedade">Propriedade base da ordenação</param>
        /// <param name="sortDirection">Direção (Ascendente ou Descendente)</param>
        /// <param name="tipo">Tipo dos objetos</param>
        /// <returns>Resultado da comparação dos dois objetos</returns>
        private int Compara(object obj1, object obj2, string strNomePropriedade, SortDirection sortDirection, Type tipo)
        {
            // Verifica se é do tipo int
            if (tipo == typeof(int))
            {
                // Obtém os valores dos objetos
                int intValor1 = (int)obj1;
                int intValor2 = (int)obj2;

                return sortDirection.Equals(SortDirection.Ascending) ? intValor1.CompareTo(intValor2) : intValor2.CompareTo(intValor1);
            }

            // Verifica se é do tipo bool
            if (tipo == typeof(bool))
            {
                // Obtém os valores dos objetos
                bool blnValor1 = (bool)obj1;
                bool blnValor2 = (bool)obj2;

                // Caso a Direção seja ASC, retorna comparação 1->2, caso seja DESC, retorna comparação 2->1
                return sortDirection.Equals(SortDirection.Ascending) ? blnValor1.CompareTo(blnValor2) : blnValor2.CompareTo(blnValor1);
            }

            // Verifica se é do tipo decimal
            if (tipo == typeof(decimal))
            {
                // Obtém os valores dos objetos
                decimal decValor1 = (decimal)obj1;
                decimal decValor2 = (decimal)obj2;

                // Caso a Direção seja ASC, retorna comparação 1->2, caso seja DESC, retorna comparação 2->1
                return sortDirection.Equals(SortDirection.Ascending) ? decValor1.CompareTo(decValor2) : decValor2.CompareTo(decValor1);
            }

            // Verifica se é do tipo Data
            if (tipo == typeof(DateTime))
            {
                // Obtém os valores dos objetos
                DateTime datValor1 = (DateTime)obj1;
                DateTime datValor2 = (DateTime)obj2;

                // Caso a Direção seja ASC, retorna comparação 1->2, caso seja DESC, retorna comparação 2->1
                return sortDirection.Equals(SortDirection.Ascending) ? datValor1.CompareTo(datValor2) : datValor2.CompareTo(datValor1);
            }
            else
            {
                // Se não for nenhum dos tipos acima, assume com sendo string
                string strValor1 = (string)obj1.ToString();
                string strValor2 = (string)obj2.ToString();

                // Caso a Direção seja ASC, retorna comparação 1->2, caso seja DESC, retorna comparação 2->1
                return sortDirection.Equals(SortDirection.Ascending) ? strValor1.CompareTo(strValor2) : strValor2.CompareTo(strValor1);
            }
        }

        /// <summary>
        /// Pega o tipo dos objetos
        /// </summary>
        /// <param name="obj1">objeto 1</param>
        /// <param name="obj2">objeto 2</param>
        /// <param name="strNomePropriedade">Propriedade base da ordenação</param>
        /// <returns>tipo dos objetos</returns>
        private Type PegaTipo(object obj1, object obj2, string strNomePropriedade)
        {
            if (obj1 != null)
            {
                // Pega o tipo do objeto 2 (que não é nulo)
                return obj1.GetType().GetProperty(strNomePropriedade).PropertyType;
            }
            else if (obj2 != null)
            {
                // Pega o tipo do objeto 2 (que não é nulo)
                return obj2.GetType().GetProperty(strNomePropriedade).PropertyType;
            }

            return typeof(String);
        }

        /// <summary>
        /// Pega o resultado da comparação de dois objetos, usando uma propriedade e uma direção
        /// (QUANDO A PROPRIEDADE TEM FILHOS)
        /// </summary>
        /// <param name="obj1">Primeiro objeto a ser comparado</param>
        /// <param name="obj2">Segundo objeto a ser comparado</param>
        /// <param name="strNomePropriedade">Propriedade base da ordenação</param>
        /// <param name="sortDirection">Direção (Ascendente ou Descendente)</param>
        /// <returns>Resultado da comparação dos dois objetos</returns>
        private int PegaValor(object obj1, object obj2, string strNomePropriedade, SortDirection sortDirection)
        {
            // Verifica se tem subpropriedades
            if (strNomePropriedade.IndexOf(".") != -1)
            {
                // Divide a string em PropriedadePai e PropriedadeFilhas
                // Se Pai.Filho => {Pai, Filho}
                // Se Pai.Filho.Neto => {Pai, Filho.Neto}
                string[] strPartes = strNomePropriedade.Split(".".ToCharArray(), 2);

                // Chamada recursiva a este método passando a primeira subpropriedade
                return PegaValor(obj1.GetType().GetProperty(strPartes[0]).GetValue(obj1, null), obj2.GetType().GetProperty(strPartes[0]).GetValue(obj2, null), strPartes[1], sortDirection);
            }
            else
            {
                Type tipo;

                // Pega o tipo do objeto 2 (que não é nulo)
                tipo = PegaTipo(obj1, obj2, strNomePropriedade);

                obj1 = RetornaValor(obj1, strNomePropriedade, tipo);
                obj2 = RetornaValor(obj2, strNomePropriedade, tipo);

                // Chama o método que realiza as comparações
                return Compara(obj1, obj2, strNomePropriedade, sortDirection, tipo);
            }
        }

        /// <summary>
        /// Pega o valor do objeto passado
        /// </summary>
        /// <param name="obj1">Objeto que deseja pegar o valor</param>
        /// <param name="strNomePropriedade">Propriedade base da ordenação</param>
        /// <param name="tipo">Tipo do objeto</param>
        /// <returns>Valor do objeto</returns>
        private object RetornaValor(object obj1, string strNomePropriedade, Type tipo)
        {
            if (string.IsNullOrEmpty(strNomePropriedade))
            {
                return obj1 == null ? RetornaValorMinimo(obj1, tipo) : obj1;
            }
            else
            {
                object objRetorno;

                // Verifica se o objeto é nulo, se for, retorna valor mínimo, senao retorna valor
                objRetorno = obj1 == null ? RetornaValorMinimo(obj1, tipo) : obj1.GetType().GetProperty(strNomePropriedade).GetValue(obj1, null);

                // Caso ainda sim o retorno for nulo, realiza novamente os testes
                if (objRetorno == null)
                {
                    objRetorno = obj1.GetType().GetProperty(strNomePropriedade).GetValue(obj1, null) == null ? RetornaValorMinimo(obj1.GetType().GetProperty(strNomePropriedade).GetValue(obj1, null), tipo) : obj1.GetType().GetProperty(strNomePropriedade).GetValue(obj1, null);
                }

                return objRetorno;
            }
        }

        /// <summary>
        /// Retorna o valor mínimo do tipo passado
        /// </summary>
        /// <param name="obj1">Objeto 1</param>
        /// <param name="tipo">tipo</param>
        /// <returns>Valor mínimo para o tipo</returns>
        private object RetornaValorMinimo(object obj1, Type tipo)
        {
            if (tipo == typeof(Decimal))
            {
                obj1 = Decimal.MinValue;
            }

            if (tipo == typeof(Int16))
            {
                obj1 = Int16.MinValue;
            }

            if (tipo == typeof(Int32))
            {
                obj1 = Int32.MinValue;
            }

            if (tipo == typeof(Int64))
            {
                obj1 = Int64.MinValue;
            }

            if (tipo == typeof(Byte))
            {
                obj1 = Byte.MinValue;
            }

            if (tipo == typeof(String))
            {
                obj1 = String.Empty;
            }

            if (tipo == typeof(DateTime))
            {
                obj1 = DateTime.MinValue;
            }

            return obj1;
        }

        #endregion "FIM - MÉTODOS PRIVADOS"

        #region "MÉTODOS PÚBLICOS"

        /// <summary>
        /// Retorna o sort direction do grid
        /// </summary>
        /// <param name="strDirecao">Direção de ordenação da lista ('ASC' OU 'DESC')</param>
        /// <returns>SORT DIRECTION</returns>
        public SortDirection ObterSortDirection(string strDirecao)
        {
            if (strDirecao.Equals("ASC"))
            {
                return SortDirection.Ascending;
            }

            return SortDirection.Descending;
        }

        /// <summary>
        /// Ordena uma lista de generics
        /// </summary>
        /// <param name="lstTemplate">Lista de generics a ser ordenada</param>
        /// <param name="strNomePropriedade">Propriedade base da ordenação</param>
        /// <param name="sortDirection">Direção (Ascendente ou Descendente)</param>
        /// <returns>Lista de generics já ordenada</returns>
        public List<T> OrdenaLista(List<T> lstTemplate, string strNomePropriedade, SortDirection sortDirection)
        {
            lstTemplate.Sort(delegate(T t1, T t2)
            {
                // Verifica se tem subpropriedades
                if (strNomePropriedade.IndexOf(".") != -1)
                {
                    // Chama o método recursivo que busca o valor da propriedade a ser ordenada
                    return PegaValor((object)t1, (object)t2, strNomePropriedade, sortDirection);
                }
                else
                {
                    Type tipo;

                    // Pega o tipo do objeto 2 (que não é nulo)
                    if ((object)t1.GetType().GetProperty(strNomePropriedade).GetValue(t1, null) != null)
                    {
                        tipo = t1.GetType().GetProperty(strNomePropriedade).GetValue(t1, null).GetType();
                    }
                    else if ((object)t2.GetType().GetProperty(strNomePropriedade).GetValue(t2, null) != null)
                    {
                        tipo = t2.GetType().GetProperty(strNomePropriedade).GetValue(t2, null).GetType();
                    }
                    else
                    {
                        tipo = typeof(String);
                    }

                    object obj1 = RetornaValor((object)t1.GetType().GetProperty(strNomePropriedade).GetValue(t1, null), null, tipo);
                    object obj2 = RetornaValor((object)t2.GetType().GetProperty(strNomePropriedade).GetValue(t2, null), null, tipo);

                    // Retorna a comparação (-1 = false; 0 = true)
                    return Compara(obj1, obj2, strNomePropriedade, sortDirection, tipo);
                }
            });

            return lstTemplate;
        }

        #endregion "FIM - MÉTODOS PÚBLICOS"
    }
}
