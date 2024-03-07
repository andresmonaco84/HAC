  create or replace procedure PRC_CAD_GPE_GRUPO_EMPRESA_D 
  (
     pCAD_GPE_ID_GRUPO_EMPRESA IN TB_CAD_GPE_GRUPO_EMPRESA.CAD_GPE_ID_GRUPO_EMPRESA%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_GPE_GRUPO_EMPRESA_D
  * 
  *    Data Criacao: 20/06/2007	   Por: Cristiane Gomes da Silva
  *    Data Alteracao:	            Por: 
  *
  *    Funcao: Exclui Grupo de Empresa
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_GPE_GRUPO_EMPRESA
    WHERE  
        CAD_GPE_ID_GRUPO_EMPRESA = pCAD_GPE_ID_GRUPO_EMPRESA;	   
  end PRC_CAD_GPE_GRUPO_EMPRESA_D;
/
