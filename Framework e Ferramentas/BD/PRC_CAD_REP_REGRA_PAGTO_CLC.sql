CREATE OR REPLACE PROCEDURE "PRC_CAD_REP_REGRA_PAGTO_CLC" (pCAD_CLC_CD_CLINICA IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_CD_CLINICA%type DEFAULT NULL,
                                                           pFLAG_VIGENTE       IN CHAR,
                                                           io_cursor           OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_CAD_REP_REGRA_PAGAMENTO_L
  *
  *    Data Criacao:  data da  criaÿ§ÿ£o   Por: Nome do Analista
  *    Data Alteracao: data da alteraÿ§ÿ£o  Por: Nome do Analista
  *
  *    Funcao: Descriÿ§ÿ£o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE           VARCHAR2(6000);
  V_SELECT          VARCHAR2(8000);
BEGIN

    IF pFLAG_VIGENTE = 'S' THEN
       V_WHERE := V_WHERE || '
       AND (RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL 
       OR 
       TO_DATE(RPG.CAD_REP_DT_FIM_VIGENCIA, '|| CHR(39) ||'dd/mm/yyyy'|| CHR(39) ||') >= 
       TO_DATE(SYSDATE,  '|| CHR(39) ||'dd/mm/yyyy'|| CHR(39) ||')) 
       AND 
       (CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL OR TO_DATE(CPR.ASS_CPR_DT_FIM_VIGENCIA, '|| CHR(39)||'dd/mm/yyyy'|| CHR(39) ||') >= 
       TO_DATE(SYSDATE, '|| CHR(39) ||'dd/mm/yyyy'|| CHR(39) ||')) ';
    ELSE
       V_WHERE := V_WHERE || '
       AND (TO_DATE(RPG.CAD_REP_DT_FIM_VIGENCIA, '|| CHR(39) || 'DD/MM/YYYY' || CHR(39) ||') <= 
       TO_DATE(SYSDATE, '|| CHR(39) || 'DD/MM/YYYY' || CHR(39) ||'))
       AND 
       (CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL 
       OR 
       TO_DATE(CPR.ASS_CPR_DT_FIM_VIGENCIA, '|| CHR(39) ||'DD/MM/YYYY'|| CHR(39) ||') <= 
       TO_DATE(SYSDATE, '|| CHR(39) || 'DD/MM/YYYY' ||  CHR(39) ||')) ';
    END IF;

V_SELECT := '
    SELECT DISTINCT REP.*
      FROM TB_ASS_RPG_REGRA_PAGTO RPG
     INNER JOIN TB_ASS_CPR_CLINICA_PROF CPR
        ON RPG.ASS_CPR_ID = CPR.ASS_CPR_ID
     INNER JOIN TB_CAD_CLC_CLINICA_CREDENCIADA CLC
        ON CPR.CAD_CLC_ID = CLC.CAD_CLC_ID
     INNER JOIN TB_CAD_REP_REGRA_PAGAMENTO REP
        ON RPG.CAD_REP_ID = REP.CAD_REP_ID
     WHERE CLC.CAD_CLC_CD_CLINICA = ' || pCAD_CLC_CD_CLINICA;

  OPEN V_CURSOR FOR V_SELECT || V_WHERE;
       -- DBMS_OUTPUT.put_line(V_SELECT || V_WHERE);
  IO_CURSOR := V_CURSOR;
  
END PRC_CAD_REP_REGRA_PAGTO_CLC;