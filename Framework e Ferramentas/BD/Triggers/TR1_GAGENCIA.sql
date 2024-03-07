CREATE OR REPLACE TRIGGER "TR1_GAGENCIA"
  AFTER UPDATE OF DIGAG ON GAGENCIA
  REFERENCING OLD AS OLD NEW AS NEW
  FOR EACH ROW
DECLARE
  V_ASS_BCT_DV_AGENCIA SGS.TB_ASS_BCT_BANCO_CONTA.ASS_BCT_DV_AGENCIA%TYPE;
  V_CAD_BAN_ID         SGS.TB_CAD_BAN_BANCO.CAD_BAN_ID%TYPE;
BEGIN
  IF (UPDATING) THEN
    BEGIN
      SELECT DISTINCT BAN.CAD_BAN_ID
        INTO V_CAD_BAN_ID
        FROM SGS.TB_ASS_BCT_BANCO_CONTA BCT, SGS.TB_CAD_BAN_BANCO BAN
       WHERE BCT.ASS_BCT_CD_AGENCIA = :NEW.NUMAGENCIA
         AND BCT.CAD_BAN_ID = BAN.CAD_BAN_ID
         AND BAN.CAD_BAN_NR_BANCO_RM = :NEW.NUMBANCO;
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        NULL;
    END;
    IF :NEW.DIGAG != :OLD.DIGAG THEN
      V_ASS_BCT_DV_AGENCIA := :NEW.DIGAG;
    ELSE
      V_ASS_BCT_DV_AGENCIA := :OLD.DIGAG;
    END IF;
    UPDATE SGS.TB_ASS_BCT_BANCO_CONTA BCT
       SET ASS_BCT_DV_AGENCIA                = V_ASS_BCT_DV_AGENCIA,
           BCT.ASS_BCT_DT_ULTIMA_ATUALIZACAO = SYSDATE,
           BCT.SEG_USU_ID_USUARIO_ATUALIZ    = 1
     WHERE BCT.CAD_BAN_ID = V_CAD_BAN_ID
       AND BCT.ASS_BCT_CD_AGENCIA = :NEW.NUMAGENCIA;
  END IF;
END TR1_GAGENCIA;
/
