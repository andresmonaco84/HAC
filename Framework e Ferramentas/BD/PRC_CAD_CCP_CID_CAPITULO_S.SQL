CREATE OR REPLACE
procedure PRC_CAD_CCP_CID_CAPITULO_S
  (
     pCAD_CCP_CD_CAPITULO IN TB_CAD_CCP_CID_CAPITULO.CAD_CCP_CD_CAPITULO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CCP_CID_CAPITULO_S
  *
  *    Data Criacao: 	 26/04/2007   Por: Ricardo Costa
  *    Data Alteracao: 03/05/2007   alteração  Por: Carlos Eduardo
  *    Alteração: Foi alterado o nome da procedure devido a alteração do nome da tabela
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CAD_CCP_CD_CAPITULO,
       CAD_CCP_DS_CAPITULO,
       CAD_CCP_INICIO,
       CAD_CCP_FIM
    FROM TB_CAD_CCP_CID_CAPITULO
    WHERE
        (pCAD_CCP_CD_CAPITULO is null OR CAD_CCP_CD_CAPITULO = pCAD_CCP_CD_CAPITULO);
    io_cursor := v_cursor;
  end PRC_CAD_CCP_CID_CAPITULO_S;
/
