create or replace procedure PRC_ASS_PRP_PROF_PROC_U
  (
     pASS_PRP_ID IN TB_ASS_PRP_PROFISSIONAL_PROD.ASS_PRP_ID%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_PRO_ID_PROFISSIONAL%type default NULL,
     pCAD_PRD_ID IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_PRD_ID%type default NULL,
     pASS_PRP_FL_ATIVO_OK IN TB_ASS_PRP_PROFISSIONAL_PROD.ASS_PRP_FL_ATIVO_OK%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_PRP_PROFISSIONAL_PROD.SEG_USU_ID_USUARIO%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PRP_PROF_PROC_U
  * 
  *    Data Criacao: 	10/11/2008    Por: Pedro
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Update Status da associação Profissional x Procedimento
  *
  *******************************************************************/  
  begin
    UPDATE TB_ASS_PRP_PROFISSIONAL_PROD 
    SET	   
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE,
        CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO,
        CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL,
        CAD_PRD_ID = pCAD_PRD_ID,
        ASS_PRP_FL_ATIVO_OK = pASS_PRP_FL_ATIVO_OK,
        ASS_PRP_DT_ULTIMA_ATUALIZACAO = sysdate,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
    WHERE
        ASS_PRP_ID = pASS_PRP_ID;	
  end PRC_ASS_PRP_PROF_PROC_U;

/
