create or replace procedure PRC_LEG_ATU_GUIA_ATEDIMENTO
(
   pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE,
   pATD_GUI_CD_CODIGO IN TB_ATD_GUI_GUIAATEND.ATD_GUI_CD_CODIGO%TYPE,
   pATD_GUI_CD_SENHA IN  TB_ATD_GUI_GUIAATEND.ATD_GUI_CD_SENHA%TYPE
)
is
  /********************************************************************
  *    Procedure: PRC_LEG_ATU_GUIA_ATEDIMENTO
  *
  *    Data Criacao:  28/02/2008   Por: SILMARA
  *    Funcao: incluir as informac?es na tabela GUIA_ATENDIMENTO_AMB
  *
  *    Data Alterac?o: 20/03/2008  Por: Andrea Cazuca
  *    Atualizac?o: Foi incluido o codigo da guia como parametro
  *
  *    Data Alterac?o: 21/06/2008  Por: SILMARA
  *    Atualizac?o: Foi incluido o codigo da SENHA como parametro
  *
  *******************************************************************/
    v_contador                   number;
    v_cont                       number;
    v_cd_unid_hospitalar         number;
--    v_cd_intamb                  number;
    v_nr_prontuario              number;
--    v_cd_guia                    varchar2(15);
    v_error_code                 number;
    v_error_message              varchar2(900);
    ex_atendimentoinexistente    exception;
  begin
      SELECT    COUNT(*)
      INTO      v_contador
      FROM      TB_ATD_ATE_ATENDIMENTO ATD, TB_ATD_GUI_GUIAATEND GUI
      WHERE     ATD.ATD_ATE_ID = pATD_ATE_ID
      AND       ATD.ATD_ATE_ID = GUI.ATD_ATE_ID
      AND       GUI.ATD_GUI_CD_CODIGO = pATD_GUI_CD_CODIGO;
      IF v_contador = 0 THEN
          raise ex_atendimentoinexistente;
      ELSE 
         SELECT 
               TO_NUMBER(UNI.CAD_UNI_CD_UNID_HOSPITALAR,'99') ,
               decode(PAC.CAD_PAC_NR_PRONTUARIO,null,7,PAC.CAD_PAC_NR_PRONTUARIO)
          INTO   v_cd_unid_hospitalar,
                 v_nr_prontuario
          FROM
                 Tb_Atd_Ate_Atendimento atd,
                 TB_CAD_UNI_UNIDADE UNI,
                 TB_CAD_PAC_PACIENTE PAC,
                 TB_ATD_GUI_GUIAATEND GUI,
                 TB_ASS_PAT_PACIEATEND PAT,
                 TB_CAD_PLA_PLANO PLA
          WHERE  ATD.ATD_ATE_ID = pATD_ATE_ID
          AND    ATD.ATD_ATE_ID = GUI.ATD_ATE_ID
          AND    GUI.ATD_GUI_CD_CODIGO = pATD_GUI_CD_CODIGO
          AND    ATD.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
          AND    ATD.ATD_ATE_ID = PAT.ATD_ATE_ID
          AND    PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
          AND   PAC.CAD_CNV_ID_CONVENIO=PLA.CAD_CNV_ID_CONVENIO
          AND   PAC.CAD_PLA_ID_PLANO=PLA.CAD_PLA_ID_PLANO;
      END IF;
      SELECT COUNT(*)
      INTO   v_cont
      FROM   HOSPITAL.guia_atendimento_amb
      WHERE  CODATEAMB = pATD_ATE_ID
      AND    NR_GUIA = pATD_GUI_CD_CODIGO;
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
         pATD_GUI_CD_CODIGO);
      ELSE
         UPDATE HOSPITAL.GUIA_ATENDIMENTO_AMB
            SET CODUNIHOS = v_cd_unid_hospitalar,
                CODPAC = v_nr_prontuario,
                nr_guia = pATD_GUI_CD_CODIGO
          WHERE CODATEAMB = pATD_ATE_ID;
      END IF;
   IF pATD_GUI_CD_SENHA IS NOT NULL THEN
      UPDATE PACIENTE_ATENDIMENTO_AMB SET SENHA = pATD_GUI_CD_SENHA
      WHERE CODATEAMB = pATD_ATE_ID;
   END IF;
  EXCEPTION
  WHEN ex_atendimentoinexistente THEN
       raise_application_error('-20000', 'Guia Inexistente');
  WHEN OTHERS THEN
       v_error_code := SQLCODE;
       v_error_message := SQLERRM;
       raise_application_error(v_error_code, v_error_message);
end PRC_LEG_ATU_GUIA_ATEDIMENTO;
