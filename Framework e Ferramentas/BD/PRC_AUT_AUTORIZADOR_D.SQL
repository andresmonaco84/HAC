

  --PRC_AUT_AUTORIZADOR_D
  create or replace procedure PRC_AUT_AUTORIZADOR_D 
  (
     pCD_AUTORIZADOR IN TB_AUT_AUTORIZADOR.CD_AUTORIZADOR%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_AUTORIZADOR_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_AUTORIZADOR
    WHERE  
        CD_AUTORIZADOR = pCD_AUTORIZADOR;	   
  end PRC_AUT_AUTORIZADOR_D;
