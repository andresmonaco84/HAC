  --PRC_CAD_TPACOMOD_ACS_SID
  create or replace procedure PRC_CAD_TPACOMOD_ACS_SID 
  (
     pCAD_TAA_CD_TP_ACOMODACAO_ACS IN TB_CAD_TAA_TIPO_ACOMODACAO_ACS.CAD_TAA_CD_TIPO_ACOMODACAO_ACS%type,
     pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_CAD_TAA_TIPO_ACOMODACAO_ACS.TIS_TAC_CD_TIPO_ACOMODACAO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_TPACOMOD_ACS_SID
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CAD_TAA_CD_TIPO_ACOMODACAO_ACS,
       CAD_TAA_DS_TIPO_ACOMODACAO_ACS,
       TIS_TAC_CD_TIPO_ACOMODACAO
    FROM TB_CAD_TAA_TIPO_ACOMODACAO_ACS
    WHERE
        CAD_TAA_CD_TIPO_ACOMODACAO_ACS = pCAD_TAA_CD_TP_ACOMODACAO_ACS
    AND TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO;          
    io_cursor := v_cursor;
  end PRC_CAD_TPACOMOD_ACS_SID;
