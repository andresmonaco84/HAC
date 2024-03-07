create or replace function FNC_AGS_ULTIMO_LEITO
(
 pATD_ATE_ID in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE
)
--------------------------------------------------------------
-- DT. 12/08/09
-- RETORNA O ULTIMO LEITO DA MAVIMENTACAO DO PAC INT
--
--------------------------------------------------------------
return VARCHAR2 is Result VARCHAR2(50);
begin
  SELECT   CASE when ATD.ATD_ATE_TP_PACIENTE = 'I' THEN
                     QLE.CAD_QLE_NR_QUARTO || '/' || QLE.CAD_QLE_NR_LEITO
                WHEN ATD.ATD_ATE_TP_PACIENTE = 'E' THEN 
                     'EXT'
                ELSE ''
                END INTO RESULT

                 FROM      TB_ATD_IML_INT_MOV_LEITO IML
                 JOIN      TB_CAD_QLE_QUARTO_LEITO QLE
                 ON        QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN      TB_ATD_ATE_ATENDIMENTO ATD
                 ON        ATD.ATD_ATE_ID = IML.ATD_ATE_ID
                 JOIN      TB_ATD_AIC_ATE_INT_COMPL AIC
                 ON        AIC.ATD_ATE_ID = ATD.ATD_ATE_ID
                    

                 WHERE     FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) = 
                           (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML3.ATD_IML_DT_ENTRADA,IML3.ATD_IML_HR_ENTRADA)) FROM TB_ATD_IML_INT_MOV_LEITO IML3
                            WHERE IML3.ATD_ATE_ID = ATD.ATD_ATE_ID AND IML3.ATD_IML_FL_STATUS = 'A')
                   and     ATD.ATD_ATE_ID = pATD_ATE_ID
				   and	   rownum = 1;

  return(Result);
end FNC_AGS_ULTIMO_LEITO;
/
