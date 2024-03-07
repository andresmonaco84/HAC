CREATE OR REPLACE PROCEDURE "PRC_CAD_CID_CID10_S"
  (
     pCAD_CID_CD_CID10 IN TB_CAD_CID_CID10.CAD_CID_CD_CID10%type DEFAULT NULL,
     pCAD_CGR_CD_GRUPO IN TB_CAD_CID_CID10.CAD_CGR_CD_GRUPO%type DEFAULT NULL,
     pCAD_CID_DS_CID10 IN TB_CAD_CID_CID10.CAD_CID_DS_CID10%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: {nome da procedure}
  *
  *    Data Criacao: 	23/04/2007  Por: Ricardo Costa
  *    Data Alteracao:	data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Obtem registros CID10 por descricao ou por Grupo de CID
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    IF ( pCAD_CID_DS_CID10 IS NOT NULL ) THEN
       OPEN v_cursor FOR
       SELECT
          CAD_CID_CD_CID10,
          CAD_CID_DS_CID10,
          CAD_CGR_CD_GRUPO
       FROM TB_CAD_CID_CID10
       WHERE ( CAD_CID_DS_CID10 LIKE pCAD_CID_DS_CID10 );
    ELSIF ( pCAD_CGR_CD_GRUPO IS NOT NULL ) THEN
       OPEN v_cursor FOR
       SELECT
          CAD_CID_CD_CID10,
          CAD_CID_DS_CID10,
          CAD_CGR_CD_GRUPO
       FROM TB_CAD_CID_CID10
       WHERE ( CAD_CGR_CD_GRUPO = pCAD_CGR_CD_GRUPO );
    ELSE
       OPEN v_cursor FOR
       SELECT
          CAD_CID_CD_CID10,
          CAD_CID_DS_CID10,
          CAD_CGR_CD_GRUPO
       FROM TB_CAD_CID_CID10
       WHERE (pCAD_CID_CD_CID10 is null OR CAD_CID_CD_CID10 = pCAD_CID_CD_CID10);
    END IF;
    io_cursor := v_cursor;
  end PRC_CAD_CID_CID10_S;
 