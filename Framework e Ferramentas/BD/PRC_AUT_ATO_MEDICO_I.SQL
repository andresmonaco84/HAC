

  --PRC_AUT_ATO_MEDICO_I
  create or replace procedure PRC_AUT_ATO_MEDICO_I
  (
     pCODATOMED IN TB_AUT_ATO_MEDICO.CODATOMED%type,
     pDESATOMED IN TB_AUT_ATO_MEDICO.DESATOMED%type default NULL,
     pID_CPT IN TB_AUT_ATO_MEDICO.ID_CPT%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ATO_MEDICO_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_ATO_MEDICO
    (
       CODATOMED,
       DESATOMED,
       ID_CPT
    )
    VALUES
    (
	     pCODATOMED,
	     pDESATOMED,
	     pID_CPT
    );
	
  end PRC_AUT_ATO_MEDICO_I;

