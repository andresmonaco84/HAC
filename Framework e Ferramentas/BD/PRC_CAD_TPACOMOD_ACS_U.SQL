  --PRC_CAD_TPACOMOD_ACS_U
  create or replace procedure PRC_CAD_TPACOMOD_ACS_U
  (
     pCAD_TAA_CD_TP_ACOMODACAO_ACS IN TB_CAD_TAA_TIPO_ACOMODACAO_ACS.CAD_TAA_CD_TIPO_ACOMODACAO_ACS%type,
     pCAD_TAA_DS_TP_ACOMODACAO_ACS IN TB_CAD_TAA_TIPO_ACOMODACAO_ACS.CAD_TAA_DS_TIPO_ACOMODACAO_ACS%type default NULL,
     pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_CAD_TAA_TIPO_ACOMODACAO_ACS.TIS_TAC_CD_TIPO_ACOMODACAO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TPACOMOD_ACS_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_CAD_TAA_TIPO_ACOMODACAO_ACS
    SET	   
        CAD_TAA_DS_TIPO_ACOMODACAO_ACS = pCAD_TAA_DS_TP_ACOMODACAO_ACS 
    WHERE
        CAD_TAA_CD_TIPO_ACOMODACAO_ACS = pCAD_TAA_CD_TP_ACOMODACAO_ACS
    AND TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO;	
  end PRC_CAD_TPACOMOD_ACS_U;

