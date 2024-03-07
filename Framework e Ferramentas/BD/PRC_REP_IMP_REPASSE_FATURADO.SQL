CREATE OR REPLACE PROCEDURE PRC_REP_IMP_REPASSE_FATURADO(PFAT_CCP_MES_FAT         IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_MES_FAT%TYPE,
                                                         PFAT_CCP_ANO_FAT         IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ANO_FAT%TYPE,
                                                         PFAT_CCI_CD_CLINICA_PROF IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_CCI_CD_CLINICA_PROF%TYPE,
                                                         PUSUARIO_IMPORTACAO      IN TB_FAT_CCI_CONTA_CONSU_ITEM.SEG_USU_ID_USUARIO%TYPE)
IS

/********************************************************************
*    Procedure: PRC_REP_IMP_REPASSE_FATURADO
*
*    Data Criacao:   01/05/2012   Por: 
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
lIdtRetorno NUMBER;


BEGIN
  
--  PRETORNO_OPERACAO := 0;
  
  DECLARE
    CURSOR FAT IS
      
      SELECT ATD.ATD_ATE_ID,
             CCI.FAT_CCP_ID,
             CCI.FAT_COC_ID,
             CCI.CAD_TAP_TP_ATRIBUTO,
             CCI.CAD_PRD_ID,
             CCI.CAD_TIH_TP_INDICE_HOSP,
             CCI.FAT_CCI_QT_INDICE,
             CCI.FAT_CCI_VL_INDICE,
             CCI.FAT_CCI_VL_UNITARIO,
             CCI.FAT_CCI_DT_INICIO_CONSUMO DT_REALIZACAO,
             CCI.FAT_CCI_HR_INICIO_CONSUMO,
             SUM(NVL(CCI.FAT_CCI_VL_FATURADO, 0)) VL_FATURADO,
             SUM(CCI.FAT_CCI_QT_CONSUMO) QTD,
             CCI.CAD_PRO_ID_PROFISSIONAL,
             CCI.FAT_CCI_PC_GRAU_PART_PROF,
             SYSDATE REP_PGM_DT_ULTIMA_ATUALIZACAO,
             SUM(NVL(CCI.FAT_CCI_VL_CALCULADO, 0)) VL_CALCULADO,
             CCI.CAD_PAC_ID_PACIENTE,
             CCI.FAT_CCI_TP_CREDENCIA_PROF,
             CCI.FAT_CCI_FL_PACOTE,
             CCI.CAD_CEC_ID_CCUSTO,
             CCI.CAD_CAC_ID_CLASSCONTABIL,
             CCI.FAT_CCI_MES_FECHAMENTO,
             CCI.FAT_CCI_ANO_FECHAMENTO,
             SYSDATE,
             ATD.CAD_UNI_ID_UNIDADE,
             ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO,
             'F', -- faturamento
             MCC.CAD_SET_ID,
             --QLE.CAD_SET_ID,
             PAC.CAD_CNV_ID_CONVENIO,
             CCI.FAT_CCI_PC_ACOMODACAO_HM,
             CCI.FAT_CCI_CD_CLINICA_PROF,
             CLC.CAD_CLC_ID,
             PLA.CAD_PLA_CD_TIPOPLANO,
             EPP.AUX_EPP_CD_ESPECPROC,
             PRD.TIS_MED_CD_TABELAMEDICA,
             ATD.ATD_ATE_FL_RETORNO_OK,
             ATD.TIS_CBO_CD_CBOS,
             ATD.ATD_ATE_TP_PACIENTE

        FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI, --
             TB_CAD_CNV_CONVENIO         CNV,
             TB_CAD_PAC_PACIENTE         PAC,
             TB_ATD_ATE_ATENDIMENTO      ATD,
             TB_FAT_CCP_CONTA_CONS_PARC  CCP,
             TB_CAD_PES_PESSOA           PES,
             TB_CAD_PLA_PLANO            PLA,
             TB_AUX_EPP_ESPECPROC        EPP,
             TB_FAT_MCC_MOV_COM_CONSUMO  MCC,
             -- TB_ATD_IML_INT_MOV_LEITO IML,
             -- TB_CAD_QLE_QUARTO_LEITO QLE,
             TB_CAD_PRD_PRODUTO             PRD,
             TB_CAD_CLC_CLINICA_CREDENCIADA CLC,

             TB_CAD_REP_REGRA_PAGAMENTO     REP, --
             TB_ASS_CPR_CLINICA_PROF        CPR, -- 
             TB_ASS_RPG_REGRA_PAGTO         RPG  --
                          
-- select * from tb_cad_rep_regra_pagamento rep -- VLHORA -- REP_ID
-- select * from tb_ass_cpr_clinica_prof  -- CPR_ID (clinica)
-- select * from tb_ass_rpg_regra_pagto -- CRP_ID e REP_ID

--             TB_ASS_RPG_REGRA_PAGTO RPG, --------
--             TB_ASS_CPR_CLINICA_PROF CPR --------
             
       WHERE CCP.FAT_CCP_MES_FAT = PFAT_CCP_MES_FAT
         AND CCP.FAT_CCP_ANO_FAT = PFAT_CCP_ANO_FAT
         AND CCP.ATD_ATE_ID = ATD.ATD_ATE_ID
         AND ATD.ATD_ATE_ID = CCI.ATD_ATE_ID
         AND CCP.FAT_CCP_ID = CCI.FAT_CCP_ID
         AND CCP.FAT_COC_ID = CCI.FAT_COC_ID
         AND CCP.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
         AND PAC.CAD_PAC_ID_PACIENTE = CCI.CAD_PAC_ID_PACIENTE
         AND PRD.CAD_PRD_ID = CCI.CAD_PRD_ID
         AND PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
         AND PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
         AND PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
         AND EPP.AUX_EPP_CD_ESPECPROC(+) = PRD.AUX_EPP_CD_ESPECPROC
         AND EPP.TIS_MED_CD_TABELAMEDICA(+) = PRD.TIS_MED_CD_TABELAMEDICA
         AND CCI.CAD_PRD_ID = PRD.CAD_PRD_ID
         AND MCC.ATD_ATE_ID(+) = ATD.ATD_ATE_ID
         AND CCI.FAT_MCC_ID = MCC.FAT_MCC_ID

         AND RPG.CAD_REP_ID = REP.CAD_REP_ID --
         AND RPG.ASS_CPR_ID = CPR.ASS_CPR_ID --
         
         AND CCI.CAD_TAP_TP_ATRIBUTO IN ('EXA', 'HM', 'TAX')
         AND CCI.FAT_CCI_FL_STATUS <> 'C'
         --AND (CCI.FAT_FL_PENDENTE_AUTORIZA NOT IN ('P', 'N') OR CCI.FAT_FL_PENDENTE_AUTORIZA IS NULL)
         AND CCP.FAT_LNF_ID IS NOT NULL
         AND CCP.FAT_CCP_FL_EMITIDA = 'S'
         AND CCP.FAT_CCP_FL_FATURADA = 'S'
--         AND CCP.FAT_NOF_ID IS NOT NULL
         AND (CCI.FAT_CCI_FL_PACOTE = 'N' OR CCI.FAT_CCI_FL_PACOTE IS NULL)
         AND CCI.FAT_CCI_CD_CLINICA_PROF IS NOT NULL
            --AND CCI.FAT_CCI_CD_CLINICA_PROF        = 6
            --AND IML.ATD_ATE_ID(+)                = ATD.ATD_ATE_ID
            --AND IML.CAD_CAD_QLE_ID               = QLE.CAD_QLE_ID
         AND CLC.CAD_CLC_CD_CLINICA = CCI.FAT_CCI_CD_CLINICA_PROF
         AND (REP.CAD_REP_TP_BASE_CALCULO IN ('VLHORA', 'VLFIA')
          OR  (REP.CAD_REP_TP_BASE_CALCULO NOT IN ('VLHORA', 'VLFIA')
               AND CCP.FAT_NOF_ID IS NOT NULL))
         AND CCI.FAT_CCI_CD_CLINICA_PROF = DECODE(PFAT_CCI_CD_CLINICA_PROF, NULL, CCI.FAT_CCI_CD_CLINICA_PROF, PFAT_CCI_CD_CLINICA_PROF)
         AND (CASE
               WHEN (PLA.CAD_PLA_CD_TIPOPLANO = 'SP' AND
                    CCI.FAT_CCI_TP_CREDENCIA_PROF = 'MC') THEN
                'NO'
               ELSE
                CCI.FAT_CCI_TP_CREDENCIA_PROF
             END) IN ('MF', 'MC')
         AND ATD.ATD_ATE_FL_REPASSE_STATUS <> 'P'
         AND ATD.ATD_ATE_FL_RETORNO_OK = 'N'

       GROUP BY ATD.ATD_ATE_ID,
                CCI.FAT_CCP_ID,
                CCI.FAT_COC_ID,
                CCI.CAD_TAP_TP_ATRIBUTO,
                CCI.CAD_PRD_ID,
                CCI.CAD_TIH_TP_INDICE_HOSP,
                CCI.FAT_CCI_QT_INDICE,
                CCI.FAT_CCI_VL_INDICE,
                CCI.FAT_CCI_VL_UNITARIO,
                CCI.FAT_CCI_DT_INICIO_CONSUMO,
                CCI.FAT_CCI_HR_INICIO_CONSUMO,
                CCI.CAD_PRO_ID_PROFISSIONAL,
                CCI.FAT_CCI_PC_GRAU_PART_PROF,
                SYSDATE,
                CCI.CAD_PAC_ID_PACIENTE,
                CCI.FAT_CCI_TP_CREDENCIA_PROF,
                CCI.FAT_CCI_FL_PACOTE,
                CCI.CAD_CEC_ID_CCUSTO,
                CCI.CAD_CAC_ID_CLASSCONTABIL,
                CCI.FAT_CCI_MES_FECHAMENTO,
                CCI.FAT_CCI_ANO_FECHAMENTO,
                SYSDATE,
                ATD.CAD_UNI_ID_UNIDADE,
                ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                'F',
                MCC.CAD_SET_ID,
                --QLE.CAD_SET_ID,
                PAC.CAD_CNV_ID_CONVENIO,
                CCI.FAT_CCI_PC_ACOMODACAO_HM,
                CCI.FAT_CCI_CD_CLINICA_PROF,
                CLC.CAD_CLC_ID,
                PLA.CAD_PLA_CD_TIPOPLANO,
                EPP.AUX_EPP_CD_ESPECPROC,
                PRD.TIS_MED_CD_TABELAMEDICA,
                ATD.ATD_ATE_FL_RETORNO_OK,
                ATD.TIS_CBO_CD_CBOS,
                ATD.ATD_ATE_TP_PACIENTE

       ORDER BY ATD.ATD_ATE_ID,
                CCI.FAT_CCP_ID,
                CCI.FAT_CCI_DT_INICIO_CONSUMO,
                PRD.TIS_MED_CD_TABELAMEDICA;
  
    --
  
  BEGIN
    FOR T IN FAT LOOP
    
      BEGIN
        
/*        IF PRETORNO_OPERACAO <= 0 THEN
           PRETORNO_OPERACAO := FAT%ROWCOUNT;
           dbms_output.put_line('rowcount: ' || PRETORNO_OPERACAO);        
        END IF;*/
        
        --
        SELECT SEQ_REP_PGM_01.NEXTVAL INTO lIdtRetorno FROM DUAL;
  
        --
        INSERT INTO TB_REP_PGM_PAGTO_MEDICO
          (ATD_ATE_ID,
           FAT_CCP_ID,
           FAT_COC_ID,
           CAD_TAP_TP_ATRIBUTO,
           CAD_PRD_ID,
           CAD_TIH_TP_INDICE_HOSP,
           REP_PGM_QT_INDICE,
           REP_PGM_VL_INDICE,
           REP_PGM_VL_UNITARIO,
           REP_PGM_DT_INICIO_REALIZACAO,
           REP_PGM_HR_INICIO_REALIZACAO,
           REP_PGM_VL_FATURADO,
           REP_PGM_QT_CONSUMO,
           CAD_PRO_ID_PROFISSIONAL,
           REP_PGM_PC_GRAU_PART_PROF,
           REP_PGM_DT_ULTIMA_ATUALIZACAO,
           REP_PGM_VL_CALCULADO,
           CAD_PAC_ID_PACIENTE,
           REP_PGM_TP_CREDENCIA_PROF,
           REP_PGM_FL_PACOTE,
           CAD_CEC_ID_CCUSTO,
           CAD_CAC_ID_CLASSCONTABIL,
           REP_PGM_MES_FECHAMENTO,
           REP_PGM_ANO_FECHAMENTO,
           SEG_USU_ID_USUARIO_CRIACAO,
           REP_PGM_DT_CRIACAO,
           CAD_UNI_ID_UNIDADE,
           CAD_LAT_ID_LOCAL_ATENDIMENTO,
           REP_PGM_CD_ORIGEM,
           REP_PGM_ID,
           CAD_SET_ID_REALIZACAO,
           CAD_SET_ID_MOVIMENTACAO,
           FAT_CCI_PC_ACOMODACAO_HM,
           CAD_CNV_ID_CONVENIO,
           CAD_CLC_ID,
           CAD_PLA_CD_TIPOPLANO,
           AUX_EPP_CD_ESPECPROC,
           TIS_MED_CD_TABELAMEDICA,
           REP_PGM_FL_ATENDIMENTO_RETORNO,
           REP_PGM_MES_PAGTO,
           REP_PGM_ANO_PAGTO
           )
        -------
        VALUES
        -----
          (T.ATD_ATE_ID,
           T.FAT_CCP_ID,
           T.FAT_COC_ID,
           T.CAD_TAP_TP_ATRIBUTO,
           T.CAD_PRD_ID, -- DECODE(T.ATD_ATE_FL_RETORNO_OK, 'S', NULL, T.CAD_PRD_ID), -- SE FOR RETORNO...
           T.CAD_TIH_TP_INDICE_HOSP,
           T.FAT_CCI_QT_INDICE,
           T.FAT_CCI_VL_INDICE,
           T.FAT_CCI_VL_UNITARIO,
           T.DT_REALIZACAO,
           T.FAT_CCI_HR_INICIO_CONSUMO,
           T.VL_FATURADO,
           T.QTD,
           T.CAD_PRO_ID_PROFISSIONAL,
           T.FAT_CCI_PC_GRAU_PART_PROF,
           T.REP_PGM_DT_ULTIMA_ATUALIZACAO,
           T.VL_CALCULADO,
           T.CAD_PAC_ID_PACIENTE,
           T.FAT_CCI_TP_CREDENCIA_PROF,
           T.FAT_CCI_FL_PACOTE,
           T.CAD_CEC_ID_CCUSTO,
           T.CAD_CAC_ID_CLASSCONTABIL,
           TO_CHAR(SYSDATE, 'MM'), -- T.FAT_CCI_MES_FECHAMENTO,
           TO_CHAR(SYSDATE, 'YYYY'),-- T.FAT_CCI_ANO_FECHAMENTO,
           PUSUARIO_IMPORTACAO, -- USUÁRIO LOGADO NO SISTEMA
           SYSDATE,
           T.CAD_UNI_ID_UNIDADE,
           T.CAD_LAT_ID_LOCAL_ATENDIMENTO,
           'F', -- faturamento
           lIdtRetorno,
           T.CAD_SET_ID,
           T.CAD_SET_ID,
           --QLE.CAD_SET_ID,
           T.FAT_CCI_PC_ACOMODACAO_HM,
           T.CAD_CNV_ID_CONVENIO,
           T.CAD_CLC_ID,
           T.CAD_PLA_CD_TIPOPLANO,
           T.AUX_EPP_CD_ESPECPROC,
           T.TIS_MED_CD_TABELAMEDICA,
           T.ATD_ATE_FL_RETORNO_OK,
           TO_CHAR(SYSDATE, 'MM'),
           TO_CHAR(SYSDATE, 'YYYY'));
  
  
           UPDATE TB_FAT_CCI_CONTA_CONSU_ITEM CCI1
              SET CCI1.FAT_CCI_FL_IMPORTADO_REPASSE = 'P'
            WHERE CCI1.FAT_CCP_ID = T.FAT_CCP_ID
              AND CCI1.ATD_ATE_ID = T.ATD_ATE_ID
              AND CCI1.CAD_PRD_ID = T.CAD_PRD_ID
              AND CCI1.CAD_PAC_ID_PACIENTE = T.CAD_PAC_ID_PACIENTE
              AND CCI1.CAD_PRO_ID_PROFISSIONAL = T.CAD_PRO_ID_PROFISSIONAL;

           -- Ajustar a importação para atualizar a especialidade do profissional
           UPDATE TB_REP_PGM_PAGTO_MEDICO PGM2
              SET PGM2.TIS_CBO_CD_CBOS = T.TIS_CBO_CD_CBOS
            WHERE T.ATD_ATE_TP_PACIENTE IN ('A','U')
              AND PGM2.REP_PGM_ID = lIdtRetorno;
  
           -- se der erro, informa e atualiza o status na CCI 
           EXCEPTION
              WHEN OTHERS THEN
                   UPDATE TB_FAT_CCI_CONTA_CONSU_ITEM CCI1
                      SET CCI1.FAT_CCI_FL_IMPORTADO_REPASSE = 'E'
                    WHERE CCI1.FAT_CCP_ID = T.FAT_CCP_ID
                      AND CCI1.ATD_ATE_ID = T.ATD_ATE_ID
                      AND CCI1.CAD_PRD_ID = T.CAD_PRD_ID
                      AND CCI1.CAD_PAC_ID_PACIENTE = T.CAD_PAC_ID_PACIENTE
                      AND CCI1.CAD_PRO_ID_PROFISSIONAL = T.CAD_PRO_ID_PROFISSIONAL;
            
--              PRETORNO_OPERACAO := -1;  
--              dbms_output.put_line(PRETORNO_OPERACAO);      
              
         END;  
    
    END LOOP;
  END;
END PRC_REP_IMP_REPASSE_FATURADO;
/
