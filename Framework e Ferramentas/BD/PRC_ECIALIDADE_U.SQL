

  --PRC_ECIALIDADE_U
  create or replace procedure PRC_ECIALIDADE_U
  (
     pCODESPMED IN ESPECIALIDADE.CODESPMED%type,
     pDESESPMED IN ESPECIALIDADE.DESESPMED%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ECIALIDADE_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE ESPECIALIDADE
    SET	   
        DESESPMED = pDESESPMED 
    WHERE
        CODESPMED = pCODESPMED;	
  end PRC_ECIALIDADE_U;

