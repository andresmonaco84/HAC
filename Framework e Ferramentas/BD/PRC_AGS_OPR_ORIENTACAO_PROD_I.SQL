create or replace procedure PRC_AGS_OPR_ORIENTACAO_PROD_I
  (
     pNewIdt OUT integer,
    -- pAGS_OPR_ID IN TB_AGS_OPR_ORIENTACAO_PROD.AGS_OPR_ID%TYPE default null,
     pAGS_ORS_ID IN TB_AGS_OPR_ORIENTACAO_PROD.AGS_ORS_ID%type default NULL,
     pAGS_OPR_DT_ULTIMA_ATUALIZACAO IN TB_AGS_OPR_ORIENTACAO_PROD.AGS_OPR_DT_ULTIMA_ATUALIZACAO%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_AGS_OPR_ORIENTACAO_PROD.SEG_USU_ID_USUARIO%type default NULL,
     pCAD_PRD_ID IN TB_AGS_OPR_ORIENTACAO_PROD.CAD_PRD_ID%type default NULL,
     pAGS_OPR_FL_STATUS IN TB_AGS_OPR_ORIENTACAO_PROD.AGS_OPR_FL_STATUS%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_OPR_ORIENTACAO_PROD_I
  *
  *    Data Criacao:   29/09/2008   Por: Pedro Henrique A. de Carvalho
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
    lIdtRetorno integer;
nCount integer;
  begin
 
    SELECT COUNT(*)
    INTO   nCount
    FROM   TB_AGS_OPR_ORIENTACAO_PROD OPR
    WHERE  OPR.AGS_ORS_ID = pAGS_ORS_ID
    AND    OPR.CAD_PRD_ID = pCAD_PRD_ID
    ;

    IF nCount > 0 THEN
       raise_application_error (-20000, 'Orientação já associada para este procedimento!');
    END IF;
  
  
  
    SELECT SEQ_AGS_OPR_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_AGS_OPR_ORIENTACAO_PROD
    (
       AGS_OPR_ID,
       AGS_ORS_ID,
       AGS_OPR_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PRD_ID,
       AGS_OPR_FL_STATUS
    )
    VALUES
    (
       lIdtRetorno,
       pAGS_ORS_ID,
       pAGS_OPR_DT_ULTIMA_ATUALIZACAO,
       pSEG_USU_ID_USUARIO,
       pCAD_PRD_ID,
       pAGS_OPR_FL_STATUS
    );
    pNewIdt := lIdtRetorno;
  end PRC_AGS_OPR_ORIENTACAO_PROD_I;
