using SGS.ClientControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HospitalAnaCosta.SGS.Impressao
{
    public class Tools
    {
        private ToolsData data = new ToolsData();
        public void DataValidade(AtendimentoEntity atendimentoEntity)
        {
            if (atendimentoEntity.Origem == "1") //LIBERACAO
            {
                DataTable dtbFeriado = data.ConsultarFeriado(atendimentoEntity.IDUnidade, atendimentoEntity.DataSolicitacao);

                DateTime dValidade = Convert.ToDateTime(atendimentoEntity.DataSolicitacao).AddDays(30);
                dValidade = ProximoDiaUtil(dValidade, dtbFeriado);
                if (Convert.ToDateTime(atendimentoEntity.DataAtual) > dValidade)
                    throw new Exception("4");

                atendimentoEntity.Validade = FrmValidade.AbrirDataValidade(atendimentoEntity);
                if (atendimentoEntity.Validade.Length == 0)
                    throw new Exception("5");
            }
        }

        public DateTime ProximoDiaUtil(DateTime dataBase, DataTable dtbFeriado)
        {
            while (isFeriado(dataBase, dtbFeriado))
            {
                dataBase = dataBase.AddDays(1);
            }
            return dataBase;
        }

        /// <summary>
        /// Retorna o próximo dia útil (em relação a feriados e sábados/domingos)
        /// </summary>
        /// <see cref="ObterDiaUtil e, no BD, FNC_DIAS_UTEIS (LEGADO)"/>
        /// <param name="dataBase">Dia para início da verificação</param>
        /// <param name="lstFeriado">Lista de feriados</param>
        public DateTime ProximoDiaUtil(DateTime dataBase, DataTable dtbFeriados, bool validaSabado, bool validaDomingo)
        {
            bool fds = false;
            if (validaSabado && dataBase.DayOfWeek == DayOfWeek.Saturday)
            {
                dataBase = dataBase.AddDays(1);
            }
            if (validaDomingo && dataBase.DayOfWeek == DayOfWeek.Sunday)
            {
                dataBase = dataBase.AddDays(1);
            }


            while (isFeriado(dataBase, dtbFeriados))
            {
                dataBase = dataBase.AddDays(1);
                while (!fds)
                {
                    if ((validaSabado && dataBase.DayOfWeek == DayOfWeek.Saturday) ||
                        (validaDomingo && dataBase.DayOfWeek == DayOfWeek.Sunday))
                    {
                        dataBase = dataBase.AddDays(1);
                    }
                    else
                    {
                        fds = true;
                    }
                }
            }
            return dataBase;
        }

        public bool isFeriado(DateTime dataBase, DataTable dtbFeriado)
        {
            foreach (DataRow item in dtbFeriado.Rows)
            {
                if (Convert.ToDateTime(item["CAD_FER_DT_FERIADO"].ToString()) == dataBase)
                    return true;
            }

            return false;
        }

        public DataTable ConsultarValidade(AtendimentoEntity Atendimento)
        {
            return data.ConsultarValidade(Atendimento);
        }

        public DataTable ConsultarFeriado(string idtUnidade, string dataInicioLista)
        {
            return data.ConsultarFeriado(idtUnidade, dataInicioLista);
        }
       
    }
}
