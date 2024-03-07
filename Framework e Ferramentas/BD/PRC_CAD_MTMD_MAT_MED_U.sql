CREATE OR REPLACE PROCEDURE SGS.PRC_CAD_MTMD_MAT_MED_U(pCAD_MTMD_GRUPO_ID         IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_GRUPO_ID%type,
                                                       pCAD_MTMD_SUBGRUPO_ID      IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_SUBGRUPO_ID%type,
                                                       pCAD_MTMD_NOMEFANTASIA     IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_NOMEFANTASIA%type,
                                                       pCAD_MTMD_DESCRICAO        IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_DESCRICAO%type,
                                                       pCAD_MTMD_CD_FABRICANTE    IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_CD_FABRICANTE%type default NULL,
                                                       pCAD_MTMD_FL_FRACIONA      IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_FRACIONA%type,
                                                       pCAD_MTMD_FL_ATIVO         IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_ATIVO%type default NULL,
                                                       pCAD_MTMD_CD_RM            IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_CD_RM%type default NULL,
                                                       pCAD_MTMD_FL_CONTROLA_LOTE IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_CONTROLA_LOTE%type default NULL,
                                                       pCODUNDCONTROLE            IN VARCHAR,
                                                       pCODUNDVENDA               IN VARCHAR,
                                                       pCODUNDCOMPRA              IN VARCHAR,
                                                       pCODIGOPRD                 IN VARCHAR,
                                                       vGOTAS                     IN NUMBER) is

  /********************************************************************
  *    Procedure: PRC_CAD_MTMD_MAT_MED_U
  *
  *    Data Criacao:   2009  Por: Ricardo
  *    Data Alteracao:  5/9/11  Por: Andre
  *         Alteracao:  Retirada da busca no legado do mneumo
  *    Data Alteracao:  14/11/11  Por: Andre
  *         Alteracao:  n?o usar mais CAD_MTMD_CD_RM (IDPRD), apenas o CODIGOPRD como chave
  *    Data Alteracao:  29/04/13  Por: Andre
  *         Alteracao:  Ajustes para nova vers?o do RM
  *    Data Alteracao:  15/08/13  Por: Andre
  *         Alteracao:  SE INATIVAR E TIVER SALDO, BARRAR
  *    Data Alteracao:  15/09/15  Por: Andre
  *         Alteracao:  N?o atualizar CAD_MTMD_PRIATI_ID
  *    Data Alteracao:  13/12/16  Por: Andre
  *         Alteracao:  Barrar produto fracionado com saldo no ACS
  *
  *    Funcao: Grava produto
  *******************************************************************/

  nGrupo             SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_grupo_id%TYPE;
  nSubGrupo          SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_subgrupo_id%TYPE;
  nPrincAtivo        SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_priati_id%TYPE;
  bExistePA          BOOLEAN;
  pIMOBILIZADO       SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_fl_imobilizado%TYPE;
  pCONSIGNADO        SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_fl_consignado%TYPE;
  pBAIXA_AUTOMATICA  SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_fl_baixa_automatica%TYPE;
  pPADRONIZADO       SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_fl_padrao%TYPE;
  pMATMED            SGS.TB_CAD_MTMD_MAT_MED.tis_med_cd_tabelamedica%TYPE;
  pANVISA            SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_CD_ANVISA%TYPE;
  pRM_FATOR_CONTROLE SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_unidade_controle%TYPE;
  pRM_FATOR_VENDA    SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_unidade_venda%TYPE;
  pRM_FATOR_COMPRA   SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_unidade_compra%TYPE;
  pDS_CONTROLE       SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_unid_controle_ds%TYPE;
  pDS_VENDA          SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_unid_venda_ds%TYPE;
  pDS_COMPRA         SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_unid_compra_ds%TYPE;
  --pCODMNEMAT          SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_codmne%TYPE;
  pCODGRUMAT         SGS.TB_CAD_MTMD_MAT_MED.codgrumat%TYPE;
  nIdt               SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_ID%type;
  pALTAVIGILANCIA    SGS.TB_CAD_MTMD_MAT_MED.cad_mtmd_fl_mav%TYPE;
  pPEDPAD_QTDE       SGS.TB_MTMD_PEDIDO_PADRAO_ITENS.MTMD_PEDPAD_QTDE%TYPE;
  vSal               VARCHAR2(10);
  vSalDesc           VARCHAR2(100);
  vForma             VARCHAR2(10);
  vFormaDesc         VARCHAR2(100);
  vDosagem           VARCHAR2(10);
  vDosagemDesc       VARCHAR2(100);

begin

  -- GRUPOS =======================================================================================
  IF (pCAD_MTMD_GRUPO_ID IS NULL) THEN
    nGrupo := 0;
  ELSE
    nGrupo := pCAD_MTMD_GRUPO_ID;
    FOR grupo IN (SELECT CODTB3FAT,
                         SUBSTR(DESCRICAO, 1, 50) DESCRICAO,
                         DECODE(INATIVO, 0, 1, 0) INATIVO
                    FROM TTB3@RMDB
                   WHERE CODTB3FAT = nGrupo
                     AND CODCOLIGADA = 1) LOOP
      BEGIN
        INSERT INTO SGS.TB_CAD_MTMD_GRUPO
          (CAD_MTMD_GRUPO_ID, CAD_MTMD_GRUPO_DESCRICAO, CAD_MTMD_FL_ATIVO)
        VALUES
          (nGrupo, grupo.DESCRICAO, grupo.INATIVO);
      EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
          -- SE JA EXISTIR IGNORA
          NULL;
        WHEN OTHERS THEN
          -- DBMS_OUTPUT.PUT_LINE(' GRUPO '||TO_CHAR(grupo.CODTB3FAT)||' DESCRICAO '||grupo.DESCRICAO);
          RAISE_APPLICATION_ERROR(-20001,
                                  ' ERRO CADASTRO GRUPO ' ||
                                  TO_CHAR(grupo.CODTB3FAT) || ' DESCRICAO ' ||
                                  grupo.DESCRICAO);
      END;
    END LOOP;
  END IF;

  --SE INATIVAR E TIVER SALDO, BARRAR
  IF (pCAD_MTMD_FL_ATIVO = 0) THEN
    SELECT CAD_MTMD_ID
      INTO nIdt
      FROM TB_CAD_MTMD_MAT_MED
     WHERE TRIM(CAD_MTMD_CODMNE) = TRIM(pCODIGOPRD);
    IF (FNC_MTMD_ESTOQUE_CONTABIL(nIdt, 1) > 0 or
       FNC_MTMD_ESTOQUE_CONTABIL(nIdt, 2) > 0) THEN
      RAISE_APPLICATION_ERROR(-20099,
                              'PRODUTO COM SALDO EM ESTOQUE E NAO PODE SER INATIVADO.');
    END IF;

    --SE TIVER CADASTRO DE PADRAO TAMBEM BARAR
    SELECT NVL(SUM(PI.MTMD_PEDPAD_QTDE), 0)
      INTO pPEDPAD_QTDE
      FROM TB_MTMD_PEDIDO_PADRAO_ITENS PI
      JOIN TB_MTMD_PEDIDO_PADRAO P ON P.MTMD_PEDPAD_ID = PI.MTMD_PEDPAD_ID
      JOIN TB_CAD_SET_SETOR S ON S.CAD_SET_ID = P.CAD_SET_ID
      JOIN TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = PI.CAD_MTMD_ID
     WHERE TRIM(M.CAD_MTMD_CODMNE) = TRIM(pCODIGOPRD)
       AND S.CAD_SET_FL_ATIVO_OK = 'S'
       AND (S.CAD_SET_FL_SUBSTALMOX_OK = 'S' OR S.CAD_SET_ALMOX_CENTRAL = 1);
    IF (pPEDPAD_QTDE > 0) THEN
      RAISE_APPLICATION_ERROR(-20099,
                              'PRODUTO COM ESTOQUE PADRAO CADASTRADO NO ALMOXARIFADO NAO PODENDO SER INATIVADO.');
    END IF;
  END IF;

  --SE PRODUTO TIVER SENDO ALTERADO PARA MATERIAL OU FRACIONADO E TIVER SALDO NO ACS, BARRAR
  IF (pCAD_MTMD_FL_FRACIONA = 1 OR pCAD_MTMD_GRUPO_ID != 1) THEN
    BEGIN
      SELECT CAD_MTMD_ID
        INTO nIdt
        FROM TB_CAD_MTMD_MAT_MED
       WHERE TRIM(CAD_MTMD_CODMNE) = TRIM(pCODIGOPRD);
      IF (FNC_MTMD_ESTOQUE_CONTABIL(nIdt, 2) > 0) THEN
        RAISE_APPLICATION_ERROR(-20099,
                                'PRODUTO COM SALDO EM ESTOQUE NO ACS, NAO PODE SER MATERIAL OU FRACIONADO.');
      END IF;
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        NULL;
    END;
  END IF;

  --SUB GRUPOS  ===================================================================================
  IF (pCAD_MTMD_SUBGRUPO_ID IS NULL) THEN
    nSubGrupo := 0;
  ELSE
    nSubGrupo := pCAD_MTMD_SUBGRUPO_ID;

    -- VERIFICA SE SUBGRUPO FOI ALTERADO, TEM QUE INFORMAR NA MOVIMENTAC?O DA CONTABILIADE PARA
    -- TRANSFERIR SALDO
    FOR sub IN (SELECT CODTB4FAT,
                       SUBSTR(DESCRICAO, 1, 50) DESCRICAO,
                       DECODE(INATIVO, 0, 1, 0) INATIVO
                  FROM TTB4@RMDB
                 WHERE CODTB4FAT = nSubGrupo
                   AND CODCOLIGADA = 1) LOOP
      BEGIN
        INSERT INTO SGS.TB_CAD_MTMD_SUBGRUPO
          (CAD_MTMD_SUBGRUPO_ID,
           CAD_MTMD_GRUPO_ID,
           CAD_MTMD_SUBGRUPO_DESCRICAO)
        VALUES
          (nSubGrupo, nGrupo, sub.DESCRICAO);
      EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
          -- SE JA EXISTIR IGNORA
          NULL;
        WHEN OTHERS THEN
          RAISE_APPLICATION_ERROR(-20001,
                                  ' SUB GRUPO ' || TO_CHAR(nSubGrupo) ||
                                  ' DESCRICAO ' || SUB.DESCRICAO || ' ' ||
                                  SQLERRM);
      END;
    END LOOP;
  END IF;

  -- PRINCIPIO ATIVO ==============================================================================
  -- VERIFICO SE JA TEM ALGUM MATMED COM MESMO P.A. CADASTRADO PARA PEGAR ID DO P.A.
  nPrincAtivo := 0;
  bExistePA   := FALSE;
  FOR pa IN (SELECT SIM.*, TPRD.CODIGOPRD
               FROM TPRDSIMILAR@RMDB SIM, TPRODUTO@RMDB TPRD
              WHERE SIM.IDPRD = TPRD.IDPRD
                AND TRIM(TPRD.CODIGOPRD) = TRIM(pCODIGOPRD)
                AND SIM.CODCOLIGADA = 1) LOOP

    -- BUSCO NO GEM ALGUM PRODUTO CADASTRADO COM MESMO P.A.
    -- PODE EXISTIR VARIOS
    bExistePA := TRUE;
    FOR gem IN (SELECT CAD_MTMD_PRIATI_ID
                  FROM SGS.TB_CAD_MTMD_MAT_MED
                 WHERE TRIM(CAD_MTMD_CODMNE) = TRIM(pa.CODIGOPRD)) LOOP
      nPrincAtivo := gem.CAD_MTMD_PRIATI_ID;
      EXIT;
    END LOOP;
  END LOOP;

  -- NAO ACHOU, CRIA REGISTRO NA TABELA DE P.A.
  IF (bExistePA = TRUE) THEN
    IF (nPrincAtivo = 0) THEN
      SELECT SGS.SEQ_PRINCIPIO_ATIVO.NEXTVAL INTO nPrincAtivo FROM DUAL;
      INSERT INTO SGS.TB_CAD_MTMD_PRIATI_PRINC_ATIVO
        (CAD_MTMD_PRIATI_ID, CAD_MTMD_PRIATI_DESCRICAO)
      VALUES
        (nPrincAtivo, TO_CHAR(nPrincAtivo) || ' ALTERAR ');
    END IF;
  END IF;

  -- ==============================================================================================

  -- COMPLEMENTOS
  BEGIN
    SELECT DECODE(NVL(COMPLE.IMOBILIZADO, 0), 'N', 0, 1) IMOBILIZADO,
           DECODE(COMPLE.MATCONSIGNADO, 'N', 0, 1) CONSIGNADO,
           DECODE(NVL(COMPLE.BAIXAAUTOMATICA, 0), 'N', 0, 1) BAIXA_AUTOMATICA,
           DECODE(COMPLE.PADRONIZADO, 'N', 0, 1),
           DECODE(NVL(COMPLE.MATMED, ''), 'MA', '95', 'ME', '96'),
           COMPLE.ANVISA,
           COMPLE.ALTAVIGILANCIA,
           COMPLE.SAL,
           COMPLE.FORMA_FARMACEUTICA,
           COMPLE.DOSAGEM
      INTO pIMOBILIZADO,
           pCONSIGNADO,
           pBAIXA_AUTOMATICA,
           pPADRONIZADO,
           pMATMED,
           pANVISA,
           pALTAVIGILANCIA,
           vSal,
           vForma,
           vDosagem
      FROM TPRDCOMPL@RMDB COMPLE, TPRODUTO@RMDB TPRD
     WHERE COMPLE.IDPRD = TPRD.IDPRD
       AND COMPLE.CODCOLIGADA = 1
       AND COMPLE.CODCOLIGADA = 1
       AND TRIM(TPRD.CODIGOPRD) = TRIM(pCODIGOPRD);
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      pIMOBILIZADO      := 0;
      pCONSIGNADO       := 0;
      pBAIXA_AUTOMATICA := 0;
      pPADRONIZADO      := 0;
      pMATMED           := '95';
      pANVISA           := NULL;
      pALTAVIGILANCIA   := 'N';
      vSal              := NULL;
      vForma            := NULL;
      vDosagem          := NULL;
  END;

  -- BUSCA DESCRI€ÇO DE TABELAS DINAMICAS;
  BEGIN
    SELECT A.DESCRICAO
      INTO vSalDesc
      FROM GCONSIST@RMDB A
     WHERE A.CODCOLIGADA = 1
       AND A.APLICACAO = 'T'
       AND A.CODTABELA = 'SAL'
       AND A.CODINTERNO = vSal;
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      vSalDesc := NULL;
  END;

  BEGIN
    SELECT A.DESCRICAO
      INTO vFormaDesc
      FROM GCONSIST@RMDB A
     WHERE A.CODCOLIGADA = 1
       AND A.APLICACAO = 'T'
       AND A.CODTABELA = 'FORMA'
       AND A.CODINTERNO = vForma;
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      vFormaDesc := NULL;
  END;

  BEGIN
    SELECT A.DESCRICAO
      INTO vDosagemDesc
      FROM GCONSIST@RMDB A
     WHERE A.CODCOLIGADA = 1
       AND A.APLICACAO = 'T'
       AND A.CODTABELA = 'DOSAGEM'
       AND A.CODINTERNO = vDosagem;
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      vDosagemDesc := NULL;
  END;

  -- ==============================================================================================
  -- UNIDADES
  IF (pCODUNDCONTROLE IS NOT NULL AND pCODUNDVENDA IS NOT NULL AND
     pCODUNDCOMPRA IS NOT NULL) THEN
    BEGIN
      SELECT UNIDADE_CONTROLE.FATORCONVERSAO RM_FATOR_CONTROLE, -- dispensado do almoxarifado
             UNIDADE_VENDA.FATORCONVERSAO    RM_FATOR_VENDA, -- unidade das alas
             UNIDADE_COMPRA.FATORCONVERSAO   RM_FATOR_COMPRA, -- usado em compras
             UNIDADE_CONTROLE.DESCRICAO      DS_CONTROLE,
             UNIDADE_VENDA.DESCRICAO         DS_VENDA,
             UNIDADE_COMPRA.DESCRICAO        DS_COMPRA
        INTO pRM_FATOR_CONTROLE,
             pRM_FATOR_VENDA,
             pRM_FATOR_COMPRA,
             pDS_CONTROLE,
             pDS_VENDA,
             pDS_COMPRA
        FROM TUND@RMDB UNIDADE_CONTROLE,
             TUND@RMDB UNIDADE_VENDA,
             TUND@RMDB UNIDADE_COMPRA
       WHERE UNIDADE_CONTROLE.CODUND = pCODUNDCONTROLE
         AND UNIDADE_VENDA.CODUND = pCODUNDVENDA
         AND UNIDADE_COMPRA.CODUND = pCODUNDCOMPRA;
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        NULL;
    END;
  END IF;

  -- ==============================================================================================
  --pCODMNEMAT := pCODIGOPRD;
  pCODGRUMAT := 0;
  -- ==============================================================================================

  -- ==============================================================================================
  -- VERIFICA CODIGO DE BARRA SE MUDOU DE INTEIRO PARA FRACIONADO TEM QUE MUDAR FILIAL
  UPDATE TB_CAD_MTMD_MAT_MED
     SET CAD_MTMD_FILIAL_ID = 3, -- OK
         --CAD_MTMD_PRIATI_ID           = nPrincAtivo,              -- OK
         CAD_MTMD_GRUPO_ID            = nGrupo, -- OK
         CAD_MTMD_SUBGRUPO_ID         = nSubGrupo, -- OK
         TIS_MED_CD_TABELAMEDICA      = pMATMED, -- OK
         CAD_MTMD_NOMEFANTASIA        = pCAD_MTMD_NOMEFANTASIA, -- OK
         CAD_MTMD_DESCRICAO           = pCAD_MTMD_DESCRICAO, -- OK
         CAD_MTMD_UNIDADE_VENDA       = pRM_FATOR_VENDA, -- OK
         CAD_MTMD_UNIDADE_COMPRA      = pRM_FATOR_COMPRA, -- OK
         CAD_MTMD_UNIDADE_CONTROLE    = pRM_FATOR_CONTROLE, -- OK
         CAD_MTMD_CD_FABRICANTE       = pCAD_MTMD_CD_FABRICANTE, -- OK
         CAD_MTMD_FL_FRACIONA         = pCAD_MTMD_FL_FRACIONA, -- OK
         CAD_MTMD_FL_ATIVO            = pCAD_MTMD_FL_ATIVO, -- OK
         CAD_MTMD_FL_MANTER_ESTOQUE   = 1, -- OK
         CAD_MTMD_FL_REUTILIZAVEL     = 0, -- OK
         CAD_MTMD_DT_ATUALIZACAO      = SYSDATE, -- OK
         CAD_MTMD_FL_IMOBILIZADO      = pIMOBILIZADO, -- OK
         CAD_MTMD_FL_CONSIGNADO       = pCONSIGNADO, -- OK
         CAD_MTMD_FL_BAIXA_AUTOMATICA = pBAIXA_AUTOMATICA, -- OK
         CAD_MTMD_FL_PADRAO           = pPADRONIZADO, -- OK
         CAD_MTMD_CD_RM               = pCAD_MTMD_CD_RM, -- OK
         CAD_MTMD_UNID_COMPRA_DS      = pDS_COMPRA, -- OK
         CAD_MTMD_UNID_CONTROLE_DS    = pDS_CONTROLE, -- OK
         CAD_MTMD_UNID_VENDA_DS       = pDS_VENDA, -- OK
         CODGRUMAT                    = pCODGRUMAT, -- OK
         MTMD_TP_FRACAO_ID            = vGOTAS,
         CAD_MTMD_CD_ANVISA           = pANVISA,
         CAD_MTMD_FL_MAV              = pALTAVIGILANCIA,
         CAD_MTMD_FL_CONTROLA_LOTE    = DECODE(nGrupo,
                                               1,
                                               1,
                                               pCAD_MTMD_FL_CONTROLA_LOTE),
         CAD_MTMD_PRIATI_SAL_DSC      = vSalDesc,
         CAD_MTMD_FORMA_FARMACEUTICA  = vFormaDesc,
         CAD_MTMD_DOSAGEM_PADRONIZADA = vDosagemDesc
  --WHERE CAD_MTMD_CD_RM = pCAD_MTMD_CD_RM;
   WHERE TRIM(CAD_MTMD_CODMNE) = TRIM(pCODIGOPRD);
  IF SQL%NOTFOUND THEN
    SGS.PRC_CAD_MTMD_MAT_MED_I(pCAD_MTMD_GRUPO_ID, -- GRUPO
                               pCAD_MTMD_SUBGRUPO_ID, -- subgrupo
                               pCAD_MTMD_NOMEFANTASIA,
                               pCAD_MTMD_DESCRICAO,
                               pCAD_MTMD_CD_FABRICANTE,
                               pCAD_MTMD_FL_FRACIONA,
                               pCAD_MTMD_FL_ATIVO, -- ATIVO
                               pCAD_MTMD_CD_RM,
                               pCAD_MTMD_FL_CONTROLA_LOTE,
                               pCODUNDCONTROLE,
                               pCODUNDVENDA,
                               pCODUNDCOMPRA,
                               pCODIGOPRD,
                               vGOTAS,
                               nIdt);
  END IF;
end PRC_CAD_MTMD_MAT_MED_U;