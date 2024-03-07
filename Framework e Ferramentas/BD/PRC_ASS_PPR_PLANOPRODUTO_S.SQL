create or replace procedure PRC_ASS_PPR_PLANOPRODUTO_S
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_PPR_PLANOPRODUTO.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     pCAD_PLA_ID_PLANO IN TB_ASS_PPR_PLANOPRODUTO.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     pAUX_EPP_CD_ESPECPROC IN TB_CAD_PRD_PRODUTO.AUX_EPP_CD_ESPECPROC%TYPE DEFAULT NULL,
     pAUX_GPC_CD_GRUPOPROC IN TB_CAD_PRD_PRODUTO.AUX_GPC_CD_GRUPOPROC%TYPE DEFAULT NULL,
     pCAD_PRD_CD_CODIGO IN TB_CAD_PRD_PRODUTO.CAD_PRD_CD_CODIGO%TYPE DEFAULT NULL,
     pTIS_MED_CD_TABELAMEDICA IN TB_CAD_PRD_PRODUTO.TIS_MED_CD_TABELAMEDICA%TYPE DEFAULT NULL,
     pASS_PPR_FL_STATUS IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_FL_STATUS%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is

  /********************************************************************
  *    Procedure: PRC_ASS_PPR_PLANOPRODUTO_S
  *
  *    Data Criacao:   04/01/2008           Por: Fabiola Lopes
  *
  *    Funcao: Lista os produtos associados plano x produto  
  *
  *    Data Alteracao:  13/02/2008  Por: Davi S. M. dos Reis
  *    Alteração: Inclusao do novos atributos de via de autorizacao,
  *               senha antecipada e prazo de resposta
  *
  *    Data Alteracao:  04/03/2008  Por: Davi S. M. dos Reis
  *    Alteração: Inclusao do novo atributo ASS_PPR_FL_AUTORIZA_ASS_OK
  *
  *    Data Alteracao:  14/04/2008  Por: Davi S. M. dos Reis
  *    Alteração: Inclusao do atributo CAD_PRD_CD_CODIGO no retorno da consulta
  *
  *    Data Alteracao: 18/06/2008  Por: Bruno A. da Costa
  *    Alteração: Inclusão da opção de selecionar por todos os planos
  *
  *    Data Alteracao:  10/06/2009  Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao de condicao para verificar, tambem, o 
  *               status das associacoes
  *
  *    Data Alteracao:  22/09/2009  Por: Alexandre M. Muniz
  *    Alteracao: Inclusão do atributo ASS_PPR_FL_PROCDOPLER_OK
  *               no retorno da consulta.
  *
  *******************************************************************/

  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
         SELECT PPR.CAD_CNV_ID_CONVENIO,
                PPR.CAD_PLA_ID_PLANO,
                PPR.CAD_PRD_ID,
                PPR.TIS_MED_CD_TABELAMEDICA,
                PPR.SEG_USU_ID_USUARIO,
                PPR.ASS_PPR_DT_ULTIMA_ATUALIZACAO,
                PRD.CAD_PRD_DS_DESCRICAO,
                PRD.CAD_PRD_CD_CODIGO,
                PPR.ASS_PPR_FL_EXIGEGUIA_OK,
                PPR.ASS_PPR_FL_EXIGESENHA_OK,
                PPR.ASS_PPR_FL_EXIGEAUTOR_OK,
                PPR.ASS_PPR_FL_ANTECIPASENHA_OK,
                PPR.ASS_PPR_FL_AUTORIZATEL_OK,
                PPR.ASS_PPR_FL_AUTORIZAFAX_OK,
                PPR.ASS_PPR_FL_AUTORIZAPES_OK,
                PPR.ASS_PPR_FL_AUTORIZAWEB_OK,
                PPR.ASS_PPR_QT_DIASAUTORIZACAO,
                PPR.ASS_PPR_FL_AUTORIZA_ASS_OK,
                PPR.ASS_PPR_FL_STATUS,
                PPR.ASS_PPR_FL_EXIGEGUIAPS_OK,
                PPR.ASS_PPR_FL_EXIGESENHAPS_OK,
                PPR.ASS_PPR_FL_PROCDOPLER_OK
         FROM   TB_ASS_PPR_PLANOPRODUTO PPR,
                TB_CAD_PRD_PRODUTO PRD
         WHERE  PPR.CAD_PRD_ID = PRD.CAD_PRD_ID
           AND  PPR.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
           AND  (pCAD_PLA_ID_PLANO IS NULL OR PPR.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
           AND  (pASS_PPR_FL_STATUS IS NULL OR PPR.ASS_PPR_FL_STATUS = pASS_PPR_FL_STATUS)
           AND  (pAUX_EPP_CD_ESPECPROC IS NULL OR PRD.AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC)
           AND  (pAUX_GPC_CD_GRUPOPROC IS NULL OR PRD.AUX_GPC_CD_GRUPOPROC = pAUX_GPC_CD_GRUPOPROC)
           AND  (pCAD_PRD_CD_CODIGO IS NULL OR PRD.CAD_PRD_CD_CODIGO = pCAD_PRD_CD_CODIGO)
           AND  (pTIS_MED_CD_TABELAMEDICA IS NULL OR PRD.TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA)
           order by PRD.CAD_PRD_CD_CODIGO;

    io_cursor := v_cursor;
  end PRC_ASS_PPR_PLANOPRODUTO_S;

