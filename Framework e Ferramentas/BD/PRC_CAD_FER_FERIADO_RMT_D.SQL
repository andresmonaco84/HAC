

--PRC_CAD_FER_FERIADO_RMT_D
create or replace procedure PRC_CAD_FER_FERIADO_RMT_D 
(
     pCAD_FER_ID_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_ID_FERIADO%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_FER_FERIADO_RMT_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_FER_FERIADO
WHERE  
        CAD_FER_ID_FERIADO = pCAD_FER_ID_FERIADO;	   
end PRC_CAD_FER_FERIADO_RMT_D;
