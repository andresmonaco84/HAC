CREATE OR REPLACE PROCEDURE SGS.PRC_CAD_MTMD_MAT_MED_I(pCAD_MTMD_GRUPO_ID         IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_GRUPO_ID%type,
                                                       pCAD_MTMD_SUBGRUPO_ID      IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_SUBGRUPO_ID%type,
                                                       pCAD_MTMD_NOMEFANTASIA     IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_NOMEFANTASIA%type,
                                                       pCAD_MTMD_DESCRICAO        IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_DESCRICAO%type,
                                                       pCAD_MTMD_CD_FABRICANTE    IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_CD_FABRICANTE%type default NULL,
                                                       pCAD_MTMD_FL_FRACIONA      IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_FRACIONA%type,
                                                       pCAD_MTMD_FL_ATIVO         IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_ATIVO%type default NULL,
                                                       pCAD_MTMD_CD_RM            IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_CD_RM%type default NULL,
                                                       pCAD_MTMD_FL_CONTROLA_LOTE IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_CONTROLA_LOTE%type default NULL,
                                                       pCODUNDCONTROLE            IN VARCHAR default NULL,
                                                       pCODUNDVENDA               IN VARCHAR default NULL,
                                                       pCODUNDCOMPRA              IN VARCHAR default NULL,
                                                       pCODIGOPRD                 IN VARCHAR,
                                                       vGOTAS                     IN NUMBER,
                                                       pNewIdt                    OUT integer) is

  /********************************************************************
  *    Procedure: PRC_CAD_MTMD_MAT_MED_I
  *
  *    Data Criacao:   2009  Por: Ricardo
  *    Data Alteracao:  5/9/11  Por: Andre
  *         Alteracao:  Retirada da busca no legado do mneumo
  *    Data Alteracao:  14/11/11  Por: Andre
  *         Alteracao:  n?o usar mais CAD_MTMD_CD_RM (IDPRD), apenas o CODIGOPRD como chave
  *    Data Alteracao:  16/10/12  Por: Andre
  *         Alteracao:  validado duplicac?o do campo CAD_MTMD_CODMNE
  *    Data Alteracao:  29/04/13  Por: Andre
  *         Alteracao:  Ajustes para nova vers?o do RM
  *    Data Alteracao:  15/09/15  Por: Andre
  *         Alteracao:  N?o gravar CAD_MTMD_PRIATI_ID
  *    Data Alteracao:  25/08/16  Por: Ramiro
  *         Alteracao:  Gravar CAD_MTMD_FL_MAV
  *
  *    Funcao: Grava produto
  *******************************************************************/

  lIdtRetorno        integer;
  nGrupo             TB_CAD_MTMD_MAT_MED.cad_mtmd_grupo_id%TYPE;
  nSubGrupo          TB_CAD_MTMD_MAT_MED.cad_mtmd_subgrupo_id%TYPE;
  nPrincAtivo        TB_CAD_MTMD_MAT_MED.cad_mtmd_priati_id%TYPE;
  bExistePA          BOOLEAN;
  pIMOBILIZADO       TB_CAD_MTMD_MAT_MED.cad_mtmd_fl_imobilizado%TYPE;
  pCONSIGNADO        TB_CAD_MTMD_MAT_MED.cad_mtmd_fl_consignado%TYPE;
  pBAIXA_AUTOMATICA  TB_CAD_MTMD_MAT_MED.cad_mtmd_fl_baixa_automatica%TYPE;
  pPADRONIZADO       TB_CAD_MTMD_MAT_MED.cad_mtmd_fl_padrao%TYPE;
  pMATMED            TB_CAD_MTMD_MAT_MED.tis_med_cd_tabelamedica%TYPE;
  pANVISA            TB_CAD_MTMD_MAT_MED.cad_mtmd_cd_anvisa%TYPE;
  pRM_FATOR_CONTROLE TB_CAD_MTMD_MAT_MED.cad_mtmd_unidade_controle%TYPE;
  pRM_FATOR_VENDA    TB_CAD_MTMD_MAT_MED.cad_mtmd_unidade_venda%TYPE;
  pRM_FATOR_COMPRA   TB_CAD_MTMD_MAT_MED.cad_mtmd_unidade_compra%TYPE;
  pDS_CONTROLE       TB_CAD_MTMD_MAT_MED.cad_mtmd_unid_controle_ds%TYPE;
  pDS_VENDA          TB_CAD_MTMD_MAT_MED.cad_mtmd_unid_venda_ds%TYPE;
  pDS_COMPRA         TB_CAD_MTMD_MAT_MED.cad_mtmd_unid_compra_ds%TYPE;
  pCODMNEMAT         TB_CAD_MTMD_MAT_MED.cad_mtmd_codmne%TYPE;
  pCODGRUMAT         TB_CAD_MTMD_MAT_MED.codgrumat%TYPE;
  pALTAVIGILANCIA    TB_CAD_MTMD_MAT_MED.cad_mtmd_fl_mav%TYPE;
  vSal               VARCHAR2(10);
  vSalDesc           VARCHAR2(100);
  vForma             VARCHAR2(10);
  vFormaDesc         VARCHAR2(100);
  vDosagem           VARCHAR2(10);
  vDosagemDesc       VARCHAR2(100);

begin
  BEGIN
    SELECT CAD_MTMD_CODMNE
      INTO pCODMNEMAT
      FROM TB_CAD_MTMD_MAT_MED
     WHERE TRIM(CAD_MTMD_CODMNE) = TRIM(pCODIGOPRD);
    RAISE_APPLICATION_ERROR(-20000, 'PRODUTO JA EXISTENTE COM ESTE CODIGO');
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      -- GERA ID
      SELECT SEQ_MATMED.NEXTVAL INTO lIdtRetorno FROM DUAL;

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
            INSERT INTO TB_CAD_MTMD_GRUPO
              (CAD_MTMD_GRUPO_ID,
               CAD_MTMD_GRUPO_DESCRICAO,
               CAD_MTMD_FL_ATIVO)
            VALUES
              (nGrupo, grupo.DESCRICAO, grupo.INATIVO);
          EXCEPTION
            WHEN DUP_VAL_ON_INDEX THEN
              -- SE JA EXISTIR IGNORA
              NULL;
            WHEN OTHERS THEN
              DBMS_OUTPUT.PUT_LINE(' GRUPO ' || TO_CHAR(grupo.CODTB3FAT) ||
                                   ' DESCRICAO ' || grupo.DESCRICAO);
          END;
        END LOOP;
      END IF;

      --SUB GRUPOS  ===================================================================================
      IF (pCAD_MTMD_SUBGRUPO_ID IS NULL) THEN
        nSubGrupo := 0;

      ELSE
        nSubGrupo := pCAD_MTMD_SUBGRUPO_ID;

        FOR sub IN (SELECT CODTB4FAT,
                           substr(DESCRICAO, 1, 50) DESCRICAO,
                           DECODE(INATIVO, 0, 1, 0) INATIVO
                      FROM TTB4@RMDB
                     WHERE CODTB4FAT = nSubGrupo
                       AND CODCOLIGADA = 1) LOOP
          BEGIN
            INSERT INTO TB_CAD_MTMD_SUBGRUPO
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
              DBMS_OUTPUT.PUT_LINE(' SUB GRUPO ' || TO_CHAR(nSubGrupo) ||
                                   ' DESCRICAO ' || SUB.DESCRICAO || ' ' ||
                                   SQLERRM);
              ROLLBACK;
              RAISE;
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
                      FROM TB_CAD_MTMD_MAT_MED
                     WHERE TRIM(CAD_MTMD_CODMNE) = TRIM(pa.CODIGOPRD)) LOOP
          nPrincAtivo := gem.CAD_MTMD_PRIATI_ID;
          EXIT;
        END LOOP;
      END LOOP;

      -- NAO ACHOU, CRIA REGISTRO NA TABELA DE P.A.
      IF (bExistePA = TRUE) THEN
        IF (nPrincAtivo = 0) THEN
          SELECT SEQ_PRINCIPIO_ATIVO.NEXTVAL INTO nPrincAtivo FROM DUAL;
          INSERT INTO TB_CAD_MTMD_PRIATI_PRINC_ATIVO
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
           AND TRIM(TPRD.CODIGOPRD) = TRIM(pCODIGOPRD);
      EXCEPTION
        WHEN NO_DATA_FOUND THEN
          pIMOBILIZADO      := 0;
          pCONSIGNADO       := 0;
          pBAIXA_AUTOMATICA := 0;
          pPADRONIZADO      := 0;
          pMATMED           := '96';
          pANVISA           := NULL;
          pALTAVIGILANCIA   := 'N';
          vSal              := NULL;
          vForma            := NULL;
          vDosagem          := NULL;
          -- DSADT.EMAIL('ricardo.costa@anacosta.com.br', '[TRIGGER PRODUTO]',' ID RM '||TO_CHAR(pCAD_MTMD_CD_RM)||' COMPLEMENTO NÃO ENCONTRADO ' );
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

      pCODMNEMAT := pCODIGOPRD;
      pCODGRUMAT := 0;

      INSERT INTO TB_CAD_MTMD_MAT_MED
        (CAD_MTMD_ID, -- OK
         CAD_MTMD_FILIAL_ID, -- OK
         CAD_MTMD_PRIATI_ID, -- OK
         CAD_MTMD_GRUPO_ID, -- OK
         CAD_MTMD_SUBGRUPO_ID, -- OK
         TIS_MED_CD_TABELAMEDICA, -- OK
         CAD_MTMD_NOMEFANTASIA, -- OK
         CAD_MTMD_DESCRICAO, -- OK
         CAD_MTMD_UNIDADE_VENDA, -- OK
         CAD_MTMD_UNIDADE_COMPRA, -- OK
         CAD_MTMD_UNIDADE_CONTROLE, -- OK
         CAD_MTMD_CODMNE, -- OK
         -- CAD_MTMD_CURVA_ABC,
         CAD_MTMD_CD_FABRICANTE, -- OK
         CAD_MTMD_FL_FRACIONA, -- OK
         CAD_MTMD_FL_ATIVO, -- OK
         CAD_MTMD_FL_MANTER_ESTOQUE, -- OK
         CAD_MTMD_FL_REUTILIZAVEL, -- OK
         CAD_MTMD_DT_ATUALIZACAO, -- OK
         CAD_MTMD_FL_IMOBILIZADO, -- OK
         CAD_MTMD_FL_CONSIGNADO, -- OK
         CAD_MTMD_FL_BAIXA_AUTOMATICA, -- OK
         CAD_MTMD_FL_PADRAO, -- OK
         CAD_MTMD_CD_RM, -- OK
         CAD_MTMD_UNID_COMPRA_DS, -- OK
         CAD_MTMD_UNID_CONTROLE_DS, -- OK
         CAD_MTMD_UNID_VENDA_DS, -- OK
         CODGRUMAT, -- OK
         MTMD_TP_FRACAO_ID,
         CAD_MTMD_CD_ANVISA,
         CAD_MTMD_FL_MAV,
         CAD_MTMD_FL_CONTROLA_LOTE,
         CAD_MTMD_PRIATI_SAL_DSC,
         CAD_MTMD_FORMA_FARMACEUTICA,
         CAD_MTMD_DOSAGEM_PADRONIZADA)
      VALUES
        (lIdtRetorno,
         3, -- FORCA FILIAL 3, N?O E UTILIZADA NO PRODUTO
         0, -- Insere 0 p/ CAD_MTMD_PRIATI_ID
         nGrupo,
         nSubGrupo,
         pMATMED,
         pCAD_MTMD_NOMEFANTASIA,
         pCAD_MTMD_DESCRICAO,
         pRM_FATOR_VENDA,
         pRM_FATOR_COMPRA,
         pRM_FATOR_CONTROLE,
         pCODMNEMAT,
         -- pCAD_MTMD_CURVA_ABC,
         pCAD_MTMD_CD_FABRICANTE,
         pCAD_MTMD_FL_FRACIONA,
         pCAD_MTMD_FL_ATIVO,
         1, -- MANTER ESTOQUE
         0,
         SYSDATE,
         pIMOBILIZADO,
         pCONSIGNADO,
         pBAIXA_AUTOMATICA,
         pPADRONIZADO,
         pCAD_MTMD_CD_RM,
         pDS_COMPRA,
         pDS_CONTROLE,
         pDS_VENDA,
         pCODGRUMAT,
         vGOTAS,
         pANVISA,
         pALTAVIGILANCIA,
         DECODE(nGrupo, 1, 1, pCAD_MTMD_FL_CONTROLA_LOTE),
         vSalDesc,
         vFormaDesc,
         vDosagemDesc);
      pNewIdt := lIdtRetorno;
    WHEN OTHERS THEN
      RAISE_APPLICATION_ERROR(-20000, sqlerrm);
  END;

end PRC_CAD_MTMD_MAT_MED_I;