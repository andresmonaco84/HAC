

  --PRC_TIS_MOM_MOTOBI_MULHER_D
  create or replace procedure PRC_TIS_MOM_MOTOBI_MULHER_D 
  (
     pTIS_MOM_CD_MOTIVOOBITO IN TB_TIS_MOM_MOTIVOOBITO_MULHER.TIS_MOM_CD_MOTIVOOBITO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_MOM_MOTOBI_MULHER_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_TIS_MOM_MOTIVOOBITO_MULHER
    WHERE  
        TIS_MOM_CD_MOTIVOOBITO = pTIS_MOM_CD_MOTIVOOBITO;	   
  end PRC_TIS_MOM_MOTOBI_MULHER_D;
