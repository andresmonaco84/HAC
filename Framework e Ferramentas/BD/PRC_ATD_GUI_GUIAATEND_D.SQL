  create or replace procedure PRC_ATD_GUI_GUIAATEND_D 
  (
     pATD_ATE_ID IN TB_ATD_GUI_GUIAATEND.ATD_ATE_ID%type,
     pATD_GUI_CD_CODIGO IN TB_ATD_GUI_GUIAATEND.ATD_GUI_CD_CODIGO%type,
     pATD_GUI_DT_VALIDADE IN TB_ATD_GUI_GUIAATEND.ATD_GUI_DT_VALIDADE%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATD_GUI_GUIAATEND_D
  * 
  *    Data Criacao: 	11/03/2008   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Exclui guia de atendimento
  *
  *******************************************************************/    
  begin
    DELETE TB_ATD_GUI_GUIAATEND
    WHERE  
        ATD_ATE_ID = pATD_ATE_ID
    AND ATD_GUI_CD_CODIGO = pATD_GUI_CD_CODIGO
    AND ATD_GUI_DT_VALIDADE = pATD_GUI_DT_VALIDADE;	   
  end PRC_ATD_GUI_GUIAATEND_D;
/
