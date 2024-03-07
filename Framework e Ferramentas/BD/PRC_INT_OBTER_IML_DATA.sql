create or replace procedure PRC_INT_OBTER_IML_DATA
  (
     pATD_ATE_ID            IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
     pDATA_MOVIMENTACAO      IN DATE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_OBTER_IML_DATA
  *
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Retorna o IML de acordo com o DateTime/Atendimento
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR    
    
 SELECT ATD_ATE_ID,
        ATD_IML_DT_ENTRADA,
        ATD_IML_HR_ENTRADA,
        ATD_IML_DT_SAIDA,
        ATD_IML_HR_SAIDA,
        CAD_CAD_QLE_ID,
        ATD_IML_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO,
        CAD_PAC_ID_PACIENTE,
        TIS_TAC_CD_TIPO_ACOMODACAO,
        ATD_IML_FL_STATUS,
        ATD_IML_FL_CORTESIA,
        ATD_IML_FL_DIF_CLASSE,
        ATD_IML_ID
   FROM TB_ATD_IML_INT_MOV_LEITO IML
  WHERE IML.ATD_ATE_ID = pATD_ATE_ID
    AND FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA, IML.ATD_IML_HR_ENTRADA) <=
        pDATA_MOVIMENTACAO
    AND (FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_SAIDA, IML.ATD_IML_HR_SAIDA) >
        pDATA_MOVIMENTACAO OR (IML.ATD_IML_DT_SAIDA IS NULL));

    io_cursor := v_cursor;
  end PRC_INT_OBTER_IML_DATA;