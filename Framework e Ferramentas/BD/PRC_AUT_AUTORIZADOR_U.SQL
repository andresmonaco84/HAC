

  --PRC_AUT_AUTORIZADOR_U
  create or replace procedure PRC_AUT_AUTORIZADOR_U
  (
     pCODCON IN TB_AUT_AUTORIZADOR.CODCON%type,
     pCODEST IN TB_AUT_AUTORIZADOR.CODEST%type,
     pCODBEN IN TB_AUT_AUTORIZADOR.CODBEN%type,
     pCODSEQBEN IN TB_AUT_AUTORIZADOR.CODSEQBEN%type,
     pCD_AUTORIZADOR IN TB_AUT_AUTORIZADOR.CD_AUTORIZADOR%type,
     pDT_AUTORIZACAO IN TB_AUT_AUTORIZADOR.DT_AUTORIZACAO%type default NULL,
     pCD_LOCAL_AUTORIZACAO IN TB_AUT_AUTORIZADOR.CD_LOCAL_AUTORIZACAO%type default NULL,
     pCODATOMED IN TB_AUT_AUTORIZADOR.CODATOMED%type default NULL,
     pCODESPMED IN TB_AUT_AUTORIZADOR.CODESPMED%type default NULL,
     pDS_RET_AUTORIZADOR IN TB_AUT_AUTORIZADOR.DS_RET_AUTORIZADOR%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_AUTORIZADOR_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_AUTORIZADOR
    SET	   
        CODCON = pCODCON,
        CODEST = pCODEST,
        CODBEN = pCODBEN,
        CODSEQBEN = pCODSEQBEN,
        DT_AUTORIZACAO = pDT_AUTORIZACAO,
        CD_LOCAL_AUTORIZACAO = pCD_LOCAL_AUTORIZACAO,
        CODATOMED = pCODATOMED,
        CODESPMED = pCODESPMED,
        DS_RET_AUTORIZADOR = pDS_RET_AUTORIZADOR 
    WHERE
        CD_AUTORIZADOR = pCD_AUTORIZADOR;	
  end PRC_AUT_AUTORIZADOR_U;

