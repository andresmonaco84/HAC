--PRC_CAD_JPG_JUSTIFICA_PAGTO_D
create or replace procedure PRC_CAD_JPG_JUSTIFICA_PAGTO_D 
(
     pID_CAD_JPG IN TB_CAD_JPG_JUSTIFICA_PAGTO.ID_CAD_JPG%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_JPG_JUSTIFICA_PAGTO_D
* 
*    Data Criacao: 	  28/02/2012         Por: Fabíola Lopes
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Exclusão das Justificativas de Pagamento
*
*******************************************************************/  
begin
DELETE TB_CAD_JPG_JUSTIFICA_PAGTO
WHERE  
        ID_CAD_JPG = pID_CAD_JPG;	   
end PRC_CAD_JPG_JUSTIFICA_PAGTO_D;