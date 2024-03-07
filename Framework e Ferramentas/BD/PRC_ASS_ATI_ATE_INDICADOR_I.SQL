create or replace procedure PRC_ASS_ATI_ATE_INDICADOR_I
(
 pNewIdt OUT integer,
     pASS_ATI_ID IN TB_ASS_ATI_ATE_INDICADOR.ASS_ATI_ID%type,
     pCAD_IND_ID IN TB_ASS_ATI_ATE_INDICADOR.CAD_IND_ID%type,
     pATD_ATE_ID IN TB_ASS_ATI_ATE_INDICADOR.ATD_ATE_ID%type,
     pCAD_PES_ID_PESSOA IN TB_ASS_ATI_ATE_INDICADOR.CAD_PES_ID_PESSOA%type,
     pSEG_USU_ID_USUARIO_C IN TB_ASS_ATI_ATE_INDICADOR.SEG_USU_ID_USUARIO_C%type,
     pASS_ATI_DT_CRIACAO IN TB_ASS_ATI_ATE_INDICADOR.ASS_ATI_DT_CRIACAO%type,
     pSEG_USU_ID_USUARIO_A IN TB_ASS_ATI_ATE_INDICADOR.SEG_USU_ID_USUARIO_A%type,
     pASS_ATI_DT_ULT_ATUALIZ IN TB_ASS_ATI_ATE_INDICADOR.ASS_ATI_DT_ULT_ATUALIZ%type,
     pASS_ATI_DT_RSL_INI IN TB_ASS_ATI_ATE_INDICADOR.ASS_ATI_DT_RSL_INI%type default NULL,
     pASS_ATI_DT_RSL_FIM IN TB_ASS_ATI_ATE_INDICADOR.ASS_ATI_DT_RSL_FIM%type default NULL,
     pASS_ATI_FL_RSL IN TB_ASS_ATI_ATE_INDICADOR.ASS_ATI_FL_RSL%type default NULL,
     pASS_ATI_VL_RSL_MIN IN TB_ASS_ATI_ATE_INDICADOR.ASS_ATI_VL_RSL_MIN%type default NULL,
     pASS_ATI_VL_RSL_MAX IN TB_ASS_ATI_ATE_INDICADOR.ASS_ATI_VL_RSL_MAX%type default NULL,
     pASS_ATI_DS_RSL IN TB_ASS_ATI_ATE_INDICADOR.ASS_ATI_DS_RSL%type default NULL,
    pATD_IDR_ID IN TB_ASS_ATI_ATE_INDICADOR.ATD_IDR_ID%type default NULL
)
is
/********************************************************************
*    Procedure: PRC_ASS_ATI_ATE_INDICADOR_I
*
*    Data Criacao:  data da  criação   Por: Nome do Analista
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
lIdtRetorno INTEGER;
  begin
    SELECT SEQ_ass_ati_01.NextVal INTO lIdtRetorno FROM DUAL;

INSERT INTO TB_ASS_ATI_ATE_INDICADOR
(
       ASS_ATI_ID,
       CAD_IND_ID,
       ATD_ATE_ID,
       CAD_PES_ID_PESSOA,
       SEG_USU_ID_USUARIO_C,
       ASS_ATI_DT_CRIACAO,
       SEG_USU_ID_USUARIO_A,
       ASS_ATI_DT_ULT_ATUALIZ,
       ASS_ATI_DT_RSL_INI,
       ASS_ATI_DT_RSL_FIM,
       ASS_ATI_FL_RSL,
       ASS_ATI_VL_RSL_MIN,
       ASS_ATI_VL_RSL_MAX,
       ASS_ATI_DS_RSL,
       ATD_IDR_ID
)
VALUES
(
       lIdtRetorno,
       pCAD_IND_ID,
       pATD_ATE_ID,
       pCAD_PES_ID_PESSOA,
       pSEG_USU_ID_USUARIO_C,
       pASS_ATI_DT_CRIACAO,
       pSEG_USU_ID_USUARIO_A,
       pASS_ATI_DT_ULT_ATUALIZ,
       pASS_ATI_DT_RSL_INI,
       pASS_ATI_DT_RSL_FIM,
       pASS_ATI_FL_RSL,
       pASS_ATI_VL_RSL_MIN,
       pASS_ATI_VL_RSL_MAX,
       pASS_ATI_DS_RSL,
       pATD_IDR_ID
);
   pNewIdt := lIdtRetorno;
end PRC_ASS_ATI_ATE_INDICADOR_I;
