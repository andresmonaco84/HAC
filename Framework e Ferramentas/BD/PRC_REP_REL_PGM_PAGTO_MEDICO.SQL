CREATE OR REPLACE PROCEDURE PRC_REP_REL_PGM_PAGTO_MEDICO
  (
     pREP_PGM_MES_PAGTO_INI IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%type,
     pREP_PGM_ANO_PAGTO_INI IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%type,

     pREP_PGM_TP_CREDENCIA_PROF IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE,

     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
/********************************************************************
*    Procedure: PRC_REP_REL_PGM_PAGTO_MEDICO
*
*    Data Criacao:    data da  criação   Por: Nome do Analista
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE VARCHAR2(2000);
  V_SELECT VARCHAR2(2000);

  begin
    V_WHERE := NULL;
   
    IF pREP_PGM_TP_CREDENCIA_PROF IS NOT NULL THEN 
       V_WHERE:= V_WHERE || ' AND PGM.REP_PGM_TP_CREDENCIA_PROF = ' || CHR(39) ||  pREP_PGM_TP_CREDENCIA_PROF || CHR(39); 
    END IF;
      
    V_SELECT := 'SELECT CLC.CAD_CLC_ID,
						            LPAD(CLC.CAD_CLC_CD_CLINICA, 4, ''0'') CAD_CLC_CD_CLINICA,
                        CLC.CAD_CLC_DS_DESCRICAO,
                        SUM(NVL(PGM.REP_PGM_QT_CONSUMO,0)) TOTAL_CONSUMO,
                        SUM(NVL(PGM.REP_PGM_VL_PAGO,0)) TOTAL_VALOR_PAGO

                   FROM TB_REP_PGM_PAGTO_MEDICO PGM, 
                        TB_CAD_CLC_CLINICA_CREDENCIADA CLC
                        
                  WHERE PGM.REP_PGM_FL_STATUS <> ''I''
                    AND PGM.CAD_CLC_ID = CLC.CAD_CLC_ID
                  
                    AND PGM.REP_PGM_MES_PAGTO = ' || pREP_PGM_MES_PAGTO_INI || '
                    AND PGM.REP_PGM_ANO_PAGTO = ' || pREP_PGM_ANO_PAGTO_INI
                     || V_WHERE || '
                     
                  GROUP BY CLC.CAD_CLC_ID, CLC.CAD_CLC_CD_CLINICA, CLC.CAD_CLC_DS_DESCRICAO
                  ORDER BY CLC.CAD_CLC_DS_DESCRICAO ';
                  
    OPEN v_cursor FOR
    V_SELECT;
    io_cursor := v_cursor;
  end PRC_REP_REL_PGM_PAGTO_MEDICO;
