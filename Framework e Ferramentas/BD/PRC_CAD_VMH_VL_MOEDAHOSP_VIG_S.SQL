
create or replace procedure PRC_CAD_VMH_VL_MOEDAHOSP_VIG_S
  (
     pCAD_TIH_TP_INDICE_HOSP IN TB_CAD_VMH_VALOR_MOEDA_HOSP.CAD_TIH_TP_INDICE_HOSP%type,
     pCAD_VMH_TP_MOEDA IN TB_CAD_VMH_VALOR_MOEDA_HOSP.CAD_VMH_TP_MOEDA%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_VMH_VL_MOEDAHOSP_VIG_S
  *
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CAD_TIH_TP_INDICE_HOSP,
       CAD_VMH_VL_MOEDA_HOSPITALAR,
       CAD_VMH_DT_INICIO_VIGENCIA,
       CAD_VMH_DT_FIM_VIGENCIA,
       CAD_VMH_TP_MOEDA,
       CAD_VMH_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
  FROM TB_CAD_VMH_VALOR_MOEDA_HOSP
 WHERE CAD_TIH_TP_INDICE_HOSP = pCAD_TIH_TP_INDICE_HOSP
   AND
       (
         TRUNC(CAD_VMH_DT_INICIO_VIGENCIA) <= trunc(SYSDATE) AND TRUNC(CAD_VMH_DT_FIM_VIGENCIA) >= trunc(sysdate)
    OR
         TRUNC(CAD_VMH_DT_INICIO_VIGENCIA) <= TRUNC(SYSDATE) AND TRUNC(CAD_VMH_DT_FIM_VIGENCIA) IS NULL
       )
    AND CAD_VMH_TP_MOEDA = pCAD_VMH_TP_MOEDA;
    io_cursor := v_cursor;
  end PRC_CAD_VMH_VL_MOEDAHOSP_VIG_S;