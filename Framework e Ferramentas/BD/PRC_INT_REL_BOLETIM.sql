create or replace procedure PRC_INT_REL_BOLETIM
  (
   pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
   io_cursor              OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_REL_BOLETIM
  *
  *    Data Criacao:  31/08/2009   Por: pedro
  *    Data Alteracao:           Por:
  *
  *    Funcao: Popula o Relatorio de Guias a vencer
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;

begin

  OPEN v_cursor FOR
SELECT
               ATD.ATD_ATE_ID,
               PES.CAD_PES_NM_PESSOA PACIENTE,
               PAC.CAD_PAC_NR_PRONTUARIO,
               CNV.CAD_CNV_CD_HAC_PRESTADOR,
               CNV.CAD_CNV_NM_FANTASIA,
               DECODE(PES.CAD_PES_TP_SEXO,'F','FEMININO','M','MASCULINO') CAD_PES_TP_SEXO,
               to_char(PES.CAD_PES_DT_NASCIMENTO,'dd/MM/yyyy') CAD_PES_DT_NASCIMENTO,

               ATD.CODPAD PADRAO,
               DECODE(PES.CAD_PES_CD_ESTADOCIVIL,'1','Solteiro','2','Casado','3','Separado','4','Divorciado',
               '5','Viuvo','6','Uniao Estavel') CAD_PES_CD_ESTADOCIVIL,
               FLOOR(FLOOR(MONTHS_BETWEEN(DECODE(INA.ATD_INA_DT_ALTA_ADM,NULL,ATD.ATD_ATE_DT_ATENDIMENTO,INA.ATD_INA_DT_ALTA_ADM), PES.CAD_PES_DT_NASCIMENTO)) / 12) idade,
               ATD.ATD_ATE_DT_ATENDIMENTO,
               ATD.ATD_ATE_HR_ATENDIMENTO,
               IML_QLE.CAD_QLE_NR_QUARTO,
               IML_QLE.CAD_QLE_NR_LEITO,
               PES.CAD_PES_NM_NATURALIDADE,
               PES.CAD_PES_NM_CONJUGE,
               MUN.AUX_MUN_NM_MUNICIPIO,
               PES.CAD_PES_NM_NOMEMAE,
               PES.CAD_PES_NM_NOMEPAI,
               fnc_retorna_tel_pac(PES.CAD_PES_ID_PESSOA) TELEFONE,
               NAC.AUX_NAC_NM_NOME,
               END.CAD_END_NM_LOGRADOURO,
               END.CAD_END_NM_BAIRRO,
               END.CAD_END_DS_NUMERO,
               END.CAD_END_DS_COMPLEMENTO,
               PROF.AUX_PRF_DS_DESCRICAO,
               PAC.CAD_PAC_CD_CREDENCIAL,
               to_char(PAC.CAD_PAC_DT_VALIDADECREDENCIAL,'dd/MM/yyyy') CAD_PAC_DT_VALIDADECREDENCIAL,

               PLA.CAD_PLA_DT_FIM_VIGENCIA,
               PLA.CAD_PLA_CD_PLANO_HAC,

               DECODE(ATD.ATD_ATE_FL_CARATER_SOLIC,'U','URGENCIA','E','ELETIVA') ATD_ATE_FL_CARATER_SOLIC,
               CID.CAD_CID_DS_CID10,
               PRO_ATD.CAD_PRO_NM_NOME PROF_RESPONSAVEL,
               PRO_ATD.CAD_PRO_NR_CONSELHO NR_CONSELHO_RESP,
               PRO_AIC.CAD_PRO_NM_NOME PROF_ADMISSAO,
               PRO_AIC.CAD_PRO_NR_CONSELHO NR_CONSELHO_ADMIS


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
  JOIN          TB_ATD_AIC_ATE_INT_COMPL  AIC
  ON            AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
  LEFT JOIN     TB_ATD_INA_INT_ALTA       INA
  ON            INA.ATD_ATE_ID          = ATD.ATD_ATE_ID
  LEFT JOIN     TB_CAD_UNI_UNIDADE        UNI
  ON            UNI.CAD_UNI_ID_UNIDADE  = ATD.CAD_UNI_ID_UNIDADE
  LEFT JOIN     TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
  ON            LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
  LEFT JOIN          TB_ATD_GUI_GUIAATEND      GUI
  ON            GUI.ATD_ATE_ID          = ATD.ATD_ATE_ID
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
--  LEFT JOIN     TB_ASS_PEE_PESSOA_ENDERECO  PEE
--  ON            PEE.CAD_PES_ID_PESSOA     = PES.CAD_PES_ID_PESSOA
  LEFT JOIN     TB_CAD_END_ENDERECO         END
  ON            END.CAD_PES_ID_PESSOA   = PES.CAD_PES_ID_PESSOA
  LEFT JOIN     TB_AUX_MUN_MUNICIPIO        MUN
  ON            MUN.AUX_MUN_CD_IBGE       = END.AUX_MUN_CD_IBGE
  LEFT JOIN     TB_AUX_PRF_PROFISSAO        PROF
  ON            PROF.AUX_PRF_CD_CODIGO    = PES.AUX_PRF_CD_CODIGO
  LEFT JOIN          TB_CAD_CID_CID10            CID
  ON            CID.CAD_CID_CD_CID10      = ATD.CAD_CID_CD_CID10
  LEFT JOIN          TB_CAD_PRO_PROFISSIONAL     PRO_ATD
  ON            PRO_ATD.CAD_PRO_ID_PROFISSIONAL = ATD.CAD_PRO_ID_PROF_EXEC
  LEFT JOIN          TB_CAD_PRO_PROFISSIONAL     PRO_AIC
  ON            PRO_AIC.CAD_PRO_ID_PROFISSIONAL = AIC.CAD_PRO_ID_PROF_ADM
  LEFT JOIN     TB_AUX_NAC_NACIONALIDADE    NAC
  ON            NAC.AUX_NAC_CD_CODIGO     = PES.AUX_NAC_CD_CODIGO

  WHERE (pATD_ATE_ID IS NULL OR ATD.ATD_ATE_ID = pATD_ATE_ID)

  ;
  io_cursor := v_cursor;
end PRC_INT_REL_BOLETIM;
