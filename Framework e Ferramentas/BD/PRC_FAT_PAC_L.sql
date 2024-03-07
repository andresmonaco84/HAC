CREATE OR REPLACE PROCEDURE PRC_FAT_PAC_L
 (
        pCAD_UNI_ID_UNIDADE           IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
        pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
        pCAD_SET_ID                   IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
        pATD_ATE_ID                   IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
        pCAD_CNV_ID_CONVENIO          IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
        pCAD_PLA_ID_PLANO             IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
        pCAD_PAC_NR_PRONTUARIO        IN TB_CAD_PAC_PACIENTE.CAD_PAC_NR_PRONTUARIO%TYPE DEFAULT NULL,
        pCAD_PAC_CD_CREDENCIAL        IN TB_CAD_PAC_PACIENTE.CAD_PAC_CD_CREDENCIAL%TYPE DEFAULT NULL,
        pCAD_PES_NM_PESSOA            IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%TYPE DEFAULT NULL,
        pCAD_PES_DT_NASCIMENTO        IN TB_CAD_PES_PESSOA.CAD_PES_DT_NASCIMENTO%TYPE DEFAULT NULL,
        io_cursor                     OUT PKG_CURSOR.t_cursor
)
IS
/********************************************************************
*    Procedure: PRC_FAT_PAC_L
*
*    Data Alteracao: 13/6/2011  Por: Pedro
*    Altera??o: retirando a funcao e passando pra v_select
*
*
*******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(2000);
  V_SELECT  varchar2(6000);
begin
  V_WHERE := NULL;
  IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND PAC.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO; END IF;
  IF pCAD_PLA_ID_PLANO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND PAC.CAD_PLA_ID_PLANO = ' || pCAD_PLA_ID_PLANO; END IF;
  IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
  IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO; END IF;
  IF pCAD_SET_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD.CAD_SET_ID = ' || pCAD_SET_ID; END IF;
  IF pATD_ATE_ID IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD.ATD_ATE_ID = ' || pATD_ATE_ID; END IF;
  IF pCAD_PAC_NR_PRONTUARIO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND PAC.CAD_PAC_NR_PRONTUARIO = ' || pCAD_PAC_NR_PRONTUARIO; END IF;
  IF pCAD_PAC_CD_CREDENCIAL IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND PAC.CAD_PAC_CD_CREDENCIAL = ' || CHR(39) || pCAD_PAC_CD_CREDENCIAL || CHR(39); END IF;
  IF pCAD_PES_NM_PESSOA IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND PES.CAD_PES_NM_PESSOA LIKE ' || CHR(39) || pCAD_PES_NM_PESSOA || CHR(39); END IF;
  IF pCAD_PES_DT_NASCIMENTO IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND PES.CAD_PES_DT_NASCIMENTO = ' || CHR(39) || pCAD_PES_DT_NASCIMENTO || CHR(39); END IF;
   V_SELECT := '
 SELECT    CNV.CAD_CNV_CD_HAC_PRESTADOR,
           PLA.CAD_PLA_CD_PLANO_HAC,
           PAC.CAD_PAC_CD_CREDENCIAL,
           PAC.CAD_PAC_NR_PRONTUARIO,
           PES.CAD_PES_NM_PESSOA,
           TRUNC(PES.CAD_PES_DT_NASCIMENTO) CAD_PES_DT_NASCIMENTO,
           PRO.CAD_PRO_NM_NOME,
           CBOS.TIS_CBO_DS_CBOS_HAC,
           TAT.TIS_TAT_DS_TPATENDIMENTO,
           ATD.ATD_ATE_FL_STATUS,
           decode(ATD.ATD_ATE_TP_PACIENTE,' || CHR(39) ||'A' || CHR(39) ||',' || CHR(39) ||'AMBULATORIO' || CHR(39) ||',' || CHR(39) ||'U' || CHR(39) ||',' || CHR(39) ||'URGENCIA' || CHR(39) ||',' || CHR(39) ||'I' || CHR(39) ||',' || CHR(39) ||'INTERNADO' || CHR(39) ||',' || CHR(39) ||'E' || CHR(39) ||',' || CHR(39) ||'EXTERNO' || CHR(39) ||') ATD_ATE_TP_PACIENTE,
           ATD.ATD_ATE_ID,
           ATD.ATD_ATE_FL_RETORNO_OK,
           TRUNC(ATD.ATD_ATE_DT_ATENDIMENTO) ATD_ATE_DT_ATENDIMENTO,
           TRUNC(INA.ATD_INA_DT_ALTA_ADM) ATD_INA_DT_ALTA_ADM,
           UNI.CAD_UNI_DS_UNIDADE,
           LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
           CASE WHEN ATD.ATD_ATE_TP_PACIENTE = ' || CHR(39) ||'I' || CHR(39) ||' THEN SETOR.CAD_SET_DS_SETOR
                ELSE SETO.CAD_SET_DS_SETOR
           END CAD_SET_DS_SETOR,
           IML_QLE.CAD_QLE_NR_QUARTO,
           IML_QLE.CAD_QLE_NR_LEITO,
           CASE WHEN ATD.ATD_ATE_FL_PRONT_ELETR_ATIVO ='||chr(39)||'S'||chr(39)||' THEN '||chr(39)||'Sim'||chr(39)||' ELSE '||chr(39)||'Nao'||chr(39)||' END ATD_ATE_FL_PRONT_ELETR_ATIVO,
           ATD.ATD_ATE_DS_OBSERVACAO 
       FROM
                     TB_ATD_ATE_ATENDIMENTO    ATD
      JOIN          TB_ASS_PAT_PACIEATEND     PAT      ON            PAT.ATD_ATE_ID          = ATD.ATD_ATE_ID
      JOIN          TB_CAD_PAC_PACIENTE       PAC      ON            PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
      JOIN          TB_CAD_PES_PESSOA         PES      ON            PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
      JOIN          TB_CAD_CNV_CONVENIO       CNV      ON            CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
      JOIN          TB_CAD_PLA_PLANO          PLA      ON            PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
      LEFT JOIN     TB_ATD_INA_INT_ALTA       INA      ON            INA.ATD_ATE_ID          = ATD.ATD_ATE_ID
      JOIN          TB_TIS_CBO_CBOS           CBOS     ON            CBOS.TIS_CBO_CD_CBOS    = ATD.TIS_CBO_CD_CBOS
      LEFT JOIN          TB_CAD_PRO_PROFISSIONAL   PRO      ON            ATD.CAD_PRO_ID_PROF_EXEC = PRO.CAD_PRO_ID_PROFISSIONAL
      JOIN          TB_TIS_TAT_TP_ATENDIMENTO TAT      ON            TAT.TIS_TAT_CD_TPATENDIMENTO = ATD.TIS_TAT_CD_TPATENDIMENTO
      LEFT JOIN  (    SELECT   QLE.CAD_QLE_ID, QLE.CAD_SET_ID , QLE.CAD_QLE_NR_QUARTO, QLE.CAD_QLE_NR_LEITO,
                          IML.ATD_ATE_ID, QLE.TIS_TAC_CD_TIPO_ACOMODACAO, QLE.CAD_QLE_TP_QUARTO_LEITO ,
                          IML.ATD_IML_DT_ENTRADA, IML.ATD_IML_HR_ENTRADA,iml.ATD_IML_ID, IML.ATD_IML_DT_SAIDA
                       FROM      TB_ATD_IML_INT_MOV_LEITO IML
                       LEFT JOIN TB_CAD_QLE_QUARTO_LEITO QLE
                       ON        QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                       JOIN      TB_ATD_ATE_ATENDIMENTO ATD2
                       ON        ATD2.ATD_ATE_ID = IML.ATD_ATE_ID
                       WHERE       FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) =
                                         (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML3.ATD_IML_DT_ENTRADA,IML3.ATD_IML_HR_ENTRADA)) FROM TB_ATD_IML_INT_MOV_LEITO IML3
                                                       WHERE IML3.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IML3.ATD_IML_FL_STATUS =  ' || CHR(39) ||'A' || CHR(39) ||')
              )  IML_QLE
      ON      IML_QLE.ATD_ATE_ID      = ATD.ATD_ATE_ID
      JOIN          TB_CAD_UNI_UNIDADE           UNI   ON            UNI.CAD_UNI_ID_UNIDADE  = ATD.CAD_UNI_ID_UNIDADE
      JOIN          TB_CAD_LAT_LOCAL_ATENDIMENTO LAT   ON            LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
      LEFT JOIN     TB_CAD_SET_SETOR             SETOR ON            IML_QLE.CAD_SET_ID      = SETOR.CAD_SET_ID
      JOIN          TB_CAD_SET_SETOR             SETO  ON            ATD.CAD_SET_ID      = SETO.CAD_SET_ID
     WHERE (ATD.ATD_ATE_FL_STATUS = ' || CHR(39) ||'A' || CHR(39) ||')
       '
  ;
  OPEN v_cursor FOR
  V_SELECT || V_WHERE ;
  io_cursor := v_cursor;
END PRC_FAT_PAC_L;

