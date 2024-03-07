CREATE OR REPLACE FUNCTION "FNC_VERIFICA_FERIADO_SGS"
  ( pCAD_FER_DT_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_DT_FERIADO%TYPE,
    pCAD_UNI_ID_UNIDADE IN TB_CAD_FER_FERIADO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
    pCAD_FER_TP_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_TP_FERIADO%TYPE DEFAULT NULL
    )

  RETURN  NUMBER AS

NFERIADO NUMBER(2);

BEGIN

IF (pCAD_FER_TP_FERIADO = 'F') THEN --APENAS PARA AGENDA DE CONSULTAS
    SELECT  COUNT(*)    INTO    NFERIADO
    FROM    TB_CAD_FER_FERIADO FER
    WHERE   FER.CAD_FER_TP_FERIADO IN ('F') 
    AND     to_char(FER.CAD_FER_DT_FERIADO,'dd-mm-yyyy') = to_char(pCAD_FER_DT_FERIADO,'dd-mm-yyyy');

ELSE IF (pCAD_FER_TP_FERIADO IS NOT NULL) THEN
    SELECT  COUNT(*)    INTO    NFERIADO
    FROM    TB_CAD_FER_FERIADO FER
    WHERE   (pCAD_UNI_ID_UNIDADE IS NULL OR FER.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    AND     (FER.CAD_FER_TP_FERIADO = pCAD_FER_TP_FERIADO )
    AND     to_char(FER.CAD_FER_DT_FERIADO,'dd-mm-yyyy') = to_char(pCAD_FER_DT_FERIADO,'dd-mm-yyyy');

ELSE      -- AGENDA SADT E OUTROS
    SELECT  COUNT(*)
    INTO    NFERIADO
    FROM    TB_CAD_FER_FERIADO FER
    WHERE   (
            (pCAD_UNI_ID_UNIDADE IS NULL OR FER.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE) or
            (FER.CAD_FER_TP_FERIADO IN ('E','F'))
            )
    AND     to_char(FER.CAD_FER_DT_FERIADO,'dd-mm-yyyy') = to_char(pCAD_FER_DT_FERIADO,'dd-mm-yyyy');
END IF;
END IF;


if NFERIADO > 0 then   NFERIADO:= 1;   end if;

   RETURN NFERIADO;
END; -- Function FNC_VERIFICA_FERIADO_SGS
 