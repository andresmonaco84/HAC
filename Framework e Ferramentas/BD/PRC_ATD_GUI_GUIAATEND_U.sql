CREATE OR REPLACE PROCEDURE "PRC_ATD_GUI_GUIAATEND_U"
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
*    Procedure: PRC_ATD_GUI_GUIAATEND_U
*
*    Data Criacao:   21/02/2011   Por: Davi Silvestre M. dos Reis
*
*    Funcao: Atualiza os dados de uma Guia de Atendimento j� gravada
*
*******************************************************************/
begin
UPDATE TB_ATD_GUI_GUIAATEND
SET
        ATD_GUI_DT_ULTIMA_ATUALIZACAO = sysdate,
        ATD_GUI_FL_GUIAPRINC_OK = pATD_GUI_FL_GUIAPRINC_OK,
        ATD_GUI_DT_EMISSAOGUIA = TRUNC(pATD_GUI_DT_EMISSAOGUIA),
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ATD_GUI_DT_AUTORIZGUIA = TRUNC(pATD_GUI_DT_AUTORIZGUIA),
        ATD_GUI_FL_ATIVO_OK = pATD_GUI_FL_ATIVO_OK,
        ATD_GUI_CD_SENHA = pATD_GUI_CD_SENHA
WHERE
        ATD_ATE_ID = pATD_ATE_ID
    AND ATD_GUI_CD_CODIGO = pATD_GUI_CD_CODIGO
    AND ATD_GUI_DT_VALIDADE = TRUNC(pATD_GUI_DT_VALIDADE);
end PRC_ATD_GUI_GUIAATEND_U;

 