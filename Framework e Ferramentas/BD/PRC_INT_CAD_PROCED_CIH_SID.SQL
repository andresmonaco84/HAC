  --PRC_INT_CAD_PROCED_CIH_SID
  create or replace procedure PRC_INT_CAD_PROCED_CIH_SID 
  (
     pCAD_PCI_CD_PROCEDIMENTO_CIH IN TB_CAD_PCI_PROCED_CIH.CAD_PCI_CD_PROCEDIMENTO_CIH%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_CAD_PROCED_CIH_SID
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CAD_PCI_CD_PROCEDIMENTO_CIH,
       CAD_PCI_DS_PROCEDIMENTOCIH,
       CAD_CID_CD_CID10
    FROM TB_CAD_PCI_PROCED_CIH
    WHERE
        CAD_PCI_CD_PROCEDIMENTO_CIH = pCAD_PCI_CD_PROCEDIMENTO_CIH;          
    io_cursor := v_cursor;
  end PRC_INT_CAD_PROCED_CIH_SID;
