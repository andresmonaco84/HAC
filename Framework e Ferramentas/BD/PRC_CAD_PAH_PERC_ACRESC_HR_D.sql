  --PRC_CAD_PAH_PERC_ACRESCIMO_HR_D
  create or replace procedure PRC_CAD_PAH_PERC_ACRESC_HR_D 
  (
     pCAD_PAH_ID IN TB_CAD_PAH_PERC_ACRESCIMO_HR.CAD_PAH_ID%type  
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PAH_PERC_ACRESC_HR_D
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_PAH_PERC_ACRESCIMO_HR
    WHERE  
        CAD_PAH_ID = pCAD_PAH_ID;     
  end PRC_CAD_PAH_PERC_ACRESC_HR_D;

