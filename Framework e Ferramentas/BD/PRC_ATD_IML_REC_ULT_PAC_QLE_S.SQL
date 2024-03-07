CREATE OR REPLACE PROCEDURE PRC_ATD_IML_REC_ULT_PAC_QLE_S(pCAD_QLE_ID IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_ID%TYPE,
                                                       IO_CURSOR   OUT PKG_CURSOR.T_CURSOR) IS
  /********************************************************************
  *    Procedure: PRC_ATD_IML_REC_ULT_PAC_QLE_S
  *
  *    Data Criacao:   22/08/2011          Por:  Fabiola
  *    Funcao: Recupera o ultimo paciente do quarto e leito
  *
   *******************************************************************/
  V_CURSOR PKG_CURSOR.T_CURSOR;
BEGIN
  OPEN V_CURSOR FOR
 
 select max(fnc_juntar_data_hora(iml.atd_iml_dt_saida, iml.atd_iml_hr_saida)),
       iml.atd_ate_id,
       iml.atd_iml_dt_saida,
       iml.atd_iml_hr_saida
  from tb_atd_iml_int_mov_leito iml
 where iml.cad_cad_qle_id = pCAD_QLE_ID
   and iml.atd_iml_dt_saida is not null
 group by iml.atd_ate_id,
          fnc_juntar_data_hora(iml.atd_iml_dt_saida, iml.atd_iml_hr_saida),
          iml.atd_iml_dt_saida,
          iml.atd_iml_hr_saida
 order by fnc_juntar_data_hora(iml.atd_iml_dt_saida, iml.atd_iml_hr_saida) desc;
  IO_CURSOR := V_CURSOR;
END PRC_ATD_IML_REC_ULT_PAC_QLE_S;
