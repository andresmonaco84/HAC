create or replace procedure PRC_ECIALIDADE_S
  (
     pCODESPMED IN NUMBER DEFAULT NULL,
     pDESESPMED IN ESPECIALIDADE.DESESPMED%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ECIALIDADE_S
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  vCBOHAC varchar2(3);

  begin
  
    SELECT CBO.TIS_CBO_CD_CBOS_HAC INTO vCBOHAC FROM TB_TIS_CBO_CBOS CBO WHERE CBO.TIS_CBO_CD_CBOS = pCODESPMED;
    
    OPEN v_cursor FOR
    SELECT	
       CODESPMED,
       DESESPMED
    FROM ESPECIALIDADE
    WHERE
        (CODESPMED = vCBOHAC) AND 
        (pDESESPMED is null OR DESESPMED = pDESESPMED);
    io_cursor := v_cursor;
  end PRC_ECIALIDADE_S;
