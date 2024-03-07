create or replace function FNC_INT_LEITOS_VAGOS
(
       pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE
)
return VARCHAR2 IS

sLinha VARCHAR2(1000)
;
begin
    sLinha := ' ';
    FOR LEITOS IN
    ( SELECT
         QLE.CAD_QLE_NR_QUARTO||' - '||QLE.CAD_QLE_NR_LEITO QUARTO_LEITO
    FROM TB_CAD_SET_SETOR        SETOR
    JOIN TB_CAD_QLE_QUARTO_LEITO QLE
    ON   QLE.CAD_SET_ID = SETOR.CAD_SET_ID
    WHERE SETOR.CAD_SET_FL_PERMITEINTERN_OK = 'S'
    AND   QLE.CAD_SQL_CD_SIT_QUARTO_LEITO   =  1
    AND   SETOR.CAD_SET_ID = pCAD_SET_ID
    AND   QLE.CAD_QLE_TP_QUARTO_LEITO = 'I'
    order by QLE.CAD_QLE_NR_QUARTO, QLE.CAD_QLE_NR_LEITO )

    LOOP
       IF (sLinha = ' ') then
           sLinha := LEITOS.QUARTO_LEITO;
       else
           sLinha := sLinha ||', '||  LEITOS.QUARTO_LEITO;
       end if;
    END LOOP;



  return(sLinha);
end FNC_INT_LEITOS_VAGOS;

