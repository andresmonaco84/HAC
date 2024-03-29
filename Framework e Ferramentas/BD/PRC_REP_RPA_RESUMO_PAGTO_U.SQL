create or replace procedure PRC_REP_RPA_RESUMO_PAGTO_U
(
     pREP_RPA_ID IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ID%type,
     pCAD_CLC_ID IN TB_REP_RPA_RESUMO_PAGTO.CAD_CLC_ID%type default NULL,
     pREP_RPA_DT_PAGAMENTO IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_DT_PAGAMENTO%type default NULL,
     pREP_RPA_MES_PAGTO IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_MES_PAGTO%type default NULL,
     pREP_RPA_ANO_PAGTO IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ANO_PAGTO%type default NULL,
     pREP_RPA_TP_CREDENCIA_PROF IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_TP_CREDENCIA_PROF%type default NULL,
     pREP_RPA_VL_PAGTO_CLINICA IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_VL_PAGTO_CLINICA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_REP_RPA_RESUMO_PAGTO.SEG_USU_ID_USUARIO%type default NULL,
     pREP_RPA_DT_ULTIMA_ATUALIZACAO IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_DT_ULTIMA_ATUALIZACAO%type default NULL,
     pREP_RPA_DT_CRIACAO IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_DT_CRIACAO%type default NULL,
     pSEG_USU_ID_USUARIO_CRIACAO IN TB_REP_RPA_RESUMO_PAGTO.SEG_USU_ID_USUARIO_CRIACAO%type default NULL,
     pREP_RPA_VL_DESCONTO IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_VL_DESCONTO%type default NULL,
     pCAD_UNI_ID_UNIDADE IN TB_REP_RPA_RESUMO_PAGTO.CAD_UNI_ID_UNIDADE%type default NULL,
     pREP_RPA_VL_ACRESCIMO IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_VL_ACRESCIMO%type default NULL,
     pREP_RPA_DT_INICIO IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_DT_INICIO%type default NULL,
     pREP_RPA_DT_FIM IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_DT_FIM%type default NULL,
     pID_CAD_JPG IN TB_REP_RPA_RESUMO_PAGTO.ID_CAD_JPG%type default NULL,
     pREP_PRA_VL_IMPOSTO IN TB_REP_RPA_RESUMO_PAGTO.REP_PRA_VL_IMPOSTO%type default NULL,
     pREP_RPA_FL_STATUS IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_FL_STATUS%type default NULL,
     pREP_RPA_FONTE_PAGADORA IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_FONTE_PAGADORA%type default NULL,
     pCAD_UNI_ID_UNIDADE_ATEND IN TB_REP_RPA_RESUMO_PAGTO.CAD_UNI_ID_UNIDADE_ATEND%type DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATEND IN TB_REP_RPA_RESUMO_PAGTO.CAD_LAT_ID_LOCAL_ATEND%type DEFAULT NULL,
     pREP_RPA_FL_ANTECIPACAO IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_FL_ANTECIPACAO%TYPE DEFAULT NULL
)
is
/********************************************************************
*    Procedure: PRC_REP_RPA_RESUMO_PAGTO_U
*
*    Data Criacao:   data da  cria��o   Por: Nome do Analista
*    Data Alteracao:  data da altera��o  Por: Nome do Analista
*
*    Funcao: Descri��o da funcionalidade da Stored Procedure
*
*******************************************************************/
begin
UPDATE TB_REP_RPA_RESUMO_PAGTO
SET
        CAD_CLC_ID = pCAD_CLC_ID,
        REP_RPA_DT_PAGAMENTO = pREP_RPA_DT_PAGAMENTO,
        REP_RPA_MES_PAGTO = pREP_RPA_MES_PAGTO,
        REP_RPA_ANO_PAGTO = pREP_RPA_ANO_PAGTO,
        REP_RPA_TP_CREDENCIA_PROF = pREP_RPA_TP_CREDENCIA_PROF,
        REP_RPA_VL_PAGTO_CLINICA = pREP_RPA_VL_PAGTO_CLINICA,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        REP_RPA_DT_ULTIMA_ATUALIZACAO = pREP_RPA_DT_ULTIMA_ATUALIZACAO,
        REP_RPA_DT_CRIACAO = pREP_RPA_DT_CRIACAO,
        SEG_USU_ID_USUARIO_CRIACAO = pSEG_USU_ID_USUARIO_CRIACAO,
        REP_RPA_VL_DESCONTO = pREP_RPA_VL_DESCONTO,
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE,
        REP_RPA_VL_ACRESCIMO = pREP_RPA_VL_ACRESCIMO,
        REP_RPA_DT_INICIO = pREP_RPA_DT_INICIO,
        REP_RPA_DT_FIM = pREP_RPA_DT_FIM,
        ID_CAD_JPG = pID_CAD_JPG,
        REP_PRA_VL_IMPOSTO = pREP_PRA_VL_IMPOSTO,
        REP_RPA_FL_STATUS = pREP_RPA_FL_STATUS,
        REP_RPA_FONTE_PAGADORA = pREP_RPA_FONTE_PAGADORA,
        CAD_UNI_ID_UNIDADE_ATEND = pCAD_UNI_ID_UNIDADE_ATEND,
        CAD_LAT_ID_LOCAL_ATEND = pCAD_LAT_ID_LOCAL_ATEND,
        REP_RPA_FL_ANTECIPACAO = pREP_RPA_FL_ANTECIPACAO
WHERE
        REP_RPA_ID = pREP_RPA_ID;
end PRC_REP_RPA_RESUMO_PAGTO_U;
