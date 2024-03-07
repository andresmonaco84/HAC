create or replace procedure PRC__BENEFICIARIO_SID
  (
     pCODBEN IN BNF_BENEFICIARIO.CODBEN%type,
     pCODCON IN BNF_BENEFICIARIO.CODCON%type,
     pCODEST IN BNF_BENEFICIARIO.CODEST%type,
     pCODSEQBEN IN BNF_BENEFICIARIO.CODSEQBEN%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC__BENEFICIARIO_SID
  *
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CODCON,
       CODEST,
       CODBEN,
       CODSEQBEN,
       NOMBEN,
       CODPADATEBEN,
       CODPADCOBBEN,
       CODINDBEN,
       SEXBEN,
       CODGRAPAR,
       ESTCIVBEN,
       DATNASBEN,
       DATINGCONBEN,
       DATADMEMP,
       DATSAICONBEN,
       OCUEMPBEN,
       CARPROBEN,
       CODSITBEN,
       DATLIMBEN,
       DATSITBEN,
       CPFBEN,
       RGBEN,
       CODACO,
       CODPLA,
       VALCOB,
       CODTIPPAD,
       DATEMIEXC,
       SITATI,
       CODTIPCARBEN,
       INDPAG,
       DT_ATU_INDPAG,
       IND_NEGOCIACAO,
       DATFATOD,
       IDADEBEN,
       MAEBEN,
       CANC_ANS,
       ID_AUTORIZACAO_ANS,
       VLPERC,
       CODPRO,
       DATALTBEN,
       CD_EMPRESA,
       ID_COPART_EXAME,
       ID_COPART_CONSULTA,
       ID_CRONICO,
       CO_PART,
       ID_EMISSAO_CARTEIRINHA,
       VL_COBRANCA_ATUAL,
       DT_COBRANCA_ATUAL,
       DT_REF_COBRANCA_ATUAL,
       DT_EMISSAO_CARTEIRINHA,
       ID_CONTENCIOSO,
       DS_CONTENCIOSO,
       ID_SUSPENSAO_BOLETO,
       ID_DOENTE_CRONICO,
       CD_CID_CRONICO,
       ID_REPASSE,
       DT_EXCLUSAO_FATURA,
       CD_LOCAL_REPASSE,
       ID_PAC,
       ID_CURATIVO,
       DT_INI_CURATIVO,
       ID_HOMECARE,
       DT_INI_HOMECARE,
       ID_MEDFAMILIA,
       DT_INI_MEDFAMILIA,
       ID_SEGURO_REMISSAO,
       ID_PLANO_BEM,
       DT_INI_CRONICO,
       DT_INI_PLANO_BEM,
       DT_INICIO_REPASSE,
       DT_FINAL_REPASSE,
       CD_EMPRESA_REPASSE,
       DS_LOCALIDADE,
       ID_EMPRESA_REPASSADA,
       DT_FIM_PLANO_BEM,
       CD_PLANO_BEM,
       ID_ACESSORIO,
       CODNAC,
       CODPAIS,
       ORGAO_EMISSOR_RG,
       PAIS_EMISSOR_RG,
       PISPASEP,
       IND_ACIDENTE_TRABALHO,
       CODPAC,
       DOCBEN,
       COD_NATDOC,
       DT_EXPEDOC,
       COD_ATIVPRINC,
       IDOPER,
       ID_CARTAO_AUTORIZADOR,
       DT_CARTAO_AUTORIZADOR,
       NM_REDUZIDO,
       DS_LOGIN,
       CD_CCO,
       DV_CCO,
       CDPLANOANS_ORIGEM
    FROM BNF_BENEFICIARIO
    WHERE
        CODBEN = pCODBEN
    AND CODCON = pCODCON
    AND CODEST = pCODEST
    AND CODSEQBEN = pCODSEQBEN;
    io_cursor := v_cursor;
  end PRC__BENEFICIARIO_SID;
