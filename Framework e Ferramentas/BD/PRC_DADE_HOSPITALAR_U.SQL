

  --PRC_DADE_HOSPITALAR_U
  create or replace procedure PRC_DADE_HOSPITALAR_U
  (
     pCODUNIHOS IN UNIDADE_HOSPITALAR.CODUNIHOS%type,
     pDESUNIHOS IN UNIDADE_HOSPITALAR.DESUNIHOS%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_DADE_HOSPITALAR_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE UNIDADE_HOSPITALAR
    SET	   
        DESUNIHOS = pDESUNIHOS 
    WHERE
        CODUNIHOS = pCODUNIHOS;	
  end PRC_DADE_HOSPITALAR_U;

