  --PRC_INT_CAD_CID_CID10_D
  create or replace procedure PRC_INT_CAD_CID_CID10_D 
  (
     pCAD_CID_CD_CID10 IN TB_CAD_CID_CID10.CAD_CID_CD_CID10%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_CAD_CID_CID10_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_CID_CID10
    WHERE  
        CAD_CID_CD_CID10 = pCAD_CID_CD_CID10;	   
  end PRC_INT_CAD_CID_CID10_D;
