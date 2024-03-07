  --PRC_CAD_MAA_MOTI_ALT_AUDIT_D
  create or replace procedure PRC_CAD_MAA_MOTI_ALT_AUDIT_D 
  (
     pCAD_MAA_ID IN TB_CAD_MAA_MOTI_ALTERA_AUDIT.CAD_MAA_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MAA_MOTI_ALT_AUDIT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_MAA_MOTI_ALTERA_AUDIT
    WHERE  
        CAD_MAA_ID = pCAD_MAA_ID;	   
  end PRC_CAD_MAA_MOTI_ALT_AUDIT_D;