create or replace procedure PRC_LEG_ATU_ATEAMB_I
(
 pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
 pMES in NUMBER,
 pANO in NUMBER
)
is
  /********************************************************************
  *    Procedure: PRC_LEG_ATU_ATEAMB_I
  *
  *    Data Criacao:  07/01/2008   Por: SILMARA
  *    Data Alteracao: 28/02/2008  Por: Silmara
  *    Data alteracao: 25/04/2008  Por Silmara
  *    Data alteracao: 08/07/2008  Por Silmara
  *    Data Alteracao: 26/03/2009  Por: Bruno Costa
  *    Data Alteracao: 20/12/2010  Por: Andrea Cazuca 
  *    Alteracao: Adicionado campo NR_SENHA_CHAMADA
  *    Alteracao: Alteração dos dados do atendimento no legado se existir o
  *    atendimento gerado pelo agendamento.
  *    Alteracao: Parametro fixo do andar para o legado aguardando associacao
  *    Alteracao: Enviar convênio para o legado quando plano 'SKIDO','SKIPA'
  *	   Alteracao: Retirado a exceção da Unidade 26 (Viva Saúde)
  *    Funcao: incluir as informações na tabela paciente_atendimento_amb
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
    v_setor                      varchar2(4);
    v_contador                   number;
    v_error_code                 number;
    v_error_message              varchar2(900);
    v_senha_chamada              number;
    ex_atendimentoinexistente    exception;
  begin
     SELECT    COUNT(*)
    INTO      v_contador
    FROM      TB_ATD_ATE_ATENDIMENTO ATD, TB_CAD_UNI_UNIDADE UNI 
    WHERE     ATD.ATD_ATE_ID = pATD_ATE_ID 
    AND ATD.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE;
    IF v_contador = 0 THEN
        raise ex_atendimentoinexistente;
    ELSE
        SELECT distinct TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR,'99') , 
               decode(PAC.CAD_PAC_NR_PRONTUARIO,null,7,PAC.CAD_PAC_NR_PRONTUARIO),
               ATD.ATD_ATE_ID,
               SUBSTR(PES.CAD_PES_NM_PESSOA,0,52),
               TRUNC(atd.atd_ate_dt_atendimento),
               LPAD(TO_CHAR(ATD.ATD_ATE_HR_ATENDIMENTO),4,'0'),
               TO_NUMBER(UNI.CAD_UNI_CD_HOSPITALAR,'9'),
                decode(SUBSTR(LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO,0,3),'FIS','AMB',SUBSTR(LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO,0,3)),
                 SETOR.CAD_SET_NR_ANDAR,
             CASE WHEN PLA.CAD_PLA_CD_TIPOPLANO='SP' AND CNV.CAD_CNV_CD_HAC_PRESTADOR='SX73' AND PLA.CAD_PLA_CD_PLANO_HAC IN ('SKIDO','SKIPA')
                  THEN 'SX94'
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='SP'  THEN SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='GB' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='PL' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='PA' THEN SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  WHEN PLA.CAD_PLA_CD_TIPOPLANO='FU' THEN PLA.CAD_PLA_CD_PLANO_HAC
                  ELSE SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)
                  END,
                 --DECODE(PLA.CAD_PLA_CD_TIPOPLANO,'SP',SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4) ,
              --  'GB',PLA.CAD_PLA_CD_PLANO_HAC,
             --   'PL',PLA.CAD_PLA_CD_PLANO_HAC,
             --   'PA',SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4) ,
             --   'FU',PLA.CAD_PLA_CD_PLANO_HAC,SUBSTR(cnv.cad_cnv_cd_hac_prestador,1,4)),
               ATD.CODPAD,
               --fixo 'A',
                    CASE WHEN ATD.ATD_ATE_TP_PACIENTE='A' AND LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO='CON' THEN 4
                    WHEN ATD.ATD_ATE_TP_PACIENTE='A' AND ATD.ATD_ATE_FL_RETORNO_OK='N' AND ATD.TIS_TAT_CD_TPATENDIMENTO=2
                    THEN 12
                    WHEN ATD.ATD_ATE_TP_PACIENTE='U' AND ATD.ATD_ATE_FL_RETORNO_OK='S'  THEN 2
                    WHEN ATD.ATD_ATE_TP_PACIENTE='U' AND ATD.ATD_ATE_FL_RETORNO_OK='N' THEN 10
                    WHEN ATD.ATD_ATE_TP_PACIENTE='A' AND ATD.ATD_ATE_FL_RETORNO_OK='N' AND ATD.TIS_TAT_CD_TPATENDIMENTO=3
                    AND SETOR.CAD_SET_CD_SETOR='FISI' THEN 22
                    WHEN ATD.ATD_ATE_TP_PACIENTE='A' AND ATD.ATD_ATE_FL_RETORNO_OK='N' AND ATD.TIS_TAT_CD_TPATENDIMENTO=3
                    AND SETOR.CAD_SET_CD_SETOR='LITO' THEN 17
                    WHEN ATD.ATD_ATE_TP_PACIENTE='A' AND ATD.TIS_TAT_CD_TPATENDIMENTO=8  THEN 15
                    WHEN ATD.ATD_ATE_TP_PACIENTE='A' AND ATD.TIS_TAT_CD_TPATENDIMENTO=10  THEN 16
                    WHEN ATD.ATD_ATE_TP_PACIENTE='A' AND SETOR.CAD_SET_CD_SETOR='ENDO' AND ATD.TIS_TAT_CD_TPATENDIMENTO=5 THEN 30
                    WHEN ATD.ATD_ATE_TP_PACIENTE='A' AND ATD.TIS_TAT_CD_TPATENDIMENTO=3 AND SETOR.CAD_SET_CD_SETOR='BCOS' THEN 18
                    WHEN ATD.ATD_ATE_FL_CARATER_SOLIC = 'U' AND ATD.ATD_ATE_FL_RETORNO_OK='N' AND
                    ATD.TIS_TAT_CD_TPATENDIMENTO=5 THEN 3
                    WHEN ATD.ATD_ATE_FL_CARATER_SOLIC = 'E' AND ATD.ATD_ATE_FL_RETORNO_OK='N' AND ATD.TIS_TAT_CD_TPATENDIMENTO=5 THEN 3
                    WHEN ATD.ATD_ATE_TP_PACIENTE='A' AND ATD.TIS_TAT_CD_TPATENDIMENTO=6  THEN 25
                    WHEN ATD.ATD_ATE_TP_PACIENTE='A' AND ATD.ATD_ATE_FL_RETORNO_OK='N' AND ATD.TIS_TAT_CD_TPATENDIMENTO=3
                    THEN 13
                    WHEN ATD.ATD_ATE_TP_PACIENTE='A' AND ATD.ATD_ATE_FL_RETORNO_OK='S'  THEN 2
                    WHEN ATD.ATD_ATE_TP_PACIENTE='A' AND ATD.ATD_ATE_FL_RETORNO_OK='N'  and ATD.TIS_TAT_CD_TPATENDIMENTO=4 THEN 1
                    WHEN ATD.ATD_ATE_TP_PACIENTE='A' AND ATD.TIS_TAT_CD_TPATENDIMENTO=5 AND ATD.CODCLI IS NOT NULL THEN 14
                    ELSE  TO_NUMBER(ATD.TIS_TAT_CD_TPATENDIMENTO)
               END,
               decode(ATD.ATD_ATE_TP_PACIENTE,'U',2,1),
               PES.CAD_PES_TP_SEXO,
               SUBSTR(SEG_USU_DS_NOME,1,30),
               DECODE(CBO.TIS_CBO_CD_CBOS_HAC,'ENF','CLI','ATE','CLI',CBO.TIS_CBO_CD_CBOS_HAC),
              decode(TO_NUMBER(TRIM(PRO.CAD_PRO_NR_CONSELHO)),9999,99999,TO_NUMBER(TRIM(PRO.CAD_PRO_NR_CONSELHO))),
               ATD.ATD_ATE_FL_STATUS,
               TRUNC(PES.CAD_PES_DT_NASCIMENTO),
          --   FIXO 'AT' UF_CARIDE
               SUBSTR(PAC.CAD_PAC_NM_TITULAR,0,40),
               BENEF_ACS.CODGRAPAR,
          ---  NOME EMPRESA VERIFICAR UTILIZACAO
               ATD.CODCLI,
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01'
               OR CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05' THEN SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,11,2)
               ELSE NULL
               END,
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01'
               OR CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05' THEN SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,0,3)
               ELSE NULL
               END,
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01'
               OR CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05' THEN SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,4,7)
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
               SUBSTR(PLA.CAD_PLA_NM_NOME_PLANO,1,30),
               --- tipo de plano (utilizado no tiss)
               PAC.CAD_PAC_DT_VALIDADECREDENCIAL,
               CASE WHEN ATD.TIS_TAT_CD_TPATENDIMENTO=4 AND ATD.ATD_ATE_FL_RETORNO_OK='S' THEN 2
                    WHEN ATD.TIS_TAT_CD_TPATENDIMENTO=4 AND ATD.ATD_ATE_FL_RETORNO_OK='N'THEN 1
                    ELSE   3
                    END,
               SUBSTR(ATD.ATD_ATE_DS_OBSERVACAO,1,30),
               SUBSTR(PES.CAD_PES_NR_RG,0,9),
               ATD.TIS_IAC_CD_INDACIDENTE,
               PAC.CAD_PAC_CD_CNS,
               TRIM(DECODE(ATD.ATD_ATE_NR_CONSELHO_SOLIC,NULL,PRO.CAD_PRO_CD_COD_PRO,ATD.ATD_ATE_NR_CONSELHO_SOLIC)),
               ATD.ATD_ATE_DS_INDCLINICA,
               ATD.ATD_ATE_FL_CARATER_SOLIC,
               TRIM(ATD.CAD_CID_CD_CID10),
               DECODE(PAC.CAD_PAC_CD_SUBPLANO,NULL,PLA.CAD_PLA_CD_PLANO,PAC.CAD_PAC_CD_SUBPLANO),
               SETOR.CAD_SET_CD_SETOR,
               ATD.ATD_ATE_NR_SENHA_CHAMADA
                       INTO
               v_cd_unid_hospitalar,
               v_nr_prontuario,
               v_cd_intamb,
               v_nm_pessoa,
               v_dt_atendimento,
               v_hr_atendimento,
               v_cd_hospitalar,
               v_cd_local_atendimento,
               v_cd_andar,
               v_cd_convenio_leg,
               v_codpadateben,
               v_cd_tipo_ate_velho,
               v_cd_mot_ate,
               v_tp_sexo,
               v_nm_usuario,
               v_codespmed,
               v_nr_conselho,
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
               v_subproduto,
               v_setor,
               v_senha_chamada
        FROM
               Tb_Atd_Ate_Atendimento atd,
               TB_CAD_UNI_UNIDADE UNI,
               TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
               TB_CAD_PRO_PROFISSIONAL PRO,
               TB_CAD_PAC_PACIENTE PAC,
               TB_CAD_CNV_CONVENIO CNV,
               TB_CAD_PLA_PLANO PLA,
               TB_CAD_PES_PESSOA PES,
               TB_TIS_CBO_CBOS CBO,
               TB_CAD_SET_SETOR SETOR,
               TB_ASS_PAT_PACIEATEND PAT,
               TB_SEG_USU_USUARIO USU,
               (SELECT ATD.ATD_ATE_ID, BNF.CODGRAPAR CODGRAPAR
                FROM  TB_ATD_ATE_ATENDIMENTO ATD,
                      TB_CAD_PAC_PACIENTE PAC,
                      TB_CAD_CNV_CONVENIO CNV,
                      TB_CAD_PLA_PLANO PLA,
                      TB_ASS_PAT_PACIEATEND PAT,
                      BENEFICIARIO.BNF_BENEFICIARIO BNF
               WHERE  PAT.CAD_PAC_ID_PACIENTE=PAC.CAD_PAC_ID_PACIENTE
               AND    PAT.ATD_ATE_ID=ATD.ATD_ATE_ID
              AND    PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
          --     AND    PLA.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
               AND    PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
               AND    BNF.CODCON = PLA.CAD_PLA_CD_PLANO_HAC
               AND    BNF.CODEST = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,0,3))
               AND    BNF.CODBEN = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,4,7))
               AND    BNF.CODSEQBEN = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,11,2))
               AND    ATD.ATD_ATE_ID = pATD_ATE_ID
               AND    TRUNC(ATD.ATD_ATE_DT_ATENDIMENTO)=TRUNC(PAT.ASS_PAT_DT_ENTRADA)
               AND    (CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01'
               OR CNV.CAD_CNV_CD_HAC_PRESTADOR = 'GG05')
               ) BENEF_ACS
        WHERE ATD.ATD_ATE_ID = pATD_ATE_ID
        AND  PAT.ATD_ATE_ID=ATD.ATD_ATE_ID
        AND    PAT.CAD_PAC_ID_PACIENTE=PAC.CAD_PAC_ID_PACIENTE
        AND    TRUNC(ATD.ATD_ATE_DT_ATENDIMENTO)=TRUNC(PAT.ASS_PAT_DT_ENTRADA)
        AND    ATD.TIS_CBO_CD_CBOS=CBO.TIS_CBO_CD_CBOS
       AND    PAC.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
     --   AND    PLA.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO
        AND    PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
        AND    PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
        AND    ATD.ATD_ATE_ID = BENEF_ACS.ATD_ATE_ID(+)
        AND    ATD.CAD_PRO_ID_PROF_EXEC=PRO.CAD_PRO_ID_PROFISSIONAL(+)
        AND    ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO=LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
        AND    ATD.CAD_UNI_ID_UNIDADE=UNI.CAD_UNI_ID_UNIDADE
        AND    ATD.CAD_SET_ID=SETOR.CAD_SET_ID
        AND    USU.SEG_USU_ID_USUARIO=ATD.SEG_USU_ID_USUARIO;
    END IF;
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
    ANOFAT,
    NR_SENHA_CHAMADA)
    VALUES
    ( v_cd_unid_hospitalar,
               v_nr_prontuario,
               v_cd_intamb,
               v_nm_pessoa,
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
               v_carater_solocit ,
               v_cid10,
               v_subproduto,
               pMES,
               pANO,
               v_senha_chamada);
      ELSE
      UPDATE  HOSPITAL.PACIENTE_ATENDIMENTO_AMB
     SET
    CODUNIHOS=v_cd_unid_hospitalar,
    CODPAC=v_nr_prontuario,
    NOMPAC=v_nm_pessoa,
--    DATATE= v_dt_atendimento,
 --   HORATE= v_hr_atendimento,
    HR_RECEP=v_hr_atendimento,
    LOCAL= v_cd_local_atendimento,
    CODAND= v_cd_andar,
    CODPADPAC = v_codpadateben,
    CODTIPATE = v_cd_tipo_ate_velho,
    CODMOTATEAMB = v_cd_mot_ate,
    SEXPAC= v_tp_sexo,
    NOMREGPAC=v_nm_usuario,
    CODESPMED=v_codespmed,
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
    CD_ID_ACIDENTE=v_cd_ind_acidente,
    NR_CNS=v_nr_cns,
 --   NR_CONS_PROF=v_nr_conselho_solic,
    NR_CONS_PROF=v_nr_conselho,
    DS_IND_CLINICA=v_ind_clinica,
    CD_TP_CARAT_ATEND=v_carater_solocit,
    CID=v_cid10,
    SUBPRODUTO=v_subproduto,
    MESFAT=pMES,
    ANOFAT=pANO,
    NR_SENHA_CHAMADA=v_senha_chamada
    WHERE CODSITATE='P'
    AND CODATEAMB=pATD_ATE_ID
    AND ((indemiconamb is null or indemiconamb='N')
         OR  (indfatamb is null or indfatamb='N'));
    UPDATE  HOSPITAL.PACIENTE_ATENDIMENTO_AMB
    SET NOMPAC=v_nm_pessoa,
 --   DATATE= v_dt_atendimento,
 --   HORATE= v_hr_atendimento,
    HR_RECEP=v_hr_atendimento,
    LOCAL= v_cd_local_atendimento,
    CODAND= v_cd_andar,
    CODPADPAC = v_codpadateben,
    CODTIPATE = v_cd_tipo_ate_velho,
    CODMOTATEAMB = v_cd_mot_ate,
    SEXPAC= v_tp_sexo,
    NOMREGPAC=v_nm_usuario,
    CODESPMED=v_codespmed,
    CODMED=v_nr_conselho,
    CODSITATE=v_cod_sit_ate,
    DATNASPAC=v_dt_nascimento,
    UF_CARIDE='AT',
    BENPRI=v_nm_titular,
    CODGRAPAR=v_codgrapar,
    NOMEMPPAC=null,
    CODCLI=v_cod_clinica,
    DIGCARIDE=v_codseqben,
    CODBEN=v_codben,
    CODEST= v_codest,
    NUMCRE=v_cd_credencial,
    TP_PLANO=v_nome_plano,
    DT_VALIDADE=v_dt_validade,
    CODTIPO=v_tipo_atendimento_tiss,
    OBS=v_obs,
    CARIDE=v_car_identidade,
    CD_ID_ACIDENTE=v_cd_ind_acidente,
    NR_CNS=v_nr_cns,
    NR_CONS_PROF=v_nr_conselho,
    DS_IND_CLINICA=v_ind_clinica,
    CD_TP_CARAT_ATEND=v_carater_solocit,
    CID=v_cid10,
    SUBPRODUTO=v_subproduto,
    MESFAT=pMES,
    ANOFAT=pANO
    WHERE CODATEAMB=pATD_ATE_ID
    AND CODSITATE IN ('A','C','D')
    AND CODTIPATE not in (3,12,13,22) 
    AND ((indemiconamb is null or indemiconamb='N')
         OR  (indfatamb is null or indfatamb='N'));
    UPDATE PACIENTE_ATENDIMENTO_AMB
    SET DATATE= v_dt_atendimento,
    HORATE= v_hr_atendimento,
    NR_CONS_PROF=v_nr_conselho_solic,
    CODTIPATE = v_cd_tipo_ate_velho,
    NOMPAC=v_nm_pessoa,
    HR_RECEP=v_hr_atendimento,
    LOCAL= v_cd_local_atendimento,
  --  CODPAC=v_nr_prontuario,
    CODAND= v_cd_andar,
    CODPADPAC = v_codpadateben,
    CODMOTATEAMB = v_cd_mot_ate,
    SEXPAC= v_tp_sexo,
    NOMREGPAC=v_nm_usuario,
    CODSITATE=v_cod_sit_ate,
    DATNASPAC=v_dt_nascimento,
    UF_CARIDE='AT',
    BENPRI=v_nm_titular,
    CODGRAPAR=v_codgrapar,
    NOMEMPPAC=null,
    CODCLI=v_cod_clinica,
    DIGCARIDE=v_codseqben,
    CODBEN=v_codben,
    CODEST= v_codest,
    NUMCRE=v_cd_credencial,
    TP_PLANO=v_nome_plano,
    DT_VALIDADE=v_dt_validade,
    CODTIPO=v_tipo_atendimento_tiss,
    OBS=v_obs,
    CARIDE=v_car_identidade,
    CD_ID_ACIDENTE=v_cd_ind_acidente,
    NR_CNS=v_nr_cns,
    DS_IND_CLINICA=v_ind_clinica,
    CD_TP_CARAT_ATEND=v_carater_solocit,
    CID=v_cid10,
    SUBPRODUTO=v_subproduto,
    MESFAT=pMES,
    ANOFAT=pANO
    WHERE CODATEAMB=pATD_ATE_ID
    AND CODTIPATE in (3,12,13,22)
    AND ((indemiconamb is null or indemiconamb='N')
         OR  (indfatamb is null or indfatamb='N'));
     UPDATE PACIENTE_ATENDIMENTO_AMB SET CODESPMED=v_codespmed,
     CODMED=v_nr_conselho
    WHERE
    CODATEAMB=pATD_ATE_ID
    AND (v_codespmed='GIN' OR v_setor='COLP')
    AND CODTIPATE in (3,12,13,22)
    AND ((indemiconamb is null or indemiconamb='N')
         OR  (indfatamb is null or indfatamb='N'));
    UPDATE PACIENTE_ATENDIMENTO_AMB SET CODESPMED=v_codespmed,
    CODMED=v_nr_conselho
    WHERE CODATEAMB=pATD_ATE_ID
    AND ( v_codespmed IN ('ENP','ENG','GAS') OR  v_setor='ENDO')
    AND CODTIPATE in (3,12,13,22,30)
    AND ((indemiconamb is null or indemiconamb='N')
         OR  (indfatamb is null or indfatamb='N'));
    UPDATE PACIENTE_ATENDIMENTO_AMB
     SET CODCON=v_cd_convenio_leg,
    CODPAC=v_nr_prontuario    
    WHERE CODATEAMB=pATD_ATE_ID AND
    CODSITATE IN ('A','P')
     AND ((indemiconamb is null or indemiconamb='N')
         OR  (indfatamb is null or indfatamb='N'));
    update paciente_atendimento_amb 
     set datate = v_dt_atendimento  ,
       horate = v_hr_atendimento 
     where codateamb = pATD_ATE_ID
     and not exists(select agd.age_agd_cd_intamb from tb_age_agd_agenda agd
where agd.age_agd_cd_intamb = pATD_ATE_ID )
AND CODSITATE ='A'
AND ((indemiconamb is null or indemiconamb='N')
         OR  (indfatamb is null or indfatamb='N'));       
    END IF;
  EXCEPTION
  WHEN ex_atendimentoinexistente THEN
       raise_application_error('-20000', 'Atendimento Inexistente');
  WHEN OTHERS THEN
       v_error_code := SQLCODE;
       v_error_message := SQLERRM;
       raise_application_error(v_error_code, v_error_message);
end PRC_LEG_ATU_ATEAMB_I;
