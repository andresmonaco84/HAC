  --PRC_ASS_PESSOA_END_RMT_I
  create or replace procedure PRC_ASS_PESSOA_END_RMT_I
  (
     pCAD_END_ID_ENDERECO IN TB_ASS_PEE_PESSOA_ENDERECO.CAD_END_ID_ENDERECO%type,
     pCAD_PES_ID_PESSOA IN TB_ASS_PEE_PESSOA_ENDERECO.CAD_PES_ID_PESSOA%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PESSOA_END_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_ASS_PEE_PESSOA_ENDERECO
    (
       CAD_END_ID_ENDERECO,
       CAD_PES_ID_PESSOA
    )
    VALUES
    (
	     pCAD_END_ID_ENDERECO,
	     pCAD_PES_ID_PESSOA
    );
	
  end PRC_ASS_PESSOA_END_RMT_I;

