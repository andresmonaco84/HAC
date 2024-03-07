

--PRC_CAD_GRP_GRADUACAO_PROF_D
create or replace procedure PRC_CAD_GRP_GRADUACAO_PROF_D 
(
     pCAD_GRP_ID IN TB_CAD_GRP_GRADUACAO_PROF.CAD_GRP_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_GRP_GRADUACAO_PROF_D
* 
*    Data Criacao: 	15/07/2010   Por: André Souza Monaco
*    Data Alteracao:	  Por: 
*
*    Funcao: Exclui graduação do profissional
*
*******************************************************************/    
begin
DELETE TB_CAD_GRP_GRADUACAO_PROF
WHERE  
        CAD_GRP_ID = pCAD_GRP_ID;	   
end PRC_CAD_GRP_GRADUACAO_PROF_D;
