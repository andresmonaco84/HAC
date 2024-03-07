

  --PRC_AGS_ESF_ESCALA_FALTA_SADT_I
  create or replace procedure PRC_AGS_ESF_ESM_FALTA_SADT_I
  (
     pNewIdt OUT integer,
     pAGS_ESF_ID IN TB_AGS_ESF_ESCALA_FALTA_SADT.AGS_ESF_ID%type default NULL,
     pAGS_ESF_DT_INI_FALTA IN TB_AGS_ESF_ESCALA_FALTA_SADT.AGS_ESF_DT_INI_FALTA%type,
     pAGS_ESF_DT_FIM_FALTA IN TB_AGS_ESF_ESCALA_FALTA_SADT.AGS_ESF_DT_FIM_FALTA%type,
     pAGS_ESF_DS_OBSERVACAO IN TB_AGS_ESF_ESCALA_FALTA_SADT.AGS_ESF_DS_OBSERVACAO%type default NULL,
     pAGS_ESF_FL_SUBSTITUTO_OK IN TB_AGS_ESF_ESCALA_FALTA_SADT.AGS_ESF_FL_SUBSTITUTO_OK%type,
     pCAD_PRO_ID_PROFISSIONAL_SUBST IN TB_AGS_ESF_ESCALA_FALTA_SADT.CAD_PRO_ID_PROFISSIONAL_SUBST%type default NULL,
     pAGS_ESM_ID IN TB_AGS_ESF_ESCALA_FALTA_SADT.AGS_ESM_ID%type,
     pAGS_ESF_DT_ULTIMA_ATUALIZACAO IN TB_AGS_ESF_ESCALA_FALTA_SADT.AGS_ESF_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_AGS_ESF_ESCALA_FALTA_SADT.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGS_ESF_ESCALA_FALTA_SADT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_AGS_ESF_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_AGS_ESF_ESCALA_FALTA_SADT
    (
       AGS_ESF_ID,
       AGS_ESF_DT_INI_FALTA,
       AGS_ESF_DT_FIM_FALTA,
       AGS_ESF_DS_OBSERVACAO,
       AGS_ESF_FL_SUBSTITUTO_OK,
       CAD_PRO_ID_PROFISSIONAL_SUBST,
       AGS_ESM_ID,
       AGS_ESF_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (

         lIdtRetorno,
	     pAGS_ESF_DT_INI_FALTA,
	     pAGS_ESF_DT_FIM_FALTA,
	     pAGS_ESF_DS_OBSERVACAO,
	     pAGS_ESF_FL_SUBSTITUTO_OK,
	     pCAD_PRO_ID_PROFISSIONAL_SUBST,
	     pAGS_ESM_ID,
	     pAGS_ESF_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_AGS_ESF_ESM_FALTA_SADT_I;

