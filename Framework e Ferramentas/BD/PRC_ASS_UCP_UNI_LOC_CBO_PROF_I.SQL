  create or replace procedure PRC_ASS_UCP_UNI_LOC_CBO_PROF_I
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
  *    Procedure: PRC_ASS_UCP_UNI_LOC_CBO_PROF_I
  * 
  *    Data Criacao: 	02/07/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao:  04/07/2007  Por: Cristiane Gomes da Silva
  *
  *    Alteração: 1) Inclusão de DEFAULT NULL no parâmetro 
  *               pASS_UCP_DT_FIM_VIGENCIA  
  *
  *
  *    Data Alteracao:  10/07/2007  Por: Carlos Eduardo
  *
  *    Alteração: Retirada de vigência 
  *  
  *    Funcao: Inclui uma Associação de Unidade ao Local de Atendimento,
  *            à Especialidade e ao Profissional
  *
  *******************************************************************/  
  begin
    	    
    INSERT INTO TB_ASS_UCP_UNID_LOC_CBO_PROF
    (
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       TIS_CBO_CD_CBOS,
       CAD_PRO_ID_PROFISSIONAL,
       ASS_UCP_FL_STATUS,
       ASS_UCP_QTD_AGEND_PERM_CBOS,
       ASS_UCP_DS_OBS,
       SEG_USU_ID_USUARIO,
       ASS_UCP_DT_ULTIMA_ATUALIZACAO
    )
    VALUES
    (
       pCAD_UNI_ID_UNIDADE,
       pCAD_LAT_ID_LOCAL_ATENDIMENTO,
       pTIS_CBO_CD_CBOS,
       pCAD_PRO_ID_PROFISSIONAL,
       pASS_UCP_FL_STATUS,
	     pASS_UCP_QTD_AGEND_PERM_CBOS,
	     UPPER(pASS_UCP_DS_OBS),
	     pSEG_USU_ID_USUARIO,
	     sysdate
    );
  
  end PRC_ASS_UCP_UNI_LOC_CBO_PROF_I;
/
