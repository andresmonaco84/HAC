

  --PRC_AUT_QTD_ATO_BENEF_I
  create or replace procedure PRC_AUT_QTD_ATO_BENEF_I
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
  *    Procedure: PRC_AUT_QTD_ATO_BENEF_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_QTD_ATO_BENEF
    (
       CODCON,
       CODEST,
       CODBEN,
       CODSEQBEN,
       TP_ATENDIMENTO,
       CODATOMED,
       QTD_UTILIZADA,
       DT_INI_UTILIZACAO
    )
    VALUES
    (
	     pCODCON,
	     pCODEST,
	     pCODBEN,
	     pCODSEQBEN,
	     pTP_ATENDIMENTO,
	     pCODATOMED,
	     pQTD_UTILIZADA,
	     pDT_INI_UTILIZACAO
    );
	
  end PRC_AUT_QTD_ATO_BENEF_I;

