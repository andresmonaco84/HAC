create or replace function FNC_FAT_ATD_PASSOU_PELA_UTI
(
 pATD_ATE_ID in TB_ATD_IML_INT_MOV_LEITO.ATD_ATE_ID%TYPE
)
--------------------------------------------------------------
-- DT. 12/08/09
-- RETORNA 1 SE O ATD PASSOU PELA UTI --0=NAO
--
--------------------------------------------------------------
return NUMBER is Result NUMBER;
begin

SELECT    CASE WHEN QLE.CAD_QLE_ID IS NULL THEN 0
          ELSE 1 END     INTO RESULT
                 FROM      TB_ATD_IML_INT_MOV_LEITO IML
                 LEFT JOIN TB_CAD_QLE_QUARTO_LEITO QLE
                 ON        QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN      TB_ATD_ATE_ATENDIMENTO ATD2
                 ON        ATD2.ATD_ATE_ID = IML.ATD_ATE_ID
                 JOIN      TB_CAD_SET_SETOR SETOR2
                 ON        SETOR2.CAD_SET_ID = QLE.CAD_SET_ID
                 WHERE     SETOR2.CAD_SET_CD_SETOR IN ('UTIC','UTIG','UTII','UTIN')
                 AND ATD2.ATD_ATE_ID = pATD_ATE_ID
                 AND ROWNUM = 1
;

  return(Result);
end FNC_FAT_ATD_PASSOU_PELA_UTI;

