CREATE OR REPLACE PROCEDURE "PRC_REP_REL_PROC_SCLI" (
    pREP_PGM_MES_PAGTO_INI       IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
    pREP_PGM_ANO_PAGTO_INI       IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
    pSEMCONSULTA                 IN STRING,
    IO_CURSOR                OUT PKG_CURSOR.T_CURSOR
)
IS
/********************************************************************
*
*    PROCEDURE: PRC_REP_REL_PROC_SCLI
*    DATA       POR:
*    ALTERAÇÃO: Soraya - 04/09/2012
*               De:   PGM.CAD_CLC_ID = 45  e != 45 (linha 55 e 70)
*               Para: PGM.CAD_CLC_ID = 367 e != 367 
*
*
*********************************************************************/
 V_CURSOR PKG_CURSOR.T_CURSOR;
 V_WHERE  VARCHAR2(5000);
 V_SELECT VARCHAR2(5000);
 V_GROUP  VARCHAR2(5000);
BEGIN
    V_SELECT := NULL;
    V_GROUP  := NULL;
    V_WHERE  := NULL;
    IF (pREP_PGM_MES_PAGTO_INI IS NOT NULL) THEN
      V_WHERE := V_WHERE || ' AND PGM.REP_PGM_MES_PAGTO = ' || pREP_PGM_MES_PAGTO_INI;
    END IF;
    IF (pREP_PGM_ANO_PAGTO_INI IS NOT NULL) THEN
      V_WHERE := V_WHERE || ' AND PGM.REP_PGM_ANO_PAGTO = ' || pREP_PGM_ANO_PAGTO_INI;
    END IF;
    IF (pSEMCONSULTA = 'S') THEN
       V_WHERE := V_WHERE || ' AND PGM.AUX_EPP_CD_ESPECPROC != 101 ';
    END IF;
    V_SELECT := 'SELECT  CLC.CAD_CLC_CD_CLINICA, 
                         PGM.CAD_PLA_CD_TIPOPLANO, 
                         LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
                         PRD.CAD_PRD_CD_CODIGO || '' - '' || PRD.CAD_PRD_DS_DESCRICAO PROCEDIMENTO,
                         UNI.CAD_UNI_CD_HOSPITALAR,
                         PGM.ATD_ATE_ID,
                         PGM.REP_PGM_DT_INICIO_REALIZACAO,
                         SUM(PGM.REP_PGM_VL_FATURADO) VL_FATURADO,
                         SUM(PGM.REP_PGM_VL_CALCULADO) VL_CALCULADO,
                         SUM(PGM.REP_PGM_QT_CONSUMO) QTD_CONSUMO,
                         SUM(PGM.REP_PGM_VL_PAGO) VL_PAGO,
                         PRO.CAD_PRO_NR_CONSELHO,
                         PRO.CAD_PRO_NM_NOME
                    FROM TB_REP_PGM_PAGTO_MEDICO PGM, 
                         TB_CAD_CLC_CLINICA_CREDENCIADA CLC, 
                         TB_CAD_UNI_UNIDADE UNI,
                         TB_CAD_PRD_PRODUTO PRD,
                         TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
                         TB_CAD_PRO_PROFISSIONAL PRO
                   WHERE 
                     PGM.CAD_CLC_ID = 367
                     AND PGM.CAD_CLC_ID = CLC.CAD_CLC_ID
                     AND PGM.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
                     AND PGM.CAD_PRD_ID = PRD.CAD_PRD_ID
                     AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
                     AND PGM.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL
                     ' || V_WHERE || '
                     AND PGM.CAD_PRD_ID IN ( SELECT CAD_PRD_ID
                                               FROM TB_REP_PGM_PAGTO_MEDICO PGM_1
                                              WHERE PGM.CAD_PRO_ID_PROFISSIONAL = PGM_1.CAD_PRO_ID_PROFISSIONAL
                                                AND PGM.CAD_CLC_ID = PGM_1.CAD_CLC_ID
                                                AND PGM.CAD_PLA_CD_TIPOPLANO = PGM_1.CAD_PLA_CD_TIPOPLANO
                                                AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = PGM_1.CAD_LAT_ID_LOCAL_ATENDIMENTO
                                                AND PGM.CAD_UNI_ID_UNIDADE = PGM_1.CAD_UNI_ID_UNIDADE
                                                ' || V_WHERE || '
                                                AND PGM_1.CAD_CLC_ID != 367 )';
    V_GROUP := ' GROUP BY CLC.CAD_CLC_CD_CLINICA, 
                          PGM.CAD_PLA_CD_TIPOPLANO, 
                          LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
                          PRD.CAD_PRD_CD_CODIGO || '' - '' || PRD.CAD_PRD_DS_DESCRICAO,
                          UNI.CAD_UNI_CD_HOSPITALAR,
                          PGM.ATD_ATE_ID,
                          PGM.REP_PGM_DT_INICIO_REALIZACAO,
                          PRO.CAD_PRO_NR_CONSELHO,
                          PRO.CAD_PRO_NM_NOME ';
    --dbms_output.put_line(v_select || v_group);
    OPEN v_cursor FOR
         V_SELECT || V_GROUP;
    io_cursor := v_cursor;
END PRC_REP_REL_PROC_SCLI;
 