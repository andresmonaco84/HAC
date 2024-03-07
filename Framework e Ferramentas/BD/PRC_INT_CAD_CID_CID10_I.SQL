create or replace procedure PRC_INT_CAD_CID_CID10_I
  (
     pCAD_CID_CD_CID10 IN TB_CAD_CID_CID10.CAD_CID_CD_CID10%type,
     pCAD_CID_DS_CID10 IN TB_CAD_CID_CID10.CAD_CID_DS_CID10%type default NULL,
     pCAD_CGR_CD_GRUPO IN TB_CAD_CID_CID10.CAD_CGR_CD_GRUPO%type,
     pCAD_CID_FL_ATIVO IN TB_CAD_CID_CID10.CAD_CID_FL_ATIVO%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_CAD_CID_CID10_I
  *
  *    Data Criacao:  data da  criação   Por: Nome do Analista
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/

  begin

    INSERT INTO TB_CAD_CID_CID10
    (
       CAD_CID_CD_CID10,
       CAD_CID_DS_CID10,
       CAD_CGR_CD_GRUPO,
       CAD_CID_FL_ATIVO
    )
    VALUES
    (
      pCAD_CID_CD_CID10,
      pCAD_CID_DS_CID10,
      pCAD_CGR_CD_GRUPO,
      pCAD_CID_FL_ATIVO
    );

  end PRC_INT_CAD_CID_CID10_I;
 