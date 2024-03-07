create or replace procedure PRC_CAD_TPACOMOD_ACS_S
  (
     pCAD_TAA_CD_TP_ACOMODACAO_ACS IN TB_CAD_TAA_TIPO_ACOMODACAO_ACS.CAD_TAA_CD_TIPO_ACOMODACAO_ACS%type DEFAULT NULL,
     pCAD_TAA_DS_TP_ACOMODACAO_ACS IN TB_CAD_TAA_TIPO_ACOMODACAO_ACS.CAD_TAA_DS_TIPO_ACOMODACAO_ACS%type DEFAULT NULL,
     pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_CAD_TAA_TIPO_ACOMODACAO_ACS.TIS_TAC_CD_TIPO_ACOMODACAO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TPACOMOD_ACS_S
  *
  *    Data Criacao:  data da  criac?o   Por: Nome do Analista
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CAD_TAA_CD_TIPO_ACOMODACAO_ACS,
       CAD_TAA_DS_TIPO_ACOMODACAO_ACS,
       TIS_TAC_CD_TIPO_ACOMODACAO,
       CAD_UNI_ID_UNIDADE
    FROM TB_CAD_TAA_TIPO_ACOMODACAO_ACS
    WHERE
        (pCAD_TAA_CD_TP_ACOMODACAO_ACS is null OR CAD_TAA_CD_TIPO_ACOMODACAO_ACS = pCAD_TAA_CD_TP_ACOMODACAO_ACS) AND
        (pCAD_TAA_DS_TP_ACOMODACAO_ACS is null OR CAD_TAA_DS_TIPO_ACOMODACAO_ACS = pCAD_TAA_DS_TP_ACOMODACAO_ACS) AND
        (pTIS_TAC_CD_TIPO_ACOMODACAO is null OR TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO);
    io_cursor := v_cursor;
  end PRC_CAD_TPACOMOD_ACS_S;
