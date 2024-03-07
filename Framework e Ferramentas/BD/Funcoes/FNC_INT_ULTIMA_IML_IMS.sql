create or replace function FNC_INT_ULTIMA_IML_IMS
(
       pATD_ATE_ID IN TB_ATD_IML_INT_MOV_LEITO.ATD_ATE_ID%TYPE,
       setorQuartoLeito varchar default null
)
return VARCHAR2 IS

sResultado VARCHAR2(200);
sQuartoleito VARCHAR2(50);
sSetor VARCHAR2(200);

dtUltimaIMLeito DATE;
hrUltimaIMLeito int;
dtUltimaIMSetor DATE;
hrUltimaIMSetor int

;
begin
    sResultado := '';
    sQuartoleito:= '';
    sSetor:= '';
begin
        SELECT    CASE WHEN setorQuartoLeito IS NULL THEN
                       QLE.CAD_QLE_NR_QUARTO || '/' || QLE.CAD_QLE_NR_LEITO
                  ELSE SETOR.CAD_SET_DS_SETOR || ' ' || QLE.CAD_QLE_NR_QUARTO || '/' || QLE.CAD_QLE_NR_LEITO
                  END,
                  IML.ATD_IML_DT_ENTRADA, 
                  IML.ATD_IML_HR_ENTRADA
                  
                  INTO sQuartoleito,
                       dtUltimaIMLeito,
                       hrUltimaIMLeito
             --             IML.ATD_IML_HR_ENTRADA,IML.ATD_IML_DT_SAIDA ,setor.cad_set_ds_setor
                 FROM      TB_ATD_IML_INT_MOV_LEITO IML
                 JOIN      TB_CAD_QLE_QUARTO_LEITO QLE
                 ON        QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN      TB_ATD_ATE_ATENDIMENTO ATD2
                 ON        ATD2.ATD_ATE_ID = IML.ATD_ATE_ID
                  join      tb_cad_set_setor setor
                 on        setor.cad_set_id = qle.cad_set_id
                WHERE       FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) = 
                                         (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML3.ATD_IML_DT_ENTRADA,IML3.ATD_IML_HR_ENTRADA)) FROM TB_ATD_IML_INT_MOV_LEITO IML3
                                                       WHERE IML3.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IML3.ATD_IML_FL_STATUS = 'A')
                      and  iml.atd_ate_id = pATD_ATE_ID;

   EXCEPTION
   WHEN NO_DATA_FOUND THEN
   sQuartoleito:= '';
   END;
begin
        SELECT   IMS.ATD_IMS_DT_ENTRADA,
                 setor.cad_set_ds_setor,
                 IMS.ATD_IMS_HR_ENTRADA
                 
                 into  dtUltimaIMSetor,
                       sSetor,
                       hrUltimaIMSetor
                FROM TB_ATD_IMS_INT_MOV_SETOR IMS
                join tb_cad_set_setor setor
                on   setor.cad_set_id = IMS.CAD_SET_ID_SETOR
                 WHERE     IMS.ATD_IMS_ID = (SELECT MAX(IMS3.ATD_IMS_ID) FROM TB_ATD_IMS_INT_MOV_SETOR IMS3
                                             WHERE IMS3.ATD_ATE_ID = ims.ATD_ATE_ID AND IMS3.ATD_IMS_FL_STATUS = 'A')
                      and  ims.atd_ate_id = pATD_ATE_ID;

   EXCEPTION
   WHEN NO_DATA_FOUND THEN
   sSetor:= '';
   end;
   
if((sQuartoleito IS NULL) and (sSetor IS NOT NULL)) then

       IF (dtUltimaIMLeito > dtUltimaIMSetor) then
           sResultado := sQuartoleito;
       else
           sResultado := sSetor;
       end if;
       
       IF (dtUltimaIMLeito = dtUltimaIMSetor) then
            if(hrUltimaIMLeito > hrUltimaIMSetor) then
                    sResultado := sQuartoleito;
            else   
                    sResultado := sSetor;     
            end if;
       end if;
 end if;
if((sQuartoleito IS NULL) and (sSetor IS NOT NULL)) then
     sResultado := sSetor;
end if;
if((sQuartoleito IS NOT NULL) and (sSetor IS NULL)) then
     sResultado := sQuartoleito;
end if;

  return(sResultado);
end FNC_INT_ULTIMA_IML_IMS;
/
