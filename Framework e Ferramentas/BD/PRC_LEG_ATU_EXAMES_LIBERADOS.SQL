create or replace procedure PRC_LEG_ATU_EXAMES_LIBERADOS
(
 pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE
)
is
  /********************************************************************
  *    Procedure: PRC_LEG_ATU_EXAMES_LIBERADOS
  *
  *    Data Criacao:  27/02/2008   Por: SILMARA
  *    Data alterac?o: 20/05/2008  Por: SILMARA
  *    Data Alteracao: 01/09/2008  Por: Andrea Cazuca
  *    Data Alterac?o: 09/09/2008  Por: Silmara 
  *    Alteracao: Quando n?o existir item na pap e existir na paciente_atendimento_amb
  *               excluir da paciente_atendimento_amb e da tb_req_exames_liberados
  *   Alterac?o: Alterar para cancelar o atendimento e n?o excluir 
  *
  *    Funcao: incluir as informac?es na tabela TB_REQ_EXAMES_LIBERADOS
  *
  *******************************************************************/
    v_contador                   number;
    v_contador1                  number;
    v_cd_unid_hospitalar         number;
    v_cd_intamb                  number;
    v_nr_prontuario              number;
    v_cd_andar                   number;
    v_error_code                 number;
    v_error_message              varchar2(900);
    ex_atendimentoinexistente    exception;
  begin
    SELECT    COUNT(*)
    INTO      v_contador
    FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP
    WHERE     PAP.ATD_ATE_ID = pATD_ATE_ID
    AND    PAP.ASS_PAP_FL_ORIGEM='L'
    AND    PAP.ASS_PAP_FL_STATUS_AUTOR='A';
    IF v_contador = 0 THEN
       SELECT COUNT(*)
       INTO   v_contador1
       FROM   PACIENTE_ATENDIMENTO_AMB
       WHERE  CODATEAMB = pATD_ATE_ID;
       
       IF v_contador1 = 0 THEN
          raise ex_atendimentoinexistente;
       ELSE
          DELETE TB_REQ_EXAMES_LIBERADOS WHERE CODATEAMB = pATD_ATE_ID 
           ;
          UPDATE PACIENTE_ATENDIMENTO_AMB SET CODSITATE='C'
          WHERE CODATEAMB = pATD_ATE_ID
          AND  NOT EXISTS(select ATD.ATD_ATE_ID FROM TB_ATD_ATE_ATENDIMENTO ATD 
                           WHERE ATD.ATD_ATE_ID= pATD_ATE_ID);
       END IF;
    ELSE
       SELECT DISTINCT
       CASE WHEN TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR,'99') = 27 AND PLA.CAD_PLA_CD_TIPOPLANO='SP'
              THEN 5
         ELSE TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR,'99')
         END,
               decode(PAC.CAD_PAC_NR_PRONTUARIO,NULL,7,PAC.CAD_PAC_NR_PRONTUARIO),
               PAP.ATD_ATE_ID,
               1
               INTO
               v_cd_unid_hospitalar,
               v_nr_prontuario,
               v_cd_intamb,
               v_cd_andar
        FROM
              TB_ASS_PAP_PAC_ATEN_PROC PAP,
               TB_CAD_UNI_UNIDADE UNI,
               TB_CAD_PAC_PACIENTE PAC,
               TB_CAD_PLA_PLANO PLA
        WHERE PAP.ATD_ATE_ID = pATD_ATE_ID
        AND    PAP.CAD_UNI_ID_UNIDADE=UNI.CAD_UNI_ID_UNIDADE
        AND    PAP.ASS_PAP_FL_ORIGEM='L'
        AND    PAP.ASS_PAP_FL_STATUS_AUTOR='A'
        AND    PAP.CAD_PAC_ID_PACIENTE=PAC.CAD_PAC_ID_PACIENTE
        AND    PAC.CAD_CNV_ID_CONVENIO=PLA.CAD_CNV_ID_CONVENIO
        AND    PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO;
    END IF;
    IF v_contador <> 0 THEN
       SELECT COUNT(*)
       INTO  v_contador
       FROM HOSPITAL.TB_REQ_EXAMES_LIBERADOS
       WHERE CODATEAMB=pATD_ATE_ID;
       
       IF v_contador = 0 THEN
          INSERT INTO HOSPITAL.TB_REQ_EXAMES_LIBERADOS
          (CODUNIHOS,
          CODPAC,
          CODATEAMB,
          andar_liberado,
          DATA_LIBERACAO)
          VALUES
          (v_cd_unid_hospitalar,
          v_nr_prontuario,
          v_cd_intamb,
          v_cd_andar,
          TRUNC(SYSDATE));
       ELSE
          UPDATE HOSPITAL.TB_REQ_EXAMES_LIBERADOS
             SET CODUNIHOS=v_cd_unid_hospitalar,
                 andar_liberado=v_cd_andar,
                 DATA_LIBERACAO=TRUNC(SYSDATE)
          WHERE CODATEAMB = pATD_ATE_ID;
       END IF;
    END IF;
  EXCEPTION
  WHEN ex_atendimentoinexistente THEN
       raise_application_error('-20000', 'Atendimento Inexistente');
  WHEN OTHERS THEN
       v_error_code := SQLCODE;
       v_error_message := SQLERRM;
       raise_application_error(v_error_code, v_error_message);
end PRC_LEG_ATU_EXAMES_LIBERADOS;