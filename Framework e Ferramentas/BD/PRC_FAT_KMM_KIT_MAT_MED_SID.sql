create or replace procedure PRC_FAT_KMM_KIT_MAT_MED_SID
  (
     pFAT_KMM_ID IN TB_FAT_KMM_KIT_MAT_MED.FAT_KMM_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_KMM_KIT_MAT_MED_SID
  *
  *    Data Criacao: 	14/01/2010   Por: André Souza Monaco
  *    Data Alteracao:	--  Por: --
  *
  *    Funcao: Traz registro pelo seu id
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       FAT_KMM_ID,
       CAD_PRD_ID_KIT,
       FAT_KMM_DT_INI_VIGENCIA,
       FAT_KMM_DT_FIM_VIGENCIA,
       FAT_KMM_FL_STATUS,
       CAD_PRD_ID_ITEM,
       FAT_KMM_QT_ITEM,
       FAT_KMM_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_FAT_KMM_KIT_MAT_MED
    WHERE
        FAT_KMM_ID = pFAT_KMM_ID;
    io_cursor := v_cursor;
  end PRC_FAT_KMM_KIT_MAT_MED_SID;
