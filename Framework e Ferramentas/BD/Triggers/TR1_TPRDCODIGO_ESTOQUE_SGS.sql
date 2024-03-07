CREATE OR REPLACE TRIGGER TR1_TPRDCODIGO_ESTOQUE_SGS
 AFTER
  INSERT OR UPDATE OR DELETE
 ON TPRDCODIGO
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
vCodigoPrd         TPRODUTO.CODIGOPRD%TYPE;
vCodigoPrdExist    TPRODUTO.CODIGOPRD%TYPE;
vIdMtmdSGS         NUMBER;
vInserir           BOOLEAN := false;
BEGIN

IF (DELETING AND :OLD.CODCOLIGADA = 1) THEN
  DELETE SGS.TB_ASS_MTMD_CODIGO_BARRA
   WHERE MTM_CD_BARRA   = :OLD.CODIGO AND
         MTMD_LOTEST_ID = 0;
ELSIF (:NEW.CODCOLIGADA = 1 AND :NEW.IDPRD IS NOT NULL AND :NEW.CODIGO IS NOT NULL AND LENGTH(:NEW.CODIGO) > 8) THEN

  SELECT PRODUTO.CODIGOPRD
    INTO vCodigoPrd
    FROM TPRODUTO PRODUTO
   WHERE PRODUTO.CODCOLPRD = :NEW.CODCOLIGADA
    AND  PRODUTO.IDPRD     = :NEW.IDPRD;  

  IF UPDATING THEN  
     IF (NVL(:NEW.INATIVO,0) = 1) THEN
         DELETE SGS.TB_ASS_MTMD_CODIGO_BARRA
          WHERE MTM_CD_BARRA   = :OLD.CODIGO
            AND MTMD_LOTEST_ID = 0;
     ELSE
       BEGIN
         UPDATE SGS.TB_ASS_MTMD_CODIGO_BARRA
            SET MTM_CD_BARRA             = :NEW.CODIGO,
                SEG_ID_USUARIO_IMPRESSAO = 1,
                ASS_MTMD_DT_ATUALIZACAO  = SYSDATE                
          WHERE MTM_CD_BARRA   = :OLD.CODIGO AND
                MTMD_LOTEST_ID = 0;
       EXCEPTION WHEN DUP_VAL_ON_INDEX THEN
         RAISE_APPLICATION_ERROR(-20000,'CODIGO DE BARRA J� EXISTENTE PARA O PRODUTO '||TO_CHAR(vCodigoPrd)||sqlerrm);
       END;
  
       IF SQL%NOTFOUND THEN
          vInserir := true;
       END IF;
     END IF;
  END IF;
  
  IF ((INSERTING OR vInserir) AND NVL(:NEW.INATIVO,0) = 0) THEN    
    BEGIN         
      SELECT PRODUTO.CAD_MTMD_ID
      INTO   vIdMtmdSGS
      FROM SGS.TB_CAD_MTMD_MAT_MED PRODUTO
      WHERE TRIM(PRODUTO.CAD_MTMD_CODMNE) = TRIM(vCodigoPrd);
    EXCEPTION WHEN NO_DATA_FOUND THEN
        NULL; --N�o achou produto pelo codigo no SGS por algum motivo
    END;        

    IF (NVL(vIdMtmdSGS,0) > 0) THEN
      BEGIN
        SELECT PRODUTO.CAD_MTMD_CODMNE
          INTO vCodigoPrdExist
          FROM SGS.TB_ASS_MTMD_CODIGO_BARRA BARRA JOIN
               SGS.TB_CAD_MTMD_MAT_MED      PRODUTO ON PRODUTO.CAD_MTMD_ID = BARRA.CAD_MTMD_ID
         WHERE BARRA.MTM_CD_BARRA = :NEW.CODIGO; 

         IF (vCodigoPrdExist != vCodigoPrd) THEN
            RAISE_APPLICATION_ERROR(-20000,'CODIGO DE BARRA J� EXISTENTE PARA OUTRO PRODUTO NO SGS, COD '||TO_CHAR(vCodigoPrdExist)||sqlerrm);
         END IF;
      EXCEPTION WHEN NO_DATA_FOUND THEN
        BEGIN
          INSERT INTO TB_ASS_MTMD_CODIGO_BARRA
          (
             CAD_MTMD_ID,
             CAD_MTMD_FILIAL_ID,
             MTMD_LOTEST_ID,
             MTM_CD_BARRA,
             SEG_ID_USUARIO_IMPRESSAO,
             ASS_MTMD_DT_ATUALIZACAO
          )
          VALUES
          (
             vIdMtmdSGS,
             :NEW.CODCOLIGADA,
             0,
             :NEW.CODIGO,
             1,
             SYSDATE
          );
        EXCEPTION WHEN DUP_VAL_ON_INDEX THEN
          RAISE_APPLICATION_ERROR(-20000,'CODIGO DE BARRA J� EXISTENTE PARA O PRODUTO '||TO_CHAR(vCodigoPrd)||sqlerrm);
        END; 
      END;
    END IF;
  END IF;
END IF;
END;
