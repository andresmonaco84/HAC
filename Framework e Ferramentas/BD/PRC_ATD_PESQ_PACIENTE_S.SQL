CREATE OR REPLACE PROCEDURE SGS."PRC_ATD_PESQ_PACIENTE_S"
  (
     pCAD_PES_NM_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
is
  /********************************************************************
  *    Procedure: PRC_ATD_PESQ_PACIENTE_S
  *
  *    Data Criacao: 	28/03/2008           Por: Andrea Cazuca
  *    Funcao: Lista Pacientes Agendados e Atendidos
  *
  *    Data Alteracao:	15/05/2008  Por: Davi S. M. dos Reis
  *    Alteracao: Alteracao na PROC para retornar mais informacoes.
  *
  *    Data Alteracao: 11/06/2008   Por: Fabiola R. Lopes
  *    Alteracao: Inclusao do nome e codigo do setor (acerto da formatacao da data e hora)
  *
  *    Data Alteracao: 10/07/2008  Por: Fabiola Lopes
  *    Alteracao:      Acerto da recuperacao da informacao em plano e convenio, estava repetindo o plano duas vezes - task 3100
  *
  *    Data Alteracao: 25/11/2008  Por: Andrea Cazuca
  *    Alteracao:      Inluido um left join no profissional
  *********************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
       SELECT  AGD.AGE_AGD_ID Idt, 
               --PLA.CAD_PLA_CD_PLANO_HAC || ' / ' || PLA.CAD_PLA_CD_PLANO_HAC PlanoConvenio,
               PLA.CAD_PLA_CD_PLANO_HAC || ' / ' || CNV.CAD_CNV_CD_HAC_PRESTADOR PlanoConvenio,
               PAC.CAD_PAC_CD_CREDENCIAL Credencial,
               PAC.CAD_PAC_NR_PRONTUARIO Prontuario, 
               AGD.AGE_AGD_CD_INTAMB NroAtendimento, 
               to_char(trunc(AGD.AGE_AGD_DT_ATENDIMENTO),'dd/MM/yyyy') || ' ' || SUBSTR(LPAD(TO_CHAR(AGD.AGE_AGD_HR_ATENDIMENTO),4,'0'),0,2) || ':' || SUBSTR(LPAD(TO_CHAR(AGD.AGE_AGD_HR_ATENDIMENTO),4,'0'),3,2) DataHora,
               'CONSULTA' Tipo_Atendimento,
               'AGE' Modulo,
               UNI.CAD_UNI_DS_UNIDADE || ' / ' || LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO || ' / ' || SETOR.CAD_SET_CD_SETOR UnidadeLocal, 
               AGD.AGE_AGD_FL_STATUS STATUS,
               PRO.CAD_PRO_NM_NOME PROFISSIONAL,
               PES.CAD_PES_NM_PESSOA Nome,
               TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'dd/MM/yyyy') DataNasc,
               AGD.AGE_AGD_DT_ATENDIMENTO DATA
          FROM TB_CAD_PES_PESSOA PES
         INNER JOIN TB_CAD_PAC_PACIENTE PAC
            ON PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
         INNER JOIN TB_AGE_AGD_AGENDA AGD
            ON AGD.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
         INNER JOIN TB_CAD_PLA_PLANO PLA
            ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
          --  AND PLA.CAD_PLA_FL_SITUACAO_PLANO = 'S'
         INNER JOIN TB_AGE_ESM_ESCALA_MEDICA ESM
            ON ESM.AGE_ESM_ID = AGD.AGE_ESM_ID
            --AND ESM.AGE_ESM_FL_SITUACAO = 'A'
         INNER JOIN TB_CAD_UNI_UNIDADE UNI
            ON UNI.CAD_UNI_ID_UNIDADE = ESM.CAD_UNI_ID_UNIDADE
            --AND UNI.CAD_UNI_FL_STATUS = 'A'
         INNER JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
            ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO
            --AND LAT.CAD_LAT_FL_ATIVO_OK = 'S'
         INNER JOIN TB_CAD_PRO_PROFISSIONAL PRO
            ON PRO.CAD_PRO_ID_PROFISSIONAL = AGD.CAD_PRO_ID_PROFISSIONALEXEC
            --AND PRO.CAD_PRO_FL_ATIVO_OK = 'S'
         INNER JOIN TB_AGE_SAU_SALA_UNID_AND SAU
            ON ESM.AGE_SAU_ID = SAU.AGE_SAU_ID
         INNER JOIN TB_ASS_USS_UNID_LOC_SET_SALA USS
            ON USS.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
            AND USS.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
            AND USS.AGE_SAU_ID = SAU.AGE_SAU_ID
         INNER JOIN TB_CAD_SET_SETOR SETOR
            ON USS.CAD_SET_ID = SETOR.CAD_SET_ID
         INNER JOIN TB_CAD_CNV_CONVENIO CNV
            ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO  
          --  AND CNV.CAD_CNV_FL_STATUS = 'A' 
         WHERE AGD.AGE_AGD_FL_STATUS = 'P'
           AND PES.CAD_PES_NM_PESSOA LIKE pCAD_PES_NM_PESSOA
           and AGD.AGE_AGD_DT_ATENDIMENTO > trunc(sysdate - 30)
           
        UNION ALL
        SELECT ATE.ATD_ATE_ID Idt, 
               PLA.CAD_PLA_CD_PLANO_HAC || ' / ' || CNV.CAD_CNV_CD_HAC_PRESTADOR PlanoConvenio,
               PAC.CAD_PAC_CD_CREDENCIAL Credencial,
               PAC.CAD_PAC_NR_PRONTUARIO Prontuario, 
               ATE.ATD_ATE_ID NroAtendimento,           
         to_char(trunc(ATE.ATD_ATE_DT_ATENDIMENTO),'dd/MM/yyyy') || ' ' || SUBSTR(LPAD(TO_CHAR(ATE.ATD_ATE_HR_ATENDIMENTO),4,'0'),0,2) || ':' || SUBSTR(LPAD(TO_CHAR(ATE.ATD_ATE_HR_ATENDIMENTO),4,'0'),3,2) DataHora,
               TAT.TIS_TAT_DS_TPATENDIMENTO Tipo_Atendimento, 
               'ATE' Modulo,
               UNI.CAD_UNI_DS_UNIDADE || ' / ' || LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO || ' / ' || SETOR.CAD_SET_CD_SETOR UnidadeLocal,
               ATE.ATD_ATE_FL_STATUS STATUS,
               PRO.CAD_PRO_NM_NOME PROFISSIONAL,
               PES.CAD_PES_NM_PESSOA Nome,
               TO_CHAR(PES.CAD_PES_DT_NASCIMENTO, 'dd/MM/yyyy') DataNasc,
               ATE.ATD_ATE_DT_ATENDIMENTO DATA
          FROM TB_CAD_PES_PESSOA PES
         INNER JOIN TB_CAD_PAC_PACIENTE PAC
            ON PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
         INNER JOIN TB_ASS_PAT_PACIEATEND PAT
            ON PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
         INNER JOIN TB_ATD_ATE_ATENDIMENTO ATE
            ON ATE.ATD_ATE_ID = PAT.ATD_ATE_ID
         INNER JOIN TB_CAD_PLA_PLANO PLA
            ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
            --AND PLA.CAD_PLA_FL_SITUACAO_PLANO = 'A'
         INNER JOIN TB_CAD_UNI_UNIDADE UNI
            ON UNI.CAD_UNI_ID_UNIDADE = ATE.CAD_UNI_ID_UNIDADE
            --AND UNI.CAD_UNI_FL_STATUS = 'A'
         INNER JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
            ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATE.CAD_LAT_ID_LOCAL_ATENDIMENTO
            --AND LAT.CAD_LAT_FL_ATIVO_OK = 'S'
         INNER JOIN TB_TIS_TAT_TP_ATENDIMENTO TAT
            ON TAT.TIS_TAT_CD_TPATENDIMENTO = ATE.TIS_TAT_CD_TPATENDIMENTO
         LEFT JOIN TB_CAD_PRO_PROFISSIONAL PRO
            ON PRO.CAD_PRO_ID_PROFISSIONAL = ATE.CAD_PRO_ID_PROF_EXEC
            --AND PRO.CAD_PRO_FL_ATIVO_OK = 'S'
         INNER JOIN TB_CAD_SET_SETOR SETOR
            ON SETOR.CAD_SET_ID = ATE.CAD_SET_ID
            --AND SETOR.CAD_SET_FL_ATIVO_OK = 'A'
         INNER JOIN TB_CAD_CNV_CONVENIO CNV
            ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
          --  AND CNV.CAD_CNV_FL_STATUS = 'A'
         WHERE PES.CAD_PES_NM_PESSOA LIKE pCAD_PES_NM_PESSOA
         and ATE.ATD_ATE_DT_ATENDIMENTO > trunc(sysdate - 180)
         ORDER BY DATA desc;
    io_cursor := v_cursor;
end PRC_ATD_PESQ_PACIENTE_S;
 
