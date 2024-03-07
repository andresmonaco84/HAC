
   --PRC_CAD_SETOR_D
  create or replace procedure PRC_CAD_SETOR_RMT_D 
  (
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%type  
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_SETOR_RMT_D   --CADASTRO REMOTING
  * 
  *    Data Criacao:   20/07/09   Por: pEDRO
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_SET_SETOR
    WHERE  
        CAD_SET_ID = pCAD_SET_ID;     
  end PRC_CAD_SETOR_RMT_D;
