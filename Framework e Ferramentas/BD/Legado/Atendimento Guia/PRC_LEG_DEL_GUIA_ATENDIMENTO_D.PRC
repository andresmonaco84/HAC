create or replace procedure PRC_LEG_DEL_GUIA_ATENDIMENTO_D
  (
     pATD_ATE_ID IN GUIA_ATENDIMENTO_AMB.CODATEAMB%type,
     pATD_GUI_CD_CODIGO IN GUIA_ATENDIMENTO_AMB.NR_GUIA%TYPE
  )
  is
  /********************************************************************
  *    Procedure: PRC_LEG_DEL_GUIA_ATENDIMENTO_D
  *
  *    Data Criacao: 	11/03/2008         Por: Andrea Cazuca
  *
  *    Funcao: Exclui Guia de Atendimento do Legado
  *
  *******************************************************************/
  begin
  
        DELETE GUIA_ATENDIMENTO_AMB
        WHERE  CODATEAMB = pATD_ATE_ID
        AND    NR_GUIA = pATD_GUI_CD_CODIGO;
    
  end PRC_LEG_DEL_GUIA_ATENDIMENTO_D;
/
