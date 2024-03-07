create or replace procedure PRC_CAD_CNV_CONVENIO_S(pCAD_CNV_ID_CONVENIO      IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
                                                   pCAD_CNV_CD_HAC_PRESTADOR IN TB_CAD_CNV_CONVENIO.CAD_CNV_CD_HAC_PRESTADOR%type DEFAULT NULL,
                                                   pCAD_PES_NR_CNPJ_CPF      IN TB_CAD_PES_PESSOA.CAD_PES_NR_CNPJ_CPF%type DEFAULT NULL,
                                                   pCAD_PES_NM_RAZAOSOCIAL   IN TB_CAD_PES_PESSOA.CAD_PES_NM_RAZAOSOCIAL%type DEFAULT NULL,
                                                   pCAD_PES_NM_PESSOA        IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%type DEFAULT NULL,
                                                   pCAD_CNV_FL_STATUS        IN TB_CAD_CNV_CONVENIO.CAD_CNV_FL_STATUS%type DEFAULT NULL,
                                                   io_cursor                 OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_CAD_CNV_CONVENIO_S
  *
  *   Data Alteracao: 04/11/2010  Por: André Souza Monaco
  *   Alteracao: Inclusao dos campos CAD_CNV_FL_VALIDA_SUBPLANOCRE,
  *                                  CAD_CNV_NR_INISUBPLANOCRE e,
  *                                  CAD_CNV_NR_FIMSUBPLANOCRE (tarefa 11787)
  *
  *   Data Alteracao: 16/11/2010  Por: pedro
  *   Alteracao: Inclusao do campo CAD_CNV_FL_EXIGE_VALIDA_CRED e mudança do formato da proc
  *                                  
  *   Data Alteracao: 08/02/2011  Por: Davi Silvestre M. dos Reis
  *   Alteracao: Inclusao do campo CAD_CNV_FL_UTILIZAEQUIVALE
  *                                  
  *    Data Alteracao: 23/08/2011   Por: Fabiola
  *    Alteração: Inclusão do campo CAD_TPE_CD_CODIGO
  *   Data Alteracao: 03/12/2012  Por: Eduardo Hyppolito
  *   Alteracao: Inclusao do campo CAD_CNV_FL_VALID_CD_ANS
  *
  *******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(2000);
  V_SELECT  varchar2(4000);
begin
  V_WHERE := NULL;
  IF pCAD_CNV_ID_CONVENIO IS NOT NULL THEN
    V_WHERE := V_WHERE ||
               ' AND CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO;
  END IF;
  IF pCAD_CNV_CD_HAC_PRESTADOR IS NOT NULL THEN
    V_WHERE := V_WHERE ||
               ' AND CAD_CNV_CD_HAC_PRESTADOR = ' || CHR(39) || pCAD_CNV_CD_HAC_PRESTADOR || CHR(39);
  END IF;
  IF pCAD_PES_NM_PESSOA IS NOT NULL THEN
    V_WHERE := V_WHERE ||
               ' AND CAD_PES_NM_PESSOA LIKE ' || CHR(39) || UPPER(pCAD_PES_NM_PESSOA) || CHR(39); 
  END IF;
  IF pCAD_PES_NM_RAZAOSOCIAL IS NOT NULL THEN
    V_WHERE := V_WHERE ||
               ' AND CAD_PES_NM_RAZAOSOCIAL LIKE ' || CHR(39) || UPPER(pCAD_PES_NM_RAZAOSOCIAL) || CHR(39);
  END IF;
  IF pCAD_PES_NR_CNPJ_CPF IS NOT NULL THEN
    V_WHERE := V_WHERE ||
               ' AND CAD_PES_NR_CNPJ_CPF = ' || pCAD_PES_NR_CNPJ_CPF;
  END IF;
  IF pCAD_CNV_FL_STATUS IS NOT NULL THEN
    V_WHERE := V_WHERE ||
               ' AND CAD_CNV_FL_STATUS = ' || CHR(39) || pCAD_CNV_FL_STATUS || CHR(39);
  END IF;
           
   V_SELECT := '
    SELECT CNV.CAD_CNV_ID_CONVENIO,
           CNV.CAD_CNV_CD_HAC_PRESTADOR,
           CNV.CAD_CNV_CD_REG_ANS,
           CNV.CAD_CNV_DT_INCLUSAO,
           CNV.CAD_CNV_DT_INI_VIGENCIA,
           CNV.CAD_CNV_DT_FIM_VIGENCIA,
           CNV.CAD_CNV_QT_DIA_CONTA_PARCIAL,
           CNV.CAD_CNV_QT_DIA_REALIZ_FATUR,
           CNV.CAD_CNV_DS_DIA_EMI_CONTA,
           CNV.CAD_CNV_DS_DIA_ENTR_CONTA,
           CNV.CAD_CNV_DS_DIA_AUDIT_CONTA,
           CNV.CAD_CNV_HR_EXPIRA_DIARIA,
           CNV.CAD_CNV_VL_FAT_MIN,
           CNV.SEG_USU_ID_USUARIO,
           CNV.CAD_CNV_CD_CONVENIO_LEG,
           CNV.CAD_CNV_DS_MSK_BENEFIC,
           CNV.CAD_CNV_DT_ULTIMA_ATUALIZACAO,
           CNV.CAD_PES_ID_PESSOA,
           CNV.CAD_CNV_FL_GERA_NRGUIA_OK,
           CNV.AUX_FPG_CD_FORMAPAGTO,
           CNV.CAD_CNV_FL_STATUS,
           CNV.TIS_TFA_CD_TPFATURAMENTO,
           CNV.CAD_CNV_DS_MASC_MASCARAMATRI,
           CNV.CAD_CNV_DS_MASCI_MASCARAGUIA,
           CNV.CAD_CNV_DS_MASC_MASCARASENH,
           CNV.CAD_CNV_FL_VLD_VALIDADV,
           CAD_CNV_CD_MODVALIDADOR,
           CNV.CAD_CNV_NR_INICREDVALIDADOR,
           CNV.CAD_CNV_NR_FIMCREDVALIDADOR,
           CNV.CAD_CNV_QT_DIGCREDVALIDADOR,
           CNV.CAD_CNV_FL_VERIF_HORARIO_LOCAL,
           CNV.CAD_CNV_FL_VALIDA_SUBPLANOCRE,
           CNV.CAD_CNV_NR_INISUBPLANOCRE,
           CNV.CAD_CNV_NR_FIMSUBPLANOCRE,
           CNV.CAD_CNV_FL_EXIGE_VALIDA_CRED,
           CNV.CAD_CNV_FL_UTILIZAEQUIVALE,
           CNV.CAD_TPE_CD_CODIGO,
           CNV.CAD_CNV_FL_VALID_CD_ANS,
           PES.*
      FROM TB_CAD_CNV_CONVENIO CNV, TB_CAD_PES_PESSOA PES
     WHERE CNV.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA '
     || V_WHERE ||     
    ' ORDER BY PES.CAD_PES_NM_PESSOA ';

 OPEN v_cursor FOR
  V_SELECT;
  io_cursor := v_cursor;
end PRC_CAD_CNV_CONVENIO_S;