create or replace procedure PRC_AGE_SAU_SALA_UNID_AND_D
  (
     pAGE_SAU_ID IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_SAU_SALA_UNID_AND_D
  * 
  *    Data Criacao: 	05/07/2007            Por: Guilherme Holdack
  *      Data Alteracao:                        Por: 
  *
  *    Funcao: Deleção de registros da tabela TB_AGE_SAU_SALA_UNID_AND
  *
  *******************************************************************/    
  begin
    DELETE TB_AGE_SAU_SALA_UNID_AND
    WHERE  
        AGE_SAU_ID = pAGE_SAU_ID;	   
  end PRC_AGE_SAU_SALA_UNID_AND_D;
/
