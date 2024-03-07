  create or replace procedure PRC_SEG_UUN_USUARIO_UNIDADE_I 
  (
     pSEG_USU_ID_USUARIO IN TB_SEG_UUN_USUARIO_UNIDADE.SEG_USU_ID_USUARIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_SEG_UUN_USUARIO_UNIDADE.CAD_UNI_ID_UNIDADE%type	
  ) 
  is
	/********************************************************************
  *    Procedure: PRC_SEG_UUN_USUARIO_UNIDADE_I
  *
  *    Data Criacao: 	22/02/2007   Por: Carlos Araujo
  *    Data Alteracao:	           Por: 
  *
  *    Funcao: Associa Usuário associado à Unidade
  *
  *******************************************************************/  
  begin
	    
    INSERT INTO TB_SEG_UUN_USUARIO_UNIDADE
    (
       SEG_USU_ID_USUARIO,
       CAD_UNI_ID_UNIDADE
    )
    VALUES
    (
	     pSEG_USU_ID_USUARIO,
	     pCAD_UNI_ID_UNIDADE
    );
	
  end PRC_SEG_UUN_USUARIO_UNIDADE_I;
/
