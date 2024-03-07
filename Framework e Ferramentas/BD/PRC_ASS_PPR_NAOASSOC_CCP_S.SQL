create or replace procedure PRC_ASS_PPR_NAOASSOC_CCP_S
  (
     pAUX_EEP_CD_ESPECPROCED IN TB_CAD_PRD_PRODUTO.AUX_EPP_CD_ESPECPROC%TYPE DEFAULT NULL,
     pAUX_GPC_CD_GRUPOPROCED IN TB_CAD_PRD_PRODUTO.AUX_GPC_CD_GRUPOPROC%TYPE DEFAULT NULL,
     pCAD_PRD_CD_CODIGO IN TB_CAD_PRD_PRODUTO.CAD_PRD_CD_CODIGO%TYPE DEFAULT NULL,
     pTIS_MED_CD_TABELAMEDICA IN TB_CAD_PRD_PRODUTO.TIS_MED_CD_TABELAMEDICA%TYPE DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CCP_CONV_CLINICA_PROCED.CAD_CNV_ID_CONVENIO%TYPE,
     pCAD_CLC_ID IN TB_ASS_CCP_CONV_CLINICA_PROCED.CAD_CLC_ID%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PPR_NAOASSOC_CCP_S
  *
  *    Data Criacao: 	25/01/2008           Por: Fabiola Lopes
  *    Data Alteracao:	data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Lista os produtos que não estao associados a convenio x clinca
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
         SELECT
                PRD.CAD_PRD_ID,
                PRD.CAD_PRD_DS_DESCRICAO,
                PRD.CAD_PRD_CD_CODIGO,
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
                    FROM  TB_ASS_CCP_CONV_CLINICA_PROCED CCP
                    
                   WHERE  (pAUX_EEP_CD_ESPECPROCED IS NULL OR CCP.AUX_EEP_CD_ESPECPROCED = pAUX_EEP_CD_ESPECPROCED)
                     AND  (pAUX_GPC_CD_GRUPOPROCED IS NULL OR CCP.AUX_GPC_CD_GRUPOPROCED = pAUX_GPC_CD_GRUPOPROCED)
                     AND  (pCAD_PRD_CD_CODIGO IS NULL OR CCP.CAD_PRD_CD_CODIGO = pCAD_PRD_CD_CODIGO)
                     AND  (CCP.CAD_PRD_CD_CODIGO = PRD.CAD_PRD_CD_CODIGO)
                     AND  (CCP.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
                     AND  (CCP.CAD_CLC_ID = pCAD_CLC_ID ) )
         AND    (pAUX_EEP_CD_ESPECPROCED IS NULL OR PRD.AUX_EPP_CD_ESPECPROC = pAUX_EEP_CD_ESPECPROCED)
         AND    (pAUX_GPC_CD_GRUPOPROCED IS NULL OR PRD.AUX_GPC_CD_GRUPOPROC = pAUX_GPC_CD_GRUPOPROCED)
         AND    (pCAD_PRD_CD_CODIGO IS NULL OR PRD.CAD_PRD_CD_CODIGO = pCAD_PRD_CD_CODIGO)
         AND    (pTIS_MED_CD_TABELAMEDICA IS NULL OR PRD.TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA)
         ORDER BY PRD.CAD_PRD_DS_DESCRICAO;

    io_cursor := v_cursor;
end PRC_ASS_PPR_NAOASSOC_CCP_S;
