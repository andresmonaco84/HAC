create or replace procedure PRC_ATD_PRS_PREVISAO_SAIDA_I
(
pNewIdt OUT integer,
     pATD_PRS_ID IN TB_ATD_PRS_PREVISAO_SAIDA.ATD_PRS_ID%type,
     pATD_ATE_ID IN TB_ATD_PRS_PREVISAO_SAIDA.ATD_ATE_ID%type,
     pATD_PRS_DT_SAIDA IN TB_ATD_PRS_PREVISAO_SAIDA.ATD_PRS_DT_SAIDA%type default NULL,
     pATD_PRS_DT_SAIDA_UTI IN TB_ATD_PRS_PREVISAO_SAIDA.ATD_PRS_DT_SAIDA_UTI%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ATD_PRS_PREVISAO_SAIDA.SEG_USU_ID_USUARIO%type default NULL,
     pCAD_PRO_NR_CONSELHO IN TB_ATD_PRS_PREVISAO_SAIDA.CAD_PRO_NR_CONSELHO%type default NULL,
     pATD_PRS_DT_CRIACAO IN TB_ATD_PRS_PREVISAO_SAIDA.ATD_PRS_DT_CRIACAO%type default NULL--,
    -- pATD_PRS_FL_CONFIRMACAO IN TB_ATD_PRS_PREVISAO_SAIDA.ATD_PRS_FL_CONFIRMACAO%type default NULL,
   --  pSEG_USU_ID_USUARIO_CONF IN TB_ATD_PRS_PREVISAO_SAIDA.SEG_USU_ID_USUARIO_CONF%type default NULL,
    -- pCAD_PRO_NR_CONSELHO_CONF IN TB_ATD_PRS_PREVISAO_SAIDA.CAD_PRO_NR_CONSELHO_CONF%type default NULL
)
is
/********************************************************************
*    Procedure: PRC_ATD_PRS_PREVISAO_SAIDA_I
*
*    Data Criacao:  data da  cria??o   Por: Nome do Analista
*    Data Alteracao:  data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
    lIdtRetorno integer;
begin
  SELECT SEQ_ATD_PRS_01.Nextval INTO lIdtRetorno FROM dual;

INSERT INTO TB_ATD_PRS_PREVISAO_SAIDA
(
       ATD_PRS_ID,
       ATD_ATE_ID,
       ATD_PRS_DT_SAIDA,
       ATD_PRS_DT_SAIDA_UTI,
       SEG_USU_ID_USUARIO,
       CAD_PRO_NR_CONSELHO,
       ATD_PRS_DT_CRIACAO--,
     --  ATD_PRS_FL_CONFIRMACAO,
     --  SEG_USU_ID_USUARIO_CONF,
     --  CAD_PRO_NR_CONSELHO_CONF
)
VALUES
(
       lIdtRetorno,
       pATD_ATE_ID,
       pATD_PRS_DT_SAIDA,
       pATD_PRS_DT_SAIDA_UTI,
       pSEG_USU_ID_USUARIO,
       pCAD_PRO_NR_CONSELHO,
       pATD_PRS_DT_CRIACAO--,
   --    pATD_PRS_FL_CONFIRMACAO,
    --   pSEG_USU_ID_USUARIO_CONF,
      -- pCAD_PRO_NR_CONSELHO_CONF
);
  pNewIdt := lIdtRetorno;
end PRC_ATD_PRS_PREVISAO_SAIDA_I;
