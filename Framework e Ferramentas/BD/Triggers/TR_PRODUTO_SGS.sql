CREATE OR REPLACE TRIGGER TR_PRODUTO_SGS
 AFTER
 DELETE OR
 INSERT OR 
 UPDATE OF CODTB3FAT, CODTB4FAT, NOMEFANTASIA, DESCRICAO, CODFAB, CAMPOLIVRE2, INATIVO,
           IDPRD, CODUNDCONTROLE, CODUNDVENDA, CODUNDCOMPRA, CODIGOPRD, CAMPOLIVRE3
 ON TPRD
 REFERENCING OLD AS OLD NEW AS NEW
 FOR EACH ROW

declare
  -- local variables here
  nIdt                         SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_ID@PRODUCAO%TYPE;
  sTipo                        SGS.TB_CAD_MTMD_MAT_MED.TIS_MED_CD_TABELAMEDICA@PRODUCAO%TYPE;

  vCAD_MTMD_GRUPO_ID           SGS.TB_CAD_MTMD_GRUPO.CAD_MTMD_GRUPO_ID@PRODUCAO%TYPE;
  vCAD_MTMD_GRUPO_DESCRICAO    SGS.TB_CAD_MTMD_GRUPO.CAD_MTMD_GRUPO_DESCRICAO@PRODUCAO%TYPE;
  vCAD_MTMD_SUBGRUPO_ID        SGS.TB_CAD_MTMD_SUBGRUPO.CAD_MTMD_SUBGRUPO_ID@PRODUCAO%TYPE;
  vCAD_MTMD_SUBGRUPO_DESCRICAO SGS.TB_CAD_MTMD_SUBGRUPO.CAD_MTMD_SUBGRUPO_DESCRICAO@PRODUCAO%TYPE;
  vFRACIONA                    SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_FRACIONA@PRODUCAO%TYPE;
  vATIVO                       SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_ATIVO@PRODUCAO%TYPE;
  vIMOBILIZADO                 SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_IMOBILIZADO@PRODUCAO%TYPE;
  vCONSIGNADO                  SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_CONSIGNADO@PRODUCAO%TYPE;
  vBAIXA_AUTOMATICA            SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_BAIXA_AUTOMATICA@PRODUCAO%TYPE;
  vPADRONIZADO                 SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_PADRAO@PRODUCAO%TYPE;


  vUNIDADE_COMPRA     TUND.FATORCONVERSAO%TYPE;
  vUNIDADE_CONTROLE   TUND.FATORCONVERSAO%TYPE;
  vUNIDADE_VENDA      TUND.FATORCONVERSAO%TYPE;
  vDSUNIDADE_VENDA    TUND.DESCRICAO%TYPE;
  vDSUNIDADE_CONTROLE TUND.DESCRICAO%TYPE;
  vDSUNIDADE_COMPRA   TUND.DESCRICAO%TYPE;
  vCODUNDCOMPRA       TUND.CODUND%TYPE;
  vCODUNDVENDA        TUND.CODUND%TYPE;
  vCODUNDCONTROLE     TUND.CODUND%TYPE;


  vUNIDADE_CONSUMO NUMBER;
  vCODTB3FAT       TTB3.CODTB3FAT%TYPE;
  vDESCRICAO       TTB3.DESCRICAO%TYPE;
  vINATIVO         TTB3.INATIVO%TYPE;
  vsFRACIONA       CHAR(2);
  vGOTAS          NUMBER;

  vCODTB4FAT  TTB4.CODTB4FAT%TYPE;

  vCODIGOPRD   TPRD.CODIGOPRD%TYPE;
  vCODCOLIGADA TPRD.CODCOLIGADA%TYPE;
  vIDPRD       TPRD.IDPRD%TYPE;

  vCODMNEMAT  MTM_MAT_MED.CODMNEMAT@PRODUCAO%TYPE;
begin

IF :NEW.CODCOLIGADA = 1 THEN

  -- PARA CENTRALIZAR PESQUISAS
  IF ( INSERTING OR UPDATING ) THEN
     sTipo := '95';
     -- BUSCA GRUPO
     IF ( :NEW.CODTB3FAT IS NOT NULL ) THEN
        vCODTB3FAT := :NEW.CODTB3FAT;
     ELSE
        vCODTB3FAT := :OLD.CODTB3FAT;
     END IF;

     -- BUSCA SUB GRUPO
     IF ( :NEW.CODTB4FAT IS NOT NULL ) THEN
        vCODTB4FAT := :NEW.CODTB4FAT;
     ELSE
        vCODTB4FAT := :OLD.CODTB4FAT;
     END IF;
     -- BUSCA UNIDADES
     BEGIN
     IF ( :NEW.CODUNDVENDA IS NOT NULL ) THEN
        vCODUNDVENDA := :NEW.CODUNDVENDA;
     ELSE
        vCODUNDVENDA := :OLD.CODUNDVENDA;
     END IF;
     EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20000,'vUNIDADE_VENDA');
     END;
     --
     IF ( :NEW.CODUNDCONTROLE IS NOT NULL ) THEN
        vCODUNDCONTROLE := :NEW.CODUNDCONTROLE;
     ELSE
        vCODUNDCONTROLE := :OLD.CODUNDCONTROLE;
     END IF;
     --
     IF ( :NEW.CODUNDCOMPRA IS NOT NULL ) THEN
        vCODUNDCOMPRA := :NEW.CODUNDCOMPRA;
     ELSE
        vCODUNDCOMPRA := :OLD.CODUNDCOMPRA;
     END IF;
     vUNIDADE_CONSUMO := vUNIDADE_VENDA;

     -- BUSCA INFO MAT MED LEGADO
     IF ( :NEW.CODIGOPRD IS NOT NULL ) THEN
        vCODIGOPRD := :NEW.CODIGOPRD;
     ELSE
        vCODIGOPRD := :NEW.CODIGOPRD;
     END IF;
     -- COMPLEMENTO
     IF ( :NEW.IDPRD IS NOT NULL ) THEN
        vCODCOLIGADA := :NEW.CODCOLIGADA;
        vIDPRD       := :NEW.IDPRD;
     ELSE
        vCODCOLIGADA := :OLD.CODCOLIGADA;
        vIDPRD       := :OLD.IDPRD;
     END IF;

     -- FRACIONA ????
     /*
     IF ( INSERTING ) THEN
          IF ( :NEW.CAMPOLIVRE2 IS NOT NULL ) THEN
             vsFRACIONA := :NEW.CAMPOLIVRE2;
          ELSE
             vsFRACIONA := 'N';
          END IF;
     END IF;
     */
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
     
     --Se estiver ativando produto, atualizar código do produto do estoque com o do RM
     IF (UPDATING AND :NEW.INATIVO IS NOT NULL) THEN
        IF (:NEW.INATIVO = 0 AND :OLD.INATIVO = 1) THEN        
           UPDATE SGS.TB_CAD_MTMD_MAT_MED@PRODUCAO SET
                TB_CAD_MTMD_MAT_MED.CAD_MTMD_CODMNE = vCODIGOPRD
             WHERE SGS.TB_CAD_MTMD_MAT_MED.CAD_MTMD_CD_RM = vIDPRD;
        END IF;
     END IF;
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
      SGS.PRC_CAD_MTMD_MAT_MED_I@PRODUCAO ( vCODTB3FAT, -- GRUPO
                                            vCODTB4FAT,   -- subgrupo
                                            :NEW.NOMEFANTASIA,
                                            :NEW.DESCRICAO,
                                            :NEW.CODFAB,
                                            vFRACIONA,
                                            vATIVO, -- ATIVO
                                            vIDPRD,
                                            vCODUNDCONTROLE,
                                            vCODUNDVENDA,
                                            vCODUNDCOMPRA,
                                            vCODIGOPRD,
                                            vGOTAS,
                                            nIdt
                                           );

  ELSIF ( UPDATING ) THEN
    BEGIN
    SGS.PRC_CAD_MTMD_MAT_MED_U@PRODUCAO  ( vCODTB3FAT, -- GRUPO
                                           vCODTB4FAT,   -- subgrupo
                                           :NEW.NOMEFANTASIA,
                                           :NEW.DESCRICAO,
                                           :NEW.CODFAB,
                                           vFRACIONA,
                                           vATIVO, -- ATIVO
                                           vIDPRD,
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
  END IF; -- FIM TESTE TIPO TRIGGER
  
END IF;
  
end TR_PRODUTO_SGS;
