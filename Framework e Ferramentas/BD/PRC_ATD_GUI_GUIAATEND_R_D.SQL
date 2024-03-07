

--PRC_ATD_GUI_GUIAATEND_R_D
create or replace procedure PRC_ATD_GUI_GUIAATEND_R_D 
(
     pATD_ATE_ID IN TB_ATD_GUI_GUIAATEND.ATD_ATE_ID%type,
     pATD_GUI_CD_CODIGO IN TB_ATD_GUI_GUIAATEND.ATD_GUI_CD_CODIGO%type,
     pATD_GUI_DT_VALIDADE IN TB_ATD_GUI_GUIAATEND.ATD_GUI_DT_VALIDADE%type	
)
is
/********************************************************************
*    Procedure: PRC_ATD_GUI_GUIAATEND_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ATD_GUI_GUIAATEND
WHERE  
        ATD_ATE_ID = pATD_ATE_ID
    AND ATD_GUI_CD_CODIGO = pATD_GUI_CD_CODIGO
    AND ATD_GUI_DT_VALIDADE = pATD_GUI_DT_VALIDADE;	   
end PRC_ATD_GUI_GUIAATEND_R_D;
