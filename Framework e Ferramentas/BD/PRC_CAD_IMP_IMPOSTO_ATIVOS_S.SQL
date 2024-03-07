create procedure PRC_CAD_IMP_IMPOSTO_ATIVOS_S
  (
     pCAD_IMP_ID_IMPOSTO IN TB_CAD_IMP_IMPOSTO.CAD_IMP_ID_IMPOSTO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_IMP_IMPOSTO_ATIVOS_S
  * 
  *    Data Criacao: 	  29/05/2007           Por: Fabiola R. Lopes
  *    Data Alteracao:	                     Por: 
  *
  *    Funcao: Recupera os Impostos ativos cadastrados
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CAD_IMP_ID_IMPOSTO,
       CAD_IMP_NM_IMPOSTO,
       CAD_IMP_DS_IMPOSTO,
       CAD_IMP_FL_ATIVO_OK,
       SEG_USU_ID_USUARIO,
       CAD_IMP_DT_ULTIMA_ATUALIZACAO
    FROM TB_CAD_IMP_IMPOSTO
    WHERE
        (pCAD_IMP_ID_IMPOSTO is null OR CAD_IMP_ID_IMPOSTO = pCAD_IMP_ID_IMPOSTO)
        AND CAD_IMP_FL_ATIVO_OK = 'S';
    io_cursor := v_cursor;
  end PRC_CAD_IMP_IMPOSTO_ATIVOS_S;