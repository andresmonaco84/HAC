CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_REC_TP_CONSUMO_L"
(      pCAD_TAP_TP_ATRIBUTO_TAX IN TB_CAD_PRD_PRODUTO.CAD_TAP_TP_ATRIBUTO%TYPE DEFAULT NULL,
       pCAD_TAP_TP_ATRIBUTO_DIA IN TB_CAD_PRD_PRODUTO.CAD_TAP_TP_ATRIBUTO%TYPE DEFAULT NULL,
       pCAD_TAP_TP_ATRIBUTO_MAT IN TB_CAD_PRD_PRODUTO.CAD_TAP_TP_ATRIBUTO%TYPE DEFAULT NULL,
       pCAD_TAP_TP_ATRIBUTO_MED IN TB_CAD_PRD_PRODUTO.CAD_TAP_TP_ATRIBUTO%TYPE DEFAULT NULL,
       pCAD_TAP_TP_ATRIBUTO_HM IN TB_CAD_PRD_PRODUTO.CAD_TAP_TP_ATRIBUTO%TYPE DEFAULT NULL,
       pCAD_TAP_TP_ATRIBUTO_EXA IN TB_CAD_PRD_PRODUTO.CAD_TAP_TP_ATRIBUTO%TYPE DEFAULT NULL,
       pCAD_TAP_TP_ATRIBUTO_GAS IN TB_CAD_PRD_PRODUTO.CAD_TAP_TP_ATRIBUTO%TYPE DEFAULT NULL,
       pCAD_TAP_TP_ATRIBUTO_PAC IN TB_CAD_PRD_PRODUTO.CAD_TAP_TP_ATRIBUTO%TYPE DEFAULT NULL,
       pFAT_CCP_MES_COMPET IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_MES_COMPET%TYPE DEFAULT NULL,
       pFAT_CCP_ANO_COMPET IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ANO_COMPET %TYPE DEFAULT NULL,
       pCAD_CNV_ID_CONVENIO IN tb_cad_cnv_convenio.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
       pATD_ATE_DT_ATENDIMENTO_INI IN tb_fat_cci_conta_consu_item.fat_cci_dt_inicio_consumo%TYPE DEFAULT NULL,
       pATD_ATE_DT_ATENDIMENTO_FIM IN tb_fat_cci_conta_consu_item.fat_cci_dt_fim_consumo%TYPE DEFAULT NULL,
       pFATURADO   varchar2 default null,
       pLOTEGERADO varchar2 default null,
       pEMITIDO    varchar2 default null,
       pDIGITADO   varchar2 default null,
       pAUDITORIA  varchar2 default null,
       io_cursor OUT PKG_CURSOR.t_cursor
)
is
  /********************************************************************
*    Procedure:       PRC_FAT_REL_REC_TP_CONSUMO_L
*   Data Alteracao: 05/09/2013  Por: Pedro
*   Alterac?o: tudo 
*
*    Funcao: Listar Receita por Tipo de Consumo
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
select 
        prd.cad_prd_cd_codigo,
        prd.cad_prd_ds_descricao,
        cci.cad_tap_tp_atributo,
        tap.cad_tap_ds_atributo,
        ccp.fat_ccp_mes_compet,
        ccp.fat_ccp_ano_compet,
        count(*)  as quantidade,
        sum(cci.fat_cci_vl_faturado) as valor
 FROM    TB_FAT_CCI_CONTA_CONSU_ITEM  CCI
    JOIN TB_FAT_CCP_CONTA_CONS_PARC   CCP
    ON      CCP.FAT_CCP_ID             = CCI.FAT_CCP_ID
    AND     CCP.ATD_ATE_ID             = CCI.ATD_ATE_ID
    AND     CCP.FAT_COC_ID             = CCI.FAT_COC_ID
    AND     CCP.CAD_PAC_ID_PACIENTE    = CCI.CAD_PAC_ID_PACIENTE
    AND     CCP.FAT_CCP_FL_STATUS      = 'A'
    JOIN    TB_CAD_PRD_PRODUTO           PRD
    ON      PRD.CAD_PRD_ID             = CCI.CAD_PRD_ID
    JOIN    TB_CAD_TAP_TP_ATRIB_PRODUTO  TAP
    ON      PRD.CAD_TAP_TP_ATRIBUTO    = TAP.CAD_TAP_TP_ATRIBUTO   
    JOIN    TB_CAD_CNV_CONVENIO          CNV
    ON      CNV.CAD_CNV_ID_CONVENIO    = CCI.CAD_CNV_ID_CONVENIO
    
    WHERE  (CCI.FAT_CCI_FL_STATUS      = 'A')

     AND     (( pFATURADO  IS NOT NULL AND CCP.FAT_NOF_ID IS NOT NULL )
        OR  ( pAUDITORIA  IS NOT NULL AND CCP.FAT_CCP_FL_STATUS_AUDIT =  'E' )
        OR  ( pLOTEGERADO  IS NOT NULL AND CCP.FAT_CCP_FL_FATURADA =  'S'  AND CCP.FAT_NOF_ID IS NULL)
        OR  ( pEMITIDO  IS NOT NULL AND CCP.FAT_CCP_FL_EMITIDA =  'S'  AND CCP.FAT_CCP_FL_FATURADA = 'N' 
            AND (CCP.FAT_CCP_FL_STATUS_AUDIT =  'A'  OR CCP.FAT_CCP_DT_ENVIO_AUDIT IS NULL))
       -- OR  ( pDIGITADO  IS NOT NULL AND CCI.FAT_CCP_ID IS NULL)
       )
    and  (
        (pATD_ATE_DT_ATENDIMENTO_INI IS NULL and pATD_ATE_DT_ATENDIMENTO_FIM IS NULL) OR
        (cci.fat_cci_dt_inicio_consumo between pATD_ATE_DT_ATENDIMENTO_INI and pATD_ATE_DT_ATENDIMENTO_FIM)
        )
and       (pCAD_TAP_TP_ATRIBUTO_TAX IS not NULL and cci.cad_tap_tp_atributo = 'TAX'
        OR pCAD_TAP_TP_ATRIBUTO_DIA IS NOT NULL AND cci.cad_tap_tp_atributo = 'DIA'
        OR pCAD_TAP_TP_ATRIBUTO_MAT IS NOT NULL AND cci.cad_tap_tp_atributo = 'MAT'
        OR pCAD_TAP_TP_ATRIBUTO_MED IS NOT NULL AND cci.cad_tap_tp_atributo = 'MED'
        OR pCAD_TAP_TP_ATRIBUTO_HM IS NOT NULL AND cci.cad_tap_tp_atributo = 'HM'
        OR pCAD_TAP_TP_ATRIBUTO_EXA IS NOT NULL AND cci.cad_tap_tp_atributo = 'EXA'
        OR pCAD_TAP_TP_ATRIBUTO_GAS IS NOT NULL AND cci.cad_tap_tp_atributo = 'GAS'
        OR pCAD_TAP_TP_ATRIBUTO_PAC IS NOT NULL AND cci.cad_tap_tp_atributo = 'PAC')
and     (PCAD_CNV_ID_CONVENIO IS NULL OR CCI.CAD_CNV_ID_CONVENIO = PCAD_CNV_ID_CONVENIO)
AND     (CCP.FAT_CCP_MES_COMPET = PFAT_CCP_MES_COMPET)
AND     (CCP.FAT_CCP_ANO_COMPET = PFAT_CCP_ANO_COMPET)
AND     (CCI.FAT_CCI_FL_PACOTE = 'N' OR CCI.FAT_CCI_FL_PACOTE IS NULL)
AND     (CCI.FAT_CCI_TP_DESTINO_ITEM != 'H')
GROUP   BY PRD.CAD_PRD_CD_CODIGO,PRD.CAD_PRD_DS_DESCRICAO, CCP.FAT_CCP_ANO_COMPET,
        CCP.FAT_CCP_MES_COMPET,CCI.CAD_TAP_TP_ATRIBUTO,TAP.CAD_TAP_DS_ATRIBUTO
ORDER   BY TAP.CAD_TAP_DS_ATRIBUTO, PRD.CAD_PRD_DS_DESCRICAO,PRD.CAD_PRD_CD_CODIGO;
IO_CURSOR := V_CURSOR;
END PRC_FAT_REL_REC_TP_CONSUMO_L;
 