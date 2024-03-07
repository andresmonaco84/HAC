CREATE OR REPLACE TRIGGER TR_TITMMOV_01
  BEFORE INSERT OR
         DELETE OR
         UPDATE ON RM.TITMMOV
  FOR EACH ROW
DECLARE

  sTIPO  VARCHAR2(10);
  sGRUPO VARCHAR2(3);
  vMATMED TPRDCOMPL.MATMED%TYPE;
  vMATCONSIGNADO TPRDCOMPL.MATCONSIGNADO%TYPE;
  vIDPRD TPRODUTO.IDPRD%TYPE;

BEGIN

  --IF :NEW.CODCOLIGADA = 1 THEN

    BEGIN
      SELECT TRIM(CODTMV)
        INTO sTIPO
        FROM TMOV
       WHERE CODCOLIGADA = :NEW.CODCOLIGADA
         AND IDMOV = :NEW.IDMOV;
    EXCEPTION
      WHEN OTHERS THEN
        sTIPO := NULL;
    END;

    IF sTIPO LIKE '1.2.%' THEN

      BEGIN
        SELECT CODTB3FAT, PROD.IDPRD
          INTO sGRUPO,    vIDPRD
          FROM TPRODUTODEF DEF JOIN 
               TPRODUTO PROD ON (PROD.CODCOLPRD = DEF.CODCOLIGADA AND
                                 PROD.IDPRD = DEF.IDPRD)
        WHERE CODCOLIGADA = 1
          AND PROD.CODIGOPRD = (SELECT TRIM(CODIGOPRD) FROM TPRODUTO WHERE IDPRD = :NEW.IDPRD);
         /*WHERE CODCOLIGADA = :NEW.CODCOLIGADA
           AND IDPRD = :NEW.IDPRD;*/
      EXCEPTION
        WHEN NO_DATA_FOUND THEN
          SELECT CODTB3FAT, DEF.IDPRD
            INTO sGRUPO,    vIDPRD
            FROM TPRODUTODEF DEF
           WHERE CODCOLIGADA = :NEW.CODCOLIGADA
             AND IDPRD = :NEW.IDPRD;      
      END;

      -- OBRIGA GRUPO 61 EM NOTA FISCAL DE CONSIGNADO;
      IF (sTIPO = '1.2.48' AND sGRUPO NOT IN ('06', '61')) THEN
        RAISE_APPLICATION_ERROR(-20501, '-  NOTA FISCAL DE CONSIGNADOS SO PERMITE PRODUTOS DO GRUPO 61(PROTESE/ORTESE/SINTESE) E 06(MATERIAL)  -');
      END IF;

      IF (sTIPO <> '1.2.48' AND sTIPO <> '1.2.62' AND sGRUPO = '61') THEN
        RAISE_APPLICATION_ERROR(-20501, '-  PRODUTOS DO GRUPO 61(PROTESE/ORTESE/SINTESE) SO PODEM SER DIGITADOS EM NOTA FISCAL DE CONSIGNADOS  -');
      END IF;

      IF :NEW.CODCOLIGADA = 2 THEN 
          BEGIN
            SELECT MATMED,  MATCONSIGNADO
              INTO vMATMED, vMATCONSIGNADO
              FROM TPRDCOMPL
             WHERE CODCOLIGADA = 1 --:NEW.CODCOLIGADA
               AND IDPRD = vIDPRD; --:NEW.IDPRD;
          EXCEPTION
            WHEN NO_DATA_FOUND THEN
              SELECT MATMED,  MATCONSIGNADO
                INTO vMATMED, vMATCONSIGNADO
                FROM TPRDCOMPL
               WHERE CODCOLIGADA = :NEW.CODCOLIGADA
                 AND IDPRD = :NEW.IDPRD;
          END;
          
          IF (vMATMED = 'MA' AND sGRUPO = '01') THEN
             RAISE_APPLICATION_ERROR(-20501, '-  DIVERGENCIA NO CADASTRO DE PRODUTO, QUE ESTA CADASTRADO COM O GRUPO DE MEDICAMENTO MAS ATRIBUIDO COMO MATERIAL, FAVOR VERIFICAR. -');
          END IF;
               
          IF (vMATMED = 'ME' AND vMATCONSIGNADO = 'S') THEN
             RAISE_APPLICATION_ERROR(-20501, '-  MEDICAMENTO COM ATRIBUTO DE ''COMPRA UNICA HAC'' NAO PODE ENTRAR PARA A COLIGADA 2, FAVOR VERIFICAR. -');
          END IF;
      END IF;

    END IF;

  --END IF;

END;