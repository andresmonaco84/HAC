--PRC_ASS_TCP_TAB_CNV_PORTANES_D
create or replace procedure PRC_ASS_TCP_TAB_CNV_PORTANES_D
(
     pASS_TCP_ID IN TB_ASS_TCP_TAB_CNV_PORTE_ANES.ASS_TCP_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_TCP_TAB_CNV_PORTANES_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_TCP_TAB_CNV_PORTE_ANES
WHERE  
        ASS_TCP_ID = pASS_TCP_ID;	   
end PRC_ASS_TCP_TAB_CNV_PORTANES_D;