CREATE OR REPLACE PROCEDURE "PRC_LEG_ATU_ALTA_INT" (pATD_ATE_ID IN TB_ATD_INA_INT_ALTA.ATD_ATE_ID%TYPE) is
/*************************************************************************
* Procedure: PRC_LEG_ATU_ALTA_INT
* Data Criacao:  19/07/2010   Por: RAMIRO
* Funcao: ATUALIZAR ALTA DO SGS NA TABELA DO LEGADO HOSPITAL.TB_INTERNADO
**************************************************************************/

  v_contador              number;
  ex_atendinexistente     exception;
  v_cd_alta               number;
  v_dt_alta               date;
  v_hr_alta               varchar2(4);
  v_nr_conselho           number;
  v_id_usuario            number;
  v_dt_transacao          date;
  v_tp_transacao          char(1);
  v_local                 number;
  
BEGIN

  SELECT COUNT(*)
    INTO v_contador
    FROM TB_ATD_INA_INT_ALTA
   WHERE ATD_ATE_ID = pATD_ATE_ID;

  IF v_contador = 0 THEN
    raise ex_atendinexistente;

  ELSE
    SELECT DISTINCT
           CASE WHEN ((ATD.ATD_ATE_DT_ATENDIMENTO - ALT.ATD_INA_DT_ALTA_ADM) > 2 AND (TIS.TIS_MSI_CD_TIPOALTA = 4)) THEN
                  53
                WHEN ((ATD.ATD_ATE_DT_ATENDIMENTO - ALT.ATD_INA_DT_ALTA_ADM) <= 2 AND (TIS.TIS_MSI_CD_TIPOALTA = 4.)) THEN
                  52
                WHEN (LEG.CD_ALTA IS NULL) THEN
                  12
                ELSE LEG.CD_ALTA
                END "CD_ALTA",
           ALT.ATD_INA_DT_ALTA_ADM "DT_ALTA",
           ALT.ATD_INA_HR_ALTA_ADM "HORA_ALTA",
           TRIM(PRO.CAD_PRO_NR_CONSELHO)"CRM_ALTA",
           ALT.SEG_USU_ID_USUARIO_ALTA "CD_MATRICULA_ALTA",
           SYSDATE "DT_TRANSACAO",
           'A' "TP_TRANSACAO",
           ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO

      INTO v_cd_alta,
           v_dt_alta,
           v_hr_alta,
           v_nr_conselho,
           v_id_usuario,
           v_dt_transacao,
           v_tp_transacao,
           v_local
      FROM TB_ATD_INA_INT_ALTA ALT,
           TB_CAD_PRO_PROFISSIONAL PRO,
           TB_ATD_ATE_ATENDIMENTO ATD,
           TB_TIS_MSI_MOTIVO_SAIDA_INT TIS,
           HOSPITAL.TB_ALTA LEG
     WHERE ALT.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL(+)
       AND ALT.ATD_ATE_ID = ATD.ATD_ATE_ID
       AND ALT.TIS_MSI_CD_MOTIVOSAIDAINT = TIS.TIS_MSI_CD_MOTIVOSAIDAINT(+)
       AND TIS.TIS_MSI_CD_MOTIVOSAIDAINT = LEG.CD_MOT_SAIDA_INT(+)
       AND ALT.ATD_ATE_ID = pATD_ATE_ID;

  END IF;


  SELECT COUNT(*)
    INTO v_contador
    FROM HOSPITAL.TB_INTERNADO
   WHERE NR_SEQINTER = pATD_ATE_ID;


  IF v_contador > 0 THEN
    UPDATE HOSPITAL.TB_INTERNADO
       SET CD_ALTA = v_cd_alta,
           DT_ALTA = v_dt_alta,
           HORA_ALTA = v_hr_alta,
           CRM_ALTA = v_nr_conselho,
           CD_MATRICULA_ALTA = v_id_usuario,
           DT_TRANSACAO = v_dt_transacao,
           TP_TRANSACAO = v_tp_transacao
     WHERE NR_SEQINTER = pATD_ATE_ID;


    UPDATE HOSPITAL.TB_INTERNADO_PARCELA
       SET DT_ALTA = v_dt_alta,
           HORA_ALTA = v_hr_alta
     WHERE NR_SEQINTER = pATD_ATE_ID
       AND DT_ALTA IS NULL;


  END IF;

  
  
  IF V_LOCAL = 46 THEN --HOME CARE
    
      SELECT COUNT(*)
        INTO v_contador
        FROM HOSPITAL.TB_TRANSFERENCIA
       WHERE NR_SEQINTER = pATD_ATE_ID;

         
      IF v_contador > 0 THEN       
           
        UPDATE HOSPITAL.TB_TRANSFERENCIA
           SET DT_SAIDA     = v_dt_alta,
               HORA_SAIDA   = v_hr_alta,
               CD_MATRICULA = v_id_usuario,
               DT_TRANSACAO = v_dt_transacao,
               TP_TRANSACAO = v_tp_transacao,
               IN_CANCELADO = decode(v_cd_alta, 1000, 'C', 'A')
         WHERE NR_SEQINTER  = pATD_ATE_ID ;

      END IF;

    END IF;

  
  
  end;
 
