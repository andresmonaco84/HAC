 
  --PRC_AUT_QTD_ESP_BENEF_S
  create or replace procedure PRC_AUT_QTD_ESP_BENEF_S 
  (
     pCODCON IN TB_AUT_QTD_ESP_BENEF.CODCON%type DEFAULT NULL,
     pCODEST IN TB_AUT_QTD_ESP_BENEF.CODEST%type DEFAULT NULL,
     pCODBEN IN TB_AUT_QTD_ESP_BENEF.CODBEN%type DEFAULT NULL,
     pCODSEQBEN IN TB_AUT_QTD_ESP_BENEF.CODSEQBEN%type DEFAULT NULL,
     pCODESPMED IN TB_AUT_QTD_ESP_BENEF.CODESPMED%type DEFAULT NULL,
     pTP_ATENDIMENTO IN TB_AUT_QTD_ESP_BENEF.TP_ATENDIMENTO%type DEFAULT NULL,
     pQTD_UTILIZADA IN TB_AUT_QTD_ESP_BENEF.QTD_UTILIZADA%type DEFAULT NULL,
     pDT_INI_UTILIZACAO IN TB_AUT_QTD_ESP_BENEF.DT_INI_UTILIZACAO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_QTD_ESP_BENEF_S
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CODCON,
       CODEST,
       CODBEN,
       CODSEQBEN,
       CODESPMED,
       TP_ATENDIMENTO,
       QTD_UTILIZADA,
       DT_INI_UTILIZACAO
    FROM TB_AUT_QTD_ESP_BENEF
    WHERE
        (pCODCON is null OR CODCON = pCODCON) AND 
        (pCODEST is null OR CODEST = pCODEST) AND 
        (pCODBEN is null OR CODBEN = pCODBEN) AND 
        (pCODSEQBEN is null OR CODSEQBEN = pCODSEQBEN) AND 
        (pCODESPMED is null OR CODESPMED = pCODESPMED) AND 
        (pTP_ATENDIMENTO is null OR TP_ATENDIMENTO = pTP_ATENDIMENTO) AND 
        (pQTD_UTILIZADA is null OR QTD_UTILIZADA = pQTD_UTILIZADA) AND 
        (pDT_INI_UTILIZACAO is null OR DT_INI_UTILIZACAO = pDT_INI_UTILIZACAO);          
    io_cursor := v_cursor;
  end PRC_AUT_QTD_ESP_BENEF_S;
