CREATE OR REPLACE PROCEDURE PRC_INT_CAD_QLE_RMT_S
  (
     pCAD_QLE_ID IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_ID%type DEFAULT NULL,
     pCAD_SET_ID IN TB_CAD_QLE_QUARTO_LEITO.CAD_SET_ID%type DEFAULT NULL,
     pCAD_QLE_NR_QUARTO IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_NR_QUARTO%type DEFAULT NULL,
     pCAD_QLE_NR_LEITO IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_NR_LEITO%type DEFAULT NULL,
     pCAD_QLE_NR_RAMAL IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_NR_RAMAL%type DEFAULT NULL,
     pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_CAD_QLE_QUARTO_LEITO.TIS_TAC_CD_TIPO_ACOMODACAO%type DEFAULT NULL,
     pCAD_QLE_TP_SEXO IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_TP_SEXO%type DEFAULT NULL,
     pTIS_TAC_CD_TIPO_ACOM_PROV IN TB_CAD_QLE_QUARTO_LEITO.TIS_TAC_CD_TIPO_ACOM_PROV%type DEFAULT NULL,
     pCAD_QLE_DT_ULTIMA_ATUALIZACAO IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_QLE_QUARTO_LEITO.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pCAD_SQL_CD_SIT_QUARTO_LEITO IN TB_CAD_QLE_QUARTO_LEITO.CAD_SQL_CD_SIT_QUARTO_LEITO%type DEFAULT NULL,
     pCAD_QLE_TP_QUARTO_LEITO IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_TP_QUARTO_LEITO%type DEFAULT NULL,
     pCAD_QLE_FL_ALTERA_ACOMOD IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_FL_ALTERA_ACOMOD%type DEFAULT NULL,
     pTIS_CBO_CBOS IN TB_CAD_QLE_QUARTO_LEITO.TIS_CBO_CBOS%type DEFAULT NULL,
     pCAD_QLE_FL_LIMPEZA_LEITO IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_FL_LIMPEZA_LEITO%type DEFAULT NULL,
     pCAD_QLE_FL_CONS_SEX_PRIM_PAC IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_FL_CONS_SEX_PRIM_PAC%type DEFAULT NULL,
     pCAD_QLE_QT_VISITA_PERM_LEITO IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_QT_VISITA_PERM_LEITO%type DEFAULT NULL,
     pCAD_QLE_FL_CONS_PATOLOGIA IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_FL_CONS_PATOLOGIA%type DEFAULT NULL,
     pCAD_QLE_DS_OBSERVACAO IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_DS_OBSERVACAO%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_CAD_QLE_RMT_S
  *
  *    Data Criacao:   28/07/09   Por: Pedro
  *    Funcao: Listar quartos por unidade,local ja com descricao de Uni,Lat, Setor, Especialidade
  *
  *    Alteracao: 18/07/2014 Desconsiderar quartos/leitos desativados por reestruturacao
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       QLE.CAD_QLE_ID,
       QLE.CAD_SET_ID,
       QLE.CAD_QLE_NR_QUARTO,
       QLE.CAD_QLE_NR_LEITO,
       QLE.CAD_QLE_NR_RAMAL,
       QLE.TIS_TAC_CD_TIPO_ACOMODACAO,
       QLE.CAD_QLE_TP_SEXO,
       QLE.TIS_TAC_CD_TIPO_ACOM_PROV,
       QLE.CAD_QLE_DT_ULTIMA_ATUALIZACAO,
       QLE.SEG_USU_ID_USUARIO,
       QLE.CAD_SQL_CD_SIT_QUARTO_LEITO,
       QLE.CAD_QLE_TP_QUARTO_LEITO,
       QLE.CAD_QLE_FL_ALTERA_ACOMOD,
       QLE.TIS_CBO_CBOS,
       QLE.CAD_QLE_FL_LIMPEZA_LEITO,
       QLE.CAD_QLE_FL_CONS_SEX_PRIM_PAC,
       QLE.CAD_QLE_QT_VISITA_PERM_LEITO,
       QLE.CAD_QLE_FL_CONS_PATOLOGIA,
       QLE.CAD_QLE_DS_OBSERVACAO,
       SETOR.CAD_SET_DS_SETOR,
       UNI.CAD_UNI_ID_UNIDADE,
       PES_UNI.CAD_PES_NM_PESSOA,
       LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
       CBOS.TIS_CBO_DS_CBOS,
       TAC.TIS_TAC_DS_TIPO_ACOMODACAO,
       TAC_PROV.TIS_TAC_DS_TIPO_ACOMODACAO TIS_TAC_DS_TIPO_ACOMOD_PROV,
       SQL.CAD_SQL_DS_SIT_QUARTO_LEITO,
       DECODE(QLE.CAD_QLE_TP_SEXO, 'F', 'FEMININO', 'M', 'MASCULINO', 'A', 'AMBOS') SEXO,
       DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO, 'I', 'INTERNO', 'E', 'EXTERNO') TIPO_LEITO
    FROM TB_CAD_QLE_QUARTO_LEITO QLE
    INNER JOIN TB_CAD_SET_SETOR SETOR
    ON SETOR.CAD_SET_ID = QLE.CAD_SET_ID
    INNER JOIN TB_CAD_UNI_UNIDADE UNI
    ON UNI.CAD_UNI_ID_UNIDADE = SETOR.CAD_UNI_ID_UNIDADE
    INNER JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
    ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO
    INNER JOIN TB_CAD_PES_PESSOA PES_UNI
    ON PES_UNI.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
    LEFT JOIN TB_TIS_CBO_CBOS CBOS
    ON CBOS.TIS_CBO_CD_CBOS = QLE.TIS_CBO_CBOS
    INNER JOIN TB_CAD_SQL_SIT_QUARTO_LEITO SQL
    ON SQL.CAD_SQL_CD_SIT_QUARTO_LEITO = QLE.CAD_SQL_CD_SIT_QUARTO_LEITO
    INNER JOIN TB_TIS_TAC_TIPO_ACOMODACAO TAC
    ON TAC.TIS_TAC_CD_TIPO_ACOMODACAO = QLE.TIS_TAC_CD_TIPO_ACOMODACAO
    INNER JOIN TB_TIS_TAC_TIPO_ACOMODACAO TAC_PROV
    ON TAC_prov.TIS_TAC_CD_TIPO_ACOMODACAO = QLE.TIS_TAC_CD_TIPO_ACOM_PROV
    WHERE
        (pCAD_QLE_ID is null OR QLE.CAD_QLE_ID = pCAD_QLE_ID) AND
        (pCAD_SET_ID is null OR QLE.CAD_SET_ID = pCAD_SET_ID) AND
        (pCAD_QLE_NR_QUARTO is null OR QLE.CAD_QLE_NR_QUARTO = pCAD_QLE_NR_QUARTO) AND
        (pCAD_QLE_NR_LEITO is null OR QLE.CAD_QLE_NR_LEITO = pCAD_QLE_NR_LEITO) AND
        (pCAD_QLE_NR_RAMAL is null OR QLE.CAD_QLE_NR_RAMAL = pCAD_QLE_NR_RAMAL) AND
        (pTIS_TAC_CD_TIPO_ACOMODACAO is null OR QLE.TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO) AND
        (pCAD_QLE_TP_SEXO is null OR QLE.CAD_QLE_TP_SEXO = pCAD_QLE_TP_SEXO) AND
        (pTIS_TAC_CD_TIPO_ACOM_PROV is null OR QLE.TIS_TAC_CD_TIPO_ACOM_PROV = pTIS_TAC_CD_TIPO_ACOM_PROV) AND
        (pCAD_QLE_DT_ULTIMA_ATUALIZACAO is null OR QLE.CAD_QLE_DT_ULTIMA_ATUALIZACAO = pCAD_QLE_DT_ULTIMA_ATUALIZACAO) AND
        (pSEG_USU_ID_USUARIO is null OR QLE.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO) AND
        (pCAD_SQL_CD_SIT_QUARTO_LEITO is null OR QLE.CAD_SQL_CD_SIT_QUARTO_LEITO = pCAD_SQL_CD_SIT_QUARTO_LEITO) AND
        (pCAD_QLE_TP_QUARTO_LEITO is null OR QLE.CAD_QLE_TP_QUARTO_LEITO = pCAD_QLE_TP_QUARTO_LEITO) AND
        (pCAD_QLE_FL_ALTERA_ACOMOD is null OR QLE.CAD_QLE_FL_ALTERA_ACOMOD = pCAD_QLE_FL_ALTERA_ACOMOD) AND
        (pTIS_CBO_CBOS is null OR QLE.TIS_CBO_CBOS = pTIS_CBO_CBOS) AND
        (pCAD_QLE_FL_LIMPEZA_LEITO is null OR QLE.CAD_QLE_FL_LIMPEZA_LEITO = pCAD_QLE_FL_LIMPEZA_LEITO) AND
        (pCAD_QLE_FL_CONS_SEX_PRIM_PAC is null OR QLE.CAD_QLE_FL_CONS_SEX_PRIM_PAC = pCAD_QLE_FL_CONS_SEX_PRIM_PAC) AND
        (pCAD_QLE_QT_VISITA_PERM_LEITO is null OR QLE.CAD_QLE_QT_VISITA_PERM_LEITO = pCAD_QLE_QT_VISITA_PERM_LEITO) AND
        (pCAD_QLE_FL_CONS_PATOLOGIA is null OR QLE.CAD_QLE_FL_CONS_PATOLOGIA = pCAD_QLE_FL_CONS_PATOLOGIA) AND
        (pCAD_QLE_DS_OBSERVACAO is null OR QLE.CAD_QLE_DS_OBSERVACAO LIKE pCAD_QLE_DS_OBSERVACAO) AND
        (pCAD_UNI_ID_UNIDADE IS NULL OR UNI.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE) AND
        (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
         AND SQL.CAD_SQL_CD_SIT_QUARTO_LEITO != 5 --DESCONSIDERANDO LEITOS DESATIVADOS POR REESTRUTURACAO
          ORDER BY QLE.CAD_QLE_NR_QUARTO, QLE.CAD_QLE_NR_LEITO;
    io_cursor := v_cursor;
  end PRC_INT_CAD_QLE_RMT_S;
 
/