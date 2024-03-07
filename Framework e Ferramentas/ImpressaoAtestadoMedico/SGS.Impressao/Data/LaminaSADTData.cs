using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HospitalAnaCosta.SGS.tools;

namespace HospitalAnaCosta.SGS.Impressao
{
    class LaminaSADTData : ClassBase
    {
        public LaminaSADTEntity Consultar(LaminaSADTEntity AtendimentoSADT)
        {
            string sqlString = string.Empty;
            DataTable dtb = new DataTable();
            
            sqlString = string.Format("SELECT\n" +
            "          ATS.ATS_ATE_CD_INTLIB,\n" + 
            "          ATS.ATS_ATE_IN_INTLIB,\n" + 
            "          ATS.ATS_ATE_ID,\n" + 
            "          ATS.CAD_PRD_ID,\n" + 
            "          TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED,'dd/MM/yyyy') ATS_ATE_DT_REALIZ_PROCED,\n" + 
            "          ATS.ATS_ATE_HR_REALIZ_PROCED,\n" + 
            "          ATS.ATS_ATE_FL_STATUS,\n" + 
            "          ATS.TIS_MED_CD_TABELAMEDICA,\n" + 
            "          LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,\n" + 
            "          S.CAD_SET_CD_SETOR, S.CAD_SET_DS_SETOR, S.CAD_SET_DS_PROCEDENCIA,\n" + 
            "          PES.CAD_PES_NM_PESSOA,\n" + 
            "          TO_CHAR(TRUNC(SYSDATE),'dd/MM/yyyy') DATA_ATUAL\n" + 
            "\n" + 
            "     FROM TB_ATS_ATE_ATENDIMENTO_SADT   ATS\n" + 
            "     JOIN TB_CAD_PAC_PACIENTE         PAC  ON  PAC.CAD_PAC_ID_PACIENTE  = ATS.CAD_PAC_ID_PACIENTE_INT\n" + 
            "     JOIN TB_CAD_PES_PESSOA           PES  ON  PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA\n" + 
            "     JOIN TB_CAD_SET_SETOR              S   ON S.CAD_SET_ID            = ATS.CAD_SET_ID_ATEN\n" + 
            "LEFT JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON  LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = S.CAD_LAT_ID_LOCAL_ATENDIMENTO\n" + 
            "\n" + 
            "    WHERE (ATS.ATS_ATE_FL_STATUS = 'A') AND\n" + 
            "          (ATS.ATS_ATE_CD_INTLIB = {0}) AND\n" + 
            "          (ATS.ATS_ATE_IN_INTLIB = '{1}') AND\n" + 
            "          (ATS.ATS_ATE_ID = {2}) AND\n" +
            "          (ATS.CAD_PRD_ID = {3}) AND\n" + 
            "          (ATS.AUX_EPP_CD_ESPECPROC = {4}) AND\n" + 
            "          (ATS.TIS_MED_CD_TABELAMEDICA = {5}) \n"
            ,AtendimentoSADT.Atendimento,
            AtendimentoSADT.TipoIntLib,
            AtendimentoSADT.CodigoExame,
            AtendimentoSADT.IdtProduto,
            AtendimentoSADT.CodigoEspecialidade,
            AtendimentoSADT.CodigoTabelaMedica);
            
            dtb = remoto.executeQuery(sqlString);

            if (dtb.Rows.Count == 0)
                throw new Exception("0"); //Atendimento inexistente.

            if (dtb.Rows[0]["ATS_ATE_FL_STATUS"].ToString() != "A")
                throw new Exception("1"); //Exame cancelado.
           
            return MontarEntity(dtb);
        }

        private LaminaSADTEntity MontarEntity(DataTable dtb)
        {
            LaminaSADTEntity atendimentoSADTEntity = new LaminaSADTEntity();
          
            atendimentoSADTEntity.Atendimento = dtb.Rows[0]["ATS_ATE_CD_INTLIB"].ToString();
            atendimentoSADTEntity.TipoIntLib = dtb.Rows[0]["ATS_ATE_IN_INTLIB"].ToString();
            atendimentoSADTEntity.CodigoExame = dtb.Rows[0]["ATS_ATE_ID"].ToString();
            atendimentoSADTEntity.IdtProduto = dtb.Rows[0]["CAD_PRD_ID"].ToString();
            atendimentoSADTEntity.CodigoTabelaMedica = dtb.Rows[0]["TIS_MED_CD_TABELAMEDICA"].ToString();
          
            atendimentoSADTEntity.Local = dtb.Rows[0]["CAD_LAT_DS_LOCAL_ATENDIMENTO"].ToString();
            atendimentoSADTEntity.Setor = dtb.Rows[0]["CAD_SET_DS_PROCEDENCIA"].ToString();
            
            atendimentoSADTEntity.Paciente = dtb.Rows[0]["CAD_PES_NM_PESSOA"].ToString();

            atendimentoSADTEntity.DataAtendimento = dtb.Rows[0]["ATS_ATE_DT_REALIZ_PROCED"].ToString();
            atendimentoSADTEntity.HoraAtendimento = dtb.Rows[0]["ATS_ATE_HR_REALIZ_PROCED"].ToString();
            atendimentoSADTEntity.DataAtual = dtb.Rows[0]["DATA_ATUAL"].ToString();

            return atendimentoSADTEntity;
        }
    }
}
