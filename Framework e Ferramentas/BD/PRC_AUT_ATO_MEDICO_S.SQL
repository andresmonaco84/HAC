 
  --PRC_AUT_ATO_MEDICO_S
  create or replace procedure PRC_AUT_ATO_MEDICO_S 
  (
     pCODATOMED IN TB_AUT_ATO_MEDICO.CODATOMED%type DEFAULT NULL,
     pDESATOMED IN TB_AUT_ATO_MEDICO.DESATOMED%type DEFAULT NULL,
     pID_CPT IN TB_AUT_ATO_MEDICO.ID_CPT%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ATO_MEDICO_S
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
       CODATOMED,
       DESATOMED,
       ID_CPT
    FROM TB_AUT_ATO_MEDICO
    WHERE
        (pCODATOMED is null OR CODATOMED = pCODATOMED) AND 
        (pDESATOMED is null OR DESATOMED = pDESATOMED) AND 
        (pID_CPT is null OR ID_CPT = pID_CPT);          
    io_cursor := v_cursor;
  end PRC_AUT_ATO_MEDICO_S;
