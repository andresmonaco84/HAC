CREATE OR REPLACE TRIGGER "TR1_FCONTA"
  AFTER UPDATE OF DIGCONTA ON FCONTA
  REFERENCING OLD AS OLD NEW AS NEW
  FOR EACH ROW
DECLARE
  V_ASS_BCT_DV_CONTA SGS.TB_ASS_BCT_BANCO_CONTA.ASS_BCT_DV_CONTA%TYPE;
  V_CAD_BAN_ID       SGS.TB_CAD_BAN_BANCO.CAD_BAN_ID%TYPE;
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
    IF :NEW.DIGCONTA != :OLD.DIGCONTA THEN
      V_ASS_BCT_DV_CONTA := :NEW.DIGCONTA;
    ELSE
      V_ASS_BCT_DV_CONTA := :OLD.DIGCONTA;
    END IF;
    UPDATE SGS.TB_ASS_BCT_BANCO_CONTA BCT
       SET ASS_BCT_DV_CONTA = V_ASS_BCT_DV_CONTA,
       BCT.ASS_BCT_DT_ULTIMA_ATUALIZACAO = SYSDATE,
       BCT.SEG_USU_ID_USUARIO_ATUALIZ = 1
     WHERE BCT.CAD_BAN_ID = V_CAD_BAN_ID
       AND BCT.ASS_BCT_CD_AGENCIA = :NEW.NUMAGENCIA
       AND BCT.ASS_BCT_NR_CONTA = :NEW.NROCONTA;
  END IF;
END TR1_FCONTA;
/
