

--PRC_ASS_PRE_PROF_ESP_EXAME_I
create or replace procedure PRC_ASS_PRE_PROF_ESP_EXAME_I
(
     pASS_PRE_ID IN TB_ASS_PRE_PROF_ESP_EXAME.ASS_PRE_ID%type,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PRE_PROF_ESP_EXAME.CAD_PRO_ID_PROFISSIONAL%type default NULL,
     pAUX_EPP_CD_ESPECPROC IN TB_ASS_PRE_PROF_ESP_EXAME.AUX_EPP_CD_ESPECPROC%type,
     pAUX_GPC_GRUPOPROC IN TB_ASS_PRE_PROF_ESP_EXAME.AUX_GPC_GRUPOPROC%type default NULL,
     pASS_PRE_DT_ULTIMA_ATUALIZACAO IN TB_ASS_PRE_PROF_ESP_EXAME.ASS_PRE_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_PRE_PROF_ESP_EXAME.SEG_USU_ID_USUARIO%type,
     pTIS_MED_CD_TABELAMEDICA IN TB_ASS_PRE_PROF_ESP_EXAME.TIS_MED_CD_TABELAMEDICA%type,
     pASS_PRE_FL_ATIVO IN TB_ASS_PRE_PROF_ESP_EXAME.ASS_PRE_FL_ATIVO%type  
) 
is
/********************************************************************
*    Procedure: PRC_ASS_PRE_PROF_ESP_EXAME_I
* 
*    Data Criacao:   data da  criação   Por: Nome do Analista
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
     lIdtRetorno INTEGER;
  begin
    SELECT SEQ_CAD_PAC_01.NextVal INTO lIdtRetorno FROM DUAL;
      
INSERT INTO TB_ASS_PRE_PROF_ESP_EXAME
(
       ASS_PRE_ID,
       CAD_PRO_ID_PROFISSIONAL,
       AUX_EPP_CD_ESPECPROC,
       AUX_GPC_GRUPOPROC,
       ASS_PRE_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       TIS_MED_CD_TABELAMEDICA,
       ASS_PRE_FL_ATIVO
)
VALUES
(
       lIdtRetorno,
       pCAD_PRO_ID_PROFISSIONAL,
       pAUX_EPP_CD_ESPECPROC,
       pAUX_GPC_GRUPOPROC,
       pASS_PRE_DT_ULTIMA_ATUALIZACAO,
       pSEG_USU_ID_USUARIO,
       pTIS_MED_CD_TABELAMEDICA,
       pASS_PRE_FL_ATIVO
);
  
end PRC_ASS_PRE_PROF_ESP_EXAME_I;

