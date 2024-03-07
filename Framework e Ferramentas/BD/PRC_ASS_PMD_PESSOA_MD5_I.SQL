  create or replace procedure PRC_ASS_PMD_PESSOA_MD5_I
  (
     pNewIdt OUT integer,
     pASS_PMD_ID IN TB_ASS_PMD_PESSOA_MD5.ASS_PMD_ID%type default NULL,
     pASS_PMD_CD_MD5 IN TB_ASS_PMD_PESSOA_MD5.ASS_PMD_CD_MD5%type,
     pCAD_PES_ID_PESSOA IN TB_ASS_PMD_PESSOA_MD5.CAD_PES_ID_PESSOA%type,
     pASS_PMD_NM_PESSOA IN TB_ASS_PMD_PESSOA_MD5.ASS_PMD_NM_PESSOA%type default NULL,
     pASS_PMD_DT_NASCIMENTO IN TB_ASS_PMD_PESSOA_MD5.ASS_PMD_DT_NASCIMENTO%type default NULL,
     pASS_PMD_TP_SEXO IN TB_ASS_PMD_PESSOA_MD5.ASS_PMD_TP_SEXO%type default NULL,
     pASS_PMD_DT_CRIACAO IN TB_ASS_PMD_PESSOA_MD5.ASS_PMD_DT_CRIACAO%type default NULL,
     pASS_PMD_DT_DESATIVACAO IN TB_ASS_PMD_PESSOA_MD5.ASS_PMD_DT_DESATIVACAO%type default NULL,
     pSEG_USU_ID_USUARIO_CRIACAO IN TB_ASS_PMD_PESSOA_MD5.SEG_USU_ID_USUARIO_CRIACAO%type default NULL,
     pSEG_USU_ID_USUARIO_DESATIV IN TB_ASS_PMD_PESSOA_MD5.SEG_USU_ID_USUARIO_DESATIVACAO%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PMD_PESSOA_MD5_I
  * 
  *    Data Criacao: 	data da criacao   Por: Nome do Analista
  *    Funcao: Descricao da funcionalidade da Stored Procedure

  *    Data Alteracao:  12/11/2010  Por: Fabiola Lopes
  *    Alteracao: Coloquei um trunc na data de nascimento para evitar de gravar a hora
  *
  *    Data Alteracao:
  *    Alteracao:
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_ASS_PMD_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_ASS_PMD_PESSOA_MD5
    (
       ASS_PMD_ID,
       ASS_PMD_CD_MD5,
       CAD_PES_ID_PESSOA,
       ASS_PMD_NM_PESSOA,
       ASS_PMD_DT_NASCIMENTO,
       ASS_PMD_TP_SEXO,
       ASS_PMD_DT_CRIACAO,
       ASS_PMD_DT_DESATIVACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       SEG_USU_ID_USUARIO_DESATIVACAO
    )
    VALUES
    (
       lIdtRetorno,
	     pASS_PMD_CD_MD5,
	     pCAD_PES_ID_PESSOA,
	     pASS_PMD_NM_PESSOA,
	     TRUNC(pASS_PMD_DT_NASCIMENTO),
	     pASS_PMD_TP_SEXO,
	     pASS_PMD_DT_CRIACAO,
	     pASS_PMD_DT_DESATIVACAO,
	     pSEG_USU_ID_USUARIO_CRIACAO,
	     pSEG_USU_ID_USUARIO_DESATIV
    );
    pNewIdt := lIdtRetorno;	
  end PRC_ASS_PMD_PESSOA_MD5_I;
