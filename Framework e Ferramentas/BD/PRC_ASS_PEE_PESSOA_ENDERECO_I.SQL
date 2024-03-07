  create or replace procedure PRC_ASS_PEE_PESSOA_ENDERECO_I
  (
     pCAD_END_ID_ENDERECO IN TB_CAD_END_ENDERECO.CAD_END_ID_ENDERECO%type,
     pCAD_PES_ID_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_ID_PESSOA%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PEE_PESSOA_ENDERECO_I
  * 
  *    Data Criacao: 	28/05/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao:	29/05/2007   Por: Cristiane Gomes da Silva
  *
  *    Funcao: Associa Pessoa a Endereço
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
  end PRC_ASS_PEE_PESSOA_ENDERECO_I;
/
