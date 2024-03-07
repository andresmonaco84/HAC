CREATE OR REPLACE PROCEDURE "PRC_COB_MGC_L"
(
     pCAD_CNV_ID_CONVENIO IN TB_FAT_NOF_NOTA_FISCAL.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     pASS_BCT_ID IN TB_COB_MGC_MOV_GUIA_COBRANCA.ASS_BCT_ID%TYPE DEFAULT NULL,
     pDATA_INI IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_MOVIMENTO%TYPE DEFAULT NULL,
     pDATA_FIM IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_DT_MOVIMENTO%TYPE DEFAULT NULL,
     pFAT_NOF_NR_NOTAFISCAL IN TB_FAT_NOF_NOTA_FISCAL.FAT_NOF_NR_NOTAFISCAL%TYPE DEFAULT NULL,
     pFAT_NOF_TP_SERIEFISCAL IN TB_FAT_NOF_NOTA_FISCAL.FAT_NOF_TP_SERIEFISCAL%TYPE DEFAULT NULL,
     pNAO_MARCADOS VARCHAR2 DEFAULT NULL,
     pCAD_TMC_ID IN TB_COB_MGC_MOV_GUIA_COBRANCA.CAD_TMC_ID%TYPE DEFAULT NULL,
     pCOB_MGC_NR_NOTA_CREDITO IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_NR_NOTA_CREDITO%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_COB_MGC_L
*
*    Data Criacao:   19/06/2012    Por: PEDRO
*    Data Alteracao:
*
*    Funcao: Lista MGC
*******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       CCP.ATD_GUI_CD_CODIGO,
       CCP.ATD_GUI_CD_SENHA,
       CCP.CAD_PAC_CD_CREDENCIAL,
       CCP.CAD_PES_NM_PESSOA,
       CCP.ATD_ATE_ID,
       CCP.COB_CCP_VL_TOT_CONTA,
       NVL(MGC.COB_MGC_VL_MOVIMENTO,0) + NVL(MGC.COB_MGC_VL_ISS,0) + NVL(MGC.COB_MGC_VL_IR,0) + NVL(MGC.COB_MGC_VL_CSLL,0) +
                                     NVL(MGC.COB_MGC_VL_PIS,0) + NVL(MGC.COB_MGC_VL_COFINS,0) VALOR_DIGITADO, --vl calculado na tela
       NVL(MGC.COB_MGC_VL_MOVIMENTO,0) COB_MGC_VL_MOVIMENTO,
       NVL(MGC.COB_MGC_PC_ISS,0) COB_MGC_PC_ISS,
       NVL(MGC.COB_MGC_VL_ISS,0) COB_MGC_VL_ISS,
       NVL(MGC.COB_MGC_PC_IR,0) COB_MGC_PC_IR,
       NVL(MGC.COB_MGC_VL_IR,0) COB_MGC_VL_IR,
       NVL(MGC.COB_MGC_PC_CSLL,0) COB_MGC_PC_CSLL,
       NVL(MGC.COB_MGC_VL_CSLL,0) COB_MGC_VL_CSLL,
       NVL(MGC.COB_MGC_PC_PIS,0) COB_MGC_PC_PIS,
       NVL(MGC.COB_MGC_VL_PIS,0) COB_MGC_VL_PIS,
       NVL(MGC.COB_MGC_PC_COFINS,0) COB_MGC_PC_COFINS,
       NVL(MGC.COB_MGC_VL_COFINS,0) COB_MGC_VL_COFINS,
       BAN.CAD_BAN_CD_BANCO || ' - ' || BAN.CAD_BAN_NM_BANCO CAD_BAN_NM_BANCO,
       BCT.ASS_BCT_CD_AGENCIA || ' / ' || BCT.ASS_BCT_NR_CONTA ASS_BCT_NR_CONTA,
       TMC.CAD_TMC_DS_DESCRICAO,
       MGC.SEG_USU_ID_USUARIO_REG,
       USU1.SEG_USU_DS_NOME SEG_USU_DS_NOME_REG,
       MGC.COB_MGC_DT_ULTIMA_ATUALIZACAO,
       USU2.SEG_USU_DS_NOME SEG_USU_DS_NOME_ATUALIZ,
       CCP.COB_CCP_ID,
       CCP.COB_CCP_DT_PARCELA,
       MGC.COB_MGC_NR_NOTA_CREDITO,
       MGC.COB_MGC_NR_PROT_PROTESTO,
       MGC.CAD_MGC_DT_REGISTRO,
       MGC.COB_MGC_ID,
       MGC.CAD_TMC_ID,
       MGC.COB_MGC_DT_MOVIMENTO,
       MGC.SEG_USU_ID_USUARIO_ATUALIZ,
       MGC.COB_MGC_DS_MOTIVO_BAIXA,
       MGC.COB_MGC_DT_LIBERACAO_CONTAB,
       MGC.ASS_BCT_ID,
       MGC.COB_COC_ID,
       MGC.CAD_PAC_ID_PACIENTE,
       NVL(SUM(MGC.COB_MGC_VL_MOVIMENTO) OVER (),0) TOTAL_VL_MOVIMENTO,
       SUM( NVL(MGC.COB_MGC_VL_MOVIMENTO,0) +  NVL(MGC.COB_MGC_VL_ISS,0) +  NVL(MGC.COB_MGC_VL_IR,0) +  NVL(MGC.COB_MGC_VL_CSLL,0) +
                                      NVL(MGC.COB_MGC_VL_PIS,0) +  NVL(MGC.COB_MGC_VL_COFINS,0)) OVER () TOTAL_VALOR_DIGITADO,
       SUM( NVL(MGC.COB_MGC_VL_MOVIMENTO,0) +  NVL(MGC.COB_MGC_VL_ISS,0) +  NVL(MGC.COB_MGC_VL_IR,0) +  NVL(MGC.COB_MGC_VL_CSLL,0) +
                                      NVL(MGC.COB_MGC_VL_PIS,0) +  NVL(MGC.COB_MGC_VL_COFINS,0)) OVER ()
                                      -  NVL(SUM(MGC.COB_MGC_VL_MOVIMENTO) OVER (),0) TOTAL_RETENCOES,
       NVL(SUM(NOF.FAT_NFO_VL_FATURADO) OVER(),0)  TOTAL_VALOR_GUIAS,
       NVL(SUM(MGC.COB_MGC_VL_ISS) OVER (),0) TOTAL_VALOR_ISS,
       NVL(SUM(MGC.COB_MGC_VL_IR) OVER (),0) TOTAL_VALOR_IRRF,
       NVL(SUM(MGC.COB_MGC_VL_CSLL) OVER (),0) TOTAL_VALOR_CSLL,
       NVL(SUM(MGC.COB_MGC_VL_PIS) OVER (),0) TOTAL_VALOR_PIS,
       NVL(SUM(MGC.COB_MGC_VL_COFINS) OVER (),0) TOTAL_VALOR_COFINS,
       CCP.ATD_GUI_DT_VALIDADE,
       NOF.FAT_NOF_ID,
       NOF.FAT_NOF_NR_NOTAFISCAL,
       NOF.FAT_NOF_TP_SERIEFISCAL,
       NOF.FAT_NFO_DT_EMISSAO,
       NOF.FAT_NFO_DT_VENCIMENTO,
       NOF.FAT_NOF_MES_FAT,
       NOF.FAT_NOF_ANO_FAT,
       NOF.FAT_NFO_VL_FATURADO,
       NOF.FAT_NFO_VL_RETENCAO,
       NOF.FAT_NFO_VL_LIQUIDO,
       NOF.FAT_NOF_VL_IR,
       NOF.FAT_NOF_PC_IR,
       NOF.FAT_NOF_VL_ISS,
       NOF.FAT_NOF_PC_ISS,
       NOF.FAT_NOF_VL_COFINS,
       NOF.FAT_NOF_PC_COFINS,
       NOF.FAT_NOF_VL_CSLL,
       NOF.FAT_NOF_PC_CSLL,
       NOF.FAT_NOF_VL_PIS,
       NOF.FAT_NOF_PC_PIS,
       NOF.FAT_NOF_VL_DESCONTO,
       NOF.FAT_NOF_DS_DESCONTO,
       NOF.FAT_NOF_FL_JURIDICA,
       NOF.FAT_NOF_NR_DOCUMENTO,
       NOF.FAT_NFO_FL_LIBERADO_COB,
       NOF.FAT_NOF_DT_LIBERA_COBRANCA,
       NOF.FAT_NOF_FL_LIBERA_PROTOCOLO,
       NOF.FAT_NOF_DT_LIBERA_PROTOCOLO,
       NOF.FAT_NOF_FL_ENVIO_ELET_REALIZ,
       NOF.FAT_NOF_DT_ENVIO_ELETR_REALIZ,
       BCT.CAD_BAN_ID,
       BCT.ASS_BCT_CD_CTA_CAIXA_RM,
       NULL CAD_PAC_NR_PRONTUARIO,
       NULL CAD_PES_DT_NASCIMENTO,
       NULL CAD_PES_TP_SEXO,
       CASE WHEN ROUND(TOTAL_GUIA.SOMA_VL_MOVIMENTO - NC_GUIA.SOMA_VL_MOVIMENTO,2) >= CCP.COB_CCP_VL_TOT_CONTA THEN 'BAIXA'
            WHEN ROUND(TOTAL_GUIA.SOMA_VL_MOVIMENTO - NC_GUIA.SOMA_VL_MOVIMENTO,2) > 0 THEN 'BAIXA PARCIAL'
            ELSE 'PENDENTE' END TIPO_PAGAMENTO
FROM      TB_FAT_NOF_NOTA_FISCAL       NOF
JOIN      TB_COB_CCP_CONTA_CONS_PARC   CCP  ON  CCP.FAT_NOF_ID          = NOF.FAT_NOF_ID
--JOIN      TB_CAD_PAC_PACIENTE          PAC  ON  PAC.CAD_PAC_ID_PACIENTE = CCP.CAD_PAC_ID_PACIENTE
--JOIN      TB_CAD_PES_PESSOA            PES  ON  PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
JOIN      TB_COB_MGC_MOV_GUIA_COBRANCA MGC  ON  MGC.FAT_NOF_ID          = CCP.FAT_NOF_ID
                                           AND  MGC.ATD_ATE_ID          = CCP.ATD_ATE_ID
                                           AND  MGC.CAD_PAC_ID_PACIENTE = CCP.CAD_PAC_ID_PACIENTE
                                           AND  MGC.COB_COC_ID          = CCP.COB_COC_ID
                                           AND  MGC.ATD_GUI_CD_CODIGO   = CCP.ATD_GUI_CD_CODIGO
                                           AND  MGC.ATD_GUI_DT_VALIDADE = CCP.ATD_GUI_DT_VALIDADE
                                           AND  MGC.COB_CCP_ID          = CCP.COB_CCP_ID
JOIN      TB_CAD_TMC_TIPO_MOV_COBRANCA TMC  ON  TMC.CAD_TMC_ID          = MGC.CAD_TMC_ID
JOIN      TB_ASS_BCT_BANCO_CONTA       BCT  ON  BCT.ASS_BCT_ID          = MGC.ASS_BCT_ID
JOIN      TB_CAD_BAN_BANCO             BAN  ON  BAN.CAD_BAN_ID          = BCT.CAD_BAN_ID
JOIN      TB_SEG_USU_USUARIO           USU1 ON  USU1.SEG_USU_ID_USUARIO = MGC.SEG_USU_ID_USUARIO_REG
JOIN      TB_SEG_USU_USUARIO           USU2 ON  USU2.SEG_USU_ID_USUARIO = MGC.SEG_USU_ID_USUARIO_ATUALIZ
LEFT JOIN (SELECT SUM(MGC.COB_MGC_VL_MOVIMENTO) SOMA_VL_MOVIMENTO,MGC.FAT_NOF_ID,MGC.ATD_ATE_ID,MGC.CAD_PAC_ID_PACIENTE,MGC.COB_COC_ID,
          MGC.COB_CCP_ID,MGC.ATD_GUI_CD_CODIGO,MGC.ATD_GUI_DT_VALIDADE--,MGC.CAD_TMC_ID,MGC.COB_MGC_DT_MOVIMENTO
          FROM TB_COB_MGC_MOV_GUIA_COBRANCA MGC WHERE MGC.CAD_TMC_ID != 2 --AND MGC.FAT_NOF_ID = idtNotaFiscal
          GROUP BY MGC.FAT_NOF_ID,MGC.ATD_ATE_ID,MGC.CAD_PAC_ID_PACIENTE,MGC.COB_COC_ID,MGC.COB_CCP_ID,MGC.ATD_GUI_CD_CODIGO,MGC.ATD_GUI_DT_VALIDADE
          ) TOTAL_GUIA                      ON  TOTAL_GUIA.FAT_NOF_ID          = CCP.FAT_NOF_ID
                                            AND TOTAL_GUIA.ATD_ATE_ID          = CCP.ATD_ATE_ID
                                            AND TOTAL_GUIA.CAD_PAC_ID_PACIENTE = CCP.CAD_PAC_ID_PACIENTE
                                            AND TOTAL_GUIA.COB_COC_ID          = CCP.COB_COC_ID
                                            AND TOTAL_GUIA.COB_CCP_ID          = CCP.COB_CCP_ID
                                            AND TOTAL_GUIA.ATD_GUI_CD_CODIGO   = CCP.ATD_GUI_CD_CODIGO
                                            AND TOTAL_GUIA.ATD_GUI_DT_VALIDADE = CCP.ATD_GUI_DT_VALIDADE
LEFT JOIN (SELECT SUM(MGC.COB_MGC_VL_MOVIMENTO) SOMA_VL_MOVIMENTO,MGC.FAT_NOF_ID,MGC.ATD_ATE_ID,MGC.CAD_PAC_ID_PACIENTE,MGC.COB_COC_ID,
          MGC.COB_CCP_ID,MGC.ATD_GUI_CD_CODIGO,MGC.ATD_GUI_DT_VALIDADE--,MGC.CAD_TMC_ID,MGC.COB_MGC_DT_MOVIMENTO
          FROM TB_COB_MGC_MOV_GUIA_COBRANCA MGC WHERE MGC.CAD_TMC_ID = 2 --AND MGC.FAT_NOF_ID = idtNotaFiscal
          GROUP BY MGC.FAT_NOF_ID,MGC.ATD_ATE_ID,MGC.CAD_PAC_ID_PACIENTE,MGC.COB_COC_ID,MGC.COB_CCP_ID,MGC.ATD_GUI_CD_CODIGO,MGC.ATD_GUI_DT_VALIDADE
          ) NC_GUIA                         ON  NC_GUIA.FAT_NOF_ID          = CCP.FAT_NOF_ID
                                            AND NC_GUIA.ATD_ATE_ID          = CCP.ATD_ATE_ID
                                            AND NC_GUIA.CAD_PAC_ID_PACIENTE = CCP.CAD_PAC_ID_PACIENTE
                                            AND NC_GUIA.COB_COC_ID          = CCP.COB_COC_ID
                                            AND NC_GUIA.COB_CCP_ID          = CCP.COB_CCP_ID
                                            AND NC_GUIA.ATD_GUI_CD_CODIGO   = CCP.ATD_GUI_CD_CODIGO
                                            AND NC_GUIA.ATD_GUI_DT_VALIDADE = CCP.ATD_GUI_DT_VALIDADE
WHERE  CCP.COB_CCP_FL_STATUS   = 'A'
AND    NOF.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
AND    MGC.COB_MGC_DT_MOVIMENTO >= pDATA_INI
AND    MGC.COB_MGC_DT_MOVIMENTO <= pDATA_FIM
AND    (pASS_BCT_ID IS NULL OR MGC.ASS_BCT_ID = pASS_BCT_ID)
AND    ((pNAO_MARCADOS IS NOT NULL AND MGC.COB_MGC_DT_LIBERACAO_CONTAB IS NULL) OR pNAO_MARCADOS IS NULL)
AND    (pFAT_NOF_NR_NOTAFISCAL IS NULL OR NOF.FAT_NOF_NR_NOTAFISCAL = pFAT_NOF_NR_NOTAFISCAL)
AND    (pFAT_NOF_TP_SERIEFISCAL IS NULL OR NOF.FAT_NOF_TP_SERIEFISCAL = pFAT_NOF_TP_SERIEFISCAL)
AND    (pCAD_TMC_ID IS NULL OR MGC.CAD_TMC_ID = pCAD_TMC_ID)
AND    (pCOB_MGC_NR_NOTA_CREDITO IS NULL OR MGC.COB_MGC_NR_NOTA_CREDITO = pCOB_MGC_NR_NOTA_CREDITO)
ORDER BY CCP.CAD_PES_NM_PESSOA,MGC.COB_MGC_DT_MOVIMENTO,TMC.CAD_TMC_DS_DESCRICAO
;
  io_cursor := v_cursor;
end PRC_COB_MGC_L;
