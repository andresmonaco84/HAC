  create or replace procedure PRC_SEG_PEU_PERMISSAO_D 
  (
     pCAD_UNI_ID_UNIDADE IN TB_SEG_PEU_PERMISSAO_USUARIO.CAD_UNI_ID_UNIDADE%type,
     pSEG_MOD_ID_MODULO IN TB_SEG_MPF_MODULO_PERFIL.SEG_MOD_ID_MODULO%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_USU_ID_USUARIO%type default null,
     pSEG_PER_ID_PERFIL IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_PER_ID_PERFIL%type default null
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PEU_PERMISSAO_D
  *
  *    Data Criacao: 	23/02/2007   Por: Carlos Araujo
  *    Data Alteracao:	           Por: 
  *
  *    Funcao: Exclui as associacoes de perfis à Unidade, Módulo e Usuario
  *
  *******************************************************************/
  begin
  
    DELETE	
    FROM TB_SEG_PEU_PERMISSAO_USUARIO PEU
    WHERE
          (PEU.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
      AND (PEU.SEG_MOD_ID_MODULO  = pSEG_MOD_ID_MODULO)
      AND (pSEG_USU_ID_USUARIO    IS NULL OR PEU.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO)
      AND (pSEG_PER_ID_PERFIL     IS NULL OR PEU.SEG_PER_ID_PERFIL  = pSEG_PER_ID_PERFIL);
        
  end PRC_SEG_PEU_PERMISSAO_D;
/
