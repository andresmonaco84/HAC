 create or replace procedure PRC_CAD_VMH_VALOR_MOEDA_HOSP_U
  (
     pCAD_TIH_TP_INDICE_HOSP IN TB_CAD_VMH_VALOR_MOEDA_HOSP.CAD_TIH_TP_INDICE_HOSP%type,
     pCAD_VMH_VL_MOEDA_HOSPITALAR IN TB_CAD_VMH_VALOR_MOEDA_HOSP.CAD_VMH_VL_MOEDA_HOSPITALAR%type,
     pCAD_VMH_DT_INICIO_VIGENCIA IN TB_CAD_VMH_VALOR_MOEDA_HOSP.CAD_VMH_DT_INICIO_VIGENCIA%type,
     pCAD_VMH_DT_FIM_VIGENCIA IN TB_CAD_VMH_VALOR_MOEDA_HOSP.CAD_VMH_DT_FIM_VIGENCIA%type default NULL,
     pCAD_VMH_TP_MOEDA IN TB_CAD_VMH_VALOR_MOEDA_HOSP.CAD_VMH_TP_MOEDA%type default NULL,     
     pSEG_USU_ID_USUARIO IN TB_CAD_VMH_VALOR_MOEDA_HOSP.SEG_USU_ID_USUARIO%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_VMH_VALOR_MOEDA_HOSP_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_VMH_VALOR_MOEDA_HOSP
    SET	   
        CAD_VMH_DT_FIM_VIGENCIA = pCAD_VMH_DT_FIM_VIGENCIA,        
        CAD_VMH_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
    WHERE
        CAD_TIH_TP_INDICE_HOSP = pCAD_TIH_TP_INDICE_HOSP
    AND CAD_VMH_DT_INICIO_VIGENCIA = pCAD_VMH_DT_INICIO_VIGENCIA
    AND CAD_VMH_VL_MOEDA_HOSPITALAR = pCAD_VMH_VL_MOEDA_HOSPITALAR
    AND CAD_VMH_TP_MOEDA = pCAD_VMH_TP_MOEDA;	
  end PRC_CAD_VMH_VALOR_MOEDA_HOSP_U;

