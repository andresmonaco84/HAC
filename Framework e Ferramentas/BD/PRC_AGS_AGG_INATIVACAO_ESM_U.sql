create or replace procedure PRC_AGS_AGG_INATIVACAO_ESM_U

  is
  /********************************************************************
  *    Procedure: PRC_AGS_AGG_INATIVACAO_ESM_U
  *
  *    Data Criacao:   25/01/2012   Por: PEDRO
  *
  *    Funcao: INATIVAR ESCALAS COM DATA FIM < SYSDATE
  *            INSERIR DATA FIM PARA ESCALAS INATIVAS E EXCLUIDAS
  *
  *
  *******************************************************************/

  cursor CURSOR_ESM_INATIVAS is
         SELECT ESM.AGS_ESM_ID
         FROM   TB_AGS_ESM_ESCALA_SADT ESM
         WHERE  ESM.AGS_ESM_DT_FIM_ESCALA IS NULL
         AND    ESM.AGS_ESM_FL_STATUS IN ('I','E');

  cursor CURSOR_ESM_ATIVAS is
         SELECT ESM.AGS_ESM_ID
         FROM   TB_AGS_ESM_ESCALA_SADT ESM
         WHERE  TRUNC(ESM.AGS_ESM_DT_FIM_ESCALA) < TRUNC(SYSDATE)
         AND    ESM.AGS_ESM_FL_STATUS IN ('A','E','S','P');

  begin
       FOR I IN CURSOR_ESM_INATIVAS LOOP
           UPDATE TB_AGS_ESM_ESCALA_SADT ESM
           SET    ESM.AGS_ESM_DT_FIM_ESCALA = SYSDATE
           WHERE  ESM.AGS_ESM_ID = I.AGS_ESM_ID;
           COMMIT;
       END LOOP;

       FOR I IN CURSOR_ESM_ATIVAS LOOP
           UPDATE TB_AGS_ESM_ESCALA_SADT ESM
           SET    ESM.AGS_ESM_FL_STATUS = 'I'
           WHERE  ESM.AGS_ESM_ID = I.AGS_ESM_ID;
           COMMIT;
       END LOOP;


  end PRC_AGS_AGG_INATIVACAO_ESM_U;
