create or replace procedure PRC_CAD_FER_FERIADO_I
  (
     pNewIdt OUT integer,
     pCAD_FER_ID_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_ID_FERIADO%type default NULL,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_FER_FERIADO.CAD_UNI_ID_UNIDADE%type default NULL,
     pCAD_FER_DT_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_DT_FERIADO%type,
     pCAD_FER_DS_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_DS_FERIADO%type,
     pCAD_FER_TP_FERIADO IN TB_CAD_FER_FERIADO.CAD_FER_TP_FERIADO%type,	
     pSEG_USU_ID_USUARIO IN TB_CAD_FER_FERIADO.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_FER_FERIADO_I
  * 
  *    Data Criacao: 	26/06/2007   Por: Guilherme Holdack
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Funcao: Inserção de registro na tabela TB_CAD_FER_FERIADO
  *
  *	   Data Alteracao:	18/07/2007   Por: Fabiola Lopes
  *	   Alteração:	    Inclusão do UPPER na descricao do feriado
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_CAD_FER_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_CAD_FER_FERIADO
    (
        CAD_FER_ID_FERIADO,
        CAD_UNI_ID_UNIDADE,
        CAD_FER_DT_FERIADO,
        CAD_FER_DS_FERIADO,
        CAD_FER_TP_FERIADO,
        CAD_FER_DT_ULTIMA_ATUALIZACAO,
		SEG_USU_ID_USUARIO
    )
    VALUES
    (
	    lIdtRetorno,
	    pCAD_UNI_ID_UNIDADE,
	    pCAD_FER_DT_FERIADO,
        UPPER(pCAD_FER_DS_FERIADO),
	    pCAD_FER_TP_FERIADO,
        SYSDATE,
		pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_CAD_FER_FERIADO_I;
/
