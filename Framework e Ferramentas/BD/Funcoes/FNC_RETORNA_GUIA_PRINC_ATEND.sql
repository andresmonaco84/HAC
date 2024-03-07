CREATE OR REPLACE FUNCTION "FNC_RETORNA_GUIA_PRINC_ATEND" (
   pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE
)
return varchar is Result varchar(30);
begin

       SELECT GUIA.ATD_GUI_CD_CODIGO INTO Result
       FROM TB_ATD_GUI_GUIAATEND GUIA
       WHERE GUIA.ATD_GUI_FL_GUIAPRINC_OK = 'S'
       AND GUIA.ATD_ATE_ID = pATD_ATE_ID
     ;

  return(Result);
end FNC_RETORNA_GUIA_PRINC_ATEND;

