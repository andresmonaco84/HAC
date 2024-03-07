  --PRC_ASS_CNV_UNIDADE_RMT_D
  create or replace procedure PRC_ASS_CNV_UNIDADE_RMT_D 
  (
     pASS_CNU_ID IN TB_ASS_CNU_CONVENIO_UNIDADE.ASS_CNU_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_UNIDADE_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_CNU_CONVENIO_UNIDADE
    WHERE  
        ASS_CNU_ID = pASS_CNU_ID;	   
  end PRC_ASS_CNV_UNIDADE_RMT_D;
