CREATE OR REPLACE
procedure PRC_CAD_CGR_CID_GRUPO_S
  (
     pCAD_CGR_CD_GRUPO IN TB_CAD_CGR_CID_GRUPO.CAD_CGR_CD_GRUPO%type DEFAULT NULL,
     pCAD_CGR_DS_GRUPO IN TB_CAD_CGR_CID_GRUPO.CAD_CGR_DS_GRUPO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CGR_CID_GRUPO_S
  *
  *    Data Criacao: 	24/04/2007  Por: Ricardo costa
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    IF ( pCAD_CGR_DS_GRUPO IS NOT NULL ) THEN
       OPEN v_cursor FOR
       SELECT
          CAD_CGR_CD_GRUPO,
          CAD_CGR_DS_GRUPO,
          CAD_CCP_CD_CAPITULO
       FROM TB_CAD_CGR_CID_GRUPO
       WHERE
           (CAD_CGR_DS_GRUPO LIKE pCAD_CGR_DS_GRUPO );
    ELSE
       OPEN v_cursor FOR
       SELECT
          CAD_CGR_CD_GRUPO,
          CAD_CGR_DS_GRUPO,
          CAD_CCP_CD_CAPITULO
       FROM TB_CAD_CGR_CID_GRUPO
       WHERE
           (pCAD_CGR_CD_GRUPO is null OR CAD_CGR_CD_GRUPO = pCAD_CGR_CD_GRUPO);
    END IF;
    io_cursor := v_cursor;
  end PRC_CAD_CGR_CID_GRUPO_S;
/
