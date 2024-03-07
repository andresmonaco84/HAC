 
  --PRC_TIS_TSS_TIPOSAIDA_SADT_S
  create or replace procedure PRC_TIS_TSS_TIPOSAIDA_SADT_S 
  (
     pTIS_TSS_CD_TIPOSAIDA IN TB_TIS_TSS_TIPOSAIDA_SADT.TIS_TSS_CD_TIPOSAIDA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: {nome da procedure}
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
       TIS_TSS_CD_TIPOSAIDA,
       TIS_TSS_DS_TIPOSAIDA
    FROM TB_TIS_TSS_TIPOSAIDA_SADT
    WHERE
        (pTIS_TSS_CD_TIPOSAIDA is null OR TIS_TSS_CD_TIPOSAIDA = pTIS_TSS_CD_TIPOSAIDA)
    order by TIS_TSS_CD_TIPOSAIDA;
    io_cursor := v_cursor;
  end PRC_TIS_TSS_TIPOSAIDA_SADT_S;
