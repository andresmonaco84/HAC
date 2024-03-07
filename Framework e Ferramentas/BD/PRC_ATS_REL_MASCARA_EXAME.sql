create or replace procedure PRC_ATS_REL_MASCARA_EXAME
  (
     pCAD_PRD_ID IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.CAD_PRD_ID%type DEFAULT NULL,
     pAUX_EPP_CD_ESPECPROC IN TB_AUX_EPP_ESPECPROC.AUX_EPP_CD_ESPECPROC%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_REL_MASCARA_EXAME
  *
  *    Data Criacao:   21/02/2009       Por: Pedro
  *    Data Alteracao:  29/03/2010  Por: Pedro
  *    Alteração:   join tb_AUX_EPP
  *  
  *    Funcao: Recupera os dados da associacao de Laudo x Procedimento
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT

       LPR.CAD_PRD_ID,
       LPR.ATS_LPR_STATUS,
       LPR.ATS_LPR_DT_ULTIMA_ATUALIZACAO,
       LPR.SEG_USU_ID_USUARIO,
       TPL.ATS_TPL_CD_CODIGO,
       TPL.ATS_TPL_DS_DESCRICAO,
       EPP.AUX_EPP_CD_ESPECPROC,
       EPP.AUX_EPP_DS_DESCRICAO,
       PRD.CAD_PRD_CD_CODIGO,
       PRD.CAD_PRD_DS_DESCRICAO
    FROM TB_ATS_LPR_LAUDO_PROCEDIMENTO LPR
    inner join tb_ats_tpl_texto_padrao_laudo TPL
    on LPR.ats_tpl_id = TPL.ats_tpl_id
    inner join tb_cad_prd_produto PRD
    on LPR.cad_prd_id = PRD.cad_prd_id
    inner join tb_aux_epp_especproc epp
    on epp.aux_epp_cd_especproc = prd.aux_epp_cd_especproc
    and epp.tis_med_cd_tabelamedica = prd.tis_med_cd_tabelamedica

    WHERE
        (pCAD_PRD_ID is null OR LPR.CAD_PRD_ID = pCAD_PRD_ID) 
        AND (pAUX_EPP_CD_ESPECPROC IS NULL OR EPP.AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC)
       ;
    io_cursor := v_cursor;
  end PRC_ATS_REL_MASCARA_EXAME;
/
