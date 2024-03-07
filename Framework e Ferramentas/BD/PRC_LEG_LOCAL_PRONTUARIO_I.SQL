create or replace procedure PRC_LEG_LOCAL_PRONTUARIO_I
  (
     pCODPAC IN LOCAL_PRONTUARIO.CODPAC%type,
     pATD_ATE_ID IN LOCAL_PRONTUARIO.CODATEAMB%type,
     pNOMPAC IN LOCAL_PRONTUARIO.NOMPAC%type,
     pCODAND IN LOCAL_PRONTUARIO.CODAND%type default NULL,
     pCODESPMED IN LOCAL_PRONTUARIO.CODESPMED%type default NULL,
     pNOMED IN LOCAL_PRONTUARIO.NOMED%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_LEG_LOCAL_PRONTUARIO_I
  * 
  *    Data Criacao: 	15/02/2008   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Insere na tabela quando prontu�rio solicitado
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO LOCAL_PRONTUARIO
    (
       CODPAC,
       CODATEAMB,
       DAT_SOLICITACAO,
       NOMPAC,
       CODAND,
       CODESPMED,
       NOMED,
       STATUS,
       SEQ
    )
    VALUES
    (
	     pCODPAC,
	     pATD_ATE_ID,
	     sysdate,
	     pNOMPAC,
	     pCODAND,
	     pCODESPMED,
	     pNOMED,
	     0,
	     99
    );
	
  end PRC_LEG_LOCAL_PRONTUARIO_I;
/
