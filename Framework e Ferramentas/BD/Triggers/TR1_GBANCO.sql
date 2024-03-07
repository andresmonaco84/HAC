CREATE OR REPLACE TRIGGER "TR1_GBANCO"
  AFTER DELETE OR INSERT OR UPDATE OF NOME, NUMEROOFICIAL ON GBANCO
  REFERENCING OLD AS OLD NEW AS NEW
  FOR EACH ROW
DECLARE
  V_CAD_BAN_ID                 SGS.TB_CAD_BAN_BANCO.CAD_BAN_ID%TYPE;
  V_CAD_BAN_CD_BANCO           SGS.TB_CAD_BAN_BANCO.CAD_BAN_CD_BANCO%TYPE;
  V_CAD_BAN_NM_BANCO           SGS.TB_CAD_BAN_BANCO.CAD_BAN_NM_BANCO%TYPE;
  V_CAD_BAN_DT_CRIACAO         SGS.TB_CAD_BAN_BANCO.CAD_BAN_DT_CRIACAO%TYPE;
  V_SEG_USU_ID_USUARIO_CRIACAO SGS.TB_CAD_BAN_BANCO.SEG_USU_ID_USUARIO_CRIACAO%TYPE;
  V_CAD_BAN_DT_ULTIMA_ATUALIZA SGS.TB_CAD_BAN_BANCO.CAD_BAN_DT_ULTIMA_ATUALIZACAO%TYPE;
  V_SEG_USU_ID_USUARIO_ATUALIZ SGS.TB_CAD_BAN_BANCO.SEG_USU_ID_USUARIO_ATUALIZ%TYPE;
  V_CAD_BAN_FL_ATIVO           SGS.TB_CAD_BAN_BANCO.CAD_BAN_FL_ATIVO%TYPE;
  V_CAD_BAN_NR_BANCO_RM        SGS.TB_CAD_BAN_BANCO.CAD_BAN_NR_BANCO_RM%TYPE;
BEGIN
  IF (INSERTING) THEN
    BEGIN
      SELECT BAN.CAD_BAN_ID
        INTO V_CAD_BAN_ID
        FROM SGS.TB_CAD_BAN_BANCO BAN
       WHERE BAN.CAD_BAN_CD_BANCO = :NEW.NUMEROOFICIAL;
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        SELECT SGS.SEQ_CAD_BAN_01.NEXTVAL INTO V_CAD_BAN_ID FROM DUAL;
        V_CAD_BAN_CD_BANCO           := :NEW.NUMEROOFICIAL;
        V_CAD_BAN_NM_BANCO           := :NEW.NOMEREDUZIDO;
        V_CAD_BAN_DT_CRIACAO         := SYSDATE;
        V_SEG_USU_ID_USUARIO_CRIACAO := 1;
        V_CAD_BAN_DT_ULTIMA_ATUALIZA := SYSDATE;
        V_SEG_USU_ID_USUARIO_ATUALIZ := 1;
        V_CAD_BAN_FL_ATIVO           := 'S';
        V_CAD_BAN_NR_BANCO_RM        := :NEW.NUMBANCO;
        INSERT INTO SGS.TB_CAD_BAN_BANCO
          (CAD_BAN_ID,
           CAD_BAN_CD_BANCO,
           CAD_BAN_NM_BANCO,
           CAD_BAN_DT_CRIACAO,
           SEG_USU_ID_USUARIO_CRIACAO,
           CAD_BAN_DT_ULTIMA_ATUALIZACAO,
           SEG_USU_ID_USUARIO_ATUALIZ,
           CAD_BAN_FL_ATIVO,
           CAD_BAN_NR_BANCO_RM)
        VALUES
          (V_CAD_BAN_ID,
           V_CAD_BAN_CD_BANCO,
           V_CAD_BAN_NM_BANCO,
           V_CAD_BAN_DT_CRIACAO,
           V_SEG_USU_ID_USUARIO_CRIACAO,
           V_CAD_BAN_DT_ULTIMA_ATUALIZA,
           V_SEG_USU_ID_USUARIO_ATUALIZ,
           V_CAD_BAN_FL_ATIVO,
           V_CAD_BAN_NR_BANCO_RM);
    END;
    UPDATE SGS.TB_CAD_BAN_BANCO BAN
       SET BAN.CAD_BAN_NR_BANCO_RM = :NEW.NUMBANCO,
           BAN.CAD_BAN_FL_ATIVO    = 'S'
     WHERE BAN.CAD_BAN_CD_BANCO = :NEW.NUMEROOFICIAL;
  END IF;
  IF (UPDATING) THEN
    IF :NEW.NOME != :OLD.NOME THEN
      V_CAD_BAN_NM_BANCO := :NEW.NOME;
    ELSE
      V_CAD_BAN_NM_BANCO := :OLD.NOME;
    END IF;
    IF :NEW.NUMEROOFICIAL != :OLD.NUMEROOFICIAL THEN
      V_CAD_BAN_CD_BANCO := :NEW.NUMEROOFICIAL;
    ELSE
      V_CAD_BAN_CD_BANCO := :OLD.NUMEROOFICIAL;
    END IF;
    UPDATE SGS.TB_CAD_BAN_BANCO
       SET CAD_BAN_NM_BANCO              = V_CAD_BAN_NM_BANCO,
           CAD_BAN_CD_BANCO              = V_CAD_BAN_CD_BANCO,
           SEG_USU_ID_USUARIO_ATUALIZ    = 1,
           CAD_BAN_DT_ULTIMA_ATUALIZACAO = SYSDATE
     WHERE CAD_BAN_NR_BANCO_RM = :NEW.NUMBANCO;
  END IF;
  IF (DELETING) THEN
    UPDATE SGS.TB_CAD_BAN_BANCO BAN
       SET BAN.CAD_BAN_FL_ATIVO          = 'N',
           SEG_USU_ID_USUARIO_ATUALIZ    = 1,
           CAD_BAN_DT_ULTIMA_ATUALIZACAO = SYSDATE
     WHERE BAN.CAD_BAN_NR_BANCO_RM = :OLD.NUMBANCO;
  END IF;
END TR1_GBANCO;
/
