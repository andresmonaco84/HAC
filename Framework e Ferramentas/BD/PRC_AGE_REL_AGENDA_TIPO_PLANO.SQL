create or replace procedure PRC_AGE_REL_AGENDA_TIPO_PLANO
  (
     pDT_INICIO_CONSULTA in TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
     pDT_FIM_CONSULTA in TB_AGE_AGD_AGENDA.AGE_AGD_DT_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type default null,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_REL_AGENDA_TIPO_PLANO
  *
  *    Data Criacao:  25/09/2007   Por: Guilherme
  *    Data Alteracao: 22/10/2007   Por: Guilherme
  *         Alterac?o: Otimizac?o de procedure
  *
  *    Funcao: Alimentar relatorio de Agendamentos por tipo de Plano
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
SELECT TPE.CAD_TPE_CD_CODIGO,
       TPE.CAD_TPE_DS_DESCRICAO,
       CASE
         WHEN PAC.CAD_CNV_ID_CONVENIO = 281 THEN PLA.CAD_PLA_CD_TIPOPLANO ELSE TPE.CAD_TPE_CD_CODIGO END FOO,
       CASE
         WHEN PAC.CAD_CNV_ID_CONVENIO = 281 AND
              NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC,
                                      SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3),
                                      SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7),
                                      SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)),
                  0) = 1 THEN
          'PARTICIPANTE DO PROG. INST. GERIATRIA - VIVA SAUDE' WHEN
          PAC.CAD_CNV_ID_CONVENIO = 281 AND
              NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC,
                                      SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3),
                                      SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7),
                                      SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)),
                  0) = 2 THEN
          'PARTICIPANTE DO PROG. INST. GERIATRIA - VIVA SAUDE' WHEN          
          PAC.CAD_CNV_ID_CONVENIO = 281 AND
              NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC,
                                      SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3),
                                      SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7),
                                      SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)),
                  0) = 4 THEN
          'AMB. ALTA CRITICOS'
         WHEN PAC.CAD_CNV_ID_CONVENIO = 281 AND
              NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC,
                                      SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3),
                                      SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7),
                                      SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)),
                  0) NOT IN (1, 2, 4) THEN
          'AGENDAMENTO NORMAL'
         WHEN PAC.CAD_CNV_ID_CONVENIO != 281 THEN TPE.CAD_TPE_DS_DESCRICAO
       END BAR,
       CASE
         WHEN TPE.CAD_TPE_CD_CODIGO != 'ACS' THEN SUM(COUNT(*)) OVER(PARTITION BY PLA.CAD_PLA_CD_TIPOPLANO)
         WHEN TPE.CAD_TPE_CD_CODIGO = 'ACS' THEN SUM(COUNT(*)) OVER(PARTITION BY PLA.CAD_PLA_CD_TIPOPLANO || INS_GER.CD_INSGER)
       END TOTAL
  FROM TB_AGE_AGD_AGENDA AGD,
       TB_CAD_PAC_PACIENTE PAC,
       TB_CAD_CNV_CONVENIO CNV,
       TB_CAD_PLA_PLANO PLA,
       TB_CAD_TPE_TIPOEMPRESA TPE,
       TB_AGE_ESM_ESCALA_MEDICA ESM,
       (SELECT AGD.AGE_AGD_ID AGE_AGD_ID,
               TPE.CAD_TPE_CD_CODIGO CAD_TPE_CD_CODIGO,
               PLA.CAD_PLA_CD_TIPOPLANO CAD_PLA_CD_TIPOPLANO,
               CASE
                 WHEN NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC,
                                              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3),
                                              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7),
                                              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)),
                          0) = 1 THEN 1
                 WHEN NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC,
                                              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3),
                                              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7),
                                              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)),
                          0) = 2 THEN 2
                 WHEN NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC,
                                              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3),
                                              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7),
                                              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)),
                          0) = 4 THEN 4                          
                 WHEN NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC,
                                              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3),
                                              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7),
                                              SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)),
                    0) NOT IN (1, 2, 4) THEN 0
               END CD_INSGER
          FROM TB_AGE_AGD_AGENDA        AGD,
               TB_CAD_PAC_PACIENTE      PAC,
               TB_CAD_CNV_CONVENIO      CNV,
               TB_CAD_PLA_PLANO         PLA,
               TB_CAD_TPE_TIPOEMPRESA   TPE,
               TB_AGE_ESM_ESCALA_MEDICA ESM
         WHERE TRUNC(AGD.AGE_AGD_DT_ATENDIMENTO) BETWEEN pDT_INICIO_CONSULTA AND pDT_FIM_CONSULTA
           AND AGD.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
           AND PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
           AND PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
           AND CNV.CAD_TPE_CD_CODIGO = TPE.CAD_TPE_CD_CODIGO
           AND AGD.AGE_ESM_ID = ESM.AGE_ESM_ID
           AND ESM.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
           AND AGD.AGE_AGD_FL_STATUS != 'C'
           AND PLA.CAD_PLA_CD_TIPOPLANO IN ('GB', 'PL')) INS_GER 
           WHERE TRUNC(AGD.AGE_AGD_DT_ATENDIMENTO) BETWEEN pDT_INICIO_CONSULTA AND pDT_FIM_CONSULTA AND AGD.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE AND PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO AND PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO AND CNV.CAD_TPE_CD_CODIGO = TPE.CAD_TPE_CD_CODIGO AND AGD.AGE_ESM_ID = ESM.AGE_ESM_ID AND ESM.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE AND AGD.AGE_AGD_FL_STATUS != 'C' AND INS_GER.AGE_AGD_ID(+) = AGD.AGE_AGD_ID
 GROUP BY TPE.CAD_TPE_CD_CODIGO,
          TPE.CAD_TPE_DS_DESCRICAO,
          CASE WHEN PAC.CAD_CNV_ID_CONVENIO = 281 THEN PLA.CAD_PLA_CD_TIPOPLANO ELSE TPE.CAD_TPE_CD_CODIGO
          END,
          CASE
            WHEN PAC.CAD_CNV_ID_CONVENIO = 281 AND
               NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC, SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3), SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7), SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)), 0) = 1 THEN
             'PARTICIPANTE DO PROG. INST. GERIATRIA - VIVA SAUDE'
            WHEN PAC.CAD_CNV_ID_CONVENIO = 281 AND
               NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC, SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3), SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7), SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)), 0) = 2 THEN
             'PARTICIPANTE DO PROG. INST. GERIATRIA - VIVA SAUDE'             
            WHEN PAC.CAD_CNV_ID_CONVENIO = 281 AND
                 NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC, SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3), SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7), SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)), 0) = 4 THEN
             'AMB. ALTA CRITICOS' 
            WHEN PAC.CAD_CNV_ID_CONVENIO = 281 AND NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC, SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3), SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7), SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)), 0) NOT IN (1, 2) THEN
             'AGENDAMENTO NORMAL'
            WHEN PAC.CAD_CNV_ID_CONVENIO != 281 THEN TPE.CAD_TPE_DS_DESCRICAO
          END,
          TPE.CAD_TPE_CD_CODIGO,
          PLA.CAD_PLA_CD_TIPOPLANO,
          INS_GER.CD_INSGER
 ORDER BY TPE.CAD_TPE_CD_CODIGO,
          TPE.CAD_TPE_DS_DESCRICAO,
          CASE
            WHEN PAC.CAD_CNV_ID_CONVENIO = 281 THEN PLA.CAD_PLA_CD_TIPOPLANO ELSE TPE.CAD_TPE_CD_CODIGO END,
          CASE
            WHEN PAC.CAD_CNV_ID_CONVENIO = 281 AND
                 NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC,
                                         SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3),
                                         SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7),
                                         SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)),
                     0) = 1 THEN
             'PARTICIPANTE DO PROG. INST. GERIATRIA - VIVA SAUDE'
            WHEN PAC.CAD_CNV_ID_CONVENIO = 281 AND
                 NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC,
                                         SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3),
                                         SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7),
                                         SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)),
                     0) = 2 THEN
             'PARTICIPANTE DO PROG. INST. GERIATRIA - VIVA SAUDE'             
            WHEN PAC.CAD_CNV_ID_CONVENIO = 281 AND
                 NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC,
                                         SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3),
                                         SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7),
                                         SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)),
                     0) = 4 THEN
             'AMB. ALTA CRITICOS'
            WHEN PAC.CAD_CNV_ID_CONVENIO = 281 AND NVL(FNC_VERIFICA_INSGER(PLA.CAD_PLA_CD_PLANO_HAC,
                                         SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 0, 3),
                                         SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 4, 7),
                                         SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL, 11, 2)),
                     0) NOT IN (1, 2, 4) THEN
             'AGENDAMENTO NORMAL'
            WHEN PAC.CAD_CNV_ID_CONVENIO != 281 THEN TPE.CAD_TPE_DS_DESCRICAO
          END
;

    io_cursor := v_cursor;
  end PRC_AGE_REL_AGENDA_TIPO_PLANO;