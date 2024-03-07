using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HospitalAnaCosta.SGS.tools;

namespace HospitalAnaCosta.SGS.Impressao
{
    class ExameLiberacaoData : ClassBase
    {
        public AtendimentoEntity Consultar(AtendimentoEntity Atendimento)
        {
            string sqlString = string.Empty;
            DataTable dtb = new DataTable();
            
            
            sqlString = "SELECT\n" +
            "                             1 ORIGEM ,\n" + 
            "                             PAP.ATD_ATE_ID ,\n" + 
            "                           --  PAP.ASS_PAP_ID,\n" + 
            "                             PAP.CAD_UNI_ID_UNIDADE,\n" + 
            "                             PAP.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" + 
            "                             to_char(PAP.ASS_PAP_DT_AUTOR,'dd/MM/yyyy') ATD_ATE_DT_ATENDIMENTO,\n" + 
            "                             lpad(TO_char(PAP.ASS_PAP_HR_AUTOR),'4','0') ATD_ATE_HR_ATENDIMENTO,\n" + 
            "\n" + 
            "                             PAP.CODPAD,\n" + 
            "                             to_char(PAC.CAD_PAC_DT_VALIDADECREDENCIAL,'dd/MM/yyyy') CAD_PAC_DT_VALIDADECREDENCIAL,\n" + 
            "                             PAC.CAD_PAC_CD_CREDENCIAL,\n" + 
            "                             PAC.CAD_PAC_NR_PRONTUARIO,\n" + 
            "                             PES.CAD_PES_NR_RG,\n" + 
            "                             PES.CAD_PES_NM_PESSOA,\n" + 
            "                             to_char(PES.CAD_PES_DT_NASCIMENTO,'dd/MM/yyyy') CAD_PES_DT_NASCIMENTO,\n" + 
            "                             PES.CAD_PES_TP_SEXO,\n" +
            "                             PAP.ASS_PAP_FL_STATUS_AUTOR,\n" + 
            "                             CASE\n" + 
            "                                  WHEN PAP.ASS_PAP_FL_STATUS_AUTOR = 'A' THEN 'AUTORIZADO'\n" + 
            "                                  WHEN PAP.ASS_PAP_FL_STATUS_AUTOR = 'N' THEN 'NAO AUTORIZADO'\n" + 
            "                                  ELSE 'PENDENTE'\n" + 
            "                             END STATUS_LIBERACAO,\n" + 
            "                             PRD.CAD_PRD_CD_CODIGO,\n" + 
            "                             PRD.CAD_PRD_DS_DESCRICAO\n" + 
            "\n" + 
            "                      FROM          TB_ASS_PAP_PAC_ATEN_PROC    PAP\n" + 
            "                      JOIN          TB_CAD_PAC_PACIENTE         PAC  ON   PAC.CAD_PAC_ID_PACIENTE = PAP.CAD_PAC_ID_PACIENTE\n" + 
            "                      JOIN          TB_CAD_PES_PESSOA           PES  ON   PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA\n" + 
            "\n" + 
            "                      JOIN          TB_ASS_PPG_PAC_ATE_PROC_GUIA PPG ON   PPG.ATD_ATE_ID            =  PAP.ATD_ATE_ID\n" + 
            "                                                                     AND  PPG.CAD_PAC_ID_PACIENTE  =  PAP.CAD_PAC_ID_PACIENTE\n" + 
            "                      LEFT JOIN     TB_CAD_PRD_PRODUTO          PRD  ON   PRD.CAD_PRD_ID        =  PPG.CAD_PRD_ID\n" +
            "                       WHERE        PAP.ASS_PAP_FL_STATUS_AUTOR = 'A' AND PAP.ATD_ATE_ID  = " + Atendimento.Atendimento;

            dtb = remoto.executeQuery(sqlString);
            sqlString = string.Empty;
            if (dtb.Rows.Count == 0)
                throw new Exception("0"); //Liberacao inexistente.
            
            dtb.Rows[0]["ORIGEM"] = Atendimento.Origem.ToString();

            return MontarEntity(dtb);
        }

        private AtendimentoEntity MontarEntity(DataTable dtb)
        {
            AtendimentoEntity atendimentoEntity = new AtendimentoEntity();
            atendimentoEntity.Origem = dtb.Rows[0]["ORIGEM"].ToString();
            atendimentoEntity.Atendimento = dtb.Rows[0]["ATD_ATE_ID"].ToString();
           // atendimentoEntity.TipoPaciente = dtb.Rows[0]["TP_PACIENTE"].ToString();
            atendimentoEntity.DataAtendimento = dtb.Rows[0]["ATD_ATE_DT_ATENDIMENTO"].ToString();
            atendimentoEntity.HoraAtendimento = dtb.Rows[0]["ATD_ATE_HR_ATENDIMENTO"].ToString();
            atendimentoEntity.Padrao = dtb.Rows[0]["CODPAD"].ToString();

            
            atendimentoEntity.IDLocal = dtb.Rows[0]["CAD_LAT_ID_LOCAL_ATENDIMENTO"].ToString();
          
          
            atendimentoEntity.RG = dtb.Rows[0]["CAD_PES_NR_RG"].ToString();
            atendimentoEntity.Validade = dtb.Rows[0]["CAD_PAC_DT_VALIDADECREDENCIAL"].ToString();
            
            atendimentoEntity.Credencial = dtb.Rows[0]["CAD_PAC_CD_CREDENCIAL"].ToString();
            atendimentoEntity.Prontuario = dtb.Rows[0]["CAD_PAC_NR_PRONTUARIO"].ToString();
            atendimentoEntity.Paciente = dtb.Rows[0]["CAD_PES_NM_PESSOA"].ToString();
            atendimentoEntity.DataNascimento = dtb.Rows[0]["CAD_PES_DT_NASCIMENTO"].ToString();
            atendimentoEntity.Sexo = dtb.Rows[0]["CAD_PES_TP_SEXO"].ToString();

           
            atendimentoEntity.StatusLiberacao = dtb.Rows[0]["STATUS_LIBERACAO"].ToString();

            for (int iCont = 0; iCont < dtb.Rows.Count; iCont++)
            {
                atendimentoEntity.CodigoProduto += dtb.Rows[iCont]["CAD_PRD_CD_CODIGO"].ToString() + ";";
                atendimentoEntity.DescricaoProduto += dtb.Rows[iCont]["CAD_PRD_DS_DESCRICAO"].ToString() + ";";
            }
            if (atendimentoEntity.CodigoProduto.Trim().Length > 0)
                atendimentoEntity.CodigoProduto = atendimentoEntity.CodigoProduto.Remove(atendimentoEntity.CodigoProduto.LastIndexOf(";"), 1);
            if (atendimentoEntity.DescricaoProduto.Trim().Length > 0)
                atendimentoEntity.DescricaoProduto = atendimentoEntity.DescricaoProduto.Remove(atendimentoEntity.DescricaoProduto.LastIndexOf(";"), 1);
            

            return atendimentoEntity;
        }
    }
}
