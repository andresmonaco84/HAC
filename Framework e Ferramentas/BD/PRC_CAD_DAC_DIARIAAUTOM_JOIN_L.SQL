create or replace procedure PRC_CAD_DAC_DIARIAAUTOM_JOIN_L
  (
     pCAD_DAC_ID IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_DAC_ID%type DEFAULT NULL,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_CNV_ID_CONVENIO%type DEFAULT NULL,
     pCAD_PLA_ID_PLANO IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_PLA_ID_PLANO%type DEFAULT NULL,
     pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_CAD_DAC_DIARIA_AUTOM_CNV.TIS_TAC_CD_TIPO_ACOMODACAO%type DEFAULT NULL,
     pCAD_PRD_ID IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_PRD_ID%type DEFAULT NULL,
     pCAD_SPL_ID IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_SPL_ID%type DEFAULT NULL,
     pCAD_SET_ID IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_SET_ID%type DEFAULT NULL,
     pCAD_DAC_DT_INICIO_VIGENCIA IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_DAC_DT_INICIO_VIGENCIA%type DEFAULT NULL,
     pCAD_DAC_DT_FIM_VIGENCIA IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_DAC_DT_FIM_VIGENCIA%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_DAC_DIARIA_AUTOM_CNV.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pCAD_DAC_DT_ULTIMA_ATUALIZACAO IN TB_CAD_DAC_DIARIA_AUTOM_CNV.CAD_DAC_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_DAC_DIARIAAUTOM_JOIN_L
  *
  *    Data Criacao:   data da  cria��o   Por: Nome do Analista
  *    Data Alteracao:  data da altera��o  Por: Nome do Analista
  *
  *    Funcao: Descri��o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
   SELECT DAC.CAD_DAC_ID,
       DAC.CAD_CNV_ID_CONVENIO,
       DAC.CAD_PLA_ID_PLANO,
       DAC.TIS_TAC_CD_TIPO_ACOMODACAO,
       DAC.CAD_PRD_ID,
       DAC.CAD_SPL_ID,
       DAC.CAD_SET_ID,
       DAC.CAD_DAC_DT_INICIO_VIGENCIA,
       DAC.CAD_DAC_DT_FIM_VIGENCIA,
       DAC.SEG_USU_ID_USUARIO,
       DAC.CAD_DAC_DT_ULTIMA_ATUALIZACAO,
       DAC.CAD_DAC_FL_CONSIDERAOBITO,
       DAC.CAD_DAC_HR_OBITO_MAIOR,

       PRD.CAD_PRD_CD_CODIGO,
       PRD.CAD_PRD_DS_DESCRICAO,

       TAC.TIS_TAC_DS_TIPO_ACOMODACAO,

       UNI.CAD_UNI_DS_UNIDADE,
       SETOR.CAD_SET_DS_SETOR,
       
       SPL.CAD_SPL_DS_SUB_PLANO,
       CNV.CAD_CNV_CD_HAC_PRESTADOR,
       PLA.CAD_PLA_CD_PLANO

  FROM TB_CAD_DAC_DIARIA_AUTOM_CNV DAC,
       TB_CAD_PRD_PRODUTO PRD,
       TB_TIS_TAC_TIPO_ACOMODACAO TAC,
       TB_CAD_SET_SETOR SETOR,
       TB_CAD_SPL_SUB_PLANO SPL,
       TB_CAD_CNV_CONVENIO CNV,
       TB_CAD_PLA_PLANO PLA,
       TB_CAD_UNI_UNIDADE UNI
 WHERE (pCAD_DAC_ID is null OR DAC.CAD_DAC_ID = pCAD_DAC_ID)
   AND (pCAD_CNV_ID_CONVENIO is null OR DAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
   AND (pCAD_PLA_ID_PLANO is null OR DAC.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
   AND (pTIS_TAC_CD_TIPO_ACOMODACAO is null OR DAC.TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO)
   AND (pCAD_PRD_ID is null OR DAC.CAD_PRD_ID = pCAD_PRD_ID)
   AND (pCAD_SPL_ID is null OR DAC.CAD_SPL_ID = pCAD_SPL_ID)
   AND (pCAD_SET_ID is null OR DAC.CAD_SET_ID = pCAD_SET_ID)
   AND (pCAD_DAC_DT_INICIO_VIGENCIA is null OR DAC.CAD_DAC_DT_INICIO_VIGENCIA = pCAD_DAC_DT_INICIO_VIGENCIA)
   AND (pCAD_DAC_DT_FIM_VIGENCIA is null OR DAC.CAD_DAC_DT_FIM_VIGENCIA = pCAD_DAC_DT_FIM_VIGENCIA)
   AND (pSEG_USU_ID_USUARIO is null OR DAC.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO)
   AND (pCAD_DAC_DT_ULTIMA_ATUALIZACAO is null OR DAC.CAD_DAC_DT_ULTIMA_ATUALIZACAO = pCAD_DAC_DT_ULTIMA_ATUALIZACAO)
   AND (DAC.CAD_PRD_ID = PRD.CAD_PRD_ID)
   AND (DAC.TIS_TAC_CD_TIPO_ACOMODACAO = TAC.TIS_TAC_CD_TIPO_ACOMODACAO)
   AND (DAC.CAD_SET_ID = SETOR.CAD_SET_ID(+))
   AND (DAC.CAD_SPL_ID = SPL.CAD_SPL_ID(+))
   AND (CNV.CAD_CNV_ID_CONVENIO = DAC.CAD_CNV_ID_CONVENIO)
   AND (PLA.CAD_PLA_ID_PLANO (+)= DAC.CAD_PLA_ID_PLANO)
   AND (SETOR.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE);
    io_cursor := v_cursor;
  end PRC_CAD_DAC_DIARIAAUTOM_JOIN_L;
