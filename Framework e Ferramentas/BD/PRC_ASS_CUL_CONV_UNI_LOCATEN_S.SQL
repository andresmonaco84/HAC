  --PRC_ASS_CUL_CONV_UNI_LOCATEN_S
  create or replace procedure PRC_ASS_CUL_CONV_UNI_LOCATEN_S 
  (
     pASS_CUL_ID IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_ID%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     pASS_CNU_ID IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUL_CONV_UNI_LOCATEN_S
  * 
  *    Data Criacao: 	05/06/2007  Por: Silmara
  *    Data Alteracao:12/06/2007  Por: Silmara
  *    Alteracao: Passar como parametro o convenio
  *
  *    Funcao: associacao convenio unidade local de atendimento
  *
  *    Data Alteracao: 26/06/2007  Por: Andrea Cazuca
  *    Alteracao:  Inclui o ASS_CNU_ID como parametro de pesquisa
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CUL.ASS_CUL_ID,
       CUL.ASS_CUL_DT_INI_VIGENCIA,
       CUL.ASS_CUL_DS_MOTIVO_FIM_VIGENCIA,
       CUL.ASS_CUL_DT_ULTIMA_ATUALIZACAO,
       CUL.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CUL.ASS_CUL_DT_FIM_VIGENCIA,
       CUL.SEG_USU_ID_USUARIO,
       CUL.ASS_CNU_ID
    FROM TB_ASS_CUL_CONV_UNI_LOCATEND CUL, TB_ASS_CNU_CONVENIO_UNIDADE CNU 
    WHERE
        (pASS_CUL_ID is null OR CUL.ASS_CUL_ID = pASS_CUL_ID)
    AND  (pCAD_CNV_ID_CONVENIO is null OR CNU.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
    AND  CNU.ASS_CNU_ID = CUL.ASS_CNU_ID
    AND  (pASS_CNU_ID is null OR CUL.ASS_CNU_ID = pASS_CNU_ID)
    ORDER BY CUL.ASS_CUL_DT_INI_VIGENCIA DESC, CUL.ASS_CUL_DT_FIM_VIGENCIA DESC;          
    io_cursor := v_cursor;
  end PRC_ASS_CUL_CONV_UNI_LOCATEN_S;
/
