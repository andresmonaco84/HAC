create or replace procedure PRC_ATD_DPM_DIETA_PRESC_MED_I
(
  pNewIdt OUT integer,

     pATD_PME_ID IN TB_ATD_DPM_DIETA_PRESC_MED.ATD_PME_ID%type default NULL,
     pATD_DPM_DS_DIETA IN TB_ATD_DPM_DIETA_PRESC_MED.ATD_DPM_DS_DIETA%type default NULL,
     pATD_DPM_DS_OBSERVACAO IN TB_ATD_DPM_DIETA_PRESC_MED.ATD_DPM_DS_OBSERVACAO%type,
     pATD_DPM_DT_HORA_CRIACAO IN TB_ATD_DPM_DIETA_PRESC_MED.ATD_DPM_DT_HORA_CRIACAO%type default NULL,
     pATD_DPM_ID_USU_CRIACAO IN TB_ATD_DPM_DIETA_PRESC_MED.ATD_DPM_ID_USU_CRIACAO%type default NULL,
     pATD_DPM_DT_ULT_ATUALIZ IN TB_ATD_DPM_DIETA_PRESC_MED.ATD_DPM_DT_ULT_ATUALIZ%type default NULL,
     pATD_DPM_ID_USU_ULT_ATUALIZ IN TB_ATD_DPM_DIETA_PRESC_MED.ATD_DPM_ID_USU_ULT_ATUALIZ%type default NULL,
          pATD_DPM_STATUS IN TB_ATD_DPM_DIETA_PRESC_MED.ATD_DPM_STATUS%type DEFAULT NULL,
               pATD_DPM_FL_IMPRESSO IN TB_ATD_DPM_DIETA_PRESC_MED.ATD_DPM_FL_IMPRESSO%type DEFAULT NULL,
                   pCAD_MTMD_ID IN TB_ATD_DPM_DIETA_PRESC_MED.CAD_MTMD_ID%type DEFAULT NULL
)
is
/********************************************************************
*    Procedure: PRC_ATD_DPM_DIETA_PRESC_MED_I
*
*    Data Criacao:  data da  cria??o   Por: Nome do Analista
*    Data Alteracao:  data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
 lIdtRetorno integer;
begin
    SELECT SEQ_ATD_DPM_01.NextVal INTO lIdtRetorno FROM DUAL;

INSERT INTO TB_ATD_DPM_DIETA_PRESC_MED
(
       ATD_DPM_ID,
       ATD_PME_ID,
       ATD_DPM_DS_DIETA,
       ATD_DPM_DS_OBSERVACAO,
       ATD_DPM_DT_HORA_CRIACAO,
       ATD_DPM_ID_USU_CRIACAO,
       ATD_DPM_DT_ULT_ATUALIZ,
       ATD_DPM_ID_USU_ULT_ATUALIZ,
       ATD_DPM_STATUS,
       ATD_DPM_FL_IMPRESSO,
       CAD_MTMD_ID
)
VALUES
(
       lIdtRetorno,
       pATD_PME_ID,
       pATD_DPM_DS_DIETA,
       pATD_DPM_DS_OBSERVACAO,
       SYSDATE,
       pATD_DPM_ID_USU_CRIACAO,
       pATD_DPM_DT_ULT_ATUALIZ,
       pATD_DPM_ID_USU_ULT_ATUALIZ,
       pATD_DPM_STATUS,
       pATD_DPM_FL_IMPRESSO,
       pCAD_MTMD_ID
);
   pNewIdt := lIdtRetorno;
end PRC_ATD_DPM_DIETA_PRESC_MED_I;
