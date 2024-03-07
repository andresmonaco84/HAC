CREATE OR REPLACE TRIGGER TR_COMPL_PRD_SGS
 AFTER
 INSERT OR UPDATE OR DELETE
 ON RM.TPRDCOMPL
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
DECLARE
 vIMOBILIZADO     TPRDCOMPL.IMOBILIZADO%TYPE;
 vMATCONSIGNADO   TPRDCOMPL.MATCONSIGNADO%TYPE;
 vBAIXAAUTOMATICA TPRDCOMPL.BAIXAAUTOMATICA%TYPE;
 vPADRONIZADO     TPRDCOMPL.PADRONIZADO%TYPE;
 vCOBRADO         TPRDCOMPL.COBRADO%TYPE;
 vIDPRD           TPRDCOMPL.IDPRD%TYPE;
 vMATMED          TPRDCOMPL.MATMED%TYPE;
 vREUTILIZAVEL    TPRDCOMPL.REUTILIZAVEL%TYPE;
 vMTMD_ID         NUMBER(10);
 sGrupo           VARCHAR2(10);
 -- vCODCOLIGADA     TPRDCOMPL.CODCOLIGADA%TYPE;
BEGIN
IF :NEW.CODCOLIGADA = 1 THEN
  IF ( UPDATING OR INSERTING ) THEN        
    BEGIN 
      SELECT CAD_MTMD_ID INTO vMTMD_ID
        FROM SGS.TB_CAD_MTMD_MAT_MED@PRODUCAO
       WHERE TRIM(CAD_MTMD_CODMNE) = (SELECT TRIM(CODIGOPRD) FROM TPRODUTO WHERE IDPRD = :NEW.IDPRD);

      BEGIN
        SELECT TRIM(CODTB3FAT)
          INTO sGrupo
          FROM TPRODUTODEF
         WHERE IDPRD = TRIM(:NEW.IDPRD)
           AND CODCOLIGADA = :NEW.CODCOLIGADA;
      EXCEPTION
        WHEN OTHERS THEN
          sGrupo := NULL;
      END;

      IF (NVL(:NEW.MATMED,'N') = 'MA' AND NVL(sGrupo,'00') = '01') THEN
        RAISE_APPLICATION_ERROR(-20501, '-  ESTE PRODUTO NAO PODE SER CADASTRADO COMO MATERIAL, POIS ESTA CADASTRADO COM O GRUPO DROGAS E MEDICAMENTOS, FAVOR VERIFICAR. -');
      END IF;

      IF (NVL(:NEW.MATMED,'N') = 'ME' AND NVL(sGrupo,'00') != '01') THEN
        RAISE_APPLICATION_ERROR(-20501, '-  ESTE PRODUTO NAO PODE SER CADASTRADO COMO MEDICAMENTO, POIS ESTA CADASTRADO COM UM GRUPO DE MATERIAL, FAVOR VERIFICAR. -');
      END IF;

      IF ( :NEW.MATCONSIGNADO IS NOT NULL ) THEN
         vMATCONSIGNADO := :NEW.MATCONSIGNADO;
      ELSE
         vMATCONSIGNADO := 'N';
      END IF;

      IF (NVL(:NEW.MATMED,'N') = 'ME' AND NVL(vMATCONSIGNADO,'N') = 'S') THEN
         IF (SGS.FNC_MTMD_ESTOQUE_CONTABIL@PRODUCAO(vMTMD_ID, 2) > 0) THEN
               RAISE_APPLICATION_ERROR(-20501,'PRODUTO COM SALDO EM ESTOQUE NO ACS, NAO PODE SER COMPRA UNICA HAC.');
         END IF;
      END IF; 
    
       IF ( :NEW.IMOBILIZADO IS NOT NULL ) THEN
          vIMOBILIZADO := :NEW.IMOBILIZADO;
       ELSE
          vIMOBILIZADO := 'N';
       END IF;       
       IF ( :NEW.BAIXAAUTOMATICA IS NOT NULL ) THEN
          vBAIXAAUTOMATICA := :NEW.BAIXAAUTOMATICA;
       ELSE
          vBAIXAAUTOMATICA := 'N';
       END IF;
       IF ( :NEW.PADRONIZADO IS NOT NULL ) THEN
          vPADRONIZADO := :NEW.PADRONIZADO;
       ELSE
          vPADRONIZADO := 'N';
       END IF;
       IF ( :NEW.COBRADO IS NOT NULL ) THEN
          vCOBRADO := :NEW.COBRADO;
       ELSE
          vCOBRADO := 'N';
       END IF;
       IF ( :NEW.IDPRD IS NOT NULL ) THEN
          vIDPRD := :NEW.IDPRD;
       ELSE
          vIDPRD := 'N';
       END IF;
       IF ( :NEW.MATMED IS NOT NULL ) THEN
          vMATMED := :NEW.MATMED;
       ELSE
          vMATMED := 'N';
       END IF;
       IF ( :NEW.REUTILIZAVEL IS NOT NULL ) THEN
          vREUTILIZAVEL := :NEW.REUTILIZAVEL;
       ELSE
          vREUTILIZAVEL := 'N';
       END IF;
    /*
       IF ( :NEW.CODCOLIGADA IS NOT NULL ) THEN
          vCODCOLIGADA := :NEW.CODCOLIGADA;
       ELSE
          vCODCOLIGADA := :OLD.CODCOLIGADA;
       END IF;
  */
       -- ATUALIZA MAT MED SGS
       UPDATE SGS.TB_CAD_MTMD_MAT_MED@PRODUCAO SET
          TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_IMOBILIZADO      = DECODE( NVL(vIMOBILIZADO,'N'),'N',0,1),
          TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_CONSIGNADO       = DECODE( NVL(vMATCONSIGNADO,'N'),'N',0,1),
          TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_BAIXA_AUTOMATICA = DECODE( NVL(vBAIXAAUTOMATICA,'N'),'N',0,1),
          TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_PADRAO           = DECODE( NVL(vPADRONIZADO,'N'),'N',0,1),
          TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_FATURADO         = DECODE( NVL(vCOBRADO,'N'),'N',0,1),
          TB_CAD_MTMD_MAT_MED.TIS_MED_CD_TABELAMEDICA      = DECODE( vMATMED,'MA',95,'ME',96,NULL),
          TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_REUTILIZAVEL     = DECODE( vREUTILIZAVEL,'N',0,1),
          TB_CAD_MTMD_MAT_MED.CAD_MTMD_CD_ANVISA           = :NEW.ANVISA,
          TB_CAD_MTMD_MAT_MED.CAD_MTMD_DT_ATUALIZACAO      = SYSDATE
       WHERE CAD_MTMD_ID = vMTMD_ID;
       --WHERE SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_CD_RM = vIDPRD;
       --WHERE TRIM(SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_CODMNE) = (SELECT TRIM(CODIGOPRD) FROM TPRODUTO WHERE IDPRD = vIDPRD AND CODCOLPRD = 1);
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        null;
        --RAISE_APPLICATION_ERROR(-20000,sqlerrm);
    END;
  END IF; --
END IF;
END TR_COMPL_PRD_SGS;
