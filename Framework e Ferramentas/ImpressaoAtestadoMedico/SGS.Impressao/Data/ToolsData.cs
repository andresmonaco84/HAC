using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HospitalAnaCosta.SGS.tools;

namespace HospitalAnaCosta.SGS.Impressao
{
    public class ToolsData : ClassBase
    {            
        public DataTable ConsultarValidade(AtendimentoEntity Atendimento)
        {
            string sqlString = string.Empty;
            DataTable dtbValidade = new DataTable();

            if (Atendimento.Origem == "1") // LIBERACAO
            {
                sqlString = "SELECT\n" +
                            "       CAD_PVE_ID,\n" +
                            "       CAD_PVE_DS_EXAME,\n" +
                            "       CAD_PVE_QT_VALIDADE,\n" +
                            "       DECODE(CAD_PVE_UN_TEMPO,'H','HORAS','D','DIAS') CAD_PVE_UN_TEMPO,\n" +
                            "       CAD_PVE_FL_STATUS\n" +
                            "    FROM TB_CAD_PVE_PER_VALID_EXAME\n" +
                            "    WHERE CAD_PVE_FL_STATUS = 'A' \n";

                dtbValidade = remoto.executeQuery(sqlString);
                sqlString = string.Empty;
            }
            return dtbValidade;
        }

        public DataTable ConsultarFeriado(string idtUnidade, string dataInicioLista)
        {
            DataTable dtbFeriado = new DataTable();
            string sqlString = string.Format("SELECT\n" +
                       "       CAD_FER_ID_FERIADO,\n" +
                       "       CAD_UNI_ID_UNIDADE,\n" +
                       "       CAD_FER_DT_FERIADO,\n" +
                       "       CAD_FER_TP_FERIADO,\n" +
                       "       CAD_FER_DS_FERIADO,\n" +
                       "       CAD_FER_DT_ULTIMA_ATUALIZACAO,\n" +
                       "       SEG_USU_ID_USUARIO\n" +
                       "    FROM TB_CAD_FER_FERIADO\n" +
                       "    WHERE (CAD_UNI_ID_UNIDADE = {0} OR CAD_FER_TP_FERIADO = 'F')\n" +
                       "    AND TO_DATE(CAD_FER_DT_FERIADO, 'DD-MM-YYYY') >= TO_DATE(DECODE({1},NULL,TRUNC(SYSDATE),{1}), 'DD-MM-YYYY')\n" +
                       "    ORDER BY CAD_FER_DT_FERIADO DESC", idtUnidade, dataInicioLista.Length == 0 ? "NULL" : dataInicioLista);
            dtbFeriado = remoto.executeQuery(sqlString);
            sqlString = string.Empty;

            return dtbFeriado;
        }

       

    }
}
