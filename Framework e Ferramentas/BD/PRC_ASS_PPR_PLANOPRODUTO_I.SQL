create or replace procedure PRC_ASS_PPR_PLANOPRODUTO_I
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_PPR_PLANOPRODUTO.CAD_CNV_ID_CONVENIO%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_PPR_PLANOPRODUTO.CAD_PLA_ID_PLANO%type,
     pCAD_PRD_ID IN TB_ASS_PPR_PLANOPRODUTO.CAD_PRD_ID%type,
     pASS_PPR_FL_EXIGEGUIA_OK IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_FL_EXIGEGUIA_OK%type,
     pASS_PPR_FL_EXIGESENHA_OK IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_FL_EXIGESENHA_OK%type,
     pASS_PPR_FL_EXIGEAUTOR_OK IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_FL_EXIGEAUTOR_OK%type,
     pASS_PPR_FL_ANTECIPASENHA_OK IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_FL_ANTECIPASENHA_OK%type,
     pASS_PPR_FL_AUTORIZATEL_OK IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_FL_AUTORIZATEL_OK%type,
     pASS_PPR_FL_AUTORIZAFAX_OK IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_FL_AUTORIZAFAX_OK%type,
     pASS_PPR_FL_AUTORIZAPES_OK IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_FL_AUTORIZAPES_OK%type,
     pASS_PPR_FL_AUTORIZAWEB_OK IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_FL_AUTORIZAWEB_OK%type,
     pASS_PPR_QT_DIASAUTORIZACAO IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_QT_DIASAUTORIZACAO%type default NULL,
     pTIS_MED_CD_TABELAMEDICA IN TB_ASS_PPR_PLANOPRODUTO.TIS_MED_CD_TABELAMEDICA%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_PPR_PLANOPRODUTO.SEG_USU_ID_USUARIO%type,
     pASS_PPR_FL_STATUS IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_FL_STATUS%TYPE,
     pASS_PPR_FL_COBERTO_OK IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_FL_AUTORIZA_ASS_OK%TYPE,
     pASS_PPR_FL_EXIGEGUIAPS_OK  IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_FL_EXIGEGUIAPS_OK%TYPE,
     pASS_PPR_FL_EXIGESENHAPS_OK IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_FL_EXIGESENHAPS_OK%TYPE,
     pASS_PPR_FL_PROCDOPLER_OK IN TB_ASS_PPR_PLANOPRODUTO.ASS_PPR_FL_PROCDOPLER_OK%TYPE default NULL
     
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PPR_PLANOPRODUTO_I
  *
  *    Data Criacao:     04/01/2008         Por: Fabiola Lopes
  *    Data Alteracao:  data da alteragco  Por: Nome do Analista
  *
  *    Data Alteracao:  13/02/2008  Por: Davi S. M. dos Reis
  *    Alteração: Inclusao do novos atributos de via de autorizacao,
  *               senha antecipada e prazo de resposta
  *
  *    Data Alteracao:  04/03/2008  Por: Davi S. M. dos Reis
  *    Alteração: Inclusao do novo atributo ASS_PPR_FL_AUTORIZA_ASS_OK
  *
  *    Data Alteracao:  31/03/2008  Por: Davi S. M. dos Reis
  *    Alteração: Inclusao do novo atributo ASS_PPR_FL_AUTORIZAWEB_OK
  *
  *    Data Alteracao:  08/03/2008  Por: Davi S. M. dos Reis
  *    Alteração: Renomeacao do parametro pASS_PPR_FL_AUTORIZA_ASS_OK para pASS_PPR_FL_COBERTO_OK
  *
  *    Data Alteracao:  28/04/2008  Por: Davi S. M. dos Reis
  *    Alteração: Inclusao da consistencia para validar se o convenio, o plano e o
  *               produto ja existem na tabela (se ja estao associados)
  *
  *    Data Alteracao:  22/09/2009  Por: Alexandre M. Muniz
  *    Alteração: Inclusao do novo atributo ASS_PPR_FL_PROCDOPLER_OK
  *
  *    Funcao: Inclusao das associacoes de produtos com plano x convenio
  *
  *******************************************************************/

  begin

    INSERT INTO TB_ASS_PPR_PLANOPRODUTO
    (
       CAD_CNV_ID_CONVENIO,
       CAD_PLA_ID_PLANO,
       CAD_PRD_ID,
       ASS_PPR_FL_EXIGEGUIA_OK,
       ASS_PPR_FL_EXIGESENHA_OK,
       ASS_PPR_FL_EXIGEAUTOR_OK,
       ASS_PPR_FL_ANTECIPASENHA_OK,
       ASS_PPR_FL_AUTORIZATEL_OK,
       ASS_PPR_FL_AUTORIZAFAX_OK,
       ASS_PPR_FL_AUTORIZAPES_OK,
       ASS_PPR_FL_AUTORIZAWEB_OK, 
       ASS_PPR_QT_DIASAUTORIZACAO,
       TIS_MED_CD_TABELAMEDICA,
       SEG_USU_ID_USUARIO,
       ASS_PPR_DT_ULTIMA_ATUALIZACAO,
       ASS_PPR_FL_STATUS,
       ASS_PPR_FL_AUTORIZA_ASS_OK,
       ASS_PPR_FL_EXIGESENHAPS_OK,
       ASS_PPR_FL_EXIGEGUIAPS_OK,
       ASS_PPR_FL_PROCDOPLER_OK
    )
    SELECT
       pCAD_CNV_ID_CONVENIO,
       pCAD_PLA_ID_PLANO,
       pCAD_PRD_ID,
       pASS_PPR_FL_EXIGEGUIA_OK,
       pASS_PPR_FL_EXIGESENHA_OK,
       pASS_PPR_FL_EXIGEAUTOR_OK,
       pASS_PPR_FL_ANTECIPASENHA_OK,
       pASS_PPR_FL_AUTORIZATEL_OK,
       pASS_PPR_FL_AUTORIZAFAX_OK,
       pASS_PPR_FL_AUTORIZAPES_OK,
       pASS_PPR_FL_AUTORIZAWEB_OK,
       pASS_PPR_QT_DIASAUTORIZACAO,
       pTIS_MED_CD_TABELAMEDICA,
       pSEG_USU_ID_USUARIO,
       SYSDATE,
       pASS_PPR_FL_STATUS,
       pASS_PPR_FL_COBERTO_OK,
       pASS_PPR_FL_EXIGESENHAPS_OK,
       pASS_PPR_FL_EXIGEGUIAPS_OK,
       pASS_PPR_FL_PROCDOPLER_OK
    FROM DUAL
   WHERE NOT EXISTS (
                   SELECT 1
                     FROM TB_ASS_PPR_PLANOPRODUTO PPR
                         WHERE PPR.CAD_PRD_ID = pCAD_PRD_ID
                           AND PPR.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
                           AND PPR.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
                    );


  end PRC_ASS_PPR_PLANOPRODUTO_I;
