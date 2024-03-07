create or replace procedure PRC_AGE_AGG_AGENDA_GERADA_SP_U
  is
  /********************************************************************
  *    Procedure: PRC_AGE_AGG_AGENDA_GERADA_SP_U
  *
  *    Data Criacao: 	29/10/2007             Por: Cristiane Gomes
  *    Funcao: Liberar horario reservado para SP para horario normal, 
  *            dois dias antes da data gerada (exceto horário de agenda
  *            com falta sem substituto)
  *
  *******************************************************************/
  cursor CURSOR_AGG is
         SELECT AGG.AGE_AGG_ID
         FROM TB_AGE_AGG_AGENDA_GERADA AGG
         WHERE AGG.AGE_AGG_TP_HORARIO = 5
         AND TRUNC(AGG.AGE_AGG_DT_AGENDA) = TRUNC(SYSDATE) + 2
         AND AGG.AGE_AGG_FL_STATUS_HORARIO = 1
         AND NOT EXISTS
	 (SELECT *
	 FROM TB_AGE_ESF_ESCALA_FALTAS ESF
	 WHERE AGG.AGE_ESF_ID = ESF.AGE_ESF_ID
         AND AGG.AGE_AGG_TP_HORARIO = 5
         AND TRUNC(AGG.AGE_AGG_DT_AGENDA) = TRUNC(SYSDATE) + 2
         AND AGG.AGE_AGG_FL_STATUS_HORARIO = 1
	 AND ESF.AGE_ESF_FL_SUBSTITUTO_OK = 'N');
  begin
       FOR I IN CURSOR_AGG LOOP           
           UPDATE TB_AGE_AGG_AGENDA_GERADA
           SET AGE_AGG_TP_HORARIO = 1
           WHERE AGE_AGG_ID = I.AGE_AGG_ID;
           COMMIT;
       END LOOP;    
end PRC_AGE_AGG_AGENDA_GERADA_SP_U;