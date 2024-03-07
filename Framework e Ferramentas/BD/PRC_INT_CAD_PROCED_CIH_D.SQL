  --PRC_INT_CAD_PROCED_CIH_D
  create or replace procedure PRC_INT_CAD_PROCED_CIH_D 
  (
     pCAD_PCI_CD_PROCEDIMENTO_CIH IN TB_CAD_PCI_PROCED_CIH.CAD_PCI_CD_PROCEDIMENTO_CIH%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_CAD_PROCED_CIH_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_CAD_PCI_PROCED_CIH
    WHERE  
        CAD_PCI_CD_PROCEDIMENTO_CIH = pCAD_PCI_CD_PROCEDIMENTO_CIH;	   
  end PRC_INT_CAD_PROCED_CIH_D;
