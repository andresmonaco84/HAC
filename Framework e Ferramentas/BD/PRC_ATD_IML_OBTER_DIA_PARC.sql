create or replace procedure PRC_ATD_IML_OBTER_DIA_PARC
  (
     pATD_ATE_ID IN TB_ATD_IML_INT_MOV_LEITO.ATD_ATE_ID%type,
     pCAD_PAC_ID_PACIENTE IN TB_ATD_IML_INT_MOV_LEITO.CAD_PAC_ID_PACIENTE%type,
     pDATA_LIMITE DATE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATD_IML_OBTER_DIA_PARC
  *    Autor: Marcus Relva 
  *    Data: 26/11/2010
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
   /* Obter diarias simples */   
    select iml.atd_ate_id,
       iml.atd_iml_dt_entrada,
       iml.atd_iml_hr_entrada,
       nvl(iml.atd_iml_dt_saida,trunc(pDATA_LIMITE)) as atd_iml_dt_saida ,
       nvl(iml.atd_iml_hr_saida,to_number(to_char(pDATA_LIMITE, 'HH24MI'))) as atd_iml_hr_saida,
       iml.cad_cad_qle_id,
       iml.atd_iml_dt_ultima_atualizacao,
       iml.seg_usu_id_usuario,
       iml.cad_pac_id_paciente,
       iml.tis_tac_cd_tipo_acomod_aut,
       iml.tis_tac_cd_tipo_acomodacao,
       iml.atd_iml_fl_status,
       iml.atd_iml_fl_cortesia,
       iml.atd_iml_fl_dif_classe,
       iml.atd_iml_id,
       iml.atd_iml_fl_falta_vaga
  from tb_atd_iml_int_mov_leito iml
 where iml.atd_ate_id = pATD_ATE_ID
       and iml.atd_iml_fl_status = 'A'
       and iml.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
       and (iml.atd_iml_dt_saida IS NULL OR fnc_juntar_data_hora(iml.atd_iml_dt_saida, iml.atd_iml_hr_saida) < pDATA_LIMITE)
       and fnc_juntar_data_hora(iml.atd_iml_dt_entrada, iml.atd_iml_hr_entrada) <= pDATA_LIMITE
       and fnc_juntar_data_hora(iml.atd_iml_dt_entrada, 0) not in --0 iml.atd_iml_hr_entrada
                                          (select fnc_juntar_data_hora(cci.fat_cci_dt_inicio_consumo, 0 ) -- cci.fat_cci_hr_inicio_consumo
                                           from tb_fat_cci_conta_consu_item cci, tb_cad_prd_produto prd
                                           where cci.atd_ate_id = pATD_ATE_ID
                                           and cci.cad_prd_id = prd.cad_prd_id
                                           and prd.cad_prd_fl_lanca_diaria = 'S'
                                           and cci.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
                                           and cci.fat_cci_fl_status = 'A'
                                           and cci.cad_tap_tp_atributo = 'DIA')
union                                            
 /* Obter diarias ate a data limite */  
select iml.atd_ate_id,
       iml.atd_iml_dt_entrada,
       iml.atd_iml_hr_entrada,       
       trunc(pDATA_LIMITE) as atd_iml_dt_saida,
       to_number(to_char(pDATA_LIMITE, 'HH24MI')) as atd_iml_hr_saida,
       iml.cad_cad_qle_id,
       iml.atd_iml_dt_ultima_atualizacao,
       iml.seg_usu_id_usuario,
       iml.cad_pac_id_paciente,
       iml.tis_tac_cd_tipo_acomod_aut,
       iml.tis_tac_cd_tipo_acomodacao,
       iml.atd_iml_fl_status,
       iml.atd_iml_fl_cortesia,
       iml.atd_iml_fl_dif_classe,
       iml.atd_iml_id,
       iml.atd_iml_fl_falta_vaga
  from tb_atd_iml_int_mov_leito iml
 where iml.atd_ate_id = pATD_ATE_ID
       and iml.atd_iml_fl_status = 'A'
       and iml.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE      
       and fnc_juntar_data_hora(iml.atd_iml_dt_entrada, iml.atd_iml_hr_entrada) <= pDATA_LIMITE
       and (iml.atd_iml_dt_saida IS NULL
            or pDATA_LIMITE between fnc_juntar_data_hora(iml.atd_iml_dt_entrada, iml.atd_iml_hr_entrada) and fnc_juntar_data_hora(iml.atd_iml_dt_saida, iml.atd_iml_hr_saida))
       and fnc_juntar_data_hora(iml.atd_iml_dt_entrada, iml.atd_iml_hr_entrada) not in 
        (select fnc_juntar_data_hora(cci.fat_cci_dt_inicio_consumo, cci.fat_cci_hr_inicio_consumo)                            
                                         from tb_fat_cci_conta_consu_item cci, tb_cad_prd_produto prd
                                         where cci.atd_ate_id = pATD_ATE_ID
                                         and cci.cad_prd_id = prd.cad_prd_id
                                         and prd.cad_prd_fl_lanca_diaria = 'S'
                                         and cci.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
                                         and cci.fat_cci_fl_status = 'A'
                                         and cci.cad_tap_tp_atributo = 'DIA')
union
/* Obter diarias dentro de um periodo */
select          
       iml.atd_ate_id,
       b.fat_cci_dt_fim_consumo as atd_iml_dt_entrada,
       b.fat_cci_hr_fim_consumo as atd_iml_hr_entrada,     
       --Data de Saida
       CASE when (atd_iml_dt_saida is null OR pDATA_LIMITE < fnc_juntar_data_hora(iml.atd_iml_dt_saida,iml.atd_iml_hr_saida))
       THEN trunc(pDATA_LIMITE) 
       ELSE iml.atd_iml_dt_saida
       END as  atd_iml_dt_saida,
       --Hora de Saida
       to_number(to_char(
       CASE when (atd_iml_hr_saida is null OR pDATA_LIMITE < fnc_juntar_data_hora(iml.atd_iml_dt_saida,iml.atd_iml_hr_saida))
       THEN pDATA_LIMITE
       ELSE fnc_juntar_data_hora(iml.atd_iml_dt_saida,iml.atd_iml_hr_saida)
       END
       , 'HH24MI')) as atd_iml_hr_saida,             
       iml.cad_cad_qle_id,
       iml.atd_iml_dt_ultima_atualizacao,
       iml.seg_usu_id_usuario,
       iml.cad_pac_id_paciente,
       iml.tis_tac_cd_tipo_acomod_aut,
       iml.tis_tac_cd_tipo_acomodacao,
       iml.atd_iml_fl_status,
       iml.atd_iml_fl_cortesia,
       iml.atd_iml_fl_dif_classe,
       iml.atd_iml_id,
       iml.atd_iml_fl_falta_vaga         
  from tb_atd_iml_int_mov_leito iml,
  (select cci.fat_cci_dt_inicio_consumo,
          cci.fat_cci_hr_inicio_consumo,
          cci.fat_cci_dt_fim_consumo,
          cci.fat_cci_hr_fim_consumo                   
         from tb_fat_cci_conta_consu_item cci, tb_cad_prd_produto prd
         where cci.atd_ate_id = pATD_ATE_ID
         and cci.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
         and cci.cad_prd_id = prd.cad_prd_id
         and prd.cad_prd_fl_lanca_diaria = 'S'
         and cci.fat_cci_fl_status = 'A'
         and cci.cad_tap_tp_atributo = 'DIA'
         and fnc_juntar_data_hora(cci.fat_cci_dt_fim_consumo, cci.fat_cci_hr_fim_consumo) = 
                     (select max(fnc_juntar_data_hora(cci.fat_cci_dt_fim_consumo, cci.fat_cci_hr_fim_consumo))         
                     from tb_fat_cci_conta_consu_item cci, tb_cad_prd_produto prd
                     where cci.atd_ate_id = pATD_ATE_ID
                     and cci.cad_prd_id = prd.cad_prd_id
                     and prd.cad_prd_fl_lanca_diaria = 'S'
                     and cci.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
                     and cci.fat_cci_fl_status = 'A'
                     and cci.cad_tap_tp_atributo = 'DIA')) b
       where iml.atd_ate_id = pATD_ATE_ID
       and iml.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE                
       and fnc_juntar_data_hora(iml.atd_iml_dt_entrada, iml.atd_iml_hr_entrada) <= pDATA_LIMITE
       and fnc_juntar_data_hora(iml.atd_iml_dt_entrada, iml.atd_iml_hr_entrada) <= fnc_juntar_data_hora(b.fat_cci_dt_fim_consumo, b.fat_cci_hr_fim_consumo)
       and (iml.atd_iml_dt_saida is null or
           fnc_juntar_data_hora(iml.atd_iml_dt_saida, iml.atd_iml_hr_saida) >= fnc_juntar_data_hora(b.fat_cci_dt_fim_consumo, b.fat_cci_hr_fim_consumo));
    io_cursor := v_cursor;
  end PRC_ATD_IML_OBTER_DIA_PARC;
