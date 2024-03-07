  --PRC_ASS_CNV_DC_LOC_PLA_RMT_SID
  create or replace procedure PRC_ASS_CNV_DC_LOC_PLA_RMT_SID 
  (
     pASS_CDP_ID IN TB_ASS_CDP_CNV_DC_LOC_PLANO.ASS_CDP_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_DC_LOC_PLA_RMT_SID
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
       ASS_CDP_ID,
       ASS_CDL_ID,
       CAD_PLA_ID_PLANO,
       ASS_CDP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_ASS_CDP_CNV_DC_LOC_PLANO
    WHERE
        ASS_CDP_ID = pASS_CDP_ID;          
    io_cursor := v_cursor;
  end PRC_ASS_CNV_DC_LOC_PLA_RMT_SID;
