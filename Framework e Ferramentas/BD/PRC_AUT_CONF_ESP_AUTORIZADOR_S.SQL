 
  --PRC_AUT_CONF_ESP_AUTORIZADOR_S
  create or replace procedure PRC_AUT_CONF_ESP_AUTORIZADOR_S 
  (
     pCODCON IN TB_AUT_CONF_ESP_AUTORIZADOR.CODCON%type DEFAULT NULL,
     pCODESPMED IN TB_AUT_CONF_ESP_AUTORIZADOR.CODESPMED%type DEFAULT NULL,
     pTP_ATENDIMENTO IN TB_AUT_CONF_ESP_AUTORIZADOR.TP_ATENDIMENTO%type DEFAULT NULL,
     pQTD_LIMITE IN TB_AUT_CONF_ESP_AUTORIZADOR.QTD_LIMITE%type DEFAULT NULL,
     pQTD_DIAS_PERIODO IN TB_AUT_CONF_ESP_AUTORIZADOR.QTD_DIAS_PERIODO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_CONF_ESP_AUTORIZADOR_S
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
       CODESPMED,
       TP_ATENDIMENTO,
       QTD_LIMITE,
       QTD_DIAS_PERIODO
    FROM TB_AUT_CONF_ESP_AUTORIZADOR
    WHERE
        (pCODCON is null OR CODCON = pCODCON) AND 
        (pCODESPMED is null OR CODESPMED = pCODESPMED) AND 
        (pTP_ATENDIMENTO is null OR TP_ATENDIMENTO = pTP_ATENDIMENTO) AND 
        (pQTD_LIMITE is null OR QTD_LIMITE = pQTD_LIMITE) AND 
        (pQTD_DIAS_PERIODO is null OR QTD_DIAS_PERIODO = pQTD_DIAS_PERIODO);          
    io_cursor := v_cursor;
  end PRC_AUT_CONF_ESP_AUTORIZADOR_S;
