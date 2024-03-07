

  --PRC_SEG_SISTEMA_U
  create or replace procedure PRC_SEG_SISTEMA_U
  (
     pSEG_ID_SISTEMA IN TB_SEG_SISTEMA.SEG_ID_SISTEMA%type,
     pSEG_NM_SISTEMA IN TB_SEG_SISTEMA.SEG_NM_SISTEMA%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_SISTEMA_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_SEG_SISTEMA
    SET	   
        SEG_NM_SISTEMA = pSEG_NM_SISTEMA 
    WHERE
        SEG_ID_SISTEMA = pSEG_ID_SISTEMA;	
  end PRC_SEG_SISTEMA_U;

