  create or replace procedure PRC_CAD_GPE_GRUPO_EMPRESA_U
  (
     pCAD_GPE_ID_GRUPO_EMPRESA IN TB_CAD_GPE_GRUPO_EMPRESA.CAD_GPE_ID_GRUPO_EMPRESA%type,
     pCAD_GPE_DS_GRUPO_EMPRESA IN TB_CAD_GPE_GRUPO_EMPRESA.CAD_GPE_DS_GRUPO_EMPRESA%type,
     pCAD_GPE_CD_GRUPO IN TB_CAD_GPE_GRUPO_EMPRESA.CAD_GPE_CD_GRUPO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_GPE_GRUPO_EMPRESA_U
  * 
  *    Data Criacao: 	20/06/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 21/06/2007   Por: Cristiane Gomes da Silva
  *
  *    Alteração: 1) Retirada da coluna CAD_GPE_FL_COPART_OK
  *
  *    Funcao: Altera Grupo de Empresa
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_GPE_GRUPO_EMPRESA
    SET	   
        CAD_GPE_DS_GRUPO_EMPRESA = UPPER(pCAD_GPE_DS_GRUPO_EMPRESA),
        CAD_GPE_CD_GRUPO = UPPER(pCAD_GPE_CD_GRUPO) 
    WHERE
        CAD_GPE_ID_GRUPO_EMPRESA = pCAD_GPE_ID_GRUPO_EMPRESA;	
  end PRC_CAD_GPE_GRUPO_EMPRESA_U;
/
