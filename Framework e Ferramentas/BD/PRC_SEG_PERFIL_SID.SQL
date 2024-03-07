  create or replace procedure PRC_SEG_PERFIL_SID 
  (
     pSEG_PER_ID_PERFIL IN TB_SEG_PER_PERFIL.SEG_PER_ID_PERFIL%type     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PER_PERFIL_SID
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
       SEG_PER_NM_PERFIL,
       SEG_PER_FL_STATUS,
       SEG_PER_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       SEG_ID_SISTEMA
    FROM TB_SEG_PER_PERFIL
    WHERE
        SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL;          
    io_cursor := v_cursor;
  end PRC_SEG_PERFIL_SID;
