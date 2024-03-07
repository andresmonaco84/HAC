

  --PRC_TIS_MOM_MOTOBI_MULHER_U
  create or replace procedure PRC_TIS_MOM_MOTOBI_MULHER_U
  (
     pTIS_MOM_CD_MOTIVOOBITO IN TB_TIS_MOM_MOTIVOOBITO_MULHER.TIS_MOM_CD_MOTIVOOBITO%type,
     pTIS_MOM_DS_MOTIVOOBITO IN TB_TIS_MOM_MOTIVOOBITO_MULHER.TIS_MOM_DS_MOTIVOOBITO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_TIS_MOM_MOTOBI_MULHER_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_TIS_MOM_MOTIVOOBITO_MULHER
    SET	   
        TIS_MOM_DS_MOTIVOOBITO = pTIS_MOM_DS_MOTIVOOBITO 
    WHERE
        TIS_MOM_CD_MOTIVOOBITO = pTIS_MOM_CD_MOTIVOOBITO;	
  end PRC_TIS_MOM_MOTOBI_MULHER_U;

