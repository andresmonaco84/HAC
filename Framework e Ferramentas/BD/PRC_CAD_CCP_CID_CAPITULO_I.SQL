CREATE OR REPLACE
procedure PRC_CAD_CCP_CID_CAPITULO_I
  (
     pCAD_CCP_CD_CAPITULO IN TB_CAD_CCP_CID_CAPITULO.CAD_CCP_CD_CAPITULO%type,
     pCAD_CCP_DS_CAPITULO IN TB_CAD_CCP_CID_CAPITULO.CAD_CCP_DS_CAPITULO%type default NULL,
     pCAD_CCP_INICIO IN TB_CAD_CCP_CID_CAPITULO.CAD_CCP_INICIO%type default NULL,
     pCAD_CCP_FIM IN TB_CAD_CCP_CID_CAPITULO.CAD_CCP_FIM%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CCP_CID_CAPITULO_I
  *
  *    Data Criacao: 	26/04/2007   Por: Ricardo Costa
  *    Data Alteracao: 03/05/2007   alteração  Por: Carlos Eduardo
  *    Alteração: Foi alterado o nome da procedure devido a alteração do nome da tabela
  *
  *    Data Alteracao: 25/05/2007   alteração  Por: Silmara 
  *    Alteração: Foi alterado os parâmetros para gravar em maiúsculo  
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/

  begin

    INSERT INTO TB_CAD_CCP_CID_CAPITULO
    (
       CAD_CCP_CD_CAPITULO,
       CAD_CCP_DS_CAPITULO,
       CAD_CCP_INICIO,
       CAD_CCP_FIM
    )
    VALUES
    (
	     pCAD_CCP_CD_CAPITULO,
	     UPPER(pCAD_CCP_DS_CAPITULO),
	     UPPER(pCAD_CCP_INICIO),
	     UPPER(pCAD_CCP_FIM)
    );

  end PRC_CAD_CCP_CID_CAPITULO_I;
/
