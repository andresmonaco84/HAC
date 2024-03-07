CREATE OR REPLACE PROCEDURE PRC_REP_REL_ARQ_STOS_CLIN (
    pREP_PGM_MES_PAGTO_INI        IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
    pREP_PGM_ANO_PAGTO_INI        IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
    pCAD_PLA_CD_TIPOPLANO         IN TB_REP_PGM_PAGTO_MEDICO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
    pREP_PGM_TP_CREDENCIA_PROF    IN TB_REP_PGM_PAGTO_MEDICO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
--    pCAD_UNI_ID_UNIDADE           IN TB_REP_PGM_PAGTO_MEDICO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
--    pCAD_CD_EMPRESA????
    IO_CURSOR                     OUT PKG_CURSOR.T_CURSOR
)
IS

/********************************************************************
*
*    PROCEDURE: PRC_REP_REL_ARQ_STOS_CLIN
*    DATA 02/04/2012   POR: DAVI S. M. DOS REIS
*
*********************************************************************/

V_CURSOR PKG_CURSOR.T_CURSOR;
V_CAD_CLC_ID number;
BEGIN

  V_CAD_CLC_ID := 367; -- ID da Stos. Clínica: 367; Código da Sos. Clinica: 45

  OPEN V_CURSOR FOR
    SELECT 
           PGM.ATD_ATE_ID,
           TO_CHAR(PGM.FAT_CCP_ID) FAT_CCP_ID,
           CNV.CAD_CNV_CD_HAC_PRESTADOR,
           PES.CAD_PES_NM_PESSOA,
           PRD.CAD_PRD_CD_CODIGO,
           PRD.CAD_PRD_DS_DESCRICAO,

           UNI.CAD_UNI_CD_UNID_HOSPITALAR,
           PRO.CAD_PRO_NR_CONSELHO,
           PRO.CAD_PRO_NM_NOME,
    --       PGM.CAD_PLA_CD_TIPOPLANO,
           
           PGM.REP_PGM_MES_FECHAMENTO,
           PGM.REP_PGM_ANO_FECHAMENTO,
           PGM.REP_PGM_MES_PAGTO,
           PGM.REP_PGM_ANO_PAGTO, -- MES / ANO PAGAMENTO
           TO_CHAR(PGM.REP_PGM_DT_INICIO_REALIZACAO, 'ddMMyy') REP_PGM_DT_INICIO_REALIZACAO, -- DATA REALIZAÇÃO???
           LTRIM(REPLACE(REPLACE(TO_CHAR(NVL(PGM.REP_PGM_VL_FATURADO, '0'), '9999990D00'), ',', ''), '.', '')) REP_PGM_VL_FATURADO,
           LTRIM(REPLACE(REPLACE(TO_CHAR(NVL(PGM.REP_PGM_VL_CALCULADO, '0'), '9999990D00'), ',', ''), '.', '')) REP_PGM_VL_CALCULADO,
           LTRIM(REPLACE(REPLACE(TO_CHAR(NVL(PGM.REP_PGM_VL_PAGO, '0'), '9999990D00'), ',', ''), '.', '')) REP_PGM_VL_PAGO,

           PLA.CAD_PLA_CD_PLANO_HAC,
           PAC.CAD_PAC_CD_CREDENCIAL, -- LOJA, MATRICULA e DEPENDENTE
           SETOR.CAD_SET_CD_SETOR,
           SET_LEGADO.C_CUSTO,
           DECODE(ATE.ATD_ATE_TP_PACIENTE, 'I', TO_CHAR(ATE.ATD_ATE_DT_ATENDIMENTO, 'ddMMyy'), 
                                           'E', TO_CHAR(ATE.ATD_ATE_DT_ATENDIMENTO, 'ddMMyy'), '') DATA_INT,
           DECODE(ATE.ATD_ATE_TP_PACIENTE, 'I', TO_CHAR(ATE.ATD_ATE_DT_ATENDIMENTO, 'ddMMyy'), 
                                           'E', TO_CHAR(ATE.ATD_ATE_DT_ATENDIMENTO, 'ddMMyy'), '') DATA_ALTA,
           DECODE(ATE.CODPAD, NULL, 'BAS', ATE.CODPAD) AS PADRAO,
           DECODE(PLA.CAD_PLA_CD_TIPOPLANO, 'GB', 'S', 'N') AS GLOBAL,
           DECODE(ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO, 28, 'C', 29, 'I', 'A') AS CONSULTORIO
               
       FROM TB_REP_PGM_PAGTO_MEDICO PGM
      INNER JOIN TB_CAD_CNV_CONVENIO CNV
         ON CNV.CAD_CNV_ID_CONVENIO = PGM.CAD_CNV_ID_CONVENIO
      INNER JOIN TB_CAD_PAC_PACIENTE PAC
         ON PAC.CAD_PAC_ID_PACIENTE = PGM.CAD_PAC_ID_PACIENTE
      INNER JOIN TB_CAD_PES_PESSOA PES
         ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
      INNER JOIN TB_CAD_UNI_UNIDADE UNI
         ON UNI.CAD_UNI_ID_UNIDADE = PGM.CAD_UNI_ID_UNIDADE
      INNER JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
         ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO
      INNER JOIN TB_CAD_SET_SETOR SETOR
         ON SETOR.CAD_SET_ID = PGM.CAD_SET_ID_REALIZACAO
      INNER JOIN TB_CAD_PRD_PRODUTO PRD
         ON PRD.CAD_PRD_ID = PGM.CAD_PRD_ID
      INNER JOIN TB_CAD_PRO_PROFISSIONAL PRO
         ON PRO.CAD_PRO_ID_PROFISSIONAL = PGM.CAD_PRO_ID_PROFISSIONAL
      INNER JOIN TB_CAD_CLC_CLINICA_CREDENCIADA CLC
         ON CLC.CAD_CLC_ID = PGM.CAD_CLC_ID
        
      INNER JOIN TB_ATD_ATE_ATENDIMENTO ATE
         ON ATE.ATD_ATE_ID = PGM.ATD_ATE_ID
      INNER JOIN TB_CAD_PLA_PLANO PLA
         ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO

       LEFT JOIN TB_SETOR SET_LEGADO
         ON SET_LEGADO.CD_SETOR = SETOR.CAD_SET_CD_SETOR
        AND SET_LEGADO.CODUNIHOS = UNI.CAD_UNI_CD_UNID_HOSPITALAR     	   
        
           
     WHERE
           PGM.REP_PGM_FL_PAGO IN ('P', 'F') 
       AND PGM.REP_PGM_FL_STATUS <> 'I'
       AND (PGM.REP_PGM_MES_PAGTO = pREP_PGM_MES_PAGTO_INI)
       AND (PGM.REP_PGM_ANO_PAGTO = pREP_PGM_ANO_PAGTO_INI)
       AND (PGM.CAD_CLC_ID = V_CAD_CLC_ID)
       AND (pREP_PGM_TP_CREDENCIA_PROF IS NULL OR PGM.REP_PGM_TP_CREDENCIA_PROF = pREP_PGM_TP_CREDENCIA_PROF)
       AND (pREP_PGM_TP_CREDENCIA_PROF <> 'MC')
       AND (pCAD_PLA_CD_TIPOPLANO IS NULL OR (INSTR(pCAD_PLA_CD_TIPOPLANO, PGM.CAD_PLA_CD_TIPOPLANO) > 0))
       
  UNION
  
  /* UNION para obter valores de CONSULTORIO, do LEGADO */
  
  SELECT  
    B.CODATEAMBINT                                                        ATD_ATE_ID,
    B.TP_COBRANCA                                                         FAT_CCP_ID,
    'SD01'                                                                CAD_CNV_CD_HAC_PRESTADOR, 
    RPAD(B.NOMPAC, 40, ' ')                                               CAD_PES_NM_PESSOA,
    LPAD(DECODE(B.CODATOMED, NULL,CD_ITEM_PACOTE, B.CODATOMED), 8, ' ')   CAD_PRD_CD_CODIGO,
    'CONSULTORIO LEGADO'                                                  CAD_PRD_DS_DESCRICAO,
    LPAD(TO_CHAR(B.CODUNIHOS), 2, '0')                                    CAD_UNI_CD_UNID_HOSPITALAR, 
    LPAD(B.CODMED, 9, ' ')                                                CAD_PRO_NR_CONSELHO,                           
    ''                                                                    CAD_PRO_NM_NOME,
    B.MESFAT                                   	                          REP_PGM_MES_FECHAMENTO,  
    B.ANOFAT                                                              REP_PGM_ANO_FECHAMENTO, 
    0                                                                     REP_PGM_MES_PAGTO,
    0                                                                     REP_PGM_ANO_PAGTO, 
    TO_CHAR(B.DT_REALIZACAO, 'DDMMYY')                                    REP_PGM_DT_INICIO_REALIZACAO, 
    '0'                                                                   REP_PGM_VL_FATURADO,
    '0'                                                                   REP_PGM_VL_CALCULADO,
    LPAD(TO_CHAR(SUM(NVL(B.VL_PAGO_CLINICA,0))* 100), 10, ' ')            REP_PGM_VL_PAGO,
    B.CODCONV                                                             CAD_PLA_CD_PLANO_HAC,
    LPAD(TO_CHAR( NVL( B.CODEST,0)), 3, ' ') ||
      LPAD(TO_CHAR( NVL( B.CODBEN,0)), 7, ' ') ||
      LPAD(TO_CHAR( NVL( B.CODSEQBEN,0)), 2, ' ')                         CAD_PAC_CD_CREDENCIAL,
    LPAD(TO_CHAR(B.CODCLADESAMB), 2, ' ')                                 CAD_SET_CD_SETOR,
    0                                                                     C_CUSTO,
    ''                                                                    DATA_INT,
    ''                                                                    DATA_ALTA,
    decode(B.CODPAD,NULL,'BAS',B.CODPAD)                                 	PADRAO,
    DECODE(B.CODTIPEMP, 'GB',DECODE(B.CODCONV,'NR14','N','S'), 'PL', 'S', 'N') AS GLOBAL,
    DECODE(B.CODLOC, 'INT', 'I', 'A')                                     CONSULTORIO
    
  FROM      REP_PAGTO_GERAL_CLINICA B,
                  ATO_MEDICO A,
                  MEDICO D,
                  EMPRESA E
  WHERE  B.MES_PAGTO  = pREP_PGM_MES_PAGTO_INI
  AND  B.ANO_PAGTO = pREP_PGM_ANO_PAGTO_INI
  AND  A.CODATOMED(+) = B.CODATOMED
  AND  B.CODCONV = E.CODCON  
  AND  B.CODMED  = D.CODMED
  AND  E.CODTIPEMP = B.CODTIPEMP 
  AND  B.CODLOC = 'CON'
  AND  B.CD_CLINICA = 45
  AND (B.CD_STATUS IS NULL OR B.CD_STATUS NOT IN  ('EX'))
  AND pREP_PGM_TP_CREDENCIA_PROF = 'MC'
   GROUP BY  B.ANO_PAGTO,
                          B.MES_PAGTO,
                          B.CODUNIHOS,
                          B.DT_REALIZACAO,
                          B.CODATOMED,
                          B.NOMPAC,
                          B.CODCONV,
                          B.CODATEAMBINT,
                          B.TP_COBRANCA,
                          B.CODEST,
                          B.CODBEN,
                          B.CODSEQBEN,
                          B.CODCLADESAMB,
                          TO_CHAR( B.DT_REALIZACAO , 'DDMMYY'), 
                          TO_CHAR( B.DT_REALIZACAO , 'DDMMYY'),
                          B.CODPAD,
                          DECODE( B.CODTIPEMP, 'GB',DECODE(B.CODCONV,'NR14','N','S'), 'PL', 'S', 'N'),
                          B.CODMED,
                          D.NOMMED,
                          B.MES_PAGTO,
                          B.ANO_PAGTO,
                          B.CODCONV,
                          B.DT_REALIZACAO,
                          DECODE(B.CODATOMED, NULL,CD_ITEM_PACOTE, B.CODATOMED),
                          B.CODATEAMBINT,
                          B.TP_COBRANCA,
                          B.MESFAT,
                          B.ANOFAT,
                          B.CODLOC,
                          B.CD_PACOTE;
    
       
  IO_CURSOR := V_CURSOR;

END PRC_REP_REL_ARQ_STOS_CLIN;
/
