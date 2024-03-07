using System;
using System.Data;
using System.Collections;
using System.Configuration;


namespace HospitalAnaCosta.Framework.Collections.ArrayList
{
    /// <summary>
    /// Ordena o conteúdo de um ArrayList por "Propriedade" ou nome do "Método"
    /// -Permite ordenar por qualquer propriedade, mesmo que ela seja uma Entidade VO "Value Object"
    /// </summary>
    public class ArrayListSorter : IComparer
    {
        protected string sortBy;
        protected SortDirection sortDirection;

        #region Constructors
        public ArrayListSorter(string sortBy, SortDirection sortDirection)
        {
            this.sortBy = sortBy;            
            this.sortDirection = sortDirection;
        }
        #endregion

        int Compare(object x, object y, string comparer)
        {
            if (comparer.IndexOf(".") != -1)
            {
                //split the string
                string[] parts = comparer.Split(new char[] { '.' }, 2);

                return Compare(x.GetType().GetProperty(parts[0]).GetValue(x, null),
                    y.GetType().GetProperty(parts[0]).GetValue(y, null), parts[1]);
            }
            else
            {
                IComparable icx, icy;

                icx = x != null ? (IComparable)x.GetType().GetProperty(comparer).GetValue(x, null) : "";
                icy = y != null ? (IComparable)y.GetType().GetProperty(comparer).GetValue(y, null) : "";

                if (icy != null)
                {
                    icx = icx == null ? RetornaValorMinimo(icx, icy.GetType()) : icx;
                }
                else
                {
                    icx = icx == null ? "" : icx;
                }

                if (icx != null)
                {
                    icy = icy == null ? RetornaValorMinimo(icy, icx.GetType()) : icy;
                }
                else
                {
                    icy = icy == null ? "" : icy;
                }

                if (x.GetType().GetProperty(comparer).PropertyType == typeof(System.String))
                {
                    icx = (IComparable)icx.ToString().ToUpper();
                    icy = (IComparable)icy.ToString().ToUpper();
                }

                if (this.sortDirection == SortDirection.Descending)
                    return icy.CompareTo(icx);
                else
                    return icx.CompareTo(icy);
            }

        }

        public int Compare(object x, object y)
        {
            return Compare(x, y, sortBy);
        }

        private IComparable RetornaValorMinimo(IComparable ic, Type tipo)
        {
            if (tipo == typeof(Decimal))
            {
                ic = Decimal.MinValue;
            }

            if (tipo == typeof(Int16))
            {
                ic = Int16.MinValue;
            }

            if (tipo == typeof(Int32))
            {
                ic = Int32.MinValue;
            }

            if (tipo == typeof(Int64))
            {
                ic = Int64.MinValue;
            }

            if (tipo == typeof(Byte))
            {
                ic = Byte.MinValue;
            }

            if (tipo == typeof(String))
            {
                ic = String.Empty;
            }

            if (tipo == typeof(DateTime))
            {
                ic = DateTime.MinValue;
            }

            return ic;
        }

    }

    public enum SortDirection
    {
        Ascending = 0,
        Descending = 1
    }
    
}
