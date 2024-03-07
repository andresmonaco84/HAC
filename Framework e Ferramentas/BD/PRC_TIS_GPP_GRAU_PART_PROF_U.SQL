create or replace procedure PRC_TIS_GPP_GRAU_PART_PROF_U
(
     pTIS_GPP_CD_GRAU_PART_PROF IN TB_TIS_GPP_GRAU_PART_PROF.TIS_GPP_CD_GRAU_PART_PROF%type,
     pTIS_GPP_DS_GRAU_PART_PROF IN TB_TIS_GPP_GRAU_PART_PROF.TIS_GPP_DS_GRAU_PART_PROF%type,
     pTIS_GPP_PC_GRAU_PART_PROF IN TB_TIS_GPP_GRAU_PART_PROF.TIS_GPP_PC_GRAU_PART_PROF%type default NULL,
     --pTIS_GPP_DT_ULTIMA_ATUALIZACAO IN TB_TIS_GPP_GRAU_PART_PROF.TIS_GPP_DT_ULTIMA_ATUALIZACAO%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_TIS_GPP_GRAU_PART_PROF.SEG_USU_ID_USUARIO%type,
  	 pTIS_GPP_FL_STATUS IN TB_TIS_GPP_GRAU_PART_PROF.TIS_GPP_FL_STATUS%type
)
is
/********************************************************************
*    Procedure: PRC_TIS_GPP_GRAU_PART_PROF_U
*
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
begin
UPDATE TB_TIS_GPP_GRAU_PART_PROF
SET
        TIS_GPP_DS_GRAU_PART_PROF = UPPER(pTIS_GPP_DS_GRAU_PART_PROF),
        TIS_GPP_PC_GRAU_PART_PROF = pTIS_GPP_PC_GRAU_PART_PROF,
        TIS_GPP_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        TIS_GPP_FL_STATUS = pTIS_GPP_FL_STATUS
WHERE
        TIS_GPP_CD_GRAU_PART_PROF = pTIS_GPP_CD_GRAU_PART_PROF;
end PRC_TIS_GPP_GRAU_PART_PROF_U;