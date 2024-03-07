CREATE OR REPLACE
procedure PRC_CAD_CCP_CID_CAPITULO_U
  (
     pCAD_CCP_CD_CAPITULO IN TB_CAD_CCP_CID_CAPITULO.CAD_CCP_CD_CAPITULO%type,
     pCAD_CCP_DS_CAPITULO IN TB_CAD_CCP_CID_CAPITULO.CAD_CCP_DS_CAPITULO%type default NULL,
     pCAD_CCP_INICIO IN TB_CAD_CCP_CID_CAPITULO.CAD_CCP_INICIO%type default NULL,
     pCAD_CCP_FIM IN TB_CAD_CCP_CID_CAPITULO.CAD_CCP_FIM%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CID_CAPITULO_U
  *
  *    Data Criacao: 	26/04/2007   Por: Ricardo Costa
  *    Data Alteracao: 03/05/2007   alteração  Por: Carlos Eduardo
  *    Alteração: Foi alterado o nome da procedure devido a alteração do nome da tabela
  *
  *    Data Alteracao: 25/05/2007   alteração  Por: Silmara   
  *    Alteração: Foi alterado os parâmetros para gravar em maiúsculo   
  *    Funcao: Atualiza Dados na tabela Capitulos do CID
  *
  *******************************************************************/
  begin
    UPDATE TB_CAD_CCP_CID_CAPITULO
    SET
        CAD_CCP_DS_CAPITULO = UPPER(pCAD_CCP_DS_CAPITULO),
        CAD_CCP_INICIO = UPPER(pCAD_CCP_INICIO),
        CAD_CCP_FIM = UPPER(pCAD_CCP_FIM)
    WHERE
        CAD_CCP_CD_CAPITULO = pCAD_CCP_CD_CAPITULO;
  end PRC_CAD_CCP_CID_CAPITULO_U;
/
