  create or replace procedure PRC_CAD_GPE_GRUPO_EMPRESA_I
  (
     pNewIdt OUT integer,
     pCAD_GPE_DS_GRUPO_EMPRESA IN TB_CAD_GPE_GRUPO_EMPRESA.CAD_GPE_DS_GRUPO_EMPRESA%type,
     pCAD_GPE_CD_GRUPO IN TB_CAD_GPE_GRUPO_EMPRESA.CAD_GPE_CD_GRUPO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_GPE_GRUPO_EMPRESA_I
  *
  *    Data Criacao: 	20/06/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 25/06/2007   Por: Cristiane Gomes da Silva
  *
  *    Alteração: 1) Retirada da coluna CAD_GPE_FL_COPART_OK
  *
  *    Funcao: Inclui Grupo de Empresa
  *
  *******************************************************************/
    lIdtRetorno integer;
  begin
    
    SELECT SEQ_CAD_GPE_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_CAD_GPE_GRUPO_EMPRESA
    (
       CAD_GPE_ID_GRUPO_EMPRESA,
       CAD_GPE_DS_GRUPO_EMPRESA,
       CAD_GPE_CD_GRUPO
    )
    VALUES
    (
	     lIdtRetorno,
	     UPPER(pCAD_GPE_DS_GRUPO_EMPRESA),
	     UPPER(pCAD_GPE_CD_GRUPO)
    );
    pNewIdt := lIdtRetorno;

  end PRC_CAD_GPE_GRUPO_EMPRESA_I;
