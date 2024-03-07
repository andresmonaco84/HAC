  --PRC_ASS_PESSOA_TEL_RMT_I
  create or replace procedure PRC_ASS_PESSOA_TEL_RMT_I
  (
     pCAD_TEL_ID_TELEFONE IN TB_ASS_PTE_PESSOA_TELEFONE.CAD_TEL_ID_TELEFONE%type,
     pCAD_PES_ID_PESSOA IN TB_ASS_PTE_PESSOA_TELEFONE.CAD_PES_ID_PESSOA%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PESSOA_TEL_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_ASS_PTE_PESSOA_TELEFONE
    (
       CAD_TEL_ID_TELEFONE,
       CAD_PES_ID_PESSOA
    )
    VALUES
    (
	     pCAD_TEL_ID_TELEFONE,
	     pCAD_PES_ID_PESSOA
    );
	
  end PRC_ASS_PESSOA_TEL_RMT_I;

