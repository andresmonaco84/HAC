CREATE OR REPLACE PROCEDURE PRC_AGE_ATUALIZA_FALTA_U
    is
  /********************************************************************
  *    Procedure: PRC_AGE_ATUALIZA_FALTA_U
  *
  *    Data Criacao: 	24/10/2007   Por: Carlos Araujo
  *    Funcao: Atualiza as agendas geradas com id de escala de faltas caso
  *            exista falta.
  *
  *    Data Alteracao: 09/10/2013  Por: Davi S. M. dos Reis
  *    Alteracao: Nao retornar as faltas parcias para
  *               atualizar a agenda gerada.
  *
  *******************************************************************/
  begin
    FOR FALTA IN
      (SELECT ESM.AGE_ESM_ID, ESF.AGE_ESF_ID, ESF.AGE_ESF_DT_INI_FALTA, ESF.AGE_ESF_DT_FIM_FALTA
       FROM   TB_AGE_ESF_ESCALA_FALTAS ESF, TB_AGE_ESM_ESCALA_MEDICA ESM
       WHERE  ESF.AGE_ESF_DT_INI_FALTA >= SYSDATE
       AND    ESF.AGE_ESM_ID = ESM.AGE_ESM_ID
       AND    ESF.AGE_ESF_HR_INI_FALTA IS NULL       
       AND EXISTS (SELECT * FROM TB_AGE_AGG_AGENDA_GERADA AGG
                       WHERE AGG.AGE_ESF_ID IS NULL
                       AND   AGG.AGE_ESM_ID = ESF.AGE_ESM_ID
                       AND   AGG.AGE_AGG_DT_AGENDA >= ESF.AGE_ESF_DT_INI_FALTA
                       AND   AGG.AGE_AGG_DT_AGENDA <= ESF.AGE_ESF_DT_FIM_FALTA))
    LOOP
       BEGIN
            UPDATE TB_AGE_AGG_AGENDA_GERADA
            SET    AGE_ESF_ID = FALTA.AGE_ESF_ID
            WHERE  AGE_ESM_ID = FALTA.AGE_ESM_ID
            AND AGE_AGG_DT_AGENDA >= FALTA.AGE_ESF_DT_INI_FALTA
            AND AGE_AGG_DT_AGENDA <= FALTA.AGE_ESF_DT_FIM_FALTA;
       END;
    END LOOP;

  end PRC_AGE_ATUALIZA_FALTA_U;
 
/
