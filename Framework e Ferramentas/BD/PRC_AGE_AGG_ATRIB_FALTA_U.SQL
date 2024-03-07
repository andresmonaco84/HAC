CREATE OR REPLACE PROCEDURE PRC_AGE_AGG_ATRIB_FALTA_U
(
 pAGE_ESF_ID            IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_ID%TYPE,
 pAGE_ESM_ID            IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESM_ID%TYPE,
 pAGE_ESF_DT_INI_FALTA  IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_DT_INI_FALTA%TYPE,
 pAGE_ESF_DT_FIM_FALTA  IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_DT_FIM_FALTA%TYPE,
 pAGE_ESF_HR_INI_FALTA  IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_HR_INI_FALTA%TYPE DEFAULT NULL,
 pAGE_ESF_HR_FIM_FALTA  IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_HR_FIM_FALTA%TYPE DEFAULT NULL,
 pSEG_USU_ID_USUARIO    IN TB_AGE_ESF_ESCALA_FALTAS.SEG_USU_ID_USUARIO%TYPE
)
is
/********************************************************************
*    Procedure: PRC_AGE_AGG_ATRIB_FALTA_U
*
*    Data Criacao:   10/08/2007             Por: Fabiola
*
*    Data Alteracao: 20/03/2014             Por: Davi S. M. dos Reis
*         Alteracao: Considerar se a falta eh parcial (horaInicial <> NULL)
*                    ou integral (horaInicial <> NULL), para atualizar na AGG
*
*    Data Alteracao: 28/05/2014             Por: Davi S. M. dos Reis
*         Alteracao: Nao atualizar o status: o sistema fara isso via C#, para
*                    consistir a regra de falta com substituto
*
*    Funcao: Atualiza campo da TB_AGE_AGG_AGENDA_GERADA
*
*******************************************************************/
horaInicial integer;
horaFinal integer;

begin

  horaInicial := NULL;
  horaFinal   := NULL;

  SELECT AGE_ESF_HR_INI_FALTA, AGE_ESF_HR_FIM_FALTA
    INTO horaInicial, horaFinal
    FROM TB_AGE_ESF_ESCALA_FALTAS
   WHERE AGE_ESF_ID = pAGE_ESF_ID;

  UPDATE
        TB_AGE_AGG_AGENDA_GERADA
  SET   AGE_ESF_ID =  pAGE_ESF_ID,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
--        AGE_AGG_FL_STATUS_HORARIO = 1
  WHERE
        (
        (horaInicial IS NULL AND AGE_AGG_DT_AGENDA BETWEEN pAGE_ESF_DT_INI_FALTA and pAGE_ESF_DT_FIM_FALTA)
        OR
        (AGE_AGG_DT_AGENDA = pAGE_ESF_DT_INI_FALTA and
         AGE_AGG_HR_AGENDA BETWEEN horaInicial and horaFinal)
        )

   AND  AGE_ESM_ID = pAGE_ESM_ID;
end PRC_AGE_AGG_ATRIB_FALTA_U;
/
