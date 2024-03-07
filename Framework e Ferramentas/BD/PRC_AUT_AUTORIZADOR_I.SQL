
---fim


  --PRC_AUT_AUTORIZADOR_I
  create or replace procedure PRC_AUT_AUTORIZADOR_I
  (
     pNewIdt OUT integer,
     pCODCON IN TB_AUT_AUTORIZADOR.CODCON%type,
     pCODEST IN TB_AUT_AUTORIZADOR.CODEST%type,
     pCODBEN IN TB_AUT_AUTORIZADOR.CODBEN%type,
     pCODSEQBEN IN TB_AUT_AUTORIZADOR.CODSEQBEN%type,
     pCD_AUTORIZADOR IN TB_AUT_AUTORIZADOR.CD_AUTORIZADOR%type,
     pDT_AUTORIZACAO IN TB_AUT_AUTORIZADOR.DT_AUTORIZACAO%type default NULL,
     pCD_LOCAL_AUTORIZACAO IN TB_AUT_AUTORIZADOR.CD_LOCAL_AUTORIZACAO%type default NULL,
     pCODATOMED IN TB_AUT_AUTORIZADOR.CODATOMED%type default NULL,
     pCODESPMED IN TB_AUT_AUTORIZADOR.CODESPMED%type default NULL,
     pDS_RET_AUTORIZADOR IN TB_AUT_AUTORIZADOR.DS_RET_AUTORIZADOR%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_AUTORIZADOR_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  vSEQ NUMBER;
  begin

    SELECT SEQ_AUT_AUTORIZADOR.NEXTVAL INTO vSEQ FROM DUAL;
	    
    INSERT INTO TB_AUT_AUTORIZADOR
    (
       CODCON,
       CODEST,
       CODBEN,
       CODSEQBEN,
       CD_AUTORIZADOR,
       DT_AUTORIZACAO,
       CD_LOCAL_AUTORIZACAO,
       CODATOMED,
       CODESPMED,
       DS_RET_AUTORIZADOR
    )
    VALUES
    (
	     pCODCON,
	     pCODEST,
	     pCODBEN,
	     pCODSEQBEN,
	     vSEQ,
	     pDT_AUTORIZACAO,
	     pCD_LOCAL_AUTORIZACAO,
	     pCODATOMED,
	     pCODESPMED,
	     pDS_RET_AUTORIZADOR
    );
	
   pNewIdt := vSEQ;
	 
  end PRC_AUT_AUTORIZADOR_I;

