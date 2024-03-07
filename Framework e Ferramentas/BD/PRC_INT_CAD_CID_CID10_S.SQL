create or replace procedure PRC_INT_CAD_CID_CID10_S
  (
     pCAD_CID_CD_CID10 IN TB_CAD_CID_CID10.CAD_CID_CD_CID10%type DEFAULT NULL,
     pCAD_CID_DS_CID10 IN TB_CAD_CID_CID10.CAD_CID_DS_CID10%type DEFAULT NULL,
     pCAD_CGR_CD_GRUPO IN TB_CAD_CID_CID10.CAD_CGR_CD_GRUPO%type DEFAULT NULL,
     pCAD_CID_FL_ATIVO IN TB_CAD_CID_CID10.CAD_CID_FL_ATIVO%type default NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_CAD_CID_CID10_S
  *
  *    Data Criacao:  data da  criação   Por: Nome do Analista
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CAD_CID_CD_CID10,
       CAD_CID_DS_CID10,
       CAD_CGR_CD_GRUPO,
       CAD_CID_FL_ATIVO
       
    FROM TB_CAD_CID_CID10
    WHERE
        (pCAD_CID_CD_CID10 is null OR CAD_CID_CD_CID10 = pCAD_CID_CD_CID10) AND
        (pCAD_CID_DS_CID10 is null OR CAD_CID_DS_CID10 = pCAD_CID_DS_CID10) AND
        (pCAD_CGR_CD_GRUPO is null OR CAD_CGR_CD_GRUPO = pCAD_CGR_CD_GRUPO) and
        (pCAD_CID_FL_ATIVO is null OR CAD_CID_FL_ATIVO = pCAD_CID_FL_ATIVO) 
        ;
    io_cursor := v_cursor;
  end PRC_INT_CAD_CID_CID10_S;
 