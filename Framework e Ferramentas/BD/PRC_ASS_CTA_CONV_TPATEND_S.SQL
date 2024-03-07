  create or replace procedure PRC_ASS_CTA_CONV_TPATEND_S 
  (
     pASS_CTA_ID IN TB_ASS_CTA_CONV_TPATEND.ASS_CTA_ID%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CTA_CONV_TPATEND_S
  * 
  *    Data Criacao: 	29/05/2007   Por: Andrea Cazuca
  *    Funcao: Lista a Associação Convenio X Tipo de Atendimento
  *
  *    Data Alteracao:	26/06/2007  Por: Andrea Cazuca
  *    Alteracao: Foi incluido um order by
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
        (pASS_CTA_ID is null OR ASS_CTA_ID = pASS_CTA_ID)
    AND (pCAD_CNV_ID_CONVENIO is null or CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
    ORDER BY ASS_CTA_DT_INI_VIGENCIA DESC, ASS_CTA_DT_FIM_VIGENCIA DESC;
    io_cursor := v_cursor;
  end PRC_ASS_CTA_CONV_TPATEND_S;
/
