create or replace procedure PRC_ASS_PRP_PROF_PROC_I
  (
     pNewIdt OUT integer,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_UNI_ID_UNIDADE%type default NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default NULL,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_PRO_ID_PROFISSIONAL%type default NULL,
     pCAD_PRD_ID IN TB_ASS_PRP_PROFISSIONAL_PROD.CAD_PRD_ID%type default NULL, 
     pASS_PRP_FL_ATIVO_OK IN TB_ASS_PRP_PROFISSIONAL_PROD.ASS_PRP_FL_ATIVO_OK%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_ASS_PRP_PROFISSIONAL_PROD.SEG_USU_ID_USUARIO%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PRP_PROF_PROC_I
  * 
  *    Data Criacao: 	18/08/2008           Por: Davi Silvestre M. dos Reis
  *
  *    Data Alteracao:	15/09/2008         Por: Andrea Cazuca
  *    Alteracao:  Incluido verificacao se o registro já foi cadastrado
  *
  *    Funcao: Insercao de registros na tabela TB_ASS_PRP_PROFISSIONAL_PROD
  *
  *******************************************************************/  
  lIdtRetorno integer;
  nCount integer;
  
  begin
  
    SELECT COUNT(*)
    INTO   nCount
    FROM   TB_ASS_PRP_PROFISSIONAL_PROD PRP
    WHERE  PRP.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND    PRP.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND    PRP.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL
    AND    PRP.CAD_PRD_ID = pCAD_PRD_ID;
    
    IF nCount > 0 THEN
       raise_application_error (-20000, 'Procedimento já associado para este profissional');
    END IF;
	    
    SELECT SEQ_ASS_PRP_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_ASS_PRP_PROFISSIONAL_PROD
    (
       ASS_PRP_ID,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_PRO_ID_PROFISSIONAL,
       CAD_PRD_ID,
       ASS_PRP_FL_ATIVO_OK,
       SEG_USU_ID_USUARIO,
       ASS_PRP_DT_ULTIMA_ATUALIZACAO
    )
    VALUES
    (
       lIdtRetorno,
	     pCAD_UNI_ID_UNIDADE,
	     pCAD_LAT_ID_LOCAL_ATENDIMENTO,
	     pCAD_PRO_ID_PROFISSIONAL,
	     pCAD_PRD_ID,
	     pASS_PRP_FL_ATIVO_OK,
	     pSEG_USU_ID_USUARIO,
	     SYSDATE
    );

  pNewIdt := lIdtRetorno;

  end PRC_ASS_PRP_PROF_PROC_I;
  
/
