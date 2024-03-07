create or replace procedure PRC_ATS_LPR_LAUDO_PROCED_S
  (
     pATS_LPR_ID IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.ATS_LPR_ID%type DEFAULT NULL,
     pATS_TPL_ID IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.ATS_TPL_ID%type DEFAULT NULL,
     pCAD_PRD_ID IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.CAD_PRD_ID%type DEFAULT NULL,
     pATS_LPR_STATUS IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.ATS_LPR_STATUS%type DEFAULT NULL,
     pATS_LPR_DT_ULTIMA_ATUALIZACAO IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.ATS_LPR_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_ATS_LPR_LAUDO_PROCEDIMENTO.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATS_LPR_LAUDO_PROCED_S
  * 
  *    Data Criacao: 	28/11/2008		   Por: Fabíola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *   
  *    Data Alteracao:	09/12/2008  Por: Pedro
  *    inlcuido os joins tpl e prd
  *
  *    Data Alteracao:	26/02/2009/2008  Por: Pedro
  *    inlcuido order by pelo codigo por causa da tela de Laudo, o order by do c# e diferente do oracle
  *
  *    Funcao: Recupera os dados da associacao de Laudo x Procedimento
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       LPR.ATS_LPR_ID,
       LPR.ATS_TPL_ID,
       LPR.CAD_PRD_ID,
       LPR.ATS_LPR_STATUS,
       LPR.ATS_LPR_DT_ULTIMA_ATUALIZACAO,
       LPR.SEG_USU_ID_USUARIO,
       TPL.ATS_TPL_CD_CODIGO,
       TPL.ATS_TPL_DS_DESCRICAO,
       PRD.CAD_PRD_CD_CODIGO,
       PRD.CAD_PRD_DS_DESCRICAO
    FROM TB_ATS_LPR_LAUDO_PROCEDIMENTO LPR
    inner join tb_ats_tpl_texto_padrao_laudo TPL
    on LPR.ats_tpl_id = TPL.ats_tpl_id
    inner join tb_cad_prd_produto PRD
    on LPR.cad_prd_id = PRD.cad_prd_id
    
    WHERE
        (pATS_LPR_ID is null OR LPR.ATS_LPR_ID = pATS_LPR_ID) AND 
        (pATS_TPL_ID is null OR LPR.ATS_TPL_ID = pATS_TPL_ID) AND 
        (pCAD_PRD_ID is null OR LPR.CAD_PRD_ID = pCAD_PRD_ID) AND 
        (pATS_LPR_STATUS is null OR LPR.ATS_LPR_STATUS = pATS_LPR_STATUS) AND 
        (pATS_LPR_DT_ULTIMA_ATUALIZACAO is null OR LPR.ATS_LPR_DT_ULTIMA_ATUALIZACAO = pATS_LPR_DT_ULTIMA_ATUALIZACAO) AND 
        (pSEG_USU_ID_USUARIO is null OR LPR.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO)
        order by 7;          
    io_cursor := v_cursor;
  end PRC_ATS_LPR_LAUDO_PROCED_S;
/