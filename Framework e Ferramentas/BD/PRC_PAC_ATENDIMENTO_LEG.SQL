CREATE OR REPLACE PROCEDURE PRC_PAC_ATENDIMENTO_LEG (
pCODATEAMB IN PACIENTE_ATENDIMENTO_AMB.CODATEAMB%TYPE,
io_cursor OUT PKG_CURSOR.t_cursor
)
IS
  /********************************************************************
  *    Procedure: PRC_PAC_ATENDIMENTO_LEG
  *
  *    Data Criacao:  08/10/2007       Por: Bruno Alvares
  *    Data Alteracao:                  Por:
  *
  *    Funcao: Obtem o atendimento ativo
  *
  *******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
BEGIN
OPEN v_cursor FOR

 SELECT 1 FROM PACIENTE_ATENDIMENTO_AMB
 WHERE CODATEAMB = pCODATEAMB AND CODSITATE = 'A';

io_cursor := v_cursor;
     
END PRC_PAC_ATENDIMENTO_LEG;
