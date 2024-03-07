
--PRC_ASS_ULS_UNID_LOC_SET_USU_R_D
create or replace procedure PRC_ASS_ULS_UN_LO_SE_USU_R_D 
(
     pASS_ULS_ID IN TB_ASS_ULS_UNID_LOC_SET_USU.ASS_ULS_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_ULS_UNID_LOC_SET_USU_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_ULS_UNID_LOC_SET_USU
WHERE  
        ASS_ULS_ID = pASS_ULS_ID;	   
end PRC_ASS_ULS_UN_LO_SE_USU_R_D;
