create or replace procedure PRC_INT_ETIQUETA_COMPLETA
  (
  pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
   io_cursor              OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_ETIQUETA_COMPLETA
  *
  *    Data Criacao:  18/08/2009   Por: pedro
  *    Data Alteracao:  02/09/2010         Por: Pedro
  *    verifica o ult paciente do atd
  *
  *    Data Alteracao:  17/09/2010         Por:Eduardo Hyppolito
  *    Motivo: Inserir Tipo de acomodac?o
  *    Funcao: Etiqueta
  *    Data Alteracao:  18/03/2011  Motivo: pegar tipo acomodac?o da movimentac?o
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
IAE_ATD INT;
AIC_ATD INT;
begin
SELECT COUNT(*) INTO AIC_ATD FROM TB_ATD_ATE_ATENDIMENTO ATD
                             JOIN TB_ATD_AIC_ATE_INT_COMPL AIC
                             ON   AIC.ATD_ATE_ID = ATD.ATD_ATE_ID
                             WHERE ATD.ATD_ATE_ID = pATD_ATE_ID;
SELECT COUNT(*) INTO IAE_ATD FROM TB_ATD_IAE_INT_AGE_ELETIVA IAE WHERE IAE.ATD_IAE_ID = pATD_ATE_ID;
IF IAE_ATD > 0 AND AIC_ATD = 0 THEN
 OPEN v_cursor FOR
  SELECT DISTINCT
               'P' INTERNACAO_PRECADASTRO,
               IAE.ATD_IAE_ID ATD_ATE_ID,
               to_char(IAE.ATD_IAE_DT_ATENDIMENTO,'dd/MM/yyyy') ATD_ATE_DT_ATENDIMENTO,
               lpad(TO_char(IAE.ATD_IAE_HR_ATENDIMENTO),'4','0')ATD_ATE_HR_ATENDIMENTO,
               IAE.CODPAD PADRAO,
               DECODE(IAE.ATD_IAE_TP_PACIENTE,'I','INTERNO','E','EXTERNO') ATD_ATE_TP_PACIENTE,
               CNV.CAD_CNV_CD_HAC_PRESTADOR || ' - ' || substr(CNV.CAD_CNV_NM_FANTASIA,0,25) CAD_CNV_CD_HAC_PRESTADOR,
               CNV.CAD_CNV_NM_FANTASIA,
               PLA.CAD_PLA_CD_TIPOPLANO,
               PLA.CAD_PLA_CD_PLANO_HAC,
               PLA.CAD_PLA_NM_NOME_PLANO,
               PES_UNI.CAD_PES_NM_PESSOA UNIDADE,
               PES.CAD_PES_NR_RG,
               to_char(PAC_IAE.CAD_PAC_DT_VALIDADECREDENCIAL,'dd/MM/yyyy') CAD_PAC_DT_VALIDADECREDENCIAL,
                '' TIPO_INTERNACAO,
               '' CAD_QLE_TP_QUARTO_LEITO,
               '' CAD_QLE_NR_QUARTO,
               '' CAD_QLE_NR_LEITO,
               PAC_IAE.CAD_PAC_CD_CREDENCIAL,
               PAC_IAE.CAD_PAC_NR_PRONTUARIO,
               PES.CAD_PES_NM_PESSOA PACIENTE,
               to_char(PES.CAD_PES_DT_NASCIMENTO,'dd/MM/yyyy') CAD_PES_DT_NASCIMENTO,
               PES.CAD_PES_TP_SEXO,
               END.CAD_END_NM_LOGRADOURO,
               END.CAD_END_DS_NUMERO,
               END.CAD_END_DS_COMPLEMENTO,
               END.CAD_END_NM_BAIRRO,
               END.CAD_END_SG_UF,
               MUN.AUX_MUN_NM_MUNICIPIO,
               FNC_RETORNA_TEL_PAC(PES.CAD_PES_ID_PESSOA) CAD_TEL_NR_NUM_TEL,
               FLOOR(FLOOR(MONTHS_BETWEEN(SYSDATE, PES.CAD_PES_DT_NASCIMENTO)) / 12) IDADE,
               null TIS_TAC_DS_TIPO_ACOMODACAO,
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01' THEN
                DECODE(FNC_VERIFICA_INSGER( TO_CHAR(PLA.CAD_PLA_CD_PLANO_HAC),
                                            TO_NUMBER(SUBSTR(PAC_IAE.CAD_PAC_CD_CREDENCIAL,0,3)) ,
                                            TO_NUMBER(SUBSTR(PAC_IAE.CAD_PAC_CD_CREDENCIAL,4,7)),
                                            TO_NUMBER(SUBSTR(PAC_IAE.CAD_PAC_CD_CREDENCIAL,11,2))),0,'',1,'GER',2,'GER',4,'A.ALTA')
               ELSE '' END GER
 FROM
                TB_ATD_IAE_INT_AGE_ELETIVA    IAE
  JOIN          TB_CAD_PAC_PACIENTE       PAC_IAE
  ON            PAC_IAE.CAD_PAC_ID_PACIENTE = IAE.CAD_PAC_ID_PACIENTE
  JOIN          TB_CAD_PES_PESSOA         PES
  ON            PES.CAD_PES_ID_PESSOA   = PAC_IAE.CAD_PES_ID_PESSOA
  JOIN          TB_CAD_CNV_CONVENIO       CNV
  ON            CNV.CAD_CNV_ID_CONVENIO = PAC_IAE.CAD_CNV_ID_CONVENIO
  JOIN          TB_CAD_PLA_PLANO          PLA
  ON            PLA.CAD_PLA_ID_PLANO    = PAC_IAE.CAD_PLA_ID_PLANO
  JOIN          TB_CAD_UNI_UNIDADE         UNI
  ON            UNI.CAD_UNI_ID_UNIDADE  = IAE.CAD_UNI_ID_UNIDADE
  JOIN          TB_CAD_PES_PESSOA          PES_UNI
  ON            PES_UNI.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
--  LEFT JOIN     TB_ASS_PEE_PESSOA_ENDERECO  PEE
--  ON            PEE.CAD_PES_ID_PESSOA     = PES.CAD_PES_ID_PESSOA
  LEFT JOIN     TB_CAD_END_ENDERECO         END
  ON            END.CAD_PES_ID_PESSOA   = PES.CAD_PES_ID_PESSOA
  LEFT JOIN     TB_AUX_MUN_MUNICIPIO        MUN
  ON            MUN.AUX_MUN_CD_IBGE       = END.AUX_MUN_CD_IBGE
   WHERE IAE.ATD_IAE_ID = pATD_ATE_ID;
  io_cursor := v_cursor;
    ELSE
 OPEN v_cursor FOR
 SELECT DISTINCT
               'I' INTERNACAO_PRECADASTRO,
               ATD.ATD_ATE_ID ,
               to_char(ATD.ATD_ATE_DT_ATENDIMENTO,'dd/MM/yyyy') ATD_ATE_DT_ATENDIMENTO,
               lpad(TO_char(ATD.ATD_ATE_HR_ATENDIMENTO),'4','0')ATD_ATE_HR_ATENDIMENTO,
               ATD.CODPAD PADRAO,
               DECODE(ATD_ATE_TP_PACIENTE,'I','INTERNO','E','EXTERNO') ATD_ATE_TP_PACIENTE,
               CNV.CAD_CNV_CD_HAC_PRESTADOR || ' - ' || substr(CNV.CAD_CNV_NM_FANTASIA,0,25) CAD_CNV_CD_HAC_PRESTADOR,
               CNV.CAD_CNV_NM_FANTASIA,
               PLA.CAD_PLA_CD_TIPOPLANO,
               PLA.CAD_PLA_CD_PLANO_HAC,
               PLA.CAD_PLA_NM_NOME_PLANO,
               PES_UNI.CAD_PES_NM_PESSOA UNIDADE,
               PES.CAD_PES_NR_RG,
               to_char(PAC.CAD_PAC_DT_VALIDADECREDENCIAL,'dd/MM/yyyy') CAD_PAC_DT_VALIDADECREDENCIAL,
               CASE WHEN (ULT_IML.ATD_IML_FL_CORTESIA = 'S') THEN
               'CORTESIA'
                    WHEN (ULT_IML.ATD_IML_FL_DIF_CLASSE = 'S') THEN
               'DIF.CLASSE'
                    WHEN (ULT_IML.ATD_IML_FL_CORTESIA = 'N')
                    AND (ULT_IML.ATD_IML_FL_DIF_CLASSE = 'N') THEN
               'PADR?O'
               end TIPO_INTERNACAO,
               DECODE(ULT_IML.CAD_QLE_TP_QUARTO_LEITO,'I','INTERNO','E','EXTRA') CAD_QLE_TP_QUARTO_LEITO,
               ULT_IML.CAD_QLE_NR_QUARTO,
               ULT_IML.CAD_QLE_NR_LEITO,
               PAC.CAD_PAC_CD_CREDENCIAL,
               PAC.CAD_PAC_NR_PRONTUARIO,
               PES.CAD_PES_NM_PESSOA PACIENTE,
               to_char(PES.CAD_PES_DT_NASCIMENTO,'dd/MM/yyyy') CAD_PES_DT_NASCIMENTO,
               PES.CAD_PES_TP_SEXO,
               END.CAD_END_NM_LOGRADOURO,
               END.CAD_END_DS_NUMERO,
               END.CAD_END_DS_COMPLEMENTO,
               END.CAD_END_NM_BAIRRO,
               END.CAD_END_SG_UF,
               MUN.AUX_MUN_NM_MUNICIPIO,
               FNC_RETORNA_TEL_PAC(PES.CAD_PES_ID_PESSOA) CAD_TEL_NR_NUM_TEL,
               FLOOR(FLOOR(MONTHS_BETWEEN(SYSDATE, PES.CAD_PES_DT_NASCIMENTO)) / 12) IDADE,
               ult_iml.TIS_TAC_DS_TIPO_ACOMODACAO,
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01' THEN
                DECODE(FNC_VERIFICA_INSGER( TO_CHAR(PLA.CAD_PLA_CD_PLANO_HAC),
                                            TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,0,3)) ,
                                            TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,4,7)),
                                            TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,11,2))),0,'',1,'GER',2,'GER',4,'A.ALTA')
               ELSE '' END GER
  FROM
                TB_ATD_ATE_ATENDIMENTO     ATD
  JOIN          TB_ASS_PAT_PACIEATEND      PAT
  ON            PAT.ATD_ATE_ID           = ATD.ATD_ATE_ID
  JOIN          TB_CAD_PAC_PACIENTE        PAC
  ON            PAC.CAD_PAC_ID_PACIENTE  = FNC_BUSCAR_PACIENTE_ATUAL(PAT.ATD_ATE_ID)
  JOIN          TB_CAD_PES_PESSOA         PES
  ON            PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
  JOIN          TB_CAD_CNV_CONVENIO       CNV
  ON            CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
  JOIN          TB_CAD_PLA_PLANO          PLA
  ON            PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
  JOIN          TB_ATD_AIC_ATE_INT_COMPL  AIC
  ON            AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
  JOIN          TB_CAD_UNI_UNIDADE UNI
  ON            UNI.CAD_UNI_ID_UNIDADE  = ATD.CAD_UNI_ID_UNIDADE
  LEFT JOIN     TB_ATD_IAE_INT_AGE_ELETIVA IAE
  ON            IAE.ATD_IAE_ID          = ATD.ATD_ATE_ID
  JOIN          TB_CAD_PES_PESSOA          PES_UNI
  ON            PES_UNI.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
--  LEFT JOIN     TB_ASS_PEE_PESSOA_ENDERECO  PEE
--  ON            PEE.CAD_PES_ID_PESSOA     = PES.CAD_PES_ID_PESSOA
  LEFT JOIN     TB_CAD_END_ENDERECO         END
  ON            END.CAD_PES_ID_PESSOA       = PES.CAD_PES_ID_PESSOA
  LEFT JOIN     TB_AUX_MUN_MUNICIPIO        MUN
  ON            MUN.AUX_MUN_CD_IBGE       = END.AUX_MUN_CD_IBGE
LEFT JOIN  (    SELECT QLE.CAD_QLE_NR_QUARTO,CAD_QLE_NR_LEITO, TIS.TIS_TAC_DS_TIPO_ACOMODACAO,
                        CAD_QLE_TP_QUARTO_LEITO,
                       IML.ATD_ATE_ID, IML.ATD_IML_FL_CORTESIA,IML.ATD_IML_FL_DIF_CLASSE
                 FROM      TB_ATD_IML_INT_MOV_LEITO IML
                 JOIN TB_CAD_QLE_QUARTO_LEITO QLE
                 ON        QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN      TB_ATD_ATE_ATENDIMENTO ATD2
                 ON        ATD2.ATD_ATE_ID = IML.ATD_ATE_ID
                 JOIN      TB_TIS_TAC_TIPO_ACOMODACAO TIS
                 ON        TIS.TIS_TAC_CD_TIPO_ACOMODACAO = IML.TIS_TAC_CD_TIPO_ACOMODACAO
                 WHERE       FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) =
                                         (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML3.ATD_IML_DT_ENTRADA,IML3.ATD_IML_HR_ENTRADA)) FROM TB_ATD_IML_INT_MOV_LEITO IML3
                                                       WHERE IML3.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IML3.ATD_IML_FL_STATUS = 'A')
              )  ULT_IML
  ON ULT_IML.ATD_ATE_ID = ATD.ATD_ATE_ID
   WHERE     ATD.ATD_ATE_ID = pATD_ATE_ID;
     io_cursor := v_cursor;
  END IF;
end PRC_INT_ETIQUETA_COMPLETA;