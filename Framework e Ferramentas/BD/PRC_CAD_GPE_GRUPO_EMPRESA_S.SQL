  create or replace procedure PRC_CAD_GPE_GRUPO_EMPRESA_S 
  (
     pCAD_GPE_ID_GRUPO_EMPRESA IN TB_CAD_GPE_GRUPO_EMPRESA.CAD_GPE_ID_GRUPO_EMPRESA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_GPE_GRUPO_EMPRESA_S 
  * 
  *    Data Criacao: 	20/06/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 21/06/2007   Por: Cristiane Gomes da Silva
  *
  *    Alteração: 1) Retirada da coluna CAD_GPE_FL_COPART_OK
  *
  *    Funcao: Obtém Grupo(s) de Empresa(s)
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CAD_GPE_ID_GRUPO_EMPRESA,
       CAD_GPE_DS_GRUPO_EMPRESA,
       CAD_GPE_CD_GRUPO
    FROM TB_CAD_GPE_GRUPO_EMPRESA
    WHERE
        (pCAD_GPE_ID_GRUPO_EMPRESA is null OR CAD_GPE_ID_GRUPO_EMPRESA = pCAD_GPE_ID_GRUPO_EMPRESA)
    ORDER BY CAD_GPE_DS_GRUPO_EMPRESA;          
    io_cursor := v_cursor;
  end PRC_CAD_GPE_GRUPO_EMPRESA_S;
/
