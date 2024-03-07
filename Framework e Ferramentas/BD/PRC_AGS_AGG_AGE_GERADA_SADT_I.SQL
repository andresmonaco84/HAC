 create or replace procedure PRC_AGS_AGG_AGE_GERADA_SADT_I
  (
     pNewIdt OUT integer,
     pAGS_AGG_ID IN TB_AGS_AGG_AGE_GERADA_SADT.AGS_AGG_ID%type default NULL,
     pAGS_ESM_ID IN TB_AGS_AGG_AGE_GERADA_SADT.AGS_ESM_ID%type,
     pAGS_ESF_ID IN TB_AGS_AGG_AGE_GERADA_SADT.AGS_ESF_ID%type default NULL,
     pAGS_AGG_DT_AGENDA_GERADA IN TB_AGS_AGG_AGE_GERADA_SADT.AGS_AGG_DT_AGENDA_GERADA%type,
     pAGS_AGG_HR_AGENDA_GERADA IN TB_AGS_AGG_AGE_GERADA_SADT.AGS_AGG_HR_AGENDA_GERADA%type,
     pAGS_AGG_TP_HORARIO IN TB_AGS_AGG_AGE_GERADA_SADT.AGS_AGG_TP_HORARIO%type,
     pAGS_AGG_FL_STATUS_HORARIO IN TB_AGS_AGG_AGE_GERADA_SADT.AGS_AGG_FL_STATUS_HORARIO%type,
     pAGS_AGG_DT_ULTIMA_ATUALIZACAO IN TB_AGS_AGG_AGE_GERADA_SADT.AGS_AGG_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_AGS_AGG_AGE_GERADA_SADT.SEG_USU_ID_USUARIO%type,
     pASS_EHR_ID IN TB_AGS_AGG_AGE_GERADA_SADT.ASS_EHR_ID%type default NULL  
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGS_AGG_AGE_GERADA_SADT_I
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure

  *


  *******************************************************************/  

    lIdtRetorno integer;
    
  begin


    SELECT SEQ_AGS_AGG_01.NextVal INTO lIdtRetorno FROM DUAL;
      
    INSERT INTO TB_AGS_AGG_AGE_GERADA_SADT
    (
       AGS_AGG_ID,
       AGS_ESM_ID,
       AGS_ESF_ID,
       AGS_AGG_DT_AGENDA_GERADA,
       AGS_AGG_HR_AGENDA_GERADA,
       AGS_AGG_TP_HORARIO,
       AGS_AGG_FL_STATUS_HORARIO,
       AGS_AGG_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ASS_EHR_ID
    )
    VALUES
    (

         lIdtRetorno,
       pAGS_ESM_ID,
       pAGS_ESF_ID,
       pAGS_AGG_DT_AGENDA_GERADA,
       pAGS_AGG_HR_AGENDA_GERADA,
       pAGS_AGG_TP_HORARIO,
       pAGS_AGG_FL_STATUS_HORARIO,
       pAGS_AGG_DT_ULTIMA_ATUALIZACAO,
       pSEG_USU_ID_USUARIO,
       pASS_EHR_ID
    );
    pNewIdt := lIdtRetorno;  

  end PRC_AGS_AGG_AGE_GERADA_SADT_I;


