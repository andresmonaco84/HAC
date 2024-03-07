  --PRC_TIS_MOM_MOTOBI_MULHER_SID
  create or replace procedure PRC_TIS_MOM_MOTOBI_MULHER_SID 
  (
     pTIS_MOM_CD_MOTIVOOBITO IN TB_TIS_MOM_MOTIVOOBITO_MULHER.TIS_MOM_CD_MOTIVOOBITO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_TIS_MOM_MOTOBI_MULHER_SID
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
        TIS_MOM_CD_MOTIVOOBITO = pTIS_MOM_CD_MOTIVOOBITO;          
    io_cursor := v_cursor;
  end PRC_TIS_MOM_MOTOBI_MULHER_SID;
