create or replace procedure PRC_ASS_EPL_EMP_PLA_I
  (
  pNewIdt OUT integer,
pCAD_EMP_ID_EMPRESA IN tb_cad_emp_empresa.cad_emp_id_empresa%TYPE,
pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE,
pASS_EPL_FL_STATUS IN TB_ASS_EPL_EMPRESA_PLANO.ASS_EPL_FL_STATUS%TYPE,
pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%TYPE
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_EPL_EMP_PLA_I
  *
  *    Data Criacao: 	20/11/2007   Por: Guilherme
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Inclui associacao Empresa X Plano
  *
  *******************************************************************/
 	lIdtRetorno integer;


  BEGIN

  SELECT SEQ_ASS_CDL_01.NextVal INTO lIdtRetorno FROM DUAL;

  INSERT INTO tb_ass_epl_empresa_plano 
  (
  ass_epl_id,
  cad_pla_id_plano,
  cad_emp_id_empresa,
  ass_epl_fl_status,
  seg_usu_id_usuario,
  ass_epl_dt_ultima_atualizacao)
  
  VALUES
  (
  lIdtRetorno,
  pCAD_PLA_ID_PLANO,
  pCAD_EMP_ID_EMPRESA,
  pASS_EPL_FL_STATUS,
  pSEG_USU_ID_USUARIO,
  SYSDATE
  );
   pNewIdt := lIdtRetorno;
  end PRC_ASS_EPL_EMP_PLA_I;
/
