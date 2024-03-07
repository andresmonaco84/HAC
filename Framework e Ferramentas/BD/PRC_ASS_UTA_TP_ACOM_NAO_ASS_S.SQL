CREATE OR REPLACE PROCEDURE "PRC_ASS_UTA_TP_ACOM_NAO_ASS_S"
  (
     pCAD_UNI_ID_UNIDADE IN TB_ASS_UTA_UNID_TPACOMOD.CAD_UNI_ID_UNIDADE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UTA_TP_ACOM_NAO_ASS_S
  *
  *    Data Criacao: 	21/06/2007   Por: Ricardo Costa
  *    Data Alteracao:    Por:
  *
  *    Funcao: Obtem Tipo(s) de Acomodac?o(?es) NAO ASSOCIADOS A UNIDADE
  *
  *    Data Alteração:  Por:  Andréa Cazuca
  *    Alteração:  Inclusão dos campos TIS_TAC_PC_ACOMODACAO_HM, TIS_TAC_DT_ULTIMA_ATUALIZACAO, SEG_USU_ID_USUARIO
  *                TIS_TAC_FL_PERM_DIF_CLASSE, TIS_TAC_FL_UTILIZA_REPASSE, TIS_TAC_FL_STATUS
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS.TIS_TAC_CD_TIPO_ACOMODACAO,
       TIS.TIS_TAC_DS_TIPO_ACOMODACAO,
       TIS.TIS_TAC_PC_ACOMODACAO_HM,
       TIS.TIS_TAC_DT_ULTIMA_ATUALIZACAO,
       TIS.SEG_USU_ID_USUARIO,
       TIS.TIS_TAC_FL_PERM_DIF_CLASSE,
       TIS.TIS_TAC_FL_UTILIZA_REPASSE,
       TIS.TIS_TAC_FL_STATUS
    FROM TB_TIS_TAC_TIPO_ACOMODACAO TIS
    WHERE TIS_TAC_CD_TIPO_ACOMODACAO NOT IN
                     ( SELECT TIS_TAC_CD_TIPO_ACOMODACAO
                       FROM TB_ASS_UTA_UNID_TPACOMOD
                       WHERE CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
                       AND  ASS_UTA_FL_ATIVO_OK = 'S' )
    ORDER BY TIS_TAC_DS_TIPO_ACOMODACAO;
    io_cursor := v_cursor;
  end PRC_ASS_UTA_TP_ACOM_NAO_ASS_S;
 