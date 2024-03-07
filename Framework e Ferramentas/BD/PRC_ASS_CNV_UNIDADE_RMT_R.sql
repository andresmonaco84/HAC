 create or replace procedure PRC_ASS_CNV_UNIDADE_RMT_R
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_CNV_ID_CONVENIO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_UNIDADE_RMT_R
  *
  *    Data Criacao:   26/11/2010   Por: André Souza Monaco
  *
  *    Funcao: Lista as unidades ref. do convênio
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       UNI.CAD_UNI_ID_UNIDADE,
       UNI.CAD_UNI_DS_UNIDADE,
       UNI.CAD_UNI_FL_STATUS,
       CNU.ASS_CNU_ID,
       CNU.ASS_CNU_DT_INI_VIGENCIA,
       CNU.ASS_CNU_DT_FIM_VIGENCIA      
    FROM TB_ASS_CNU_CONVENIO_UNIDADE CNU, TB_CAD_UNI_UNIDADE UNI
    WHERE CNU.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE AND
          CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
          ORDER BY UNI.CAD_UNI_DS_UNIDADE;
    io_cursor := v_cursor;
  end PRC_ASS_CNV_UNIDADE_RMT_R;
