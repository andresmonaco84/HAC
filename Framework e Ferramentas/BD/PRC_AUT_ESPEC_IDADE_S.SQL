 
  --PRC_AUT_ESPEC_IDADE_S
  create or replace procedure PRC_AUT_ESPEC_IDADE_S 
  (
     pCODESPMED IN TB_AUT_ESPEC_IDADE.CODESPMED%type DEFAULT NULL,
     pIDADE IN TB_AUT_ESPEC_IDADE.IDADE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ESPEC_IDADE_S
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
       IDADE
    FROM TB_AUT_ESPEC_IDADE
    WHERE
        (pCODESPMED is null OR CODESPMED = pCODESPMED) AND 
        (pIDADE is null OR IDADE = pIDADE);          
    io_cursor := v_cursor;
  end PRC_AUT_ESPEC_IDADE_S;
