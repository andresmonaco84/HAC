create or replace procedure PRC_ASS_CDR_DIA_RETORNO_I
  (
     pNewIdt OUT integer,
     pASS_CDR_ID_DIA_RETORNO IN TB_ASS_CDR_DIA_RETORNO.ASS_CDR_ID_DIA_RETORNO%type default NULL,
     pASS_CDR_FL_ESPECIALIDADE_OK IN TB_ASS_CDR_DIA_RETORNO.ASS_CDR_FL_ESPECIALIDADE_OK%type,
     pASS_CDR_FL_UNIDADE_OK IN TB_ASS_CDR_DIA_RETORNO.ASS_CDR_FL_UNIDADE_OK%type,
     pASS_CDR_FL_PROFISSIONAL_OK IN TB_ASS_CDR_DIA_RETORNO.ASS_CDR_FL_PROFISSIONAL_OK%type,
     pASS_CDR_QT_DIAS IN TB_ASS_CDR_DIA_RETORNO.ASS_CDR_QT_DIAS%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_CDR_DIA_RETORNO.SEG_USU_ID_USUARIO%type,
     pASS_CUL_ID IN TB_ASS_CDR_DIA_RETORNO.ASS_CUL_ID%type default NULL,
     pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE DEFAULT NULL,
     pASS_CDR_FL_LOCAL_OK IN TB_ASS_CDR_DIA_RETORNO.ASS_CDR_FL_LOCAL_OK%TYPE
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CDR_DIA_RETORNO_I
  * 
  *    Data Criacao: 	data da  criac?o   Por: Ricardo
  *    Data Alteracao: 12/07/2007	 Por: Ricardo
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	lIdtRetorno integer;	  
  nCount      integer;
  begin
  nCount := 0;
    SELECT COUNT(*) 
    INTO   nCount
    FROM   TB_ASS_CDR_DIA_RETORNO
    WHERE  ASS_CUL_ID = pASS_CUL_ID;
    IF nCount > 0 then
       raise_application_error (-20000, 'Ja existe Associac?o para este Convenio e Unidade');
    END IF;
    SELECT SEQ_CDR_DIAS_RETORNO_01.NextVal INTO lIdtRetorno FROM DUAL;
    INSERT INTO TB_ASS_CDR_DIA_RETORNO
    (
       ASS_CDR_ID_DIA_RETORNO,
       ASS_CDR_FL_ESPECIALIDADE_OK,
       ASS_CDR_FL_UNIDADE_OK,
       ASS_CDR_FL_PROFISSIONAL_OK,
       ASS_CDR_QT_DIAS,
       ASS_CDR_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ASS_CUL_ID,
       TIS_CBO_CD_CBOS,
       ASS_CDR_FL_LOCAL_OK
    )
    VALUES
    (
	     lIdtRetorno,
	     pASS_CDR_FL_ESPECIALIDADE_OK,
	     pASS_CDR_FL_UNIDADE_OK,
	     pASS_CDR_FL_PROFISSIONAL_OK,
	     pASS_CDR_QT_DIAS,
       SYSDATE,
	     pSEG_USU_ID_USUARIO,
	     pASS_CUL_ID,
       pTIS_CBO_CD_CBOS,
       pASS_CDR_FL_LOCAL_OK
    );
	pNewIdt := lIdtRetorno;
  end PRC_ASS_CDR_DIA_RETORNO_I;
