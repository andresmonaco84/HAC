create or replace procedure PRC_ATD_IMS_INT_MOV_SETOR_D 
(
     pATD_IMS_ID IN TB_ATD_IMS_INT_MOV_SETOR.ATD_IMS_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ATD_IMS_INT_MOV_SETOR_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ATD_IMS_INT_MOV_SETOR
WHERE  
        ATD_IMS_ID = pATD_IMS_ID;	   
end PRC_ATD_IMS_INT_MOV_SETOR_D;