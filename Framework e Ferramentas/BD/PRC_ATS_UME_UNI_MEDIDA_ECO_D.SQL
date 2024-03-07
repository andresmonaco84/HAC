

  --PRC_ATS_UME_UNI_MEDIDA_ECOCAR_D
  create or replace procedure PRC_ATS_UME_UNI_MEDIDA_ECO_D 
  (
     pATS_UME_CD_ECOCARDIO IN TB_ATS_UME_UNI_MEDIDA_ECOCAR.ATS_UME_CD_ECOCARDIO%type,
     pATS_UME_CD_UNID_MEDIDA IN TB_ATS_UME_UNI_MEDIDA_ECOCAR.ATS_UME_CD_UNID_MEDIDA%type,
     pATS_UME_TP_UNID_MEDIDA IN TB_ATS_UME_UNI_MEDIDA_ECOCAR.ATS_UME_TP_UNID_MEDIDA%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_UME_UNI_MEDIDA_ECOCAR_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATS_UME_UNI_MEDIDA_ECOCAR
    WHERE  
        ATS_UME_CD_ECOCARDIO = pATS_UME_CD_ECOCARDIO
    AND ATS_UME_CD_UNID_MEDIDA = pATS_UME_CD_UNID_MEDIDA
    AND ATS_UME_TP_UNID_MEDIDA = pATS_UME_TP_UNID_MEDIDA;	   
  end PRC_ATS_UME_UNI_MEDIDA_ECO_D;
