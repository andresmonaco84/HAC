CREATE OR REPLACE PROCEDURE "PRC_ASS_RPG_REGRA_PAGTO_I"
(
  pNewIdt OUT integer,
     pASS_CPR_ID IN TB_ASS_RPG_REGRA_PAGTO.ASS_CPR_ID%type,
     pCAD_REP_ID IN TB_ASS_RPG_REGRA_PAGTO.CAD_REP_ID%type,
     pCAD_REP_DT_INICIO_VIGENCIA IN TB_ASS_RPG_REGRA_PAGTO.CAD_REP_DT_INICIO_VIGENCIA%type,
     pCAD_REP_DT_FIM_VIGENCIA IN TB_ASS_RPG_REGRA_PAGTO.CAD_REP_DT_FIM_VIGENCIA%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_RPG_REGRA_PAGTO.SEG_USU_ID_USUARIO%type,
     pCAD_REP_DT_ULTIMA_ATUALIZACAO IN TB_ASS_RPG_REGRA_PAGTO.CAD_REP_DT_ULTIMA_ATUALIZACAO%type,
     pASS_RPG_ID IN TB_ASS_RPG_REGRA_PAGTO.ASS_RPG_ID%type,
     pASS_RPG_PC_HAC IN TB_ASS_RPG_REGRA_PAGTO.ASS_RPG_PC_HAC%type,     
     pASS_RPG_PC_ACS IN TB_ASS_RPG_REGRA_PAGTO.ASS_RPG_PC_ACS%type
)
is
/********************************************************************
*    Procedure: PRC_ASS_RPG_REGRA_PAGTO_I
*
*    Data Criacao:  data da  criação   Por: Nome do Analista
*    Data Alteracao: data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
lIdtRetorno integer;
begin

SELECT SEQ_ASS_RPG_01.NextVal INTO lIdtRetorno FROM DUAL;

INSERT INTO TB_ASS_RPG_REGRA_PAGTO
(
    ASS_RPG_ID,
       CAD_REP_ID,
       CAD_REP_DT_INICIO_VIGENCIA,
       CAD_REP_DT_FIM_VIGENCIA,
       SEG_USU_ID_USUARIO,
       CAD_REP_DT_ULTIMA_ATUALIZACAO,
       ASS_CPR_ID,
       ASS_RPG_PC_HAC,
       ASS_RPG_PC_ACS
)
VALUES
(
      lIdtRetorno,
      pCAD_REP_ID,
      pCAD_REP_DT_INICIO_VIGENCIA,
      pCAD_REP_DT_FIM_VIGENCIA,
      pSEG_USU_ID_USUARIO,
      pCAD_REP_DT_ULTIMA_ATUALIZACAO,
      pASS_CPR_ID,
      pASS_RPG_PC_HAC,
      pASS_RPG_PC_ACS
);

pNewIdt := lIdtRetorno;

end PRC_ASS_RPG_REGRA_PAGTO_I;
 