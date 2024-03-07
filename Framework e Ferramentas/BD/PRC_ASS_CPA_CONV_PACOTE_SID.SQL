  --PRC_ASS_CPA_CONV_PACOTE_SID
  create or replace procedure PRC_ASS_CPA_CONV_PACOTE_SID
  (
     pASS_CPA_ID IN TB_ASS_CPA_CONVENIO_PACOTE.ASS_CPA_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CPA_CONV_PACOTE_SID
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
       ASS_CPA_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_PLA_ID_PLANO,
       CAD_PRD_ID,
       ASS_CPA_FL_STATUS,
       ASS_CPA_DT_INICIO_VIGENCIA,
       ASS_CPA_DT_FIM_VIGENCIA,
       ASS_CPA_FL_LANC_PAC_ABERTO,
       ASS_CPA_DS_OBSERVACAO,
       ASS_CPA_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_ASS_CPA_CONVENIO_PACOTE
    WHERE
        ASS_CPA_ID = pASS_CPA_ID;          
    io_cursor := v_cursor;
  end PRC_ASS_CPA_CONV_PACOTE_SID;