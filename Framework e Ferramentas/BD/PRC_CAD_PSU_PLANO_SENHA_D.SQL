
  --PRC_CAD_PSU_PLANO_SENHA_UTIL_D
  create or replace procedure PRC_CAD_PSU_PLANO_SENHA_D 
  (
     pCAD_PSU_NR_SENHA_UTILIZADA IN TB_CAD_PSU_PLANO_SENHA_UTIL.CAD_PSU_NR_SENHA_UTILIZADA%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PSU_PLANO_SENHA_UTIL_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_PSU_PLANO_SENHA_UTIL
    WHERE  
        CAD_PSU_NR_SENHA_UTILIZADA = pCAD_PSU_NR_SENHA_UTILIZADA;	   
  end PRC_CAD_PSU_PLANO_SENHA_D;

