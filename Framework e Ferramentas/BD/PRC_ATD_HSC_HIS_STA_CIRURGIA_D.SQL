--PRC_ATD_HSC_HIS_STA_CIRURGIA_D
create or replace procedure PRC_ATD_HSC_HIS_STA_CIRURGIA_D 
(
     pATD_HSC_ID IN TB_ATD_HSC_HIST_STA_CIRURGIA.ATD_HSC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ATD_HSC_HIS_STA_CIRURGIA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ATD_HSC_HIST_STA_CIRURGIA
WHERE  
        ATD_HSC_ID = pATD_HSC_ID;	   
end PRC_ATD_HSC_HIS_STA_CIRURGIA_D;