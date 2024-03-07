create or replace procedure PRC_LEG_DEL_ITEM_CONTA_D
  (
     pATD_ATE_ID IN ITEM_CONTA_SP_AMBULATORIO.CODATEAMB%type,
     PCODUNIHOS IN ITEM_CONTA_SP_AMBULATORIO.CODUNIHOS%type,
     pCODPAC    IN ITEM_CONTA_SP_AMBULATORIO.CODPAC%type,
     PCODATO IN ITEM_CONTA_SP_AMBULATORIO.CODATOMED%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_LEG_DEL_ITEM_CONTA_D
  *
  *    Data Criacao: 	05/03/2008         Por: Andrea Cazuca
  *
  *    Funcao: Verifica se existe item na conta e exclui.
  *
  *******************************************************************/
  
  begin
  
    DELETE ITEM_CONTA_SP_AMBULATORIO
    WHERE  CODATEAMB = pATD_ATE_ID
    AND    CODUNIHOS = PCODUNIHOS
    AND    CODPAC    = pCODPAC
    AND    CODATOMED = PCODATO
    AND    USUARIO LIKE 'AUTO_ATEAMB%';
    
  end PRC_LEG_DEL_ITEM_CONTA_D;
/
