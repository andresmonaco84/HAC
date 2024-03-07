

  --PRC_AUT_ATO_MEDICO_U
  create or replace procedure PRC_AUT_ATO_MEDICO_U
  (
     pCODATOMED IN TB_AUT_ATO_MEDICO.CODATOMED%type,
     pDESATOMED IN TB_AUT_ATO_MEDICO.DESATOMED%type default NULL,
     pID_CPT IN TB_AUT_ATO_MEDICO.ID_CPT%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ATO_MEDICO_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_ATO_MEDICO
    SET	   
        DESATOMED = pDESATOMED,
        ID_CPT = pID_CPT 
    WHERE
        CODATOMED = pCODATOMED;	
  end PRC_AUT_ATO_MEDICO_U;

