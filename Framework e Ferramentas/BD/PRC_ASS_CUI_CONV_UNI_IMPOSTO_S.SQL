  --PRC_ASS_CUI_CONV_UNI_IMPOSTO_S
  create or replace procedure PRC_ASS_CUI_CONV_UNI_IMPOSTO_S 
  (
     pASS_CUI_ID IN TB_ASS_CUI_CONV_UNI_IMPOSTO.ASS_CUI_ID%type DEFAULT NULL,
     pASS_CNU_ID IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_ID%type DEFAULT NULL,
     -- pASS_CUI_DT_INI_VIGENCIA IN TB_ASS_CUI_CONV_UNI_IMPOSTO.ASS_CUI_DT_INI_VIGENCIA% type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUI_CONV_UNI_IMPOSTO_S
  * 
  *    Data Criacao: 	28/05/2007         Por: Fabiola R. Lopes
  *    Funcao: Recupera as Associacoes de Convenio Unidade e Impostos
  *
  *    Data Alteracao: 04/06/2007       Por: Andrea Cazuca
  *    Alteracao: Incluido o campo ASS_CNU_ID, para listar por Codigo do ConvenioUnidade
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       ASS_CUI_ID,
       ASS_CUI_DT_INI_VIGENCIA,
       ASS_CUI_DT_FIM_VIGENCIA,
       ASS_CNU_ID,
       ASS_CUI_PC_IMPOSTO,
       ASS_CUI_DS_MOTIVO_FIM_VIGENCIA,
       ASS_CUI_DT_ULTIMA_ATUALIZACAO,
       CAD_IMP_ID_IMPOSTO,
       ASS_CUI_VL_MIN_RECOLHIM,
       SEG_USU_ID_USUARIO
    FROM TB_ASS_CUI_CONV_UNI_IMPOSTO
    WHERE
        (pASS_CUI_ID is null OR ASS_CUI_ID = pASS_CUI_ID)
    AND (pASS_CNU_ID is null OR ASS_CNU_ID = pASS_CNU_ID)
    order by ASS_CUI_DT_INI_VIGENCIA DESC, ASS_CUI_DT_FIM_VIGENCIA DESC;
    io_cursor := v_cursor;
  end PRC_ASS_CUI_CONV_UNI_IMPOSTO_S;
/
