using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Hac.Windows.Forms.Controls.Code
{
    public static class Funcoes
    {
        public static string tituloSistema = "Internação";
        
        public static int CalcularIdade(DateTime data)
        {
            return (int)((double)new TimeSpan(DateTime.Now.Subtract(data).Ticks).Days / 365.25);
        }
              
        public static DataTable FilterTable(DataTable dt, string filterString)
        {
            DataRow[] filteredRows = dt.Select(filterString);
            DataTable filteredDt = dt.Clone();

            DataRow dr;
            foreach (DataRow oldDr in filteredRows)
            {
                dr = filteredDt.NewRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dr[dt.Columns[i].ColumnName] = oldDr[dt.Columns[i].ColumnName];
                }
                filteredDt.Rows.Add(dr);

            }

            return filteredDt;
        }
    }
}
