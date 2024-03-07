  --PRC_ASS_PPT_PESSOA_PRONTUARIO_SID
  create or replace procedure PRC_ASS_PPT_PESSOA_PRONTUA_SID 
  (
     pASS_PPT_ID_PESSOA_PRONTUARIO IN TB_ASS_PPT_PESSOA_PRONTUARIO.ASS_PPT_ID_PESSOA_PRONTUARIO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PPT_PESSOA_PRONTUA_SID
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
       ASS_PPT_ID_PESSOA_PRONTUARIO,
       CAD_PES_ID_PESSOA,
       CAD_PAC_NR_PRONTUARIO
    FROM TB_ASS_PPT_PESSOA_PRONTUARIO
    WHERE
        ASS_PPT_ID_PESSOA_PRONTUARIO = pASS_PPT_ID_PESSOA_PRONTUARIO;          
    io_cursor := v_cursor;
  end PRC_ASS_PPT_PESSOA_PRONTUA_SID;
