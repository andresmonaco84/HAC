create or replace procedure PRC_ASS_PCL_PROF_CLINICA_S
  (
     pCAD_UNI_ID_UNIDADE IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_UNI_ID_UNIDADE%type default NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default NULL,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_PRO_ID_PROFISSIONAL%type default NULL,
     pASS_PCL_ID IN TB_ASS_PCL_PROF_CLINICA.ASS_PCL_ID%type default NULL,
     pCAD_CLC_ID IN TB_ASS_PCL_PROF_CLINICA.CAD_CLC_ID%type default NULL,
     pASS_PCL_DT_INI_VIGENCIA IN TB_ASS_PCL_PROF_CLINICA.ASS_PCL_DT_INI_VIGENCIA%type default NULL,
     pASS_PCL_DT_FIM_VIGENCIA IN TB_ASS_PCL_PROF_CLINICA.ASS_PCL_DT_FIM_VIGENCIA%type default NULL,

     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PCL_PROF_CLINICA_S
  *
  *    Data Criacao:   22/09/2008   Por: Pedro H. A. de Carvalho
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Seleciona Profissional associado a Clinica
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       PCL.ASS_PCL_ID,
       PCL.CAD_UNI_ID_UNIDADE,
       PCL.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       PCL.CAD_PRO_ID_PROFISSIONAL,
       PCL.CAD_CLC_ID,
       PCL.ASS_PCL_DT_INI_VIGENCIA,
       PCL.ASS_PCL_DT_FIM_VIGENCIA,
       PCL.ASS_PCL_DT_ULTIMA_ATUALIZACAO,
       PCL.SEG_USU_ID_USUARIO
    FROM TB_ASS_PCL_PROF_CLINICA PCL
    WHERE
        (pASS_PCL_ID is null OR PCL.ASS_PCL_ID = pASS_PCL_ID)
      AND (pCAD_UNI_ID_UNIDADE is null OR PCL.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
      AND (pCAD_LAT_ID_LOCAL_ATENDIMENTO is null OR PCL.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
      AND (pCAD_PRO_ID_PROFISSIONAL is null OR PCL.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL)
      AND (pCAD_CLC_ID is null or PCL.CAD_CLC_ID = pCAD_CLC_ID)
      AND (pASS_PCL_DT_INI_VIGENCIA is null or PCL.ASS_PCL_DT_INI_VIGENCIA = pASS_PCL_DT_INI_VIGENCIA)
      AND (pASS_PCL_DT_FIM_VIGENCIA is null or PCL.ASS_PCL_DT_FIM_VIGENCIA = pASS_PCL_DT_FIM_VIGENCIA)
      ;
    io_cursor := v_cursor;
  end PRC_ASS_PCL_PROF_CLINICA_S;
/
