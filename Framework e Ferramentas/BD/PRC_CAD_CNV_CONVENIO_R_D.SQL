

  --PRC_CAD_CNV_CONVENIO_R_D
  create or replace procedure PRC_CAD_CNV_CONVENIO_R_D 
  (
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CNV_CONVENIO_R_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_CNV_CONVENIO
    WHERE  
        CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO;	   
  end PRC_CAD_CNV_CONVENIO_R_D;
