 create or replace procedure PRC_CAD_TIH_TP_INDICE_HOSP_D 
  (
     pCAD_TIH_TP_INDICE_HOSP IN TB_CAD_TIH_TP_INDICE_HOSP.CAD_TIH_TP_INDICE_HOSP%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TIH_TP_INDICE_HOSP_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_TIH_TP_INDICE_HOSP
    WHERE  
        CAD_TIH_TP_INDICE_HOSP = pCAD_TIH_TP_INDICE_HOSP;	   
  end PRC_CAD_TIH_TP_INDICE_HOSP_D;
