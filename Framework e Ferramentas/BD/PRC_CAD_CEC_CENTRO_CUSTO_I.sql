create or replace procedure PRC_CAD_CEC_CENTRO_CUSTO_I
  (
     pCAD_CEC_ID_CCUSTO IN TB_CAD_CEC_CENTRO_CUSTO.CAD_CEC_ID_CCUSTO%type default null,
     pCAD_CEC_CD_CCUSTO IN TB_CAD_CEC_CENTRO_CUSTO.CAD_CEC_CD_CCUSTO%type,
     pCAD_CEC_DS_CCUSTO IN TB_CAD_CEC_CENTRO_CUSTO.CAD_CEC_DS_CCUSTO%type,
     pCAD_CEC_FL_CCUSTO IN TB_CAD_CEC_CENTRO_CUSTO.CAD_CEC_FL_CCUSTO%type,
     pCAD_CEC_DT_ULTIMA_ATUALIZACAO IN TB_CAD_CEC_CENTRO_CUSTO.CAD_CEC_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_CAD_CEC_CENTRO_CUSTO.SEG_USU_ID_USUARIO%type,
     pNewIdt OUT integer
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CEC_CENTRO_CUSTO_I
  *
  *    Data Criacao:   02/12/2009   Por: PEDRO
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
    nrSEQ integer;
  begin

    SELECT SEQ_CAD_CEC_01.NEXTVAL INTO nrSEQ FROM DUAL;

    INSERT INTO TB_CAD_CEC_CENTRO_CUSTO
    (
       CAD_CEC_ID_CCUSTO,
       CAD_CEC_CD_CCUSTO,
       CAD_CEC_DS_CCUSTO,
       CAD_CEC_FL_CCUSTO,
       CAD_CEC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
       nrSEQ,
       pCAD_CEC_CD_CCUSTO,
       pCAD_CEC_DS_CCUSTO,
       pCAD_CEC_FL_CCUSTO,
       pCAD_CEC_DT_ULTIMA_ATUALIZACAO,
       pSEG_USU_ID_USUARIO
    );

  pNewIdt:= nrSEQ;

  end PRC_CAD_CEC_CENTRO_CUSTO_I;

