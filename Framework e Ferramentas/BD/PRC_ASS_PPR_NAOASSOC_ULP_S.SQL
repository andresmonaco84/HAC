create or replace procedure PRC_ASS_PPR_NAOASSOC_ULP_S
  (
     pAUX_EPP_CD_ESPECPROC IN TB_CAD_PRD_PRODUTO.AUX_EPP_CD_ESPECPROC%TYPE DEFAULT NULL,
     pAUX_GPC_CD_GRUPOPROC IN TB_CAD_PRD_PRODUTO.AUX_GPC_CD_GRUPOPROC%TYPE DEFAULT NULL,
     pCAD_PRD_CD_CODIGO IN TB_CAD_PRD_PRODUTO.CAD_PRD_CD_CODIGO%TYPE DEFAULT NULL,
     pTIS_MED_CD_TABELAMEDICA IN TB_CAD_PRD_PRODUTO.TIS_MED_CD_TABELAMEDICA%TYPE DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULP_UNID_LOCAL_PROCED.CAD_UNI_ID_UNIDADE%TYPE,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULP_UNID_LOCAL_PROCED.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
     pCAD_SET_ID IN TB_ASS_ULP_UNID_LOCAL_PROCED.CAD_SET_ID%TYPE,
     pAGE_SAU_ID IN TB_ASS_ULP_UNID_LOCAL_PROCED.AGE_SAU_ID%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is

  /********************************************************************
  *    Procedure: PRC_ASS_PPR_NAOASSOC_ULP_S
  *
  *    Data Criacao: 	04/01/2008           Por: Fabiola Lopes
  *    Data Alteracao:	data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Lista os produtos que não estao associados a unidade x local x setor x produto(procedimento)
  *
  *******************************************************************/

  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
        SELECT
                PRD.CAD_PRD_ID,
                PRD.CAD_PRD_DS_DESCRICAO,
                prd.cad_prd_cd_codigo,
                PRD.CAD_PRD_CD_GPREXA,
                PRD.SEG_USU_ID_USUARIO,
                PRD.CAD_PRD_DT_ULTIMA_ATUALIZACAO,
                PRD.CAD_PRD_FL_STATUS,
                PRD.CAD_PRD_NM_MNEMONICO,
                PRD.AUX_EPP_CD_ESPECPROC,
                PRD.AUX_GPC_CD_GRUPOPROC,
                PRD.CAD_PRD_DS_RESUMIDA,
                PRD.CAD_PRD_TP_PRODUTO,
                PRD.TIS_MED_CD_TABELAMEDICA,
                PRD.CAD_PRD_FL_UTILIZAAGEND_OK
          FROM
                TB_CAD_PRD_PRODUTO PRD
         WHERE NOT EXISTS(
                  SELECT  1
                    FROM  TB_ASS_ULP_UNID_LOCAL_PROCED ULP
                   WHERE  (pAUX_EPP_CD_ESPECPROC IS NULL OR ULP.AUX_EPP_CD_ESPECPROCED = pAUX_EPP_CD_ESPECPROC)
                     AND  (pAUX_GPC_CD_GRUPOPROC IS NULL OR ULP.AUX_GPC_CD_GRUPOPROC = pAUX_GPC_CD_GRUPOPROC)
                     AND  (pCAD_PRD_CD_CODIGO IS NULL OR ULP.CAD_PRD_CD_CODIGO = pCAD_PRD_CD_CODIGO)
                     AND  (ULP.CAD_PRD_CD_CODIGO = PRD.CAD_PRD_CD_CODIGO)
                     AND  ULP.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
                     AND  ULP.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
                     AND  ULP.CAD_SET_ID = pCAD_SET_ID
                     AND  (pAGE_SAU_ID IS NULL OR ULP.AGE_SAU_ID = pAGE_SAU_ID))
         AND    (pAUX_EPP_CD_ESPECPROC IS NULL OR PRD.AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC)
         AND    (pAUX_GPC_CD_GRUPOPROC IS NULL OR PRD.AUX_GPC_CD_GRUPOPROC = pAUX_GPC_CD_GRUPOPROC)
         AND    (pCAD_PRD_CD_CODIGO IS NULL OR PRD.CAD_PRD_CD_CODIGO = pCAD_PRD_CD_CODIGO)
         AND    (pTIS_MED_CD_TABELAMEDICA IS NULL OR TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA)
         ORDER BY PRD.CAD_PRD_DS_DESCRICAO;

    io_cursor := v_cursor;
end PRC_ASS_PPR_NAOASSOC_ULP_S;
