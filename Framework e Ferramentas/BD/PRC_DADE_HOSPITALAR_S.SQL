 
  --PRC_DADE_HOSPITALAR_S
  create or replace procedure PRC_DADE_HOSPITALAR_S 
  (
     pCODUNIHOS IN UNIDADE_HOSPITALAR.CODUNIHOS%type DEFAULT NULL,
     pDESUNIHOS IN UNIDADE_HOSPITALAR.DESUNIHOS%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_DADE_HOSPITALAR_S
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
       CODUNIHOS,
       DESUNIHOS
    FROM UNIDADE_HOSPITALAR
    WHERE
        (pCODUNIHOS is null OR CODUNIHOS = pCODUNIHOS) AND 
        (pDESUNIHOS is null OR DESUNIHOS = pDESUNIHOS);          
    io_cursor := v_cursor;
  end PRC_DADE_HOSPITALAR_S;
