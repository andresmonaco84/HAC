create or replace procedure PRC_ASS_ULP_UNID_CECI_PROCE_S
  (
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULP_UNID_LOCAL_PROCED.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
     pAUX_EPP_CD_ESPECPROCED IN TB_ASS_ULP_UNID_LOCAL_PROCED.AUX_EPP_CD_ESPECPROCED%TYPE,
     pTIS_MED_CD_TABELAMEDICA IN TB_ASS_ULP_UNID_LOCAL_PROCED.TIS_MED_CD_TABELAMEDICA%TYPE,
     pFL_CECI varchar2 default null,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_ULP_UNID_CECI_PROCE_S
  *
  *    Data Criacao:   30/08/2010           Por: Pedro
  *    Data Alteracao:  data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Listar as Associacoes de Unidade x CECI(CENTRO CIRURGICO) x Procedimentos
  * 
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;

  begin
 OPEN v_cursor FOR
SELECT DISTINCT
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
         TB_CAD_PRD_PRODUTO PRD,
         TB_CAD_SET_SETOR SETOR
         
    WHERE
           ULP.CAD_PRD_ID = PRD.CAD_PRD_ID
      AND  ULP.CAD_SET_ID = SETOR.CAD_SET_ID
      AND  (ULP.ASS_ULP_FL_LIB_AGE_SADT  =     'S')
      AND  (ULP.AUX_EPP_CD_ESPECPROCED   =     pAUX_EPP_CD_ESPECPROCED)
      AND  (ULP.TIS_MED_CD_TABELAMEDICA  =     pTIS_MED_CD_TABELAMEDICA)
      AND  (pCAD_UNI_ID_UNIDADE IS NULL OR ULP.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
      AND  (
           (pFL_CECI = 'S' AND SETOR.CAD_SET_DS_SETOR  = 'CENTRO CIRURGICO') OR
           (pFL_CECI = 'N' AND SETOR.CAD_SET_DS_SETOR != 'CENTRO CIRURGICO') OR
           (pFL_CECI IS NULL)
           )
            ;           
    io_cursor := v_cursor;
  end PRC_ASS_ULP_UNID_CECI_PROCE_S;
/
