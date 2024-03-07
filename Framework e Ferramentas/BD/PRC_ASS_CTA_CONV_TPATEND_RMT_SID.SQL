  --PRC_ASS_CTA_CONV_TPATEND_RMT_SID
  create or replace procedure PRC_ASS_CTA_CONV_TPATD_RMT_SID 
  (
     pASS_CTA_ID IN TB_ASS_CTA_CONV_TPATEND.ASS_CTA_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CTA_CONV_TPATD_RMT_SID
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
       ASS_CTA_ID,
       CAD_CNV_ID_CONVENIO,
       TIS_TAT_CD_TPATENDIMENTO,
       ASS_CTA_DS_MOTIVO_FIM_VIGENCIA,
       ASS_CTA_DT_ULTIMA_ATUALIZACAO,
       ASS_CTA_DT_INI_VIGENCIA,
       ASS_CTA_DT_FIM_VIGENCIA,
       SEG_USU_ID_USUARIO
    FROM TB_ASS_CTA_CONV_TPATEND
    WHERE
        ASS_CTA_ID = pASS_CTA_ID;          
    io_cursor := v_cursor;
  end PRC_ASS_CTA_CONV_TPATD_RMT_SID;
