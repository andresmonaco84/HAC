create or replace procedure PRC_CAD_SPL_SUB_PLANO_S
  (
     pCAD_SPL_ID            IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_ID%type DEFAULT NULL,
     pCAD_SPL_CD_SUB_PLANO  IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_CD_SUB_PLANO%type DEFAULT NULL,
     pCAD_SPL_DS_SUB_PLANO  IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_DS_SUB_PLANO%type DEFAULT NULL,
     pCAD_SPL_FL_STATUS     IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_FL_STATUS%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO   IN TB_CAD_SPL_SUB_PLANO.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_SPL_SUB_PLANO_S
  *
  *    Data Criacao: 	04/07/2008			Por: Fabiola Lopes
  *    Data Alteracao:	data da alteragco	Por: Nome do Analista
  *
  *    Funcao: Lista os Sub-Planos cadastrados
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

    SELECT CAD_SPL_ID SubPlano,
           CAD_SPL_CD_SUB_PLANO Codigo,
           CAD_SPL_DS_SUB_PLANO Descricao,
           CAD_SPL_FL_STATUS Status,
           CAD_CNV_ID_CONVENIO Convenio
    
      FROM TB_CAD_SPL_SUB_PLANO
    
     WHERE
           (pCAD_SPL_ID is null OR CAD_SPL_ID = pCAD_SPL_ID) 
     AND   (pCAD_SPL_CD_SUB_PLANO is null OR CAD_SPL_CD_SUB_PLANO = pCAD_SPL_CD_SUB_PLANO)
     AND   (pCAD_SPL_DS_SUB_PLANO is null OR CAD_SPL_DS_SUB_PLANO like pCAD_SPL_DS_SUB_PLANO)
     AND   (pCAD_SPL_FL_STATUS is null OR CAD_SPL_FL_STATUS = pCAD_SPL_FL_STATUS)
     AND   (pCAD_CNV_ID_CONVENIO is null OR CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO);
          
    io_cursor := v_cursor;
  end PRC_CAD_SPL_SUB_PLANO_S;
/
