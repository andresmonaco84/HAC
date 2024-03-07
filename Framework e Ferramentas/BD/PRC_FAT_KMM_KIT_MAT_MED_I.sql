create or replace procedure PRC_FAT_KMM_KIT_MAT_MED_I
  (
     pNewIdt OUT integer,
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
  *    Procedure: PRC_FAT_KMM_KIT_MAT_MED_I
  *
  *    Data Criacao: 	Data Criacao: 	14/01/2010   Por: André Souza Monaco
  *    Data Alteracao:	--  Por: --
  *
  *    Funcao: Inserção de kit de mat/med
  *
  *******************************************************************/
  lIdtRetorno integer;
  begin
    SELECT SEQ_FAT_KMM_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_FAT_KMM_KIT_MAT_MED
    (
       FAT_KMM_ID,
       CAD_PRD_ID_KIT,
       FAT_KMM_DT_INI_VIGENCIA,
       FAT_KMM_DT_FIM_VIGENCIA,
       FAT_KMM_FL_STATUS,
       CAD_PRD_ID_ITEM,
       FAT_KMM_QT_ITEM,
       FAT_KMM_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
	     lIdtRetorno,
	     pCAD_PRD_ID_KIT,
	     pFAT_KMM_DT_INI_VIGENCIA,
	     pFAT_KMM_DT_FIM_VIGENCIA,
	     pFAT_KMM_FL_STATUS,
	     pCAD_PRD_ID_ITEM,
	     pFAT_KMM_QT_ITEM,
	     SYSDATE,
	     pSEG_USU_ID_USUARIO
    );
    
    pNewIdt := lIdtRetorno;	
  end PRC_FAT_KMM_KIT_MAT_MED_I;
