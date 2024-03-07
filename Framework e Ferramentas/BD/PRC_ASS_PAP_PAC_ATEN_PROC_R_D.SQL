

--PRC_ASS_PAP_PAC_ATEN_PROC_R_D
create or replace procedure PRC_ASS_PAP_PAC_ATEN_PROC_R_D 
(
     pASS_PAP_ID IN TB_ASS_PAP_PAC_ATEN_PROC.ASS_PAP_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_PAP_PAC_ATEN_PROC_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_PAP_PAC_ATEN_PROC
WHERE  
        ASS_PAP_ID = pASS_PAP_ID;	   
end PRC_ASS_PAP_PAC_ATEN_PROC_R_D;
