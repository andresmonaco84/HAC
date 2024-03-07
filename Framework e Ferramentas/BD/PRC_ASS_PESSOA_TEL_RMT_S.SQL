  --PRC_ASS_PESSOA_TEL_RMT_S
  create or replace procedure PRC_ASS_PESSOA_TEL_RMT_S 
  (
     pCAD_TEL_ID_TELEFONE IN TB_ASS_PTE_PESSOA_TELEFONE.CAD_TEL_ID_TELEFONE%type DEFAULT NULL,
     pCAD_PES_ID_PESSOA IN TB_ASS_PTE_PESSOA_TELEFONE.CAD_PES_ID_PESSOA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PESSOA_TEL_RMT_S
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
       CAD_TEL_ID_TELEFONE,
       CAD_PES_ID_PESSOA
    FROM TB_ASS_PTE_PESSOA_TELEFONE
    WHERE
        (pCAD_TEL_ID_TELEFONE is null OR CAD_TEL_ID_TELEFONE = pCAD_TEL_ID_TELEFONE) AND 
        (pCAD_PES_ID_PESSOA is null OR CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA);          
    io_cursor := v_cursor;
  end PRC_ASS_PESSOA_TEL_RMT_S;
