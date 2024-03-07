
  --PRC_CAD_CEC_CENTRO_CUSTO_U
  create or replace procedure PRC_CAD_CEC_CENTRO_CUSTO_U
  (
     pCAD_CEC_ID_CCUSTO IN TB_CAD_CEC_CENTRO_CUSTO.CAD_CEC_ID_CCUSTO%type,
     pCAD_CEC_CD_CCUSTO IN TB_CAD_CEC_CENTRO_CUSTO.CAD_CEC_CD_CCUSTO%type,
     pCAD_CEC_DS_CCUSTO IN TB_CAD_CEC_CENTRO_CUSTO.CAD_CEC_DS_CCUSTO%type,
     pCAD_CEC_FL_CCUSTO IN TB_CAD_CEC_CENTRO_CUSTO.CAD_CEC_FL_CCUSTO%type,
     pCAD_CEC_DT_ULTIMA_ATUALIZACAO IN TB_CAD_CEC_CENTRO_CUSTO.CAD_CEC_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_CEC_CENTRO_CUSTO.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CEC_CENTRO_CUSTO_U
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_CEC_CENTRO_CUSTO
    SET     
        CAD_CEC_CD_CCUSTO = pCAD_CEC_CD_CCUSTO,
        CAD_CEC_DS_CCUSTO = pCAD_CEC_DS_CCUSTO,
        CAD_CEC_FL_CCUSTO = pCAD_CEC_FL_CCUSTO,
        CAD_CEC_DT_ULTIMA_ATUALIZACAO = pCAD_CEC_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
    WHERE
        CAD_CEC_ID_CCUSTO = pCAD_CEC_ID_CCUSTO;  
  end PRC_CAD_CEC_CENTRO_CUSTO_U;

