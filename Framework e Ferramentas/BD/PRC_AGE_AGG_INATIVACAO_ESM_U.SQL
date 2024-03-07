create or replace procedure PRC_AGE_AGG_INATIVACAO_ESM_U
  (
     pAGE_ESM_ID IN TB_AGE_AGG_AGENDA_GERADA.AGE_ESM_ID%type,
     pAGE_DT_INATIVACAO_ESM IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_DT_FIM_ESCALA%TYPE DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_AGG_INATIVACAO_ESM_U
  *
  *    Data Criacao: 	11/12/2007   Por: Guilherme Holdack
  *
  *    Funcao: Configurar como desabilitados os horarios de agenda gerada
  *            que estejam com status de 'livre' e que estejam localizados
  *            a partir da data de inativac?o da escala medica informada pelo
  *            parametro pAGE_DT_INATIVACAO_ESM
  *
  *    Data Alteracao: 13/02/2008  Por: Cristiane Gomes
  *
  *    Alteracao: Retirada substituida a condicao >= por > da clausula where
  *******************************************************************/
  begin
    UPDATE
        tb_age_agg_agenda_gerada agg
    SET
        agg.age_agg_fl_status_horario = 4 -- desabilitado
    WHERE
        agg.age_esm_id = pAGE_ESM_ID
    AND agg.age_agg_fl_status_horario = 1 -- livre
    AND agg.age_agg_dt_agenda > Trunc(DECODE(pAGE_DT_INATIVACAO_ESM,NULL,SYSDATE,pAGE_DT_INATIVACAO_ESM));


  end PRC_AGE_AGG_INATIVACAO_ESM_U;
 