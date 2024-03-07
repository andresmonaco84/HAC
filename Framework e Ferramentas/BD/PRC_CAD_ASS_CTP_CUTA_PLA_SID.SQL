  --PRC_INT_ASS_CTP_CUTA_PLA_SID
  create or replace procedure PRC_CAD_ASS_CTP_CUTA_PLA_SID 
  (
     pASS_CTP_ID IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_ASS_CTP_CUTA_PLA_SID
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
       ASS_CTP_ID,
       ASS_CUT_ID,
       ASS_CTP_DT_INI_VIGENCIA,
       ASS_CTP_DT_FIM_VIGENCIA,
       CAD_PLA_ID_PLANO,
       ASS_CTP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_ASS_CTP_CNV_UN_TPACOM_PLA
    WHERE
        ASS_CTP_ID = pASS_CTP_ID;          
    io_cursor := v_cursor;
  end PRC_CAD_ASS_CTP_CUTA_PLA_SID;
