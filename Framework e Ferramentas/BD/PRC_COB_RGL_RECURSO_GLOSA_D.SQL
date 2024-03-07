

--PRC_COB_RGL_RECURSO_GLOSA_D
create or replace procedure PRC_COB_RGL_RECURSO_GLOSA_D 
(
     pCOB_RGL_NR_PROTOC_RECURSO IN TB_COB_RGL_RECURSO_GLOSA.COB_RGL_NR_PROTOC_RECURSO%type	
)
is
/********************************************************************
*    Procedure: PRC_COB_RGL_RECURSO_GLOSA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_COB_RGL_RECURSO_GLOSA
WHERE  
        COB_RGL_NR_PROTOC_RECURSO = pCOB_RGL_NR_PROTOC_RECURSO;	   
end PRC_COB_RGL_RECURSO_GLOSA_D;
