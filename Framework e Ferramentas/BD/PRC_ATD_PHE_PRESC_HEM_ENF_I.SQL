

--PRC_ATD_PHE_PRESC_HEM_ENF_I
create or replace procedure PRC_ATD_PHE_PRESC_HEM_ENF_I
(
     pATD_PME_ID IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PME_ID%type,
     pATD_PHE_HORA IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_HORA%type default NULL,
     pATD_PHE_VL_PASIS IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_VL_PASIS%type default NULL,
     pATD_PHE_VL_PULSO IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_VL_PULSO%type default NULL,
     pATD_PHE_VL_DOR IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_VL_DOR%type default NULL,
     pATD_PHE_VL_GLICCAP IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_VL_GLICCAP%type default NULL,
     pATD_PHE_VL_PADIS IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_VL_PADIS%type default NULL,
     pATD_PHE_ID_USU_CRIACAO IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_ID_USU_CRIACAO%type default NULL,
     pATD_PHE_DT_CRIACAO IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_DT_CRIACAO%type default NULL,
     pATD_PHE_ID_USU_ATUALIZ IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_ID_USU_ATUALIZ%type default NULL,
     pATD_PHE_DT_ULT_ATUALIZ IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_DT_ULT_ATUALIZ%type default NULL,
     
     pATD_PHE_VL_TEMPINI IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_VL_TEMPINI%type default NULL,
     pATD_PHE_VL_TEMPFIM IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_VL_TEMPFIM%type default NULL ,
     pATD_PHE_VL_PESO IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_VL_PESO%type DEFAULT NULL,
      pNewIdt OUT integer
    -- pATD_PHE_ID IN TB_ATD_PHE_PRESC_HEM_ENF.ATD_PHE_ID%type
) 
is
/********************************************************************
*    Procedure: PRC_ATD_PHE_PRESC_HEM_ENF_I
* 
*    Data Criacao:  data da  criação   Por: Nome do Analista
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
 lIdtRetorno integer;
begin
    SELECT SEQ_ATD_PhE_01.NextVal INTO lIdtRetorno FROM DUAL;
      
INSERT INTO TB_ATD_PHE_PRESC_HEM_ENF
(
       ATD_PME_ID,
       ATD_PHE_HORA,
       ATD_PHE_VL_PASIS,
       ATD_PHE_VL_PULSO,
       ATD_PHE_VL_DOR,
       ATD_PHE_VL_GLICCAP,
       ATD_PHE_VL_PADIS,
       ATD_PHE_ID_USU_CRIACAO,
       ATD_PHE_DT_CRIACAO,
       ATD_PHE_ID_USU_ATUALIZ,
       ATD_PHE_DT_ULT_ATUALIZ,
      
       ATD_PHE_VL_TEMPINI,
       ATD_PHE_VL_TEMPFIM,
        ATD_PHE_ID,
        ATD_PHE_VL_PESO
)
VALUES
(
       pATD_PME_ID,
       pATD_PHE_HORA,
       pATD_PHE_VL_PASIS,
       pATD_PHE_VL_PULSO,
       pATD_PHE_VL_DOR,
       pATD_PHE_VL_GLICCAP,
       pATD_PHE_VL_PADIS,
       pATD_PHE_ID_USU_CRIACAO,
       pATD_PHE_DT_CRIACAO,
       pATD_PHE_ID_USU_ATUALIZ,
       pATD_PHE_DT_ULT_ATUALIZ,
      
       pATD_PHE_VL_TEMPINI,
       pATD_PHE_VL_TEMPFIM,
        lIdtRetorno,
        pATD_PHE_VL_PESO
);


 pNewIdt := lIdtRetorno;
end PRC_ATD_PHE_PRESC_HEM_ENF_I;
