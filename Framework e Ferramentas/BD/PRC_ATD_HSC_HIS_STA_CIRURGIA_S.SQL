--PRC_ATD_HSC_HIS_STA_CIRURGIA_S
create or replace procedure PRC_ATD_HSC_HIS_STA_CIRURGIA_S 
(
     pATD_HSC_ID IN TB_ATD_HSC_HIST_STA_CIRURGIA.ATD_HSC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ATD_HSC_HIS_STA_CIRURGIA_S
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       ATD_HSC_ID,
       ATD_CIR_ID,
       ATD_HSC_FL_STATUS,
       ATD_HSC_DT_INICIO,
       ATD_HSC_HR_INICIO,
       ATD_HSC_DT_FIM,
       ATD_HSC_HR_FIM
FROM TB_ATD_HSC_HIST_STA_CIRURGIA
WHERE
        ATD_HSC_ID = pATD_HSC_ID;          
io_cursor := v_cursor;
end PRC_ATD_HSC_HIS_STA_CIRURGIA_S;