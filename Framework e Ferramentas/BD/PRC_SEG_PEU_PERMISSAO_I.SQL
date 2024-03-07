  create or replace procedure PRC_SEG_PEU_PERMISSAO_I 
  (
     pSEG_PER_ID_PERFIL IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_PER_ID_PERFIL%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_USU_ID_USUARIO%type,
     pSEG_MOD_ID_MODULO IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_MOD_ID_MODULO%type,
     pCAD_UNI_ID_UNIDADE IN TB_SEG_PEU_PERMISSAO_USUARIO.CAD_UNI_ID_UNIDADE%type     	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PEU_PERMISSAO_I
  *
  *    Data Criacao: 	23/02/2007   Por: Carlos Araujo
  *    Data Alteracao:	           Por: 
  *
  *    Funcao: Inclui a associação de Perfil à Unidade, Módulo e Usuario
  *
  *******************************************************************/
  begin
  
    INSERT INTO TB_SEG_PEU_PERMISSAO_USUARIO
    (
       SEG_PER_ID_PERFIL,
       SEG_USU_ID_USUARIO,
       SEG_MOD_ID_MODULO,
       CAD_UNI_ID_UNIDADE
    )
    VALUES
    (
	     pSEG_PER_ID_PERFIL,
	     pSEG_USU_ID_USUARIO,
       pSEG_MOD_ID_MODULO,
	     pCAD_UNI_ID_UNIDADE
    );
        
  end PRC_SEG_PEU_PERMISSAO_I;
/
