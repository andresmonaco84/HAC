  --PRC_ASS_CPA_CONVENIO_PACOTE_D
  create or replace procedure PRC_ASS_CPA_CONVENIO_PACOTE_D 
  (
     pASS_CPA_ID IN TB_ASS_CPA_CONVENIO_PACOTE.ASS_CPA_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CPA_CONVENIO_PACOTE_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_CPA_CONVENIO_PACOTE
    WHERE  
        ASS_CPA_ID = pASS_CPA_ID;	   
  end PRC_ASS_CPA_CONVENIO_PACOTE_D;
