 
  --PRC_TIS_MOM_MOTOBI_MULHER_S
  create or replace procedure PRC_TIS_MOM_MOTOBI_MULHER_S 
  (
     pTIS_MOM_CD_MOTIVOOBITO IN TB_TIS_MOM_MOTIVOOBITO_MULHER.TIS_MOM_CD_MOTIVOOBITO%type DEFAULT NULL,
     pTIS_MOM_DS_MOTIVOOBITO IN TB_TIS_MOM_MOTIVOOBITO_MULHER.TIS_MOM_DS_MOTIVOOBITO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_TIS_MOM_MOTOBI_MULHER_S
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       TIS_MOM_CD_MOTIVOOBITO,
       TIS_MOM_DS_MOTIVOOBITO
    FROM TB_TIS_MOM_MOTIVOOBITO_MULHER
    WHERE
        (pTIS_MOM_CD_MOTIVOOBITO is null OR TIS_MOM_CD_MOTIVOOBITO = pTIS_MOM_CD_MOTIVOOBITO) AND 
        (pTIS_MOM_DS_MOTIVOOBITO is null OR TIS_MOM_DS_MOTIVOOBITO = pTIS_MOM_DS_MOTIVOOBITO);          
    io_cursor := v_cursor;
  end PRC_TIS_MOM_MOTOBI_MULHER_S;
