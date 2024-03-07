create or replace procedure PRC_CAD_AUT_AUTORIZADOR_D
(
     pCAD_AUT_ID IN TB_CAD_AUT_AUTORIZADOR.CAD_AUT_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_AUT_AUTORIZADOR_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_AUT_AUTORIZADOR
WHERE  
        CAD_AUT_ID = pCAD_AUT_ID;	   
end PRC_CAD_AUT_AUTORIZADOR_D;
/
