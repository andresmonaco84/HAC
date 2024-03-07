CREATE OR REPLACE TRIGGER TR_PRODUTO_ESTOQUE_SGS
 AFTER
 INSERT OR DELETE OR UPDATE OF CODIGOPRD, CAMPOLIVRE2, IDPRD, DESCRICAO, INATIVO, CAMPOLIVRE3, NOMEFANTASIA
 ON RM.TPRODUTO
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW
declare
  -- local variables here
  vCODIGOPRD       TPRD.CODIGOPRD%TYPE;
  vIDPRD           TPRD.IDPRD%TYPE;
  nIdt             SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_ID@PRODUCAO%TYPE;
  vATIVO           SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_ATIVO@PRODUCAO%TYPE;
  vFRACIONA        SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_FRACIONA@PRODUCAO%TYPE;
  vsFRACIONA       CHAR(2);
  vGOTAS           NUMBER;
  vCODTB3FAT       TTB3.CODTB3FAT%TYPE;
  vCODTB4FAT       TTB4.CODTB4FAT%TYPE;
  vCODUNDCOMPRA    TUND.CODUND%TYPE;
  vCODUNDVENDA     TUND.CODUND%TYPE;
  vCODUNDCONTROLE  TUND.CODUND%TYPE;
  vCODFAB          TPRODUTODEF.CODFAB%TYPE;
begin
IF :NEW.CODCOLPRD = 1 THEN
  IF ( INSERTING OR UPDATING ) THEN
     IF ( :NEW.CODIGOPRD IS NOT NULL ) THEN
        vCODIGOPRD := :NEW.CODIGOPRD;
     ELSE
        vCODIGOPRD := :NEW.CODIGOPRD;
     END IF;
     IF ( :NEW.IDPRD IS NOT NULL ) THEN
        vIDPRD       := :NEW.IDPRD;
     ELSE
        vIDPRD       := :OLD.IDPRD;
     END IF;
     -- FRACIONA
     IF ( UPDATING OR INSERTING ) THEN
          IF ( :NEW.CAMPOLIVRE2 IS NOT NULL ) THEN
             IF ( UPPER(:NEW.CAMPOLIVRE2) = 'S' ) THEN
                vsFRACIONA := 'S';
             ELSE
                 vsFRACIONA := 'N';
             END IF;
          ELSE
             vsFRACIONA := 'N';
          END IF;
          IF ( :NEW.CAMPOLIVRE3 IS NOT NULL ) THEN
             IF ( UPPER(:NEW.CAMPOLIVRE3) = 'S' ) THEN
                vGOTAS := 1;
             ELSE
                 vGOTAS := NULL;
             END IF;
          ELSE
             vGOTAS := NULL;
          END IF;
     END IF;
     SELECT DECODE( TRIM(vsFRACIONA), 'S', 1, 0)
     INTO vFRACIONA
     FROM DUAL;
     --Se estiver ativando produto, atualizar codigo do produto do estoque com o do RM
     /*IF (UPDATING AND :NEW.INATIVO IS NOT NULL) THEN
        IF (:NEW.INATIVO = 0 AND :OLD.INATIVO = 1) THEN
           UPDATE SGS.TB_CAD_MTMD_MAT_MED@PRODUCAO SET
                TB_CAD_MTMD_MAT_MED.CAD_MTMD_CODMNE = vCODIGOPRD
             WHERE SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_CD_RM = vIDPRD;
        END IF;
     END IF;*/
     --
     IF ( :NEW.INATIVO IS NOT NULL ) THEN
        vATIVO := :NEW.INATIVO;
     ELSE
        vATIVO := :OLD.INATIVO;
     END IF;
     SELECT DECODE( vATIVO, 1, 0, 1)
     INTO   vATIVO
     FROM DUAL;
  END IF; -- FIM TESTE INSERTING UPDATING
  -- =======================================================================================
  IF ( INSERTING ) THEN
      SGS.PRC_CAD_MTMD_MAT_MED_I@PRODUCAO ( 0,   -- GRUPO
                      0,   -- SUBGRUPO
                      :NEW.NOMEFANTASIA,
                      :NEW.DESCRICAO,
                      NULL,--CODFAB
                      vFRACIONA,
                      vATIVO,
                      vIDPRD,
                      :NEW.CONTROLADOPORLOTE,
                      NULL,--CODUNDCONTROLE
                      NULL,--CODUNDVENDA
                      NULL,--CODUNDCOMPRA
                      vCODIGOPRD,
                      vGOTAS,
                      nIdt
                       );
  ELSIF ( UPDATING ) THEN
    BEGIN
    SELECT CODTB3FAT,  CODTB4FAT,  CODFAB,  CODUNDCONTROLE,  CODUNDVENDA,  CODUNDCOMPRA
      INTO vCODTB3FAT, vCODTB4FAT, vCODFAB, vCODUNDCONTROLE, vCODUNDVENDA, vCODUNDCOMPRA
      FROM TPRODUTODEF D
     WHERE D.IDPRD = vIDPRD AND
           D.CODCOLIGADA = :NEW.CODCOLPRD;
    SGS.PRC_CAD_MTMD_MAT_MED_U@PRODUCAO  ( vCODTB3FAT,   -- GRUPO
                       NVL(vCODTB4FAT, 0),   -- SUBGRUPO
                       :NEW.NOMEFANTASIA,
                       :NEW.DESCRICAO,
                       vCODFAB,
                       vFRACIONA,
                       vATIVO,
                       vIDPRD,
                       :NEW.CONTROLADOPORLOTE,
                       vCODUNDCONTROLE,
                       vCODUNDVENDA,
                       vCODUNDCOMPRA,
                       vCODIGOPRD,
                       vGOTAS);
      EXCEPTION
         WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20000,'UPDATE PRODUTO '||SQLERRM);
     END;
  ELSIF ( DELETING ) THEN
   NULL;
  END IF;
END IF;
end TR_PRODUTO_ESTOQUE_SGS;