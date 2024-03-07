

  --PRC_ASS_UTA_UNID_TPACOMOD_D
  create or replace procedure PRC_ASS_UTA_UNID_TPACOMOD_D 
  (
     pASS_UTA_ID_UNID_TPACOMOD IN TB_ASS_UTA_UNID_TPACOMOD.ASS_UTA_ID_UNID_TPACOMOD%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UTA_UNID_TPACOMOD_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_UTA_UNID_TPACOMOD
    WHERE  
        ASS_UTA_ID_UNID_TPACOMOD = pASS_UTA_ID_UNID_TPACOMOD;	   
  end PRC_ASS_UTA_UNID_TPACOMOD_D;
