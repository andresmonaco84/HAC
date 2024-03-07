  --PRC_ASS_PLANO_CBOS_RMT_D
  create or replace procedure PRC_ASS_PLANO_CBOS_RMT_D 
  (
     pCAD_PLA_ID_PLANO IN TB_ASS_PLC_PLANO_CBOS.CAD_PLA_ID_PLANO%type,
     pTIS_CBO_CD_CBOS IN TB_ASS_PLC_PLANO_CBOS.TIS_CBO_CD_CBOS%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PLANO_CBOS_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_PLC_PLANO_CBOS
    WHERE  
        CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO
    AND TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS;	   
  end PRC_ASS_PLANO_CBOS_RMT_D;
