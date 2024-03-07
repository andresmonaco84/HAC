--PRC_ATD_HSC_HIS_STA_CIRURGIA_U
create or replace procedure PRC_ATD_HSC_HIS_STA_CIRURGIA_U
(
     pATD_HSC_ID IN TB_ATD_HSC_HIST_STA_CIRURGIA.ATD_HSC_ID%type,
     pATD_CIR_ID IN TB_ATD_HSC_HIST_STA_CIRURGIA.ATD_CIR_ID%type,
     pATD_HSC_FL_STATUS IN TB_ATD_HSC_HIST_STA_CIRURGIA.ATD_HSC_FL_STATUS%type,
     pATD_HSC_DT_INICIO IN TB_ATD_HSC_HIST_STA_CIRURGIA.ATD_HSC_DT_INICIO%type,
     pATD_HSC_HR_INICIO IN TB_ATD_HSC_HIST_STA_CIRURGIA.ATD_HSC_HR_INICIO%type,
     pATD_HSC_DT_FIM IN TB_ATD_HSC_HIST_STA_CIRURGIA.ATD_HSC_DT_FIM%type default NULL,
     pATD_HSC_HR_FIM IN TB_ATD_HSC_HIST_STA_CIRURGIA.ATD_HSC_HR_FIM%type default NULL
) 
is
/********************************************************************
*    Procedure: PRC_ATD_HSC_HIS_STA_CIRURGIA_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_ATD_HSC_HIST_STA_CIRURGIA
SET	   
        ATD_CIR_ID = pATD_CIR_ID,
        ATD_HSC_FL_STATUS = pATD_HSC_FL_STATUS,
        ATD_HSC_DT_INICIO = pATD_HSC_DT_INICIO,
        ATD_HSC_HR_INICIO = pATD_HSC_HR_INICIO,
        ATD_HSC_DT_FIM = pATD_HSC_DT_FIM,
        ATD_HSC_HR_FIM = pATD_HSC_HR_FIM 
WHERE
        ATD_HSC_ID = pATD_HSC_ID;	
end PRC_ATD_HSC_HIS_STA_CIRURGIA_U;