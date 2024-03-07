create or replace procedure PRC_ASS_PLC_PLANO_CBOS_S
  (
     pCAD_PLA_ID_PLANO IN TB_ASS_PLC_PLANO_CBOS.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     pTIS_CBO_CD_CBOS IN TB_ASS_PLC_PLANO_CBOS.TIS_CBO_CD_CBOS%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PLC_PLANO_CBOS_S
  * 
  *    Data Criacao: 	16/08/2007   Por: Andrea Cazuca
  *    Data Alteracao:	data da altera???#o  Por: Nome do Analista
  *
  *    Funcao: Lista os Planos X Especialidade Associados
  *
  *    Data Alteração:	09/11/07	Por: Bruno Costa
  *	   Ateração:		Inclusão de um campo
  *
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CAD_PLA_ID_PLANO,
       TIS_CBO_CD_CBOS,
       ASS_PLC_FL_STATUS,
       SEG_USU_ID_USUARIO,
       ASS_PLC_DT_ULTIMA_ATUALIZACAO,
       ASS_PLC_FL_ENCAMINHA_OK, 
       ASS_PLC_FL_EXIGE_SENHA_OK
    FROM TB_ASS_PLC_PLANO_CBOS
    WHERE
        (pCAD_PLA_ID_PLANO is null OR CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO) AND 
        (pTIS_CBO_CD_CBOS is null OR TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS);          
    io_cursor := v_cursor;
  end PRC_ASS_PLC_PLANO_CBOS_S;