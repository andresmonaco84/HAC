  --PRC_CAD_ECC_ESCALA_CTRL_CIRC_S
  create or replace procedure PRC_AGE_ECC_ESCALA_CTRL_CIRC_S 
  (
     pAGE_ECC_ID IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_ID%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_AGE_ECC_ESCALA_CTRL_CIRC.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pAGE_ECC_NR_CIRCULAR IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_NR_CIRCULAR%type DEFAULT null,
     pAGE_ECC_TP_CIRCULAR IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_TP_CIRCULAR%TYPE DEFAULT NULL,
     pAGE_ECC_CD_FISICO IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_CD_FISICO%TYPE DEFAULT NULL,
     pAGE_ECC_DT_CIRCULAR IN TB_AGE_ECC_ESCALA_CTRL_CIRC.AGE_ECC_DT_CIRCULAR%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGE_ECC_ESCALA_CTRL_CIRC_S
  * 
  *    Data Criacao: 	02/07/2007           Por: Guilherme Holdack
  *    Data Alteracao:	                     Por:                 
  *
  *    Funcao: Seleção de registros na tabela TB_AGE_ECC_ESCALA_CTRL_CIRC
  *
  *
  *    Data alteração: 11/10/2007          Por: Guilherme Holdack
  *    Alteração:  Inclusão de parâmetro para possibilitar busca por tipo de
  *                circular e por data de circular
  *
  *    Data Alteração: 19/10/2007          Por: Guilherme
  *    Alteração:  Inclusão de parâmetro e novo campo de código físico de circular
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       AGE_ECC_ID,
       AGE_ECC_NR_CIRCULAR,
       AGE_ECC_DT_CIRCULAR,
       AGE_ECC_DS_OBS_CIRCULAR,
       AGE_ECC_TP_CIRCULAR,
       SEG_USU_ID_USUARIO,
       AGE_ECC_DT_ULTIMA_ATUALIZACAO,
       CAD_UNI_ID_UNIDADE,
       age_ecc_cd_fisico
    FROM TB_AGE_ECC_ESCALA_CTRL_CIRC 
    WHERE
        (pAGE_ECC_ID is null OR AGE_ECC_ID = pAGE_ECC_ID)
    AND (pCAD_UNI_ID_UNIDADE is null OR CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
    AND (pAGE_ECC_NR_CIRCULAR is null or AGE_ECC_NR_CIRCULAR = pAGE_ECC_NR_CIRCULAR)
    AND (pAGE_ECC_TP_CIRCULAR IS NULL OR AGE_ECC_TP_CIRCULAR = pAGE_ECC_TP_CIRCULAR)
    AND (pAGE_ECC_DT_CIRCULAR IS NULL OR AGE_ECC_DT_CIRCULAR = pAGE_ECC_DT_CIRCULAR)
    AND (pAGE_ECC_CD_FISICO IS NULL OR AGE_ECC_CD_FISICO = pAGE_ECC_CD_FISICO);
    io_cursor := v_cursor;
  end PRC_AGE_ECC_ESCALA_CTRL_CIRC_S;
/
