create or replace function FNC_AGS_ULTIMO_SETOR_INT
(
 pATD_ATE_ID in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE
)
--------------------------------------------------------------
-- DT. 12/08/09
-- RETORNA O ULTIMO SETOR DA MAVIMENTACAO DO PAC INT
--
--------------------------------------------------------------
return varchar2 is Result varchar2(30);
begin
  SELECT        SETOR.CAD_SET_CD_SETOR INTO RESULT

                 FROM      TB_ATD_IML_INT_MOV_LEITO IML
                 JOIN      TB_CAD_QLE_QUARTO_LEITO QLE
                 ON        QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN      TB_ATD_ATE_ATENDIMENTO ATD
                 ON        ATD.ATD_ATE_ID = IML.ATD_ATE_ID
                 JOIN      TB_ATD_AIC_ATE_INT_COMPL AIC
                 ON        AIC.ATD_ATE_ID = ATD.ATD_ATE_ID
                 JOIN      TB_CAD_SET_SETOR SETOR
                 ON        SETOR.CAD_SET_ID = QLE.CAD_SET_ID
                 WHERE     FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) = 
                           (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML3.ATD_IML_DT_ENTRADA,IML3.ATD_IML_HR_ENTRADA)) FROM TB_ATD_IML_INT_MOV_LEITO IML3
                            WHERE IML3.ATD_ATE_ID = ATD.ATD_ATE_ID AND IML3.ATD_IML_FL_STATUS = 'A')
                   and     ATD.ATD_ATE_ID = pATD_ATE_ID
       ;

  return(Result);
end FNC_AGS_ULTIMO_SETOR_INT;
/
