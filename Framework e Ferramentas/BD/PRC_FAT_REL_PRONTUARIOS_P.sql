CREATE OR REPLACE PROCEDURE PRC_FAT_REL_PRONTUARIOS_P
(
    pCAD_UNI_ID_UNIDADE TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE,
    pATD_ATE_TP_PACIENTE TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO TB_CAD_CNV_CONVENIO.CAD_TPE_CD_CODIGO%TYPE DEFAULT NULL,
    pFAT_CCP_DT_PARCELA_INI TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_DT_PARCELA%TYPE,
    pFAT_CCP_DT_PARCELA_FIM TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_DT_PARCELA%TYPE DEFAULT NULL,
    io_cursor OUT PKG_CURSOR.t_cursor
    --,teste out long
)
IS
/********************************************************************
*    Procedure: PRC_FAT_REL_PRONTUARIOS_P
*
*    Data Alteracao: 27/12/2012  Por: Andre
*    Data Alteracao: 22/03/2013  Por: Andre
*         Alterac?o: - Adic?o do campo (subquery) SETOR na query
*                    - Ajuste da query nos 1? e 3? union
*    Data Alteracao: 19/04/2013  Por: Andre
*         Alterac?o: Ajuste da query no 3? union
*    Data Alteracao: 07/05/2013  Por: Andre
*         Alterac?o: Filtrar ATD_ATE_TP_PACIENTE apenas 'I' e 'E' (para regionais)
*    Data Alteracao: 12/02/2014  Por: Andre
*         Alterac?o: Mudanca logica da query ficando de acordo com a pesquisa do cadastro
*    Data Alteracao: 23/01/2015  Por: Andre
*         Alterac?o: Comentado segundo union (das previsoes)
*    Data Alteracao: 05/02/2015  Por: Andre
*         Alterac?o: Descomentado segundo union (das previsoes)
*    Data Alteracao: 22/06/2015  Por: Andre
*         Alterac?o: Nao trazer pacientes internados na data atual sem alta
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
V_WHERE  varchar2(3000);
V_SELECT  varchar2(15000);
V_PERIODO  varchar2(500);
begin
V_WHERE := NULL;
IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATE.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
IF pATD_ATE_TP_PACIENTE IS NOT NULL THEN
   V_WHERE := V_WHERE || ' AND ATE.ATD_ATE_TP_PACIENTE = ' ||CHR(39)|| pATD_ATE_TP_PACIENTE ||CHR(39);
ELSIF (pCAD_UNI_ID_UNIDADE != 244) THEN
   V_WHERE := V_WHERE || ' AND ATE.ATD_ATE_TP_PACIENTE IN (''I'',''E'') ';
END IF;
IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND CNV.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO; END IF;
IF pCAD_TPE_CD_CODIGO = 'ACS' THEN
   V_WHERE := V_WHERE || ' AND CNV.CAD_TPE_CD_CODIGO = ''ACS''';
ELSIF pCAD_TPE_CD_CODIGO IS NOT NULL THEN
   V_WHERE := V_WHERE || ' AND CNV.CAD_TPE_CD_CODIGO != ''ACS''';
END IF;
V_PERIODO := ' AND (FAT_CCP_DT_PARCELA BETWEEN ' || CHR(39) || pFAT_CCP_DT_PARCELA_INI || CHR(39) || ' AND ' || CHR(39) || TRUNC(NVL(pFAT_CCP_DT_PARCELA_FIM, SYSDATE)) || CHR(39) || ')';
V_SELECT:='SELECT CAD_CNV_CD_HAC_PRESTADOR,
                  ATD_ATE_ID,
                  CAD_PES_NM_PESSOA,
                  CAD_PAC_NR_PRONTUARIO,
                  ATD_ATE_TP_PACIENTE,
                  FAT_CCP_DT_PARCELA,
                  (SELECT S.CAD_SET_DS_SETOR 
                     FROM TB_ATD_IML_INT_MOV_LEITO IML
                    INNER JOIN TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                    INNER JOIN TB_CAD_SET_SETOR S ON QLE.CAD_SET_ID = S.CAD_SET_ID
                    WHERE IML.ATD_ATE_ID = PRONT.ATD_ATE_ID AND
                          NVL(FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_SAIDA, IML.ATD_IML_HR_SAIDA), TRUNC(SYSDATE+1)) =
                          (SELECT MAX(NVL(FNC_JUNTAR_DATA_HORA(ATD_IML_DT_SAIDA, ATD_IML_HR_SAIDA), TRUNC(SYSDATE+1))) FROM TB_ATD_IML_INT_MOV_LEITO WHERE ATD_ATE_ID = IML.ATD_ATE_ID) AND ROWNUM = 1) SETOR,
                  FAT_CCP_ID
          FROM (
          SELECT CNV.CAD_CNV_CD_HAC_PRESTADOR,       
                 ATE.ATD_ATE_ID,
                 PES.CAD_PES_NM_PESSOA,
                 PAC.CAD_PAC_NR_PRONTUARIO,
                 ATE.ATD_ATE_TP_PACIENTE,
                 ATE.ATD_ATE_DT_ATENDIMENTO,
                   CASE WHEN INA.TIS_MSI_CD_MOTIVOSAIDAINT in(41,42,43,65,66,67) THEN INA.ATD_INA_DT_ALTA_CLINICA 
                  ELSE 
                 INA.ATD_INA_DT_ALTA_ADM   END ATD_INA_DT_ALTA_ADM,
                 NVL(TRUNC(CCP.FAT_CCP_DT_PARCELA_INI), ATE.ATD_ATE_DT_ATENDIMENTO) FAT_CCP_DT_PARCELA_INI,
                 CASE WHEN CCP.FAT_CCP_DT_PARCELA IS NOT NULL THEN
                           CCP.FAT_CCP_DT_PARCELA
                      WHEN ATE.ATD_ATE_TP_PACIENTE != ''I'' THEN
                           ATE.ATD_ATE_DT_ATENDIMENTO 
                       WHEN (ATE.ATD_ATE_TP_PACIENTE = ''I'' AND  ina.tis_msi_cd_motivosaidaint in(41,42,43,65,66,67) and
                            (INA.ATD_INA_DT_ALTA_CLINICA IS NULL OR TRUNC(INA.ATD_INA_DT_ALTA_CLINICA) > TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL)) AND
                             (TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO) + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL > TRUNC(SYSDATE))) THEN
                           TRUNC(SYSDATE)
                      WHEN (ATE.ATD_ATE_TP_PACIENTE = ''I'' AND   ina.tis_msi_cd_motivosaidaint in(41,42,43,65,66,67) and
                            (INA.ATD_INA_DT_ALTA_CLINICA IS NULL OR TRUNC(INA.ATD_INA_DT_ALTA_CLINICA) > TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL))) THEN
                           ATE.ATD_ATE_DT_ATENDIMENTO + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL     
                      WHEN (ATE.ATD_ATE_TP_PACIENTE = ''I'' AND
                            (INA.ATD_INA_DT_ALTA_ADM IS NULL OR TRUNC(INA.ATD_INA_DT_ALTA_ADM) > TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL)) AND
                             (TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO) + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL > TRUNC(SYSDATE))) THEN
                           TRUNC(SYSDATE)
                      WHEN (ATE.ATD_ATE_TP_PACIENTE = ''I'' AND
                            (INA.ATD_INA_DT_ALTA_ADM IS NULL OR TRUNC(INA.ATD_INA_DT_ALTA_ADM) > TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL))) THEN
                           ATE.ATD_ATE_DT_ATENDIMENTO + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL
                      ELSE
                           INA.ATD_INA_DT_ALTA_ADM
                 END FAT_CCP_DT_PARCELA,
                 NVL(CCP.FAT_CCP_ID, 1) FAT_CCP_ID,
                 PAC.CAD_PAC_ID_PACIENTE
          FROM   TB_ATD_ATE_ATENDIMENTO          ATE
            JOIN TB_CAD_UNI_UNIDADE              UNI  ON UNI.CAD_UNI_ID_UNIDADE   = ATE.CAD_UNI_ID_UNIDADE
            JOIN TB_ASS_PAT_PACIEATEND           PAT  ON PAT.ATD_ATE_ID           = ATE.ATD_ATE_ID
            LEFT JOIN TB_ATD_INA_INT_ALTA        INA  ON INA.ATD_ATE_ID           = ATE.ATD_ATE_ID
            JOIN TB_CAD_PAC_PACIENTE             PAC  ON PAC.CAD_PAC_ID_PACIENTE  = PAT.CAD_PAC_ID_PACIENTE
            JOIN TB_CAD_PES_PESSOA               PES  ON PES.CAD_PES_ID_PESSOA    = PAC.CAD_PES_ID_PESSOA
            JOIN TB_CAD_CNV_CONVENIO             CNV  ON CNV.CAD_CNV_ID_CONVENIO  = PAC.CAD_CNV_ID_CONVENIO
            LEFT JOIN TB_FAT_CCP_CONTA_CONS_PARC CCP  ON CCP.ATD_ATE_ID           = PAT.ATD_ATE_ID AND CCP.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
           WHERE  ATE.ATD_ATE_FL_STATUS = ''A''   AND ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO !=46
           ' || V_WHERE || '
          UNION
          SELECT CAD_CNV_CD_HAC_PRESTADOR,       
                 ATD_ATE_ID,
                 CAD_PES_NM_PESSOA,
                 CAD_PAC_NR_PRONTUARIO,
                 ATD_ATE_TP_PACIENTE,
                 ATD_ATE_DT_ATENDIMENTO,
                 ATD_INA_DT_ALTA_ADM,
                 FAT_CCP_DT_PARCELA_INI,       
                 CASE WHEN ATD_ATE_TP_PACIENTE != ''I'' THEN
                           ATD_ATE_DT_ATENDIMENTO
                      WHEN (ATD_INA_DT_ALTA_ADM IS NOT NULL AND ATD_INA_DT_ALTA_ADM <= TRUNC(SYSDATE)) THEN
                           ATD_INA_DT_ALTA_ADM
                      WHEN (ATD_ATE_TP_PACIENTE = ''I'' AND
                            (ATD_INA_DT_ALTA_ADM IS NULL OR TRUNC(ATD_INA_DT_ALTA_ADM) > TRUNC(FAT_CCP_DT_PARCELA_INI + CAD_CNV_QT_DIA_CONTA_PARCIAL)) AND
                            (TRUNC(FAT_CCP_DT_PARCELA_INI) + CAD_CNV_QT_DIA_CONTA_PARCIAL > TRUNC(SYSDATE))) THEN
                           TRUNC(SYSDATE)
                      ELSE
                           FAT_CCP_DT_PARCELA_INI + CAD_CNV_QT_DIA_CONTA_PARCIAL       
                 END FAT_CCP_DT_PARCELA,
                 FAT_CCP_ID,
                 CAD_PAC_ID_PACIENTE
          FROM (
          SELECT CNV.CAD_CNV_CD_HAC_PRESTADOR,       
                 ATE.ATD_ATE_ID,
                 PES.CAD_PES_NM_PESSOA,
                 PAC.CAD_PAC_NR_PRONTUARIO,
                 ATE.ATD_ATE_TP_PACIENTE,
                 ATE.ATD_ATE_DT_ATENDIMENTO,
                 CASE WHEN INA.TIS_MSI_CD_MOTIVOSAIDAINT in(41,42,43,65,66,67) THEN INA.ATD_INA_DT_ALTA_CLINICA 
                  ELSE 
                 INA.ATD_INA_DT_ALTA_ADM END ATD_INA_DT_ALTA_ADM, 
                 CASE WHEN CCP.FAT_CCP_DT_PARCELA IS NOT NULL THEN
                           CCP.FAT_CCP_DT_PARCELA
                      WHEN ATE.ATD_ATE_TP_PACIENTE != ''I'' THEN
                           ATE.ATD_ATE_DT_ATENDIMENTO 
                      WHEN (ATE.ATD_ATE_TP_PACIENTE = ''I'' AND ina.tis_msi_cd_motivosaidaint in(41,42,43,65,66,67) and
                            (INA.ATD_INA_DT_ALTA_CLINICA IS NULL OR TRUNC(INA.ATD_INA_DT_ALTA_CLINICA) > TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL)) AND
                             (TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO) + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL > TRUNC(SYSDATE))) THEN
                           TRUNC(SYSDATE)
                      WHEN (ATE.ATD_ATE_TP_PACIENTE = ''I'' AND ina.tis_msi_cd_motivosaidaint in(41,42,43,65,66,67) and
                            (INA.ATD_INA_DT_ALTA_CLINICA IS NULL OR TRUNC(INA.ATD_INA_DT_ALTA_CLINICA) > TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL))) THEN
                           ATE.ATD_ATE_DT_ATENDIMENTO + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL     
                      WHEN (ATE.ATD_ATE_TP_PACIENTE = ''I'' AND
                            (INA.ATD_INA_DT_ALTA_ADM IS NULL OR TRUNC(INA.ATD_INA_DT_ALTA_ADM) > TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL)) AND
                             (TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO) + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL > TRUNC(SYSDATE))) THEN
                           TRUNC(SYSDATE)
                      WHEN (ATE.ATD_ATE_TP_PACIENTE = ''I'' AND
                            (INA.ATD_INA_DT_ALTA_ADM IS NULL OR TRUNC(INA.ATD_INA_DT_ALTA_ADM) > TRUNC(ATE.ATD_ATE_DT_ATENDIMENTO + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL))) THEN
                           ATE.ATD_ATE_DT_ATENDIMENTO + CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL
                      ELSE
                           INA.ATD_INA_DT_ALTA_ADM
                 END FAT_CCP_DT_PARCELA_INI,
                 NULL FAT_CCP_DT_PARCELA,
                 NVL(CCP.FAT_CCP_ID, 1) + 1 FAT_CCP_ID,
                 PAC.CAD_PAC_ID_PACIENTE,
                 CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL
          FROM   TB_ATD_ATE_ATENDIMENTO          ATE
            JOIN TB_CAD_UNI_UNIDADE              UNI  ON UNI.CAD_UNI_ID_UNIDADE   = ATE.CAD_UNI_ID_UNIDADE
            JOIN TB_ASS_PAT_PACIEATEND           PAT  ON PAT.ATD_ATE_ID           = ATE.ATD_ATE_ID
            LEFT JOIN TB_ATD_INA_INT_ALTA        INA  ON INA.ATD_ATE_ID           = ATE.ATD_ATE_ID
            JOIN TB_CAD_PAC_PACIENTE             PAC  ON PAC.CAD_PAC_ID_PACIENTE  = PAT.CAD_PAC_ID_PACIENTE
            JOIN TB_CAD_PES_PESSOA               PES  ON PES.CAD_PES_ID_PESSOA    = PAC.CAD_PES_ID_PESSOA
            JOIN TB_CAD_CNV_CONVENIO             CNV  ON CNV.CAD_CNV_ID_CONVENIO  = PAC.CAD_CNV_ID_CONVENIO
            LEFT JOIN TB_FAT_CCP_CONTA_CONS_PARC CCP  ON CCP.ATD_ATE_ID           = PAT.ATD_ATE_ID AND CCP.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
           WHERE  ATE.ATD_ATE_FL_STATUS = ''A'' AND ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO !=46
           ' || V_WHERE || '
             AND    NVL(CCP.FAT_CCP_ID, 1) = (SELECT MAX(NVL(CCP1.FAT_CCP_ID, 1)) 
                                              FROM TB_ATD_ATE_ATENDIMENTO          ATE1
                                              JOIN TB_CAD_UNI_UNIDADE              UNI1  ON UNI1.CAD_UNI_ID_UNIDADE   = ATE1.CAD_UNI_ID_UNIDADE
                                              JOIN TB_ASS_PAT_PACIEATEND           PAT1  ON PAT1.ATD_ATE_ID           = ATE1.ATD_ATE_ID
                                              LEFT JOIN TB_ATD_INA_INT_ALTA        INA1  ON INA1.ATD_ATE_ID           = ATE1.ATD_ATE_ID
                                              JOIN TB_CAD_PAC_PACIENTE             PAC1  ON PAC1.CAD_PAC_ID_PACIENTE  = PAT1.CAD_PAC_ID_PACIENTE
                                              JOIN TB_CAD_PES_PESSOA               PES1  ON PES1.CAD_PES_ID_PESSOA    = PAC1.CAD_PES_ID_PESSOA
                                              JOIN TB_CAD_CNV_CONVENIO             CNV1  ON CNV1.CAD_CNV_ID_CONVENIO  = PAC1.CAD_CNV_ID_CONVENIO
                                              LEFT JOIN TB_FAT_CCP_CONTA_CONS_PARC CCP1  ON CCP1.ATD_ATE_ID           = PAT1.ATD_ATE_ID AND CCP1.CAD_PAC_ID_PACIENTE = PAT1.CAD_PAC_ID_PACIENTE
                                              WHERE ATE1.ATD_ATE_ID = ATE.ATD_ATE_ID AND PAC1.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE) )
           WHERE CASE WHEN ATD_ATE_TP_PACIENTE != ''I'' THEN
                           ATD_ATE_DT_ATENDIMENTO
                      WHEN (ATD_INA_DT_ALTA_ADM IS NOT NULL AND ATD_INA_DT_ALTA_ADM <= TRUNC(SYSDATE)) THEN
                           ATD_INA_DT_ALTA_ADM
                      WHEN (ATD_ATE_TP_PACIENTE = ''I'' AND
                            (ATD_INA_DT_ALTA_ADM IS NULL OR TRUNC(ATD_INA_DT_ALTA_ADM) > TRUNC(FAT_CCP_DT_PARCELA_INI + CAD_CNV_QT_DIA_CONTA_PARCIAL)) AND
                            (TRUNC(FAT_CCP_DT_PARCELA_INI) + CAD_CNV_QT_DIA_CONTA_PARCIAL > TRUNC(SYSDATE))) THEN
                           TRUNC(SYSDATE)
                      ELSE
                           FAT_CCP_DT_PARCELA_INI + CAD_CNV_QT_DIA_CONTA_PARCIAL       
                 END != FAT_CCP_DT_PARCELA_INI
           ) PRONT
           WHERE NOT EXISTS ( SELECT 0 FROM TB_FAT_COP_CONTROLE_PRONTUARIO COP WHERE COP.ATD_ATE_ID = PRONT.ATD_ATE_ID AND COP.FAT_CCP_ID = PRONT.FAT_CCP_ID) AND
                 ((ATD_INA_DT_ALTA_ADM IS NOT NULL OR (FAT_CCP_DT_PARCELA = TRUNC(SYSDATE) AND FAT_CCP_DT_PARCELA_INI < TRUNC(SYSDATE)))   
                  OR (FAT_CCP_DT_PARCELA_INI < TRUNC(SYSDATE) AND FAT_CCP_DT_PARCELA < TRUNC(SYSDATE))) 
                  AND NOT EXISTS(SELECT PAT.ATD_ATE_ID, PAT.CAD_PAC_ID_PACIENTE FROM TB_ASS_PAT_PACIEATEND PAT WHERE PAT.ASS_PAT_DT_SAIDA IS NOT NULL 
                  AND PAT.CAD_PAC_ID_PACIENTE = PRONT.CAD_PAC_ID_PACIENTE 
                  AND PAT.ATD_ATE_ID = PRONT.ATD_ATE_ID )
           ' || V_PERIODO ||
           ' ORDER BY 3';
--teste:= v_select; 
 OPEN v_cursor FOR
   V_SELECT ;
 -- select 1 from dual;
  io_cursor := v_cursor;
END PRC_FAT_REL_PRONTUARIOS_P; 