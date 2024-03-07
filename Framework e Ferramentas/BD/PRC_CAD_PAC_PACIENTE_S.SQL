CREATE OR REPLACE PROCEDURE "PRC_CAD_PAC_PACIENTE_S"(pCAD_PAC_CD_CODCIP     IN TB_CAD_PAC_PACIENTE.CAD_PAC_CD_CODCIP%type DEFAULT NULL,
                                                     pCAD_PAC_ID_PACIENTE   IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%type DEFAULT NULL,
                                                     pCAD_PLA_ID_PLANO      IN TB_CAD_PAC_PACIENTE.CAD_PLA_ID_PLANO%type DEFAULT NULL,
                                                     pCAD_PAC_NR_PRONTUARIO IN TB_CAD_PAC_PACIENTE.CAD_PAC_NR_PRONTUARIO%type DEFAULT NULL,
                                                     pCAD_PAC_CD_CREDENCIAL IN TB_CAD_PAC_PACIENTE.CAD_PAC_CD_CREDENCIAL%type DEFAULT NULL,
                                                     pCAD_PES_NM_NOMEMAE    IN TB_CAD_PES_PESSOA.CAD_PES_NM_NOMEMAE%type DEFAULT NULL,
                                                     pCAD_CNV_ID_CONVENIO   IN TB_CAD_PAC_PACIENTE.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
                                                     pCAD_PES_NM_PESSOA     IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%type DEFAULT NULL,
                                                     pASS_PMD_CD_MD5_ATUAL  IN TB_ASS_PMD_PESSOA_MD5.ASS_PMD_CD_MD5%type DEFAULT NULL,
                                                     io_cursor              OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_CAD_PAC_PACIENTE_S
  *
  *    Data Criacao:  data da  cria???#o   Por: Nome do Analista
  *    Data Alteracao:  15/10/2008         Por: Cristiane Gomes da Silva
  *
  *    Funcao: Descri???#o da funcionalidade da Stored Procedure
  *
  *    Alteracao: 1) Inclus?o de novos parametros: Id Plano, Nr Prontuario e Credencial
  *               2) Join com tabela pessoa
  *               3) Inclusao de novos campos: CAD_PAC_CD_SUBPLANO, CAD_PAC_TP_SAGUINENO
  *                  AUX_PRF_CD_CODIGO, AUX_NAC_CD_CODIGO, CAD_PAC_FL_DOADORORGAOS_OK
  *               4) Alterac?o do nome do atributo CAD_PAC_TP_SANGUINEO
  *               5) Alterac?o para recuperar paciente com credencial n?o nula para ACS e GG05
  *               6) Desconsiderar parametros nulos para nao usar OR
  *
  *    Data Alteracao:  25/11/2009  Por: Davi Silvestre M. dos Reis
  *			    Alteracao: Inclusao do parametro NOME (CAD_PES_NM_PESSOA) na pesquisa,
  *                    para facilitar a localizacao de pacientes com CIPs iguais
  *
  *    Data Alteracao:  21/05/2010  Por: Davi Silvestre M. dos Reis
  *			    Alteracao: Inclusao do parametro do codigo do MD5 (pASS_PMD_CD_MD5_ATUAL) na pesquisa
  *
  *    Data Alteracao:  03/11/2010  Por: Davi Silvestre M. dos Reis
  *    Alteracao:       Inclusao de novo atributo (CAD_PAC_FL_RESTRICAO_PA_OK)
  *
  *    Data Alteracao:  30/11/2010  Por: Davi Silvestre M. dos Reis
  *    Alteracao:       Ordenacao decrescente a partir da data de atualizacao (para pegar
  *                     os mais recentes primeiro)
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(2000);
  V_SELECT  varchar2(4000);
begin
  V_WHERE := NULL;
  IF pCAD_PAC_ID_PACIENTE IS NOT NULL THEN
    V_WHERE := V_WHERE ||
               ' AND PAC.CAD_PAC_ID_PACIENTE = ' || pCAD_PAC_ID_PACIENTE;
  END IF;
  IF pCAD_PLA_ID_PLANO IS NOT NULL AND pCAD_PLA_ID_PLANO > 0 THEN
    V_WHERE := V_WHERE || ' AND PAC.CAD_PLA_ID_PLANO = ' || pCAD_PLA_ID_PLANO;
  END IF;
  IF pCAD_PAC_NR_PRONTUARIO IS NOT NULL THEN
    V_WHERE := V_WHERE ||
               ' AND PAC.CAD_PAC_NR_PRONTUARIO = ' || pCAD_PAC_NR_PRONTUARIO;
  END IF;
  IF pCAD_PAC_CD_CREDENCIAL IS NOT NULL THEN
    V_WHERE := V_WHERE ||
               ' AND PAC.CAD_PAC_CD_CREDENCIAL = ' || CHR(39) || pCAD_PAC_CD_CREDENCIAL || CHR(39);
  END IF;
  IF pCAD_PAC_CD_CODCIP IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PAC.CAD_PAC_CD_CODCIP = ' || CHR(39) || pCAD_PAC_CD_CODCIP || CHR(39);
  END IF;
  IF pCAD_PES_NM_NOMEMAE IS NOT NULL THEN
    V_WHERE := V_WHERE ||
               ' AND UPPER(PES.CAD_PES_NM_NOMEMAE) LIKE ' || CHR(39) || UPPER(pCAD_PES_NM_NOMEMAE) || CHR(39);
  END IF;
  IF pCAD_CNV_ID_CONVENIO IS NOT NULL AND pCAD_CNV_ID_CONVENIO > 0 THEN
    V_WHERE := V_WHERE ||
               ' AND PAC.CAD_CNV_ID_CONVENIO = ' || pCAD_CNV_ID_CONVENIO;
  END IF;
  IF pCAD_PES_NM_PESSOA IS NOT NULL THEN
    V_WHERE := V_WHERE ||
               ' AND UPPER(PES.CAD_PES_NM_PESSOA) LIKE ' || CHR(39) || UPPER(pCAD_PES_NM_PESSOA) || CHR(39);
  END IF;
  IF pASS_PMD_CD_MD5_ATUAL IS NOT NULL THEN
    V_WHERE := V_WHERE ||
               ' AND MD5.ASS_PMD_CD_MD5 LIKE ' || CHR(39) || pASS_PMD_CD_MD5_ATUAL || CHR(39);
  END IF;
  -- ENQUANTO N?O 'SUBIR' O MD5, MONTA DUAS QUERYS: UMA COM E OUTRA SEM O MD5
  IF pASS_PMD_CD_MD5_ATUAL IS NOT NULL THEN
    V_SELECT := 'SELECT PAC.CAD_PAC_ID_PACIENTE,
             PAC.CAD_CNV_ID_CONVENIO,
             PAC.CAD_PLA_ID_PLANO,
             PAC.CAD_PAC_CD_CREDENCIAL,
             PAC.CAD_EMP_ID_EMPRESA,
             PAC.CAD_PAC_NR_PRONTUARIO,
             PAC.CAD_PAC_NM_TITULAR,
             PAC.CAD_PAC_DT_VALIDADECREDENCIAL,
             PAC.CAD_PAC_CD_CNS,
             PAC.CAD_PAC_DS_OBSERVACAO,
             PAC.CAD_PAC_FL_VIP_OK,
             PAC.CAD_PAC_CD_CODCIP,
             PAC.CAD_PAC_CD_CODBEN,
             PAC.CAD_PAC_CD_CODBENSEQ,
             PAC.SEG_USU_ID_USUARIO,
             PAC.CAD_PES_ID_PESSOA,
             PES.CAD_PES_NR_CNPJ_CPF,
             PES.CAD_PES_FL_JURIDICA_OK,
             PES.CAD_PES_NM_PESSOA,
             PES.CAD_PES_NM_RAZAOSOCIAL,
             PES.CAD_PES_DT_NASCIMENTO,
             PES.CAD_PES_NR_RG,
             PES.CAD_PES_CD_INSCR_MUNIC,
             PES.CAD_PES_CD_INSCR_ESTAD,
             PES.CAD_PES_TP_SEXO,
             PES.SEG_USU_ID_USUARIO,
             PES.CAD_PES_CD_ESTADOCIVIL,
             PES.CAD_PES_NM_NOMEMAE,
             PAC.CAD_PAC_CD_SUBPLANO,
             PAC.CAD_PAC_TP_SANGUINEO,
             PAC.AUX_PRF_CD_CODIGO,
             PAC.AUX_NAC_CD_CODIGO,
             PAC.CAD_PAC_FL_DOADORORGAOS_OK,
             PES.CAD_PES_CD_ORGAOEMISSORRG,
             PES.CAD_PES_DT_EXPEDICAORG,
             MD5.ASS_PMD_CD_MD5,
             PAC.CAD_PAC_FL_RESTRICAO_PA_OK,
             PAC.CAD_PAC_FL_ATIVO_OK,
             PES.CAD_PES_FL_ATIVO_OK
        FROM TB_CAD_PAC_PACIENTE PAC,
             TB_CAD_PES_PESSOA   PES,
             TB_CAD_PLA_PLANO    PLA,
             TB_ASS_PMD_PESSOA_MD5 MD5
       WHERE PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
       AND PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO
       AND PES.CAD_PES_ID_PESSOA = MD5.CAD_PES_ID_PESSOA '
       || V_WHERE ||
       ' AND ((PLA.CAD_PLA_CD_TIPOPLANO NOT IN ('||CHR(39)||'SP'||CHR(39)||','||CHR(39)||'PA'||CHR(39)||','||CHR(39)||'NP'||CHR(39)||')
       AND PLA.CAD_PLA_CD_PLANO_HAC != '||CHR(39)||'G226'||CHR(39)||'
       AND PAC.CAD_PAC_CD_CREDENCIAL IS NOT NULL)
       OR (PLA.CAD_PLA_CD_TIPOPLANO IN ('||CHR(39)||'SP'||CHR(39)||','||CHR(39)||'PA'||CHR(39)||','||CHR(39)||'NP'||CHR(39)||'))
       OR (PLA.CAD_PLA_CD_PLANO_HAC = '||CHR(39)||'G226'||CHR(39)||'))';
  ELSE
  V_SELECT := 'SELECT PAC.CAD_PAC_ID_PACIENTE,
             PAC.CAD_CNV_ID_CONVENIO,
             PAC.CAD_PLA_ID_PLANO,
             PAC.CAD_PAC_CD_CREDENCIAL,
             PAC.CAD_EMP_ID_EMPRESA,
             PAC.CAD_PAC_NR_PRONTUARIO,
             PAC.CAD_PAC_NM_TITULAR,
             PAC.CAD_PAC_DT_VALIDADECREDENCIAL,
             PAC.CAD_PAC_CD_CNS,
             PAC.CAD_PAC_DS_OBSERVACAO,
             PAC.CAD_PAC_FL_VIP_OK,
             PAC.CAD_PAC_CD_CODCIP,
             PAC.CAD_PAC_CD_CODBEN,
             PAC.CAD_PAC_CD_CODBENSEQ,
             PAC.SEG_USU_ID_USUARIO,
             PAC.CAD_PES_ID_PESSOA,
             PES.CAD_PES_NR_CNPJ_CPF,
             PES.CAD_PES_FL_JURIDICA_OK,
             PES.CAD_PES_NM_PESSOA,
             PES.CAD_PES_NM_RAZAOSOCIAL,
             PES.CAD_PES_DT_NASCIMENTO,
             PES.CAD_PES_NR_RG,
             PES.CAD_PES_CD_INSCR_MUNIC,
             PES.CAD_PES_CD_INSCR_ESTAD,
             PES.CAD_PES_TP_SEXO,
             PES.SEG_USU_ID_USUARIO,
             PES.CAD_PES_CD_ESTADOCIVIL,
             PES.CAD_PES_NM_NOMEMAE,
             PAC.CAD_PAC_CD_SUBPLANO,
             PAC.CAD_PAC_TP_SANGUINEO,
             PAC.AUX_PRF_CD_CODIGO,
             PAC.AUX_NAC_CD_CODIGO,
             PAC.CAD_PAC_FL_DOADORORGAOS_OK,
             PES.CAD_PES_CD_ORGAOEMISSORRG,
             PES.CAD_PES_DT_EXPEDICAORG,
             PAC.CAD_PAC_FL_RESTRICAO_PA_OK,
             '''' ASS_PMD_CD_MD5,
             PAC.CAD_PAC_FL_ATIVO_OK,
             PES.CAD_PES_FL_ATIVO_OK
        FROM TB_CAD_PAC_PACIENTE PAC,
             TB_CAD_PES_PESSOA   PES,
             TB_CAD_PLA_PLANO    PLA
       WHERE PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA
       AND PAC.CAD_PLA_ID_PLANO = PLA.CAD_PLA_ID_PLANO '
       || V_WHERE ||
       ' AND ((PLA.CAD_PLA_CD_TIPOPLANO NOT IN ('||CHR(39)||'SP'||CHR(39)||','||CHR(39)||'PA'||CHR(39)||','||CHR(39)||'NP'||CHR(39)||')
       AND PLA.CAD_PLA_CD_PLANO_HAC != '||CHR(39)||'G226'||CHR(39)||'
       AND PAC.CAD_PAC_CD_CREDENCIAL IS NOT NULL)
       OR (PLA.CAD_PLA_CD_TIPOPLANO IN ('||CHR(39)||'SP'||CHR(39)||','||CHR(39)||'PA'||CHR(39)||','||CHR(39)||'NP'||CHR(39)||'))
       OR (PLA.CAD_PLA_CD_PLANO_HAC = '||CHR(39)||'G226'||CHR(39)||'))';
  END IF;
  V_SELECT := V_SELECT || ' ORDER BY PAC.CAD_PAC_DT_ULTIMA_ATUALIZACAO DESC';
  OPEN v_cursor FOR
  V_SELECT;
  io_cursor := v_cursor;
end PRC_CAD_PAC_PACIENTE_S;