create or replace procedure PRC_INT_REL_ANIVERSARIANTES
  (
pATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_HR_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_HR_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_FL_CARATER_SOLIC_U IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_CARATER_SOLIC%TYPE DEFAULT NULL,
pATD_ATE_FL_CARATER_SOLIC_E IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_CARATER_SOLIC%TYPE DEFAULT NULL,
pFAIXA_ETARIA_INI varchar2 default null,
pFAIXA_ETARIA_FIM varchar2 default null,
pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
pCAD_SET_NR_ANDAR IN TB_CAD_SET_SETOR.CAD_SET_NR_ANDAR%TYPE DEFAULT NULL,
pATD_AIC_TP_SITUACAO_PAC IN TB_ATD_AIC_ATE_INT_COMPL.ATD_AIC_TP_SITUACAO_PAC%TYPE DEFAULT NULL,
pATD_ATE_TP_PACIENTE_I IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
pATD_ATE_TP_PACIENTE_E IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
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
pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_CD_TIPO_ACOMODACAO%TYPE DEFAULT NULL,
pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE DEFAULT NULL,
pCAD_PRO_ID_PROF_EXEC IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
pCAD_PES_TP_SEXO IN TB_CAD_PES_PESSOA.CAD_PES_TP_SEXO%TYPE DEFAULT NULL,
pCAD_CNV_ID_CONVENIO     IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
pCAD_PLA_ID_PLANO        IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
pCAD_UNI_ID_UNID_PROC    IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNID_PROC%TYPE DEFAULT NULL,
   io_cursor              OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_REL_ANIVERSARIANTES
  *
  *    Data Criacao:  11/08/2009   Por: pedro
  *    Data Alteracao:           Por:
  *
  *    Funcao: Popula o Relatorio de Pacientes Internados com varias possibilidades de filtro
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
 SELECT DISTINCT
               DECODE(IML_QLE.CAD_QLE_TP_QUARTO_LEITO,'I','INTERNO','E','EXTRA') CAD_QLE_TP_QUARTO_LEITO,
               IML_QLE.CAD_QLE_NR_QUARTO,
               IML_QLE.CAD_QLE_NR_LEITO,
               TAC.TIS_TAC_DS_TIPO_ACOMODACAO,
               ATD.ATD_ATE_ID,
               UNI.CAD_UNI_DS_UNIDADE UNIDADE,
               LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
               LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,               
               SETOR.CAD_SET_DS_SETOR,
               PAC.CAD_PAC_NR_PRONTUARIO,
               PES.CAD_PES_NM_PESSOA PACIENTE,
               to_char(PES.CAD_PES_DT_NASCIMENTO,'dd/MM/yyyy') CAD_PES_DT_NASCIMENTO,
               PES.CAD_PES_TP_SEXO,
               ATD.ATD_ATE_DT_ATENDIMENTO,
               ATD.ATD_ATE_HR_ATENDIMENTO,
               Floor(floor(months_between(SYSDATE, pes.cad_pes_dt_nascimento)) / 12) idade,
               ATD.TIS_TAT_CD_TPATENDIMENTO
  FROM
                TB_ATD_ATE_ATENDIMENTO    ATD

  JOIN          TB_CAD_PAC_PACIENTE       PAC
  ON            PAC.CAD_PAC_ID_PACIENTE = fnc_buscar_paciente_atual(atd.atd_ate_id)
  JOIN          TB_CAD_PES_PESSOA         PES
  ON            PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
  JOIN          TB_ATD_AIC_ATE_INT_COMPL  AIC
  ON            AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
  LEFT JOIN  (    SELECT     QLE.CAD_QLE_ID, QLE.CAD_SET_ID , QLE.CAD_QLE_NR_QUARTO, QLE.CAD_QLE_NR_LEITO,
                          IML.ATD_ATE_ID, QLE.TIS_TAC_CD_TIPO_ACOMODACAO, QLE.CAD_QLE_TP_QUARTO_LEITO ,
                          IML.ATD_IML_DT_ENTRADA, IML.ATD_IML_HR_ENTRADA
                 FROM      TB_ATD_IML_INT_MOV_LEITO IML
                 LEFT JOIN TB_CAD_QLE_QUARTO_LEITO QLE
                 ON        QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN      TB_ATD_ATE_ATENDIMENTO ATD2
                 ON        ATD2.ATD_ATE_ID = IML.ATD_ATE_ID
                 WHERE     IML.ATD_IML_DT_SAIDA IS NULL AND IML.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IML.ATD_IML_FL_STATUS = 'A'
                 UNION
                 SELECT NULL CAD_QLE_ID, IMS.CAD_SET_ID_SETOR, NULL CAD_QLE_NR_QUARTO, NULL CAD_QLE_NR_LEITO,
                        IMS.ATD_ATE_ID, NULL TIS_TAC_CD_TIPO_ACOMODACAO, NULL CAD_QLE_TP_QUARTO_LEITO,
                        IMS.ATD_IMS_DT_ENTRADA ATD_IML_DT_ENTRADA, IMS.ATD_IMS_HR_ENTRADA ATD_IML_HR_ENTRADA
                 FROM      TB_ATD_IMS_INT_MOV_SETOR IMS
                 JOIN      TB_ATD_ATE_ATENDIMENTO ATD2
                 ON        ATD2.ATD_ATE_ID = IMS.ATD_ATE_ID
                 WHERE IMS.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IMS.ATD_IMS_DT_SAIDA IS NULL AND IMS.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IMS.ATD_IMS_FL_STATUS = 'A'
                 AND NOT IMS.ATD_ATE_ID IN (SELECT IML.ATD_ATE_ID
                                               FROM      TB_ATD_IML_INT_MOV_LEITO IML
                                               LEFT JOIN TB_CAD_QLE_QUARTO_LEITO QLE
                                               ON        QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                                               JOIN      TB_ATD_ATE_ATENDIMENTO ATD2
                                               ON        ATD2.ATD_ATE_ID = IML.ATD_ATE_ID
                                               WHERE     IML.ATD_IML_DT_SAIDA IS NULL AND IML.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IML.ATD_IML_FL_STATUS = 'A')
              )  IML_QLE
  ON IML_QLE.ATD_ATE_ID = ATD.ATD_ATE_ID
  LEFT JOIN     TB_TIS_TAC_TIPO_ACOMODACAO  TAC
  ON            TAC.TIS_TAC_CD_TIPO_ACOMODACAO = IML_QLE.TIS_TAC_CD_TIPO_ACOMODACAO
  JOIN          TB_CAD_UNI_UNIDADE          UNI
  ON            UNI.CAD_UNI_ID_UNIDADE    = ATD.CAD_UNI_ID_UNIDADE
  JOIN          TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
  ON            LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
  LEFT JOIN     TB_CAD_SET_SETOR            SETOR
  ON            SETOR.CAD_SET_ID          = IML_QLE.CAD_SET_ID
   WHERE
       (pCAD_UNI_ID_UNIDADE IS NULL OR ATD.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
   AND (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
   AND (pCAD_SET_ID IS NULL OR IML_QLE.CAD_SET_ID = pCAD_SET_ID)
   AND  (AIC.ATD_AIC_TP_SITUACAO_PAC = 'I')
   AND (pFAIXA_ETARIA_INI IS NULL OR FLOOR(FLOOR(MONTHS_BETWEEN(SYSDATE, PES.CAD_PES_DT_NASCIMENTO)) / 12) BETWEEN pFAIXA_ETARIA_INI AND pFAIXA_ETARIA_FIM)
   AND (ATD.ATD_ATE_TP_PACIENTE = 'I')
   AND (ATD.ATD_ATE_FL_STATUS = 'A')
   AND (pATD_ATE_DT_ATENDIMENTO_INI IS NULL OR to_number(TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'MMdd'))  >= to_number(TO_CHAR(to_date(pATD_ATE_DT_ATENDIMENTO_INI,'dd/MM/yyyy'),'MMdd')))
   AND (pATD_ATE_DT_ATENDIMENTO_FIM IS NULL OR to_number(tO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'MMdd'))  <= to_number(TO_CHAR(to_date(pATD_ATE_DT_ATENDIMENTO_FIM,'dd/MM/yyyy'),'MMdd')))
   order by UNI.CAD_UNI_DS_UNIDADE,
            LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
            SETOR.CAD_SET_DS_SETOR,
            IML_QLE.CAD_QLE_NR_QUARTO,
            IML_QLE.CAD_QLE_NR_LEITO,
            ATD.TIS_TAT_CD_TPATENDIMENTO
  ;
  io_cursor := v_cursor;
end PRC_INT_REL_ANIVERSARIANTES;
