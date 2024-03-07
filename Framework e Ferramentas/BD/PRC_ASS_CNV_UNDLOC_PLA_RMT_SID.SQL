  --PRC_ASS_CNV_UNDLOC_PLA_RMT_SID
  create or replace procedure PRC_ASS_CNV_UNDLOC_PLA_RMT_SID 
  (
     pASS_CLP_ID IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_UNDLOC_PLA_RMT_SID
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
       ASS_CLP_ID,
       ASS_CUL_ID,
       ASS_CLP_DT_INI_VIGENCIA,
       ASS_CLP_DT_FIM_VIGENCIA,
       CAD_PLA_ID_PLANO,
       ASS_CLP_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ASS_CLP_FL_BLOQUEIA_UNIDADE_OK
    FROM TB_ASS_CLP_CNV_UND_LOC_PLANO
    WHERE
        ASS_CLP_ID = pASS_CLP_ID;          
    io_cursor := v_cursor;
  end PRC_ASS_CNV_UNDLOC_PLA_RMT_SID;
