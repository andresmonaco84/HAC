  create or replace procedure PRC_CAD_CHS_CONV_HIST_STATUS_S 
  (
     pCAD_CHS_ID IN TB_CAD_CHS_CONV_HISTO_STATUS.CAD_CHS_ID%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     pCAD_CHS_DT_INI_VIGENCIA IN TB_CAD_CHS_CONV_HISTO_STATUS.CAD_CHS_DT_INI_VIGENCIA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CHS_CONV_HIST_STATUS_S
  * 
  *    Data Criacao: 	20/06/2007   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Lista os Status do Convênio
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CAD_CHS_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_CHS_DT_INI_VIGENCIA,
       CAD_CHS_DT_FIM_VIGENCIA,
       CAD_CHS_FL_STATUS,
       CAD_CHS_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_CAD_CHS_CONV_HISTO_STATUS
    WHERE
        (pCAD_CHS_ID is null OR CAD_CHS_ID = pCAD_CHS_ID)
    AND (pCAD_CNV_ID_CONVENIO is null OR CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
    AND (pCAD_CHS_DT_INI_VIGENCIA is null OR CAD_CHS_DT_INI_VIGENCIA = pCAD_CHS_DT_INI_VIGENCIA)
    ORDER BY CAD_CHS_ID desc;
    io_cursor := v_cursor;
  end PRC_CAD_CHS_CONV_HIST_STATUS_S;
/
