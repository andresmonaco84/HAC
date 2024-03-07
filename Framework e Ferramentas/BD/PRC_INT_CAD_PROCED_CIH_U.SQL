  --PRC_INT_CAD_PROCED_CIH_U
  create or replace procedure PRC_INT_CAD_PROCED_CIH_U
  (
     pCAD_PCI_CD_PROCEDIMENTO_CIH IN TB_CAD_PCI_PROCED_CIH.CAD_PCI_CD_PROCEDIMENTO_CIH%type,
     pCAD_PCI_DS_PROCEDIMENTOCIH IN TB_CAD_PCI_PROCED_CIH.CAD_PCI_DS_PROCEDIMENTOCIH%type,
     pCAD_CID_CD_CID10 IN TB_CAD_PCI_PROCED_CIH.CAD_CID_CD_CID10%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_CAD_PROCED_CIH_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_PCI_PROCED_CIH
    SET	   
        CAD_PCI_DS_PROCEDIMENTOCIH = pCAD_PCI_DS_PROCEDIMENTOCIH,
        CAD_CID_CD_CID10 = pCAD_CID_CD_CID10 
    WHERE
        CAD_PCI_CD_PROCEDIMENTO_CIH = pCAD_PCI_CD_PROCEDIMENTO_CIH;	
  end PRC_INT_CAD_PROCED_CIH_U;

