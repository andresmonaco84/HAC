

  --PRC_AUT_QTD_ATO_BENEF_D
  create or replace procedure PRC_AUT_QTD_ATO_BENEF_D 
  (
     pCODATOMED IN TB_AUT_QTD_ATO_BENEF.CODATOMED%type,
     pCODBEN IN TB_AUT_QTD_ATO_BENEF.CODBEN%type,
     pCODCON IN TB_AUT_QTD_ATO_BENEF.CODCON%type,
     pCODEST IN TB_AUT_QTD_ATO_BENEF.CODEST%type,
     pCODSEQBEN IN TB_AUT_QTD_ATO_BENEF.CODSEQBEN%type,
     pTP_ATENDIMENTO IN TB_AUT_QTD_ATO_BENEF.TP_ATENDIMENTO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_QTD_ATO_BENEF_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_QTD_ATO_BENEF
    WHERE  
        CODATOMED = pCODATOMED
    AND CODBEN = pCODBEN
    AND CODCON = pCODCON
    AND CODEST = pCODEST
    AND CODSEQBEN = pCODSEQBEN
    AND TP_ATENDIMENTO = pTP_ATENDIMENTO;	   
  end PRC_AUT_QTD_ATO_BENEF_D;
