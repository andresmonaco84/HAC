 CREATE OR REPLACE PROCEDURE SGS.PRC_MTMD_MOV_INTERNADO_D
  (
     pATD_ATE_ID IN TB_MTMD_MOV_INTERNADO.ATD_ATE_ID%type,
     pSEQ_PACIENTE IN TB_MTMD_MOV_INTERNADO.SEQ_PACIENTE%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_MTMD_MOV_INTERNADO_D
  *
  *    Data Criacao:  15/07/2009   Por: Andr� S. Monaco
  *     DATA ALTERA��O: 04/02/2010    POR: RICARDO COSTA
  *          ALTERA��O: CRIADO TESTE PARA CHECAR SE O UPDATE ALTEROU ALGUM REGISTRO
  *
  *    Funcao: Ao inv�s de deletar, o registro � flagado como excluido
  *            para manter hist�rico.
  *******************************************************************/
  nTeste NUMBER;
  begin
/*
    IF ( pATD_ATE_ID is null ) OR ( pSEQ_PACIENTE IS NULL  ) THEN
       RAISE_APPLICATION_ERROR(-20000,' SEQUENCIA VAZIA ');
    END IF;
*/
    UPDATE TB_MTMD_MOV_INTERNADO  SET
    CAD_MTMD_FL_EXCLUIDO = 1
    WHERE  ATD_ATE_ID = pATD_ATE_ID
    AND SEQ_PACIENTE  = pSEQ_PACIENTE;
  /*  IF SQL%NOTFOUND THEN
       RAISE_APPLICATION_ERROR(-20000,' N�O ENCONTROU TB_MTMD_MOV_INTERNADO PARA EXCLUIR ');
       -- NULL;
    END IF;*/
  end PRC_MTMD_MOV_INTERNADO_D;
