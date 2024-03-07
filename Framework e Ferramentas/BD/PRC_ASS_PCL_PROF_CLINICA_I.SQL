create or replace procedure PRC_ASS_PCL_PROF_CLINICA_I
  (
     pNewIdt OUT integer,
    -- pASS_PCL_ID IN TB_ASS_PCL_PROF_CLINICA.ASS_PCL_ID%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_PCL_PROF_CLINICA.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_PCL_PROF_CLINICA.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_PCL_PROF_CLINICA.CAD_PRO_ID_PROFISSIONAL%type,
     pCAD_CLC_ID IN TB_ASS_PCL_PROF_CLINICA.CAD_CLC_ID%type,
     pASS_PCL_DT_INI_VIGENCIA IN TB_ASS_PCL_PROF_CLINICA.ASS_PCL_DT_INI_VIGENCIA%type,
     pASS_PCL_DT_FIM_VIGENCIA IN TB_ASS_PCL_PROF_CLINICA.ASS_PCL_DT_FIM_VIGENCIA%type default NULL,
     pASS_PCL_DT_ULTIMA_ATUALIZACAO IN TB_ASS_PCL_PROF_CLINICA.ASS_PCL_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_PCL_PROF_CLINICA.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PCL_PROF_CLINICA_I
  *
  *    Data Criacao:   22/09/2008   Por: Pedro H. A. de Carvalho
  *    Data Alteracao:  24/10/2009  Por: Pedro
  *
  *    Alteração: alteração na validação de associação ja existente
  *
  *******************************************************************/
   lIdtRetorno integer;
 nCount integer;

  begin

    SELECT COUNT(*)
    INTO   nCount
    FROM   TB_ASS_PCL_PROF_CLINICA PCL
    WHERE  PCL.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND    PCL.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND    PCL.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL
    AND    PCL.CAD_CLC_ID = pCAD_CLC_ID
   AND    ((pASS_PCL_DT_INI_VIGENCIA >=  PCL.ASS_PCL_DT_INI_VIGENCIA AND PCL.ASS_PCL_DT_FIM_VIGENCIA IS NULL)
    OR     (pASS_PCL_DT_INI_VIGENCIA BETWEEN  PCL.ASS_PCL_DT_INI_VIGENCIA AND PCL.ASS_PCL_DT_FIM_VIGENCIA));
 
  
    IF nCount > 0 THEN
       raise_application_error (-20000, 'Clínica já associada para este profissional nesse período!');
    END IF;


    SELECT SEQ_ASS_PCL_01.NextVal INTO lIdtRetorno FROM DUAL;


    INSERT INTO TB_ASS_PCL_PROF_CLINICA
    (
       ASS_PCL_ID,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_PRO_ID_PROFISSIONAL,
       CAD_CLC_ID,
       ASS_PCL_DT_INI_VIGENCIA,
       ASS_PCL_DT_FIM_VIGENCIA,
       ASS_PCL_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
       lIdtRetorno,
       pCAD_UNI_ID_UNIDADE,
       pCAD_LAT_ID_LOCAL_ATENDIMENTO,
       pCAD_PRO_ID_PROFISSIONAL,
       pCAD_CLC_ID,
       pASS_PCL_DT_INI_VIGENCIA,
       pASS_PCL_DT_FIM_VIGENCIA,
       pASS_PCL_DT_ULTIMA_ATUALIZACAO,
       pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;

  end PRC_ASS_PCL_PROF_CLINICA_I;

/
