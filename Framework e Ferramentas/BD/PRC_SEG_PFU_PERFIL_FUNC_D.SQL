  create or replace procedure PRC_SEG_PFU_PERFIL_FUNC_D 
  (
     pSEG_MOD_ID_MODULO IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_MOD_ID_MODULO%type,
     pSEG_PER_ID_PERFIL IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_PER_ID_PERFIL%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PFU_PERFIL_FUNC_D
  * 
  *    Data Criacao: 	27/02/2007             Por: Carlos Eduardo
  *    Data Alteracao:	                     Por: 
  *
  *    Funcao: Exclui Funcionalidades associadas a Módulo e Perfil
  *
  *******************************************************************/    
  begin
    DELETE TB_SEG_PFU_PERFIL_FUNCIONALID
    WHERE  
        SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO
    AND SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL;	   
  end PRC_SEG_PFU_PERFIL_FUNC_D;
/
