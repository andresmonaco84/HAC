  --PRC_INT_ASS_CUT_SID
  create or replace procedure PRC_INT_ASS_CUT_SID 
  (
     pASS_CUT_ID IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_ASS_CUT_SID
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
       ASS_CUT_ID,
       ASS_CUT_DT_INI_VIGENCIA,
       ASS_CUT_DS_MOTIVO_FIM_VIGENCIA,
       ASS_CUT_DT_FIM_VIGENCIA,
       ASS_CUT_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ASS_UTA_ID_UNID_TPACOMOD,
       ASS_CNU_ID
    FROM TB_ASS_CUT_CONV_UNI_TPACOMOD
    WHERE
        ASS_CUT_ID = pASS_CUT_ID;          
    io_cursor := v_cursor;
  end PRC_INT_ASS_CUT_SID;
