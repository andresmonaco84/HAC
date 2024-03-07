  --PRC_ASS_PESSOA_END_RMT_SID
  create or replace procedure PRC_ASS_PESSOA_END_RMT_SID 
  (
     pCAD_END_ID_ENDERECO IN TB_ASS_PEE_PESSOA_ENDERECO.CAD_END_ID_ENDERECO%type,
     pCAD_PES_ID_PESSOA IN TB_ASS_PEE_PESSOA_ENDERECO.CAD_PES_ID_PESSOA%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PESSOA_END_RMT_SID
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
       CAD_END_ID_ENDERECO,
       CAD_PES_ID_PESSOA
    FROM TB_ASS_PEE_PESSOA_ENDERECO
    WHERE
        CAD_END_ID_ENDERECO = pCAD_END_ID_ENDERECO
    AND CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA;          
    io_cursor := v_cursor;
  end PRC_ASS_PESSOA_END_RMT_SID;
