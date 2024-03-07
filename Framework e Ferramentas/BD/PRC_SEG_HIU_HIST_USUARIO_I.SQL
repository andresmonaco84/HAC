  create or replace procedure PRC_SEG_HIU_HIST_USUARIO_I
  (
     pNewIdt OUT integer,
     pSEG_MOD_ID_MODULO IN TB_SEG_HIU_HISTORICO_USUARIO.SEG_MOD_ID_MODULO%type,
     pSEG_FUN_ID_FUNCIONALIDADE IN TB_SEG_HIU_HISTORICO_USUARIO.SEG_FUN_ID_FUNCIONALIDADE%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_HIU_HISTORICO_USUARIO.SEG_USU_ID_USUARIO%type,
     pSEG_HIU_HR_ATUALIZACAO IN TB_SEG_HIU_HISTORICO_USUARIO.SEG_HIU_HR_ATUALIZACAO%type,
     pSEG_HIU_DS_COMPLEMENTO IN TB_SEG_HIU_HISTORICO_USUARIO.SEG_HIU_DS_COMPLEMENTO%type,
     pCAD_SET_ID IN TB_SEG_HIU_HISTORICO_USUARIO.CAD_SET_ID%type default NULL,
     PATD_ATE_ID IN TB_SEG_HIU_HISTORICO_USUARIO.ATD_ATE_ID%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_HIU_HIST_USUARIO_I
  * 
  *    Data Criacao: 	12/02/2008   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Insere dados do Historico de Atendimento
  *
  *******************************************************************/  
    lIdtRetorno integer;
	  
  begin
    SELECT SEQ_SEG_HIU_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
    INSERT INTO TB_SEG_HIU_HISTORICO_USUARIO
    (
       SEG_HIU_ID,
       SEG_MOD_ID_MODULO,
       SEG_FUN_ID_FUNCIONALIDADE,
       SEG_USU_ID_USUARIO,
       SEG_HIU_DT_ATUALIZACAO,
       SEG_HIU_HR_ATUALIZACAO,
       SEG_HIU_DS_COMPLEMENTO,
       CAD_SET_ID,
       ATD_ATE_ID
    )
    VALUES
    (
	     lIdtRetorno,
	     pSEG_MOD_ID_MODULO,
	     pSEG_FUN_ID_FUNCIONALIDADE,
	     pSEG_USU_ID_USUARIO,
	     trunc(sysdate),
	     pSEG_HIU_HR_ATUALIZACAO,
	     pSEG_HIU_DS_COMPLEMENTO,
	     pCAD_SET_ID,
       PATD_ATE_ID
    );
    pNewIdt := lIdtRetorno;	
  end PRC_SEG_HIU_HIST_USUARIO_I;
/
