create or replace procedure PRC_ATD_GUI_GUIAATEND_I
  (
     pATD_GUI_CD_CODIGO IN TB_ATD_GUI_GUIAATEND.ATD_GUI_CD_CODIGO%type,
     pATD_GUI_FL_GUIAPRINC_OK IN TB_ATD_GUI_GUIAATEND.ATD_GUI_FL_GUIAPRINC_OK%type,
     pATD_ATE_ID IN TB_ATD_GUI_GUIAATEND.ATD_ATE_ID%type,
     pATD_GUI_DT_EMISSAOGUIA IN TB_ATD_GUI_GUIAATEND.ATD_GUI_DT_EMISSAOGUIA%type,
     pSEG_USU_ID_USUARIO IN TB_ATD_GUI_GUIAATEND.SEG_USU_ID_USUARIO%type,
     pATD_GUI_DT_AUTORIZGUIA IN TB_ATD_GUI_GUIAATEND.ATD_GUI_DT_AUTORIZGUIA%type,
     pATD_GUI_FL_ATIVO_OK IN TB_ATD_GUI_GUIAATEND.ATD_GUI_FL_ATIVO_OK%type default NULL,
     pATD_GUI_CD_SENHA IN TB_ATD_GUI_GUIAATEND.ATD_GUI_CD_SENHA%type default NULL,
     pATD_GUI_DT_VALIDADE IN TB_ATD_GUI_GUIAATEND.ATD_GUI_DT_VALIDADE%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATD_GUI_GUIAATEND_I
  *
  *    Data Criacao:  11/03/2008   Por: Andrea Cazuca
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Inclui guia de atendimento
  *
  *******************************************************************/

  begin

    INSERT INTO TB_ATD_GUI_GUIAATEND
    (
       ATD_GUI_CD_CODIGO,
       ATD_GUI_DT_ULTIMA_ATUALIZACAO,
       ATD_GUI_FL_GUIAPRINC_OK,
       ATD_ATE_ID,
       ATD_GUI_DT_EMISSAOGUIA,
       SEG_USU_ID_USUARIO,
       ATD_GUI_DT_AUTORIZGUIA,
       ATD_GUI_FL_ATIVO_OK,
       ATD_GUI_CD_SENHA,
       ATD_GUI_DT_VALIDADE
    )
    VALUES
    (
      pATD_GUI_CD_CODIGO,
      sysdate,
      pATD_GUI_FL_GUIAPRINC_OK,
      pATD_ATE_ID,
      TRUNC(pATD_GUI_DT_EMISSAOGUIA),
      pSEG_USU_ID_USUARIO,
      TRUNC(pATD_GUI_DT_AUTORIZGUIA),
      pATD_GUI_FL_ATIVO_OK,
      pATD_GUI_CD_SENHA,
      TRUNC(pATD_GUI_DT_VALIDADE)
    );

  end PRC_ATD_GUI_GUIAATEND_I;
