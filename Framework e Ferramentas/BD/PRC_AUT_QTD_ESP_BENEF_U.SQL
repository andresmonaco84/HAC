

  --PRC_AUT_QTD_ESP_BENEF_U
  create or replace procedure PRC_AUT_QTD_ESP_BENEF_U
  (
     pCODCON IN TB_AUT_QTD_ESP_BENEF.CODCON%type,
     pCODEST IN TB_AUT_QTD_ESP_BENEF.CODEST%type,
     pCODBEN IN TB_AUT_QTD_ESP_BENEF.CODBEN%type,
     pCODSEQBEN IN TB_AUT_QTD_ESP_BENEF.CODSEQBEN%type,
     pCODESPMED IN TB_AUT_QTD_ESP_BENEF.CODESPMED%type,
     pTP_ATENDIMENTO IN TB_AUT_QTD_ESP_BENEF.TP_ATENDIMENTO%type,
     pQTD_UTILIZADA IN TB_AUT_QTD_ESP_BENEF.QTD_UTILIZADA%type default NULL,
     pDT_INI_UTILIZACAO IN TB_AUT_QTD_ESP_BENEF.DT_INI_UTILIZACAO%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_QTD_ESP_BENEF_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_QTD_ESP_BENEF
    SET	   
        QTD_UTILIZADA = pQTD_UTILIZADA,
        DT_INI_UTILIZACAO = pDT_INI_UTILIZACAO 
    WHERE
        CODBEN = pCODBEN
    AND CODCON = pCODCON
    AND CODESPMED = pCODESPMED
    AND CODEST = pCODEST
    AND CODSEQBEN = pCODSEQBEN
    AND TP_ATENDIMENTO = pTP_ATENDIMENTO;	
  end PRC_AUT_QTD_ESP_BENEF_U;

