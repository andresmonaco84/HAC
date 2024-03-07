CREATE OR REPLACE PROCEDURE "PRC_LEG_ATU_GUIA_LIB" (
   pATD_ATE_ID IN TB_ASS_PAP_PAC_ATEN_PROC.ATD_ATE_ID%TYPE,
   pATD_GUI_CD_CODIGO IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ATE_GUI_CD_CODIGO%TYPE,
   pATD_GUI_CD_SENHA IN  TB_ASS_PPG_PAC_ATE_PROC_GUIA.ASS_PPG_CD_SENHA%TYPE
)
is
  /********************************************************************
  *    Procedure: PRC_LEG_ATU_GUIA_LIB
  *
  *    Data Criacao:  17/07/2008   Por: SILMARA
  *    Funcao: incluir as informações na tabela GUIA_ATENDIMENTO_AMB
  *
  *******************************************************************/
    v_contador                   number;
    v_cont                       number;
    v_cd_unid_hospitalar         number;
    v_nr_prontuario              number;
    v_error_code                 number;
    v_error_message              varchar2(900);
    ex_atendimentoinexistente    exception;
  begin
      SELECT    COUNT(*)
      INTO      v_contador
      FROM      TB_ASS_PAP_PAC_ATEN_PROC PAP ,
                TB_ASS_PPG_PAC_ATE_PROC_GUIA PPG
      WHERE     PAP.ATD_ATE_ID = pATD_ATE_ID
      AND       PAP.ATD_ATE_ID= PPG.ATD_ATE_ID
      AND       PPG.ATE_GUI_CD_CODIGO = pATD_GUI_CD_CODIGO;
      IF v_contador = 0 THEN
          raise ex_atendimentoinexistente;
      ELSE
             SELECT  distinct  TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR,'99') ,
         decode(PAC.CAD_PAC_NR_PRONTUARIO,null,7,PAC.CAD_PAC_NR_PRONTUARIO)
          INTO  
          v_cd_unid_hospitalar,
          v_nr_prontuario
          FROM
                 TB_ASS_PAP_PAC_ATEN_PROC PAP,
                 TB_CAD_UNI_UNIDADE UNI,
                 TB_CAD_PAC_PACIENTE PAC,
                 TB_ASS_PPG_PAC_ATE_PROC_GUIA PPG,
                 TB_CAD_PLA_PLANO PLA
          WHERE  PAP.ATD_ATE_ID = pATD_ATE_ID
          AND    PAP.ATD_ATE_ID = PPG.ATD_ATE_ID
          AND    PPG.ATE_GUI_CD_CODIGO = pATD_GUI_CD_CODIGO
          AND    PAP.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
          AND    PAP.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE 
          AND    PAC.CAD_CNV_ID_CONVENIO=PLA.CAD_CNV_ID_CONVENIO
          AND    PAC.CAD_PLA_ID_PLANO=PLA.CAD_PLA_ID_PLANO;
      END IF;
      SELECT COUNT(*)
      INTO   v_cont
      FROM   HOSPITAL.guia_atendimento_amb
      WHERE  CODATEAMB = pATD_ATE_ID
      AND   NR_GUIA = substr(pATD_GUI_CD_CODIGO,0,15);
      IF v_cont = 0 THEN
        INSERT INTO HOSPITAL.GUIA_ATENDIMENTO_AMB
        (CODUNIHOS,
        CODPAC,
        CODATEAMB,
        NR_GUIA)
        VALUES
        (v_cd_unid_hospitalar,
         v_nr_prontuario,
         pATD_ATE_ID,
         substr(pATD_GUI_CD_CODIGO,0,15));
      ELSE
         UPDATE HOSPITAL.GUIA_ATENDIMENTO_AMB
            SET CODUNIHOS = v_cd_unid_hospitalar,
                CODPAC = v_nr_prontuario,
                nr_guia = substr(pATD_GUI_CD_CODIGO,0,15)
          WHERE CODATEAMB = pATD_ATE_ID;
      END IF;
   IF pATD_GUI_CD_SENHA IS NOT NULL THEN
      UPDATE PACIENTE_ATENDIMENTO_AMB SET SENHA = substr(pATD_GUI_CD_SENHA,0,20)
      WHERE CODATEAMB = pATD_ATE_ID;
   END IF;
  EXCEPTION
  WHEN ex_atendimentoinexistente THEN
       raise_application_error('-20000', 'Guia Inexistente');
  WHEN OTHERS THEN
       v_error_code := SQLCODE;
       v_error_message := SQLERRM;
       raise_application_error(v_error_code, v_error_message);
end PRC_LEG_ATU_GUIA_LIB;