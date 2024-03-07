  --PRC_ATS_REL_LAUDO_D
  create or replace procedure PRC_ATS_REL_LAUDO_D 
  (
  --   pCAD_PRD_ID IN TB_ATS_REL_LAUDO.CAD_PRD_ID%type,
     pIDT IN TB_ATS_REL_LAUDO.IDT%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_REL_LAUDO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATS_REL_LAUDO
    WHERE  
    -- CAD_PRD_ID = pCAD_PRD_ID
    -- AND 
    IDT = pIDT;	   
  end PRC_ATS_REL_LAUDO_D;
