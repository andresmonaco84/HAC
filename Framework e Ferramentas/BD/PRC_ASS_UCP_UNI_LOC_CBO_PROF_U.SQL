  create or replace procedure PRC_ASS_UCP_UNI_LOC_CBO_PROF_U
  (
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type,
     pCAD_PRO_ID_PROFISSIONAL IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL %TYPE DEFAULT NULL,
     pASS_UCP_FL_STATUS IN TB_ASS_UCP_UNID_LOC_CBO_PROF.ASS_UCP_FL_STATUS%type,     
     pASS_UCP_QTD_AGEND_PERM_CBOS IN TB_ASS_UCP_UNID_LOC_CBO_PROF.ASS_UCP_QTD_AGEND_PERM_CBOS%type DEFAULT NULL,
     pASS_UCP_DS_OBS IN TB_ASS_UCP_UNID_LOC_CBO_PROF.ASS_UCP_DS_OBS%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_UCP_UNID_LOC_CBO_PROF.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UCP_UNI_LOC_CBO_PROF_U
  * 
  *    Data Criacao: 	02/07/2007        Por: Cristiane Gomes da Silva
  *    Funcao: Altera a Associação de Unidade com Local de Atendimento,
  *            Especialidade e Profissional
  *  
  *    Data Alteracao:	11/07/2007      Por: Carlos Eduardo
  *    Alteração: Retirada de Vigência
  *
  *******************************************************************/  
  begin
    UPDATE TB_ASS_UCP_UNID_LOC_CBO_PROF
    SET	   
        ASS_UCP_FL_STATUS = pASS_UCP_FL_STATUS,
        ASS_UCP_QTD_AGEND_PERM_CBOS = pASS_UCP_QTD_AGEND_PERM_CBOS,
        ASS_UCP_DS_OBS = UPPER(pASS_UCP_DS_OBS),
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ASS_UCP_DT_ULTIMA_ATUALIZACAO = sysdate
    WHERE
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS
    AND CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL;
  end PRC_ASS_UCP_UNI_LOC_CBO_PROF_U;
/
