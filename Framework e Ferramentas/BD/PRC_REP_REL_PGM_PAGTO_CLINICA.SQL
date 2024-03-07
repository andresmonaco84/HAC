CREATE OR REPLACE PROCEDURE PRC_REP_REL_PGM_PAGTO_CLINICA
  (
     pREP_PGM_MES_PAGTO_INI IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%type,
     pREP_PGM_ANO_PAGTO_INI IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%type,
     
     pREP_PGM_TP_CREDENCIA_PROF IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE,
     
     pCAD_CLC_ID IN TB_REP_PGM_PAGTO_MEDICO.CAD_CLC_ID%TYPE,
     
     pSEMCONSULTA IN CHAR,
     
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
/********************************************************************
*    Procedure: PRC_REP_REL_PGM_PAGTO_CLINICA
*
*    Data Criacao:   data da  criação   Por: Nome do Analista
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/

  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE VARCHAR2(3000);
  V_SELECT VARCHAR2(5000);

  begin
    V_WHERE := NULL;

    IF pREP_PGM_TP_CREDENCIA_PROF IS NOT NULL THEN 
       V_WHERE:= V_WHERE || ' AND PGM.REP_PGM_TP_CREDENCIA_PROF = ' || CHR(39) ||  pREP_PGM_TP_CREDENCIA_PROF || CHR(39); 
    END IF;
      
    IF pSEMCONSULTA = 'S' THEN
       V_WHERE := V_WHERE || ' AND PGM.AUX_EPP_CD_ESPECPROC != 101 ';
    END IF;

    V_SELECT := '
                    SELECT EPP.AUX_EPP_DS_DESCRICAO, 
                    LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO, 
                    CNV.CAD_CNV_CD_HAC_PRESTADOR, 
                    UNI.CAD_UNI_DS_UNIDADE,
                    CLC.CAD_CLC_CD_CLINICA,
                    CLC.CAD_CLC_DS_DESCRICAO,
                    PGM.CAD_CLC_ID,
                    PGM.REP_PGM_TP_CREDENCIA_PROF,
                    PGM.REP_PGM_MES_PAGTO,
                    PGM.REP_PGM_ANO_PAGTO,
                    FNC_REP_REL_SUB_VLHORA(PGM.REP_PGM_MES_PAGTO, 
                                           PGM.REP_PGM_ANO_PAGTO, 
                                           PGM.CAD_CLC_ID, 
                                           PGM.REP_PGM_TP_CREDENCIA_PROF) VLHORA,
                    FNC_REP_REL_SUB_VLHORAEXTRA(PGM.REP_PGM_MES_PAGTO, 
                                           PGM.REP_PGM_ANO_PAGTO, 
                                           PGM.CAD_CLC_ID, 
                                           PGM.REP_PGM_TP_CREDENCIA_PROF) VLHORAEXTRA,
                    FNC_REP_REL_SUB_VLACRESCIMO(PGM.REP_PGM_MES_PAGTO, 
                                           PGM.REP_PGM_ANO_PAGTO, 
                                           PGM.CAD_CLC_ID, 
                                           PGM.REP_PGM_TP_CREDENCIA_PROF) VLACRESCIMO,
                    FNC_REP_REL_SUB_VLDESCONTO(PGM.REP_PGM_MES_PAGTO, 
                                           PGM.REP_PGM_ANO_PAGTO, 
                                           PGM.CAD_CLC_ID, 
                                           PGM.REP_PGM_TP_CREDENCIA_PROF) VLDESCONTO,
                              
                    SUM(NVL(PGM.REP_PGM_QT_CONSUMO,0)) QTD_CONSUMO,
                    SUM(NVL(PGM.REP_PGM_VL_CALCULADO,0)) VL_CALCULADO,
                    SUM(NVL(PGM.REP_PGM_VL_PAGO,0)) VL_PAGO

                  FROM TB_REP_PGM_PAGTO_MEDICO PGM,
                       TB_AUX_EPP_ESPECPROC EPP,
                       TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
                       TB_CAD_UNI_UNIDADE UNI,
                       TB_CAD_CNV_CONVENIO CNV,
                       TB_CAD_CLC_CLINICA_CREDENCIADA CLC
                 WHERE PGM.AUX_EPP_CD_ESPECPROC = EPP.AUX_EPP_CD_ESPECPROC
                   AND (PGM.TIS_MED_CD_TABELAMEDICA = EPP.TIS_MED_CD_TABELAMEDICA OR PGM.TIS_MED_CD_TABELAMEDICA IS NULL)
                   AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
                   AND CLC.CAD_CLC_ID = PGM.CAD_CLC_ID
                   AND UNI.CAD_UNI_ID_UNIDADE = PGM.CAD_UNI_ID_UNIDADE
                   AND PGM.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
                   AND PGM.REP_PGM_MES_PAGTO = ' || pREP_PGM_MES_PAGTO_INI || '
                   AND PGM.REP_PGM_ANO_PAGTO = ' || pREP_PGM_ANO_PAGTO_INI || '
                   AND PGM.CAD_CLC_ID = ' || pCAD_CLC_ID
                   || V_WHERE ||
                '
                GROUP BY 
                      EPP.AUX_EPP_DS_DESCRICAO, 
                      LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO, 
                      CNV.CAD_CNV_CD_HAC_PRESTADOR, 
                      UNI.CAD_UNI_DS_UNIDADE,
                      CLC.CAD_CLC_CD_CLINICA,
                      CLC.CAD_CLC_DS_DESCRICAO,
                      PGM.CAD_CLC_ID,
                      PGM.REP_PGM_TP_CREDENCIA_PROF,
                      PGM.REP_PGM_MES_PAGTO,
                      PGM.REP_PGM_ANO_PAGTO,
                      FNC_REP_REL_SUB_VLHORA(PGM.REP_PGM_MES_PAGTO, 
                                             PGM.REP_PGM_ANO_PAGTO, 
                                             PGM.CAD_CLC_ID, 
                                             PGM.REP_PGM_TP_CREDENCIA_PROF),
                      FNC_REP_REL_SUB_VLHORAEXTRA(PGM.REP_PGM_MES_PAGTO, 
                                             PGM.REP_PGM_ANO_PAGTO, 
                                             PGM.CAD_CLC_ID, 
                                             PGM.REP_PGM_TP_CREDENCIA_PROF),
                      FNC_REP_REL_SUB_VLACRESCIMO(PGM.REP_PGM_MES_PAGTO, 
                                             PGM.REP_PGM_ANO_PAGTO, 
                                             PGM.CAD_CLC_ID, 
                                             PGM.REP_PGM_TP_CREDENCIA_PROF),
                      FNC_REP_REL_SUB_VLDESCONTO(PGM.REP_PGM_MES_PAGTO, 
                                             PGM.REP_PGM_ANO_PAGTO, 
                                             PGM.CAD_CLC_ID, 
                                             PGM.REP_PGM_TP_CREDENCIA_PROF)';

    OPEN v_cursor FOR
         V_SELECT;
         
    io_cursor := v_cursor;
  end PRC_REP_REL_PGM_PAGTO_CLINICA;
