

--PRC_CAD_IPA_ITEM_PACOTE_D
create or replace procedure PRC_CAD_IPA_ITEM_PACOTE_D 
(
     pCAD_IPA_ID IN TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_IPA_ITEM_PACOTE_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_IPA_ITEM_PACOTE
WHERE  
        CAD_IPA_ID = pCAD_IPA_ID;	   
end PRC_CAD_IPA_ITEM_PACOTE_D;
