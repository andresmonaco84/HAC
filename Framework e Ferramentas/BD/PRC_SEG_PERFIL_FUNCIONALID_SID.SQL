
  create or replace procedure PRC_SEG_PERFIL_FUNCIONALID_SID 
  (
     pSEG_FUN_ID_FUNCIONALIDADE IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_FUN_ID_FUNCIONALIDADE%type,
     pSEG_MOD_ID_MODULO IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_MOD_ID_MODULO%type,
     pSEG_PER_ID_PERFIL IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_PER_ID_PERFIL%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PFU_PERFIL_FUNCIONALID_SID
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
       SEG_PER_ID_PERFIL,
       SEG_MOD_ID_MODULO,
       SEG_FUN_ID_FUNCIONALIDADE
    FROM TB_SEG_PFU_PERFIL_FUNCIONALID
    WHERE
        SEG_FUN_ID_FUNCIONALIDADE = pSEG_FUN_ID_FUNCIONALIDADE
    AND SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO
    AND SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL;          
    io_cursor := v_cursor;
  end PRC_SEG_PFU_PERFIL_FUNCIONALID_SID;
