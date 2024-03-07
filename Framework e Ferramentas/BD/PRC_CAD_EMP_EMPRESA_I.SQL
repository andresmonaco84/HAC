  create or replace procedure PRC_CAD_EMP_EMPRESA_I
  (
     pNewIdt OUT integer,
     pCAD_EMP_CD_EMPRESA IN TB_CAD_EMP_EMPRESA.CAD_EMP_CD_EMPRESA%type,
     pCAD_PES_ID_PESSOA IN TB_CAD_EMP_EMPRESA.CAD_PES_ID_PESSOA%type,
     pCAD_GPE_ID_GRUPO_EMPRESA IN TB_CAD_EMP_EMPRESA.CAD_GPE_ID_GRUPO_EMPRESA%type default NULL,
     pCAD_EMP_FL_COPART_OK IN TB_CAD_EMP_EMPRESA.CAD_EMP_FL_COPART_OK%type,
     pCAD_EMP_FL_STATUS IN TB_CAD_EMP_EMPRESA.CAD_EMP_FL_STATUS%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_EMP_EMPRESA_I
  *
  *    Data Criacao: 	  21/06/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao:  27/07/2007   Por: Carlos Araujo
  *    Alteração: Inclusão de campo status
  *
  *
  *    Funcao: Inclui uma Empresa
  *
  *******************************************************************/
    lIdtRetorno integer;

  begin
    SELECT SEQ_CAD_EMP_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_CAD_EMP_EMPRESA
    (
       CAD_EMP_ID_EMPRESA,
       CAD_EMP_CD_EMPRESA,
       CAD_PES_ID_PESSOA,
       CAD_GPE_ID_GRUPO_EMPRESA,
       CAD_EMP_FL_COPART_OK,
       CAD_EMP_FL_STATUS
    )
    VALUES
    (
	     lIdtRetorno,
	     UPPER(pCAD_EMP_CD_EMPRESA),
	     pCAD_PES_ID_PESSOA,
	     pCAD_GPE_ID_GRUPO_EMPRESA,
	     UPPER(pCAD_EMP_FL_COPART_OK),
       pCAD_EMP_FL_STATUS
    );
    pNewIdt := lIdtRetorno;

  end PRC_CAD_EMP_EMPRESA_I;
/
