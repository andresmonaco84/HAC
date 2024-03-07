CREATE OR REPLACE PROCEDURE "PRC_COB_CONFERENCIA"
(
    pCOB_TXT_ID IN TB_COB_TXT_COBRANCA.COB_TXT_ID%TYPE,

    IO_CURSOR OUT PKG_CURSOR.T_CURSOR
    --, TESTE OUT LONG
)
IS
/********************************************************************
*    PROCEDURE: PRC_COB_CONFERENCIA
*
*    Data Alteração: 16/07/2013 Por: Pedro
*    Alteração:
*
******************************************************************\*/
 V_CURSOR                       PKG_CURSOR.T_CURSOR;
 V_DATA_PAGAMENTO_TXT           DATE;
 V_IDT_PESSOA_CONVENIO          NUMBER;
 
BEGIN
 SELECT TXT.CAD_PES_ID_PESSOA,TXT.COB_TXT_DT_PAGTO INTO V_IDT_PESSOA_CONVENIO, V_DATA_PAGAMENTO_TXT FROM TB_COB_TXT_COBRANCA TXT WHERE TXT.COB_TXT_ID = pCOB_TXT_ID AND ROWNUM =1;
      
   
  -- TESTE :=  V_SELECT ;
  OPEN v_cursor FOR
              SELECT 'IMPORTACAO' TABELA,
                     TXT.FAT_NOF_ID, NOF.FAT_NOF_NR_NOTAFISCAL, NOF.FAT_NOF_TP_SERIEFISCAL, TXT.COB_TXT_DT_PAGTO COB_TXT_DT_PAGTO,
                     TXT.CAD_PES_ID_PESSOA,
                     TXT.ATD_ATE_ID,
                     TXT.COB_TXT_NM_BENEF CAD_PES_NM_PESSOA,
                     SUM(NVL(TXT.COB_TXT_VL_MOVIMENTO,0)) COB_TXT_VL_MOVIMENTO,
                     SUM(NVL(TXT.COB_TXT_VL_ISS,0)) COB_TXT_VL_ISS,
                     SUM(NVL(TXT.COB_TXT_VL_IR,0)) COB_TXT_VL_IR,
                     SUM(NVL(TXT.COB_TXT_VL_CSLL,0)) COB_TXT_VL_CSLL,
                     SUM(NVL(TXT.COB_TXT_VL_PIS,0)) COB_TXT_VL_PIS,
                     SUM(NVL(TXT.COB_TXT_VL_COFINS,0)) COB_TXT_VL_COFINS
                     
             FROM    TB_COB_TXT_COBRANCA          TXT
             JOIN    TB_FAT_NOF_NOTA_FISCAL       NOF ON NOF.FAT_NOF_ID          = TXT.FAT_NOF_ID 
             WHERE   TXT.COB_TXT_ID = pCOB_TXT_ID
               AND    TXT.ATD_ATE_ID          IN
                                 (SELECT ATD_ATE_ID FROM              
                                  (SELECT 
                                         TXT.FAT_NOF_ID,TXT.COB_TXT_DT_PAGTO, TXT.CAD_PES_ID_PESSOA, TXT.ATD_ATE_ID,
                                         SUM(NVL(TXT.COB_TXT_VL_MOVIMENTO,0)),
                                         SUM(NVL(TXT.COB_TXT_VL_PIS,0)),
                                         SUM(NVL(TXT.COB_TXT_VL_COFINS,0)),
                                         SUM(NVL(TXT.COB_TXT_VL_CSLL,0)),
                                         SUM(NVL(TXT.COB_TXT_VL_IR,0)),
                                         SUM(NVL(TXT.COB_TXT_VL_ISS,0))
                                 FROM    TB_COB_TXT_COBRANCA TXT 
                                 WHERE   TXT.COB_TXT_ID = pCOB_TXT_ID                           
                                GROUP BY TXT.FAT_NOF_ID, TXT.COB_TXT_DT_PAGTO, TXT.ATD_ATE_ID, TXT.CAD_PES_ID_PESSOA
                                   MINUS
                                   SELECT 
                                          MGC.FAT_NOF_ID,MGC.COB_MGC_DT_MOVIMENTO, CNV.CAD_PES_ID_PESSOA, MGC.ATD_ATE_ID,
                                          SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0)),
                                          SUM(NVL(MGC.COB_MGC_VL_PIS,0)),
                                          SUM(NVL(MGC.COB_MGC_VL_COFINS,0)),
                                          SUM(NVL(MGC.COB_MGC_VL_CSLL,0)),
                                          SUM(NVL(MGC.COB_MGC_VL_IR,0)),
                                          SUM(NVL(MGC.COB_MGC_VL_ISS,0))
                                    FROM  TB_COB_MGC_MOV_GUIA_COBRANCA MGC 
                                    JOIN  TB_FAT_NOF_NOTA_FISCAL       NOF ON NOF.FAT_NOF_ID          = MGC.FAT_NOF_ID
                                    JOIN  TB_CAD_CNV_CONVENIO          CNV ON CNV.CAD_CNV_ID_CONVENIO = NOF.CAD_CNV_ID_CONVENIO
                                    WHERE 
                                          CNV.CAD_PES_ID_PESSOA    = V_IDT_PESSOA_CONVENIO
                                      AND MGC.COB_MGC_DT_MOVIMENTO = V_DATA_PAGAMENTO_TXT
                                    GROUP BY  MGC.FAT_NOF_ID, MGC.COB_MGC_DT_MOVIMENTO, MGC.ATD_ATE_ID, CNV.CAD_PES_ID_PESSOA
                              ))    
              GROUP BY TXT.FAT_NOF_ID, NOF.FAT_NOF_NR_NOTAFISCAL, NOF.FAT_NOF_TP_SERIEFISCAL, TXT.COB_TXT_DT_PAGTO, TXT.COB_TXT_NM_BENEF, TXT.ATD_ATE_ID, TXT.CAD_PES_ID_PESSOA
              
             UNION ALL
             
               SELECT 'PAGAMENTO' TABELA,
                      MGC.FAT_NOF_ID,NOF.FAT_NOF_NR_NOTAFISCAL, NOF.FAT_NOF_TP_SERIEFISCAL,MGC.COB_MGC_DT_MOVIMENTO,
                      CNV.CAD_PES_ID_PESSOA,
                      MGC.ATD_ATE_ID,
                      PES.CAD_PES_NM_PESSOA,
                      SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0)),
                      SUM(NVL(MGC.COB_MGC_VL_ISS,0)),
                      SUM(NVL(MGC.COB_MGC_VL_IR,0)),
                      SUM(NVL(MGC.COB_MGC_VL_CSLL,0)),
                      SUM(NVL(MGC.COB_MGC_VL_PIS,0)),
                      SUM(NVL(MGC.COB_MGC_VL_COFINS,0))
                      
                FROM  TB_COB_MGC_MOV_GUIA_COBRANCA MGC 
                JOIN  TB_FAT_NOF_NOTA_FISCAL       NOF ON NOF.FAT_NOF_ID          = MGC.FAT_NOF_ID
                JOIN  TB_CAD_CNV_CONVENIO          CNV ON CNV.CAD_CNV_ID_CONVENIO = NOF.CAD_CNV_ID_CONVENIO
                JOIN  TB_CAD_PAC_PACIENTE          PAC ON PAC.CAD_PAC_ID_PACIENTE = MGC.CAD_PAC_ID_PACIENTE
                JOIN  TB_CAD_PES_PESSOA            PES ON PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
                WHERE 
                      CNV.CAD_PES_ID_PESSOA    = V_IDT_PESSOA_CONVENIO
                  AND MGC.COB_MGC_DT_MOVIMENTO = V_DATA_PAGAMENTO_TXT
                  AND MGC.ATD_ATE_ID IN 
                            (SELECT ATD_ATE_ID FROM              
                                (SELECT 
                                       TXT.FAT_NOF_ID,TXT.COB_TXT_DT_PAGTO,
                                       TXT.CAD_PES_ID_PESSOA,
                                       TXT.ATD_ATE_ID,
                                       SUM(NVL(TXT.COB_TXT_VL_MOVIMENTO,0)),
                                       SUM(NVL(TXT.COB_TXT_VL_PIS,0)),
                                       SUM(NVL(TXT.COB_TXT_VL_COFINS,0)),
                                       SUM(NVL(TXT.COB_TXT_VL_CSLL,0)),
                                       SUM(NVL(TXT.COB_TXT_VL_IR,0)),
                                       SUM(NVL(TXT.COB_TXT_VL_ISS,0))
                               FROM    TB_COB_TXT_COBRANCA TXT 
                               WHERE   TXT.COB_TXT_ID = pCOB_TXT_ID
                              GROUP BY TXT.FAT_NOF_ID, TXT.COB_TXT_DT_PAGTO, TXT.ATD_ATE_ID, TXT.CAD_PES_ID_PESSOA
                                 MINUS
                                 SELECT 
                                        MGC.FAT_NOF_ID,MGC.COB_MGC_DT_MOVIMENTO,
                                        CNV.CAD_PES_ID_PESSOA,
                                        MGC.ATD_ATE_ID,
                                        SUM(NVL(MGC.COB_MGC_VL_MOVIMENTO,0)),
                                        SUM(NVL(MGC.COB_MGC_VL_PIS,0)),
                                        SUM(NVL(MGC.COB_MGC_VL_COFINS,0)),
                                        SUM(NVL(MGC.COB_MGC_VL_CSLL,0)),
                                        SUM(NVL(MGC.COB_MGC_VL_IR,0)),
                                        SUM(NVL(MGC.COB_MGC_VL_ISS,0))
                                  FROM  TB_COB_MGC_MOV_GUIA_COBRANCA MGC 
                                  JOIN  TB_FAT_NOF_NOTA_FISCAL       NOF ON NOF.FAT_NOF_ID          = MGC.FAT_NOF_ID
                                  JOIN  TB_CAD_CNV_CONVENIO          CNV ON CNV.CAD_CNV_ID_CONVENIO = NOF.CAD_CNV_ID_CONVENIO
                                  WHERE  
                                        CNV.CAD_PES_ID_PESSOA    = V_IDT_PESSOA_CONVENIO
                                    AND MGC.COB_MGC_DT_MOVIMENTO = V_DATA_PAGAMENTO_TXT
                                  GROUP BY  MGC.FAT_NOF_ID, MGC.COB_MGC_DT_MOVIMENTO, MGC.ATD_ATE_ID, CNV.CAD_PES_ID_PESSOA
                        ))    
                GROUP BY  MGC.FAT_NOF_ID,NOF.FAT_NOF_NR_NOTAFISCAL, NOF.FAT_NOF_TP_SERIEFISCAL, MGC.COB_MGC_DT_MOVIMENTO, MGC.ATD_ATE_ID, PES.CAD_PES_NM_PESSOA, CNV.CAD_PES_ID_PESSOA
             ORDER BY 2,7,1
              
   ;
io_cursor := v_cursor;

END PRC_COB_CONFERENCIA;
