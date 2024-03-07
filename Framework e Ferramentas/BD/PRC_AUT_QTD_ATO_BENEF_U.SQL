

  --PRC_AUT_QTD_ATO_BENEF_U
  create or replace procedure PRC_AUT_QTD_ATO_BENEF_U
  (
     pCODCON IN TB_AUT_QTD_ATO_BENEF.CODCON%type,
     pCODEST IN TB_AUT_QTD_ATO_BENEF.CODEST%type,
     pCODBEN IN TB_AUT_QTD_ATO_BENEF.CODBEN%type,
     pCODSEQBEN IN TB_AUT_QTD_ATO_BENEF.CODSEQBEN%type,
     pTP_ATENDIMENTO IN TB_AUT_QTD_ATO_BENEF.TP_ATENDIMENTO%type,
     pCODATOMED IN TB_AUT_QTD_ATO_BENEF.CODATOMED%type,
     pQTD_UTILIZADA IN TB_AUT_QTD_ATO_BENEF.QTD_UTILIZADA%type default NULL,
     pDT_INI_UTILIZACAO IN TB_AUT_QTD_ATO_BENEF.DT_INI_UTILIZACAO%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_QTD_ATO_BENEF_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_QTD_ATO_BENEF
    SET	   
        QTD_UTILIZADA = pQTD_UTILIZADA,
        DT_INI_UTILIZACAO = pDT_INI_UTILIZACAO 
    WHERE
        CODATOMED = pCODATOMED
    AND CODBEN = pCODBEN
    AND CODCON = pCODCON
    AND CODEST = pCODEST
    AND CODSEQBEN = pCODSEQBEN
    AND TP_ATENDIMENTO = pTP_ATENDIMENTO;	
  end PRC_AUT_QTD_ATO_BENEF_U;

