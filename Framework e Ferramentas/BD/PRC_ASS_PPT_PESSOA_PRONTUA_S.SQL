 
  --PRC_ASS_PPT_PESSOA_PRONTUARIO_S
  create or replace procedure PRC_ASS_PPT_PESSOA_PRONTUA_S 
  (
     pASS_PPT_ID_PESSOA_PRONTUARIO IN TB_ASS_PPT_PESSOA_PRONTUARIO.ASS_PPT_ID_PESSOA_PRONTUARIO%type DEFAULT NULL,
     pCAD_PES_ID_PESSOA IN TB_ASS_PPT_PESSOA_PRONTUARIO.CAD_PES_ID_PESSOA%type DEFAULT NULL,
     pCAD_PAC_NR_PRONTUARIO IN TB_ASS_PPT_PESSOA_PRONTUARIO.CAD_PAC_NR_PRONTUARIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PPT_PESSOA_PRONTUA_S
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
        (pASS_PPT_ID_PESSOA_PRONTUARIO is null OR ASS_PPT_ID_PESSOA_PRONTUARIO = pASS_PPT_ID_PESSOA_PRONTUARIO) AND 
        (pCAD_PES_ID_PESSOA is null OR CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA) AND 
        (pCAD_PAC_NR_PRONTUARIO is null OR CAD_PAC_NR_PRONTUARIO = pCAD_PAC_NR_PRONTUARIO);          
    io_cursor := v_cursor;
  end PRC_ASS_PPT_PESSOA_PRONTUA_S;
