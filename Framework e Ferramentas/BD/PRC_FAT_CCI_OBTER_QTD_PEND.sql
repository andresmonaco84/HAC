CREATE OR REPLACE PROCEDURE PRC_FAT_CCI_OBTER_QTD_PEND
(
       pFAT_FCL_NR_SEQ_LOTE IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_NR_SEQ_LOTE%type default null,
       pDATA IN DATE,
       nRETORNO OUT INT
)
is
/********************************************************************
*    Procedure: PRC_FAT_CCI_OBTER_QTD_PENDENCIAS
*
*    Data Criacao:   06/01/2011   Por: Rafael Coimbra
*
*    Funcao: Verifica se um atendimento tem itens pedentes para
*            definir exibição de relatório na tela de Emissão de 
*            Conta
*
*******************************************************************/
BEGIN
  SELECT 
       COUNT(CCI.FAT_CCI_ID) INTO nRETORNO
  FROM 
         TB_FAT_CCI_CONTA_CONSU_ITEM CCI
  INNER JOIN TB_CAD_MPF_MOTI_PEND_FATURAR MPF
        ON CCI.CAD_MPF_ID = MPF.CAD_MPF_ID
  INNER JOIN TB_FAT_FCL_CONTR_EMI_LOTE FCL
        ON CCI.ATD_ATE_ID = FCL.ATD_ATE_ID
        AND CCI.CAD_PAC_ID_PACIENTE = FCL.CAD_PAC_ID_PACIENTE
  WHERE
        MPF.CAD_MPF_FL_MOTIVO = 'P'
        AND FCL.FAT_FCL_NR_SEQ_LOTE = pFAT_FCL_NR_SEQ_LOTE
        AND fnc_juntar_data_hora(CCI.FAT_CCI_DT_INICIO_CONSUMO, CCI.FAT_CCI_HR_INICIO_CONSUMO) <= pDATA;
EXCEPTION
WHEN NO_DATA_FOUND THEN
     nRETORNO := 0;
end PRC_FAT_CCI_OBTER_QTD_PEND;
/
