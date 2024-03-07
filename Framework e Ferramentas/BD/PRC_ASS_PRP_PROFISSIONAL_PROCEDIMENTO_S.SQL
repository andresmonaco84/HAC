  -- PRC_ASS_PRP_PROF_PROC_S
  create or replace procedure PRC_ASS_PRP_PROF_PROC_S 
  (
     pASS_PRP_ID IN TB_ASS_PRP_PROFISSIONAL_PROD.ASS_PRP_ID%type default NULL,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_PRO_ID_PROFISSIONAL%type default NULL,
     pCAD_PRD_ID IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_PRD_ID%type default NULL, 
     pASS_PRP_FL_ATIVO_OK IN TB_ASS_PRP_PROFISSIONAL_PROD.ASS_PRP_FL_ATIVO_OK%type default NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /**********************************************************************
  *    Procedure: PRC_ASS_PRP_PROF_PROC_S
  * 
  *    Data Criacao: 	18/08/2008           Por: Davi Silvestre M. dos Reis
  *    Data Alteracao:	                   Por: 
  *
  *    Funcao: Pesquisa de registros na tabela TB_ASS_PRP_PROFISSIONAL_PROD
  *
  ***********************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  
  begin
    OPEN v_cursor FOR
    SELECT
       PRP.ASS_PRP_ID,
       PRP.CAD_PRO_ID_PROFISSIONAL,
       PRP.CAD_PRD_ID,
       PRP.ASS_PRP_FL_ATIVO_OK,
       PRP.SEG_USU_ID_USUARIO,
       PRP.ASS_PRP_DT_ULTIMA_ATUALIZACAO
    FROM TB_ASS_PRP_PROFISSIONAL_PROD PRP
    WHERE
          (pASS_PRP_ID is null OR PRP.ASS_PRP_ID = pASS_PRP_ID)
      AND (pCAD_PRO_ID_PROFISSIONAL is null OR PRP.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL)
      AND (pCAD_PRD_ID is null OR PRP.CAD_PRD_ID = pCAD_PRD_ID)
      AND (pASS_PRP_FL_ATIVO_OK is null OR PRP.ASS_PRP_FL_ATIVO_OK = pASS_PRP_FL_ATIVO_OK);
    
    io_cursor := v_cursor;
    
end PRC_ASS_PRP_PROF_PROC_S;
/
