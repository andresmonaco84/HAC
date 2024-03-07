create or replace function fnc_age_usu_marcados
  (
   pDT_INICIO_CONSULTA TB_AGE_AGD_AGENDA.AGE_AGD_DT_AGENDA%TYPE,
   pDT_FIM_CONSULTA IN TB_AGE_AGD_AGENDA.AGE_AGD_DT_AGENDA%TYPE,
   pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%TYPE,
   pCAD_UNI_ID_UNIDADE in TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE
  )
  return NUMBER is Result NUMBER;
  begin
  select
                 count(agd.age_agd_id) into result
          from   tb_age_agd_agenda agd
          where  trunc(agd.age_agd_dt_agenda) between pDT_INICIO_CONSULTA and pDT_FIM_CONSULTA
             and agd.seg_usu_id_usuario = pSEG_USU_ID_USUARIO
             and AGD.CAD_UNI_ID_UNID_LOGIN_USU = pCAD_UNI_ID_UNIDADE
  ;

    return(Result);
  end fnc_age_usu_marcados;
