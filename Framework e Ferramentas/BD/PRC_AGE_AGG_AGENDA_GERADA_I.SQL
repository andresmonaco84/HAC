  create or replace procedure PRC_AGE_AGG_AGENDA_GERADA_I
  (
     pNewIdt OUT integer,
     pAGE_AGG_ID IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_ID%type default NULL,
     pAGE_ESM_ID IN TB_AGE_AGG_AGENDA_GERADA.AGE_ESM_ID%type,
     pAGE_ESF_ID IN TB_AGE_AGG_AGENDA_GERADA.AGE_ESF_ID%type default NULL,
     pAGE_AGG_DT_AGENDA IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_DT_AGENDA%type,
     pAGE_AGG_HR_AGENDA IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_HR_AGENDA%type,
     pAGE_AGG_TP_HORARIO IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_TP_HORARIO%type,
     pSEG_USU_ID_USUARIO IN TB_AGE_AGG_AGENDA_GERADA.SEG_USU_ID_USUARIO%type,
     pAGE_AGG_FL_STATUS_HORARIO IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_FL_STATUS_HORARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGE_AGG_AGENDA_GERADA_I
  * 
  *    Data Criacao: 	13/08/2007        Por: Carlos Araujo
  *    Data Alteracao:	                Por: 
  *
  *    Funcao: Inclui horário de uma determinada agenda
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_AGE_AGG_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_AGE_AGG_AGENDA_GERADA
    (
       AGE_AGG_ID,
       AGE_ESM_ID,
       AGE_ESF_ID,
       AGE_AGG_DT_AGENDA,
       AGE_AGG_HR_AGENDA,
       AGE_AGG_TP_HORARIO,
       AGE_AGG_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       AGE_AGG_FL_STATUS_HORARIO
    )
    VALUES
    (
	     lIdtRetorno,
	     pAGE_ESM_ID,
	     pAGE_ESF_ID,
	     pAGE_AGG_DT_AGENDA,
	     pAGE_AGG_HR_AGENDA,
	     pAGE_AGG_TP_HORARIO,
	     sysdate(),
	     pSEG_USU_ID_USUARIO,
	     pAGE_AGG_FL_STATUS_HORARIO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_AGE_AGG_AGENDA_GERADA_I;
/
