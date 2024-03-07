  --PRC_ASS_CNV_DC_LOC_PLA_RMT_S
  create or replace procedure PRC_ASS_CNV_DC_LOC_PLA_RMT_S 
  (
     pASS_CDP_ID IN TB_ASS_CDP_CNV_DC_LOC_PLANO.ASS_CDP_ID%type DEFAULT NULL,
     pASS_CDL_ID IN TB_ASS_CDP_CNV_DC_LOC_PLANO.ASS_CDL_ID%type DEFAULT NULL,
     pCAD_PLA_ID_PLANO IN TB_ASS_CDP_CNV_DC_LOC_PLANO.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     pASS_CDP_DT_ULTIMA_ATUALIZACAO IN TB_ASS_CDP_CNV_DC_LOC_PLANO.ASS_CDP_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_CDP_CNV_DC_LOC_PLANO.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_DC_LOC_PLA_RMT_S
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
        (pASS_CDP_ID is null OR ASS_CDP_ID = pASS_CDP_ID) AND 
        (pASS_CDL_ID is null OR ASS_CDL_ID = pASS_CDL_ID) AND 
        (pCAD_PLA_ID_PLANO is null OR CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO) AND 
        (pASS_CDP_DT_ULTIMA_ATUALIZACAO is null OR ASS_CDP_DT_ULTIMA_ATUALIZACAO = pASS_CDP_DT_ULTIMA_ATUALIZACAO) AND 
        (pSEG_USU_ID_USUARIO is null OR SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO);          
    io_cursor := v_cursor;
  end PRC_ASS_CNV_DC_LOC_PLA_RMT_S;
