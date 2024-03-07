CREATE OR REPLACE TRIGGER tr_tmov_matmed_nota
 BEFORE
  UPDATE
 ON tmov
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
  sControlaEstoque TITMTMV.efeitosaldoa2%TYPE;
BEGIN

IF :NEW.CODCOLIGADA IN (1,2) THEN
  IF ( (LTRIM(:OLD.NUMEROMOV,0) != LTRIM(:NEW.NUMEROMOV,0)) AND UPDATING ) THEN
     BEGIN
          SELECT TIPOMOVIMENTO.efeitosaldoa2
          INTO   sControlaEstoque
          FROM TITMTMV TIPOMOVIMENTO
          WHERE TIPOMOVIMENTO.CODTMV      = :NEW.CODTMV
          AND TIPOMOVIMENTO.CODCOLIGADA   = :NEW.CODCOLIGADA;
        EXCEPTION
          WHEN NO_DATA_FOUND THEN
               RAISE_APPLICATION_ERROR(-20000,'Tipo Movimento NO_DATA_FOUND');
          WHEN OTHERS THEN
               RAISE_APPLICATION_ERROR(-20000,'Tipo Movimento '||sqlerrm);
        END;
        IF ( sControlaEstoque = 'A' AND :NEW.STATUS IN ('F','N') AND :NEW.TIPO = 'P' ) THEN
           RAISE_APPLICATION_ERROR(-20000,' VOCE NAO PODE ALTERAR O NUMERO DA NOTA FISCAL');
        END IF;
  END IF;

END IF;

end tr_interf_matmed_nota;
