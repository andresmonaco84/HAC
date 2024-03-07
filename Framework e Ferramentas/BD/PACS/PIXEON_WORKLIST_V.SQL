-- CREATE OR REPLACE VIEW PIXEON_WORKLIST_V AS
SELECT 
       SUBSTR(APL.ATS_APL_ID,0,15)                                                            NA_ACCESSIONNUMBER,--CODIGO DO EXAME 
       PAC.CAD_PAC_NR_PRONTUARIO                                                              CO_PATIENTID,-- CODIGO DO PACIENTE
       CASE 
         WHEN ATS.ATS_ATE_FL_RN = 'S' THEN 
            SUBSTR(IDR.ATD_IDR_NM_NOME,1,100)
         ELSE 
            SUBSTR(PES.CAD_PES_NM_PESSOA,1,100) 
         END                                                                                   NA_PATIENTNAME,-- NOME DO PACIENTE
       CASE 
         WHEN ATS.ATS_ATE_FL_RN = 'S' THEN 
            SUBSTR(IDR.ATD_IDR_TP_SEXO,1,16)
         ELSE 
            SUBSTR(PES.CAD_PES_TP_SEXO,1,16) 
         END                                                                                    NA_PATIENTSEX, -- SEXO PACIENTE
       CASE 
         WHEN ATS.ATS_ATE_FL_RN = 'S' THEN 
            TO_CHAR(IDR.ATD_IDR_DT_NASCIMENTO,'YYYYMMDD')
         ELSE 
            TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'YYYYMMDD') 
         END                                                                                     NA_PATIENTBIRTHDAY,   -- DATA NASCIMENTO PACIENTE              
       SUBSTR(ATS.ATS_ATE_QT_PESO,1,50)                                                          NA_PATIENTWEIGHT,-- PESO PACIENTE
       SUBSTR(ATS.ATS_ATE_QT_ALTURA,1,50)                                                        NA_PATIENTHEIGHT,-- ALTURA PACIENTE
       NULL                                                                                      CO_PERFOMINGID,-- MEDICO RESPONSAVEL LAUDO
       NULL                                                                                      NA_PERFOMINGNAME,-- NOME MEDICO ASSINANTE
       NULL                                                                                      NA_PERFOMINGCRM,-- CRM MEDICO ASSINANTE
       NULL                                                                                      NA_PERFOMINGEMAIL,-- E-MAI MEDICO ASSINANTE
       PRO_SOL.CAD_PSO_CD_CONSELHO                                                               CO_REQUESTERID,-- ID MEDICO SOLICITANTE
       SUBSTR(PRO_SOL.CAD_PSO_NM_PROFISSIONAL,1,50)                                              NA_REQUESTERNAME,-- NOME MEDICO SOLICITANTE
       SUBSTR(PRO_SOL.CAD_PSO_CD_CONSELHO,1,50)                                                  NA_REQUESTERCRM,-- CRM MEDICO SOLITANTE
       NULL                                                                                      NA_REQUESTEREMAIL,-- E-MAIL MEDICO SOLITANTE
       SUBSTR(PRO_SOL.CAD_PSO_SG_UF_CONSELHO,1,50)                                               NA_REQUESTERUF, -- UF MEDICO SOLICITANTE
      SUBSTR(TRIM(PRD.CAD_PRD_DS_DESCRICAO),1,200)                                               NA_DESCRIPTION,-- DESCRICAO DO PROCEDIMENTO
      NULL                                                                                       NA_BODYPART,-- REGI?O DO CORPO ALVO DO EXAME
      TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED,'YYYYMMDD')                                           NA_STUDYDATE,-- DATA DA REALIZACAO DO EXAME       
      SUBSTR(TRIM(TO_CHAR(ATS.ATS_ATE_HR_REALIZ_PROCED,'0000') ),0,2) || 
      SUBSTR(TRIM(TO_CHAR(ATS.ATS_ATE_HR_REALIZ_PROCED,'0000') ),3,2) || '00'                    NA_STUDYTIME,-- HORA REALIZACAO DO EXAME
      SUBSTR(ATS.ATS_ATE_DS_APARELHO,1,50)                                                       NA_MODALITYRIS,
      NULL                                                                                       NA_PASSWORD,-- SENHA PARA ACESSO WEB  
      SUBSTR(UNI_SOLIC.CAD_UNI_DS_UNIDADE,1,100)                                                 NA_REQUESTINGSERVICE,-- UNIDADE QUE SOLICITOU  
      SUBSTR(UNI_SOLIC.CAD_UNI_DS_UNIDADE,1,100)                                                 NA_REQUIREUNIT,-- UNIDADE QUE IRA EXECUTAR  
      TO_CHAR(ARP.ATS_ARP_DT_RESULTADO,'YYYYMMDD')                                               NA_DATETIMERELEASE,-- DATA DE ENTREGA  
      NULL                                                                                       NA_STUDYID,-- IDENTIFICADOR DO EXAME  
      NULL                                                                                       NA_MACHINE,-- IDENTIFICADOR DA MAQUINA ONDE O EXAME SERA REALIZADO
      SUBSTR(CNV.CAD_CNV_CD_HAC_PRESTADOR || '-' || CNV.CAD_CNV_NM_FANTASIA,1,50)                NA_INSURANCEPLAN,-- CONVENIO/PLANO  
      SUBSTR(UNI_ATEND.CAD_UNI_DS_UNIDADE|| '-'|| 
      FNC_CAD_PES_ENDERECO_S(UNI_ATEND.CAD_PES_ID_PESSOA,2),1,50)                                NA_REQUESTINGDEPARTMENT,-- LOCAL DE ENTREGA
       CASE 
          WHEN ATS.ATS_ATE_FL_EXAME_COM_LAUDO = 'S' THEN
             SUBSTR('CL-'||ATS.ATS_ATE_CD_INTLIB,1,16)                                                                     -- NA_CUSTOMSEARCHFIELD-- tamanho 16 NUMERO ATENDIMENTO
          ELSE
             SUBSTR('SL-'||ATS.ATS_ATE_CD_INTLIB,1,16)                                                                     
         END                                                                                     NA_CUSTOMSEARCHFIELD-- tamanho 16 NUMERO ATENDIMENTO
 FROM TB_ATS_ATE_ATENDIMENTO_SADT    ATS,
      TB_ATS_APL_ATEN_PROCED_LAUDO   APL,
      TB_CAD_PES_PESSOA              PES,
      TB_CAD_PAC_PACIENTE            PAC,
      TB_CAD_PRD_PRODUTO             PRD,
      TB_CAD_PSO_PROF_SOLICITANTE    PRO_SOL,
      TB_CAD_SET_SETOR               SET_SOLIC,
      TB_CAD_UNI_UNIDADE             UNI_SOLIC,
      TB_CAD_SET_SETOR               SET_ATEND,
      TB_CAD_UNI_UNIDADE             UNI_ATEND,
      TB_ATS_ARP_ATEN_RESULT_PROCED  ARP,
      TB_AUX_EPP_ESPECPROC           EPP,
      TB_CAD_CNV_CONVENIO            CNV,
      TB_CAD_PLA_PLANO               PLA,
      TB_ATD_ATE_ATENDIMENTO         ATD,
      TB_ASS_PAT_PACIEATEND          PAT ,
      TB_ATD_IDR_INT_DADOS_RN        IDR
WHERE APL.ATS_ATE_CD_INTLIB      = ATS.ATS_ATE_CD_INTLIB -- NAO VAI PRECISAR DE OUTERJOIN,POIS TODOS OS EXAMES DEVEM EXISTIR NA TABELA DE LAUDO TBM  
AND APL.ATS_ATE_ID               = ATS.ATS_ATE_ID 
AND APL.AUX_EPP_CD_ESPECPROC     = ATS.AUX_EPP_CD_ESPECPROC 
AND APL.CAD_PRD_ID               = ATS.CAD_PRD_ID 
AND ATD.ATD_ATE_ID               = ATS.ATS_ATE_CD_INTLIB 
AND PAT.ATD_ATE_ID               = ATD.ATD_ATE_ID 
AND CNV.CAD_CNV_ID_CONVENIO      = PAT.CAD_CNV_ID_CONVENIO 
AND PLA.CAD_CNV_ID_CONVENIO      = CNV.CAD_CNV_ID_CONVENIO 
AND PLA.CAD_PLA_ID_PLANO         = PAT.CAD_PLA_ID_PLANO 
AND APL.ATS_APL_STATUS_LAUDO     = 'R'  -- ESTE STATUS N?O EXISTIA NA TABELA DE LAUDO ENT?O N?O VAI BUSCAR EXAMES PASSADOS  
AND ARP.ATS_ATE_CD_INTLIB        = ATS.ATS_ATE_CD_INTLIB 
AND ARP.ATS_ATE_ID               = ATS.ATS_ATE_ID 
AND ARP.CAD_PRD_ID               = ATS.CAD_PRD_ID 
AND ARP.ATS_EPP_CD_ESPECPROC     = ATS.AUX_EPP_CD_ESPECPROC 
AND PAC.CAD_PAC_ID_PACIENTE      = ATS.CAD_PAC_ID_PACIENTE_INT 
AND PES.CAD_PES_ID_PESSOA        = PAC.CAD_PES_ID_PESSOA 
AND PRD.TIS_MED_CD_TABELAMEDICA  = '90' 
AND PRD.AUX_EPP_CD_ESPECPROC     = ATS.AUX_EPP_CD_ESPECPROC 
AND PRD.CAD_PRD_ID               = ATS.CAD_PRD_ID 
AND PRO_SOL.CAD_PSO_CD_CONSELHO    = ATS.ATS_ATE_NR_CONSELHO_SOLIC 
AND PRO_SOL.CAD_PSO_SG_UF_CONSELHO = ATS.ATS_ATE_SG_UF_CONSELHO_SOLIC  
AND SET_SOLIC.CAD_SET_ID         = ATS.CAD_SET_ID
AND UNI_SOLIC.CAD_UNI_ID_UNIDADE = SET_ATEND.CAD_UNI_ID_UNIDADE 
AND SET_ATEND.CAD_SET_ID         = ATS.CAD_SET_ID_ATEN 
AND UNI_ATEND.CAD_UNI_ID_UNIDADE = SET_ATEND.CAD_UNI_ID_UNIDADE 
AND ATS.ATS_ATE_FL_STATUS        = 'A' 
AND EPP.AUX_EPP_CD_ESPECPROC     = ATS.AUX_EPP_CD_ESPECPROC 
and EPP.TIS_MED_CD_TABELAMEDICA  = '90' 
AND ATS.ATS_ATE_ID_RN            = IDR.ATD_IDR_ID (+)
AND ATS.ATS_ATE_DT_REALIZ_PROCED >= (SYSDATE - INTERVAL '24' HOUR)
AND APL.ATS_APL_ID NOT IN ( SELECT NA_ACCESSIONNUMBER FROM PIXUSER.PIXEON_INTEGRACAO )
;

-- CREATE TABLE PIXUSER.PIXEON_INTEGRACAO ( NA_ACCESSIONNUMBER   VARCHAR2(50),DT_INTEGRACAO        VARCHAR2(50) );
