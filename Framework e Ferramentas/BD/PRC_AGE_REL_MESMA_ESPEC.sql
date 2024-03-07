create or replace procedure PRC_AGE_REL_MESMA_ESPEC
  (
       PDT_INICIO_CONSULTA IN Tb_Age_Agd_Agenda.Age_Agd_Dt_Atendimento%type,
       PDT_FIM_CONSULTA IN Tb_Age_Agd_Agenda.Age_Agd_Dt_Atendimento%type,
       PCAD_UNI_ID_UNIDADE IN tb_cad_uni_unidade.cad_uni_id_unidade%type DEFAULT NULL,
       PCAD_LAT_ID_LOCAL_ATENDIMENTO IN tb_cad_lat_local_atendimento.cad_lat_id_local_atendimento%type DEFAULT NULL,

      io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_REL_MESMA_ESPEC
  *
  *    Data Criacao:   08/10/2010           Por: Eduardo Hyppolito
  *    Funcao: Verifica agendamento de pacientes para mais de uma especialidade
  *
  *
  *********************************************************************/

  v_cursor PKG_CURSOR.t_cursor;
begin
      OPEN v_cursor FOR

SELECT     PLA.CAD_PLA_CD_PLANO_HAC,
           PES.CAD_PES_NM_PESSOA,
           CBO.TIS_CBO_DS_CBOS_HAC,
           PAC.CAD_PAC_CD_CREDENCIAL,

        COUNT(*) TOTAL_AGEND
        FROM TB_AGE_AGD_AGENDA AGE,
             TB_AGE_ESM_ESCALA_MEDICA ESM,
             TB_CAD_PES_PESSOA PES,
             TB_CAD_PAC_PACIENTE PAC,
             TB_CAD_CNV_CONVENIO CNV,
             TB_CAD_PLA_PLANO PLA,
             TB_TIS_CBO_CBOS CBO
       WHERE
             AGE.AGE_AGD_FL_STATUS = 'P'
       --  AND AGE.AGE_AGD_TP_AGENDA != 4
         AND PAC.CAD_PAC_ID_PACIENTE=AGE.CAD_PAC_ID_PACIENTE
         AND PAC.CAD_PES_ID_PESSOA=PES.CAD_PES_ID_PESSOA
         AND PAC.CAD_CNV_ID_CONVENIO=CNV.CAD_CNV_ID_CONVENIO
         AND AGE.AGE_AGD_DT_ATENDIMENTO  BETWEEN PDT_INICIO_CONSULTA AND PDT_FIM_CONSULTA
         --AND AGE.AGE_AGD_DT_ATENDIMENTO > sysdate
         AND ESM.AGE_ESM_ID = AGE.AGE_ESM_ID
         AND PLA.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
         AND PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
       --  AND CNV.CAD_CNV_ID_CONVENIO=281
         AND ESM.TIS_CBO_CD_CBOS=CBO.TIS_CBO_CD_CBOS
         AND (PCAD_UNI_ID_UNIDADE is null or esm.cad_uni_id_unidade = PCAD_UNI_ID_UNIDADE)
         AND (PCAD_LAT_ID_LOCAL_ATENDIMENTO is null or esm.cad_lat_id_local_atendimento = PCAD_LAT_ID_LOCAL_ATENDIMENTO)

         GROUP BY PLA.CAD_PLA_CD_PLANO_HAC,
                  PES.CAD_PES_NM_PESSOA,
                  CBO.TIS_CBO_DS_CBOS_HAC,
                  PAC.CAD_PAC_CD_CREDENCIAL

         HAVING COUNT(*) > 1
order by 3;

  io_cursor := v_cursor;

end PRC_AGE_REL_MESMA_ESPEC;
/
