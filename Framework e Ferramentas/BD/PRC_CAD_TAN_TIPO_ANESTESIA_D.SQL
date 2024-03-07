

--PRC_CAD_TAN_TIPO_ANESTESIA_D
create or replace procedure PRC_CAD_TAN_TIPO_ANESTESIA_D 
(
     pCAD_TAN_TP_ANESTESIA IN TB_CAD_TAN_TIPO_ANESTESIA.CAD_TAN_TP_ANESTESIA%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_TAN_TIPO_ANESTESIA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_TAN_TIPO_ANESTESIA
WHERE  
        CAD_TAN_TP_ANESTESIA = pCAD_TAN_TP_ANESTESIA;	   
end PRC_CAD_TAN_TIPO_ANESTESIA_D;
