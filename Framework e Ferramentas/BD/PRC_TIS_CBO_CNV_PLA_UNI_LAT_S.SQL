CREATE OR REPLACE PROCEDURE "PRC_TIS_CBO_CNV_PLA_UNI_LAT_S"
  (
     pCAD_PLA_CD_PLANO_HAC IN TB_CAD_PLA_PLANO.CAD_PLA_CD_PLANO_HAC%type,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CBO_CNV_PLA_UNI_LAT_S
  *
  *    Data Criacao: 	07/08/2007   Por: Guilherme Holdack
  *
  *
  *    Alterac?o:     14/08/2007   Por: Guilherme Holdack
  *        Listando apenas especialidades associadas a profissionais que
  *                 tenham agenda gerada e escala medica       
  *    
  *    Data Alteracao:  21/09/2007    Por: Andrea Cazuca
  *    Alteracao: Inclus?o dos campos TIS_CBO_CD_CBOS_HAC e TIS_CBO_DS_CBOS_HAC
  *
  *    Funcao: Lista as Especialidades de acordo com Plano x Convenio x Unidade x Local de Atendimento
  *          
  *    Alterac?o: 28/09/2007       Por: Bruno Costa
  *            ordenac?o por TIS_CBO_DS_CBOS_HAC 
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alterac?o: Remoc?o de Upper em campo, no where
  *
  *	   Data Alterac?o:	29/07/2008		Por:	Pedro Carvalho
  *	   Func?o:			Inclus?o de novos campo na tabela (TIS_CBO_FL_QTD_ATE_LIMITADA CHAR(1), TIS_CBO_QT_ATEND_PERM_ANO NUMBER(3))
  *
  *    Data Alteração: 07/04/2014   Por: Andréa Cazuca
  *    Alteração:  Inclusão de novos campos TIS_CBO_VL_IDADE_LIMITE_ESP, TIS_CBO_CD_CBOS_NOVO, TIS_CBO_CD_CBOS_V3
  *                TIS_CBO_FL_STATUS
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT distinct
       CBO.TIS_CBO_CD_CBOS,
       CBO.TIS_CBO_DS_CBOS,
       CBO.TIS_CBO_FL_STATUS_ENCAMINHA,
       CBO.TIS_CBO_CD_CBOS_HAC,
       CBO.TIS_CBO_DS_CBOS_HAC,
       CBO.TIS_CBO_FL_QTD_ATE_LIMITADA,
       CBO.TIS_CBO_QT_ATEND_PERM_ANO,
       CBO.TIS_CBO_VL_IDADE_LIMITE_ESP,
       CBO.TIS_CBO_CD_CBOS_NOVO,
       CBO.TIS_CBO_CD_CBOS_V3,
       CBO.TIS_CBO_FL_STATUS
           FROM
       tb_cad_uni_unidade uni,
       tb_cad_cnv_convenio cnv,
       tb_cad_pla_plano pla,
       tb_cad_lat_local_atendimento lat,
       tb_ass_clp_cnv_und_loc_plano clp,
       tb_ass_cul_conv_uni_locatend cul,
       tb_ass_cnu_convenio_unidade cnu,
       tb_tis_cbo_cbos cbo,
       tb_ass_plc_plano_cbos plc,
       tb_ass_ucp_unid_loc_cbo_prof ucp,
       tb_age_esm_escala_medica esm,
       tb_age_agg_agenda_gerada agg
    WHERE
       pla.cad_pla_cd_plano_hac = upper(pCAD_PLA_CD_PLANO_HAC)
       and cnv.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
       and uni.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE
       and lat.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
       and pla.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
       and clp.cad_pla_id_plano = pla.cad_pla_id_plano
       and clp.ass_cul_id = cul.ass_cul_id
       and cul.ass_cnu_id = cnu.ass_cnu_id
       and cnu.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
       and cnu.cad_uni_id_unidade = uni.cad_uni_id_unidade
       and cul.cad_lat_id_local_atendimento = lat.cad_lat_id_local_atendimento
       and plc.cad_pla_id_plano = pla.cad_pla_id_plano
       and plc.tis_cbo_cd_cbos = cbo.tis_cbo_cd_cbos
       and ucp.cad_uni_id_unidade = uni.cad_uni_id_unidade
       and ucp.cad_lat_id_local_atendimento = lat.cad_lat_id_local_atendimento
       and ucp.tis_cbo_cd_cbos = cbo.tis_cbo_cd_cbos
       and esm.cad_pro_id_profissional = ucp.cad_pro_id_profissional
       and esm.cad_uni_id_unidade = ucp.cad_uni_id_unidade
       and esm.cad_lat_id_local_atendimento = ucp.cad_lat_id_local_atendimento
       and esm.tis_cbo_cd_cbos = cbo.tis_cbo_cd_cbos
       and agg.age_esm_id = esm.age_esm_id
       order by TIS_CBO_DS_CBOS_HAC;
       io_cursor := v_cursor;
  end PRC_TIS_CBO_CNV_PLA_UNI_LAT_S;
 