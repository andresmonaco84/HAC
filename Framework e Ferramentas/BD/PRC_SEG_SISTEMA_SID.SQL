

---bozo

  --PRC_SEG_SISTEMA_SID
  create or replace procedure PRC_SEG_SISTEMA_SID 
  (
     pSEG_ID_SISTEMA IN TB_SEG_SISTEMA.SEG_ID_SISTEMA%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_SISTEMA_SID
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
       SEG_ID_SISTEMA,
       SEG_NM_SISTEMA
    FROM TB_SEG_SISTEMA
    WHERE
        SEG_ID_SISTEMA = pSEG_ID_SISTEMA;          
    io_cursor := v_cursor;
  end PRC_SEG_SISTEMA_SID;
