  --PRC_CAD_IMP_IMPOSTO_U
  create or replace procedure PRC_CAD_IMP_IMPOSTO_U
  (
     pCAD_IMP_ID_IMPOSTO IN TB_CAD_IMP_IMPOSTO.CAD_IMP_ID_IMPOSTO%type,
     pCAD_IMP_NM_IMPOSTO IN TB_CAD_IMP_IMPOSTO.CAD_IMP_NM_IMPOSTO%type,
     pCAD_IMP_DS_IMPOSTO IN TB_CAD_IMP_IMPOSTO.CAD_IMP_DS_IMPOSTO%type,
     pCAD_IMP_FL_ATIVO_OK IN TB_CAD_IMP_IMPOSTO.CAD_IMP_FL_ATIVO_OK%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_IMP_IMPOSTO.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_IMP_IMPOSTO_U
  * 
  *    Data Criacao: 	24/05/2007         Por: Fabiola R. Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Altera os Dados do Cadastro de Imposto
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_IMP_IMPOSTO
    SET	   
        CAD_IMP_NM_IMPOSTO = UPPER(pCAD_IMP_NM_IMPOSTO),
        CAD_IMP_DS_IMPOSTO = UPPER(pCAD_IMP_DS_IMPOSTO),
        CAD_IMP_FL_ATIVO_OK = pCAD_IMP_FL_ATIVO_OK,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        CAD_IMP_DT_ULTIMA_ATUALIZACAO = SYSDATE 
    WHERE
        CAD_IMP_ID_IMPOSTO = pCAD_IMP_ID_IMPOSTO;	
  end PRC_CAD_IMP_IMPOSTO_U;
/
