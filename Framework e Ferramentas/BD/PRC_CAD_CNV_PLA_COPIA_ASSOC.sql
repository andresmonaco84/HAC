create or replace procedure PRC_CAD_CNV_PLA_COPIA_ASSOC
(pCAD_UNI_ID_UNIDADE_ORIGEM              IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
pCAD_LAT_ID_LOCAL_ATEND_ORIGEM     IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
pCAD_UNI_ID_UNIDADE_DESTINO              IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
pDATAINICIAL                             IN TB_CAD_CNV_CONVENIO.CAD_CNV_DT_INI_VIGENCIA%TYPE,
pCAD_CNV_ID_CONVENIO                     IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL) is

  /********************************************************************
  *    Procedure: PRC_CAD_CNV_PLA_COPIA_ASSOC
  *
  *    Data Criacao:  03/04/2009   Por: Cristiane Gomes da Silva
  *    Data Alteracao:             Por:
  *
  *    Funcao: Copiar associações de convênios planos para outra unidade/local
  *
  *******************************************************************/
  v_ass_cnu_id NUMBER;
  v_ass_cul_id  NUMBER;
  v_ass_clp_id NUMBER;
  v_ass_cdr_id_dia_retorno NUMBER;
begin
  -- LOOP ASSOCIACAO CONVENIO X UNIDADE
  FOR CNU IN (
    SELECT ASS_CNU_ID,
           ASS_CNU_DT_INI_VIGENCIA,
           ASS_CNU_DT_FIM_VIGENCIA,
           ASS_CNU_DS_MOTIVO_FIM_VIGENCIA,
           ASS_CNU_DT_ULTIMA_ATUALIZACAO,
           CAD_CNV_ID_CONVENIO,
           CAD_UNI_ID_UNIDADE,
           SEG_USU_ID_USUARIO
    FROM TB_ASS_CNU_CONVENIO_UNIDADE
    WHERE CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE_ORIGEM
    AND (CAD_CNV_ID_CONVENIO IS NULL OR CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
    AND (ASS_CNU_DT_FIM_VIGENCIA IS NULL OR TRUNC(ASS_CNU_DT_FIM_VIGENCIA) >= TRUNC(SYSDATE))) 
    LOOP
    BEGIN
      SELECT SEQ_ASS_CNU_01.NEXTVAL
      INTO   v_ass_cnu_id
      FROM   DUAL;
      INSERT INTO TB_ASS_CNU_CONVENIO_UNIDADE
      (ASS_CNU_ID,
      ASS_CNU_DT_INI_VIGENCIA,
      ASS_CNU_DT_FIM_VIGENCIA,
      ASS_CNU_DS_MOTIVO_FIM_VIGENCIA,
      ASS_CNU_DT_ULTIMA_ATUALIZACAO,
      CAD_CNV_ID_CONVENIO,
      CAD_UNI_ID_UNIDADE,
      SEG_USU_ID_USUARIO)
      VALUES
      (v_ass_cnu_id,
      pDATAINICIAL,
      CNU.ASS_CNU_DT_FIM_VIGENCIA,
      CNU.ASS_CNU_DS_MOTIVO_FIM_VIGENCIA,
      SYSDATE,
      CNU.CAD_CNV_ID_CONVENIO,
      pCAD_UNI_ID_UNIDADE_DESTINO,
      CNU.SEG_USU_ID_USUARIO);
      -- LOOP ASSOCIACAO CONVENIO X UNIDADE X LOCAL
      FOR CUL IN (
      SELECT ASS_CUL_ID,
      ASS_CUL_DT_INI_VIGENCIA,
      ASS_CUL_DS_MOTIVO_FIM_VIGENCIA,
      ASS_CUL_DT_ULTIMA_ATUALIZACAO,
      CAD_LAT_ID_LOCAL_ATENDIMENTO,
      ASS_CUL_DT_FIM_VIGENCIA,
      SEG_USU_ID_USUARIO,
      ASS_CNU_ID
      FROM TB_ASS_CUL_CONV_UNI_LOCATEND CUL1
      WHERE CUL1.ASS_CNU_ID = CNU.ASS_CNU_ID
      AND CUL1.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATEND_ORIGEM
      AND (CUL1.ASS_CUL_DT_FIM_VIGENCIA IS NULL OR TRUNC(CUL1.ASS_CUL_DT_FIM_VIGENCIA) >= TRUNC(SYSDATE))) LOOP
        BEGIN
          SELECT SEQ_ASS_CUL_01.NEXTVAL
          INTO v_ass_cul_id
          FROM DUAL;
          INSERT INTO TB_ASS_CUL_CONV_UNI_LOCATEND
          (ASS_CUL_ID,
          ASS_CUL_DT_INI_VIGENCIA,
          ASS_CUL_DS_MOTIVO_FIM_VIGENCIA,
          ASS_CUL_DT_ULTIMA_ATUALIZACAO,
          CAD_LAT_ID_LOCAL_ATENDIMENTO,
          ASS_CUL_DT_FIM_VIGENCIA,
          SEG_USU_ID_USUARIO,
          ASS_CNU_ID)
          VALUES
          (v_ass_cul_id,
          pDATAINICIAL,
          CUL.ASS_CUL_DS_MOTIVO_FIM_VIGENCIA,
          SYSDATE,
          CUL.CAD_LAT_ID_LOCAL_ATENDIMENTO,
          CUL.ASS_CUL_DT_FIM_VIGENCIA,
          CUL.SEG_USU_ID_USUARIO,
          v_ass_cnu_id);
          -- LOOP ASSOCIACAO CONVENIO X UNIDADE X LOCAL X PLANO
          FOR CLP IN (
          SELECT ASS_CLP_ID,
          ASS_CUL_ID,
          ASS_CLP_DT_INI_VIGENCIA,
          ASS_CLP_DT_FIM_VIGENCIA,
          CAD_PLA_ID_PLANO,
          ASS_CLP_DT_ULTIMA_ATUALIZACAO,
          SEG_USU_ID_USUARIO,
          ASS_CLP_FL_BLOQUEIA_UNIDADE_OK
          FROM TB_ASS_CLP_CNV_UND_LOC_PLANO
          WHERE ASS_CUL_ID = CUL.ASS_CUL_ID
          AND (ASS_CLP_DT_FIM_VIGENCIA IS NULL OR TRUNC(ASS_CLP_DT_FIM_VIGENCIA) >= TRUNC(SYSDATE))) LOOP
            BEGIN
              SELECT SEQ_ASS_CLP_01.NEXTVAL
              INTO   v_ass_clp_id
              FROM   DUAL;
              INSERT INTO TB_ASS_CLP_CNV_UND_LOC_PLANO
              (ASS_CLP_ID,
              ASS_CUL_ID,
              ASS_CLP_DT_INI_VIGENCIA,
              ASS_CLP_DT_FIM_VIGENCIA,
              CAD_PLA_ID_PLANO,
              ASS_CLP_DT_ULTIMA_ATUALIZACAO,
              SEG_USU_ID_USUARIO,
              ASS_CLP_FL_BLOQUEIA_UNIDADE_OK)
              VALUES
              (v_ass_clp_id,
              v_ass_cul_id,
              pDATAINICIAL,
              CLP.ASS_CLP_DT_FIM_VIGENCIA,
              CLP.CAD_PLA_ID_PLANO,
              SYSDATE,
              CLP.SEG_USU_ID_USUARIO,
              CLP.ASS_CLP_FL_BLOQUEIA_UNIDADE_OK);
              EXCEPTION 
              WHEN DUP_VAL_ON_INDEX THEN
                   NULL;
              WHEN NO_DATA_FOUND THEN
                   NULL;
            END;
          END LOOP;
          -- LOOP ASSOCIACAO CONVENIO X DIAS DE RETORNO
          FOR CDR IN (
          SELECT ASS_CDR_ID_DIA_RETORNO,
          ASS_CDR_FL_ESPECIALIDADE_OK,
          ASS_CDR_FL_UNIDADE_OK,
          ASS_CDR_FL_PROFISSIONAL_OK,
          ASS_CDR_QT_DIAS,
          ASS_CDR_DT_ULTIMA_ATUALIZACAO,
          SEG_USU_ID_USUARIO,
          ASS_CUL_ID
          FROM TB_ASS_CDR_DIA_RETORNO
          WHERE ASS_CUL_ID = CUL.ASS_CUL_ID) LOOP
            BEGIN
              SELECT SEQ_CDR_DIAS_RETORNO_01.NEXTVAL
              INTO   v_ass_cdr_id_dia_retorno
              FROM   DUAL;
              INSERT INTO TB_ASS_CDR_DIA_RETORNO
              (ASS_CDR_ID_DIA_RETORNO,
              ASS_CDR_FL_ESPECIALIDADE_OK,
              ASS_CDR_FL_UNIDADE_OK,
              ASS_CDR_FL_PROFISSIONAL_OK,
              ASS_CDR_QT_DIAS,
              ASS_CDR_DT_ULTIMA_ATUALIZACAO,
              SEG_USU_ID_USUARIO,
              ASS_CUL_ID)
              VALUES
              (v_ass_cdr_id_dia_retorno,
              CDR.ASS_CDR_FL_ESPECIALIDADE_OK,
              CDR.ASS_CDR_FL_UNIDADE_OK,
              CDR.ASS_CDR_FL_PROFISSIONAL_OK,
              CDR.ASS_CDR_QT_DIAS,
              CDR.ASS_CDR_DT_ULTIMA_ATUALIZACAO,
              CDR.SEG_USU_ID_USUARIO,
              v_ass_cul_id);
              EXCEPTION
              WHEN DUP_VAL_ON_INDEX THEN
                   NULL;
              WHEN NO_DATA_FOUND THEN
                   NULL;
            END;
          END LOOP;
          EXCEPTION
          WHEN DUP_VAL_ON_INDEX THEN
               NULL;
          WHEN NO_DATA_FOUND THEN
               NULL;
        END;
      END LOOP;
      EXCEPTION
      WHEN DUP_VAL_ON_INDEX THEN
           NULL;
      WHEN NO_DATA_FOUND THEN
           NULL;
    END;
  END LOOP;
  COMMIT;
end PRC_CAD_CNV_PLA_COPIA_ASSOC;