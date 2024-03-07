  create or replace procedure PRC_ASS_CNU_CONVENIO_UNIDADE_S 
  (
     pASS_CNU_ID IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_ID%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNU_CONVENIO_UNIDADE_S
  * 
  *    Data Criacao: 	25/05/2007   Por: Andrea Cazuca
  *    Funcao: Seleciona a associacao de Convenio X Unidade
  *
  *    Data Alteracao:	26/06/2007  Por: Andrea Cazuca
  *    Alteracao: Foi incluido um order by
  *    
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
        (pASS_CNU_ID is null OR ASS_CNU_ID = pASS_CNU_ID)
    AND (pCAD_CNV_ID_CONVENIO is null OR CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
    AND (pCAD_UNI_ID_UNIDADE is null OR CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    ORDER BY ASS_CNU_DT_INI_VIGENCIA DESC, ASS_CNU_DT_FIM_VIGENCIA DESC;
    io_cursor := v_cursor;
  end PRC_ASS_CNU_CONVENIO_UNIDADE_S;
/
