  --PRC_TIS_CBO_CBOS_RMT_D
  create or replace procedure PRC_TIS_CBO_CBOS_RMT_D 
  (
     pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CBO_CBOS_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_TIS_CBO_CBOS
    WHERE  
        TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS;	   
  end PRC_TIS_CBO_CBOS_RMT_D;
