create or replace procedure PRC_SEG_MPF_MODULO_PERFIL_D
  (
     pSEG_MOD_ID_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_ID_MODULO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_MPF_MODULO_PERFIL_D
  *
  *    Data Criacao: 	 27/02/2007   Por: Andrea Cazuca
  *    Data Alteracao: 05/03/2007   Por: Carlos
  *
  *    Funcao: Exclui os perfis associados ao Módulo 
  *
  *******************************************************************/
  begin
  
    DELETE	
    FROM TB_SEG_MPF_MODULO_PERFIL MPF
    WHERE MPF.SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO;
        
end PRC_SEG_MPF_MODULO_PERFIL_D;
/
