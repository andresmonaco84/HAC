 create or replace procedure PRC_CAD_VMH_VALOR_MOEDA_HOSP_D 
  (
     pCAD_TIH_TP_INDICE_HOSP IN TB_CAD_VMH_VALOR_MOEDA_HOSP.CAD_TIH_TP_INDICE_HOSP%type,
     pCAD_VMH_DT_INICIO_VIGENCIA IN TB_CAD_VMH_VALOR_MOEDA_HOSP.CAD_VMH_DT_INICIO_VIGENCIA%type,
     pCAD_VMH_VL_MOEDA_HOSPITALAR IN TB_CAD_VMH_VALOR_MOEDA_HOSP.CAD_VMH_VL_MOEDA_HOSPITALAR%type,
     pCAD_VMH_TP_MOEDA IN TB_CAD_VMH_VALOR_MOEDA_HOSP.CAD_VMH_TP_MOEDA%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_VMH_VALOR_MOEDA_HOSP_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
  
    DELETE TB_CAD_VMH_VALOR_MOEDA_HOSP
    WHERE  
        CAD_TIH_TP_INDICE_HOSP = pCAD_TIH_TP_INDICE_HOSP
    AND CAD_VMH_DT_INICIO_VIGENCIA = pCAD_VMH_DT_INICIO_VIGENCIA
    AND CAD_VMH_VL_MOEDA_HOSPITALAR = pCAD_VMH_VL_MOEDA_HOSPITALAR
    AND CAD_VMH_TP_MOEDA = pCAD_VMH_TP_MOEDA;
    
  end PRC_CAD_VMH_VALOR_MOEDA_HOSP_D;

