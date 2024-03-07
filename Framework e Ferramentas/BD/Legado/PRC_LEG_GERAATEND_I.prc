create or replace procedure PRC_LEG_GERAATEND_I
(
 pAGE_AGD_ID IN TB_AGE_AGD_AGENDA.AGE_AGD_ID%TYPE
)
is
  /********************************************************************
  *    Procedure: PRC_LEG_GERAATEND_I
  * 
  *    Data Criacao:  20/08/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 23/06/2008   Por: Cristiane Gomes da Silva
  *
  *    Funcao: Gerar atendimento ambulatorial para os procedimentos 
  *            agendados
  *
  *    Alteração: 1) Gerar o atendimento no mesmo momento em que a agenda
  *               é marcada
  *               2) Solução alternativa para tratar as várias especialidades
  *               do legado associadas a somente uma no TISS
  *               3) Não acessar a tabela de Especialidades do legado, 
  *               usar o novo atributo da tabela TB_TIS_CBO_CBOS
  *               4) Correção da formatação da hora
  *               5) Alteração do tipo da variável hora atendimento
  *               6) Inclusão da condição convênio = 'SD01' na subquery de 
  *               grau de parentesco 
  *               7) Tratamento do convênio GG05 como o SD01
  *               8) Inclusão do DISTINCT na subquery 
  *               9) Tratar profissional nao cadastrado na tabela MEDICO (legado)
  *               10) Considerar o código do convênio para SP, PA e FU e 
  *               código do plano para ACS ao gravar o CODCON no legado
  *
  *******************************************************************/
    v_nr_prontuario              number;
    v_nm_pessoa                  varchar2(52);
    v_dt_atendimento             date;
    v_hr_atendimento             varchar2(4);
    v_cd_hospitalar              number;
    v_cd_unid_hospitalar         number;
    v_cd_local_atendimento       varchar2(3);
    v_cd_andar                   number;
    v_cd_convenio_leg            varchar2(4);
    v_cd_credencial              varchar2(30);
    v_tp_sexo                    varchar2(1);
    v_nm_usuario                 varchar2(30);
    v_codespmed                  varchar2(3);
    v_nr_conselho                number;
    v_dt_nascimento              date;
    v_codseqben                  varchar2(2);
    v_nm_titular                 varchar2(40);
    v_codest                     number;
    v_codben                     number;
    v_codgrapar                  varchar2(2);
    v_codpadateben               varchar2(3);
    v_id_usuario                 number;
    v_contador                   number;
    v_cd_intamb                  number;
    v_error_code                 number;
    v_error_message              varchar2(900);
    ex_agendainexistente         exception;
  begin     
    SELECT COUNT(*)
    INTO   v_contador
    FROM   TB_AGE_AGD_AGENDA AGD,
           TB_AGE_ESM_ESCALA_MEDICA ESM,
           TB_TIS_CBO_CBOS CBO
    WHERE  AGD.AGE_ESM_ID = ESM.AGE_ESM_ID
    AND    ESM.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS
    AND    CBO.TIS_CBO_CD_CBOS_HAC IS NOT NULL
    AND    AGD.AGE_AGD_FL_STATUS = 'P'
    AND    AGD.AGE_AGD_CD_INTAMB IS NULL
    AND    AGD.AGE_AGD_IN_INTAMB IS NULL
    AND    AGD.AGE_AGD_ID = pAGE_AGD_ID;
    
    IF v_contador > 1 OR v_contador = 0 THEN
       v_codespmed := NULL;
    ELSE
        SELECT CBO.TIS_CBO_CD_CBOS_HAC
        INTO   v_codespmed
        FROM   TB_AGE_AGD_AGENDA AGD,
               TB_AGE_ESM_ESCALA_MEDICA ESM,
               TB_TIS_CBO_CBOS CBO
        WHERE  AGD.AGE_ESM_ID = ESM.AGE_ESM_ID
        AND    ESM.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS
        AND    AGD.AGE_AGD_FL_STATUS = 'P'
        AND    AGD.AGE_AGD_CD_INTAMB IS NULL
        AND    AGD.AGE_AGD_IN_INTAMB IS NULL
        AND    AGD.AGE_AGD_ID = pAGE_AGD_ID;
    END IF;
    
    SELECT    COUNT(*)
    INTO      v_contador
    FROM      TB_AGE_AGD_AGENDA
    WHERE     AGE_AGD_ID = pAGE_AGD_ID;
    
    IF v_contador = 0 THEN
        raise ex_agendainexistente;
    ELSE    
        SELECT CASE WHEN PAC.CAD_PAC_NR_PRONTUARIO IS NULL THEN 7
               ELSE PAC.CAD_PAC_NR_PRONTUARIO
               END,
               SUBSTR(PES.CAD_PES_NM_PESSOA,0,52),
               TRUNC(AGD.AGE_AGD_DT_ATENDIMENTO),
               LPAD(TO_CHAR(AGD.AGE_AGD_HR_ATENDIMENTO),4,'0'),
               TO_NUMBER(UNI.CAD_UNI_CD_HOSPITALAR,'9'),              
               TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR,'99'),
               SUBSTR(LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO,0,3),
               TO_NUMBER(TO_CHAR(SAU.AGE_SAU_CD_ANDAR,'99'),'99'),
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01' THEN PLA.CAD_PLA_CD_PLANO_HAC
               ELSE CNV.CAD_CNV_CD_HAC_PRESTADOR
               END,
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR != 'SD01' 
               AND CNV.CAD_CNV_CD_HAC_PRESTADOR != 'PA__' 
               AND CNV.CAD_CNV_CD_HAC_PRESTADOR != 'GG05'
               AND PAC.CAD_PAC_CD_CREDENCIAL IS NOT NULL THEN PAC.CAD_PAC_CD_CREDENCIAL
               WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR != 'SD01' 
               AND CNV.CAD_CNV_CD_HAC_PRESTADOR != 'PA__' 
               AND CNV.CAD_CNV_CD_HAC_PRESTADOR != 'GG05'
               AND PAC.CAD_PAC_CD_CREDENCIAL IS NULL THEN 'ALTERAR'
               ELSE '.'
               END,
               PES.CAD_PES_TP_SEXO,
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR != 'SD01' 
               AND CNV.CAD_CNV_CD_HAC_PRESTADOR != 'PA__' 
               AND CNV.CAD_CNV_CD_HAC_PRESTADOR != 'GG05' THEN 'ALTERAR'           
               ELSE 'AGENDAMENTO'
               END,
               TO_NUMBER(PRO.CAD_PRO_NR_CONSELHO),
               PES.CAD_PES_DT_NASCIMENTO,
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01' 
               OR CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05' THEN SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,11,2)
               ELSE NULL
               END,
               SUBSTR(PAC.CAD_PAC_NM_TITULAR,0,40),
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01' 
               OR CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05' THEN SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,0,3)
               ELSE NULL
               END,           
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01' 
               OR CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05' THEN SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,4,7)
               ELSE NULL
               END,
               BENEF_ACS.CODGRAPAR,
               BENEF_ACS.CODPADATEBEN,
               AGD.SEG_USU_ID_USUARIO   
        INTO   v_nr_prontuario,v_nm_pessoa,
               v_dt_atendimento, v_hr_atendimento, v_cd_hospitalar,
               v_cd_unid_hospitalar, v_cd_local_atendimento, v_cd_andar,
               v_cd_convenio_leg, v_cd_credencial, v_tp_sexo,
               v_nm_usuario, v_nr_conselho,
               v_dt_nascimento, v_codseqben, v_nm_titular,
               v_codest, v_codben, v_codgrapar, v_codpadateben, v_id_usuario
        FROM   TB_AGE_AGD_AGENDA AGD,
               TB_AGE_ESM_ESCALA_MEDICA ESM,
               TB_CAD_UNI_UNIDADE UNI,
               TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
               TB_AGE_SAU_SALA_UNID_AND SAU,
               TB_CAD_PRO_PROFISSIONAL PRO,
               TB_CAD_PAC_PACIENTE PAC,
               TB_CAD_CNV_CONVENIO CNV,
               TB_CAD_PLA_PLANO PLA,
               TB_CAD_PES_PESSOA PES,
               (SELECT DISTINCT AGD.AGE_AGD_ID, BNF.CODGRAPAR CODGRAPAR, BNF.CODPADATEBEN CODPADATEBEN
               FROM   TB_AGE_AGD_AGENDA AGD,
                      TB_AGE_ESM_ESCALA_MEDICA ESM,
                      TB_CAD_UNI_UNIDADE UNI,
                      TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
                      TB_AGE_SAU_SALA_UNID_AND SAU,
                      TB_CAD_PRO_PROFISSIONAL PRO, 
                      TB_CAD_PAC_PACIENTE PAC,
                      TB_CAD_CNV_CONVENIO CNV,
                      TB_CAD_PLA_PLANO PLA,
                      TB_CAD_PES_PESSOA PES,
                      BENEFICIARIO.BNF_BENEFICIARIO BNF
               WHERE  AGD.AGE_ESM_ID = ESM.AGE_ESM_ID
               AND    AGD.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
               AND    ESM.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
               AND    ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
               AND    ESM.AGE_SAU_ID = SAU.AGE_SAU_ID
               AND    ESM.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL
               AND    PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
               AND    PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
               AND    PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
               AND    BNF.CODCON = PLA.CAD_PLA_CD_PLANO_HAC
               AND    BNF.CODEST = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,0,3))
               AND    BNF.CODBEN = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,4,7))
               AND    BNF.CODSEQBEN = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,11,2))
               AND    AGD.AGE_AGD_FL_STATUS = 'P'
               AND    AGD.AGE_AGD_CD_INTAMB IS NULL
               AND    AGD.AGE_AGD_IN_INTAMB IS NULL
               AND    AGD.AGE_AGD_ID = pAGE_AGD_ID
               AND    LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO = 'AMB'
               AND    (CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01'
               OR CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05')
               ) BENEF_ACS
        WHERE  AGD.AGE_ESM_ID = ESM.AGE_ESM_ID
        AND    AGD.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
        AND    ESM.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
        AND    ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
        AND    ESM.AGE_SAU_ID = SAU.AGE_SAU_ID
        AND    ESM.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL
        AND    PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
        AND    PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
        AND    PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
        AND    AGD.AGE_AGD_ID = BENEF_ACS.AGE_AGD_ID (+)
        AND    AGD.AGE_AGD_FL_STATUS = 'P'
        AND    AGD.AGE_AGD_CD_INTAMB IS NULL
        AND    AGD.AGE_AGD_IN_INTAMB IS NULL
        AND    AGD.AGE_AGD_ID = pAGE_AGD_ID
        AND    LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO = 'AMB'; 
        
        SELECT COUNT(*)
        INTO   v_contador
        FROM   MEDICO
        WHERE  CODMED = v_nr_conselho;
        
        IF v_contador = 0 THEN
           v_nr_conselho := 99999;   
        END IF;                
    END IF;
       
    SELECT     HOSPITAL.SEQATEND.NextVal
    INTO       v_cd_intamb
    FROM       DUAL;
        
    INSERT INTO HOSPITAL.PACIENTE_ATENDIMENTO_AMB
    (CODPAC, CODATEAMB, NOMPAC, DATATE, HORATE, 
    CODHOS, CODUNIHOS, LOCAL, CODAND, 
    CODCON, CODPADPAC, CODTIPPAD, CODTIPATE, NUMCRE, CODMOTATEAMB,
    SEXPAC, NOMREGPAC, CODESPMED, CODMED, CODSITATE, INDFATAMB,
    DATNASPAC, DIGCARIDE, BENPRI, CODGRAPAR, CODEST, CODBEN, CODTIPO)
    VALUES
    (v_nr_prontuario, v_cd_intamb, v_nm_pessoa, v_dt_atendimento, v_hr_atendimento,
    v_cd_hospitalar, v_cd_unid_hospitalar, v_cd_local_atendimento, v_cd_andar, 
    v_cd_convenio_leg, v_codpadateben, 'C', 1, v_cd_credencial, 1,
    v_tp_sexo, v_nm_usuario, v_codespmed, v_nr_conselho,'P', 'N',
    v_dt_nascimento, v_codseqben, v_nm_titular, v_codgrapar, v_codest, v_codben, 1);
  
    UPDATE    TB_AGE_AGD_AGENDA
    SET       AGE_AGD_CD_INTAMB = v_cd_intamb,
              AGE_AGD_IN_INTAMB = 'A',
              AGE_AGD_DT_ULTIMA_ATUALIZACAO = sysdate,
              SEG_USU_ID_USUARIO = v_id_usuario
    WHERE     AGE_AGD_ID = pAGE_AGD_ID;
    
  EXCEPTION 
  WHEN ex_agendainexistente THEN
       raise_application_error('-20000', 'Agenda Inexistente');                          
  WHEN OTHERS THEN
       v_error_code := SQLCODE;
       v_error_message := SQLERRM;
       raise_application_error(v_error_code, v_error_message);            
       
end PRC_LEG_GERAATEND_I;
/
