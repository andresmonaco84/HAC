create or replace procedure PRC_MTMD_MOV_HIST_PACIENTE_PE
(
     pATD_ATE_ID      IN  TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_ID%TYPE,
     retornoConsumo   OUT LONG
  )
  is
  /********************************************************************
  *  Procedure: PRC_MTMD_MOV_HIST_PACIENTE_PE
  *
  *  Data Criacao: 	09/09/2011   Por: ANDRE S. MONACO
  *
  *  Funcao: RETORNA OS PRODUTOS CONSUMIDOS PARA O PRONTUÁRIO ELETRÔNICO
  *******************************************************************/
  begin

    FOR MOV IN
              (
              SELECT
                 --PRODUTO.CAD_MTMD_CODMNE,
                 PRODUTO.CAD_MTMD_NOMEFANTASIA,
                 --PRODUTO.CAD_MTMD_UNID_VENDA_DS,
                 --SUM(MOVIMENTACAO.MTMD_MOV_QTDE) QTDE
                 (CASE
                     WHEN PRODUTO.CAD_MTMD_FL_FRACIONA = 1 AND MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (14, 26, 35) THEN
                        TO_CHAR( SUM(MOVIMENTACAO.MTMD_MOV_QTDE) )||'/'||TO_CHAR( PRODUTO.CAD_MTMD_UNIDADE_VENDA)
                     ELSE
                        TO_CHAR( SUM(MOVIMENTACAO.MTMD_MOV_QTDE))
                  END)  DS_QTDE_CONSUMO
                  
              FROM TB_MTMD_MOV_MOVIMENTACAO        MOVIMENTACAO,
                   TB_CAD_MTMD_MAT_MED             PRODUTO
              WHERE MOVIMENTACAO.ATD_ATE_ID        = pATD_ATE_ID
              AND   MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (11, 14, 18, 24, 25, 26, 35, 36)
              AND   MOVIMENTACAO.MTMD_MOV_FL_ESTORNO = 0
              AND   MOVIMENTACAO.CAD_MTMD_ID       = PRODUTO.CAD_MTMD_ID
              GROUP BY PRODUTO.CAD_MTMD_CODMNE,
                       PRODUTO.CAD_MTMD_NOMEFANTASIA,
                       PRODUTO.CAD_MTMD_UNID_VENDA_DS,
                       PRODUTO.CAD_MTMD_UNIDADE_VENDA,
                       PRODUTO.CAD_MTMD_FL_FRACIONA,
                       MOVIMENTACAO.CAD_MTMD_SUBTP_ID
              ORDER BY PRODUTO.CAD_MTMD_NOMEFANTASIA ASC
              )
    LOOP
        IF (retornoConsumo IS NOT NULL) THEN
           retornoConsumo := retornoConsumo || ', ';
        END IF;
        retornoConsumo := retornoConsumo || MOV.DS_QTDE_CONSUMO || ' ' || RTrim(MOV.CAD_MTMD_NOMEFANTASIA);
    END LOOP;
    
    IF (retornoConsumo IS NOT NULL) THEN
        retornoConsumo := retornoConsumo || '. Realizado conforme prescrição médica em ' || TO_CHAR(SYSDATE, 'dd/MM/yyyy hh24:Mi') || '.';
    END IF;

end PRC_MTMD_MOV_HIST_PACIENTE_PE;
