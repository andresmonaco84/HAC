CREATE OR REPLACE PROCEDURE "PRC_AGE_AGG_AGENDA_GERADA_S"
  (
     pAGE_AGG_ID IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_ID%type DEFAULT NULL,
     pAGE_AGG_DT_AGENDA IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_DT_AGENDA%type DEFAULT NULL,
     pAGE_AGG_HR_AGENDA IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_HR_AGENDA%type DEFAULT NULL,
     pAGE_ESM_ID IN TB_AGE_AGG_AGENDA_GERADA.AGE_ESM_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor--,
   -- TESTE OUT  LONG
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_AGG_AGENDA_GERADA_S
  *
  *    Data Alteracao:  23/05/2013  Por: Pedro
  *       Alteracao: custo
  *
  *    Funcao: Lista a Agenda Gerada
  *
  *******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(3000);

  V_SELECT  varchar2(10000);
  begin
    V_WHERE := NULL;
    IF pAGE_AGG_ID IS NOT NULL THEN  V_WHERE := V_WHERE || ' AND AGE_AGG_ID = ' || pAGE_AGG_ID;    END IF;
    IF pAGE_AGG_DT_AGENDA IS NOT NULL THEN V_WHERE := V_WHERE || ' AND AGE_AGG_DT_AGENDA = ' ||CHR(39)|| pAGE_AGG_DT_AGENDA ||CHR(39);    END IF;
    IF pAGE_AGG_HR_AGENDA IS NOT NULL THEN V_WHERE := V_WHERE || ' AND AGE_AGG_HR_AGENDA = ' || pAGE_AGG_HR_AGENDA;    END IF;
    IF pAGE_ESM_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND AGE_ESM_ID = ' || pAGE_ESM_ID;    END IF;


   V_SELECT :=
   '
    SELECT
       AGE_AGG_ID,
       AGE_ESM_ID,
       AGE_ESF_ID,
       AGE_AGG_DT_AGENDA,
       AGE_AGG_HR_AGENDA,
       AGE_AGG_TP_HORARIO,
       AGE_AGG_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       AGE_AGG_FL_STATUS_HORARIO,
       AGE_AGG_DS_BLOQUEIO
    FROM TB_AGE_AGG_AGENDA_GERADA
    WHERE AGE_AGG_DT_AGENDA BETWEEN TRUNC(SYSDATE) AND ADD_MONTHS(TRUNC(SYSDATE), 3)
    ' || V_WHERE || '
    ORDER BY AGE_AGG_DT_AGENDA';
    -- TESTE :=  V_SELECT ;
OPEN v_cursor FOR
   V_SELECT ;
    io_cursor := v_cursor;
  end PRC_AGE_AGG_AGENDA_GERADA_S;
 