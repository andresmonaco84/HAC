create or replace function fnc_age_usu_cancelados
  (
   pDT_INICIO_CONSULTA TB_AGE_AGD_AGENDA.AGE_AGD_DT_AGENDA%TYPE,
   pDT_FIM_CONSULTA IN TB_AGE_AGD_AGENDA.AGE_AGD_DT_AGENDA%TYPE,
   pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%TYPE,
   pCAD_UNI_ID_UNIDADE in TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE
  )
  return NUMBER is Result NUMBER;
  begin
 
   select DISTINCT
        nvl(Sum(count(agd.age_agd_id)),0)  into result
          from   tb_age_agc_agenda_cancelada agd
          where  trunc(agd.age_agc_dt_cancelamento) between pDT_INICIO_CONSULTA and pDT_FIM_CONSULTA              
              AND (agd.cad_uni_id_unid_login_usu = pCAD_UNI_ID_UNIDADE )
              AND (AGD.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO )
          group by agd.seg_usu_id_usuario, agd.cad_uni_id_unid_login_usu,agd.age_agd_id;
 
    return(Result);
  end fnc_age_usu_cancelados;
 