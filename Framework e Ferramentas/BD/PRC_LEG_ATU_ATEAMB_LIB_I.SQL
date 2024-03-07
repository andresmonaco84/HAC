create or replace procedure sgs.PRC_LEG_ATU_ATEAMB_LIB_I
(
 pATD_ATE_ID IN TB_ASS_PAP_PAC_ATEN_PROC.ATD_ATE_ID%TYPE,
 pMES in NUMBER,
 pANO in NUMBER,
 pCODAND in NUMBER
)
is
  /********************************************************************
  *    Procedure: PRC_LEG_ATU_ATEAMB_LIB_I
  *
  *    Data Criacao:  09/05/2008   Por: SILMARA
  *    Funcao: incluir as informac?es na tabela paciente_atendimento_amb
  *     Alteracao: Enviar convenio para o legado quando plano 'SKIDO','SKIPA'
  *
  *******************************************************************/
    v_cd_unid_hospitalar         number;
    v_cd_intamb                  number;
    v_nr_prontuario              number;
    v_nm_pessoa                  varchar2(52);
    v_dt_atendimento             date;
    v_hr_atendimento             varchar2(4);
    v_cd_hospitalar              number;
    v_cd_local_atendimento       varchar2(3);
    v_cd_andar                   number;
    v_cd_convenio_leg            varchar2(4);
    v_codpadateben               varchar2(3);
    v_cd_tipo_ate_velho          number;
    v_cd_mot_ate                 number;
    v_tp_sexo                    varchar2(1);
    v_nm_usuario                 varchar2(30);
    v_codespmed                  varchar2(3);
    v_nr_conselho                number;
    v_cod_sit_ate                varchar2(1);
    v_dt_nascimento              date;
    v_nm_titular                 varchar2(40);
    v_codgrapar                  varchar2(2);
  --  v_nome_empresa               varchar2(30);
    v_cod_clinica                varchar2(5);
    v_codseqben                  varchar2(2);
    v_codest                     number;
    v_codben                     number;
    v_cd_credencial              varchar2(30);
    v_nome_plano                 varchar2(30);
    v_dt_validade                date;
    v_tipo_atendimento_tiss      char(2);
    v_obs                        varchar2(30);
    v_car_identidade             varchar2(9);
    v_cd_ind_acidente            number;
    v_nr_cns                     varchar2(15);
    v_nr_conselho_solic          varchar2(15);
    v_ind_clinica                varchar2(500);
    v_carater_solocit            varchar2(2);
    v_cid10                      varchar2(5);
    v_subproduto                 varchar2(10);
    v_nr_ass_pap_id              number(10);
    v_nr_id_prof                 number;
    v_contador                   number;
    v_error_code                 number;
    v_error_message              varchar2(900);
    ex_atendimentoinexistente    exception;
  begin
   v_nr_conselho:=99999;
   v_codespmed:='CLI';
   v_nr_conselho_solic:=0;
    SELECT    COUNT(*), MAX(PAP.ASS_PAP_ID)
    INTO      v_contador,v_nr_ass_pap_id
    FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP , TB_CAD_UNI_UNIDADE UNI
    WHERE     PAP.ATD_ATE_ID = pATD_ATE_ID
    AND    PAP.ASS_PAP_FL_STATUS_AUTOR='A'
    AND    PAP.ASS_PAP_FL_ORIGEM='L'
    AND    PAP.CAD_UNI_ID_UNIDADE=UNI.CAD_UNI_ID_UNIDADE
    AND    UNI.CAD_UNI_CD_UNID_HOSPITALAR != 26;
    SELECT  DECODE(PRO.CAD_PRO_NR_CONSELHO,NULL,99999,PRO.CAD_PRO_NR_CONSELHO),
             PRO.CAD_PRO_ID_PROFISSIONAL
               INTO  v_nr_conselho, v_nr_id_prof
              FROM  TB_ASS_PAP_PAC_ATEN_PROC PAP,
                    TB_CAD_PRO_PROFISSIONAL PRO
              WHERE   PRO.CAD_PRO_NR_CONSELHO(+) = PAP.ATD_ATE_NR_CONSELHO_SOLIC
              AND   PRO.TIS_CPR_CD_CONSELHOPROF(+) LIKE 'CRM%'
              AND   PAP.ASS_PAP_ID=v_nr_ass_pap_id
              AND    PAP.ASS_PAP_FL_STATUS_AUTOR='A';
     SELECT  DECODE(MIN(CBO.TIS_CBO_CD_CBOS_HAC),NULL,'CLI',MIN(CBO.TIS_CBO_CD_CBOS_HAC))
              into v_codespmed
              FROM TB_TIS_CBO_CBOS CBO,
              TB_ASS_PCB_PROFISSIONAL_CBOS PCB
              WHERE  CBO.TIS_CBO_CD_CBOS=PCB.TIS_CBO_CD_CBOS
              AND (PCB.CAD_PRO_ID_PROFISSIONAL(+)=v_nr_id_prof);
    IF v_contador = 0 THEN
        raise ex_atendimentoinexistente;
    ELSE
       SELECT DISTINCT  TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR,'99') ,
               DECODE(PAC.CAD_PAC_NR_PRONTUARIO,NULL,7,PAC.CAD_PAC_NR_PRONTUARIO),
               PAP.ATD_ATE_ID,
               SUBSTR(PES.CAD_PES_NM_PESSOA,0,52),
               TRUNC(PAP.ASS_PAP_DT_AUTOR),
               LPAD(TO_CHAR(PAP.ASS_PAP_HR_AUTOR),4,'0'),
               TO_NUMBER(UNI.CAD_UNI_CD_HOSPITALAR,'9'),
               DECODE(SUBSTR(LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO,0,3),'CON','AMB','FIS','AMB',SUBSTR(LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO,0,3)),
         --       CASE WHEN UNI.CAD_UNI_CD_UNID_HOSPITALAR = '8' THEN 1
         --      ELSE 7
          --     END,
CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO='SP' AND CNV.CAD_CNV_CD_HAC_PRESTADOR='SX73' AND PLA.CAD_PLA_CD_PLANO_HAC IN ('SKIDO','SKIPA')
                  THEN 'SX94'
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='SP'  THEN SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='GB' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='PL' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='PA' THEN SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='FU' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  ELSE SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  END,
               DECODE(PAP.CODPAD,NULL,BENEF_ACS.CODPADATE,PAP.CODPAD),
               --fixo 'A',
               CASE WHEN
                    LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO='CON' THEN 4
                    WHEN LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO='AMB' AND CLC.CAD_CLC_DS_RESUMIDA IS NOT NULL THEN 14
                    ELSE  3
               END,
               1,
               PES.CAD_PES_TP_SEXO,
               SUBSTR(SEG_USU_DS_NOME,1,30),
         --   SITUAC?O DO ATENDIMENTO
               'A',
               TRUNC(PES.CAD_PES_DT_NASCIMENTO),
          --   FIXO 'AT' UF_CARIDE
               SUBSTR(PAC.CAD_PAC_NM_TITULAR,0,40),
               BENEF_ACS.CODGRAPAR,
          ---  NOME EMPRESA VERIFICAR UTILIZACAO
               CLC.CAD_CLC_DS_RESUMIDA,
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01'
               OR CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05' THEN SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,11,2)
               ELSE NULL
               END,
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01'
               OR CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05' THEN TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,0,3))
               ELSE NULL
               END,
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01'
               OR CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05' THEN TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,4,7))
               ELSE NULL
               END,
             --- FIXO 'N' INDFATAMB
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
               SUBSTR(PLA.CAD_PLA_NM_NOME_PLANO,0,30),
               --- tipo de plano (utilizado no tiss)
               PAC.CAD_PAC_DT_VALIDADECREDENCIAL,
                3,
               NULL,
               substr(PES.CAD_PES_NR_RG,0,9),
               NULL,
               PAC.CAD_PAC_CD_CNS,
               PAP.ATD_ATE_NR_CONSELHO_SOLIC,
               NULL,
               'E',
               NULL,
               case when (TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR,'99')) = 6 and pCODAND = 11 then 1
               when (TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR,'99')) = 24  then 11
               when (TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR,'99')) not in(6,24)
               then 1
               when  pCODAND is null then 1
               else pCODAND
               end,
               DECODE(PAC.CAD_PAC_CD_SUBPLANO,NULL,PLA.CAD_PLA_CD_PLANO,PAC.CAD_PAC_CD_SUBPLANO)
        INTO
               v_cd_unid_hospitalar,
               v_nr_prontuario,
               v_cd_intamb,
               v_nm_pessoa,
               v_dt_atendimento,
               v_hr_atendimento,
               v_cd_hospitalar,
               v_cd_local_atendimento,
        --       v_cd_andar,
               v_cd_convenio_leg,
               v_codpadateben,
               v_cd_tipo_ate_velho,
               v_cd_mot_ate,
               v_tp_sexo,
               v_nm_usuario,
            --   v_codespmed,
           --    v_nr_conselho,
               v_cod_sit_ate,
               v_dt_nascimento,
               v_nm_titular,
               v_codgrapar,
               v_cod_clinica,
               v_codseqben,
               v_codest,
               v_codben,
               --v_nome_empresa
               --fixo A
               v_cd_credencial,
               v_nome_plano,
               v_dt_validade,
               v_tipo_atendimento_tiss,
               v_obs,
               v_car_identidade,
               v_cd_ind_acidente,
               v_nr_cns,
               v_nr_conselho_solic,
               v_ind_clinica,
               v_carater_solocit,
               v_cid10,
                v_cd_andar,
               v_subproduto
         FROM
               Tb_Ass_Pap_Pac_Aten_Proc PAP,
               TB_CAD_UNI_UNIDADE UNI,
               TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
               TB_CAD_PAC_PACIENTE PAC,
               TB_CAD_CNV_CONVENIO CNV,
               TB_CAD_PLA_PLANO PLA,
               TB_CAD_PES_PESSOA PES,
               TB_SEG_USU_USUARIO USU,
               TB_CAD_CLC_CLINICA_CREDENCIADA CLC,
               (SELECT PAP.ATD_ATE_ID, BNF.CODGRAPAR CODGRAPAR ,BNF.CODPADATEBEN CODPADATE
                FROM
                      TB_CAD_PAC_PACIENTE PAC,
                      TB_ASS_PAP_PAC_ATEN_PROC PAP,
                      TB_CAD_CNV_CONVENIO CNV,
                      TB_CAD_PLA_PLANO PLA,
                      BENEFICIARIO.BNF_BENEFICIARIO BNF
               WHERE
                PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
            --         PLA.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
               AND    PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
               AND    PAC.CAD_PAC_ID_PACIENTE = PAP.CAD_PAC_ID_PACIENTE
               AND    BNF.CODCON = PLA.CAD_PLA_CD_PLANO_HAC
               AND    lpad(to_char(BNF.CODEST),3,'0') = (SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,0,3))
               AND    lpad(to_char(BNF.CODBEN),7,'0') = (SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,4,7))
               AND    lpad(to_char(BNF.CODSEQBEN),2,'0') = (SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,11,2))
               AND    PAP.ATD_ATE_ID = pATD_ATE_ID
               AND    PAP.ASS_PAP_ID = v_nr_ass_pap_id
               AND    (CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01'
               OR CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05')
               ) BENEF_ACS
        WHERE  PAP.ATD_ATE_ID = pATD_ATE_ID
        AND    PAP.ASS_PAP_FL_STATUS_AUTOR='A'
        AND    PAP.ASS_PAP_FL_ORIGEM='L'
        AND    PAP.ASS_PAP_ID = v_nr_ass_pap_id
        AND    PAP.CAD_PAC_ID_PACIENTE=PAC.CAD_PAC_ID_PACIENTE
        AND    PAP.CAD_CLC_ID=CLC.CAD_CLC_ID(+)
        AND    PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
     --   AND    PLA.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
        AND    PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
        AND    PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
        AND    PAP.ATD_ATE_ID = BENEF_ACS.ATD_ATE_ID(+)
        AND    PAP.CAD_LAT_ID_LOCAL_ATENDIMENTO=LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
        AND    PAP.CAD_UNI_ID_UNIDADE=UNI.CAD_UNI_ID_UNIDADE
        AND    USU.SEG_USU_ID_USUARIO=PAP.SEG_USU_ID_USUARIO;
    END IF;
    v_contador:=0;
    SELECT COUNT(*)
     INTO      v_contador
    from paciente_atendimento_amb
    where codateamb = pATD_ATE_ID;
    IF v_contador = 0 THEN
    INSERT INTO HOSPITAL.PACIENTE_ATENDIMENTO_AMB
   (CODUNIHOS,
    CODPAC,
    CODATEAMB,
    NOMPAC,
    DATATE,
    HORATE,
    HR_RECEP,
    CODHOS,
    LOCAL,
    CODAND,
    CODCON,
    CODPADPAC,
    CODTIPPAD,
    CODTIPATE,
    CODMOTATEAMB,
    SEXPAC,
    NOMREGPAC,
    CODESPMED,
    CODMED,
    CODSITATE,
    DATNASPAC,
    UF_CARIDE,
    BENPRI,
    CODGRAPAR,
    NOMEMPPAC,
    CODCLI,
    DIGCARIDE,
    CODBEN,
    CODEST,
    INDFATAMB,
    NUMCRE,
    TP_PLANO,
    DT_VALIDADE,
    CODTIPO,
    OBS,
    CARIDE,
    CD_ID_ACIDENTE,
    NR_CNS,
    NR_CONS_PROF,
    DS_IND_CLINICA,
    CD_TP_CARAT_ATEND,
    CID,
    SUBPRODUTO,
    MESFAT,
    ANOFAT)
    VALUES
    ( v_cd_unid_hospitalar ,
               v_nr_prontuario ,
               v_cd_intamb ,
               v_nm_pessoa ,
               v_dt_atendimento,
               v_hr_atendimento,
               v_hr_atendimento,
               v_cd_hospitalar,
               v_cd_local_atendimento,
               v_cd_andar,
               v_cd_convenio_leg,
               v_codpadateben,
               'A',
               v_cd_tipo_ate_velho,
               v_cd_mot_ate,
               v_tp_sexo,
               v_nm_usuario,
               v_codespmed,
               v_nr_conselho,
               v_cod_sit_ate,
               v_dt_nascimento,
               'AT',
                v_nm_titular,
               v_codgrapar,
               null,
               v_cod_clinica,
               v_codseqben,
               v_codben,
               v_codest,
               'N',
               v_cd_credencial,
               v_nome_plano,
               v_dt_validade,
               v_tipo_atendimento_tiss,
               v_obs,
               v_car_identidade,
               v_cd_ind_acidente,
               v_nr_cns,
               v_nr_conselho_solic,
               v_ind_clinica,
               v_carater_solocit,
               v_cid10,
               v_subproduto,
               pMES,
               pANO);
      ELSE
      delete hospital.tb_req_exames_liberados
      where codateamb=pATD_ATE_ID;
      delete hospital.guia_atendimento_amb
      where codateamb=pATD_ATE_ID;
      UPDATE  HOSPITAL.PACIENTE_ATENDIMENTO_AMB
     SET
    CODUNIHOS=v_cd_unid_hospitalar,
    CODPAC=v_nr_prontuario,
    NOMPAC=v_nm_pessoa,
 --   DATATE= v_dt_atendimento,
 --   HORATE= v_hr_atendimento,
    HR_RECEP=v_hr_atendimento,
    LOCAL= v_cd_local_atendimento,
    CODAND= v_cd_andar,
    CODPADPAC = v_codpadateben,
 --   CODTIPATE = v_cd_tipo_ate_velho,
 --   CODMOTATEAMB = v_cd_mot_ate,
    SEXPAC= v_tp_sexo,
    NOMREGPAC=v_nm_usuario,
   -- CODESPMED=v_codespmed,
   CODMED=v_nr_conselho,
    CODSITATE=v_cod_sit_ate,
    DATNASPAC=v_dt_nascimento,
    UF_CARIDE='AT',
    BENPRI=v_nm_titular,
    CODGRAPAR=v_codgrapar,
    NOMEMPPAC=null,
    CODCLI=v_cod_clinica,
    CODCON=v_cd_convenio_leg,
    DIGCARIDE=v_codseqben,
    CODBEN=v_codben,
    CODEST= v_codest,
    INDFATAMB='N',
    NUMCRE=v_cd_credencial,
    TP_PLANO=v_nome_plano,
    DT_VALIDADE=v_dt_validade,
    CODTIPO=v_tipo_atendimento_tiss,
    OBS=v_obs,
    CARIDE=v_car_identidade,
    NR_CNS=v_nr_cns,
    NR_CONS_PROF=v_nr_conselho_solic,
    CD_TP_CARAT_ATEND=v_carater_solocit,
    SUBPRODUTO=v_subproduto
   -- MESFAT=pMES,
   --   ANOFAT=pANO
    WHERE CODSITATE='A'
     AND ((indemiconamb is null or indemiconamb='N')
         OR  (indfatamb is null or indfatamb='N'))
    AND CODATEAMB=pATD_ATE_ID;
    UPDATE PACIENTE_ATENDIMENTO_AMB
    SET CODTIPATE = v_cd_tipo_ate_velho,
    CODMOTATEAMB = v_cd_mot_ate
     WHERE CODSITATE='A'
     AND ((indemiconamb is null or indemiconamb='N')
         OR  (indfatamb is null or indfatamb='N'))
    AND CODATEAMB=pATD_ATE_ID
    AND CODTIPATE=3;
    END IF;
  EXCEPTION
  WHEN ex_atendimentoinexistente THEN
       raise_application_error('-20000', 'Atendimento Inexistente');
 WHEN OTHERS THEN
        v_error_code := SQLCODE;
       v_error_message := SQLERRM;
      raise_application_error(v_error_code, v_error_message);
end PRC_LEG_ATU_ATEAMB_LIB_I;
