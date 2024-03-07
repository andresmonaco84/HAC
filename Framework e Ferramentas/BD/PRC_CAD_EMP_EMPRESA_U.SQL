  create or replace procedure PRC_CAD_EMP_EMPRESA_U
  (
     pCAD_EMP_ID_EMPRESA IN TB_CAD_EMP_EMPRESA.CAD_EMP_ID_EMPRESA%type,
     pCAD_EMP_CD_EMPRESA IN TB_CAD_EMP_EMPRESA.CAD_EMP_CD_EMPRESA%type,
     pCAD_PES_ID_PESSOA IN TB_CAD_EMP_EMPRESA.CAD_PES_ID_PESSOA%type,
     pCAD_GPE_ID_GRUPO_EMPRESA IN TB_CAD_EMP_EMPRESA.CAD_GPE_ID_GRUPO_EMPRESA%type default NULL,
     pCAD_EMP_FL_COPART_OK IN TB_CAD_EMP_EMPRESA.CAD_EMP_FL_COPART_OK%type,
     pCAD_EMP_FL_STATUS IN TB_CAD_EMP_EMPRESA.CAD_EMP_FL_STATUS%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_EMP_EMPRESA_U
  * 
  *    Data Criacao: 	21/06/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao:	           Por: 
  *
  *    Funcao: Altera Empresa
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_EMP_EMPRESA
    SET	   
        CAD_EMP_CD_EMPRESA       = UPPER(pCAD_EMP_CD_EMPRESA),
        CAD_PES_ID_PESSOA        = pCAD_PES_ID_PESSOA,
        CAD_GPE_ID_GRUPO_EMPRESA = pCAD_GPE_ID_GRUPO_EMPRESA,
        CAD_EMP_FL_COPART_OK     = UPPER(pCAD_EMP_FL_COPART_OK),
        CAD_EMP_FL_STATUS        = pCAD_EMP_FL_STATUS
    WHERE
        CAD_EMP_ID_EMPRESA = pCAD_EMP_ID_EMPRESA;	
  end PRC_CAD_EMP_EMPRESA_U;
/
