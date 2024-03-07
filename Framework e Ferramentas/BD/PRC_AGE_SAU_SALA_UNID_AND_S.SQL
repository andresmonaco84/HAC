create or replace procedure PRC_AGE_SAU_SALA_UNID_AND_S
  (
    pAGE_SAU_ID IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_ID%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_AGE_SAU_SALA_UNID_AND.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGE_SAU_SALA_UNID_AND_S
  * 
  *    Data Criacao: 	05/07/2007            Por: Guilherme Holdack
  *    Data Alteracao: 24/04/2008           Por: Silmara
  *    Alteracao: Inclusao campo
  *    Funcao: Seleção de registros da tabela TB_AGE_SAU_SALA_UNID_AND
  *
  *******************************************************************/ 
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       AGE_SAU_ID,
       AGE_SAU_CD_ANDAR,
       AGE_SAU_NR_SALA,
       CAD_UNI_ID_UNIDADE,
       AGE_SAU_FL_STATUS,
       SEG_USU_ID_USUARIO,
       AGE_SAU_DT_ULTIMA_ATUALIZACAO,
       AGE_SAU_DS_SALA
    FROM TB_AGE_SAU_SALA_UNID_AND
    WHERE
     (pAGE_SAU_ID is null OR AGE_SAU_ID = pAGE_SAU_ID)
      AND (pCAD_UNI_ID_UNIDADE is null OR CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
      ORDER BY AGE_SAU_CD_ANDAR, AGE_SAU_NR_SALA;
    io_cursor := v_cursor;
  end PRC_AGE_SAU_SALA_UNID_AND_S;
