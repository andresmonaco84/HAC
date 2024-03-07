CREATE OR REPLACE PROCEDURE SGS."PRC_FAT_LOTE_LOTE_L" (pCAD_UNI_ID_UNIDADE           TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
                                                  pCAD_LAT_ID_LOCAL_ATENDIMENTO VARCHAR2 DEFAULT NULL,
                                                  pCAD_SET_ID                   TB_ATD_ATE_ATENDIMENTO.CAD_SET_ID%TYPE DEFAULT NULL,
                                                  pATD_ATE_DT_ATENDIMENTO       TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
                                                  pCAD_CNV_ID_CONVENIO          TB_CAD_PAC_PACIENTE.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
                                                  pFAT_LNF_ID                   TB_FAT_LNF_LOTE_CTA_PARC_NF.FAT_LNF_ID%TYPE DEFAULT NULL,
                                                  pCOM_NOTA_FISCAL              DECIMAL DEFAULT NULL, -- Se igual a 1 traz registros com nota fiscal, se n?o sem nota fiscal
                                                  IO_CURSOR                     OUT PKG_CURSOR.T_CURSOR) IS
  /********************************************************************
  *    Procedure: PRC_FAT_LOTE_GERALOTE_L
  *
  *    Data Criacao:   data da criac?o   Por: Nome do Analista
  *
  *    Data Alteracao: 12/07/2010        Por: Fabiola Lopes
  *    Alteracao: Retirei a tabela PAT conforme definic?o junto com a Silmara (para identificac?o do paciente)
  *
  *    Data Alteracao: 22/07/2010        Por: Fabiola Lopes
  *    Alteracao: Inclus?o do join entre as tabelas CCP e PAC
  *
  *    Data Alteracao: 19/01/2011        Por: Andre Souza Monaco
  *    Alteracao: Inclus?o do parametro pCOM_NOTA_FISCAL
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  /* Marcus Relva 25/05/2011 - Tirei tabelas COC, CCI, AIC, MCC que nao eram utilizadas pra nada, removi os unions desnecessários */
  /* Marcus Relva 15/03/2012 - pFAT_LNF_ID is not null = usar só esse param como filtro */
  /* Marcus Relva 15/03/2012 - pFAT_LNF_ID is null = removi as tabelas pessoa unidade alta que não eram utilizadas */
	/* Marcus Relva 13/03/2013 - Inclui o ID da unidade */
  V_CURSOR PKG_CURSOR.T_CURSOR;
BEGIN
  if pFAT_LNF_ID is not null then
    OPEN V_CURSOR FOR
      SELECT LNF.FAT_LNF_ID,
             LNF.FAT_LNF_DT_EMISSAO,
             ATE.ATD_ATE_ID,
             ATE.ATD_ATE_TP_PACIENTE,
             PES.CAD_PES_NM_PESSOA,
             ATE.ATD_ATE_DT_ATENDIMENTO,
             ATE.ATD_ATE_HR_ATENDIMENTO,
             INA.ATD_INA_DT_ALTA_ADM,
             INA.ATD_INA_HR_ALTA_ADM,
             CCP.FAT_COC_ID,
             CCP.FAT_CCP_ID,
             PAC.CAD_PAC_ID_PACIENTE,
             PAC.CAD_CNV_ID_CONVENIO,
             PAC.CAD_PAC_NR_PRONTUARIO,
             UNI.CAD_UNI_DS_UNIDADE,
             CCP.FAT_CCP_DT_PARCELA,
             CCP.FAT_CCP_VL_TOT_CONTA,
             ATE.ATD_ATE_DT_ATENDIMENTO,
             CCP.FAT_NOF_ID,
			UNI.CAD_UNI_ID_UNIDADE
        FROM TB_FAT_LNF_LOTE_CTA_PARC_NF LNF,
             TB_ATD_ATE_ATENDIMENTO      ATE,
             TB_ATD_INA_INT_ALTA         INA,
             TB_FAT_CCP_CONTA_CONS_PARC  CCP,
             TB_CAD_PAC_PACIENTE         PAC,
             TB_CAD_PES_PESSOA           PES,
             TB_CAD_UNI_UNIDADE          UNI
       WHERE LNF.FAT_LNF_ID = pFAT_LNF_ID
         AND INA.ATD_ATE_ID(+) = ATE.ATD_ATE_ID
         AND ATE.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
         AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
         AND CCP.FAT_LNF_ID = LNF.FAT_LNF_ID
         AND CCP.ATD_ATE_ID = ATE.ATD_ATE_ID
         AND CCP.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
         AND ATE.ATD_ATE_FL_STATUS = 'A'
         AND CCP.FAT_CCP_FL_FATURADA = 'S'
         AND ((NVL(pCOM_NOTA_FISCAL, 0) = 0 AND CCP.FAT_NOF_ID IS NULL) OR
             (NVL(pCOM_NOTA_FISCAL, 0) = 1 AND NOT CCP.FAT_NOF_ID IS NULL));
    IO_CURSOR := V_CURSOR;
  else
    OPEN V_CURSOR FOR
    SELECT LNF.FAT_LNF_ID, LNF.FAT_LNF_DT_EMISSAO, CCP.FAT_NOF_ID
        FROM TB_FAT_CCP_CONTA_CONS_PARC  CCP,
             TB_FAT_LNF_LOTE_CTA_PARC_NF LNF
       WHERE CCP.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
         AND CCP.CAD_LAT_ID_LOCAL_ATENDIMENTO IN (SELECT column_value from table(FNC_SPLIT(pCAD_LAT_ID_LOCAL_ATENDIMENTO)))
         AND CCP.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
				 AND CCP.FAT_CCP_DT_PARCELA <= pATD_ATE_DT_ATENDIMENTO
         AND CCP.FAT_LNF_ID = LNF.FAT_LNF_ID
         AND CCP.FAT_CCP_FL_FATURADA = 'S'
         AND ((NVL(pCOM_NOTA_FISCAL, 0) = 0 AND CCP.FAT_NOF_ID IS NULL) OR
             (NVL(pCOM_NOTA_FISCAL, 0) = 1 AND NOT CCP.FAT_NOF_ID IS NULL))
       group by LNF.FAT_LNF_ID, LNF.FAT_LNF_DT_EMISSAO, CCP.FAT_NOF_ID;
    IO_CURSOR := V_CURSOR;
  end if;
END PRC_FAT_LOTE_LOTE_L;
