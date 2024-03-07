 CREATE OR REPLACE PROCEDURE PRC_MTMD_MOV_POS_FATURA
(
--pACAO         IN NUMBER, --Valores poss�veis 0: Inclus�o / 1: Exclus�o
--pCAD_MTMD_ID  IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_ID%type  DEFAULT NULL,
--pATD_ATE_ID   IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_ID%type DEFAULT NULL,
  pMTMD_MOV_ID               IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_ID%type,
  pSEQ_PACIENTE              IN TB_MTMD_MOV_MOVIMENTACAO.SEQ_PACIENTE%type,
  pMTMD_MOV_DATA_FATURAMENTO IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA_FATURAMENTO%type DEFAULT NULL,     
  pMTMD_MOV_HORA_FATURAMENTO IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_HORA_FATURAMENTO%type DEFAULT NULL
) IS
  /********************************************************************
  *    Procedure: PRC_MTMD_MOV_POS_FATURA
  *
  *    Data Criacao:   18/03/2010     Por: Andr� Souza Monaco
  *    Data Altera��o: 29/09/2010     Por: Andr� Souza Monaco
  *         Altera��o: S� vai ser para inclus�o
  *    Data Altera��o: 04/10/2010     Por: Andr� Souza Monaco
  *         Altera��o: Adi��o de par�metros pMTMD_MOV_DATA_FATURAMENTO  
  *                    e pMTMD_MOV_HORA_FATURAMENTO
  *
  *    Funcao: Opera��es realizadas ap�s a realiza��o do processo de
  *            faturamento do SGS
  *
  *******************************************************************/
BEGIN
    UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
    MTMD_MOV_DATA_FATURAMENTO = NVL(pMTMD_MOV_DATA_FATURAMENTO, SYSDATE),
    MTMD_MOV_HORA_FATURAMENTO = NVL(pMTMD_MOV_HORA_FATURAMENTO, TO_CHAR(SYSDATE, 'HH24MI')),
    MTMD_MOV_FL_FATURADO      = 1,
    SEQ_PACIENTE              = pSEQ_PACIENTE
    WHERE MTMD_MOV_ID         = pMTMD_MOV_ID;
    /*IF (pACAO = 0) THEN -- Inclus�o ================================================================
      UPDATE TB_MTMD_MOV_MOVIMENTACAO SET
      MTMD_MOV_DATA_FATURAMENTO = SYSDATE,
      MTMD_MOV_HORA_FATURAMENTO = TO_CHAR(SYSDATE, 'HH24MI'),
      MTMD_MOV_FL_FATURADO      = 1
      WHERE MTMD_MOV_ID = pMTMD_MOV_ID;
      BEGIN
         INSERT INTO TB_MTMD_MOV_INTERNADO
        (ATD_ATE_ID,  SEQ_PACIENTE,   MTMD_MOV_ID,  CAD_MTMD_ID, CAD_MTMD_FL_EXCLUIDO  )
        VALUES
        (pATD_ATE_ID, pSEQ_PACIENTE,  pMTMD_MOV_ID, pCAD_MTMD_ID, 0);
      EXCEPTION WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20000,' ERRO TENTANDO INSERIR MOV INTERNADO '||SQLERRM);
      END;
    ELSIF (pACAO = 1) THEN  -- EXCLUS�O =============================================================
      BEGIN
         -- MARCA MOVIMENTO COMO EXCLUIDO
         UPDATE TB_MTMD_MOV_INTERNADO  SET
         CAD_MTMD_FL_EXCLUIDO = 1
         WHERE  MTMD_MOV_ID = pMTMD_MOV_ID;
      EXCEPTION WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20100,SQLERRM);
      END; 
    ELSE
       RAISE_APPLICATION_ERROR(-20100,' NAO EXISTE NENHUMA A��O ');
    END IF;*/
END PRC_MTMD_MOV_POS_FATURA;
