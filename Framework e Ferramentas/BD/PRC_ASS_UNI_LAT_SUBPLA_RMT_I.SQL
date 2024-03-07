  --PRC_ASS_UNI_LAT_SUBPLA_RMT_I
  create or replace procedure PRC_ASS_UNI_LAT_SUBPLA_RMT_I
  (
     pNewIdt OUT integer,
     pASS_USP_ID IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_ID%type default NULL,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SPL_ID IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_SPL_ID%type,
     pASS_USP_FL_STATUS IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.SEG_USU_ID_USUARIO%type,
     pASS_USP_DT_ULTIMA_ATUALIZACAO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_DT_ULTIMA_ATUALIZACAO%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_PLA_ID_PLANO%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UNI_LAT_SUBPLA_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_ASS_UTA_28.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ASS_USP_UNI_LAT_SUB_PLANO
    (
       ASS_USP_ID,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_SPL_ID,
       ASS_USP_FL_STATUS,
       SEG_USU_ID_USUARIO,
       ASS_USP_DT_ULTIMA_ATUALIZACAO,
       CAD_PLA_ID_PLANO
    )
    VALUES
    (
      lIdtRetorno,
	     pCAD_UNI_ID_UNIDADE,
	     pCAD_LAT_ID_LOCAL_ATENDIMENTO,
	     pCAD_SPL_ID,
	     pASS_USP_FL_STATUS,
	     pSEG_USU_ID_USUARIO,
	     pASS_USP_DT_ULTIMA_ATUALIZACAO,
	     pCAD_PLA_ID_PLANO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_ASS_UNI_LAT_SUBPLA_RMT_I;

