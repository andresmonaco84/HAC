create or replace procedure PRC_ASS_ULP_UNID_LOCAL_PROCE_S
  (
     pASS_ULP_ID IN TB_ASS_ULP_UNID_LOCAL_PROCED.ASS_ULP_ID%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULP_UNID_LOCAL_PROCED.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULP_UNID_LOCAL_PROCED.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
     pCAD_SET_ID IN TB_ASS_ULP_UNID_LOCAL_PROCED.CAD_SET_ID%TYPE DEFAULT NULL,
     pAGE_SAU_ID IN TB_ASS_ULP_UNID_LOCAL_PROCED.AGE_SAU_ID%TYPE DEFAULT NULL,
     pAUX_EPP_CD_ESPECPROCED IN TB_ASS_ULP_UNID_LOCAL_PROCED.AUX_EPP_CD_ESPECPROCED%TYPE DEFAULT NULL,
     pAUX_GPC_CD_GRUPOPROC IN TB_ASS_ULP_UNID_LOCAL_PROCED.AUX_GPC_CD_GRUPOPROC%TYPE DEFAULT NULL,
     pCAD_PRD_CD_CODIGO IN TB_ASS_ULP_UNID_LOCAL_PROCED.CAD_PRD_CD_CODIGO%TYPE DEFAULT NULL,
     pTIS_MED_CD_TABELAMEDICA IN TB_ASS_ULP_UNID_LOCAL_PROCED.TIS_MED_CD_TABELAMEDICA%TYPE DEFAULT NULL,
     pASS_ULP_FL_LIB_AGE_SADT IN TB_ASS_ULP_UNID_LOCAL_PROCED.ASS_ULP_FL_LIB_AGE_SADT%TYPE DEFAULT NULL,
     pCAD_PRD_ID IN TB_ASS_ULP_UNID_LOCAL_PROCED.CAD_PRD_ID%TYPE DEFAULT NULL,
     pCAD_PRD_DS_DESCRICAO IN TB_CAD_PRD_PRODUTO.CAD_PRD_DS_DESCRICAO%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_ULP_UNID_LOCAL_PROCE_S
  *
  *    Data Criacao:   24/01/2008           Por: Fabiola Lopes
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Listar as Associacoes de Unidade x Local x Procedimentos
  *
  *    Data Alteracao:  24/03/2008  Por: Davi S. M. dos Reis
  *    Alteração: Inclusao do atributo da sala
  *
  *    Data Alteracao:  24/03/2008  Por: Davi S. M. dos Reis
  *    Alteração: Inclusao do atributo da sala como parametro
  *
  *    Data Alteracao:  08/04/2008  Por: Davi S. M. dos Reis
  *    Alteração: Inclusao do atributo da quantidade de horarios para
  *               agendamento do procedimento
  *
  *    Data Alteracao: 11/04/2008   Por: Fabiola Lopes
  *    Alteracao: Inclusao um join na clausula where e distinct no select
  *
  *    Data Alteracao: 23/06/2008   Por: Andrea Cazuca
  *    Alteracao: Inclusao de dos campos ass_ulp_fl_lib_age_sadt,
  *               ass_ulp_fl_exi_prep_agesadt e tis_med_cd_tabelamedica
  *
  *    Data Alteracao: 05/08/2008   Por: Andréa Cazuca
  *    Alteracao: Inclusao do atributo tis_med_cd_tabelamedica
  *
  *    Data Alteracao: 07/08/2008   Por: Bruno Costa
  *	   Alteracao: Inclusao do atributo pASS_ULP_FL_LIB_AGE_SADT
  *
  *    Data Alteracao: 15/08/2008      Por: Fabiola Lopes
  *    Alteracao: Inclusao do atributo CAD_PRD_ID
  *
  *    Data Alteracao: 19/08/2008      Por: Andrea Cazuca
  *    Alteracao: Inclusao do campo CAD_PRD_DS_DESCRICAO para pesquisa
  *
  *    Data Alteracao: 25/08/2008      Por: Fabiola R. Lopes
  *    Alteracao: Alteracao do join do CAD_PRD_CD_CODIGO para CAD_PRD_ID
  *
  *    Data Alteracao: 23/09/2008      Por: Fabiola R. Lopes
  *    Alteracao: Inclusao de um campo ASS_ULP_HR_LIMITE_AGE_SADT
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  v_SQL varchar2 (2000);
  V_SELECT VARCHAR2 (2000);
  begin

  if (pASS_ULP_ID IS NOT NULL) THEN
    v_SQL := v_SQL || ' AND  ULP.ASS_ULP_ID = '|| pASS_ULP_ID;
  END IF;
  if (pCAD_UNI_ID_UNIDADE IS NOT NULL) THEN
   v_SQL := v_SQL || ' AND  ULP.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE;
  END IF;
  if (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL) THEN
    v_SQL := v_SQL || ' AND  ULP.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO;
  END IF;
  if (pAGE_SAU_ID IS NOT NULL) THEN
    v_SQL := v_SQL || ' AND  AGE_SAU_ID = ' || pAGE_SAU_ID;
  END IF;
  IF (pAUX_EPP_CD_ESPECPROCED IS NOT NULL) THEN
    v_SQL := v_SQL || ' AND  ULP.AUX_EPP_CD_ESPECPROCED = ' || CHR(39) || pAUX_EPP_CD_ESPECPROCED|| CHR(39);
  END IF;
  IF (pAUX_GPC_CD_GRUPOPROC IS NOT NULL) THEN  
    v_SQL := v_SQL || ' AND  ULP.AUX_GPC_CD_GRUPOPROC = ' || CHR(39) || pAUX_GPC_CD_GRUPOPROC || CHR(39);
  END IF;
  IF (pCAD_PRD_CD_CODIGO IS NOT NULL) THEN
    v_SQL := v_SQL || ' AND  ULP.CAD_PRD_CD_CODIGO = ' || CHR(39)|| pCAD_PRD_CD_CODIGO|| CHR(39);
  END IF;
  IF (pTIS_MED_CD_TABELAMEDICA IS NOT NULL) THEN
    v_SQL := v_SQL || ' AND  ULP.TIS_MED_CD_TABELAMEDICA = ' || CHR(39) || pTIS_MED_CD_TABELAMEDICA || CHR(39);
  END IF;
  IF (pASS_ULP_FL_LIB_AGE_SADT IS NOT NULL) THEN
    v_SQL := v_SQL || ' AND  ULP.ASS_ULP_FL_LIB_AGE_SADT = ' || CHR(39) || pASS_ULP_FL_LIB_AGE_SADT || CHR(39);
  END IF;
  IF (pCAD_PRD_ID IS NOT NULL) THEN
    v_SQL := v_SQL || ' AND  ULP.CAD_PRD_ID = ' || pCAD_PRD_ID;
  END IF;
  IF (pCAD_PRD_DS_DESCRICAO IS NOT NULL) THEN  
    v_SQL := v_SQL || ' AND  PRD.CAD_PRD_DS_DESCRICAO LIKE UPPER(' || CHR(39) || pCAD_PRD_DS_DESCRICAO|| CHR(39) ||')';
  END IF;
  if (pCAD_SET_ID IS NOT NULL) THEN
    v_SQL := v_SQL || ' AND  ULP.CAD_SET_ID = ' || pCAD_SET_ID;
  END IF;
  V_SELECT := 'SELECT DISTINCT
       ULP.ASS_ULP_ID,
       ULP.CAD_UNI_ID_UNIDADE,
       ULP.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ULP.AUX_EPP_CD_ESPECPROCED,
       ULP.AUX_GPC_CD_GRUPOPROC,
       ULP.CAD_PRD_CD_CODIGO,
       ULP.ASS_ULP_FL_STATUS,
       ULP.ASS_ULP_DT_ULTIMA_ATUALIZACAO,
       ULP.SEG_USU_ID_USUARIO,
       ULP.CAD_SET_ID,
       ULP.AGE_SAU_ID,
       PRD.CAD_PRD_DS_DESCRICAO,
       PRD.CAD_PRD_NM_MNEMONICO,
       ULP.ASS_ULP_QT_HORA_RESERVADA,
       ULP.ASS_ULP_FL_LIB_AGE_SADT,
       ULP.ASS_ULP_FL_EXI_PREP_AGESADT,
       ULP.TIS_MED_CD_TABELAMEDICA,
       ULP.CAD_PRD_ID,
       ULP.ASS_ULP_HR_LIMITE_AGE_SADT
    FROM TB_ASS_ULP_UNID_LOCAL_PROCED ULP,
         TB_CAD_PRD_PRODUTO PRD
       WHERE
           ULP.CAD_PRD_ID = PRD.CAD_PRD_ID'
       || v_SQL;
    OPEN v_cursor FOR
    V_SELECT;
    io_cursor := v_cursor;
  end PRC_ASS_ULP_UNID_LOCAL_PROCE_S;
