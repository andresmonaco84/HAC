CREATE OR REPLACE PROCEDURE PRC_MTMD_USU_UNIDADE_S
(
     pSEG_USU_ID_USUARIO IN TB_SEG_UUN_USUARIO_UNIDADE.SEG_USU_ID_USUARIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_SEG_UUN_USUARIO_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
 /********************************************************************
  *    Procedure: PRC_MTMD_USU_UNIDADE
  *
  *    Data Criacao:  03/05/2010   Por: RICARDO COSTA
  *    Data Alteracao:	25/02/2013  Por: André
  *         Alteracao:	Inclusão de order by
  *
  *    Funcao: Obtem as unidades associadas ao usuário ou verifica se usuário tem acesso
               a unidade passada como parametro
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT UUN.CAD_UNI_ID_UNIDADE,
           UNI.cad_uni_ds_unidade
    FROM TB_SEG_UUN_USUARIO_UNIDADE UUN,
         TB_CAD_UNI_UNIDADE         UNI
    WHERE UUN.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    AND   (pCAD_UNI_ID_UNIDADE IS NULL OR UUN.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
    AND   UNI.cad_uni_id_unidade = UUN.cad_uni_id_unidade
    ORDER BY UNI.cad_uni_ds_unidade;
    io_cursor := v_cursor;
  end PRC_MTMD_USU_UNIDADE_S;
 
