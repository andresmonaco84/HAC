create or replace procedure PRC_ASS_CUI_CONV_UNI_IMP_CONV
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUI_CONV_UNI_IMP_CONV
  *
  *    Data Criacao: 	28/05/2007         Por: Fabiola R. Lopes
  *    Funcao: Recuperar a Associacao do Convenio Unidade com Imposto por Convênio
  *
  *    Data Alteracao:	28/08/2007       Por: Andrea Cazuca
  *    Alteracao:   Incluido ordenação por data de inicio e fim de vigencia
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
   SELECT
       A.ASS_CUI_ID,
       A.ASS_CUI_DT_INI_VIGENCIA,
       A.ASS_CUI_DT_FIM_VIGENCIA,
       A.ASS_CNU_ID,
       A.ASS_CUI_PC_IMPOSTO,
       A.ASS_CUI_DS_MOTIVO_FIM_VIGENCIA,
       A.ASS_CUI_DT_ULTIMA_ATUALIZACAO,
       A.CAD_IMP_ID_IMPOSTO,
       A.ASS_CUI_VL_MIN_RECOLHIM,
       A.SEG_USU_ID_USUARIO
    FROM TB_ASS_CUI_CONV_UNI_IMPOSTO A, TB_ASS_CNU_CONVENIO_UNIDADE B
    WHERE A.ASS_CNU_ID = B.ASS_CNU_ID
    AND   B.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO
    ORDER BY A.ASS_CUI_DT_INI_VIGENCIA DESC, A.ASS_CUI_DT_FIM_VIGENCIA DESC;
    io_cursor := v_cursor;
  end PRC_ASS_CUI_CONV_UNI_IMP_CONV;
/
