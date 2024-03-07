create or replace procedure PRC_ASS_PTE_PESSOA_TELEFONE_I
  (
     pCAD_TEL_ID_TELEFONE IN TB_ASS_PTE_PESSOA_TELEFONE.CAD_TEL_ID_TELEFONE%type,    
     pCAD_PES_ID_PESSOA IN TB_ASS_PTE_PESSOA_TELEFONE.CAD_PES_ID_PESSOA%type    
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PTE_PESSOA_TELEFONE_I
  * 
  *    Data Criacao: 	30/05/2007   Por: Silmara
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Associacao do telefone com a pessoa
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
	
  end PRC_ASS_PTE_PESSOA_TELEFONE_I;
/
