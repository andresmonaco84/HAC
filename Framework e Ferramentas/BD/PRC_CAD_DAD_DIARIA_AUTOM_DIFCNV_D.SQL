  --PRC_CAD_DAD_DIARIA_AUTOM_DIFCNV_D
  create or replace procedure PRC_CAD_DAD_DIARIA_AUTOM_DIFCNV_D 
  (
     pCAD_DAD_ID IN TB_CAD_DAD_DIARIA_AUTOM_DIFCNV.CAD_DAD_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_DAD_DIARIA_AUTOM_DIFCNV_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_DAD_DIARIA_AUTOM_DIFCNV
    WHERE  
        CAD_DAD_ID = pCAD_DAD_ID;	   
  end PRC_CAD_DAD_DIARIA_AUTOM_DIFCNV_D;