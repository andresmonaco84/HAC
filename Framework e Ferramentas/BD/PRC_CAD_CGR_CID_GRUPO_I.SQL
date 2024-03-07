CREATE OR REPLACE
procedure PRC_CAD_CGR_CID_GRUPO_I
  (
     pCAD_CGR_CD_GRUPO IN TB_CAD_CGR_CID_GRUPO.CAD_CGR_CD_GRUPO%type,
     pCAD_CGR_DS_GRUPO IN TB_CAD_CGR_CID_GRUPO.CAD_CGR_DS_GRUPO%type default NULL,
     pCAD_CCP_CD_CAPITULO IN TB_CAD_CGR_CID_GRUPO.CAD_CCP_CD_CAPITULO%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CGR_CID_GRUPO_I
  *
  *    Data Criacao: 	24/04/2007   Por: Ricardo Costa
  *    Data Alteracao:	25/05/2007  Por: Silmara
  *    Alteração: Foi alterado os parâmetros para gravar em maiúsculo  
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/

  begin

    INSERT INTO TB_CAD_CGR_CID_GRUPO
    (
       CAD_CGR_CD_GRUPO,
       CAD_CGR_DS_GRUPO,
       CAD_CCP_CD_CAPITULO
    )
    VALUES
    (
	     UPPER(pCAD_CGR_CD_GRUPO),
	     UPPER(pCAD_CGR_DS_GRUPO),
	     pCAD_CCP_CD_CAPITULO
    );

  end PRC_CAD_CGR_CID_GRUPO_I;
/
