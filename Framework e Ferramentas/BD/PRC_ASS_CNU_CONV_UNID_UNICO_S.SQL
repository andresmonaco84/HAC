create or replace procedure PRC_ASS_CNU_CONV_UNID_UNICO_S
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
     pASS_CNU_ID IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_ID%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNU_CONV_UNID_UNICO_S
  *
  *    Data Criacao: 	30/05/2007   Por: Fabiola R. Lopes
  *    Funcao: Seleciona Associacao de Convenio X Unidade não repetidos
  *
  *    Data Alteracao: 26/06/2007   Por: Andrea Cazuca
  *    Alteracao: Foi alterado para trazer somente as unidade vigentes
  *
  *    Data Alteracao: 14/07/2008   Por: Andrea Cazuca
  *    Alteracao: Foi incluido o trunco da verificacao de data
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT ASS_CNU_ID,
           CAD_CNV_ID_CONVENIO,
           CAD_UNI_ID_UNIDADE,
           ASS_CNU_DT_INI_VIGENCIA,
           ASS_CNU_DT_FIM_VIGENCIA
    FROM   TB_ASS_CNU_CONVENIO_UNIDADE 
    WHERE  (pCAD_CNV_ID_CONVENIO is null or CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
    AND    (pASS_CNU_ID is null or ASS_CNU_ID = pASS_CNU_ID)
    AND    (pCAD_UNI_ID_UNIDADE is null or CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    AND    (ASS_CNU_DT_FIM_VIGENCIA IS NULL OR trunc(ASS_CNU_DT_FIM_VIGENCIA) >= trunc(SYSDATE) +1);
    io_cursor := v_cursor;
  end PRC_ASS_CNU_CONV_UNID_UNICO_S;
/
