CREATE OR REPLACE FUNCTION FNC_SENHA_UTILIZADA
(

 page_agd_id IN tb_age_agc_agenda_cancelada.age_agd_id%TYPE,
 pAGE_AGD_FL_STATUS IN tb_age_agc_agenda_cancelada.AGE_AGD_FL_STATUS%TYPE DEFAULT NULL

)
return varchar2 is
  Result tb_cad_psu_plano_senha_util.cad_psu_nr_senha_utilizada%TYPE DEFAULT NULL;

  /********************************************************************
  *    Func?o: FNC_SENHA_UTILIZADA
  *
  *    Data Criacao:  12/11/2007   Por: Guilherme
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *    Data Alteracao: 05/11/2008   Por: Silmara
  *    Alterac?o: Utilizar Tabela de agenda cancelada
  *
  *    Utilidade: Recuperar a senha utilizada na agenda
  *******************************************************************/

BEGIN
     SELECT
     psu.cad_psu_nr_senha_utilizada
     INTO RESULT
     FROM
     tb_cad_psu_plano_senha_util psu,
     tb_age_agc_agenda_cancelada agc
     WHERE
     agc.age_agd_id = page_agd_id
     AND agc.age_agd_id = psu.age_agd_id
     AND (pAGE_AGD_FL_STATUS IS NULL OR (agc.age_agd_fl_status = psu.cad_psu_fl_status AND agc.age_agd_fl_status = pAGE_AGD_FL_STATUS))

UNION ALL

     SELECT
     psu.cad_psu_nr_senha_utilizada     
     FROM
     tb_cad_psu_plano_senha_util psu,
     tb_age_agd_agenda agd 
     WHERE
     agd.age_agd_id = page_agd_id
     AND agd.age_agd_id = psu.age_agd_id
     AND (pAGE_AGD_FL_STATUS IS NULL OR (agd.age_agd_fl_status = psu.cad_psu_fl_status   AND agd.age_agd_fl_status = pAGE_AGD_FL_STATUS));

   return(Result);
end FNC_SENHA_UTILIZADA;
 