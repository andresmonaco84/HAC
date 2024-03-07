  create or replace procedure PRC_SEG_MOD_MODULO_I 
  (
     pNewIdt OUT integer,
     pSEG_MOD_ID_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_ID_MODULO%type default NULL,
     pSEG_MOD_NM_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_NM_MODULO%type,
     pSEG_MOD_DS_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_DS_MODULO%type,
     pSEG_MOD_CD_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_CD_MODULO%type,
     pSEG_MOD_DS_SISTEMA IN TB_SEG_MOD_MODULO.SEG_MOD_DS_SISTEMA%type,
     pSEG_MOD_DS_VERSAO IN TB_SEG_MOD_MODULO.SEG_MOD_DS_VERSAO%type default NULL,
     pSEG_MOD_DT_VERSAO IN TB_SEG_MOD_MODULO.SEG_MOD_DT_VERSAO%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_MOD_MODULO_I
  * 
  *    Data Criacao: 	01/03/2007             Por: Carlos Eduardo
  *    Data Alteracao:  28/05/2007             Por: Silmara
  *    Alteracao: Foi alterado os parametros para gravar em maiusculo
  *    Funcao: Inclui um Módulos do sistema
  *
  *******************************************************************/                           
  lIdtRetorno integer;	  
  begin
    SELECT SEQ_SEG_MOD_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_SEG_MOD_MODULO
    (
       SEG_MOD_ID_MODULO,
       SEG_MOD_NM_MODULO,
       SEG_MOD_DS_MODULO,
       SEG_MOD_CD_MODULO,
       SEG_MOD_DS_SISTEMA,
       SEG_MOD_DS_VERSAO,
       SEG_MOD_DT_VERSAO
    )
    VALUES
    (
	     lIdtRetorno,
	     UPPER(pSEG_MOD_NM_MODULO),
	     UPPER(pSEG_MOD_DS_MODULO),
	     UPPER(pSEG_MOD_CD_MODULO),
	     UPPER(pSEG_MOD_DS_SISTEMA),
	     UPPER(pSEG_MOD_DS_VERSAO),
	     pSEG_MOD_DT_VERSAO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_SEG_MOD_MODULO_I;
/
