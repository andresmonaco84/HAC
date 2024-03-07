create or replace procedure PRC_INT_REL_GERENC_POSICAO
  (

pATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE,
pATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE,
pATD_ATE_HR_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_HR_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%TYPE DEFAULT NULL,
pFAIXA_ETARIA_INI varchar2 default null,
pFAIXA_ETARIA_FIM varchar2 default null,
pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE,
pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
pTIS_TIN_CD_INTERNACAO IN TB_TIS_TIN_TP_INTERNACAO.TIS_TIN_CD_INTERNACAO%TYPE DEFAULT NULL,
pATD_AIC_TP_SITUACAO_PAC IN TB_ATD_AIC_ATE_INT_COMPL.ATD_AIC_TP_SITUACAO_PAC%TYPE DEFAULT NULL,
pCAD_PRD_ID IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%TYPE DEFAULT NULL,
pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE DEFAULT NULL,
pCAD_PRO_ID_PROF_EXEC IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
pCAD_PES_TP_SEXO IN TB_CAD_PES_PESSOA.CAD_PES_TP_SEXO%TYPE DEFAULT NULL,
pCAD_CNV_ID_CONVENIO     IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
pCAD_PLA_ID_PLANO        IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
pTIS_MSI_CD_MOTIVOSAIDAINT IN TB_TIS_MSI_MOTIVO_SAIDA_INT.TIS_MSI_CD_MOTIVOSAIDAINT%TYPE DEFAULT NULL,
pCAD_PLA_CD_TIPOPLANO_GB IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
pCAD_PLA_CD_TIPOPLANO_PL IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
pCAD_PLA_CD_TIPOPLANO_FU IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
pCAD_PLA_CD_TIPOPLANO_NP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
pCAD_PLA_CD_TIPOPLANO_PA IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
pCAD_PLA_CD_TIPOPLANO_SP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,


   io_cursor              OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_REL_PAC
  *
  *    Data Criacao:  05/11/2009   Por: pedro
  *    Data Alteracao:           Por:
  *
  *    Funcao: Popula o Relatorio Gerencial de posi��o de atendimento
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;

begin

  OPEN v_cursor FOR

 SELECT DISTINCT
        --   atd.atd_ate_id,
               CNV.CAD_CNV_CD_HAC_PRESTADOR,
               CNV.CAD_CNV_CD_HAC_PRESTADOR || '/' || PLA.CAD_PLA_CD_PLANO_HAC,
               PLA.CAD_PLA_CD_PLANO_HAC,
               PLA.CAD_PLA_CD_TIPOPLANO,
               PLA.CAD_PLA_NM_NOME_PLANO,
               PLA.CAD_PLA_CD_PLANO_HAC || '-' || PLA.CAD_PLA_NM_NOME_PLANO PLANO,
               SUM(COUNT(DISTINCT ATD.ATD_ATE_ID)) OVER (PARTITION BY CNV.CAD_CNV_ID_CONVENIO||PLA.CAD_PLA_ID_PLANO) TOTAL,
               ROUND((SUM(COUNT(DISTINCT ATD.ATD_ATE_ID)) OVER (PARTITION BY CNV.CAD_CNV_ID_CONVENIO||PLA.CAD_PLA_ID_PLANO) * 100) / SUM(COUNT(DISTINCT ATD.ATD_ATE_ID)) OVER(),2) PCT,                SUM(COUNT(DISTINCT ATD.ATD_ATE_ID)) OVER() TOTAL_GERAL

  FROM
                TB_ATD_ATE_ATENDIMENTO    ATD

  JOIN          TB_ASS_PAT_PACIEATEND     PAT
  ON            PAT.ATD_ATE_ID          = ATD.ATD_ATE_ID
  JOIN          TB_CAD_PAC_PACIENTE       PAC
  ON            PAC.CAD_PAC_ID_PACIENTE = fnc_buscar_paciente_atual(PAT.ATD_ATE_ID)
  JOIN          TB_CAD_PES_PESSOA         PES
  ON            PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
  JOIN          TB_CAD_CNV_CONVENIO       CNV
  ON            CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
  JOIN          TB_CAD_PLA_PLANO          PLA
  ON            PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
  JOIN          TB_ATD_IML_INT_MOV_LEITO  IML
  ON            IML.ATD_ATE_ID          = ATD.ATD_ATE_ID
  JOIN          TB_ATD_AIC_ATE_INT_COMPL  AIC
  ON            AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
  LEFT JOIN  (    SELECT   QLE.CAD_QLE_ID, QLE.CAD_SET_ID , QLE.CAD_QLE_NR_QUARTO, QLE.CAD_QLE_NR_LEITO,
                          IML.ATD_ATE_ID, QLE.TIS_TAC_CD_TIPO_ACOMODACAO, QLE.CAD_QLE_TP_QUARTO_LEITO ,
                          IML.ATD_IML_DT_ENTRADA, IML.ATD_IML_HR_ENTRADA
                 FROM      TB_ATD_IML_INT_MOV_LEITO IML
                 LEFT JOIN TB_CAD_QLE_QUARTO_LEITO QLE
                 ON        QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN      TB_ATD_ATE_ATENDIMENTO ATD2
                 ON        ATD2.ATD_ATE_ID = IML.ATD_ATE_ID
                  WHERE       FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) = 
                                         (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML3.ATD_IML_DT_ENTRADA,IML3.ATD_IML_HR_ENTRADA)) FROM TB_ATD_IML_INT_MOV_LEITO IML3
                                                       WHERE IML3.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IML3.ATD_IML_FL_STATUS = 'A')
              )  IML_QLE
  ON IML_QLE.ATD_ATE_ID = ATD.ATD_ATE_ID
  LEFT JOIN     TB_ATD_INA_INT_ALTA         INA
  ON            INA.ATD_ATE_ID            = ATD.ATD_ATE_ID
  JOIN          TB_TIS_CBO_CBOS             CBOS
  ON            CBOS.TIS_CBO_CD_CBOS      = ATD.TIS_CBO_CD_CBOS
  JOIN          TB_CAD_UNI_UNIDADE          UNI
  ON            UNI.CAD_UNI_ID_UNIDADE    = ATD.CAD_UNI_ID_UNIDADE
  JOIN          TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
  ON            LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
  LEFT JOIN     TB_CAD_SET_SETOR            SETOR
  ON            SETOR.CAD_SET_ID          = IML_QLE.CAD_SET_ID
  JOIN          TB_CAD_PRO_PROFISSIONAL     PRO
  ON            PRO.CAD_PRO_ID_PROFISSIONAL = ATD.CAD_PRO_ID_PROF_EXEC
  LEFT JOIN     TB_CAD_PRD_PRODUTO          PRD
  ON            PRD.CAD_PRD_ID            = AIC.CAD_PRD_ID
  

    WHERE
       (ATD.ATD_ATE_DT_ATENDIMENTO  between pATD_ATE_DT_ATENDIMENTO_INI AND pATD_ATE_DT_ATENDIMENTO_FIM)
   AND (ATD.ATD_ATE_FL_STATUS = 'A')
   AND (pCAD_UNI_ID_UNIDADE IS NULL OR ATD.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
   AND (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
   AND (pCAD_SET_ID IS NULL OR IML_QLE.CAD_SET_ID = pCAD_SET_ID)
      
   AND (pFAIXA_ETARIA_INI IS NULL OR FLOOR(FLOOR(MONTHS_BETWEEN(SYSDATE, PES.CAD_PES_DT_NASCIMENTO)) / 12) BETWEEN pFAIXA_ETARIA_INI AND pFAIXA_ETARIA_FIM)
   AND (pTIS_CBO_CD_CBOS IS NULL OR ATD.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
   AND (pCAD_PRO_ID_PROF_EXEC IS NULL OR ATD.CAD_PRO_ID_PROF_EXEC = pCAD_PRO_ID_PROF_EXEC)
  -- AND (pATD_ATE_TP_PACIENTE IS NULL OR ATD.ATD_ATE_TP_PACIENTE = pATD_ATE_TP_PACIENTE)
   AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
   AND (pCAD_PLA_ID_PLANO IS NULL OR PAC.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
   AND ( pCAD_PRD_ID IS NULL OR AIC.CAD_PRD_ID = pCAD_PRD_ID)
   AND (pCAD_PES_TP_SEXO IS NULL OR PES.CAD_PES_TP_SEXO = pCAD_PES_TP_SEXO)
   AND (pTIS_TIN_CD_INTERNACAO IS NULL OR AIC.TIS_TIN_CD_INTERNACAO = pTIS_TIN_CD_INTERNACAO)
   AND (pTIS_MSI_CD_MOTIVOSAIDAINT IS NULL OR INA.TIS_MSI_CD_MOTIVOSAIDAINT = pTIS_MSI_CD_MOTIVOSAIDAINT)
   
    AND (pCAD_PLA_CD_TIPOPLANO_GB IS not NULL and PLA.CAD_PLA_CD_TIPOPLANO = 'GB'
   OR pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PL'
   OR pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PA'
   OR pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'SP'   
   OR pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'FU'
   OR pCAD_PLA_CD_TIPOPLANO_NP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'NP')

  GROUP BY     PLA.CAD_PLA_NM_NOME_PLANO,
               CNV.CAD_CNV_CD_HAC_PRESTADOR,
               PLA.CAD_PLA_CD_PLANO_HAC,
               PLA.CAD_PLA_CD_TIPOPLANO,
               PLA.CAD_PLA_CD_PLANO_HAC || '-' || PLA.CAD_PLA_NM_NOME_PLANO,
               CNV.CAD_CNV_CD_HAC_PRESTADOR || '/' || PLA.CAD_PLA_CD_PLANO_HAC,
               CNV.CAD_CNV_ID_CONVENIO,PLA.CAD_PLA_ID_PLANO


  ;
  io_cursor := v_cursor;
end PRC_INT_REL_GERENC_POSICAO;
/
