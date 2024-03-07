create or replace procedure PRC_AGE_ESF_ESCALA_FALTAS_S
  (
     pAGE_ESF_ID IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_ID%type DEFAULT NULL,
     pAGE_ESM_ID IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESM_ID%type DEFAULT NULL,
     pAGE_ESF_DT_FALTA IN TB_AGE_ESF_ESCALA_FALTAS.AGE_ESF_DT_INI_FALTA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_ESF_ESCALA_FALTAS_S
  *
  *    Data Criacao: 	  30/06/2007   Por: Silmara
  *
  *    Data Alteracao:	14/09/2009   Por: Pedro
  *    Alteracao:  add AGE_ESF_DT_ULTIMA_ATUALIZACAO    
  *
  *    Funcao: Obter ou listar faltas de uma determinada escala medica  
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       AGE_ESF_ID,
       AGE_ESF_DT_INI_FALTA,
       AGE_ESF_HR_INI_FALTA,
       AGE_ESF_HR_FIM_FALTA,
       AGE_ESF_DS_OBSERVACAO,
       AGE_ESM_ID,
       SEG_USU_ID_USUARIO,
       AGE_ESF_DT_FIM_FALTA,
       AGE_ESF_FL_SUBSTITUTO_OK,
       TIS_CBO_CD_CBOS_SUBST,
       CAD_PRO_ID_PROFISSIONAL_SUBST,
       AGE_ESF_DT_ULTIMA_ATUALIZACAO
    FROM TB_AGE_ESF_ESCALA_FALTAS
    WHERE
        (pAGE_ESF_ID is null OR AGE_ESF_ID = pAGE_ESF_ID)
    AND (pAGE_ESM_ID is null OR AGE_ESM_ID = pAGE_ESM_ID)
    AND (pAGE_ESF_DT_FALTA is null OR pAGE_ESF_DT_FALTA BETWEEN AGE_ESF_DT_INI_FALTA AND AGE_ESF_DT_FIM_FALTA)
    ORDER BY AGE_ESF_DT_FIM_FALTA DESC;
    io_cursor := v_cursor;
  end PRC_AGE_ESF_ESCALA_FALTAS_S;

/
