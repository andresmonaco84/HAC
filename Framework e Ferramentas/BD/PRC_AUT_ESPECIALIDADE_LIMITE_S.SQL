 
  --PRC_AUT_ESPECIALIDADE_LIMITE_S
  create or replace procedure PRC_AUT_ESPECIALIDADE_LIMITE_S 
  (
     pCODESPMED IN TB_AUT_ESPECIALIDADE_LIMITE.CODESPMED%type DEFAULT NULL,
     pTP_ATENDIMENTO IN TB_AUT_ESPECIALIDADE_LIMITE.TP_ATENDIMENTO%type DEFAULT NULL,
     pQTD_DIAS_PERIODO IN TB_AUT_ESPECIALIDADE_LIMITE.QTD_DIAS_PERIODO%type DEFAULT NULL,
     pQTD_LIMITE IN TB_AUT_ESPECIALIDADE_LIMITE.QTD_LIMITE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ESPECIALIDADE_LIMITE_S
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
       CODESPMED,
       TP_ATENDIMENTO,
       QTD_DIAS_PERIODO,
       QTD_LIMITE
    FROM TB_AUT_ESPECIALIDADE_LIMITE
    WHERE
        (pCODESPMED is null OR CODESPMED = pCODESPMED) AND 
        (pTP_ATENDIMENTO is null OR TP_ATENDIMENTO = pTP_ATENDIMENTO) AND 
        (pQTD_DIAS_PERIODO is null OR QTD_DIAS_PERIODO = pQTD_DIAS_PERIODO) AND 
        (pQTD_LIMITE is null OR QTD_LIMITE = pQTD_LIMITE);          
    io_cursor := v_cursor;
  end PRC_AUT_ESPECIALIDADE_LIMITE_S;
