create or replace procedure sgs.PRC_ASS_CVP_CONV_VLR_PRODUTO_U(pASS_CVP_ID                   IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_ID%type,
                                                           pCAD_CNV_ID_CONVENIO          IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_CNV_ID_CONVENIO%type,
                                                           pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default NULL,
                                                           pCAD_TAP_TP_ATRIBUTO          IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_TAP_TP_ATRIBUTO%type,
                                                           pCAD_PRD_ID                   IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_PRD_ID%type,
                                                           pCAD_TIH_TP_INDICE_HOSP       IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_TIH_TP_INDICE_HOSP%type,
                                                           pASS_CVP_QT_INDICE_HOSP       IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_QT_INDICE_HOSP%type,
                                                           pASS_CVP_VL_INDICE_HOSP       IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_VL_INDICE_HOSP%type,
                                                           pASS_CVP_TP_PORTE             IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_TP_PORTE%type default NULL,
                                                           pASS_CVP_VL_PRODUTO           IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_VL_PRODUTO%type default NULL,
                                                           pASS_CVP_QT_MAXIMA_PERM       IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_QT_MAXIMA_PERM%type,
                                                           pASS_CVP_QT_MINIMA_PERM       IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_QT_MINIMA_PERM%type,
                                                           pASS_CVP_PC_ACRESCIMO         IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_PC_ACRESCIMO%type default NULL,
                                                           pASS_CVP_PC_DESCONTO          IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_PC_DESCONTO%type default NULL,
                                                           pASS_CVP_VL_ACRESCIMO         IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_VL_ACRESCIMO%type default NULL,
                                                           pASS_CVP_VL_DESCONTO          IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_VL_DESCONTO%type default NULL,
                                                           pASS_CVP_PC_TAXAADM           IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_PC_TAXAADM%type default NULL,
                                                           pASS_CVP_PC_DOPPLER           IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_PC_DOPPLER%type default NULL,
                                                           pASS_CVP_DT_INICIO_VIGENCIA   IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_DT_INICIO_VIGENCIA%type,
                                                           pASS_CVP_DT_FIM_VIGENCIA      IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_DT_FIM_VIGENCIA%type default NULL,
                                                           pTIS_CDE_CD_CODIGO_DESPESA    IN TB_ASS_CVP_CONV_VLR_PRODUTO.TIS_CDE_CD_CODIGO_DESPESA%type default NULL,
                                                           pASS_CPE_ID                   IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CPE_ID%type default NULL,
                                                           pASS_DT_ULTIMA_ATUALIZACAO    IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_DT_ULTIMA_ATUALIZACAO%type,
                                                           pSEG_USU_ID_USUARIO           IN TB_ASS_CVP_CONV_VLR_PRODUTO.SEG_USU_ID_USUARIO%type,
                                                           pASS_CVP_FL_PC_ACRESCIMOHR    IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_FL_PC_ACRESCIMOHR%type default NULL,
                                                           pASS_CVP_FL_ISEN_COBRA        IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_FL_ISEN_COBRA%type default NULL,
                                                           pASS_CVP_FL_COBERT_ANEST      IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_FL_COBERT_ANEST%type default NULL,
                                                           pASS_CVP_TP_UNID_CONSUMO      IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_TP_UNID_CONSUMO%type default NULL,
                                                           pASS_CVP_PC_ACOMOD_HM         IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_PC_ACOMOD_HM%type default NULL,
                                                           pCAD_PLA_ID_PLANO             IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_PLA_ID_PLANO%type default NULL,
                                                           pCAD_SPL_ID                   IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_SPL_ID%type default NULL,
                                                           pCAD_UNI_ID_UNIDADE           IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_UNI_ID_UNIDADE%type default NULL,
                                                           pTIS_MED_CD_TABELAMEDICA      IN TB_ASS_CVP_CONV_VLR_PRODUTO.TIS_MED_CD_TABELAMEDICA%type default NULL,
                                                           pAUX_EPP_CD_ESPECPROC         IN TB_ASS_CVP_CONV_VLR_PRODUTO.AUX_EPP_CD_ESPECPROC%type default NULL,
                                                           pAUX_GPC_CD_GRUPOPROC         IN TB_ASS_CVP_CONV_VLR_PRODUTO.AUX_GPC_CD_GRUPOPROC%type default NULL,
                                                           pASS_CVP_FL_STATUS            IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_FL_STATUS%type default NULL,
                                                           pCAD_PRD_ID_TAXA_ADM          IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_PRD_ID_TAXA_ADM%type default NULL,
                                                           pASS_CVP_TP_PORTE_SALA        IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_TP_PORTE_SALA%type default NULL) is
  /********************************************************************
  *    Procedure: PRC_ASS_CVP_CONV_VLR_PRODUTO_U
  *
  *    Data Criacao:    11/2009     Por: Alexandre Muniz
  *    Data Alteracao: 20/09/2010  Por: André S. Monaco
  *         Alteracao: Adição de campos (TIS_MED_CD_TABELAMEDICA,
  *                                      AUX_EPP_CD_ESPECPROC,
  *                                      AUX_GPC_CD_GRUPOPROC,
  *                                      ASS_CVP_FL_STATUS)
  *    Data Alteracao: 26/10/2010  Por: André S. Monaco
  *         Alteracao: Adição do campo CAD_PRD_ID_TAXA_ADM
  *    Data Alteracao: 06/12/2010  Por: André S. Monaco
  *         Alteracao: Adição do campo ASS_CVP_TP_PORTE_SALA
  *
  *    Funcao: Atualiza valor de procedimento do convênio
  *
  *******************************************************************/
	v_erro NUMBER;
begin
  if (pCAD_TIH_TP_INDICE_HOSP = 'M2') then
    begin
      update tb_cad_cvm_conv_vlr_moedahos cvm      
         set cvm.cad_cvm_vl_moeda_hospitalar = pASS_CVP_VL_INDICE_HOSP,
             cvm.cad_cvm_dt_inicio_vigencia  = pASS_CVP_DT_INICIO_VIGENCIA,
             cvm.cad_cvm_dt_fim_vigencia     = pASS_CVP_DT_FIM_VIGENCIA
       where cvm.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
         and cvm.cad_tap_tp_atributo = 'M2'
         and cvm.cad_tih_tp_indice_hosp = 'M2'
         and cvm.cad_cvm_dt_fim_vigencia is null;
    exception
      when others then
        v_erro := 1;
    end;
  end if;
  UPDATE TB_ASS_CVP_CONV_VLR_PRODUTO
     SET CAD_CNV_ID_CONVENIO          = pCAD_CNV_ID_CONVENIO,
         CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO,
         CAD_TAP_TP_ATRIBUTO          = pCAD_TAP_TP_ATRIBUTO,
         CAD_PRD_ID                   = pCAD_PRD_ID,
         CAD_TIH_TP_INDICE_HOSP       = pCAD_TIH_TP_INDICE_HOSP,
         ASS_CVP_QT_INDICE_HOSP       = pASS_CVP_QT_INDICE_HOSP,
         ASS_CVP_VL_INDICE_HOSP       = pASS_CVP_VL_INDICE_HOSP,
         ASS_CVP_TP_PORTE             = pASS_CVP_TP_PORTE,
         ASS_CVP_VL_PRODUTO           = pASS_CVP_VL_PRODUTO,
         ASS_CVP_QT_MAXIMA_PERM       = pASS_CVP_QT_MAXIMA_PERM,
         ASS_CVP_QT_MINIMA_PERM       = pASS_CVP_QT_MINIMA_PERM,
         ASS_CVP_PC_ACRESCIMO         = pASS_CVP_PC_ACRESCIMO,
         ASS_CVP_PC_DESCONTO          = pASS_CVP_PC_DESCONTO,
         ASS_CVP_VL_ACRESCIMO         = pASS_CVP_VL_ACRESCIMO,
         ASS_CVP_VL_DESCONTO          = pASS_CVP_VL_DESCONTO,
         ASS_CVP_PC_TAXAADM           = pASS_CVP_PC_TAXAADM,
         ASS_CVP_PC_DOPPLER           = pASS_CVP_PC_DOPPLER,
         ASS_CVP_DT_INICIO_VIGENCIA   = pASS_CVP_DT_INICIO_VIGENCIA,
         ASS_CVP_DT_FIM_VIGENCIA      = pASS_CVP_DT_FIM_VIGENCIA,
         TIS_CDE_CD_CODIGO_DESPESA    = pTIS_CDE_CD_CODIGO_DESPESA,
         ASS_CPE_ID                   = pASS_CPE_ID,
         ASS_DT_ULTIMA_ATUALIZACAO    = pASS_DT_ULTIMA_ATUALIZACAO,
         SEG_USU_ID_USUARIO           = pSEG_USU_ID_USUARIO,
         ASS_CVP_FL_PC_ACRESCIMOHR    = pASS_CVP_FL_PC_ACRESCIMOHR,
         ASS_CVP_FL_ISEN_COBRA        = pASS_CVP_FL_ISEN_COBRA,
         ASS_CVP_FL_COBERT_ANEST      = pASS_CVP_FL_COBERT_ANEST,
         ASS_CVP_TP_UNID_CONSUMO      = pASS_CVP_TP_UNID_CONSUMO,
         ASS_CVP_PC_ACOMOD_HM         = pASS_CVP_PC_ACOMOD_HM,
         CAD_PLA_ID_PLANO             = pCAD_PLA_ID_PLANO,
         CAD_SPL_ID                   = pCAD_SPL_ID,
         CAD_UNI_ID_UNIDADE           = pCAD_UNI_ID_UNIDADE,
         TIS_MED_CD_TABELAMEDICA      = pTIS_MED_CD_TABELAMEDICA,
         AUX_EPP_CD_ESPECPROC         = pAUX_EPP_CD_ESPECPROC,
         AUX_GPC_CD_GRUPOPROC         = pAUX_GPC_CD_GRUPOPROC,
         ASS_CVP_FL_STATUS            = pASS_CVP_FL_STATUS,
         CAD_PRD_ID_TAXA_ADM          = pCAD_PRD_ID_TAXA_ADM,
         ASS_CVP_TP_PORTE_SALA        = pASS_CVP_TP_PORTE_SALA
   WHERE ASS_CVP_ID = pASS_CVP_ID;
end PRC_ASS_CVP_CONV_VLR_PRODUTO_U;
