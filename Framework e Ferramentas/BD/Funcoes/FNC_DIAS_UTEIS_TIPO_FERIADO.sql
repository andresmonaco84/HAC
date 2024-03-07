CREATE OR REPLACE FUNCTION "FNC_DIAS_UTEIS_TIPO_FERIADO" (QTD_DIAS IN NUMBER,
    pCAD_UNI_ID_UNIDADE IN TB_CAD_FER_FERIADO.CAD_UNI_ID_UNIDADE%TYPE,
    pCAD_FER_TP_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_TP_FERIADO%TYPE)

    RETURN DATE AS

DDATA      DATE;
NFERIADO    NUMBER(2);
NCONT       NUMBER(2);
/************************************************************
*  Alterado por:  Pedro 
*  Dt. Alteracao: 23/01/2012 
* 
* DIAS UTEIS NAO CONTABILIZANDO SABADO, DOMINGO E FERIADOS
*************************************************************/
BEGIN

    NCONT := 1;
    SELECT SYSDATE  INTO DDATA FROM DUAL;

    WHILE NCONT <= QTD_DIAS LOOP

        BEGIN
        
            /* SABADO */
            IF TO_CHAR(DDATA,'D') = 7 THEN DDATA := DDATA + 1; END IF;
            /* DOMINGO */
            IF TO_CHAR(DDATA,'D') = 1 THEN 
               BEGIN
                  IF NCONT = 1 THEN  NCONT := NCONT + 1;   END IF;
                  DDATA := DDATA + 1;
               END;
            END IF;
           
            /* FERIADO */
            SELECT FNC_VERIFICA_FERIADO_SGS(DDATA, pCAD_UNI_ID_UNIDADE, pCAD_FER_TP_FERIADO) INTO NFERIADO FROM DUAL;          
            IF NFERIADO = 1   THEN  DDATA := DDATA + 1;  END IF;
               
            /* DIAS UTEIS */
            IF NFERIADO != 1 AND TO_CHAR(DDATA,'D') NOT IN (1,7) THEN
               BEGIN
                  DDATA := DDATA + 1;
                  NCONT := NCONT + 1;
               END;
            END IF;
       END;
       
    END LOOP;
    
     /* VERIFICA SE A DATA FINAL Eh SABADO, DOMINGO OU FERIADO */
     /* FERIADO */
     SELECT FNC_VERIFICA_FERIADO_SGS(DDATA, pCAD_UNI_ID_UNIDADE, pCAD_FER_TP_FERIADO) INTO NFERIADO FROM DUAL;          
     IF NFERIADO = 1   THEN  DDATA := DDATA + 1;  END IF;    
     /* SABADO */
     IF TO_CHAR(DDATA,'D') = 7 THEN DDATA := DDATA + 1; END IF;
     /* DOMINGO */
     IF TO_CHAR(DDATA,'D') = 1 THEN DDATA := DDATA + 1; END IF;
     /* FERIADO */
     SELECT FNC_VERIFICA_FERIADO_SGS(DDATA, pCAD_UNI_ID_UNIDADE, pCAD_FER_TP_FERIADO) INTO NFERIADO FROM DUAL;          
     IF NFERIADO = 1   THEN  DDATA := DDATA + 1;  END IF;    

    RETURN DDATA;

END; -- Function FNC_DIAS_UTEIS_TIPO_FERIADO;
/
