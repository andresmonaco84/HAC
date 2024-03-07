create or replace procedure PRC_LEG_ATU_PARC_INT(pFAT_CCP_ID IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%TYPE,
                                                 pATD_ATE_ID IN TB_FAT_CCP_CONTA_CONS_PARC.ATD_ATE_ID%TYPE) is
/**************************************************************************************
* Procedure: PRC_LEG_ATU_PARC_INT
* Data Criacao:  19/07/2010   Por: RAMIRO
* Funcao: INCLUIR AS PARCELAS DO SGS NA TABELA DO LEGADO HOSPITAL.TB_INTERNADO_PARCELA
***************************************************************************************/

  v_contador              number;
  ex_atendinexistente     exception;
  v_dt_int                date;
  v_dt_alta               date; 
  v_hr_alta               varchar2(4);
  v_fl_faturada           char(1);  
  v_cd_unid_hospitalar    number;    

BEGIN

  SELECT COUNT(*)
    INTO v_contador
    FROM TB_FAT_CCP_CONTA_CONS_PARC PARC
   WHERE PARC.FAT_CCP_ID = pFAT_CCP_ID
     AND PARC.ATD_ATE_ID = pATD_ATE_ID;

  IF v_contador = 0 THEN
    raise ex_atendinexistente;

  ELSE
    SELECT DECODE(pFAT_CCP_ID, 
                  1, ATD.ATD_ATE_DT_ATENDIMENTO, 
                 (SELECT PARC2.FAT_CCP_DT_PARCELA 
                    FROM TB_FAT_CCP_CONTA_CONS_PARC PARC2 
                   WHERE PARC2.FAT_CCP_ID = pFAT_CCP_ID - 1
                     AND PARC2.ATD_ATE_ID = pATD_ATE_ID)) "DT_INT",
           PARC.FAT_CCP_DT_PARCELA "DT_ALTA",
           PARC.FAT_CCP_HR_PARCELA "HORA_ALTA",
           PARC.FAT_CCP_FL_FATURADA "FATURADO",
           TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR, '99') "CODUNIHOS"
      INTO v_dt_int,
           v_dt_alta, 
           v_hr_alta,
           v_fl_faturada,
           v_cd_unid_hospitalar              
      FROM TB_FAT_CCP_CONTA_CONS_PARC PARC,
           TB_ATD_ATE_ATENDIMENTO ATD,
           TB_CAD_UNI_UNIDADE UNI
     WHERE PARC.FAT_CCP_ID = pFAT_CCP_ID
       AND ATD.ATD_ATE_ID = pATD_ATE_ID
       AND PARC.ATD_ATE_ID = ATD.ATD_ATE_ID
       AND ATD.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE;
  END IF;

  SELECT COUNT(*)
    INTO v_contador
    FROM HOSPITAL.TB_INTERNADO_PARCELA
   WHERE TP_COBRANCA = TO_CHAR(pFAT_CCP_ID)
     AND NR_SEQINTER = pATD_ATE_ID;

  IF v_contador = 0 THEN
    INSERT INTO HOSPITAL.TB_INTERNADO_PARCELA
      (NR_SEQINTER,
       TP_COBRANCA,
       DT_INT,
       DT_ALTA,
       HORA_ALTA,
       FATURADO,
       CODUNIHOS,
       NR_PARCELA)
    values
      (pATD_ATE_ID,
       TO_CHAR(pFAT_CCP_ID),
       v_dt_int,
       v_dt_alta,
       v_hr_alta,
       v_fl_faturada,
       v_cd_unid_hospitalar,
       TO_CHAR(pFAT_CCP_ID));
  ELSE
    UPDATE HOSPITAL.TB_INTERNADO_PARCELA
       SET DT_ALTA = v_dt_alta,
           HORA_ALTA = v_hr_alta,
           FATURADO = v_fl_faturada
     WHERE TP_COBRANCA = TO_CHAR(pFAT_CCP_ID)
       AND NR_SEQINTER = pATD_ATE_ID;
  END IF;
.
END PRC_LEG_ATU_PARC_INT;