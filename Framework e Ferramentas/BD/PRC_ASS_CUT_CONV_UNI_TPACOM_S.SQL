create or replace procedure PRC_ASS_CUT_CONV_UNI_TPACOM_S
  (
     pASS_CUT_ID IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUT_CONV_UNI_TPACOM_S
  *
  *    Data Criacao: 	12/06/2007         Por: Fabíola R. Lopes
  *    Data Alteracao:	                   Por:
  *
  *    Funcao: Recupera as Associações de Convênio Unidade x Tipo de Acomodação
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
       ASS_UTA_ID_UNID_TPACOMOD,
       SEG_USU_ID_USUARIO,
       ASS_CNU_ID
    FROM TB_ASS_CUT_CONV_UNI_TPACOMOD
    WHERE
        (pASS_CUT_ID is null OR ASS_CUT_ID = pASS_CUT_ID);
    io_cursor := v_cursor;
  end PRC_ASS_CUT_CONV_UNI_TPACOM_S;