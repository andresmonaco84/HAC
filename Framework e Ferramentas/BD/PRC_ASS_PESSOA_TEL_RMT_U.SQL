  --PRC_ASS_PESSOA_TEL_RMT_U
  create or replace procedure PRC_ASS_PESSOA_TEL_RMT_U
  (
     pCAD_TEL_ID_TELEFONE IN TB_ASS_PTE_PESSOA_TELEFONE.CAD_TEL_ID_TELEFONE%type,
     pCAD_PES_ID_PESSOA IN TB_ASS_PTE_PESSOA_TELEFONE.CAD_PES_ID_PESSOA%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PESSOA_TEL_RMT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_ASS_PTE_PESSOA_TELEFONE
    SET	   
 
    WHERE
        CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA
    AND CAD_TEL_ID_TELEFONE = pCAD_TEL_ID_TELEFONE;	
  end PRC_ASS_PESSOA_TEL_RMT_U;

