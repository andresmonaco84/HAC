CREATE OR REPLACE PROCEDURE PRC_REP_REL_ARQ_PAG_MED_LITO (
    pREP_PGM_MES_PAGTO_INI        IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
    pREP_PGM_ANO_PAGTO_INI        IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
    pCAD_CLC_ID                   IN TB_REP_PGM_PAGTO_MEDICO.CAD_CLC_ID%TYPE,
    pCAD_UNI_ID_UNIDADE           IN TB_REP_PGM_PAGTO_MEDICO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_REP_PGM_PAGTO_MEDICO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
    -- PAGO PELO HAC?
    -- PAGO PELO CONVENIO?
    pCAD_TPE_CD_CODIGO_HN         IN TB_CAD_CNV_CONVENIO.CAD_TPE_CD_CODIGO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_EX         IN TB_CAD_CNV_CONVENIO.CAD_TPE_CD_CODIGO%TYPE DEFAULT NULL,
    pCAD_TPE_CD_CODIGO_TX         IN TB_CAD_CNV_CONVENIO.CAD_TPE_CD_CODIGO%TYPE DEFAULT NULL,
    -- CODIGO DO SERVI�O?
    pCAD_PRD_ID                   IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%TYPE DEFAULT NULL,
    IO_CURSOR                     OUT PKG_CURSOR.T_CURSOR
)
IS

/********************************************************************
*
*    PROCEDURE: PRC_REP_REL_ARQ_PAG_MED_LITO
*    DATA 08/03/2012   POR: DAVI S. M. DOS REIS
*
*********************************************************************/

V_CURSOR PKG_CURSOR.T_CURSOR;
BEGIN
  OPEN V_CURSOR FOR
    SELECT
           PGM.REP_PGM_MES_PAGTO,
           PGM.REP_PGM_ANO_PAGTO, -- MES / ANO PAGAMENTO
           -- NRO??
           PRO.CAD_PRO_NR_CONSELHO, -- NRO CRM
           PRO.CAD_PRO_NM_NOME, -- M�DICO
           UNI.CAD_UNI_DS_UNIDADE,
           LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO, -- LOCAL ATENDIMENTO (?)
           -- NROS?? (CREDENCIAL? PRONTU�RIO? )
           CNV.CAD_CNV_CD_HAC_PRESTADOR, -- C�D. CONV�NIO
           PES.CAD_PES_NM_PESSOA,
           SETOR.CAD_SET_DS_SETOR,
           PRD.CAD_PRD_CD_CODIGO, -- C�DIGO EXAME (PRODUTO)
           PRD.CAD_PRD_DS_DESCRICAO, -- DESCRI��O EXAME (PRODUTO)
           PGM.REP_PGM_DT_INICIO_REALIZACAO, -- DATA REALIZA��O???
           PGM.REP_PGM_QT_CONSUMO,
           PGM.REP_PGM_VL_FATURADO,
           PGM.REP_PGM_VL_CALCULADO,
           PGM.REP_PGM_VL_PAGO
      FROM TB_REP_PGM_PAGTO_MEDICO PGM
     INNER JOIN TB_CAD_CNV_CONVENIO CNV
        ON CNV.CAD_CNV_ID_CONVENIO = PGM.CAD_CNV_ID_CONVENIO
     INNER JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
        ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO
     INNER JOIN TB_CAD_PRD_PRODUTO PRD
        ON PRD.CAD_PRD_ID = PGM.CAD_PRD_ID
     INNER JOIN TB_CAD_PRO_PROFISSIONAL PRO
        ON PRO.CAD_PRO_ID_PROFISSIONAL = PGM.CAD_PRO_ID_PROFISSIONAL
     INNER JOIN TB_CAD_UNI_UNIDADE UNI
        ON UNI.CAD_UNI_ID_UNIDADE = PGM.CAD_UNI_ID_UNIDADE
     INNER JOIN TB_CAD_PAC_PACIENTE PAC
        ON PAC.CAD_PAC_ID_PACIENTE = PGM.CAD_PAC_ID_PACIENTE
     INNER JOIN TB_CAD_PES_PESSOA PES
        ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
      LEFT JOIN TB_CAD_SET_SETOR SETOR
        ON PGM.CAD_SET_ID_REALIZACAO = SETOR.CAD_SET_ID
     WHERE
           (PGM.REP_PGM_MES_PAGTO = pREP_PGM_MES_PAGTO_INI)
       AND (PGM.REP_PGM_ANO_PAGTO = pREP_PGM_ANO_PAGTO_INI)
       AND (PCAD_UNI_ID_UNIDADE IS NULL OR PGM.CAD_UNI_ID_UNIDADE = PCAD_UNI_ID_UNIDADE)
       AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = PCAD_LAT_ID_LOCAL_ATENDIMENTO)
       AND (pCAD_CLC_ID IS NULL OR PGM.CAD_CLC_ID = pCAD_CLC_ID)
       -- PAGO PELO HAC?
       -- PAGO PELO CONVENIO?
       AND (pCAD_TPE_CD_CODIGO_HN IS NULL OR CNV.CAD_TPE_CD_CODIGO = 'HN'
            OR pCAD_TPE_CD_CODIGO_TX IS NULL OR CNV.CAD_TPE_CD_CODIGO = 'TX'
            OR pCAD_TPE_CD_CODIGO_EX IS NULL OR CNV.CAD_TPE_CD_CODIGO = 'EX')
    -- CODIGO DO SERVI�O?
       AND (pCAD_PRD_ID IS NULL OR PRD.CAD_PRD_ID = pCAD_PRD_ID);
  IO_CURSOR := V_CURSOR;

END PRC_REP_REL_ARQ_PAG_MED_LITO;
/