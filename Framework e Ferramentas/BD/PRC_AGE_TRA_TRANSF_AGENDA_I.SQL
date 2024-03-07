  --PRC_AGE_TRA_TRANSF_AGENDA_I
  create or replace procedure PRC_AGE_TRA_TRANSF_AGENDA_I
  (
     pNewIdt OUT integer,
     pAGE_TRA_DT_TRANSF IN TB_AGE_TRA_TRANSF_AGENDA.AGE_TRA_DT_TRANSF%type,
     pAGE_TRA_HR_TRANSF IN TB_AGE_TRA_TRANSF_AGENDA.AGE_TRA_HR_TRANSF%type,
     pAGE_TRA_TP_TRANSF IN TB_AGE_TRA_TRANSF_AGENDA.AGE_TRA_TP_TRANSF%type,
     pSEG_USU_ID_USUARIO IN TB_AGE_TRA_TRANSF_AGENDA.SEG_USU_ID_USUARIO%type,
     pAGE_AGG_ID_ORIGEM IN TB_AGE_TRA_TRANSF_AGENDA.AGE_AGG_ID_ORIGEM%type,
     pAGE_AGG_ID_DESTINO IN TB_AGE_TRA_TRANSF_AGENDA.AGE_AGG_ID_DESTINO%type,
     pCAD_PAC_ID_PACIENTE IN TB_AGE_TRA_TRANSF_AGENDA.CAD_PAC_ID_PACIENTE%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGE_TRA_TRANSF_AGENDA_I
  * 
  *    Data Criacao: 	22/08/2007   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Insere dados da transferencia de paciente
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_AGE_TRA_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_AGE_TRA_TRANSF_AGENDA
    (
       AGE_TRA_ID,
       AGE_TRA_DT_TRANSF,
       AGE_TRA_HR_TRANSF,
       AGE_TRA_TP_TRANSF,
       SEG_USU_ID_USUARIO,
       AGE_TRA_DT_ULTIMA_ATUALIZACAO,
       AGE_AGG_ID_ORIGEM,
       AGE_AGG_ID_DESTINO,
       CAD_PAC_ID_PACIENTE
    )
    VALUES
    (
	     lIdtRetorno,
	     pAGE_TRA_DT_TRANSF,
	     pAGE_TRA_HR_TRANSF,
	     pAGE_TRA_TP_TRANSF,
	     pSEG_USU_ID_USUARIO,
	     sysdate,
	     pAGE_AGG_ID_ORIGEM,
	     pAGE_AGG_ID_DESTINO,
	     pCAD_PAC_ID_PACIENTE
    );
    pNewIdt := lIdtRetorno;	
  end PRC_AGE_TRA_TRANSF_AGENDA_I;
/
