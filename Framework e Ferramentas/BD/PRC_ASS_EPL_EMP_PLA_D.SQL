create or replace procedure PRC_ASS_EPL_EMP_PLA_D
  (
pCAD_EMP_ID_EMPRESA IN tb_cad_emp_empresa.cad_emp_id_empresa%TYPE,
pCAD_PLA_CD_TIPOPLANO IN Tb_Cad_Pla_Plano.Cad_Pla_Cd_Tipoplano%TYPE
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_EPL_EMP_PLA_D
  *
  *    Data Criacao: 	20/11/2007   Por: Guilherme
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Exclui associacao Empresa X Plano
  *
  *******************************************************************/
  begin
    DELETE tb_ass_epl_empresa_plano epl
    WHERE
       epl.cad_emp_id_empresa = pCAD_EMP_ID_EMPRESA
       AND epl.cad_pla_id_plano IN
       (SELECT pla.cad_pla_id_plano
       FROM
       tb_cad_pla_plano pla
       WHERE
       pla.cad_pla_cd_tipoplano = pCAD_PLA_CD_TIPOPLANO
       )
       ;
  end PRC_ASS_EPL_EMP_PLA_D;
/
