create or replace procedure PRC_ASS_CUT_CONV_UNI_TPAC_CONV
  (
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CNU_CONVENIO_UNIDADE.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     pASS_CNU_ID IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CNU_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUT_CONV_UNI_TPAC_CONV
  *
  *    Data Criacao: 	12/06/2007           Por: Fabíola R. Lopes
  *    Funcao: Recupera as Associações de Convênio Unidade x Tipo de Acomodação por Convênio
  *
  *    Data Alteracao:	28/06/2007         Por: Andrea Cazuca
  *    Alteracao: Inclui o parametro ASS_CNU_ID para fazer pesquisa
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
      SELECT A.ASS_CUT_ID,
             A.ASS_CUT_DT_INI_VIGENCIA,
             A.ASS_CUT_DS_MOTIVO_FIM_VIGENCIA,
             A.ASS_CUT_DT_FIM_VIGENCIA,
             A.ASS_CUT_DT_ULTIMA_ATUALIZACAO,
             A.ASS_UTA_ID_UNID_TPACOMOD,
             A.SEG_USU_ID_USUARIO,
             A.ASS_CNU_ID
      FROM   TB_ASS_CUT_CONV_UNI_TPACOMOD A, TB_ASS_CNU_CONVENIO_UNIDADE B
      WHERE  A.ASS_CNU_ID = B.ASS_CNU_ID
      AND    (pCAD_CNV_ID_CONVENIO is null OR B.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
      AND    (pASS_CNU_ID is null OR A.ASS_CNU_ID = pASS_CNU_ID);
    io_cursor := v_cursor;
  end PRC_ASS_CUT_CONV_UNI_TPAC_CONV;
/
