

--PRC_ASS_ARE_ATD_RESPONSAVEL_D
create or replace procedure PRC_ASS_ARE_ATD_RESPONSAVEL_D 
(
     pATD_ATE_ID IN TB_ASS_ARE_ATD_RESPONSAVEL.ATD_ATE_ID%type,
     pCAD_PES_ID_PESSOA IN TB_ASS_ARE_ATD_RESPONSAVEL.CAD_PES_ID_PESSOA%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_ARE_ATD_RESPONSAVEL_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_ARE_ATD_RESPONSAVEL
WHERE  
        ATD_ATE_ID = pATD_ATE_ID
    AND CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA;	   
end PRC_ASS_ARE_ATD_RESPONSAVEL_D;
