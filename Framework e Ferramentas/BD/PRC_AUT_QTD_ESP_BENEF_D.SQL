

  --PRC_AUT_QTD_ESP_BENEF_D
  create or replace procedure PRC_AUT_QTD_ESP_BENEF_D 
  (
     pCODBEN IN TB_AUT_QTD_ESP_BENEF.CODBEN%type,
     pCODCON IN TB_AUT_QTD_ESP_BENEF.CODCON%type,
     pCODESPMED IN TB_AUT_QTD_ESP_BENEF.CODESPMED%type,
     pCODEST IN TB_AUT_QTD_ESP_BENEF.CODEST%type,
     pCODSEQBEN IN TB_AUT_QTD_ESP_BENEF.CODSEQBEN%type,
     pTP_ATENDIMENTO IN TB_AUT_QTD_ESP_BENEF.TP_ATENDIMENTO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_QTD_ESP_BENEF_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_QTD_ESP_BENEF
    WHERE  
        CODBEN = pCODBEN
    AND CODCON = pCODCON
    AND CODESPMED = pCODESPMED
    AND CODEST = pCODEST
    AND CODSEQBEN = pCODSEQBEN
    AND TP_ATENDIMENTO = pTP_ATENDIMENTO;	   
  end PRC_AUT_QTD_ESP_BENEF_D;
