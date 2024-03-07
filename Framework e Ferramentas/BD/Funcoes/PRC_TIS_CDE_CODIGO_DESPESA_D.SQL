

  --PRC_TIS_CDE_CODIGO_DESPESA_D
  create or replace procedure PRC_TIS_CDE_CODIGO_DESPESA_D 
  (
     pTIS_CDE_CD_CODIGO_DESPESA IN TB_TIS_CDE_CODIGO_DESPESA.TIS_CDE_CD_CODIGO_DESPESA%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CDE_CODIGO_DESPESA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_TIS_CDE_CODIGO_DESPESA
    WHERE  
        TIS_CDE_CD_CODIGO_DESPESA = pTIS_CDE_CD_CODIGO_DESPESA;	   
  end PRC_TIS_CDE_CODIGO_DESPESA_D;
