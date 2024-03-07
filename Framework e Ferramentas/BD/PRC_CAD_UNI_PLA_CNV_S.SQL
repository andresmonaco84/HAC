CREATE OR REPLACE PROCEDURE PRC_CAD_UNI_PLA_CNV_S
(
   pCAD_PLA_CD_PLANO_HAC IN TB_CAD_PLA_PLANO.CAD_PLA_CD_PLANO_HAC%type,
   pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type,  
   pDATA_BASE date default null,
   pTELA string default null,
   pCAD_UNI_FL_GRAVA_ATEND_OK IN TB_CAD_UNI_UNIDADE.CAD_UNI_FL_GRAVA_ATEND_OK%type DEFAULT NULL,
   io_cursor OUT PKG_CURSOR.t_cursor
) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_UNI_PLA_CNV_S
  * 
  *    Data Criacao: 	06/08/2007             Por: Guilherme Holdack
  *	   Data Alteracao: 29/09/2007            Por:Silmara	
  *    Alteracao: Associacao Conveno,Unidade,Local,Plano E FLAG AGENDA
  *
  *    Funcao: Recupera as Unidades por filtros de Plano e Id do Convênio
  *
  *    Data de Alteração: 03/10/2007         Por: Guilherme Holdack
  *    Alteração: Inclusão de Pes.* para retornar os dados de Pessoa.
  *
  *    Data de Alteração: 07/11/2007         Por: Carlos Araujo
  *    Alteração: Inclusão de verificação de vigência.  
  *
  *    Data de Alteração: 17/09/2008         Por: Andrea Cazuca
  *    Alteração: Incluído o parametro tela para verificar a query a ser executada
  *
  *    Data Alteração:  21/10/2008  Por: Andréa Cazuca
  *    Alterção: Incluindo o parâmetro CAD_UNI_FL_GRAVA_ATEND_OK
  *
  *    Data Alteração:  05/08/2010  Por: Rafael Coimbra
  *    Alterção: Incluindo o parâmetro CAD_UNI_FL_FATURA_UNID_OK
  *
  *******************************************************************/        
  v_cursor PKG_CURSOR.t_cursor;
  begin
     IF pTELA = 'A' OR pTELA = 'L' THEN
       OPEN v_cursor FOR
       select  distinct
          UNI.CAD_UNI_ID_UNIDADE,
          UNI.CAD_UNI_DS_IMAGEM_ASSOCIADA,
          UNI.CAD_UNI_ID_UNIDADE_MASTER,
          UNI.CAD_UNI_FL_STATUS,
          UNI.CAD_UNI_DT_ULTIMO_STATUS,
          UNI.CAD_UNI_FL_GRAVA_ATEND_OK,
          UNI.CAD_UNI_FL_LIBERA_AGENDA_OK,
          UNI.CAD_UNI_FL_GRAVA_CD_PAC_OK,
          UNI.CAD_UNI_FL_CRONICO_OK,
          UNI.CAD_UNI_FL_PRIORIDADE_OK,
          UNI.CAD_PES_ID_PESSOA,
          UNI.CAD_UNI_CD_UNID_HOSPITALAR,
          UNI.CAD_UNI_FL_GRAVA_CD_PAC_OK,
          UNI.CAD_UNI_NR_CNES,
          UNI.CAD_UNI_FL_LIB_LOC_SETOR_OK,
          UNI.CAD_UNI_FL_FATURA_UNID_OK,
          PES.*
       from
          tb_cad_uni_unidade uni,
          tb_cad_cnv_convenio cnv,
          tb_cad_pla_plano pla,
          tb_ass_cnu_convenio_unidade cnu,
          tb_ass_clp_cnv_und_loc_plano clp,
          tb_ass_cul_conv_uni_locatend cul,
          tb_cad_pes_pessoa pes  
       where
           (pla.cad_pla_cd_plano_hac  = Upper(pCAD_PLA_CD_PLANO_HAC))
       and (cnv.cad_cnv_id_convenio   = pCAD_CNV_ID_CONVENIO)
       and  pla.cad_cnv_id_convenio    = cnv.cad_cnv_id_convenio
       and  cnu.cad_uni_id_unidade     = uni.cad_uni_id_unidade
       and  cnu.cad_cnv_id_convenio    = cnv.cad_cnv_id_convenio
       and  uni.cad_pes_id_pessoa      = pes.cad_pes_id_pessoa
       and  cul.ass_cul_id             = clp.ass_cul_id 
       and  cul.ass_cnu_id             = cnu.ass_cnu_id
       and  clp.cad_pla_id_plano       = pla.cad_pla_id_plano 
       AND (pDATA_BASE is null OR pDATA_BASE BETWEEN cnu.ass_cnu_dt_ini_vigencia AND cnu.ass_cnu_dt_fim_vigencia OR cnu.ass_cnu_dt_fim_vigencia is null)
       AND (pDATA_BASE is null OR pDATA_BASE BETWEEN clp.ass_clp_dt_ini_vigencia AND clp.ass_clp_dt_fim_vigencia OR clp.ass_clp_dt_fim_vigencia is null)
       AND (pDATA_BASE is null OR pDATA_BASE BETWEEN cul.ass_cul_dt_ini_vigencia AND cul.ass_cul_dt_fim_vigencia OR cul.ass_cul_dt_fim_vigencia is null)
       AND (pCAD_UNI_FL_GRAVA_ATEND_OK is null OR UNI.CAD_UNI_FL_GRAVA_ATEND_OK = pCAD_UNI_FL_GRAVA_ATEND_OK)
       ORDER BY PES.CAD_PES_NM_PESSOA;
       io_cursor := v_cursor;
     ELSE
       OPEN v_cursor FOR
       select  distinct
          UNI.CAD_UNI_ID_UNIDADE,
          UNI.CAD_UNI_DS_IMAGEM_ASSOCIADA,
          UNI.CAD_UNI_ID_UNIDADE_MASTER,
          UNI.CAD_UNI_FL_STATUS,
          UNI.CAD_UNI_DT_ULTIMO_STATUS,
          UNI.CAD_UNI_FL_GRAVA_ATEND_OK,
          UNI.CAD_UNI_FL_LIBERA_AGENDA_OK,
          UNI.CAD_UNI_FL_GRAVA_CD_PAC_OK,
          UNI.CAD_UNI_FL_CRONICO_OK,
          UNI.CAD_UNI_FL_PRIORIDADE_OK,
          UNI.CAD_PES_ID_PESSOA,
          UNI.CAD_UNI_CD_UNID_HOSPITALAR,
          UNI.CAD_UNI_FL_GRAVA_CD_PAC_OK,
          UNI.CAD_UNI_NR_CNES,
          UNI.CAD_UNI_FL_LIB_LOC_SETOR_OK,
          UNI.CAD_UNI_FL_FATURA_UNID_OK,
          PES.*
       from
          tb_cad_uni_unidade uni,
          tb_cad_cnv_convenio cnv,
          tb_cad_pla_plano pla,
          tb_ass_cnu_convenio_unidade cnu,
          tb_ass_clp_cnv_und_loc_plano clp,
          tb_ass_cul_conv_uni_locatend cul,
          tb_cad_pes_pessoa pes  
       where
           (pla.cad_pla_cd_plano_hac  = Upper(pCAD_PLA_CD_PLANO_HAC))
       and (cnv.cad_cnv_id_convenio   = pCAD_CNV_ID_CONVENIO)
       and  pla.cad_cnv_id_convenio    = cnv.cad_cnv_id_convenio
       and  cnu.cad_uni_id_unidade     = uni.cad_uni_id_unidade
       and  cnu.cad_cnv_id_convenio    = cnv.cad_cnv_id_convenio
       and  uni.cad_pes_id_pessoa      = pes.cad_pes_id_pessoa
       and  cul.ass_cul_id             = clp.ass_cul_id 
       and  cul.ass_cnu_id             = cnu.ass_cnu_id
       and  clp.cad_pla_id_plano       = pla.cad_pla_id_plano 
       and  uni.cad_uni_fl_libera_agenda_ok = 'S'
       AND (pDATA_BASE is null OR pDATA_BASE BETWEEN cnu.ass_cnu_dt_ini_vigencia AND cnu.ass_cnu_dt_fim_vigencia OR cnu.ass_cnu_dt_fim_vigencia is null)
       AND (pDATA_BASE is null OR pDATA_BASE BETWEEN clp.ass_clp_dt_ini_vigencia AND clp.ass_clp_dt_fim_vigencia OR clp.ass_clp_dt_fim_vigencia is null)
       AND (pDATA_BASE is null OR pDATA_BASE BETWEEN cul.ass_cul_dt_ini_vigencia AND cul.ass_cul_dt_fim_vigencia OR cul.ass_cul_dt_fim_vigencia is null)
       AND (pCAD_UNI_FL_GRAVA_ATEND_OK is null OR UNI.CAD_UNI_FL_GRAVA_ATEND_OK = pCAD_UNI_FL_GRAVA_ATEND_OK)
       ORDER BY PES.CAD_PES_NM_PESSOA;
       io_cursor := v_cursor;
     END IF;
  end PRC_CAD_UNI_PLA_CNV_S;
