create or replace procedure PRC_TIS_TSC_TIPOSAIDACONS_U
  (
     pTIS_TSC_CD_TIPOSAIDACONSULTA IN TB_TIS_TSC_TIPOSAIDACONSULTA.TIS_TSC_CD_TIPOSAIDACONSULTA%type,
     pTIS_TSC_DS_TIPOSAIDACONSULTA IN TB_TIS_TSC_TIPOSAIDACONSULTA.TIS_TSC_DS_TIPOSAIDACONSULTA%type,
     pTIS_TSC_FL_STATUS            IN TB_TIS_TSC_TIPOSAIDACONSULTA.TIS_TSC_FL_STATUS%type,
     pSEG_USU_ID_USUARIO           IN TB_TIS_TSC_TIPOSAIDACONSULTA.SEG_USU_ID_USUARIO_CRIACAO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TSC_TIPOSAIDACONS_U
  *
  *    Data Criacao:  12/04/2207   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 02/05/2007   Por: Cristiane Gomes da Silva
  *    Data Alteração: 28/05/2007   Por: Silmara
  *    Alteração:Foi alterado os parâmetros para gravar em maiúsculo
  *    Funcao: Altera Tipo de Saída para Consulta - TISS
  *
  *******************************************************************/
  begin
    UPDATE TB_TIS_TSC_TIPOSAIDACONSULTA
    SET
        TIS_TSC_DS_TIPOSAIDACONSULTA = UPPER(pTIS_TSC_DS_TIPOSAIDACONSULTA),
        TIS_TSC_FL_STATUS = pTIS_TSC_FL_STATUS,
        TIS_TSC_DT_ULT_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USU_ULT_ATUALIZ = pSEG_USU_ID_USUARIO
    WHERE
        TIS_TSC_CD_TIPOSAIDACONSULTA = pTIS_TSC_CD_TIPOSAIDACONSULTA;
  end PRC_TIS_TSC_TIPOSAIDACONS_U;
 