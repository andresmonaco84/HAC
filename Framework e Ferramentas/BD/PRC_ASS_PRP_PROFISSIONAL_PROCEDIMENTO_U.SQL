  -- PRC_ASS_PRP_PROF_PROC_U
  create or replace procedure PRC_ASS_PRP_PROF_PROC_U
  (
     pASS_PRP_ID IN TB_ASS_PRP_PROFISSIONAL_PROD.ASS_PRP_ID%type,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_PRO_ID_PROFISSIONAL%type default NULL,
     pCAD_PRD_ID IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_PRD_ID%type default NULL, 
     pASS_PRP_FL_ATIVO_OK IN TB_ASS_PRP_PROFISSIONAL_PROD.ASS_PRP_FL_ATIVO_OK%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_PRP_PROFISSIONAL_PROD.SEG_USU_ID_USUARIO%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PRP_PROF_PROC_U
  * 
  *    Data Criacao: 	18/08/2008           Por: Davi Silvestre M. dos Reis
  *    Data Alteracao:	                   Por: 
  *
  *    Funcao: Atualizacao de registros na tabela TB_ASS_PRP_PROFISSIONAL_PROD
  *
  *******************************************************************/  
  begin
    UPDATE TB_ASS_PRP_PROFISSIONAL_PROD PRP
    SET	   
        PRP.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL,
        PRP.CAD_PRD_ID = pCAD_PRD_ID,
        PRP.ASS_PRP_FL_ATIVO_OK = pASS_PRP_FL_ATIVO_OK,
        PRP.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        PRP.ASS_PRP_DT_ULTIMA_ATUALIZACAO = SYSDATE 
    WHERE
        PRP.ASS_PRP_ID = pASS_PRP_ID;
            
  end PRC_ASS_PRP_PROF_PROC_U;
/
