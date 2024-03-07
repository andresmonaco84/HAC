 CREATE OR REPLACE PROCEDURE PRC_MTMD_MOV_POS_FATURA
(
--pACAO         IN NUMBER, --Valores possíveis 0: Inclusão / 1: Exclusão
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
  *    Data Criacao:   18/03/2010     Por: André Souza Monaco
  *    Data Alteração: 29/09/2010     Por: André Souza Monaco
  *         Alteração: Só vai ser para inclusão
  *    Data Alteração: 04/10/2010     Por: André Souza Monaco
  *         Alteração: Adição de parâmetros pMTMD_MOV_DATA_FATURAMENTO  
  *                    e pMTMD_MOV_HORA_FATURAMENTO
  *
  *    Funcao: Operações realizadas após a realização do processo de
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
    /*IF (pACAO = 0) THEN -- Inclusão ================================================================
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
    ELSIF (pACAO = 1) THEN  -- EXCLUSÃO =============================================================
      BEGIN
         -- MARCA MOVIMENTO COMO EXCLUIDO
         UPDATE TB_MTMD_MOV_INTERNADO  SET
         CAD_MTMD_FL_EXCLUIDO = 1
         WHERE  MTMD_MOV_ID = pMTMD_MOV_ID;
      EXCEPTION WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20100,SQLERRM);
      END; 
    ELSE
       RAISE_APPLICATION_ERROR(-20100,' NAO EXISTE NENHUMA AÇÃO ');
    END IF;*/
END PRC_MTMD_MOV_POS_FATURA;
