  --PRC_CAD_PHS_PLA_HISTO_STATUS_D
  create or replace procedure PRC_CAD_PHS_PLA_HISTO_STATUS_D 
  (
     pCAD_PHS_ID IN TB_CAD_PHS_PLA_HISTO_STATUS.CAD_PHS_ID%type	
  )
  is
   /********************************************************************
  *    Procedure: PRC_CAD_PHS_PLA_HISTO_STATUS_D
  * 
  *    Data Criacao: 10/08/2007   Por: Guilherme Holdack
  *    Data Alteracao:	           Por: 
  *
  *    Funcao: Deletar registros na tabela TB_CAD_PHS_PLA_HISTO_STATUS
  *
  *******************************************************************/  
  begin
    DELETE TB_CAD_PHS_PLA_HISTO_STATUS
    WHERE  
        CAD_PHS_ID = pCAD_PHS_ID;	   
  end PRC_CAD_PHS_PLA_HISTO_STATUS_D;
/
