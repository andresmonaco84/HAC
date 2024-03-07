  --PRC_ASS_CNV_UNIDADE_RMT_SID
  create or replace procedure PRC_ASS_CNV_UNIDADE_RMT_SID 
  (
     pASS_CNU_ID IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_UNIDADE_RMT_SID
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
       ASS_CNU_ID,
       ASS_CNU_DT_INI_VIGENCIA,
       ASS_CNU_DT_FIM_VIGENCIA,
       ASS_CNU_DS_MOTIVO_FIM_VIGENCIA,
       ASS_CNU_DT_ULTIMA_ATUALIZACAO,
       CAD_CNV_ID_CONVENIO,
       CAD_UNI_ID_UNIDADE,
       SEG_USU_ID_USUARIO
    FROM TB_ASS_CNU_CONVENIO_UNIDADE
    WHERE
        ASS_CNU_ID = pASS_CNU_ID;          
    io_cursor := v_cursor;
  end PRC_ASS_CNV_UNIDADE_RMT_SID;
