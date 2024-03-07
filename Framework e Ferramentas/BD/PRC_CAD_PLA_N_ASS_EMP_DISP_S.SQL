create or replace procedure PRC_CAD_PLA_N_ASS_EMP_DISP_S
  (
     pCAD_EMP_ID_EMPRESA IN TB_CAD_EMP_EMPRESA.CAD_EMP_ID_EMPRESA%type DEFAULT NULL,
     pCAD_PLA_CD_TIPOPLANO IN tb_cad_pla_plano.cad_pla_cd_tipoplano%TYPE DEFAULT NULL,
     pCAD_PLA_FL_SITUACAO_PLANO IN Tb_Cad_Pla_Plano.Cad_Pla_Fl_Situacao_Plano%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
 
is
  /********************************************************************
  *    Procedure: PRC_CAD_PLA_N_ASS_EMP_DISP_S 
  * 
  *    Data Criacao: 	 20/11/2007   Por: Guilherme Holdack       
  *
  *    Funcao: Obtem os Planos n?o associados as Empresa(s) por filtros especificos
  *
  *    Data Alteracao: 14/02/2008            Por: Andrea Cazuca
  *    Alterac?o: Inclus?o dos campo CAD_PLA_FL_EXIGE_SENHA_LIB_OK e
  *               CAD_PLA_FL_LIBERA_EXAME_OK
  *
  *    Data Alterac?o: 24/03/2008    Por: Fabiola Lopes
  *    Alterac?o: Inclus?o de um campo que foi incluido na tabela (cad_pla_ds_orientacao)
  *
  *    Data Alteracao: 17/06/2009          Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao do campo CAD_PLA_FL_AUTORIZA_ONLINE
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
      SELECT pla.cad_pla_id_plano,
             pla.cad_pla_cd_plano_hac,
             pla.cad_pla_cd_plano,
             pla.cad_pla_cd_tipoplano,
             pla.cad_pla_nm_nome_plano,
             pla.cad_pla_fl_situacao_plano,
             pla.cad_cnv_id_convenio,
             pla.cad_pla_dt_ult_atualizacao,
             pla.seg_usu_id_usuario,
             pla.cad_pla_dt_inicio_vigencia,
             pla.cad_pla_dt_fim_vigencia,
             pla.cad_pla_ds_obs_fim_vig,
             pla.cad_pla_fl_exige_guia,
             pla.cad_pla_fl_exige_senha_lib_ok,
             pla.cad_pla_fl_libera_exame_ok,
             pla.cad_pla_ds_orientacao,
             pla.cad_pla_fl_autoriza_online           
       FROM
             tb_cad_pla_plano pla
      WHERE
             pla.cad_pla_id_plano NOT IN 
                                          ( SELECT epl.cad_pla_id_plano 
                                            FROM   tb_ass_epl_empresa_plano epl
                                            WHERE  epl.cad_emp_id_empresa = pCAD_EMP_ID_EMPRESA)
        AND  pla.cad_pla_cd_tipoplano = pCAD_PLA_CD_TIPOPLANO
        AND  pla.cad_pla_fl_situacao_plano = pCAD_PLA_FL_SITUACAO_PLANO;
      io_cursor := v_cursor;
  end PRC_CAD_PLA_N_ASS_EMP_DISP_S;
/
