create or replace procedure PRC_ATD_SPM_SORO_PRESC_MED_I
(
 pNewIdt OUT integer,
     --pATD_SPM_ID IN TB_ATD_SPM_SORO_PRESC_MED.ATD_SPM_ID%type,
     pATD_PME_ID IN TB_ATD_SPM_SORO_PRESC_MED.ATD_PME_ID%type default NULL,
     pATD_SPM_DS_DESCRICAO IN TB_ATD_SPM_SORO_PRESC_MED.ATD_SPM_DS_DESCRICAO%type default NULL,
     pATD_SPM_DS_VIA IN TB_ATD_SPM_SORO_PRESC_MED.ATD_SPM_DS_VIA%type default NULL,
     pATD_SPM_DS_INTERVALO IN TB_ATD_SPM_SORO_PRESC_MED.ATD_SPM_DS_INTERVALO%type default NULL,
     pATD_SPM_DS_OBSERVACAO IN TB_ATD_SPM_SORO_PRESC_MED.ATD_SPM_DS_OBSERVACAO%type,
     pATD_SPM_DT_HORA_CRIACAO IN TB_ATD_SPM_SORO_PRESC_MED.ATD_SPM_DT_HORA_CRIACAO%type default NULL,
     pATD_SPM_ID_USU_CRIACAO IN TB_ATD_SPM_SORO_PRESC_MED.ATD_SPM_ID_USU_CRIACAO%type default NULL,
     pATD_SPM_DT_ULT_ATUALIZ IN TB_ATD_SPM_SORO_PRESC_MED.ATD_SPM_DT_ULT_ATUALIZ%type default NULL,
     pATD_SPM_ID_USU_ULT_ATUALIZ IN TB_ATD_SPM_SORO_PRESC_MED.ATD_SPM_ID_USU_ULT_ATUALIZ%type default NULL,
          pATD_SPM_CD_VIA IN TB_ATD_SPM_SORO_PRESC_MED.ATD_SPM_CD_VIA%type default NULL
)
is
/********************************************************************
*    Procedure: PRC_ATD_SPM_SORO_PRESC_MED_I
*
*    Data Criacao:  data da  cria??o   Por: Nome do Analista
*    Data Alteracao:  data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/
lIdtRetorno integer;
begin
    SELECT SEQ_ATD_SPM_01.NextVal INTO lIdtRetorno FROM DUAL;


INSERT INTO TB_ATD_SPM_SORO_PRESC_MED
(
       ATD_SPM_ID,
       ATD_PME_ID,
       ATD_SPM_DS_DESCRICAO,
       ATD_SPM_DS_VIA,
       ATD_SPM_DS_INTERVALO,
       ATD_SPM_DS_OBSERVACAO,
       ATD_SPM_DT_HORA_CRIACAO,
       ATD_SPM_ID_USU_CRIACAO,
       ATD_SPM_DT_ULT_ATUALIZ,
       ATD_SPM_ID_USU_ULT_ATUALIZ,
       ATD_SPM_CD_VIA
)
VALUES
(
       lIdtRetorno,
       pATD_PME_ID,
       pATD_SPM_DS_DESCRICAO,
       pATD_SPM_DS_VIA,
       pATD_SPM_DS_INTERVALO,
       pATD_SPM_DS_OBSERVACAO,
       SYSDATE,
       pATD_SPM_ID_USU_CRIACAO,
       SYSDATE,
       pATD_SPM_ID_USU_ULT_ATUALIZ,
       pATD_SPM_CD_VIA
);
 pNewIdt := lIdtRetorno;
 
end PRC_ATD_SPM_SORO_PRESC_MED_I;
