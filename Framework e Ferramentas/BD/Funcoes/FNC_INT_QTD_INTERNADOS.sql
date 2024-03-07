create or replace function FNC_INT_QTD_INTERNADOS
(
 pATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_HR_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_HR_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_FL_CARATER_SOLIC_U IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_CARATER_SOLIC%TYPE DEFAULT NULL,
pATD_ATE_FL_CARATER_SOLIC_E IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_CARATER_SOLIC%TYPE DEFAULT NULL,
pFAIXA_ETARIA_INI varchar2 default null,
pFAIXA_ETARIA_FIM varchar2 default null,
pPERMANENCIA_INI varchar2 default null,
pPERMANENCIA_FIM varchar2 default null,
pEVOLUCAO varchar2 default null,
pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
pCAD_SET_NR_ANDAR IN TB_CAD_SET_SETOR.CAD_SET_NR_ANDAR%TYPE DEFAULT NULL,
pATD_AIC_TP_SITUACAO_PAC IN TB_ATD_AIC_ATE_INT_COMPL.ATD_AIC_TP_SITUACAO_PAC%TYPE DEFAULT NULL,
pATD_ATE_TP_PACIENTE IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
pCAD_QLE_TP_QUARTO_LEITO IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_TP_QUARTO_LEITO%TYPE DEFAULT NULL,
pTIS_TIN_CD_INTER IN TB_ATD_AIC_ATE_INT_COMPL.TIS_TIN_CD_INTERNACAO%TYPE DEFAULT NULL,
pTIS_TRI_CD_TP_REGINT IN TB_ATD_AIC_ATE_INT_COMPL.TIS_TRI_CD_REGINTENNACAO%TYPE DEFAULT NULL,
pCAD_PLA_CD_TIPOPLANO_GB IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
pCAD_PLA_CD_TIPOPLANO_PL IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
pCAD_PLA_CD_TIPOPLANO_FU IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
pCAD_PLA_CD_TIPOPLANO_NP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
pCAD_PLA_CD_TIPOPLANO_PA IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
pCAD_PLA_CD_TIPOPLANO_SP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
pCAD_PRD_ID IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%TYPE DEFAULT NULL,
pCAD_CID_CD_CID10 IN TB_CAD_CID_CID10.CAD_CID_CD_CID10%TYPE DEFAULT NULL,
pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_CD_TIPO_ACOMODACAO%TYPE DEFAULT NULL,
pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE DEFAULT NULL,
pCAD_PRO_ID_PROF_EXEC IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
pCAD_PES_TP_SEXO IN TB_CAD_PES_PESSOA.CAD_PES_TP_SEXO%TYPE DEFAULT NULL,
pCAD_CNV_ID_CONVENIO     IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
pCAD_PLA_ID_PLANO        IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
pSUBGRUPO VARCHAR2 DEFAULT NULL
--pCAD_CGC_ID_G IN TB_CAD_CNV_CONVENIO.CAD_CGC_ID%TYPE DEFAULT NULL,
--pCAD_CGC_ID_E IN TB_CAD_CNV_CONVENIO.CAD_CGC_ID%TYPE DEFAULT NULL
)
---retorna a qtd de int ----- por varios parametros
return NUMBER is Result NUMBER;
begin
   SELECT      Count(DISTINCT ATD.ATD_ATE_ID) INTO RESULT
        FROM          TB_ATD_ATE_ATENDIMENTO    ATD
        JOIN          TB_CAD_PAC_PACIENTE       PAC        ON            PAC.CAD_PAC_ID_PACIENTE = fnc_buscar_paciente_atual(ATD.ATD_ATE_ID)
        JOIN          TB_CAD_PES_PESSOA         PES        ON            PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
        JOIN          TB_CAD_CNV_CONVENIO       CNV        ON            CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
        JOIN          TB_CAD_PLA_PLANO          PLA        ON            PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
        JOIN          TB_ATD_AIC_ATE_INT_COMPL  AIC        ON            AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
        JOIN          TB_CAD_PRO_PROFISSIONAL   PRO        ON            PRO.CAD_PRO_ID_PROFISSIONAL = ATD.CAD_PRO_ID_PROF_EXEC

     LEFT JOIN  (   SELECT   QLE.CAD_QLE_ID, QLE.CAD_SET_ID , IML.ATD_ATE_ID, QLE.CAD_SQL_CD_SIT_QUARTO_LEITO,QLE.CAD_QLE_TP_QUARTO_LEITO
                       FROM      TB_ATD_IML_INT_MOV_LEITO IML
                       JOIN      TB_CAD_QLE_QUARTO_LEITO QLE     ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                       JOIN      TB_ATD_AIC_ATE_INT_COMPL AIC2   ON AIC2.ATD_ATE_ID = IML.ATD_ATE_ID AND AIC2.ATD_AIC_TP_SITUACAO_PAC = 'I'

                       WHERE   IML.ATD_IML_FL_STATUS = 'A' AND  FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) =
                                         (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML3.ATD_IML_DT_ENTRADA,IML3.ATD_IML_HR_ENTRADA)) FROM TB_ATD_IML_INT_MOV_LEITO IML3
                            WHERE IML3.ATD_ATE_ID = AIC2.ATD_ATE_ID AND IML3.ATD_IML_FL_STATUS = 'A')
                    )  IML_QLE
        ON IML_QLE.ATD_ATE_ID = ATD.ATD_ATE_ID

        JOIN          TB_CAD_SET_SETOR                   SETOR        ON            SETOR.CAD_SET_ID                 = IML_QLE.CAD_SET_ID        AND           SETOR.CAD_SET_ID NOT IN (2072,2312,5,140)
        LEFT JOIN     TB_ATD_IEP_INT_EVOL_PACIENTE       IEP        ON            IEP.ATD_ATE_ID                   = ATD.ATD_ATE_ID
        LEFT JOIN     TB_CAD_CID_CID10                   CID_IEP        ON            CID_IEP.CAD_CID_CD_CID10         = IEP.CAD_CID_CD_CID10
         WHERE
             (ATD.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
         AND (ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
         AND SETOR.CAD_CSE_ID NOT IN (8,9)
         AND (pCAD_SET_ID IS NULL OR IML_QLE.CAD_SET_ID = pCAD_SET_ID)
         AND (ATD.ATD_ATE_FL_STATUS = 'A')
         AND AIC.ATD_AIC_TP_SITUACAO_PAC = 'I'
         aND SETOR.CAD_SET_FL_PERMITEINTERN_OK = 'S'
         AND SETOR.CAD_SET_FL_ATIVO_OK = 'S'
         AND IML_QLE.CAD_SQL_CD_SIT_QUARTO_LEITO IN (2)
         AND (pCAD_QLE_TP_QUARTO_LEITO IS NULL OR IML_QLE.CAD_QLE_TP_QUARTO_LEITO = pCAD_QLE_TP_QUARTO_LEITO)
         AND (pATD_ATE_TP_PACIENTE IS NULL OR ATD.ATD_ATE_TP_PACIENTE = pATD_ATE_TP_PACIENTE)

         AND (pTIS_CBO_CD_CBOS IS NULL OR ATD.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
         AND (pCAD_PRO_ID_PROF_EXEC IS NULL OR ATD.CAD_PRO_ID_PROF_EXEC = pCAD_PRO_ID_PROF_EXEC)
         AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
         AND (pCAD_PLA_ID_PLANO IS NULL OR PAC.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
         AND (pCAD_PRD_ID IS NULL OR AIC.CAD_PRD_ID = pCAD_PRD_ID)
         AND (pCAD_CID_CD_CID10 IS NULL OR CID_IEP.CAD_CID_CD_CID10 = pCAD_CID_CD_CID10)
         AND (pCAD_PES_TP_SEXO IS NULL OR PES.CAD_PES_TP_SEXO = pCAD_PES_TP_SEXO)

      /*   AND (pCAD_PLA_CD_TIPOPLANO_GB IS not NULL and PLA.CAD_PLA_CD_TIPOPLANO = 'GB'
           OR pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PL'
           OR pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PA'
           OR pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'SP'
           OR pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'FU'
           OR pCAD_PLA_CD_TIPOPLANO_NP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'NP'
           OR (pCAD_PLA_CD_TIPOPLANO_GB IS NULL AND pCAD_PLA_CD_TIPOPLANO_PL IS NULL AND pCAD_PLA_CD_TIPOPLANO_PA IS NULL 
           AND pCAD_PLA_CD_TIPOPLANO_SP IS NULL AND pCAD_PLA_CD_TIPOPLANO_FU IS NULL AND pCAD_PLA_CD_TIPOPLANO_NP IS NULL))*/

 AND ((pSUBGRUPO = 'ACS' AND CNV.CAD_CNV_ID_CONVENIO = 281) OR
         (pSUBGRUPO = 'AMIL' AND cnv.cad_cgc_id = 1 and cnv.cad_tpe_cd_codigo = 'SP' and cnv.cad_cnv_cd_hac_prestador != 'S077') OR
         (pSUBGRUPO = 'FUNCIONARIO' AND cnv.cad_cnv_cd_hac_prestador in ('GG05', 'HAC', 'NP01', 'NR14', 'S077') ) OR
         (pSUBGRUPO = 'MERCADO' AND CNV.cad_cgc_id = 2 AND cnv.cad_cnv_id_convenio!=282 ) OR
         (pSUBGRUPO = 'PARTICULAR' AND CNV.cad_cgc_id = 2 AND CNV.CAD_CNV_ID_CONVENIO = 282) OR
         (pSUBGRUPO = 'NAOPAGANTE'  AND CNV.CAD_CNV_ID_CONVENIO = 1021) OR
         (pSUBGRUPO IS NULL)
         )

         AND (pATD_ATE_FL_CARATER_SOLIC_U IS NOT NULL AND ATD.ATD_ATE_FL_CARATER_SOLIC = 'U'
         OR pATD_ATE_FL_CARATER_SOLIC_E IS NOT NULL AND ATD.ATD_ATE_FL_CARATER_SOLIC = 'E')

         AND (pFAIXA_ETARIA_INI IS NULL OR (Floor(floor(months_between(SYSDATE, pes.cad_pes_dt_nascimento)) / 12) >= pFAIXA_ETARIA_INI))
         and (pFAIXA_ETARIA_FIM IS NULL OR (Floor(floor(months_between(SYSDATE, pes.cad_pes_dt_nascimento)) / 12) <= pFAIXA_ETARIA_FIM))

      AND  (pPERMANENCIA_INI IS NULL OR
               ( nvl(TRUNC(sysdate)-ATD.ATD_ATE_DT_ATENDIMENTO,0) >=  pPERMANENCIA_INI)
               )
         AND  (pPERMANENCIA_FIM IS NULL OR
               ( nvl(TRUNC(sysdate)-ATD.ATD_ATE_DT_ATENDIMENTO,0) <= pPERMANENCIA_FIM)
              )

 --AND (pCAD_CGC_ID_G IS NOT NULL AND CNV.CAD_CGC_ID = 1 OR
   --       pCAD_CGC_ID_E IS NOT NULL AND CNV.CAD_CGC_ID = 2)
       /*  AND  (pPERMANENCIA_INI IS NULL OR
               ( nvl(TRUNC(sysdate-fnc_juntar_data_hora(ATD.ATD_ATE_DT_ATENDIMENTO,ATD.ATD_ATE_HR_ATENDIMENTO)),0) >=  pPERMANENCIA_INI)
               )
         AND  (pPERMANENCIA_FIM IS NULL OR
               ( nvl(TRUNC(sysdate-fnc_juntar_data_hora(ATD.ATD_ATE_DT_ATENDIMENTO,ATD.ATD_ATE_HR_ATENDIMENTO)),0) <= pPERMANENCIA_FIM)
              )*/
;
  return(Result);
end FNC_INT_QTD_INTERNADOS;
