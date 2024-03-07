create or replace procedure PRC_ATE_REL_ESTAT_CONV_PLA
(
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE,
     pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
     pATD_DT_INICIO IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type,
     pATD_DT_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%type,
          pCAD_CGC_ID IN tb_cad_cnv_convenio.cad_cgc_id%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ATE_REL_ESTAT_CONV_PLA
*
*    Data Criacao:  21/01/2011   Por: Rafael Coimbra
*    Funcao: Alimentar relatorio das estatisticas do Atendimento DE
*            ABSENTEISMO por convenio e plano.
*
*    Data Alteracao:  15/03/2011   Por: Davi Silvestre M. dos Reis
*    Alteracao:     inclusao das colunas 'faltosos' e 'atendidos'
*
*    Data Alteracao:  14/05/2014   Por: Davi Silvestre M. dos Reis
*    Alteracao:     inclusao da hora no campo DATA_ATENDIMENTO
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
BEGIN
    OPEN v_cursor FOR
         SELECT
              ROW_NUMBER() OVER (PARTITION BY PLA.CAD_PLA_ID_PLANO ORDER BY CNV.CAD_CNV_ID_CONVENIO) AS SEQ,
              COUNT(AGD.AGE_AGD_ID) AS FALTOSOS,
             (
               SELECT COUNT(AGD1.AGE_AGD_ID)
                  FROM TB_AGE_AGD_AGENDA AGD1,
                       TB_CAD_PAC_PACIENTE PAC1,
                       TB_CAD_PLA_PLANO PLA1,
                       TB_CAD_CNV_CONVENIO CNV1,
                       TB_ATD_ATE_ATENDIMENTO ATD1
                 WHERE (AGD1.AGE_AGD_DT_ATENDIMENTO BETWEEN pATD_DT_INICIO AND pATD_DT_FIM)
                   AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC1.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
                   AND (pCAD_PLA_ID_PLANO IS NULL OR PAC1.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
                   AND (AGD1.AGE_AGD_FL_STATUS = 'A')
                   AND PAC1.CAD_PAC_ID_PACIENTE = AGD1.CAD_PAC_ID_PACIENTE
                   AND PAC1.CAD_PLA_ID_PLANO = PLA1.CAD_PLA_ID_PLANO
                   AND PAC1.CAD_CNV_ID_CONVENIO = CNV1.CAD_CNV_ID_CONVENIO
                   AND ATD1.ATD_ATE_ID = AGD1.AGE_AGD_CD_INTAMB
                   AND ATD1.CAD_LAT_ID_LOCAL_ATENDIMENTO != 28
                    AND (pCAD_CGC_ID IS NULL OR CNV1.CAD_CGC_ID = pCAD_CGC_ID)
                   AND PLA1.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
                   AND PLA1.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
             ) ATENDIDOS,
             
              CNV.CAD_CNV_ID_CONVENIO AS ID_CONVENIO,
              CNV.CAD_CNV_CD_HAC_PRESTADOR AS CD_HAC,
              CNV.CAD_CNV_DS_RAZAOSOCIAL AS DS_CONVENIO,
              PLA.CAD_PLA_ID_PLANO AS ID_PLANO,
              PLA.CAD_PLA_CD_PLANO_HAC AS CD_PLANO_HAC,
              PLA.CAD_PLA_NM_NOME_PLANO AS NOME_PLANO,
              
              TO_DATE(TO_CHAR(AGD.AGE_AGD_DT_ATENDIMENTO,'dd-MM-yyyy') || ' ' ||
                      TO_CHAR(AGD.AGE_AGD_HR_ATENDIMENTO,'0000'),'dd-MM-yyyy HH24MI') DATA_ATENDIMENTO,

              CASE WHEN PAC.CAD_CNV_ID_CONVENIO IN (281,283) THEN BB_TITULAR.NOME_TITULAR
                ELSE NVL(PAC.CAD_PAC_NM_TITULAR, PES.CAD_PES_NM_PESSOA) 
              END AS NOME_TITULAR,
              PES.CAD_PES_NM_PESSOA AS NOME_PESSOA,
              PAC.CAD_PAC_CD_CREDENCIAL AS CD_CREDENCIAL,
              CBO.TIS_CBO_CD_CBOS AS ID_ESPECIALIDADE,
              CBO.TIS_CBO_DS_CBOS_HAC AS DS_ESPECIALIDADE
         FROM
             TB_AGE_AGD_AGENDA AGD,
             TB_AGE_ESM_ESCALA_MEDICA ESM,
             TB_CAD_PES_PESSOA PES,
             TB_CAD_PAC_PACIENTE PAC,
             TB_CAD_PLA_PLANO PLA,
             TB_CAD_CNV_CONVENIO CNV,
             TB_TIS_CBO_CBOS CBO,
            
             (SELECT PAC.CAD_PAC_ID_PACIENTE,
                     BB_TITULAR.CODCON, BB_TITULAR.CODBEN, BB_TITULAR.CODEST,BB_TITULAR.CODSEQBEN,
                     BB_TITULAR.NOMBEN NOME_TITULAR 
                FROM TB_CAD_PAC_PACIENTE PAC,
                     TB_CAD_PLA_PLANO PLA,
                     BNF_BENEFICIARIO BB_TITULAR ,
                     TB_CAD_CNV_CONVENIO CNV
               WHERE PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
                 AND BB_TITULAR.CODCON = PLA.CAD_PLA_CD_PLANO
                 AND BB_TITULAR.CODEST = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,1,3))
                 AND BB_TITULAR.CODBEN = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,4,7))
                 AND BB_TITULAR.CODINDBEN = 'S'
                 AND LENGTH(PAC.CAD_PAC_CD_CREDENCIAL) = 12
                 AND PAC.CAD_CNV_ID_CONVENIO IN (281,283)
                 AND PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
                  AND (pCAD_CGC_ID IS NULL OR CNV.CAD_CGC_ID = pCAD_CGC_ID)                 
             ) BB_TITULAR
         
         
         WHERE
             (AGD.AGE_AGD_DT_ATENDIMENTO BETWEEN pATD_DT_INICIO AND pATD_DT_FIM)
             AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
             AND (pCAD_PLA_ID_PLANO IS NULL OR PAC.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
             AND (AGD.AGE_AGD_FL_STATUS IN ('F', 'P'))
             AND ESM.AGE_ESM_ID = AGD.AGE_ESM_ID
             AND ESM.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS
             AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
             AND PAC.CAD_PAC_ID_PACIENTE = AGD.CAD_PAC_ID_PACIENTE
             AND PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
             AND PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
             AND ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO != 28
             AND BB_TITULAR.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE    
              AND (pCAD_CGC_ID IS NULL OR CNV.CAD_CGC_ID = pCAD_CGC_ID) 
         GROUP BY
         (
             CNV.CAD_CNV_ID_CONVENIO,
             CNV.CAD_CNV_CD_HAC_PRESTADOR,
             CNV.CAD_CNV_DS_RAZAOSOCIAL,
             PLA.CAD_PLA_ID_PLANO,
             PLA.CAD_PLA_CD_PLANO_HAC,
             PLA.CAD_PLA_NM_NOME_PLANO,
            CASE WHEN PAC.CAD_CNV_ID_CONVENIO IN (281,283) THEN BB_TITULAR.NOME_TITULAR
                ELSE NVL(PAC.CAD_PAC_NM_TITULAR, PES.CAD_PES_NM_PESSOA) 
              END ,
             AGD.AGE_AGD_DT_AGENDA,
             AGD.AGE_AGD_DT_ATENDIMENTO,
             AGD.AGE_AGD_HR_ATENDIMENTO,
             PAC.CAD_PAC_NM_TITULAR,
             PES.CAD_PES_NM_PESSOA,
             PAC.CAD_PAC_NR_PRONTUARIO,
             CBO.TIS_CBO_CD_CBOS,
             CBO.TIS_CBO_DS_CBOS_HAC,
             PAC.CAD_PAC_CD_CREDENCIAL
         )
         ORDER BY PLA.CAD_PLA_ID_PLANO, AGD.AGE_AGD_DT_AGENDA;

    io_cursor := v_cursor;
END PRC_ATE_REL_ESTAT_CONV_PLA;
