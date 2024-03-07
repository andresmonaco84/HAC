

  --PRC_AGS_EHR_ESCALA_HOR_RESERVA_D
  create or replace procedure PRC_AGS_EHR_ESM_HOR_RESERVA_D 
  (
     pAGS_EHR_ID IN TB_AGS_EHR_ESCALA_HOR_RESERVA.AGS_EHR_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_EHR_ESCALA_HOR_RESERVA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AGS_EHR_ESCALA_HOR_RESERVA
    WHERE  
        AGS_EHR_ID = pAGS_EHR_ID;	   
  end PRC_AGS_EHR_ESM_HOR_RESERVA_D;
