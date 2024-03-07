create or replace procedure PRC_AGE_AGD_AGENDA_STATUS_CANC
  (
     pAGE_AGD_ID         IN TB_AGE_AGD_AGENDA.AGE_AGD_ID%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_AGE_AGD_AGENDA.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pAGE_AGD_CD_INTAMB  IN TB_AGE_AGD_AGENDA.AGE_AGD_CD_INTAMB%TYPE DEFAULT NULL,
     pAGE_AGD_FL_STATUS  IN TB_AGE_AGD_AGENDA.AGE_AGD_FL_STATUS%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_AGD_AGENDA_STATUS_CANC
  *
  *    Data Criacao: 	01/08/2007   Por: Fabiola Lopes
  *    Data Alteracao:	16/10/2007  Por: Cristiane Gomes da Silva
  *
  *    Funcao: Atualiza o status de cancelado do agendamento
  *
  *    Alteracao: 1) Exclusão do atendimento (legado), ao inves de
  *               alterar a situacao deste
  *
  *    Data Alteracao:  23/01/2008  Por: Andrea Cazuca
  *    Alteracao:  Incluido o campo AGE_AGD_CD_INTAMB E AGE_AGD_FL_STATUS
  *******************************************************************/
 pINTAMB TB_AGE_AGD_AGENDA.AGE_AGD_CD_INTAMB%TYPE;
  begin   
   
    IF pAGE_AGD_ID IS NOT NULL THEN
        UPDATE TB_AGE_AGD_AGENDA
        SET
            AGE_AGD_FL_STATUS = pAGE_AGD_FL_STATUS,
            AGE_AGD_DT_ULTIMA_ATUALIZACAO  = SYSDATE,
            SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
        WHERE
            AGE_AGD_ID = pAGE_AGD_ID;               
       
       SELECT AGE_AGD_CD_INTAMB INTO pINTAMB FROM TB_AGE_AGD_AGENDA   
       WHERE  AGE_AGD_ID = pAGE_AGD_ID;
            
       DELETE FROM HOSPITAL.PACIENTE_ATENDIMENTO_AMB
       WHERE CODATEAMB = pINTAMB;
   END IF;
   
   IF pAGE_AGD_CD_INTAMB IS NOT NULL THEN
        UPDATE TB_AGE_AGD_AGENDA
        SET
            AGE_AGD_FL_STATUS = pAGE_AGD_FL_STATUS,
            AGE_AGD_DT_ULTIMA_ATUALIZACAO  = SYSDATE,
            SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
        WHERE
            AGE_AGD_CD_INTAMB = pAGE_AGD_CD_INTAMB;
   END IF;
                  
  end PRC_AGE_AGD_AGENDA_STATUS_CANC;
/
