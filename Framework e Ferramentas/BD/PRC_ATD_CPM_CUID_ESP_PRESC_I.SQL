create or replace procedure PRC_ATD_CPM_CUID_ESP_PRESC_I
(
 pNewIdt OUT integer,
     --pATD_CPM_ID IN TB_ATD_CPM_CUID_ESP_PRESC_MED.ATD_CPM_ID%type,
     pATD_PME_ID IN TB_ATD_CPM_CUID_ESP_PRESC_MED.ATD_PME_ID%type default NULL,
     pATD_CPM_DS_CUIDADO_ESPEC IN TB_ATD_CPM_CUID_ESP_PRESC_MED.ATD_CPM_DS_CUIDADO_ESPEC%type default NULL,
     pATD_CPM_DS_OBSERVACAO IN TB_ATD_CPM_CUID_ESP_PRESC_MED.ATD_CPM_DS_OBSERVACAO%type,
     pATD_CPM_DT_HORA_CRIACAO IN TB_ATD_CPM_CUID_ESP_PRESC_MED.ATD_CPM_DT_HORA_CRIACAO%type default NULL,
     pATD_CPM_ID_USU_CRIACAO IN TB_ATD_CPM_CUID_ESP_PRESC_MED.ATD_CPM_ID_USU_CRIACAO%type default NULL,
     pATD_CPM_DT_ULT_ATUALIZ IN TB_ATD_CPM_CUID_ESP_PRESC_MED.ATD_CPM_DT_ULT_ATUALIZ%type default NULL,
     pATD_CPM_ID_USU_ULT_ATUALIZ IN TB_ATD_CPM_CUID_ESP_PRESC_MED.ATD_CPM_ID_USU_ULT_ATUALIZ%type default NULL,
          pATD_CPM_STATUS IN TB_ATD_CPM_CUID_ESP_PRESC_MED.ATD_CPM_STATUS%type DEFAULT NULL,
               pATD_CPM_FL_IMPRESSO IN TB_ATD_CPM_CUID_ESP_PRESC_MED.ATD_CPM_FL_IMPRESSO%type DEFAULT NULL,
               pATD_CPM_TP_CUIDADO IN TB_ATD_CPM_CUID_ESP_PRESC_MED.ATD_CPM_TP_CUIDADO%type DEFAULT NULL
)
is
/********************************************************************
*    Procedure: PRC_ATD_CPM_CUID_ESP_PRESC_MED_I
*
*    Data Criacao:  data da  cria??o   Por: Nome do Analista
*    Data Alteracao:  data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Stored Procedure
*
*******************************************************************/

lIdtRetorno integer;
begin
    SELECT SEQ_ATD_CPM_01.NextVal INTO lIdtRetorno FROM DUAL;


INSERT INTO TB_ATD_CPM_CUID_ESP_PRESC_MED
(
       ATD_CPM_ID,
       ATD_PME_ID,
       ATD_CPM_DS_CUIDADO_ESPEC,
       ATD_CPM_DS_OBSERVACAO,
       ATD_CPM_DT_HORA_CRIACAO,
       ATD_CPM_ID_USU_CRIACAO,
       ATD_CPM_DT_ULT_ATUALIZ,
       ATD_CPM_ID_USU_ULT_ATUALIZ,
       ATD_CPM_STATUS,
       ATD_CPM_FL_IMPRESSO,
   ATD_CPM_TP_CUIDADO
)
VALUES
(
       lIdtRetorno,
       pATD_PME_ID,
       pATD_CPM_DS_CUIDADO_ESPEC,
       pATD_CPM_DS_OBSERVACAO,
       SYSDATE,
       pATD_CPM_ID_USU_CRIACAO,
       pATD_CPM_DT_ULT_ATUALIZ,
       pATD_CPM_ID_USU_ULT_ATUALIZ,
       pATD_CPM_STATUS,
       pATD_CPM_FL_IMPRESSO,
pATD_CPM_TP_CUIDADO
);
 pNewIdt := lIdtRetorno;
end PRC_ATD_CPM_CUID_ESP_PRESC_I;
