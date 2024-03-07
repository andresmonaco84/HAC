create or replace procedure PRC_SEG_MPF_MODULO_PERFIL_I
(
     pSEG_PER_ID_PERFIL IN TB_SEG_MPF_MODULO_PERFIL.SEG_PER_ID_PERFIL%type,
     pSEG_MOD_ID_MODULO IN TB_SEG_MPF_MODULO_PERFIL.SEG_MOD_ID_MODULO%type
  ) 
  is
	/********************************************************************
  *    Procedure: PRC_SEG_MPF_MODULO_PERFIL_I
  *
  *    Data Criacao: 	 27/02/2007   Por: Andrea Cazuca
  *    Data Alteracao: 05/03/2007   Por: Carlos
  *
  *    Funcao: Inclui a associacao entre Perfil e Módulo
  *
  *******************************************************************/  
  begin
	    
    INSERT INTO TB_SEG_MPF_MODULO_PERFIL
    (
       SEG_PER_ID_PERFIL,
       SEG_MOD_ID_MODULO
    )
    VALUES
    (
	     pSEG_PER_ID_PERFIL,
       pSEG_MOD_ID_MODULO
    );
  
end PRC_SEG_MPF_MODULO_PERFIL_I;
/
