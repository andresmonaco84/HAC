

--PRC_FAT_TCS_COMANDA_SET_CC_D
create or replace procedure PRC_FAT_TCS_COMANDA_SET_CC_D 
(
     pCAD_SET_ID IN TB_FAT_TCS_COMANDA_SET_CC.CAD_SET_ID%type,
     pFAT_TCO_ID IN TB_FAT_TCS_COMANDA_SET_CC.FAT_TCO_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_TCS_COMANDA_SET_CC_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_FAT_TCS_COMANDA_SET_CC
WHERE  
        CAD_SET_ID = pCAD_SET_ID
    AND FAT_TCO_ID = pFAT_TCO_ID;	   
end PRC_FAT_TCS_COMANDA_SET_CC_D;
