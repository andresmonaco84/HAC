CREATE OR REPLACE PROCEDURE PRC_FAT_CCI_ATUALIZARMM_AUD
(
  pATD_ATE_ID             IN TB_FAT_MCC_MOV_COM_CONSUMO.ATD_ATE_ID%TYPE,
  pCAD_PRD_ID             IN TB_FAT_CCI_CONTA_CONSU_ITEM.CAD_PRD_ID%type,
  pCAD_PAC_ID_PACIENTE    IN TB_FAT_CCI_CONTA_CONSU_ITEM.CAD_PAC_ID_PACIENTE%type,
  pFAT_CCP_ID             IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%TYPE,
  pSEG_USU_ID_USUARIO     IN TB_FAT_CCI_CONTA_CONSU_ITEM.SEG_USU_ID_USUARIO%TYPE,
  pFAT_CCI_FL_FRACIONADO  IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_CCI_FL_FRACIONADO%TYPE,
  pFAT_CCI_VL_UNITARIO    IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_CCI_VL_UNITARIO%TYPE,
  pFAT_CCI_ID_PRINCIPAL   IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_CCI_ID_PRINCIPAL%type default null,
  pDESCRICAO_SETOR        IN VARCHAR2) IS
  /********************************************************************
  * Marcus Relva - 30/12/2010
  *******************************************************************/
  COMANDA_MATMED CONSTANT NUMBER := 1;
  COMANDA_MATMED_AMBPS CONSTANT NUMBER := 349;
BEGIN
if(pFAT_CCI_ID_PRINCIPAL is null) then
  update tb_fat_cci_conta_consu_item cci
   set cci.fat_cci_fl_status = 'C',
       cci.seg_usu_id_usuario = pSEG_USU_ID_USUARIO,
       cci.fat_cci_dt_ultima_atualizacao = sysdate
 where cci.atd_ate_id = pATD_ATE_ID
   and cci.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
   and cci.cad_prd_id = pCAD_PRD_ID
   and cci.cad_nfm_id is null
   and cci.fat_cci_fl_status = 'A'
   and cci.fat_ccp_id = pFAT_CCP_ID
   and cci.fat_cci_fl_fracionado = pFAT_CCI_FL_FRACIONADO
   and round((cci.fat_cci_vl_faturado / cci.fat_cci_qt_consumo),2) = pFAT_CCI_VL_UNITARIO
   -- O valor unitario deve ser calculado:
   /*
   and  decode(cci.fat_cci_fl_fracionado,
       'S', cci.fat_cci_vl_matmed_fabrica,
       'N', round((cci.fat_cci_vl_faturado / cci.fat_cci_qt_consumo),2)) = pFAT_CCI_VL_UNITARIO
   */
   and cci.fat_cci_id_principal is null
   and cci.fat_mcc_id in
       (select mcc.fat_mcc_id
          from tb_fat_mcc_mov_com_consumo mcc, tb_cad_set_setor str
         where mcc.cad_set_id = str.cad_set_id
           and mcc.fat_mcc_fl_status = 'A'
           and mcc.atd_ate_id = pATD_ATE_ID
           and mcc.fat_tco_id in (COMANDA_MATMED, COMANDA_MATMED_AMBPS)
           and decode(str.cad_set_cd_setor,
                      'CECI',
                      'CENTRO CIRURGICO',
                      'ENDO',
                      'ENDOSCOPIA',
                      'HEMD',
                      'HEMODINAMICA',
                      'ENFERMARIA') = pDESCRICAO_SETOR);
else
   update tb_fat_cci_conta_consu_item cci
   set cci.fat_cci_fl_status = 'C',
       cci.seg_usu_id_usuario = pSEG_USU_ID_USUARIO,
       cci.fat_cci_dt_ultima_atualizacao = sysdate
    where 
       cci.atd_ate_id = pATD_ATE_ID
       and cci.cad_pac_id_paciente = pCAD_PAC_ID_PACIENTE
       and cci.fat_cci_id_principal = pFAT_CCI_ID_PRINCIPAL
       and cci.fat_ccp_id = pFAT_CCP_ID
       and cci.cad_nfm_id is null;                        
end if;
END PRC_FAT_CCI_ATUALIZARMM_AUD;
 