

  --PRC_SEG_PFU_PERFIL_FUNCIONALID_U
  create or replace procedure PRC_SEG_PERFIL_FUNCIONALID_U
  (
     pSEG_PER_ID_PERFIL IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_PER_ID_PERFIL%type,
     pSEG_MOD_ID_MODULO IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_MOD_ID_MODULO%type,
     pSEG_FUN_ID_FUNCIONALIDADE IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_FUN_ID_FUNCIONALIDADE%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PFU_PERFIL_FUNCIONALID_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_SEG_PFU_PERFIL_FUNCIONALID
    SET	   
 
    WHERE
        SEG_FUN_ID_FUNCIONALIDADE = pSEG_FUN_ID_FUNCIONALIDADE
    AND SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO
    AND SEG_PER_ID_PERFIL = pSEG_PER_ID_PERFIL;	
  end PRC_SEG_PERFIL_FUNCIONALID_U;

