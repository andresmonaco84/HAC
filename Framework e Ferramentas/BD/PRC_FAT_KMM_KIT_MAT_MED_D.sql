create or replace procedure PRC_FAT_KMM_KIT_MAT_MED_D
  (
     pFAT_KMM_ID IN TB_FAT_KMM_KIT_MAT_MED.FAT_KMM_ID%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_KMM_KIT_MAT_MED_D
  *
  *    Data Criacao: 	14/01/2010   Por: André Souza Monaco
  *    Data Alteracao:	--  Por: --
  *
  *    Funcao: Deleção de kit de mat/med
  *
  *******************************************************************/
  begin
    DELETE TB_FAT_KMM_KIT_MAT_MED
    WHERE
        FAT_KMM_ID = pFAT_KMM_ID;
  end PRC_FAT_KMM_KIT_MAT_MED_D;
