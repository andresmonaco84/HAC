  --PRC_CAD_PAC_PACIENTE_RMT_D
  create or replace procedure PRC_CAD_PAC_PACIENTE_RMT_D 
  (
     pCAD_PAC_ID_PACIENTE IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PAC_PACIENTE_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_PAC_PACIENTE
    WHERE  
        CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE;	   
  end PRC_CAD_PAC_PACIENTE_RMT_D;
