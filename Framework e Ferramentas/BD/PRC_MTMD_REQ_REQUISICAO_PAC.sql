CREATE OR REPLACE PROCEDURE "PRC_MTMD_REQ_REQUISICAO_PAC"
  (
     pATD_ATE_ID          IN TB_MTMD_REQ_REQUISICAO.ATD_ATE_ID%type default NULL,
     pATD_ATE_TP_PACIENTE IN TB_MTMD_REQ_REQUISICAO.ATD_ATE_TP_PACIENTE%type default NULL,
     pCAD_SET_ID          IN TB_MTMD_REQ_REQUISICAO.CAD_SET_ID%type,
     io_cursor            OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Funcao: Busca por requisicoes para uma internacao fornecida pelo operador
  *				SOMENTE REQUISICOES EM ABERTO: STATUS: 0= FECHADA 1=ABERTA 2=ATENDIDA PELO ALMOX
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       REQUISICAO.MTMD_REQ_ID,
       REQUISICAO.ATD_ATE_ID,
       REQUISICAO.ATD_ATE_TP_PACIENTE,
       REQUISICAO.MTMD_REQ_FL_STATUS,
       REQUISICAO.MTMD_REQ_DT_ATUALIZACAO,
       REQUISICAO.MTM_TIPO_REQUISICAO,
       REQUISICAO.CAD_MTMD_KIT_ID,
       SETOR.CAD_SET_DS_SETOR,
       UNIDADE.CAD_UNI_DS_UNIDADE,
       LOC.CAD_LAT_DS_LOCAL_ATENDIMENTO,
       USU_REQUISICAO.SEG_USU_DS_NOME DS_USUARIO_REQUISICAO,
       USU_DISPENSACAO.SEG_USU_DS_NOME DS_USUARIO_DISPENSACAO,
       REQUISICAO.MTMD_REQ_FL_URGENCIA,
       REQUISICAO.CAD_SET_SETOR_FARMACIA
    FROM TB_MTMD_REQ_REQUISICAO       REQUISICAO,
         TB_CAD_SET_SETOR             SETOR,
         TB_CAD_UNI_UNIDADE           UNIDADE,
         TB_CAD_LAT_LOCAL_ATENDIMENTO LOC,
         TB_SEG_USU_USUARIO           USU_REQUISICAO,
         TB_SEG_USU_USUARIO           USU_DISPENSACAO
    WHERE REQUISICAO.ATD_ATE_ID              = pATD_ATE_ID
    --AND   REQUISICAO.ATD_ATE_TP_PACIENTE     = pATD_ATE_TP_PACIENTE
    AND  REQUISICAO.CAD_SET_ID               = pCAD_SET_ID
    AND  REQUISICAO.MTMD_REQ_FL_STATUS       = 1 -- ABERTA
    AND  REQUISICAO.MTMD_FL_PENDENTE         = 0
    AND  SETOR.CAD_SET_ID                    = REQUISICAO.CAD_SET_ID
    AND  UNIDADE.CAD_UNI_ID_UNIDADE          = REQUISICAO.CAD_UNI_ID_UNIDADE
    AND  LOC.CAD_LAT_ID_LOCAL_ATENDIMENTO    = REQUISICAO.CAD_LAT_ID_LOCAL_ATENDIMENTO
    AND   USU_REQUISICAO.SEG_USU_ID_USUARIO  (+)= REQUISICAO.MTMD_ID_USUARIO_REQUISICAO
    AND   USU_DISPENSACAO.SEG_USU_ID_USUARIO (+)= REQUISICAO.MTMD_ID_USUARIO_DISPENSACAO;

    io_cursor := v_cursor;
  end PRC_MTMD_REQ_REQUISICAO_PAC;