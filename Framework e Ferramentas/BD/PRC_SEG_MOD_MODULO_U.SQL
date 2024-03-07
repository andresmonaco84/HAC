  create or replace procedure PRC_SEG_MOD_MODULO_U 
  (
     pSEG_MOD_ID_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_ID_MODULO%type,
     pSEG_MOD_NM_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_NM_MODULO%type,
     pSEG_MOD_DS_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_DS_MODULO%type,
     pSEG_MOD_CD_MODULO IN TB_SEG_MOD_MODULO.SEG_MOD_CD_MODULO%type,
     pSEG_MOD_DS_SISTEMA IN TB_SEG_MOD_MODULO.SEG_MOD_DS_SISTEMA%type,
     pSEG_MOD_DS_VERSAO IN TB_SEG_MOD_MODULO.SEG_MOD_DS_VERSAO%type default NULL,
     pSEG_MOD_DT_VERSAO IN TB_SEG_MOD_MODULO.SEG_MOD_DT_VERSAO%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_MOD_MODULO_U
  * 
  *    Data Criacao: 	01/03/2007             Por: Carlos Eduardo
  *    Data Alteracao:  28/05/2007             Por: Silmara
  *    Alteracao:Foi alterado os parametros para gravar em maiusculo
  *    Funcao: Altera um Módulos do sistema
  *
  *******************************************************************/                             
  begin
    UPDATE TB_SEG_MOD_MODULO
    SET	   
        SEG_MOD_NM_MODULO = UPPER(pSEG_MOD_NM_MODULO),
        SEG_MOD_DS_MODULO = UPPER(pSEG_MOD_DS_MODULO),
        SEG_MOD_CD_MODULO = UPPER(pSEG_MOD_CD_MODULO),
        SEG_MOD_DS_SISTEMA = UPPER(pSEG_MOD_DS_SISTEMA),
        SEG_MOD_DS_VERSAO = UPPER(pSEG_MOD_DS_VERSAO),
        SEG_MOD_DT_VERSAO = pSEG_MOD_DT_VERSAO 
    WHERE
        SEG_MOD_ID_MODULO = pSEG_MOD_ID_MODULO;	
  end PRC_SEG_MOD_MODULO_U;
/
