create or replace procedure PRC_AGS_REL_ESTAT_POR_USU
  (
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type default null,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default null,
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%type default null,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type default null,
     pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%type default null,
     pDT_INI_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_DT_ATENDIMENTO%type,
     pDT_FIM_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_DT_ATENDIMENTO%type default null,
     pHR_INI_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_HR_ATENDIMENTO%type default null,
     pHR_FIM_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_HR_ATENDIMENTO%type default null,
     pAGE_SAU_ID in tb_age_sau_sala_unid_and.age_sau_id%type default null,
     pAUX_EPP_CD_ESPECPROC in tb_aux_epp_especproc.aux_epp_cd_especproc%type default null,
     pCAD_PRD_ID  in tb_cad_prd_produto.cad_prd_id%type default null,
   io_cursor              OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_AGS_REL_ESTAT_POR_USU
  *
  *    Data Criacao:  12/7/2010   Por: Pedro
  *    Data Alteracao:  8/12/2011 Por: Pedro
  *    Data Alteracao:  12/12/2011 Por: Eduardo
  *    Alteração: '90'
  *    Alteração: Filtrar por Especialidade (EPP)
  *    Funcao: Popula o Relatorio de Agendamentos por usuario
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
SELECT DISTINCT
       USU.SEG_USU_DS_NOME,
       USU.SEG_USU_CD_MATRICULA,
       EPP.AUX_EPP_DS_DESCRICAO,
       PRD.CAD_PRD_DS_DESCRICAO,
       TO_CHAR(AGS.AGS_AGE_DT_ATENDIMENTO,'MM/yyyy') AGS_AGE_DT_ATENDIMENTO,
       COUNT(AGS.LIB_PRD_ID) OVER(PARTITION BY USU.SEG_USU_ID_USUARIO||EPP.AUX_EPP_CD_ESPECPROC||PRD.CAD_PRD_ID||TO_CHAR(AGS.AGS_AGE_DT_ATENDIMENTO,'MM/YYYY'))
       TOTAL
FROM TB_AGS_AGE_AGENDA_SADT AGS
JOIN   TB_ATS_ATE_ATENDIMENTO_SADT ATS     ON ATS.ATS_ATE_CD_INTLIB = AGS.LIB_PRD_ID
JOIN TB_SEG_USU_USUARIO USU                ON USU.SEG_USU_ID_USUARIO = AGS.SEG_USU_ID_USUARIO_AGENDA
JOIN TB_CAD_PRD_PRODUTO PRD                ON  PRD.CAD_PRD_ID = AGS.CAD_PRD_ID
                                           AND PRD.TIS_MED_CD_TABELAMEDICA = '90'
JOIN TB_AUX_EPP_ESPECPROC EPP              ON EPP.AUX_EPP_CD_ESPECPROC = PRD.AUX_EPP_CD_ESPECPROC
                                           AND EPP.TIS_MED_CD_TABELAMEDICA = PRD.TIS_MED_CD_TABELAMEDICA


where (ags.ags_age_dt_atendimento >= pDT_INI_CONSULTA)
and   (pDT_FIM_CONSULTA IS NULL OR ags.ags_age_dt_atendimento <= pDT_FIM_CONSULTA)
and   (pAUX_EPP_CD_ESPECPROC IS NULL OR epp.aux_epp_cd_especproc = pAUX_EPP_CD_ESPECPROC)
order by 1,3
  ;
  io_cursor := v_cursor;
end PRC_AGS_REL_ESTAT_POR_USU;
