create or replace procedure PRC_FAT_KMM_KIT_MAT_MED_U
  (
     pFAT_KMM_ID IN TB_FAT_KMM_KIT_MAT_MED.FAT_KMM_ID%type,
     pCAD_PRD_ID_KIT IN TB_FAT_KMM_KIT_MAT_MED.CAD_PRD_ID_KIT%type,
     pFAT_KMM_DT_INI_VIGENCIA IN TB_FAT_KMM_KIT_MAT_MED.FAT_KMM_DT_INI_VIGENCIA%type,
     pFAT_KMM_DT_FIM_VIGENCIA IN TB_FAT_KMM_KIT_MAT_MED.FAT_KMM_DT_FIM_VIGENCIA%type default NULL,
     pFAT_KMM_FL_STATUS IN TB_FAT_KMM_KIT_MAT_MED.FAT_KMM_FL_STATUS%type,
     pCAD_PRD_ID_ITEM IN TB_FAT_KMM_KIT_MAT_MED.CAD_PRD_ID_ITEM%type,
     pFAT_KMM_QT_ITEM IN TB_FAT_KMM_KIT_MAT_MED.FAT_KMM_QT_ITEM%type,
     pSEG_USU_ID_USUARIO IN TB_FAT_KMM_KIT_MAT_MED.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_KMM_KIT_MAT_MED_U
  *
  *    Data Criacao: 	14/01/2010   Por: André Souza Monaco
  *    Data Alteracao:	--  Por: --
  *
  *    Funcao: Atualização de kit de mat/med
  *
  *******************************************************************/
  begin
    UPDATE TB_FAT_KMM_KIT_MAT_MED
    SET
        FAT_KMM_DT_INI_VIGENCIA = pFAT_KMM_DT_INI_VIGENCIA,
        FAT_KMM_DT_FIM_VIGENCIA = pFAT_KMM_DT_FIM_VIGENCIA,
        FAT_KMM_FL_STATUS = pFAT_KMM_FL_STATUS,
        --CAD_PRD_ID_ITEM = pCAD_PRD_ID_ITEM,
        --FAT_KMM_QT_ITEM = pFAT_KMM_QT_ITEM,
        FAT_KMM_DT_ULTIMA_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
    WHERE
        CAD_PRD_ID_KIT = pCAD_PRD_ID_KIT;
  end PRC_FAT_KMM_KIT_MAT_MED_U;
