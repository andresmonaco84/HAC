  --PRC_ASS_PESSOA_TEL_RMT_SID
  create or replace procedure PRC_ASS_PESSOA_TEL_RMT_SID 
  (
     pCAD_PES_ID_PESSOA IN TB_ASS_PTE_PESSOA_TELEFONE.CAD_PES_ID_PESSOA%type,
     pCAD_TEL_ID_TELEFONE IN TB_ASS_PTE_PESSOA_TELEFONE.CAD_TEL_ID_TELEFONE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PESSOA_TEL_RMT_SID
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
        CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA
    AND CAD_TEL_ID_TELEFONE = pCAD_TEL_ID_TELEFONE;          
    io_cursor := v_cursor;
  end PRC_ASS_PESSOA_TEL_RMT_SID;
