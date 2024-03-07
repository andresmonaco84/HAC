

  --PRC_ATS_APE_ATEN_PROCED_ECOCAR_D
  create or replace procedure PRC_ATS_APE_ATEN_PROC_ECOCAR_D 
  (
     pATS_APE_ID IN TB_ATS_APE_ATEN_PROCED_ECOCAR.ATS_APE_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_APE_ATEN_PROCED_ECOCAR_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATS_APE_ATEN_PROCED_ECOCAR
    WHERE  
        ATS_APE_ID = pATS_APE_ID;	   
  end PRC_ATS_APE_ATEN_PROC_ECOCAR_D;
