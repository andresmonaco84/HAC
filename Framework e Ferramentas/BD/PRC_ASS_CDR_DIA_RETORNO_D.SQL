  --PRC_ASS_CDR_DIA_RETORNO_D
  create or replace procedure PRC_ASS_CDR_DIA_RETORNO_D 
  (
     pASS_CDR_ID_DIA_RETORNO IN TB_ASS_CDR_DIA_RETORNO.ASS_CDR_ID_DIA_RETORNO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CDR_DIA_RETORNO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_CDR_DIA_RETORNO
    WHERE  
        ASS_CDR_ID_DIA_RETORNO = pASS_CDR_ID_DIA_RETORNO;	   
  end PRC_ASS_CDR_DIA_RETORNO_D;
/
