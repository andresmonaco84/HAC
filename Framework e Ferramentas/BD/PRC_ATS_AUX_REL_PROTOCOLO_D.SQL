  create or replace procedure PRC_ATS_AUX_REL_PROTOCOLO_D 
  (
     pIDT IN TB_ATS_AUX_REL_PROTOCOLO.IDT%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_AUX_REL_PROTOCOLO_D
  * 
  *    Data Criacao: 	21/02/2009   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATS_AUX_REL_PROTOCOLO
    WHERE  
        (pIDT is null or IDT = pIDT);	   
  end PRC_ATS_AUX_REL_PROTOCOLO_D;
/
