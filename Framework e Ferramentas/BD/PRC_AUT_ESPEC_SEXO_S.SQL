 
  --PRC_AUT_ESPEC_SEXO_S
  create or replace procedure PRC_AUT_ESPEC_SEXO_S 
  (
     pCODESPMED IN TB_AUT_ESPEC_SEXO.CODESPMED%type DEFAULT NULL,
     pSEXBEN IN TB_AUT_ESPEC_SEXO.SEXBEN%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ESPEC_SEXO_S
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
       CODESPMED,
       SEXBEN
    FROM TB_AUT_ESPEC_SEXO
    WHERE
        (pCODESPMED is null OR CODESPMED = pCODESPMED) AND 
        (pSEXBEN is null OR SEXBEN = pSEXBEN);          
    io_cursor := v_cursor;
  end PRC_AUT_ESPEC_SEXO_S;
