create or replace procedure PRC_ASS_EPL_EMP_PLA_S
  (
     pCAD_PLA_ID_PLANO IN TB_ASS_PLC_PLANO_CBOS.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     pCAD_EMP_ID_EMPRESA IN TB_CAD_EMP_EMPRESA.CAD_EMP_ID_EMPRESA%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_EPL_EMP_PLA_S
  *
  *    Data Criacao: 	20/11/2007   Por: Guilherme
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Lista associacao Empresa x Plano 
  *
  *******************************************************************/

     v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
      SELECT 
      epl.ass_epl_id,
      epl.cad_pla_id_plano,
      epl.cad_emp_id_empresa,
      epl.ass_epl_fl_status,
      epl.seg_usu_id_usuario


      FROM
      tb_ass_epl_empresa_plano epl
    WHERE
            (pCAD_PLA_ID_PLANO IS NULL OR epl.cad_pla_id_plano = pCAD_PLA_ID_PLANO)
        AND (pCAD_EMP_ID_EMPRESA IS NULL OR epl.cad_emp_id_empresa = pCAD_EMP_ID_EMPRESA);
         io_cursor := v_cursor;
  end PRC_ASS_EPL_EMP_PLA_S;
/
