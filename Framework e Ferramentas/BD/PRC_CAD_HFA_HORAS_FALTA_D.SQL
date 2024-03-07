

--PRC_CAD_HFA_HORAS_FALTA_D
create or replace procedure PRC_CAD_HFA_HORAS_FALTA_D 
(
     pCAD_HFA_ID IN TB_CAD_HFA_HORAS_FALTA.CAD_HFA_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_HFA_HORAS_FALTA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_HFA_HORAS_FALTA
WHERE  
        CAD_HFA_ID = pCAD_HFA_ID;	   
end PRC_CAD_HFA_HORAS_FALTA_D;
