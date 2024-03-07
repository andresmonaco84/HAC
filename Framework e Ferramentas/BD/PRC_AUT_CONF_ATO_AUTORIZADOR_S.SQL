 
  --PRC_AUT_CONF_ATO_AUTORIZADOR_S
  create or replace procedure PRC_AUT_CONF_ATO_AUTORIZADOR_S 
  (
     pQTD_LIMITE IN TB_AUT_CONF_ATO_AUTORIZADOR.QTD_LIMITE%type DEFAULT NULL,
     pCODATOMED IN TB_AUT_CONF_ATO_AUTORIZADOR.CODATOMED%type DEFAULT NULL,
     pQTD_DIAS_PERIODO IN TB_AUT_CONF_ATO_AUTORIZADOR.QTD_DIAS_PERIODO%type DEFAULT NULL,
     pTP_ATENDIMENTO IN TB_AUT_CONF_ATO_AUTORIZADOR.TP_ATENDIMENTO%type DEFAULT NULL,
     pCODCON IN TB_AUT_CONF_ATO_AUTORIZADOR.CODCON%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_CONF_ATO_AUTORIZADOR_S
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
       QTD_LIMITE,
       CODATOMED,
       QTD_DIAS_PERIODO,
       TP_ATENDIMENTO,
       CODCON
    FROM TB_AUT_CONF_ATO_AUTORIZADOR
    WHERE
        (pQTD_LIMITE is null OR QTD_LIMITE = pQTD_LIMITE) AND 
        (pCODATOMED is null OR CODATOMED = pCODATOMED) AND 
        (pQTD_DIAS_PERIODO is null OR QTD_DIAS_PERIODO = pQTD_DIAS_PERIODO) AND 
        (pTP_ATENDIMENTO is null OR TP_ATENDIMENTO = pTP_ATENDIMENTO) AND 
        (pCODCON is null OR CODCON = pCODCON);          
    io_cursor := v_cursor;
  end PRC_AUT_CONF_ATO_AUTORIZADOR_S;
